Public Class ClsPurchaseOrderDetail

    Private sId As Long = cInvalidId
    Private sOrderId As Integer = cInvalidId
    Private sItemId As Integer = cInvalidId
    Private sOrderQuantity As Double = 0
    Private sOrderPrice As Double = 0
    Private sPricePurchasePrevious As Double = 0
    Private sVendorId As Integer = cInvalidId
    Private sManufacturerId As Integer = cInvalidId

    Public Property Id() As Long
        Get
            Return sId
        End Get
        Set(ByVal value As Long)
            sId = value
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

    Public Property ItemId() As Integer
        Get
            Return sItemId
        End Get
        Set(ByVal value As Integer)
            sItemId = value
        End Set
    End Property

    Public Property OrderQuantity() As Double
        Get
            Return sOrderQuantity
        End Get
        Set(ByVal value As Double)
            sOrderQuantity = value
        End Set
    End Property

    Public Property OrderPrice() As Double
        Get
            Return sOrderPrice
        End Get
        Set(ByVal value As Double)
            sOrderPrice = value
        End Set
    End Property

    Public Property PricePurchasePrevious() As Double
        Get
            Return sPricePurchasePrevious
        End Get
        Set(ByVal value As Double)
            sPricePurchasePrevious = value
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

    Public Property ManufacturerId() As Integer
        Get
            Return sManufacturerId
        End Get
        Set(ByVal value As Integer)
            sManufacturerId = value
        End Set
    End Property

End Class
