Public Class ClsProfileMaster
    Inherits ClsIdName

    Private sAuthorizationNo As String = ""

    Public Property AuthorizationNo() As String
        Get
            Return sAuthorizationNo
        End Get
        Set(ByVal value As String)
            sAuthorizationNo = value.Trim
        End Set
    End Property

End Class
