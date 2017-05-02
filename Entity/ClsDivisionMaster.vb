Public Class ClsDivisionMaster

    Private sId As Integer = cInvalidId
    Private sName As String = ""
    Private sUserId As String = ""
    Private sDateOn As Date = DateDefault

    Public Property Id() As Integer
        Get
            Return sId
        End Get
        Set(ByVal value As Integer)
            sId = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return sName
        End Get
        Set(ByVal value As String)
            sName = value.Trim
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
