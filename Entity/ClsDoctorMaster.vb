Public Class ClsDoctorMaster
    Inherits ClsIdNameCreatedBy

    Private sAddress As String = ""
    Private sPhoneR As String = ""
    Private sPhoneO As String = ""
    Private sMobile As String = ""
    Private sEMail As String = ""
    Private sCity As String = ""
    Private sPin As String = ""
    Private sSpecialityId As Integer = cInvalidId

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

    Public Property SpecialityId() As Integer
        Get
            Return sSpecialityId
        End Get
        Set(ByVal value As Integer)
            sSpecialityId = value
        End Set
    End Property

End Class
