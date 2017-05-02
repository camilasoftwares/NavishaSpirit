Public Class ClsTransactionStock

    'Private sId As Long = cInvalidId
    Private sTransactionNo As String = ""
    Private sItemId As Integer = cInvalidId
    Private sBatch As String = ""
    Private sExpiryDate As Date = DateDefault
    Private sPackQuantity As Double = 0
    Private sQuantityIn As Double = 0
    Private sQuantityOut As Double = 0
    Private sPricePurchase As Double = 0
    Private sPriceSale As Double = 0
    Private sTaxPercent As Double = 0
    Private sDiscountPercent As Double = 0
    Private sTaxAmount As Double = 0
    Private sDiscountAmount As Double = 0
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

    Public Property TransactionNo() As String
        Get
            Return sTransactionNo
        End Get
        Set(ByVal value As String)
            sTransactionNo = value.Trim
        End Set
    End Property

    Public Property ItemId() As Integer
        Get
            Return sItemId
        End Get
        Set(ByVal value As Integer)
            sItemId = value
        End Set
    End Property

    Public Property Batch() As String
        Get
            Return sBatch
        End Get
        Set(ByVal value As String)
            sBatch = value.Trim
        End Set
    End Property

    Public Property ExpiryDate() As Date
        Get
            Return sExpiryDate
        End Get
        Set(ByVal value As Date)
            sExpiryDate = value
        End Set
    End Property

    Public Property PackQuantity() As Double
        Get
            Return sPackQuantity
        End Get
        Set(ByVal value As Double)
            sPackQuantity = value
        End Set
    End Property

    Public Property QuantityIn() As Double
        Get
            Return sQuantityIn
        End Get
        Set(ByVal value As Double)
            sQuantityIn = value
        End Set
    End Property

    Public Property QuantityOut() As Double
        Get
            Return sQuantityOut
        End Get
        Set(ByVal value As Double)
            sQuantityOut = value
        End Set
    End Property

    Public Property PricePurchase() As Double
        Get
            Return sPricePurchase
        End Get
        Set(ByVal value As Double)
            sPricePurchase = value
        End Set
    End Property

    Public Property PriceSale() As Double
        Get
            Return sPriceSale
        End Get
        Set(ByVal value As Double)
            sPriceSale = value
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

    Public Property DiscountPercent() As Double
        Get
            Return sDiscountPercent
        End Get
        Set(ByVal value As Double)
            sDiscountPercent = value
        End Set
    End Property

    Public Property TaxAmount() As Double
        Get
            Return sTaxAmount
        End Get
        Set(ByVal value As Double)
            sTaxAmount = value
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
