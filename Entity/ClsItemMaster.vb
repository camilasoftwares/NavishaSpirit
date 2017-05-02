Public Class ClsItemMaster
    Inherits ClsIdNameCreatedBy

    Private sItemCode As String = ""
    Private sVAT As Double = 0
    Private sPackType As String = ""
    Private sGenericId1 As Integer = cInvalidId
    Private sGenericId2 As Integer = cInvalidId
    Private sGenericId3 As Integer = cInvalidId
    Private sPIId As Integer = cInvalidId
    Private sManufacturerId As Integer = cInvalidId
    Private sCategoryId As Integer = cInvalidId
    Private sScheduleId As Integer = cInvalidId
    Private sStorageId As Integer = cInvalidId
    Private sMinimum As Double = 0
    Private sNameFirst As String = ""

    Public Property ItemCode() As String
        Get
            Return sItemCode
        End Get
        Set(ByVal value As String)
            sItemCode = value.Trim
        End Set
    End Property

    Public Property VAT() As Double
        Get
            Return sVAT
        End Get
        Set(ByVal value As Double)
            sVAT = value
        End Set
    End Property

    Public Property PackType() As String
        Get
            Return sPackType
        End Get
        Set(ByVal value As String)
            sPackType = value.Trim
        End Set
    End Property

    Public Property GenericId1() As Integer
        Get
            Return sGenericId1
        End Get
        Set(ByVal value As Integer)
            sGenericId1 = value
        End Set
    End Property

    Public Property GenericId2() As Integer
        Get
            Return sGenericId2
        End Get
        Set(ByVal value As Integer)
            sGenericId2 = value
        End Set
    End Property

    Public Property GenericId3() As Integer
        Get
            Return sGenericId3
        End Get
        Set(ByVal value As Integer)
            sGenericId3 = value
        End Set
    End Property

    Public Property PIId() As Integer
        Get
            Return sPIId
        End Get
        Set(ByVal value As Integer)
            sPIId = value
        End Set
    End Property

    Public Property ManufacturerId() As Integer
        Get
            Return sManufacturerId
        End Get
        Set(ByVal value As Integer)
            sManufacturerId = value
        End Set
    End Property

    Public Property CategoryId() As Integer
        Get
            Return sCategoryId
        End Get
        Set(ByVal value As Integer)
            sCategoryId = value
        End Set
    End Property

    Public Property ScheduleId() As Integer
        Get
            Return sScheduleId
        End Get
        Set(ByVal value As Integer)
            sScheduleId = value
        End Set
    End Property

    Public Property StorageId() As Integer
        Get
            Return sStorageId
        End Get
        Set(ByVal value As Integer)
            sStorageId = value
        End Set
    End Property

    Public Property Minimum() As Double
        Get
            Return sMinimum
        End Get
        Set(ByVal value As Double)
            sMinimum = value
        End Set
    End Property

    Public Property NameFirst() As String
        Get
            Return sNameFirst
        End Get
        Set(ByVal value As String)
            sNameFirst = value.Trim
        End Set
    End Property

End Class
