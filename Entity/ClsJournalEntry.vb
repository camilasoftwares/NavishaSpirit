Public Class ClsJournalEntry

    Private sJournalNo As String = ""
    Private sJournaldate As Date = DateDefault
    Private sHeadId As Integer = cInvalidId
    Private sDrAmount As Double = 0
    Private sCrAmount As Double = 0
    Private sRemark As String = ""
    Private sInvoiceNo As String = ""
    Private sUserId As String = ""
    Private sDateOn As Date = DateDefault
    Private sId As Long = cInvalidId

    Public Property Id() As Long
        Get
            Return sId
        End Get
        Set(ByVal value As Long)
            sId = value
        End Set
    End Property

    Public Property JournalNo() As String
        Get
            Return sJournalNo
        End Get
        Set(ByVal value As String)
            sJournalNo = value.Trim
        End Set
    End Property

    Public Property Journaldate() As Date
        Get
            Return sJournaldate
        End Get
        Set(ByVal value As Date)
            sJournaldate = value
        End Set
    End Property

    Public Property HeadId() As Integer
        Get
            Return sHeadId
        End Get
        Set(ByVal value As Integer)
            sHeadId = value
        End Set
    End Property

    Public Property DrAmount() As Double
        Get
            Return sDrAmount
        End Get
        Set(ByVal value As Double)
            sDrAmount = value
        End Set
    End Property

    Public Property CrAmount() As Double
        Get
            Return sCrAmount
        End Get
        Set(ByVal value As Double)
            sCrAmount = value
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

    Public Property InvoiceNo() As String
        Get
            Return sInvoiceNo
        End Get
        Set(ByVal value As String)
            sInvoiceNo = value.Trim
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
