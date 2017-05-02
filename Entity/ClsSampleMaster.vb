Public Class ClsSampleMaster

    Private sId As Long = cInvalidId
    Private sSampleCode As String = ""
    Private sCustomerId As Integer = cInvalidId
    Private sDoctorId As Integer = cInvalidId
    Private sMode As String = ""
    Private sRemark As String = ""
    Private sPrescription As String = ""
    Private sCashOutAmount As Double = 0
    Private sAdjustedAmount As Double = 0
    Private sSampleDate As Date = DateDefault
    Private sCashMemo As Boolean = False
    Private sUserId As String = ""
    Private sDateOn As Date = DateDefault
    Private sNotClosed As Boolean = False
    Private sForCashOut As Boolean = False
    Private sDiscountAmount As Double = 0
    Private sDivisionId As Integer = cInvalidId
    Private sTransporterId As Integer = cInvalidId
    Private sHQId As Integer = cInvalidId
    Private sPickSlipNo As String = ""
    Private sOrderNo As String = ""
    Private sReference As String = ""
    Private sDestination As String = ""
    Private sLRNo As String = ""
    Private sChequeNo As String = ""
    Private sCases As String = ""
    Private sTaxId As Integer = cInvalidId
    Private sDueDate As Date = DateDefault
    Private sLRDate As Date = DateDefault
    Private sOrderDate As Date = DateDefault
    Private sCreditAdjust As Double = 0
    Private sDebitAdjust As Double = 0
    Private sTaxPercent As Double = 0
    Private sPreExciseAmount As Double = 0

    Public Property Id() As Long
        Get
            Return sId
        End Get
        Set(ByVal value As Long)
            sId = value
        End Set
    End Property

    Public Property SampleCode() As String
        Get
            Return sSampleCode
        End Get
        Set(ByVal value As String)
            sSampleCode = value.Trim
        End Set
    End Property

    Public Property CustomerId() As Integer
        Get
            Return sCustomerId
        End Get
        Set(ByVal value As Integer)
            sCustomerId = value
        End Set
    End Property

    Public Property DoctorId() As Integer
        Get
            Return sDoctorId
        End Get
        Set(ByVal value As Integer)
            sDoctorId = value
        End Set
    End Property

    Public Property Mode() As String
        Get
            Return sMode
        End Get
        Set(ByVal value As String)
            sMode = value.Trim
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

    Public Property Prescription() As String
        Get
            Return sPrescription
        End Get
        Set(ByVal value As String)
            sPrescription = value.Trim
        End Set
    End Property

    Public Property CashOutAmount() As Double
        Get
            Return sCashOutAmount
        End Get
        Set(ByVal value As Double)
            sCashOutAmount = value
        End Set
    End Property

    Public Property AdjustedAmount() As Double
        Get
            Return sAdjustedAmount
        End Get
        Set(ByVal value As Double)
            sAdjustedAmount = value
        End Set
    End Property

    Public Property SampleDate() As Date
        Get
            Return sSampleDate
        End Get
        Set(ByVal value As Date)
            sSampleDate = value
        End Set
    End Property

    Public Property CashMemo() As Boolean
        Get
            Return sCashMemo
        End Get
        Set(ByVal value As Boolean)
            sCashMemo = value
        End Set
    End Property

    Public Property ForCashOut() As Boolean
        Get
            Return sForCashOut
        End Get
        Set(ByVal value As Boolean)
            sForCashOut = value
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

    Public Property NotClosed() As Boolean
        Get
            Return sNotClosed
        End Get
        Set(ByVal value As Boolean)
            sNotClosed = value
        End Set
    End Property

    Public Property DiscountAmount() As Double
        Get
            Return sDiscountAmount
        End Get
        Set(ByVal value As Double)
            sDiscountAmount = value
        End Set
    End Property

    Public Property DivisionId() As Integer
        Get
            Return sDivisionId
        End Get
        Set(ByVal value As Integer)
            sDivisionId = value
        End Set
    End Property

    Public Property TransporterId() As Integer
        Get
            Return sTransporterId
        End Get
        Set(ByVal value As Integer)
            sTransporterId = value
        End Set
    End Property

    Public Property HQId() As Integer
        Get
            Return sHQId
        End Get
        Set(ByVal value As Integer)
            sHQId = value
        End Set
    End Property

    Public Property PickSlipNo() As String
        Get
            Return sPickSlipNo
        End Get
        Set(ByVal value As String)
            sPickSlipNo = value.Trim
        End Set
    End Property

    Public Property OrderNo() As String
        Get
            Return sOrderNo
        End Get
        Set(ByVal value As String)
            sOrderNo = value.Trim
        End Set
    End Property

    Public Property Reference() As String
        Get
            Return sReference
        End Get
        Set(ByVal value As String)
            sReference = value.Trim
        End Set
    End Property

    Public Property Destination() As String
        Get
            Return sDestination
        End Get
        Set(ByVal value As String)
            sDestination = value.Trim
        End Set
    End Property

    Public Property LRNo() As String
        Get
            Return sLRNo
        End Get
        Set(ByVal value As String)
            sLRNo = value.Trim
        End Set
    End Property

    Public Property ChequeNo() As String
        Get
            Return sChequeNo
        End Get
        Set(ByVal value As String)
            sChequeNo = value.Trim
        End Set
    End Property

    Public Property Cases() As String
        Get
            Return sCases
        End Get
        Set(ByVal value As String)
            sCases = value.Trim
        End Set
    End Property

    Public Property TaxId() As Integer
        Get
            Return sTaxId
        End Get
        Set(ByVal value As Integer)
            sTaxId = value
        End Set
    End Property

    Public Property DueDate() As Date
        Get
            Return sDueDate
        End Get
        Set(ByVal value As Date)
            sDueDate = value
        End Set
    End Property

    Public Property LRDate() As Date
        Get
            Return sLRDate
        End Get
        Set(ByVal value As Date)
            sLRDate = value
        End Set
    End Property

    Public Property OrderDate() As Date
        Get
            Return sOrderDate
        End Get
        Set(ByVal value As Date)
            sOrderDate = value
        End Set
    End Property

    Public Property CreditAdjust() As Double
        Get
            Return sCreditAdjust
        End Get
        Set(ByVal value As Double)
            sCreditAdjust = value
        End Set
    End Property

    Public Property DebitAdjust() As Double
        Get
            Return sDebitAdjust
        End Get
        Set(ByVal value As Double)
            sDebitAdjust = value
        End Set
    End Property

    Public Property TaxPercent() As Double
        Get
            Return sTaxPercent
        End Get
        Set(ByVal value As Double)
            sTaxPercent = value
        End Set
    End Property

    Public Property PreExciseAmount() As Double
        Get
            Return sPreExciseAmount
        End Get
        Set(ByVal value As Double)
            sPreExciseAmount = value
        End Set
    End Property

End Class
