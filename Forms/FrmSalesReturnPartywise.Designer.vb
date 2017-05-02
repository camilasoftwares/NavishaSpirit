<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSalesReturnPartywise
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
        Me.PnlCustomer = New System.Windows.Forms.Panel
        Me.BtnSearchInvoice = New System.Windows.Forms.Button
        Me.CmbCustomer = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.PnlReturnHead = New System.Windows.Forms.Panel
        Me.DtPkrReturnDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtSalesReturnCode = New System.Windows.Forms.TextBox
        Me.PnlInvoiceDetail = New System.Windows.Forms.Panel
        Me.GrdInvoiceDetail = New System.Windows.Forms.DataGridView
        Me.PnlItemDetail = New System.Windows.Forms.Panel
        Me.BtnRemove = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.ChkNonSaleable = New System.Windows.Forms.CheckBox
        Me.TxtSalePrice = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtQuantity = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.CmbItem = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CmbInvoice = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.PnlReturnItems = New System.Windows.Forms.Panel
        Me.Label8 = New System.Windows.Forms.Label
        Me.GrdItemsReturn = New System.Windows.Forms.DataGridView
        Me.PnlTotal = New System.Windows.Forms.Panel
        Me.BtnSearch = New System.Windows.Forms.Button
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.BtnNew = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.TxtRemark = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtDiscountOnBillReturn = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.TxtRoundOffReturn = New System.Windows.Forms.TextBox
        Me.TxtTotalReturn = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.TxtNetAmountReturn = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.PnlCustomer.SuspendLayout()
        Me.PnlReturnHead.SuspendLayout()
        Me.PnlInvoiceDetail.SuspendLayout()
        CType(Me.GrdInvoiceDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlItemDetail.SuspendLayout()
        Me.PnlReturnItems.SuspendLayout()
        CType(Me.GrdItemsReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlTotal.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlCustomer
        '
        Me.PnlCustomer.Controls.Add(Me.BtnSearchInvoice)
        Me.PnlCustomer.Controls.Add(Me.CmbCustomer)
        Me.PnlCustomer.Controls.Add(Me.Label6)
        Me.PnlCustomer.Location = New System.Drawing.Point(12, 43)
        Me.PnlCustomer.Name = "PnlCustomer"
        Me.PnlCustomer.Size = New System.Drawing.Size(758, 45)
        Me.PnlCustomer.TabIndex = 1
        '
        'BtnSearchInvoice
        '
        Me.BtnSearchInvoice.Location = New System.Drawing.Point(626, 8)
        Me.BtnSearchInvoice.Name = "BtnSearchInvoice"
        Me.BtnSearchInvoice.Size = New System.Drawing.Size(108, 29)
        Me.BtnSearchInvoice.TabIndex = 4
        Me.BtnSearchInvoice.Text = "Search Invoices"
        Me.BtnSearchInvoice.UseVisualStyleBackColor = True
        '
        'CmbCustomer
        '
        Me.CmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbCustomer.BackColor = System.Drawing.Color.White
        Me.CmbCustomer.FormattingEnabled = True
        Me.CmbCustomer.Location = New System.Drawing.Point(97, 12)
        Me.CmbCustomer.Name = "CmbCustomer"
        Me.CmbCustomer.Size = New System.Drawing.Size(275, 21)
        Me.CmbCustomer.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Customer Name*"
        '
        'PnlReturnHead
        '
        Me.PnlReturnHead.Controls.Add(Me.DtPkrReturnDate)
        Me.PnlReturnHead.Controls.Add(Me.Label2)
        Me.PnlReturnHead.Controls.Add(Me.Label3)
        Me.PnlReturnHead.Controls.Add(Me.TxtSalesReturnCode)
        Me.PnlReturnHead.Location = New System.Drawing.Point(12, 12)
        Me.PnlReturnHead.Name = "PnlReturnHead"
        Me.PnlReturnHead.Size = New System.Drawing.Size(758, 31)
        Me.PnlReturnHead.TabIndex = 0
        '
        'DtPkrReturnDate
        '
        Me.DtPkrReturnDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrReturnDate.Location = New System.Drawing.Point(282, 5)
        Me.DtPkrReturnDate.Name = "DtPkrReturnDate"
        Me.DtPkrReturnDate.Size = New System.Drawing.Size(92, 20)
        Me.DtPkrReturnDate.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(211, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Return Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Return Code"
        '
        'TxtSalesReturnCode
        '
        Me.TxtSalesReturnCode.BackColor = System.Drawing.Color.White
        Me.TxtSalesReturnCode.Enabled = False
        Me.TxtSalesReturnCode.Location = New System.Drawing.Point(76, 5)
        Me.TxtSalesReturnCode.Name = "TxtSalesReturnCode"
        Me.TxtSalesReturnCode.ReadOnly = True
        Me.TxtSalesReturnCode.Size = New System.Drawing.Size(129, 20)
        Me.TxtSalesReturnCode.TabIndex = 1
        '
        'PnlInvoiceDetail
        '
        Me.PnlInvoiceDetail.Controls.Add(Me.GrdInvoiceDetail)
        Me.PnlInvoiceDetail.Location = New System.Drawing.Point(12, 86)
        Me.PnlInvoiceDetail.Name = "PnlInvoiceDetail"
        Me.PnlInvoiceDetail.Size = New System.Drawing.Size(755, 217)
        Me.PnlInvoiceDetail.TabIndex = 2
        '
        'GrdInvoiceDetail
        '
        Me.GrdInvoiceDetail.AllowUserToAddRows = False
        Me.GrdInvoiceDetail.AllowUserToDeleteRows = False
        Me.GrdInvoiceDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdInvoiceDetail.Location = New System.Drawing.Point(6, 3)
        Me.GrdInvoiceDetail.Name = "GrdInvoiceDetail"
        Me.GrdInvoiceDetail.ReadOnly = True
        Me.GrdInvoiceDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdInvoiceDetail.Size = New System.Drawing.Size(746, 204)
        Me.GrdInvoiceDetail.TabIndex = 0
        '
        'PnlItemDetail
        '
        Me.PnlItemDetail.Controls.Add(Me.BtnRemove)
        Me.PnlItemDetail.Controls.Add(Me.BtnAdd)
        Me.PnlItemDetail.Controls.Add(Me.ChkNonSaleable)
        Me.PnlItemDetail.Controls.Add(Me.TxtSalePrice)
        Me.PnlItemDetail.Controls.Add(Me.Label16)
        Me.PnlItemDetail.Controls.Add(Me.TxtQuantity)
        Me.PnlItemDetail.Controls.Add(Me.Label17)
        Me.PnlItemDetail.Controls.Add(Me.CmbItem)
        Me.PnlItemDetail.Controls.Add(Me.Label5)
        Me.PnlItemDetail.Controls.Add(Me.CmbInvoice)
        Me.PnlItemDetail.Controls.Add(Me.Label4)
        Me.PnlItemDetail.Location = New System.Drawing.Point(12, 299)
        Me.PnlItemDetail.Name = "PnlItemDetail"
        Me.PnlItemDetail.Size = New System.Drawing.Size(755, 58)
        Me.PnlItemDetail.TabIndex = 3
        '
        'BtnRemove
        '
        Me.BtnRemove.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnRemove.Location = New System.Drawing.Point(679, 27)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(73, 26)
        Me.BtnRemove.TabIndex = 12
        Me.BtnRemove.Text = "&Remove"
        Me.BtnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnAdd.Location = New System.Drawing.Point(600, 27)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(73, 26)
        Me.BtnAdd.TabIndex = 11
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'ChkNonSaleable
        '
        Me.ChkNonSaleable.AutoSize = True
        Me.ChkNonSaleable.Location = New System.Drawing.Point(293, 29)
        Me.ChkNonSaleable.Name = "ChkNonSaleable"
        Me.ChkNonSaleable.Size = New System.Drawing.Size(90, 17)
        Me.ChkNonSaleable.TabIndex = 10
        Me.ChkNonSaleable.Text = "Non Saleable"
        Me.ChkNonSaleable.UseVisualStyleBackColor = True
        '
        'TxtSalePrice
        '
        Me.TxtSalePrice.BackColor = System.Drawing.Color.White
        Me.TxtSalePrice.Enabled = False
        Me.TxtSalePrice.Location = New System.Drawing.Point(200, 27)
        Me.TxtSalePrice.Name = "TxtSalePrice"
        Me.TxtSalePrice.ReadOnly = True
        Me.TxtSalePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtSalePrice.Size = New System.Drawing.Size(72, 20)
        Me.TxtSalePrice.TabIndex = 9
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(139, 30)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 13)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Sale Price"
        '
        'TxtQuantity
        '
        Me.TxtQuantity.Location = New System.Drawing.Point(57, 27)
        Me.TxtQuantity.Name = "TxtQuantity"
        Me.TxtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtQuantity.Size = New System.Drawing.Size(62, 20)
        Me.TxtQuantity.TabIndex = 7
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(5, 30)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Quantity"
        '
        'CmbItem
        '
        Me.CmbItem.BackColor = System.Drawing.Color.White
        Me.CmbItem.Enabled = False
        Me.CmbItem.FormattingEnabled = True
        Me.CmbItem.Location = New System.Drawing.Point(244, 0)
        Me.CmbItem.Name = "CmbItem"
        Me.CmbItem.Size = New System.Drawing.Size(242, 21)
        Me.CmbItem.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(211, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Item"
        '
        'CmbInvoice
        '
        Me.CmbInvoice.BackColor = System.Drawing.Color.White
        Me.CmbInvoice.Enabled = False
        Me.CmbInvoice.FormattingEnabled = True
        Me.CmbInvoice.Location = New System.Drawing.Point(57, 0)
        Me.CmbInvoice.Name = "CmbInvoice"
        Me.CmbInvoice.Size = New System.Drawing.Size(144, 21)
        Me.CmbInvoice.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Invoice"
        '
        'PnlReturnItems
        '
        Me.PnlReturnItems.Controls.Add(Me.Label8)
        Me.PnlReturnItems.Controls.Add(Me.GrdItemsReturn)
        Me.PnlReturnItems.Location = New System.Drawing.Point(12, 363)
        Me.PnlReturnItems.Name = "PnlReturnItems"
        Me.PnlReturnItems.Size = New System.Drawing.Size(755, 245)
        Me.PnlReturnItems.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(42, 225)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(296, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "* Total calculation includes discount percent and tax percent."
        '
        'GrdItemsReturn
        '
        Me.GrdItemsReturn.AllowUserToAddRows = False
        Me.GrdItemsReturn.AllowUserToDeleteRows = False
        Me.GrdItemsReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdItemsReturn.Location = New System.Drawing.Point(6, 3)
        Me.GrdItemsReturn.Name = "GrdItemsReturn"
        Me.GrdItemsReturn.ReadOnly = True
        Me.GrdItemsReturn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdItemsReturn.Size = New System.Drawing.Size(746, 219)
        Me.GrdItemsReturn.TabIndex = 0
        '
        'PnlTotal
        '
        Me.PnlTotal.Controls.Add(Me.BtnSearch)
        Me.PnlTotal.Controls.Add(Me.BtnPrint)
        Me.PnlTotal.Controls.Add(Me.BtnNew)
        Me.PnlTotal.Controls.Add(Me.BtnClose)
        Me.PnlTotal.Controls.Add(Me.BtnSave)
        Me.PnlTotal.Controls.Add(Me.TxtRemark)
        Me.PnlTotal.Controls.Add(Me.Label25)
        Me.PnlTotal.Controls.Add(Me.TxtDiscountOnBillReturn)
        Me.PnlTotal.Controls.Add(Me.Label27)
        Me.PnlTotal.Controls.Add(Me.TxtRoundOffReturn)
        Me.PnlTotal.Controls.Add(Me.TxtTotalReturn)
        Me.PnlTotal.Controls.Add(Me.Label20)
        Me.PnlTotal.Controls.Add(Me.Label23)
        Me.PnlTotal.Controls.Add(Me.TxtNetAmountReturn)
        Me.PnlTotal.Controls.Add(Me.Label24)
        Me.PnlTotal.Location = New System.Drawing.Point(12, 614)
        Me.PnlTotal.Name = "PnlTotal"
        Me.PnlTotal.Size = New System.Drawing.Size(755, 67)
        Me.PnlTotal.TabIndex = 5
        '
        'BtnSearch
        '
        Me.BtnSearch.Location = New System.Drawing.Point(597, 32)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(72, 26)
        Me.BtnSearch.TabIndex = 13
        Me.BtnSearch.Text = "Searc&h"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.Location = New System.Drawing.Point(518, 32)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(72, 26)
        Me.BtnPrint.TabIndex = 12
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'BtnNew
        '
        Me.BtnNew.Location = New System.Drawing.Point(362, 32)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(72, 26)
        Me.BtnNew.TabIndex = 10
        Me.BtnNew.Text = "&New"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(676, 32)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 14
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(440, 32)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(72, 26)
        Me.BtnSave.TabIndex = 11
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'TxtRemark
        '
        Me.TxtRemark.Location = New System.Drawing.Point(63, 35)
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(285, 20)
        Me.TxtRemark.TabIndex = 9
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(8, 37)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(49, 13)
        Me.Label25.TabIndex = 8
        Me.Label25.Text = "Remarks"
        '
        'TxtDiscountOnBillReturn
        '
        Me.TxtDiscountOnBillReturn.BackColor = System.Drawing.Color.White
        Me.TxtDiscountOnBillReturn.Location = New System.Drawing.Point(308, 3)
        Me.TxtDiscountOnBillReturn.Name = "TxtDiscountOnBillReturn"
        Me.TxtDiscountOnBillReturn.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDiscountOnBillReturn.Size = New System.Drawing.Size(89, 20)
        Me.TxtDiscountOnBillReturn.TabIndex = 3
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(162, 6)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(140, 13)
        Me.Label27.TabIndex = 2
        Me.Label27.Text = "Discount On Bill Return"
        '
        'TxtRoundOffReturn
        '
        Me.TxtRoundOffReturn.BackColor = System.Drawing.Color.White
        Me.TxtRoundOffReturn.Enabled = False
        Me.TxtRoundOffReturn.Location = New System.Drawing.Point(465, 2)
        Me.TxtRoundOffReturn.Name = "TxtRoundOffReturn"
        Me.TxtRoundOffReturn.ReadOnly = True
        Me.TxtRoundOffReturn.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtRoundOffReturn.Size = New System.Drawing.Size(53, 20)
        Me.TxtRoundOffReturn.TabIndex = 5
        Me.TxtRoundOffReturn.TabStop = False
        '
        'TxtTotalReturn
        '
        Me.TxtTotalReturn.BackColor = System.Drawing.Color.White
        Me.TxtTotalReturn.Enabled = False
        Me.TxtTotalReturn.Location = New System.Drawing.Point(45, 2)
        Me.TxtTotalReturn.Name = "TxtTotalReturn"
        Me.TxtTotalReturn.ReadOnly = True
        Me.TxtTotalReturn.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTotalReturn.Size = New System.Drawing.Size(111, 20)
        Me.TxtTotalReturn.TabIndex = 1
        Me.TxtTotalReturn.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 6)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(31, 13)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Total"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(403, 6)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 13)
        Me.Label23.TabIndex = 4
        Me.Label23.Text = "Round-Off"
        '
        'TxtNetAmountReturn
        '
        Me.TxtNetAmountReturn.BackColor = System.Drawing.Color.White
        Me.TxtNetAmountReturn.Enabled = False
        Me.TxtNetAmountReturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetAmountReturn.Location = New System.Drawing.Point(603, 2)
        Me.TxtNetAmountReturn.Name = "TxtNetAmountReturn"
        Me.TxtNetAmountReturn.ReadOnly = True
        Me.TxtNetAmountReturn.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtNetAmountReturn.Size = New System.Drawing.Size(140, 20)
        Me.TxtNetAmountReturn.TabIndex = 7
        Me.TxtNetAmountReturn.TabStop = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(524, 5)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(73, 13)
        Me.Label24.TabIndex = 6
        Me.Label24.Text = "Net Amount"
        '
        'FrmSalesReturnPartywise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(779, 693)
        Me.ControlBox = False
        Me.Controls.Add(Me.PnlTotal)
        Me.Controls.Add(Me.PnlReturnItems)
        Me.Controls.Add(Me.PnlItemDetail)
        Me.Controls.Add(Me.PnlInvoiceDetail)
        Me.Controls.Add(Me.PnlReturnHead)
        Me.Controls.Add(Me.PnlCustomer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSalesReturnPartywise"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sales Return"
        Me.PnlCustomer.ResumeLayout(False)
        Me.PnlCustomer.PerformLayout()
        Me.PnlReturnHead.ResumeLayout(False)
        Me.PnlReturnHead.PerformLayout()
        Me.PnlInvoiceDetail.ResumeLayout(False)
        CType(Me.GrdInvoiceDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlItemDetail.ResumeLayout(False)
        Me.PnlItemDetail.PerformLayout()
        Me.PnlReturnItems.ResumeLayout(False)
        Me.PnlReturnItems.PerformLayout()
        CType(Me.GrdItemsReturn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlTotal.ResumeLayout(False)
        Me.PnlTotal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlCustomer As System.Windows.Forms.Panel
    Friend WithEvents CmbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnSearchInvoice As System.Windows.Forms.Button
    Friend WithEvents PnlReturnHead As System.Windows.Forms.Panel
    Friend WithEvents DtPkrReturnDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtSalesReturnCode As System.Windows.Forms.TextBox
    Friend WithEvents PnlInvoiceDetail As System.Windows.Forms.Panel
    Friend WithEvents GrdInvoiceDetail As System.Windows.Forms.DataGridView
    Friend WithEvents PnlItemDetail As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbInvoice As System.Windows.Forms.ComboBox
    Friend WithEvents ChkNonSaleable As System.Windows.Forms.CheckBox
    Friend WithEvents TxtSalePrice As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents BtnRemove As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents PnlReturnItems As System.Windows.Forms.Panel
    Friend WithEvents GrdItemsReturn As System.Windows.Forms.DataGridView
    Friend WithEvents PnlTotal As System.Windows.Forms.Panel
    Friend WithEvents TxtDiscountOnBillReturn As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TxtRoundOffReturn As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotalReturn As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TxtNetAmountReturn As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents TxtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
