Public Class ClsSalesReturnMaster

    Private sId As Long = cInvalidId
    Private sSaleId As Long = cInvalidId
    Private sCustomerId As Integer = cInvalidId
    Private sDoctorId As Integer = cInvalidId
    Private sSalesReturnCode As String = ""
    Private sStatus As String = ""
    Private sRemark As String = ""
    Private sReturnDate As Date = DateDefault
    Private sUserId As String = ""
    Private sDateOn As Date = DateDefault
    Private sNotClosed As Boolean = False
    Private sDiscountAmount As Double = 0

    Public Property Id() As Long
        Get
            Return sId
        End Get
        Set(ByVal value As Long)
            sId = value
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

    Public Property SalesReturnCode() As String
        Get
            Return sSalesReturnCode
        End Get
        Set(ByVal value As String)
            sSalesReturnCode = value.Trim
        End Set
    End Property

    Public Property Status() As String
        Get
            Return sStatus
        End Get
        Set(ByVal value As String)
            sStatus = value.Trim
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

    Public Property ReturnDate() As Date
        Get
            Return sReturnDate
        End Get
        Set(ByVal value As Date)
            sReturnDate = value
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

End Class
