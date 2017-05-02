'This class is used as record of script functions

Public MustInherit Class ClsScriptFunctions

    'Don't Remove This
    Protected Sub New()
    End Sub

#Region "Common Functions"
    Protected MustOverride Function ResetSeedToZero(ByVal tableName As String) As String
    Public MustOverride Function SQLRound(ByVal value As Double, ByVal uptoPos As UInteger) As String
#End Region

#Region "AccountGroup"
    Public MustOverride Function AccountGroupUpdatable(ByRef accountGroupObj As ClsAccountGroup) As String
    Public MustOverride Function GetAllAccountGroup() As String
    Public MustOverride Function GetAllAccountGroupLike(ByVal fieldName As String, ByVal likeValue As String) As String
    Protected MustOverride Function GetAllAccountGroupIdNameLike(ByVal likeValue As String) As String
    Public MustOverride Function GetAccountGroup(ByVal groupId As Integer) As String
    Protected MustOverride Function GetAccountGroupId(ByVal groupCode As String) As String
    Public MustOverride Function InsertIntoAccountGroup(ByRef accountGroupObj As ClsAccountGroup) As String
    Public MustOverride Function UpdateAccountGroup(ByRef accountGroupObj As ClsAccountGroup) As String
#End Region

#Region "AccountHead"
    Public MustOverride Function AccountHeadUpdatable(ByRef accountHeadObj As ClsAccountHead) As String
    Public MustOverride Function GetAllAccountHead() As String
    Public MustOverride Function GetAllAccountHeadForGroupId(ByVal groupId As Integer) As String
    Public MustOverride Function GetAllAccountHeadLike(ByVal fieldName As String, ByVal likeValue As String) As String
    Protected MustOverride Function GetAllAccountHeadIdNameLike(ByVal name As String) As String
    Public MustOverride Function GetAllAccountHeadForGroupCode(ByVal groupCode As String) As String
    Public MustOverride Function GetAccountHead(ByVal id As Integer) As String
    Public MustOverride Function InsertIntoAccountHead(ByRef accountHeadObj As ClsAccountHead) As String
    Public MustOverride Function UpdateAccountHead(ByRef accountHeadObj As ClsAccountHead) As String
#End Region

#Region "ApplicationValueMaster"
    Public MustOverride Function GetApplicationValueMaster(ByVal name As String) As String
    Public MustOverride Function InsertIntoApplicationValueMaster(ByRef applicationValueMasterObj As ClsApplicationValueMaster) As String
    Public MustOverride Function UpdateApplicationValueMaster(ByRef applicationValueMasterObj As ClsApplicationValueMaster) As String
#End Region

#Region "BranchMaster"
    Public MustOverride Function GetAllBranchMaster() As String
    Public MustOverride Function InsertIntoBranchMaster(ByRef branchMasterObj As ClsBranchMaster) As String
    Public MustOverride Function UpdateBranchMaster(ByRef branchMasterObj As ClsBranchMaster) As String
#End Region

#Region "CashPayment"
    Public MustOverride Function GetAllCashPayment() As String
    Public MustOverride Function GetAllCashPaymentValuesLike(ByVal forField As String, ByVal value As String) As String
    Public MustOverride Function GetAllCashPaymentLikePaymentDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
    Public MustOverride Function GetCashPayment(ByVal id As Long) As String
    Public MustOverride Function InsertIntoCashPayment(ByRef CashPaymentObj As ClsCashPayment) As String
    Public MustOverride Function UpdateCashPayment(ByRef CashPaymentObj As ClsCashPayment) As String
    Public MustOverride Function DeleteCashPayment(ByVal id As Long) As String
#End Region

#Region "CashReceipt"
    Public MustOverride Function GetAllCashReceipt() As String
    Public MustOverride Function GetAllCashReceiptValuesLike(ByVal forField As String, ByVal value As String) As String
    Public MustOverride Function GetAllCashReceiptLikeReceiptDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
    Public MustOverride Function GetCashReceipt(ByVal id As Long) As String
    Public MustOverride Function InsertIntoCashReceipt(ByRef cashReceiptObj As ClsCashReceipt) As String
    Public MustOverride Function UpdateCashReceipt(ByRef cashReceiptObj As ClsCashReceipt) As String
    Public MustOverride Function DeleteCashReceipt(ByVal id As Long) As String
#End Region

#Region "CategoryMaster"
    Public MustOverride Function CategoryMasterUpdatable(ByRef categoryMasterObj As ClsCategoryMaster) As String
    Public MustOverride Function GetAllCategoryMaster() As String
    Protected MustOverride Function GetAllCategoryMasterIdForNameLike(ByVal name As String) As String
    Public MustOverride Function InsertIntoCategoryMaster(ByRef categoryMasterObj As ClsCategoryMaster) As String
    Public MustOverride Function UpdateCategoryMaster(ByRef categoryMasterObj As ClsCategoryMaster) As String
#End Region

#Region "ChequePayment"
    Public MustOverride Function GetAllChequePayment() As String
    Public MustOverride Function GetAllChequePaymentValuesLike(ByVal forField As String, ByVal value As String) As String
    Public MustOverride Function GetAllChequePaymentLikeDate(ByVal fieldName As String, ByVal day As String, ByVal month As String, ByVal year As String) As String
    Public MustOverride Function GetChequePayment(ByVal id As Long) As String
    Public MustOverride Function InsertIntoChequePayment(ByRef chequePaymentObj As ClsChequePayment) As String
    Public MustOverride Function UpdateChequePayment(ByRef chequePaymentObj As ClsChequePayment) As String
    Public MustOverride Function DeleteChequePayment(ByVal id As Long) As String
#End Region

#Region "ChequeReceipt"
    Public MustOverride Function GetAllChequeReceipt() As String
    Public MustOverride Function GetAllBankName() As String
    Public MustOverride Function GetAllChequeReceiptValuesLike(ByVal forField As String, ByVal value As String) As String
    Public MustOverride Function GetAllChequeReceiptLikeDate(ByVal fieldName As String, ByVal day As String, ByVal month As String, ByVal year As String) As String
    Public MustOverride Function GetChequeReceipt(ByVal id As Long) As String
    Public MustOverride Function InsertIntoChequeReceipt(ByRef chequeReceiptObj As ClsChequeReceipt) As String
    Public MustOverride Function UpdateChequeReceipt(ByRef chequeReceiptObj As ClsChequeReceipt) As String
    Public MustOverride Function DeleteChequeReceipt(ByVal id As Long) As String
#End Region

#Region "CompanyInfo"
    Public MustOverride Function GetCompanyInfo() As String
    Public MustOverride Function UpdateCompanyInfo(ByRef companyInfoObj As ClsCompanyInfo) As String
#End Region

#Region "CreditNote"
    Public MustOverride Function GetAllCreditNote() As String
    Public MustOverride Function GetAllCreditNoteValuesLike(ByVal forField As String, ByVal value As String) As String
    Public MustOverride Function GetAllCreditNoteLikeNoteDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
    Public MustOverride Function GetCreditNote(ByVal id As Long) As String
    Public MustOverride Function InsertIntoCreditNote(ByRef creditNoteObj As ClsCreditNote) As String
    Public MustOverride Function UpdateCreditNote(ByRef creditNoteObj As ClsCreditNote) As String
#End Region

#Region "CurrentFreeStock"
    Public MustOverride Function GetAllCurrentFreeStock(ByVal excludeZeroQuantity As Boolean) As String
    Public MustOverride Function GetAllCurrentFreeStockForItemId(ByVal itemId As Integer, ByVal includeZeroQuantity As Boolean) As String
    Public MustOverride Function GetCurrentFreeStockForItemIdAndBatch(ByVal itemId As Integer, ByVal batch As String) As String
    Public MustOverride Function GetCurrentFreeStock(ByVal id As Long) As String
    Public MustOverride Function InsertIntoCurrentFreeStock(ByRef currentFreeStockObj As ClsCurrentFreeStock) As String
    Public MustOverride Function UpdateCurrentFreeStock(ByRef currentFreeStockObj As ClsCurrentFreeStock) As String
#End Region

#Region "CurrentStock"
    Public MustOverride Function GetAllCurrentStock(ByVal excludeZeroQuantity As Boolean) As String
    Public MustOverride Function GetAllCurrentStockForExpiry(ByVal expiryDate As Date) As String
    Public MustOverride Function GetAllCurrentStockForItemId(ByVal itemId As Integer, ByVal includeZeroQuantity As Boolean) As String
    Public MustOverride Function GetCurrentStockForItemIdAndBatch(ByVal itemId As Integer, ByVal batch As String) As String
    Public MustOverride Function GetCurrentStock(ByVal id As Long) As String
    Public MustOverride Function InsertIntoCurrentStock(ByRef currentStockObj As ClsCurrentStock) As String
    Public MustOverride Function UpdateCurrentStock(ByRef currentStockObj As ClsCurrentStock) As String
#End Region

#Region "CustomerMaster"
    Public MustOverride Function GetAllCustomerMaster() As String
    Protected MustOverride Function GetAllCustomerMasterIdNameLike(ByVal likeValue As String) As String
    Protected MustOverride Function GetAllCustomerMasterCodeNameLike(ByVal likeValue As String) As String
    Public MustOverride Function GetAllCustomerMasterLike(ByVal fieldName As String, ByVal likeValue As String) As String
    Public MustOverride Function GetAllCustomerMasterCode() As String
    Public MustOverride Function GetCustomerMasterIdForCode(ByVal code As String) As String
    Protected MustOverride Function GetCustomerMasterCustomerTypeId(ByVal id As Integer) As String
    Public MustOverride Function GetCustomerMaster(ByVal id As Integer) As String
    Public MustOverride Function InsertIntoCustomerMaster(ByRef customerMasterObj As ClsCustomerMaster) As String
    Public MustOverride Function UpdateCustomerMaster(ByRef customerMasterObj As ClsCustomerMaster) As String
#End Region

#Region "CustomerType"
    Public MustOverride Function CustomerTypeUpdatable(ByRef customerTypeObj As ClsCustomerType) As String
    Public MustOverride Function GetAllCustomerType() As String
    Public MustOverride Function GetCustomerType(ByVal id As Integer) As String
    Public MustOverride Function InsertIntoCustomerType(ByRef customerTypeObj As ClsCustomerType) As String
    Public MustOverride Function UpdateCustomerType(ByRef customerTypeObj As ClsCustomerType) As String
#End Region

#Region "CustomerTypePrice"
    Public MustOverride Function GetAllCustomerTypePrice() As String
    Public MustOverride Function GetAllCustomerTypePrice(ByVal itemId As Integer, ByVal batch As String) As String
    Public MustOverride Function GetCustomerTypePrice(ByVal itemId As Integer, ByVal batch As String, ByVal customerId As Integer) As String
    Public MustOverride Function GetCustomerTypePrice(ByVal id As Long) As String
    Public MustOverride Function InsertIntoCustomerTypePrice(ByRef customerTypePriceObj As ClsCustomerTypePrice) As String
    Public MustOverride Function UpdateCustomerTypePrice(ByRef customerTypePriceObj As ClsCustomerTypePrice) As String
#End Region

#Region "DebitNote"
    Public MustOverride Function GetAllDebitNote() As String
    Public MustOverride Function GetAllDebitNoteValuesLike(ByVal forField As String, ByVal value As String) As String
    Public MustOverride Function GetAllDebitNoteLikeNoteDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
    Public MustOverride Function GetDebitNote(ByVal id As Long) As String
    Public MustOverride Function InsertIntoDebitNote(ByRef debitNoteObj As ClsDebitNote) As String
    Public MustOverride Function UpdateDebitNote(ByRef debitNoteObj As ClsDebitNote) As String
#End Region

#Region "DestructionSlipDetail"
    Public MustOverride Function GetAllDestructionSlipDetail() As String
    Public MustOverride Function GetAllDestructionSlipDetailForDestructionSlipId(ByVal destructionSlipId As Long) As String
    Public MustOverride Function GetAllDestructionSlipDetailForDestructionSlipCode(ByVal destructionSlipCode As String) As String
    Public MustOverride Function GetDestructionSlipDetail(ByVal id As Long) As String
    Public MustOverride Function InsertIntoDestructionSlipDetail(ByRef destructionSlipDetailObj As ClsDestructionSlipDetail) As String
    Public MustOverride Function UpdateDestructionSlipDetail(ByRef destructionSlipDetailObj As ClsDestructionSlipDetail) As String
    Public MustOverride Function DeleteDestructionSlipDetail(ByVal id As Long) As String
#End Region

#Region "DestructionSlipMaster"
    Public MustOverride Function GetAllDestructionSlipMaster() As String
    Public MustOverride Function GetAllDestructionSlipMasterValuesLike(ByVal forField As String, ByVal value As String) As String
    Public MustOverride Function GetAllDestructionSlipMasterLikeDestructionDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
    Public MustOverride Function GetDestructionSlipMasterNotClosedForLogin(ByVal loginName As String) As String
    Public MustOverride Function GetDestructionSlipMasterIdNotClosedForLogin(ByVal loginName As String) As String
    Protected MustOverride Function GetDestructionSlipMasterIdForCode(ByVal destructionCode As String) As String
    Public MustOverride Function GetDestructionSlipMaster(ByVal id As Long) As String
    Public MustOverride Function InsertIntoDestructionSlipMaster(ByRef destructionSlipMasterObj As ClsDestructionSlipMaster) As String
    Public MustOverride Function UpdateDestructionSlipMaster(ByRef destructionSlipMasterObj As ClsDestructionSlipMaster) As String
#End Region

#Region "DivisionMaster"
    Public MustOverride Function DivisionMasterUpdatable(ByRef divisionMasterObj As ClsDivisionMaster) As String
    Public MustOverride Function GetAllDivisionMaster() As String
    Protected MustOverride Function GetAllDivisionMasterIdForNameLike(ByVal name As String) As String
    Public MustOverride Function InsertIntoDivisionMaster(ByRef divisionMasterObj As ClsDivisionMaster) As String
    Public MustOverride Function UpdateDivisionMaster(ByRef divisionMasterObj As ClsDivisionMaster) As String
#End Region

#Region "DoctorMaster"
    Public MustOverride Function GetAllDoctorMaster() As String
    Protected MustOverride Function GetAllDoctorMasterIdNameLike(ByVal likeValue As String) As String
    Public MustOverride Function GetAllDoctorMasterLike(ByVal fieldName As String, ByVal likeValue As String) As String
    Public MustOverride Function GetAllDoctorMasterSpecialityLike(ByVal likeValue As String) As String
    Public MustOverride Function InsertIntoDoctorMaster(ByRef doctorMasterObj As ClsDoctorMaster) As String
    Public MustOverride Function UpdateDoctorMaster(ByRef doctorMasterObj As ClsDoctorMaster) As String
#End Region

#Region "ExpiryDetail"
    Public MustOverride Function GetAllExpiryDetail() As String
    Public MustOverride Function GetAllExpiryDetailBetweenDates(ByVal dateFrom As Date, ByVal dateTo As Date) As String
    Public MustOverride Function GetExpiryDetail(ByVal id As Long) As String
    Public MustOverride Function InsertIntoExpiryDetail(ByRef expiryDetailObj As ClsExpiryDetail) As String
    Public MustOverride Function UpdateExpiryDetail(ByRef expiryDetailObj As ClsExpiryDetail) As String
    Public MustOverride Function DeleteExpiryDetail(ByVal id As Long) As String
#End Region

#Region "FreeItemDetail"
    Public MustOverride Function GetAllFreeItemDetail() As String
    Public MustOverride Function GetAllFreeItemDetailForPurchaseId(ByVal purchaseId As Integer) As String
    Public MustOverride Function GetFreeItemDetailLastForItemId(ByVal itemId As Integer, ByVal batch As String) As String
    Public MustOverride Function GetFreeItemDetailLastPriceForItemId(ByVal itemId As Integer) As String
    Public MustOverride Function InsertIntoFreeItemDetail(ByRef freeItemDetailObj As ClsFreeItemDetail) As String
    Public MustOverride Function UpdateFreeItemDetail(ByRef freeItemDetailObj As ClsFreeItemDetail) As String
    Public MustOverride Function DeleteFreeItemDetail(ByVal id As Long) As String
#End Region

#Region "FreeStockTransaction"
    Public MustOverride Function GetAllFreeStockTransaction() As String
    Public MustOverride Function GetAllFreeStockTransactionForSalesId(ByVal salesId As Long) As String
    Public MustOverride Function GetFreeStockTransaction(ByVal id As Long) As String
    Protected MustOverride Function GetFreeStockTransactionTotalForSaleId(ByVal saleId As Long) As String
    Public MustOverride Function InsertIntoFreeStockTransaction(ByRef freeStockTransactionObj As ClsFreeStockTransaction) As String
    Public MustOverride Function UpdateFreeStockTransaction(ByRef freeStockTransactionObj As ClsFreeStockTransaction) As String
    Public MustOverride Function DeleteFreeStockTransaction(ByVal id As Long) As String
#End Region

#Region "GenericMaster"
    Public MustOverride Function GenericMasterUpdatable(ByRef genericMasterObj As ClsGenericMaster) As String
    Public MustOverride Function GetAllGenericMaster() As String
    Protected MustOverride Function GetAllGenericMasterIdForNameLike(ByVal name As String) As String
    Public MustOverride Function InsertIntoGenericMaster(ByRef genericMasterObj As ClsGenericMaster) As String
    Public MustOverride Function UpdateGenericMaster(ByRef genericMasterObj As ClsGenericMaster) As String
#End Region

#Region "HQMaster"
    Public MustOverride Function GetAllHQMaster() As String
    Public MustOverride Function GetAllHQMasterLike(ByVal fieldName As String, ByVal likeValue As String) As String
    Protected MustOverride Function GetAllHQMasterIdForNameLike(ByVal name As String) As String
    Public MustOverride Function InsertIntoHQMaster(ByRef hqMasterObj As ClsHQMaster) As String
    Public MustOverride Function UpdateHQMaster(ByRef hqMasterObj As ClsHQMaster) As String
#End Region

#Region "ItemMaster"
    Public MustOverride Function ItemMasterUpdatable(ByRef itemMasterObj As ClsItemMaster) As String
    Public MustOverride Function GetAllItemMaster() As String
    Public MustOverride Function GetAllItemMaster(ByVal ids As String) As String
    Public MustOverride Function GetAllItemMasterForCategoryId(ByVal categoryId As Integer) As String
    Public MustOverride Function GetAllItemMasterLike(ByVal fieldName As String, ByVal likeValue As String) As String
    Public MustOverride Function InsertIntoItemMaster(ByRef itemMasterObj As ClsItemMaster) As String
    Public MustOverride Function UpdateItemMaster(ByRef itemMasterObj As ClsItemMaster) As String
#End Region

#Region "LegalTerms"
    Public MustOverride Function GetAllLegalTerms() As String
    Public MustOverride Function GetLegalTerms(ByVal id As Integer) As String
    Public MustOverride Function InsertIntoLegalTerms(ByRef legalTermsObj As ClsLegalTerms) As String
    Public MustOverride Function UpdateLegalTerms(ByRef legalTermsObj As ClsLegalTerms) As String
    Public MustOverride Function DeleteLegalTerms(ByVal id As Integer) As String
#End Region

#Region "LoginList"
    Public MustOverride Function UpdateLoginList(ByVal loginId As String, ByVal loginTime As Double) As String
    Public MustOverride Function DeleteFromLoginList(ByVal loginId As String) As String
#End Region

#Region "JournalEntry"
    Public MustOverride Function GetAllJournalEntry() As String
    Public MustOverride Function GetAllJournalEntryForJournal(ByVal journal As String) As String
    Public MustOverride Function GetAllJournalEntryWithDistinctJournalNo() As String
    Public MustOverride Function GetJournalEntry(ByVal id As Long) As String
    Public MustOverride Function InsertIntoJournalEntry(ByRef JournalEntryObj As ClsJournalEntry) As String
    Public MustOverride Function UpdateJournalEntry(ByRef JournalEntryObj As ClsJournalEntry) As String
    Public MustOverride Function DeleteJournalEntry(ByVal id As Long) As String
#End Region

#Region "ManufacturerMaster"
    Public MustOverride Function GetAllManufacturerMaster() As String
    Public MustOverride Function GetAllManufacturerMasterLike(ByVal fieldName As String, ByVal likeValue As String) As String
    Protected MustOverride Function GetAllManufacturerMasterIdForNameLike(ByVal name As String) As String
    Public MustOverride Function InsertIntoManufacturerMaster(ByRef manufacturerMasterObj As ClsManufacturerMaster) As String
    Public MustOverride Function UpdateManufacturerMaster(ByRef manufacturerMasterObj As ClsManufacturerMaster) As String
#End Region

#Region "OpeningStock"
    Public MustOverride Function GetAllOpeningStock() As String
    Public MustOverride Function GetOpeningStockForItemIdAndBatch(ByVal itemId As Integer, ByVal batch As String) As String
    Public MustOverride Function GetOpeningStock(ByVal id As Long) As String
    Public MustOverride Function InsertIntoOpeningStock(ByRef openingStockObj As ClsOpeningStock) As String
    Public MustOverride Function UpdateOpeningStock(ByRef openingStockObj As ClsOpeningStock) As String
    Public MustOverride Function DeleteOpeningStock(ByVal id As Long) As String
#End Region

#Region "PIMaster"
    Public MustOverride Function GetAllPIMaster() As String
    Protected MustOverride Function GetAllPIMasterIdForNameLike(ByVal name As String) As String
    Public MustOverride Function InsertIntoPIMaster(ByRef piMasterObj As ClsPIMaster) As String
    Public MustOverride Function UpdatePIMaster(ByRef piMasterObj As ClsPIMaster) As String
#End Region

#Region "ProfileMaster"
    Public MustOverride Function ProfileMasterUpdatable(ByRef profileMasterObj As ClsProfileMaster) As String
    Public MustOverride Function GetAllProfileMaster() As String
    Public MustOverride Function GetProfileMasterById(ProfileId As Int32) As String
    Public MustOverride Function InsertIntoProfileMaster(ByRef profileMasterObj As ClsProfileMaster) As String
    Public MustOverride Function UpdateProfileMaster(ByRef profileMasterObj As ClsProfileMaster) As String
#End Region

#Region "PurchaseDetail"
    Public MustOverride Function GetAllPurchaseDetail() As String
    Public MustOverride Function GetAllPurchaseDetailForPurchaseId(ByVal purchaseId As Integer) As String
    Public MustOverride Function GetAllPurchaseDetailForPurchaseCode(ByVal purchaseCode As String) As String
    Public MustOverride Function GetAllPurchaseDetailForVendorIdAndBatch(ByVal vendorId As Integer, ByVal batch As String) As String
    Public MustOverride Function GetPurchaseDetailLastForItemId(ByVal itemId As Integer, ByVal batch As String) As String
    Public MustOverride Function GetPurchaseDetailLastPriceForItemId(ByVal itemId As Integer) As String
    Public MustOverride Function InsertIntoPurchaseDetail(ByRef purchaseDetailObj As ClsPurchaseDetail) As String
    Public MustOverride Function UpdatePurchaseDetail(ByRef purchaseDetailObj As ClsPurchaseDetail) As String
    Public MustOverride Function DeletePurchaseDetail(ByVal id As Long) As String
#End Region

#Region "PurchaseMaster"
    Public MustOverride Function GetAllPurchaseMaster() As String
    Public MustOverride Function GetAllPurchaseMasterForVendorCode(ByVal vendorCode As String) As String
    Protected MustOverride Function GetAllPurchaseMasterIdPurchaseCodeLike(ByVal value As String) As String
    Protected MustOverride Function GetPurchaseMasterIdPurchaseCode(ByVal code As String) As String
    Protected MustOverride Function GetAllPurchaseMasterIdForVendorId(ByVal vendorId As Integer) As String
    Public MustOverride Function GetAllPurchaseMasterValuesLike(ByVal forField As String, ByVal value As String) As String
    Public MustOverride Function GetAllPurchaseMasterLikePurchaseDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
    Public MustOverride Function GetPurchaseMasterNotClosedForLogin(ByVal loginName As String) As String
    Public MustOverride Function GetPurchaseMasterIdNotClosedForLogin(ByVal loginName As String) As String
    Public MustOverride Function GetPurchaseMaster(ByVal id As Integer) As String
    Public MustOverride Function InsertIntoPurchaseMaster(ByRef purchaseMasterObj As ClsPurchaseMaster) As String
    Public MustOverride Function UpdatePurchaseMaster(ByRef purchaseMasterObj As ClsPurchaseMaster) As String
#End Region

#Region "Purchase Return Detail"
    Public MustOverride Function GetAllPurchaseReturnDetail() As String
    Public MustOverride Function GetAllPurchaseReturnDetailForPurchaseReturnId(ByVal id As Integer) As String
    Public MustOverride Function GetPurchaseReturnDetailById(ByVal id As Long) As String
    Public MustOverride Function InsertPurchaseReturnDetail(ByRef purchaseReturnDetailObj As ClsPurchaseReturnDetail) As String
    Public MustOverride Function UpdatePurchaseReturnDetail(ByRef purchaseReturnDetailObj As ClsPurchaseReturnDetail) As String
    Public MustOverride Function DeletePurchaseReturnDetail(ByVal id As Long) As String
#End Region

#Region "Purchase Return Master"
    Public MustOverride Function GetAllPurchaseReturnMaster() As String
    Public MustOverride Function GetAllPurchaseReturnMasterValuesLike(ByVal forField As String, ByVal value As String) As String
    Public MustOverride Function GetAllPurchaseReturnMasterLikeReturnDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
    Public MustOverride Function GetPurchaseReturnMasterById(ByVal id As Integer) As String
    Public MustOverride Function GetPurchaseReturnMasterDiscountAmount(ByVal id As Long) As String
    Public MustOverride Function GetPurchaseReturnMasterNotClosedForLogin(ByVal loginName As String) As String
    Public MustOverride Function InsertPurchaseReturnMaster(ByRef purchaseReturnMasterObj As ClsPurchaseReturnMaster) As String
    Public MustOverride Function UpdatePurchaseReturnMaster(ByRef purchaseReturnMasterObj As ClsPurchaseReturnMaster) As String
#End Region

#Region "PurchaseOrderDetail"
    Public MustOverride Function GetAllPurchaseOrderDetail() As String
    Public MustOverride Function GetAllPurchaseOrderDetailForPurchaseOrderId(ByVal purchaseOrderId As Long) As String
    Public MustOverride Function GetPurchaseOrderDetail(ByVal id As Long) As String
    Public MustOverride Function InsertIntoPurchaseOrderDetail(ByRef purchaseOrderDetailObj As ClsPurchaseOrderDetail) As String
    Public MustOverride Function UpdatePurchaseOrderDetail(ByRef purchaseOrderDetailObj As ClsPurchaseOrderDetail) As String
    Public MustOverride Function DeletePurchaseOrderDetail(ByVal id As Long) As String
#End Region

#Region "PurchaseOrderMaster"
    Public MustOverride Function GetAllPurchaseOrderMaster() As String
    Public MustOverride Function GetAllPurchaseOrderMasterValuesLike(ByVal forField As String, ByVal value As String) As String
    Public MustOverride Function GetAllPurchaseOrderMasterLikeOrderDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
    Public MustOverride Function GetPurchaseOrderMasterNotClosedForLogin(ByVal loginName As String) As String
    Public MustOverride Function GetPurchaseOrderMasterIdNotClosedForLogin(ByVal loginName As String) As String
    Public MustOverride Function GetPurchaseOrderMaster(ByVal id As Long) As String
    Public MustOverride Function InsertIntoPurchaseOrderMaster(ByRef purchaseOrderMasterObj As ClsPurchaseOrderMaster) As String
    Public MustOverride Function UpdatePurchaseOrderMaster(ByRef purchaseOrderMasterObj As ClsPurchaseOrderMaster) As String
#End Region

#Region "SalesDetail"
    Public MustOverride Function GetAllSalesDetail() As String
    Public MustOverride Function GetAllSalesDetailForSalesId(ByVal salesId As Long) As String
    Public MustOverride Function GetAllSalesDetailForSaleIds(ByVal saleIds As String) As String
    Public MustOverride Function GetAllSalesDetailForCustomerIdAndBatch(ByVal customerId As Integer, ByVal batch As String) As String
    Public MustOverride Function GetAllSalesDetailForSalesCode(ByVal salesCode As String) As String
    Public MustOverride Function GetSalesDetail(ByVal id As Long) As String
    Protected MustOverride Function GetSalesDetailTotalForSaleId(ByVal saleId As Long) As String
    Public MustOverride Function InsertIntoSalesDetail(ByRef salesDetailObj As ClsSalesDetail) As String
    Public MustOverride Function UpdateSalesDetail(ByRef salesDetailObj As ClsSalesDetail) As String
    Public MustOverride Function DeleteSalesDetail(ByVal id As Long) As String
#End Region

#Region "SalesMaster"
    Public MustOverride Function GetAllSalesMaster() As String
    Public MustOverride Function GetAllSalesMasterForCashOut() As String
    Public MustOverride Function GetAllSalesMasterForLRNo() As String
    Public MustOverride Function GetAllSalesMasterForCustomerCode(ByVal customerCode As String) As String
    Protected MustOverride Function GetAllSalesMasterIdForCustomerId(ByVal customerId As Integer) As String
    Public MustOverride Function GetAllSalesMasterValuesLike(ByVal forField As String, ByVal value As String) As String
    Public MustOverride Function GetAllSalesMasterLikeSaleDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
    Protected MustOverride Function GetAllSalesMasterIdSaleCodeLike(ByVal value As String) As String
    Public MustOverride Function GetAllSalesMasterForDateOn(ByVal dateFrom As Date, ByVal dateTo As Date) As String
    Protected MustOverride Function GetSalesMasterIdSaleCode(ByVal code As String) As String
    Public MustOverride Function GetSalesMasterNotClosedForLogin(ByVal loginName As String) As String
    Public MustOverride Function GetSalesMasterIdNotClosedForLogin(ByVal loginName As String) As String
    Public MustOverride Function GetSalesMaster(ByVal id As Long) As String
    Public MustOverride Function GetSalesMasterNetAmount(ByVal id As Long) As String
    Public MustOverride Function GetSalesMasterDiscountAmount(ByVal id As Long) As String
    Public MustOverride Function InsertIntoSalesMaster(ByRef salesMasterObj As ClsSalesMaster) As String
    Public MustOverride Function UpdateSalesMaster(ByRef salesMasterObj As ClsSalesMaster) As String
#End Region

#Region "SalesReturnDetail"
    Public MustOverride Function GetAllSalesReturnDetail() As String
    Public MustOverride Function GetAllSalesReturnDetailForSalesReturnId(ByVal salesReturnId As Long) As String
    Public MustOverride Function GetSalesReturnDetail(ByVal id As Long) As String
    Public MustOverride Function InsertIntoSalesReturnDetail(ByRef salesReturnDetailsObj As ClsSalesReturnDetail) As String
    Public MustOverride Function UpdateSalesReturnDetail(ByRef salesReturnDetailsObj As ClsSalesReturnDetail) As String
    Public MustOverride Function DeleteSalesReturnDetail(ByVal id As Long) As String
#End Region

#Region "SalesReturnMaster"
    Public MustOverride Function GetAllSalesReturnMaster() As String
    Public MustOverride Function GetAllSalesReturnMasterValuesLike(ByVal forField As String, ByVal value As String) As String
    Public MustOverride Function GetAllSalesReturnMasterLikeReturnDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
    Public MustOverride Function GetSalesReturnMasterNotClosedForLogin(ByVal loginName As String) As String
    Public MustOverride Function GetSalesReturnMasterIdNotClosedForLogin(ByVal loginName As String) As String
    Public MustOverride Function GetSalesReturnMaster(ByVal id As Long) As String
    Public MustOverride Function GetSalesReturnMasterDiscountAmount(ByVal id As Long) As String
    Public MustOverride Function InsertIntoSalesReturnMaster(ByRef salesReturnMastersObj As ClsSalesReturnMaster) As String
    Public MustOverride Function UpdateSalesReturnMaster(ByRef salesReturnMastersObj As ClsSalesReturnMaster) As String
#End Region

#Region "SampleDetail"
    Public MustOverride Function GetAllSampleDetail() As String
    Public MustOverride Function GetAllSampleDetailForSampleId(ByVal sampleId As Long) As String
    Public MustOverride Function GetAllSampleDetailForSampleCode(ByVal sampleCode As String) As String
    Public MustOverride Function GetAllSampleDetailForSampleIds(ByVal sampleIds As String) As String
    Public MustOverride Function GetSampleDetail(ByVal id As Long) As String
    Protected MustOverride Function GetSampleDetailTotalForSampleId(ByVal sampleId As Long) As String
    Public MustOverride Function InsertIntoSampleDetail(ByRef sampleDetailObj As ClsSampleDetail) As String
    Public MustOverride Function UpdateSampleDetail(ByRef sampleDetailObj As ClsSampleDetail) As String
    Public MustOverride Function DeleteSampleDetail(ByVal id As Long) As String
#End Region

#Region "SampleMaster"
    Public MustOverride Function GetAllSampleMaster() As String
    Public MustOverride Function GetAllSampleMasterForCashOut() As String
    Public MustOverride Function GetAllSampleMasterForCustomerCode(ByVal customerCode As String) As String
    Public MustOverride Function GetAllSampleMasterValuesLike(ByVal forField As String, ByVal value As String) As String
    Public MustOverride Function GetAllSampleMasterLikeSampleDate(ByVal day As String, ByVal month As String, ByVal year As String) As String
    Public MustOverride Function GetAllSampleMasterForDateOn(ByVal dateFrom As Date, ByVal dateTo As Date) As String
    Protected MustOverride Function GetAllSampleMasterIdSampleCodeLike(ByVal value As String) As String
    Protected MustOverride Function GetSampleMasterIdSampleCode(ByVal code As String) As String
    Public MustOverride Function GetSampleMasterNotClosedForLogin(ByVal loginName As String) As String
    Public MustOverride Function GetSampleMasterIdNotClosedForLogin(ByVal loginName As String) As String
    Public MustOverride Function GetSampleMaster(ByVal id As Long) As String
    Public MustOverride Function GetSampleMasterNetAmount(ByVal id As Long) As String
    Public MustOverride Function GetSampleMasterDiscountAmount(ByVal id As Long) As String
    Public MustOverride Function InsertIntoSampleMaster(ByRef sampleMasterObj As ClsSampleMaster) As String
    Public MustOverride Function UpdateSampleMaster(ByRef sampleMasterObj As ClsSampleMaster) As String
#End Region

#Region "ScheduleMaster"
    Public MustOverride Function ScheduleMasterUpdatable(ByRef scheduleMasterObj As ClsScheduleMaster) As String
    Public MustOverride Function GetAllScheduleMaster() As String
    Public MustOverride Function InsertIntoScheduleMaster(ByRef scheduleMasterObj As ClsScheduleMaster) As String
    Public MustOverride Function UpdateScheduleMaster(ByRef scheduleMasterObj As ClsScheduleMaster) As String
#End Region

#Region "SpecialityMaster"
    Public MustOverride Function SpecialityMasterUpdatable(ByRef specialityMasterObj As ClsSpecialityMaster) As String
    Public MustOverride Function GetAllSpecialityMaster() As String
    Protected MustOverride Function GetAllSpecialityMasterIdLike(ByVal likeValue As String) As String
    Public MustOverride Function InsertIntoSpecialityMaster(ByRef specialityMasterObj As ClsSpecialityMaster) As String
    Public MustOverride Function UpdateSpecialityMaster(ByRef specialityMasterObj As ClsSpecialityMaster) As String
#End Region

#Region "StorageMaster"
    Public MustOverride Function StorageMasterUpdatable(ByRef storageMasterObj As ClsStorageMaster) As String
    Public MustOverride Function GetAllStorageMaster() As String
    Public MustOverride Function InsertIntoStorageMaster(ByRef storageMasterObj As ClsStorageMaster) As String
    Public MustOverride Function UpdateStorageMaster(ByRef storageMasterObj As ClsStorageMaster) As String
#End Region

#Region "Tax Master"
    Public MustOverride Function TaxMasterUpdatable(ByRef taxMasterObj As ClsTaxMaster) As String
    Public MustOverride Function GetAllTaxMaster() As String
    Public MustOverride Function GetTaxMaster(ByVal id As Integer) As String
    Public MustOverride Function InsertIntoTaxMaster(ByRef taxMasterObj As ClsTaxMaster) As String
    Public MustOverride Function UpdateTaxMaster(ByRef taxMasterObj As ClsTaxMaster) As String
#End Region

#Region "TempAccount"
    Public MustOverride Function GetAllTempAccount() As String
    Public MustOverride Function GetAllTempAccountForTrialBalanceInDetail() As String
    Public MustOverride Function GetAllTempAccountForTrialBalanceInCondensed() As String
    Public MustOverride Function GetAllTempAccountForTrialBalanceInDetail(ByVal forGroupId As Integer) As String
    Public MustOverride Function GetAllTempAccountForTrialBalanceInCondensed(ByVal forGroupId As Integer) As String
    Public MustOverride Function FillTempAccountForDate(ByVal dateTo As Date) As String
    Protected MustOverride Function ClearTempAccount() As String
#End Region

#Region "Track Log"
    Public MustOverride Function GetAllTrackLogForSales(ByVal dateFrom As Date) As String
    Public MustOverride Function GetAllTrackLogForPurchase(ByVal dateFrom As Date) As String
    Public MustOverride Function GetAllTrackLogForDestructionSlip(ByVal dateFrom As Date) As String
#End Region

#Region "TransactionAccount"
    Public MustOverride Function GetAllTransactionAccount() As String
    'Public MustOverride Function GetTransactionAccount(ByVal id As Long) As String
    Public MustOverride Function GetTransactionAccountBalanceForVoucherNo(ByVal voucherNo As String) As String
    Public MustOverride Function GetTransactionAccountBalanceForVoucherNo(ByVal voucherNo As String, ByVal headId As Integer) As String
    Public MustOverride Function InsertIntoTransactionAccount(ByRef transactionAccountObj As ClsTransactionAccount) As String
    Public MustOverride Function UpdateTransactionAccount(ByRef transactionAccountObj As ClsTransactionAccount) As String
#End Region

#Region "TransactionStock"
    Public MustOverride Function GetAllTransactionStock() As String
    'Public MustOverride Function GetTransactionStock(ByVal id As Long) As String
    Public MustOverride Function InsertIntoTransactionStock(ByRef transactionStockObj As ClsTransactionStock) As String
    Public MustOverride Function UpdateTransactionStock(ByRef transactionStockObj As ClsTransactionStock) As String
#End Region

#Region "Transporter"
    Public MustOverride Function GetAllTransporter() As String
    Public MustOverride Function GetAllTransporterLike(ByVal fieldName As String, ByVal likeValue As String) As String
    Protected MustOverride Function GetAllTransporterIdForNameLike(ByVal name As String) As String
    Public MustOverride Function InsertIntoTransporter(ByRef transporterObj As ClsTransporter) As String
    Public MustOverride Function UpdateTransporter(ByRef transporterObj As ClsTransporter) As String
#End Region

#Region "UserMaster"
    Public MustOverride Function GetAllUserMaster() As String
    Public MustOverride Function GetUserMaster(ByVal loginName As String, ByVal pass As String) As String
    Public MustOverride Function ValidateUserMaster(ByVal id As Integer, ByVal pass As String) As String
    Public MustOverride Function InsertIntoUserMaster(ByRef userMasterObj As ClsUserMaster) As String
    Public MustOverride Function UpdateUserMaster(ByRef userMasterObj As ClsUserMaster, ByVal ignorePassword As Boolean) As String
    Public MustOverride Function UpdateUserMasterPassword(ByVal id As Integer, ByVal pass As String) As String
#End Region

#Region "VendorDetail"
    Public MustOverride Function GetAllVendorDetail() As String
    Public MustOverride Function GetAllVendorDetailForAccountId(ByVal accountId As String) As String
    Public MustOverride Function InsertIntoVendorDetail(ByRef vendorDetailObj As ClsVendorDetail) As String
    Public MustOverride Function UpdateVendorDetail(ByRef vendorDetailObj As ClsVendorDetail) As String
    Public MustOverride Function DeleteVendorDetail(ByVal id As Integer) As String
#End Region

#Region "VendorMaster"
    Public MustOverride Function VendorMasterUpdatable(ByRef vendorMasterObj As ClsVendorMaster) As String
    Public MustOverride Function GetAllVendorMaster() As String
    Public MustOverride Function GetAllVendorMasterLike(ByVal fieldName As String, ByVal likeValue As String) As String
    Protected MustOverride Function GetAllVendorMasterIdNameLike(ByVal likeValue As String) As String
    Protected MustOverride Function GetAllVendorMasterCodeNameLike(ByVal likeValue As String) As String
    Protected MustOverride Function GetVendorMasterIdForCode(ByVal code As String) As String
    Public MustOverride Function GetVendorMasterAccountId(ByVal id As Integer) As String
    Public MustOverride Function InsertIntoVendorMaster(ByRef vendorMasterObj As ClsVendorMaster) As String
    Public MustOverride Function UpdateVendorMaster(ByRef vendorMasterObj As ClsVendorMaster) As String
#End Region

#Region "DailyTransaction"
    Public MustOverride Function GetDailyTransactionSheet() As String
#End Region

End Class
