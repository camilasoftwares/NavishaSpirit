Public Class ClsSalesReturnDetail

    Private sId As Long = cInvalidId
    Private sSalesReturnId As Long = cInvalidId
    Private sItemId As Integer = cInvalidId
    Private sBatch As String = ""
    Private sExpiryDate As Date = DateDefault
    Private sPackQuantity As Double = 0
    Private sReturnQuantity As Double = 0
    Private sPricePurchase As Double = 0
    Private sPriceSale As Double = 0
    Private sTaxPercent As Double = 0
    Private sDiscountPercent As Double = 0
    Private sTaxAmount As Double = 0
    Private sDiscountAmount As Double = 0
    Private sStorageId As Integer = cInvalidId
    Private sRemark As String = ""
    Private sSaleId As Long = cInvalidId
    Private sUserId As String = ""
    Private sDateOn As Date = DateDefault
    Private sNonSaleable As Boolean = False

    Public Property Id() As Long
        Get
            Return sId
        End Get
        Set(ByVal value As Long)
            sId = value
        End Set
    End Property

    Public Property SalesReturnId() As Long
        Get
            Return sSalesReturnId
        End Get
        Set(ByVal value As Long)
            sSalesReturnId = value
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

    Public Property ReturnQuantity() As Double
        Get
            Return sReturnQuantity
        End Get
        Set(ByVal value As Double)
            sReturnQuantity = value
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

    Public Property StorageId() As Integer
        Get
            Return sStorageId
        End Get
        Set(ByVal value As Integer)
            sStorageId = value
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

    Public Property SaleId() As Long
        Get
            Return sSaleId
        End Get
        Set(ByVal value As Long)
            sSaleId = value
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

    Public Property NonSaleable() As Boolean
        Get
            Return sNonSaleable
        End Get
        Set(ByVal value As Boolean)
            sNonSaleable = value
        End Set
    End Property

    ''' <summary>
    ''' Before using this function set all values to object
    ''' </summary>
    ''' <returns>Calculated Total</returns>
    ''' <remarks></remarks>
    Public Function GetTotal() As Double
        Dim result As Double = 0
        Try
            Dim total As Double = sReturnQuantity * sPriceSale
            Dim discount As Double = total * sDiscountPercent / 100
            Dim tax As Double = (total - discount) * sTaxPercent / 100
            result = total + tax - discount

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

End Class
