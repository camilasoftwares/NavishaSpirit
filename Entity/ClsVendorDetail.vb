Public Class ClsVendorDetail

    Private sId As Integer = cInvalidId
    Private sAccountId As String = ""
    Private sManufacturerId As Integer = cInvalidId

    Public Property Id() As Integer
        Get
            Return sId
        End Get
        Set(ByVal value As Integer)
            sId = value
        End Set
    End Property

    Public Property AccountId() As String
        Get
            Return sAccountId
        End Get
        Set(ByVal value As String)
            sAccountId = value.Trim
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
