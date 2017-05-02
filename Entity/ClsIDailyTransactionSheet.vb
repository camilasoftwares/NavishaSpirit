Public Class ClsDailyTransactionSheet
    'Inherits ClsIdNameCreatedBy

    Private sItemCode As String = ""
    Private sCategory As String = ""
    Private sPackType As String = ""
    Private sItemName As String = ""
    Private dOpeningQty As Decimal = 0.00
    Private dPurchaseQty As Decimal = 0.00
    Private dTotalQty As Decimal = 0.00
    Private dSaleQty As Decimal = 0.00
    Private dClosingQty As Decimal = 0.00
    Private dSaleRate As Decimal = 0.00
    Private dAmount As Decimal = 0.00
    Private dGrossTotal As Decimal = 0.00
    Private dTransferQty As Decimal = 0.00

    Public Property Category() As String
        Get
            Return sCategory
        End Get
        Set(ByVal value As String)
            sCategory = value.Trim
        End Set
    End Property

    Public Property ItemCode() As String
        Get
            Return sItemCode
        End Get
        Set(ByVal value As String)
            sItemCode = value.Trim
        End Set
    End Property

    Public Property ItemName() As String
        Get
            Return sItemName
        End Get
        Set(ByVal value As String)
            sItemName = value.Trim
        End Set
    End Property

    Public Property PackType() As String
        Get
            Return sPackType
        End Get
        Set(ByVal value As String)
            sPackType = value.Trim
        End Set
    End Property

    Public Property OpeningQty() As Decimal
        Get
            Return dOpeningQty
        End Get
        Set(ByVal value As Decimal)
            dOpeningQty = value
        End Set
    End Property

    Private dOpeningPrice As Decimal
    Public Property OpeningPrice() As Decimal
        Get
            Return dOpeningPrice
        End Get
        Set(ByVal value As Decimal)
            dOpeningPrice = value
        End Set
    End Property

    Public Property PurchaseQty() As Decimal
        Get
            Return dPurchaseQty
        End Get
        Set(ByVal value As Decimal)
            dPurchaseQty = value
        End Set
    End Property

    Private dOutPrice As Decimal
    Public Property OutPrice() As Decimal
        Get
            Return dOutPrice
        End Get
        Set(ByVal value As Decimal)
            dOutPrice = value
        End Set
    End Property

    Public ReadOnly Property TotalQty() As Decimal
        Get
            Return dOpeningQty + dPurchaseQty
        End Get
    End Property

    Public Property SaleQty() As Decimal
        Get
            Return dSaleQty
        End Get
        Set(ByVal value As Decimal)
            dSaleQty = value
            InPrice = dSaleQty * dSaleRate
        End Set
    End Property

    Public Property SaleRate() As Decimal
        Get
            Return dSaleRate
        End Get
        Set(ByVal value As Decimal)
            dSaleRate = value
        End Set
    End Property

    Private dInPrice As Decimal
    Public Property InPrice() As Decimal
        Get
            Return dInPrice
        End Get
        Set(ByVal value As Decimal)
            dInPrice = value
        End Set
    End Property

    'Public Property TransferQty() As Decimal
    '    Get
    '        Return dTransferQty
    '    End Get
    '    Set(ByVal value As Decimal)
    '        dTransferQty = value
    '    End Set
    'End Property

    Public ReadOnly Property ClosingQty() As Decimal
        Get
            Return TotalQty - (SaleQty + dTransferQty)
        End Get
    End Property

End Class
