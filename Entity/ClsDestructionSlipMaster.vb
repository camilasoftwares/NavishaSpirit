Public Class ClsDestructionSlipMaster

    Private sId As Long = cInvalidId
    Private sUserId As String = ""
    Private sRemark As String = ""
    Private sDateOn As Date = DateDefault
    Private sDestructionSlipCode As String = ""
    Private sNotClosed As Boolean = False
    Private sDestructionSlipDate As Date = DateDefault

    Public Property Id() As Long
        Get
            Return sId
        End Get
        Set(ByVal value As Long)
            sId = value
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

    Public Property Remark() As String
        Get
            Return sRemark
        End Get
        Set(ByVal value As String)
            sRemark = value.Trim
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

    Public Property DestructionSlipCode() As String
        Get
            Return sDestructionSlipCode
        End Get
        Set(ByVal value As String)
            sDestructionSlipCode = value.Trim
        End Set
    End Property

    Public Property NotClosed() As Boolean
        Get
            Return sNotClosed
        End Get
        Set(ByVal value As Boolean)
            sNotClosed = value
        End Set
    End Property

    Public Property DestructionSlipDate() As Date
        Get
            Return sDestructionSlipDate
        End Get
        Set(ByVal value As Date)
            sDestructionSlipDate = value
        End Set
    End Property

End Class
