Public Class ClsAccountHead

    Private sId As Integer = cInvalidId
    Private sHeadCode As String = ""
    Private sName As String = ""
    Private sGroupId As Integer = cInvalidId
    Private sOpeningBalance As Double = 0
    Private sCrDr As String = ""
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

    Public Property HeadCode() As String
        Get
            Return sHeadCode
        End Get
        Set(ByVal value As String)
            sHeadCode = value.Trim
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

    Public Property GroupId() As Integer
        Get
            Return sGroupId
        End Get
        Set(ByVal value As Integer)
            sGroupId = value
        End Set
    End Property

    Public Property OpeningBalance() As Double
        Get
            Return sOpeningBalance
        End Get
        Set(ByVal value As Double)
            sOpeningBalance = value
        End Set
    End Property

    Public Property CrDr() As String
        Get
            Return sCrDr
        End Get
        Set(ByVal value As String)
            sCrDr = value.Trim
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

    Public ReadOnly Property ItemName() As String
        Get
            Return sName + " [" + sHeadCode + "]"
        End Get
    End Property

End Class
