<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSample
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSample))
        Me.DtPkrSampleDate = New System.Windows.Forms.DateTimePicker
        Me.CmbCustomer = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtSampleCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbCategory = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.BtnRemove = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.CmbItem = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtQuantity = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.GrpSampleOnBill = New System.Windows.Forms.GroupBox
        Me.GrdSample = New System.Windows.Forms.DataGridView
        Me.GrpButtons = New System.Windows.Forms.GroupBox
        Me.BtnSearch = New System.Windows.Forms.Button
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.BtnNew = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnAddFreeItems = New System.Windows.Forms.Button
        Me.TxtReference = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.PnlCustomer = New System.Windows.Forms.Panel
        Me.LblAddCustomer = New System.Windows.Forms.Label
        Me.TxtDLNo = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.TxtTinNo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.PnlSample = New System.Windows.Forms.Panel
        Me.LblAddDivision = New System.Windows.Forms.Label
        Me.TxtOrderNo = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.DtPkrOrderDate = New System.Windows.Forms.DateTimePicker
        Me.Label20 = New System.Windows.Forms.Label
        Me.TxtPickSlipNo = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.CmbDivision = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.PnlTransporter = New System.Windows.Forms.Panel
        Me.LblAddTransporter = New System.Windows.Forms.Label
        Me.LblAddHQ = New System.Windows.Forms.Label
        Me.CmbHQ = New System.Windows.Forms.ComboBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.DtPkrDueDate = New System.Windows.Forms.DateTimePicker
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtCases = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.TxtChequeNo = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.DtPkrLRDate = New System.Windows.Forms.DateTimePicker
        Me.Label27 = New System.Windows.Forms.Label
        Me.TxtLRNo = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.TxtDestination = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.CmbTransporter = New System.Windows.Forms.ComboBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.PnlItem = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbCardNo = New System.Windows.Forms.ComboBox
        Me.GrpSampleOnBill.SuspendLayout()
        CType(Me.GrdSample, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpButtons.SuspendLayout()
        Me.PnlCustomer.SuspendLayout()
        Me.PnlSample.SuspendLayout()
        Me.PnlTransporter.SuspendLayout()
        Me.PnlItem.SuspendLayout()
        Me.SuspendLayout()
        '
        'DtPkrSampleDate
        '
        Me.DtPkrSampleDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrSampleDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPkrSampleDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrSampleDate.Location = New System.Drawing.Point(71, 56)
        Me.DtPkrSampleDate.Name = "DtPkrSampleDate"
        Me.DtPkrSampleDate.Size = New System.Drawing.Size(97, 20)
        Me.DtPkrSampleDate.TabIndex = 6
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
        Me.Label5.Location = New System.Drawing.Point(5, 12)
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
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Date"
        '
        'TxtSampleCode
        '
        Me.TxtSampleCode.BackColor = System.Drawing.Color.White
        Me.TxtSampleCode.Enabled = False
        Me.TxtSampleCode.Location = New System.Drawing.Point(71, 30)
        Me.TxtSampleCode.Name = "TxtSampleCode"
        Me.TxtSampleCode.ReadOnly = True
        Me.TxtSampleCode.Size = New System.Drawing.Size(202, 20)
        Me.TxtSampleCode.TabIndex = 4
        Me.TxtSampleCode.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Issue Code"
        '
        'CmbCategory
        '
        Me.CmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCategory.FormattingEnabled = True
        Me.CmbCategory.Location = New System.Drawing.Point(8, 20)
        Me.CmbCategory.Name = "CmbCategory"
        Me.CmbCategory.Size = New System.Drawing.Size(97, 21)
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
        'BtnRemove
        '
        Me.BtnRemove.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnRemove.Location = New System.Drawing.Point(921, 16)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(70, 26)
        Me.BtnRemove.TabIndex = 9
        Me.BtnRemove.Text = "&Remove"
        Me.BtnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnAdd.Location = New System.Drawing.Point(845, 16)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(70, 26)
        Me.BtnAdd.TabIndex = 8
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'CmbItem
        '
        Me.CmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbItem.FormattingEnabled = True
        Me.CmbItem.Location = New System.Drawing.Point(111, 20)
        Me.CmbItem.Name = "CmbItem"
        Me.CmbItem.Size = New System.Drawing.Size(277, 21)
        Me.CmbItem.Sorted = True
        Me.CmbItem.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(108, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Item Name*"
        '
        'TxtQuantity
        '
        Me.TxtQuantity.Location = New System.Drawing.Point(394, 21)
        Me.TxtQuantity.Name = "TxtQuantity"
        Me.TxtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtQuantity.Size = New System.Drawing.Size(62, 20)
        Me.TxtQuantity.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(391, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Quantity"
        '
        'GrpSampleOnBill
        '
        Me.GrpSampleOnBill.Controls.Add(Me.GrdSample)
        Me.GrpSampleOnBill.Location = New System.Drawing.Point(11, 233)
        Me.GrpSampleOnBill.Name = "GrpSampleOnBill"
        Me.GrpSampleOnBill.Size = New System.Drawing.Size(1003, 376)
        Me.GrpSampleOnBill.TabIndex = 4
        Me.GrpSampleOnBill.TabStop = False
        Me.GrpSampleOnBill.Text = "Items"
        '
        'GrdSample
        '
        Me.GrdSample.AllowUserToAddRows = False
        Me.GrdSample.AllowUserToDeleteRows = False
        Me.GrdSample.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdSample.Location = New System.Drawing.Point(10, 19)
        Me.GrdSample.Name = "GrdSample"
        Me.GrdSample.ReadOnly = True
        Me.GrdSample.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdSample.Size = New System.Drawing.Size(980, 351)
        Me.GrdSample.TabIndex = 0
        '
        'GrpButtons
        '
        Me.GrpButtons.Controls.Add(Me.BtnSearch)
        Me.GrpButtons.Controls.Add(Me.BtnPrint)
        Me.GrpButtons.Controls.Add(Me.BtnNew)
        Me.GrpButtons.Controls.Add(Me.BtnClose)
        Me.GrpButtons.Controls.Add(Me.BtnSave)
        Me.GrpButtons.Controls.Add(Me.BtnAddFreeItems)
        Me.GrpButtons.Location = New System.Drawing.Point(606, 615)
        Me.GrpButtons.Name = "GrpButtons"
        Me.GrpButtons.Size = New System.Drawing.Size(408, 54)
        Me.GrpButtons.TabIndex = 4
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
        Me.TxtReference.TabIndex = 14
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 138)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 13)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "Reference"
        '
        'PnlCustomer
        '
        Me.PnlCustomer.Controls.Add(Me.LblAddCustomer)
        Me.PnlCustomer.Controls.Add(Me.TxtDLNo)
        Me.PnlCustomer.Controls.Add(Me.Label32)
        Me.PnlCustomer.Controls.Add(Me.TxtTinNo)
        Me.PnlCustomer.Controls.Add(Me.Label6)
        Me.PnlCustomer.Controls.Add(Me.Label3)
        Me.PnlCustomer.Controls.Add(Me.Label5)
        Me.PnlCustomer.Controls.Add(Me.CmbCustomer)
        Me.PnlCustomer.Controls.Add(Me.CmbCardNo)
        Me.PnlCustomer.Location = New System.Drawing.Point(12, 12)
        Me.PnlCustomer.Name = "PnlCustomer"
        Me.PnlCustomer.Size = New System.Drawing.Size(358, 163)
        Me.PnlCustomer.TabIndex = 0
        '
        'LblAddCustomer
        '
        Me.LblAddCustomer.BackColor = System.Drawing.Color.Transparent
        Me.LblAddCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddCustomer.Image = CType(resources.GetObject("LblAddCustomer.Image"), System.Drawing.Image)
        Me.LblAddCustomer.Location = New System.Drawing.Point(326, 29)
        Me.LblAddCustomer.Name = "LblAddCustomer"
        Me.LblAddCustomer.Size = New System.Drawing.Size(21, 21)
        Me.LblAddCustomer.TabIndex = 4
        Me.LblAddCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtDLNo
        '
        Me.TxtDLNo.BackColor = System.Drawing.Color.White
        Me.TxtDLNo.Enabled = False
        Me.TxtDLNo.Location = New System.Drawing.Point(99, 83)
        Me.TxtDLNo.Name = "TxtDLNo"
        Me.TxtDLNo.ReadOnly = True
        Me.TxtDLNo.Size = New System.Drawing.Size(221, 20)
        Me.TxtDLNo.TabIndex = 8
        Me.TxtDLNo.TabStop = False
        Me.TxtDLNo.Visible = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(5, 86)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(47, 13)
        Me.Label32.TabIndex = 7
        Me.Label32.Text = "D.L. No."
        Me.Label32.Visible = False
        '
        'TxtTinNo
        '
        Me.TxtTinNo.BackColor = System.Drawing.Color.White
        Me.TxtTinNo.Enabled = False
        Me.TxtTinNo.Location = New System.Drawing.Point(99, 57)
        Me.TxtTinNo.Name = "TxtTinNo"
        Me.TxtTinNo.ReadOnly = True
        Me.TxtTinNo.Size = New System.Drawing.Size(221, 20)
        Me.TxtTinNo.TabIndex = 6
        Me.TxtTinNo.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "TIN No."
        '
        'PnlSample
        '
        Me.PnlSample.Controls.Add(Me.LblAddDivision)
        Me.PnlSample.Controls.Add(Me.TxtOrderNo)
        Me.PnlSample.Controls.Add(Me.Label17)
        Me.PnlSample.Controls.Add(Me.DtPkrOrderDate)
        Me.PnlSample.Controls.Add(Me.Label20)
        Me.PnlSample.Controls.Add(Me.TxtPickSlipNo)
        Me.PnlSample.Controls.Add(Me.Label15)
        Me.PnlSample.Controls.Add(Me.TxtReference)
        Me.PnlSample.Controls.Add(Me.Label16)
        Me.PnlSample.Controls.Add(Me.CmbDivision)
        Me.PnlSample.Controls.Add(Me.Label14)
        Me.PnlSample.Controls.Add(Me.TxtSampleCode)
        Me.PnlSample.Controls.Add(Me.Label1)
        Me.PnlSample.Controls.Add(Me.DtPkrSampleDate)
        Me.PnlSample.Controls.Add(Me.Label2)
        Me.PnlSample.Location = New System.Drawing.Point(378, 12)
        Me.PnlSample.Name = "PnlSample"
        Me.PnlSample.Size = New System.Drawing.Size(309, 163)
        Me.PnlSample.TabIndex = 1
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
        Me.LblAddDivision.TabIndex = 2
        Me.LblAddDivision.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtOrderNo
        '
        Me.TxtOrderNo.Location = New System.Drawing.Point(71, 108)
        Me.TxtOrderNo.Name = "TxtOrderNo"
        Me.TxtOrderNo.Size = New System.Drawing.Size(97, 20)
        Me.TxtOrderNo.TabIndex = 10
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 111)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 13)
        Me.Label17.TabIndex = 9
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
        Me.DtPkrOrderDate.TabIndex = 12
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(174, 111)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(30, 13)
        Me.Label20.TabIndex = 11
        Me.Label20.Text = "Date"
        '
        'TxtPickSlipNo
        '
        Me.TxtPickSlipNo.Location = New System.Drawing.Point(71, 82)
        Me.TxtPickSlipNo.Name = "TxtPickSlipNo"
        Me.TxtPickSlipNo.Size = New System.Drawing.Size(202, 20)
        Me.TxtPickSlipNo.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 85)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 13)
        Me.Label15.TabIndex = 7
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
        Me.PnlTransporter.Controls.Add(Me.LblAddTransporter)
        Me.PnlTransporter.Controls.Add(Me.LblAddHQ)
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
        Me.PnlTransporter.Location = New System.Drawing.Point(693, 14)
        Me.PnlTransporter.Name = "PnlTransporter"
        Me.PnlTransporter.Size = New System.Drawing.Size(321, 161)
        Me.PnlTransporter.TabIndex = 2
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
        Me.LblAddTransporter.TabIndex = 2
        Me.LblAddTransporter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'CmbHQ
        '
        Me.CmbHQ.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbHQ.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbHQ.FormattingEnabled = True
        Me.CmbHQ.Location = New System.Drawing.Point(70, 135)
        Me.CmbHQ.Name = "CmbHQ"
        Me.CmbHQ.Size = New System.Drawing.Size(202, 21)
        Me.CmbHQ.Sorted = True
        Me.CmbHQ.TabIndex = 16
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(4, 140)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(32, 13)
        Me.Label31.TabIndex = 15
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
        Me.DtPkrDueDate.TabIndex = 14
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(4, 112)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(53, 13)
        Me.Label30.TabIndex = 13
        Me.Label30.Text = "Due Date"
        '
        'TxtCases
        '
        Me.TxtCases.Location = New System.Drawing.Point(215, 84)
        Me.TxtCases.Name = "TxtCases"
        Me.TxtCases.Size = New System.Drawing.Size(93, 20)
        Me.TxtCases.TabIndex = 12
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(179, 87)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(36, 13)
        Me.Label29.TabIndex = 11
        Me.Label29.Text = "Cases"
        '
        'TxtChequeNo
        '
        Me.TxtChequeNo.Location = New System.Drawing.Point(70, 83)
        Me.TxtChequeNo.Name = "TxtChequeNo"
        Me.TxtChequeNo.Size = New System.Drawing.Size(103, 20)
        Me.TxtChequeNo.TabIndex = 10
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(4, 87)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(64, 13)
        Me.Label28.TabIndex = 9
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
        Me.DtPkrLRDate.TabIndex = 8
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(179, 60)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(30, 13)
        Me.Label27.TabIndex = 7
        Me.Label27.Text = "Date"
        '
        'TxtLRNo
        '
        Me.TxtLRNo.Location = New System.Drawing.Point(70, 57)
        Me.TxtLRNo.Name = "TxtLRNo"
        Me.TxtLRNo.Size = New System.Drawing.Size(103, 20)
        Me.TxtLRNo.TabIndex = 6
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(4, 61)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(44, 13)
        Me.Label26.TabIndex = 5
        Me.Label26.Text = "L.R.No."
        '
        'TxtDestination
        '
        Me.TxtDestination.Location = New System.Drawing.Point(70, 31)
        Me.TxtDestination.Name = "TxtDestination"
        Me.TxtDestination.Size = New System.Drawing.Size(149, 20)
        Me.TxtDestination.TabIndex = 4
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(4, 34)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(60, 13)
        Me.Label25.TabIndex = 3
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
        'PnlItem
        '
        Me.PnlItem.Controls.Add(Me.CmbItem)
        Me.PnlItem.Controls.Add(Me.Label7)
        Me.PnlItem.Controls.Add(Me.CmbCategory)
        Me.PnlItem.Controls.Add(Me.Label11)
        Me.PnlItem.Controls.Add(Me.BtnRemove)
        Me.PnlItem.Controls.Add(Me.Label10)
        Me.PnlItem.Controls.Add(Me.TxtQuantity)
        Me.PnlItem.Controls.Add(Me.BtnAdd)
        Me.PnlItem.Location = New System.Drawing.Point(12, 176)
        Me.PnlItem.Name = "PnlItem"
        Me.PnlItem.Size = New System.Drawing.Size(1002, 51)
        Me.PnlItem.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Card No."
        Me.Label3.Visible = False
        '
        'CmbCardNo
        '
        Me.CmbCardNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.CmbCardNo.FormattingEnabled = True
        Me.CmbCardNo.Location = New System.Drawing.Point(99, 3)
        Me.CmbCardNo.Name = "CmbCardNo"
        Me.CmbCardNo.Size = New System.Drawing.Size(92, 21)
        Me.CmbCardNo.Sorted = True
        Me.CmbCardNo.TabIndex = 1
        Me.CmbCardNo.Visible = False
        '
        'FrmSample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(1026, 685)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpButtons)
        Me.Controls.Add(Me.PnlItem)
        Me.Controls.Add(Me.PnlTransporter)
        Me.Controls.Add(Me.PnlSample)
        Me.Controls.Add(Me.PnlCustomer)
        Me.Controls.Add(Me.GrpSampleOnBill)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSample"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Issue Sample"
        Me.GrpSampleOnBill.ResumeLayout(False)
        CType(Me.GrdSample, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpButtons.ResumeLayout(False)
        Me.PnlCustomer.ResumeLayout(False)
        Me.PnlCustomer.PerformLayout()
        Me.PnlSample.ResumeLayout(False)
        Me.PnlSample.PerformLayout()
        Me.PnlTransporter.ResumeLayout(False)
        Me.PnlTransporter.PerformLayout()
        Me.PnlItem.ResumeLayout(False)
        Me.PnlItem.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CmbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtSampleCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtPkrSampleDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmbItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents BtnRemove As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents GrpSampleOnBill As System.Windows.Forms.GroupBox
    Friend WithEvents GrdSample As System.Windows.Forms.DataGridView
    Friend WithEvents GrpButtons As System.Windows.Forms.GroupBox
    Friend WithEvents TxtReference As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnAddFreeItems As System.Windows.Forms.Button
    Friend WithEvents CmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PnlCustomer As System.Windows.Forms.Panel
    Friend WithEvents PnlSample As System.Windows.Forms.Panel
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
    Friend WithEvents TxtDLNo As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents TxtTinNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PnlItem As System.Windows.Forms.Panel
    Friend WithEvents LblAddCustomer As System.Windows.Forms.Label
    Friend WithEvents LblAddDivision As System.Windows.Forms.Label
    Friend WithEvents LblAddTransporter As System.Windows.Forms.Label
    Friend WithEvents LblAddHQ As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbCardNo As System.Windows.Forms.ComboBox

End Class
