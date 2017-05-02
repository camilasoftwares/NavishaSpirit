Public Class ClsPurchaseMaster

    Private sId As Integer = cInvalidId
    Private sPurchaseCode As String = ""
    Private sVendorId As Integer = cInvalidId
    Private sMode As String = ""
    Private sVoucherNo As String = ""
    Private sOrderId As Integer = cInvalidId
    Private sRemark As String = ""
    Private sUserId As String = ""
    Private sDateOn As Date = DateDefault
    Private sPurchaseDate As Date = DateDefault
    Private sNotClosed As Boolean = False
    Private sDiscountAmount As Double = 0
    Private sTaxId As Integer = cInvalidId
    Private sCreditAdjust As Double = 0
    Private sDebitAdjust As Double = 0
    Private sTaxPercent As Double = 0
    Private sPreExciseAmount As Double = 0
    Private sFreightCharge As Double = 0

    Public Property Id() As Integer
        Get
            Return sId
        End Get
        Set(ByVal value As Integer)
            sId = value
        End Set
    End Property

    Public Property PurchaseCode() As String
        Get
            Return sPurchaseCode
        End Get
        Set(ByVal value As String)
            sPurchaseCode = value.Trim
        End Set
    End Property

    Public Property VendorId() As Integer
        Get
            Return sVendorId
        End Get
        Set(ByVal value As Integer)
            sVendorId = value
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

    Public Property VoucherNo() As String
        Get
            Return sVoucherNo
        End Get
        Set(ByVal value As String)
            sVoucherNo = value.Trim
        End Set
    End Property

    Public Property OrderId() As Integer
        Get
            Return sOrderId
        End Get
        Set(ByVal value As Integer)
            sOrderId = value
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

    Public Property PurchaseDate() As Date
        Get
            Return sPurchaseDate
        End Get
        Set(ByVal value As Date)
            sPurchaseDate = value
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

    Public Property TaxId() As Integer
        Get
            Return sTaxId
        End Get
        Set(ByVal value As Integer)
            sTaxId = value
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

    Public Property FreightCharge() As Double
        Get
            Return sFreightCharge
        End Get
        Set(ByVal value As Double)
            sFreightCharge = value
        End Set
    End Property
End Class
