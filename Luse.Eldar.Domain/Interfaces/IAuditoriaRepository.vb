Public Structure ValidationResult
    Public Success As Boolean
    Public Reason As String
    Public Sub New(ok As Boolean, why As String)
        Success = ok : Reason = why
    End Sub
End Structure

Public Interface IAuditoriaRepository
    Function GetValidacionIP(ip As String) As ValidationResult
    Function InsertAuditoria(a As AuditoriaIngreso) As Integer
End Interface