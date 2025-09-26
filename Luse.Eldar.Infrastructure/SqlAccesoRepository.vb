Imports System.Data.SqlClient
Imports Luse.Eldar.Domain

Public Class SqlAccesoRepository
    Implements IAccesoRepository

    Private ReadOnly _cs As String
    Public Sub New(connectionString As String)
        _cs = connectionString
    End Sub

    Public Function GetByTipoAndUser(tipo As Integer, usercode As String) _
    As IEnumerable(Of Acceso) Implements IAccesoRepository.GetByTipoAndUser

        Dim lista As New List(Of Acceso)()
        Using cn As New SqlConnection(_cs)
            Using cmd As New SqlCommand("
        SELECT Usercode, IDTipoAcceso
        FROM Acceso
        WHERE IDTipoAcceso = @tipo AND Usercode = @user;", cn)

                cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo
                cmd.Parameters.Add("@user", SqlDbType.VarChar, 50).Value =
          If(usercode, "").Trim().ToLowerInvariant()

                cn.Open()
                Using rd = cmd.ExecuteReader()
                    While rd.Read()
                        lista.Add(New Acceso With {
              .Id = 0,
              .Usercode = rd.GetString(0),
              .TipoAcceso = rd.GetInt32(1),
              .Habilitado = True
            })
                    End While
                End Using
            End Using
        End Using
        Return lista
    End Function

    Private Function IAccesoRepository_GetAccesoLogin(usercode As String, password As String, pass As String) As AccesoLogin Implements IAccesoRepository.GetAccesoLogin
        Dim lista As New List(Of AccesoLogin)()

        Using cn As New SqlConnection(_cs)
            Dim sql As String =
                "SELECT TOP 1
                ac.IDAcceso,
                ag.IDAgencia,
                ag.IDAgenciaSup,
                ag.Nombre,
                ag.UpgPos,
                ac.Activo,
                s.Cantidad  AS StockAgencia,
                ss.Cantidad AS StockAgenciaSube,
                ss.IDStockSube,
                ac.ClaveArecuperar,
                ac.RecuperarContrasena,
                ac.ChangePassword,
                ac.DateForExpirationPassword,
                ac.BloqueadoVenta,
                ac.IntentosFallidos
            FROM dbo.Agencia         AS ag
            JOIN dbo.AgenciaXUsers   AS axu ON axu.IDAgencia   = ag.IDAgencia
            JOIN dbo.Acceso          AS ac  ON ac.IDAcceso     = axu.IDUserAcceso
            LEFT JOIN dbo.StockSube  AS ss  ON ss.IDAgencia    = ag.IDAgencia 
            JOIN dbo.Stock           AS s   ON s.IDAgencia     = ag.IDAgencia 
            WHERE ac.IDTipoAcceso = 2 AND Usercode = @UserCode 
            AND (Password = @Password Or (ClaveArecuperar  <> '' and ClaveArecuperar = @pass));"

            Using cmd As New SqlCommand(sql, cn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@UserCode", SqlDbType.NVarChar).Value = usercode
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password
                cmd.Parameters.Add("@Pass", SqlDbType.NVarChar).Value = pass

                cn.Open()
                Using rd = cmd.ExecuteReader()

                    If rd.Read() Then
                        Return New AccesoLogin With {
                          .IDAcceso = If(rd.IsDBNull(0), 0, Convert.ToInt32(rd(0))),
                          .IDAgencia = If(rd.IsDBNull(1), 0, Convert.ToInt32(rd(1))),
                          .IDAgenciaSup = If(rd.IsDBNull(2), 0, Convert.ToInt32(rd(2))),
                          .Nombre = If(rd.IsDBNull(3), "", rd.GetString(3)),
                          .UpgPos = If(rd.IsDBNull(4), 0, Convert.ToInt32(rd(4))),
                          .Activo = If(rd.IsDBNull(5), False, Convert.ToBoolean(rd(5))),
                          .StockAgencia = If(rd.IsDBNull(6), 0D, Convert.ToDecimal(rd(6))),
                          .StockAgenciaSube = If(rd.IsDBNull(7), 0D, Convert.ToDecimal(rd(7))),
                          .IDStockSube = If(rd.IsDBNull(8), 0, Convert.ToInt32(rd(8))),
                          .ClaveArecuperar = If(rd.IsDBNull(9), "", rd.GetString(9)),
                          .RecuperarContrasena = If(rd.IsDBNull(10), False, Convert.ToBoolean(rd(10))),
                          .ChangePassword = If(rd.IsDBNull(11), False, Convert.ToBoolean(rd(11))),
                          .DateForExpirationPassword = If(rd.IsDBNull(12), Date.MinValue, Convert.ToDateTime(rd(12))),
                          .BloqueadoVenta = If(rd.IsDBNull(13), False, Convert.ToBoolean(rd(13))),
                          .IntentosFallidos = If(rd.IsDBNull(14), 0, Convert.ToInt32(rd(14)))
                        }
                    End If


                End Using
            End Using
        End Using
        Return Nothing
    End Function

    Public Function ValidarUsuario(usercode As String, password As String) As LoginResult _
    Implements IAccesoRepository.ValidarUsuario

        Dim res As New LoginResult With {.Success = False, .Reason = ""}

        Const sqlSel As String = "
    SELECT TOP 1 IDAcceso, Password, Activo, BloqueadoVenta, DateForExpirationPassword, IntentosFallidos
    FROM Acceso WITH (NOLOCK)
    WHERE LOWER(RTRIM(LTRIM(Usercode))) = LOWER(RTRIM(LTRIM(@user)));"

        Using cn As New SqlConnection(_cs)
            cn.Open()

            ' 1) Buscar usuario
            Dim dr As SqlDataReader
            Using cmd As New SqlCommand(sqlSel, cn)
                cmd.Parameters.Add("@user", SqlDbType.VarChar, 100).Value = If(usercode, "").Trim()
                dr = cmd.ExecuteReader(CommandBehavior.SingleRow)
                If Not dr.Read() Then
                    res.Reason = "usuario_inexistente"
                    Return res
                End If

                Dim idAcceso = Convert.ToInt32(dr("IDAcceso"))
                Dim passDb = dr("Password").ToString()
                Dim activo = If(IsDBNull(dr("Activo")), False, Convert.ToBoolean(dr("Activo")))
                Dim bloqueado = If(IsDBNull(dr("BloqueadoVenta")), False, Convert.ToBoolean(dr("BloqueadoVenta")))
                Dim vence As DateTime = If(IsDBNull(dr("DateForExpirationPassword")), Date.MinValue, Convert.ToDateTime(dr("DateForExpirationPassword")))
                dr.Close()

                ' 2) Validaciones básicas
                If Not activo Then
                    res.Reason = "inactivo"
                    Return res
                End If
                If bloqueado Then
                    res.Reason = "bloqueado"
                    Return res
                End If

                ' 3) Validar password (antes de chequear vencimiento)
                Dim okPass As Boolean = String.Equals(passDb, If(password, ""), StringComparison.Ordinal)
                If Not okPass Then
                    Const THRESHOLD As Integer = 3

                    Dim newCount As Integer
                    Using up As New SqlCommand("
                      UPDATE Acceso
                      SET IntentosFallidos = ISNULL(IntentosFallidos,0) + 1
                      OUTPUT inserted.IntentosFallidos
                      WHERE IDAcceso = @id;", cn)
                        up.Parameters.Add("@id", SqlDbType.Int).Value = idAcceso
                        newCount = Convert.ToInt32(up.ExecuteScalar())
                    End Using

                    If newCount >= THRESHOLD Then
                        Using lockCmd As New SqlCommand("
                    UPDATE Acceso
                    SET Activo = 0,
                        BloqueadoVenta = 1,
                        ChangePassword = 1
                    WHERE IDAcceso = @id;", cn)
                            lockCmd.Parameters.Add("@id", SqlDbType.Int).Value = idAcceso
                            lockCmd.ExecuteNonQuery()
                        End Using
                        res.Reason = "bloqueado_por_intentos"
                    Else
                        res.Reason = "pass_incorrecta"
                    End If

                    Return res ' ← cortar acá si la pass es incorrecta
                End If

                ' 4) Password OK -> resetear IntentosFallidos
                Using upOk As New SqlCommand("
                    UPDATE Acceso SET IntentosFallidos = 0
                    WHERE IDAcceso = @id;", cn)
                    upOk.Parameters.Add("@id", SqlDbType.Int).Value = idAcceso
                    upOk.ExecuteNonQuery()
                End Using

                ' 5) Si password OK pero vencida -> Success=True + reason
                If vence <> Date.MinValue AndAlso vence < DateTime.Now Then
                    res.Success = True
                    res.Reason = "pass_vencida"
                    Return res
                End If

                ' 6) OK normal
                res.Success = True
                ' res.Reason = ""  ' no tocar; queda vacío cuando está todo bien
                Return res
            End Using
        End Using
    End Function
    Public Function EnsureStockSube(idAgencia As Integer) As Integer _
        Implements IAccesoRepository.EnsureStockSube

        Const sql As String = "
        IF NOT EXISTS (
            SELECT 1
            FROM StockSube
            WHERE IDAgencia = @IDAgencia
              AND IDProducto = 100
        )
        BEGIN
            INSERT INTO StockSube (IDProducto, IDAgencia, Cantidad, Activo, CargaInicial, StockPos, FechaModificacion, ImeiPos)
            VALUES (100, @IDAgencia, 0, 1, 0, 0, GETDATE(), NULL);
        END;

        SELECT TOP 1 IDStockSube
        FROM StockSube
        WHERE IDAgencia = @IDAgencia
          AND IDProducto = 100;"

        Using cn As New SqlConnection(_cs)
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.Add("@IDAgencia", SqlDbType.Int).Value = idAgencia
                cn.Open()
                Dim obj = cmd.ExecuteScalar()
                Return If(obj Is Nothing OrElse obj Is DBNull.Value, 0, Convert.ToInt32(obj))
            End Using
        End Using
    End Function
End Class
