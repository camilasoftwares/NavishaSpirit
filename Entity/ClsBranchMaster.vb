Public Class ClsBranchMaster
    Inherits ClsIdNameCreatedBy

    Private sBranchCode As String = ""
    Private sAddress As String = ""
    Private sCity As String = ""
    Private sPin As String = ""
    Private sContactPerson As String = ""
    Private sPhone As String = ""
    Private sFax As String = ""
    Private sEMail As String = ""
    Private sState As String = ""
    Private sUpTtNo As String = ""
    Private sTinNo As String = ""

    Public Property BranchCode() As String
        Get
            Return sBranchCode
        End Get
        Set(ByVal value As String)
            sBranchCode = value.Trim
        End Set
    End Property

    Public Property Address() As String
        Get
            Return sAddress
        End Get
        Set(ByVal value As String)
            sAddress = value.Trim
        End Set
    End Property

    Public Property City() As String
        Get
            Return sCity
        End Get
        Set(ByVal value As String)
            sCity = value.Trim
        End Set
    End Property

    Public Property Pin() As String
        Get
            Return sPin
        End Get
        Set(ByVal value As String)
            sPin = value.Trim
        End Set
    End Property

    Public Property ContactPerson() As String
        Get
            Return sContactPerson
        End Get
        Set(ByVal value As String)
            sContactPerson = value.Trim
        End Set
    End Property

    Public Property Phone() As String
        Get
            Return sPhone
        End Get
        Set(ByVal value As String)
            sPhone = value.Trim
        End Set
    End Property

    Public Property Fax() As String
        Get
            Return sFax
        End Get
        Set(ByVal value As String)
            sFax = value.Trim
        End Set
    End Property

    Public Property EMail() As String
        Get
            Return sEMail
        End Get
        Set(ByVal value As String)
            sEMail = value.Trim
        End Set
    End Property

    Public Property State() As String
        Get
            Return sState
        End Get
        Set(ByVal value As String)
            sState = value.Trim
        End Set
    End Property

    Public Property UpTtNo() As String
        Get
            Return sUpTtNo
        End Get
        Set(ByVal value As String)
            sUpTtNo = value.Trim
        End Set
    End Property

    Public Property TinNo() As String
        Get
            Return sTinNo
        End Get
        Set(ByVal value As String)
            sTinNo = value.Trim
        End Set
    End Property

End Class
