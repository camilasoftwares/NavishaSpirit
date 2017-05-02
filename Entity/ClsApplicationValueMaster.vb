Public Class ClsApplicationValueMaster
    Inherits ClsIdName

    Private sIdValue As String = ""

    Public Property IdValue() As String
        Get
            Return sIdValue
        End Get
        Set(ByVal value As String)
            sIdValue = value.Trim
        End Set
    End Property

End Class
