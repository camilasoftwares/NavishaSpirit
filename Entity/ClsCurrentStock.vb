Public Class ClsCurrentStock

    Private sId As Long = cInvalidId
    Private sItemId As Long = cInvalidId
    Private sBatch As String = ""
    Private sExpiryDate As Date = DateDefault
    Private sPackQuantity As Double = 0
    Private sCurrentQuantity As Double = 0
    Private sPricePurchase As Double = 0
    Private sStorageId As Integer = cInvalidId
    Private sRemark As String = ""
    Private sUserId As String = ""
    Private sDateOn As Date = DateDefault
    Private sManufactureDate As Date = DateDefault
    Private sMRP As Double = 0
    Private sPTR As Double = 0
    Private sManufacturerId As Integer = cInvalidId
    Private sPTS As Double = 0
    Private sRate1 As Double = 0
    Private sRate2 As Double = 0
    Private sRate3 As Double = 0

    Private lItemName As String = ""

    Public Property Id() As Long
        Get
            Return sId
        End Get
        Set(ByVal value As Long)
            sId = value
        End Set
    End Property

    Public Property ItemId() As Long
        Get
            Return sItemId
        End Get
        Set(ByVal value As Long)
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

    Public Property CurrentQuantity() As Double
        Get
            Return sCurrentQuantity
        End Get
        Set(ByVal value As Double)
            sCurrentQuantity = value
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

    Public Property ManufactureDate() As Date
        Get
            Return sManufactureDate
        End Get
        Set(ByVal value As Date)
            sManufactureDate = value
        End Set
    End Property

    Public Property MRP() As Double
        Get
            Return sMRP
        End Get
        Set(ByVal value As Double)
            sMRP = value
        End Set
    End Property

    Public Property PTR() As Double
        Get
            Return sPTR
        End Get
        Set(ByVal value As Double)
            sPTR = value
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

    Public Property PTS() As Double
        Get
            Return sPTS
        End Get
        Set(ByVal value As Double)
            sPTS = value
        End Set
    End Property

    Public Property Rate1() As Double
        Get
            Return sRate1
        End Get
        Set(ByVal value As Double)
            sRate1 = value
        End Set
    End Property

    Public Property Rate2() As Double
        Get
            Return sRate2
        End Get
        Set(ByVal value As Double)
            sRate2 = value
        End Set
    End Property

    Public Property Rate3() As Double
        Get
            Return sRate3
        End Get
        Set(ByVal value As Double)
            sRate3 = value
        End Set
    End Property

    '******************* Virtual Property
    Public ReadOnly Property ItemName() As String
        Get
            Return lItemName + "[" + sBatch + "]"
        End Get
    End Property

    Public ReadOnly Property ItemNameWithQuantity() As String
        Get
            Return lItemName + "[" + sBatch + "] (" + CStr(sCurrentQuantity) + ")"
        End Get
    End Property

    Public ReadOnly Property BatchWithQuantity() As String
        Get
            Return sBatch + "(" + CStr(sCurrentQuantity) + ")"
        End Get
    End Property

    Public Sub SetName(ByVal name As String)
        lItemName = name
    End Sub

End Class
