
Public Interface IAccesoRepository
    Function GetByTipoAndUser(tipo As Integer, usercode As String) As IEnumerable(Of Acceso)
    Function GetAccesoLogin(usercode As String, password As String, pass As String) As AccesoLogin
    Function ValidarUsuario(usercode As String, password As String) As LoginResult
    Function EnsureStockSube(idAgencia As Integer) As Integer
End Interface
