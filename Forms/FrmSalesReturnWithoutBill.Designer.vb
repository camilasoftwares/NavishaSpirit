<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSalesReturnWithoutBill
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
        Me.CmbBatch = New System.Windows.Forms.ComboBox
        Me.CmbItem = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtQuantity = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.GrpButtons = New System.Windows.Forms.GroupBox
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.BtnNew = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.TxtRemark = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.BtnSearch = New System.Windows.Forms.Button
        Me.GrpSaleDetail.SuspendLayout()
        Me.GrpItemReturn.SuspendLayout()
        CType(Me.GrdItemsSaleReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpSaleDetail
        '
        Me.GrpSaleDetail.Controls.Add(Me.DtPkrReturnDate)
        Me.GrpSaleDetail.Controls.Add(Me.Label2)
        Me.GrpSaleDetail.Controls.Add(Me.Label1)
        Me.GrpSaleDetail.Controls.Add(Me.TxtSalesReturnCode)
        Me.GrpSaleDetail.Location = New System.Drawing.Point(12, 12)
        Me.GrpSaleDetail.Name = "GrpSaleDetail"
        Me.GrpSaleDetail.Size = New System.Drawing.Size(826, 53)
        Me.GrpSaleDetail.TabIndex = 0
        Me.GrpSaleDetail.TabStop = False
        Me.GrpSaleDetail.Text = "Sale Detail"
        '
        'DtPkrReturnDate
        '
        Me.DtPkrReturnDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrReturnDate.Location = New System.Drawing.Point(257, 19)
        Me.DtPkrReturnDate.Name = "DtPkrReturnDate"
        Me.DtPkrReturnDate.Size = New System.Drawing.Size(92, 20)
        Me.DtPkrReturnDate.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(186, 23)
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
        Me.TxtSalesReturnCode.Size = New System.Drawing.Size(94, 20)
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
        Me.GrpItemReturn.Controls.Add(Me.CmbBatch)
        Me.GrpItemReturn.Controls.Add(Me.CmbItem)
        Me.GrpItemReturn.Controls.Add(Me.Label8)
        Me.GrpItemReturn.Controls.Add(Me.Label10)
        Me.GrpItemReturn.Controls.Add(Me.Label16)
        Me.GrpItemReturn.Controls.Add(Me.TxtQuantity)
        Me.GrpItemReturn.Controls.Add(Me.Label17)
        Me.GrpItemReturn.Location = New System.Drawing.Point(12, 71)
        Me.GrpItemReturn.Name = "GrpItemReturn"
        Me.GrpItemReturn.Size = New System.Drawing.Size(826, 321)
        Me.GrpItemReturn.TabIndex = 10
        Me.GrpItemReturn.TabStop = False
        '
        'TxtDiscountOnBillReturn
        '
        Me.TxtDiscountOnBillReturn.BackColor = System.Drawing.Color.White
        Me.TxtDiscountOnBillReturn.Location = New System.Drawing.Point(305, 295)
        Me.TxtDiscountOnBillReturn.Name = "TxtDiscountOnBillReturn"
        Me.TxtDiscountOnBillReturn.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDiscountOnBillReturn.Size = New System.Drawing.Size(105, 20)
        Me.TxtDiscountOnBillReturn.TabIndex = 72
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(186, 298)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(117, 13)
        Me.Label27.TabIndex = 73
        Me.Label27.Text = "Discount On Bill Return"
        '
        'TxtRoundOffReturn
        '
        Me.TxtRoundOffReturn.BackColor = System.Drawing.Color.White
        Me.TxtRoundOffReturn.Enabled = False
        Me.TxtRoundOffReturn.Location = New System.Drawing.Point(527, 294)
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
        Me.TxtTotalReturn.Location = New System.Drawing.Point(47, 294)
        Me.TxtTotalReturn.Name = "TxtTotalReturn"
        Me.TxtTotalReturn.ReadOnly = True
        Me.TxtTotalReturn.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTotalReturn.Size = New System.Drawing.Size(118, 20)
        Me.TxtTotalReturn.TabIndex = 66
        Me.TxtTotalReturn.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(10, 298)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(31, 13)
        Me.Label20.TabIndex = 69
        Me.Label20.Text = "Total"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(465, 298)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 13)
        Me.Label23.TabIndex = 62
        Me.Label23.Text = "Round-Off"
        '
        'TxtNetAmountReturn
        '
        Me.TxtNetAmountReturn.BackColor = System.Drawing.Color.White
        Me.TxtNetAmountReturn.Enabled = False
        Me.TxtNetAmountReturn.Location = New System.Drawing.Point(676, 294)
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
        Me.Label24.Location = New System.Drawing.Point(607, 297)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(63, 13)
        Me.Label24.TabIndex = 60
        Me.Label24.Text = "Net Amount"
        '
        'TxtSalePrice
        '
        Me.TxtSalePrice.BackColor = System.Drawing.Color.White
        Me.TxtSalePrice.Enabled = False
        Me.TxtSalePrice.Location = New System.Drawing.Point(504, 33)
        Me.TxtSalePrice.Name = "TxtSalePrice"
        Me.TxtSalePrice.ReadOnly = True
        Me.TxtSalePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtSalePrice.Size = New System.Drawing.Size(72, 20)
        Me.TxtSalePrice.TabIndex = 10
        '
        'TxtTotal
        '
        Me.TxtTotal.BackColor = System.Drawing.Color.White
        Me.TxtTotal.Enabled = False
        Me.TxtTotal.Location = New System.Drawing.Point(582, 32)
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
        Me.GrdItemsSaleReturn.Size = New System.Drawing.Size(807, 228)
        Me.GrdItemsSaleReturn.TabIndex = 48
        '
        'BtnRemove
        '
        Me.BtnRemove.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnRemove.Location = New System.Drawing.Point(744, 29)
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
        Me.BtnAdd.Location = New System.Drawing.Point(665, 29)
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
        Me.Label13.Location = New System.Drawing.Point(579, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 44
        Me.Label13.Text = "Total"
        '
        'CmbBatch
        '
        Me.CmbBatch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbBatch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbBatch.FormattingEnabled = True
        Me.CmbBatch.Location = New System.Drawing.Point(295, 32)
        Me.CmbBatch.Name = "CmbBatch"
        Me.CmbBatch.Size = New System.Drawing.Size(135, 21)
        Me.CmbBatch.Sorted = True
        Me.CmbBatch.TabIndex = 34
        '
        'CmbItem
        '
        Me.CmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbItem.FormattingEnabled = True
        Me.CmbItem.Location = New System.Drawing.Point(10, 32)
        Me.CmbItem.Name = "CmbItem"
        Me.CmbItem.Size = New System.Drawing.Size(279, 21)
        Me.CmbItem.Sorted = True
        Me.CmbItem.TabIndex = 33
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(292, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Batch*"
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
        Me.Label16.Location = New System.Drawing.Point(501, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 13)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Sale Price"
        '
        'TxtQuantity
        '
        Me.TxtQuantity.Location = New System.Drawing.Point(436, 33)
        Me.TxtQuantity.Name = "TxtQuantity"
        Me.TxtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtQuantity.Size = New System.Drawing.Size(62, 20)
        Me.TxtQuantity.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(433, 16)
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
        Me.GrpButtons.Location = New System.Drawing.Point(12, 398)
        Me.GrpButtons.Name = "GrpButtons"
        Me.GrpButtons.Size = New System.Drawing.Size(826, 51)
        Me.GrpButtons.TabIndex = 12
        Me.GrpButtons.TabStop = False
        '
        'BtnPrint
        '
        Me.BtnPrint.Location = New System.Drawing.Point(587, 15)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(72, 26)
        Me.BtnPrint.TabIndex = 63
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'BtnNew
        '
        Me.BtnNew.Location = New System.Drawing.Point(431, 16)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(72, 26)
        Me.BtnNew.TabIndex = 62
        Me.BtnNew.Text = "&New"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(745, 16)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 61
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(509, 16)
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
        Me.TxtRemark.Size = New System.Drawing.Size(288, 20)
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
        'BtnSearch
        '
        Me.BtnSearch.Location = New System.Drawing.Point(666, 16)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(72, 26)
        Me.BtnSearch.TabIndex = 64
        Me.BtnSearch.Text = "Searc&h"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'FrmSalesReturnWithoutBill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(852, 462)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpButtons)
        Me.Controls.Add(Me.GrpItemReturn)
        Me.Controls.Add(Me.GrpSaleDetail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSalesReturnWithoutBill"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Return"
        Me.GrpSaleDetail.ResumeLayout(False)
        Me.GrpSaleDetail.PerformLayout()
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
    Friend WithEvents GrpItemReturn As System.Windows.Forms.GroupBox
    Friend WithEvents TxtSalePrice As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents GrdItemsSaleReturn As System.Windows.Forms.DataGridView
    Friend WithEvents BtnRemove As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CmbBatch As System.Windows.Forms.ComboBox
    Friend WithEvents CmbItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
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
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents TxtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TxtDiscountOnBillReturn As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
End Class
