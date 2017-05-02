Public Class ClsUserMaster
    Inherits ClsIdName

    Private sPassword As String = ""
    Private sProfileId As Integer = cInvalidId
    Private sLoginName As String = ""
    Private sAuthorizationNo As String = ""

    Public Property Password() As String
        Get
            Return sPassword
        End Get
        Set(ByVal value As String)
            sPassword = value.Trim
        End Set
    End Property

    Public Property ProfileId() As Integer
        Get
            Return sProfileId
        End Get
        Set(ByVal value As Integer)
            sProfileId = value
        End Set
    End Property

    Public Property LoginName() As String
        Get
            Return sLoginName
        End Get
        Set(ByVal value As String)
            sLoginName = value.Trim
        End Set
    End Property

    Public Property AuthorizationNo() As String
        Get
            Return sAuthorizationNo
        End Get
        Set(ByVal value As String)
            sAuthorizationNo = value.Trim
        End Set
    End Property

End Class
