<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSales
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSales))
        Me.LblAddCustomer = New System.Windows.Forms.Label()
        Me.CmbMode = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.DtPkrSaleDate = New System.Windows.Forms.DateTimePicker()
        Me.CmbCustomer = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtSaleCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbCategory = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtSalePrice = New System.Windows.Forms.TextBox()
        Me.TxtTotal = New System.Windows.Forms.TextBox()
        Me.BtnRemove = New System.Windows.Forms.Button()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CmbItem = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtQuantity = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GrpSaleOnBill = New System.Windows.Forms.GroupBox()
        Me.GrdSale = New System.Windows.Forms.DataGridView()
        Me.TxtDiscountOnBill = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TxtBillRoundOff = New System.Windows.Forms.TextBox()
        Me.TxtGrossAmount = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TxtBillNetAmount = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GrpButtons = New System.Windows.Forms.GroupBox()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnAddFreeItems = New System.Windows.Forms.Button()
        Me.TxtReference = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PnlCustomer = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtAddress = New System.Windows.Forms.TextBox()
        Me.LblAddress = New System.Windows.Forms.Label()
        Me.TxtTinNo = New System.Windows.Forms.TextBox()
        Me.PnlSale = New System.Windows.Forms.Panel()
        Me.LblAddDivision = New System.Windows.Forms.Label()
        Me.TxtOrderNo = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DtPkrOrderDate = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtPickSlipNo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CmbDivision = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PnlTransporter = New System.Windows.Forms.Panel()
        Me.LblAddHQ = New System.Windows.Forms.Label()
        Me.LblAddTransporter = New System.Windows.Forms.Label()
        Me.CmbHQ = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.DtPkrDueDate = New System.Windows.Forms.DateTimePicker()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TxtCases = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TxtChequeNo = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.DtPkrLRDate = New System.Windows.Forms.DateTimePicker()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TxtLRNo = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TxtDestination = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.CmbTransporter = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PnlItem = New System.Windows.Forms.Panel()
        Me.CmbSaleOn = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtFreeQuantity = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TxtDiscountPercent = New System.Windows.Forms.TextBox()
        Me.PnlTax = New System.Windows.Forms.Panel()
        Me.LblTaxPercent = New System.Windows.Forms.Label()
        Me.TxtTaxAmt = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.CmbTax = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TxtDebitAdj = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtCreditAdj = New System.Windows.Forms.TextBox()
        Me.PnlGross = New System.Windows.Forms.Panel()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.TxtDiscount = New System.Windows.Forms.TextBox()
        Me.TxtTaxableAmount = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.TxtPreExciseAmount = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.PnlFinal = New System.Windows.Forms.Panel()
        Me.Txt_GroceAmt = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txt_tot_tax = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtFrieght = New System.Windows.Forms.TextBox()
        Me.LblFrieght = New System.Windows.Forms.Label()
        Me.ChkCancel = New System.Windows.Forms.CheckBox()
        Me.TxtOverAllDiscount = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.GrpSaleOnBill.SuspendLayout()
        CType(Me.GrdSale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpButtons.SuspendLayout()
        Me.PnlCustomer.SuspendLayout()
        Me.PnlSale.SuspendLayout()
        Me.PnlTransporter.SuspendLayout()
        Me.PnlItem.SuspendLayout()
        Me.PnlTax.SuspendLayout()
        Me.PnlGross.SuspendLayout()
        Me.PnlFinal.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblAddCustomer
        '
        Me.LblAddCustomer.BackColor = System.Drawing.Color.Transparent
        Me.LblAddCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddCustomer.Image = CType(resources.GetObject("LblAddCustomer.Image"), System.Drawing.Image)
        Me.LblAddCustomer.Location = New System.Drawing.Point(326, 8)
        Me.LblAddCustomer.Name = "LblAddCustomer"
        Me.LblAddCustomer.Size = New System.Drawing.Size(21, 21)
        Me.LblAddCustomer.TabIndex = 4
        Me.LblAddCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmbMode
        '
        Me.CmbMode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMode.FormattingEnabled = True
        Me.CmbMode.Location = New System.Drawing.Point(99, 104)
        Me.CmbMode.Name = "CmbMode"
        Me.CmbMode.Size = New System.Drawing.Size(91, 21)
        Me.CmbMode.Sorted = True
        Me.CmbMode.TabIndex = 10
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(5, 108)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(61, 13)
        Me.Label22.TabIndex = 9
        Me.Label22.Text = "Sale Status"
        '
        'DtPkrSaleDate
        '
        Me.DtPkrSaleDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrSaleDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPkrSaleDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrSaleDate.Location = New System.Drawing.Point(446, 7)
        Me.DtPkrSaleDate.Name = "DtPkrSaleDate"
        Me.DtPkrSaleDate.Size = New System.Drawing.Size(97, 20)
        Me.DtPkrSaleDate.TabIndex = 5
        '
        'CmbCustomer
        '
        Me.CmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbCustomer.FormattingEnabled = True
        Me.CmbCustomer.Location = New System.Drawing.Point(99, 9)
        Me.CmbCustomer.Name = "CmbCustomer"
        Me.CmbCustomer.Size = New System.Drawing.Size(221, 21)
        Me.CmbCustomer.Sorted = True
        Me.CmbCustomer.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Customer Name*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Date"
        '
        'TxtSaleCode
        '
        Me.TxtSaleCode.BackColor = System.Drawing.Color.White
        Me.TxtSaleCode.Enabled = False
        Me.TxtSaleCode.Location = New System.Drawing.Point(71, 30)
        Me.TxtSaleCode.Name = "TxtSaleCode"
        Me.TxtSaleCode.ReadOnly = True
        Me.TxtSaleCode.Size = New System.Drawing.Size(202, 20)
        Me.TxtSaleCode.TabIndex = 3
        Me.TxtSaleCode.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Invoice No."
        '
        'CmbCategory
        '
        Me.CmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCategory.FormattingEnabled = True
        Me.CmbCategory.Location = New System.Drawing.Point(8, 20)
        Me.CmbCategory.Name = "CmbCategory"
        Me.CmbCategory.Size = New System.Drawing.Size(77, 21)
        Me.CmbCategory.Sorted = True
        Me.CmbCategory.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Category"
        '
        'TxtSalePrice
        '
        Me.TxtSalePrice.BackColor = System.Drawing.Color.White
        Me.TxtSalePrice.Location = New System.Drawing.Point(518, 21)
        Me.TxtSalePrice.Name = "TxtSalePrice"
        Me.TxtSalePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtSalePrice.Size = New System.Drawing.Size(58, 20)
        Me.TxtSalePrice.TabIndex = 11
        '
        'TxtTotal
        '
        Me.TxtTotal.BackColor = System.Drawing.Color.White
        Me.TxtTotal.Enabled = False
        Me.TxtTotal.Location = New System.Drawing.Point(624, 21)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.ReadOnly = True
        Me.TxtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTotal.Size = New System.Drawing.Size(72, 20)
        Me.TxtTotal.TabIndex = 15
        Me.TxtTotal.TabStop = False
        '
        'BtnRemove
        '
        Me.BtnRemove.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnRemove.Location = New System.Drawing.Point(929, 16)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(65, 26)
        Me.BtnRemove.TabIndex = 19
        Me.BtnRemove.Text = "&Remove"
        Me.BtnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnAdd.Location = New System.Drawing.Point(858, 16)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(65, 26)
        Me.BtnAdd.TabIndex = 18
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(621, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Total"
        '
        'CmbItem
        '
        Me.CmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbItem.FormattingEnabled = True
        Me.CmbItem.Location = New System.Drawing.Point(91, 20)
        Me.CmbItem.Name = "CmbItem"
        Me.CmbItem.Size = New System.Drawing.Size(267, 21)
        Me.CmbItem.Sorted = True
        Me.CmbItem.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(88, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Item Name*"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(515, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Sale Price"
        '
        'TxtQuantity
        '
        Me.TxtQuantity.Location = New System.Drawing.Point(366, 22)
        Me.TxtQuantity.Name = "TxtQuantity"
        Me.TxtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtQuantity.Size = New System.Drawing.Size(71, 20)
        Me.TxtQuantity.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(363, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Quantity"
        '
        'GrpSaleOnBill
        '
        Me.GrpSaleOnBill.Controls.Add(Me.GrdSale)
        Me.GrpSaleOnBill.Location = New System.Drawing.Point(13, 205)
        Me.GrpSaleOnBill.Name = "GrpSaleOnBill"
        Me.GrpSaleOnBill.Size = New System.Drawing.Size(1003, 313)
        Me.GrpSaleOnBill.TabIndex = 4
        Me.GrpSaleOnBill.TabStop = False
        Me.GrpSaleOnBill.Text = "Items On Bill"
        '
        'GrdSale
        '
        Me.GrdSale.AllowUserToAddRows = False
        Me.GrdSale.AllowUserToDeleteRows = False
        Me.GrdSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdSale.Location = New System.Drawing.Point(10, 19)
        Me.GrdSale.Name = "GrdSale"
        Me.GrdSale.ReadOnly = True
        Me.GrdSale.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdSale.Size = New System.Drawing.Size(980, 288)
        Me.GrdSale.TabIndex = 0
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
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(5, 85)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(68, 13)
        Me.Label23.TabIndex = 6
        Me.Label23.Text = "Cash Disc."
        '
        'TxtBillRoundOff
        '
        Me.TxtBillRoundOff.BackColor = System.Drawing.Color.White
        Me.TxtBillRoundOff.Enabled = False
        Me.TxtBillRoundOff.Location = New System.Drawing.Point(97, 33)
        Me.TxtBillRoundOff.Name = "TxtBillRoundOff"
        Me.TxtBillRoundOff.ReadOnly = True
        Me.TxtBillRoundOff.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtBillRoundOff.Size = New System.Drawing.Size(49, 20)
        Me.TxtBillRoundOff.TabIndex = 5
        Me.TxtBillRoundOff.TabStop = False
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
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(35, 37)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 13)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "Round-Off"
        '
        'TxtBillNetAmount
        '
        Me.TxtBillNetAmount.BackColor = System.Drawing.Color.White
        Me.TxtBillNetAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBillNetAmount.Location = New System.Drawing.Point(96, 3)
        Me.TxtBillNetAmount.Name = "TxtBillNetAmount"
        Me.TxtBillNetAmount.ReadOnly = True
        Me.TxtBillNetAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtBillNetAmount.Size = New System.Drawing.Size(140, 20)
        Me.TxtBillNetAmount.TabIndex = 9
        Me.TxtBillNetAmount.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(9, 7)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(82, 13)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "Total Amount"
        '
        'GrpButtons
        '
        Me.GrpButtons.Controls.Add(Me.BtnSearch)
        Me.GrpButtons.Controls.Add(Me.BtnPrint)
        Me.GrpButtons.Controls.Add(Me.BtnNew)
        Me.GrpButtons.Controls.Add(Me.BtnClose)
        Me.GrpButtons.Controls.Add(Me.BtnSave)
        Me.GrpButtons.Controls.Add(Me.BtnAddFreeItems)
        Me.GrpButtons.Location = New System.Drawing.Point(115, 95)
        Me.GrpButtons.Name = "GrpButtons"
        Me.GrpButtons.Size = New System.Drawing.Size(403, 50)
        Me.GrpButtons.TabIndex = 8
        Me.GrpButtons.TabStop = False
        '
        'BtnSearch
        '
        Me.BtnSearch.Location = New System.Drawing.Point(246, 20)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(72, 26)
        Me.BtnSearch.TabIndex = 3
        Me.BtnSearch.Text = "Searc&h"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.Location = New System.Drawing.Point(167, 19)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(72, 26)
        Me.BtnPrint.TabIndex = 2
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'BtnNew
        '
        Me.BtnNew.Location = New System.Drawing.Point(11, 20)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(72, 26)
        Me.BtnNew.TabIndex = 0
        Me.BtnNew.Text = "&New"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(325, 20)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 4
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(89, 20)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(72, 26)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnAddFreeItems
        '
        Me.BtnAddFreeItems.Location = New System.Drawing.Point(6, 19)
        Me.BtnAddFreeItems.Name = "BtnAddFreeItems"
        Me.BtnAddFreeItems.Size = New System.Drawing.Size(87, 26)
        Me.BtnAddFreeItems.TabIndex = 65
        Me.BtnAddFreeItems.Text = "H Free &Items"
        Me.BtnAddFreeItems.UseVisualStyleBackColor = True
        Me.BtnAddFreeItems.Visible = False
        '
        'TxtReference
        '
        Me.TxtReference.Location = New System.Drawing.Point(71, 135)
        Me.TxtReference.Name = "TxtReference"
        Me.TxtReference.Size = New System.Drawing.Size(232, 20)
        Me.TxtReference.TabIndex = 13
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 138)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 13)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Reference"
        '
        'PnlCustomer
        '
        Me.PnlCustomer.Controls.Add(Me.Label3)
        Me.PnlCustomer.Controls.Add(Me.TxtAddress)
        Me.PnlCustomer.Controls.Add(Me.LblAddress)
        Me.PnlCustomer.Controls.Add(Me.CmbMode)
        Me.PnlCustomer.Controls.Add(Me.Label22)
        Me.PnlCustomer.Controls.Add(Me.TxtTinNo)
        Me.PnlCustomer.Controls.Add(Me.PnlSale)
        Me.PnlCustomer.Controls.Add(Me.PnlTransporter)
        Me.PnlCustomer.Controls.Add(Me.DtPkrSaleDate)
        Me.PnlCustomer.Controls.Add(Me.Label6)
        Me.PnlCustomer.Controls.Add(Me.Label5)
        Me.PnlCustomer.Controls.Add(Me.LblAddCustomer)
        Me.PnlCustomer.Controls.Add(Me.CmbCustomer)
        Me.PnlCustomer.Location = New System.Drawing.Point(12, 12)
        Me.PnlCustomer.Name = "PnlCustomer"
        Me.PnlCustomer.Size = New System.Drawing.Size(1017, 135)
        Me.PnlCustomer.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(387, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Bill Date"
        '
        'TxtAddress
        '
        Me.TxtAddress.Location = New System.Drawing.Point(99, 32)
        Me.TxtAddress.Multiline = True
        Me.TxtAddress.Name = "TxtAddress"
        Me.TxtAddress.Size = New System.Drawing.Size(444, 65)
        Me.TxtAddress.TabIndex = 12
        '
        'LblAddress
        '
        Me.LblAddress.AutoSize = True
        Me.LblAddress.Location = New System.Drawing.Point(5, 36)
        Me.LblAddress.Name = "LblAddress"
        Me.LblAddress.Size = New System.Drawing.Size(45, 13)
        Me.LblAddress.TabIndex = 11
        Me.LblAddress.Text = "Address"
        '
        'TxtTinNo
        '
        Me.TxtTinNo.BackColor = System.Drawing.Color.White
        Me.TxtTinNo.Enabled = False
        Me.TxtTinNo.Location = New System.Drawing.Point(322, 103)
        Me.TxtTinNo.Name = "TxtTinNo"
        Me.TxtTinNo.ReadOnly = True
        Me.TxtTinNo.Size = New System.Drawing.Size(221, 20)
        Me.TxtTinNo.TabIndex = 6
        Me.TxtTinNo.TabStop = False
        '
        'PnlSale
        '
        Me.PnlSale.Controls.Add(Me.LblAddDivision)
        Me.PnlSale.Controls.Add(Me.TxtOrderNo)
        Me.PnlSale.Controls.Add(Me.Label17)
        Me.PnlSale.Controls.Add(Me.DtPkrOrderDate)
        Me.PnlSale.Controls.Add(Me.Label20)
        Me.PnlSale.Controls.Add(Me.TxtPickSlipNo)
        Me.PnlSale.Controls.Add(Me.Label15)
        Me.PnlSale.Controls.Add(Me.TxtReference)
        Me.PnlSale.Controls.Add(Me.Label16)
        Me.PnlSale.Controls.Add(Me.CmbDivision)
        Me.PnlSale.Controls.Add(Me.Label14)
        Me.PnlSale.Controls.Add(Me.TxtSaleCode)
        Me.PnlSale.Controls.Add(Me.Label1)
        Me.PnlSale.Controls.Add(Me.Label2)
        Me.PnlSale.Location = New System.Drawing.Point(943, 58)
        Me.PnlSale.Name = "PnlSale"
        Me.PnlSale.Size = New System.Drawing.Size(54, 58)
        Me.PnlSale.TabIndex = 1
        Me.PnlSale.Visible = False
        '
        'LblAddDivision
        '
        Me.LblAddDivision.BackColor = System.Drawing.Color.Transparent
        Me.LblAddDivision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddDivision.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddDivision.Image = CType(resources.GetObject("LblAddDivision.Image"), System.Drawing.Image)
        Me.LblAddDivision.Location = New System.Drawing.Point(279, 2)
        Me.LblAddDivision.Name = "LblAddDivision"
        Me.LblAddDivision.Size = New System.Drawing.Size(21, 21)
        Me.LblAddDivision.TabIndex = 14
        Me.LblAddDivision.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtOrderNo
        '
        Me.TxtOrderNo.Location = New System.Drawing.Point(71, 108)
        Me.TxtOrderNo.Name = "TxtOrderNo"
        Me.TxtOrderNo.Size = New System.Drawing.Size(97, 20)
        Me.TxtOrderNo.TabIndex = 9
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 111)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 13)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Order No."
        '
        'DtPkrOrderDate
        '
        Me.DtPkrOrderDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrOrderDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPkrOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrOrderDate.Location = New System.Drawing.Point(210, 109)
        Me.DtPkrOrderDate.Name = "DtPkrOrderDate"
        Me.DtPkrOrderDate.Size = New System.Drawing.Size(93, 20)
        Me.DtPkrOrderDate.TabIndex = 11
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(174, 111)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(30, 13)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "Date"
        '
        'TxtPickSlipNo
        '
        Me.TxtPickSlipNo.Location = New System.Drawing.Point(71, 82)
        Me.TxtPickSlipNo.Name = "TxtPickSlipNo"
        Me.TxtPickSlipNo.Size = New System.Drawing.Size(202, 20)
        Me.TxtPickSlipNo.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 85)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 13)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Pick Slip No."
        '
        'CmbDivision
        '
        Me.CmbDivision.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbDivision.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbDivision.FormattingEnabled = True
        Me.CmbDivision.Location = New System.Drawing.Point(71, 3)
        Me.CmbDivision.Name = "CmbDivision"
        Me.CmbDivision.Size = New System.Drawing.Size(202, 21)
        Me.CmbDivision.Sorted = True
        Me.CmbDivision.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Division"
        '
        'PnlTransporter
        '
        Me.PnlTransporter.Controls.Add(Me.LblAddHQ)
        Me.PnlTransporter.Controls.Add(Me.LblAddTransporter)
        Me.PnlTransporter.Controls.Add(Me.CmbHQ)
        Me.PnlTransporter.Controls.Add(Me.Label31)
        Me.PnlTransporter.Controls.Add(Me.DtPkrDueDate)
        Me.PnlTransporter.Controls.Add(Me.Label30)
        Me.PnlTransporter.Controls.Add(Me.TxtCases)
        Me.PnlTransporter.Controls.Add(Me.Label29)
        Me.PnlTransporter.Controls.Add(Me.TxtChequeNo)
        Me.PnlTransporter.Controls.Add(Me.Label28)
        Me.PnlTransporter.Controls.Add(Me.DtPkrLRDate)
        Me.PnlTransporter.Controls.Add(Me.Label27)
        Me.PnlTransporter.Controls.Add(Me.TxtLRNo)
        Me.PnlTransporter.Controls.Add(Me.Label26)
        Me.PnlTransporter.Controls.Add(Me.TxtDestination)
        Me.PnlTransporter.Controls.Add(Me.Label25)
        Me.PnlTransporter.Controls.Add(Me.CmbTransporter)
        Me.PnlTransporter.Controls.Add(Me.Label24)
        Me.PnlTransporter.Location = New System.Drawing.Point(946, 8)
        Me.PnlTransporter.Name = "PnlTransporter"
        Me.PnlTransporter.Size = New System.Drawing.Size(43, 40)
        Me.PnlTransporter.TabIndex = 2
        Me.PnlTransporter.Visible = False
        '
        'LblAddHQ
        '
        Me.LblAddHQ.BackColor = System.Drawing.Color.Transparent
        Me.LblAddHQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddHQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddHQ.Image = CType(resources.GetObject("LblAddHQ.Image"), System.Drawing.Image)
        Me.LblAddHQ.Location = New System.Drawing.Point(278, 134)
        Me.LblAddHQ.Name = "LblAddHQ"
        Me.LblAddHQ.Size = New System.Drawing.Size(21, 21)
        Me.LblAddHQ.TabIndex = 17
        Me.LblAddHQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblAddTransporter
        '
        Me.LblAddTransporter.BackColor = System.Drawing.Color.Transparent
        Me.LblAddTransporter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddTransporter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddTransporter.Image = CType(resources.GetObject("LblAddTransporter.Image"), System.Drawing.Image)
        Me.LblAddTransporter.Location = New System.Drawing.Point(278, 3)
        Me.LblAddTransporter.Name = "LblAddTransporter"
        Me.LblAddTransporter.Size = New System.Drawing.Size(21, 21)
        Me.LblAddTransporter.TabIndex = 16
        Me.LblAddTransporter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmbHQ
        '
        Me.CmbHQ.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbHQ.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbHQ.FormattingEnabled = True
        Me.CmbHQ.Location = New System.Drawing.Point(70, 135)
        Me.CmbHQ.Name = "CmbHQ"
        Me.CmbHQ.Size = New System.Drawing.Size(202, 21)
        Me.CmbHQ.Sorted = True
        Me.CmbHQ.TabIndex = 15
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(4, 140)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(32, 13)
        Me.Label31.TabIndex = 14
        Me.Label31.Text = "H. Q."
        '
        'DtPkrDueDate
        '
        Me.DtPkrDueDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrDueDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPkrDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrDueDate.Location = New System.Drawing.Point(70, 109)
        Me.DtPkrDueDate.Name = "DtPkrDueDate"
        Me.DtPkrDueDate.Size = New System.Drawing.Size(93, 20)
        Me.DtPkrDueDate.TabIndex = 13
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(4, 112)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(53, 13)
        Me.Label30.TabIndex = 12
        Me.Label30.Text = "Due Date"
        '
        'TxtCases
        '
        Me.TxtCases.Location = New System.Drawing.Point(215, 84)
        Me.TxtCases.Name = "TxtCases"
        Me.TxtCases.Size = New System.Drawing.Size(93, 20)
        Me.TxtCases.TabIndex = 11
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(179, 87)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(36, 13)
        Me.Label29.TabIndex = 10
        Me.Label29.Text = "Cases"
        '
        'TxtChequeNo
        '
        Me.TxtChequeNo.Location = New System.Drawing.Point(70, 83)
        Me.TxtChequeNo.Name = "TxtChequeNo"
        Me.TxtChequeNo.Size = New System.Drawing.Size(103, 20)
        Me.TxtChequeNo.TabIndex = 9
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(4, 87)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(64, 13)
        Me.Label28.TabIndex = 8
        Me.Label28.Text = "Cheque No."
        '
        'DtPkrLRDate
        '
        Me.DtPkrLRDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrLRDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPkrLRDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrLRDate.Location = New System.Drawing.Point(215, 57)
        Me.DtPkrLRDate.Name = "DtPkrLRDate"
        Me.DtPkrLRDate.Size = New System.Drawing.Size(93, 20)
        Me.DtPkrLRDate.TabIndex = 7
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(179, 60)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(30, 13)
        Me.Label27.TabIndex = 6
        Me.Label27.Text = "Date"
        '
        'TxtLRNo
        '
        Me.TxtLRNo.Location = New System.Drawing.Point(70, 57)
        Me.TxtLRNo.Name = "TxtLRNo"
        Me.TxtLRNo.Size = New System.Drawing.Size(103, 20)
        Me.TxtLRNo.TabIndex = 5
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(4, 61)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(44, 13)
        Me.Label26.TabIndex = 4
        Me.Label26.Text = "L.R.No."
        '
        'TxtDestination
        '
        Me.TxtDestination.Location = New System.Drawing.Point(70, 31)
        Me.TxtDestination.Name = "TxtDestination"
        Me.TxtDestination.Size = New System.Drawing.Size(149, 20)
        Me.TxtDestination.TabIndex = 3
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(4, 34)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(60, 13)
        Me.Label25.TabIndex = 2
        Me.Label25.Text = "Destination"
        '
        'CmbTransporter
        '
        Me.CmbTransporter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbTransporter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbTransporter.FormattingEnabled = True
        Me.CmbTransporter.Location = New System.Drawing.Point(70, 4)
        Me.CmbTransporter.Name = "CmbTransporter"
        Me.CmbTransporter.Size = New System.Drawing.Size(202, 21)
        Me.CmbTransporter.Sorted = True
        Me.CmbTransporter.TabIndex = 1
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(3, 7)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(61, 13)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "Transporter"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(255, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "TIN No."
        '
        'PnlItem
        '
        Me.PnlItem.Controls.Add(Me.CmbSaleOn)
        Me.PnlItem.Controls.Add(Me.Label9)
        Me.PnlItem.Controls.Add(Me.Label4)
        Me.PnlItem.Controls.Add(Me.TxtFreeQuantity)
        Me.PnlItem.Controls.Add(Me.Label33)
        Me.PnlItem.Controls.Add(Me.TxtDiscountPercent)
        Me.PnlItem.Controls.Add(Me.CmbItem)
        Me.PnlItem.Controls.Add(Me.Label7)
        Me.PnlItem.Controls.Add(Me.CmbCategory)
        Me.PnlItem.Controls.Add(Me.Label11)
        Me.PnlItem.Controls.Add(Me.TxtSalePrice)
        Me.PnlItem.Controls.Add(Me.BtnRemove)
        Me.PnlItem.Controls.Add(Me.TxtTotal)
        Me.PnlItem.Controls.Add(Me.Label10)
        Me.PnlItem.Controls.Add(Me.TxtQuantity)
        Me.PnlItem.Controls.Add(Me.BtnAdd)
        Me.PnlItem.Controls.Add(Me.Label8)
        Me.PnlItem.Controls.Add(Me.Label13)
        Me.PnlItem.Location = New System.Drawing.Point(13, 148)
        Me.PnlItem.Name = "PnlItem"
        Me.PnlItem.Size = New System.Drawing.Size(1002, 51)
        Me.PnlItem.TabIndex = 3
        '
        'CmbSaleOn
        '
        Me.CmbSaleOn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbSaleOn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbSaleOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSaleOn.FormattingEnabled = True
        Me.CmbSaleOn.Location = New System.Drawing.Point(446, 20)
        Me.CmbSaleOn.Name = "CmbSaleOn"
        Me.CmbSaleOn.Size = New System.Drawing.Size(65, 21)
        Me.CmbSaleOn.Sorted = True
        Me.CmbSaleOn.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(443, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Sale On"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(699, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Free"
        Me.Label4.Visible = False
        '
        'TxtFreeQuantity
        '
        Me.TxtFreeQuantity.Location = New System.Drawing.Point(702, 21)
        Me.TxtFreeQuantity.Name = "TxtFreeQuantity"
        Me.TxtFreeQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtFreeQuantity.Size = New System.Drawing.Size(71, 20)
        Me.TxtFreeQuantity.TabIndex = 17
        Me.TxtFreeQuantity.Visible = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(579, 5)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(36, 13)
        Me.Label33.TabIndex = 12
        Me.Label33.Text = "Disc%"
        Me.Label33.Visible = False
        '
        'TxtDiscountPercent
        '
        Me.TxtDiscountPercent.Location = New System.Drawing.Point(582, 21)
        Me.TxtDiscountPercent.Name = "TxtDiscountPercent"
        Me.TxtDiscountPercent.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDiscountPercent.Size = New System.Drawing.Size(38, 20)
        Me.TxtDiscountPercent.TabIndex = 13
        Me.TxtDiscountPercent.Visible = False
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
        Me.PnlTax.Controls.Add(Me.Label21)
        Me.PnlTax.Controls.Add(Me.TxtCreditAdj)
        Me.PnlTax.Location = New System.Drawing.Point(13, 522)
        Me.PnlTax.Name = "PnlTax"
        Me.PnlTax.Size = New System.Drawing.Size(221, 111)
        Me.PnlTax.TabIndex = 5
        Me.PnlTax.Visible = False
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
        Me.TxtTaxAmt.Location = New System.Drawing.Point(70, 82)
        Me.TxtTaxAmt.Name = "TxtTaxAmt"
        Me.TxtTaxAmt.ReadOnly = True
        Me.TxtTaxAmt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTaxAmt.Size = New System.Drawing.Size(72, 20)
        Me.TxtTaxAmt.TabIndex = 7
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(5, 85)
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
        Me.TxtDebitAdj.ReadOnly = True
        Me.TxtDebitAdj.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDebitAdj.Size = New System.Drawing.Size(113, 20)
        Me.TxtDebitAdj.TabIndex = 3
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(3, 6)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(55, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Credit Adj."
        '
        'TxtCreditAdj
        '
        Me.TxtCreditAdj.Location = New System.Drawing.Point(70, 3)
        Me.TxtCreditAdj.Name = "TxtCreditAdj"
        Me.TxtCreditAdj.ReadOnly = True
        Me.TxtCreditAdj.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtCreditAdj.Size = New System.Drawing.Size(113, 20)
        Me.TxtCreditAdj.TabIndex = 1
        '
        'PnlGross
        '
        Me.PnlGross.Controls.Add(Me.Label39)
        Me.PnlGross.Controls.Add(Me.TxtDiscount)
        Me.PnlGross.Controls.Add(Me.TxtTaxableAmount)
        Me.PnlGross.Controls.Add(Me.Label38)
        Me.PnlGross.Controls.Add(Me.TxtDiscountOnBill)
        Me.PnlGross.Controls.Add(Me.Label23)
        Me.PnlGross.Controls.Add(Me.Label42)
        Me.PnlGross.Controls.Add(Me.TxtGrossAmount)
        Me.PnlGross.Location = New System.Drawing.Point(240, 527)
        Me.PnlGross.Name = "PnlGross"
        Me.PnlGross.Size = New System.Drawing.Size(227, 111)
        Me.PnlGross.TabIndex = 6
        Me.PnlGross.Visible = False
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
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(5, 6)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(73, 13)
        Me.Label42.TabIndex = 0
        Me.Label42.Text = "Gross Amount"
        '
        'TxtPreExciseAmount
        '
        Me.TxtPreExciseAmount.BackColor = System.Drawing.Color.White
        Me.TxtPreExciseAmount.Enabled = False
        Me.TxtPreExciseAmount.Location = New System.Drawing.Point(87, 88)
        Me.TxtPreExciseAmount.Name = "TxtPreExciseAmount"
        Me.TxtPreExciseAmount.ReadOnly = True
        Me.TxtPreExciseAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPreExciseAmount.Size = New System.Drawing.Size(93, 20)
        Me.TxtPreExciseAmount.TabIndex = 3
        Me.TxtPreExciseAmount.TabStop = False
        Me.TxtPreExciseAmount.Visible = False
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(21, 91)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(62, 13)
        Me.Label43.TabIndex = 2
        Me.Label43.Text = "Pre Ex. Amt"
        Me.Label43.Visible = False
        '
        'PnlFinal
        '
        Me.PnlFinal.Controls.Add(Me.Txt_GroceAmt)
        Me.PnlFinal.Controls.Add(Me.Label40)
        Me.PnlFinal.Controls.Add(Me.txt_tot_tax)
        Me.PnlFinal.Controls.Add(Me.Label12)
        Me.PnlFinal.Controls.Add(Me.GrpButtons)
        Me.PnlFinal.Controls.Add(Me.TxtFrieght)
        Me.PnlFinal.Controls.Add(Me.LblFrieght)
        Me.PnlFinal.Controls.Add(Me.ChkCancel)
        Me.PnlFinal.Controls.Add(Me.TxtPreExciseAmount)
        Me.PnlFinal.Controls.Add(Me.Label43)
        Me.PnlFinal.Controls.Add(Me.TxtOverAllDiscount)
        Me.PnlFinal.Controls.Add(Me.Label37)
        Me.PnlFinal.Controls.Add(Me.TxtBillRoundOff)
        Me.PnlFinal.Controls.Add(Me.Label18)
        Me.PnlFinal.Controls.Add(Me.TxtBillNetAmount)
        Me.PnlFinal.Controls.Add(Me.Label19)
        Me.PnlFinal.Location = New System.Drawing.Point(485, 524)
        Me.PnlFinal.Name = "PnlFinal"
        Me.PnlFinal.Size = New System.Drawing.Size(521, 149)
        Me.PnlFinal.TabIndex = 7
        '
        'Txt_GroceAmt
        '
        Me.Txt_GroceAmt.BackColor = System.Drawing.Color.White
        Me.Txt_GroceAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_GroceAmt.Location = New System.Drawing.Point(352, 26)
        Me.Txt_GroceAmt.Name = "Txt_GroceAmt"
        Me.Txt_GroceAmt.ReadOnly = True
        Me.Txt_GroceAmt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Txt_GroceAmt.Size = New System.Drawing.Size(140, 26)
        Me.Txt_GroceAmt.TabIndex = 14
        Me.Txt_GroceAmt.TabStop = False
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(223, 32)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(124, 20)
        Me.Label40.TabIndex = 13
        Me.Label40.Text = "Gross Amount"
        '
        'txt_tot_tax
        '
        Me.txt_tot_tax.BackColor = System.Drawing.Color.White
        Me.txt_tot_tax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tot_tax.Location = New System.Drawing.Point(352, 3)
        Me.txt_tot_tax.Name = "txt_tot_tax"
        Me.txt_tot_tax.ReadOnly = True
        Me.txt_tot_tax.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_tot_tax.Size = New System.Drawing.Size(140, 20)
        Me.txt_tot_tax.TabIndex = 12
        Me.txt_tot_tax.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(265, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Total Tax"
        '
        'TxtFrieght
        '
        Me.TxtFrieght.Location = New System.Drawing.Point(91, 64)
        Me.TxtFrieght.Name = "TxtFrieght"
        Me.TxtFrieght.Size = New System.Drawing.Size(67, 20)
        Me.TxtFrieght.TabIndex = 7
        Me.TxtFrieght.Visible = False
        '
        'LblFrieght
        '
        Me.LblFrieght.AutoSize = True
        Me.LblFrieght.Location = New System.Drawing.Point(11, 68)
        Me.LblFrieght.Name = "LblFrieght"
        Me.LblFrieght.Size = New System.Drawing.Size(76, 13)
        Me.LblFrieght.TabIndex = 6
        Me.LblFrieght.Text = "Freight Charge"
        Me.LblFrieght.Visible = False
        '
        'ChkCancel
        '
        Me.ChkCancel.AutoSize = True
        Me.ChkCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkCancel.ForeColor = System.Drawing.Color.Red
        Me.ChkCancel.Location = New System.Drawing.Point(375, 72)
        Me.ChkCancel.Name = "ChkCancel"
        Me.ChkCancel.Size = New System.Drawing.Size(117, 17)
        Me.ChkCancel.TabIndex = 10
        Me.ChkCancel.TabStop = False
        Me.ChkCancel.Text = "Cancel This bill."
        Me.ChkCancel.UseVisualStyleBackColor = True
        '
        'TxtOverAllDiscount
        '
        Me.TxtOverAllDiscount.BackColor = System.Drawing.Color.White
        Me.TxtOverAllDiscount.Enabled = False
        Me.TxtOverAllDiscount.Location = New System.Drawing.Point(240, 61)
        Me.TxtOverAllDiscount.Name = "TxtOverAllDiscount"
        Me.TxtOverAllDiscount.ReadOnly = True
        Me.TxtOverAllDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtOverAllDiscount.Size = New System.Drawing.Size(93, 20)
        Me.TxtOverAllDiscount.TabIndex = 1
        Me.TxtOverAllDiscount.TabStop = False
        Me.TxtOverAllDiscount.Visible = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(174, 65)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(62, 13)
        Me.Label37.TabIndex = 0
        Me.Label37.Text = "T. Discount"
        Me.Label37.Visible = False
        '
        'FrmSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(1026, 685)
        Me.ControlBox = False
        Me.Controls.Add(Me.PnlFinal)
        Me.Controls.Add(Me.PnlGross)
        Me.Controls.Add(Me.PnlTax)
        Me.Controls.Add(Me.PnlItem)
        Me.Controls.Add(Me.PnlCustomer)
        Me.Controls.Add(Me.GrpSaleOnBill)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSales"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sales"
        Me.GrpSaleOnBill.ResumeLayout(False)
        CType(Me.GrdSale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpButtons.ResumeLayout(False)
        Me.PnlCustomer.ResumeLayout(False)
        Me.PnlCustomer.PerformLayout()
        Me.PnlSale.ResumeLayout(False)
        Me.PnlSale.PerformLayout()
        Me.PnlTransporter.ResumeLayout(False)
        Me.PnlTransporter.PerformLayout()
        Me.PnlItem.ResumeLayout(False)
        Me.PnlItem.PerformLayout()
        Me.PnlTax.ResumeLayout(False)
        Me.PnlTax.PerformLayout()
        Me.PnlGross.ResumeLayout(False)
        Me.PnlGross.PerformLayout()
        Me.PnlFinal.ResumeLayout(False)
        Me.PnlFinal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CmbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtSaleCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtPkrSaleDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmbItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents BtnRemove As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents TxtSalePrice As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents GrpSaleOnBill As System.Windows.Forms.GroupBox
    Friend WithEvents TxtBillRoundOff As System.Windows.Forms.TextBox
    Friend WithEvents TxtGrossAmount As System.Windows.Forms.TextBox
    Friend WithEvents GrdSale As System.Windows.Forms.DataGridView
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtBillNetAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GrpButtons As System.Windows.Forms.GroupBox
    Friend WithEvents TxtReference As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents CmbMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents LblAddCustomer As System.Windows.Forms.Label
    Friend WithEvents BtnAddFreeItems As System.Windows.Forms.Button
    Friend WithEvents TxtDiscountOnBill As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents CmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PnlCustomer As System.Windows.Forms.Panel
    Friend WithEvents PnlSale As System.Windows.Forms.Panel
    Friend WithEvents CmbDivision As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtPickSlipNo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents DtPkrOrderDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents PnlTransporter As System.Windows.Forms.Panel
    Friend WithEvents DtPkrLRDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TxtLRNo As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TxtDestination As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents CmbTransporter As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents CmbHQ As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents DtPkrDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TxtCases As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TxtChequeNo As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TxtTinNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PnlItem As System.Windows.Forms.Panel
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents TxtDiscountPercent As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtFreeQuantity As System.Windows.Forms.TextBox
    Friend WithEvents PnlTax As System.Windows.Forms.Panel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TxtCreditAdj As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TxtDebitAdj As System.Windows.Forms.TextBox
    Friend WithEvents TxtTaxAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents CmbTax As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents PnlGross As System.Windows.Forms.Panel
    Friend WithEvents TxtPreExciseAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents TxtTaxableAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents PnlFinal As System.Windows.Forms.Panel
    Friend WithEvents CmbSaleOn As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblTaxPercent As System.Windows.Forms.Label
    Friend WithEvents TxtOverAllDiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents LblAddDivision As System.Windows.Forms.Label
    Friend WithEvents LblAddHQ As System.Windows.Forms.Label
    Friend WithEvents LblAddTransporter As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents TxtDiscount As System.Windows.Forms.TextBox
    Friend WithEvents ChkCancel As System.Windows.Forms.CheckBox
    Friend WithEvents LblFrieght As System.Windows.Forms.Label
    Friend WithEvents TxtFrieght As System.Windows.Forms.TextBox
    Friend WithEvents LblAddress As System.Windows.Forms.Label
    Friend WithEvents TxtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_GroceAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txt_tot_tax As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label

End Class
