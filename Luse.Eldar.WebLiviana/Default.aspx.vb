
Imports System.Data
Imports System.IO
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Web.Services
Imports LuSe.WsTransaccional
Imports Newtonsoft.Json
Imports LuSe.Eldar.Domain
Imports Servicios


Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub Page_LoadAsync(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.HttpMethod = "POST" Then

            Dim json As String = New StreamReader(Request.InputStream).ReadToEnd()

            Dim valor As Parametros = JsonConvert.DeserializeObject(Of Parametros)(json) ' Obtener el valor enviado desde JavaScript
            If valor IsNot Nothing Then
                Dim cSQL As String
                Dim referer As String = "No detectado"
                Dim navegador As String = "No detectado"
                Try
                    referer = Request.UrlReferrer.ToString()
                Catch ex As Exception
                    referer = "Error al obtener el origen " + ex.Message
                End Try

                Try
                    navegador = Request.Browser.Browser.ToString() + " V." + Request.Browser.Version.ToString()
                Catch ex As Exception
                    navegador = "Error al obtener el navegador " + ex.Message
                End Try
                referer = referer
                Dim oServicio As New Servicios
                cSQL = "Update AuditoriaIngreso set Navegador = '" + navegador + "' where IDAuditoriaIngreso = " + valor.IDAuditoria.ToString()
                oServicio.ExecuteSqlAudit(cSQL)


                Session("Usuario") = valor.User
                Session("Password") = valor.Pass

                Session("Saldo") = valor.Saldo
                Session("SaldoSube") = valor.SaldoSube
                Session("IDAgencia") = valor.IDAgencia
                Session("NombreAgencia") = valor.NombreAgencia
                Session("DireccionAgencia") = valor.DireccionAgencia
                Session("ImeI") = valor.Imei
                Session("IDPrestamoBase") = valor.IDPrestamoBase
                Session("AptoCredito") = valor.AptoCredito
                Session("MensajeCredito") = valor.MensajeCredito
                Session("IDAcceso") = valor.IDAcceso
                Session("IPCliente") = valor.IPCliente
                Session("HabilitadoEntregaDinero") = valor.HabilitadoEntregaDinero
                'Cargar estas variables segun el usuario para saber si el mismo tendra autorizaciones


                Session("CodPuestoRP") = valor.CodPuestoRP.ToString.PadLeft(6, "0") ' mCodPuestoRP.ToString.PadLeft(6, "0")
                Session("AgenteRP") = valor.Agente.ToString.PadLeft(5, "0") 'mAgenteRP.ToString.PadLeft(5, "0")
                Session("SucursalRP") = valor.Sucursal

                If Session("CodPuestoRP") = 0 Then
                    Session("mnuRPVisible") = False
                Else
                    Session("mnuRPVisible") = True

                End If

                If Session("HabilitadoEntregaDinero") = 0 Then
                    Session("mnuRetiroDinero") = False
                Else
                    Session("mnuRetiroDinero") = True

                End If
            End If


        End If

    End Sub

    Public Class resCaptcha

        Private msuccess As Boolean
        Public Property success() As Boolean
            Get
                Return msuccess
            End Get
            Set(ByVal value As Boolean)
                msuccess = value
            End Set
        End Property
        Private mchallenge_ts As DateTime
        Public Property challenge_ts() As DateTime
            Get
                Return mchallenge_ts
            End Get
            Set(ByVal value As DateTime)
                mchallenge_ts = value
            End Set
        End Property
        Private mhostname As String
        Public Property hostname() As String
            Get
                Return mhostname
            End Get
            Set(ByVal value As String)
                mhostname = value
            End Set
        End Property
        Private maction As String
        Public Property action() As String
            Get
                Return maction
            End Get
            Set(ByVal value As String)
                maction = value
            End Set
        End Property

    End Class


    Private Sub Login(ByVal sender As Object, ByVal e As EventArgs) 'Handles btnIngresar.ServerClick

    End Sub



End Class
