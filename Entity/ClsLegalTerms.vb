Public Class ClsLegalTerms

    Private sId As Integer = cInvalidId
    Private sName As String = ""

    Public Property Id() As Integer
        Get
            Return sId
        End Get
        Set(ByVal value As Integer)
            sId = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return sName
        End Get
        Set(ByVal value As String)
            sName = value.Trim
        End Set
    End Property

End Class
