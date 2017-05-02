'This function is used to get readymade scripts by passing values.
'It helps in maintaining scripts with change in database

Public Class ClsScripts
    Inherits ClsScriptFunctions

#Region "Local variables and Constants"
    Shared sInstance As ClsScripts
#End Region

#Region "Public Functions"

    ''' <summary>
    ''' This function is used to get Instance of this class
    ''' </summary>
    ''' <returns>Instance of this class</returns>
    ''' <remarks></remarks>
    Public Shared Function GetInstance() As ClsScripts
        If sInstance Is Nothing Then
            sInstance = New ClsScripts
        End If

        Return sInstance
    End Function

#End Region

#Region "Tables Names"
    Private Const cProfileMaster As String = "ProfileMaster"
    Private Const cApplicationValueMaster As String = "ApplicationValueMaster"
    Private Const cUserMaster As String = "UserMaster"
    Private Const cCompanyInfo As String = "CompanyInfo"
    Private Const cBranchMaster As String = "BranchMaster"
    Private Const cCustomerMaster As String = "CustomerMaster"
    Private Const cSpecialityMaster As String = "SpecialityMaster"
    Private Const cDoctorMaster As String = "DoctorMaster"
    Private Const cManufacturerMaster As String = "ManufacturerMaster"
    Private Const cVendorMaster As String = "VendorMaster"
    Private Const cVendorDetail As String = "VendorDetail"
    Private Const cStorageMaster As String = "StorageMaster"
    Private Const cGenericMaster As String = "GenericMaster"
    Private Const cPIMaster As String = "PIMaster"
    Private Const cCategoryMaster As String = "CategoryMaster"
    Private Const cScheduleMaster As String = "ScheduleMaster"
    Private Const cItemMaster As String = "ItemMaster"
    Private Const cSalesMaster As String = "SalesMaster"
    Private Const cSalesDetail As String = "SalesDetail"
    Private Const cPurchaseMaster As String = "PurchaseMaster"
    Private Const cPurchaseOrderMaster As String = "PurchaseOrderMaster"
    Private Const cPurchaseDetail As String = "PurchaseDetail"
    Private Const cPurchaseOrderDetail As String = "PurchaseOrderDetail"
    Private Const cAccountGroup As String = "AccountGroup"
    Private Const cTransactionStock As String = "TransactionStock"
    Private Const cDestructionSlipDetail As String = "destructionSlipDetail"
    Private Const cChequePayment As String = "ChequePayment"
    Private Const cCashReceipt As String = "CashReceipt"
    Private Const cChequeReceipt As String = "ChequeReceipt"
    Private Const cCurrentStock As String = "CurrentStock"
    Private Const cDestructionSlipMaster As String = "DestructionSlipMaster"
    Private Const cJournalEntry As String = "JournalEntry"
    Private Const cSalesReturnDetail As String = "SalesReturnDetail"
    Private Const cSalesReturnMaster As String = "SalesReturnMaster"
    Private Const cAccountHead As String = "accountHead"
    Private Const cTransactionAccount As String = "TransactionAccount"
    Private Const cCashPayment As String = "CashPayment"
    Private Const cExpiryDetail As String = "ExpiryDetail"
    Private Const cTempAccount As String = "TempAccount"
    Private Const cPurchaseReturnMaster As String = "PurchaseReturnMaster"
    Private Const cPurchaseReturnDetail As String = "PurchaseReturnDetail"
    Private Const cCurrentFreeStock As String = "CurrentFreeStock"
    Private Const cFreeItemDetail As String = "FreeItemDetail"
    Private Const cFreeStockTransaction As String = "FreeStockTransaction"
    Private Const cCustomerType As String = "CustomerType"
    Private Const cCustomerTypePrice As String = "CustomerTypePrice"
    Private Const cLoginList As String = "LoginList"
    Private Const cLegalTerms As String = "LegalTerms"
    Private Const cOpeningStock As String = "OpeningStock"
    Private Const cTransporter As String = "Transporter"
    Private Const cHQMaster As String = "HQMaster"
    Private Const cDivisionMaster As String = "DivisionMaster"
    Private Const cTaxMaster As String = "TaxMaster"
    Private Const cSampleMaster As String = "SampleMaster"
    Private Const cSampleDetail As String = "SampleDetail"
    Private Const cCreditNote As String = "CreditNote"
    Private Const cDebitNote As String = "DebitNote"

#End Region

#Region "Common Functions"

    Protected Overrides Function ResetSeedToZero(ByVal tableName As String) As String
        Dim sql As String = ""
        sql = "DBCC CHECKIDENT(" + tableName + ", RESEED, 0)"

        Return sql
    End Function

    Public Overrides Function SQLRound(ByVal value As Double, ByVal uptoPos As UInteger) As String
        Dim sql As String = ""
        sql = "Select ROUND(" + CStr(value) + "," + CStr(uptoPos) + ")"

        Return sql
    End Function

    Private Function CaseSensitive() As String
        Dim sql As String = ""
        sql = " COLLATE Latin1_General_CS_AS "

        Return sql
    End Function

#End Region

#Region "AccountGroup"

    Public Overrides Function AccountGroupUpdatable(ByRef accountGroupObj As ClsAccountGroup) As String
        Dim sql As String = ""
        With accountGroupObj
            sql = "select * from " + cAccountGroup
            sql = sql + " where "
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + " and " + cId
            sql = sql + "<>" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function GetAllAccountGroup() As String
        Dim sql As String = ""
        sql = "select * from " + cAccountGroup
        sql = sql + " Order by " + cName

        Return sql
    End Function

    Public Overrides Function GetAllAccountGroupLike(ByVal fieldName As String, ByVal likeValue As String) As String
        Dim sql As String = ""
        sql = "select * from " + cAccountGroup
        If fieldName = cGroupCode Or fieldName = cName Or fieldName = cAvailableIn Then
            sql = sql + " where " + fieldName + " like '" + likeValue.Trim + "%'"
            sql = sql + " Order by " + cName
        Else
            sql = ""
        End If

        Return sql
    End Function

    Protected Overrides Function GetAllAccountGroupIdNameLike(ByVal likeValue As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cAccountGroup
        sql = sql + " where " + cName + " like '" + likeValue.Trim + "%'"

        Return sql
    End Function

    Public Overrides Function GetAccountGroup(ByVal id As Integer) As String
        Dim sql As String = ""
        sql = "select * from " + cAccountGroup
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Protected Overrides Function GetAccountGroupId(ByVal groupCode As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cAccountGroup
        sql = sql + " where " + cGroupCode + " ='" + groupCode.Trim + "'"

        Return sql
    End Function

    Public Overrides Function InsertIntoAccountGroup(ByRef accountGroupObj As ClsAccountGroup) As String
        Dim sql As String = ""
        sql = "insert into " + cAccountGroup + "("
        sql = sql + cName
        sql = sql + "," + cGroupCode
        sql = sql + "," + cAvailableIn
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With accountGroupObj
            sql = sql + "'" + .Name + "'"
            sql = sql + ",'" + .GroupCode + "'"
            sql = sql + ",'" + .AvailableIn + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + " select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateAccountGroup(ByRef accountGroupObj As ClsAccountGroup) As String
        Dim sql As String = ""
        sql = "update " + cAccountGroup
        sql = sql + " set "
        With accountGroupObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cGroupCode
            sql = sql + "='" + .GroupCode + "'"
            sql = sql + "," + cAvailableIn
            sql = sql + "='" + .AvailableIn + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "AccountHead"

    Public Overrides Function AccountHeadUpdatable(ByRef accountHeadObj As ClsAccountHead) As String
        Dim sql As String = ""
        With accountHeadObj
            sql = "select * from " + cAccountHead
            sql = sql + " where "
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + " and " + cId
            sql = sql + "<>" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function GetAllAccountHead() As String
        Dim sql As String = ""
        sql = "select * from " + cAccountHead

        Return sql
    End Function

    Public Overrides Function GetAllAccountHeadForGroupId(ByVal groupId As Integer) As String
        Dim sql As String = ""
        sql = "select * from " + cAccountHead
        sql = sql + " where " + cGroupId + " = " + CStr(groupId)
        sql = sql + " Order by " + cName

        Return sql
    End Function

    Public Overrides Function GetAllAccountHeadLike(ByVal fieldName As String, ByVal likeValue As String) As String
        Dim sql As String = ""
        sql = "select * from " + cAccountHead
        If fieldName = cHeadCode Or fieldName = cName Then
            sql = sql + " where " + fieldName + " like '" + likeValue.Trim + "%'"
            sql = sql + " Order by " + cName
        ElseIf fieldName = cGroupId Then
            sql = sql + " where " + cGroupId + " in (" + GetAllAccountGroupIdNameLike(likeValue) + ")"
            sql = sql + " Order by " + cName
        Else
            sql = ""
        End If

        Return sql
    End Function

    Protected Overrides Function GetAllAccountHeadIdNameLike(ByVal name As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cAccountHead
        sql = sql + " where " + cName + " like '" + name.Trim + "%'"
        
        Return sql
    End Function

    Public Overrides Function GetAllAccountHeadForGroupCode(ByVal groupCode As String) As String
        Dim sql As String = ""
        sql = "select * from " + cAccountHead
        sql = sql + " where " + cGroupId + " in (" + GetAccountGroupId(groupCode) + ")"
        sql = sql + " Order by " + cName

        Return sql
    End Function

    Public Overrides Function GetAccountHead(ByVal id As Integer) As String
        Dim sql As String = ""
        sql = "select * from " + cAccountHead
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoAccountHead(ByRef accountHeadObj As ClsAccountHead) As String
        Dim sql As String = ""
        sql = "insert into " + cAccountHead + "("
        sql = sql + cHeadCode
        sql = sql + "," + cName
        sql = sql + "," + cGroupId
        sql = sql + "," + cOpeningBalance
        sql = sql + "," + cCrDr
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With accountHeadObj
            sql = sql + "'" + .HeadCode + "'"
            sql = sql + ",'" + .Name + "'"
            sql = sql + "," + CStr(.GroupId)
            sql = sql + "," + CStr(.OpeningBalance)
            sql = sql + ",'" + .CrDr + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateAccountHead(ByRef accountHeadObj As ClsAccountHead) As String
        Dim sql As String = ""
        sql = "update " + cAccountHead
        sql = sql + " set "
        With accountHeadObj
            sql = sql + cHeadCode
            sql = sql + "='" + .HeadCode + "'"
            sql = sql + "," + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cGroupId
            sql = sql + "=" + CStr(.GroupId)
            sql = sql + "," + cOpeningBalance
            sql = sql + "=" + CStr(.OpeningBalance)
            sql = sql + "," + cCrDr
            sql = sql + "='" + .CrDr + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "ApplicationValueMaster"

    Public Overrides Function GetApplicationValueMaster(ByVal name As String) As String
        Dim sql As String = ""
        sql = "select * from " + cApplicationValueMaster
        sql = sql + " where " + cName + "='" + name + "'"

        Return sql
    End Function

    Public Overrides Function InsertIntoApplicationValueMaster(ByRef applicationValueMasterObj As ClsApplicationValueMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cApplicationValueMaster + "("
        sql = sql + cName
        sql = sql + "," + cIdValue
        sql = sql + ") values("
        With applicationValueMasterObj
            sql = sql + "'" + .Name + "'"
            sql = sql + ",'" + .IdValue + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateApplicationValueMaster(ByRef applicationValueMasterObj As ClsApplicationValueMaster) As String
        Dim sql As String = ""
        sql = "update " + cApplicationValueMaster
        sql = sql + " set "
        With applicationValueMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cIdValue
            sql = sql + "='" + .IdValue + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "BranchMaster"

    Public Overrides Function GetAllBranchMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cBranchMaster

        Return sql
    End Function

    Public Overrides Function InsertIntoBranchMaster(ByRef branchMasterObj As ClsBranchMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cBranchMaster + "("
        sql = sql + cName
        sql = sql + "," + cBranchCode
        sql = sql + "," + cAddress
        sql = sql + "," + cCity
        sql = sql + "," + cPin
        sql = sql + "," + cContactPerson
        sql = sql + "," + cPhone
        sql = sql + "," + cFax
        sql = sql + "," + cEmail
        sql = sql + "," + cState
        sql = sql + "," + cUpTtNo
        sql = sql + "," + cTinNo
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With branchMasterObj
            sql = sql + "'" + .Name + "'"
            sql = sql + ",'" + .BranchCode + "'"
            sql = sql + ",'" + .Address + "'"
            sql = sql + ",'" + .City + "'"
            sql = sql + ",'" + .Pin + "'"
            sql = sql + ",'" + .ContactPerson + "'"
            sql = sql + ",'" + .Phone + "'"
            sql = sql + ",'" + .Fax + "'"
            sql = sql + ",'" + .EMail + "'"
            sql = sql + ",'" + .State + "'"
            sql = sql + ",'" + .UpTtNo + "'"
            sql = sql + ",'" + .TinNo + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateBranchMaster(ByRef branchMasterObj As ClsBranchMaster) As String
        Dim sql As String = ""
        sql = "update " + cBranchMaster
        sql = sql + " set "
        With branchMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cBranchCode
            sql = sql + "='" + .BranchCode + "'"
            sql = sql + "," + cAddress
            sql = sql + "='" + .Address + "'"
            sql = sql + "," + cCity
            sql = sql + "='" + .City + "'"
            sql = sql + "," + cPin
            sql = sql + "='" + .Pin + "'"
            sql = sql + "," + cContactPerson
            sql = sql + "='" + .ContactPerson + "'"
            sql = sql + "," + cPhone
            sql = sql + "='" + .Phone + "'"
            sql = sql + "," + cFax
            sql = sql + "='" + .Fax + "'"
            sql = sql + "," + cEmail
            sql = sql + "='" + .EMail + "'"
            sql = sql + "," + cState
            sql = sql + "='" + .State + "'"
            sql = sql + "," + cUpTtNo
            sql = sql + "='" + .UpTtNo + "'"
            sql = sql + "," + cTinNo
            sql = sql + "='" + .TinNo + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "CashPayment"

    Public Overrides Function GetAllCashPayment() As String
        Dim sql As String = ""
        sql = "select * from " + cCashPayment

        Return sql
    End Function

    Public Overrides Function GetAllCashPaymentValuesLike(ByVal forField As String, ByVal value As String) As String
        Dim sql As String = ""
        sql = "select * from " + cCashPayment
        If forField = cCode Then
            sql = sql + " where '" + cCAP + "' + Convert(varchar," + cId + ") like '" + value.Trim + "%'"
        ElseIf forField = cBillNo Then
            sql = sql + " where " + cBillNo + " like '" + value.Trim + "%'"
        ElseIf forField = cToHeadId Then
            sql = sql + " where " + cToHeadId + " in (" + GetAllAccountHeadIdNameLike(value) + ")"
        Else
            sql = ""
        End If

        If sql.Trim <> "" Then sql = sql + " order by " + cPaymentDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetAllCashPaymentLikePaymentDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
        Dim flag As Boolean = False
        Dim sql As String = ""
        sql = "select * from " + cCashPayment
        sql = sql + " where "

        If day.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(DAY, " + cPaymentDate + ") = '" + day + "' "
            flag = True
        End If

        If month.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(MONTH, " + cPaymentDate + ") = '" + month + "' "
            flag = True
        End If

        If year.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(YEAR, " + cPaymentDate + ") = '" + year + "' "
            flag = True
        End If

        If flag = False Then sql = ""
        If sql.Trim <> "" Then sql = sql + " order by " + cPaymentDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetCashPayment(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cCashPayment
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoCashPayment(ByRef CashPaymentObj As ClsCashPayment) As String
        Dim sql As String = ""
        sql = "insert into " + cCashPayment + "("
        sql = sql + cToHeadId
        sql = sql + "," + cFromHeadId
        sql = sql + "," + cAmount
        sql = sql + "," + cBillNo
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + "," + cPaymentDate
        sql = sql + ") values("
        With CashPaymentObj
            sql = sql + CStr(.ToHeadId)
            sql = sql + "," + CStr(.FromHeadId)
            sql = sql + "," + CStr(.Amount)
            sql = sql + ",'" + .BillNo + "'"
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
            sql = sql + ",'" + .PaymentDate.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateCashPayment(ByRef CashPaymentObj As ClsCashPayment) As String
        Dim sql As String = ""
        sql = "update " + cCashPayment
        sql = sql + " set "
        With CashPaymentObj
            sql = sql + cToHeadId
            sql = sql + "=" + CStr(.ToHeadId)
            sql = sql + "," + cFromHeadId
            sql = sql + "=" + CStr(.FromHeadId)
            sql = sql + "," + cAmount
            sql = sql + "=" + CStr(.Amount)
            sql = sql + "," + cBillNo
            sql = sql + "='" + .BillNo + "'"
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + "," + cPaymentDate
            sql = sql + "='" + .PaymentDate.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function DeleteCashPayment(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "delete " + cCashPayment
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

#End Region

#Region "CashReceipt"

    Public Overrides Function GetAllCashReceipt() As String
        Dim sql As String = ""
        sql = "select * from " + cCashReceipt

        Return sql
    End Function

    Public Overrides Function GetAllCashReceiptValuesLike(ByVal forField As String, ByVal value As String) As String
        Dim sql As String = ""
        sql = "select * from " + cCashReceipt
        If forField = cCode Then
            sql = sql + " where '" + cCAR + "' + Convert(varchar," + cId + ") like '" + value.Trim + "%'"
        ElseIf forField = cInvoiceNo Then
            sql = sql + " where " + cInvoiceNo + " like '" + value.Trim + "%'"
        ElseIf forField = cFromHeadId Then
            sql = sql + " where " + cFromHeadId + " in (" + GetAllAccountHeadIdNameLike(value) + ")"
        Else
            sql = ""
        End If

        If sql.Trim <> "" Then sql = sql + " order by " + cReceiptDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetAllCashReceiptLikeReceiptDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
        Dim flag As Boolean = False
        Dim sql As String = ""
        sql = "select * from " + cCashReceipt
        sql = sql + " where "

        If day.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(DAY, " + cReceiptDate + ") = '" + day + "' "
            flag = True
        End If

        If month.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(MONTH, " + cReceiptDate + ") = '" + month + "' "
            flag = True
        End If

        If year.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(YEAR, " + cReceiptDate + ") = '" + year + "' "
            flag = True
        End If

        If flag = False Then sql = ""
        If sql.Trim <> "" Then sql = sql + " order by " + cReceiptDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetCashReceipt(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cCashReceipt
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoCashReceipt(ByRef cashReceiptObj As ClsCashReceipt) As String
        Dim sql As String = ""
        sql = "insert into " + cCashReceipt + "("
        sql = sql + cFromHeadId
        sql = sql + "," + cToHeadId
        sql = sql + "," + cAmount
        sql = sql + "," + cInvoiceNo
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + "," + cReceiptDate
        sql = sql + ") values("
        With cashReceiptObj
            sql = sql + CStr(.FromHeadId)
            sql = sql + "," + CStr(.ToHeadId)
            sql = sql + "," + CStr(.Amount)
            sql = sql + ",'" + .InvoiceNo + "'"
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
            sql = sql + ",'" + .ReceiptDate.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateCashReceipt(ByRef cashReceiptObj As ClsCashReceipt) As String
        Dim sql As String = ""
        sql = "update " + cCashReceipt
        sql = sql + " set "
        With cashReceiptObj
            sql = sql + cFromHeadId
            sql = sql + "=" + CStr(.FromHeadId)
            sql = sql + "," + cToHeadId
            sql = sql + "=" + CStr(.ToHeadId)
            sql = sql + "," + cAmount
            sql = sql + "=" + CStr(.Amount)
            sql = sql + "," + cInvoiceNo
            sql = sql + "='" + .InvoiceNo + "'"
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + "," + cReceiptDate
            sql = sql + "='" + .ReceiptDate.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function DeleteCashReceipt(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "delete " + cCashReceipt
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

#End Region

#Region "CategoryMaster"

    Public Overrides Function CategoryMasterUpdatable(ByRef categoryMasterObj As ClsCategoryMaster) As String
        Dim sql As String = ""
        sql = "select * from " + cCategoryMaster
        sql = sql + " where "
        With categoryMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + " and " + cId
            sql = sql + "<>" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function GetAllCategoryMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cCategoryMaster

        Return sql
    End Function

    Protected Overrides Function GetAllCategoryMasterIdForNameLike(ByVal name As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cCategoryMaster
        sql = sql + " where " + cName + " like '" + name.Trim + "%'"

        Return sql
    End Function

    Public Overrides Function InsertIntoCategoryMaster(ByRef categoryMasterObj As ClsCategoryMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cCategoryMaster + "("
        sql = sql + cName
        sql = sql + "," + cPIId
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With categoryMasterObj
            sql = sql + "'" + .Name + "'"
            sql = sql + "," + CStr(.PIId)
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateCategoryMaster(ByRef categoryMasterObj As ClsCategoryMaster) As String
        Dim sql As String = ""
        sql = "update " + cCategoryMaster
        sql = sql + " set "
        With categoryMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cPIId
            sql = sql + "=" + CStr(.PIId)
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "ChequePayment"

    Public Overrides Function GetAllChequePayment() As String
        Dim sql As String = ""
        sql = "select * from " + cChequePayment

        Return sql
    End Function

    Public Overrides Function GetAllChequePaymentValuesLike(ByVal forField As String, ByVal value As String) As String
        Dim sql As String = ""
        sql = "select * from " + cChequePayment
        If forField = cCode Then
            sql = sql + " where '" + cCHP + "' + Convert(varchar," + cId + ") like '" + value.Trim + "%'"
        ElseIf forField = cBillNo Then
            sql = sql + " where " + cBillNo + " like '" + value.Trim + "%'"
        ElseIf forField = cToHeadId Then
            sql = sql + " where " + cToHeadId + " in (" + GetAllAccountHeadIdNameLike(value) + ")"
        Else
            sql = ""
        End If

        If sql.Trim <> "" Then sql = sql + " order by " + cPaymentDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetAllChequePaymentLikeDate(ByVal fieldName As String, ByVal day As String, ByVal month As String, ByVal year As String) As String
        Dim flag As Boolean = False
        Dim sql As String = ""
        sql = "select * from " + cChequePayment
        sql = sql + " where "

        If day.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(DAY, " + fieldName + ") = '" + day + "' "
            flag = True
        End If

        If month.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(MONTH, " + fieldName + ") = '" + month + "' "
            flag = True
        End If

        If year.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(YEAR, " + fieldName + ") = '" + year + "' "
            flag = True
        End If

        If flag = False Then sql = ""
        If sql.Trim <> "" Then sql = sql + " order by " + fieldName + " desc "

        Return sql
    End Function

    Public Overrides Function GetChequePayment(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cChequePayment
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoChequePayment(ByRef chequePaymentObj As ClsChequePayment) As String
        Dim sql As String = ""
        sql = "insert into " + cChequePayment + "("
        sql = sql + cFromHeadId
        sql = sql + "," + cToHeadId
        sql = sql + "," + cChequeNo
        sql = sql + "," + cChequeDate
        sql = sql + "," + cAmount
        sql = sql + "," + cBillNo
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + "," + cPaymentDate
        sql = sql + ") values("
        With chequePaymentObj
            sql = sql + CStr(.FromHeadId)
            sql = sql + "," + CStr(.ToHeadId)
            sql = sql + ",'" + .ChequeNo + "'"
            sql = sql + ",'" + .ChequeDate.ToString("s") + "'"
            sql = sql + "," + CStr(.Amount)
            sql = sql + ",'" + .BillNo + "'"
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
            sql = sql + ",'" + .PaymentDate.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateChequePayment(ByRef chequePaymentObj As ClsChequePayment) As String
        Dim sql As String = ""
        sql = "update " + cChequePayment
        sql = sql + " set "
        With chequePaymentObj
            sql = sql + cFromHeadId
            sql = sql + "=" + CStr(.FromHeadId)
            sql = sql + "," + cToHeadId
            sql = sql + "=" + CStr(.ToHeadId)
            sql = sql + "," + cChequeNo
            sql = sql + "='" + .ChequeNo + "'"
            sql = sql + "," + cChequeDate
            sql = sql + "='" + .ChequeDate.ToString("s") + "'"
            sql = sql + "," + cAmount
            sql = sql + "=" + CStr(.Amount)
            sql = sql + "," + cBillNo
            sql = sql + "='" + .BillNo + "'"
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + "," + cPaymentDate
            sql = sql + "='" + .PaymentDate.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function DeleteChequePayment(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "delete " + cChequePayment
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

#End Region

#Region "ChequeReceipt"

    Public Overrides Function GetAllChequeReceipt() As String
        Dim sql As String = ""
        sql = "select * from " + cChequeReceipt

        Return sql
    End Function

    Public Overrides Function GetAllBankName() As String
        Dim sql As String = ""
        sql = "select distinct(" + cBankName + ") from " + cChequeReceipt

        Return sql
    End Function

    Public Overrides Function GetAllChequeReceiptValuesLike(ByVal forField As String, ByVal value As String) As String
        Dim sql As String = ""
        sql = "select * from " + cChequeReceipt
        If forField = cCode Then
            sql = sql + " where '" + cCHR + "' + Convert(varchar," + cId + ") like '" + value.Trim + "%'"
        ElseIf forField = cInvoiceNo Then
            sql = sql + " where " + cInvoiceNo + " like '" + value.Trim + "%'"
        ElseIf forField = cBankName Then
            sql = sql + " where " + cBankName + " like '" + value.Trim + "%'"
        ElseIf forField = cFromHeadId Then
            sql = sql + " where " + cFromHeadId + " in (" + GetAllAccountHeadIdNameLike(value) + ")"
        Else
            sql = ""
        End If

        If sql.Trim <> "" Then sql = sql + " order by " + cReceiptDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetAllChequeReceiptLikeDate(ByVal fieldName As String, ByVal day As String, ByVal month As String, ByVal year As String) As String
        Dim flag As Boolean = False
        Dim sql As String = ""
        sql = "select * from " + cChequeReceipt
        sql = sql + " where "

        If day.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(DAY, " + fieldName + ") = '" + day + "' "
            flag = True
        End If

        If month.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(MONTH, " + fieldName + ") = '" + month + "' "
            flag = True
        End If

        If year.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(YEAR, " + fieldName + ") = '" + year + "' "
            flag = True
        End If

        If flag = False Then sql = ""
        If sql.Trim <> "" Then sql = sql + " order by " + fieldName + " desc "

        Return sql
    End Function

    Public Overrides Function GetChequeReceipt(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cChequeReceipt
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoChequeReceipt(ByRef chequeReceiptObj As ClsChequeReceipt) As String
        Dim sql As String = ""
        sql = "insert into " + cChequeReceipt + "("
        sql = sql + cToHeadId
        sql = sql + "," + cFromHeadId
        sql = sql + "," + cChequeNo
        sql = sql + "," + cChequeDate
        sql = sql + "," + cAmount
        sql = sql + "," + cInvoiceNo
        sql = sql + "," + cBankName
        sql = sql + "," + cSendToBank
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + "," + cReceiptDate
        sql = sql + ") values("
        With chequeReceiptObj
            sql = sql + CStr(.ToHeadId)
            sql = sql + "," + CStr(.FromHeadId)
            sql = sql + ",'" + .ChequeNo + "'"
            sql = sql + ",'" + .ChequeDate.ToString("s") + "'"
            sql = sql + "," + CStr(.Amount)
            sql = sql + ",'" + .InvoiceNo + "'"
            sql = sql + ",'" + .BankName + "'"
            sql = sql + "," + CStr(Math.Abs(CInt(.SendToBank)))
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
            sql = sql + ",'" + .ReceiptDate.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateChequeReceipt(ByRef chequeReceiptObj As ClsChequeReceipt) As String
        Dim sql As String = ""
        sql = "update " + cChequeReceipt
        sql = sql + " set "
        With chequeReceiptObj
            sql = sql + cToHeadId
            sql = sql + "=" + CStr(.ToHeadId)
            sql = sql + "," + cFromHeadId
            sql = sql + "=" + CStr(.FromHeadId)
            sql = sql + "," + cChequeNo
            sql = sql + "='" + .ChequeNo + "'"
            sql = sql + "," + cChequeDate
            sql = sql + "='" + .ChequeDate.ToString("s") + "'"
            sql = sql + "," + cAmount
            sql = sql + "=" + CStr(.Amount)
            sql = sql + "," + cInvoiceNo
            sql = sql + "='" + .InvoiceNo + "'"
            sql = sql + "," + cBankName
            sql = sql + "='" + .BankName + "'"
            sql = sql + "," + cSendToBank
            sql = sql + "=" + CStr(Math.Abs(CInt(.SendToBank)))
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + "," + cReceiptDate
            sql = sql + "='" + .ReceiptDate.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function DeleteChequeReceipt(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "delete " + cChequeReceipt
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

#End Region

#Region "CompanyInfo"

    Public Overrides Function GetCompanyInfo() As String
        Dim sql As String = ""
        sql = "select * from " + cCompanyInfo

        Return sql
    End Function

    Public Overrides Function UpdateCompanyInfo(ByRef companyInfoObj As ClsCompanyInfo) As String
        Dim sql As String = ""
        sql = "update " + cCompanyInfo
        sql = sql + " set "
        With companyInfoObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cSubTitle
            sql = sql + "='" + .SubTitle + "'"
            sql = sql + "," + cAddress
            sql = sql + "='" + .Address + "'"
            sql = sql + "," + cContactPerson
            sql = sql + "='" + .ContactPerson + "'"
            sql = sql + "," + cPhone
            sql = sql + "='" + .Phone + "'"
            sql = sql + "," + cFax
            sql = sql + "='" + .Fax + "'"
            sql = sql + "," + cEmail
            sql = sql + "='" + .EMail + "'"
            sql = sql + "," + cCity
            sql = sql + "='" + .City + "'"
            sql = sql + "," + cState
            sql = sql + "='" + .State + "'"
            sql = sql + "," + cPin
            sql = sql + "='" + .Pin + "'"
            sql = sql + "," + cUpTtNo
            sql = sql + "='" + .UpTtNo + "'"
            sql = sql + "," + cCstNo
            sql = sql + "='" + .CstNo + "'"
            sql = sql + "," + cDlNo
            sql = sql + "='" + .DlNo + "'"
            sql = sql + "," + cTinNo
            sql = sql + "='" + .TinNo + "'"
            sql = sql + "," + cLogo

            If .Logo Is Nothing Then
                sql = sql + "= NULL "
            Else
                sql = sql + "=" + ImageToString(.Logo)
            End If

            sql = sql + " where " + cId
            sql = sql + "=" + CStr(1)
        End With

        Return sql
    End Function

#End Region

#Region "CreditNote"

    Public Overrides Function GetAllCreditNote() As String
        Dim sql As String = ""
        sql = "select * from " + cCreditNote

        Return sql
    End Function

    Public Overrides Function GetAllCreditNoteValuesLike(ByVal forField As String, ByVal value As String) As String
        Dim sql As String = ""
        sql = "select * from " + cCreditNote
        If forField = cCode Then
            sql = sql + " where " + cCode + " like '" + value.Trim + "%'"
        ElseIf forField = cCustomerCode Then
            sql = sql + " where " + cCustomerCode + " in (" + GetAllCustomerMasterCodeNameLike(value) + ")"
        Else
            sql = ""
        End If

        If sql.Trim <> "" Then sql = sql + " order by " + cNoteDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetAllCreditNoteLikeNoteDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
        Dim flag As Boolean = False
        Dim sql As String = ""
        sql = "select * from " + cCreditNote
        sql = sql + " where "

        If day.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(DAY, " + cNoteDate + ") = '" + day + "' "
            flag = True
        End If

        If month.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(MONTH, " + cNoteDate + ") = '" + month + "' "
            flag = True
        End If

        If year.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(YEAR, " + cNoteDate + ") = '" + year + "' "
            flag = True
        End If

        If flag = False Then sql = ""
        If sql.Trim <> "" Then sql = sql + " order by " + cNoteDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetCreditNote(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cCreditNote
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoCreditNote(ByRef creditNoteObj As ClsCreditNote) As String
        Dim sql As String = ""
        sql = "insert into " + cCreditNote + "("
        sql = sql + cCustomerCode
        sql = sql + "," + cNoteDate
        sql = sql + "," + cAmount
        sql = sql + "," + cAgainstCode
        sql = sql + "," + cCode
        sql = sql + "," + cNarration
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With creditNoteObj
            sql = sql + "'" + .CustomerCode + "'"
            sql = sql + ",'" + .NoteDate.ToString("s") + "'"
            sql = sql + "," + CStr(.Amount)
            sql = sql + ",'" + .AgainstCode + "'"
            sql = sql + ",'" + .Code + "'"
            sql = sql + ",'" + .Narration + "'"
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateCreditNote(ByRef creditNoteObj As ClsCreditNote) As String
        Dim sql As String = ""
        sql = "update " + cCreditNote
        sql = sql + " set "
        With creditNoteObj
            sql = sql + cCustomerCode
            sql = sql + "='" + .CustomerCode + "'"
            sql = sql + "," + cAgainstCode
            sql = sql + "='" + .AgainstCode + "'"
            sql = sql + "," + cNoteDate
            sql = sql + "='" + .NoteDate.ToString("s") + "'"
            sql = sql + "," + cAmount
            sql = sql + "=" + CStr(.Amount)
            sql = sql + "," + cNarration
            sql = sql + "='" + .Narration + "'"
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cCode
            sql = sql + "='" + .Code + "'"
        End With

        Return sql
    End Function

#End Region

#Region "CurrentFreeStock"

    Public Overrides Function GetAllCurrentFreeStock(ByVal excludeZeroQuantity As Boolean) As String
        Dim sql As String = ""
        sql = "select * from " + cCurrentFreeStock
        If excludeZeroQuantity = True Then
            sql = sql + " where " + cCurrentQuantity + "> 0 "
        End If

        Return sql
    End Function

    Public Overrides Function GetAllCurrentFreeStockForItemId(ByVal itemId As Integer, ByVal includeZeroQuantity As Boolean) As String
        Dim sql As String = ""
        sql = "select * from " + cCurrentFreeStock
        sql = sql + " where " + cItemId + "=" + CStr(itemId)
        If includeZeroQuantity = False Then
            sql = sql + " and " + cCurrentQuantity + "> 0 "
        End If

        Return sql
    End Function

    Public Overrides Function GetCurrentFreeStockForItemIdAndBatch(ByVal itemId As Integer, ByVal batch As String) As String
        Dim sql As String = ""
        sql = "select * from " + cCurrentFreeStock
        sql = sql + " where " + cItemId + "=" + CStr(itemId)
        sql = sql + " and " + cBatch + "='" + batch + "'"

        Return sql
    End Function

    Public Overrides Function GetCurrentFreeStock(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cCurrentFreeStock
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoCurrentFreeStock(ByRef currentFreeStockObj As ClsCurrentFreeStock) As String
        Dim sql As String = ""
        sql = "insert into " + cCurrentFreeStock + "("
        sql = sql + cBatch
        sql = sql + "," + cItemId
        sql = sql + "," + cPackQuantity
        sql = sql + "," + cCurrentQuantity
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With currentFreeStockObj
            sql = sql + "'" + .Batch + "'"
            sql = sql + "," + CStr(.ItemId)
            sql = sql + "," + CStr(.PackQuantity)
            sql = sql + "," + CStr(.CurrentQuantity)
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateCurrentFreeStock(ByRef currentFreeStockObj As ClsCurrentFreeStock) As String
        Dim sql As String = ""
        sql = "update " + cCurrentFreeStock
        sql = sql + " set "
        With currentFreeStockObj
            sql = sql + cBatch
            sql = sql + "='" + .Batch + "'"
            sql = sql + "," + cItemId
            sql = sql + "=" + CStr(.ItemId)
            sql = sql + "," + cPackQuantity
            sql = sql + "=" + CStr(.PackQuantity)
            sql = sql + "," + cCurrentQuantity
            sql = sql + "=" + CStr(.CurrentQuantity)
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "CurrentStock"

    Public Overrides Function GetAllCurrentStock(ByVal excludeZeroQuantity As Boolean) As String
        Dim sql As String = ""
        sql = "select * from " + cCurrentStock
        If excludeZeroQuantity = True Then
            sql = sql + " where " + cCurrentQuantity + "> 0 "
        End If

        Return sql
    End Function

    Public Overrides Function GetAllCurrentStockForExpiry(ByVal expiryDate As Date) As String
        Dim sql As String = ""
        sql = "select * from " + cCurrentStock
        sql = sql + " where " + cCurrentQuantity + "> 0 " + " and " + cExpiryDate + "<='" + expiryDate.ToString("s") + "'"

        Return sql
    End Function

    Public Overrides Function GetAllCurrentStockForItemId(ByVal itemId As Integer, ByVal includeZeroQuantity As Boolean) As String
        Dim sql As String = ""
        sql = "select * from " + cCurrentStock
        sql = sql + " where " + cItemId + "=" + CStr(itemId)
        If includeZeroQuantity = False Then
            sql = sql + " and " + cCurrentQuantity + "> 0 "
        End If

        Return sql
    End Function

    Public Overrides Function GetCurrentStockForItemIdAndBatch(ByVal itemId As Integer, ByVal batch As String) As String
        Dim sql As String = ""
        sql = "select * from " + cCurrentStock
        sql = sql + " where " + cItemId + "=" + CStr(itemId)
        sql = sql + " and " + cBatch + "='" + batch + "'"

        Return sql
    End Function

    Public Overrides Function GetCurrentStock(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cCurrentStock
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoCurrentStock(ByRef currentStockObj As ClsCurrentStock) As String
        Dim sql As String = ""
        sql = "insert into " + cCurrentStock + "("
        sql = sql + cBatch
        sql = sql + "," + cItemId
        sql = sql + "," + cExpiryDate
        sql = sql + "," + cManufactureDate
        sql = sql + "," + cManufacturerId
        sql = sql + "," + cMRP
        sql = sql + "," + cPTR
        sql = sql + "," + cPackQuantity
        sql = sql + "," + cCurrentQuantity
        sql = sql + "," + cPricePurchase
        sql = sql + "," + cPTS
        sql = sql + "," + cRate1
        sql = sql + "," + cRate2
        sql = sql + "," + cRate3
        sql = sql + "," + cStorageId
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With currentStockObj
            sql = sql + "'" + .Batch + "'"
            sql = sql + "," + CStr(.ItemId)
            sql = sql + ",'" + .ExpiryDate.ToString("s") + "'"
            sql = sql + ",'" + .ManufactureDate.ToString("s") + "'"
            sql = sql + "," + CStr(.ManufacturerId)
            sql = sql + "," + CStr(.MRP)
            sql = sql + "," + CStr(.PTR)
            sql = sql + "," + CStr(.PackQuantity)
            sql = sql + "," + CStr(.CurrentQuantity)
            sql = sql + "," + CStr(.PricePurchase)
            sql = sql + "," + CStr(.PTS)
            sql = sql + "," + CStr(.Rate1)
            sql = sql + "," + CStr(.Rate2)
            sql = sql + "," + CStr(.Rate3)
            sql = sql + "," + CStr(.StorageId)
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateCurrentStock(ByRef currentStockObj As ClsCurrentStock) As String
        Dim sql As String = ""
        sql = "update " + cCurrentStock
        sql = sql + " set "
        With currentStockObj
            sql = sql + cBatch
            sql = sql + "='" + .Batch + "'"
            sql = sql + "," + cItemId
            sql = sql + "=" + CStr(.ItemId)
            sql = sql + "," + cExpiryDate
            sql = sql + "='" + .ExpiryDate.ToString("s") + "'"
            sql = sql + "," + cManufactureDate
            sql = sql + "='" + .ManufactureDate.ToString("s") + "'"
            sql = sql + "," + cManufacturerId
            sql = sql + "=" + CStr(.ManufacturerId)
            sql = sql + "," + cMRP
            sql = sql + "=" + CStr(.MRP)
            sql = sql + "," + cPTR
            sql = sql + "=" + CStr(.PTR)
            sql = sql + "," + cPackQuantity
            sql = sql + "=" + CStr(.PackQuantity)
            sql = sql + "," + cCurrentQuantity
            sql = sql + "=" + CStr(.CurrentQuantity)
            sql = sql + "," + cPricePurchase
            sql = sql + "=" + CStr(.PricePurchase)
            sql = sql + "," + cPTS
            sql = sql + "=" + CStr(.PTS)
            sql = sql + "," + cRate1
            sql = sql + "=" + CStr(.Rate1)
            sql = sql + "," + cRate2
            sql = sql + "=" + CStr(.Rate2)
            sql = sql + "," + cRate3
            sql = sql + "=" + CStr(.Rate3)
            sql = sql + "," + cStorageId
            sql = sql + "=" + CStr(.StorageId)
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "CustomerMaster"

    Public Overrides Function GetAllCustomerMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cCustomerMaster
        sql = sql + " Order by " + cAccountId

        Return sql
    End Function

    Protected Overrides Function GetAllCustomerMasterIdNameLike(ByVal likeValue As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cCustomerMaster
        sql = sql + " where " + cName + " like '" + likeValue.Trim + "%'"

        Return sql
    End Function

    Protected Overrides Function GetAllCustomerMasterCodeNameLike(ByVal likeValue As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cAccountId + ") from " + cCustomerMaster
        sql = sql + " where " + cName + " like '" + likeValue.Trim + "%'"

        Return sql
    End Function

    Public Overrides Function GetAllCustomerMasterLike(ByVal fieldName As String, ByVal likeValue As String) As String
        Dim sql As String = ""
        sql = "select * from " + cCustomerMaster
        sql = sql + " where " + fieldName + " like '" + likeValue.Trim + "%'"
        sql = sql + " Order by " + cAccountId

        Return sql
    End Function

    Public Overrides Function GetAllCustomerMasterCode() As String
        Dim sql As String = ""
        sql = "select distinct(" + cAccountId + ") from " + cCustomerMaster
        sql = sql + " Order by " + cAccountId

        Return sql
    End Function

    Public Overrides Function GetCustomerMasterIdForCode(ByVal code As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cCustomerMaster
        sql = sql + " where " + cAccountId + "='" + code.Trim + "'"

        Return sql
    End Function

    Protected Overrides Function GetCustomerMasterCustomerTypeId(ByVal id As Integer) As String
        Dim sql As String = ""
        sql = "select distinct(" + cCustomerTypeId + ") from " + cCustomerMaster
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function GetCustomerMaster(ByVal id As Integer) As String
        Dim sql As String = ""
        sql = "select * from " + cCustomerMaster
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoCustomerMaster(ByRef customerMasterObj As ClsCustomerMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cCustomerMaster + "("
        sql = sql + cName
        sql = sql + "," + cAccountId
        'sql = sql + "," + cCardNo
        sql = sql + "," + cCustomerTypeId
        sql = sql + "," + cTaxId
        sql = sql + "," + cHQId
        sql = sql + "," + cDueDays
        sql = sql + "," + cAddress
        sql = sql + "," + cPhoneR
        sql = sql + "," + cPhoneO
        sql = sql + "," + cMobile
        sql = sql + "," + cEmail
        sql = sql + "," + cCity
        sql = sql + "," + cPin
        sql = sql + "," + cMemberOf
        'sql = sql + "," + cDlNo
        sql = sql + "," + cUpTtNo
        sql = sql + "," + cTinNo
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With customerMasterObj
            sql = sql + "'" + .Name + "'"
            sql = sql + ",'" + .AccountId + "'"
            'sql = sql + ",'" + .CardNo + "'"
            sql = sql + "," + CStr(.CustomerTypeId)
            sql = sql + "," + CStr(.TaxId)
            sql = sql + "," + CStr(.HQId)
            sql = sql + "," + CStr(.DueDays)
            sql = sql + ",'" + .Address + "'"
            sql = sql + ",'" + .PhoneR + "'"
            sql = sql + ",'" + .PhoneO + "'"
            sql = sql + ",'" + .Mobile + "'"
            sql = sql + ",'" + .EMail + "'"
            sql = sql + ",'" + .City + "'"
            sql = sql + ",'" + .Pin + "'"
            sql = sql + ",'" + .MemberOf + "'"
            'sql = sql + ",'" + .DlNo + "'"
            sql = sql + ",'" + .UpTtNo + "'"
            sql = sql + ",'" + .TinNo + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateCustomerMaster(ByRef customerMasterObj As ClsCustomerMaster) As String
        Dim sql As String = ""
        sql = "update " + cCustomerMaster
        sql = sql + " set "
        With customerMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cAccountId
            sql = sql + "='" + .AccountId + "'"
            'sql = sql + "," + cCardNo
            'sql = sql + "='" + .CardNo + "'"
            sql = sql + "," + cCustomerTypeId
            sql = sql + "=" + CStr(.CustomerTypeId)
            sql = sql + "," + cTaxId
            sql = sql + "=" + CStr(.TaxId)
            sql = sql + "," + cHQId
            sql = sql + "=" + CStr(.HQId)
            sql = sql + "," + cDueDays
            sql = sql + "=" + CStr(.DueDays)
            sql = sql + "," + cAddress
            sql = sql + "='" + .Address + "'"
            sql = sql + "," + cPhoneR
            sql = sql + "='" + .PhoneR + "'"
            sql = sql + "," + cPhoneO
            sql = sql + "='" + .PhoneO + "'"
            sql = sql + "," + cMobile
            sql = sql + "='" + .Mobile + "'"
            sql = sql + "," + cEmail
            sql = sql + "='" + .EMail + "'"
            sql = sql + "," + cCity
            sql = sql + "='" + .City + "'"
            sql = sql + "," + cPin
            sql = sql + "='" + .Pin + "'"
            sql = sql + "," + cMemberOf
            sql = sql + "='" + .MemberOf + "'"
            'sql = sql + "," + cDlNo
            'sql = sql + "='" + .DlNo + "'"
            sql = sql + "," + cUpTtNo
            sql = sql + "='" + .UpTtNo + "'"
            sql = sql + "," + cTinNo
            sql = sql + "='" + .TinNo + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "CustomerType"

    Public Overrides Function CustomerTypeUpdatable(ByRef customerTypeObj As ClsCustomerType) As String
        Dim sql As String = ""
        With customerTypeObj
            sql = "select * from " + cCustomerType
            sql = sql + " where "
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + " and " + cId
            sql = sql + "<>" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function GetAllCustomerType() As String
        Dim sql As String = ""
        sql = "select * from " + cCustomerType
        sql = sql + " Order by " + cName

        Return sql
    End Function

    Public Overrides Function GetCustomerType(ByVal id As Integer) As String
        Dim sql As String = ""
        sql = "select * from " + cCustomerType
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoCustomerType(ByRef customerTypeObj As ClsCustomerType) As String
        Dim sql As String = ""
        sql = "insert into " + cCustomerType + "("
        sql = sql + cName
        sql = sql + ") values("
        With customerTypeObj
            sql = sql + "'" + .Name + "'"
        End With
        sql = sql + ")"
        sql = sql + " select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateCustomerType(ByRef customerTypeObj As ClsCustomerType) As String
        Dim sql As String = ""
        sql = "update " + cCustomerType
        sql = sql + " set "
        With customerTypeObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "CustomerTypePrice"

    Public Overrides Function GetAllCustomerTypePrice() As String
        Dim sql As String = ""
        sql = "select * from " + cCustomerTypePrice

        Return sql
    End Function

    Public Overrides Function GetAllCustomerTypePrice(ByVal itemId As Integer, ByVal batch As String) As String
        Dim sql As String = ""
        sql = "select * from " + cCustomerTypePrice
        sql = sql + " where " + cItemId + "=" + CStr(itemId)
        sql = sql + " and " + cBatch + "='" + batch + "'"

        Return sql
    End Function

    Public Overrides Function GetCustomerTypePrice(ByVal itemId As Integer, ByVal batch As String, ByVal customerId As Integer) As String
        Dim sql As String = ""
        sql = "select " + cPrice + " from " + cCustomerTypePrice
        sql = sql + " where " + cItemId + "=" + CStr(itemId)
        sql = sql + " and " + cBatch + "='" + batch + "'"
        sql = sql + " and " + cCustomerTypeId + " in (" + GetCustomerMasterCustomerTypeId(customerId) + ")"

        Return sql
    End Function

    Public Overrides Function GetCustomerTypePrice(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cCustomerTypePrice
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoCustomerTypePrice(ByRef customerTypePriceObj As ClsCustomerTypePrice) As String
        Dim sql As String = ""
        sql = "insert into " + cCustomerTypePrice + "("
        sql = sql + cCustomerTypeId
        sql = sql + "," + cItemId
        sql = sql + "," + cPrice
        sql = sql + "," + cBatch
        sql = sql + ") values("
        With customerTypePriceObj
            sql = sql + CStr(.CustomerTypeId)
            sql = sql + "," + CStr(.ItemId)
            sql = sql + "," + CStr(.Price)
            sql = sql + ",'" + .Batch + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateCustomerTypePrice(ByRef customerTypePriceObj As ClsCustomerTypePrice) As String
        Dim sql As String = ""
        sql = "update " + cCustomerTypePrice
        sql = sql + " set "
        With customerTypePriceObj
            sql = sql + cCustomerTypeId
            sql = sql + "=" + CStr(.CustomerTypeId)
            sql = sql + "," + cItemId
            sql = sql + "=" + CStr(.ItemId)
            sql = sql + "," + cPrice
            sql = sql + "=" + CStr(.Price)
            sql = sql + "," + cBatch
            sql = sql + "='" + .Batch + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "DebitNote"

    Public Overrides Function GetAllDebitNote() As String
        Dim sql As String = ""
        sql = "select * from " + cDebitNote

        Return sql
    End Function

    Public Overrides Function GetAllDebitNoteValuesLike(ByVal forField As String, ByVal value As String) As String
        Dim sql As String = ""
        sql = "select * from " + cDebitNote
        If forField = cCode Then
            sql = sql + " where " + cCode + " like '" + value.Trim + "%'"
        ElseIf forField = cVendorCode Then
            sql = sql + " where " + cVendorCode + " in (" + GetAllVendorMasterCodeNameLike(value) + ")"
        Else
            sql = ""
        End If

        If sql.Trim <> "" Then sql = sql + " order by " + cNoteDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetAllDebitNoteLikeNoteDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
        Dim flag As Boolean = False
        Dim sql As String = ""
        sql = "select * from " + cDebitNote
        sql = sql + " where "

        If day.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(DAY, " + cNoteDate + ") = '" + day + "' "
            flag = True
        End If

        If month.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(MONTH, " + cNoteDate + ") = '" + month + "' "
            flag = True
        End If

        If year.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(YEAR, " + cNoteDate + ") = '" + year + "' "
            flag = True
        End If

        If flag = False Then sql = ""
        If sql.Trim <> "" Then sql = sql + " order by " + cNoteDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetDebitNote(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cDebitNote
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoDebitNote(ByRef debitNoteObj As ClsDebitNote) As String
        Dim sql As String = ""
        sql = "insert into " + cDebitNote + "("
        sql = sql + cVendorCode
        sql = sql + "," + cNoteDate
        sql = sql + "," + cAmount
        sql = sql + "," + cAgainstCode
        sql = sql + "," + cCode
        sql = sql + "," + cNarration
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With debitNoteObj
            sql = sql + "'" + .VendorCode + "'"
            sql = sql + ",'" + .NoteDate.ToString("s") + "'"
            sql = sql + "," + CStr(.Amount)
            sql = sql + ",'" + .AgainstCode + "'"
            sql = sql + ",'" + .Code + "'"
            sql = sql + ",'" + .Narration + "'"
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateDebitNote(ByRef debitNoteObj As ClsDebitNote) As String
        Dim sql As String = ""
        sql = "update " + cDebitNote
        sql = sql + " set "
        With debitNoteObj
            sql = sql + cVendorCode
            sql = sql + "='" + .VendorCode + "'"
            sql = sql + "," + cAgainstCode
            sql = sql + "='" + .AgainstCode + "'"
            sql = sql + "," + cNoteDate
            sql = sql + "='" + .NoteDate.ToString("s") + "'"
            sql = sql + "," + cAmount
            sql = sql + "=" + CStr(.Amount)
            sql = sql + "," + cNarration
            sql = sql + "='" + .Narration + "'"
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cCode
            sql = sql + "='" + .Code + "'"
        End With

        Return sql
    End Function

#End Region

#Region "DestructionSlipDetail"

    Public Overrides Function GetAllDestructionSlipDetail() As String
        Dim sql As String = ""
        sql = "select * from " + cDestructionSlipDetail

        Return sql
    End Function

    Public Overrides Function GetAllDestructionSlipDetailForDestructionSlipId(ByVal destructionSlipId As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cDestructionSlipDetail
        sql = sql + " where " + cDestructionSlipId + "=" + CStr(destructionSlipId)

        Return sql
    End Function

    Public Overrides Function GetAllDestructionSlipDetailForDestructionSlipCode(ByVal destructionSlipCode As String) As String
        Dim sql As String = ""
        sql = "select * from " + cDestructionSlipDetail
        sql = sql + " where " + cDestructionSlipId + " in (" + GetDestructionSlipMasterIdForCode(destructionSlipCode) + ") "

        Return sql
    End Function

    Public Overrides Function GetDestructionSlipDetail(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cDestructionSlipDetail
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoDestructionSlipDetail(ByRef destructionSlipDetailObj As ClsDestructionSlipDetail) As String
        Dim sql As String = ""
        sql = "insert into " + cDestructionSlipDetail + "("
        sql = sql + cItemId
        sql = sql + "," + cDestructionSlipId
        sql = sql + "," + cBatch
        sql = sql + "," + cExpiryDate
        sql = sql + "," + cPackQuantity
        sql = sql + "," + cDestructionQuantity
        sql = sql + "," + cPricePurchase
        sql = sql + "," + cPriceSale
        sql = sql + "," + cTaxPercent
        sql = sql + "," + cDiscountPercent
        sql = sql + "," + cTaxAmount
        sql = sql + "," + cDiscountAmount
        sql = sql + "," + cStorageId
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With destructionSlipDetailObj
            sql = sql + CStr(.ItemId)
            sql = sql + "," + CStr(.DestructionSlipId)
            sql = sql + ",'" + .Batch + "'"
            sql = sql + ",'" + .ExpiryDate.ToString("s") + "'"
            sql = sql + "," + CStr(.PackQuantity)
            sql = sql + "," + CStr(.DestructionQuantity)
            sql = sql + "," + CStr(.PricePurchase)
            sql = sql + "," + CStr(.PriceSale)
            sql = sql + "," + CStr(.TaxPercent)
            sql = sql + "," + CStr(.DiscountPercent)
            sql = sql + "," + CStr(.TaxAmount)
            sql = sql + "," + CStr(.DiscountAmount)
            sql = sql + "," + CStr(.StorageId)
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql

    End Function

    Public Overrides Function UpdateDestructionSlipDetail(ByRef destructionSlipDetailObj As ClsDestructionSlipDetail) As String
        Dim sql As String = ""
        sql = "update " + cDestructionSlipDetail
        sql = sql + " set "
        With destructionSlipDetailObj
            sql = sql + cItemId
            sql = sql + "=" + CStr(.ItemId)
            sql = sql + "," + cBatch
            sql = sql + "='" + .Batch + "'"
            sql = sql + "," + cDestructionSlipId
            sql = sql + "=" + CStr(.DestructionSlipId)
            sql = sql + "," + cExpiryDate
            sql = sql + "='" + .ExpiryDate.ToString("s") + "'"
            sql = sql + "," + cPackQuantity
            sql = sql + "=" + CStr(.PackQuantity)
            sql = sql + "," + cDestructionQuantity
            sql = sql + "=" + CStr(.DestructionQuantity)
            sql = sql + "," + cPricePurchase
            sql = sql + "=" + CStr(.PricePurchase)
            sql = sql + "," + cPriceSale
            sql = sql + "=" + CStr(.PriceSale)
            sql = sql + "," + cTaxPercent
            sql = sql + "=" + CStr(.TaxPercent)
            sql = sql + "," + cDiscountPercent
            sql = sql + "=" + CStr(.DiscountPercent)
            sql = sql + "," + cTaxAmount
            sql = sql + "=" + CStr(.TaxAmount)
            sql = sql + "," + cDiscountAmount
            sql = sql + "=" + CStr(.DiscountAmount)
            sql = sql + "," + cStorageId
            sql = sql + "=" + CStr(.StorageId)
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function DeleteDestructionSlipDetail(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "delete " + cDestructionSlipDetail
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

#End Region

#Region "DestructionSlipMaster"

    Public Overrides Function GetAllDestructionSlipMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cDestructionSlipMaster

        Return sql
    End Function

    Public Overrides Function GetAllDestructionSlipMasterValuesLike(ByVal forField As String, ByVal value As String) As String
        Dim sql As String = ""
        sql = "select * from " + cDestructionSlipMaster
        If forField = cDestructionSlipCode Then
            sql = sql + " where " + cDestructionSlipCode + " like '" + value.Trim + "%'"
        Else
            sql = ""
        End If

        Return sql
    End Function

    Public Overrides Function GetAllDestructionSlipMasterLikeDestructionDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
        Dim flag As Boolean = False
        Dim sql As String = ""
        sql = "select * from " + cDestructionSlipMaster
        sql = sql + " where "

        If day.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(DAY, " + cDestructionSlipDate + ") = '" + day + "' "
            flag = True
        End If

        If month.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(MONTH, " + cDestructionSlipDate + ") = '" + month + "' "
            flag = True
        End If

        If year.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(YEAR, " + cDestructionSlipDate + ") = '" + year + "' "
            flag = True
        End If

        If flag = False Then sql = ""

        Return sql
    End Function

    Public Overrides Function GetDestructionSlipMasterNotClosedForLogin(ByVal loginName As String) As String
        Dim sql As String = ""
        sql = "select * from " + cDestructionSlipMaster
        sql = sql + " where " + cUserId + "='" + loginName + "'"
        sql = sql + " and " + cNotClosed + "=" + CStr(Math.Abs(CInt(True)))

        Return sql
    End Function

    Public Overrides Function GetDestructionSlipMasterIdNotClosedForLogin(ByVal loginName As String) As String
        Dim sql As String = ""
        sql = "select max(" + cId + ") from " + cDestructionSlipMaster
        sql = sql + " where " + cUserId + "='" + loginName + "'"
        sql = sql + " and " + cNotClosed + "=" + CStr(Math.Abs(CInt(True)))

        Return sql
    End Function

    Protected Overrides Function GetDestructionSlipMasterIdForCode(ByVal destructionCode As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cDestructionSlipMaster
        sql = sql + " where " + cDestructionSlipCode + "='" + destructionCode + "'"

        Return sql
    End Function

    Public Overrides Function GetDestructionSlipMaster(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cDestructionSlipMaster
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoDestructionSlipMaster(ByRef destructionSlipMasterObj As ClsDestructionSlipMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cDestructionSlipMaster + "("
        sql = sql + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + "," + cDestructionSlipCode
        sql = sql + "," + cNotClosed
        sql = sql + "," + cDestructionSlipDate
        sql = sql + ") values("
        With destructionSlipMasterObj
            sql = sql + "'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
            sql = sql + ",'" + .DestructionSlipCode + "'"
            sql = sql + "," + CStr(Math.Abs(CInt(.NotClosed)))
            sql = sql + ",'" + .DestructionSlipDate.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateDestructionSlipMaster(ByRef destructionSlipMasterObj As ClsDestructionSlipMaster) As String
        Dim sql As String = ""
        sql = "update " + cDestructionSlipMaster
        sql = sql + " set "
        With destructionSlipMasterObj
            sql = sql + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + "," + cDestructionSlipCode
            sql = sql + "='" + .DestructionSlipCode + "'"
            sql = sql + "," + cNotClosed
            sql = sql + "=" + CStr(Math.Abs(CInt(.NotClosed)))
            sql = sql + "," + cDestructionSlipDate
            sql = sql + "='" + .DestructionSlipDate.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "DivisionMaster"

    Public Overrides Function DivisionMasterUpdatable(ByRef divisionMasterObj As ClsDivisionMaster) As String
        Dim sql As String = ""
        sql = "select * from " + cDivisionMaster
        sql = sql + " where "
        With divisionMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + " and " + cId
            sql = sql + "<>" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function GetAllDivisionMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cDivisionMaster

        Return sql
    End Function

    Protected Overrides Function GetAllDivisionMasterIdForNameLike(ByVal name As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cDivisionMaster
        sql = sql + " where " + cName + " like '" + name.Trim + "%'"

        Return sql
    End Function

    Public Overrides Function InsertIntoDivisionMaster(ByRef divisionMasterObj As ClsDivisionMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cDivisionMaster + "("
        sql = sql + cName
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With divisionMasterObj
            sql = sql + "'" + .Name + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateDivisionMaster(ByRef divisionMasterObj As ClsDivisionMaster) As String
        Dim sql As String = ""
        sql = "update " + cDivisionMaster
        sql = sql + " set "
        With divisionMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "DoctorMaster"

    Public Overrides Function GetAllDoctorMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cDoctorMaster
        sql = sql + " Order by " + cName

        Return sql
    End Function

    Protected Overrides Function GetAllDoctorMasterIdNameLike(ByVal likeValue As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cDoctorMaster
        sql = sql + " where " + cName + " like '" + likeValue.Trim + "%'"

        Return sql
    End Function

    Public Overrides Function GetAllDoctorMasterLike(ByVal fieldName As String, ByVal likeValue As String) As String
        Dim sql As String = ""
        sql = "select * from " + cDoctorMaster
        sql = sql + " where " + fieldName + " like '" + likeValue.Trim + "%'"
        sql = sql + " Order by " + cName

        Return sql
    End Function

    Public Overrides Function GetAllDoctorMasterSpecialityLike(ByVal likeValue As String) As String
        Dim sql As String = ""
        sql = "select * from " + cDoctorMaster
        sql = sql + " where " + cSpecialityId + " in(" + GetAllSpecialityMasterIdLike(likeValue) + ")"
        sql = sql + " Order by " + cName

        Return sql
    End Function

    Public Overrides Function InsertIntoDoctorMaster(ByRef doctorMasterObj As ClsDoctorMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cDoctorMaster + "("
        sql = sql + cName
        sql = sql + "," + cAddress
        sql = sql + "," + cPhoneR
        sql = sql + "," + cPhoneO
        sql = sql + "," + cMobile
        sql = sql + "," + cEmail
        sql = sql + "," + cCity
        sql = sql + "," + cPin
        sql = sql + "," + cSpecialityId
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With doctorMasterObj
            sql = sql + "'" + .Name + "'"
            sql = sql + ",'" + .Address + "'"
            sql = sql + ",'" + .PhoneR + "'"
            sql = sql + ",'" + .PhoneO + "'"
            sql = sql + ",'" + .Mobile + "'"
            sql = sql + ",'" + .EMail + "'"
            sql = sql + ",'" + .City + "'"
            sql = sql + ",'" + .Pin + "'"
            sql = sql + "," + CStr(.SpecialityId)
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateDoctorMaster(ByRef doctorMasterObj As ClsDoctorMaster) As String
        Dim sql As String = ""
        sql = "update " + cDoctorMaster
        sql = sql + " set "
        With doctorMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cAddress
            sql = sql + "='" + .Address + "'"
            sql = sql + "," + cPhoneR
            sql = sql + "='" + .PhoneR + "'"
            sql = sql + "," + cPhoneO
            sql = sql + "='" + .PhoneO + "'"
            sql = sql + "," + cMobile
            sql = sql + "='" + .Mobile + "'"
            sql = sql + "," + cEmail
            sql = sql + "='" + .EMail + "'"
            sql = sql + "," + cCity
            sql = sql + "='" + .City + "'"
            sql = sql + "," + cPin
            sql = sql + "='" + .Pin + "'"
            sql = sql + "," + cSpecialityId
            sql = sql + "=" + CStr(.SpecialityId)
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "ExpiryDetail"

    Public Overrides Function GetAllExpiryDetail() As String
        Dim sql As String = ""
        sql = "select * from " + cExpiryDetail

        Return sql
    End Function

    Public Overrides Function GetAllExpiryDetailBetweenDates(ByVal dateFrom As Date, ByVal dateTo As Date) As String
        Dim sql As String = ""
        sql = "select * from " + cExpiryDetail
        sql = sql + " where " + cDateOn + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"

        Return sql
    End Function

    Public Overrides Function GetExpiryDetail(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cExpiryDetail
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoExpiryDetail(ByRef expiryDetailObj As ClsExpiryDetail) As String
        Dim sql As String = ""
        sql = "insert into " + cExpiryDetail + "("
        sql = sql + cItemId
        sql = sql + "," + cBatch
        sql = sql + "," + cExpiryDate
        sql = sql + "," + cPackQuantity
        sql = sql + "," + cQuantity
        sql = sql + "," + cPricePurchase
        sql = sql + "," + cPriceSale
        sql = sql + "," + cTaxPercent
        sql = sql + "," + cDiscountPercent
        sql = sql + "," + cTaxAmount
        sql = sql + "," + cDiscountAmount
        sql = sql + "," + cStorageId
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With expiryDetailObj
            sql = sql + CStr(.ItemId)
            sql = sql + ",'" + .Batch + "'"
            sql = sql + ",'" + .ExpiryDate.ToString("s") + "'"
            sql = sql + "," + CStr(.PackQuantity)
            sql = sql + "," + CStr(.Quantity)
            sql = sql + "," + CStr(.PricePurchase)
            sql = sql + "," + CStr(.PriceSale)
            sql = sql + "," + CStr(.TaxPercent)
            sql = sql + "," + CStr(.DiscountPercent)
            sql = sql + "," + CStr(.TaxAmount)
            sql = sql + "," + CStr(.DiscountAmount)
            sql = sql + "," + CStr(.StorageId)
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql

    End Function

    Public Overrides Function UpdateExpiryDetail(ByRef expiryDetailObj As ClsExpiryDetail) As String
        Dim sql As String = ""
        sql = "update " + cExpiryDetail
        sql = sql + " set "
        With expiryDetailObj
            sql = sql + cItemId
            sql = sql + "=" + CStr(.ItemId)
            sql = sql + "," + cBatch
            sql = sql + "='" + .Batch + "'"
            sql = sql + "," + cExpiryDate
            sql = sql + "='" + .ExpiryDate.ToString("s") + "'"
            sql = sql + "," + cPackQuantity
            sql = sql + "=" + CStr(.PackQuantity)
            sql = sql + "," + cQuantity
            sql = sql + "=" + CStr(.Quantity)
            sql = sql + "," + cPricePurchase
            sql = sql + "=" + CStr(.PricePurchase)
            sql = sql + "," + cPriceSale
            sql = sql + "=" + CStr(.PriceSale)
            sql = sql + "," + cTaxPercent
            sql = sql + "=" + CStr(.TaxPercent)
            sql = sql + "," + cDiscountPercent
            sql = sql + "=" + CStr(.DiscountPercent)
            sql = sql + "," + cTaxAmount
            sql = sql + "=" + CStr(.TaxAmount)
            sql = sql + "," + cDiscountAmount
            sql = sql + "=" + CStr(.DiscountAmount)
            sql = sql + "," + cStorageId
            sql = sql + "=" + CStr(.StorageId)
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function DeleteExpiryDetail(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "delete " + cExpiryDetail
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

#End Region

#Region "FreeItemDetail"

    Public Overrides Function GetAllFreeItemDetail() As String
        Dim sql As String = ""
        sql = "select * from " + cFreeItemDetail

        Return sql
    End Function

    Public Overrides Function GetAllFreeItemDetailForPurchaseId(ByVal purchaseId As Integer) As String
        Dim sql As String = ""
        sql = "select * from " + cFreeItemDetail
        sql = sql + " where " + cPurchaseId + "=" + CStr(purchaseId)

        Return sql
    End Function

    Public Overrides Function GetFreeItemDetailLastForItemId(ByVal itemId As Integer, ByVal batch As String) As String
        Dim sql As String = ""
        sql = "SELECT TOP 1 " + cFreeItemDetail + ".*"
        sql = sql + " FROM " + cPurchaseMaster + " INNER JOIN "
        sql = sql + cFreeItemDetail + " ON " + cPurchaseMaster + "." + cId + " = " + cFreeItemDetail + "." + cPurchaseId
        sql = sql + " where " + cFreeItemDetail + "." + cItemId + "=" + CStr(itemId)
        sql = sql + " and " + cFreeItemDetail + "." + cBatch + "='" + batch.Trim + "'"
        sql = sql + " ORDER BY " + cPurchaseMaster + "." + cPurchaseDate + " DESC "

        Return sql
    End Function

    Public Overrides Function GetFreeItemDetailLastPriceForItemId(ByVal itemId As Integer) As String
        Dim sql As String = ""
        sql = "SELECT TOP 1 " + cFreeItemDetail + "." + cPricePurchase
        sql = sql + " FROM " + cPurchaseMaster + " INNER JOIN "
        sql = sql + cFreeItemDetail + " ON " + cPurchaseMaster + "." + cId + " = " + cFreeItemDetail + "." + cPurchaseId
        sql = sql + " where " + cFreeItemDetail + "." + cItemId + "=" + CStr(itemId)
        sql = sql + " ORDER BY " + cPurchaseMaster + "." + cPurchaseDate + " DESC "

        Return sql
    End Function

    Public Overrides Function InsertIntoFreeItemDetail(ByRef freeItemDetailObj As ClsFreeItemDetail) As String
        Dim sql As String = ""
        sql = "insert into " + cFreeItemDetail + "("
        sql = sql + cPurchaseId
        sql = sql + "," + cItemId
        sql = sql + "," + cBatch
        sql = sql + "," + cFreeQuantity
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + "," + cPackQuantity
        sql = sql + ") values("
        With freeItemDetailObj
            sql = sql + CStr(.PurchaseId)
            sql = sql + "," + CStr(.ItemId)
            sql = sql + ",'" + .Batch + "'"
            sql = sql + "," + CStr(.FreeQuantity)
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
            sql = sql + "," + CStr(.PackQuantity)
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateFreeItemDetail(ByRef freeItemDetailObj As ClsFreeItemDetail) As String
        Dim sql As String = ""
        sql = "update " + cFreeItemDetail
        sql = sql + " set "
        With freeItemDetailObj
            sql = sql + cPurchaseId
            sql = sql + "=" + CStr(.PurchaseId)
            sql = sql + "," + cItemId
            sql = sql + "=" + CStr(.ItemId)
            sql = sql + "," + cBatch
            sql = sql + "='" + .Batch + "'"
            sql = sql + "," + cFreeQuantity
            sql = sql + "=" + CStr(.FreeQuantity)
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + "," + cPackQuantity
            sql = sql + "=" + CStr(.PackQuantity)
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function DeleteFreeItemDetail(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "delete " + cFreeItemDetail
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

#End Region

#Region "FreeStockTransaction"

    Public Overrides Function GetAllFreeStockTransaction() As String
        Dim sql As String = ""
        sql = "select * from " + cFreeStockTransaction

        Return sql
    End Function

    Public Overrides Function GetAllFreeStockTransactionForSalesId(ByVal salesId As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cFreeStockTransaction
        sql = sql + " where " + cSaleId + "=" + CStr(salesId)

        Return sql
    End Function

    Public Overrides Function GetFreeStockTransaction(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cFreeStockTransaction
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Protected Overrides Function GetFreeStockTransactionTotalForSaleId(ByVal saleId As Long) As String
        Dim sql As String = ""
        sql = "select sum((" + cSaleQuantity + " * " + cPriceSale + ") + " + cTaxAmount + " - " + cDiscountAmount + ") from " + cFreeStockTransaction
        sql = sql + " where " + cSaleId + "=" + CStr(saleId)

        Return sql
    End Function

    Public Overrides Function InsertIntoFreeStockTransaction(ByRef freeStockTransactionObj As ClsFreeStockTransaction) As String
        Dim sql As String = ""
        sql = "insert into " + cFreeStockTransaction + "("
        sql = sql + cSaleId
        sql = sql + "," + cItemId
        sql = sql + "," + cBatch
        sql = sql + "," + cPackQuantity
        sql = sql + "," + cFreeQuantity
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With freeStockTransactionObj
            sql = sql + CStr(.SaleId)
            sql = sql + "," + CStr(.ItemId)
            sql = sql + ",'" + .Batch + "'"
            sql = sql + "," + CStr(.PackQuantity)
            sql = sql + "," + CStr(.FreeQuantity)
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateFreeStockTransaction(ByRef freeStockTransactionObj As ClsFreeStockTransaction) As String
        Dim sql As String = ""
        sql = "update " + cFreeStockTransaction
        sql = sql + " set "
        With freeStockTransactionObj
            sql = sql + cSaleId
            sql = sql + "=" + CStr(.SaleId)
            sql = sql + "," + cItemId
            sql = sql + "=" + CStr(.ItemId)
            sql = sql + "," + cBatch
            sql = sql + "='" + .Batch + "'"
            sql = sql + "," + cPackQuantity
            sql = sql + "=" + CStr(.PackQuantity)
            sql = sql + "," + cFreeQuantity
            sql = sql + "=" + CStr(.FreeQuantity)
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function DeleteFreeStockTransaction(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "delete " + cFreeStockTransaction
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

#End Region

#Region "GenericMaster"

    Public Overrides Function GenericMasterUpdatable(ByRef genericMasterObj As ClsGenericMaster) As String
        Dim sql As String = ""
        With genericMasterObj
            sql = "select * from " + cGenericMaster
            sql = sql + " where "
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + " and " + cId
            sql = sql + "<>" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function GetAllGenericMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cGenericMaster

        Return sql
    End Function

    Protected Overrides Function GetAllGenericMasterIdForNameLike(ByVal name As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cGenericMaster
        sql = sql + " where " + cName + " like '" + name.Trim + "%'"

        Return sql
    End Function

    Public Overrides Function InsertIntoGenericMaster(ByRef genericMasterObj As ClsGenericMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cGenericMaster + "("
        sql = sql + cName
        sql = sql + "," + cStatus
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With genericMasterObj
            sql = sql + "'" + .Name + "'"
            sql = sql + ",'" + .Status + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateGenericMaster(ByRef genericMasterObj As ClsGenericMaster) As String
        Dim sql As String = ""
        sql = "update " + cGenericMaster
        sql = sql + " set "
        With genericMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cStatus
            sql = sql + "='" + .Status + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "HQMaster"

    Public Overrides Function GetAllHQMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cHQMaster
        sql = sql + " Order by " + cName

        Return sql
    End Function

    Public Overrides Function GetAllHQMasterLike(ByVal fieldName As String, ByVal likeValue As String) As String
        Dim sql As String = ""
        sql = "select * from " + cHQMaster
        sql = sql + " where " + fieldName + " like '" + likeValue.Trim + "%'"
        sql = sql + " Order by " + cName

        Return sql
    End Function

    Protected Overrides Function GetAllHQMasterIdForNameLike(ByVal name As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cHQMaster
        sql = sql + " where " + cName + " like '" + name.Trim + "%'"

        Return sql
    End Function

    Public Overrides Function InsertIntoHQMaster(ByRef hqMasterObj As ClsHQMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cHQMaster + "("
        sql = sql + cName
        sql = sql + "," + cAddress
        sql = sql + "," + cPhoneR
        sql = sql + "," + cPhoneO
        sql = sql + "," + cMobile
        sql = sql + "," + cEmail
        sql = sql + "," + cCity
        sql = sql + "," + cPin
        sql = sql + "," + cRepresentative
        sql = sql + "," + cPhoneRepresentative
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With hqMasterObj
            sql = sql + "'" + .Name + "'"
            sql = sql + ",'" + .Address + "'"
            sql = sql + ",'" + .PhoneR + "'"
            sql = sql + ",'" + .PhoneO + "'"
            sql = sql + ",'" + .Mobile + "'"
            sql = sql + ",'" + .EMail + "'"
            sql = sql + ",'" + .City + "'"
            sql = sql + ",'" + .Pin + "'"
            sql = sql + ",'" + .Representative + "'"
            sql = sql + ",'" + .PhoneRepresentative + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateHQMaster(ByRef hqMasterObj As ClsHQMaster) As String
        Dim sql As String = ""
        sql = "update " + cHQMaster
        sql = sql + " set "
        With hqMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cAddress
            sql = sql + "='" + .Address + "'"
            sql = sql + "," + cPhoneR
            sql = sql + "='" + .PhoneR + "'"
            sql = sql + "," + cPhoneO
            sql = sql + "='" + .PhoneO + "'"
            sql = sql + "," + cMobile
            sql = sql + "='" + .Mobile + "'"
            sql = sql + "," + cEmail
            sql = sql + "='" + .EMail + "'"
            sql = sql + "," + cCity
            sql = sql + "='" + .City + "'"
            sql = sql + "," + cPin
            sql = sql + "='" + .Pin + "'"
            sql = sql + "," + cRepresentative
            sql = sql + "='" + .Representative + "'"
            sql = sql + "," + cPhoneRepresentative
            sql = sql + "='" + .PhoneRepresentative + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "ItemMaster"

    Public Overrides Function ItemMasterUpdatable(ByRef itemMasterObj As ClsItemMaster) As String
        Dim sql As String = ""
        sql = "select * from " + cItemMaster
        sql = sql + " where "
        With itemMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + " and " + cId
            sql = sql + "<>" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function GetAllItemMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cItemMaster

        Return sql
    End Function

    Public Overrides Function GetAllItemMaster(ByVal ids As String) As String
        Dim sql As String = ""
        sql = "select * from " + cItemMaster
        sql = sql + " where " + cId + " in(" + ids + ")"

        Return sql
    End Function

    Public Overrides Function GetAllItemMasterForCategoryId(ByVal categoryId As Integer) As String
        Dim sql As String = ""
        sql = "select * from " + cItemMaster
        sql = sql + " where " + cCategoryId + " = " + CStr(categoryId)

        Return sql
    End Function

    Public Overrides Function GetAllItemMasterLike(ByVal fieldName As String, ByVal likeValue As String) As String
        Dim sql As String = ""
        sql = "select * from " + cItemMaster
        If fieldName = cName Or fieldName = cNameFirst Or fieldName = cPackType Then
            sql = sql + " where " + fieldName + " like '" + likeValue.Trim + "%'"
        ElseIf fieldName = cGenericId1 Then
            sql = sql + " where " + cGenericId1 + " in (" + GetAllGenericMasterIdForNameLike(likeValue) + ")"
        ElseIf fieldName = cGenericId2 Then
            sql = sql + " where " + cGenericId2 + " in (" + GetAllGenericMasterIdForNameLike(likeValue) + ")"
        ElseIf fieldName = cGenericId3 Then
            sql = sql + " where " + cGenericId3 + " in (" + GetAllGenericMasterIdForNameLike(likeValue) + ")"
        ElseIf fieldName = cPIId Then
            sql = sql + " where " + cPIId + " in (" + GetAllPIMasterIdForNameLike(likeValue) + ")"
        ElseIf fieldName = cManufacturerId Then
            sql = sql + " where " + cManufacturerId + " in (" + GetAllManufacturerMasterIdForNameLike(likeValue) + ")"
        ElseIf fieldName = cCategoryId Then
            sql = sql + " where " + cCategoryId + " in (" + GetAllCategoryMasterIdForNameLike(likeValue) + ")"
        End If

        Return sql
    End Function

    Public Overrides Function InsertIntoItemMaster(ByRef itemMasterObj As ClsItemMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cItemMaster + "("
        sql = sql + cItemCode
        sql = sql + "," + cName
        sql = sql + "," + cNameFirst
        sql = sql + "," + cVAT
        sql = sql + "," + cPackType
        sql = sql + "," + cGenericId1
        sql = sql + "," + cGenericId2
        sql = sql + "," + cGenericId3
        sql = sql + "," + cPIId
        sql = sql + "," + cManufacturerId
        sql = sql + "," + cCategoryId
        sql = sql + "," + cScheduleId
        sql = sql + "," + cStorageId
        sql = sql + "," + cMinimum
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With itemMasterObj
            sql = sql + "'" + .ItemCode + "'"
            sql = sql + ",'" + .Name + "'"
            sql = sql + ",'" + .NameFirst + "'"
            sql = sql + "," + CStr(.VAT)
            sql = sql + ",'" + .PackType + "'"
            sql = sql + "," + CStr(.GenericId1)
            sql = sql + "," + CStr(.GenericId2)
            sql = sql + "," + CStr(.GenericId3)
            sql = sql + "," + CStr(.PIId)
            sql = sql + "," + CStr(.ManufacturerId)
            sql = sql + "," + CStr(.CategoryId)
            sql = sql + "," + CStr(.ScheduleId)
            sql = sql + "," + CStr(.StorageId)
            sql = sql + "," + CStr(.Minimum)
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateItemMaster(ByRef itemMasterObj As ClsItemMaster) As String
        Dim sql As String = ""
        sql = "update " + cItemMaster
        sql = sql + " set "
        With itemMasterObj
            sql = sql + cItemCode
            sql = sql + "='" + .ItemCode + "'"
            sql = sql + "," + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cNameFirst
            sql = sql + "='" + .NameFirst + "'"
            sql = sql + "," + cVAT
            sql = sql + "=" + CStr(.VAT)
            sql = sql + "," + cPackType
            sql = sql + "='" + .PackType + "'"
            sql = sql + "," + cGenericId1
            sql = sql + "=" + CStr(.GenericId1)
            sql = sql + "," + cGenericId2
            sql = sql + "=" + CStr(.GenericId2)
            sql = sql + "," + cGenericId3
            sql = sql + "=" + CStr(.GenericId3)
            sql = sql + "," + cPIId
            sql = sql + "=" + CStr(.PIId)
            sql = sql + "," + cManufacturerId
            sql = sql + "=" + CStr(.ManufacturerId)
            sql = sql + "," + cCategoryId
            sql = sql + "=" + CStr(.CategoryId)
            sql = sql + "," + cScheduleId
            sql = sql + "=" + CStr(.ScheduleId)
            sql = sql + "," + cStorageId
            sql = sql + "=" + CStr(.StorageId)
            sql = sql + "," + cMinimum
            sql = sql + "=" + CStr(.Minimum)
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "Legal Terms"

    Public Overrides Function GetAllLegalTerms() As String
        Dim sql As String = ""
        sql = "select * from " + cLegalTerms
        sql = sql + " Order by " + cName

        Return sql
    End Function

    Public Overrides Function GetLegalTerms(ByVal id As Integer) As String
        Dim sql As String = ""
        sql = "select * from " + cLegalTerms
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoLegalTerms(ByRef legalTermsObj As ClsLegalTerms) As String
        Dim sql As String = ""
        sql = "insert into " + cLegalTerms + "("
        sql = sql + cName
        sql = sql + ") values("
        With legalTermsObj
            sql = sql + "'" + .Name + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateLegalTerms(ByRef legalTermsObj As ClsLegalTerms) As String
        Dim sql As String = ""
        sql = "update " + cLegalTerms
        sql = sql + " set "
        With legalTermsObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function DeleteLegalTerms(ByVal id As Integer) As String
        Dim sql As String = ""
        sql = "delete " + cLegalTerms
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

#End Region

#Region "LoginList"

    Public Overrides Function UpdateLoginList(ByVal loginId As String, ByVal loginTime As Double) As String
        Dim sql As String = ""
        sql = "if EXISTS(select * From " + cLoginList + " Where " + cLoginId + " ='" + loginId + "' And " + cLoginList + "." + cLoginTime + " = " + CStr(loginTime) + ") "
        sql = sql + vbCrLf
        sql = sql + " Update " + cLoginList + " Set " + cDateOn + " = GETDATE() Where " + cLoginId + " ='" + loginId + "' And " + cLoginList + "." + cLoginTime + " = " + CStr(loginTime)
        sql = sql + vbCrLf + " else " + vbCrLf
        sql = sql + " insert Into " + cLoginList + "(" + cLoginId + ", " + cDateOn + ", " + cLoginTime + ") Values ('" + loginId + "', GETDATE(), " + CStr(loginTime) + ")"

        Return sql
    End Function

    Public Overrides Function DeleteFromLoginList(ByVal loginId As String) As String
        Dim sql As String = ""
        sql = " Delete " + cLoginList + " Where " + cLoginId + " ='" + loginId + "'"

        Return sql
    End Function

#End Region

#Region "JournalEntry"

    Public Overrides Function GetAllJournalEntry() As String
        Dim sql As String = ""
        sql = "select * from " + cJournalEntry

        Return sql
    End Function

    Public Overrides Function GetAllJournalEntryForJournal(ByVal journal As String) As String
        Dim sql As String = ""
        sql = "select * from " + cJournalEntry
        sql = sql + " where " + cJournalNo + "='" + journal.Trim + "'"

        Return sql
    End Function

    Public Overrides Function GetAllJournalEntryWithDistinctJournalNo() As String
        Dim sql As String = ""
        sql = "select distinct(" + cJournalNo + ") from " + cJournalEntry

        Return sql
    End Function

    Public Overrides Function GetJournalEntry(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cJournalEntry
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoJournalEntry(ByRef JournalEntryObj As ClsJournalEntry) As String
        Dim sql As String = ""
        sql = "insert into " + cJournalEntry + "("
        sql = sql + cJournalNo
        sql = sql + "," + cJournaldate
        sql = sql + "," + cHeadId
        sql = sql + "," + cDrAmount
        sql = sql + "," + cCrAmount
        sql = sql + "," + cRemark
        sql = sql + "," + cInvoiceNo
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With JournalEntryObj
            sql = sql + "'" + .JournalNo + "'"
            sql = sql + ",'" + .Journaldate.ToString("s") + "'"
            sql = sql + "," + CStr(.HeadId)
            sql = sql + "," + CStr(.DrAmount)
            sql = sql + "," + CStr(.CrAmount)
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .InvoiceNo + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateJournalEntry(ByRef JournalEntryObj As ClsJournalEntry) As String
        Dim sql As String = ""
        sql = "update " + cJournalEntry
        sql = sql + " set "
        With JournalEntryObj
            sql = sql + cJournalNo
            sql = sql + "='" + .JournalNo + "'"
            sql = sql + "," + cJournaldate
            sql = sql + "='" + .Journaldate.ToString("s") + "'"
            sql = sql + "," + cHeadId
            sql = sql + "=" + CStr(.HeadId)
            sql = sql + "," + cDrAmount
            sql = sql + "=" + CStr(.DrAmount)
            sql = sql + "," + cCrAmount
            sql = sql + "=" + CStr(.CrAmount)
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cInvoiceNo
            sql = sql + "='" + .InvoiceNo + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function DeleteJournalEntry(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "Delete " + cJournalEntry
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

#End Region

#Region "ManufacturerMaster"

    Public Overrides Function GetAllManufacturerMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cManufacturerMaster
        sql = sql + " Order by " + cName

        Return sql
    End Function

    Public Overrides Function GetAllManufacturerMasterLike(ByVal fieldName As String, ByVal likeValue As String) As String
        Dim sql As String = ""
        sql = "select * from " + cManufacturerMaster
        sql = sql + " where " + fieldName + " like '" + likeValue.Trim + "%'"
        sql = sql + " Order by " + cName

        Return sql
    End Function

    Protected Overrides Function GetAllManufacturerMasterIdForNameLike(ByVal name As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cManufacturerMaster
        sql = sql + " where " + cName + " like '" + name.Trim + "%'"

        Return sql
    End Function

    Public Overrides Function InsertIntoManufacturerMaster(ByRef manufacturerMasterObj As ClsManufacturerMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cManufacturerMaster + "("
        sql = sql + cName
        sql = sql + "," + cAddress
        sql = sql + "," + cPhoneR
        sql = sql + "," + cPhoneO
        sql = sql + "," + cMobile
        sql = sql + "," + cEmail
        sql = sql + "," + cCity
        sql = sql + "," + cPin
        sql = sql + "," + cRepresentative
        sql = sql + "," + cPhoneRepresentative
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With manufacturerMasterObj
            sql = sql + "'" + .Name + "'"
            sql = sql + ",'" + .Address + "'"
            sql = sql + ",'" + .PhoneR + "'"
            sql = sql + ",'" + .PhoneO + "'"
            sql = sql + ",'" + .Mobile + "'"
            sql = sql + ",'" + .EMail + "'"
            sql = sql + ",'" + .City + "'"
            sql = sql + ",'" + .Pin + "'"
            sql = sql + ",'" + .Representative + "'"
            sql = sql + ",'" + .PhoneRepresentative + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateManufacturerMaster(ByRef manufacturerMasterObj As ClsManufacturerMaster) As String
        Dim sql As String = ""
        sql = "update " + cManufacturerMaster
        sql = sql + " set "
        With manufacturerMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cAddress
            sql = sql + "='" + .Address + "'"
            sql = sql + "," + cPhoneR
            sql = sql + "='" + .PhoneR + "'"
            sql = sql + "," + cPhoneO
            sql = sql + "='" + .PhoneO + "'"
            sql = sql + "," + cMobile
            sql = sql + "='" + .Mobile + "'"
            sql = sql + "," + cEmail
            sql = sql + "='" + .EMail + "'"
            sql = sql + "," + cCity
            sql = sql + "='" + .City + "'"
            sql = sql + "," + cPin
            sql = sql + "='" + .Pin + "'"
            sql = sql + "," + cRepresentative
            sql = sql + "='" + .Representative + "'"
            sql = sql + "," + cPhoneRepresentative
            sql = sql + "='" + .PhoneRepresentative + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "OpeningStock"

    Public Overrides Function GetAllOpeningStock() As String
        Dim sql As String = ""
        sql = "select * from " + cOpeningStock

        Return sql
    End Function

    Public Overrides Function GetOpeningStockForItemIdAndBatch(ByVal itemId As Integer, ByVal batch As String) As String
        Dim sql As String = ""
        sql = "select * from " + cOpeningStock
        sql = sql + " where " + cItemId + "=" + CStr(itemId)
        sql = sql + " and " + cBatch + "='" + batch + "'"

        Return sql
    End Function

    Public Overrides Function GetOpeningStock(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cOpeningStock
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoOpeningStock(ByRef openingStockObj As ClsOpeningStock) As String
        Dim sql As String = ""
        sql = "insert into " + cOpeningStock + "("
        sql = sql + cBatch
        sql = sql + "," + cItemId
        sql = sql + "," + cPackQuantity
        sql = sql + "," + cQuantity
        sql = sql + "," + cFreeQuantity
        sql = sql + "," + cPricePurchase
        sql = sql + "," + cMRP
        sql = sql + "," + cPTS
        sql = sql + "," + cPTR
        sql = sql + "," + cPTD
        sql = sql + "," + cRate1
        sql = sql + "," + cRate2
        sql = sql + "," + cStorageId
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With openingStockObj
            sql = sql + "'" + .Batch + "'"
            sql = sql + "," + CStr(.ItemId)
            sql = sql + "," + CStr(.PackQuantity)
            sql = sql + "," + CStr(.Quantity)
            sql = sql + "," + CStr(.FreeQuantity)
            sql = sql + "," + CStr(.PricePurchase)
            sql = sql + "," + CStr(.MRP)
            sql = sql + "," + CStr(.PTS)
            sql = sql + "," + CStr(.PTR)
            sql = sql + "," + CStr(.PTD)
            sql = sql + "," + CStr(.Rate1)
            sql = sql + "," + CStr(.Rate2)
            sql = sql + "," + CStr(.StorageId)
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateOpeningStock(ByRef openingStockObj As ClsOpeningStock) As String
        Dim sql As String = ""
        sql = "update " + cOpeningStock
        sql = sql + " set "
        With openingStockObj
            sql = sql + cBatch
            sql = sql + "='" + .Batch + "'"
            sql = sql + "," + cItemId
            sql = sql + "=" + CStr(.ItemId)
            sql = sql + "," + cPackQuantity
            sql = sql + "=" + CStr(.PackQuantity)
            sql = sql + "," + cQuantity
            sql = sql + "=" + CStr(.Quantity)
            sql = sql + "," + cFreeQuantity
            sql = sql + "=" + CStr(.FreeQuantity)
            sql = sql + "," + cPricePurchase
            sql = sql + "=" + CStr(.PricePurchase)
            sql = sql + "," + cMRP
            sql = sql + "=" + CStr(.MRP)
            sql = sql + "," + cPTS
            sql = sql + "=" + CStr(.PTS)
            sql = sql + "," + cPTR
            sql = sql + "=" + CStr(.PTR)
            sql = sql + "," + cPTD
            sql = sql + "=" + CStr(.PTD)
            sql = sql + "," + cRate1
            sql = sql + "=" + CStr(.Rate1)
            sql = sql + "," + cRate2
            sql = sql + "=" + CStr(.Rate2)
            sql = sql + "," + cStorageId
            sql = sql + "=" + CStr(.StorageId)
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function DeleteOpeningStock(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "Delete " + cOpeningStock
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

#End Region

#Region "PIMaster"

    Public Overrides Function GetAllPIMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cPIMaster

        Return sql
    End Function

    Protected Overrides Function GetAllPIMasterIdForNameLike(ByVal name As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cPIMaster
        sql = sql + " where " + cName + " like '" + name.Trim + "%'"

        Return sql
    End Function

    Public Overrides Function InsertIntoPIMaster(ByRef piMasterObj As ClsPIMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cPIMaster + "("
        sql = sql + cName
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With piMasterObj
            sql = sql + "'" + .Name + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdatePIMaster(ByRef piMasterObj As ClsPIMaster) As String
        Dim sql As String = ""
        sql = "update " + cPIMaster
        sql = sql + " set "
        With piMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "ProfileMaster"

    Public Overrides Function ProfileMasterUpdatable(ByRef profileMasterObj As ClsProfileMaster) As String
        Dim sql As String = ""
        sql = "select * from " + cProfileMaster
        sql = sql + " where "
        With profileMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + " and " + cId
            sql = sql + "<>" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function GetAllProfileMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cProfileMaster
        sql = sql + " Order by " + cName

        Return sql
    End Function

    Public Overrides Function GetProfileMasterById(ProfileId As Int32) As String
        Dim sql As String = ""
        sql = "select * from " + cProfileMaster + " where Id = " + ProfileId.ToString()
        Return sql
    End Function

    Public Overrides Function InsertIntoProfileMaster(ByRef profileMasterObj As ClsProfileMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cProfileMaster + "("
        sql = sql + cName
        sql = sql + "," + cAuthorizationNo
        sql = sql + ") values("
        With profileMasterObj
            sql = sql + "'" + .Name + "'"
            sql = sql + ",'" + .AuthorizationNo + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateProfileMaster(ByRef profileMasterObj As ClsProfileMaster) As String
        Dim sql As String = ""
        sql = "update " + cProfileMaster
        sql = sql + " set "
        With profileMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cAuthorizationNo
            sql = sql + "='" + .AuthorizationNo + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "PurchaseDetail"

    Public Overrides Function GetAllPurchaseDetail() As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseDetail

        Return sql
    End Function

    Public Overrides Function GetAllPurchaseDetailForPurchaseId(ByVal purchaseId As Integer) As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseDetail
        sql = sql + " where " + cPurchaseId + "=" + CStr(purchaseId)

        Return sql
    End Function

    Public Overrides Function GetAllPurchaseDetailForPurchaseCode(ByVal purchaseCode As String) As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseDetail
        sql = sql + " where " + cPurchaseId + " in (" + GetPurchaseMasterIdPurchaseCode(purchaseCode) + ")"

        Return sql
    End Function

    Public Overrides Function GetAllPurchaseDetailForVendorIdAndBatch(ByVal vendorId As Integer, ByVal batch As String) As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseDetail
        sql = sql + " where " + cPurchaseId + " in (" + GetAllPurchaseMasterIdForVendorId(vendorId) + ") "
        sql = sql + " And " + cBatch + " = '" + batch + "' "

        Return sql
    End Function

    Public Overrides Function GetPurchaseDetailLastForItemId(ByVal itemId As Integer, ByVal batch As String) As String
        Dim sql As String = ""
        sql = "SELECT TOP 1 " + cPurchaseDetail + ".*"
        sql = sql + " FROM " + cPurchaseMaster + " INNER JOIN "
        sql = sql + cPurchaseDetail + " ON " + cPurchaseMaster + "." + cId + " = " + cPurchaseDetail + "." + cPurchaseId
        sql = sql + " where " + cPurchaseDetail + "." + cItemId + "=" + CStr(itemId)
        sql = sql + " and " + cPurchaseDetail + "." + cBatch + "='" + batch.Trim + "'"
        sql = sql + " ORDER BY " + cPurchaseMaster + "." + cPurchaseDate + " DESC "

        Return sql
    End Function

    Public Overrides Function GetPurchaseDetailLastPriceForItemId(ByVal itemId As Integer) As String
        Dim sql As String = ""
        sql = "SELECT TOP 1 " + cPurchaseDetail + "." + cPricePurchase
        sql = sql + " FROM " + cPurchaseMaster + " INNER JOIN "
        sql = sql + cPurchaseDetail + " ON " + cPurchaseMaster + "." + cId + " = " + cPurchaseDetail + "." + cPurchaseId
        sql = sql + " where " + cPurchaseDetail + "." + cItemId + "=" + CStr(itemId)
        sql = sql + " ORDER BY " + cPurchaseMaster + "." + cPurchaseDate + " DESC "

        Return sql
    End Function

    Public Overrides Function InsertIntoPurchaseDetail(ByRef purchaseDetailObj As ClsPurchaseDetail) As String
        Dim sql As String = ""
        sql = "insert into " + cPurchaseDetail + "("
        sql = sql + cPurchaseId
        sql = sql + "," + cItemId
        sql = sql + "," + cManufacturerId
        sql = sql + "," + cBatch
        sql = sql + "," + cExpiryDate
        sql = sql + "," + cManufactureDate
        sql = sql + "," + cMRP
        sql = sql + "," + cPTR
        sql = sql + "," + cPricePurchase
        sql = sql + "," + cPTS
        sql = sql + "," + cRate1
        sql = sql + "," + cRate2
        sql = sql + "," + cRate3
        sql = sql + "," + cTaxPercent
        sql = sql + "," + cDiscountPercent
        sql = sql + "," + cPurchaseQuantity
        sql = sql + "," + cFreeQuantity
        sql = sql + "," + cStorageId
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + "," + cTaxAmount
        sql = sql + "," + cDiscountAmount
        sql = sql + "," + cPackQuantity
        sql = sql + ") values("
        With purchaseDetailObj
            sql = sql + CStr(.PurchaseId)
            sql = sql + "," + CStr(.ItemId)
            sql = sql + "," + CStr(.ManufacturerId)
            sql = sql + ",'" + .Batch + "'"
            sql = sql + ",'" + .ExpiryDate.ToString("s") + "'"
            sql = sql + ",'" + .ManufactureDate.ToString("s") + "'"
            sql = sql + "," + CStr(.MRP)
            sql = sql + "," + CStr(.PTR)
            sql = sql + "," + CStr(.PricePurchase)
            sql = sql + "," + CStr(.PTS)
            sql = sql + "," + CStr(.Rate1)
            sql = sql + "," + CStr(.Rate2)
            sql = sql + "," + CStr(.Rate3)
            sql = sql + "," + CStr(.TaxPercent)
            sql = sql + "," + CStr(.DiscountPercent)
            sql = sql + "," + CStr(.PurchaseQuantity)
            sql = sql + "," + CStr(.FreeQuantity)
            sql = sql + "," + CStr(.StorageId)
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
            sql = sql + "," + CStr(.TaxAmount)
            sql = sql + "," + CStr(.DiscountAmount)
            sql = sql + "," + CStr(.PackQuantity)
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdatePurchaseDetail(ByRef purchaseDetailObj As ClsPurchaseDetail) As String
        Dim sql As String = ""
        sql = "update " + cPurchaseDetail
        sql = sql + " set "
        With purchaseDetailObj
            sql = sql + cPurchaseId
            sql = sql + "=" + CStr(.PurchaseId)
            sql = sql + "," + cItemId
            sql = sql + "=" + CStr(.ItemId)
            sql = sql + "," + cManufacturerId
            sql = sql + "=" + CStr(.ManufacturerId)
            sql = sql + "," + cBatch
            sql = sql + "='" + .Batch + "'"
            sql = sql + "," + cExpiryDate
            sql = sql + "='" + .ExpiryDate.ToString("s") + "'"
            sql = sql + "," + cManufactureDate
            sql = sql + "='" + .ManufactureDate.ToString("s") + "'"
            sql = sql + "," + cMRP
            sql = sql + "=" + CStr(.MRP)
            sql = sql + "," + cPTR
            sql = sql + "=" + CStr(.PTR)
            sql = sql + "," + cPricePurchase
            sql = sql + "=" + CStr(.PricePurchase)
            sql = sql + "," + cPTS
            sql = sql + "=" + CStr(.PTS)
            sql = sql + "," + cRate1
            sql = sql + "=" + CStr(.Rate1)
            sql = sql + "," + cRate2
            sql = sql + "=" + CStr(.Rate2)
            sql = sql + "," + cRate3
            sql = sql + "=" + CStr(.Rate3)
            sql = sql + "," + cTaxPercent
            sql = sql + "=" + CStr(.TaxPercent)
            sql = sql + "," + cDiscountPercent
            sql = sql + "=" + CStr(.DiscountPercent)
            sql = sql + "," + cPurchaseQuantity
            sql = sql + "=" + CStr(.PurchaseQuantity)
            sql = sql + "," + cFreeQuantity
            sql = sql + "=" + CStr(.FreeQuantity)
            sql = sql + "," + cStorageId
            sql = sql + "=" + CStr(.StorageId)
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + "," + cTaxAmount
            sql = sql + "=" + CStr(.TaxAmount)
            sql = sql + "," + cDiscountAmount
            sql = sql + "=" + CStr(.DiscountAmount)
            sql = sql + "," + cPackQuantity
            sql = sql + "=" + CStr(.PackQuantity)
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function DeletePurchaseDetail(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "delete " + cPurchaseDetail
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

#End Region

#Region "PurchaseMaster"

    Public Overrides Function GetAllPurchaseMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseMaster
        sql = sql + " order by " + cPurchaseDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetAllPurchaseMasterForVendorCode(ByVal vendorCode As String) As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseMaster
        sql = sql + " where " + cVendorId + " in (" + GetVendorMasterIdForCode(vendorCode) + ")"
        sql = sql + " order by " + cPurchaseDate + " desc "

        Return sql
    End Function

    Protected Overrides Function GetAllPurchaseMasterIdPurchaseCodeLike(ByVal value As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cPurchaseMaster
        sql = sql + " where " + cPurchaseCode + " like '" + value.Trim + "%'"
        sql = sql + " order by " + cPurchaseDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetAllPurchaseMasterValuesLike(ByVal forField As String, ByVal value As String) As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseMaster
        If forField = cPurchaseCode Then
            sql = sql + " where " + cPurchaseCode + " like '" + value.Trim + "%'"
        ElseIf forField = cOrderId Then
            sql = sql + " where " + cOrderId + " like '" + value.Trim + "%'"
        ElseIf forField = cVendorId Then
            sql = sql + " where " + cVendorId + " in(" + GetAllVendorMasterIdNameLike(value) + ")"
        ElseIf forField = cVoucherNo Then
            sql = sql + " where " + cVoucherNo + " like '" + value.Trim + "%'"
        Else
            sql = ""
        End If

        If sql.Trim <> "" Then sql = sql + " order by " + cPurchaseDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetAllPurchaseMasterLikePurchaseDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
        Dim flag As Boolean = False
        Dim sql As String = ""
        sql = "select * from " + cPurchaseMaster
        sql = sql + " where "

        If day.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(DAY, " + cPurchaseDate + ") = '" + day + "' "
            flag = True
        End If

        If month.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(MONTH, " + cPurchaseDate + ") = '" + month + "' "
            flag = True
        End If

        If year.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(YEAR, " + cPurchaseDate + ") = '" + year + "' "
            flag = True
        End If

        If flag = False Then sql = ""
        If sql.Trim <> "" Then sql = sql + " order by " + cPurchaseDate + " desc "

        Return sql
    End Function

    Protected Overrides Function GetPurchaseMasterIdPurchaseCode(ByVal code As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cPurchaseMaster
        sql = sql + " where " + cPurchaseCode + " = '" + code.Trim + "'"

        Return sql
    End Function

    Protected Overrides Function GetAllPurchaseMasterIdForVendorId(ByVal vendorId As Integer) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cPurchaseMaster
        sql = sql + " where " + cVendorId + " = " + CStr(vendorId)

        Return sql
    End Function

    Public Overrides Function GetPurchaseMasterNotClosedForLogin(ByVal loginName As String) As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseMaster
        sql = sql + " where " + cUserId + "='" + loginName + "'"
        sql = sql + " and " + cNotClosed + "=" + CStr(Math.Abs(CInt(True)))

        Return sql
    End Function

    Public Overrides Function GetPurchaseMasterIdNotClosedForLogin(ByVal loginName As String) As String
        Dim sql As String = ""
        sql = "select max(" + cId + ") from " + cPurchaseMaster
        sql = sql + " where " + cUserId + "='" + loginName + "'"
        sql = sql + " and " + cNotClosed + "=" + CStr(Math.Abs(CInt(True)))

        Return sql
    End Function

    Public Overrides Function GetPurchaseMaster(ByVal id As Integer) As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseMaster
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoPurchaseMaster(ByRef purchaseMasterObj As ClsPurchaseMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cPurchaseMaster + "("
        sql = sql + cPurchaseCode
        sql = sql + "," + cVendorId
        sql = sql + "," + cMode
        sql = sql + "," + cVoucherNo
        sql = sql + "," + cOrderId
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + "," + cPurchaseDate
        sql = sql + "," + cTaxId
        sql = sql + "," + cDiscountAmount
        sql = sql + "," + cCreditAdjust
        sql = sql + "," + cDebitAdjust
        sql = sql + "," + cTaxPercent
        sql = sql + "," + cPreExciseAmount
        sql = sql + "," + cFreightCharge
        sql = sql + "," + cNotClosed
        sql = sql + ") values("
        With purchaseMasterObj
            sql = sql + "'" + .PurchaseCode + "'"
            sql = sql + "," + CStr(.VendorId)
            sql = sql + ",'" + .Mode + "'"
            sql = sql + ",'" + .VoucherNo + "'"
            sql = sql + "," + CStr(.OrderId)
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
            sql = sql + ",'" + .PurchaseDate.ToString("s") + "'"
            sql = sql + "," + CStr(.TaxId)
            sql = sql + "," + CStr(.DiscountAmount)
            sql = sql + "," + CStr(.CreditAdjust)
            sql = sql + "," + CStr(.DebitAdjust)
            sql = sql + "," + CStr(.TaxPercent)
            sql = sql + "," + CStr(.PreExciseAmount)
            sql = sql + "," + CStr(.FreightCharge)
            sql = sql + "," + CStr(Math.Abs(CInt(.NotClosed)))
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdatePurchaseMaster(ByRef purchaseMasterObj As ClsPurchaseMaster) As String
        Dim sql As String = ""
        sql = "update " + cPurchaseMaster
        sql = sql + " set "
        With purchaseMasterObj
            sql = sql + cPurchaseCode
            sql = sql + "='" + .PurchaseCode + "'"
            sql = sql + "," + cVendorId
            sql = sql + "=" + CStr(.VendorId)
            sql = sql + "," + cMode
            sql = sql + "='" + .Mode + "'"
            sql = sql + "," + cVoucherNo
            sql = sql + "='" + .VoucherNo + "'"
            sql = sql + "," + cOrderId
            sql = sql + "=" + CStr(.OrderId)
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + "," + cPurchaseDate
            sql = sql + "='" + .PurchaseDate.ToString("s") + "'"
            sql = sql + "," + cTaxId
            sql = sql + "=" + CStr(.TaxId)
            sql = sql + "," + cDiscountAmount
            sql = sql + "=" + CStr(.DiscountAmount)
            sql = sql + "," + cCreditAdjust
            sql = sql + "=" + CStr(.CreditAdjust)
            sql = sql + "," + cDebitAdjust
            sql = sql + "=" + CStr(.DebitAdjust)
            sql = sql + "," + cTaxPercent
            sql = sql + "=" + CStr(.TaxPercent)
            sql = sql + "," + cPreExciseAmount
            sql = sql + "=" + CStr(.PreExciseAmount)
            sql = sql + "," + cFreightCharge
            sql = sql + "=" + CStr(.FreightCharge)
            sql = sql + "," + cNotClosed
            sql = sql + "=" + CStr(Math.Abs(CInt(.NotClosed)))
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "Purchase Return Detail"

    Public Overrides Function GetAllPurchaseReturnDetail() As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseReturnDetail

        Return sql
    End Function

    Public Overrides Function GetAllPurchaseReturnDetailForPurchaseReturnId(ByVal id As Integer) As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseReturnDetail + " where " + cPurchaseReturnId + "="
        sql = sql + CStr(id)

        Return sql
    End Function

    Public Overrides Function GetPurchaseReturnDetailById(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseReturnDetail + " where " + cId + "="
        sql = sql + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertPurchaseReturnDetail(ByRef purchaseReturnDetailObj As ClsPurchaseReturnDetail) As String
        Dim sql As String = ""
        sql = "insert into " + cPurchaseReturnDetail + "("
        sql = sql + cPurchaseReturnId
        sql = sql + "," + cItemId
        sql = sql + "," + cBatch
        sql = sql + "," + cExpiryDate
        sql = sql + "," + cPricePurchase
        sql = sql + "," + cPriceSale
        sql = sql + "," + cTaxPercent
        sql = sql + "," + cDiscountPercent
        sql = sql + "," + cTaxAmount
        sql = sql + "," + cDiscountAmount
        sql = sql + "," + cReturnQuantity
        sql = sql + "," + cFreeQuantity
        sql = sql + "," + cStorageId
        sql = sql + "," + cPurchaseId
        sql = sql + "," + cNonSaleable
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + "," + cPackQuantity
        sql = sql + ") values("
        With purchaseReturnDetailObj
            sql = sql + CStr(.PurchaseReturnId)
            sql = sql + "," + CStr(.ItemId)
            sql = sql + ",'" + .Batch + "'"
            sql = sql + ",'" + .ExpiryDate.ToString("s") + "'"
            sql = sql + "," + CStr(.PricePurchase)
            sql = sql + "," + CStr(.PriceSale)
            sql = sql + "," + CStr(.TaxPercent)
            sql = sql + "," + CStr(.DiscountPercent)
            sql = sql + "," + CStr(.TaxAmount)
            sql = sql + "," + CStr(.DiscountAmount)
            sql = sql + "," + CStr(.ReturnQuantity)
            sql = sql + "," + CStr(.FreeQuantity)
            sql = sql + "," + CStr(.StorageId)
            sql = sql + "," + CStr(.PurchaseId)
            sql = sql + "," + CStr(Math.Abs(CInt(.NonSaleable)))
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
            sql = sql + "," + CStr(.PackQuantity)
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdatePurchaseReturnDetail(ByRef purchaseReturnDetailObj As ClsPurchaseReturnDetail) As String
        Dim sql As String = ""
        sql = "update " + cPurchaseReturnDetail
        sql = sql + " set "
        With purchaseReturnDetailObj
            sql = sql + cPurchaseReturnId
            sql = sql + "=" + CStr(.PurchaseReturnId)
            sql = sql + "," + cItemId
            sql = sql + "=" + CStr(.ItemId)
            sql = sql + "," + cBatch
            sql = sql + "='" + .Batch + "'"
            sql = sql + "," + cExpiryDate
            sql = sql + "='" + .ExpiryDate.ToString("s") + "'"
            sql = sql + "," + cPricePurchase
            sql = sql + "=" + CStr(.PricePurchase)
            sql = sql + "," + cPriceSale
            sql = sql + "=" + CStr(.PriceSale)
            sql = sql + "," + cTaxPercent
            sql = sql + "=" + CStr(.TaxPercent)
            sql = sql + "," + cDiscountPercent
            sql = sql + "=" + CStr(.DiscountPercent)
            sql = sql + "," + cTaxAmount
            sql = sql + "=" + CStr(.TaxAmount)
            sql = sql + "," + cDiscountAmount
            sql = sql + "=" + CStr(.DiscountAmount)
            sql = sql + "," + cReturnQuantity
            sql = sql + "=" + CStr(.ReturnQuantity)
            sql = sql + "," + cPurchaseId
            sql = sql + "=" + CStr(.PurchaseId)
            sql = sql + "," + cNonSaleable
            sql = sql + "=" + CStr(Math.Abs(CInt(.NonSaleable)))
            sql = sql + "," + cFreeQuantity
            sql = sql + "=" + CStr(.FreeQuantity)
            sql = sql + "," + cStorageId
            sql = sql + "=" + CStr(.StorageId)
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + "," + cPackQuantity
            sql = sql + "=" + CStr(.PackQuantity)
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function DeletePurchaseReturnDetail(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "delete " + cPurchaseReturnDetail + " where " + cId + "="
        sql = sql + CStr(id)

        Return sql
    End Function

#End Region

#Region "Purchase Return Master"

    Public Overrides Function GetAllPurchaseReturnMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseReturnMaster

        Return sql
    End Function

    Public Overrides Function GetAllPurchaseReturnMasterValuesLike(ByVal forField As String, ByVal value As String) As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseReturnMaster
        If forField = cPurchaseReturnCode Then
            sql = sql + " where " + cPurchaseReturnCode + " like '" + value.Trim + "%'"
        ElseIf forField = cPurchaseId Then
            sql = sql + " where " + cPurchaseId + " in(" + GetAllPurchaseMasterIdPurchaseCodeLike(value) + ")"
        ElseIf forField = cVendorId Then
            sql = sql + " where " + cVendorId + " in(" + GetAllVendorMasterIdNameLike(value) + ")"
        Else
            sql = ""
        End If

        Return sql
    End Function

    Public Overrides Function GetAllPurchaseReturnMasterLikeReturnDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
        Dim flag As Boolean = False
        Dim sql As String = ""
        sql = "select * from " + cPurchaseReturnMaster
        sql = sql + " where "

        If day.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(DAY, " + cReturnDate + ") = '" + day + "' "
            flag = True
        End If

        If month.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(MONTH, " + cReturnDate + ") = '" + month + "' "
            flag = True
        End If

        If year.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(YEAR, " + cReturnDate + ") = '" + year + "' "
            flag = True
        End If

        If flag = False Then sql = ""

        Return sql
    End Function

    Public Overrides Function GetPurchaseReturnMasterById(ByVal id As Integer) As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseReturnMaster + " where " + cId + "="
        sql = sql + CStr(id)

        Return sql
    End Function

    Public Overrides Function GetPurchaseReturnMasterDiscountAmount(ByVal id As Long) As String
        Dim sql As String = ""
        sql = sql + "SELECT " + cDiscountAmount + " FROM " + cPurchaseReturnMaster
        sql = sql + " where " + cId + " = " + CStr(id)

        Return sql
    End Function

    Public Overrides Function GetPurchaseReturnMasterNotClosedForLogin(ByVal loginName As String) As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseReturnMaster
        sql = sql + " where " + cUserId + "='" + loginName + "'"
        sql = sql + " and " + cNotClosed + "=" + CStr(Math.Abs(CInt(True)))

        Return sql
    End Function

    Public Overrides Function InsertPurchaseReturnMaster(ByRef purchaseReturnMasterObj As ClsPurchaseReturnMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cPurchaseReturnMaster + "("
        sql = sql + cPurchaseReturnCode
        sql = sql + "," + cVendorId
        sql = sql + "," + cDiscountAmount
        sql = sql + "," + cMode
        sql = sql + "," + cPurchaseId
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + "," + cReturnDate
        sql = sql + "," + cNotClosed
        sql = sql + ") values("
        With purchaseReturnMasterObj
            sql = sql + "'" + .PurchaseReturnCode + "'"
            sql = sql + "," + CStr(.VendorId)
            sql = sql + "," + CStr(.DiscountAmount)
            sql = sql + ",'" + .Mode + "'"
            sql = sql + "," + CStr(.PurchaseId)
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
            sql = sql + ",'" + .ReturnDate.ToString("s") + "'"
            sql = sql + "," + CStr(Math.Abs(CInt(.NotClosed)))
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdatePurchaseReturnMaster(ByRef purchaseReturnMasterObj As ClsPurchaseReturnMaster) As String
        Dim sql As String = ""
        sql = "update " + cPurchaseReturnMaster
        sql = sql + " set "
        With purchaseReturnMasterObj
            sql = sql + cPurchaseReturnCode
            sql = sql + "='" + .PurchaseReturnCode + "'"
            sql = sql + "," + cVendorId
            sql = sql + "=" + CStr(.VendorId)
            sql = sql + "," + cDiscountAmount
            sql = sql + "=" + CStr(.DiscountAmount)
            sql = sql + "," + cMode
            sql = sql + "='" + .Mode + "'"
            sql = sql + "," + cPurchaseId
            sql = sql + "=" + CStr(.PurchaseId)
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + "," + cReturnDate
            sql = sql + "='" + .ReturnDate.ToString("s") + "'"
            sql = sql + "," + cNotClosed
            sql = sql + "=" + CStr(Math.Abs(CInt(.NotClosed)))
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "PurchaseOrderDetail"

    Public Overrides Function GetAllPurchaseOrderDetail() As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseOrderDetail

        Return sql
    End Function

    Public Overrides Function GetAllPurchaseOrderDetailForPurchaseOrderId(ByVal purchaseOrderId As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseOrderDetail
        sql = sql + " where " + cOrderId + "=" + CStr(purchaseOrderId)

        Return sql
    End Function

    Public Overrides Function GetPurchaseOrderDetail(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseOrderDetail
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoPurchaseOrderDetail(ByRef purchaseOrderDetailObj As ClsPurchaseOrderDetail) As String
        Dim sql As String = ""
        sql = "insert into " + cPurchaseOrderDetail + "("
        sql = sql + cOrderId
        sql = sql + "," + cItemId
        sql = sql + "," + cOrderQuantity
        sql = sql + "," + cOrderPrice
        sql = sql + "," + cPricePurchasePrevious
        sql = sql + "," + cVendorId
        sql = sql + "," + cManufacturerId
        sql = sql + ") values("
        With purchaseOrderDetailObj
            sql = sql + CStr(.OrderId)
            sql = sql + "," + CStr(.ItemId)
            sql = sql + "," + CStr(.OrderQuantity)
            sql = sql + "," + CStr(.OrderPrice)
            sql = sql + "," + CStr(.PricePurchasePrevious)
            sql = sql + "," + CStr(.VendorId)
            sql = sql + "," + CStr(.ManufacturerId)
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdatePurchaseOrderDetail(ByRef purchaseOrderDetailObj As ClsPurchaseOrderDetail) As String
        Dim sql As String = ""
        sql = "update " + cPurchaseOrderDetail
        sql = sql + " set "
        With purchaseOrderDetailObj
            sql = sql + cOrderId
            sql = sql + "=" + CStr(.OrderId)
            sql = sql + "," + cItemId
            sql = sql + "=" + CStr(.ItemId)
            sql = sql + "," + cOrderQuantity
            sql = sql + "=" + CStr(.OrderQuantity)
            sql = sql + "," + cOrderPrice
            sql = sql + "=" + CStr(.OrderPrice)
            sql = sql + "," + cPricePurchasePrevious
            sql = sql + "=" + CStr(.PricePurchasePrevious)
            sql = sql + "," + cVendorId
            sql = sql + "=" + CStr(.VendorId)
            sql = sql + "," + cManufacturerId
            sql = sql + "=" + CStr(.ManufacturerId)
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function DeletePurchaseOrderDetail(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "delete " + cPurchaseOrderDetail
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

#End Region

#Region "PurchaseOrderMaster"

    Public Overrides Function GetAllPurchaseOrderMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseOrderMaster

        Return sql
    End Function

    Public Overrides Function GetAllPurchaseOrderMasterValuesLike(ByVal forField As String, ByVal value As String) As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseOrderMaster
        If forField = cId Then
            sql = sql + " where " + cId + " like '" + value.Trim + "%'"
            'ElseIf forField = cStockLimit Then
            '    sql = sql + " where " + cStockLimit + " like '" + value.Trim + "%'"
            'ElseIf forField = cPurchaseLimit Then
            '    sql = sql + " where " + cPurchaseLimit + " like '" + value.Trim + "%'"
        Else
            sql = ""
        End If

        Return sql
    End Function

    Public Overrides Function GetAllPurchaseOrderMasterLikeOrderDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
        Dim flag As Boolean = False
        Dim sql As String = ""
        sql = "select * from " + cPurchaseOrderMaster
        sql = sql + " where "

        If day.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(DAY, " + cOrderDate + ") = '" + day + "' "
            flag = True
        End If

        If month.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(MONTH, " + cOrderDate + ") = '" + month + "' "
            flag = True
        End If

        If year.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(YEAR, " + cOrderDate + ") = '" + year + "' "
            flag = True
        End If

        If flag = False Then sql = ""

        Return sql
    End Function

    Public Overrides Function GetPurchaseOrderMasterNotClosedForLogin(ByVal loginName As String) As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseOrderMaster
        sql = sql + " where " + cUserId + "='" + loginName + "'"
        sql = sql + " and " + cNotClosed + "=" + CStr(Math.Abs(CInt(True)))

        Return sql
    End Function

    Public Overrides Function GetPurchaseOrderMasterIdNotClosedForLogin(ByVal loginName As String) As String
        Dim sql As String = ""
        sql = "select max(" + cId + ") from " + cPurchaseOrderMaster
        sql = sql + " where " + cUserId + "='" + loginName + "'"
        sql = sql + " and " + cNotClosed + "=" + CStr(Math.Abs(CInt(True)))

        Return sql
    End Function

    Public Overrides Function GetPurchaseOrderMaster(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cPurchaseOrderMaster
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoPurchaseOrderMaster(ByRef purchaseOrderMasterObj As ClsPurchaseOrderMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cPurchaseOrderMaster + "("
        sql = sql + cOrderDate
        'sql = sql + "," + cStockLimit
        'sql = sql + "," + cPurchaseLimit
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + "," + cNotClosed
        sql = sql + ") values("
        With purchaseOrderMasterObj
            sql = sql + "'" + .OrderDate.ToString("s") + "'"
            ''sql = sql + "," + CStr(.StockLimit)
            ''sql = sql + "," + CStr(.PurchaseLimit)
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
            sql = sql + "," + CStr(Math.Abs(CInt(.NotClosed)))
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdatePurchaseOrderMaster(ByRef purchaseOrderMasterObj As ClsPurchaseOrderMaster) As String
        Dim sql As String = ""
        sql = "update " + cPurchaseOrderMaster
        sql = sql + " set "
        With purchaseOrderMasterObj
            sql = sql + cOrderDate
            sql = sql + "='" + .OrderDate.ToString("s") + "'"
            'sql = sql + "," + cStockLimit
            'sql = sql + "=" + CStr(.StockLimit)
            'sql = sql + "," + cPurchaseLimit
            'sql = sql + "=" + CStr(.PurchaseLimit)
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + "," + cNotClosed
            sql = sql + "=" + CStr(Math.Abs(CInt(.NotClosed)))
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "SalesDetail"

    Public Overrides Function GetAllSalesDetail() As String
        Dim sql As String = ""
        sql = "select * from " + cSalesDetail

        Return sql
    End Function

    Public Overrides Function GetAllSalesDetailForSalesId(ByVal salesId As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cSalesDetail
        sql = sql + " where " + cSaleId + "=" + CStr(salesId)

        Return sql
    End Function

    Public Overrides Function GetAllSalesDetailForSaleIds(ByVal saleIds As String) As String
        Dim sql As String = ""
        sql = "select * from " + cSalesDetail
        sql = sql + " where " + cSaleId + " in (" + saleIds + ")"

        Return sql
    End Function

    Public Overrides Function GetAllSalesDetailForCustomerIdAndBatch(ByVal customerId As Integer, ByVal batch As String) As String
        Dim sql As String = ""
        sql = "select * from " + cSalesDetail
        sql = sql + " where " + cSaleId + " in (" + GetAllSalesMasterIdForCustomerId(customerId) + ") "
        sql = sql + " And " + cBatch + " = '" + batch + "' "

        Return sql
    End Function

    Public Overrides Function GetAllSalesDetailForSalesCode(ByVal salesCode As String) As String
        Dim sql As String = ""
        sql = "select * from " + cSalesDetail
        sql = sql + " where " + cSaleId + " in (" + GetSalesMasterIdSaleCode(salesCode) + ")"

        Return sql
    End Function

    Public Overrides Function GetSalesDetail(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cSalesDetail
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Protected Overrides Function GetSalesDetailTotalForSaleId(ByVal saleId As Long) As String
        Dim sql As String = ""
        sql = "select sum((" + cSaleQuantity + " * " + cPriceSale + ") + " + cTaxAmount + " - " + cDiscountAmount + ") from " + cSalesDetail
        sql = sql + " where " + cSaleId + "=" + CStr(saleId)

        Return sql
    End Function

    Public Overrides Function InsertIntoSalesDetail(ByRef salesDetailObj As ClsSalesDetail) As String
        Dim sql As String = ""
        sql = "insert into " + cSalesDetail + "("
        sql = sql + cSaleId
        sql = sql + "," + cItemId
        sql = sql + "," + cBatch
        sql = sql + "," + cExpiryDate
        sql = sql + "," + cManufactureDate
        sql = sql + "," + cManufacturerId
        sql = sql + "," + cMRP
        sql = sql + "," + cPTR
        sql = sql + "," + cPTS
        sql = sql + "," + cRate1
        sql = sql + "," + cRate2
        sql = sql + "," + cRate3
        sql = sql + "," + cPackQuantity
        sql = sql + "," + cSaleQuantity
        sql = sql + "," + cFreeQuantity
        sql = sql + "," + cPricePurchase
        sql = sql + "," + cPriceSale
        sql = sql + "," + cTaxPercent
        sql = sql + "," + cDiscountPercent
        sql = sql + "," + cDiscountAmount
        sql = sql + "," + cTaxAmount
        sql = sql + "," + cStorageId
        sql = sql + "," + cRemark
        sql = sql + "," + cForCashOut
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With salesDetailObj
            sql = sql + CStr(.SaleId)
            sql = sql + "," + CStr(.ItemId)
            sql = sql + ",'" + .Batch + "'"
            sql = sql + ",'" + .ExpiryDate.ToString("s") + "'"
            sql = sql + ",'" + .ManufactureDate.ToString("s") + "'"
            sql = sql + "," + CStr(.ManufacturerId)
            sql = sql + "," + CStr(.MRP)
            sql = sql + "," + CStr(.PTR)
            sql = sql + "," + CStr(.PTS)
            sql = sql + "," + CStr(.Rate1)
            sql = sql + "," + CStr(.Rate2)
            sql = sql + "," + CStr(.Rate3)
            sql = sql + "," + CStr(.PackQuantity)
            sql = sql + "," + CStr(.SaleQuantity)
            sql = sql + "," + CStr(.FreeQuantity)
            sql = sql + "," + CStr(.PricePurchase)
            sql = sql + "," + CStr(.PriceSale)
            sql = sql + "," + CStr(.TaxPercent)
            sql = sql + "," + CStr(.DiscountPercent)
            sql = sql + "," + CStr(.DiscountAmount)
            sql = sql + "," + CStr(.TaxAmount)
            sql = sql + "," + CStr(.StorageId)
            sql = sql + ",'" + .Remark + "'"
            sql = sql + "," + CStr(Math.Abs(CInt(.ForCashOut)))
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateSalesDetail(ByRef salesDetailObj As ClsSalesDetail) As String
        Dim sql As String = ""
        sql = "update " + cSalesDetail
        sql = sql + " set "
        With salesDetailObj
            sql = sql + cSaleId
            sql = sql + "=" + CStr(.SaleId)
            sql = sql + "," + cItemId
            sql = sql + "=" + CStr(.ItemId)
            sql = sql + "," + cBatch
            sql = sql + "='" + .Batch + "'"
            sql = sql + "," + cExpiryDate
            sql = sql + "='" + .ExpiryDate.ToString("s") + "'"
            sql = sql + "," + cManufactureDate
            sql = sql + "='" + .ManufactureDate.ToString("s") + "'"
            sql = sql + "," + cManufacturerId
            sql = sql + "=" + CStr(.ManufacturerId)
            sql = sql + "," + cMRP
            sql = sql + "=" + CStr(.MRP)
            sql = sql + "," + cPTR
            sql = sql + "=" + CStr(.PTR)
            sql = sql + "," + cPTS
            sql = sql + "=" + CStr(.PTS)
            sql = sql + "," + cRate1
            sql = sql + "=" + CStr(.Rate1)
            sql = sql + "," + cRate2
            sql = sql + "=" + CStr(.Rate2)
            sql = sql + "," + cRate3
            sql = sql + "=" + CStr(.Rate3)
            sql = sql + "," + cPackQuantity
            sql = sql + "=" + CStr(.PackQuantity)
            sql = sql + "," + cSaleQuantity
            sql = sql + "=" + CStr(.SaleQuantity)
            sql = sql + "," + cFreeQuantity
            sql = sql + "=" + CStr(.FreeQuantity)
            sql = sql + "," + cPricePurchase
            sql = sql + "=" + CStr(.PricePurchase)
            sql = sql + "," + cPriceSale
            sql = sql + "=" + CStr(.PriceSale)
            sql = sql + "," + cTaxPercent
            sql = sql + "=" + CStr(.TaxPercent)
            sql = sql + "," + cDiscountPercent
            sql = sql + "=" + CStr(.DiscountPercent)
            sql = sql + "," + cDiscountAmount
            sql = sql + "=" + CStr(.DiscountAmount)
            sql = sql + "," + cTaxAmount
            sql = sql + "=" + CStr(.TaxAmount)
            sql = sql + "," + cStorageId
            sql = sql + "=" + CStr(.StorageId)
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cForCashOut
            sql = sql + "=" + CStr(Math.Abs(CInt(.ForCashOut)))
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function DeleteSalesDetail(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "delete " + cSalesDetail
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

#End Region

#Region "SalesMaster"

    Public Overrides Function GetAllSalesMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cSalesMaster
        sql = sql + " order by " + cSaleDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetAllSalesMasterForCashOut() As String
        Dim sql As String = ""
        sql = "select * from " + cSalesMaster
        sql = sql + " where " + cCashOut + "=" + CStr(Math.Abs(CInt(True)))
        sql = sql + " order by " + cSaleDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetAllSalesMasterForLRNo() As String
        Dim sql As String = ""
        sql = "select * from " + cSalesMaster
        sql = sql + " where " + cLRNo + "=''"
        sql = sql + " order by " + cSaleDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetAllSalesMasterForCustomerCode(ByVal customerCode As String) As String
        Dim sql As String = ""
        sql = "select * from " + cSalesMaster
        sql = sql + " where " + cCustomerId + " in (" + GetCustomerMasterIdForCode(customerCode) + ")"
        sql = sql + " order by " + cSaleDate + " desc "

        Return sql
    End Function

    Protected Overrides Function GetAllSalesMasterIdForCustomerId(ByVal customerId As Integer) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cSalesMaster
        sql = sql + " where " + cCustomerId + " = " + CStr(customerId)

        Return sql
    End Function

    Public Overrides Function GetAllSalesMasterValuesLike(ByVal forField As String, ByVal value As String) As String
        Dim sql As String = ""
        sql = "select * from " + cSalesMaster
        If forField = cSaleCode Then
            sql = sql + " where " + cSaleCode + " like '" + value.Trim + "%'"
        ElseIf forField = cMode Then
            sql = sql + " where " + cMode + " like '" + value.Trim + "%'"
            'ElseIf forField = cDoctorId Then
            '    sql = sql + " where " + cDoctorId + " in(" + GetAllDoctorMasterIdNameLike(value) + ")"
        ElseIf forField = cCustomerId Then
            sql = sql + " where " + cCustomerId + " in(" + GetAllCustomerMasterIdNameLike(value) + ")"
        Else
            sql = ""
        End If

        If sql.Trim <> "" Then sql = sql + " order by " + cSaleDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetAllSalesMasterLikeSaleDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
        Dim flag As Boolean = False
        Dim sql As String = ""
        sql = "select * from " + cSalesMaster
        sql = sql + " where "

        If day.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(DAY, " + cSaleDate + ") = '" + day + "' "
            flag = True
        End If

        If month.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(MONTH, " + cSaleDate + ") = '" + month + "' "
            flag = True
        End If

        If year.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(YEAR, " + cSaleDate + ") = '" + year + "' "
            flag = True
        End If

        If flag = False Then sql = ""
        If sql.Trim <> "" Then sql = sql + " order by " + cSaleDate + " desc "

        Return sql
    End Function

    Protected Overrides Function GetAllSalesMasterIdSaleCodeLike(ByVal value As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cSalesMaster
        sql = sql + " where " + cSaleCode + " like '" + value.Trim + "%'"
        sql = sql + " order by " + cSaleDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetAllSalesMasterForDateOn(ByVal dateFrom As Date, ByVal dateTo As Date) As String
        Dim sql As String = ""
        sql = "select * from " + cSalesMaster
        sql = sql + " where " + cDateOn + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        sql = sql + " order by " + cSaleDate + " desc "

        Return sql
    End Function

    Protected Overrides Function GetSalesMasterIdSaleCode(ByVal code As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cSalesMaster
        sql = sql + " where " + cSaleCode + " = '" + code.Trim + "'"

        Return sql
    End Function

    Public Overrides Function GetSalesMasterNotClosedForLogin(ByVal loginName As String) As String
        Dim sql As String = ""
        sql = "select * from " + cSalesMaster
        sql = sql + " where " + cUserId + "='" + loginName + "'"
        sql = sql + " and " + cNotClosed + "=" + CStr(Math.Abs(CInt(True)))

        Return sql
    End Function

    Public Overrides Function GetSalesMasterIdNotClosedForLogin(ByVal loginName As String) As String
        Dim sql As String = ""
        sql = "select max(" + cId + ") from " + cSalesMaster
        sql = sql + " where " + cUserId + "='" + loginName + "'"
        sql = sql + " and " + cNotClosed + "=" + CStr(Math.Abs(CInt(True)))

        Return sql
    End Function

    Public Overrides Function GetSalesMaster(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cSalesMaster
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function GetSalesMasterNetAmount(ByVal id As Long) As String
        Dim sql As String = ""
        sql = GetSalesDetailTotalForSaleId(id)

        Return sql
    End Function

    Public Overrides Function GetSalesMasterDiscountAmount(ByVal id As Long) As String
        Dim sql As String = ""
        sql = sql + "SELECT " + cSalesMaster + "." + cDiscountAmount
        sql = sql + " FROM " + cSalesMaster
        sql = sql + " where " + cSalesMaster + "." + cId + " = " + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoSalesMaster(ByRef salesMasterObj As ClsSalesMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cSalesMaster + "("
        sql = sql + cSaleCode
        sql = sql + "," + cCustomerId
        sql = sql + "," + cDoctorId
        sql = sql + "," + cMode
        sql = sql + "," + cRemark
        sql = sql + "," + cPrescription
        sql = sql + "," + cCashOutAmount
        sql = sql + "," + cAdjustedAmount
        sql = sql + "," + cSaleDate
        sql = sql + "," + cCashMemo
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + "," + cNotClosed
        sql = sql + "," + cForCashOut
        sql = sql + "," + cDiscountAmount
        sql = sql + "," + cDivisionId
        sql = sql + "," + cPickSlipNo
        sql = sql + "," + cOrderNo
        sql = sql + "," + cOrderDate
        sql = sql + "," + cReference
        sql = sql + "," + cTransporterId
        sql = sql + "," + cDestination
        sql = sql + "," + cLRNo
        sql = sql + "," + cLRDate
        sql = sql + "," + cChequeNo
        sql = sql + "," + cCases
        sql = sql + "," + cDueDate
        sql = sql + "," + cHQId
        sql = sql + "," + cCreditAdjust
        sql = sql + "," + cDebitAdjust
        sql = sql + "," + cTaxId
        sql = sql + "," + cTaxPercent
        sql = sql + "," + cPreExciseAmount
        sql = sql + "," + cFreightCharge
        sql = sql + "," + cCancelled
        sql = sql + ") values("
        With salesMasterObj
            sql = sql + "'" + .SaleCode + "'"
            sql = sql + "," + CStr(.CustomerId)
            sql = sql + "," + CStr(.DoctorId)
            sql = sql + ",'" + .Mode + "'"
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .Prescription + "'"
            sql = sql + "," + CStr(.CashOutAmount)
            sql = sql + "," + CStr(.AdjustedAmount)
            sql = sql + ",'" + .SaleDate.ToString("s") + "'"
            sql = sql + "," + CStr(Math.Abs(CInt(.CashMemo)))
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
            sql = sql + "," + CStr(Math.Abs(CInt(.NotClosed)))
            sql = sql + "," + CStr(Math.Abs(CInt(.ForCashOut)))
            sql = sql + "," + CStr(.DiscountAmount)
            sql = sql + "," + CStr(.DivisionId)
            sql = sql + ",'" + .PickSlipNo + "'"
            sql = sql + ",'" + .OrderNo + "'"
            sql = sql + ",'" + .OrderDate.ToString("s") + "'"
            sql = sql + ",'" + .Reference + "'"
            sql = sql + "," + CStr(.TransporterId)
            sql = sql + ",'" + .Destination + "'"
            sql = sql + ",'" + .LRNo + "'"
            sql = sql + ",'" + .LRDate.ToString("s") + "'"
            sql = sql + ",'" + .ChequeNo + "'"
            sql = sql + ",'" + .Cases + "'"
            sql = sql + ",'" + .DueDate.ToString("s") + "'"
            sql = sql + "," + CStr(.HQId)
            sql = sql + "," + CStr(.CreditAdjust)
            sql = sql + "," + CStr(.DebitAdjust)
            sql = sql + "," + CStr(.TaxId)
            sql = sql + "," + CStr(.TaxPercent)
            sql = sql + "," + CStr(.PreExciseAmount)
            sql = sql + "," + CStr(.FreightCharge)
            sql = sql + "," + CStr(Math.Abs(CInt(.Cancelled)))
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateSalesMaster(ByRef salesMasterObj As ClsSalesMaster) As String
        Dim sql As String = ""
        sql = "update " + cSalesMaster
        sql = sql + " set "
        With salesMasterObj
            sql = sql + cSaleCode
            sql = sql + "='" + .SaleCode + "'"
            sql = sql + "," + cCustomerId
            sql = sql + "=" + CStr(.CustomerId)
            sql = sql + "," + cDoctorId
            sql = sql + "=" + CStr(.DoctorId)
            sql = sql + "," + cMode
            sql = sql + "='" + .Mode + "'"
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cPrescription
            sql = sql + "='" + .Prescription + "'"
            sql = sql + "," + cCashOutAmount
            sql = sql + "=" + CStr(.CashOutAmount)
            sql = sql + "," + cAdjustedAmount
            sql = sql + "=" + CStr(.AdjustedAmount)
            sql = sql + "," + cSaleDate
            sql = sql + "='" + .SaleDate.ToString("s") + "'"
            sql = sql + "," + cCashMemo
            sql = sql + "=" + CStr(Math.Abs(CInt(.CashMemo)))
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + "," + cNotClosed
            sql = sql + "=" + CStr(Math.Abs(CInt(.NotClosed)))
            sql = sql + "," + cForCashOut
            sql = sql + "=" + CStr(Math.Abs(CInt(.ForCashOut)))
            sql = sql + "," + cDiscountAmount
            sql = sql + "=" + CStr(.DiscountAmount)
            sql = sql + "," + cDivisionId
            sql = sql + "=" + CStr(.DivisionId)
            sql = sql + "," + cPickSlipNo
            sql = sql + "='" + .PickSlipNo + "'"
            sql = sql + "," + cOrderNo
            sql = sql + "='" + .OrderNo + "'"
            sql = sql + "," + cOrderDate
            sql = sql + "='" + .OrderDate.ToString("s") + "'"
            sql = sql + "," + cReference
            sql = sql + "='" + .Reference + "'"
            sql = sql + "," + cTransporterId
            sql = sql + "=" + CStr(.TransporterId)
            sql = sql + "," + cDestination
            sql = sql + "='" + .Destination + "'"
            sql = sql + "," + cLRNo
            sql = sql + "='" + .LRNo + "'"
            sql = sql + "," + cLRDate
            sql = sql + "='" + .LRDate.ToString("s") + "'"
            sql = sql + "," + cChequeNo
            sql = sql + "='" + .ChequeNo + "'"
            sql = sql + "," + cCases
            sql = sql + "='" + .Cases + "'"
            sql = sql + "," + cDueDate
            sql = sql + "='" + .DueDate.ToString("s") + "'"
            sql = sql + "," + cHQId
            sql = sql + "=" + CStr(.HQId)
            sql = sql + "," + cCreditAdjust
            sql = sql + "=" + CStr(.CreditAdjust)
            sql = sql + "," + cDebitAdjust
            sql = sql + "=" + CStr(.DebitAdjust)
            sql = sql + "," + cTaxId
            sql = sql + "=" + CStr(.TaxId)
            sql = sql + "," + cTaxPercent
            sql = sql + "=" + CStr(.TaxPercent)
            sql = sql + "," + cPreExciseAmount
            sql = sql + "=" + CStr(.PreExciseAmount)
            sql = sql + "," + cFreightCharge
            sql = sql + "=" + CStr(.FreightCharge)
            sql = sql + "," + cCancelled
            sql = sql + "=" + CStr(Math.Abs(CInt(.Cancelled)))
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "SalesReturnDetail"

    Public Overrides Function GetAllSalesReturnDetail() As String
        Dim sql As String = ""
        sql = "select * from " + cSalesReturnDetail

        Return sql
    End Function

    Public Overrides Function GetAllSalesReturnDetailForSalesReturnId(ByVal salesReturnId As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cSalesReturnDetail
        sql = sql + " where " + cSalesReturnId + "=" + CStr(salesReturnId)

        Return sql
    End Function

    Public Overrides Function GetSalesReturnDetail(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cSalesReturnDetail
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoSalesReturnDetail(ByRef salesReturnDetailsObj As ClsSalesReturnDetail) As String
        Dim sql As String = ""
        sql = "insert into " + cSalesReturnDetail + "("
        sql = sql + cSalesReturnId
        sql = sql + "," + cItemId
        sql = sql + "," + cBatch
        sql = sql + "," + cExpiryDate
        sql = sql + "," + cPackQuantity
        sql = sql + "," + cReturnQuantity
        sql = sql + "," + cNonSaleable
        sql = sql + "," + cPricePurchase
        sql = sql + "," + cPriceSale
        sql = sql + "," + cTaxPercent
        sql = sql + "," + cDiscountPercent
        sql = sql + "," + cTaxAmount
        sql = sql + "," + cDiscountAmount
        sql = sql + "," + cStorageId
        sql = sql + "," + cRemark
        sql = sql + "," + cSaleId
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With salesReturnDetailsObj
            sql = sql + CStr(.SalesReturnId)
            sql = sql + "," + CStr(.ItemId)
            sql = sql + ",'" + .Batch + "'"
            sql = sql + ",'" + .ExpiryDate.ToString("s") + "'"
            sql = sql + "," + CStr(.PackQuantity)
            sql = sql + "," + CStr(.ReturnQuantity)
            sql = sql + "," + CStr(Math.Abs(CInt(.NonSaleable)))
            sql = sql + "," + CStr(.PricePurchase)
            sql = sql + "," + CStr(.PriceSale)
            sql = sql + "," + CStr(.TaxPercent)
            sql = sql + "," + CStr(.DiscountPercent)
            sql = sql + "," + CStr(.TaxAmount)
            sql = sql + "," + CStr(.DiscountAmount)
            sql = sql + "," + CStr(.StorageId)
            sql = sql + ",'" + .Remark + "'"
            sql = sql + "," + CStr(.SaleId)
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateSalesReturnDetail(ByRef salesReturnDetailsObj As ClsSalesReturnDetail) As String
        Dim sql As String = ""
        sql = "update " + cSalesReturnDetail
        sql = sql + " set "
        With salesReturnDetailsObj
            sql = sql + cSalesReturnId
            sql = sql + "=" + CStr(.SalesReturnId)
            sql = sql + "," + cItemId
            sql = sql + "=" + CStr(.ItemId)
            sql = sql + "," + cBatch
            sql = sql + "='" + .Batch + "'"
            sql = sql + "," + cExpiryDate
            sql = sql + "='" + .ExpiryDate.ToString("s") + "'"
            sql = sql + "," + cPackQuantity
            sql = sql + "=" + CStr(.PackQuantity)
            sql = sql + "," + cReturnQuantity
            sql = sql + "=" + CStr(.ReturnQuantity)
            sql = sql + "," + cNonSaleable
            sql = sql + "=" + CStr(Math.Abs(CInt(.NonSaleable)))
            sql = sql + "," + cPricePurchase
            sql = sql + "=" + CStr(.PricePurchase)
            sql = sql + "," + cPriceSale
            sql = sql + "=" + CStr(.PriceSale)
            sql = sql + "," + cTaxPercent
            sql = sql + "=" + CStr(.TaxPercent)
            sql = sql + "," + cDiscountPercent
            sql = sql + "=" + CStr(.DiscountPercent)
            sql = sql + "," + cTaxAmount
            sql = sql + "=" + CStr(.TaxAmount)
            sql = sql + "," + cDiscountAmount
            sql = sql + "=" + CStr(.DiscountAmount)
            sql = sql + "," + cStorageId
            sql = sql + "=" + CStr(.StorageId)
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cSaleId
            sql = sql + "=" + CStr(.SaleId)
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function DeleteSalesReturnDetail(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "delete " + cSalesReturnDetail
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

#End Region

#Region "SalesReturnMaster"

    Public Overrides Function GetAllSalesReturnMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cSalesReturnMaster

        Return sql
    End Function

    Public Overrides Function GetAllSalesReturnMasterValuesLike(ByVal forField As String, ByVal value As String) As String
        Dim sql As String = ""
        sql = "select * from " + cSalesReturnMaster
        If forField = cSalesReturnCode Then
            sql = sql + " where " + cSalesReturnCode + " like '" + value.Trim + "%'"
        ElseIf forField = cSaleId Then
            sql = sql + " where " + cSaleId + " in(" + GetAllSalesMasterIdSaleCodeLike(value) + ")"
            'ElseIf forField = cDoctorId Then
            '    sql = sql + " where " + cDoctorId + " in(" + GetAllDoctorMasterIdNameLike(value) + ")"
        ElseIf forField = cCustomerId Then
            sql = sql + " where " + cCustomerId + " in(" + GetAllCustomerMasterIdNameLike(value) + ")"
        Else
            sql = ""
        End If

        Return sql
    End Function

    Public Overrides Function GetAllSalesReturnMasterLikeReturnDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
        Dim flag As Boolean = False
        Dim sql As String = ""
        sql = "select * from " + cSalesReturnMaster
        sql = sql + " where "

        If day.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(DAY, " + cReturnDate + ") = '" + day + "' "
            flag = True
        End If

        If month.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(MONTH, " + cReturnDate + ") = '" + month + "' "
            flag = True
        End If

        If year.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(YEAR, " + cReturnDate + ") = '" + year + "' "
            flag = True
        End If

        If flag = False Then sql = ""

        Return sql
    End Function

    Public Overrides Function GetSalesReturnMasterNotClosedForLogin(ByVal loginName As String) As String
        Dim sql As String = ""
        sql = "select * from " + cSalesReturnMaster
        sql = sql + " where " + cUserId + "='" + loginName + "'"
        sql = sql + " and " + cNotClosed + "=" + CStr(Math.Abs(CInt(True)))

        Return sql
    End Function

    Public Overrides Function GetSalesReturnMasterIdNotClosedForLogin(ByVal loginName As String) As String
        Dim sql As String = ""
        sql = "select max(" + cId + ") from " + cSalesReturnMaster
        sql = sql + " where " + cUserId + "='" + loginName + "'"
        sql = sql + " and " + cNotClosed + "=" + CStr(Math.Abs(CInt(True)))

        Return sql
    End Function

    Public Overrides Function GetSalesReturnMaster(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cSalesReturnMaster
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function GetSalesReturnMasterDiscountAmount(ByVal id As Long) As String
        Dim sql As String = ""
        sql = sql + "SELECT " + cSalesReturnMaster + "." + cDiscountAmount
        sql = sql + " FROM " + cSalesReturnMaster
        sql = sql + " where " + cSalesReturnMaster + "." + cId + " = " + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoSalesReturnMaster(ByRef salesReturnMastersObj As ClsSalesReturnMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cSalesReturnMaster + "("
        sql = sql + cSaleId
        sql = sql + "," + cCustomerId
        sql = sql + "," + cDoctorId
        sql = sql + "," + cDiscountAmount
        sql = sql + "," + cSalesReturnCode
        sql = sql + "," + cStatus
        sql = sql + "," + cRemark
        sql = sql + "," + cReturnDate
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + "," + cNotClosed
        sql = sql + ") values("
        With salesReturnMastersObj
            sql = sql + CStr(.SaleId)
            sql = sql + "," + CStr(.CustomerId)
            sql = sql + "," + CStr(.DoctorId)
            sql = sql + "," + CStr(.DiscountAmount)
            sql = sql + ",'" + .SalesReturnCode + "'"
            sql = sql + ",'" + .Status + "'"
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .ReturnDate.ToString("s") + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
            sql = sql + "," + CStr(Math.Abs(CInt(.NotClosed)))
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateSalesReturnMaster(ByRef salesReturnMastersObj As ClsSalesReturnMaster) As String
        Dim sql As String = ""
        sql = "update " + cSalesReturnMaster
        sql = sql + " set "
        With salesReturnMastersObj
            sql = sql + cSaleId
            sql = sql + "=" + CStr(.SaleId)
            sql = sql + "," + cCustomerId
            sql = sql + "=" + CStr(.CustomerId)
            sql = sql + "," + cDoctorId
            sql = sql + "=" + CStr(.DoctorId)
            sql = sql + "," + cDiscountAmount
            sql = sql + "=" + CStr(.DiscountAmount)
            sql = sql + "," + cSalesReturnCode
            sql = sql + "='" + .SalesReturnCode + "'"
            sql = sql + "," + cStatus
            sql = sql + "='" + .Status + "'"
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cReturnDate
            sql = sql + "='" + .ReturnDate.ToString("s") + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + "," + cNotClosed
            sql = sql + "=" + CStr(Math.Abs(CInt(.NotClosed)))
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "SampleDetail"

    Public Overrides Function GetAllSampleDetail() As String
        Dim sql As String = ""
        sql = "select * from " + cSampleDetail

        Return sql
    End Function

    Public Overrides Function GetAllSampleDetailForSampleId(ByVal sampleId As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cSampleDetail
        sql = sql + " where " + cSampleId + "=" + CStr(sampleId)

        Return sql
    End Function

    Public Overrides Function GetAllSampleDetailForSampleCode(ByVal sampleCode As String) As String
        Dim sql As String = ""
        sql = "select * from " + cSampleDetail
        sql = sql + " where " + cSampleId + " in (" + GetSampleMasterIdSampleCode(sampleCode) + ")"

        Return sql
    End Function

    Public Overrides Function GetAllSampleDetailForSampleIds(ByVal sampleIds As String) As String
        Dim sql As String = ""
        sql = "select * from " + cSampleDetail
        sql = sql + " where " + cSampleId + " in (" + sampleIds + ")"

        Return sql
    End Function

    Public Overrides Function GetSampleDetail(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cSampleDetail
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Protected Overrides Function GetSampleDetailTotalForSampleId(ByVal sampleId As Long) As String
        Dim sql As String = ""
        sql = "select sum((" + cSampleQuantity + " * " + cPriceSample + ") + " + cTaxAmount + " - " + cDiscountAmount + ") from " + cSampleDetail
        sql = sql + " where " + cSampleId + "=" + CStr(sampleId)

        Return sql
    End Function

    Public Overrides Function InsertIntoSampleDetail(ByRef sampleDetailObj As ClsSampleDetail) As String
        Dim sql As String = ""
        sql = "insert into " + cSampleDetail + "("
        sql = sql + cSampleId
        sql = sql + "," + cItemId
        sql = sql + "," + cBatch
        sql = sql + "," + cExpiryDate
        sql = sql + "," + cManufactureDate
        sql = sql + "," + cManufacturerId
        sql = sql + "," + cMRP
        sql = sql + "," + cPTR
        sql = sql + "," + cPTS
        sql = sql + "," + cRate1
        sql = sql + "," + cRate2
        sql = sql + "," + cRate3
        sql = sql + "," + cPackQuantity
        sql = sql + "," + cSampleQuantity
        sql = sql + "," + cFreeQuantity
        sql = sql + "," + cPricePurchase
        sql = sql + "," + cPriceSample
        sql = sql + "," + cTaxPercent
        sql = sql + "," + cDiscountPercent
        sql = sql + "," + cDiscountAmount
        sql = sql + "," + cTaxAmount
        sql = sql + "," + cStorageId
        sql = sql + "," + cRemark
        sql = sql + "," + cForCashOut
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With sampleDetailObj
            sql = sql + CStr(.SampleId)
            sql = sql + "," + CStr(.ItemId)
            sql = sql + ",'" + .Batch + "'"
            sql = sql + ",'" + .ExpiryDate.ToString("s") + "'"
            sql = sql + ",'" + .ManufactureDate.ToString("s") + "'"
            sql = sql + "," + CStr(.ManufacturerId)
            sql = sql + "," + CStr(.MRP)
            sql = sql + "," + CStr(.PTR)
            sql = sql + "," + CStr(.PTS)
            sql = sql + "," + CStr(.Rate1)
            sql = sql + "," + CStr(.Rate2)
            sql = sql + "," + CStr(.Rate3)
            sql = sql + "," + CStr(.PackQuantity)
            sql = sql + "," + CStr(.SampleQuantity)
            sql = sql + "," + CStr(.FreeQuantity)
            sql = sql + "," + CStr(.PricePurchase)
            sql = sql + "," + CStr(.PriceSample)
            sql = sql + "," + CStr(.TaxPercent)
            sql = sql + "," + CStr(.DiscountPercent)
            sql = sql + "," + CStr(.DiscountAmount)
            sql = sql + "," + CStr(.TaxAmount)
            sql = sql + "," + CStr(.StorageId)
            sql = sql + ",'" + .Remark + "'"
            sql = sql + "," + CStr(Math.Abs(CInt(.ForCashOut)))
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateSampleDetail(ByRef sampleDetailObj As ClsSampleDetail) As String
        Dim sql As String = ""
        sql = "update " + cSampleDetail
        sql = sql + " set "
        With sampleDetailObj
            sql = sql + cSampleId
            sql = sql + "=" + CStr(.SampleId)
            sql = sql + "," + cItemId
            sql = sql + "=" + CStr(.ItemId)
            sql = sql + "," + cBatch
            sql = sql + "='" + .Batch + "'"
            sql = sql + "," + cExpiryDate
            sql = sql + "='" + .ExpiryDate.ToString("s") + "'"
            sql = sql + "," + cManufactureDate
            sql = sql + "='" + .ManufactureDate.ToString("s") + "'"
            sql = sql + "," + cManufacturerId
            sql = sql + "=" + CStr(.ManufacturerId)
            sql = sql + "," + cMRP
            sql = sql + "=" + CStr(.MRP)
            sql = sql + "," + cPTR
            sql = sql + "=" + CStr(.PTR)
            sql = sql + "," + cPTS
            sql = sql + "=" + CStr(.PTS)
            sql = sql + "," + cRate1
            sql = sql + "=" + CStr(.Rate1)
            sql = sql + "," + cRate2
            sql = sql + "=" + CStr(.Rate2)
            sql = sql + "," + cRate3
            sql = sql + "=" + CStr(.Rate3)
            sql = sql + "," + cPackQuantity
            sql = sql + "=" + CStr(.PackQuantity)
            sql = sql + "," + cSampleQuantity
            sql = sql + "=" + CStr(.SampleQuantity)
            sql = sql + "," + cFreeQuantity
            sql = sql + "=" + CStr(.FreeQuantity)
            sql = sql + "," + cPricePurchase
            sql = sql + "=" + CStr(.PricePurchase)
            sql = sql + "," + cPriceSample
            sql = sql + "=" + CStr(.PriceSample)
            sql = sql + "," + cTaxPercent
            sql = sql + "=" + CStr(.TaxPercent)
            sql = sql + "," + cDiscountPercent
            sql = sql + "=" + CStr(.DiscountPercent)
            sql = sql + "," + cDiscountAmount
            sql = sql + "=" + CStr(.DiscountAmount)
            sql = sql + "," + cTaxAmount
            sql = sql + "=" + CStr(.TaxAmount)
            sql = sql + "," + cStorageId
            sql = sql + "=" + CStr(.StorageId)
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cForCashOut
            sql = sql + "=" + CStr(Math.Abs(CInt(.ForCashOut)))
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function DeleteSampleDetail(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "delete " + cSampleDetail
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

#End Region

#Region "SampleMaster"

    Public Overrides Function GetAllSampleMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cSampleMaster
        sql = sql + " order by " + cSampleDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetAllSampleMasterForCashOut() As String
        Dim sql As String = ""
        sql = "select * from " + cSampleMaster
        sql = sql + " where " + cCashOut + "=" + CStr(Math.Abs(CInt(True)))
        sql = sql + " order by " + cSampleDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetAllSampleMasterForCustomerCode(ByVal customerCode As String) As String
        Dim sql As String = ""
        sql = "select * from " + cSampleMaster
        sql = sql + " where " + cCustomerId + " in (" + GetCustomerMasterIdForCode(customerCode) + ")"
        sql = sql + " order by " + cSampleDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetAllSampleMasterValuesLike(ByVal forField As String, ByVal value As String) As String
        Dim sql As String = ""
        sql = "select * from " + cSampleMaster
        If forField = cSampleCode Then
            sql = sql + " where " + cSampleCode + " like '" + value.Trim + "%'"
        ElseIf forField = cMode Then
            sql = sql + " where " + cMode + " like '" + value.Trim + "%'"
            'ElseIf forField = cDoctorId Then
            '    sql = sql + " where " + cDoctorId + " in(" + GetAllDoctorMasterIdNameLike(value) + ")"
        ElseIf forField = cCustomerId Then
            sql = sql + " where " + cCustomerId + " in(" + GetAllCustomerMasterIdNameLike(value) + ")"
        Else
            sql = ""
        End If

        If sql.Trim <> "" Then sql = sql + " order by " + cSampleDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetAllSampleMasterLikeSampleDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
        Dim flag As Boolean = False
        Dim sql As String = ""
        sql = "select * from " + cSampleMaster
        sql = sql + " where "

        If day.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(DAY, " + cSampleDate + ") = '" + day + "' "
            flag = True
        End If

        If month.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(MONTH, " + cSampleDate + ") = '" + month + "' "
            flag = True
        End If

        If year.Trim <> "" Then
            If flag = True Then sql = sql + " and "
            sql = sql + "DATEPART(YEAR, " + cSampleDate + ") = '" + year + "' "
            flag = True
        End If

        If flag = False Then sql = ""
        If sql.Trim <> "" Then sql = sql + " order by " + cSampleDate + " desc "

        Return sql
    End Function

    Public Overrides Function GetAllSampleMasterForDateOn(ByVal dateFrom As Date, ByVal dateTo As Date) As String
        Dim sql As String = ""
        sql = "select * from " + cSampleMaster
        sql = sql + " where " + cDateOn + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        sql = sql + " order by " + cSampleDate + " desc "

        Return sql
    End Function

    Protected Overrides Function GetAllSampleMasterIdSampleCodeLike(ByVal value As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cSampleMaster
        sql = sql + " where " + cSampleCode + " like '" + value.Trim + "%'"
        sql = sql + " order by " + cSampleDate + " desc "

        Return sql
    End Function

    Protected Overrides Function GetSampleMasterIdSampleCode(ByVal code As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cSampleMaster
        sql = sql + " where " + cSampleCode + " = '" + code.Trim + "'"

        Return sql
    End Function

    Public Overrides Function GetSampleMasterNotClosedForLogin(ByVal loginName As String) As String
        Dim sql As String = ""
        sql = "select * from " + cSampleMaster
        sql = sql + " where " + cUserId + "='" + loginName + "'"
        sql = sql + " and " + cNotClosed + "=" + CStr(Math.Abs(CInt(True)))

        Return sql
    End Function

    Public Overrides Function GetSampleMasterIdNotClosedForLogin(ByVal loginName As String) As String
        Dim sql As String = ""
        sql = "select max(" + cId + ") from " + cSampleMaster
        sql = sql + " where " + cUserId + "='" + loginName + "'"
        sql = sql + " and " + cNotClosed + "=" + CStr(Math.Abs(CInt(True)))

        Return sql
    End Function

    Public Overrides Function GetSampleMaster(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "select * from " + cSampleMaster
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function GetSampleMasterNetAmount(ByVal id As Long) As String
        Dim sql As String = ""
        sql = GetSampleDetailTotalForSampleId(id)

        Return sql
    End Function

    Public Overrides Function GetSampleMasterDiscountAmount(ByVal id As Long) As String
        Dim sql As String = ""
        sql = sql + "SELECT " + cSampleMaster + "." + cDiscountAmount
        sql = sql + " FROM " + cSampleMaster
        sql = sql + " where " + cSampleMaster + "." + cId + " = " + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoSampleMaster(ByRef sampleMasterObj As ClsSampleMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cSampleMaster + "("
        sql = sql + cSampleCode
        sql = sql + "," + cCustomerId
        sql = sql + "," + cDoctorId
        sql = sql + "," + cMode
        sql = sql + "," + cRemark
        sql = sql + "," + cPrescription
        sql = sql + "," + cCashOutAmount
        sql = sql + "," + cAdjustedAmount
        sql = sql + "," + cSampleDate
        sql = sql + "," + cCashMemo
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + "," + cNotClosed
        sql = sql + "," + cForCashOut
        sql = sql + "," + cDiscountAmount
        sql = sql + "," + cDivisionId
        sql = sql + "," + cPickSlipNo
        sql = sql + "," + cOrderNo
        sql = sql + "," + cOrderDate
        sql = sql + "," + cReference
        sql = sql + "," + cTransporterId
        sql = sql + "," + cDestination
        sql = sql + "," + cLRNo
        sql = sql + "," + cLRDate
        sql = sql + "," + cChequeNo
        sql = sql + "," + cCases
        sql = sql + "," + cDueDate
        sql = sql + "," + cHQId
        sql = sql + "," + cCreditAdjust
        sql = sql + "," + cDebitAdjust
        sql = sql + "," + cTaxId
        sql = sql + "," + cTaxPercent
        sql = sql + "," + cPreExciseAmount
        sql = sql + ") values("
        With sampleMasterObj
            sql = sql + "'" + .SampleCode + "'"
            sql = sql + "," + CStr(.CustomerId)
            sql = sql + "," + CStr(.DoctorId)
            sql = sql + ",'" + .Mode + "'"
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .Prescription + "'"
            sql = sql + "," + CStr(.CashOutAmount)
            sql = sql + "," + CStr(.AdjustedAmount)
            sql = sql + ",'" + .SampleDate.ToString("s") + "'"
            sql = sql + "," + CStr(Math.Abs(CInt(.CashMemo)))
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
            sql = sql + "," + CStr(Math.Abs(CInt(.NotClosed)))
            sql = sql + "," + CStr(Math.Abs(CInt(.ForCashOut)))
            sql = sql + "," + CStr(.DiscountAmount)
            sql = sql + "," + CStr(.DivisionId)
            sql = sql + ",'" + .PickSlipNo + "'"
            sql = sql + ",'" + .OrderNo + "'"
            sql = sql + ",'" + .OrderDate.ToString("s") + "'"
            sql = sql + ",'" + .Reference + "'"
            sql = sql + "," + CStr(.TransporterId)
            sql = sql + ",'" + .Destination + "'"
            sql = sql + ",'" + .LRNo + "'"
            sql = sql + ",'" + .LRDate.ToString("s") + "'"
            sql = sql + ",'" + .ChequeNo + "'"
            sql = sql + ",'" + .Cases + "'"
            sql = sql + ",'" + .DueDate.ToString("s") + "'"
            sql = sql + "," + CStr(.HQId)
            sql = sql + "," + CStr(.CreditAdjust)
            sql = sql + "," + CStr(.DebitAdjust)
            sql = sql + "," + CStr(.TaxId)
            sql = sql + "," + CStr(.TaxPercent)
            sql = sql + "," + CStr(.PreExciseAmount)
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateSampleMaster(ByRef sampleMasterObj As ClsSampleMaster) As String
        Dim sql As String = ""
        sql = "update " + cSampleMaster
        sql = sql + " set "
        With sampleMasterObj
            sql = sql + cSampleCode
            sql = sql + "='" + .SampleCode + "'"
            sql = sql + "," + cCustomerId
            sql = sql + "=" + CStr(.CustomerId)
            sql = sql + "," + cDoctorId
            sql = sql + "=" + CStr(.DoctorId)
            sql = sql + "," + cMode
            sql = sql + "='" + .Mode + "'"
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cPrescription
            sql = sql + "='" + .Prescription + "'"
            sql = sql + "," + cCashOutAmount
            sql = sql + "=" + CStr(.CashOutAmount)
            sql = sql + "," + cAdjustedAmount
            sql = sql + "=" + CStr(.AdjustedAmount)
            sql = sql + "," + cSampleDate
            sql = sql + "='" + .SampleDate.ToString("s") + "'"
            sql = sql + "," + cCashMemo
            sql = sql + "=" + CStr(Math.Abs(CInt(.CashMemo)))
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + "," + cNotClosed
            sql = sql + "=" + CStr(Math.Abs(CInt(.NotClosed)))
            sql = sql + "," + cForCashOut
            sql = sql + "=" + CStr(Math.Abs(CInt(.ForCashOut)))
            sql = sql + "," + cDiscountAmount
            sql = sql + "=" + CStr(.DiscountAmount)
            sql = sql + "," + cDivisionId
            sql = sql + "=" + CStr(.DivisionId)
            sql = sql + "," + cPickSlipNo
            sql = sql + "='" + .PickSlipNo + "'"
            sql = sql + "," + cOrderNo
            sql = sql + "='" + .OrderNo + "'"
            sql = sql + "," + cOrderDate
            sql = sql + "='" + .OrderDate.ToString("s") + "'"
            sql = sql + "," + cReference
            sql = sql + "='" + .Reference + "'"
            sql = sql + "," + cTransporterId
            sql = sql + "=" + CStr(.TransporterId)
            sql = sql + "," + cDestination
            sql = sql + "='" + .Destination + "'"
            sql = sql + "," + cLRNo
            sql = sql + "='" + .LRNo + "'"
            sql = sql + "," + cLRDate
            sql = sql + "='" + .LRDate.ToString("s") + "'"
            sql = sql + "," + cChequeNo
            sql = sql + "='" + .ChequeNo + "'"
            sql = sql + "," + cCases
            sql = sql + "='" + .Cases + "'"
            sql = sql + "," + cDueDate
            sql = sql + "='" + .DueDate.ToString("s") + "'"
            sql = sql + "," + cHQId
            sql = sql + "=" + CStr(.HQId)
            sql = sql + "," + cCreditAdjust
            sql = sql + "=" + CStr(.CreditAdjust)
            sql = sql + "," + cDebitAdjust
            sql = sql + "=" + CStr(.DebitAdjust)
            sql = sql + "," + cTaxId
            sql = sql + "=" + CStr(.TaxId)
            sql = sql + "," + cTaxPercent
            sql = sql + "=" + CStr(.TaxPercent)
            sql = sql + "," + cPreExciseAmount
            sql = sql + "=" + CStr(.PreExciseAmount)
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "ScheduleMaster"

    Public Overrides Function ScheduleMasterUpdatable(ByRef scheduleMasterObj As ClsScheduleMaster) As String
        Dim sql As String = ""
        With scheduleMasterObj
            sql = "select * from " + cScheduleMaster
            sql = sql + " where ("
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + " or " + cColor
            sql = sql + "='" + .Color + "'"
            sql = sql + ") and " + cId
            sql = sql + "<>" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function GetAllScheduleMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cScheduleMaster

        Return sql
    End Function

    Public Overrides Function InsertIntoScheduleMaster(ByRef scheduleMasterObj As ClsScheduleMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cScheduleMaster + "("
        sql = sql + cName
        sql = sql + "," + cColor
        sql = sql + "," + cPrompt
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With scheduleMasterObj
            sql = sql + "'" + .Name + "'"
            sql = sql + ",'" + .Color + "'"
            sql = sql + "," + CStr(Math.Abs(CInt(.Prompt)))
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateScheduleMaster(ByRef scheduleMasterObj As ClsScheduleMaster) As String
        Dim sql As String = ""
        sql = "update " + cScheduleMaster
        sql = sql + " set "
        With scheduleMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cColor
            sql = sql + "='" + .Color + "'"
            sql = sql + "," + cPrompt
            sql = sql + "=" + CStr(Math.Abs(CInt(.Prompt)))
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "SpecialityMaster"

    Public Overrides Function SpecialityMasterUpdatable(ByRef specialityMasterObj As ClsSpecialityMaster) As String
        Dim sql As String = ""
        With specialityMasterObj
            sql = "select * from " + cSpecialityMaster
            sql = sql + " where "
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + " and " + cId
            sql = sql + "<>" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function GetAllSpecialityMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cSpecialityMaster

        Return sql
    End Function

    Protected Overrides Function GetAllSpecialityMasterIdLike(ByVal likeValue As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cSpecialityMaster
        sql = sql + " where " + cName + " like '" + likeValue.Trim + "%'"

        Return sql
    End Function

    Public Overrides Function InsertIntoSpecialityMaster(ByRef specialityMasterObj As ClsSpecialityMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cSpecialityMaster + "("
        sql = sql + cName
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With specialityMasterObj
            sql = sql + "'" + .Name + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateSpecialityMaster(ByRef specialityMasterObj As ClsSpecialityMaster) As String
        Dim sql As String = ""
        sql = "update " + cSpecialityMaster
        sql = sql + " set "
        With specialityMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "StorageMaster"

    Public Overrides Function StorageMasterUpdatable(ByRef storageMasterObj As ClsStorageMaster) As String
        Dim sql As String = ""
        With storageMasterObj
            sql = "select * from " + cStorageMaster
            sql = sql + " where "
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + " and " + cId
            sql = sql + "<>" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function GetAllStorageMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cStorageMaster

        Return sql
    End Function

    Public Overrides Function InsertIntoStorageMaster(ByRef storageMasterObj As ClsStorageMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cStorageMaster + "("
        sql = sql + cName
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With storageMasterObj
            sql = sql + "'" + .Name + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateStorageMaster(ByRef storageMasterObj As ClsStorageMaster) As String
        Dim sql As String = ""
        sql = "update " + cStorageMaster
        sql = sql + " set "
        With storageMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "Tax Master"

    Public Overrides Function TaxMasterUpdatable(ByRef taxMasterObj As ClsTaxMaster) As String
        Dim sql As String = ""
        With taxMasterObj
            sql = "select * from " + cTaxMaster
            sql = sql + " where "
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + " and " + cId
            sql = sql + "<>" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function GetAllTaxMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cTaxMaster
        sql = sql + " Order by " + cName

        Return sql
    End Function

    Public Overrides Function GetTaxMaster(ByVal id As Integer) As String
        Dim sql As String = ""
        sql = "select * from " + cTaxMaster
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoTaxMaster(ByRef taxMasterObj As ClsTaxMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cTaxMaster + "("
        sql = sql + cName
        sql = sql + "," + cTaxPercent
        sql = sql + "," + cDisplayName
        sql = sql + ") values("
        With taxMasterObj
            sql = sql + "'" + .Name + "'"
            sql = sql + "," + CStr(.TaxPercent)
            sql = sql + ",'" + .DisplayName + "'"
        End With
        sql = sql + ")"
        sql = sql + " select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateTaxMaster(ByRef taxMasterObj As ClsTaxMaster) As String
        Dim sql As String = ""
        sql = "update " + cTaxMaster
        sql = sql + " set "
        With taxMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cTaxPercent
            sql = sql + "=" + CStr(.TaxPercent)
            sql = sql + "," + cDisplayName
            sql = sql + "='" + .DisplayName + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "TempAccount"

    Public Overrides Function GetAllTempAccount() As String
        Dim sql As String = ""
        sql = sql + "Select " + cHeadId + " as " + cId + ", " + cHeadName + " as " + cName + ", " + cDrAmount + ", " + cCrAmount
        sql = sql + " from " + cTempAccount

        Return sql
    End Function

    Public Overrides Function GetAllTempAccountForTrialBalanceInDetail() As String
        Dim sql As String = ""
        sql = sql + "Select " + cHeadId + " as " + cId + ", " + cHeadName + " as " + cName + ", SUM(" + cDrAmount + ") as " + cDrAmount + ", SUM(" + cCrAmount + ") as " + cCrAmount
        sql = sql + " from " + cTempAccount
        sql = sql + " group by " + cHeadId + ", " + cHeadName

        Return sql
    End Function

    Public Overrides Function GetAllTempAccountForTrialBalanceInCondensed() As String
        Dim sql As String = ""
        sql = sql + "Select " + cGroupId + " as " + cId + ", " + cGroupName + " as " + cName + ", SUM(" + cDrAmount + ") as " + cDrAmount + ", SUM(" + cCrAmount + ") as " + cCrAmount
        sql = sql + " from " + cTempAccount
        sql = sql + " group by " + cGroupId + ", " + cGroupName

        Return sql
    End Function

    Public Overrides Function GetAllTempAccountForTrialBalanceInDetail(ByVal forGroupId As Integer) As String
        Dim sql As String = ""
        sql = sql + "Select " + cHeadId + " as " + cId + ", " + cHeadName + " as " + cName + ", SUM(" + cDrAmount + ") as " + cDrAmount + ", SUM(" + cCrAmount + ") as " + cCrAmount
        sql = sql + " from " + cTempAccount
        sql = sql + " where " + cGroupId + " = " + CStr(forGroupId)
        sql = sql + " group by " + cHeadId + ", " + cHeadName

        Return sql
    End Function

    Public Overrides Function GetAllTempAccountForTrialBalanceInCondensed(ByVal forGroupId As Integer) As String
        Dim sql As String = ""
        sql = sql + "Select " + cGroupId + " as " + cId + ", " + cGroupName + " as " + cName + ", SUM(" + cDrAmount + ") as " + cDrAmount + ", SUM(" + cCrAmount + ") as " + cCrAmount
        sql = sql + " from " + cTempAccount
        sql = sql + " where " + cGroupId + " = " + CStr(forGroupId)
        sql = sql + " group by " + cGroupId + ", " + cGroupName

        Return sql
    End Function

    Public Overrides Function FillTempAccountForDate(ByVal dateTo As Date) As String
        Dim sql As String = ""
        sql = sql + ClearTempAccount()
        sql = sql + " Insert into " + cTempAccount + "("
        sql = sql + cGroupName
        sql = sql + "," + cHeadName
        sql = sql + "," + cDrAmount
        sql = sql + "," + cCrAmount
        sql = sql + "," + cHeadId
        sql = sql + "," + cGroupId + ")"
        sql = sql + " Select " + cAccountGroup + "." + cName + " AS " + cGroupName + ", "
        sql = sql + cAccountHead + "." + cName + " AS " + cHeadName + ", "
        sql = sql + cTransactionAccount + "." + cDrAmount + ", "
        sql = sql + cTransactionAccount + "." + cCrAmount + ", "
        sql = sql + cAccountHead + "." + cId + " AS " + cHeadId + ", "
        sql = sql + cAccountGroup + "." + cId + " AS " + cGroupId
        sql = sql + " from " + cAccountGroup + " INNER JOIN "
        sql = sql + cAccountHead + " ON " + cAccountGroup + "." + cId + " = " + cAccountHead + "." + cGroupId + " INNER JOIN "
        sql = sql + cTransactionAccount + " ON " + cAccountHead + "." + cId + " = " + cTransactionAccount + "." + cHeadId
        sql = sql + " where " + cTransactionAccount + "." + cTransactionDate + " <= '" + dateTo.ToString("s") + "'"

        Return sql
    End Function

    Protected Overrides Function ClearTempAccount() As String
        Dim sql As String = ""
        sql = sql + " Delete " + cTempAccount

        Return sql
    End Function

#End Region

#Region "Track Log"

    Public Overrides Function GetAllTrackLogForSales(ByVal dateFrom As Date) As String
        Dim sql As String = ""
        sql = "SELECT Max( DATEDIFF(hh, " + cSalesDetail + "." + cDateOn + ", " + cSalesMaster + "." + cDateOn + ")) As " + cDiff + ", "
        sql = sql + cSalesMaster + "." + cSaleCode + " As " + cBillNo + ", "
        sql = sql + cSalesMaster + "." + cUserId + ", "
        sql = sql + cSalesMaster + "." + cDateOn
        sql = sql + " From "
        sql = sql + cSalesMaster + " INNER JOIN "
        sql = sql + cSalesDetail + " ON " + cSalesMaster + "." + cId + " = " + cSalesDetail + "." + cSaleId
        sql = sql + " Where ((DATEDIFF(hh, " + cSalesDetail + "." + cDateOn + ", " + cSalesMaster + "." + cDateOn + ") > 1) Or (DATEDIFF(hh, " + cSalesDetail + "." + cDateOn + ", " + cSalesMaster + "." + cDateOn + ") < - 1))"
        sql = sql + " and " + cSalesDetail + "." + cDateOn + ">'" + dateFrom.ToString("s") + "'"
        sql = sql + " group by "
        sql = sql + cSalesMaster + "." + cSaleCode + ", "
        sql = sql + cSalesMaster + "." + cUserId + ", "
        sql = sql + cSalesMaster + "." + cDateOn

        Return sql
    End Function

    Public Overrides Function GetAllTrackLogForPurchase(ByVal dateFrom As Date) As String
        Dim sql As String = ""
        sql = "SELECT Max( DATEDIFF(hh, " + cPurchaseDetail + "." + cDateOn + ", " + cPurchaseMaster + "." + cDateOn + ")) As " + cDiff + ", "
        sql = sql + cPurchaseMaster + "." + cPurchaseCode + " As " + cBillNo + ", "
        sql = sql + cPurchaseMaster + "." + cUserId + ", "
        sql = sql + cPurchaseMaster + "." + cDateOn
        sql = sql + " From "
        sql = sql + cPurchaseMaster + " INNER JOIN "
        sql = sql + cPurchaseDetail + " ON " + cPurchaseMaster + "." + cId + " = " + cPurchaseDetail + "." + cPurchaseId
        sql = sql + " Where ((DATEDIFF(hh, " + cPurchaseDetail + "." + cDateOn + ", " + cPurchaseMaster + "." + cDateOn + ") > 1) Or (DATEDIFF(hh, " + cPurchaseDetail + "." + cDateOn + ", " + cPurchaseMaster + "." + cDateOn + ") < - 1))"
        sql = sql + " and " + cPurchaseDetail + "." + cDateOn + ">'" + dateFrom.ToString("s") + "'"
        sql = sql + " group by "
        sql = sql + cPurchaseMaster + "." + cPurchaseCode + ", "
        sql = sql + cPurchaseMaster + "." + cUserId + ", "
        sql = sql + cPurchaseMaster + "." + cDateOn

        Return sql
    End Function

    Public Overrides Function GetAllTrackLogForDestructionSlip(ByVal dateFrom As Date) As String
        Dim sql As String = ""
        sql = "SELECT Max( DATEDIFF(hh, " + cDestructionSlipDetail + "." + cDateOn + ", " + cDestructionSlipMaster + "." + cDateOn + ")) As " + cDiff + ", "
        sql = sql + cDestructionSlipMaster + "." + cDestructionSlipCode + " As " + cBillNo + ", "
        sql = sql + cDestructionSlipMaster + "." + cUserId + ", "
        sql = sql + cDestructionSlipMaster + "." + cDateOn
        sql = sql + " From "
        sql = sql + cDestructionSlipMaster + " INNER JOIN "
        sql = sql + cDestructionSlipDetail + " ON " + cDestructionSlipMaster + "." + cId + " = " + cDestructionSlipDetail + "." + cDestructionSlipId
        sql = sql + " Where ((DATEDIFF(hh, " + cDestructionSlipDetail + "." + cDateOn + ", " + cDestructionSlipMaster + "." + cDateOn + ") > 1) Or (DATEDIFF(hh, " + cDestructionSlipDetail + "." + cDateOn + ", " + cDestructionSlipMaster + "." + cDateOn + ") < - 1))"
        sql = sql + " and " + cDestructionSlipDetail + "." + cDateOn + ">'" + dateFrom.ToString("s") + "'"
        sql = sql + " group by "
        sql = sql + cDestructionSlipMaster + "." + cDestructionSlipCode + ", "
        sql = sql + cDestructionSlipMaster + "." + cUserId + ", "
        sql = sql + cDestructionSlipMaster + "." + cDateOn

        Return sql
    End Function

#End Region

#Region "TransactionAccount"

    Public Overrides Function GetAllTransactionAccount() As String
        Dim sql As String = ""
        sql = "select * from " + cTransactionAccount

        Return sql
    End Function

    'Public Overrides Function GetTransactionAccount(ByVal id As Long) As String
    '    Dim sql As String = ""
    '    sql = "select * from " + cTransactionAccount
    '    sql = sql + " where " + cId + "=" + CStr(id)

    '    Return sql
    'End Function

    Public Overrides Function GetTransactionAccountBalanceForVoucherNo(ByVal voucherNo As String) As String
        Dim sql As String = ""
        sql = "select sum(" + cDrAmount + ")- sum(" + cCrAmount + ") from " + cTransactionAccount
        sql = sql + " where " + cVoucherNo + "='" + voucherNo.Trim + "'"

        Return sql
    End Function

    Public Overrides Function GetTransactionAccountBalanceForVoucherNo(ByVal voucherNo As String, ByVal headId As Integer) As String
        Dim sql As String = ""
        sql = GetTransactionAccountBalanceForVoucherNo(voucherNo)
        sql = sql + " and " + cHeadId + "=" + CStr(headId)

        Return sql
    End Function

    Public Overrides Function InsertIntoTransactionAccount(ByRef transactionAccountObj As ClsTransactionAccount) As String
        Dim sql As String = ""
        sql = "insert into " + cTransactionAccount + "("
        sql = sql + cVoucherNo
        sql = sql + "," + cTransactionDate
        sql = sql + "," + cHeadId
        sql = sql + "," + cDrAmount
        sql = sql + "," + cCrAmount
        sql = sql + "," + cNarration
        sql = sql + "," + cSource
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With transactionAccountObj
            sql = sql + "'" + .VoucherNo + "'"
            sql = sql + ",'" + .TransactionDate.ToString("s") + "'"
            sql = sql + "," + CStr(.HeadId)
            sql = sql + "," + CStr(.DrAmount)
            sql = sql + "," + CStr(.CrAmount)
            sql = sql + ",'" + .Narration + "'"
            sql = sql + ",'" + .Source + "'"
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        'sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateTransactionAccount(ByRef transactionAccountObj As ClsTransactionAccount) As String
        Dim sql As String = ""
        sql = "update " + cTransactionAccount
        sql = sql + " set "
        With transactionAccountObj
            sql = sql + cVoucherNo
            sql = sql + "='" + .VoucherNo + "'"
            sql = sql + "," + cTransactionDate
            sql = sql + "='" + .TransactionDate.ToString("s") + "'"
            sql = sql + "," + cHeadId
            sql = sql + "=" + CStr(.HeadId)
            sql = sql + "," + cDrAmount
            sql = sql + "=" + CStr(.DrAmount)
            sql = sql + "," + cCrAmount
            sql = sql + "=" + CStr(.CrAmount)
            sql = sql + "," + cNarration
            sql = sql + "='" + .Narration + "'"
            sql = sql + "," + cSource
            sql = sql + "='" + .Source + "'"
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            'sql = sql + " where " + cId
            'sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "TransactionStock"

    Public Overrides Function GetAllTransactionStock() As String
        Dim sql As String = ""
        sql = "select * from " + cTransactionStock

        Return sql
    End Function

    'Public Overrides Function GetTransactionStock(ByVal id As Long) As String
    '    Dim sql As String = ""
    '    sql = "select * from " + cTransactionStock
    '    sql = sql + " where " + cId + "=" + CStr(id)

    '    Return sql
    'End Function

    Public Overrides Function InsertIntoTransactionStock(ByRef transactionStockObj As ClsTransactionStock) As String
        Dim sql As String = ""
        sql = "insert into " + cTransactionStock + "("
        sql = sql + cItemId
        sql = sql + "," + cTransactionNo
        sql = sql + "," + cBatch
        sql = sql + "," + cExpiryDate
        sql = sql + "," + cPackQuantity
        sql = sql + "," + cQuantityIn
        sql = sql + "," + cQuantityOut
        sql = sql + "," + cPricePurchase
        sql = sql + "," + cPriceSale
        sql = sql + "," + cTaxPercent
        sql = sql + "," + cDiscountPercent
        sql = sql + "," + cTaxAmount
        sql = sql + "," + cDiscountAmount
        sql = sql + "," + cSource
        sql = sql + "," + cRemark
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With transactionStockObj
            sql = sql + CStr(.ItemId)
            sql = sql + ",'" + .TransactionNo + "'"
            sql = sql + ",'" + .Batch + "'"
            sql = sql + ",'" + .ExpiryDate.ToString("s") + "'"
            sql = sql + "," + CStr(.PackQuantity)
            sql = sql + "," + CStr(.QuantityIn)
            sql = sql + "," + CStr(.QuantityOut)
            sql = sql + "," + CStr(.PricePurchase)
            sql = sql + "," + CStr(.PriceSale)
            sql = sql + "," + CStr(.TaxPercent)
            sql = sql + "," + CStr(.DiscountPercent)
            sql = sql + "," + CStr(.TaxAmount)
            sql = sql + "," + CStr(.DiscountAmount)
            sql = sql + ",'" + .Source + "'"
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        'sql = sql + " select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateTransactionStock(ByRef transactionStockObj As ClsTransactionStock) As String
        Dim sql As String = ""
        sql = "update " + cTransactionStock
        sql = sql + " set "
        With transactionStockObj
            sql = sql + cItemId
            sql = sql + "=" + CStr(.ItemId)
            sql = sql + "," + cTransactionNo
            sql = sql + "='" + .TransactionNo + "'"
            sql = sql + "," + cBatch
            sql = sql + "='" + .Batch + "'"
            sql = sql + "," + cExpiryDate
            sql = sql + "='" + .ExpiryDate.ToString("s") + "'"
            sql = sql + "," + cPackQuantity
            sql = sql + "=" + CStr(.PackQuantity)
            sql = sql + "," + cQuantityIn
            sql = sql + "=" + CStr(.QuantityIn)
            sql = sql + "," + cQuantityOut
            sql = sql + "=" + CStr(.QuantityOut)
            sql = sql + "," + cPricePurchase
            sql = sql + "=" + CStr(.PricePurchase)
            sql = sql + "," + cPriceSale
            sql = sql + "=" + CStr(.PriceSale)
            sql = sql + "," + cTaxPercent
            sql = sql + "=" + CStr(.TaxPercent)
            sql = sql + "," + cDiscountPercent
            sql = sql + "=" + CStr(.DiscountPercent)
            sql = sql + "," + cTaxAmount
            sql = sql + "=" + CStr(.TaxAmount)
            sql = sql + "," + cDiscountAmount
            sql = sql + "=" + CStr(.DiscountAmount)
            sql = sql + "," + cSource
            sql = sql + "='" + .Source + "'"
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            'sql = sql + " where " + cId
            'sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "Transporter"

    Public Overrides Function GetAllTransporter() As String
        Dim sql As String = ""
        sql = "select * from " + cTransporter
        sql = sql + " Order by " + cName

        Return sql
    End Function

    Public Overrides Function GetAllTransporterLike(ByVal fieldName As String, ByVal likeValue As String) As String
        Dim sql As String = ""
        sql = "select * from " + cTransporter
        sql = sql + " where " + fieldName + " like '" + likeValue.Trim + "%'"
        sql = sql + " Order by " + cName

        Return sql
    End Function

    Protected Overrides Function GetAllTransporterIdForNameLike(ByVal name As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cTransporter
        sql = sql + " where " + cName + " like '" + name.Trim + "%'"

        Return sql
    End Function

    Public Overrides Function InsertIntoTransporter(ByRef transporterObj As ClsTransporter) As String
        Dim sql As String = ""
        sql = "insert into " + cTransporter + "("
        sql = sql + cName
        sql = sql + "," + cAddress
        sql = sql + "," + cPhoneR
        sql = sql + "," + cPhoneO
        sql = sql + "," + cMobile
        sql = sql + "," + cEmail
        sql = sql + "," + cCity
        sql = sql + "," + cPin
        sql = sql + "," + cRepresentative
        sql = sql + "," + cPhoneRepresentative
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With transporterObj
            sql = sql + "'" + .Name + "'"
            sql = sql + ",'" + .Address + "'"
            sql = sql + ",'" + .PhoneR + "'"
            sql = sql + ",'" + .PhoneO + "'"
            sql = sql + ",'" + .Mobile + "'"
            sql = sql + ",'" + .EMail + "'"
            sql = sql + ",'" + .City + "'"
            sql = sql + ",'" + .Pin + "'"
            sql = sql + ",'" + .Representative + "'"
            sql = sql + ",'" + .PhoneRepresentative + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateTransporter(ByRef transporterObj As ClsTransporter) As String
        Dim sql As String = ""
        sql = "update " + cTransporter
        sql = sql + " set "
        With transporterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cAddress
            sql = sql + "='" + .Address + "'"
            sql = sql + "," + cPhoneR
            sql = sql + "='" + .PhoneR + "'"
            sql = sql + "," + cPhoneO
            sql = sql + "='" + .PhoneO + "'"
            sql = sql + "," + cMobile
            sql = sql + "='" + .Mobile + "'"
            sql = sql + "," + cEmail
            sql = sql + "='" + .EMail + "'"
            sql = sql + "," + cCity
            sql = sql + "='" + .City + "'"
            sql = sql + "," + cPin
            sql = sql + "='" + .Pin + "'"
            sql = sql + "," + cRepresentative
            sql = sql + "='" + .Representative + "'"
            sql = sql + "," + cPhoneRepresentative
            sql = sql + "='" + .PhoneRepresentative + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "UserMaster"

    Public Overrides Function GetAllUserMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cUserMaster
        sql = sql + " Order by " + cName

        Return sql
    End Function

    'Public Overrides Function GetUserMaster(ByVal loginName As String, ByVal pass As String) As String
    '    Dim sql As String = ""
    '    sql = "select * from " + cUserMaster
    '    sql = sql + " where " + cLoginName + " = '" + loginName + "'"
    '    sql = sql + " and " + cPassword + CaseSensitive() + " = '" + pass + "'"

    '    Return sql
    'End Function

    Public Overrides Function GetUserMaster(ByVal loginName As String, ByVal pass As String) As String
        Dim sql As String = ""
        sql = "if EXISTS(select * From " + cLoginList + " Where " + cLoginId + " = '" + loginName + "') "
        sql = sql + vbCrLf + " begin " + vbCrLf
        sql = sql + "if (select DATEDIFF(SECOND, (select top 1 " + cDateOn + " From " + cLoginList + " Where " + cLoginId + " = '" + loginName + "'), GETDATE()))> 45 "
        sql = sql + vbCrLf + " begin " + vbCrLf
        sql = sql + "Delete " + cLoginList + " Where " + cLoginId + " = '" + loginName + "' "
        sql = sql + vbCrLf + "Select * From " + cUserMaster + " Where " + cLoginName + " = '" + loginName + "' And " + cPassword + CaseSensitive() + " = '" + pass + "'"
        sql = sql + vbCrLf + " end "
        sql = sql + vbCrLf + " else "
        sql = sql + vbCrLf + "Select * From " + cUserMaster + " Where " + cLoginName + " = '------' And " + cPassword + CaseSensitive() + " = '---------'"
        sql = sql + vbCrLf + " end "
        sql = sql + vbCrLf + " else "
        sql = sql + vbCrLf + "Select * From " + cUserMaster + " Where " + cLoginName + " = '" + loginName + "' And " + cPassword + CaseSensitive() + " = '" + pass + "'"

        Return sql
    End Function

    Public Overrides Function ValidateUserMaster(ByVal id As Integer, ByVal pass As String) As String
        Dim sql As String = ""
        sql = "select * from " + cUserMaster
        sql = sql + " where " + cId + " = " + CStr(id)
        sql = sql + " and " + cPassword + CaseSensitive() + " = '" + pass + "'"

        Return sql
    End Function

    Public Overrides Function InsertIntoUserMaster(ByRef userMasterObj As ClsUserMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cUserMaster + "("
        sql = sql + cName
        sql = sql + "," + cPassword
        sql = sql + "," + cProfileId
        sql = sql + "," + cLoginName
        sql = sql + "," + cAuthorizationNo
        sql = sql + ") values("
        With userMasterObj
            sql = sql + "'" + .Name + "'"
            sql = sql + ",'" + .Password + "'"
            sql = sql + "," + CStr(.ProfileId)
            sql = sql + ",'" + .LoginName + "'"
            sql = sql + ",'" + .AuthorizationNo + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateUserMaster(ByRef userMasterObj As ClsUserMaster, ByVal ignorePassword As Boolean) As String
        Dim sql As String = ""
        sql = "update " + cUserMaster
        sql = sql + " set "
        With userMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            If ignorePassword = False Then
                sql = sql + "," + cPassword
                sql = sql + "='" + .Password + "'"
            End If
            sql = sql + "," + cProfileId
            sql = sql + "=" + CStr(.ProfileId)
            sql = sql + "," + cLoginName
            sql = sql + "='" + .LoginName + "'"
            sql = sql + "," + cAuthorizationNo
            sql = sql + "='" + .AuthorizationNo + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function UpdateUserMasterPassword(ByVal id As Integer, ByVal pass As String) As String
        Dim sql As String = ""
        sql = "update " + cUserMaster
        sql = sql + " set "
        sql = sql + cPassword
        sql = sql + "='" + pass + "'"
        sql = sql + " where " + cId
        sql = sql + "=" + CStr(id)

        Return sql
    End Function

#End Region

#Region "VendorDetail"

    Public Overrides Function GetAllVendorDetail() As String
        Dim sql As String = ""
        sql = "select * from " + cVendorDetail
        sql = sql + " Order by " + cAccountId

        Return sql
    End Function

    Public Overrides Function GetAllVendorDetailForAccountId(ByVal accountId As String) As String
        Dim sql As String = ""
        sql = "select * from " + cVendorDetail
        sql = sql + " where " + cAccountId + "= '" + accountId + "'"
        sql = sql + " Order by " + cAccountId

        Return sql
    End Function

    Public Overrides Function InsertIntoVendorDetail(ByRef vendorDetailObj As ClsVendorDetail) As String
        Dim sql As String = ""
        sql = "insert into " + cVendorDetail + "("
        sql = sql + cManufacturerId
        sql = sql + "," + cAccountId
        sql = sql + ") values("
        With vendorDetailObj
            sql = sql + CStr(.ManufacturerId)
            sql = sql + ",'" + .AccountId + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateVendorDetail(ByRef vendorDetailObj As ClsVendorDetail) As String
        Dim sql As String = ""
        sql = "update " + cVendorDetail
        sql = sql + " set "
        With vendorDetailObj
            sql = sql + cManufacturerId
            sql = sql + "=" + CStr(.ManufacturerId)
            sql = sql + "," + cAccountId
            sql = sql + "='" + .AccountId + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function DeleteVendorDetail(ByVal id As Integer) As String
        Dim sql As String = ""
        sql = "delete " + cVendorDetail
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

#End Region

#Region "VendorMaster"

    Public Overrides Function VendorMasterUpdatable(ByRef vendorMasterObj As ClsVendorMaster) As String
        Dim sql As String = ""
        With vendorMasterObj
            sql = "select * from " + cVendorMaster
            sql = sql + " where "
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + " and " + cId
            sql = sql + "<>" + CStr(.Id)
        End With

        Return sql
    End Function

    Public Overrides Function GetAllVendorMaster() As String
        Dim sql As String = ""
        sql = "select * from " + cVendorMaster
        sql = sql + " Order by " + cAccountId

        Return sql
    End Function

    Public Overrides Function GetAllVendorMasterLike(ByVal fieldName As String, ByVal likeValue As String) As String
        Dim sql As String = ""
        sql = "select * from " + cVendorMaster
        sql = sql + " where " + fieldName + " like '" + likeValue.Trim + "%'"
        sql = sql + " Order by " + cAccountId

        Return sql
    End Function

    Protected Overrides Function GetAllVendorMasterIdNameLike(ByVal likeValue As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cVendorMaster
        sql = sql + " where " + cName + " like '" + likeValue.Trim + "%'"

        Return sql
    End Function

    Protected Overrides Function GetAllVendorMasterCodeNameLike(ByVal likeValue As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cAccountId + ") from " + cVendorMaster
        sql = sql + " where " + cName + " like '" + likeValue.Trim + "%'"

        Return sql
    End Function

    Protected Overrides Function GetVendorMasterIdForCode(ByVal code As String) As String
        Dim sql As String = ""
        sql = "select distinct(" + cId + ") from " + cVendorMaster
        sql = sql + " where " + cAccountId + "='" + code.Trim + "'"

        Return sql
    End Function

    Public Overrides Function GetVendorMasterAccountId(ByVal id As Integer) As String
        Dim sql As String = ""
        sql = "select " + cAccountId + " from " + cVendorMaster
        sql = sql + " where " + cId + "=" + CStr(id)

        Return sql
    End Function

    Public Overrides Function InsertIntoVendorMaster(ByRef vendorMasterObj As ClsVendorMaster) As String
        Dim sql As String = ""
        sql = "insert into " + cVendorMaster + "("
        sql = sql + cName
        sql = sql + "," + cAccountId
        sql = sql + "," + cAddress
        sql = sql + "," + cPhoneR
        sql = sql + "," + cPhoneO
        sql = sql + "," + cMobile
        sql = sql + "," + cEmail
        sql = sql + "," + cCity
        sql = sql + "," + cPin
        sql = sql + "," + cUpTtNo
        sql = sql + "," + cTinNo
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With vendorMasterObj
            sql = sql + "'" + .Name + "'"
            sql = sql + ",'" + .AccountId + "'"
            sql = sql + ",'" + .Address + "'"
            sql = sql + ",'" + .PhoneR + "'"
            sql = sql + ",'" + .PhoneO + "'"
            sql = sql + ",'" + .Mobile + "'"
            sql = sql + ",'" + .EMail + "'"
            sql = sql + ",'" + .City + "'"
            sql = sql + ",'" + .Pin + "'"
            sql = sql + ",'" + .UpTtNo + "'"
            sql = sql + ",'" + .TinNo + "'"
            sql = sql + ",'" + .UserId + "'"
            sql = sql + ",'" + .DateOn.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + "select SCOPE_IDENTITY() as " + cId

        Return sql
    End Function

    Public Overrides Function UpdateVendorMaster(ByRef vendorMasterObj As ClsVendorMaster) As String
        Dim sql As String = ""
        sql = "update " + cVendorMaster
        sql = sql + " set "
        With vendorMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cAccountId
            sql = sql + "='" + .AccountId + "'"
            sql = sql + "," + cAddress
            sql = sql + "='" + .Address + "'"
            sql = sql + "," + cPhoneR
            sql = sql + "='" + .PhoneR + "'"
            sql = sql + "," + cPhoneO
            sql = sql + "='" + .PhoneO + "'"
            sql = sql + "," + cMobile
            sql = sql + "='" + .Mobile + "'"
            sql = sql + "," + cEmail
            sql = sql + "='" + .EMail + "'"
            sql = sql + "," + cCity
            sql = sql + "='" + .City + "'"
            sql = sql + "," + cPin
            sql = sql + "='" + .Pin + "'"
            sql = sql + "," + cUpTtNo
            sql = sql + "='" + .UpTtNo + "'"
            sql = sql + "," + cTinNo
            sql = sql + "='" + .TinNo + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + .UserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + .DateOn.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "DailyTransaction"
    Public Overrides Function GetDailyTransactionSheet() As String
        '        Sql As String = "
        'select * from (
        'select CM.Name as Category, IM.id, IM.ItemCode, IM.Name, IM.PackType, 0 as OpeningQty,
        ' isnull(sum(PD.PurchaseQuantity) over(partition by IM.Id),0) as PurchaseQty, 
        ' 0 as TransferQty, 0 as SaleQty, isnull(AVG(PD.MRP) over(partition by IM.Id),0) as Rate, PD.DateOn, ROW_NUMBER() OVER(partition BY IM.id order by pd.dateon DESC) AS RowNumber  
        'from ItemMaster IM inner join CategoryMaster CM on CM.id = IM.CategoryId
        'left outer join PurchaseDetail PD on PD.ItemId = IM.id 
        'and PD.DateOn > (DATEFROMPARTS(year(getdate()), month(getdate()), day(getdate())))
        'Group by CM.Name, IM.DimID, IM.ItemCode, IM.Name, IM.PackType, PD.PurchaseQuantity, PD.MRP, PD.DateOn  
        ')t where RowNumber=1 Order by Name asc, DateOn Desc
        '"
        Dim sql As String = "
SELECT CM.Name as Category, 
		ItemMaster.Id, 
		ISNULL(ItemMaster.ItemCode,'') AS ItemCode, 
       ISNULL(ItemMaster.Name,'') AS Name, 
	   ISNULL(ItemMaster.PackType,'') AS PackType, 
       ISNULL((SUM(CustomOp.InQty) - SUM(CustomOp.OutQty)),0) AS OpeningQty,
       ISNULL((SUM(CustomOp.PriceOut) - SUM(CustomOp.PriceIn)),0) AS PriceOpening,
       ISNULL(SUM(Custom.InQty),0) AS PurchaseQty,
       ISNULL(SUM(Custom.OutQty),0) AS SaleQty,
       ISNULL(SUM(Custom.PriceOut),0) AS PriceOut,
       ISNULL(SUM(Custom.PriceIn),0) AS PriceIn,
	   ISNULL(RATETABLE.MRP,0) AS MRP,
	   ISNULL(RATETABLE.PTR,0) AS PTR,
	   ISNULL(RATETABLE.PTS,0) AS PTS,
	   ISNULL(RATETABLE.Rate1,0) AS Rate1,
	   ISNULL(RATETABLE.Rate2,0) AS Rate2,
	   ISNULL(RATETABLE.Rate3,0) AS Rate3
FROM ItemMaster
inner join CategoryMaster CM on CM.id = ItemMaster.CategoryId
LEFT OUTER join (
select itemid, MRP, PTS, PTR, Rate1, RATE2, Rate3 from (
select itemid, MRP, PTS, PTR, Rate1, RATE2, Rate3, row_number() over(partition by itemid order by dateon desc) as rownumber from PurchaseDetail)t where rownumber = 1
) RATETABLE on RATETABLE.ItemId = ItemMaster.Id
LEFT OUTER JOIN (
                   (SELECT SalesDetail.ItemId AS ItemId,
                           SalesDetail.PackQuantity AS PackQuantity,
                           0 AS InQty,
                           SUM(SalesDetail.SaleQuantity + SalesDetail.FreeQuantity) AS OutQty,
                           0 AS PriceOut,
                           SUM((SalesDetail.SaleQuantity + SalesDetail.FreeQuantity) * SalesDetail.PriceSale) AS PriceIn
                    FROM SalesMaster
                    INNER JOIN SalesDetail ON SalesMaster.Id = SalesDetail.SaleId
                    WHERE SalesMaster.SaleDate BETWEEN convert(datetime, convert(date,GETDATE())) AND convert(datetime, convert(date,GETDATE()+1))
                    GROUP BY SalesDetail.PackQuantity,
                             SalesDetail.ItemId)
                 UNION
                   (SELECT PurchaseReturnDetail.ItemId AS ItemId,
                           PurchaseReturnDetail.PackQuantity AS PackQuantity,
                           0 AS InQty,
                           SUM(PurchaseReturnDetail.ReturnQuantity + PurchaseReturnDetail.FreeQuantity) AS OutQty,
                           0 AS PriceOut,
                           SUM((PurchaseReturnDetail.ReturnQuantity + PurchaseReturnDetail.FreeQuantity) * PurchaseReturnDetail.PricePurchase) AS PriceIn
                    FROM PurchaseReturnDetail
                    INNER JOIN PurchaseReturnMaster ON PurchaseReturnDetail.PurchaseReturnId = PurchaseReturnMaster.Id
                    WHERE PurchaseReturnMaster.ReturnDate BETWEEN convert(datetime, convert(date,GETDATE())) AND convert(datetime, convert(date,GETDATE()+1))
                    GROUP BY PurchaseReturnDetail.PackQuantity,
                             PurchaseReturnDetail.ItemId)
                 UNION
                   (SELECT PurchaseDetail.ItemId AS ItemId,
                           PurchaseDetail.PackQuantity AS PackQuantity,
                           SUM(PurchaseDetail.FreeQuantity + PurchaseDetail.PurchaseQuantity) AS InQty,
                           0 AS OutQty,
                           SUM((PurchaseDetail.PurchaseQuantity * PurchaseDetail.PricePurchase)) AS PriceOut,
                           0 AS PriceIn
                    FROM PurchaseDetail
                    INNER JOIN PurchaseMaster ON PurchaseDetail.PurchaseId = PurchaseMaster.Id
                    WHERE PurchaseMaster.PurchaseDate BETWEEN convert(datetime, convert(date,GETDATE())) AND convert(datetime, convert(date,GETDATE()+1))
                    GROUP BY PurchaseDetail.PackQuantity,
                             PurchaseDetail.ItemId)
                 UNION
                   (SELECT SampleDetail.ItemId AS ItemId,
                           SampleDetail.PackQuantity AS PackQuantity,
                           0 AS InQty,
                           SUM(SampleDetail.FreeQuantity + SampleDetail.SampleQuantity) AS OutQty,
                           0 AS PriceOut,
                           SUM((SampleDetail.FreeQuantity + SampleDetail.SampleQuantity * SampleDetail.PriceSample)) AS PriceIn
                    FROM SampleDetail
                    INNER JOIN SampleMaster ON SampleDetail.SampleId = SampleMaster.Id
                    WHERE SampleMaster.SampleDate BETWEEN convert(datetime, convert(date,GETDATE())) AND convert(datetime, convert(date,GETDATE()+1))
                    GROUP BY SampleDetail.PackQuantity,
                             SampleDetail.ItemId)
                 UNION
                   (SELECT SalesReturnDetail.ItemId AS ItemId,
                           SalesReturnDetail.PackQuantity AS PackQuantity,
                           SUM(SalesReturnDetail.ReturnQuantity) AS InQty,
                           0 AS OutQty,
                           SUM(SalesReturnDetail.ReturnQuantity * SalesReturnDetail.PriceSale) AS PriceOut,
                           0 AS PriceIn
                    FROM SalesReturnDetail
                    INNER JOIN SalesReturnMaster ON SalesReturnDetail.SalesReturnId = SalesReturnMaster.Id
                    WHERE SalesReturnMaster.ReturnDate BETWEEN convert(datetime, convert(date,GETDATE())) AND convert(datetime, convert(date,GETDATE()+1))
                    GROUP BY SalesReturnDetail.PackQuantity,
                             SalesReturnDetail.ItemId)) Custom ON ItemMaster.Id = Custom.ItemId
LEFT OUTER JOIN (
                   (SELECT SalesDetail.ItemId AS ItemId,
                           SalesDetail.PackQuantity AS PackQuantity,
                           0 AS InQty,
                           SUM(SalesDetail.SaleQuantity + SalesDetail.FreeQuantity) AS OutQty,
                           0 AS PriceOut,
                           SUM((SalesDetail.SaleQuantity + SalesDetail.FreeQuantity) * SalesDetail.PriceSale) AS PriceIn
                    FROM SalesMaster
                    INNER JOIN SalesDetail ON SalesMaster.Id = SalesDetail.SaleId
                    WHERE SalesMaster.SaleDate < convert(datetime, convert(date,GETDATE()))
                    GROUP BY SalesDetail.PackQuantity,
                             SalesDetail.ItemId)
                 UNION
                   (SELECT PurchaseReturnDetail.ItemId AS ItemId,
                           PurchaseReturnDetail.PackQuantity AS PackQuantity,
                           0 AS InQty,
                           SUM(PurchaseReturnDetail.ReturnQuantity + PurchaseReturnDetail.FreeQuantity) AS OutQty,
                           0 AS PriceOut,
                           SUM((PurchaseReturnDetail.ReturnQuantity + PurchaseReturnDetail.FreeQuantity) * PurchaseReturnDetail.PricePurchase) AS PriceIn
                    FROM PurchaseReturnDetail
                    INNER JOIN PurchaseReturnMaster ON PurchaseReturnDetail.PurchaseReturnId = PurchaseReturnMaster.Id
                    WHERE PurchaseReturnMaster.ReturnDate < convert(datetime, convert(date,GETDATE()))
                    GROUP BY PurchaseReturnDetail.PackQuantity,
                             PurchaseReturnDetail.ItemId)
                 UNION
                   (SELECT PurchaseDetail.ItemId AS ItemId,
                           PurchaseDetail.PackQuantity AS PackQuantity,
                           SUM(PurchaseDetail.FreeQuantity + PurchaseDetail.PurchaseQuantity) AS InQty,
                           0 AS OutQty,
                           SUM((PurchaseDetail.FreeQuantity + PurchaseDetail.PurchaseQuantity * PurchaseDetail.PricePurchase)) AS PriceOut,
                           0 AS PriceIn
                    FROM PurchaseDetail
                    INNER JOIN PurchaseMaster ON PurchaseDetail.PurchaseId = PurchaseMaster.Id
                    WHERE PurchaseMaster.PurchaseDate < convert(datetime, convert(date,GETDATE()))
                    GROUP BY PurchaseDetail.PackQuantity,
                             PurchaseDetail.ItemId)
                 UNION
                   (SELECT SampleDetail.ItemId AS ItemId,
                           SampleDetail.PackQuantity AS PackQuantity,
                           0 AS InQty,
                           SUM(SampleDetail.FreeQuantity + SampleDetail.SampleQuantity) AS OutQty,
                           0 AS PriceOut,
                           SUM((SampleDetail.FreeQuantity + SampleDetail.SampleQuantity * SampleDetail.PriceSample)) AS PriceIn
                    FROM SampleDetail
                    INNER JOIN SampleMaster ON SampleDetail.SampleId = SampleMaster.Id
                    WHERE SampleMaster.SampleDate < convert(datetime, convert(date,GETDATE()))
                    GROUP BY SampleDetail.PackQuantity,
                             SampleDetail.ItemId)
                 UNION
                   (SELECT SalesReturnDetail.ItemId AS ItemId,
                           SalesReturnDetail.PackQuantity AS PackQuantity,
                           SUM(SalesReturnDetail.ReturnQuantity) AS InQty,
                           0 AS OutQty,
                           SUM(SalesReturnDetail.ReturnQuantity * SalesReturnDetail.PricePurchase) AS PriceOut,
                           0 AS PriceIn
                    FROM SalesReturnDetail
                    INNER JOIN SalesReturnMaster ON SalesReturnDetail.SalesReturnId = SalesReturnMaster.Id
                    WHERE SalesReturnMaster.ReturnDate < convert(datetime, convert(date,GETDATE()))
                    GROUP BY SalesReturnDetail.PackQuantity,
                             SalesReturnDetail.ItemId)) CustomOp ON ItemMaster.Id = CustomOp.ItemId
GROUP BY CM.Name, ItemMaster.Id, ItemMaster.ItemCode, ItemMaster.Name, ItemMaster.PackType, RATETABLE.MRP,
	   RATETABLE.PTR,
	   RATETABLE.PTS,
	   RATETABLE.Rate1,
	   RATETABLE.Rate2,
	   RATETABLE.Rate3
"
        Return sql
    End Function
#End Region

End Class