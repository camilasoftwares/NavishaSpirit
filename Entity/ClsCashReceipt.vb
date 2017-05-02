Public Class ClsCashReceipt

    Private sId As Long = cInvalidId
    Private sToHeadId As Integer = cInvalidId
    Private sFromHeadId As Integer = cInvalidId
    Private sAmount As Double = 0
    Private sInvoiceNo As String = ""
    Private sRemark As String = ""
    Private sUserId As String = ""
    Private sDateOn As Date = DateDefault
    Private sReceiptDate As Date = DateDefault

    Public Property Id() As Long
        Get
            Return sId
        End Get
        Set(ByVal value As Long)
            sId = value
        End Set
    End Property

    Public Property ToHeadId() As Integer
        Get
            Return sToHeadId
        End Get
        Set(ByVal value As Integer)
            sToHeadId = value
        End Set
    End Property

    Public Property FromHeadId() As Integer
        Get
            Return sFromHeadId
        End Get
        Set(ByVal value As Integer)
            sFromHeadId = value
        End Set
    End Property

    Public Property Amount() As Double
        Get
            Return sAmount
        End Get
        Set(ByVal value As Double)
            sAmount = value
        End Set
    End Property

    Public Property InvoiceNo() As String
        Get
            Return sInvoiceNo
        End Get
        Set(ByVal value As String)
            sInvoiceNo = value.Trim
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

    Public Property ReceiptDate() As Date
        Get
            Return sReceiptDate
        End Get
        Set(ByVal value As Date)
            sReceiptDate = value
        End Set
    End Property

End Class
