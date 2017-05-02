Public Class ClsPurchaseReturnMaster

    Private sId As Integer = cInvalidId
    Private sPurchaseReturnCode As String = ""
    Private sVendorId As Integer = cInvalidId
    Private sMode As String = ""
    Private sPurchaseId As Integer = cInvalidId
    Private sRemark As String = ""
    Private sUserId As String = ""
    Private sDateOn As Date = DateDefault
    Private sReturnDate As Date = DateDefault
    Private sNotClosed As Boolean = False
    Private sDiscountAmount As Double = 0

    Public Property Id() As Integer
        Get
            Return sId
        End Get
        Set(ByVal value As Integer)
            sId = value
        End Set
    End Property

    Public Property PurchaseReturnCode() As String
        Get
            Return sPurchaseReturnCode
        End Get
        Set(ByVal value As String)
            sPurchaseReturnCode = value.Trim
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

    Public Property PurchaseId() As Integer
        Get
            Return sPurchaseId
        End Get
        Set(ByVal value As Integer)
            sPurchaseId = value
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

    Public Property ReturnDate() As Date
        Get
            Return sReturnDate
        End Get
        Set(ByVal value As Date)
            sReturnDate = value
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

End Class
