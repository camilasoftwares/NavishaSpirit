Public Class ClsTransporter

    Private sId As Integer = cInvalidId
    Private sName As String = ""
    Private sAddress As String = ""
    Private sPhoneR As String = ""
    Private sPhoneO As String = ""
    Private sMobile As String = ""
    Private sEMail As String = ""
    Private sCity As String = ""
    Private sPin As String = ""
    Private sRepresentative As String = ""
    Private sPhoneRepresentative As String = ""
    Private sUserId As String = ""
    Private sDateOn As Date = DateDefault

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

    Public Property Representative() As String
        Get
            Return sRepresentative
        End Get
        Set(ByVal value As String)
            sRepresentative = value.Trim
        End Set
    End Property

    Public Property PhoneRepresentative() As String
        Get
            Return sPhoneRepresentative
        End Get
        Set(ByVal value As String)
            sPhoneRepresentative = value.Trim
        End Set
    End Property

End Class
