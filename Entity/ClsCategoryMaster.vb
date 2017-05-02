Public Class ClsCategoryMaster
    Inherits ClsIdNameCreatedBy

    Private sPIId As Integer = cInvalidId

    Public Property PIId() As Integer
        Get
            Return sPIId
        End Get
        Set(ByVal value As Integer)
            sPIId = value
        End Set
    End Property

End Class
