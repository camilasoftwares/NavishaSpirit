Public Class ClsTransactionAccount

    'Private sId As Long = cInvalidId
    Private sVoucherNo As String = ""
    Private sTransactionDate As Date = DateDefault
    Private sHeadId As Integer = cInvalidId
    Private sDrAmount As Double = 0
    Private sCrAmount As Double = 0
    Private sNarration As String = ""
    Private sSource As String = ""
    Private sRemark As String = ""
    Private sUserId As String = ""
    Private sDateOn As Date = DateDefault

    'Public Property Id() As Long
    '    Get
    '        Return sId
    '    End Get
    '    Set(ByVal value As Long)
    '        sId = value
    '    End Set
    'End Property

    Public Property VoucherNo() As String
        Get
            Return sVoucherNo
        End Get
        Set(ByVal value As String)
            sVoucherNo = value.Trim
        End Set
    End Property

    Public Property TransactionDate() As Date
        Get
            Return sTransactionDate
        End Get
        Set(ByVal value As Date)
            sTransactionDate = value
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

    Public Property Narration() As String
        Get
            Return sNarration
        End Get
        Set(ByVal value As String)
            sNarration = value.Trim
        End Set
    End Property

    Public Property Source() As String
        Get
            Return sSource
        End Get
        Set(ByVal value As String)
            sSource = value.Trim
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

    Public Property DateOn() As Date
        Get
            Return sDateOn
        End Get
        Set(ByVal value As Date)
            sDateOn = value
        End Set
    End Property

End Class
