Public Class ClsGenericMaster
    Inherits ClsIdNameCreatedBy

    Private sStatus As String = ""

    Public Property Status() As String
        Get
            Return sStatus
        End Get
        Set(ByVal value As String)
            sStatus = value.Trim
        End Set
    End Property

End Class
