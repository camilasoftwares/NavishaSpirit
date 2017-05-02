Public Class ClsCurrentFreeStock

    Private sId As Long = cInvalidId
    Private sItemId As Long = cInvalidId
    Private sBatch As String = ""
    Private sPackQuantity As Double = 0
    Private sCurrentQuantity As Double = 0
    Private sRemark As String = ""
    Private sUserId As String = ""
    Private sDateOn As Date = DateDefault

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

    Public ReadOnly Property ItemName() As String
        Get
            Return lItemName + "[" + sBatch + "]"
        End Get
    End Property

    Public Sub SetName(ByVal name As String)
        lItemName = name
    End Sub

End Class
