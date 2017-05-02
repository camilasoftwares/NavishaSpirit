'This function is used to get readymade scripts by passing values.
'It helps in maintaining scripts with change in database

Public Class ClsTransferScripts

#Region "Local variables and Constants"
    Shared sInstance As ClsTransferScripts

    Private lcUserId As String = "Fixed"
    Private lcVendorId As String = "1"
#End Region

#Region "Public Functions"

    ''' <summary>
    ''' This function is used to get Instance of this class
    ''' </summary>
    ''' <returns>Instance of this class</returns>
    ''' <remarks></remarks>
    Public Shared Function GetInstance() As ClsTransferScripts
        If sInstance Is Nothing Then
            sInstance = New ClsTransferScripts
        End If

        Return sInstance
    End Function

#End Region

#Region "Tables Names"
    Private Const cCategoryMaster As String = "CategoryMaster"
    Private Const cManufacturerMaster As String = "ManufacturerMaster"
    Private Const cItemMaster As String = "ItemMaster"
    Private Const cTaxMaster As String = "TaxMaster"
    Private Const cSalesMaster As String = "SalesMaster"
    Private Const cSalesDetail As String = "SalesDetail"
    Private Const cPurchaseMaster As String = "PurchaseMaster"
    Private Const cPurchaseDetail As String = "PurchaseDetail"

#End Region

#Region "Common Function"

    Public Function GetFullQuery(ByVal obj As Object) As String
        Dim sql As String = GetQuery(obj)
        If sql.Trim <> "" Then sql = CreateQueryToExecute(sql)

        Return sql
    End Function

    Private Function CreateQueryToExecute(ByVal qry As String) As String
        Dim sql As String = ""

        sql = " DECLARE @retry INT, " + vbCrLf
        sql = sql + " @errMsg VARCHAR(500); " + vbCrLf + vbCrLf
        sql = sql + " SET @errMsg = ''; " + vbCrLf
        sql = sql + " SET @retry = 5; " + vbCrLf + vbCrLf
        sql = sql + " WHILE (@retry > 0) " + vbCrLf
        sql = sql + " BEGIN " + vbCrLf
        sql = sql + "     BEGIN TRY " + vbCrLf
        sql = sql + "         BEGIN TRANSACTION; " + vbCrLf + vbCrLf

        sql = sql + qry + vbCrLf + vbCrLf

        sql = sql + "         SET @retry = 0; " + vbCrLf + vbCrLf
        sql = sql + "         COMMIT TRANSACTION; " + vbCrLf
        sql = sql + "     END TRY " + vbCrLf
        sql = sql + "     BEGIN CATCH  " + vbCrLf
        sql = sql + "         IF (ERROR_NUMBER() = 1205) " + vbCrLf
        sql = sql + "             SET @retry = @retry - 1; " + vbCrLf
        sql = sql + "         ELSE " + vbCrLf
        sql = sql + "             SET @retry = -1; " + vbCrLf + vbCrLf

        'sql = sql + "         EXECUTE usp_MyErrorLog; " + vbCrLf + vbCrLf
        sql = sql + "SET @errMsg = 'Error '  + CONVERT(VARCHAR(50), ERROR_NUMBER()) "
        sql = sql + "+ ', Severity '  + CONVERT(VARCHAR(5), ERROR_SEVERITY()) "
        sql = sql + "+ ', State '  + CONVERT(VARCHAR(5), ERROR_STATE()) "
        sql = sql + "+ ', Line ' + CONVERT(VARCHAR(5), ERROR_LINE());  " + vbCrLf

        sql = sql + "SET @errMsg =@errMsg + char(13) + ERROR_MESSAGE(); " + vbCrLf

        sql = sql + "         IF XACT_STATE() <> 0 " + vbCrLf
        sql = sql + "             ROLLBACK TRANSACTION; " + vbCrLf
        sql = sql + "     END CATCH; " + vbCrLf
        sql = sql + " END;  " + vbCrLf
        sql = sql + " select @errMsg;  " + vbCrLf

        Return sql
    End Function

    Private Function GetQuery(ByVal obj As Object) As String
        Dim sql As String = ""

        Select Case obj.GetType.Name
            Case GetType(ClsCategoryMaster).Name
                Dim temp As ClsCategoryMaster = obj
                sql = GetQuery(temp)

            Case GetType(ClsManufacturerMaster).Name
                Dim temp As ClsManufacturerMaster = obj
                sql = GetQuery(temp)

            Case GetType(ClsItemMaster).Name
                Dim temp As ClsItemMaster = obj
                sql = GetQuery(temp)

            Case GetType(ClsTaxMaster).Name
                Dim temp As ClsTaxMaster = obj
                sql = GetQuery(temp)


            Case Else
                sql = ""
        End Select

        Return sql
    End Function

    Private Function GetQuery(ByVal obj As Object, ByVal objList As List(Of Object)) As String
        Dim sql As String = ""

        Select Case obj.GetType.Name

            Case Else
                sql = ""
        End Select

        Return sql
    End Function

#End Region

#Region "Category"

    Private Function GetQuery(ByVal category As ClsCategoryMaster) As String
        Dim sql As String = ""

        If category IsNot Nothing Then
            sql = "IF NOT EXISTS (SELECT *  From " + cCategoryMaster + " Where " + cId + " = " + CStr(category.Id) + ") "
            sql = sql + vbCrLf + InsertIntoCategoryMaster(category)
            sql = sql + vbCrLf + " ELSE "
            sql = sql + vbCrLf + UpdateCategoryMaster(category)
        End If

        Return sql
    End Function

    Private Function InsertIntoCategoryMaster(ByRef categoryMasterObj As ClsCategoryMaster) As String
        Dim sql As String = ""
        sql = " BEGIN " + vbCrLf
        sql = sql + "SET IDENTITY_INSERT " + cCategoryMaster + " ON" + vbCrLf
        sql = sql + " insert into " + cCategoryMaster + "("
        sql = sql + cId
        sql = sql + "," + cName
        sql = sql + "," + cPIId
        sql = sql + "," + cUserId
        sql = sql + "," + cDateOn
        sql = sql + ") values("
        With categoryMasterObj
            sql = sql + CStr(.Id)
            sql = sql + ",'" + .Name + "'"
            sql = sql + "," + CStr(.PIId)
            sql = sql + ",'" + lcUserId + "'"
            sql = sql + ",'" + Now.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + vbCrLf + "SET IDENTITY_INSERT " + cCategoryMaster + " OFF"
        sql = sql + vbCrLf + " END "

        Return sql
    End Function

    Private Function UpdateCategoryMaster(ByRef categoryMasterObj As ClsCategoryMaster) As String
        Dim sql As String = ""
        sql = "update " + cCategoryMaster
        sql = sql + " set "
        With categoryMasterObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            sql = sql + "," + cPIId
            sql = sql + "=" + CStr(.PIId)
            sql = sql + "," + cUserId
            sql = sql + "='" + lcUserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + Now.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "Manufacturer"

    Private Function GetQuery(ByVal manufacturer As ClsManufacturerMaster) As String
        Dim sql As String = ""

        If manufacturer IsNot Nothing Then
            sql = "IF NOT EXISTS (SELECT *  From " + cManufacturerMaster + " Where " + cId + " = " + CStr(manufacturer.Id) + ") "
            sql = sql + vbCrLf + InsertIntoManufacturerMaster(manufacturer)
            sql = sql + vbCrLf + " ELSE "
            sql = sql + vbCrLf + UpdateManufacturerMaster(manufacturer)
        End If

        Return sql
    End Function

    Private Function InsertIntoManufacturerMaster(ByRef manufacturerObj As ClsManufacturerMaster) As String
        Dim sql As String = ""
        sql = " BEGIN " + vbCrLf
        sql = sql + "SET IDENTITY_INSERT " + cManufacturerMaster + " ON" + vbCrLf
        sql = sql + " insert into " + cManufacturerMaster + "("
        sql = sql + cId
        sql = sql + "," + cName
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
        With manufacturerObj
            sql = sql + CStr(.Id)
            sql = sql + ",'" + .Name + "'"
            sql = sql + ",'" + .Address + "'"
            sql = sql + ",'" + .PhoneR + "'"
            sql = sql + ",'" + .PhoneO + "'"
            sql = sql + ",'" + .Mobile + "'"
            sql = sql + ",'" + .EMail + "'"
            sql = sql + ",'" + .City + "'"
            sql = sql + ",'" + .Pin + "'"
            sql = sql + ",'" + .Representative + "'"
            sql = sql + ",'" + .PhoneRepresentative + "'"
            sql = sql + ",'" + lcUserId + "'"
            sql = sql + ",'" + Now.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + vbCrLf + "SET IDENTITY_INSERT " + cManufacturerMaster + " OFF"
        sql = sql + vbCrLf + " END "

        Return sql
    End Function

    Private Function UpdateManufacturerMaster(ByRef manufacturerObj As ClsManufacturerMaster) As String
        Dim sql As String = ""
        sql = "update " + cManufacturerMaster
        sql = sql + " set "
        With manufacturerObj
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
            sql = sql + "='" + lcUserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + Now.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "Item"

    Private Function GetQuery(ByVal item As ClsItemMaster) As String
        Dim sql As String = ""

        If item IsNot Nothing Then
            sql = "IF NOT EXISTS (SELECT *  From " + cItemMaster + " Where " + cId + " = " + CStr(item.Id) + ") "
            sql = sql + vbCrLf + InsertIntoItemMaster(item)
            sql = sql + vbCrLf + " ELSE "
            sql = sql + vbCrLf + UpdateItemMaster(item)
        End If

        Return sql
    End Function

    Private Function InsertIntoItemMaster(ByRef itemObj As ClsItemMaster) As String
        Dim sql As String = ""
        sql = " BEGIN " + vbCrLf
        sql = sql + "SET IDENTITY_INSERT " + cItemMaster + " ON" + vbCrLf
        sql = sql + " insert into " + cItemMaster + "("
        sql = sql + cId
        sql = sql + "," + cItemCode
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
        With itemObj
            sql = sql + CStr(.Id)
            sql = sql + ",'" + .ItemCode + "'"
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
            sql = sql + ",'" + lcUserId + "'"
            sql = sql + ",'" + Now.ToString("s") + "'"
        End With
        sql = sql + ")"
        sql = sql + vbCrLf + "SET IDENTITY_INSERT " + cItemMaster + " OFF"
        sql = sql + vbCrLf + " END "

        Return sql
    End Function

    Private Function UpdateItemMaster(ByRef itemObj As ClsItemMaster) As String
        Dim sql As String = ""
        sql = "update " + cItemMaster
        sql = sql + " set "
        With itemObj
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
            sql = sql + "='" + lcUserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + Now.ToString("s") + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "Tax"

    Private Function GetQuery(ByVal tax As ClsTaxMaster) As String
        Dim sql As String = ""

        If tax IsNot Nothing Then
            sql = "IF NOT EXISTS (SELECT *  From " + cTaxMaster + " Where " + cId + " = " + CStr(tax.Id) + ") "
            sql = sql + vbCrLf + InsertIntoTaxMaster(tax)
            sql = sql + vbCrLf + " ELSE "
            sql = sql + vbCrLf + UpdateTaxMaster(tax)
        End If

        Return sql
    End Function

    Private Function InsertIntoTaxMaster(ByRef taxObj As ClsTaxMaster) As String
        Dim sql As String = ""
        sql = " BEGIN " + vbCrLf
        sql = sql + "SET IDENTITY_INSERT " + cTaxMaster + " ON" + vbCrLf
        sql = sql + " insert into " + cTaxMaster + "("
        sql = sql + cId
        sql = sql + "," + cName
        sql = sql + "," + cTaxPercent
        sql = sql + "," + cDisplayName
        sql = sql + ") values("
        With taxObj
            sql = sql + CStr(.Id)
            sql = sql + ",'" + .Name + "'"
            sql = sql + "," + CStr(.TaxPercent)
            sql = sql + ",'" + .DisplayName + "'"
        End With
        sql = sql + ")"
        sql = sql + vbCrLf + "SET IDENTITY_INSERT " + cTaxMaster + " OFF"
        sql = sql + vbCrLf + " END "

        Return sql
    End Function

    Private Function UpdateTaxMaster(ByRef taxObj As ClsTaxMaster) As String
        Dim sql As String = ""
        sql = "update " + cTaxMaster
        sql = sql + " set "
        With taxObj
            sql = sql + cName
            sql = sql + "='" + .Name + "'"
            'sql = sql + "," + cTaxPercent
            'sql = sql + "=" + CStr(.TaxPercent)
            sql = sql + "," + cDisplayName
            sql = sql + "='" + .DisplayName + "'"
            sql = sql + " where " + cId
            sql = sql + "=" + CStr(.Id)
        End With

        Return sql
    End Function

#End Region

#Region "Sale"

    Public Function GetFullQuery(ByVal saleObj As ClsSalesMaster, ByVal saleDetailList As List(Of ClsSalesDetail)) As String
        Dim sql As String = GetQuery(saleObj, saleDetailList)
        If sql.Trim <> "" Then sql = CreateQueryToExecute(sql)

        Return sql
    End Function

    'Local node means sale but remote node means purchase
    Private Function GetQuery(ByVal saleObj As ClsSalesMaster, ByVal saleDetailList As List(Of ClsSalesDetail)) As String
        Dim sql As String = ""

        If saleObj IsNot Nothing Then
            sql = " Declare @PurchaseId bigint "
            sql = sql + vbCrLf + "IF NOT EXISTS (SELECT *  From " + cPurchaseMaster + " Where " + cVoucherNo + " = '" + saleObj.SaleCode + "') "
            sql = sql + vbCrLf + " Begin "
            sql = sql + vbCrLf + InsertIntoPurchaseMaster(saleObj)
            sql = sql + vbCrLf + " Select @PurchaseId = " + cId + " From " + cPurchaseMaster + " Where " + cVoucherNo + " = '" + saleObj.SaleCode + "' "
            sql = sql + vbCrLf + " End "
            sql = sql + vbCrLf + " ELSE "
            sql = sql + vbCrLf + " Begin "
            sql = sql + vbCrLf + " Select @PurchaseId = " + cId + " From " + cPurchaseMaster + " Where " + cVoucherNo + " = '" + saleObj.SaleCode + "' "
            sql = sql + vbCrLf + UpdatePurchaseMaster(saleObj)
            sql = sql + vbCrLf + " End "
            sql = sql + vbCrLf
            sql = sql + vbCrLf + DeletePurchaseDetailByCursor()
            'sql = sql + vbCrLf + " Delete " + cPurchaseDetail + " where " + cPurchaseId + " = @PurchaseId "

            For Each saleDetail As ClsSalesDetail In saleDetailList
                sql = sql + vbCrLf + InsertIntoPurchaseDetail(saleDetail)
            Next

            sql = sql + vbCrLf + " Update " + cPurchaseMaster + " set " + cNotClosed + " = 0 where " + cId + " = @PurchaseId"
        End If

        Return sql
    End Function

    Public Function InsertIntoPurchaseMaster(ByRef saleObj As ClsSalesMaster) As String
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
        sql = sql + "," + cNotClosed
        sql = sql + ") values("
        With saleObj
            sql = sql + "''"
            sql = sql + "," + lcVendorId
            sql = sql + ",'" + .Mode + "'"
            sql = sql + ",'" + .SaleCode + "'"
            sql = sql + "," + CStr(cInvalidId)
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + lcUserId + "'"
            sql = sql + ",'" + Now.ToString("s") + "'"
            sql = sql + ",'" + .SaleDate.ToString("s") + "'"
            sql = sql + "," + CStr(.TaxId)
            sql = sql + "," + CStr(.DiscountAmount)
            sql = sql + "," + CStr(.DebitAdjust)    'Credit and Debit get interchange in this case
            sql = sql + "," + CStr(.CreditAdjust)
            sql = sql + "," + CStr(.TaxPercent)
            sql = sql + "," + CStr(.PreExciseAmount)
            sql = sql + "," + CStr(Math.Abs(CInt(.NotClosed)))
        End With
        sql = sql + ")"

        Return sql
    End Function

    Public Function UpdatePurchaseMaster(ByRef saleObj As ClsSalesMaster) As String
        Dim sql As String = ""
        sql = "update " + cPurchaseMaster
        sql = sql + " set "
        With saleObj
            'sql = sql + cPurchaseCode
            'sql = sql + "='" + .PurchaseCode + "'"
            sql = sql + cVendorId
            sql = sql + "=" + lcVendorId
            sql = sql + "," + cMode
            sql = sql + "='" + .Mode + "'"
            sql = sql + "," + cVoucherNo
            sql = sql + "='" + .SaleCode + "'"
            sql = sql + "," + cOrderId
            sql = sql + "=" + CStr(cInvalidId)
            sql = sql + "," + cRemark
            sql = sql + "='" + .Remark + "'"
            sql = sql + "," + cUserId
            sql = sql + "='" + lcUserId + "'"
            sql = sql + "," + cDateOn
            sql = sql + "='" + Now.ToString("s") + "'"
            sql = sql + "," + cPurchaseDate
            sql = sql + "='" + .SaleDate.ToString("s") + "'"
            sql = sql + "," + cTaxId
            sql = sql + "=" + CStr(.TaxId)
            sql = sql + "," + cDiscountAmount
            sql = sql + "=" + CStr(.DiscountAmount)
            sql = sql + "," + cCreditAdjust     'Credit and Debit get interchange in this case
            sql = sql + "=" + CStr(.DebitAdjust)
            sql = sql + "," + cDebitAdjust
            sql = sql + "=" + CStr(.CreditAdjust)
            'sql = sql + "," + cCreditAdjust
            'sql = sql + "=" + CStr(.CreditAdjust)
            'sql = sql + "," + cDebitAdjust
            'sql = sql + "=" + CStr(.DebitAdjust)
            sql = sql + "," + cTaxPercent
            sql = sql + "=" + CStr(.TaxPercent)
            sql = sql + "," + cPreExciseAmount
            sql = sql + "=" + CStr(.PreExciseAmount)
            sql = sql + "," + cNotClosed
            sql = sql + "=" + CStr(Math.Abs(CInt(.NotClosed)))
            sql = sql + " where " + cId
            sql = sql + "= @PurchaseId"
        End With

        Return sql
    End Function

    Public Function InsertIntoPurchaseDetail(ByRef saleDetailObj As ClsSalesDetail) As String
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
        With saleDetailObj
            sql = sql + " @PurchaseId "
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
            sql = sql + "," + CStr(.SaleQuantity)
            sql = sql + "," + CStr(.FreeQuantity)
            sql = sql + "," + CStr(.StorageId)
            sql = sql + ",'" + .Remark + "'"
            sql = sql + ",'" + lcUserId + "'"
            sql = sql + ",'" + Now.ToString("s") + "'"
            sql = sql + "," + CStr(.TaxAmount)
            sql = sql + "," + CStr(.DiscountAmount)
            sql = sql + "," + CStr(.PackQuantity)
        End With
        sql = sql + ")"

        Return sql
    End Function

    Public Function DeletePurchaseDetailByCursor() As String
        Dim sql As String = ""
        sql = " BEGIN  "
        sql = sql + vbCrLf + " DECLARE @PurchaseDetailId bigint "
        sql = sql + vbCrLf + " DECLARE DeleteDetail CURSOR FOR Select " + cId + " From " + cPurchaseDetail + " where " + cPurchaseId + " = @PurchaseId "
        sql = sql + vbCrLf
        sql = sql + vbCrLf + " OPEN DeleteDetail "
        sql = sql + vbCrLf + " FETCH  DeleteDetail into @PurchaseDetailId "
        sql = sql + vbCrLf
        sql = sql + vbCrLf + " While (@@Fetch_Status=0) "
        sql = sql + vbCrLf + " BEGIN  "
        sql = sql + vbCrLf
        sql = sql + vbCrLf + " Delete " + cPurchaseDetail + " where " + cId + " = @PurchaseDetailId "
        sql = sql + vbCrLf + vbCrLf
        sql = sql + vbCrLf + " FETCH next from DeleteDetail into @PurchaseDetailId "
        sql = sql + vbCrLf
        sql = sql + vbCrLf + " END   "
        sql = sql + vbCrLf
        sql = sql + vbCrLf + " CLOSE DeleteDetail "
        sql = sql + vbCrLf + " DEALLOCATE DeleteDetail "
        sql = sql + vbCrLf + " END "

        Return sql
    End Function

#End Region

End Class
