Public Class ClsAccountGroup
    Inherits ClsIdName

    Private sGroupCode As String = ""
    Private sAvailableIn As String = ""
    Private sUserId As String = ""
    Private sDateOn As Date = DateDefault

    Public Property GroupCode() As String
        Get
            Return sGroupCode
        End Get
        Set(ByVal value As String)
            sGroupCode = value.Trim
        End Set
    End Property

    Public Property AvailableIn() As String
        Get
            Return sAvailableIn
        End Get
        Set(ByVal value As String)
            sAvailableIn = value.Trim
        End Set
    End Property

    Public Property UserId() As String
        Get
            Return sUserId
        End Get
        Set(ByVal value As String)
            sUserId = value.Trim
        End Set
    End Property

    Public Property DateOn() As Date
        Get
            Return sDateOn
        End Get
        Set(ByVal value As Date)
            sDateOn = value
        End Set
    End Property

End Class
