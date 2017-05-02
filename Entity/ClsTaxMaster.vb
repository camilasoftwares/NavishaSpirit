Public Class ClsTaxMaster

    Private sId As Integer = cInvalidId
    Private sName As String = ""
    Private sTaxPercent As Double = 0
    Private sDisplayName As String = ""

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

    Public Property TaxPercent() As Double
        Get
            Return sTaxPercent
        End Get
        Set(ByVal value As Double)
            sTaxPercent = value
        End Set
    End Property

    Public Property DisplayName() As String
        Get
            Return sDisplayName
        End Get
        Set(ByVal value As String)
            sDisplayName = value.Trim
        End Set
    End Property

End Class
