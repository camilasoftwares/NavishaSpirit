<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPurchase
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPurchase))
        Me.GrpPurchase = New System.Windows.Forms.GroupBox()
        Me.LblAddVendor = New System.Windows.Forms.Label()
        Me.TxtTINNo = New System.Windows.Forms.TextBox()
        Me.CmbAgainstOrder = New System.Windows.Forms.ComboBox()
        Me.TxtVoucher = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DtPkrPurchaseDate = New System.Windows.Forms.DateTimePicker()
        Me.CmbSupplier = New System.Windows.Forms.ComboBox()
        Me.CmbStatus = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtPurchaseCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.GrdItems = New System.Windows.Forms.DataGridView()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.GrpTotals = New System.Windows.Forms.GroupBox()
        Me.CmbItem = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GrpItem = New System.Windows.Forms.GroupBox()
        Me.TxtRate1 = New System.Windows.Forms.TextBox()
        Me.TxtRate3 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtRate2 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TxtPTS = New System.Windows.Forms.TextBox()
        Me.TxtManufactureDate = New System.Windows.Forms.MaskedTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtPTR = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtMRP = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbCategory = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtExpiryDate = New System.Windows.Forms.MaskedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LblCustomerTypePrice = New System.Windows.Forms.Label()
        Me.LblAddItem = New System.Windows.Forms.Label()
        Me.PnlQuantity = New System.Windows.Forms.Panel()
        Me.TxtDiscountPercent = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.TxtFreeQuantity = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtPurchaseQuantity = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TxtPackQty = New System.Windows.Forms.TextBox()
        Me.TxtPurchasePrice = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CmbStorage = New System.Windows.Forms.ComboBox()
        Me.BtnRemove = New System.Windows.Forms.Button()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.PnlGross = New System.Windows.Forms.Panel()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.TxtDiscount = New System.Windows.Forms.TextBox()
        Me.TxtTaxableAmount = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.TxtDiscountOnBill = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.TxtGrossAmount = New System.Windows.Forms.TextBox()
        Me.PnlTax = New System.Windows.Forms.Panel()
        Me.LblTaxPercent = New System.Windows.Forms.Label()
        Me.TxtTaxAmt = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.CmbTax = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TxtDebitAdj = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TxtCreditAdj = New System.Windows.Forms.TextBox()
        Me.PnlFinal = New System.Windows.Forms.Panel()
        Me.TxtFreightCharge = New System.Windows.Forms.TextBox()
        Me.LblFreightCharge = New System.Windows.Forms.Label()
        Me.TxtRemark = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtPreExciseAmount = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.TxtOverAllDiscount = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TxtBillRoundOff = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.TxtBillNetAmount = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.GrpPurchase.SuspendLayout()
        CType(Me.GrdItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpTotals.SuspendLayout()
        Me.GrpItem.SuspendLayout()
        Me.PnlQuantity.SuspendLayout()
        Me.PnlGross.SuspendLayout()
        Me.PnlTax.SuspendLayout()
        Me.PnlFinal.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpPurchase
        '
        Me.GrpPurchase.Controls.Add(Me.LblAddVendor)
        Me.GrpPurchase.Controls.Add(Me.TxtTINNo)
        Me.GrpPurchase.Controls.Add(Me.CmbAgainstOrder)
        Me.GrpPurchase.Controls.Add(Me.TxtVoucher)
        Me.GrpPurchase.Controls.Add(Me.Label22)
        Me.GrpPurchase.Controls.Add(Me.Label20)
        Me.GrpPurchase.Controls.Add(Me.Label17)
        Me.GrpPurchase.Controls.Add(Me.DtPkrPurchaseDate)
        Me.GrpPurchase.Controls.Add(Me.CmbSupplier)
        Me.GrpPurchase.Controls.Add(Me.CmbStatus)
        Me.GrpPurchase.Controls.Add(Me.Label6)
        Me.GrpPurchase.Controls.Add(Me.Label5)
        Me.GrpPurchase.Controls.Add(Me.Label2)
        Me.GrpPurchase.Controls.Add(Me.TxtPurchaseCode)
        Me.GrpPurchase.Controls.Add(Me.Label1)
        Me.GrpPurchase.Location = New System.Drawing.Point(9, 2)
        Me.GrpPurchase.Name = "GrpPurchase"
        Me.GrpPurchase.Size = New System.Drawing.Size(1004, 75)
        Me.GrpPurchase.TabIndex = 0
        Me.GrpPurchase.TabStop = False
        '
        'LblAddVendor
        '
        Me.LblAddVendor.BackColor = System.Drawing.Color.Transparent
        Me.LblAddVendor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddVendor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddVendor.Image = CType(resources.GetObject("LblAddVendor.Image"), System.Drawing.Image)
        Me.LblAddVendor.Location = New System.Drawing.Point(961, 17)
        Me.LblAddVendor.Name = "LblAddVendor"
        Me.LblAddVendor.Size = New System.Drawing.Size(21, 21)
        Me.LblAddVendor.TabIndex = 8
        Me.LblAddVendor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtTINNo
        '
        Me.TxtTINNo.BackColor = System.Drawing.Color.White
        Me.TxtTINNo.Enabled = False
        Me.TxtTINNo.Location = New System.Drawing.Point(91, 45)
        Me.TxtTINNo.Name = "TxtTINNo"
        Me.TxtTINNo.ReadOnly = True
        Me.TxtTINNo.Size = New System.Drawing.Size(243, 20)
        Me.TxtTINNo.TabIndex = 10
        Me.TxtTINNo.TabStop = False
        '
        'CmbAgainstOrder
        '
        Me.CmbAgainstOrder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbAgainstOrder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbAgainstOrder.FormattingEnabled = True
        Me.CmbAgainstOrder.Location = New System.Drawing.Point(702, 44)
        Me.CmbAgainstOrder.Name = "CmbAgainstOrder"
        Me.CmbAgainstOrder.Size = New System.Drawing.Size(200, 21)
        Me.CmbAgainstOrder.Sorted = True
        Me.CmbAgainstOrder.TabIndex = 14
        '
        'TxtVoucher
        '
        Me.TxtVoucher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.TxtVoucher.FormattingEnabled = True
        Me.TxtVoucher.Location = New System.Drawing.Point(414, 44)
        Me.TxtVoucher.Name = "TxtVoucher"
        Me.TxtVoucher.Size = New System.Drawing.Size(167, 21)
        Me.TxtVoucher.Sorted = True
        Me.TxtVoucher.TabIndex = 12
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(625, 46)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(71, 13)
        Me.Label22.TabIndex = 13
        Me.Label22.Text = "Against Order"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(340, 46)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 13)
        Me.Label20.TabIndex = 11
        Me.Label20.Text = "Voucher No."
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(41, 47)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 13)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "TIN No."
        '
        'DtPkrPurchaseDate
        '
        Me.DtPkrPurchaseDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrPurchaseDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPkrPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrPurchaseDate.Location = New System.Drawing.Point(335, 19)
        Me.DtPkrPurchaseDate.Name = "DtPkrPurchaseDate"
        Me.DtPkrPurchaseDate.Size = New System.Drawing.Size(103, 20)
        Me.DtPkrPurchaseDate.TabIndex = 3
        '
        'CmbSupplier
        '
        Me.CmbSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbSupplier.FormattingEnabled = True
        Me.CmbSupplier.Location = New System.Drawing.Point(702, 18)
        Me.CmbSupplier.Name = "CmbSupplier"
        Me.CmbSupplier.Size = New System.Drawing.Size(253, 21)
        Me.CmbSupplier.Sorted = True
        Me.CmbSupplier.TabIndex = 7
        '
        'CmbStatus
        '
        Me.CmbStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbStatus.FormattingEnabled = True
        Me.CmbStatus.Location = New System.Drawing.Point(497, 18)
        Me.CmbStatus.Name = "CmbStatus"
        Me.CmbStatus.Size = New System.Drawing.Size(113, 21)
        Me.CmbStatus.Sorted = True
        Me.CmbStatus.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(616, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Supplier Name*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(446, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Status *"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(254, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Purchase Date"
        '
        'TxtPurchaseCode
        '
        Me.TxtPurchaseCode.BackColor = System.Drawing.Color.White
        Me.TxtPurchaseCode.Enabled = False
        Me.TxtPurchaseCode.Location = New System.Drawing.Point(91, 19)
        Me.TxtPurchaseCode.Name = "TxtPurchaseCode"
        Me.TxtPurchaseCode.ReadOnly = True
        Me.TxtPurchaseCode.Size = New System.Drawing.Size(157, 20)
        Me.TxtPurchaseCode.TabIndex = 1
        Me.TxtPurchaseCode.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Purchase Code"
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrint.Location = New System.Drawing.Point(185, 15)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(72, 26)
        Me.BtnPrint.TabIndex = 2
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'GrdItems
        '
        Me.GrdItems.AllowUserToAddRows = False
        Me.GrdItems.AllowUserToDeleteRows = False
        Me.GrdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdItems.Location = New System.Drawing.Point(10, 114)
        Me.GrdItems.Name = "GrdItems"
        Me.GrdItems.ReadOnly = True
        Me.GrdItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdItems.Size = New System.Drawing.Size(989, 331)
        Me.GrdItems.TabIndex = 30
        '
        'BtnNew
        '
        Me.BtnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNew.Location = New System.Drawing.Point(29, 16)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(72, 26)
        Me.BtnNew.TabIndex = 0
        Me.BtnNew.Text = "&New"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(343, 16)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 4
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Location = New System.Drawing.Point(107, 16)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(72, 26)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnSearch
        '
        Me.BtnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSearch.Location = New System.Drawing.Point(264, 16)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(72, 26)
        Me.BtnSearch.TabIndex = 3
        Me.BtnSearch.Text = "Searc&h"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'GrpTotals
        '
        Me.GrpTotals.Controls.Add(Me.BtnSearch)
        Me.GrpTotals.Controls.Add(Me.BtnPrint)
        Me.GrpTotals.Controls.Add(Me.BtnNew)
        Me.GrpTotals.Controls.Add(Me.BtnClose)
        Me.GrpTotals.Controls.Add(Me.BtnSave)
        Me.GrpTotals.Location = New System.Drawing.Point(116, 82)
        Me.GrpTotals.Name = "GrpTotals"
        Me.GrpTotals.Size = New System.Drawing.Size(427, 49)
        Me.GrpTotals.TabIndex = 12
        Me.GrpTotals.TabStop = False
        '
        'CmbItem
        '
        Me.CmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbItem.FormattingEnabled = True
        Me.CmbItem.Location = New System.Drawing.Point(131, 32)
        Me.CmbItem.Name = "CmbItem"
        Me.CmbItem.Size = New System.Drawing.Size(301, 21)
        Me.CmbItem.Sorted = True
        Me.CmbItem.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(128, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Item Name*"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(536, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "PTS"
        Me.Label8.Visible = False
        '
        'GrpItem
        '
        Me.GrpItem.Controls.Add(Me.TxtRate1)
        Me.GrpItem.Controls.Add(Me.TxtRate3)
        Me.GrpItem.Controls.Add(Me.Label21)
        Me.GrpItem.Controls.Add(Me.TxtRate2)
        Me.GrpItem.Controls.Add(Me.Label24)
        Me.GrpItem.Controls.Add(Me.Label25)
        Me.GrpItem.Controls.Add(Me.TxtPTS)
        Me.GrpItem.Controls.Add(Me.TxtManufactureDate)
        Me.GrpItem.Controls.Add(Me.Label15)
        Me.GrpItem.Controls.Add(Me.TxtPTR)
        Me.GrpItem.Controls.Add(Me.Label13)
        Me.GrpItem.Controls.Add(Me.TxtMRP)
        Me.GrpItem.Controls.Add(Me.Label3)
        Me.GrpItem.Controls.Add(Me.CmbCategory)
        Me.GrpItem.Controls.Add(Me.Label14)
        Me.GrpItem.Controls.Add(Me.TxtExpiryDate)
        Me.GrpItem.Controls.Add(Me.Label12)
        Me.GrpItem.Controls.Add(Me.LblCustomerTypePrice)
        Me.GrpItem.Controls.Add(Me.LblAddItem)
        Me.GrpItem.Controls.Add(Me.PnlQuantity)
        Me.GrpItem.Controls.Add(Me.CmbStorage)
        Me.GrpItem.Controls.Add(Me.BtnRemove)
        Me.GrpItem.Controls.Add(Me.BtnAdd)
        Me.GrpItem.Controls.Add(Me.Label27)
        Me.GrpItem.Controls.Add(Me.Label26)
        Me.GrpItem.Controls.Add(Me.GrdItems)
        Me.GrpItem.Controls.Add(Me.CmbItem)
        Me.GrpItem.Controls.Add(Me.Label7)
        Me.GrpItem.Controls.Add(Me.Label8)
        Me.GrpItem.Location = New System.Drawing.Point(10, 83)
        Me.GrpItem.Name = "GrpItem"
        Me.GrpItem.Size = New System.Drawing.Size(1005, 451)
        Me.GrpItem.TabIndex = 1
        Me.GrpItem.TabStop = False
        '
        'TxtRate1
        '
        Me.TxtRate1.Location = New System.Drawing.Point(398, 83)
        Me.TxtRate1.Name = "TxtRate1"
        Me.TxtRate1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtRate1.Size = New System.Drawing.Size(59, 20)
        Me.TxtRate1.TabIndex = 25
        '
        'TxtRate3
        '
        Me.TxtRate3.Location = New System.Drawing.Point(602, 82)
        Me.TxtRate3.Name = "TxtRate3"
        Me.TxtRate3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtRate3.Size = New System.Drawing.Size(59, 20)
        Me.TxtRate3.TabIndex = 19
        Me.TxtRate3.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(402, 65)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(36, 13)
        Me.Label21.TabIndex = 24
        Me.Label21.Text = "Rate2"
        '
        'TxtRate2
        '
        Me.TxtRate2.Location = New System.Drawing.Point(337, 83)
        Me.TxtRate2.Name = "TxtRate2"
        Me.TxtRate2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtRate2.Size = New System.Drawing.Size(59, 20)
        Me.TxtRate2.TabIndex = 23
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(334, 66)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(36, 13)
        Me.Label24.TabIndex = 22
        Me.Label24.Text = "Rate1"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(607, 65)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(29, 13)
        Me.Label25.TabIndex = 18
        Me.Label25.Text = "PTD"
        Me.Label25.Visible = False
        '
        'TxtPTS
        '
        Me.TxtPTS.Location = New System.Drawing.Point(539, 82)
        Me.TxtPTS.Name = "TxtPTS"
        Me.TxtPTS.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPTS.Size = New System.Drawing.Size(59, 20)
        Me.TxtPTS.TabIndex = 17
        Me.TxtPTS.Visible = False
        '
        'TxtManufactureDate
        '
        Me.TxtManufactureDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtManufactureDate.Location = New System.Drawing.Point(688, 33)
        Me.TxtManufactureDate.Mask = "00/0000"
        Me.TxtManufactureDate.Name = "TxtManufactureDate"
        Me.TxtManufactureDate.Size = New System.Drawing.Size(78, 20)
        Me.TxtManufactureDate.TabIndex = 12
        Me.TxtManufactureDate.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(685, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 13)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Manufacture Date"
        Me.Label15.Visible = False
        '
        'TxtPTR
        '
        Me.TxtPTR.Location = New System.Drawing.Point(667, 82)
        Me.TxtPTR.Name = "TxtPTR"
        Me.TxtPTR.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPTR.Size = New System.Drawing.Size(59, 20)
        Me.TxtPTR.TabIndex = 21
        Me.TxtPTR.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(671, 66)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 13)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "PTR"
        Me.Label13.Visible = False
        '
        'TxtMRP
        '
        Me.TxtMRP.Location = New System.Drawing.Point(272, 83)
        Me.TxtMRP.Name = "TxtMRP"
        Me.TxtMRP.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtMRP.Size = New System.Drawing.Size(59, 20)
        Me.TxtMRP.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(269, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "MRP"
        '
        'CmbCategory
        '
        Me.CmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCategory.FormattingEnabled = True
        Me.CmbCategory.Location = New System.Drawing.Point(17, 32)
        Me.CmbCategory.Name = "CmbCategory"
        Me.CmbCategory.Size = New System.Drawing.Size(108, 21)
        Me.CmbCategory.Sorted = True
        Me.CmbCategory.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Category"
        '
        'TxtExpiryDate
        '
        Me.TxtExpiryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtExpiryDate.Location = New System.Drawing.Point(604, 33)
        Me.TxtExpiryDate.Mask = "00/0000"
        Me.TxtExpiryDate.Name = "TxtExpiryDate"
        Me.TxtExpiryDate.Size = New System.Drawing.Size(78, 20)
        Me.TxtExpiryDate.TabIndex = 10
        Me.TxtExpiryDate.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.AliceBlue
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(463, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 26)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "(Per " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pack Size)"
        '
        'LblCustomerTypePrice
        '
        Me.LblCustomerTypePrice.BackColor = System.Drawing.Color.Transparent
        Me.LblCustomerTypePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblCustomerTypePrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblCustomerTypePrice.Image = CType(resources.GetObject("LblCustomerTypePrice.Image"), System.Drawing.Image)
        Me.LblCustomerTypePrice.Location = New System.Drawing.Point(530, 82)
        Me.LblCustomerTypePrice.Name = "LblCustomerTypePrice"
        Me.LblCustomerTypePrice.Size = New System.Drawing.Size(21, 21)
        Me.LblCustomerTypePrice.TabIndex = 26
        Me.LblCustomerTypePrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblCustomerTypePrice.Visible = False
        '
        'LblAddItem
        '
        Me.LblAddItem.BackColor = System.Drawing.Color.Transparent
        Me.LblAddItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddItem.Image = CType(resources.GetObject("LblAddItem.Image"), System.Drawing.Image)
        Me.LblAddItem.Location = New System.Drawing.Point(438, 32)
        Me.LblAddItem.Name = "LblAddItem"
        Me.LblAddItem.Size = New System.Drawing.Size(21, 21)
        Me.LblAddItem.TabIndex = 4
        Me.LblAddItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlQuantity
        '
        Me.PnlQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlQuantity.Controls.Add(Me.TxtDiscountPercent)
        Me.PnlQuantity.Controls.Add(Me.Label40)
        Me.PnlQuantity.Controls.Add(Me.TxtFreeQuantity)
        Me.PnlQuantity.Controls.Add(Me.Label33)
        Me.PnlQuantity.Controls.Add(Me.Label11)
        Me.PnlQuantity.Controls.Add(Me.Label10)
        Me.PnlQuantity.Controls.Add(Me.TxtPurchaseQuantity)
        Me.PnlQuantity.Controls.Add(Me.Label28)
        Me.PnlQuantity.Controls.Add(Me.TxtPackQty)
        Me.PnlQuantity.Controls.Add(Me.TxtPurchasePrice)
        Me.PnlQuantity.Controls.Add(Me.Label23)
        Me.PnlQuantity.Location = New System.Drawing.Point(7, 59)
        Me.PnlQuantity.Name = "PnlQuantity"
        Me.PnlQuantity.Size = New System.Drawing.Size(248, 49)
        Me.PnlQuantity.TabIndex = 13
        '
        'TxtDiscountPercent
        '
        Me.TxtDiscountPercent.Location = New System.Drawing.Point(135, 22)
        Me.TxtDiscountPercent.Name = "TxtDiscountPercent"
        Me.TxtDiscountPercent.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDiscountPercent.Size = New System.Drawing.Size(47, 20)
        Me.TxtDiscountPercent.TabIndex = 10
        Me.TxtDiscountPercent.Visible = False
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(139, 26)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(36, 13)
        Me.Label40.TabIndex = 9
        Me.Label40.Text = "Disc%"
        Me.Label40.Visible = False
        '
        'TxtFreeQuantity
        '
        Me.TxtFreeQuantity.Location = New System.Drawing.Point(116, 23)
        Me.TxtFreeQuantity.Name = "TxtFreeQuantity"
        Me.TxtFreeQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtFreeQuantity.Size = New System.Drawing.Size(59, 20)
        Me.TxtFreeQuantity.TabIndex = 8
        Me.TxtFreeQuantity.Visible = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(125, 23)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(50, 13)
        Me.Label33.TabIndex = 7
        Me.Label33.Text = "Free Qty."
        Me.Label33.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "1 x "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(87, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Pur. Qty."
        '
        'TxtPurchaseQuantity
        '
        Me.TxtPurchaseQuantity.Location = New System.Drawing.Point(85, 22)
        Me.TxtPurchaseQuantity.Name = "TxtPurchaseQuantity"
        Me.TxtPurchaseQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPurchaseQuantity.Size = New System.Drawing.Size(61, 20)
        Me.TxtPurchaseQuantity.TabIndex = 4
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(6, 5)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(55, 13)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "Pack Size"
        '
        'TxtPackQty
        '
        Me.TxtPackQty.Location = New System.Drawing.Point(32, 22)
        Me.TxtPackQty.Name = "TxtPackQty"
        Me.TxtPackQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPackQty.Size = New System.Drawing.Size(47, 20)
        Me.TxtPackQty.TabIndex = 1
        '
        'TxtPurchasePrice
        '
        Me.TxtPurchasePrice.Location = New System.Drawing.Point(152, 22)
        Me.TxtPurchasePrice.Name = "TxtPurchasePrice"
        Me.TxtPurchasePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPurchasePrice.Size = New System.Drawing.Size(87, 20)
        Me.TxtPurchasePrice.TabIndex = 6
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(149, 6)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(77, 13)
        Me.Label23.TabIndex = 5
        Me.Label23.Text = "Pur. Price/Qty."
        '
        'CmbStorage
        '
        Me.CmbStorage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbStorage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbStorage.FormattingEnabled = True
        Me.CmbStorage.Location = New System.Drawing.Point(468, 33)
        Me.CmbStorage.Name = "CmbStorage"
        Me.CmbStorage.Size = New System.Drawing.Size(130, 21)
        Me.CmbStorage.Sorted = True
        Me.CmbStorage.TabIndex = 8
        '
        'BtnRemove
        '
        Me.BtnRemove.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnRemove.Location = New System.Drawing.Point(926, 80)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(73, 26)
        Me.BtnRemove.TabIndex = 29
        Me.BtnRemove.Text = "&Remove"
        Me.BtnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnAdd.Location = New System.Drawing.Point(732, 78)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(73, 26)
        Me.BtnAdd.TabIndex = 28
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(601, 15)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(35, 13)
        Me.Label27.TabIndex = 9
        Me.Label27.Text = "Expiry"
        Me.Label27.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(465, 16)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(44, 13)
        Me.Label26.TabIndex = 7
        Me.Label26.Text = "Storage"
        '
        'PnlGross
        '
        Me.PnlGross.Controls.Add(Me.Label39)
        Me.PnlGross.Controls.Add(Me.TxtDiscount)
        Me.PnlGross.Controls.Add(Me.TxtTaxableAmount)
        Me.PnlGross.Controls.Add(Me.Label38)
        Me.PnlGross.Controls.Add(Me.TxtDiscountOnBill)
        Me.PnlGross.Controls.Add(Me.Label29)
        Me.PnlGross.Controls.Add(Me.Label42)
        Me.PnlGross.Controls.Add(Me.TxtGrossAmount)
        Me.PnlGross.Location = New System.Drawing.Point(237, 541)
        Me.PnlGross.Name = "PnlGross"
        Me.PnlGross.Size = New System.Drawing.Size(227, 126)
        Me.PnlGross.TabIndex = 3
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(5, 32)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(70, 13)
        Me.Label39.TabIndex = 2
        Me.Label39.Text = "Disc. Amount"
        '
        'TxtDiscount
        '
        Me.TxtDiscount.BackColor = System.Drawing.Color.White
        Me.TxtDiscount.Enabled = False
        Me.TxtDiscount.Location = New System.Drawing.Point(87, 29)
        Me.TxtDiscount.Name = "TxtDiscount"
        Me.TxtDiscount.ReadOnly = True
        Me.TxtDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDiscount.Size = New System.Drawing.Size(111, 20)
        Me.TxtDiscount.TabIndex = 3
        Me.TxtDiscount.TabStop = False
        '
        'TxtTaxableAmount
        '
        Me.TxtTaxableAmount.BackColor = System.Drawing.Color.White
        Me.TxtTaxableAmount.Enabled = False
        Me.TxtTaxableAmount.Location = New System.Drawing.Point(87, 55)
        Me.TxtTaxableAmount.Name = "TxtTaxableAmount"
        Me.TxtTaxableAmount.ReadOnly = True
        Me.TxtTaxableAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTaxableAmount.Size = New System.Drawing.Size(111, 20)
        Me.TxtTaxableAmount.TabIndex = 5
        Me.TxtTaxableAmount.TabStop = False
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(5, 58)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(84, 13)
        Me.Label38.TabIndex = 4
        Me.Label38.Text = "Taxable Amount"
        '
        'TxtDiscountOnBill
        '
        Me.TxtDiscountOnBill.BackColor = System.Drawing.Color.White
        Me.TxtDiscountOnBill.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDiscountOnBill.Location = New System.Drawing.Point(87, 82)
        Me.TxtDiscountOnBill.Name = "TxtDiscountOnBill"
        Me.TxtDiscountOnBill.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDiscountOnBill.Size = New System.Drawing.Size(111, 20)
        Me.TxtDiscountOnBill.TabIndex = 7
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(5, 85)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(68, 13)
        Me.Label29.TabIndex = 6
        Me.Label29.Text = "Cash Disc."
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(5, 6)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(73, 13)
        Me.Label42.TabIndex = 0
        Me.Label42.Text = "Gross Amount"
        '
        'TxtGrossAmount
        '
        Me.TxtGrossAmount.BackColor = System.Drawing.Color.White
        Me.TxtGrossAmount.Enabled = False
        Me.TxtGrossAmount.Location = New System.Drawing.Point(87, 3)
        Me.TxtGrossAmount.Name = "TxtGrossAmount"
        Me.TxtGrossAmount.ReadOnly = True
        Me.TxtGrossAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtGrossAmount.Size = New System.Drawing.Size(111, 20)
        Me.TxtGrossAmount.TabIndex = 1
        Me.TxtGrossAmount.TabStop = False
        '
        'PnlTax
        '
        Me.PnlTax.Controls.Add(Me.LblTaxPercent)
        Me.PnlTax.Controls.Add(Me.TxtTaxAmt)
        Me.PnlTax.Controls.Add(Me.Label36)
        Me.PnlTax.Controls.Add(Me.CmbTax)
        Me.PnlTax.Controls.Add(Me.Label35)
        Me.PnlTax.Controls.Add(Me.Label34)
        Me.PnlTax.Controls.Add(Me.TxtDebitAdj)
        Me.PnlTax.Controls.Add(Me.Label30)
        Me.PnlTax.Controls.Add(Me.TxtCreditAdj)
        Me.PnlTax.Location = New System.Drawing.Point(10, 541)
        Me.PnlTax.Name = "PnlTax"
        Me.PnlTax.Size = New System.Drawing.Size(221, 126)
        Me.PnlTax.TabIndex = 2
        '
        'LblTaxPercent
        '
        Me.LblTaxPercent.AutoSize = True
        Me.LblTaxPercent.Location = New System.Drawing.Point(171, 60)
        Me.LblTaxPercent.Name = "LblTaxPercent"
        Me.LblTaxPercent.Size = New System.Drawing.Size(0, 13)
        Me.LblTaxPercent.TabIndex = 8
        '
        'TxtTaxAmt
        '
        Me.TxtTaxAmt.BackColor = System.Drawing.Color.White
        Me.TxtTaxAmt.Enabled = False
        Me.TxtTaxAmt.Location = New System.Drawing.Point(70, 85)
        Me.TxtTaxAmt.Name = "TxtTaxAmt"
        Me.TxtTaxAmt.ReadOnly = True
        Me.TxtTaxAmt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTaxAmt.Size = New System.Drawing.Size(113, 20)
        Me.TxtTaxAmt.TabIndex = 7
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(5, 88)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(46, 13)
        Me.Label36.TabIndex = 6
        Me.Label36.Text = "Tax Amt"
        '
        'CmbTax
        '
        Me.CmbTax.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbTax.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTax.FormattingEnabled = True
        Me.CmbTax.Location = New System.Drawing.Point(70, 55)
        Me.CmbTax.Name = "CmbTax"
        Me.CmbTax.Size = New System.Drawing.Size(95, 21)
        Me.CmbTax.Sorted = True
        Me.CmbTax.TabIndex = 5
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(5, 62)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(59, 13)
        Me.Label35.TabIndex = 4
        Me.Label35.Text = "VAT/Tax%"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(3, 32)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(53, 13)
        Me.Label34.TabIndex = 2
        Me.Label34.Text = "Debit Adj."
        '
        'TxtDebitAdj
        '
        Me.TxtDebitAdj.Location = New System.Drawing.Point(70, 29)
        Me.TxtDebitAdj.Name = "TxtDebitAdj"
        Me.TxtDebitAdj.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDebitAdj.Size = New System.Drawing.Size(113, 20)
        Me.TxtDebitAdj.TabIndex = 3
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(3, 6)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(55, 13)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "Credit Adj."
        '
        'TxtCreditAdj
        '
        Me.TxtCreditAdj.Location = New System.Drawing.Point(70, 3)
        Me.TxtCreditAdj.Name = "TxtCreditAdj"
        Me.TxtCreditAdj.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtCreditAdj.Size = New System.Drawing.Size(113, 20)
        Me.TxtCreditAdj.TabIndex = 1
        '
        'PnlFinal
        '
        Me.PnlFinal.Controls.Add(Me.TxtFreightCharge)
        Me.PnlFinal.Controls.Add(Me.LblFreightCharge)
        Me.PnlFinal.Controls.Add(Me.TxtRemark)
        Me.PnlFinal.Controls.Add(Me.Label16)
        Me.PnlFinal.Controls.Add(Me.TxtPreExciseAmount)
        Me.PnlFinal.Controls.Add(Me.GrpTotals)
        Me.PnlFinal.Controls.Add(Me.Label43)
        Me.PnlFinal.Controls.Add(Me.TxtOverAllDiscount)
        Me.PnlFinal.Controls.Add(Me.Label37)
        Me.PnlFinal.Controls.Add(Me.TxtBillRoundOff)
        Me.PnlFinal.Controls.Add(Me.Label31)
        Me.PnlFinal.Controls.Add(Me.TxtBillNetAmount)
        Me.PnlFinal.Controls.Add(Me.Label32)
        Me.PnlFinal.Location = New System.Drawing.Point(471, 541)
        Me.PnlFinal.Name = "PnlFinal"
        Me.PnlFinal.Size = New System.Drawing.Size(543, 126)
        Me.PnlFinal.TabIndex = 4
        '
        'TxtFreightCharge
        '
        Me.TxtFreightCharge.BackColor = System.Drawing.Color.White
        Me.TxtFreightCharge.Location = New System.Drawing.Point(82, 59)
        Me.TxtFreightCharge.Name = "TxtFreightCharge"
        Me.TxtFreightCharge.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtFreightCharge.Size = New System.Drawing.Size(93, 20)
        Me.TxtFreightCharge.TabIndex = 5
        Me.TxtFreightCharge.TabStop = False
        '
        'LblFreightCharge
        '
        Me.LblFreightCharge.AutoSize = True
        Me.LblFreightCharge.Location = New System.Drawing.Point(7, 63)
        Me.LblFreightCharge.Name = "LblFreightCharge"
        Me.LblFreightCharge.Size = New System.Drawing.Size(76, 13)
        Me.LblFreightCharge.TabIndex = 4
        Me.LblFreightCharge.Text = "Freight Charge"
        '
        'TxtRemark
        '
        Me.TxtRemark.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRemark.Location = New System.Drawing.Point(246, 33)
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(281, 20)
        Me.TxtRemark.TabIndex = 9
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(190, 39)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 13)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Remarks"
        '
        'TxtPreExciseAmount
        '
        Me.TxtPreExciseAmount.BackColor = System.Drawing.Color.White
        Me.TxtPreExciseAmount.Enabled = False
        Me.TxtPreExciseAmount.Location = New System.Drawing.Point(82, 33)
        Me.TxtPreExciseAmount.Name = "TxtPreExciseAmount"
        Me.TxtPreExciseAmount.ReadOnly = True
        Me.TxtPreExciseAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPreExciseAmount.Size = New System.Drawing.Size(93, 20)
        Me.TxtPreExciseAmount.TabIndex = 3
        Me.TxtPreExciseAmount.TabStop = False
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(7, 36)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(62, 13)
        Me.Label43.TabIndex = 2
        Me.Label43.Text = "Pre Ex. Amt"
        '
        'TxtOverAllDiscount
        '
        Me.TxtOverAllDiscount.BackColor = System.Drawing.Color.White
        Me.TxtOverAllDiscount.Enabled = False
        Me.TxtOverAllDiscount.Location = New System.Drawing.Point(82, 7)
        Me.TxtOverAllDiscount.Name = "TxtOverAllDiscount"
        Me.TxtOverAllDiscount.ReadOnly = True
        Me.TxtOverAllDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtOverAllDiscount.Size = New System.Drawing.Size(93, 20)
        Me.TxtOverAllDiscount.TabIndex = 1
        Me.TxtOverAllDiscount.TabStop = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(7, 11)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(62, 13)
        Me.Label37.TabIndex = 0
        Me.Label37.Text = "T. Discount"
        '
        'TxtBillRoundOff
        '
        Me.TxtBillRoundOff.BackColor = System.Drawing.Color.White
        Me.TxtBillRoundOff.Enabled = False
        Me.TxtBillRoundOff.Location = New System.Drawing.Point(243, 6)
        Me.TxtBillRoundOff.Name = "TxtBillRoundOff"
        Me.TxtBillRoundOff.ReadOnly = True
        Me.TxtBillRoundOff.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtBillRoundOff.Size = New System.Drawing.Size(49, 20)
        Me.TxtBillRoundOff.TabIndex = 7
        Me.TxtBillRoundOff.TabStop = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(181, 10)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(56, 13)
        Me.Label31.TabIndex = 6
        Me.Label31.Text = "Round-Off"
        '
        'TxtBillNetAmount
        '
        Me.TxtBillNetAmount.BackColor = System.Drawing.Color.White
        Me.TxtBillNetAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBillNetAmount.Location = New System.Drawing.Point(375, 7)
        Me.TxtBillNetAmount.Name = "TxtBillNetAmount"
        Me.TxtBillNetAmount.ReadOnly = True
        Me.TxtBillNetAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtBillNetAmount.Size = New System.Drawing.Size(152, 20)
        Me.TxtBillNetAmount.TabIndex = 11
        Me.TxtBillNetAmount.TabStop = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(298, 9)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(73, 13)
        Me.Label32.TabIndex = 10
        Me.Label32.Text = "Net Amount"
        '
        'FrmPurchase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(1026, 683)
        Me.ControlBox = False
        Me.Controls.Add(Me.PnlGross)
        Me.Controls.Add(Me.PnlTax)
        Me.Controls.Add(Me.GrpPurchase)
        Me.Controls.Add(Me.GrpItem)
        Me.Controls.Add(Me.PnlFinal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPurchase"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase"
        Me.GrpPurchase.ResumeLayout(False)
        Me.GrpPurchase.PerformLayout()
        CType(Me.GrdItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpTotals.ResumeLayout(False)
        Me.GrpItem.ResumeLayout(False)
        Me.GrpItem.PerformLayout()
        Me.PnlQuantity.ResumeLayout(False)
        Me.PnlQuantity.PerformLayout()
        Me.PnlGross.ResumeLayout(False)
        Me.PnlGross.PerformLayout()
        Me.PnlTax.ResumeLayout(False)
        Me.PnlTax.PerformLayout()
        Me.PnlFinal.ResumeLayout(False)
        Me.PnlFinal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpPurchase As System.Windows.Forms.GroupBox
    Friend WithEvents DtPkrPurchaseDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmbSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents CmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtPurchaseCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents GrdItems As System.Windows.Forms.DataGridView
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents GrpTotals As System.Windows.Forms.GroupBox
    Friend WithEvents CmbItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GrpItem As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPurchaseQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtVoucher As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CmbAgainstOrder As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TxtPurchasePrice As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TxtPackQty As System.Windows.Forms.TextBox
    Friend WithEvents BtnRemove As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents CmbStorage As System.Windows.Forms.ComboBox
    Friend WithEvents TxtTINNo As System.Windows.Forms.TextBox
    Friend WithEvents PnlQuantity As System.Windows.Forms.Panel
    Friend WithEvents LblAddVendor As System.Windows.Forms.Label
    Friend WithEvents LblAddItem As System.Windows.Forms.Label
    Friend WithEvents LblCustomerTypePrice As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtExpiryDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtPTR As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtMRP As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtManufactureDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtPTS As System.Windows.Forms.TextBox
    Friend WithEvents TxtRate1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtRate3 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TxtRate2 As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents PnlGross As System.Windows.Forms.Panel
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents TxtDiscount As System.Windows.Forms.TextBox
    Friend WithEvents TxtTaxableAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents TxtDiscountOnBill As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents TxtGrossAmount As System.Windows.Forms.TextBox
    Friend WithEvents PnlTax As System.Windows.Forms.Panel
    Friend WithEvents LblTaxPercent As System.Windows.Forms.Label
    Friend WithEvents TxtTaxAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents CmbTax As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TxtDebitAdj As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TxtCreditAdj As System.Windows.Forms.TextBox
    Friend WithEvents PnlFinal As System.Windows.Forms.Panel
    Friend WithEvents TxtPreExciseAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents TxtOverAllDiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents TxtBillRoundOff As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents TxtBillNetAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents TxtDiscountPercent As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents TxtFreeQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents TxtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtFreightCharge As System.Windows.Forms.TextBox
    Friend WithEvents LblFreightCharge As System.Windows.Forms.Label
End Class
