<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPurchaseReturn
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
        Me.GrpPurchaseDetail = New System.Windows.Forms.GroupBox
        Me.TxtRoundOffPurchase = New System.Windows.Forms.TextBox
        Me.TxtTaxTotalPurchase = New System.Windows.Forms.TextBox
        Me.TxtDiscountTotalPurchase = New System.Windows.Forms.TextBox
        Me.TxtTotalAmountPurchase = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxtNetAmountPurchase = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.GrdItemsPurchase = New System.Windows.Forms.DataGridView
        Me.CmbVendor = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.DtPkrPurchaseDate = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtPurchaseCode = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DtPkrReturnDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPurchaseReturnCode = New System.Windows.Forms.TextBox
        Me.GrpButtons = New System.Windows.Forms.GroupBox
        Me.BtnSearch = New System.Windows.Forms.Button
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.BtnNew = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.TxtRemark = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.GrpItemReturn = New System.Windows.Forms.GroupBox
        Me.PnlQuantity = New System.Windows.Forms.Panel
        Me.Label34 = New System.Windows.Forms.Label
        Me.TxtTotalQunatity = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.TxtReturnQuantity = New System.Windows.Forms.TextBox
        Me.TxtFreeQuantity = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.TxtPackQty = New System.Windows.Forms.TextBox
        Me.TxtPackSize = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.TxtRoundOffReturn = New System.Windows.Forms.TextBox
        Me.TxtTaxReturn = New System.Windows.Forms.TextBox
        Me.TxtDiscountReturn = New System.Windows.Forms.TextBox
        Me.TxtTotalReturn = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.TxtNetAmountReturn = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.TxtPurchasePrice = New System.Windows.Forms.TextBox
        Me.TxtTax = New System.Windows.Forms.TextBox
        Me.TxtDiscount = New System.Windows.Forms.TextBox
        Me.TxtTotal = New System.Windows.Forms.TextBox
        Me.GrdItemsPurchaseReturn = New System.Windows.Forms.DataGridView
        Me.BtnRemove = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.CmbDiscountType = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.CmbTaxType = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.CmbItem = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.GrpPurchaseDetail.SuspendLayout()
        CType(Me.GrdItemsPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpButtons.SuspendLayout()
        Me.GrpItemReturn.SuspendLayout()
        Me.PnlQuantity.SuspendLayout()
        CType(Me.GrdItemsPurchaseReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpPurchaseDetail
        '
        Me.GrpPurchaseDetail.Controls.Add(Me.TxtRoundOffPurchase)
        Me.GrpPurchaseDetail.Controls.Add(Me.TxtTaxTotalPurchase)
        Me.GrpPurchaseDetail.Controls.Add(Me.TxtDiscountTotalPurchase)
        Me.GrpPurchaseDetail.Controls.Add(Me.TxtTotalAmountPurchase)
        Me.GrpPurchaseDetail.Controls.Add(Me.Label9)
        Me.GrpPurchaseDetail.Controls.Add(Me.Label14)
        Me.GrpPurchaseDetail.Controls.Add(Me.Label15)
        Me.GrpPurchaseDetail.Controls.Add(Me.Label18)
        Me.GrpPurchaseDetail.Controls.Add(Me.TxtNetAmountPurchase)
        Me.GrpPurchaseDetail.Controls.Add(Me.Label19)
        Me.GrpPurchaseDetail.Controls.Add(Me.GrdItemsPurchase)
        Me.GrpPurchaseDetail.Controls.Add(Me.CmbVendor)
        Me.GrpPurchaseDetail.Controls.Add(Me.Label6)
        Me.GrpPurchaseDetail.Controls.Add(Me.DtPkrPurchaseDate)
        Me.GrpPurchaseDetail.Controls.Add(Me.Label5)
        Me.GrpPurchaseDetail.Controls.Add(Me.Label4)
        Me.GrpPurchaseDetail.Controls.Add(Me.TxtPurchaseCode)
        Me.GrpPurchaseDetail.Controls.Add(Me.Label3)
        Me.GrpPurchaseDetail.Controls.Add(Me.DtPkrReturnDate)
        Me.GrpPurchaseDetail.Controls.Add(Me.Label2)
        Me.GrpPurchaseDetail.Controls.Add(Me.Label1)
        Me.GrpPurchaseDetail.Controls.Add(Me.TxtPurchaseReturnCode)
        Me.GrpPurchaseDetail.Location = New System.Drawing.Point(12, 12)
        Me.GrpPurchaseDetail.Name = "GrpPurchaseDetail"
        Me.GrpPurchaseDetail.Size = New System.Drawing.Size(815, 267)
        Me.GrpPurchaseDetail.TabIndex = 1
        Me.GrpPurchaseDetail.TabStop = False
        Me.GrpPurchaseDetail.Text = "Purchase Detail"
        '
        'TxtRoundOffPurchase
        '
        Me.TxtRoundOffPurchase.BackColor = System.Drawing.Color.White
        Me.TxtRoundOffPurchase.Enabled = False
        Me.TxtRoundOffPurchase.Location = New System.Drawing.Point(515, 236)
        Me.TxtRoundOffPurchase.Name = "TxtRoundOffPurchase"
        Me.TxtRoundOffPurchase.ReadOnly = True
        Me.TxtRoundOffPurchase.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtRoundOffPurchase.Size = New System.Drawing.Size(72, 20)
        Me.TxtRoundOffPurchase.TabIndex = 53
        Me.TxtRoundOffPurchase.TabStop = False
        '
        'TxtTaxTotalPurchase
        '
        Me.TxtTaxTotalPurchase.BackColor = System.Drawing.Color.White
        Me.TxtTaxTotalPurchase.Enabled = False
        Me.TxtTaxTotalPurchase.Location = New System.Drawing.Point(195, 236)
        Me.TxtTaxTotalPurchase.Name = "TxtTaxTotalPurchase"
        Me.TxtTaxTotalPurchase.ReadOnly = True
        Me.TxtTaxTotalPurchase.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTaxTotalPurchase.Size = New System.Drawing.Size(86, 20)
        Me.TxtTaxTotalPurchase.TabIndex = 54
        Me.TxtTaxTotalPurchase.TabStop = False
        '
        'TxtDiscountTotalPurchase
        '
        Me.TxtDiscountTotalPurchase.BackColor = System.Drawing.Color.White
        Me.TxtDiscountTotalPurchase.Enabled = False
        Me.TxtDiscountTotalPurchase.Location = New System.Drawing.Point(342, 237)
        Me.TxtDiscountTotalPurchase.Name = "TxtDiscountTotalPurchase"
        Me.TxtDiscountTotalPurchase.ReadOnly = True
        Me.TxtDiscountTotalPurchase.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDiscountTotalPurchase.Size = New System.Drawing.Size(105, 20)
        Me.TxtDiscountTotalPurchase.TabIndex = 55
        Me.TxtDiscountTotalPurchase.TabStop = False
        '
        'TxtTotalAmountPurchase
        '
        Me.TxtTotalAmountPurchase.BackColor = System.Drawing.Color.White
        Me.TxtTotalAmountPurchase.Enabled = False
        Me.TxtTotalAmountPurchase.Location = New System.Drawing.Point(47, 236)
        Me.TxtTotalAmountPurchase.Name = "TxtTotalAmountPurchase"
        Me.TxtTotalAmountPurchase.ReadOnly = True
        Me.TxtTotalAmountPurchase.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTotalAmountPurchase.Size = New System.Drawing.Size(111, 20)
        Me.TxtTotalAmountPurchase.TabIndex = 56
        Me.TxtTotalAmountPurchase.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 239)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "Total"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(287, 239)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 13)
        Me.Label14.TabIndex = 58
        Me.Label14.Text = "Discount"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(164, 240)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(25, 13)
        Me.Label15.TabIndex = 57
        Me.Label15.Text = "Tax"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(453, 240)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 13)
        Me.Label18.TabIndex = 52
        Me.Label18.Text = "Round-Off"
        '
        'TxtNetAmountPurchase
        '
        Me.TxtNetAmountPurchase.BackColor = System.Drawing.Color.White
        Me.TxtNetAmountPurchase.Enabled = False
        Me.TxtNetAmountPurchase.Location = New System.Drawing.Point(662, 236)
        Me.TxtNetAmountPurchase.Name = "TxtNetAmountPurchase"
        Me.TxtNetAmountPurchase.ReadOnly = True
        Me.TxtNetAmountPurchase.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtNetAmountPurchase.Size = New System.Drawing.Size(140, 20)
        Me.TxtNetAmountPurchase.TabIndex = 51
        Me.TxtNetAmountPurchase.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(593, 239)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 13)
        Me.Label19.TabIndex = 50
        Me.Label19.Text = "Net Amount"
        '
        'GrdItemsPurchase
        '
        Me.GrdItemsPurchase.AllowUserToAddRows = False
        Me.GrdItemsPurchase.AllowUserToDeleteRows = False
        Me.GrdItemsPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdItemsPurchase.Location = New System.Drawing.Point(13, 59)
        Me.GrdItemsPurchase.Name = "GrdItemsPurchase"
        Me.GrdItemsPurchase.ReadOnly = True
        Me.GrdItemsPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdItemsPurchase.Size = New System.Drawing.Size(789, 171)
        Me.GrdItemsPurchase.TabIndex = 49
        '
        'CmbVendor
        '
        Me.CmbVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.CmbVendor.Enabled = False
        Me.CmbVendor.FormattingEnabled = True
        Me.CmbVendor.Location = New System.Drawing.Point(475, 32)
        Me.CmbVendor.Name = "CmbVendor"
        Me.CmbVendor.Size = New System.Drawing.Size(327, 21)
        Me.CmbVendor.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(472, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Vendor Name"
        '
        'DtPkrPurchaseDate
        '
        Me.DtPkrPurchaseDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrPurchaseDate.Enabled = False
        Me.DtPkrPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrPurchaseDate.Location = New System.Drawing.Point(377, 32)
        Me.DtPkrPurchaseDate.Name = "DtPkrPurchaseDate"
        Me.DtPkrPurchaseDate.Size = New System.Drawing.Size(92, 20)
        Me.DtPkrPurchaseDate.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(374, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Purchase Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(206, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 18)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "PU"
        '
        'TxtPurchaseCode
        '
        Me.TxtPurchaseCode.Location = New System.Drawing.Point(236, 33)
        Me.TxtPurchaseCode.Name = "TxtPurchaseCode"
        Me.TxtPurchaseCode.Size = New System.Drawing.Size(135, 20)
        Me.TxtPurchaseCode.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(206, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(153, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Return Against Purchase Code"
        '
        'DtPkrReturnDate
        '
        Me.DtPkrReturnDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrReturnDate.Location = New System.Drawing.Point(109, 32)
        Me.DtPkrReturnDate.Name = "DtPkrReturnDate"
        Me.DtPkrReturnDate.Size = New System.Drawing.Size(92, 20)
        Me.DtPkrReturnDate.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(106, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Return Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Return Code"
        '
        'TxtPurchaseReturnCode
        '
        Me.TxtPurchaseReturnCode.BackColor = System.Drawing.Color.White
        Me.TxtPurchaseReturnCode.Enabled = False
        Me.TxtPurchaseReturnCode.Location = New System.Drawing.Point(9, 32)
        Me.TxtPurchaseReturnCode.Name = "TxtPurchaseReturnCode"
        Me.TxtPurchaseReturnCode.ReadOnly = True
        Me.TxtPurchaseReturnCode.Size = New System.Drawing.Size(94, 20)
        Me.TxtPurchaseReturnCode.TabIndex = 0
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
        Me.GrpButtons.Location = New System.Drawing.Point(12, 614)
        Me.GrpButtons.Name = "GrpButtons"
        Me.GrpButtons.Size = New System.Drawing.Size(815, 51)
        Me.GrpButtons.TabIndex = 14
        Me.GrpButtons.TabStop = False
        '
        'BtnSearch
        '
        Me.BtnSearch.Location = New System.Drawing.Point(656, 16)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(72, 26)
        Me.BtnSearch.TabIndex = 64
        Me.BtnSearch.Text = "Searc&h"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.Location = New System.Drawing.Point(577, 15)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(72, 26)
        Me.BtnPrint.TabIndex = 63
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'BtnNew
        '
        Me.BtnNew.Location = New System.Drawing.Point(421, 16)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(72, 26)
        Me.BtnNew.TabIndex = 62
        Me.BtnNew.Text = "&New"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(735, 16)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 61
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(499, 16)
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
        Me.TxtRemark.Size = New System.Drawing.Size(354, 20)
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
        'GrpItemReturn
        '
        Me.GrpItemReturn.Controls.Add(Me.PnlQuantity)
        Me.GrpItemReturn.Controls.Add(Me.TxtRoundOffReturn)
        Me.GrpItemReturn.Controls.Add(Me.TxtTaxReturn)
        Me.GrpItemReturn.Controls.Add(Me.TxtDiscountReturn)
        Me.GrpItemReturn.Controls.Add(Me.TxtTotalReturn)
        Me.GrpItemReturn.Controls.Add(Me.Label20)
        Me.GrpItemReturn.Controls.Add(Me.Label21)
        Me.GrpItemReturn.Controls.Add(Me.Label22)
        Me.GrpItemReturn.Controls.Add(Me.Label23)
        Me.GrpItemReturn.Controls.Add(Me.TxtNetAmountReturn)
        Me.GrpItemReturn.Controls.Add(Me.Label24)
        Me.GrpItemReturn.Controls.Add(Me.TxtPurchasePrice)
        Me.GrpItemReturn.Controls.Add(Me.TxtTax)
        Me.GrpItemReturn.Controls.Add(Me.TxtDiscount)
        Me.GrpItemReturn.Controls.Add(Me.TxtTotal)
        Me.GrpItemReturn.Controls.Add(Me.GrdItemsPurchaseReturn)
        Me.GrpItemReturn.Controls.Add(Me.BtnRemove)
        Me.GrpItemReturn.Controls.Add(Me.BtnAdd)
        Me.GrpItemReturn.Controls.Add(Me.Label13)
        Me.GrpItemReturn.Controls.Add(Me.CmbDiscountType)
        Me.GrpItemReturn.Controls.Add(Me.Label12)
        Me.GrpItemReturn.Controls.Add(Me.CmbTaxType)
        Me.GrpItemReturn.Controls.Add(Me.Label11)
        Me.GrpItemReturn.Controls.Add(Me.CmbItem)
        Me.GrpItemReturn.Controls.Add(Me.Label10)
        Me.GrpItemReturn.Controls.Add(Me.Label16)
        Me.GrpItemReturn.Location = New System.Drawing.Point(12, 285)
        Me.GrpItemReturn.Name = "GrpItemReturn"
        Me.GrpItemReturn.Size = New System.Drawing.Size(815, 323)
        Me.GrpItemReturn.TabIndex = 13
        Me.GrpItemReturn.TabStop = False
        '
        'PnlQuantity
        '
        Me.PnlQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlQuantity.Controls.Add(Me.Label34)
        Me.PnlQuantity.Controls.Add(Me.TxtTotalQunatity)
        Me.PnlQuantity.Controls.Add(Me.Label31)
        Me.PnlQuantity.Controls.Add(Me.Label7)
        Me.PnlQuantity.Controls.Add(Me.Label32)
        Me.PnlQuantity.Controls.Add(Me.TxtReturnQuantity)
        Me.PnlQuantity.Controls.Add(Me.TxtFreeQuantity)
        Me.PnlQuantity.Controls.Add(Me.Label30)
        Me.PnlQuantity.Controls.Add(Me.Label17)
        Me.PnlQuantity.Controls.Add(Me.Label29)
        Me.PnlQuantity.Controls.Add(Me.Label28)
        Me.PnlQuantity.Controls.Add(Me.Label26)
        Me.PnlQuantity.Controls.Add(Me.TxtPackQty)
        Me.PnlQuantity.Controls.Add(Me.TxtPackSize)
        Me.PnlQuantity.Controls.Add(Me.Label27)
        Me.PnlQuantity.Location = New System.Drawing.Point(9, 46)
        Me.PnlQuantity.Name = "PnlQuantity"
        Me.PnlQuantity.Size = New System.Drawing.Size(802, 49)
        Me.PnlQuantity.TabIndex = 79
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Fuchsia
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(482, 12)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(265, 28)
        Me.Label34.TabIndex = 80
        Me.Label34.Text = "Pack size is fixed while purchase." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Enter quantity to return (purchased and free " & _
            "seperatly)."
        '
        'TxtTotalQunatity
        '
        Me.TxtTotalQunatity.BackColor = System.Drawing.Color.White
        Me.TxtTotalQunatity.Enabled = False
        Me.TxtTotalQunatity.Location = New System.Drawing.Point(387, 22)
        Me.TxtTotalQunatity.Name = "TxtTotalQunatity"
        Me.TxtTotalQunatity.ReadOnly = True
        Me.TxtTotalQunatity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTotalQunatity.Size = New System.Drawing.Size(77, 20)
        Me.TxtTotalQunatity.TabIndex = 75
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(370, 25)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(13, 13)
        Me.Label31.TabIndex = 77
        Me.Label31.Text = "="
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(104, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Ret. Qty."
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(384, 5)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(73, 13)
        Me.Label32.TabIndex = 76
        Me.Label32.Text = "Total Quantity"
        '
        'TxtReturnQuantity
        '
        Me.TxtReturnQuantity.Location = New System.Drawing.Point(102, 22)
        Me.TxtReturnQuantity.Name = "TxtReturnQuantity"
        Me.TxtReturnQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtReturnQuantity.Size = New System.Drawing.Size(72, 20)
        Me.TxtReturnQuantity.TabIndex = 1
        '
        'TxtFreeQuantity
        '
        Me.TxtFreeQuantity.Location = New System.Drawing.Point(294, 22)
        Me.TxtFreeQuantity.Name = "TxtFreeQuantity"
        Me.TxtFreeQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtFreeQuantity.Size = New System.Drawing.Size(73, 20)
        Me.TxtFreeQuantity.TabIndex = 51
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(277, 25)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(12, 13)
        Me.Label30.TabIndex = 74
        Me.Label30.Text = "x"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(291, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(50, 13)
        Me.Label17.TabIndex = 52
        Me.Label17.Text = "Free Qty."
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(177, 25)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(13, 13)
        Me.Label29.TabIndex = 73
        Me.Label29.Text = "+"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(6, 5)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(55, 13)
        Me.Label28.TabIndex = 59
        Me.Label28.Text = "Pack Size"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(191, 5)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(55, 13)
        Me.Label26.TabIndex = 72
        Me.Label26.Text = "Pack Size"
        '
        'TxtPackQty
        '
        Me.TxtPackQty.BackColor = System.Drawing.Color.White
        Me.TxtPackQty.Enabled = False
        Me.TxtPackQty.Location = New System.Drawing.Point(6, 22)
        Me.TxtPackQty.Name = "TxtPackQty"
        Me.TxtPackQty.ReadOnly = True
        Me.TxtPackQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPackQty.Size = New System.Drawing.Size(77, 20)
        Me.TxtPackQty.TabIndex = 60
        '
        'TxtPackSize
        '
        Me.TxtPackSize.BackColor = System.Drawing.Color.White
        Me.TxtPackSize.Enabled = False
        Me.TxtPackSize.Location = New System.Drawing.Point(194, 22)
        Me.TxtPackSize.Name = "TxtPackSize"
        Me.TxtPackSize.ReadOnly = True
        Me.TxtPackSize.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPackSize.Size = New System.Drawing.Size(77, 20)
        Me.TxtPackSize.TabIndex = 71
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(86, 27)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(12, 13)
        Me.Label27.TabIndex = 70
        Me.Label27.Text = "x"
        '
        'TxtRoundOffReturn
        '
        Me.TxtRoundOffReturn.BackColor = System.Drawing.Color.White
        Me.TxtRoundOffReturn.Enabled = False
        Me.TxtRoundOffReturn.Location = New System.Drawing.Point(520, 292)
        Me.TxtRoundOffReturn.Name = "TxtRoundOffReturn"
        Me.TxtRoundOffReturn.ReadOnly = True
        Me.TxtRoundOffReturn.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtRoundOffReturn.Size = New System.Drawing.Size(72, 20)
        Me.TxtRoundOffReturn.TabIndex = 63
        Me.TxtRoundOffReturn.TabStop = False
        '
        'TxtTaxReturn
        '
        Me.TxtTaxReturn.BackColor = System.Drawing.Color.White
        Me.TxtTaxReturn.Enabled = False
        Me.TxtTaxReturn.Location = New System.Drawing.Point(195, 292)
        Me.TxtTaxReturn.Name = "TxtTaxReturn"
        Me.TxtTaxReturn.ReadOnly = True
        Me.TxtTaxReturn.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTaxReturn.Size = New System.Drawing.Size(86, 20)
        Me.TxtTaxReturn.TabIndex = 64
        Me.TxtTaxReturn.TabStop = False
        '
        'TxtDiscountReturn
        '
        Me.TxtDiscountReturn.BackColor = System.Drawing.Color.White
        Me.TxtDiscountReturn.Enabled = False
        Me.TxtDiscountReturn.Location = New System.Drawing.Point(347, 293)
        Me.TxtDiscountReturn.Name = "TxtDiscountReturn"
        Me.TxtDiscountReturn.ReadOnly = True
        Me.TxtDiscountReturn.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDiscountReturn.Size = New System.Drawing.Size(105, 20)
        Me.TxtDiscountReturn.TabIndex = 65
        Me.TxtDiscountReturn.TabStop = False
        '
        'TxtTotalReturn
        '
        Me.TxtTotalReturn.BackColor = System.Drawing.Color.White
        Me.TxtTotalReturn.Enabled = False
        Me.TxtTotalReturn.Location = New System.Drawing.Point(47, 292)
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
        Me.Label20.Location = New System.Drawing.Point(10, 296)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(31, 13)
        Me.Label20.TabIndex = 69
        Me.Label20.Text = "Total"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(292, 295)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(49, 13)
        Me.Label21.TabIndex = 68
        Me.Label21.Text = "Discount"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(164, 296)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(25, 13)
        Me.Label22.TabIndex = 67
        Me.Label22.Text = "Tax"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(458, 296)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 13)
        Me.Label23.TabIndex = 62
        Me.Label23.Text = "Round-Off"
        '
        'TxtNetAmountReturn
        '
        Me.TxtNetAmountReturn.BackColor = System.Drawing.Color.White
        Me.TxtNetAmountReturn.Enabled = False
        Me.TxtNetAmountReturn.Location = New System.Drawing.Point(667, 292)
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
        Me.Label24.Location = New System.Drawing.Point(598, 295)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(63, 13)
        Me.Label24.TabIndex = 60
        Me.Label24.Text = "Net Amount"
        '
        'TxtPurchasePrice
        '
        Me.TxtPurchasePrice.BackColor = System.Drawing.Color.White
        Me.TxtPurchasePrice.Enabled = False
        Me.TxtPurchasePrice.Location = New System.Drawing.Point(75, 105)
        Me.TxtPurchasePrice.Name = "TxtPurchasePrice"
        Me.TxtPurchasePrice.ReadOnly = True
        Me.TxtPurchasePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPurchasePrice.Size = New System.Drawing.Size(72, 20)
        Me.TxtPurchasePrice.TabIndex = 10
        '
        'TxtTax
        '
        Me.TxtTax.Location = New System.Drawing.Point(188, 105)
        Me.TxtTax.Name = "TxtTax"
        Me.TxtTax.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTax.Size = New System.Drawing.Size(58, 20)
        Me.TxtTax.TabIndex = 11
        '
        'TxtDiscount
        '
        Me.TxtDiscount.Location = New System.Drawing.Point(358, 105)
        Me.TxtDiscount.Name = "TxtDiscount"
        Me.TxtDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDiscount.Size = New System.Drawing.Size(58, 20)
        Me.TxtDiscount.TabIndex = 12
        '
        'TxtTotal
        '
        Me.TxtTotal.BackColor = System.Drawing.Color.White
        Me.TxtTotal.Enabled = False
        Me.TxtTotal.Location = New System.Drawing.Point(517, 105)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.ReadOnly = True
        Me.TxtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTotal.Size = New System.Drawing.Size(77, 20)
        Me.TxtTotal.TabIndex = 13
        Me.TxtTotal.TabStop = False
        '
        'GrdItemsPurchaseReturn
        '
        Me.GrdItemsPurchaseReturn.AllowUserToAddRows = False
        Me.GrdItemsPurchaseReturn.AllowUserToDeleteRows = False
        Me.GrdItemsPurchaseReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdItemsPurchaseReturn.Location = New System.Drawing.Point(10, 133)
        Me.GrdItemsPurchaseReturn.Name = "GrdItemsPurchaseReturn"
        Me.GrdItemsPurchaseReturn.ReadOnly = True
        Me.GrdItemsPurchaseReturn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdItemsPurchaseReturn.Size = New System.Drawing.Size(797, 153)
        Me.GrdItemsPurchaseReturn.TabIndex = 48
        '
        'BtnRemove
        '
        Me.BtnRemove.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnRemove.Location = New System.Drawing.Point(724, 101)
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
        Me.BtnAdd.Location = New System.Drawing.Point(645, 101)
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
        Me.Label13.Location = New System.Drawing.Point(472, 108)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 44
        Me.Label13.Text = "Total"
        '
        'CmbDiscountType
        '
        Me.CmbDiscountType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbDiscountType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbDiscountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDiscountType.FormattingEnabled = True
        Me.CmbDiscountType.Location = New System.Drawing.Point(422, 105)
        Me.CmbDiscountType.Name = "CmbDiscountType"
        Me.CmbDiscountType.Size = New System.Drawing.Size(44, 21)
        Me.CmbDiscountType.Sorted = True
        Me.CmbDiscountType.TabIndex = 43
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(303, 108)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "Discount"
        '
        'CmbTaxType
        '
        Me.CmbTaxType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbTaxType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTaxType.FormattingEnabled = True
        Me.CmbTaxType.Location = New System.Drawing.Point(252, 105)
        Me.CmbTaxType.Name = "CmbTaxType"
        Me.CmbTaxType.Size = New System.Drawing.Size(44, 21)
        Me.CmbTaxType.Sorted = True
        Me.CmbTaxType.TabIndex = 40
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(153, 108)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(25, 13)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Tax"
        '
        'CmbItem
        '
        Me.CmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbItem.Enabled = False
        Me.CmbItem.FormattingEnabled = True
        Me.CmbItem.Location = New System.Drawing.Point(75, 19)
        Me.CmbItem.Name = "CmbItem"
        Me.CmbItem.Size = New System.Drawing.Size(233, 21)
        Me.CmbItem.Sorted = True
        Me.CmbItem.TabIndex = 33
        Me.CmbItem.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Item Name*"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(15, 107)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 13)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Pur. Price"
        '
        'FrmPurchaseReturn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(845, 681)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpButtons)
        Me.Controls.Add(Me.GrpItemReturn)
        Me.Controls.Add(Me.GrpPurchaseDetail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPurchaseReturn"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Purchase Return"
        Me.GrpPurchaseDetail.ResumeLayout(False)
        Me.GrpPurchaseDetail.PerformLayout()
        CType(Me.GrdItemsPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpButtons.ResumeLayout(False)
        Me.GrpButtons.PerformLayout()
        Me.GrpItemReturn.ResumeLayout(False)
        Me.GrpItemReturn.PerformLayout()
        Me.PnlQuantity.ResumeLayout(False)
        Me.PnlQuantity.PerformLayout()
        CType(Me.GrdItemsPurchaseReturn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpPurchaseDetail As System.Windows.Forms.GroupBox
    Friend WithEvents TxtRoundOffPurchase As System.Windows.Forms.TextBox
    Friend WithEvents TxtTaxTotalPurchase As System.Windows.Forms.TextBox
    Friend WithEvents TxtDiscountTotalPurchase As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotalAmountPurchase As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtNetAmountPurchase As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GrdItemsPurchase As System.Windows.Forms.DataGridView
    Friend WithEvents CmbVendor As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DtPkrPurchaseDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtPurchaseCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DtPkrReturnDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPurchaseReturnCode As System.Windows.Forms.TextBox
    Friend WithEvents GrpButtons As System.Windows.Forms.GroupBox
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents TxtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GrpItemReturn As System.Windows.Forms.GroupBox
    Friend WithEvents TxtRoundOffReturn As System.Windows.Forms.TextBox
    Friend WithEvents TxtTaxReturn As System.Windows.Forms.TextBox
    Friend WithEvents TxtDiscountReturn As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotalReturn As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TxtNetAmountReturn As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TxtPurchasePrice As System.Windows.Forms.TextBox
    Friend WithEvents TxtTax As System.Windows.Forms.TextBox
    Friend WithEvents TxtDiscount As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents GrdItemsPurchaseReturn As System.Windows.Forms.DataGridView
    Friend WithEvents BtnRemove As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CmbDiscountType As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbTaxType As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CmbItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PnlQuantity As System.Windows.Forms.Panel
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalQunatity As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents TxtReturnQuantity As System.Windows.Forms.TextBox
    Friend WithEvents TxtFreeQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TxtPackQty As System.Windows.Forms.TextBox
    Friend WithEvents TxtPackSize As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label

End Class
