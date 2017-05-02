Public Class ClsPurchaseOrderMaster

    Private sId As Integer = cInvalidId
    Private sOrderDate As Date = DateDefault
    'Private sStockLimit As Double = 0
    'Private sPurchaseLimit As Double = 0
    Private sRemark As String = ""
    Private sUserId As String = ""
    Private sDateOn As Date = DateDefault
    Private sNotClosed As Boolean = False

    Public Property Id() As Integer
        Get
            Return sId
        End Get
        Set(ByVal value As Integer)
            sId = value
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

    'Public Property StockLimit() As Double
    '    Get
    '        Return sStockLimit
    '    End Get
    '    Set(ByVal value As Double)
    '        sStockLimit = value
    '    End Set
    'End Property

    'Public Property PurchaseLimit() As Double
    '    Get
    '        Return sPurchaseLimit
    '    End Get
    '    Set(ByVal value As Double)
    '        sPurchaseLimit = value
    '    End Set
    'End Property

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

    Public Property NotClosed() As Boolean
        Get
            Return sNotClosed
        End Get
        Set(ByVal value As Boolean)
            sNotClosed = value
        End Set
    End Property

End Class
