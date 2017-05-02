<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSalesReturn
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
        Me.GrpSaleDetail = New System.Windows.Forms.GroupBox
        Me.TxtDiscountOnBill = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.TxtRoundOffSale = New System.Windows.Forms.TextBox
        Me.TxtTotalAmountSale = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxtNetAmountSale = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.GrdItemsSale = New System.Windows.Forms.DataGridView
        Me.CmbDoctor = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.CmbCustomer = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.DtPkrSaleDate = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtSaleCode = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DtPkrReturnDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtSalesReturnCode = New System.Windows.Forms.TextBox
        Me.GrpItemReturn = New System.Windows.Forms.GroupBox
        Me.TxtDiscountOnBillReturn = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.TxtRoundOffReturn = New System.Windows.Forms.TextBox
        Me.TxtTotalReturn = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.TxtNetAmountReturn = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.TxtSalePrice = New System.Windows.Forms.TextBox
        Me.TxtTotal = New System.Windows.Forms.TextBox
        Me.GrdItemsSaleReturn = New System.Windows.Forms.DataGridView
        Me.BtnRemove = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.CmbItem = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtQuantity = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.GrpButtons = New System.Windows.Forms.GroupBox
        Me.BtnSearch = New System.Windows.Forms.Button
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.BtnNew = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.TxtRemark = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.BgWorker = New System.ComponentModel.BackgroundWorker
        Me.GrpSaleDetail.SuspendLayout()
        CType(Me.GrdItemsSale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpItemReturn.SuspendLayout()
        CType(Me.GrdItemsSaleReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpSaleDetail
        '
        Me.GrpSaleDetail.Controls.Add(Me.TxtDiscountOnBill)
        Me.GrpSaleDetail.Controls.Add(Me.Label26)
        Me.GrpSaleDetail.Controls.Add(Me.TxtRoundOffSale)
        Me.GrpSaleDetail.Controls.Add(Me.TxtTotalAmountSale)
        Me.GrpSaleDetail.Controls.Add(Me.Label9)
        Me.GrpSaleDetail.Controls.Add(Me.Label18)
        Me.GrpSaleDetail.Controls.Add(Me.TxtNetAmountSale)
        Me.GrpSaleDetail.Controls.Add(Me.Label19)
        Me.GrpSaleDetail.Controls.Add(Me.GrdItemsSale)
        Me.GrpSaleDetail.Controls.Add(Me.CmbDoctor)
        Me.GrpSaleDetail.Controls.Add(Me.Label7)
        Me.GrpSaleDetail.Controls.Add(Me.CmbCustomer)
        Me.GrpSaleDetail.Controls.Add(Me.Label6)
        Me.GrpSaleDetail.Controls.Add(Me.DtPkrSaleDate)
        Me.GrpSaleDetail.Controls.Add(Me.Label5)
        Me.GrpSaleDetail.Controls.Add(Me.Label4)
        Me.GrpSaleDetail.Controls.Add(Me.TxtSaleCode)
        Me.GrpSaleDetail.Controls.Add(Me.Label3)
        Me.GrpSaleDetail.Controls.Add(Me.DtPkrReturnDate)
        Me.GrpSaleDetail.Controls.Add(Me.Label2)
        Me.GrpSaleDetail.Controls.Add(Me.Label1)
        Me.GrpSaleDetail.Controls.Add(Me.TxtSalesReturnCode)
        Me.GrpSaleDetail.Location = New System.Drawing.Point(12, 12)
        Me.GrpSaleDetail.Name = "GrpSaleDetail"
        Me.GrpSaleDetail.Size = New System.Drawing.Size(838, 325)
        Me.GrpSaleDetail.TabIndex = 0
        Me.GrpSaleDetail.TabStop = False
        Me.GrpSaleDetail.Text = "Sale Detail"
        '
        'TxtDiscountOnBill
        '
        Me.TxtDiscountOnBill.BackColor = System.Drawing.Color.White
        Me.TxtDiscountOnBill.Enabled = False
        Me.TxtDiscountOnBill.Location = New System.Drawing.Point(358, 299)
        Me.TxtDiscountOnBill.Name = "TxtDiscountOnBill"
        Me.TxtDiscountOnBill.ReadOnly = True
        Me.TxtDiscountOnBill.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDiscountOnBill.Size = New System.Drawing.Size(105, 20)
        Me.TxtDiscountOnBill.TabIndex = 70
        Me.TxtDiscountOnBill.TabStop = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(270, 302)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(82, 13)
        Me.Label26.TabIndex = 71
        Me.Label26.Text = "Discount On Bill"
        '
        'TxtRoundOffSale
        '
        Me.TxtRoundOffSale.BackColor = System.Drawing.Color.White
        Me.TxtRoundOffSale.Enabled = False
        Me.TxtRoundOffSale.Location = New System.Drawing.Point(540, 299)
        Me.TxtRoundOffSale.Name = "TxtRoundOffSale"
        Me.TxtRoundOffSale.ReadOnly = True
        Me.TxtRoundOffSale.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtRoundOffSale.Size = New System.Drawing.Size(72, 20)
        Me.TxtRoundOffSale.TabIndex = 53
        Me.TxtRoundOffSale.TabStop = False
        '
        'TxtTotalAmountSale
        '
        Me.TxtTotalAmountSale.BackColor = System.Drawing.Color.White
        Me.TxtTotalAmountSale.Enabled = False
        Me.TxtTotalAmountSale.Location = New System.Drawing.Point(153, 299)
        Me.TxtTotalAmountSale.Name = "TxtTotalAmountSale"
        Me.TxtTotalAmountSale.ReadOnly = True
        Me.TxtTotalAmountSale.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTotalAmountSale.Size = New System.Drawing.Size(111, 20)
        Me.TxtTotalAmountSale.TabIndex = 56
        Me.TxtTotalAmountSale.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(116, 302)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "Total"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(478, 302)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 13)
        Me.Label18.TabIndex = 52
        Me.Label18.Text = "Round-Off"
        '
        'TxtNetAmountSale
        '
        Me.TxtNetAmountSale.BackColor = System.Drawing.Color.White
        Me.TxtNetAmountSale.Enabled = False
        Me.TxtNetAmountSale.Location = New System.Drawing.Point(687, 299)
        Me.TxtNetAmountSale.Name = "TxtNetAmountSale"
        Me.TxtNetAmountSale.ReadOnly = True
        Me.TxtNetAmountSale.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtNetAmountSale.Size = New System.Drawing.Size(140, 20)
        Me.TxtNetAmountSale.TabIndex = 51
        Me.TxtNetAmountSale.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(618, 302)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 13)
        Me.Label19.TabIndex = 50
        Me.Label19.Text = "Net Amount"
        '
        'GrdItemsSale
        '
        Me.GrdItemsSale.AllowUserToAddRows = False
        Me.GrdItemsSale.AllowUserToDeleteRows = False
        Me.GrdItemsSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdItemsSale.Location = New System.Drawing.Point(13, 72)
        Me.GrdItemsSale.Name = "GrdItemsSale"
        Me.GrdItemsSale.ReadOnly = True
        Me.GrdItemsSale.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdItemsSale.Size = New System.Drawing.Size(818, 221)
        Me.GrdItemsSale.TabIndex = 49
        '
        'CmbDoctor
        '
        Me.CmbDoctor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbDoctor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbDoctor.BackColor = System.Drawing.Color.White
        Me.CmbDoctor.Enabled = False
        Me.CmbDoctor.FormattingEnabled = True
        Me.CmbDoctor.Location = New System.Drawing.Point(474, 45)
        Me.CmbDoctor.Name = "CmbDoctor"
        Me.CmbDoctor.Size = New System.Drawing.Size(275, 21)
        Me.CmbDoctor.TabIndex = 13
        Me.CmbDoctor.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(395, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Doctor Name*"
        Me.Label7.Visible = False
        '
        'CmbCustomer
        '
        Me.CmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbCustomer.BackColor = System.Drawing.Color.White
        Me.CmbCustomer.Enabled = False
        Me.CmbCustomer.FormattingEnabled = True
        Me.CmbCustomer.Location = New System.Drawing.Point(102, 45)
        Me.CmbCustomer.Name = "CmbCustomer"
        Me.CmbCustomer.Size = New System.Drawing.Size(275, 21)
        Me.CmbCustomer.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Customer Name*"
        '
        'DtPkrSaleDate
        '
        Me.DtPkrSaleDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrSaleDate.Enabled = False
        Me.DtPkrSaleDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrSaleDate.Location = New System.Drawing.Point(739, 19)
        Me.DtPkrSaleDate.Name = "DtPkrSaleDate"
        Me.DtPkrSaleDate.Size = New System.Drawing.Size(92, 20)
        Me.DtPkrSaleDate.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(679, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Sale Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(518, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 18)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "INV"
        '
        'TxtSaleCode
        '
        Me.TxtSaleCode.Location = New System.Drawing.Point(551, 19)
        Me.TxtSaleCode.Name = "TxtSaleCode"
        Me.TxtSaleCode.Size = New System.Drawing.Size(122, 20)
        Me.TxtSaleCode.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(383, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Return Against Sale Code"
        '
        'DtPkrReturnDate
        '
        Me.DtPkrReturnDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrReturnDate.Location = New System.Drawing.Point(285, 19)
        Me.DtPkrReturnDate.Name = "DtPkrReturnDate"
        Me.DtPkrReturnDate.Size = New System.Drawing.Size(92, 20)
        Me.DtPkrReturnDate.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(214, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Return Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Return Code"
        '
        'TxtSalesReturnCode
        '
        Me.TxtSalesReturnCode.BackColor = System.Drawing.Color.White
        Me.TxtSalesReturnCode.Enabled = False
        Me.TxtSalesReturnCode.Location = New System.Drawing.Point(79, 19)
        Me.TxtSalesReturnCode.Name = "TxtSalesReturnCode"
        Me.TxtSalesReturnCode.ReadOnly = True
        Me.TxtSalesReturnCode.Size = New System.Drawing.Size(129, 20)
        Me.TxtSalesReturnCode.TabIndex = 0
        '
        'GrpItemReturn
        '
        Me.GrpItemReturn.Controls.Add(Me.TxtDiscountOnBillReturn)
        Me.GrpItemReturn.Controls.Add(Me.Label27)
        Me.GrpItemReturn.Controls.Add(Me.TxtRoundOffReturn)
        Me.GrpItemReturn.Controls.Add(Me.TxtTotalReturn)
        Me.GrpItemReturn.Controls.Add(Me.Label20)
        Me.GrpItemReturn.Controls.Add(Me.Label23)
        Me.GrpItemReturn.Controls.Add(Me.TxtNetAmountReturn)
        Me.GrpItemReturn.Controls.Add(Me.Label24)
        Me.GrpItemReturn.Controls.Add(Me.TxtSalePrice)
        Me.GrpItemReturn.Controls.Add(Me.TxtTotal)
        Me.GrpItemReturn.Controls.Add(Me.GrdItemsSaleReturn)
        Me.GrpItemReturn.Controls.Add(Me.BtnRemove)
        Me.GrpItemReturn.Controls.Add(Me.BtnAdd)
        Me.GrpItemReturn.Controls.Add(Me.Label13)
        Me.GrpItemReturn.Controls.Add(Me.CmbItem)
        Me.GrpItemReturn.Controls.Add(Me.Label10)
        Me.GrpItemReturn.Controls.Add(Me.Label16)
        Me.GrpItemReturn.Controls.Add(Me.TxtQuantity)
        Me.GrpItemReturn.Controls.Add(Me.Label17)
        Me.GrpItemReturn.Location = New System.Drawing.Point(12, 343)
        Me.GrpItemReturn.Name = "GrpItemReturn"
        Me.GrpItemReturn.Size = New System.Drawing.Size(838, 282)
        Me.GrpItemReturn.TabIndex = 10
        Me.GrpItemReturn.TabStop = False
        '
        'TxtDiscountOnBillReturn
        '
        Me.TxtDiscountOnBillReturn.BackColor = System.Drawing.Color.White
        Me.TxtDiscountOnBillReturn.Location = New System.Drawing.Point(358, 250)
        Me.TxtDiscountOnBillReturn.Name = "TxtDiscountOnBillReturn"
        Me.TxtDiscountOnBillReturn.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDiscountOnBillReturn.Size = New System.Drawing.Size(105, 20)
        Me.TxtDiscountOnBillReturn.TabIndex = 72
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(212, 253)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(140, 13)
        Me.Label27.TabIndex = 73
        Me.Label27.Text = "Discount On Bill Return"
        '
        'TxtRoundOffReturn
        '
        Me.TxtRoundOffReturn.BackColor = System.Drawing.Color.White
        Me.TxtRoundOffReturn.Enabled = False
        Me.TxtRoundOffReturn.Location = New System.Drawing.Point(532, 249)
        Me.TxtRoundOffReturn.Name = "TxtRoundOffReturn"
        Me.TxtRoundOffReturn.ReadOnly = True
        Me.TxtRoundOffReturn.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtRoundOffReturn.Size = New System.Drawing.Size(72, 20)
        Me.TxtRoundOffReturn.TabIndex = 63
        Me.TxtRoundOffReturn.TabStop = False
        '
        'TxtTotalReturn
        '
        Me.TxtTotalReturn.BackColor = System.Drawing.Color.White
        Me.TxtTotalReturn.Enabled = False
        Me.TxtTotalReturn.Location = New System.Drawing.Point(95, 249)
        Me.TxtTotalReturn.Name = "TxtTotalReturn"
        Me.TxtTotalReturn.ReadOnly = True
        Me.TxtTotalReturn.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTotalReturn.Size = New System.Drawing.Size(111, 20)
        Me.TxtTotalReturn.TabIndex = 66
        Me.TxtTotalReturn.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(58, 253)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(31, 13)
        Me.Label20.TabIndex = 69
        Me.Label20.Text = "Total"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(470, 253)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 13)
        Me.Label23.TabIndex = 62
        Me.Label23.Text = "Round-Off"
        '
        'TxtNetAmountReturn
        '
        Me.TxtNetAmountReturn.BackColor = System.Drawing.Color.White
        Me.TxtNetAmountReturn.Enabled = False
        Me.TxtNetAmountReturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetAmountReturn.Location = New System.Drawing.Point(691, 249)
        Me.TxtNetAmountReturn.Name = "TxtNetAmountReturn"
        Me.TxtNetAmountReturn.ReadOnly = True
        Me.TxtNetAmountReturn.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtNetAmountReturn.Size = New System.Drawing.Size(140, 20)
        Me.TxtNetAmountReturn.TabIndex = 61
        Me.TxtNetAmountReturn.TabStop = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(612, 252)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(73, 13)
        Me.Label24.TabIndex = 60
        Me.Label24.Text = "Net Amount"
        '
        'TxtSalePrice
        '
        Me.TxtSalePrice.BackColor = System.Drawing.Color.White
        Me.TxtSalePrice.Enabled = False
        Me.TxtSalePrice.Location = New System.Drawing.Point(461, 33)
        Me.TxtSalePrice.Name = "TxtSalePrice"
        Me.TxtSalePrice.ReadOnly = True
        Me.TxtSalePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtSalePrice.Size = New System.Drawing.Size(93, 20)
        Me.TxtSalePrice.TabIndex = 10
        '
        'TxtTotal
        '
        Me.TxtTotal.BackColor = System.Drawing.Color.White
        Me.TxtTotal.Enabled = False
        Me.TxtTotal.Location = New System.Drawing.Point(584, 32)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.ReadOnly = True
        Me.TxtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTotal.Size = New System.Drawing.Size(77, 20)
        Me.TxtTotal.TabIndex = 13
        Me.TxtTotal.TabStop = False
        '
        'GrdItemsSaleReturn
        '
        Me.GrdItemsSaleReturn.AllowUserToAddRows = False
        Me.GrdItemsSaleReturn.AllowUserToDeleteRows = False
        Me.GrdItemsSaleReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdItemsSaleReturn.Location = New System.Drawing.Point(10, 60)
        Me.GrdItemsSaleReturn.Name = "GrdItemsSaleReturn"
        Me.GrdItemsSaleReturn.ReadOnly = True
        Me.GrdItemsSaleReturn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdItemsSaleReturn.Size = New System.Drawing.Size(821, 175)
        Me.GrdItemsSaleReturn.TabIndex = 48
        '
        'BtnRemove
        '
        Me.BtnRemove.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnRemove.Location = New System.Drawing.Point(758, 29)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(73, 26)
        Me.BtnRemove.TabIndex = 47
        Me.BtnRemove.Text = "&Remove"
        Me.BtnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnAdd.Location = New System.Drawing.Point(679, 29)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(73, 26)
        Me.BtnAdd.TabIndex = 46
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(581, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 44
        Me.Label13.Text = "Total"
        '
        'CmbItem
        '
        Me.CmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbItem.Enabled = False
        Me.CmbItem.FormattingEnabled = True
        Me.CmbItem.Location = New System.Drawing.Point(10, 32)
        Me.CmbItem.Name = "CmbItem"
        Me.CmbItem.Size = New System.Drawing.Size(342, 21)
        Me.CmbItem.Sorted = True
        Me.CmbItem.TabIndex = 33
        Me.CmbItem.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Item Name*"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(458, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 13)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Sale Price"
        '
        'TxtQuantity
        '
        Me.TxtQuantity.Location = New System.Drawing.Point(358, 33)
        Me.TxtQuantity.Name = "TxtQuantity"
        Me.TxtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtQuantity.Size = New System.Drawing.Size(96, 20)
        Me.TxtQuantity.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(355, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Quantity"
        '
        'GrpButtons
        '
        Me.GrpButtons.Controls.Add(Me.BtnSearch)
        Me.GrpButtons.Controls.Add(Me.BtnPrint)
        Me.GrpButtons.Controls.Add(Me.BtnNew)
        Me.GrpButtons.Controls.Add(Me.BtnClose)
        Me.GrpButtons.Controls.Add(Me.BtnSave)
        Me.GrpButtons.Controls.Add(Me.TxtRemark)
        Me.GrpButtons.Controls.Add(Me.Label25)
        Me.GrpButtons.Location = New System.Drawing.Point(12, 631)
        Me.GrpButtons.Name = "GrpButtons"
        Me.GrpButtons.Size = New System.Drawing.Size(838, 51)
        Me.GrpButtons.TabIndex = 12
        Me.GrpButtons.TabStop = False
        '
        'BtnSearch
        '
        Me.BtnSearch.Location = New System.Drawing.Point(676, 16)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(72, 26)
        Me.BtnSearch.TabIndex = 64
        Me.BtnSearch.Text = "Searc&h"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.Location = New System.Drawing.Point(597, 15)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(72, 26)
        Me.BtnPrint.TabIndex = 63
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'BtnNew
        '
        Me.BtnNew.Location = New System.Drawing.Point(441, 16)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(72, 26)
        Me.BtnNew.TabIndex = 62
        Me.BtnNew.Text = "&New"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(755, 16)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 61
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(519, 16)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(72, 26)
        Me.BtnSave.TabIndex = 60
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'TxtRemark
        '
        Me.TxtRemark.Location = New System.Drawing.Point(61, 19)
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(374, 20)
        Me.TxtRemark.TabIndex = 45
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 22)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(49, 13)
        Me.Label25.TabIndex = 46
        Me.Label25.Text = "Remarks"
        '
        'BgWorker
        '
        '
        'FrmSalesReturn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(861, 697)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpButtons)
        Me.Controls.Add(Me.GrpItemReturn)
        Me.Controls.Add(Me.GrpSaleDetail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSalesReturn"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Return"
        Me.GrpSaleDetail.ResumeLayout(False)
        Me.GrpSaleDetail.PerformLayout()
        CType(Me.GrdItemsSale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpItemReturn.ResumeLayout(False)
        Me.GrpItemReturn.PerformLayout()
        CType(Me.GrdItemsSaleReturn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpButtons.ResumeLayout(False)
        Me.GrpButtons.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpSaleDetail As System.Windows.Forms.GroupBox
    Friend WithEvents DtPkrReturnDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtSalesReturnCode As System.Windows.Forms.TextBox
    Friend WithEvents CmbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DtPkrSaleDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtSaleCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbDoctor As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtRoundOffSale As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotalAmountSale As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtNetAmountSale As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GrdItemsSale As System.Windows.Forms.DataGridView
    Friend WithEvents GrpItemReturn As System.Windows.Forms.GroupBox
    Friend WithEvents TxtSalePrice As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents GrdItemsSaleReturn As System.Windows.Forms.DataGridView
    Friend WithEvents BtnRemove As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CmbItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtRoundOffReturn As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotalReturn As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TxtNetAmountReturn As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents GrpButtons As System.Windows.Forms.GroupBox
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents TxtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TxtDiscountOnBill As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TxtDiscountOnBillReturn As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents BgWorker As System.ComponentModel.BackgroundWorker
End Class
