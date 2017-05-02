Public Class ClsCreditNote

    Private sId As Long = cInvalidId
    Private sCode As String = ""
    Private sAgainstCode As String = ""
    Private sCustomerCode As String = ""
    Private sAmount As Double = 0
    Private sNarration As String = ""
    Private sRemark As String = ""
    Private sUserId As String = ""
    Private sNoteDate As DateTime = DateDefault
    Private sDateOn As DateTime = DateDefault

    Public Property Id() As Long
        Get
            Return sId
        End Get
        Set(ByVal value As Long)
            sId = value
        End Set
    End Property

    Public Property Code() As String
        Get
            Return sCode
        End Get
        Set(ByVal value As String)
            sCode = value.Trim
        End Set
    End Property

    Public Property AgainstCode() As String
        Get
            Return sAgainstCode
        End Get
        Set(ByVal value As String)
            sAgainstCode = value.Trim
        End Set
    End Property

    Public Property CustomerCode() As String
        Get
            Return sCustomerCode
        End Get
        Set(ByVal value As String)
            sCustomerCode = value.Trim
        End Set
    End Property

    Public Property Amount() As Double
        Get
            Return sAmount
        End Get
        Set(ByVal value As Double)
            sAmount = value
        End Set
    End Property

    Public Property Narration() As String
        Get
            Return sNarration
        End Get
        Set(ByVal value As String)
            sNarration = value.Trim
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

    Public Property UserId() As String
        Get
            Return sUserId
        End Get
        Set(ByVal value As String)
            sUserId = value.Trim
        End Set
    End Property

    Public Property NoteDate() As DateTime
        Get
            Return sNoteDate
        End Get
        Set(ByVal value As DateTime)
            sNoteDate = value
        End Set
    End Property

    Public Property DateOn() As DateTime
        Get
            Return sDateOn
        End Get
        Set(ByVal value As DateTime)
            sDateOn = value
        End Set
    End Property

End Class
