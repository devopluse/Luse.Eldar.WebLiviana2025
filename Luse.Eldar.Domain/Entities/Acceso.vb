
Public Class Acceso
    Public Property Id As Integer
    Public Property Usercode As String
    Public Property TipoAcceso As Integer
    Public Property Habilitado As Boolean
End Class

Public Class AccesoLogin

    Public Property IDAcceso As Integer
    Public Property IDAgencia As Integer
    Public Property IDAgenciaSup As Integer
    Public Property Nombre As String
    Public Property UpgPos As Integer
    Public Property Activo As Boolean
    Public Property StockAgencia As Decimal
    Public Property StockAgenciaSube As Decimal
    Public Property IDStockSube As Integer
    Public Property ClaveArecuperar As String
    Public Property RecuperarContrasena As Boolean
    Public Property ChangePassword As Boolean
    Public Property DateForExpirationPassword As DateTime
    Public Property BloqueadoVenta As Boolean
    Public Property IntentosFallidos As Integer

End Class

Public Class AccesoIP
    Public Property IDIPList As Integer
End Class
