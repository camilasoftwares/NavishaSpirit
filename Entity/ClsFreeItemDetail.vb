Public Class ClsFreeItemDetail

    Private sId As Long = cInvalidId
    Private sPurchaseId As Integer = cInvalidId
    Private sItemId As Integer = cInvalidId
    Private sBatch As String = ""
    Private sPackQuantity As Double = 0
    Private sFreeQuantity As Double = 0
    Private sRemark As String = ""
    Private sUserId As String = ""
    Private sDateOn As Date = DateDefault

    Public Property Id() As Long
        Get
            Return sId
        End Get
        Set(ByVal value As Long)
            sId = value
        End Set
    End Property

    Public Property PurchaseId() As Integer
        Get
            Return sPurchaseId
        End Get
        Set(ByVal value As Integer)
            sPurchaseId = value
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

    Public Property FreeQuantity() As Double
        Get
            Return sFreeQuantity
        End Get
        Set(ByVal value As Double)
            sFreeQuantity = value
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

    Public Property PackQuantity() As Double
        Get
            Return sPackQuantity
        End Get
        Set(ByVal value As Double)
            sPackQuantity = value
        End Set
    End Property

End Class
