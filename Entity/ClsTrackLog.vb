Public Class ClsTrackLog

    Dim sDiff As Long = 0
    Dim sBillNo As String = ""
    Dim sUserId As String = ""
    Dim sDateOn As Date = DateDefault

    Public Property Diff() As Long
        Get
            Return sDiff
        End Get
        Set(ByVal value As Long)
            sDiff = value
        End Set
    End Property

    Public Property BillNo() As String
        Get
            Return sBillNo
        End Get
        Set(ByVal value As String)
            sBillNo = value.Trim
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

End Class
