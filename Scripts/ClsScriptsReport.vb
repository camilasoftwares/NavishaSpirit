'This function is used to get readymade scripts by passing values.
'It helps in maintaining scripts with change in database

Public Class ClsScriptsReport

#Region "Local variables and Constants"
    Shared sInstance As ClsScriptsReport
#End Region

#Region "Public Functions"

    ''' <summary>
    ''' This function is used to get Instance of this class
    ''' </summary>
    ''' <returns>Instance of this class</returns>
    ''' <remarks></remarks>
    Public Shared Function GetInstance() As ClsScriptsReport
        If sInstance Is Nothing Then
            sInstance = New ClsScriptsReport
        End If

        Return sInstance
    End Function

#End Region

#Region "Tables Names"
    Private Const cTransactionAccount As String = "TransactionAccount"
    Private Const cAccountHead As String = "AccountHead"
    Private Const cCompanyInfo As String = "CompanyInfo"
    Private Const cJournalEntry As String = "JournalEntry"
    Private Const cChequePayment As String = "ChequePayment"
    Private Const cChequeReceipt As String = "ChequeReceipt"
    Private Const cCashPayment As String = "CashPayment"
    Private Const cCashReceipt As String = "CashReceipt"
    Private Const cTransactionStock As String = "TransactionStock"
    Private Const cItemMaster As String = "ItemMaster"
    Private Const cStorageMaster As String = "StorageMaster"
    Private Const cSalesMaster As String = "SalesMaster"
    Private Const cSalesDetail As String = "SalesDetail"
    Private Const cCustomerMaster As String = "CustomerMaster"
    Private Const cPurchaseDetail As String = "PurchaseDetail"
    Private Const cPurchaseMaster As String = "PurchaseMaster"
    Private Const cCurrentStock As String = "CurrentStock"
    Private Const cManufacturerMaster As String = "ManufacturerMaster"
    Private Const cCategoryMaster As String = "CategoryMaster"
    Private Const cScheduleMaster As String = "ScheduleMaster"
    Private Const cGenericMaster As String = "GenericMaster"
    Private Const cVendorMaster As String = "VendorMaster"
    Private Const cDoctorMaster As String = "DoctorMaster"
    Private Const cPurchaseOrderMaster As String = "PurchaseOrderMaster"
    Private Const cPurchaseOrderDetail As String = "PurchaseOrderDetail"
    Private Const cDestructionSlipMaster As String = "DestructionSlipMaster"
    Private Const cDestructionSlipDetail As String = "DestructionSlipDetail"
    Private Const cSalesReturnMaster As String = "SalesReturnMaster"
    Private Const cSalesReturnDetail As String = "SalesReturnDetail"
    Private Const cPurchaseReturnMaster As String = "PurchaseReturnMaster"
    Private Const cPurchaseReturnDetail As String = "PurchaseReturnDetail"
    Private Const cExpiryDetail As String = "ExpiryDetail"
    Private Const cFreeStockTransaction As String = "FreeStockTransaction"
    Private Const cLegalTerms As String = "LegalTerms"
    Private Const cDivisionMaster As String = "DivisionMaster"
    Private Const cTransporter As String = "Transporter"
    Private Const cHQMaster As String = "HQMaster"
    Private Const cSampleMaster As String = "SampleMaster"
    Private Const cSampleDetail As String = "SampleDetail"
    Private Const cTaxMaster As String = "TaxMaster"
    Private Const cCreditNote As String = "CreditNote"
    Private Const cDebitNote As String = "DebitNote"

#End Region

#Region "Common Function"

    Private Function GetCompanyAlias() As String
        Dim sql As String = ""
        sql = cCompanyInfo + "." + cId + " As H" + cId + ", "
        sql = sql + cCompanyInfo + "." + cName + " As H" + cName + ", "
        sql = sql + cCompanyInfo + "." + cAddress + " As H" + cAddress + ", "
        sql = sql + cCompanyInfo + "." + cContactPerson + " As H" + cContactPerson + ", "
        sql = sql + cCompanyInfo + "." + cPhone + " As H" + cPhone + ", "
        sql = sql + cCompanyInfo + "." + cFax + " As H" + cFax + ", "
        sql = sql + cCompanyInfo + "." + cEmail + " As H" + cEmail + ", "
        sql = sql + cCompanyInfo + "." + cCity + " As H" + cCity + ", "
        sql = sql + cCompanyInfo + "." + cState + " As H" + cState + ", "
        sql = sql + cCompanyInfo + "." + cPin + " As H" + cPin + ", "
        sql = sql + cCompanyInfo + "." + cUpTtNo + " As H" + cUpTtNo + ", "
        sql = sql + cCompanyInfo + "." + cCstNo + " As H" + cCstNo + ", "
        sql = sql + cCompanyInfo + "." + cDlNo + " As H" + cDlNo + ", "
        sql = sql + cCompanyInfo + "." + cSubTitle + " As H" + cSubTitle + ", "
        sql = sql + cCompanyInfo + "." + cTinNo + " As H" + cTinNo

        Return sql
    End Function

    Private Function GetCompanyGroupByQuery() As String
        Dim sql As String = ""
        sql = sql + cCompanyInfo + "." + cId + ", "
        sql = sql + cCompanyInfo + "." + cName + ", "
        sql = sql + cCompanyInfo + "." + cAddress + ", "
        sql = sql + cCompanyInfo + "." + cContactPerson + ", "
        sql = sql + cCompanyInfo + "." + cPhone + ", "
        sql = sql + cCompanyInfo + "." + cFax + ", "
        sql = sql + cCompanyInfo + "." + cEmail + ", "
        sql = sql + cCompanyInfo + "." + cCity + ", "
        sql = sql + cCompanyInfo + "." + cState + ", "
        sql = sql + cCompanyInfo + "." + cPin + ", "
        sql = sql + cCompanyInfo + "." + cUpTtNo + ", "
        sql = sql + cCompanyInfo + "." + cCstNo + ", "
        sql = sql + cCompanyInfo + "." + cDlNo + ", "
        sql = sql + cCompanyInfo + "." + cSubTitle + ", "
        sql = sql + cCompanyInfo + "." + cTinNo

        Return sql
    End Function

#End Region

#Region "Ledger"

    Public Function GetLedgerForHeadId(ByVal headId As Integer, ByVal dateFrom As Date, ByVal dateTo As Date, Optional ByVal withOrderBy As Boolean = True) As String
        Dim sql As String = ""

        sql = " ("
        sql = sql + "select " + cTransactionAccount + "." + cTransactionDate + ", "
        sql = sql + cTransactionAccount + "." + cVoucherNo + ", "
        sql = sql + cTransactionAccount + "." + cDrAmount + ", "
        sql = sql + cTransactionAccount + "." + cCrAmount + ", "
        sql = sql + cTransactionAccount + "." + cNarration + ", "
        sql = sql + cAccountHead + "." + cName
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " from "
        sql = sql + cAccountHead + " RIGHT OUTER JOIN "
        sql = sql + cTransactionAccount + " ON "
        sql = sql + cAccountHead + "." + cId + " = "
        sql = sql + cTransactionAccount + "." + cHeadId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " where (" + cTransactionAccount + "." + cHeadId + " = " + CStr(headId) + ")"
        sql = sql + " and (" + cTransactionAccount + "." + cTransactionDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "')"
        sql = sql + ")"

        sql = sql + " UNION "

        sql = sql + " ("
        sql = sql + " SELECT "
        sql = sql + cTransactionAccount + "." + cTransactionDate + ", "
        sql = sql + cTransactionAccount + "." + cVoucherNo + ", "
        sql = sql + cTransactionAccount + "." + cDrAmount + ", "
        sql = sql + cTransactionAccount + "." + cCrAmount + ", "
        sql = sql + cTransactionAccount + "." + cNarration + ", "
        sql = sql + cAccountHead + "." + cName
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " From "
        sql = sql + cAccountHead + " INNER JOIN "
        sql = sql + cCustomerMaster + " ON " + cAccountHead + "." + cHeadCode + " = " + cCustomerMaster + "." + cAccountId + " INNER JOIN "
        sql = sql + cSalesMaster + " ON " + cCustomerMaster + "." + cId + " = " + cSalesMaster + "." + cCustomerId + " INNER JOIN "
        sql = sql + cTransactionAccount + " ON " + cSalesMaster + "." + cSaleCode + " = " + cTransactionAccount + "." + cVoucherNo + " INNER JOIN "
        sql = sql + cAccountHead + " As AccHead ON " + cTransactionAccount + "." + cHeadId + " = AccHead." + cId + " And AccHead." + cId + " = " + CStr(cAccountHead_CashAccount)
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " where (" + cAccountHead + "." + cId + " = " + CStr(headId) + ")"
        sql = sql + " and (" + cTransactionAccount + "." + cTransactionDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "')"
        sql = sql + ")"

        sql = sql + " order by " + cTransactionAccount + "." + cTransactionDate

        Return sql
    End Function

#End Region

#Region "Bank Book"

    Public Function GetBankBookForHeadId(ByVal headId As Integer, ByVal dateFrom As Date, ByVal dateTo As Date) As String
        Dim sql As String = ""
        'sql = "(" + GetLedgerForHeadId(headId, dateFrom, dateTo, False)
        sql = "("
        sql = sql + " select " + cTransactionAccount + "." + cTransactionDate + ", "
        sql = sql + cTransactionAccount + "." + cVoucherNo + ", "
        sql = sql + cTransactionAccount + "." + cDrAmount + ", "
        sql = sql + cTransactionAccount + "." + cCrAmount + ", "
        sql = sql + cTransactionAccount + "." + cNarration + ", "
        sql = sql + cAccountHead + "." + cName
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " from "
        sql = sql + cAccountHead + " RIGHT OUTER JOIN "
        sql = sql + cTransactionAccount + " ON "
        sql = sql + cAccountHead + "." + cId + " = "
        sql = sql + cTransactionAccount + "." + cHeadId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " where (" + cTransactionAccount + "." + cHeadId + " = " + CStr(headId) + ")"
        sql = sql + " and (" + cTransactionAccount + "." + cTransactionDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "')"
        sql = sql + " and (" + cTransactionAccount + "." + cVoucherNo + " not like 'DJE%'))"
        sql = sql + " Union "
        sql = sql + "( Select " + cJournalEntry + "." + cJournaldate + " AS " + cTransactionDate + ", "
        sql = sql + cJournalEntry + "." + cJournalNo + " AS " + cVoucherNo + ", "
        sql = sql + cJournalEntry + "." + cDrAmount + ", "
        sql = sql + cJournalEntry + "." + cCrAmount + ", "
        sql = sql + cJournalEntry + "." + cRemark + " AS " + cNarration + ", "
        sql = sql + cAccountHead + "." + cName
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " from "
        sql = sql + cJournalEntry + " INNER JOIN "
        sql = sql + cTransactionAccount + " ON 'DJE' + CONVERT(varchar, " + cJournalEntry + "." + cId + ") = " + cTransactionAccount + "." + cVoucherNo + " INNER JOIN "
        sql = sql + cAccountHead + " ON " + cJournalEntry + "." + cHeadId + " = " + cAccountHead + "." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " where (" + cJournalEntry + "." + cHeadId + " = " + CStr(headId) + ")"
        sql = sql + " and (" + cJournalEntry + "." + cJournaldate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "')"
        sql = sql + ")"

        Return sql
    End Function

    Public Function GetCrDrOpeningBalance(ByVal headId As Integer, ByVal dateBefore As Date) As String
        Dim sql As String = ""
        sql = sql + "Select SUM(" + cTransactionAccount + "." + cDrAmount + ") AS " + cDrAmount + ", "
        sql = sql + "SUM(" + cTransactionAccount + "." + cCrAmount + ") AS " + cCrAmount + ", "
        sql = sql + " SUM(Case When " + cAccountHead + "." + cCrDr + "='Dr' Then " + cAccountHead + "." + cOpeningBalance + " Else -(" + cAccountHead + "." + cOpeningBalance + ")  End) AS " + cOpeningBalance
        sql = sql + " from " + cAccountHead + " INNER JOIN "
        sql = sql + cTransactionAccount + " ON " + cAccountHead + "." + cId + " = " + cTransactionAccount + "." + cHeadId
        sql = sql + " where " + cAccountHead + "." + cId + " = " + CStr(headId)
        sql = sql + " and " + cTransactionAccount + "." + cTransactionDate + " < '" + dateBefore.ToString("s") + "'"
        sql = sql + " GROUP BY " + cAccountHead + "." + cId

        Return sql
    End Function

    Public Function GetIdNameFromChequePaymentForHeadId(ByVal headId As Integer) As String
        Dim sql As String = ""
        sql = sql + "Select ch." + cId + ", "
        sql = sql + cAccountHead + "." + cName + " from " + cAccountHead + ", " + cChequePayment + " as ch where " + cAccountHead + "." + cId
        sql = sql + " in ( select ( case "
        sql = sql + " when toheadid = " + CStr(headId) + " then fromheadid "
        sql = sql + " when fromheadid = " + CStr(headId) + " then toheadid "
        sql = sql + " End ) as headId from " + cChequePayment
        sql = sql + " where " + cChequePayment + "." + cId + " = ch." + cId
        sql = sql + " ) "

        Return sql
    End Function

    Public Function GetIdNameFromChequeReceiptForHeadId(ByVal headId As Integer) As String
        Dim sql As String = ""
        sql = sql + "Select ch." + cId + ", "
        sql = sql + cAccountHead + "." + cName + " from " + cAccountHead + ", " + cChequeReceipt + " as ch where " + cAccountHead + "." + cId
        sql = sql + " in ( select ( case "
        sql = sql + " when toheadid = " + CStr(headId) + " then fromheadid "
        sql = sql + " when fromheadid = " + CStr(headId) + " then toheadid "
        sql = sql + " End ) as headId from " + cChequeReceipt
        sql = sql + " where " + cChequeReceipt + "." + cId + " = ch." + cId
        sql = sql + " ) "

        Return sql
    End Function

    Public Function GetIdNameFromCashPaymentForHeadId(ByVal headId As Integer) As String
        Dim sql As String = ""
        sql = sql + "Select ch." + cId + ", "
        sql = sql + cAccountHead + "." + cName + " from " + cAccountHead + ", " + cCashPayment + " as ch where " + cAccountHead + "." + cId
        sql = sql + " in ( select ( case "
        sql = sql + " when toheadid = " + CStr(headId) + " then fromheadid "
        sql = sql + " when fromheadid = " + CStr(headId) + " then toheadid "
        sql = sql + " End ) as headId from " + cCashPayment
        sql = sql + " where " + cCashPayment + "." + cId + " = ch." + cId
        sql = sql + " ) "

        Return sql
    End Function

    Public Function GetIdNameFromCashReceiptForHeadId(ByVal headId As Integer) As String
        Dim sql As String = ""
        sql = sql + "Select ch." + cId + ", "
        sql = sql + cAccountHead + "." + cName + " from " + cAccountHead + ", " + cCashReceipt + " as ch where " + cAccountHead + "." + cId
        sql = sql + " in ( select ( case "
        sql = sql + " when toheadid = " + CStr(headId) + " then fromheadid "
        sql = sql + " when fromheadid = " + CStr(headId) + " then toheadid "
        sql = sql + " End ) as headId from " + cCashReceipt
        sql = sql + " where " + cCashReceipt + "." + cId + " = ch." + cId
        sql = sql + " ) "

        Return sql
    End Function

#End Region

#Region "FreeStockTransaction"

    Public Function GetFreeStockTransactionForSaleId(ByVal saleId As Long) As String
        Dim sql As String = ""
        sql = "SELECT " + cItemMaster + "." + cName + " As FreeItemName, "
        sql = sql + cFreeStockTransaction + ".* "
        sql = sql + " From "
        sql = sql + cFreeStockTransaction + " INNER JOIN "
        sql = sql + cItemMaster + " ON " + cFreeStockTransaction + "." + cItemId + " = " + cItemMaster + "." + cId
        sql = sql + " where " + cFreeStockTransaction + "." + cSaleId + " = " + CStr(saleId)

        Return sql
    End Function

#End Region

#Region "Stock Ledger"

    Public Function GetStockLedgerForItemId(ByVal itemId As Integer) As String
        Dim sql As String = ""
        sql = sql + "Select "
        sql = sql + cTransactionStock + "." + cTransactionNo + ", "
        sql = sql + cTransactionStock + "." + cItemId + ", "
        sql = sql + cItemMaster + "." + cName + " AS " + cItemName + ", "
        sql = sql + cTransactionStock + "." + cBatch + ", "
        sql = sql + cTransactionStock + "." + cExpiryDate + ", "
        sql = sql + cTransactionStock + "." + cPackQuantity + ", "
        sql = sql + cTransactionStock + "." + cQuantityIn + ", "
        sql = sql + cTransactionStock + "." + cQuantityOut + ", "
        sql = sql + cTransactionStock + "." + cPricePurchase + ", "
        sql = sql + cTransactionStock + "." + cPriceSale + ", "
        sql = sql + cTransactionStock + "." + cTaxPercent + ", "
        sql = sql + cTransactionStock + "." + cDiscountPercent + ", "
        sql = sql + cTransactionStock + "." + cTaxAmount + ", "
        sql = sql + cTransactionStock + "." + cDiscountAmount + ", "
        sql = sql + cTransactionStock + "." + cSource + ", "
        sql = sql + cTransactionStock + "." + cRemark + ", "
        sql = sql + cTransactionStock + "." + cUserId + ", "
        sql = sql + cTransactionStock + "." + cDateOn + ", "
        sql = sql + cStorageMaster + "." + cName + " AS " + cStorageName
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cCurrentStock + " LEFT OUTER JOIN "
        sql = sql + cStorageMaster + " ON " + cCurrentStock + "." + cStorageId + " = " + cStorageMaster + "." + cId + " LEFT OUTER JOIN "
        sql = sql + cTransactionStock + " INNER JOIN "
        sql = sql + cItemMaster + " ON " + cTransactionStock + "." + cItemId + " = " + cItemMaster + "." + cId + " ON " + cCurrentStock + "." + cItemId + " = " + cTransactionStock + "." + cItemId + " AND " + cCurrentStock + "." + cBatch + " = " + cTransactionStock + "." + cBatch
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " where " + cTransactionStock + "." + cItemId + "=" + CStr(itemId)

        Return sql
    End Function

#End Region

#Region "Gross Sales"

    Public Function GetGrossSales(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal userId As String) As String
        Dim sql As String = ""
        sql = "Select "
        sql = sql + cSalesMaster + "." + cId + ", "
        sql = sql + " SUM((" + cSalesDetail + "." + cSaleQuantity + " * " + cSalesDetail + "." + cPriceSale + ")" + "+" + cSalesDetail + "." + cTaxAmount + ")AS " + cBillAmount + ", "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " * " + cSalesDetail + "." + cPriceSale + " * " + cSalesDetail + "." + cDiscountPercent + "/100) AS  Discount , "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + ") AS SaleQty ,"
        sql = sql + cSalesMaster + "." + cSaleCode + " AS MSaleCode, "
        sql = sql + cSalesMaster + "." + cCustomerId + ", "
        sql = sql + cCustomerMaster + "." + cName + " AS " + cCustomerName + ", "
        sql = sql + cSalesMaster + "." + cRemark + " AS MRemarks, "
        sql = sql + cSalesMaster + "." + cSaleDate + " AS MSaleDate , "
        sql = sql + cSalesMaster + "." + cTaxPercent + ","
        sql = sql + cSalesMaster + "." + cDiscountAmount + ","
        sql = sql + cSalesMaster + "." + cDateOn + " AS MDateON , "
        sql = sql + cSalesMaster + "." + cUserId + " AS MUserID "
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cSalesMaster + " INNER JOIN "
        sql = sql + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId
        sql = sql + " RIGHT OUTER JOIN "
        sql = sql + cSalesDetail + " ON " + cSalesMaster + "." + cId + " = " + cSalesDetail + "." + cSaleId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " GROUP BY "
        sql = sql + cSalesMaster + "." + cId + ", "
        sql = sql + cSalesMaster + "." + cSaleCode + ", "
        sql = sql + cSalesMaster + "." + cCustomerId + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + cSalesMaster + "." + cRemark + ", "
        sql = sql + cSalesMaster + "." + cTaxPercent + ","
        sql = sql + cSalesMaster + "." + cDiscountAmount + ","
        sql = sql + cSalesMaster + "." + cCashOutAmount + ", "
        sql = sql + cSalesMaster + "." + cAdjustedAmount + ", "
        sql = sql + cSalesMaster + "." + cSaleDate + ", "
        sql = sql + cSalesMaster + "." + cDateOn + ", "
        sql = sql + cSalesMaster + "." + cUserId + ", "
        sql = sql + GetCompanyGroupByQuery()
        sql = sql + " having " + cSalesMaster + "." + cSaleDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        If userId.Trim <> "" Then
            sql = sql + " and " + cSalesMaster + "." + cUserId + " ='" + userId.Trim + "'"
        End If

        Return sql
    End Function

#End Region

#Region "ItemWise Sale"

    Public Function GetItemWiseSale(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal itemId As Integer) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " * " + cSalesDetail + "." + cPriceSale + ") AS " + cBillAmount + ", "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " * " + cSalesDetail + "." + cPriceSale + " * " + cSalesDetail + "." + cDiscountPercent + "/100) AS  Discount , "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + ") AS SaleQty ,"
        sql = sql + " SUM(" + cSalesDetail + "." + cFreeQuantity + ") AS FreeQty ,"
        sql = sql + cItemMaster + "." + cName + " AS " + cItemName + ","
        sql = sql + cSalesMaster + "." + cSaleDate + ","
        sql = sql + cSalesMaster + "." + cSaleCode + ","
        sql = sql + cSalesMaster + "." + cTaxPercent + ","
        sql = sql + cSalesMaster + "." + cDiscountAmount + ","
        sql = sql + cSalesDetail + "." + cBatch + ","
        sql = sql + cSalesDetail + "." + cExpiryDate + ","
        sql = sql + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cSalesMaster + " LEFT OUTER JOIN "
        sql = sql + cSalesDetail + " ON " + cSalesMaster + "." + cId + "=" + cSalesDetail + "." + cSaleId
        sql = sql + " LEFT OUTER JOIN " + cItemMaster + " ON " + cSalesDetail + "." + cItemId + "=" + cItemMaster + "." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cSalesMaster + "." + cSaleDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"

        If itemId > 0 Then sql = sql + " and " + cSalesDetail + "." + cItemId + " = " + CStr(itemId)

        sql = sql + " GROUP BY "
        sql = sql + cSalesDetail + "." + cItemId + ", "
        sql = sql + cSalesDetail + "." + cBatch + ","
        sql = sql + cSalesDetail + "." + cExpiryDate + ","
        sql = sql + cSalesMaster + "." + cSaleDate + ","
        sql = sql + cSalesMaster + "." + cSaleCode + ","
        sql = sql + cSalesMaster + "." + cTaxPercent + ","
        sql = sql + cSalesMaster + "." + cDiscountAmount + ","
        sql = sql + cItemMaster + "." + cName + ", "
        sql = sql + GetCompanyGroupByQuery()
        sql = sql + " Order By "
        sql = sql + cSalesMaster + "." + cSaleDate

        Return sql
    End Function

    Public Function GetItemCatWiseSale(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal itemId As Integer) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " * " + cSalesDetail + "." + cPriceSale + ") AS " + cBillAmount + ", "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " * " + cSalesDetail + "." + cPriceSale + " * " + cSalesDetail + "." + cDiscountPercent + "/100) AS  Discount , "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + ") AS SaleQty ,"
        sql = sql + " SUM(" + cSalesDetail + "." + cFreeQuantity + ") AS FreeQty ,"
        sql = sql + cItemMaster + "." + cName + " AS " + cItemName + ","
        sql = sql + cSalesMaster + "." + cSaleDate + ","
        sql = sql + cSalesMaster + "." + cSaleCode + ","
        sql = sql + cSalesMaster + "." + cTaxPercent + ","
        sql = sql + cSalesMaster + "." + cDiscountAmount + ","
        sql = sql + cSalesDetail + "." + cBatch + ","
        sql = sql + cSalesDetail + "." + cExpiryDate + ","
        sql = sql + GetCompanyAlias() + ","
        sql = sql + cItemMaster + "." + cCategoryId
        sql = sql + " FROM "
        sql = sql + cSalesMaster + " LEFT OUTER JOIN "
        sql = sql + cSalesDetail + " ON " + cSalesMaster + "." + cId + "=" + cSalesDetail + "." + cSaleId
        sql = sql + " LEFT OUTER JOIN " + cItemMaster + " ON " + cSalesDetail + "." + cItemId + "=" + cItemMaster + "." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cSalesMaster + "." + cSaleDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"

        If itemId > 0 Then sql = sql + " and " + cItemMaster + "." + cCategoryId + " = " + CStr(itemId)

        sql = sql + " GROUP BY "
        sql = sql + cSalesDetail + "." + cItemId + ", "
        sql = sql + cSalesDetail + "." + cBatch + ","
        sql = sql + cSalesDetail + "." + cExpiryDate + ","
        sql = sql + cSalesMaster + "." + cSaleDate + ","
        sql = sql + cSalesMaster + "." + cSaleCode + ","
        sql = sql + cSalesMaster + "." + cTaxPercent + ","
        sql = sql + cSalesMaster + "." + cDiscountAmount + ","
        sql = sql + cItemMaster + "." + cName + ", "
        sql = sql + GetCompanyGroupByQuery() + ","
        sql = sql + cItemMaster + "." + cCategoryId + ""
        sql = sql + " Order By "
        sql = sql + cSalesMaster + "." + cSaleDate

        Return sql
    End Function

#End Region

    Public Function Gettax(ByVal dateFrom As Date, ByVal dateTo As Date) As String
        Dim sql As String = ""
        sql = "select * from "
        sql = "  SELECT SalesMaster.SaleDate, SalesMaster.SaleCode, SalesMaster.CustomerId, CustomerMaster.Name, CustomerMaster.TinNo,"
        sql = sql + "sum(SalesDetail.SaleQuantity*SalesDetail.PriceSale) as Amount, SalesDetail.TaxPercent,sum(SalesDetail.TaxAmount) as taxAmount,"
        sql = sql + "sum(SalesDetail.SaleQuantity*SalesDetail.PriceSale) + sum(SalesDetail.TaxAmount)"


        sql = sql + "FROM            SalesDetail INNER JOIN"
        sql = sql + " SalesMaster ON SalesDetail.SaleId = SalesMaster.Id INNER JOIN"
        sql = sql + " ItemMaster ON SalesDetail.ItemId = ItemMaster.Id INNER JOIN"
        sql = sql + " CustomerMaster ON SalesMaster.CustomerId = CustomerMaster.Id"
        sql = sql + "	where CustomerMaster.TinNo <> '' and SalesMaster.SaleDate between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"

        sql = sql + " group by SalesMaster.SaleDate,SalesMaster.CustomerId,CustomerMaster.Name,CustomerMaster.TinNo,SalesMaster.SaleCode,SalesDetail.TaxPercent"

        Return sql
    End Function



#Region "Bunch Sale"

    Public Function GetBunchSale(ByVal dateFrom As Date, ByVal dateTo As Date) As String
        Dim sql As String = ""

        sql = "SELECt SUM(SalesDetail.SaleQuantity) AS sumqty, ItemMaster.Name, CategoryMaster.Name AS catname "
        sql = sql + " FROM         CategoryMaster INNER JOIN"
        sql = sql + " ItemMaster ON CategoryMaster.Id = ItemMaster.CategoryId RIGHT OUTER JOIN"
        sql = sql + " SalesMaster LEFT OUTER JOIN"
        sql = sql + " SalesDetail ON SalesMaster.Id = SalesDetail.SaleId ON ItemMaster.Id = SalesDetail.ItemId"
        'sql = sql + " WHERE     (SalesMaster.SaleDate BETWEEN '2015-03-12T00:00:00' AND '2015-03-12T23:59:59')"
        sql = sql + " Where " + cSalesMaster + "." + cSaleDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"

        sql = sql + " GROUP BY ItemMaster.Name, CategoryMaster.Name,CategoryMaster.Name"
        sql = sql + " ORDER BY CategoryMaster.Name,ItemMaster.Name"




        ''    sql = "SELECT "
        ''    sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " * " + cSalesDetail + "." + cPriceSale + ") AS " + cBillAmount + ", "
        ''    sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " * " + cSalesDetail + "." + cPriceSale + " * " + cSalesDetail + "." + cDiscountPercent + "/100) AS  Discount , "
        ''    sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + ") AS SaleQty ,"
        ''    sql = sql + " SUM(" + cSalesDetail + "." + cFreeQuantity + ") AS FreeQty ,"
        ''    sql = sql + cItemMaster + "." + cName + " AS " + cItemName + ","
        ''    sql = sql + cSalesMaster + "." + cSaleDate + ","
        ''    sql = sql + cSalesMaster + "." + cSaleCode + ","
        ''    sql = sql + cSalesMaster + "." + cTaxPercent + ","
        ''    sql = sql + cSalesMaster + "." + cDiscountAmount + ","
        ''    sql = sql + cSalesDetail + "." + cBatch + ","
        ''    sql = sql + cSalesDetail + "." + cExpiryDate + ","
        ''    sql = sql + GetCompanyAlias()
        ''    sql = sql + " FROM "
        ''    sql = sql + cSalesMaster + " LEFT OUTER JOIN "
        ''    sql = sql + cSalesDetail + " ON " + cSalesMaster + "." + cId + "=" + cSalesDetail + "." + cSaleId
        ''    sql = sql + " LEFT OUTER JOIN " + cItemMaster + " ON " + cSalesDetail + "." + cItemId + "=" + cItemMaster + "." + cId
        ''    sql = sql + " CROSS JOIN " + cCompanyInfo
        ''    sql = sql + " Where " + cSalesMaster + "." + cSaleDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"

        ''    'If itemId > 0 Then sql = sql + " and " + cSalesDetail + "." + cItemId + " = " + CStr(itemId)

        ''    sql = sql + " GROUP BY "
        ''    sql = sql + cSalesDetail + "." + cItemId + ", "
        ''    sql = sql + cSalesDetail + "." + cBatch + ","
        ''    sql = sql + cSalesDetail + "." + cExpiryDate + ","
        ''    sql = sql + cSalesMaster + "." + cSaleDate + ","
        ''    sql = sql + cSalesMaster + "." + cSaleCode + ","
        ''    sql = sql + cSalesMaster + "." + cTaxPercent + ","
        ''    sql = sql + cSalesMaster + "." + cDiscountAmount + ","
        ''    sql = sql + cItemMaster + "." + cName + ", "
        ''    sql = sql + GetCompanyGroupByQuery()
        ''    sql = sql + " Order By "
        ''    sql = sql + cSalesMaster + "." + cSaleDate

        Return sql
    End Function

#End Region





#Region "ItemWise PartyWise Sale"

    Public Function GetItemWisePartywiseSale(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal itemId As Integer, ByVal customerId As Integer) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " * " + cSalesDetail + "." + cPriceSale + ") AS " + cBillAmount + ", "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " * " + cSalesDetail + "." + cPriceSale + " * " + cSalesDetail + "." + cDiscountPercent + "/100) AS  Discount , "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + ") AS SaleQty ,"
        sql = sql + " SUM(" + cSalesDetail + "." + cFreeQuantity + ") AS FreeQty ,"
        sql = sql + cSalesDetail + "." + cPackQuantity + ","
        sql = sql + cItemMaster + "." + cName + " AS " + cItemName + ","
        sql = sql + cCustomerMaster + "." + cName + " AS " + cCustomerName + ","
        sql = sql + cSalesMaster + "." + cSaleDate + ","
        sql = sql + cSalesMaster + "." + cSaleCode + ","
        sql = sql + cSalesDetail + "." + cPriceSale + ","
        sql = sql + cSalesMaster + "." + cTaxPercent + ","
        sql = sql + cSalesMaster + "." + cDiscountAmount + ","
        sql = sql + cSalesDetail + "." + cBatch + ","
        sql = sql + cSalesDetail + "." + cExpiryDate + ","
        sql = sql + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cSalesMaster + " LEFT OUTER JOIN "
        sql = sql + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + "=" + cCustomerMaster + "." + cId + " LEFT OUTER JOIN "
        sql = sql + cSalesDetail + " ON " + cSalesMaster + "." + cId + "=" + cSalesDetail + "." + cSaleId
        sql = sql + " LEFT OUTER JOIN " + cItemMaster + " ON " + cSalesDetail + "." + cItemId + "=" + cItemMaster + "." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cSalesMaster + "." + cSaleDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"

        If itemId > 0 Then sql = sql + " and " + cSalesDetail + "." + cItemId + " = " + CStr(itemId)
        If customerId > 0 Then sql = sql + " and " + cSalesMaster + "." + cCustomerId + " = " + CStr(customerId)

        sql = sql + " GROUP BY "
        sql = sql + cSalesDetail + "." + cItemId + ","
        sql = sql + cSalesDetail + "." + cPackQuantity + ","
        sql = sql + cSalesDetail + "." + cPriceSale + ","
        sql = sql + cSalesDetail + "." + cBatch + ","
        sql = sql + cSalesDetail + "." + cExpiryDate + ","
        sql = sql + cSalesMaster + "." + cSaleDate + ","
        sql = sql + cSalesMaster + "." + cSaleCode + ","
        sql = sql + cSalesMaster + "." + cTaxPercent + ","
        sql = sql + cSalesMaster + "." + cDiscountAmount + ","
        sql = sql + cItemMaster + "." + cName + ", "
        sql = sql + cCustomerMaster + "." + cName + ","
        sql = sql + GetCompanyGroupByQuery()
        sql = sql + " Order By "
        sql = sql + cSalesMaster + "." + cSaleDate

        Return sql
    End Function

#End Region

#Region "Credit Sale"

    Public Function GetCreditSale(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal credit As String) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " * " + cSalesDetail + "." + cPriceSale + ") AS " + cBillAmount + ", "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " * " + cSalesDetail + "." + cPriceSale + " * " + cSalesDetail + "." + cDiscountPercent + "/100) AS  Discount , "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + ") AS SaleQty ,"
        sql = sql + " SUM(" + cSalesDetail + "." + cFreeQuantity + ") AS FreeQty ,"
        sql = sql + cSalesMaster + "." + cSaleDate + ","
        sql = sql + cSalesMaster + "." + cSaleCode + ","
        sql = sql + " SUM(" + cTransactionAccount + "." + cCrAmount + ") AS " + cTaxAmount + ","
        sql = sql + cSalesMaster + "." + cTaxPercent + ","
        sql = sql + cSalesMaster + "." + cDiscountAmount + ","
        sql = sql + cItemMaster + "." + cName + " AS " + cItemName + ","
        sql = sql + cSalesDetail + "." + cPriceSale + ","
        sql = sql + cSalesDetail + "." + cDiscountPercent + ","
        sql = sql + cCustomerMaster + "." + cName + " AS " + cCustomerName + ","
        sql = sql + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cTransactionAccount + " RIGHT OUTER JOIN "
        sql = sql + cSalesMaster + " ON " + cTransactionAccount + "." + cVoucherNo + " = " + cSalesMaster + "." + cSaleCode + " And " + cTransactionAccount + "." + cHeadId + " = " + CStr(cAccountHead_Tax) + " LEFT OUTER JOIN "
        sql = sql + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId + " RIGHT OUTER JOIN "
        sql = sql + cSalesDetail + " LEFT OUTER JOIN "
        sql = sql + cItemMaster + " ON " + cItemMaster + "." + cId + " = " + cSalesDetail + "." + cItemId + " ON " + cSalesMaster + "." + cId + " = " + cSalesDetail + "." + cSaleId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cSalesMaster + "." + cSaleDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        sql = sql + " And " + cSalesMaster + "." + cMode + " = '" + credit + "'"
        sql = sql + " GROUP BY "
        sql = sql + cSalesDetail + "." + cItemId + ", "
        sql = sql + cSalesDetail + "." + cPriceSale + ","
        sql = sql + cSalesDetail + "." + cDiscountPercent + ","
        sql = sql + cItemMaster + "." + cName + ", "
        sql = sql + cSalesMaster + "." + cSaleDate + ","
        sql = sql + cSalesMaster + "." + cSaleCode + ","
        sql = sql + cSalesMaster + "." + cTaxPercent + ","
        sql = sql + cSalesMaster + "." + cDiscountAmount + ","
        sql = sql + cCustomerMaster + "." + cName + ","
        sql = sql + GetCompanyGroupByQuery()
        sql = sql + " Order By " + cSalesMaster + "." + cSaleCode

        Return sql
    End Function

#End Region

#Region "Customer Wise Sale"

    Public Function GetPatientWiseSale(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal customerId As Integer, ByVal taxId As Integer) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " * " + cSalesDetail + "." + cPriceSale + ") AS " + cBillAmount + ", "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " * " + cSalesDetail + "." + cPriceSale + " * " + cSalesDetail + "." + cDiscountPercent + "/100) AS  Discount , "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + ") AS SaleQty ,"
        sql = sql + " SUM(" + cSalesDetail + "." + cFreeQuantity + ") AS FreeQty ,"
        sql = sql + cSalesMaster + "." + cSaleCode + ","
        sql = sql + cSalesMaster + "." + cSaleDate + ","
        sql = sql + cSalesMaster + "." + cTaxPercent + ","
        sql = sql + cSalesMaster + "." + cDiscountAmount + ","
        sql = sql + cItemMaster + "." + cName + " AS " + cItemName + ","
        sql = sql + cTaxMaster + "." + cDisplayName + ", "
        sql = sql + cCustomerMaster + "." + cName + " AS " + cCustomerName
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cSalesMaster + " LEFT OUTER JOIN "
        sql = sql + cTaxMaster + " ON " + cSalesMaster + "." + cTaxId + " = " + cTaxMaster + "." + cId + " LEFT OUTER JOIN "
        sql = sql + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId
        sql = sql + " LEFT OUTER JOIN " + cSalesDetail + " ON " + cSalesMaster + "." + cId + " = " + cSalesDetail + "." + cSaleId
        sql = sql + " LEFT OUTER JOIN " + cItemMaster + " ON " + cSalesDetail + "." + cItemId + " = " + cItemMaster + "." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cSalesMaster + "." + cSaleDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        If customerId > 0 Then sql = sql + " and " + cSalesMaster + "." + cCustomerId + " = " + CStr(customerId)
        If taxId <> cInvalidId Then sql = sql + " and " + cTaxMaster + "." + cId + " = " + CStr(taxId)

        sql = sql + " GROUP BY "
        sql = sql + cCustomerMaster + "." + cAccountId + ", "
        sql = sql + cSalesMaster + "." + cSaleCode + ","
        sql = sql + cSalesMaster + "." + cSaleDate + ","
        sql = sql + cSalesMaster + "." + cTaxPercent + ","
        sql = sql + cSalesMaster + "." + cDiscountAmount + ","
        sql = sql + cItemMaster + "." + cId + ","
        sql = sql + cItemMaster + "." + cName + ","
        sql = sql + cTaxMaster + "." + cDisplayName + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + GetCompanyGroupByQuery()
        sql = sql + " Order By " + cSalesMaster + "." + cSaleDate

        Return sql
    End Function

#End Region

#Region "Head Quarter Wise Sale "

    Public Function GetHQWiseSale(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal hqId As Integer, ByVal taxId As Integer) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + cManufacturerMaster + "." + cName + " AS " + cManufacturer + ","
        sql = sql + cItemMaster + "." + cName + " AS " + cItemName + ","
        sql = sql + cCustomerMaster + "." + cName + " AS " + cCustomerName + ","
        sql = sql + cHQMaster + "." + cName + " AS " + cHeadQuarter + ","
        sql = sql + cHQMaster + "." + cAddress + ","
        sql = sql + cSalesMaster + "." + cId + " AS SalesMasterId ,"
        sql = sql + cSalesMaster + "." + cSaleCode + ","
        sql = sql + cSalesMaster + "." + cSaleDate + ","
        sql = sql + cSalesMaster + "." + cTaxPercent + ","
        sql = sql + cSalesMaster + "." + cDiscountAmount + ","
        sql = sql + cTaxMaster + "." + cDisplayName + ","
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " * " + cSalesDetail + "." + cPriceSale + ") AS " + cBillAmount + ", "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " * " + cSalesDetail + "." + cPriceSale + " * " + cSalesDetail + "." + cDiscountPercent + "/100) AS  Discount , "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + ") AS SaleQty, "
        sql = sql + " SUM(" + cSalesDetail + "." + cFreeQuantity + ") AS FreeQty "
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cSalesMaster + " INNER JOIN "
        sql = sql + cSalesDetail + " ON " + cSalesMaster + "." + cId + "=" + cSalesDetail + "." + cSaleId + "  LEFT OUTER JOIN "
        sql = sql + cTaxMaster + " ON " + cSalesMaster + "." + cTaxId + " = " + cTaxMaster + "." + cId + " LEFT OUTER JOIN "
        sql = sql + cHQMaster + " ON " + cSalesMaster + "." + cHQId + "=" + cHQMaster + "." + cId + " LEFT OUTER JOIN "
        sql = sql + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + "=" + cCustomerMaster + "." + cId + " LEFT OUTER JOIN "
        sql = sql + cManufacturerMaster + " ON " + cSalesDetail + "." + cManufacturerId + "=" + cManufacturerMaster + "." + cId + " LEFT OUTER JOIN "
        sql = sql + cItemMaster + " ON " + cSalesDetail + "." + cItemId + "=" + cItemMaster + "." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cSalesMaster + "." + cSaleDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        If hqId > 0 Then sql = sql + " and " + cSalesMaster + "." + cHQId + " = " + CStr(hqId)
        If taxId <> cInvalidId Then sql = sql + " and " + cTaxMaster + "." + cId + " = " + CStr(taxId)

        sql = sql + " GROUP BY "
        sql = sql + cSalesDetail + "." + cItemId + ", "
        sql = sql + cManufacturerMaster + "." + cName + ","
        sql = sql + cItemMaster + "." + cName + ","
        sql = sql + cCustomerMaster + "." + cName + ","
        sql = sql + cHQMaster + "." + cName + ","
        sql = sql + cHQMaster + "." + cAddress + ","
        sql = sql + cSalesMaster + "." + cId + " ,"
        sql = sql + cSalesMaster + "." + cSaleCode + ","
        sql = sql + cSalesMaster + "." + cSaleDate + ","
        sql = sql + cSalesMaster + "." + cTaxPercent + ","
        sql = sql + cSalesMaster + "." + cDiscountAmount + ","
        sql = sql + cTaxMaster + "." + cDisplayName + ","
        sql = sql + GetCompanyGroupByQuery()
        sql = sql + " Order By " + cSalesMaster + "." + cSaleDate

        Return sql
    End Function

#End Region

#Region "VendorWise Purchase"

    Public Function GetVendorWisePurchase(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal vendorId As Integer) As String
        Dim sql As String = ""
        sql = "Select "
        sql = sql + cItemMaster + "." + cName + " AS " + cItemName + ","
        sql = sql + cVendorMaster + "." + cName + ", "
        sql = sql + cPurchaseMaster + "." + cPurchaseDate + ", "
        sql = sql + cPurchaseMaster + "." + cVoucherNo + ", "
        sql = sql + cPurchaseMaster + "." + cPurchaseCode + ", "
        sql = sql + cPurchaseMaster + "." + cTaxPercent + ","
        sql = sql + cPurchaseMaster + "." + cDiscountAmount + ","
        sql = sql + cPurchaseMaster + "." + cMode + ", "
        sql = sql + " SUM(" + cPurchaseDetail + "." + cPurchaseQuantity + " * " + cPurchaseDetail + "." + cPricePurchase + ") AS " + cBillAmount + ", "
        sql = sql + " SUM(" + cPurchaseDetail + "." + cPurchaseQuantity + " * " + cPurchaseDetail + "." + cPricePurchase + " * " + cPurchaseDetail + "." + cDiscountPercent + "/100) AS  Discount , "
        sql = sql + " SUM(" + cPurchaseDetail + "." + cPurchaseQuantity + ") AS PurchaseQty ,"
        sql = sql + " SUM(" + cPurchaseDetail + "." + cFreeQuantity + ") AS FreeQty ,"
        sql = sql + cPurchaseDetail + "." + cBatch + ","
        sql = sql + cPurchaseDetail + "." + cExpiryDate + ","
        sql = sql + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cPurchaseMaster + " LEFT OUTER JOIN "
        sql = sql + cVendorMaster + " ON " + cPurchaseMaster + "." + cVendorId + " = " + cVendorMaster + "." + cId + " LEFT OUTER JOIN "
        sql = sql + cPurchaseDetail + " ON " + cPurchaseMaster + "." + cId + " = " + cPurchaseDetail + "." + cPurchaseId
        sql = sql + " LEFT OUTER JOIN " + cItemMaster + " ON " + cPurchaseDetail + "." + cItemId + "=" + cItemMaster + "." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " WHERE "
        sql = sql + cPurchaseMaster + "." + cPurchaseDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"

        If vendorId > 0 Then sql = sql + " and " + cPurchaseMaster + "." + cVendorId + "=" + CStr(vendorId)

        sql = sql + " GROUP BY "
        sql = sql + cItemMaster + "." + cName + ","
        sql = sql + cVendorMaster + "." + cName + ", "
        sql = sql + cPurchaseMaster + "." + cPurchaseDate + ", "
        sql = sql + cPurchaseMaster + "." + cVoucherNo + ", "
        sql = sql + cPurchaseMaster + "." + cPurchaseCode + ", "
        sql = sql + cPurchaseMaster + "." + cTaxPercent + ","
        sql = sql + cPurchaseMaster + "." + cDiscountAmount + ","
        sql = sql + cPurchaseMaster + "." + cMode + ", "
        sql = sql + cPurchaseMaster + "." + cVendorId + ", "
        sql = sql + cPurchaseDetail + "." + cBatch + ","
        sql = sql + cPurchaseDetail + "." + cExpiryDate + ","
        sql = sql + GetCompanyGroupByQuery()
        sql = sql + " order by " + cPurchaseMaster + "." + cPurchaseDate

        Return sql
    End Function

#End Region

#Region "Journals"

    Public Function GetJournals(ByVal dateFrom As Date, ByVal dateTo As Date) As String
        Dim sql As String = ""
        sql = "Select "
        sql = sql + cJournalEntry + "." + cId + ", "
        sql = sql + cJournalEntry + "." + cJournalNo + ", "
        sql = sql + cJournalEntry + "." + cJournaldate + ", "
        sql = sql + cJournalEntry + "." + cHeadId + ", "
        sql = sql + cJournalEntry + "." + cDrAmount + ", "
        sql = sql + cJournalEntry + "." + cCrAmount + ", "
        sql = sql + cJournalEntry + "." + cRemark + ", "
        sql = sql + cJournalEntry + "." + cInvoiceNo + ", "
        sql = sql + cJournalEntry + "." + cUserId + ", "
        sql = sql + cJournalEntry + "." + cDateOn
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cJournalEntry
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " where " + cJournalEntry + "." + cJournaldate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"

        Return sql
    End Function

#End Region

#Region "Stock"

    Public Function GetStockInHand(ByVal categoryId As Integer, ByVal itemId As Integer, ByVal manufacturerId As Integer, ByVal storageId As Integer, ByVal scheduleId As Integer) As String
        Dim sql As String = ""
        sql = "SELECT SUM(" + cCurrentStock + "." + cCurrentQuantity + ") As " + cQuantity + ", "
        sql = sql + " AVG(" + cCurrentStock + "." + cPricePurchase + ") As " + cPricePurchase + ", "
        sql = sql + cItemMaster + "." + cName + " As " + cItemName + ", "
        sql = sql + cManufacturerMaster + "." + cName + " As " + cManufacturerName + ", "
        sql = sql + cCurrentStock + "." + cBatch + ", "
        sql = sql + cCurrentStock + "." + cExpiryDate + ", "
        sql = sql + cCurrentStock + "." + cPackQuantity + ", "
        sql = sql + GetCompanyAlias()
        sql = sql + " From "
        sql = sql + cCurrentStock + " LEFT OUTER JOIN "
        sql = sql + cItemMaster + " ON " + cItemMaster + "." + cId + " = " + cCurrentStock + "." + cItemId + " LEFT OUTER JOIN "
        sql = sql + cManufacturerMaster + " ON " + cManufacturerMaster + "." + cId + " = " + cItemMaster + "." + cManufacturerId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Group By "
        sql = sql + cCurrentStock + "." + cItemId + ", "
        sql = sql + cItemMaster + "." + cName + ", "
        sql = sql + cManufacturerMaster + "." + cName + ", "
        sql = sql + cItemMaster + "." + cManufacturerId + ", "
        sql = sql + cItemMaster + "." + cCategoryId + ", "
        sql = sql + cItemMaster + "." + cScheduleId + ", "
        sql = sql + cCurrentStock + "." + cStorageId + ", "
        sql = sql + cCurrentStock + "." + cBatch + ", "
        sql = sql + cCurrentStock + "." + cExpiryDate + ", "
        sql = sql + cCurrentStock + "." + cPackQuantity + ", "
        sql = sql + GetCompanyGroupByQuery()
        sql = sql + " Having SUM(" + cCurrentStock + "." + cCurrentQuantity + ") > 0 "
        If categoryId > 0 Then
            sql = sql + " and " + cCategoryId + "=" + CStr(categoryId)
        ElseIf itemId > 0 Then
            sql = sql + " and " + cItemId + "=" + CStr(itemId)
        ElseIf manufacturerId > 0 Then
            sql = sql + " and " + cItemMaster + "." + cManufacturerId + "=" + CStr(manufacturerId)
        ElseIf storageId > 0 Then
            sql = sql + " and " + cCurrentStock + "." + cStorageId + "=" + CStr(storageId)
        ElseIf scheduleId > 0 Then
            sql = sql + " and " + cScheduleId + "=" + CStr(scheduleId)
        End If

        Return sql
    End Function

    Public Function GetItemsAvailability(ByVal flagExceptZeroQuantity As Boolean, ByVal genericId1 As Integer, ByVal genericId2 As Integer, ByVal genericId3 As Integer, ByVal manufacturerId As Integer, ByVal categoryId As Integer, ByVal scheduleId As Integer) As String
        Dim flag As Boolean = False
        Dim sql As String = ""
        sql = "select "
        sql = sql + " sum(" + cCurrentStock + "." + cCurrentQuantity + ")" + " as " + cQuantity + ", "
        sql = sql + " avg(" + cCurrentStock + "." + cPricePurchase + ")" + " as " + cPricePurchase + ", "
        sql = sql + cCurrentStock + "." + cBatch + ", "
        sql = sql + cCurrentStock + "." + cExpiryDate + ", "
        sql = sql + cItemMaster + "." + cPackType + ", "
        sql = sql + "G1." + cName + " as Generic1, "
        sql = sql + "G2." + cName + " as Generic2, "
        sql = sql + "G3." + cName + " as Generic3, "
        sql = sql + cItemMaster + "." + cName + " as " + cItemName + ", "
        sql = sql + cManufacturerMaster + "." + cName + " as " + cManufacturerName + ", "
        sql = sql + cStorageMaster + "." + cName + " as " + cStorageName + ", "
        sql = sql + cCategoryMaster + "." + cName + " as " + cCategoryName + ", "
        sql = sql + cScheduleMaster + "." + cName + " as " + cScheduleName
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " from "
        sql = sql + cCurrentStock
        sql = sql + " left outer join " + cItemMaster + " on " + cItemMaster + "." + cId + "=" + cCurrentStock + "." + cItemId
        sql = sql + " left outer join " + cManufacturerMaster + " on " + cManufacturerMaster + "." + cId + "=" + cItemMaster + "." + cManufacturerId
        sql = sql + " left outer join " + cStorageMaster + " on " + cCurrentStock + "." + cStorageId + "=" + cStorageMaster + "." + cId
        sql = sql + " left outer join " + cCategoryMaster + " on " + cItemMaster + "." + cCategoryId + "=" + cCategoryMaster + "." + cId
        sql = sql + " left outer join " + cScheduleMaster + " on " + cItemMaster + "." + cScheduleId + "=" + cScheduleMaster + "." + cId
        sql = sql + " left outer join " + cGenericMaster + " G1 on " + cItemMaster + "." + cGenericId1 + "= G1." + cId
        sql = sql + " left outer join " + cGenericMaster + " G2 on " + cItemMaster + "." + cGenericId2 + "= G2." + cId
        sql = sql + " left outer join " + cGenericMaster + " G3 on " + cItemMaster + "." + cGenericId3 + "= G3." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " group by "
        sql = sql + cCurrentStock + "." + cItemId + ", "
        sql = sql + cItemMaster + "." + cName + ", "
        sql = sql + cManufacturerMaster + "." + cName + ", "
        sql = sql + cStorageMaster + "." + cName + ", "
        sql = sql + cCategoryMaster + "." + cName + ", "
        sql = sql + cScheduleMaster + "." + cName + ", "
        sql = sql + cItemMaster + "." + cPackType + ", "
        sql = sql + cItemMaster + "." + cManufacturerId + ", "
        sql = sql + cItemMaster + "." + cCategoryId + ", "
        sql = sql + cCurrentStock + "." + cExpiryDate + ", "
        sql = sql + cItemMaster + "." + cScheduleId + ", "
        sql = sql + cCurrentStock + "." + cStorageId + ", "
        sql = sql + cCurrentStock + "." + cBatch + ", "
        sql = sql + cItemMaster + "." + cGenericId1 + ", "
        sql = sql + cItemMaster + "." + cGenericId2 + ", "
        sql = sql + cItemMaster + "." + cGenericId3 + ", "
        sql = sql + "G1." + cName + ", "
        sql = sql + "G2." + cName + ", "
        sql = sql + "G3." + cName + ", "
        sql = sql + GetCompanyGroupByQuery()

        If genericId1 = cInvalidId Then genericId1 = 0
        If genericId2 = cInvalidId Then genericId2 = 0
        If genericId3 = cInvalidId Then genericId3 = 0
        If genericId1 <> 0 Or genericId2 <> 0 Or genericId3 <> 0 Then
            sql = sql + " having ("
            sql = sql + cItemMaster + "." + cGenericId1 + "=" + CStr(genericId1)
            sql = sql + " or " + cItemMaster + "." + cGenericId2 + "=" + CStr(genericId2)
            sql = sql + " or " + cItemMaster + "." + cGenericId3 + "=" + CStr(genericId3)
            sql = sql + ") "
            flag = True
        ElseIf manufacturerId > 0 Then
            sql = sql + " having " + cItemMaster + "." + cManufacturerId + "=" + CStr(manufacturerId)
            flag = True
        ElseIf categoryId > 0 Then
            sql = sql + " having " + cItemMaster + "." + cCategoryId + "=" + CStr(categoryId)
            flag = True
        ElseIf scheduleId > 0 Then
            sql = sql + " having " + cItemMaster + "." + cScheduleId + "=" + CStr(scheduleId)
            flag = True
        End If

        If flagExceptZeroQuantity = True Then
            If flag = True Then
                sql = sql + " and sum(" + cCurrentStock + "." + cCurrentQuantity + ") > 0"
            Else
                sql = sql + " having sum(" + cCurrentStock + "." + cCurrentQuantity + ") > 0"
            End If
        End If

        Return sql
    End Function

    Public Function GetCurrentStockExpiringBetweenDates(ByVal fromDate As Date, ByVal toDate As Date) As String
        Dim Sql As String = ""
        Sql = Sql + " SELECT  "
        Sql = Sql + cItemMaster + "." + cName + ", "
        Sql = Sql + cCurrentStock + ".* "
        Sql = Sql + ", " + GetCompanyAlias()
        Sql = Sql + " FROM "
        Sql = Sql + cCurrentStock + " LEFT OUTER JOIN "
        Sql = Sql + cItemMaster + " ON " + cCurrentStock + "." + cItemId + " = " + cItemMaster + "." + cId
        Sql = Sql + " CROSS JOIN " + cCompanyInfo
        Sql = Sql + " where " + cCurrentStock + "." + cExpiryDate + " between '" + fromDate.ToString("s") + "' and '" + toDate.ToString("s") + "'"
        Sql = Sql + " and " + cCurrentStock + "." + cCurrentQuantity + "> 0"

        Return Sql
    End Function

    Public Function GetStockInDemand(ByVal categoryId As Integer, ByVal itemId As Integer, ByVal manufacturerId As Integer, ByVal storageId As Integer, ByVal scheduleId As Integer) As String
        Dim sql As String = ""
        sql = "SELECT SUM(" + cCurrentStock + "." + cCurrentQuantity + ") As " + cQuantity + ", "
        sql = sql + cItemMaster + "." + cName + " As " + cItemName + ", "
        sql = sql + cManufacturerMaster + "." + cName + " As " + cManufacturerName + ", "
        sql = sql + cCurrentStock + "." + cBatch + ", "
        sql = sql + cCurrentStock + "." + cExpiryDate + ", "
        sql = sql + GetCompanyAlias()
        sql = sql + " From "
        sql = sql + cCurrentStock + " LEFT OUTER JOIN "
        sql = sql + cItemMaster + " ON " + cItemMaster + "." + cId + " = " + cCurrentStock + "." + cItemId + " LEFT OUTER JOIN "
        sql = sql + cManufacturerMaster + " ON " + cManufacturerMaster + "." + cId + " = " + cItemMaster + "." + cManufacturerId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where "
        sql = sql + cCurrentStock + "." + cItemId
        sql = sql + " In (" + GetStockInDemand() + ")"
        sql = sql + " Group By "
        sql = sql + cCurrentStock + "." + cItemId + ", "
        sql = sql + cItemMaster + "." + cName + ", "
        sql = sql + cManufacturerMaster + "." + cName + ", "
        sql = sql + cItemMaster + "." + cManufacturerId + ", "
        sql = sql + cItemMaster + "." + cCategoryId + ", "
        sql = sql + cItemMaster + "." + cScheduleId + ", "
        sql = sql + cCurrentStock + "." + cStorageId + ", "
        sql = sql + cCurrentStock + "." + cBatch + ", "
        sql = sql + cCurrentStock + "." + cExpiryDate + ", "
        sql = sql + GetCompanyGroupByQuery()
        If categoryId > 0 Then
            sql = sql + " having " + cCategoryId + "=" + CStr(categoryId)
        ElseIf itemId > 0 Then
            sql = sql + " having " + cItemId + "=" + CStr(itemId)
        ElseIf manufacturerId > 0 Then
            sql = sql + " having " + cItemMaster + "." + cManufacturerId + "=" + CStr(manufacturerId)
        ElseIf storageId > 0 Then
            sql = sql + " having " + cCurrentStock + "." + cStorageId + "=" + CStr(storageId)
        ElseIf scheduleId > 0 Then
            sql = sql + " having " + cScheduleId + "=" + CStr(scheduleId)
        End If

        sql = sql + " Order By " + cItemMaster + "." + cName

        Return sql
    End Function

    Protected Function GetStockInDemand() As String
        Dim sql As String = ""
        sql = "SELECT " + cCurrentStock + "." + cItemId
        sql = sql + " From "
        sql = sql + cItemMaster + " RIGHT OUTER JOIN "
        sql = sql + cCurrentStock + " ON " + cItemMaster + "." + cId + " = " + cCurrentStock + "." + cItemId
        sql = sql + " Group By "
        sql = sql + cItemMaster + "." + cMinimum + ", "
        sql = sql + cCurrentStock + "." + cItemId + ", "
        sql = sql + cItemMaster + "." + cId
        sql = sql + " Having (SUM(" + cCurrentStock + "." + cCurrentQuantity + ") <= " + cItemMaster + "." + cMinimum + ")"

        Return sql
    End Function

#End Region

#Region "Gross Purchase"

    Public Function GetGrossPurchase(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal vendorId As Integer) As String
        Dim sql As String = ""
        sql = "Select "
        sql = sql + cVendorMaster + "." + cName + ", "
        sql = sql + cPurchaseMaster + "." + cPurchaseDate + ", "
        sql = sql + cPurchaseMaster + "." + cVoucherNo + ", "
        sql = sql + cPurchaseMaster + "." + cPurchaseCode + ", "
        sql = sql + cPurchaseMaster + "." + cTaxPercent + ","
        sql = sql + cPurchaseMaster + "." + cDiscountAmount + ","
        sql = sql + cPurchaseMaster + "." + cMode + ", "
        sql = sql + " SUM(" + cPurchaseDetail + "." + cPurchaseQuantity + " * " + cPurchaseDetail + "." + cPricePurchase + ") AS " + cBillAmount + ", "
        sql = sql + " SUM(" + cPurchaseDetail + "." + cPurchaseQuantity + " * " + cPurchaseDetail + "." + cPricePurchase + " * " + cPurchaseDetail + "." + cDiscountPercent + "/100) AS  Discount , "
        sql = sql + " SUM(" + cPurchaseDetail + "." + cPurchaseQuantity + ") AS PurchaseQty ,"
        sql = sql + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cPurchaseMaster + " INNER JOIN "
        sql = sql + cVendorMaster + " ON " + cPurchaseMaster + "." + cVendorId + " = " + cVendorMaster + "." + cId + " LEFT OUTER JOIN "
        sql = sql + cPurchaseDetail + " ON " + cPurchaseMaster + "." + cId + " = " + cPurchaseDetail + "." + cPurchaseId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " WHERE "
        sql = sql + cPurchaseMaster + "." + cPurchaseDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        If vendorId > 0 Then sql = sql + " and " + cPurchaseMaster + "." + cVendorId + " = " + CStr(vendorId)
        sql = sql + " GROUP BY "
        sql = sql + cVendorMaster + "." + cName + ", "
        sql = sql + cPurchaseMaster + "." + cPurchaseDate + ", "
        sql = sql + cPurchaseMaster + "." + cVoucherNo + ", "
        sql = sql + cPurchaseMaster + "." + cPurchaseCode + ", "
        sql = sql + cPurchaseMaster + "." + cMode + ", "
        sql = sql + cPurchaseMaster + "." + cVendorId + ", "
        sql = sql + cPurchaseMaster + "." + cTaxPercent + ","
        sql = sql + cPurchaseMaster + "." + cDiscountAmount + ","
        sql = sql + GetCompanyGroupByQuery()
        sql = sql + " order by " + cPurchaseMaster + "." + cPurchaseDate

        Return sql
    End Function

#End Region

#Region "Purchase Report"

    Public Function GetPurchase(ByVal dateFrom As Date, ByVal dateTo As Date) As String
        Dim sql As String = ""
        sql = "Select "
        sql = sql + cItemMaster + "." + cName + " AS " + cItemName + ","
        sql = sql + cVendorMaster + "." + cName + ", "
        sql = sql + cPurchaseMaster + "." + cPurchaseDate + ", "
        sql = sql + cPurchaseMaster + "." + cVoucherNo + ", "
        sql = sql + cPurchaseMaster + "." + cPurchaseCode + ", "
        sql = sql + cPurchaseMaster + "." + cTaxPercent + ","
        sql = sql + cPurchaseMaster + "." + cDiscountAmount + ","
        sql = sql + cPurchaseMaster + "." + cMode + ", "
        sql = sql + " SUM(" + cPurchaseDetail + "." + cPurchaseQuantity + " * " + cPurchaseDetail + "." + cPricePurchase + ") AS " + cBillAmount + ", "
        sql = sql + " SUM(" + cPurchaseDetail + "." + cPurchaseQuantity + " * " + cPurchaseDetail + "." + cPricePurchase + " * " + cPurchaseDetail + "." + cDiscountPercent + "/100) AS  Discount , "
        sql = sql + " SUM(" + cPurchaseDetail + "." + cPurchaseQuantity + ") AS PurchaseQty ,"
        sql = sql + " SUM(" + cPurchaseDetail + "." + cFreeQuantity + ") AS FreeQty ,"
        sql = sql + cPurchaseDetail + "." + cBatch + ","
        sql = sql + cPurchaseDetail + "." + cExpiryDate + ","
        sql = sql + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cPurchaseMaster + " LEFT OUTER JOIN "
        sql = sql + cVendorMaster + " ON " + cPurchaseMaster + "." + cVendorId + " = " + cVendorMaster + "." + cId + " LEFT OUTER JOIN "
        sql = sql + cPurchaseDetail + " ON " + cPurchaseMaster + "." + cId + " = " + cPurchaseDetail + "." + cPurchaseId
        sql = sql + " LEFT OUTER JOIN " + cItemMaster + " ON " + cPurchaseDetail + "." + cItemId + "=" + cItemMaster + "." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " WHERE "
        sql = sql + cPurchaseMaster + "." + cPurchaseDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        sql = sql + " GROUP BY "
        sql = sql + cItemMaster + "." + cName + ","
        sql = sql + cVendorMaster + "." + cName + ", "
        sql = sql + cPurchaseMaster + "." + cPurchaseDate + ", "
        sql = sql + cPurchaseMaster + "." + cVoucherNo + ", "
        sql = sql + cPurchaseMaster + "." + cPurchaseCode + ", "
        sql = sql + cPurchaseMaster + "." + cMode + ", "
        sql = sql + cPurchaseMaster + "." + cVendorId + ", "
        sql = sql + cPurchaseMaster + "." + cTaxPercent + ","
        sql = sql + cPurchaseMaster + "." + cDiscountAmount + ","
        sql = sql + cPurchaseDetail + "." + cBatch + ","
        sql = sql + cPurchaseDetail + "." + cExpiryDate + ","
        sql = sql + GetCompanyGroupByQuery()
        sql = sql + " order by " + cPurchaseMaster + "." + cPurchaseDate

        Return sql
    End Function

#End Region

#Region "ItemWise Purchase"

    Public Function GetItemWisePurchase(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal itemId As Integer) As String
        Dim sql As String = ""
        sql = "Select "
        sql = sql + cItemMaster + "." + cName + " AS " + cItemName + ","
        sql = sql + cVendorMaster + "." + cName + ", "
        sql = sql + cPurchaseMaster + "." + cPurchaseDate + ", "
        sql = sql + cPurchaseMaster + "." + cVoucherNo + ", "
        sql = sql + cPurchaseMaster + "." + cPurchaseCode + ", "
        sql = sql + cPurchaseMaster + "." + cTaxPercent + ","
        sql = sql + cPurchaseMaster + "." + cDiscountAmount + ","
        sql = sql + cPurchaseMaster + "." + cMode + ", "
        sql = sql + " SUM(" + cPurchaseDetail + "." + cPurchaseQuantity + " * " + cPurchaseDetail + "." + cPricePurchase + ") AS " + cBillAmount + ", "
        sql = sql + " SUM(" + cPurchaseDetail + "." + cPurchaseQuantity + " * " + cPurchaseDetail + "." + cPricePurchase + " * " + cPurchaseDetail + "." + cDiscountPercent + "/100) AS  Discount , "
        sql = sql + " SUM(" + cPurchaseDetail + "." + cPurchaseQuantity + ") AS PurchaseQty ,"
        sql = sql + " SUM(" + cPurchaseDetail + "." + cFreeQuantity + ") AS FreeQty ,"
        sql = sql + cPurchaseDetail + "." + cBatch + ","
        sql = sql + cPurchaseDetail + "." + cExpiryDate + ","
        sql = sql + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cPurchaseMaster + " LEFT OUTER JOIN "
        sql = sql + cVendorMaster + " ON " + cPurchaseMaster + "." + cVendorId + " = " + cVendorMaster + "." + cId + " LEFT OUTER JOIN "
        sql = sql + cPurchaseDetail + " ON " + cPurchaseMaster + "." + cId + " = " + cPurchaseDetail + "." + cPurchaseId
        sql = sql + " LEFT OUTER JOIN " + cItemMaster + " ON " + cPurchaseDetail + "." + cItemId + "=" + cItemMaster + "." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " WHERE "
        sql = sql + cPurchaseMaster + "." + cPurchaseDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        If itemId > 0 Then sql = sql + " and " + cPurchaseDetail + "." + cItemId + " = " + CStr(itemId)
        sql = sql + " GROUP BY "
        sql = sql + cItemMaster + "." + cName + ","
        sql = sql + cVendorMaster + "." + cName + ", "
        sql = sql + cPurchaseMaster + "." + cPurchaseDate + ", "
        sql = sql + cPurchaseMaster + "." + cVoucherNo + ", "
        sql = sql + cPurchaseMaster + "." + cPurchaseCode + ", "
        sql = sql + cPurchaseMaster + "." + cTaxPercent + ","
        sql = sql + cPurchaseMaster + "." + cDiscountAmount + ","
        sql = sql + cPurchaseMaster + "." + cMode + ", "
        sql = sql + cPurchaseMaster + "." + cVendorId + ", "
        sql = sql + cPurchaseDetail + "." + cBatch + ","
        sql = sql + cPurchaseDetail + "." + cExpiryDate + ","
        sql = sql + GetCompanyGroupByQuery()
        sql = sql + " order by " + cPurchaseMaster + "." + cPurchaseDate

        Return sql
    End Function

#End Region

#Region "Tax for Sales"

    Public Function GetTaxForSales(ByVal dateFrom As Date, ByVal dateTo As Date) As String
        Dim sql As String = ""
        sql = "Select "
        sql = sql + cSalesMaster + "." + cSaleDate + ", "
        sql = sql + cSalesMaster + "." + cSaleCode + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + cTransactionAccount + "." + cCrAmount + ", "
        sql = sql + " SUM("
        sql = sql + cSalesDetail + "." + cSaleQuantity + " * " + cSalesDetail + "." + cPriceSale + " + " + cSalesDetail + "." + cTaxAmount + " - " + cSalesDetail + "." + cDiscountAmount + ") AS " + cBillAmount
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " from "
        sql = sql + cSalesMaster + " INNER JOIN "
        sql = sql + cSalesDetail + " ON " + cSalesMaster + "." + cId + " = " + cSalesDetail + "." + cSaleId + " INNER JOIN "
        sql = sql + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId + " INNER JOIN "
        sql = sql + cTransactionAccount + " ON " + cSalesMaster + "." + cSaleCode + " = " + cTransactionAccount + "." + cVoucherNo
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " WHERE " + cTransactionAccount + "." + cHeadId + " = 16"
        sql = sql + " and " + cSalesMaster + "." + cSaleDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        sql = sql + " GROUP BY "
        sql = sql + cSalesMaster + "." + cSaleDate + ", "
        sql = sql + cSalesMaster + "." + cSaleCode + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + cTransactionAccount + "." + cCrAmount + ", "
        sql = sql + GetCompanyGroupByQuery()

        Return sql
    End Function

#End Region

#Region "Company"

    Public Function GetCompany() As String
        Dim sql As String = ""
        sql = "Select "
        sql = sql + GetCompanyAlias()
        sql = sql + " from " + cCompanyInfo

        Return sql
    End Function

    Public Function GetCompanyLogo() As String
        Dim sql As String = ""
        sql = "Select top 1 Logo "
        sql = sql + " from " + cCompanyInfo

        Return sql
    End Function

#End Region

#Region "Sales"

    Public Function GetSales(ByVal saleId As Long) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + cCustomerMaster + "." + cName + ","
        sql = sql + cCustomerMaster + "." + cAddress + ","
        'sql = sql + cCustomerMaster + "." + cDlNo + ","
        sql = sql + cCustomerMaster + "." + cUpTtNo + ","
        sql = sql + cCustomerMaster + "." + cTinNo + ","
        sql = sql + cCustomerMaster + "." + cCity + ","
        sql = sql + cCustomerMaster + "." + cPin + ","
        sql = sql + cCustomerMaster + "." + cPhoneR + ","
        sql = sql + cCustomerMaster + "." + cPhoneO + ","
        sql = sql + cCustomerMaster + "." + cMobile + ","
        sql = sql + cItemMaster + "." + cName + " AS " + cItemName + ","
        sql = sql + cManufacturerMaster + "." + cName + " AS " + cManufacturer + ","
        sql = sql + cDivisionMaster + "." + cName + " AS " + cDivision + ","
        sql = sql + cTransporter + "." + cName + " AS " + cTransporter + ","
        sql = sql + cHQMaster + "." + cName + " AS " + cHeadQuarter + ","
        sql = sql + cStorageMaster + "." + cName + " AS " + cStorage + ","
        sql = sql + cDoctorMaster + "." + cName + " AS " + cDoctorName + ","
        sql = sql + cSalesDetail + "." + cBatch + ","
        sql = sql + cSalesDetail + "." + cExpiryDate + ","
        sql = sql + cSalesDetail + "." + cPackQuantity + ","
        sql = sql + cSalesDetail + "." + cSaleQuantity + ","
        sql = sql + cSalesDetail + "." + cFreeQuantity + ","
        sql = sql + cSalesDetail + "." + cPricePurchase + ","
        sql = sql + cSalesDetail + "." + cPriceSale + ","
        sql = sql + cSalesDetail + "." + cTaxPercent + " AS " + cTaxPercent + ","
        sql = sql + cSalesDetail + "." + cDiscountPercent + ","
        sql = sql + cSalesDetail + "." + cTaxAmount + ","
        sql = sql + cSalesDetail + "." + cDiscountAmount + " AS " + cSaleDetailDiscount + ","
        sql = sql + cSalesDetail + "." + cRemark + " AS " + cSaleDetailRemark + ","
        sql = sql + cSalesDetail + "." + cForCashOut + " AS " + cCashOut + ","
        sql = sql + cSalesDetail + "." + cManufactureDate + ","
        sql = sql + cSalesDetail + "." + cMRP + ","
        sql = sql + cSalesDetail + "." + cPTR + ","
        sql = sql + cSalesDetail + "." + cPTS + ","
        sql = sql + cSalesDetail + "." + cRate1 + ","
        sql = sql + cSalesDetail + "." + cRate3 + ","
        sql = sql + cSalesDetail + "." + cRate2 + ","
        sql = sql + cSalesMaster + "." + cSaleCode + ","
        sql = sql + cSalesMaster + "." + cMode + ","
        sql = sql + cSalesMaster + "." + cRemark + " AS " + cSaleMasterRemark + ","
        sql = sql + cSalesMaster + "." + cPrescription + ","
        sql = sql + cSalesMaster + "." + cCashOutAmount + ","
        sql = sql + cSalesMaster + "." + cAdjustedAmount + ","
        sql = sql + cSalesMaster + "." + cSaleDate + ","
        sql = sql + cSalesMaster + "." + cCashMemo + ","
        sql = sql + cSalesMaster + "." + cNotClosed + ","
        sql = sql + cSalesMaster + "." + cForCashOut + ","
        sql = sql + cSalesMaster + "." + cDiscountAmount + ","
        sql = sql + cSalesMaster + "." + cPickSlipNo + ","
        sql = sql + cSalesMaster + "." + cOrderNo + ","
        sql = sql + cSalesMaster + "." + cOrderDate + ","
        sql = sql + cSalesMaster + "." + cReference + ","
        sql = sql + cSalesMaster + "." + cDestination + ","
        sql = sql + cSalesMaster + "." + cLRNo + ","
        sql = sql + cSalesMaster + "." + cChequeNo + ","
        sql = sql + cSalesMaster + "." + cCases + ","
        sql = sql + cSalesMaster + "." + cDueDate + ","
        sql = sql + cSalesMaster + "." + cCreditAdjust + ","
        sql = sql + cSalesMaster + "." + cDebitAdjust + ","
        sql = sql + cSalesMaster + "." + cCancelled + ","
        sql = sql + cTaxMaster + "." + cDisplayName + " As " + cTaxName + ","
        sql = sql + cSalesMaster + "." + cTaxPercent + " as TaxPer,"
        sql = sql + cSalesMaster + "." + cFreightCharge + ","
        sql = sql + cSalesMaster + "." + cPreExciseAmount + ","
        sql = sql + CStr(GetTaxOn()) + " as TaxOn,"
        sql = sql + CStr(Math.Abs(CInt(GetTaxOnFree()))) + " as TaxOnFree,"
        sql = sql + cSalesMaster + "." + cLRDate
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cDivisionMaster + " RIGHT OUTER JOIN "
        sql = sql + cTransporter + " RIGHT OUTER JOIN "
        sql = sql + cDoctorMaster + " RIGHT OUTER JOIN "
        sql = sql + cSalesMaster + " LEFT OUTER JOIN "
        sql = sql + cTaxMaster + " ON " + cSalesMaster + "." + cTaxId + " = " + cTaxMaster + "." + cId + " ON " + cDoctorMaster + "." + cId + " = " + cSalesMaster + "." + cDoctorId + " LEFT OUTER JOIN "
        sql = sql + cHQMaster + " ON " + cSalesMaster + "." + cHQId + " = " + cHQMaster + "." + cId + " ON " + cTransporter + "." + cId + " = " + cSalesMaster + "." + cTransporterId + " ON " + cDivisionMaster + "." + cId + " = " + cSalesMaster + "." + cDivisionId + " LEFT OUTER JOIN "
        sql = sql + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId + " LEFT OUTER JOIN "
        sql = sql + cManufacturerMaster + " RIGHT OUTER JOIN "
        sql = sql + cItemMaster + " RIGHT OUTER JOIN "
        sql = sql + cStorageMaster + " RIGHT OUTER JOIN "
        sql = sql + cSalesDetail + " ON " + cStorageMaster + "." + cId + " = " + cSalesDetail + "." + cStorageId + " ON " + cItemMaster + "." + cId + " = " + cSalesDetail + "." + cItemId + " ON " + cManufacturerMaster + "." + cId + " = " + cSalesDetail + "." + cManufacturerId + " ON " + cSalesMaster + "." + cId + " = " + cSalesDetail + "." + cSaleId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cSalesMaster + "." + cId + " = " + CStr(saleId)

        Return sql
    End Function

#End Region

#Region "Sample"

    Public Function GetSample(ByVal sampleId As Long) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + cCustomerMaster + "." + cName + ","
        sql = sql + cCustomerMaster + "." + cAddress + ","
        'sql = sql + cCustomerMaster + "." + cDlNo + ","
        sql = sql + cCustomerMaster + "." + cUpTtNo + ","
        sql = sql + cCustomerMaster + "." + cTinNo + ","
        sql = sql + cCustomerMaster + "." + cCity + ","
        sql = sql + cCustomerMaster + "." + cPin + ","
        sql = sql + cItemMaster + "." + cName + " AS " + cItemName + ","
        sql = sql + cManufacturerMaster + "." + cName + " AS " + cManufacturer + ","
        sql = sql + cDivisionMaster + "." + cName + " AS " + cDivision + ","
        sql = sql + cTransporter + "." + cName + " AS " + cTransporter + ","
        sql = sql + cHQMaster + "." + cName + " AS " + cHeadQuarter + ","
        sql = sql + cStorageMaster + "." + cName + " AS " + cStorage + ","
        sql = sql + cDoctorMaster + "." + cName + " AS " + cDoctorName + ","
        sql = sql + cSampleDetail + "." + cBatch + ","
        sql = sql + cSampleDetail + "." + cExpiryDate + ","
        sql = sql + cSampleDetail + "." + cPackQuantity + ","
        sql = sql + cSampleDetail + "." + cSampleQuantity + ","
        sql = sql + cSampleDetail + "." + cFreeQuantity + ","
        sql = sql + cSampleDetail + "." + cPricePurchase + ","
        sql = sql + cSampleDetail + "." + cPriceSample + ","
        sql = sql + cSampleDetail + "." + cTaxPercent + " AS " + cTaxPercent + ","
        sql = sql + cSampleDetail + "." + cDiscountPercent + ","
        sql = sql + cSampleDetail + "." + cTaxAmount + ","
        sql = sql + cSampleDetail + "." + cDiscountAmount + " AS " + cSampleDetailDiscount + ","
        sql = sql + cSampleDetail + "." + cRemark + " AS " + cSampleDetailRemark + ","
        sql = sql + cSampleDetail + "." + cForCashOut + " AS " + cCashOut + ","
        sql = sql + cSampleDetail + "." + cManufactureDate + ","
        sql = sql + cSampleDetail + "." + cMRP + ","
        sql = sql + cSampleDetail + "." + cPTR + ","
        sql = sql + cSampleDetail + "." + cPTS + ","
        sql = sql + cSampleDetail + "." + cRate1 + ","
        sql = sql + cSampleDetail + "." + cRate3 + ","
        sql = sql + cSampleDetail + "." + cRate2 + ","
        sql = sql + cSampleMaster + "." + cSampleCode + ","
        sql = sql + cSampleMaster + "." + cMode + ","
        sql = sql + cSampleMaster + "." + cRemark + " AS " + cSampleMasterRemark + ","
        sql = sql + cSampleMaster + "." + cPrescription + ","
        sql = sql + cSampleMaster + "." + cCashOutAmount + ","
        sql = sql + cSampleMaster + "." + cAdjustedAmount + ","
        sql = sql + cSampleMaster + "." + cSampleDate + ","
        sql = sql + cSampleMaster + "." + cCashMemo + ","
        sql = sql + cSampleMaster + "." + cNotClosed + ","
        sql = sql + cSampleMaster + "." + cForCashOut + ","
        sql = sql + cSampleMaster + "." + cDiscountAmount + ","
        sql = sql + cSampleMaster + "." + cPickSlipNo + ","
        sql = sql + cSampleMaster + "." + cOrderNo + ","
        sql = sql + cSampleMaster + "." + cOrderDate + ","
        sql = sql + cSampleMaster + "." + cReference + ","
        sql = sql + cSampleMaster + "." + cDestination + ","
        sql = sql + cSampleMaster + "." + cLRNo + ","
        sql = sql + cSampleMaster + "." + cChequeNo + ","
        sql = sql + cSampleMaster + "." + cCases + ","
        sql = sql + cSampleMaster + "." + cDueDate + ","
        sql = sql + cSampleMaster + "." + cCreditAdjust + ","
        sql = sql + cSampleMaster + "." + cDebitAdjust + ","
        sql = sql + cTaxMaster + "." + cDisplayName + " As " + cTaxName + ","
        sql = sql + cSampleMaster + "." + cTaxPercent + " as TaxPer,"
        sql = sql + cSampleMaster + "." + cPreExciseAmount + ","
        sql = sql + cSampleMaster + "." + cLRDate
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cDivisionMaster + " RIGHT OUTER JOIN "
        sql = sql + cTransporter + " RIGHT OUTER JOIN "
        sql = sql + cDoctorMaster + " RIGHT OUTER JOIN "
        sql = sql + cSampleMaster + " LEFT OUTER JOIN "
        sql = sql + cTaxMaster + " ON " + cSampleMaster + "." + cTaxId + " = " + cTaxMaster + "." + cId + " ON " + cDoctorMaster + "." + cId + " = " + cSampleMaster + "." + cDoctorId + " LEFT OUTER JOIN "
        sql = sql + cHQMaster + " ON " + cSampleMaster + "." + cHQId + " = " + cHQMaster + "." + cId + " ON " + cTransporter + "." + cId + " = " + cSampleMaster + "." + cTransporterId + " ON " + cDivisionMaster + "." + cId + " = " + cSampleMaster + "." + cDivisionId + " LEFT OUTER JOIN "
        sql = sql + cCustomerMaster + " ON " + cSampleMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId + " LEFT OUTER JOIN "
        sql = sql + cManufacturerMaster + " RIGHT OUTER JOIN "
        sql = sql + cItemMaster + " RIGHT OUTER JOIN "
        sql = sql + cStorageMaster + " RIGHT OUTER JOIN "
        sql = sql + cSampleDetail + " ON " + cStorageMaster + "." + cId + " = " + cSampleDetail + "." + cStorageId + " ON " + cItemMaster + "." + cId + " = " + cSampleDetail + "." + cItemId + " ON " + cManufacturerMaster + "." + cId + " = " + cSampleDetail + "." + cManufacturerId + " ON " + cSampleMaster + "." + cId + " = " + cSampleDetail + "." + cSampleId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cSampleMaster + "." + cId + " = " + CStr(sampleId)

        Return sql
    End Function

#End Region

#Region "Purchase Order"

    Public Function GetPurchaseOrder(ByVal purchaseOrderId As Long) As String
        Dim Sql As String = ""
        Sql = Sql + " Select "
        Sql = Sql + cPurchaseOrderMaster + "." + cId + ", "
        Sql = Sql + cPurchaseOrderMaster + "." + cOrderDate + ", "
        Sql = Sql + cPurchaseOrderDetail + "." + cOrderQuantity + ", "
        Sql = Sql + cPurchaseOrderDetail + "." + cOrderPrice + ", "
        Sql = Sql + cItemMaster + "." + cName + " AS " + cItemName + ", "
        Sql = Sql + cVendorMaster + "." + cName + " AS " + cVendor
        Sql = Sql + ", " + GetCompanyAlias()
        Sql = Sql + " from "
        Sql = Sql + cPurchaseOrderMaster + " INNER JOIN "
        Sql = Sql + cPurchaseOrderDetail + " ON " + cPurchaseOrderMaster + "." + cId + " = " + cPurchaseOrderDetail + "." + cOrderId + " INNER JOIN "
        Sql = Sql + cItemMaster + " ON " + cPurchaseOrderDetail + "." + cItemId + " = " + cItemMaster + "." + cId + " INNER JOIN "
        Sql = Sql + cVendorMaster + " ON " + cPurchaseOrderDetail + "." + cVendorId + " = " + cVendorMaster + "." + cId
        Sql = Sql + " CROSS JOIN " + cCompanyInfo
        Sql = Sql + " where " + cPurchaseOrderMaster + "." + cId + "=" + CStr(purchaseOrderId)

        Return Sql
    End Function

#End Region

#Region "Destruction Slip"

    Public Function GetDestructionSlip(ByVal destructionId As Long) As String
        Dim Sql As String = ""
        Sql = Sql + " Select "
        Sql = Sql + cDestructionSlipMaster + "." + cId + ", "
        Sql = Sql + cDestructionSlipMaster + "." + cDestructionSlipCode + ", "
        Sql = Sql + cDestructionSlipMaster + "." + cDestructionSlipDate + ", "
        Sql = Sql + cDestructionSlipDetail + "." + cPricePurchase + ", "
        Sql = Sql + cDestructionSlipDetail + "." + cPriceSale + ", "
        Sql = Sql + cItemMaster + "." + cName + ", "
        Sql = Sql + cDestructionSlipDetail + "." + cBatch + ", "
        Sql = Sql + cDestructionSlipDetail + "." + cDestructionQuantity + ", "
        Sql = Sql + cItemMaster + "." + cPackType
        Sql = Sql + ", " + GetCompanyAlias()
        Sql = Sql + " from "
        Sql = Sql + cDestructionSlipMaster + " INNER JOIN "
        Sql = Sql + cDestructionSlipDetail + " ON " + cDestructionSlipMaster + "." + cId + " = " + cDestructionSlipDetail + "." + cDestructionSlipId + " INNER JOIN "
        Sql = Sql + cItemMaster + " ON " + cDestructionSlipDetail + "." + cItemId + " = " + cItemMaster + "." + cId
        Sql = Sql + " CROSS JOIN " + cCompanyInfo
        Sql = Sql + " where " + cDestructionSlipMaster + "." + cId + "=" + CStr(destructionId)

        Return Sql
    End Function

#End Region

#Region "Purchase"

    Public Function GetPurchase(ByVal purchaseId As Long) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + cItemMaster + "." + cName + " AS " + cItemName + ","
        sql = sql + cItemMaster + "." + cPackType + ","
        sql = sql + cManufacturerMaster + "." + cName + " AS Manfacturer ,"
        sql = sql + cVendorMaster + "." + cName + " AS " + cVendor + ","
        sql = sql + cVendorMaster + "." + cAddress + ","
        sql = sql + cVendorMaster + "." + cCity + ","
        sql = sql + cVendorMaster + "." + cPin + ","
        sql = sql + cVendorMaster + "." + cUpTtNo + ","
        sql = sql + cVendorMaster + "." + cTinNo + ","
        sql = sql + cTransactionAccount + "." + cDrAmount + " - " + cTransactionAccount + "." + cCrAmount + " AS ROF, "
        sql = sql + cPurchaseMaster + "." + cId + " AS PurchaseMasterId ,"
        sql = sql + cPurchaseMaster + "." + cPurchaseCode + ","
        sql = sql + cPurchaseMaster + "." + cMode + ","
        sql = sql + cPurchaseMaster + "." + cVoucherNo + ","
        sql = sql + cPurchaseMaster + "." + cOrderId + ","
        sql = sql + cPurchaseMaster + "." + cRemark + " AS MasterRemark ,"
        sql = sql + cPurchaseMaster + "." + cPurchaseDate + ","
        sql = sql + cPurchaseMaster + "." + cNotClosed + ","
        sql = sql + cPurchaseMaster + "." + cDiscountAmount + " AS DiscountAmountMaster ,"
        sql = sql + cPurchaseMaster + "." + cCreditAdjust + ","
        sql = sql + cPurchaseMaster + "." + cDebitAdjust + ","
        sql = sql + cPurchaseMaster + "." + cTaxPercent + ","
        sql = sql + cPurchaseMaster + "." + cPreExciseAmount + ","
        sql = sql + cPurchaseMaster + "." + cFreightCharge + ","
        sql = sql + cTaxMaster + "." + cDisplayName + " As " + cTaxName + ","
        sql = sql + cPurchaseDetail + "." + cId + " AS PurchaseDetailId ,"
        sql = sql + cPurchaseDetail + "." + cPurchaseId + ","
        sql = sql + cPurchaseDetail + "." + cItemId + ","
        sql = sql + cPurchaseDetail + "." + cBatch + ","
        sql = sql + cPurchaseDetail + "." + cExpiryDate + ","
        sql = sql + cPurchaseDetail + "." + cPricePurchase + ","
        sql = sql + cPurchaseDetail + "." + cTaxPercent + ","
        sql = sql + cPurchaseDetail + "." + cDiscountPercent + ","
        sql = sql + cPurchaseDetail + "." + cTaxAmount + ","
        sql = sql + cPurchaseDetail + "." + cDiscountAmount + ","
        sql = sql + cPurchaseDetail + "." + cPurchaseQuantity + ","
        sql = sql + cPurchaseDetail + "." + cFreeQuantity + ","
        sql = sql + cPurchaseDetail + "." + cStorageId + ","
        sql = sql + cPurchaseDetail + "." + cRemark + ","
        sql = sql + cPurchaseDetail + "." + cPackQuantity + ","
        sql = sql + cPurchaseDetail + "." + cManufactureDate + ","
        sql = sql + cPurchaseDetail + "." + cMRP + ","
        sql = sql + cPurchaseDetail + "." + cPTR + ","
        sql = sql + cPurchaseDetail + "." + cPTS + ","
        sql = sql + cPurchaseDetail + "." + cRate1 + ","
        sql = sql + cPurchaseDetail + "." + cRate2 + ","
        sql = sql + cPurchaseDetail + "." + cRate3 + ","
        sql = sql + cPurchaseDetail + "." + cManufacturerId
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " from "
        sql = sql + cPurchaseMaster + " INNER JOIN "
        sql = sql + cPurchaseDetail + " ON " + cPurchaseMaster + "." + cId + "=" + cPurchaseDetail + "." + cPurchaseId
        sql = sql + " INNER JOIN " + cVendorMaster + " ON " + cPurchaseMaster + "." + cVendorId + "=" + cVendorMaster + "." + cId + " LEFT OUTER JOIN "
        sql = sql + cTaxMaster + " ON " + cPurchaseMaster + "." + cTaxId + " = " + cTaxMaster + "." + cId + " LEFT OUTER JOIN "
        sql = sql + cManufacturerMaster + " ON " + cPurchaseDetail + "." + cManufacturerId + "=" + cManufacturerMaster + "." + cId
        sql = sql + " LEFT OUTER JOIN " + cItemMaster + " ON " + cPurchaseDetail + "." + cItemId + "=" + cItemMaster + "." + cId
        sql = sql + " LEFT OUTER JOIN " + cTransactionAccount + " ON " + cPurchaseMaster + "." + cPurchaseCode + " = " + cTransactionAccount + "." + cVoucherNo + " And " + cTransactionAccount + "." + cHeadId + " = " + CStr(cAccountHead_ROF)
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " where " + cPurchaseMaster + "." + cId + "=" + CStr(purchaseId)

        Return sql
    End Function

#End Region

#Region "Purchase Return"

    Public Function GetPurchaseReturn(ByVal purchaseReturnId As Long) As String
        Dim sql As String = ""
        sql = sql + " SELECT "
        sql = sql + cPurchaseReturnMaster + "." + cPurchaseReturnCode + ", "
        sql = sql + cPurchaseReturnMaster + "." + cReturnDate + ", "
        sql = sql + cItemMaster + "." + cName + ", "
        sql = sql + cPurchaseReturnDetail + "." + cBatch + ", "
        sql = sql + cPurchaseReturnDetail + "." + cReturnQuantity + ", "
        sql = sql + cPurchaseReturnDetail + "." + cPricePurchase + ", "
        sql = sql + cPurchaseReturnDetail + "." + cTaxAmount + ", "
        sql = sql + cPurchaseReturnMaster + "." + cDiscountAmount + ", "
        sql = sql + cPurchaseReturnDetail + "." + cNonSaleable + ", "
        sql = sql + cPurchaseReturnDetail + "." + cTaxPercent + ", "
        sql = sql + cPurchaseReturnDetail + "." + cDiscountPercent + ", "
        sql = sql + cPurchaseMaster + "." + cPurchaseCode + ", "
        sql = sql + cVendorMaster + "." + cName + " As " + cVendor + ", "
        sql = sql + cTransactionAccount + "." + cDrAmount + " - " + cTransactionAccount + "." + cCrAmount + " AS ROF "
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " From "
        sql = sql + cPurchaseReturnMaster + " INNER JOIN "
        sql = sql + cPurchaseReturnDetail + " ON " + cPurchaseReturnMaster + "." + cId + " = " + cPurchaseReturnDetail + "." + cPurchaseReturnId
        sql = sql + " INNER JOIN " + cItemMaster + " ON " + cPurchaseReturnDetail + "." + cItemId + " = " + cItemMaster + "." + cId
        sql = sql + " LEFT OUTER JOIN " + cVendorMaster + " ON " + cPurchaseReturnMaster + "." + cVendorId + " = " + cVendorMaster + "." + cId
        sql = sql + " LEFT OUTER JOIN " + cPurchaseMaster + " ON " + cPurchaseReturnDetail + "." + cPurchaseId + " = " + cPurchaseMaster + "." + cId
        sql = sql + " LEFT OUTER JOIN " + cTransactionAccount + " ON " + cPurchaseReturnMaster + "." + cPurchaseReturnCode + " = " + cTransactionAccount + "." + cVoucherNo + " And " + cTransactionAccount + "." + cHeadId + " = " + CStr(cAccountHead_ROF)
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " where " + cPurchaseReturnMaster + "." + cId + "=" + CStr(purchaseReturnId)

        Return sql
    End Function

    Public Function GetPurchaseReturn(ByVal dateFrom As Date, ByVal dateTo As Date) As String
        Dim sql As String = ""
        sql = sql + " Select "
        sql = sql + cPurchaseReturnMaster + "." + cPurchaseReturnCode + ", "
        sql = sql + cPurchaseReturnMaster + "." + cPurchaseId + ", "
        sql = sql + cPurchaseReturnMaster + "." + cReturnDate + ", "
        sql = sql + cItemMaster + "." + cName + ", "
        sql = sql + cPurchaseReturnDetail + "." + cBatch + ", "
        sql = sql + cPurchaseReturnDetail + "." + cReturnQuantity + ", "
        sql = sql + cPurchaseReturnDetail + "." + cFreeQuantity + ", "
        sql = sql + cPurchaseReturnDetail + "." + cPackQuantity + ", "
        sql = sql + cPurchaseReturnDetail + "." + cPricePurchase + ", "
        sql = sql + cPurchaseReturnDetail + "." + cTaxAmount + ", "
        sql = sql + cPurchaseReturnDetail + "." + cDiscountAmount + ","
        sql = sql + cVendorMaster + "." + cName + " AS " + cVendor
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " From "
        sql = sql + cPurchaseReturnMaster + "  INNER JOIN "
        sql = sql + cPurchaseReturnDetail + " ON " + cPurchaseReturnMaster + "." + cId + " = " + cPurchaseReturnDetail + "." + cPurchaseReturnId + "  INNER JOIN "
        sql = sql + cItemMaster + " ON " + cPurchaseReturnDetail + "." + cItemId + " = " + cItemMaster + "." + cId
        sql = sql + " INNER JOIN " + cVendorMaster + " ON " + cPurchaseReturnMaster + "." + cVendorId + " = " + cVendorMaster + "." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cPurchaseReturnMaster + "." + cReturnDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"

        Return sql
    End Function
#End Region

#Region "Sales Return"

    Public Function GetSalesReturn(ByVal salesReturnId As Long) As String
        Dim sql As String = ""
        sql = sql + " SELECT "
        sql = sql + cSalesReturnMaster + "." + cSalesReturnCode + ", "
        sql = sql + cSalesReturnMaster + "." + cReturnDate + ", "
        sql = sql + cItemMaster + "." + cName + ", "
        sql = sql + cSalesReturnDetail + "." + cBatch + ", "
        sql = sql + cSalesReturnDetail + "." + cReturnQuantity + ", "
        sql = sql + cSalesReturnDetail + "." + cPriceSale + ", "
        sql = sql + cSalesReturnDetail + "." + cTaxAmount + ", "
        sql = sql + cSalesReturnMaster + "." + cDiscountAmount + ", "
        sql = sql + cSalesReturnDetail + "." + cNonSaleable + ", "
        sql = sql + cSalesReturnDetail + "." + cTaxPercent + ", "
        sql = sql + cSalesReturnDetail + "." + cDiscountPercent + ", "
        sql = sql + cSalesMaster + "." + cSaleCode + ", "
        sql = sql + cCustomerMaster + "." + cName + " As " + cCustomerName + ", "
        sql = sql + cTransactionAccount + "." + cDrAmount + " - " + cTransactionAccount + "." + cCrAmount + " AS ROF "
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " From "
        sql = sql + cSalesReturnMaster + " INNER JOIN "
        sql = sql + cSalesReturnDetail + " ON " + cSalesReturnMaster + "." + cId + " = " + cSalesReturnDetail + "." + cSalesReturnId
        sql = sql + " INNER JOIN " + cItemMaster + " ON " + cSalesReturnDetail + "." + cItemId + " = " + cItemMaster + "." + cId
        sql = sql + " LEFT OUTER JOIN " + cCustomerMaster + " ON " + cSalesReturnMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId
        sql = sql + " LEFT OUTER JOIN " + cSalesMaster + " ON " + cSalesReturnDetail + "." + cSaleId + " = " + cSalesMaster + "." + cId
        sql = sql + " LEFT OUTER JOIN " + cTransactionAccount + " ON " + cSalesReturnMaster + "." + cSalesReturnCode + " = " + cTransactionAccount + "." + cVoucherNo + " And " + cTransactionAccount + "." + cHeadId + " = " + CStr(cAccountHead_ROF)
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " where " + cSalesReturnMaster + "." + cId + "=" + CStr(salesReturnId)

        Return sql
    End Function

#End Region

#Region "Expiries"

    Public Function GetExpiryDetails(ByVal fromDate As Date, ByVal toDate As Date) As String
        Dim Sql As String = ""
        Sql = Sql + " SELECT  "
        Sql = Sql + cItemMaster + "." + cName + ", "
        Sql = Sql + cExpiryDetail + ".* "
        Sql = Sql + ", " + GetCompanyAlias()
        Sql = Sql + " FROM "
        Sql = Sql + cExpiryDetail + " LEFT OUTER JOIN "
        Sql = Sql + cItemMaster + " ON " + cExpiryDetail + "." + cItemId + " = " + cItemMaster + "." + cId
        Sql = Sql + " CROSS JOIN " + cCompanyInfo
        Sql = Sql + " where " + cExpiryDetail + "." + cDateOn + " between '" + fromDate.ToString("s") + "' and '" + toDate.ToString("s") + "'"

        Return Sql
    End Function

#End Region

#Region "Legal Terms"

    Public Function GetLegalTermsForReport() As String
        Dim sql As String = ""
        sql = sql + "select * from " + cLegalTerms
        sql = sql + " order by " + cId

        Return sql
    End Function

#End Region

#Region "Customerwise Issue Sample"

    Public Function GetCustomerWiseIssueSample(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal customerId As Integer) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + cItemMaster + "." + cName + " AS " + cItemName + ","
        sql = sql + cCustomerMaster + "." + cName + " AS " + cCustomerName + ","
        sql = sql + cSampleMaster + "." + cSampleCode + ","
        sql = sql + cSampleMaster + "." + cSampleDate + ","
        sql = sql + cSampleDetail + "." + cBatch + ","
        sql = sql + cSampleDetail + "." + cExpiryDate + ","
        sql = sql + " SUM(" + cSampleDetail + "." + cSampleQuantity + ") AS SampleQty ,"
        sql = sql + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cSampleMaster + " INNER JOIN "
        sql = sql + cSampleDetail + " ON " + cSampleMaster + "." + cId + "=" + cSampleDetail + "." + cSampleId + " LEFT OUTER JOIN "
        sql = sql + cCustomerMaster + " ON " + cSampleMaster + "." + cCustomerId + "=" + cCustomerMaster + "." + cId + " LEFT OUTER JOIN "
        sql = sql + cHQMaster + " ON " + cSampleMaster + "." + cHQId + "=" + cHQMaster + "." + cId + " LEFT OUTER JOIN "
        sql = sql + cItemMaster + " ON " + cSampleDetail + "." + cItemId + "=" + cItemMaster + "." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cSampleMaster + "." + cSampleDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        If customerId > 0 Then sql = sql + " and " + cSampleMaster + "." + cCustomerId + " = " + CStr(customerId)
        sql = sql + " GROUP BY "
        sql = sql + cCustomerMaster + "." + cAccountId + ", "
        sql = sql + cSampleMaster + "." + cSampleCode + ","
        sql = sql + cSampleMaster + "." + cSampleDate + ","
        sql = sql + cSampleDetail + "." + cBatch + ","
        sql = sql + cSampleDetail + "." + cExpiryDate + ","
        sql = sql + cItemMaster + "." + cId + ","
        sql = sql + cItemMaster + "." + cName + ","
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + GetCompanyGroupByQuery()
        sql = sql + " Order By " + cSampleMaster + "." + cSampleDate

        Return sql
    End Function
#End Region

#Region "Sales Return"

    Public Function GetSalesReturn(ByVal dateFrom As Date, ByVal dateTo As Date) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + cSalesReturnMaster + "." + cSalesReturnCode + ","
        sql = sql + cSalesReturnMaster + "." + cSaleId + ","
        sql = sql + cSalesReturnMaster + "." + cReturnDate + ","
        sql = sql + cSalesReturnMaster + "." + cDiscountAmount + " AS DiscountAmountMaster,"
        sql = sql + cSalesReturnMaster + "." + cStatus + ","
        sql = sql + cSalesReturnDetail + "." + cBatch + ","
        sql = sql + cSalesReturnDetail + "." + cExpiryDate + ","
        sql = sql + cSalesReturnDetail + "." + cReturnQuantity + ","
        sql = sql + cSalesReturnDetail + "." + cPackQuantity + ","
        sql = sql + cSalesReturnDetail + "." + cPriceSale + ","
        sql = sql + cSalesReturnDetail + "." + cDiscountPercent + ","
        sql = sql + cSalesReturnDetail + "." + cTaxAmount + ","
        sql = sql + cSalesReturnDetail + "." + cDiscountAmount + ","
        sql = sql + cSalesReturnDetail + "." + cTaxPercent + ","
        sql = sql + cSalesReturnDetail + "." + cPricePurchase + ","
        sql = sql + cSalesMaster + "." + cSaleCode + ","
        sql = sql + cItemMaster + "." + cName + " AS " + cItemName + ","
        sql = sql + cCustomerMaster + "." + cName + " AS " + cCustomerName + ","
        sql = sql + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cSalesReturnMaster + " INNER JOIN "
        sql = sql + cSalesReturnDetail + " ON " + cSalesReturnMaster + "." + cId + "=" + cSalesReturnDetail + "." + cSalesReturnId + " LEFT OUTER JOIN "
        sql = sql + cSalesMaster + " ON " + cSalesReturnMaster + "." + cSaleId + "=" + cSalesMaster + "." + cId + " LEFT OUTER JOIN "
        sql = sql + cCustomerMaster + " ON " + cSalesReturnMaster + "." + cCustomerId + "=" + cCustomerMaster + "." + cId + " LEFT OUTER JOIN "
        sql = sql + cItemMaster + " ON " + cSalesReturnDetail + "." + cItemId + "=" + cItemMaster + "." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cSalesReturnMaster + "." + cReturnDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"

        Return sql
    End Function
#End Region

#Region "PartyWiseSale"

    Public Function GetPartyWiseSale(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal customerId As Integer) As String
        Dim sql As String = ""

        sql = "SELECT "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " * " + cSalesDetail + "." + cPriceSale + ") AS " + cBillAmount + ", "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " * " + cSalesDetail + "." + cPriceSale + " * " + cSalesDetail + "." + cDiscountPercent + "/100) AS  Discount , "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + ") AS SaleQty ,"
        sql = sql + " SUM(" + cSalesDetail + "." + cFreeQuantity + ") AS FreeQty ,"
        sql = sql + cSalesDetail + "." + cPackQuantity + ","
        sql = sql + cSalesDetail + "." + cPriceSale + ","
        sql = sql + cSalesMaster + "." + cSaleCode + ","
        sql = sql + cSalesMaster + "." + cSaleDate + ","
        sql = sql + cSalesMaster + "." + cTaxPercent + ","
        sql = sql + cSalesMaster + "." + cDiscountAmount + ","
        sql = sql + cItemMaster + "." + cName + " AS " + cItemName + ","
        sql = sql + cCustomerMaster + "." + cName + " AS " + cCustomerName
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cSalesMaster + " LEFT OUTER JOIN "
        sql = sql + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId
        sql = sql + " LEFT OUTER JOIN " + cSalesDetail + " ON " + cSalesMaster + "." + cId + " = " + cSalesDetail + "." + cSaleId
        sql = sql + " LEFT OUTER JOIN " + cItemMaster + " ON " + cSalesDetail + "." + cItemId + " = " + cItemMaster + "." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cSalesMaster + "." + cSaleDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        If customerId > 0 Then sql = sql + " and " + cSalesMaster + "." + cCustomerId + " = " + CStr(customerId)

        sql = sql + " GROUP BY "
        sql = sql + cCustomerMaster + "." + cAccountId + ", "
        sql = sql + cSalesMaster + "." + cSaleCode + ","
        sql = sql + cSalesMaster + "." + cSaleDate + ","
        sql = sql + cSalesMaster + "." + cTaxPercent + ","
        sql = sql + cSalesMaster + "." + cDiscountAmount + ","
        sql = sql + cSalesDetail + "." + cPackQuantity + ","
        sql = sql + cSalesDetail + "." + cPriceSale + ","
        sql = sql + cItemMaster + "." + cId + ","
        sql = sql + cItemMaster + "." + cName + ","
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + GetCompanyGroupByQuery()
        sql = sql + " Order By " + cSalesMaster + "." + cSaleDate

        Return sql
    End Function

#End Region

#Region "Collection Report"

    Public Function GetCollection(ByVal dateFrom As Date, ByVal dateTo As Date) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + cCashReceipt + "." + cToHeadId + ","
        sql = sql + cCashReceipt + "." + cFromHeadId + ","
        sql = sql + cCashReceipt + "." + cAmount + " AS CashAmount, 0 AS ChequeAmount,"
        sql = sql + cCashReceipt + "." + cInvoiceNo + ","
        sql = sql + cCashReceipt + "." + cRemark + ","
        sql = sql + cCashReceipt + "." + cReceiptDate + ","
        sql = sql + cAccountHead + "." + cName
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cCashReceipt + " LEFT OUTER JOIN "
        sql = sql + cAccountHead + " ON " + cCashReceipt + "." + cFromHeadId + "=" + cAccountHead + "." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cCashReceipt + "." + cReceiptDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        sql = sql + " UNION "
        sql = sql + " SELECT "
        sql = sql + cChequeReceipt + "." + cToHeadId + ","
        sql = sql + cChequeReceipt + "." + cFromHeadId + ", 0 AS CashAmount,"
        sql = sql + cChequeReceipt + "." + cAmount + " AS ChequeAmount,"
        sql = sql + cChequeReceipt + "." + cInvoiceNo + ","
        sql = sql + cChequeReceipt + "." + cRemark + ","
        sql = sql + cChequeReceipt + "." + cReceiptDate + ","
        sql = sql + "Acc." + cName
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cChequeReceipt + " LEFT OUTER JOIN "
        sql = sql + cAccountHead + " AS Acc  ON " + cChequeReceipt + "." + cFromHeadId + "= Acc." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cChequeReceipt + "." + cReceiptDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        sql = sql + " Order By " + cReceiptDate

        Return sql
    End Function

#End Region

#Region "Payment Report"

    Public Function GetPayment(ByVal dateFrom As Date, ByVal dateTo As Date) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + cCashPayment + "." + cToHeadId + ","
        sql = sql + cCashPayment + "." + cFromHeadId + ","
        sql = sql + cCashPayment + "." + cAmount + " AS CashAmount,0 As ChequeAmount,"
        sql = sql + cCashPayment + "." + cRemark + ","
        sql = sql + cCashPayment + "." + cPaymentDate + ","
        sql = sql + cAccountHead + "." + cName
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cCashPayment + " LEFT OUTER JOIN "
        sql = sql + cAccountHead + " ON " + cCashPayment + "." + cToHeadId + "=" + cAccountHead + "." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cCashPayment + "." + cPaymentDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        sql = sql + " Union "
        sql = sql + " SELECT "
        sql = sql + cChequePayment + "." + cToHeadId + ","
        sql = sql + cChequePayment + "." + cFromHeadId + ","
        sql = sql + cChequePayment + "." + cAmount + " AS ChequeAmount,0 As CashAmount,"
        sql = sql + cChequePayment + "." + cRemark + ","
        sql = sql + cChequePayment + "." + cPaymentDate + ","
        sql = sql + "Acc." + cName
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cChequePayment + " LEFT OUTER JOIN "
        sql = sql + cAccountHead + " AS Acc ON " + cChequePayment + "." + cToHeadId + "=Acc." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cChequePayment + "." + cPaymentDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        sql = sql + " Order By " + cPaymentDate

        Return sql
    End Function

#End Region

#Region "Stock and Sale Report"

    Public Function GetStockAndSaleII(ByVal dateFrom As Date, ByVal dateTo As Date) As String
        Dim sql As String

        sql = "SELECT "
        sql = sql + cItemMaster + "." + cId + ", "
        sql = sql + cItemMaster + "." + cName + ", "
        sql = sql + " Custom." + cPackQuantity + ", "
        sql = sql + " CustomOp." + cPackQuantity + " as Op" + cPackQuantity + ", "
        sql = sql + " SUM(CustomOp.InQty) - SUM(CustomOp.OutQty) As OpeningQty, "
        sql = sql + " SUM(CustomOp.PriceIn) - SUM(CustomOp.PriceOut) As PriceOpening, "
        sql = sql + " SUM(Custom.InQty) As InQty, "
        sql = sql + " SUM(Custom.OutQty) As OutQty, "
        sql = sql + " SUM(Custom.PriceIn) As PriceIn, "
        sql = sql + " SUM(Custom.PriceOut) As PriceOut "
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " From "
        sql = sql + cItemMaster + " LEFT OUTER JOIN "
        sql = sql + "("

        '********** Sales
        sql = sql + "( SELECT "
        sql = sql + cSalesDetail + "." + cItemId + " AS ItemId, "
        sql = sql + cSalesDetail + "." + cPackQuantity + " AS PackQuantity, "
        sql = sql + CStr(0) + " AS InQty, "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " + " + cSalesDetail + "." + cFreeQuantity + ") As OutQty, "
        sql = sql + CStr(0) + " AS PriceIn, "
        sql = sql + " SUM((" + cSalesDetail + "." + cSaleQuantity + " + " + cSalesDetail + "." + cFreeQuantity + ") * " + cSalesDetail + "." + cPricePurchase + ") As PriceOut "
        sql = sql + " From " + cSalesMaster + " INNER JOIN " + cSalesDetail + " ON " + cSalesMaster + "." + cId + " = " + cSalesDetail + "." + cSaleId
        sql = sql + " Where " + cSalesMaster + "." + cSaleDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        sql = sql + " Group By " + cSalesDetail + "." + cPackQuantity + ", " + cSalesDetail + "." + cItemId + " ) "

        sql = sql + " Union "

        '************ Purchase
        sql = sql + "( SELECT "
        sql = sql + cPurchaseDetail + "." + cItemId + " AS ItemId, "
        sql = sql + cPurchaseDetail + "." + cPackQuantity + " As PackQuantity, "
        sql = sql + " SUM(" + cPurchaseDetail + "." + cFreeQuantity + " + " + cPurchaseDetail + "." + cPurchaseQuantity + ") As InQty, "
        sql = sql + CStr(0) + " AS OutQty, "
        sql = sql + " SUM((" + cPurchaseDetail + "." + cFreeQuantity + " + " + cPurchaseDetail + "." + cPurchaseQuantity + " * " + cPurchaseDetail + "." + cPricePurchase + ")) As PriceIn, "
        sql = sql + CStr(0) + " AS PriceOut "
        sql = sql + " From " + cPurchaseDetail + " INNER JOIN " + cPurchaseMaster + " ON " + cPurchaseDetail + "." + cPurchaseId + " = " + cPurchaseMaster + "." + cId
        sql = sql + " Where " + cPurchaseMaster + "." + cPurchaseDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        sql = sql + " Group By " + cPurchaseDetail + "." + cPackQuantity + ", " + cPurchaseDetail + "." + cItemId + ") "

        sql = sql + ") "
        sql = sql + " Custom ON " + cItemMaster + "." + cId + " = Custom." + cItemId

        '************** Opening Stock
        sql = sql + " LEFT OUTER JOIN "

        sql = sql + "("

        '********** Sales
        sql = sql + "( SELECT "
        sql = sql + cSalesDetail + "." + cItemId + " AS ItemId, "
        sql = sql + cSalesDetail + "." + cPackQuantity + " AS PackQuantity, "
        sql = sql + CStr(0) + " AS InQty, "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " + " + cSalesDetail + "." + cFreeQuantity + ") As OutQty, "
        sql = sql + CStr(0) + " AS PriceIn, "
        sql = sql + " SUM((" + cSalesDetail + "." + cSaleQuantity + " + " + cSalesDetail + "." + cFreeQuantity + ") * " + cSalesDetail + "." + cPricePurchase + ") As PriceOut "
        sql = sql + " From " + cSalesMaster + " INNER JOIN " + cSalesDetail + " ON " + cSalesMaster + "." + cId + " = " + cSalesDetail + "." + cSaleId
        sql = sql + " Where " + cSalesMaster + "." + cSaleDate + " < '" + dateFrom.ToString("s") + "' "
        sql = sql + " Group By " + cSalesDetail + "." + cPackQuantity + ", " + cSalesDetail + "." + cItemId + " ) "

        sql = sql + " Union "

        '************ Purchase
        sql = sql + "( SELECT "
        sql = sql + cPurchaseDetail + "." + cItemId + " AS ItemId, "
        sql = sql + cPurchaseDetail + "." + cPackQuantity + " As PackQuantity, "
        sql = sql + " SUM(" + cPurchaseDetail + "." + cFreeQuantity + " + " + cPurchaseDetail + "." + cPurchaseQuantity + ") As InQty, "
        sql = sql + CStr(0) + " AS OutQty, "
        sql = sql + " SUM((" + cPurchaseDetail + "." + cFreeQuantity + " + " + cPurchaseDetail + "." + cPurchaseQuantity + " * " + cPurchaseDetail + "." + cPricePurchase + ")) As PriceIn, "
        sql = sql + CStr(0) + " AS PriceOut "
        sql = sql + " From " + cPurchaseDetail + " INNER JOIN " + cPurchaseMaster + " ON " + cPurchaseDetail + "." + cPurchaseId + " = " + cPurchaseMaster + "." + cId
        sql = sql + " Where " + cPurchaseMaster + "." + cPurchaseDate + " < '" + dateFrom.ToString("s") + "' "
        sql = sql + " Group By " + cPurchaseDetail + "." + cPackQuantity + ", " + cPurchaseDetail + "." + cItemId + ") "

        sql = sql + ") "
        sql = sql + " CustomOp ON " + cItemMaster + "." + cId + " = CustomOp." + cItemId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Group By "
        sql = sql + cItemMaster + "." + cId + ", "
        sql = sql + cItemMaster + "." + cName + ", "
        sql = sql + "Custom." + cPackQuantity + ", "
        sql = sql + "CustomOp." + cPackQuantity
        sql = sql + "," + GetCompanyGroupByQuery()

        Return sql
    End Function

    Public Function GetStockAndSale(ByVal dateFrom As Date, ByVal dateTo As Date) As String
        Dim sql As String

        sql = "SELECT "
        sql = sql + cItemMaster + "." + cId + ", "
        sql = sql + cItemMaster + "." + cName + ", "
        sql = sql + " Custom." + cPackQuantity + ", "
        sql = sql + " CustomOp." + cPackQuantity + " as Op" + cPackQuantity + ", "
        sql = sql + " SUM(CustomOp.InQty) - SUM(CustomOp.OutQty) As OpeningQty, "
        sql = sql + " SUM(CustomOp.PriceIn) - SUM(CustomOp.PriceOut) As PriceOpening, "
        sql = sql + " SUM(Custom.InQty) As InQty, "
        sql = sql + " SUM(Custom.OutQty) As OutQty, "
        sql = sql + " SUM(Custom.PriceIn) As PriceIn, "
        sql = sql + " SUM(Custom.PriceOut) As PriceOut "
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " From "
        sql = sql + cItemMaster + " LEFT OUTER JOIN "
        sql = sql + "("

        '********** Sales
        sql = sql + "( SELECT "
        sql = sql + cSalesDetail + "." + cItemId + " AS ItemId, "
        sql = sql + cSalesDetail + "." + cPackQuantity + " AS PackQuantity, "
        sql = sql + CStr(0) + " AS InQty, "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " + " + cSalesDetail + "." + cFreeQuantity + ") As OutQty, "
        sql = sql + CStr(0) + " AS PriceIn, "
        sql = sql + " SUM((" + cSalesDetail + "." + cSaleQuantity + " + " + cSalesDetail + "." + cFreeQuantity + ") * " + cSalesDetail + "." + cPricePurchase + ") As PriceOut "
        sql = sql + " From " + cSalesMaster + " INNER JOIN " + cSalesDetail + " ON " + cSalesMaster + "." + cId + " = " + cSalesDetail + "." + cSaleId
        sql = sql + " Where " + cSalesMaster + "." + cSaleDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        sql = sql + " Group By " + cSalesDetail + "." + cPackQuantity + ", " + cSalesDetail + "." + cItemId + " ) "

        sql = sql + " Union "

        '********** Purchase Return
        sql = sql + "( SELECT "
        sql = sql + cPurchaseReturnDetail + "." + cItemId + " AS ItemId, "
        sql = sql + cPurchaseReturnDetail + "." + cPackQuantity + " AS PackQuantity, "
        sql = sql + CStr(0) + " AS InQty, "
        sql = sql + " SUM(" + cPurchaseReturnDetail + "." + cReturnQuantity + " + " + cPurchaseReturnDetail + "." + cFreeQuantity + ") As OutQty, "
        sql = sql + CStr(0) + " AS PriceIn, "
        sql = sql + " SUM((" + cPurchaseReturnDetail + "." + cReturnQuantity + " + " + cPurchaseReturnDetail + "." + cFreeQuantity + ") * " + cPurchaseReturnDetail + "." + cPricePurchase + ") As PriceOut "
        sql = sql + " From " + cPurchaseReturnDetail + " INNER JOIN " + cPurchaseReturnMaster + " ON " + cPurchaseReturnDetail + "." + cPurchaseReturnId + " = " + cPurchaseReturnMaster + "." + cId
        sql = sql + " Where " + cPurchaseReturnMaster + "." + cReturnDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        sql = sql + " Group By " + cPurchaseReturnDetail + "." + cPackQuantity + ", " + cPurchaseReturnDetail + "." + cItemId + ") "

        sql = sql + " Union "

        '************ Purchase
        sql = sql + "( SELECT "
        sql = sql + cPurchaseDetail + "." + cItemId + " AS ItemId, "
        sql = sql + cPurchaseDetail + "." + cPackQuantity + " As PackQuantity, "
        sql = sql + " SUM(" + cPurchaseDetail + "." + cFreeQuantity + " + " + cPurchaseDetail + "." + cPurchaseQuantity + ") As InQty, "
        sql = sql + CStr(0) + " AS OutQty, "
        sql = sql + " SUM((" + cPurchaseDetail + "." + cFreeQuantity + " + " + cPurchaseDetail + "." + cPurchaseQuantity + " * " + cPurchaseDetail + "." + cPricePurchase + ")) As PriceIn, "
        sql = sql + CStr(0) + " AS PriceOut "
        sql = sql + " From " + cPurchaseDetail + " INNER JOIN " + cPurchaseMaster + " ON " + cPurchaseDetail + "." + cPurchaseId + " = " + cPurchaseMaster + "." + cId
        sql = sql + " Where " + cPurchaseMaster + "." + cPurchaseDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        sql = sql + " Group By " + cPurchaseDetail + "." + cPackQuantity + ", " + cPurchaseDetail + "." + cItemId + ") "

        sql = sql + " Union "

        '********* Sample
        sql = sql + "( SELECT "
        sql = sql + cSampleDetail + "." + cItemId + " AS ItemId, "
        sql = sql + cSampleDetail + "." + cPackQuantity + " As PackQuantity, "
        sql = sql + CStr(0) + " AS InQty, "
        sql = sql + " SUM(" + cSampleDetail + "." + cFreeQuantity + " + " + cSampleDetail + "." + cSampleQuantity + ") As OutQty, "
        sql = sql + CStr(0) + " AS PriceIn, "
        sql = sql + " SUM((" + cSampleDetail + "." + cFreeQuantity + " + " + cSampleDetail + "." + cSampleQuantity + " * " + cSampleDetail + "." + cPricePurchase + ")) As PriceOut "
        sql = sql + " From " + cSampleDetail + " INNER JOIN " + cSampleMaster + " ON " + cSampleDetail + "." + cSampleId + " = " + cSampleMaster + "." + cId
        sql = sql + " Where " + cSampleMaster + "." + cSampleDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        sql = sql + " Group By " + cSampleDetail + "." + cPackQuantity + ", " + cSampleDetail + "." + cItemId + ") "

        sql = sql + " Union "

        '************ Sales Return
        sql = sql + "( SELECT "
        sql = sql + cSalesReturnDetail + "." + cItemId + " AS ItemId, "
        sql = sql + cSalesReturnDetail + "." + cPackQuantity + " As PackQuantity, "
        sql = sql + " SUM(" + cSalesReturnDetail + "." + cReturnQuantity + ") As InQty, "
        sql = sql + CStr(0) + " AS OutQty, "
        sql = sql + " SUM(" + cSalesReturnDetail + "." + cReturnQuantity + " * " + cSalesReturnDetail + "." + cPricePurchase + ") As PriceIn, "
        sql = sql + CStr(0) + " AS PriceOut "
        sql = sql + " From " + cSalesReturnDetail + " INNER JOIN " + cSalesReturnMaster + " ON " + cSalesReturnDetail + "." + cSalesReturnId + " = " + cSalesReturnMaster + "." + cId
        sql = sql + " Where " + cSalesReturnMaster + "." + cReturnDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        sql = sql + " Group By " + cSalesReturnDetail + "." + cPackQuantity + ", " + cSalesReturnDetail + "." + cItemId + ") "

        sql = sql + ") "
        sql = sql + " Custom ON " + cItemMaster + "." + cId + " = Custom." + cItemId

        '************** Opening Stock
        sql = sql + " LEFT OUTER JOIN "

        sql = sql + "("

        '********** Sales
        sql = sql + "( SELECT "
        sql = sql + cSalesDetail + "." + cItemId + " AS ItemId, "
        sql = sql + cSalesDetail + "." + cPackQuantity + " AS PackQuantity, "
        sql = sql + CStr(0) + " AS InQty, "
        sql = sql + " SUM(" + cSalesDetail + "." + cSaleQuantity + " + " + cSalesDetail + "." + cFreeQuantity + ") As OutQty, "
        sql = sql + CStr(0) + " AS PriceIn, "
        sql = sql + " SUM((" + cSalesDetail + "." + cSaleQuantity + " + " + cSalesDetail + "." + cFreeQuantity + ") * " + cSalesDetail + "." + cPricePurchase + ") As PriceOut "
        sql = sql + " From " + cSalesMaster + " INNER JOIN " + cSalesDetail + " ON " + cSalesMaster + "." + cId + " = " + cSalesDetail + "." + cSaleId
        sql = sql + " Where " + cSalesMaster + "." + cSaleDate + " < '" + dateFrom.ToString("s") + "' "
        sql = sql + " Group By " + cSalesDetail + "." + cPackQuantity + ", " + cSalesDetail + "." + cItemId + " ) "

        sql = sql + " Union "

        '********** Purchase Return
        sql = sql + "( SELECT "
        sql = sql + cPurchaseReturnDetail + "." + cItemId + " AS ItemId, "
        sql = sql + cPurchaseReturnDetail + "." + cPackQuantity + " AS PackQuantity, "
        sql = sql + CStr(0) + " AS InQty, "
        sql = sql + " SUM(" + cPurchaseReturnDetail + "." + cReturnQuantity + " + " + cPurchaseReturnDetail + "." + cFreeQuantity + ") As OutQty, "
        sql = sql + CStr(0) + " AS PriceIn, "
        sql = sql + " SUM((" + cPurchaseReturnDetail + "." + cReturnQuantity + " + " + cPurchaseReturnDetail + "." + cFreeQuantity + ") * " + cPurchaseReturnDetail + "." + cPricePurchase + ") As PriceOut "
        sql = sql + " From " + cPurchaseReturnDetail + " INNER JOIN " + cPurchaseReturnMaster + " ON " + cPurchaseReturnDetail + "." + cPurchaseReturnId + " = " + cPurchaseReturnMaster + "." + cId
        sql = sql + " Where " + cPurchaseReturnMaster + "." + cReturnDate + " < '" + dateFrom.ToString("s") + "' "
        sql = sql + " Group By " + cPurchaseReturnDetail + "." + cPackQuantity + ", " + cPurchaseReturnDetail + "." + cItemId + ") "

        sql = sql + " Union "

        '************ Purchase
        sql = sql + "( SELECT "
        sql = sql + cPurchaseDetail + "." + cItemId + " AS ItemId, "
        sql = sql + cPurchaseDetail + "." + cPackQuantity + " As PackQuantity, "
        sql = sql + " SUM(" + cPurchaseDetail + "." + cFreeQuantity + " + " + cPurchaseDetail + "." + cPurchaseQuantity + ") As InQty, "
        sql = sql + CStr(0) + " AS OutQty, "
        sql = sql + " SUM((" + cPurchaseDetail + "." + cFreeQuantity + " + " + cPurchaseDetail + "." + cPurchaseQuantity + " * " + cPurchaseDetail + "." + cPricePurchase + ")) As PriceIn, "
        sql = sql + CStr(0) + " AS PriceOut "
        sql = sql + " From " + cPurchaseDetail + " INNER JOIN " + cPurchaseMaster + " ON " + cPurchaseDetail + "." + cPurchaseId + " = " + cPurchaseMaster + "." + cId
        sql = sql + " Where " + cPurchaseMaster + "." + cPurchaseDate + " < '" + dateFrom.ToString("s") + "' "
        sql = sql + " Group By " + cPurchaseDetail + "." + cPackQuantity + ", " + cPurchaseDetail + "." + cItemId + ") "

        sql = sql + " Union "

        '********* Sample
        sql = sql + "( SELECT "
        sql = sql + cSampleDetail + "." + cItemId + " AS ItemId, "
        sql = sql + cSampleDetail + "." + cPackQuantity + " As PackQuantity, "
        sql = sql + CStr(0) + " AS InQty, "
        sql = sql + " SUM(" + cSampleDetail + "." + cFreeQuantity + " + " + cSampleDetail + "." + cSampleQuantity + ") As OutQty, "
        sql = sql + CStr(0) + " AS PriceIn, "
        sql = sql + " SUM((" + cSampleDetail + "." + cFreeQuantity + " + " + cSampleDetail + "." + cSampleQuantity + " * " + cSampleDetail + "." + cPricePurchase + ")) As PriceOut "
        sql = sql + " From " + cSampleDetail + " INNER JOIN " + cSampleMaster + " ON " + cSampleDetail + "." + cSampleId + " = " + cSampleMaster + "." + cId
        sql = sql + " Where " + cSampleMaster + "." + cSampleDate + " < '" + dateFrom.ToString("s") + "' "
        sql = sql + " Group By " + cSampleDetail + "." + cPackQuantity + ", " + cSampleDetail + "." + cItemId + ") "

        sql = sql + " Union "

        '************ Sales Return
        sql = sql + "( SELECT "
        sql = sql + cSalesReturnDetail + "." + cItemId + " AS ItemId, "
        sql = sql + cSalesReturnDetail + "." + cPackQuantity + " As PackQuantity, "
        sql = sql + " SUM(" + cSalesReturnDetail + "." + cReturnQuantity + ") As InQty, "
        sql = sql + CStr(0) + " AS OutQty, "
        sql = sql + " SUM(" + cSalesReturnDetail + "." + cReturnQuantity + " * " + cSalesReturnDetail + "." + cPricePurchase + ") As PriceIn, "
        sql = sql + CStr(0) + " AS PriceOut "
        sql = sql + " From " + cSalesReturnDetail + " INNER JOIN " + cSalesReturnMaster + " ON " + cSalesReturnDetail + "." + cSalesReturnId + " = " + cSalesReturnMaster + "." + cId
        sql = sql + " Where " + cSalesReturnMaster + "." + cReturnDate + " < '" + dateFrom.ToString("s") + "' "
        sql = sql + " Group By " + cSalesReturnDetail + "." + cPackQuantity + ", " + cSalesReturnDetail + "." + cItemId + ") "

        sql = sql + ") "
        sql = sql + " CustomOp ON " + cItemMaster + "." + cId + " = CustomOp." + cItemId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Group By "
        sql = sql + cItemMaster + "." + cId + ", "
        sql = sql + cItemMaster + "." + cName + ", "
        sql = sql + "Custom." + cPackQuantity + ", "
        sql = sql + "CustomOp." + cPackQuantity
        sql = sql + "," + GetCompanyGroupByQuery()

        Return sql
    End Function

#End Region

#Region "Credit Note"

    Public Function GetCreditNote(ByVal creditNoteId As Long) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + cCreditNote + "." + cCode + ", "
        sql = sql + cCreditNote + "." + cNoteDate + ", "
        sql = sql + cCreditNote + "." + cAmount + ", "
        sql = sql + cCreditNote + "." + cRemark + ", "
        sql = sql + cCreditNote + "." + cNarration + ", "
        sql = sql + cAccountHead + "." + cName + " As AccountName, "
        sql = sql + cCustomerMaster + "." + cName + " As " + cCustomerName + ", "
        sql = sql + cCustomerMaster + "." + cAddress + ", "
        sql = sql + cCustomerMaster + "." + cMobile + ", "
        sql = sql + cCustomerMaster + "." + cCity
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " From "
        sql = sql + cCreditNote + " INNER JOIN "
        sql = sql + cAccountHead + " ON " + cCreditNote + "." + cAgainstCode + " = " + cAccountHead + "." + cHeadCode
        sql = sql + " INNER JOIN " + cCustomerMaster + " ON " + cCreditNote + "." + cCustomerCode + " = " + cCustomerMaster + "." + cAccountId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cCreditNote + "." + cId + " = " + CStr(creditNoteId)

        Return sql
    End Function

#End Region

#Region "Debit Note"

    Public Function GetDebitNote(ByVal creditNoteId As Long) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + cDebitNote + "." + cCode + ", "
        sql = sql + cDebitNote + "." + cNoteDate + ", "
        sql = sql + cDebitNote + "." + cAmount + ", "
        sql = sql + cDebitNote + "." + cRemark + ", "
        sql = sql + cDebitNote + "." + cNarration + ", "
        sql = sql + cAccountHead + "." + cName + " As AccountName, "
        sql = sql + cVendorMaster + "." + cName + " As " + cVendor + ", "
        sql = sql + cVendorMaster + "." + cAddress + ", "
        sql = sql + cVendorMaster + "." + cMobile + ", "
        sql = sql + cVendorMaster + "." + cCity
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " From "
        sql = sql + cDebitNote + " INNER JOIN "
        sql = sql + cAccountHead + " ON " + cDebitNote + "." + cAgainstCode + " = " + cAccountHead + "." + cHeadCode
        sql = sql + " INNER JOIN " + cVendorMaster + " ON " + cDebitNote + "." + cVendorCode + " = " + cVendorMaster + "." + cAccountId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cDebitNote + "." + cId + " = " + CStr(creditNoteId)

        Return sql
    End Function

#End Region

#Region "Sale Register"

    Public Function GetSaleRegister(ByVal dateFrom As Date, ByVal dateTo As Date) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + cCustomerMaster + "." + cTinNo + ", "
        sql = sql + cSalesMaster + "." + cSaleCode + ", "
        sql = sql + cSalesMaster + "." + cSaleDate + ", "
        sql = sql + " SUM(" + cSalesMaster + "." + cDebitAdjust + " - " + cSalesMaster + "." + cCreditAdjust + ") As CrDr, "
        sql = sql + " SUM(" + cSalesMaster + "." + cDiscountAmount + ") As Cash, "
        sql = sql + "(" + cTaxMaster + "." + cName + "+ ' ' + Convert(varchar, " + cSalesMaster + "." + cTaxPercent + ") + '%') As Tax, "
        sql = sql + " SUM(" + cTransactionAccount + "." + cDrAmount + ") As " + cBillAmount + ", "
        sql = sql + " SUM(TranAcc1." + cCrAmount + ") As SaleAmount, "
        sql = sql + " SUM(TranAcc3." + cDrAmount + ") As DiscountAmt, "
        sql = sql + " SUM(TranAcc2." + cCrAmount + ") As TaxAmt, "
        sql = sql + " SUM(TranAcc4." + cDrAmount + " - TranAcc4." + cCrAmount + ") As ROF"
        sql = sql + " From "
        sql = sql + cSalesMaster + " INNER JOIN "
        sql = sql + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId
        sql = sql + " INNER JOIN " + cTaxMaster + " ON " + cSalesMaster + "." + cTaxId + " = " + cTaxMaster + "." + cId
        sql = sql + " LEFT OUTER JOIN " + cTransactionAccount + " As TranAcc3 ON " + cSalesMaster + "." + cSaleCode + " = TranAcc3." + cVoucherNo + " And TranAcc3." + cHeadId + " = " + CStr(cAccountHead_Discount)
        sql = sql + " LEFT OUTER JOIN " + cTransactionAccount + " As TranAcc4 ON " + cSalesMaster + "." + cSaleCode + " = TranAcc4." + cVoucherNo + " And TranAcc4." + cHeadId + " = " + CStr(cAccountHead_ROF)
        sql = sql + " LEFT OUTER JOIN " + cTransactionAccount + " As TranAcc2 ON " + cSalesMaster + "." + cSaleCode + " = TranAcc2." + cVoucherNo + " And TranAcc2." + cHeadId + " = " + CStr(cAccountHead_Tax)
        sql = sql + " LEFT OUTER JOIN " + cTransactionAccount + " As TranAcc1 ON " + cSalesMaster + "." + cSaleCode + " = TranAcc1." + cVoucherNo + " And TranAcc1." + cHeadId + " = " + CStr(cAccountHead_Sales)
        sql = sql + " LEFT OUTER JOIN " + cAccountHead + " ON " + cCustomerMaster + "." + cAccountId + " = " + cAccountHead + "." + cHeadCode + " LEFT OUTER JOIN " + cTransactionAccount + " ON " + cAccountHead + "." + cId + " = " + cTransactionAccount + "." + cHeadId + " And " + cSalesMaster + "." + cSaleCode + " = " + cTransactionAccount + "." + cVoucherNo
        sql = sql + " Where " + cSalesMaster + "." + cSaleDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
        sql = sql + " Group By "
        sql = sql + cSalesMaster + "." + cSaleCode + ", "
        sql = sql + cSalesMaster + "." + cSaleDate + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + cCustomerMaster + "." + cTinNo + ", "
        sql = sql + cTaxMaster + "." + cName + ", "
        sql = sql + cSalesMaster + "." + cTaxPercent

        Return sql
    End Function

    'Public Function GetSaleRegister(ByVal dateFrom As Date, ByVal dateTo As Date) As String
    '    Dim sql As String = ""

    '    sql = "Select tbl.* from ("

    '    sql = sql + "SELECT "
    '    sql = sql + "5 As SNo, "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo + ", "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + "'Total' As FieldName, "
    '    sql = sql + " SUM(" + cTransactionAccount + "." + cDrAmount + " - " + cTransactionAccount + "." + cCrAmount + ") As FieldValue "
    '    sql = sql + " From "
    '    sql = sql + cSalesMaster + " INNER JOIN "
    '    sql = sql + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId
    '    sql = sql + " LEFT OUTER JOIN " + cAccountHead + " ON " + cCustomerMaster + "." + cAccountId + " = " + cAccountHead + "." + cHeadCode
    '    sql = sql + " LEFT OUTER JOIN " + cTransactionAccount + " ON " + cAccountHead + "." + cId + " = " + cTransactionAccount + "." + cHeadId + " And " + cSalesMaster + "." + cSaleCode + " = " + cTransactionAccount + "." + cVoucherNo
    '    sql = sql + " Group By "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo

    '    sql = sql + " UNION "

    '    sql = sql + " SELECT "
    '    sql = sql + "1 As SNo, "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo + ", "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + "'Sale Amt' As FieldName, "
    '    sql = sql + " SUM(" + cTransactionAccount + "." + cCrAmount + ") As FieldValue "
    '    sql = sql + " From "
    '    sql = sql + cTransactionAccount + " RIGHT OUTER JOIN "
    '    sql = sql + cSalesMaster + " INNER JOIN "
    '    sql = sql + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId + " ON " + cTransactionAccount + "." + cVoucherNo + " = " + cSalesMaster + "." + cSaleCode + " And " + cTransactionAccount + "." + cHeadId + " = " + CStr(cAccountHead_Sales)
    '    sql = sql + " Group By "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo

    '    sql = sql + " UNION "

    '    sql = sql + " SELECT "
    '    sql = sql + "3 As SNo, "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo + ", "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + "'Dis Amt' As FieldName, "
    '    sql = sql + " SUM(" + cTransactionAccount + "." + cDrAmount + ") As FieldValue "
    '    sql = sql + " From "
    '    sql = sql + cTransactionAccount + " RIGHT OUTER JOIN "
    '    sql = sql + cSalesMaster + " INNER JOIN "
    '    sql = sql + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId + " ON " + cTransactionAccount + "." + cVoucherNo + " = " + cSalesMaster + "." + cSaleCode + " And " + cTransactionAccount + "." + cHeadId + " = " + CStr(cAccountHead_Discount)
    '    sql = sql + " Group By "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo

    '    sql = sql + " UNION "

    '    sql = sql + " SELECT "
    '    sql = sql + "4 As SNo, "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo + ", "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + "'ROF' As FieldName, "
    '    sql = sql + " SUM(" + cTransactionAccount + "." + cDrAmount + " - " + cTransactionAccount + "." + cCrAmount + ") As FieldValue "
    '    sql = sql + " From "
    '    sql = sql + cTransactionAccount + " RIGHT OUTER JOIN "
    '    sql = sql + cSalesMaster + " INNER JOIN "
    '    sql = sql + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId + " ON " + cTransactionAccount + "." + cVoucherNo + " = " + cSalesMaster + "." + cSaleCode + " And " + cTransactionAccount + "." + cHeadId + " = " + CStr(cAccountHead_ROF)
    '    sql = sql + " Group By "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo

    '    sql = sql + " UNION "

    '    sql = sql + " SELECT "
    '    sql = sql + "2 As SNo, "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo + ", "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + "(" + cTaxMaster + "." + cName + "+ ' ' + Convert(varchar, " + cSalesMaster + "." + cTaxPercent + ") + '%') As FieldName, "
    '    sql = sql + " SUM(" + cTransactionAccount + "." + cCrAmount + ") As FieldValue "
    '    sql = sql + " From "
    '    sql = sql + cTaxMaster + " INNER JOIN "
    '    sql = sql + cSalesMaster + " INNER JOIN "
    '    sql = sql + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId + " ON " + cTaxMaster + "." + cId + " = " + cSalesMaster + "." + cTaxId
    '    sql = sql + " LEFT OUTER JOIN " + cTransactionAccount + " ON " + cSalesMaster + "." + cSaleCode + " = " + cTransactionAccount + "." + cVoucherNo + " And " + cTransactionAccount + "." + cHeadId + " = " + CStr(cAccountHead_Tax)
    '    sql = sql + " Group By "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo + ", "
    '    sql = sql + cTaxMaster + "." + cName + ", "
    '    sql = sql + cSalesMaster + "." + cTaxPercent

    '    sql = sql + ") tbl "
    '    sql = sql + " Where tbl." + cSaleDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
    '    sql = sql + " Order by tbl." + cSaleCode + ", tbl.Sno"

    '    Return sql
    'End Function

    'Public Function GetSaleRegister(ByVal dateFrom As Date, ByVal dateTo As Date) As String
    '    Dim sql As String = ""

    '    sql = "Select tbl.* from ("

    '    sql = sql + " SELECT "
    '    sql = sql + "1 As SNo, "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo + ", "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + "'01Sale Amt' As FieldName, "
    '    sql = sql + " SUM(" + cTransactionAccount + "." + cCrAmount + ") As FieldValue "
    '    sql = sql + " From "
    '    sql = sql + cTransactionAccount + " RIGHT OUTER JOIN "
    '    sql = sql + cSalesMaster + " INNER JOIN "
    '    sql = sql + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId + " ON " + cTransactionAccount + "." + cVoucherNo + " = " + cSalesMaster + "." + cSaleCode + " And " + cTransactionAccount + "." + cHeadId + " = " + CStr(cAccountHead_Sales)
    '    sql = sql + " Group By "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo

    '    sql = sql + " UNION "

    '    sql = sql + " SELECT "
    '    sql = sql + "2 As SNo, "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo + ", "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + "('02' + " + cTaxMaster + "." + cName + "+ ' ' + Convert(varchar, " + cSalesMaster + "." + cTaxPercent + ") + '%') As FieldName, "
    '    sql = sql + " SUM(" + cTransactionAccount + "." + cCrAmount + ") As FieldValue "
    '    sql = sql + " From "
    '    sql = sql + cTaxMaster + " INNER JOIN "
    '    sql = sql + cSalesMaster + " INNER JOIN "
    '    sql = sql + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId + " ON " + cTaxMaster + "." + cId + " = " + cSalesMaster + "." + cTaxId
    '    sql = sql + " LEFT OUTER JOIN " + cTransactionAccount + " ON " + cSalesMaster + "." + cSaleCode + " = " + cTransactionAccount + "." + cVoucherNo + " And " + cTransactionAccount + "." + cHeadId + " = " + CStr(cAccountHead_Tax)
    '    sql = sql + " Group By "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo + ", "
    '    sql = sql + cTaxMaster + "." + cName + ", "
    '    sql = sql + cSalesMaster + "." + cTaxPercent

    '    sql = sql + " UNION "

    '    sql = sql + " SELECT "
    '    sql = sql + "3 As SNo, "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo + ", "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + "'03Dis Amt' As FieldName, "
    '    sql = sql + " SUM(" + cTransactionAccount + "." + cDrAmount + ") As FieldValue "
    '    sql = sql + " From "
    '    sql = sql + cTransactionAccount + " RIGHT OUTER JOIN "
    '    sql = sql + cSalesMaster + " INNER JOIN "
    '    sql = sql + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId + " ON " + cTransactionAccount + "." + cVoucherNo + " = " + cSalesMaster + "." + cSaleCode + " And " + cTransactionAccount + "." + cHeadId + " = " + CStr(cAccountHead_Discount)
    '    sql = sql + " Group By "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo

    '    sql = sql + " UNION "

    '    sql = sql + " SELECT "
    '    sql = sql + "4 As SNo, "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo + ", "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + "'04ROF' As FieldName, "
    '    sql = sql + " SUM(" + cTransactionAccount + "." + cDrAmount + " - " + cTransactionAccount + "." + cCrAmount + ") As FieldValue "
    '    sql = sql + " From "
    '    sql = sql + cTransactionAccount + " RIGHT OUTER JOIN "
    '    sql = sql + cSalesMaster + " INNER JOIN "
    '    sql = sql + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId + " ON " + cTransactionAccount + "." + cVoucherNo + " = " + cSalesMaster + "." + cSaleCode + " And " + cTransactionAccount + "." + cHeadId + " = " + CStr(cAccountHead_ROF)
    '    sql = sql + " Group By "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo

    '    sql = sql + " UNION "

    '    sql = sql + "SELECT "
    '    sql = sql + "5 As SNo, "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo + ", "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + "'05Total' As FieldName, "
    '    sql = sql + " SUM(" + cTransactionAccount + "." + cDrAmount + " - " + cTransactionAccount + "." + cCrAmount + ") As FieldValue "
    '    sql = sql + " From "
    '    sql = sql + cSalesMaster + " INNER JOIN "
    '    sql = sql + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId
    '    sql = sql + " LEFT OUTER JOIN " + cAccountHead + " ON " + cCustomerMaster + "." + cAccountId + " = " + cAccountHead + "." + cHeadCode
    '    sql = sql + " LEFT OUTER JOIN " + cTransactionAccount + " ON " + cAccountHead + "." + cId + " = " + cTransactionAccount + "." + cHeadId + " And " + cSalesMaster + "." + cSaleCode + " = " + cTransactionAccount + "." + cVoucherNo
    '    sql = sql + " Group By "
    '    sql = sql + cSalesMaster + "." + cSaleCode + ", "
    '    sql = sql + cSalesMaster + "." + cSaleDate + ", "
    '    sql = sql + cCustomerMaster + "." + cName + ", "
    '    sql = sql + cCustomerMaster + "." + cTinNo

    '    sql = sql + ") tbl "
    '    sql = sql + " Where tbl." + cSaleDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"
    '    sql = sql + " Order by tbl." + cSaleCode + ", tbl.Sno"

    '    Return sql
    'End Function

#End Region

#Region "OutStanding Report"

    Public Function GetOutStanding(ByVal dateFrom As Date, ByVal dateTo As Date) As String
        Dim sql As String = ""
        sql = "Select tbl.* From "
        sql = sql + "(SELECT " + cCustomerMaster + "." + cId + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + cSalesMaster + "." + cSaleCode + " As Code,"
        sql = sql + cSalesMaster + "." + cSaleDate + " As " + cTransactionDate + ", "
        sql = sql + "(SUM(" + cTransactionAccount + "." + cDrAmount + ") - TranAcc." + cDrAmount + ") As OutAmount, 0 As InAmount "
        sql = sql + ", " + GetCompanyAlias()

        sql = sql + " From "
        'sql = sql + cCustomerMaster + " LEFT OUTER JOIN "
        'sql = sql + cTransactionAccount + " INNER JOIN " + cSalesMaster + " ON " + cTransactionAccount + "." + cVoucherNo + "=" + cSalesMaster + "." + cSaleCode
        'sql = sql + " ON " + cCustomerMaster + "." + cId + "=" + cSalesMaster + "." + cCustomerId
        sql = sql + cTransactionAccount + " As TranAcc RIGHT OUTER JOIN "
        sql = sql + cTransactionAccount + " INNER JOIN "
        sql = sql + cSalesMaster + " ON " + cTransactionAccount + "." + cVoucherNo + " = " + cSalesMaster + "." + cSaleCode + " ON TranAcc." + cVoucherNo + " = " + cSalesMaster + "." + cSaleCode + " And TranAcc." + cHeadId + " = " + CStr(cAccountHead_Discount)
        sql = sql + " RIGHT OUTER JOIN " + cCustomerMaster + " ON " + cSalesMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo

        sql = sql + " Where " + cSalesMaster + "." + cSaleDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"

        sql = sql + " Group By "
        sql = sql + cCustomerMaster + "." + cId + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + cSalesMaster + "." + cSaleCode + ", "
        sql = sql + cSalesMaster + "." + cSaleDate + ","
        sql = sql + "TranAcc." + cHeadId + ", "
        sql = sql + "TranAcc." + cDrAmount + ", "
        sql = sql + GetCompanyGroupByQuery()

        sql = sql + " UNION "
        sql = sql + " Select " + cCustomerMaster + "." + cId + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + "'" + cCAP + "' + CONVERT(Varchar," + cCashPayment + "." + cId + ") As Code ,"
        sql = sql + cCashPayment + "." + cPaymentDate + " As " + cTransactionDate + ","
        sql = sql + "SUM(" + cCashPayment + "." + cAmount + ") As OutAmount , 0 As InAmount"
        sql = sql + ", " + GetCompanyAlias()

        sql = sql + " From " + cCashPayment + " RIGHT OUTER JOIN "
        sql = sql + cAccountHead + " ON " + cCashPayment + "." + cToHeadId + " = " + cAccountHead + "." + cId
        sql = sql + " RIGHT OUTER JOIN " + cCustomerMaster + " As " + cCustomerMaster + " ON "
        sql = sql + cAccountHead + "." + cHeadCode + " = " + cCustomerMaster + "." + cAccountId
        sql = sql + " CROSS JOIN " + cCompanyInfo

        sql = sql + " Where " + cCashPayment + "." + cPaymentDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"

        sql = sql + " Group By "
        sql = sql + cCustomerMaster + "." + cId + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + cCashPayment + "." + cPaymentDate + ", "
        sql = sql + cCashPayment + "." + cId + ","
        sql = sql + GetCompanyGroupByQuery()

        sql = sql + " UNION "

        sql = sql + " Select "
        sql = sql + cCustomerMaster + "." + cId + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + "'" + cCHP + "' + CONVERT(Varchar," + cChequePayment + "." + cId + ") As Code, "
        sql = sql + cChequePayment + "." + cPaymentDate + " As " + cTransactionDate + ", "
        sql = sql + "SUM(" + cChequePayment + "." + cAmount + ") As OutAmount, 0 As InAmount "
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " From "
        sql = sql + cAccountHead + " As " + cAccountHead + " LEFT OUTER JOIN "
        sql = sql + cChequePayment + " ON " + cAccountHead + "." + cId + " = " + cChequePayment + "." + cToHeadId
        sql = sql + " RIGHT OUTER JOIN " + cCustomerMaster + " As " + cCustomerMaster + " ON "
        sql = sql + cAccountHead + "." + cHeadCode + " = " + cCustomerMaster + "." + cAccountId
        sql = sql + " CROSS JOIN " + cCompanyInfo

        sql = sql + " Where " + cChequePayment + "." + cPaymentDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"

        sql = sql + " Group By "
        sql = sql + cCustomerMaster + "." + cId + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + cChequePayment + "." + cId + ", "
        sql = sql + cChequePayment + "." + cPaymentDate + ","
        sql = sql + GetCompanyGroupByQuery()

        sql = sql + " UNION "

        sql = sql + "Select "
        sql = sql + cCustomerMaster + "." + cId + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + cSalesReturnMaster + "." + cSalesReturnCode + " As Code, "
        sql = sql + cSalesReturnMaster + "." + cReturnDate + " As " + cTransactionDate + ", "
        sql = sql + "0 As OutAmount, "
        sql = sql + "SUM(" + cTransactionAccount + "." + cCrAmount + ") As InAmount "
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " From "
        sql = sql + cTransactionAccount + " As " + cTransactionAccount + " INNER JOIN "
        sql = sql + cSalesReturnMaster + " ON " + cTransactionAccount + "." + cVoucherNo + " = " + cSalesReturnMaster + "." + cSalesReturnCode
        sql = sql + " RIGHT OUTER JOIN " + cCustomerMaster + " As " + cCustomerMaster + " ON "
        sql = sql + cSalesReturnMaster + "." + cCustomerId + " = " + cCustomerMaster + "." + cId
        sql = sql + " CROSS JOIN " + cCompanyInfo

        sql = sql + " Where " + cSalesReturnMaster + "." + cReturnDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"

        sql = sql + " Group By "
        sql = sql + cCustomerMaster + "." + cId + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + cSalesReturnMaster + "." + cSalesReturnCode + ", "
        sql = sql + cSalesReturnMaster + "." + cReturnDate + ","
        sql = sql + GetCompanyGroupByQuery()

        sql = sql + " UNION "

        sql = sql + "Select "
        sql = sql + cCustomerMaster + "." + cId + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + "'" + cCHR + "' + CONVERT(Varchar," + cChequeReceipt + "." + cId + ") As Code, "
        sql = sql + cChequeReceipt + "." + cReceiptDate + " As " + cTransactionDate + ", "
        sql = sql + "0 As OutAmount, "
        sql = sql + " SUM(" + cChequeReceipt + "." + cAmount + ") As InAmount "
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " From "
        sql = sql + cAccountHead + " As " + cAccountHead + " LEFT OUTER JOIN "
        sql = sql + cChequeReceipt + " ON " + cAccountHead + "." + cId + " = " + cChequeReceipt + "." + cFromHeadId
        sql = sql + " RIGHT OUTER JOIN " + cCustomerMaster + " As " + cCustomerMaster + " ON "
        sql = sql + cAccountHead + "." + cHeadCode + " = " + cCustomerMaster + "." + cAccountId
        sql = sql + " CROSS JOIN " + cCompanyInfo

        sql = sql + " Where " + cChequeReceipt + "." + cReceiptDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"

        sql = sql + " Group By "
        sql = sql + cCustomerMaster + "." + cId + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + cChequeReceipt + "." + cId + ", "
        sql = sql + cChequeReceipt + "." + cReceiptDate + ","
        sql = sql + GetCompanyGroupByQuery()

        sql = sql + " UNION "

        sql = sql + " Select "
        sql = sql + cCustomerMaster + "." + cId + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + "'" + cCAR + "' + CONVERT(varchar, "
        sql = sql + cCashReceipt + "." + cId + ") As Code, "
        sql = sql + cCashReceipt + "." + cReceiptDate + " As " + cTransactionDate + ", "
        sql = sql + "0 As OutAmount, "
        sql = sql + "SUM(" + cCashReceipt + "." + cAmount + ") As InAmount "
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " From "
        sql = sql + cAccountHead + " As " + cAccountHead + " LEFT OUTER JOIN "
        sql = sql + cCashReceipt + " ON " + cAccountHead + "." + cId + " = " + cCashReceipt + "." + cFromHeadId
        sql = sql + " RIGHT OUTER JOIN " + cCustomerMaster + " As " + cCustomerMaster + " ON "
        sql = sql + cAccountHead + "." + cHeadCode + " = " + cCustomerMaster + "." + cAccountId
        sql = sql + " CROSS JOIN " + cCompanyInfo

        sql = sql + " Where " + cCashReceipt + "." + cReceiptDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"

        sql = sql + " Group By "
        sql = sql + cCustomerMaster + "." + cId + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + cCashReceipt + "." + cId + ", "
        sql = sql + cCashReceipt + "." + cReceiptDate + ","
        sql = sql + GetCompanyGroupByQuery()

        sql = sql + " UNION "

        sql = sql + " SELECT "
        sql = sql + cCustomerMaster + "." + cId + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + "'" + cDJE + "' + CONVERT(Varchar," + cJournalEntry + "." + cId + ") As Code, "
        sql = sql + cJournalEntry + "." + cJournaldate + " As " + cTransactionDate + ", "
        sql = sql + " SUM(" + cJournalEntry + "." + cDrAmount + ") As OutAmount, "
        sql = sql + " SUM(" + cJournalEntry + "." + cCrAmount + ") As InAmount "
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " From "
        sql = sql + cCustomerMaster + " INNER JOIN "
        sql = sql + cAccountHead + " ON " + cCustomerMaster + "." + cAccountId + " = " + cAccountHead + "." + cHeadCode + " INNER JOIN "
        sql = sql + cJournalEntry + " ON " + cAccountHead + "." + cId + " = " + cJournalEntry + "." + cHeadId
        sql = sql + " CROSS JOIN " + cCompanyInfo

        sql = sql + " Where " + cJournalEntry + "." + cJournaldate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"

        sql = sql + " Group By " + cCustomerMaster + "." + cId + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + cJournalEntry + "." + cId + ", "
        sql = sql + cJournalEntry + "." + cJournaldate + ", "
        sql = sql + GetCompanyGroupByQuery()

        sql = sql + " UNION "

        sql = sql + " SELECT "
        sql = sql + cCustomerMaster + "." + cId + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + cCreditNote + "." + cCode + ", "
        sql = sql + cCreditNote + "." + cNoteDate + " As " + cTransactionDate + ", "
        sql = sql + " 0 As OutAmount, "
        sql = sql + " SUM(" + cCreditNote + "." + cAmount + ") As InAmount "
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " From "
        sql = sql + cCustomerMaster + " INNER JOIN "
        sql = sql + cCreditNote + " ON " + cCustomerMaster + "." + cAccountId + " = " + cCreditNote + "." + cCustomerCode
        sql = sql + " CROSS JOIN " + cCompanyInfo

        sql = sql + " Where " + cCreditNote + "." + cNoteDate + " between '" + dateFrom.ToString("s") + "' and '" + dateTo.ToString("s") + "'"

        sql = sql + " Group By "
        sql = sql + cCustomerMaster + "." + cId + ", "
        sql = sql + cCustomerMaster + "." + cName + ", "
        sql = sql + cCreditNote + "." + cCode + ", "
        sql = sql + cCreditNote + "." + cNoteDate + ", "
        sql = sql + GetCompanyGroupByQuery()

        sql = sql + ") tbl Order By tbl." + cTransactionDate

        Return sql
    End Function

#End Region

#Region "Cash Receipt"

    Public Function GetCashReceipt(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + cAccountHead + "." + cName + ","
        sql = sql + cCashReceipt + "." + cId + ","
        sql = sql + "'" + cCAR + "'+" + "Convert(Varchar," + cCashReceipt + "." + cId + ") AS Code,"
        sql = sql + cCashReceipt + "." + cAmount + " AS ReceiptAmount ,"
        sql = sql + cCashReceipt + "." + cInvoiceNo + ","
        sql = sql + cCashReceipt + "." + cReceiptDate
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cAccountHead + " INNER JOIN "
        sql = sql + cCashReceipt + " ON " + cAccountHead + "." + cId + "=" + cCashReceipt + "." + cFromHeadId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cCashReceipt + "." + cId + " = " + CStr(id)
        sql = sql + " GROUP BY " + cCashReceipt + "." + cId + ","
        sql = sql + cAccountHead + "." + cName + ","
        sql = sql + cCashReceipt + "." + cAmount + ","
        sql = sql + cCashReceipt + "." + cInvoiceNo + ","
        sql = sql + cCashReceipt + "." + cReceiptDate + ","
        sql = sql + GetCompanyGroupByQuery()

        Return sql
    End Function

#End Region

#Region "Cheque Receipt"

    Public Function GetChequeReceipt(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + cAccountHead + "." + cName + ","
        sql = sql + cChequeReceipt + "." + cChequeNo + ","
        sql = sql + cChequeReceipt + "." + cId + ","
        sql = sql + "'" + cCHR + "'+" + "Convert(Varchar," + cChequeReceipt + "." + cId + ") AS Code,"
        sql = sql + cChequeReceipt + "." + cChequeDate + ","
        sql = sql + cChequeReceipt + "." + cAmount + ","
        sql = sql + cChequeReceipt + "." + cInvoiceNo + ","
        sql = sql + cChequeReceipt + "." + cReceiptDate + ","
        sql = sql + cChequeReceipt + "." + cBankName + ","
        sql = sql + cChequeReceipt + "." + cSendToBank
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cAccountHead + " INNER JOIN "
        sql = sql + cChequeReceipt + " ON " + cAccountHead + "." + cId + "=" + cChequeReceipt + "." + cFromHeadId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cChequeReceipt + "." + cId + " = " + CStr(id)
        sql = sql + " GROUP BY "
        sql = sql + cAccountHead + "." + cName + ","
        sql = sql + cChequeReceipt + "." + cChequeNo + ","
        sql = sql + cChequeReceipt + "." + cId + ","
        sql = sql + cChequeReceipt + "." + cChequeDate + ","
        sql = sql + cChequeReceipt + "." + cAmount + ","
        sql = sql + cChequeReceipt + "." + cInvoiceNo + ","
        sql = sql + cChequeReceipt + "." + cReceiptDate + ","
        sql = sql + cChequeReceipt + "." + cBankName + ","
        sql = sql + cChequeReceipt + "." + cSendToBank + ","
        sql = sql + GetCompanyGroupByQuery()

        Return sql
    End Function

#End Region

#Region "Cash Payment"

    Public Function GetCashPayment(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + cAccountHead + "." + cName + ","
        sql = sql + cCashPayment + "." + cId + ","
        sql = sql + "'" + cCAP + "'+" + "Convert(Varchar," + cCashPayment + "." + cId + ") AS Code,"
        sql = sql + cCashPayment + "." + cAmount + " AS PaymentAmount ,"
        sql = sql + cCashPayment + "." + cBillNo + ","
        sql = sql + cCashPayment + "." + cPaymentDate
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cAccountHead + " INNER JOIN "
        sql = sql + cCashPayment + " ON " + cAccountHead + "." + cId + "=" + cCashPayment + "." + cToHeadId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cCashPayment + "." + cId + " = " + CStr(id)
        sql = sql + " GROUP BY " + cCashPayment + "." + cId + ","
        sql = sql + cAccountHead + "." + cName + ","
        sql = sql + cCashPayment + "." + cAmount + ","
        sql = sql + cCashPayment + "." + cBillNo + ","
        sql = sql + cCashPayment + "." + cPaymentDate + ","
        sql = sql + GetCompanyGroupByQuery()

        Return sql
    End Function

#End Region

#Region "Cheque Payment"

    Public Function GetChequePayment(ByVal id As Long) As String
        Dim sql As String = ""
        sql = "SELECT "
        sql = sql + cAccountHead + "." + cName + ","
        sql = sql + cChequePayment + "." + cChequeNo + ","
        sql = sql + cChequePayment + "." + cId + ","
        sql = sql + "'" + cCHP + "'+" + "Convert(Varchar," + cChequePayment + "." + cId + ") AS Code,"
        sql = sql + cChequePayment + "." + cChequeDate + ","
        sql = sql + cChequePayment + "." + cAmount + ","
        sql = sql + cChequePayment + "." + cBillNo + ","
        sql = sql + cChequePayment + "." + cPaymentDate
        sql = sql + ", " + GetCompanyAlias()
        sql = sql + " FROM "
        sql = sql + cAccountHead + " INNER JOIN "
        sql = sql + cChequePayment + " ON " + cAccountHead + "." + cId + "=" + cChequePayment + "." + cToHeadId
        sql = sql + " CROSS JOIN " + cCompanyInfo
        sql = sql + " Where " + cChequePayment + "." + cId + " = " + CStr(id)
        sql = sql + " GROUP BY "
        sql = sql + cAccountHead + "." + cName + ","
        sql = sql + cChequePayment + "." + cChequeNo + ","
        sql = sql + cChequePayment + "." + cId + ","
        sql = sql + cChequePayment + "." + cChequeDate + ","
        sql = sql + cChequePayment + "." + cAmount + ","
        sql = sql + cChequePayment + "." + cBillNo + ","
        sql = sql + cChequePayment + "." + cPaymentDate + ","
        sql = sql + GetCompanyGroupByQuery()

        Return sql
    End Function

#End Region

End Class
