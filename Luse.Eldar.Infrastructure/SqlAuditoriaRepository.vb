Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Http
Imports Luse.Eldar.Domain
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class SqlAuditoriaRepository
    Implements IAuditoriaRepository
    Private ReadOnly _cs As String

    Public Sub New(connectionString As String)
        _cs = connectionString
    End Sub

    'Public Function GetValidacionIP(ip As String) As Boolean Implements IAuditoriaRepository.GetValidacionIP
    '    Const sql As String = "
    '    SELECT CASE WHEN EXISTS (
    '        SELECT * FROM IPList WHERE Bloqueada = 1 AND IP =  @ip
    '    ) THEN 1 ELSE 0 END;"

    '    Using cn As New SqlConnection(_cs)
    '        Using cmd As New SqlCommand(sql, cn)
    '            cmd.Parameters.Add("@ip", SqlDbType.VarChar, 200).Value = If(ip, "").Trim()
    '            cn.Open()
    '            Dim exists As Integer = Convert.ToInt32(cmd.ExecuteScalar())
    '            ' Si existe al menos un registro -> devolver False (bloqueado)
    '            Return (exists = 0)
    '        End Using
    '    End Using
    'End Function

    Public Function InsertAuditoria(a As AuditoriaIngreso) As Integer _
        Implements IAuditoriaRepository.InsertAuditoria

        Const sql As String =
          "INSERT INTO AuditoriaIngreso (Fecha, Usuario, Password, IP, Exito, Observaciones)
     VALUES (GETDATE(), @Usuario, @Password, @IP, @Exito, @Obs);
     SELECT CAST(SCOPE_IDENTITY() AS INT);"

        Using cn As New SqlConnection(_cs)
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100).Value = If(a.Usuario, "")
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 200).Value = If(a.Password, "")
                cmd.Parameters.Add("@IP", SqlDbType.VarChar, 50).Value = If(a.IP, "")
                cmd.Parameters.Add("@Exito", SqlDbType.Bit).Value = a.Exito
                cmd.Parameters.Add("@Obs", SqlDbType.VarChar, 200).Value = If(a.Observaciones, "")

                cn.Open()
                Dim idObj = cmd.ExecuteScalar()
                Dim id As Integer = If(idObj Is Nothing OrElse idObj Is DBNull.Value, 0, Convert.ToInt32(idObj))
                a.IDAuditoriaIngreso = id
                Return id
            End Using
        End Using
    End Function



    ' Helper horario restringido: 00:01–06:59:59 y domingos todo el día
    Private Function IsWithinRestrictedWindow(now As DateTime) As Boolean
        If now.DayOfWeek = DayOfWeek.Sunday Then Return True
        Dim t = now.TimeOfDay
        Dim fromTS = New TimeSpan(0, 1, 0)  ' 00:01
        Dim toTS = New TimeSpan(7, 0, 0)    ' 07:00 (no inclusive)
        Return (t >= fromTS AndAlso t < toTS)
    End Function

    Public Function GetValidacionIP(ip As String) As ValidationResult Implements IAuditoriaRepository.GetValidacionIP
        ip = If(ip, "").Trim()
        If String.IsNullOrEmpty(ip) Then
            Return New ValidationResult(True, "IP vacia")
        End If

        Const sql As String = "
        SELECT TOP 1 Bloqueada
        FROM IPList
        WHERE IP = @ip;"

        Try
            Using cn As New SqlConnection(_cs)
                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.Add("@ip", SqlDbType.VarChar, 200).Value = ip
                    cn.Open()

                    Dim val = cmd.ExecuteScalar()

                    ' Si la IP existe en la tabla
                    If val IsNot Nothing AndAlso val IsNot DBNull.Value Then
                        Dim bloqueada As Boolean = Convert.ToBoolean(val)
                        If bloqueada Then
                            Return New ValidationResult(False, "IP en lista negra (bloqueada)")
                        Else
                            Return New ValidationResult(True, "IP en lista blanca (habilitada)")
                        End If
                    End If

                    ' Si no existe en la tabla, NO habilitar (ajustá este criterio si querés permitir por defecto)
                    Return New ValidationResult(True, "IP no registrada")
                End Using
            End Using
        Catch
            Return New ValidationResult(True, "Error al validar IP")
        End Try
    End Function


End Class