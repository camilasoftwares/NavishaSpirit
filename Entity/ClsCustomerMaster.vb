Public Class ClsCustomerMaster
    Inherits ClsIdNameCreatedBy

    Private sAccountId As String = ""
    'Private sCardNo As String = ""
    Private sAddress As String = ""
    Private sPhoneR As String = ""
    Private sPhoneO As String = ""
    Private sMobile As String = ""
    Private sEMail As String = ""
    Private sCity As String = ""
    Private sPin As String = ""
    Private sMemberOf As String = ""
    'Private sDlNo As String = ""
    Private sUpTtNo As String = ""
    Private sTinNo As String = ""
    Private sCustomerTypeId As Integer = cInvalidId
    Private sDueDays As Integer = 0
    Private sTaxId As Integer = cInvalidId
    Private sHQId As Integer = cInvalidId

    Public Property AccountId() As String
        Get
            Return sAccountId
        End Get
        Set(ByVal value As String)
            sAccountId = value.Trim
        End Set
    End Property

    'Public Property CardNo() As String
    '    Get
    '        Return sCardNo
    '    End Get
    '    Set(ByVal value As String)
    '        sCardNo = value.Trim
    '    End Set
    'End Property

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

    Public Property MemberOf() As String
        Get
            Return sMemberOf
        End Get
        Set(ByVal value As String)
            sMemberOf = value.Trim
        End Set
    End Property

    'Public Property DlNo() As String
    '    Get
    '        Return sDlNo
    '    End Get
    '    Set(ByVal value As String)
    '        sDlNo = value.Trim
    '    End Set
    'End Property

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

    Public Property CustomerTypeId() As Integer
        Get
            Return sCustomerTypeId
        End Get
        Set(ByVal value As Integer)
            sCustomerTypeId = value
        End Set
    End Property

    Public Property DueDays() As Integer
        Get
            Return sDueDays
        End Get
        Set(ByVal value As Integer)
            sDueDays = value
        End Set
    End Property

    Public Property TaxId() As Integer
        Get
            Return sTaxId
        End Get
        Set(ByVal value As Integer)
            sTaxId = value
        End Set
    End Property

    Public Property HQId() As Integer
        Get
            Return sHQId
        End Get
        Set(ByVal value As Integer)
            sHQId = value
        End Set
    End Property

End Class
