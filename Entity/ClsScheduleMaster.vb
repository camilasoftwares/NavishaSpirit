Public Class ClsScheduleMaster
    Inherits ClsIdNameCreatedBy

    Private sColor As String = ""
    Private sPrompt As Boolean = False

    Public Property Color() As String
        Get
            Return sColor
        End Get
        Set(ByVal value As String)
            sColor = value.Trim
        End Set
    End Property

    Public Property Prompt() As Boolean
        Get
            Return sPrompt
        End Get
        Set(ByVal value As Boolean)
            sPrompt = value
        End Set
    End Property

End Class
