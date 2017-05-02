Namespace Author

    Module ModAuthorizationNo

#Region "Private Varaibles & Constants"

        'Private Const cMaxMenuItems As Integer = 50

#End Region

#Region "Enum Authorization List"

        Enum EnAuthorizationList
            Masters
            Transactions
            Accounts
            StockReports
            SalesReports
            PurchaseReports
            SampleReports
            Reports
            AccountReports
            Tools


            CustomerType
            CustomerType_NoAdd
            CustomerType_NoUpdate
            Customers
            Customers_NoAdd
            Customers_NoUpdate
            Manufacturers
            Manufacturers_NoAdd
            Manufacturers_NoUpdate
            Vendors
            Vendors_NoAdd
            Vendors_NoUpdate
            StoragePoint
            StoragePoint_NoAdd
            StoragePoint_NoUpdate
            Category
            Category_NoAdd
            Category_NoUpdate
            Transporters
            Transporters_NoAdd
            Transporters_NoUpdate
            HQ
            HQ_NoAdd
            HQ_NoUpdate
            Division
            Division_NoAdd
            Division_NoUpdate
            Tax
            Tax_NoAdd
            Tax_NoUpdate
            Items
            Items_NoAdd
            Items_NoUpdate
            AccountGroup
            AccountGroup_NoAdd
            AccountGroup_NoUpdate
            AccountHead
            AccountHead_NoAdd
            AccountHead_NoUpdate

            '********
            Sales
            Sales_Current_NoAdd
            Sales_Current_NoUpdate
            Sales_Current_NoRemove
            Sales_Old_NoAdd
            Sales_Old_NoUpdate
            Sales_Old_NoRemove
            Purchase
            Purchase_Current_NoAdd
            Purchase_Current_NoUpdate
            Purchase_Current_NoRemove
            Purchase_Old_NoAdd
            Purchase_Old_NoUpdate
            Purchase_Old_NoRemove
            SalesReturn
            SalesReturn_Current_NoAdd
            SalesReturn_Current_NoUpdate
            SalesReturn_Current_NoRemove
            SalesReturn_Old_NoAdd
            SalesReturn_Old_NoUpdate
            SalesReturn_Old_NoRemove
            PurchaseReturn
            PurchaseReturn_Current_NoAdd
            PurchaseReturn_Current_NoUpdate
            PurchaseReturn_Current_NoRemove
            PurchaseReturn_Old_NoAdd
            PurchaseReturn_Old_NoUpdate
            PurchaseReturn_Old_NoRemove
            DestructionSlips
            DestructionSlips_Current_NoAdd
            DestructionSlips_Current_NoUpdate
            DestructionSlips_Current_NoRemove
            DestructionSlips_Old_NoAdd
            DestructionSlips_Old_NoUpdate
            DestructionSlips_Old_NoRemove
            ExpirySlips
            ExpirySlips_NoAdd
            ExpirySlips_NoUpdate
            ExpirySlips_NoRemove
            PurchaseOrder
            PurchaseOrder_Current_NoAdd
            PurchaseOrder_Current_NoUpdate
            PurchaseOrder_Current_NoRemove
            PurchaseOrder_Old_NoAdd
            PurchaseOrder_Old_NoUpdate
            PurchaseOrder_Old_NoRemove
            IssueSample
            IssueSample_Current_NoAdd
            IssueSample_Current_NoUpdate
            IssueSample_Current_NoRemove
            IssueSample_Old_NoAdd
            IssueSample_Old_NoUpdate
            IssueSample_Old_NoRemove
            LRs
            LRs_NoUpdate

            '*********************
            CashPayment
            CashPayment_NoAdd
            CashPayment_NoUpdate
            CashPayment_NoRemove
            CashReceipt
            CashReceipt_NoAdd
            CashReceipt_NoUpdate
            CashReceipt_NoRemove
            ChequePayment
            ChequePayment_NoAdd
            ChequePayment_NoUpdate
            ChequePayment_NoRemove
            ChequeReceipt
            ChequeReceipt_NoAdd
            ChequeReceipt_NoUpdate
            ChequeReceipt_NoRemove
            JournalEntry
            JournalEntry_NoAdd
            JournalEntry_NoUpdate
            JournalEntry_NoRemove
            CreditNote
            CreditNote_Current_NoAdd
            CreditNote_Current_NoUpdate
            CreditNote_Old_NoAdd
            CreditNote_Old_NoUpdate
            DebitNote
            DebitNote_Current_NoAdd
            DebitNote_Current_NoUpdate
            DebitNote_Old_NoAdd
            DebitNote_Old_NoUpdate

            '****************************

            StockInHand
            StockInDemand
            StockLedger
            ItemsAvailability
            ExpiryReports
            ExpiryReports_Slips
            ExpiryReports_Stock

            '****************************

            GrossSale
            ItemwiseSale
            CustomerwiseSale
            HQwiseSale
            CreditSale
            VAT
            DatewiseSaleReturn

            '****************************

            GrossPurchase
            VendorwisePurchase
            DatewisePurchase
            ItemwisePurchase
            PurchaseReturnReport

            '****************************

            CustomerwiseReport

            '****************************

            CollectionRegister
            PaymentRegister
            PartywiseItemwiseSale
            ItemwisePartywiseSale
            StockAndSale
            StockAndSaleII
            Outstandings

            '****************************

            CashBook
            BankBook
            JournalBook
            Ledger
            TrialBalance

            '****************************

            CompanyInformation
            CompanyInformation_NoUpdate
            LegalTerms
            LegalTerms_NoAdd
            LegalTerms_NoUpdate
            LegalTerms_NoRemove
            ProfileMaster
            ProfileMaster_NoAdd
            ProfileMaster_NoUpdate
            UserMaster
            UserMaster_NoAdd
            UserMaster_NoUpdate
            ChangePassword
            ApplicationSettings
            ApplicationSettings_NoUpdate


            Count   'This should be last
        End Enum

#End Region

#Region "Class"

        Class Authorization

            Public Shared Function Masters() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Masters)
                Return str
            End Function

            Public Shared Function Transactions() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Transactions)
                Return str
            End Function

            Public Shared Function Accounts() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Accounts)
                Return str
            End Function

            Public Shared Function StockReports() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.StockReports)
                Return str
            End Function

            Public Shared Function SalesReports() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.SalesReports)
                Return str
            End Function

            Public Shared Function PurchaseReports() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.PurchaseReports)
                Return str
            End Function

            Public Shared Function SampleReports() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.SampleReports)
                Return str
            End Function

            Public Shared Function Reports() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Reports)
                Return str
            End Function

            Public Shared Function AccountReports() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.AccountReports)
                Return str
            End Function

            Public Shared Function Tools() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Tools)
                Return str
            End Function

            Public Shared Function CustomerType() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CustomerType)
                Return str
            End Function

            Public Shared Function CustomerType_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CustomerType_NoAdd)
                Return str
            End Function

            Public Shared Function CustomerType_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CustomerType_NoUpdate)
                Return str
            End Function

            Public Shared Function Customers() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Customers)
                Return str
            End Function

            Public Shared Function Customers_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Customers_NoAdd)
                Return str
            End Function

            Public Shared Function Customers_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Customers_NoUpdate)
                Return str
            End Function

            Public Shared Function Manufacturers() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Manufacturers)
                Return str
            End Function

            Public Shared Function Manufacturers_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Manufacturers_NoAdd)
                Return str
            End Function

            Public Shared Function Manufacturers_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Manufacturers_NoUpdate)
                Return str
            End Function

            Public Shared Function Vendors() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Vendors)
                Return str
            End Function

            Public Shared Function Vendors_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Vendors_NoAdd)
                Return str
            End Function

            Public Shared Function Vendors_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Vendors_NoUpdate)
                Return str
            End Function

            Public Shared Function StoragePoint() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.StoragePoint)
                Return str
            End Function

            Public Shared Function StoragePoint_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.StoragePoint_NoAdd)
                Return str
            End Function

            Public Shared Function StoragePoint_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.StoragePoint_NoUpdate)
                Return str
            End Function

            Public Shared Function Category() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Category)
                Return str
            End Function

            Public Shared Function Category_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Category_NoAdd)
                Return str
            End Function

            Public Shared Function Category_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Category_NoUpdate)
                Return str
            End Function

            Public Shared Function Transporters() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Transporters)
                Return str
            End Function

            Public Shared Function Transporters_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Transporters_NoAdd)
                Return str
            End Function

            Public Shared Function Transporters_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Transporters_NoUpdate)
                Return str
            End Function

            Public Shared Function HQ() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.HQ)
                Return str
            End Function

            Public Shared Function HQ_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.HQ_NoAdd)
                Return str
            End Function

            Public Shared Function HQ_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.HQ_NoUpdate)
                Return str
            End Function

            Public Shared Function Division() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Division)
                Return str
            End Function

            Public Shared Function Division_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Division_NoAdd)
                Return str
            End Function

            Public Shared Function Division_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Division_NoUpdate)
                Return str
            End Function

            Public Shared Function Tax() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Tax)
                Return str
            End Function

            Public Shared Function Tax_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Tax_NoAdd)
                Return str
            End Function

            Public Shared Function Tax_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Tax_NoUpdate)
                Return str
            End Function

            Public Shared Function Items() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Items)
                Return str
            End Function

            Public Shared Function Items_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Items_NoAdd)
                Return str
            End Function

            Public Shared Function Items_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Items_NoUpdate)
                Return str
            End Function

            Public Shared Function AccountGroup() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.AccountGroup)
                Return str
            End Function

            Public Shared Function AccountGroup_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.AccountGroup_NoAdd)
                Return str
            End Function

            Public Shared Function AccountGroup_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.AccountGroup_NoUpdate)
                Return str
            End Function

            Public Shared Function AccountHead() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.AccountHead)
                Return str
            End Function

            Public Shared Function AccountHead_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.AccountHead_NoAdd)
                Return str
            End Function

            Public Shared Function AccountHead_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.AccountHead_NoUpdate)
                Return str
            End Function

            Public Shared Function Sales() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Sales)
                Return str
            End Function

            Public Shared Function Sales_Current_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Sales_Current_NoAdd)
                Return str
            End Function

            Public Shared Function Sales_Current_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Sales_Current_NoUpdate)
                Return str
            End Function

            Public Shared Function Sales_Current_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Sales_Current_NoRemove)
                Return str
            End Function

            Public Shared Function Sales_Old_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Sales_Old_NoAdd)
                Return str
            End Function

            Public Shared Function Sales_Old_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Sales_Old_NoUpdate)
                Return str
            End Function

            Public Shared Function Sales_Old_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Sales_Old_NoRemove)
                Return str
            End Function

            Public Shared Function Purchase() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Purchase)
                Return str
            End Function

            Public Shared Function Purchase_Current_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Purchase_Current_NoAdd)
                Return str
            End Function

            Public Shared Function Purchase_Current_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Purchase_Current_NoUpdate)
                Return str
            End Function

            Public Shared Function Purchase_Current_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Purchase_Current_NoRemove)
                Return str
            End Function

            Public Shared Function Purchase_Old_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Purchase_Old_NoAdd)
                Return str
            End Function

            Public Shared Function Purchase_Old_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Purchase_Old_NoUpdate)
                Return str
            End Function

            Public Shared Function Purchase_Old_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Purchase_Old_NoRemove)
                Return str
            End Function

            Public Shared Function SalesReturn() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.SalesReturn)
                Return str
            End Function

            Public Shared Function SalesReturn_Current_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.SalesReturn_Current_NoAdd)
                Return str
            End Function

            Public Shared Function SalesReturn_Current_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.SalesReturn_Current_NoUpdate)
                Return str
            End Function

            Public Shared Function SalesReturn_Current_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.SalesReturn_Current_NoRemove)
                Return str
            End Function

            Public Shared Function SalesReturn_Old_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.SalesReturn_Old_NoAdd)
                Return str
            End Function

            Public Shared Function SalesReturn_Old_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.SalesReturn_Old_NoUpdate)
                Return str
            End Function

            Public Shared Function SalesReturn_Old_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.SalesReturn_Old_NoRemove)
                Return str
            End Function

            Public Shared Function PurchaseReturn() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.PurchaseReturn)
                Return str
            End Function

            Public Shared Function PurchaseReturn_Current_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.PurchaseReturn_Current_NoAdd)
                Return str
            End Function

            Public Shared Function PurchaseReturn_Current_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.PurchaseReturn_Current_NoUpdate)
                Return str
            End Function

            Public Shared Function PurchaseReturn_Current_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.PurchaseReturn_Current_NoRemove)
                Return str
            End Function

            Public Shared Function PurchaseReturn_Old_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.PurchaseReturn_Old_NoAdd)
                Return str
            End Function

            Public Shared Function PurchaseReturn_Old_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.PurchaseReturn_Old_NoUpdate)
                Return str
            End Function

            Public Shared Function PurchaseReturn_Old_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.PurchaseReturn_Old_NoRemove)
                Return str
            End Function

            Public Shared Function DestructionSlips() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.DestructionSlips)
                Return str
            End Function

            Public Shared Function DestructionSlips_Current_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.DestructionSlips_Current_NoAdd)
                Return str
            End Function

            Public Shared Function DestructionSlips_Current_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.DestructionSlips_Current_NoUpdate)
                Return str
            End Function

            Public Shared Function DestructionSlips_Current_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.DestructionSlips_Current_NoRemove)
                Return str
            End Function

            Public Shared Function DestructionSlips_Old_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.DestructionSlips_Old_NoAdd)
                Return str
            End Function

            Public Shared Function DestructionSlips_Old_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.DestructionSlips_Old_NoUpdate)
                Return str
            End Function

            Public Shared Function DestructionSlips_Old_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.DestructionSlips_Old_NoRemove)
                Return str
            End Function

            Public Shared Function ExpirySlips() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ExpirySlips)
                Return str
            End Function

            Public Shared Function ExpirySlips_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ExpirySlips_NoAdd)
                Return str
            End Function

            Public Shared Function ExpirySlips_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ExpirySlips_NoUpdate)
                Return str
            End Function

            Public Shared Function ExpirySlips_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ExpirySlips_NoRemove)
                Return str
            End Function

            Public Shared Function PurchaseOrder() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.PurchaseOrder)
                Return str
            End Function

            Public Shared Function PurchaseOrder_Current_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.PurchaseOrder_Current_NoAdd)
                Return str
            End Function

            Public Shared Function PurchaseOrder_Current_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.PurchaseOrder_Current_NoUpdate)
                Return str
            End Function

            Public Shared Function PurchaseOrder_Current_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.PurchaseOrder_Current_NoRemove)
                Return str
            End Function

            Public Shared Function PurchaseOrder_Old_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.PurchaseOrder_Old_NoAdd)
                Return str
            End Function

            Public Shared Function PurchaseOrder_Old_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.PurchaseOrder_Old_NoUpdate)
                Return str
            End Function

            Public Shared Function PurchaseOrder_Old_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.PurchaseOrder_Old_NoRemove)
                Return str
            End Function

            Public Shared Function IssueSample() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.IssueSample)
                Return str
            End Function

            Public Shared Function IssueSample_Current_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.IssueSample_Current_NoAdd)
                Return str
            End Function

            Public Shared Function IssueSample_Current_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.IssueSample_Current_NoUpdate)
                Return str
            End Function

            Public Shared Function IssueSample_Current_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.IssueSample_Current_NoRemove)
                Return str
            End Function

            Public Shared Function IssueSample_Old_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.IssueSample_Old_NoAdd)
                Return str
            End Function

            Public Shared Function IssueSample_Old_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.IssueSample_Old_NoUpdate)
                Return str
            End Function

            Public Shared Function IssueSample_Old_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.IssueSample_Old_NoRemove)
                Return str
            End Function

            Public Shared Function LRs() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.LRs)
                Return str
            End Function

            Public Shared Function LRs_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.LRs_NoUpdate)
                Return str
            End Function

            Public Shared Function CashPayment() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CashPayment)
                Return str
            End Function

            Public Shared Function CashPayment_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CashPayment_NoAdd)
                Return str
            End Function

            Public Shared Function CashPayment_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CashPayment_NoUpdate)
                Return str
            End Function

            Public Shared Function CashPayment_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CashPayment_NoRemove)
                Return str
            End Function

            Public Shared Function CashReceipt() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CashReceipt)
                Return str
            End Function

            Public Shared Function CashReceipt_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CashReceipt_NoAdd)
                Return str
            End Function

            Public Shared Function CashReceipt_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CashReceipt_NoUpdate)
                Return str
            End Function

            Public Shared Function CashReceipt_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CashReceipt_NoRemove)
                Return str
            End Function

            Public Shared Function ChequePayment() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ChequePayment)
                Return str
            End Function

            Public Shared Function ChequePayment_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ChequePayment_NoAdd)
                Return str
            End Function

            Public Shared Function ChequePayment_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ChequePayment_NoUpdate)
                Return str
            End Function

            Public Shared Function ChequePayment_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ChequePayment_NoRemove)
                Return str
            End Function

            Public Shared Function ChequeReceipt() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ChequeReceipt)
                Return str
            End Function

            Public Shared Function ChequeReceipt_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ChequeReceipt_NoAdd)
                Return str
            End Function

            Public Shared Function ChequeReceipt_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ChequeReceipt_NoUpdate)
                Return str
            End Function

            Public Shared Function ChequeReceipt_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ChequeReceipt_NoRemove)
                Return str
            End Function

            Public Shared Function JournalEntry() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.JournalEntry)
                Return str
            End Function

            Public Shared Function JournalEntry_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.JournalEntry_NoAdd)
                Return str
            End Function

            Public Shared Function JournalEntry_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.JournalEntry_NoUpdate)
                Return str
            End Function

            Public Shared Function JournalEntry_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.JournalEntry_NoRemove)
                Return str
            End Function

            Public Shared Function CreditNote() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CreditNote)
                Return str
            End Function

            Public Shared Function CreditNote_Current_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CreditNote_Current_NoAdd)
                Return str
            End Function

            Public Shared Function CreditNote_Current_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CreditNote_Current_NoUpdate)
                Return str
            End Function

            Public Shared Function CreditNote_Old_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CreditNote_Old_NoAdd)
                Return str
            End Function

            Public Shared Function CreditNote_Old_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CreditNote_Old_NoUpdate)
                Return str
            End Function

            Public Shared Function DebitNote() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.DebitNote)
                Return str
            End Function

            Public Shared Function DebitNote_Current_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.DebitNote_Current_NoAdd)
                Return str
            End Function

            Public Shared Function DebitNote_Current_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.DebitNote_Current_NoUpdate)
                Return str
            End Function

            Public Shared Function DebitNote_Old_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.DebitNote_Old_NoAdd)
                Return str
            End Function

            Public Shared Function DebitNote_Old_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.DebitNote_Old_NoUpdate)
                Return str
            End Function

            Public Shared Function StockInHand() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.StockInHand)
                Return str
            End Function

            Public Shared Function StockInDemand() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.StockInDemand)
                Return str
            End Function

            Public Shared Function StockLedger() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.StockLedger)
                Return str
            End Function

            Public Shared Function ItemsAvailability() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ItemsAvailability)
                Return str
            End Function

            Public Shared Function ExpiryReports() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ExpiryReports)
                Return str
            End Function

            Public Shared Function ExpiryReports_Slips() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ExpiryReports_Slips)
                Return str
            End Function

            Public Shared Function ExpiryReports_Stock() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ExpiryReports_Stock)
                Return str
            End Function

            Public Shared Function GrossSale() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.GrossSale)
                Return str
            End Function

            Public Shared Function ItemwiseSale() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ItemwiseSale)
                Return str
            End Function

            Public Shared Function CustomerwiseSale() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CustomerwiseSale)
                Return str
            End Function

            Public Shared Function HQwiseSale() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.HQwiseSale)
                Return str
            End Function

            Public Shared Function CreditSale() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CreditSale)
                Return str
            End Function

            Public Shared Function VAT() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.VAT)
                Return str
            End Function

            Public Shared Function DatewiseSaleReturn() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.DatewiseSaleReturn)
                Return str
            End Function

            Public Shared Function GrossPurchase() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.GrossPurchase)
                Return str
            End Function

            Public Shared Function VendorwisePurchase() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.VendorwisePurchase)
                Return str
            End Function

            Public Shared Function DatewisePurchase() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.DatewisePurchase)
                Return str
            End Function

            Public Shared Function ItemwisePurchase() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ItemwisePurchase)
                Return str
            End Function

            Public Shared Function PurchaseReturnReport() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.PurchaseReturnReport)
                Return str
            End Function

            Public Shared Function CustomerwiseReport() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CustomerwiseReport)
                Return str
            End Function

            Public Shared Function CollectionRegister() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CollectionRegister)
                Return str
            End Function

            Public Shared Function PaymentRegister() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.PaymentRegister)
                Return str
            End Function

            Public Shared Function PartywiseItemwiseSale() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.PartywiseItemwiseSale)
                Return str
            End Function

            Public Shared Function ItemwisePartywiseSale() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ItemwisePartywiseSale)
                Return str
            End Function

            Public Shared Function StockAndSale() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.StockAndSale)
                Return str
            End Function

            Public Shared Function StockAndSaleII() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.StockAndSaleII)
                Return str
            End Function

            Public Shared Function Outstandings() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Outstandings)
                Return str
            End Function

            Public Shared Function CashBook() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CashBook)
                Return str
            End Function

            Public Shared Function BankBook() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.BankBook)
                Return str
            End Function

            Public Shared Function JournalBook() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.JournalBook)
                Return str
            End Function

            Public Shared Function Ledger() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.Ledger)
                Return str
            End Function

            Public Shared Function TrialBalance() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.TrialBalance)
                Return str
            End Function

            Public Shared Function CompanyInformation() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CompanyInformation)
                Return str
            End Function

            Public Shared Function CompanyInformation_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.CompanyInformation_NoUpdate)
                Return str
            End Function

            Public Shared Function LegalTerms() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.LegalTerms)
                Return str
            End Function

            Public Shared Function LegalTerms_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.LegalTerms_NoAdd)
                Return str
            End Function

            Public Shared Function LegalTerms_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.LegalTerms_NoUpdate)
                Return str
            End Function

            Public Shared Function LegalTerms_NoRemove() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.LegalTerms_NoRemove)
                Return str
            End Function

            Public Shared Function ProfileMaster() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ProfileMaster)
                Return str
            End Function

            Public Shared Function ProfileMaster_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ProfileMaster_NoAdd)
                Return str
            End Function

            Public Shared Function ProfileMaster_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ProfileMaster_NoUpdate)
                Return str
            End Function

            Public Shared Function UserMaster() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.UserMaster)
                Return str
            End Function

            Public Shared Function UserMaster_NoAdd() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.UserMaster_NoAdd)
                Return str
            End Function

            Public Shared Function UserMaster_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.UserMaster_NoUpdate)
                Return str
            End Function

            Public Shared Function ChangePassword() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ChangePassword)
                Return str
            End Function

            Public Shared Function ApplicationSettings() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ApplicationSettings)
                Return str
            End Function

            Public Shared Function ApplicationSettings_NoUpdate() As String
                Static Dim str As String = CreateNewCode(EnAuthorizationList.ApplicationSettings_NoUpdate)
                Return str
            End Function

        End Class

#End Region

#Region "Set Tree View"

        Public Sub SetTreeViewMenuList(ByRef trVwMenuList As TreeView)
            Try
                trVwMenuList.Nodes.Clear()
                trVwMenuList.CheckBoxes = True

                Dim node As TreeNode

                'Masters
                node = New TreeNode
                node.Text = "Masters"
                node.Tag = Authorization.Masters
                trVwMenuList.Nodes.Add(node)

                AddNodesToMaster(node)

                'Transaction         
                node = New TreeNode
                node.Text = "Transactions"
                node.Tag = Authorization.Transactions
                trVwMenuList.Nodes.Add(node)

                AddNodesToTransaction(node)

                'Accounts         
                node = New TreeNode
                node.Text = "Accounts"
                node.Tag = Authorization.Accounts
                trVwMenuList.Nodes.Add(node)

                AddNodesToAccounts(node)

                'StockReports         
                node = New TreeNode
                node.Text = "Stock Reports"
                node.Tag = Authorization.StockReports
                trVwMenuList.Nodes.Add(node)

                AddNodesToStockReports(node)

                'SalesReports         
                node = New TreeNode
                node.Text = "Sales Reports"
                node.Tag = Authorization.SalesReports
                trVwMenuList.Nodes.Add(node)

                AddNodesToSalesReports(node)

                'PurchaseReports         
                node = New TreeNode
                node.Text = "Purchase Reports"
                node.Tag = Authorization.PurchaseReports
                trVwMenuList.Nodes.Add(node)

                AddNodesToPurchaseReports(node)

                'SampleReports         
                node = New TreeNode
                node.Text = "Sample Reports"
                node.Tag = Authorization.SampleReports
                trVwMenuList.Nodes.Add(node)

                AddNodesToSampleReports(node)

                'Reports         
                node = New TreeNode
                node.Text = "Reports"
                node.Tag = Authorization.Reports
                trVwMenuList.Nodes.Add(node)

                AddNodesToReports(node)

                'AccountReports         
                node = New TreeNode
                node.Text = "AccountReports"
                node.Tag = Authorization.AccountReports
                trVwMenuList.Nodes.Add(node)

                AddNodesToAccountReports(node)

                'Tools          
                node = New TreeNode
                node.Text = "Tools"
                node.Tag = Authorization.Tools
                trVwMenuList.Nodes.Add(node)

                AddNodesToTools(node)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddNodesToMaster(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "Customer Type"
                subNode.Tag = Authorization.CustomerType
                node.Nodes.Add(subNode)

                AddDetailNodesToCustomerType(subNode)

                subNode = New TreeNode
                subNode.Text = "Customers"
                subNode.Tag = Authorization.Customers
                node.Nodes.Add(subNode)

                AddDetailNodesToCustomers(subNode)

                subNode = New TreeNode
                subNode.Text = "Manufacturers"
                subNode.Tag = Authorization.Manufacturers
                node.Nodes.Add(subNode)

                AddDetailNodesToManufacturers(subNode)

                subNode = New TreeNode
                subNode.Text = "Vendors"
                subNode.Tag = Authorization.Vendors
                node.Nodes.Add(subNode)

                AddDetailNodesToVendors(subNode)

                subNode = New TreeNode
                subNode.Text = "Storage Point"
                subNode.Tag = Authorization.StoragePoint
                node.Nodes.Add(subNode)

                AddDetailNodesToStoragePoint(subNode)

                subNode = New TreeNode
                subNode.Text = "Category"
                subNode.Tag = Authorization.Category
                node.Nodes.Add(subNode)

                AddDetailNodesToCategory(subNode)

                subNode = New TreeNode
                subNode.Text = "Transporters"
                subNode.Tag = Authorization.Transporters
                node.Nodes.Add(subNode)

                AddDetailNodesToTransporters(subNode)

                subNode = New TreeNode
                subNode.Text = "HQ"
                subNode.Tag = Authorization.HQ
                node.Nodes.Add(subNode)

                AddDetailNodesToHQ(subNode)

                subNode = New TreeNode
                subNode.Text = "Division"
                subNode.Tag = Authorization.Division
                node.Nodes.Add(subNode)

                AddDetailNodesToDivision(subNode)

                subNode = New TreeNode
                subNode.Text = "Tax"
                subNode.Tag = Authorization.Tax
                node.Nodes.Add(subNode)

                AddDetailNodesToTax(subNode)

                subNode = New TreeNode
                subNode.Text = "Items"
                subNode.Tag = Authorization.Items
                node.Nodes.Add(subNode)

                AddDetailNodesToItems(subNode)

                subNode = New TreeNode
                subNode.Text = "Account Group"
                subNode.Tag = Authorization.AccountGroup
                node.Nodes.Add(subNode)

                AddDetailNodesToAccountGroup(subNode)

                subNode = New TreeNode
                subNode.Text = "Account Head"
                subNode.Tag = Authorization.AccountHead
                node.Nodes.Add(subNode)

                AddDetailNodesToAccountHead(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddNodesToTransaction(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "Sales"
                subNode.Tag = Authorization.Sales
                node.Nodes.Add(subNode)

                AddDetailNodesToSales(subNode)

                subNode = New TreeNode
                subNode.Text = "Purchase"
                subNode.Tag = Authorization.Purchase
                node.Nodes.Add(subNode)

                AddDetailNodesToPurchase(subNode)

                subNode = New TreeNode
                subNode.Text = "Sales Return"
                subNode.Tag = Authorization.SalesReturn
                node.Nodes.Add(subNode)

                AddDetailNodesToSalesReturn(subNode)

                subNode = New TreeNode
                subNode.Text = "Purchase Return"
                subNode.Tag = Authorization.PurchaseReturn
                node.Nodes.Add(subNode)

                AddDetailNodesToPurchaseReturn(subNode)

                subNode = New TreeNode
                subNode.Text = "Destruction Slips"
                subNode.Tag = Authorization.DestructionSlips
                node.Nodes.Add(subNode)

                AddDetailNodesToDestructionSlips(subNode)

                subNode = New TreeNode
                subNode.Text = "Expiry Slips"
                subNode.Tag = Authorization.ExpirySlips
                node.Nodes.Add(subNode)

                AddDetailNodesToExpirySlips(subNode)

                subNode = New TreeNode
                subNode.Text = "Purchase Order"
                subNode.Tag = Authorization.PurchaseOrder
                node.Nodes.Add(subNode)

                AddDetailNodesToPurchaseOrder(subNode)

                subNode = New TreeNode
                subNode.Text = "Issue Sample"
                subNode.Tag = Authorization.IssueSample
                node.Nodes.Add(subNode)

                AddDetailNodesToIssueSample(subNode)

                subNode = New TreeNode
                subNode.Text = "LRs"
                subNode.Tag = Authorization.LRs
                node.Nodes.Add(subNode)

                AddDetailNodesToLRs(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddNodesToAccounts(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "Cash Payment"
                subNode.Tag = Authorization.CashPayment
                node.Nodes.Add(subNode)

                AddDetailNodesToCashPayment(subNode)

                subNode = New TreeNode
                subNode.Text = "Cash Receipt"
                subNode.Tag = Authorization.CashReceipt
                node.Nodes.Add(subNode)

                AddDetailNodesToCashReceipt(subNode)

                subNode = New TreeNode
                subNode.Text = "Cheque Payment"
                subNode.Tag = Authorization.ChequePayment
                node.Nodes.Add(subNode)

                AddDetailNodesToChequePayment(subNode)

                subNode = New TreeNode
                subNode.Text = "Cheque Receipt"
                subNode.Tag = Authorization.ChequeReceipt
                node.Nodes.Add(subNode)

                AddDetailNodesToChequeReceipt(subNode)

                subNode = New TreeNode
                subNode.Text = "Journal Entry"
                subNode.Tag = Authorization.JournalEntry
                node.Nodes.Add(subNode)

                AddDetailNodesToJournalEntry(subNode)

                subNode = New TreeNode
                subNode.Text = "Credit Note"
                subNode.Tag = Authorization.CreditNote
                node.Nodes.Add(subNode)

                AddDetailNodesToCreditNote(subNode)

                subNode = New TreeNode
                subNode.Text = "Debit Note"
                subNode.Tag = Authorization.DebitNote
                node.Nodes.Add(subNode)

                AddDetailNodesToDebitNote(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddNodesToStockReports(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "Stock In Hand"
                subNode.Tag = Authorization.StockInHand
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Stock In Demand"
                subNode.Tag = Authorization.StockInDemand
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Stock Ledger"
                subNode.Tag = Authorization.StockLedger
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Items Availability"
                subNode.Tag = Authorization.ItemsAvailability
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Expiry Reports"
                subNode.Tag = Authorization.ExpiryReports
                node.Nodes.Add(subNode)

                AddNodesToExpiryReports(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddNodesToSalesReports(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "Gross Sale"
                subNode.Tag = Authorization.GrossSale
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Itemwise Sale"
                subNode.Tag = Authorization.ItemwiseSale
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Customerwise Sale"
                subNode.Tag = Authorization.CustomerwiseSale
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "HQwise Sale"
                subNode.Tag = Authorization.HQwiseSale
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Credit Sale"
                subNode.Tag = Authorization.CreditSale
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "VAT"
                subNode.Tag = Authorization.VAT
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Datewise Sale Return"
                subNode.Tag = Authorization.DatewiseSaleReturn
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddNodesToPurchaseReports(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "Gross Purchase"
                subNode.Tag = Authorization.GrossPurchase
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Vendorwise Purchase"
                subNode.Tag = Authorization.VendorwisePurchase
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Datewise Purchase"
                subNode.Tag = Authorization.DatewisePurchase
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Itemwise Purchase"
                subNode.Tag = Authorization.ItemwisePurchase
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Purchase Return"
                subNode.Tag = Authorization.PurchaseReturnReport
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddNodesToSampleReports(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "Customerwise Report"
                subNode.Tag = Authorization.CustomerwiseReport
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddNodesToReports(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "Collection Register"
                subNode.Tag = Authorization.CollectionRegister
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Payment Register"
                subNode.Tag = Authorization.PaymentRegister
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Partywise Itemwise Sale"
                subNode.Tag = Authorization.PartywiseItemwiseSale
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Itemwise Partywise Sale"
                subNode.Tag = Authorization.ItemwisePartywiseSale
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Stock And Sale"
                subNode.Tag = Authorization.StockAndSale
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Stock And Sale II"
                subNode.Tag = Authorization.StockAndSaleII
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Outstandings"
                subNode.Tag = Authorization.Outstandings
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddNodesToAccountReports(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "Cash Book"
                subNode.Tag = Authorization.CashBook
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Bank Book"
                subNode.Tag = Authorization.BankBook
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Journal Book"
                subNode.Tag = Authorization.JournalBook
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Ledger"
                subNode.Tag = Authorization.Ledger
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Trial Balance"
                subNode.Tag = Authorization.TrialBalance
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddNodesToTools(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "Company Information"
                subNode.Tag = Authorization.CompanyInformation
                node.Nodes.Add(subNode)

                AddDetailNodesToCompanyInformation(subNode)

                subNode = New TreeNode
                subNode.Text = "Legal Terms"
                subNode.Tag = Authorization.LegalTerms
                node.Nodes.Add(subNode)

                AddDetailNodesToLegalTerms(subNode)

                subNode = New TreeNode
                subNode.Text = "Profile Master"
                subNode.Tag = Authorization.ProfileMaster
                node.Nodes.Add(subNode)

                AddDetailNodesToProfileMaster(subNode)

                subNode = New TreeNode
                subNode.Text = "User Master"
                subNode.Tag = Authorization.UserMaster
                node.Nodes.Add(subNode)

                AddDetailNodesToUserMaster(subNode)

                subNode = New TreeNode
                subNode.Text = "Change Password"
                subNode.Tag = Authorization.ChangePassword
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Application Settings"
                subNode.Tag = Authorization.ApplicationSettings
                node.Nodes.Add(subNode)

                AddDetailNodesToApplicationSettings(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

#End Region

#Region "Detail Nodes"

        Private Sub AddDetailNodesToCustomerType(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.CustomerType_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.CustomerType_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToCustomers(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.Customers_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.Customers_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToManufacturers(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.Manufacturers_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.Manufacturers_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToVendors(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.Vendors_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.Vendors_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToStoragePoint(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.StoragePoint_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.StoragePoint_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToCategory(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.Category_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.Category_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToTransporters(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.Transporters_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.Transporters_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToHQ(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.HQ_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.HQ_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToDivision(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.Division_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.Division_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToTax(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.Tax_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.Tax_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToItems(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.Items_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.Items_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToAccountGroup(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.AccountGroup_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.AccountGroup_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToAccountHead(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.AccountHead_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.AccountHead_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToSales(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add Current"
                subNode.Tag = Authorization.Sales_Current_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update Current"
                subNode.Tag = Authorization.Sales_Current_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove Current"
                subNode.Tag = Authorization.Sales_Current_NoRemove
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Add Old"
                subNode.Tag = Authorization.Sales_Old_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update Old"
                subNode.Tag = Authorization.Sales_Old_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove Old"
                subNode.Tag = Authorization.Sales_Old_NoRemove
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToPurchase(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add Current"
                subNode.Tag = Authorization.Purchase_Current_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update Current"
                subNode.Tag = Authorization.Purchase_Current_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove Current"
                subNode.Tag = Authorization.Purchase_Current_NoRemove
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Add Old"
                subNode.Tag = Authorization.Purchase_Old_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update Old"
                subNode.Tag = Authorization.Purchase_Old_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove Old"
                subNode.Tag = Authorization.Purchase_Old_NoRemove
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToSalesReturn(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add Current"
                subNode.Tag = Authorization.SalesReturn_Current_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update Current"
                subNode.Tag = Authorization.SalesReturn_Current_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove Current"
                subNode.Tag = Authorization.SalesReturn_Current_NoRemove
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Add Old"
                subNode.Tag = Authorization.SalesReturn_Old_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update Old"
                subNode.Tag = Authorization.SalesReturn_Old_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove Old"
                subNode.Tag = Authorization.SalesReturn_Old_NoRemove
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToPurchaseReturn(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add Current"
                subNode.Tag = Authorization.PurchaseReturn_Current_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update Current"
                subNode.Tag = Authorization.PurchaseReturn_Current_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove Current"
                subNode.Tag = Authorization.PurchaseReturn_Current_NoRemove
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Add Old"
                subNode.Tag = Authorization.PurchaseReturn_Old_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update Old"
                subNode.Tag = Authorization.PurchaseReturn_Old_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove Old"
                subNode.Tag = Authorization.PurchaseReturn_Old_NoRemove
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToDestructionSlips(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add Current"
                subNode.Tag = Authorization.DestructionSlips_Current_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update Current"
                subNode.Tag = Authorization.DestructionSlips_Current_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove Current"
                subNode.Tag = Authorization.DestructionSlips_Current_NoRemove
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Add Old"
                subNode.Tag = Authorization.DestructionSlips_Old_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update Old"
                subNode.Tag = Authorization.DestructionSlips_Old_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove Old"
                subNode.Tag = Authorization.DestructionSlips_Old_NoRemove
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToExpirySlips(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.ExpirySlips_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.ExpirySlips_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove"
                subNode.Tag = Authorization.ExpirySlips_NoRemove
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToPurchaseOrder(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add Current"
                subNode.Tag = Authorization.PurchaseOrder_Current_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update Current"
                subNode.Tag = Authorization.PurchaseOrder_Current_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove Current"
                subNode.Tag = Authorization.PurchaseOrder_Current_NoRemove
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Add Old"
                subNode.Tag = Authorization.PurchaseOrder_Old_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update Old"
                subNode.Tag = Authorization.PurchaseOrder_Old_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove Old"
                subNode.Tag = Authorization.PurchaseOrder_Old_NoRemove
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToIssueSample(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add Current"
                subNode.Tag = Authorization.IssueSample_Current_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update Current"
                subNode.Tag = Authorization.IssueSample_Current_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove Current"
                subNode.Tag = Authorization.IssueSample_Current_NoRemove
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Add Old"
                subNode.Tag = Authorization.IssueSample_Old_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update Old"
                subNode.Tag = Authorization.IssueSample_Old_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove Old"
                subNode.Tag = Authorization.IssueSample_Old_NoRemove
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToLRs(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.LRs_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToCashPayment(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.CashPayment_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.CashPayment_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove"
                subNode.Tag = Authorization.CashPayment_NoRemove
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToCashReceipt(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.CashReceipt_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.CashReceipt_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove"
                subNode.Tag = Authorization.CashReceipt_NoRemove
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToChequePayment(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.ChequePayment_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.ChequePayment_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove"
                subNode.Tag = Authorization.ChequePayment_NoRemove
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToChequeReceipt(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.ChequeReceipt_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.ChequeReceipt_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove"
                subNode.Tag = Authorization.ChequeReceipt_NoRemove
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToJournalEntry(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.JournalEntry_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.JournalEntry_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove"
                subNode.Tag = Authorization.JournalEntry_NoRemove
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToCreditNote(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add Current"
                subNode.Tag = Authorization.CreditNote_Current_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update Current"
                subNode.Tag = Authorization.CreditNote_Current_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Add Old"
                subNode.Tag = Authorization.CreditNote_Old_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update Old"
                subNode.Tag = Authorization.CreditNote_Old_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToDebitNote(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add Current"
                subNode.Tag = Authorization.DebitNote_Current_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update Current"
                subNode.Tag = Authorization.DebitNote_Current_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Add Old"
                subNode.Tag = Authorization.DebitNote_Old_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update Old"
                subNode.Tag = Authorization.DebitNote_Old_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddNodesToExpiryReports(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "Expiry Detail(Slips)"
                subNode.Tag = Authorization.ExpiryReports_Slips
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "Expiry Stock"
                subNode.Tag = Authorization.ExpiryReports_Stock
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToCompanyInformation(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.CompanyInformation_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToLegalTerms(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.LegalTerms_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.LegalTerms_NoUpdate
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Remove"
                subNode.Tag = Authorization.LegalTerms_NoRemove
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToProfileMaster(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.ProfileMaster_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.ProfileMaster_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToUserMaster(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Add"
                subNode.Tag = Authorization.UserMaster_NoAdd
                node.Nodes.Add(subNode)

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.UserMaster_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub AddDetailNodesToApplicationSettings(ByRef node As TreeNode)
            Try
                Dim subNode As TreeNode

                subNode = New TreeNode
                subNode.Text = "No Update"
                subNode.Tag = Authorization.ApplicationSettings_NoUpdate
                node.Nodes.Add(subNode)

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

#End Region

#Region "Other Functions"

        Public Sub RemoveTreeViewMenuListCheckBoxes(ByRef trVwMenuList As TreeView)
            Try
                With trVwMenuList
                    Dim subNode As TreeNode
                    For Each subNode In .Nodes
                        UnCheckCheckBox(subNode)
                    Next
                End With

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub UnCheckCheckBox(ByRef node As TreeNode)
            Try
                node.Checked = False

                Dim subNode As TreeNode
                For Each subNode In node.Nodes
                    UnCheckCheckBox(subNode)
                Next

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Public Function SumOfTreeViewMenuListValue(ByRef trVwMenuList As TreeView) As String
            Dim result As String = ""
            Try
                With trVwMenuList
                    Dim subNode As TreeNode
                    For Each subNode In .Nodes
                        result = SumOfNodeValue(result, subNode)
                    Next
                End With

            Catch ex As Exception
                AddToLog(ex)
            End Try

            Return result
        End Function

        Private Function SumOfNodeValue(ByVal firstValue As String, ByRef node As TreeNode) As String
            Dim result As String = ""
            Try
                result = firstValue

                If node.Checked = True Then
                    If firstValue.Trim = "" Then
                        result = node.Tag
                    Else
                        Dim str As String = node.Tag
                        If str.Trim <> "" Then

                            result = StringSum(firstValue, str)
                        End If
                    End If
                End If

                Dim subNode As TreeNode
                For Each subNode In node.Nodes
                    result = SumOfNodeValue(result, subNode)
                Next

            Catch ex As Exception
                AddToLog(ex)
            End Try

            Return result
        End Function

        Public Sub CheckTreeViewMenuListCheckBoxesForValue(ByRef trVwMenuList As TreeView, ByVal value As String)
            Try
                With trVwMenuList
                    Dim subNode As TreeNode
                    For Each subNode In .Nodes
                        CheckCheckBoxesForValue(subNode, value)
                    Next
                End With

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Private Sub CheckCheckBoxesForValue(ByRef node As TreeNode, ByVal value As String)
            Try
                node.Checked = AndedTheString(node.Tag, value)

                Dim subNode As TreeNode
                For Each subNode In node.Nodes
                    CheckCheckBoxesForValue(subNode, value)
                Next

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Public Sub CheckParent(ByRef node As TreeNode)
            Try
                If node Is Nothing Then Exit Try

                Dim parentNode As TreeNode = node.Parent
                If parentNode Is Nothing Then Exit Try

                parentNode.Checked = True

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

        Public Sub UnCheckChild(ByRef node As TreeNode)
            Try
                If node Is Nothing Then Exit Try

                Dim subNode As TreeNode
                For Each subNode In node.Nodes
                    subNode.Checked = False
                Next

            Catch ex As Exception
                AddToLog(ex)
            End Try
        End Sub

#End Region

#Region "String Functions"

        Private Function CreateNewCode(ByVal shiftPos As EnAuthorizationList) As String
            Dim result As String = ""
            Try
                If shiftPos < 0 Or shiftPos > EnAuthorizationList.Count Then Exit Try

                Dim str As New String("0", EnAuthorizationList.Count - 1)
                str = str.Insert(shiftPos, "1")

                result = str

            Catch ex As Exception
                AddToLog(ex)
            End Try

            Return result
        End Function

        Private Function StringSum(ByVal first As String, ByVal second As String) As String
            Dim sum As String = ""
            Try
                Dim strSum As String = ""
                Dim strLen As Integer = second.Length
                Dim x As Integer
                For x = 0 To strLen - 1
                    If first(x) = "0" And second(x) = "0" Then
                        strSum = strSum + "0"
                    Else
                        strSum = strSum + "1"
                    End If
                Next

                sum = strSum

            Catch ex As Exception
                AddToLog(ex)
            End Try

            Return sum
        End Function

        Public Function OredTheString(ByVal first As String, ByVal second As String) As Boolean
            Dim result As Boolean = False
            Try
                Dim strLen As Integer = second.Length
                Dim x As Integer
                For x = 0 To strLen - 1
                    If first(x) <> second(x) Then
                        result = True

                        Exit Try
                    End If
                Next

            Catch ex As Exception
                AddToLog(ex)
            End Try

            Return result
        End Function

        Public Function AndedTheString(ByVal first As String, ByVal second As String) As Boolean
            Dim result As Boolean = False
            Try
                Dim strLen As Integer = second.Length
                Dim x As Integer
                For x = 0 To strLen - 1
                    If first(x) = second(x) And first(x) = "1" Then
                        result = True

                        Exit Try
                    End If
                Next

            Catch ex As Exception
                AddToLog(ex)
            End Try

            Return result
        End Function

#End Region

    End Module

End Namespace