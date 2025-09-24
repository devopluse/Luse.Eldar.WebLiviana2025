Public Interface IAuditoriaRepository
    Function GetValidacionIP(ip As String) As Boolean
    Function InsertAuditoria(a As AuditoriaIngreso) As Integer
    Function EnsureStockSube(idAgencia As Integer) As Integer
End Interface
