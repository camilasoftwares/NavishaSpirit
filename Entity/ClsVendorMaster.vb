Public Class ClsVendorMaster
    Inherits ClsIdNameCreatedBy

    Private sAccountId As String = ""
    Private sAddress As String = ""
    Private sPhoneR As String = ""
    Private sPhoneO As String = ""
    Private sMobile As String = ""
    Private sEMail As String = ""
    Private sCity As String = ""
    Private sPin As String = ""
    Private sUpTtNo As String = ""
    Private sTinNo As String = ""

    Public Property AccountId() As String
        Get
            Return sAccountId
        End Get
        Set(ByVal value As String)
            sAccountId = value.Trim
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

    Public Property PhoneR() As String
        Get
            Return sPhoneR
        End Get
        Set(ByVal value As String)
            sPhoneR = value.Trim
        End Set
    End Property

    Public Property PhoneO() As String
        Get
            Return sPhoneO
        End Get
        Set(ByVal value As String)
            sPhoneO = value.Trim
        End Set
    End Property

    Public Property Mobile() As String
        Get
            Return sMobile
        End Get
        Set(ByVal value As String)
            sMobile = value.Trim
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
