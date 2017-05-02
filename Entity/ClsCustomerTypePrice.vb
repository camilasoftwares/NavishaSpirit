Public Class ClsCustomerTypePrice

    Private sId As Long = cInvalidId
    Private sCustomerTypeId As Integer = cInvalidId
    Private sItemId As Long = cInvalidId
    Private sBatch As String = ""
    Private sPrice As Double = 0

    Public Property Id() As Long
        Get
            Return sId
        End Get
        Set(ByVal value As Long)
            sId = value
        End Set
    End Property

    Public Property CustomerTypeId() As Integer
        Get
            Return sCustomerTypeId
        End Get
        Set(ByVal value As Integer)
            sCustomerTypeId = value
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

    Public Property Price() As Double
        Get
            Return sPrice
        End Get
        Set(ByVal value As Double)
            sPrice = value
        End Set
    End Property

End Class
