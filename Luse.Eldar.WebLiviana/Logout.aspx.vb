
'Partial Class Logout
'    Inherits System.Web.UI.Page

'End Class
Partial Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' Evitar cache en el navegador
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetNoStore()
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1))

        ' Cerrar autenticación Forms
        System.Web.Security.FormsAuthentication.SignOut()

        ' Limpiar sesión
        Session.Clear()
        Session.RemoveAll()
        Session.Abandon()

        ' Expirar cookie de sesión
        Dim sesCookie As New HttpCookie("ASP.NET_SessionId", "")
        sesCookie.Expires = DateTime.UtcNow.AddDays(-1)
        Response.Cookies.Add(sesCookie)

        ' Expirar cookie de autenticación
        Dim authCookieName = System.Web.Security.FormsAuthentication.FormsCookieName
        Dim authCookie As New HttpCookie(authCookieName, "")
        authCookie.Expires = DateTime.UtcNow.AddDays(-1)
        authCookie.HttpOnly = True
        Response.Cookies.Add(authCookie)

        ' Redirigir al login
        Response.Redirect("~/Default.aspx", True)
    End Sub
End Class
