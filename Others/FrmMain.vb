Imports AIMS.Author
Imports System.Threading
Imports System.Configuration

Public Class FrmMain

#Region "Varaibles & Constants"
    Dim flagLoading As Boolean = False
    Shared sInstance As FrmMain

    Private Delegate Sub LoginExpiredDelegate()
#End Region

#Region "Control Events"

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If sInstance Is Nothing Then sInstance = Me
            flagLoading = True
            Me.Visible = False
            SplashScreen.ShowDialog()

            If ValidateConnection() = False Then
                Application.Exit()
                Exit Sub
            End If

            LogMeOff()

            'Dim ExpireDate As New Date(2012, 3, 31, 1, 0, 0, 0, DateTimeKind.Local)
            'If ExpireDate.Date <= Now.Date Then
            '    MsgBox(" $%^&****HJDHjkahfjadfh$&*(&%*(%&", MsgBoxStyle.Critical, "Error")
            '    Application.Exit()
            '    Exit Sub
            'End If

            Dim frm As New FrmLogin
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ReValidateConnection()
                'Perform all starting task here
                LoadApplicationValues()

                Me.Visible = True
                SetControls()
            Else
                Application.Exit()
            End If

            flagLoading = False

        Catch ex As Exception
            AddToLog(ex)

            Application.Exit()
        End Try
    End Sub

    Private Sub Help(ByVal sender As Object, ByVal hlpEvent As System.Windows.Forms.HelpEventArgs) Handles MyBase.HelpRequested
        ShowHelp()
        hlpEvent.Handled = True
    End Sub

#End Region

#Region "Private Functions"

    Private Delegate Sub DoWorkEventHandler(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)

    Private Sub SetControls()
        Dim bgWorker As New System.ComponentModel.BackgroundWorker
        AddHandler bgWorker.DoWork, AddressOf BgWorker_DoWork
        bgWorker.RunWorkerAsync(gUser)

        SetMenusVisibility()
    End Sub

    Private Function ValidateConnection() As Boolean
        Dim result As Boolean = False
        If ClsDBFunctions.GetInstance.CheckConnection = False Then
            'If ModProfileMasterDAL.GetProfileById(Me.Name, gUser.ProfileId).Name.ToLower() = "navishaboss" Then
            '    Dim frm As New FrmConnectionString
            '    If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            '        result = ClsDBFunctions.GetInstance.CheckConnection
            '        If result = False Then
            '            MsgBox("Fail to connect with new settings.", MsgBoxStyle.Critical, "Fail")
            '        End If
            '    End If
            'Else
            '    Return SetConnection()
            'End If

            Return SetConnection()
        Else
            result = True
        End If

        'If ClsDBFunctions.GetInstance.CheckConnection = False Then
        '    Return SetConnection()
        '    ' NKP : Uncomment following line for setting Connection string and Comment the Function call SetConnection above. 
        '    'Dim frm As New FrmConnectionString
        '    'If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        '    '    result = ClsDBFunctions.GetInstance.CheckConnection
        '    '    If result = False Then
        '    '        MsgBox("Fail to connect with new settings.", MsgBoxStyle.Critical, "Fail")
        '    '    End If
        '    'End If
        'Else
        '    result = True
        'End If

        Return result
    End Function

    Private Function ReValidateConnection() As Boolean
        Dim result As Boolean = False
        If ModProfileMasterDAL.GetProfileById(Me.Name, gUser.ProfileId).Name.ToLower() = "navishaboss" Then
            Dim frm As New FrmConnectionString
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                result = ClsDBFunctions.GetInstance.CheckConnection
                If result = False Then
                    MsgBox("Fail to connect with new settings.", MsgBoxStyle.Critical, "Fail")
                End If
            End If
        Else
            Return SetConnection()
        End If
    End Function

    Private Function SetConnection() As Boolean
        Try
            Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            If config Is Nothing Then
                MsgBox("Unable to set config file.", MsgBoxStyle.Critical, "File")
                Exit Try
            End If

            Dim connStrings As System.Configuration.ConnectionStringsSection = config.ConnectionStrings
            If connStrings Is Nothing Then
                MsgBox("Unable to find connection strings in config file.", MsgBoxStyle.Critical, "Connection String")
                Exit Try
            End If

            Dim conString As String = connStrings.ConnectionStrings("Navisha").ConnectionString
            Dim b() As Byte = System.Text.ASCIIEncoding.ASCII.GetBytes(conString)
            conString = Convert.ToBase64String(b)

            Dim conStrSetting As System.Configuration.ConnectionStringSettings = connStrings.ConnectionStrings(cConnectionStringKey)
            If conStrSetting Is Nothing Then
                conStrSetting = New System.Configuration.ConnectionStringSettings
                conStrSetting.ConnectionString = conString
                conStrSetting.ProviderName = "System.Data.SqlClient"
                conStrSetting.Name = cConnectionStringKey
                config.ConnectionStrings.ConnectionStrings.Add(conStrSetting)
                config.Save()
            Else
                conStrSetting.ConnectionString = conString
                conStrSetting.ProviderName = "System.Data.SqlClient"
                conStrSetting.Name = cConnectionStringKey
            End If


            System.Configuration.ConfigurationManager.RefreshSection("connectionStrings")
            Return True
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Function

    Private Function SetConnection(ConnectionName As String) As Boolean
        Try
            Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            If config Is Nothing Then
                MsgBox("Unable to set config file.", MsgBoxStyle.Critical, "File")
                Exit Try
            End If

            Dim connStrings As System.Configuration.ConnectionStringsSection = config.ConnectionStrings
            If connStrings Is Nothing Then
                MsgBox("Unable to find connection strings in config file.", MsgBoxStyle.Critical, "Connection String")
                Exit Try
            End If

            Dim conString As String = connStrings.ConnectionStrings(ConnectionName).ConnectionString
            Dim b() As Byte = System.Text.ASCIIEncoding.ASCII.GetBytes(conString)
            conString = Convert.ToBase64String(b)

            Dim conStrSetting As System.Configuration.ConnectionStringSettings = connStrings.ConnectionStrings(cConnectionStringKey)
            If conStrSetting Is Nothing Then
                conStrSetting = New System.Configuration.ConnectionStringSettings
                conStrSetting.ConnectionString = conString
                conStrSetting.ProviderName = "System.Data.SqlClient"
                conStrSetting.Name = cConnectionStringKey

                config.ConnectionStrings.ConnectionStrings.Add(conStrSetting)
            Else
                conStrSetting.ConnectionString = conString
                conStrSetting.ProviderName = "System.Data.SqlClient"
                conStrSetting.Name = cConnectionStringKey
            End If

            config.Save()
            System.Configuration.ConfigurationManager.RefreshSection("connectionStrings")
            Return True
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Function

#End Region

#Region "Public functions"

    ''' <summary>
    ''' This function is used to get Instance of this class
    ''' </summary>
    ''' <returns>Instance of this class</returns>
    ''' <remarks></remarks>
    Public Shared Function GetInstance() As FrmMain
        If sInstance Is Nothing Then
            sInstance = New FrmMain
        End If

        Return sInstance
    End Function

    Public Sub ShowHelp()
        System.Windows.Forms.Help.ShowHelp(Me, "Help.chm", HelpNavigator.AssociateIndex)
    End Sub

#End Region

#Region "Menus Visibility"

    Private Sub SetMenusVisibility()

        If gUser Is Nothing Then
            MsgBox("User Object not set.", MsgBoxStyle.Critical)
            Application.Exit()
        End If

        With gUser
            ToolsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.Tools)
            ProfileMasterToolsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.ProfileMaster)
            UserMasterToolsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.UserMaster)
            NewPasswordToolsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.ChangePassword)
            CompanyInformationToolsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.CompanyInformation)
            MastersToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.Masters)
            BranchMastersToolStripMenuItem.Visible = False 'AndedTheString(.AuthorizationNo, Authorization.a)
            CustomersMastersToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.Customers)
            SpecialityMastersToolStripMenuItem.Visible = False 'AndedTheString(.AuthorizationNo, Authorization.a)
            DoctorsMastersToolStripMenuItem.Visible = False 'AndedTheString(.AuthorizationNo, Authorization.a)
            ManufacturerMastersToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.Manufacturers)
            VendorsMastersToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.Vendors)
            StoragePointsMastersToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.StoragePoint)
            GenericsMastersToolStripMenuItem.Visible = False 'AndedTheString(.AuthorizationNo, Authorization.a)
            PIMastersToolStripMenuItem.Visible = False 'AndedTheString(.AuthorizationNo, Authorization.a)
            CategoryMastersToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.Category)
            ScheduleMastersToolStripMenuItem.Visible = False 'AndedTheString(.AuthorizationNo, Authorization.a)
            ItemsMastersToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.Items)
            TransactionsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.Transactions)
            SalesTransactionsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.Sales)
            PurchaseTransactionsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.Purchase)
            CashOutTransactionsToolStripMenuItem.Visible = False 'AndedTheString(.AuthorizationNo, Authorization.a)
            AccountGroupsMastersToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.AccountGroup)
            AccountHeadsMastersToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.AccountHead)
            SalesReturnTransactionsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.SalesReturn)
            AccountsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.Accounts)
            JournalEntryAccountsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.JournalEntry)
            CashPaymentAccountsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.CashPayment)
            CashReceiptAccountsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.CashReceipt)
            ChequePaymentAccountsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.ChequePayment)
            ChequeReceiptAccountsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.ChequeReceipt)
            PurchaseOrderTransactionsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.PurchaseOrder)
            DestructionSlipsTransactionsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.DestructionSlips)
            'ExpirySlipsTransactionsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.ExpirySlips)
            AccountReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.AccountReports)
            TrialBalanceAccountReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.TrialBalance)
            LedgerAccountReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.Ledger)
            CashBookAccountReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.CashBook)
            BankBookAccountReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.BankBook)
            StockReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.StockReports)
            StockLedgerStockReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.StockLedger)
            SalesReportToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.SalesReports)
            GrossSalesSalesReportToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.GrossSale)
            ItemwiseSalesSalesReportToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.ItemwiseSale)
            PurchaseReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.PurchaseReports)
            VendorwisePurchasePurchaseReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.VendorwisePurchase)
            JournalBookAccountReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.JournalBook)
            StockInHandStockReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.StockInHand)
            ItemsAvailabilityStockReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.ItemsAvailability)
            GrossPurchasePurchaseReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.GrossPurchase)
            VATSalesReportToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.VAT)
            PurchaseReturnTransactionsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.PurchaseReturn)
            'ExpiryReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.ExpiryReports)
            'ExpiryDetailExpiryReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.ExpiryReports_Slips)
            'ExpiryStockExpiryReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.ExpiryReports_Stock)
            StockInDemandStockReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.StockInDemand)
            CustomerTypeMastersToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.CustomerType)
            SalesReturnWithoutBillTransactionsToolStripMenuItem.Visible = False ' AndedTheString(.AuthorizationNo, Authorization.a)
            CustomerwiseSaleSalesReportToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.CustomerwiseSale)
            CreditSaleSalesReportToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.CreditSale)
            DatewisePurchasePurchaseReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.DatewisePurchase)
            ItemwisePurchasePurchaseReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.ItemwisePurchase)
            PurchaseReturnPurchaseReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.PurchaseReturnReport)
            LegalTermsToolsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.LegalTerms)
            TrackLogToolsToolStripMenuItem.Visible = False 'AndedTheString(.AuthorizationNo, Authorization.a)
            TransporterMastersToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.Transporters)
            HQMasterMastersToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.HQ)
            DivisionMastersToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.Division)
            TaxMasterMastersToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.Tax)
            IssueSampleTransactionsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.IssueSample)
            HQWiseSaleSalesReportToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.HQwiseSale)
            SampleReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.SampleReports)
            CustomerwiseSampleReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.CustomerwiseReport)
            DatewiseSaleReturnSalesReportToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.DatewiseSaleReturn)
            LRsTransactionsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.LRs)
            ReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.Reports)
            CollectionRegisterReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.CollectionRegister)
            PaymentRegisterReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.PaymentRegister)
            PartywiseSaleReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.PartywiseItemwiseSale)
            SaleRegisterReportsToolStripMenuItem.Visible = False 'AndedTheString(.AuthorizationNo, Authorization.a)
            StockAndSaleReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.StockAndSale)
            ItemwisePartywiseSaleReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.ItemwisePartywiseSale)
            CreditNoteAccountsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.CreditNote)
            DebitNoteAccountsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.DebitNote)
            OutStandingsReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.Outstandings)
            ApplicationSettingsToolsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.ApplicationSettings)
            TransferDataToolsToolStripMenuItem.Visible = False ' AndedTheString(.AuthorizationNo, Authorization.a)
            StockAndSaleIIReportsToolStripMenuItem.Visible = AndedTheString(.AuthorizationNo, Authorization.StockAndSaleII)

        End With

    End Sub

    Private Sub MastersToolStripMenuItem_DropDownOpened(ByVal sender As Object, ByVal e As System.EventArgs) Handles MastersToolStripMenuItem.DropDownOpened
        BranchMastersToolStripMenuItem.Visible = False
        PIMastersToolStripMenuItem.Visible = False

        ToolStripMenuItem1.Visible = BranchMastersToolStripMenuItem.Visible
        ToolStripMenuItem2.Visible = CustomersMastersToolStripMenuItem.Visible Or SpecialityMastersToolStripMenuItem.Visible Or DoctorsMastersToolStripMenuItem.Visible
        ToolStripMenuItem3.Visible = ManufacturerMastersToolStripMenuItem.Visible Or VendorsMastersToolStripMenuItem.Visible
        ToolStripMenuItem4.Visible = StoragePointsMastersToolStripMenuItem.Visible Or GenericsMastersToolStripMenuItem.Visible Or PIMastersToolStripMenuItem.Visible Or CategoryMastersToolStripMenuItem.Visible Or ScheduleMastersToolStripMenuItem.Visible
        ToolStripMenuItem6.Visible = (ItemsMastersToolStripMenuItem.Visible) And (AccountGroupsMastersToolStripMenuItem.Visible Or AccountHeadsMastersToolStripMenuItem.Visible)
    End Sub

    Private Sub TransactionsToolStripMenuItem_DropDownOpened(ByVal sender As Object, ByVal e As System.EventArgs) Handles TransactionsToolStripMenuItem.DropDownOpened
        ToolStripMenuItem5.Visible = SalesReportToolStripMenuItem.Visible Or PurchaseTransactionsToolStripMenuItem.Visible
        ToolStripMenuItem7.Visible = CashOutTransactionsToolStripMenuItem.Visible
        ToolStripMenuItem10.Visible = (SalesReturnTransactionsToolStripMenuItem.Visible) Or PurchaseReturnTransactionsToolStripMenuItem.Visible Or DestructionSlipsTransactionsToolStripMenuItem.Visible And (PurchaseOrderTransactionsToolStripMenuItem.Visible) 'Or ExpirySlipsTransactionsToolStripMenuItem.Visible) 
    End Sub

    Private Sub AccountsToolStripMenuItem_DropDownOpened(ByVal sender As Object, ByVal e As System.EventArgs) Handles AccountsToolStripMenuItem.DropDownOpened
        ToolStripMenuItem8.Visible = CashPaymentAccountsToolStripMenuItem.Visible Or CashReceiptAccountsToolStripMenuItem.Visible
        ToolStripMenuItem9.Visible = (ChequePaymentAccountsToolStripMenuItem.Visible Or ChequeReceiptAccountsToolStripMenuItem.Visible) And (JournalEntryAccountsToolStripMenuItem.Visible)
    End Sub

    Private Sub StockReportsToolStripMenuItem_DropDownOpened(ByVal sender As Object, ByVal e As System.EventArgs) Handles StockReportsToolStripMenuItem.DropDownOpened
        ToolStripMenuItem13.Visible = (StockInHandStockReportsToolStripMenuItem.Visible Or StockLedgerStockReportsToolStripMenuItem.Visible) And (ItemsAvailabilityStockReportsToolStripMenuItem.Visible)
        'ToolStripMenuItem15.Visible = (ItemsAvailabilityStockReportsToolStripMenuItem.Visible) 'And (ExpiryReportsToolStripMenuItem.Visible)
    End Sub

    Private Sub SalesReportToolStripMenuItem_DropDownOpened(ByVal sender As Object, ByVal e As System.EventArgs) Handles SalesReportToolStripMenuItem.DropDownOpened
        ToolStripMenuItem14.Visible = (GrossSalesSalesReportToolStripMenuItem.Visible Or ItemwiseSalesSalesReportToolStripMenuItem.Visible) And (VATSalesReportToolStripMenuItem.Visible)
    End Sub

    Private Sub AccountReportsToolStripMenuItem_DropDownOpened(ByVal sender As Object, ByVal e As System.EventArgs) Handles AccountReportsToolStripMenuItem.DropDownOpened
        ToolStripMenuItem12.Visible = CashBookAccountReportsToolStripMenuItem.Visible Or BankBookAccountReportsToolStripMenuItem.Visible Or JournalBookAccountReportsToolStripMenuItem.Visible
        ToolStripMenuItem11.Visible = LedgerAccountReportsToolStripMenuItem.Visible And TrialBalanceAccountReportsToolStripMenuItem.Visible
    End Sub

#End Region

#Region "File Menu"

    Private Sub LogOffFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOffFileToolStripMenuItem.Click
        Try
            LogMeOff()
            gUser = Nothing
            flagLoading = True
            Me.Visible = False
            Dim frm As New FrmLogin
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

                'Perform all starting task here
                LoadApplicationValues()

                Me.Visible = True
                SetControls()
            Else
                Application.Exit()
            End If

            flagLoading = False

        Catch ex As Exception
            AddToLog(ex)

            Application.Exit()
        End Try
    End Sub

    Private Sub ExitFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitFileToolStripMenuItem.Click
        LogMeOff()
        Me.Close()
    End Sub

#End Region

#Region "Masters Menu"

    Private Sub BranchMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BranchMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmBranchMaster
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CustomerTypeMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerTypeMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmCustomerType
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CustomersMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmCustomerMaster
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SpecialityMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpecialityMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmSpecialityMaster
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub DoctorsMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoctorsMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmDoctorMaster
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub ManufacturerMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManufacturerMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmManufacturerMaster
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub VendorsMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VendorsMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmVendorMaster
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub StoragePointsMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StoragePointsMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmStorageMaster
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GenericsMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenericsMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmGenericMaster
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub PIMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmPIMaster
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CategoryMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoryMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmCategoryMaster
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub ScheduleMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScheduleMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmScheduleMaster
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub ItemsMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemsMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmItemMaster
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub AccountGroupsMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountGroupsMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmAccountGroups
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub AccountHeadsMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountHeadsMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmAccountHeads
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub TransporterMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransporterMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmTransporter
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub HQMasterMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HQMasterMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmHQMaster
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub DivisionMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DivisionMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmDivisionMaster
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub TaxMasterMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaxMasterMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmTaxMaster
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub OpeningStockMastersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpeningStockMastersToolStripMenuItem.Click
        Try
            Dim frm As New FrmOpeningStock
            frm.ShowDialog(Me)
            frm.Dispose()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Transactions Menu"

    Private Sub SalesTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesTransactionsToolStripMenuItem.Click
        Try
            Dim frm As New FrmSales
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub PurchaseTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseTransactionsToolStripMenuItem.Click
        Try
            Dim frm As New FrmPurchase
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CashOutTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashOutTransactionsToolStripMenuItem.Click
        Try
            Dim frm As New FrmSaleCashOut
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SalesReturnTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReturnTransactionsToolStripMenuItem.Click
        Try
            Dim frm As New FrmSalesReturnPartywise 'FrmSalesReturn
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub PurchaseReturnTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReturnTransactionsToolStripMenuItem.Click
        Try
            Dim frm As New FrmPurchaseReturnPartywise 'FrmPurchaseReturn
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub PurchaseOrderTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrderTransactionsToolStripMenuItem.Click
        Try
            Dim frm As New FrmPurchaseOrder
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub DestructionSlipsTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DestructionSlipsTransactionsToolStripMenuItem.Click
        Try
            Dim frm As New FrmDestructionSlip
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub ExpirySlipsTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim frm As New FrmExpiry
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SalesReturnWithoutBillTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReturnWithoutBillTransactionsToolStripMenuItem.Click
        Try
            Dim frm As New FrmSalesReturnWithoutBill
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub IssueSampleTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IssueSampleTransactionsToolStripMenuItem.Click
        Try
            Dim frm As New FrmSample
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LRsTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LRsTransactionsToolStripMenuItem.Click
        Try
            Dim diag As New DlgLR
            diag.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Accounts Menu"

    Private Sub JournalEntryAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalEntryAccountsToolStripMenuItem.Click
        Try
            Dim frm As New FrmJournalEntry
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CashPaymentAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashPaymentAccountsToolStripMenuItem.Click
        Try
            Dim frm As New FrmCashPayment
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CashReceiptAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashReceiptAccountsToolStripMenuItem.Click
        Try
            Dim frm As New FrmCashReceipt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub ChequePaymentAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChequePaymentAccountsToolStripMenuItem.Click
        Try
            Dim frm As New FrmChequePayment
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub ChequeReceiptAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChequeReceiptAccountsToolStripMenuItem.Click
        Try
            Dim frm As New FrmChequeReceipt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CreditNoteAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditNoteAccountsToolStripMenuItem.Click
        Try
            Dim frm As New FrmCreditNote
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub DebitNoteAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebitNoteAccountsToolStripMenuItem.Click
        Try
            Dim frm As New FrmDebitNote
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Stock Reports"

    Private Sub StockLedgerStockReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockLedgerStockReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgStockLedger
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub StockInHandStockReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockInHandStockReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgStockRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub ItemsAvailabilityStockReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemsAvailabilityStockReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgItemsAvailabilityRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub ExpiryDetailExpiryReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim frm As New DlgExpiryDetailRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub ExpiryStockExpiryReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim frm As New DlgExpiryRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub StockInDemandStockReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockInDemandStockReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgStockInDemandRpt
            frm.SetStockInDemand()
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Sales Report"

    Private Sub GrossSalesSalesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrossSalesSalesReportToolStripMenuItem.Click
        Try
            Dim frm As New DlgGrossSalesRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub ItemwiseSalesSalesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemwiseSalesSalesReportToolStripMenuItem.Click
        Try
            Dim frm As New DlgItemwiseSaleRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub VATSalesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VATSalesReportToolStripMenuItem.Click
        Try
            Dim frm As New DlgTaxOnSalesRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CustomerwiseSaleSalesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerwiseSaleSalesReportToolStripMenuItem.Click
        Try
            Dim frm As New DlgPatientWiseSaleRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CreditSaleSalesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditSaleSalesReportToolStripMenuItem.Click
        Try
            Dim frm As New DlgCreditSaleRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub HQWiseSaleSalesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HQWiseSaleSalesReportToolStripMenuItem.Click
        Try
            Dim frm As New DlgHQWiseSaleRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub DatewiseSaleReturnSalesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatewiseSaleReturnSalesReportToolStripMenuItem.Click
        Try
            Dim frm As New DlgSalesReturnRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Purchase Reports"

    Private Sub VendorwisePurchasePurchaseReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VendorwisePurchasePurchaseReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgVendorwisePurchaseRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrossPurchasePurchaseReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrossPurchasePurchaseReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgGrossPurchaseRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub DatewisePurchasePurchaseReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatewisePurchasePurchaseReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgPurchaseRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub ItemwisePurchasePurchaseReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemwisePurchasePurchaseReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgItemWisePurchaseRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub PurchaseReturnPurchaseReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReturnPurchaseReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgPurchaseReturnRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Sample Reports"

    Private Sub CustomerwiseSampleReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerwiseSampleReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgCustomerWiseSampleRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Reports"

    Private Sub CollectionRegisterReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollectionRegisterReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgCollectionRegisterRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub PaymentRegisterReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentRegisterReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgPaymentRegisterRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub PartywiseSaleReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartywiseSaleReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgPartywiseSaleRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub StockAndSaleReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockAndSaleReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgStockAndSaleRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SaleRegisterReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleRegisterReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgSaleRegisterRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub ItemwisePartywiseSaleReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemwisePartywiseSaleReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgItemwisePartywiseSaleRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub OutStandingsReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutStandingsReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgOutstandingRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub StockAndSaleIIReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockAndSaleIIReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgStockAndSaleRpt
            frm.SetFlagForII()
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Account Reports"

    Private Sub TrialBalanceAccountReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrialBalanceAccountReportsToolStripMenuItem.Click
        Try
            Dim frm As New FrmTrialBalance
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LedgerAccountReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerAccountReportsToolStripMenuItem.Click
        Try
            Dim diag As New DlgLedgerBookRpt
            diag.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CashBookAccountReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashBookAccountReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgCashBookRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BankBookAccountReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankBookAccountReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgBankBookRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub JournalBookAccountReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalBookAccountReportsToolStripMenuItem.Click
        Try
            Dim frm As New DlgJournalBookRpt
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Tools Menu"

    Private Sub ProfileMasterToolsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProfileMasterToolsToolStripMenuItem.Click
        Try
            Dim frm As New FrmProfileMaster
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub UserMasterToolsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserMasterToolsToolStripMenuItem.Click
        Try
            Dim frm As New FrmUserMaster
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub NewPasswordToolsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewPasswordToolsToolStripMenuItem.Click
        Try
            Dim frm As New FrmNewPassword
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CompanyInformationToolsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanyInformationToolsToolStripMenuItem.Click
        Try
            Dim frm As New FrmCompanyInfo
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LegalTermsToolsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LegalTermsToolsToolStripMenuItem.Click
        Try
            Dim frm As New FrmLegalTerms
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub TrackLogToolsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackLogToolsToolStripMenuItem.Click
        Try
            Dim frm As New FrmTrackLog
            frm.ShowDialog(Me)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub ApplicationSettingsToolsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApplicationSettingsToolsToolStripMenuItem.Click
        Try
            Dim frm As New FrmAppSettings
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub TransferDataToolsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferDataToolsToolStripMenuItem.Click
        Try
            Dim frm As New FrmTransferData
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Help Menu"

    Private Sub HelpHelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpHelpToolStripMenuItem.Click
        ShowHelp()
    End Sub

#End Region

#Region "Login Expiry Functionality"

    Dim lUser As ClsUserMaster = Nothing
    Dim lLoginTime As TimeSpan = Nothing
    Dim lCountFail As Integer = 0

    Private Sub BgWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Try
            lUser = TryCast(e.Argument, ClsUserMaster)
            lLoginTime = Now.TimeOfDay
            While True
                If gUser Is Nothing Then
                    e.Cancel = True
                    Exit Try
                Else
                    Respond()

                    Thread.Sleep(10000) '10 Second
                End If
            End While

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub Respond()
        If lUser IsNot Nothing Then
            If UpdateLoginList(Me.Name, lUser.LoginName, lLoginTime.TotalMilliseconds) <> EnResult.Change Then
                lCountFail = lCountFail + 1

                ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Message), "Problem in connection. Please check.")

                If lCountFail > 4 Then
                    Me.Invoke(New LoginExpiredDelegate(AddressOf LoginExpired))
                    lUser = Nothing
                    Thread.Sleep(0)
                End If
            Else
                lCountFail = 0
            End If
        End If
    End Sub

    Private Sub LoginExpired()
        MsgBox("Login Expired. Please re-login.", MsgBoxStyle.Critical, "Expired")
        LogOffFileToolStripMenuItem_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub Message(ByVal o As Object)
        Dim msg As String = o.ToString
        MsgBox(msg, MsgBoxStyle.Critical, "Problem")
    End Sub

    Private Sub LogMeOff()
        If gUser IsNot Nothing Then DeleteFromLoginList(Me.Name, gUser.LoginName)
    End Sub

#End Region


    Private Sub BunchReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BunchReportToolStripMenuItem.Click
        Try
            Dim frm As New Dlg_GatePass
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub TaxReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TaxReportToolStripMenuItem.Click
        Try
            Dim frm As New DlgTaxReport

            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub DailyTransactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DailyTransactionToolStripMenuItem.Click
        Try
            Dim frm As New frmDailyTransaction
            frm.Height = Me.Height
            frm.Width = Me.Width
            frm.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub
End Class
