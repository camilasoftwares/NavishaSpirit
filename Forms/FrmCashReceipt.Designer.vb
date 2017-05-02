<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCashReceipt
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
        Me.TxtVoucherNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbCashHead = New System.Windows.Forms.ComboBox
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.GrpCashHead = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.DtPkrReceiptDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.GrpButtons = New System.Windows.Forms.GroupBox
        Me.BtnRemove = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.GrdReceipts = New System.Windows.Forms.DataGridView
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.TxtRemark = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtAmount = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GrpReceiptDetails = New System.Windows.Forms.GroupBox
        Me.TxtInvoiceNo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbLedger = New System.Windows.Forms.ComboBox
        Me.BtnSearch = New System.Windows.Forms.Button
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.GrpCashHead.SuspendLayout()
        Me.GrpButtons.SuspendLayout()
        CType(Me.GrdReceipts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpReceiptDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtVoucherNo
        '
        Me.TxtVoucherNo.BackColor = System.Drawing.Color.White
        Me.TxtVoucherNo.Enabled = False
        Me.TxtVoucherNo.Location = New System.Drawing.Point(79, 19)
        Me.TxtVoucherNo.Name = "TxtVoucherNo"
        Me.TxtVoucherNo.ReadOnly = True
        Me.TxtVoucherNo.Size = New System.Drawing.Size(98, 20)
        Me.TxtVoucherNo.TabIndex = 70
        Me.TxtVoucherNo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Voucher No."
        '
        'CmbCashHead
        '
        Me.CmbCashHead.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbCashHead.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbCashHead.FormattingEnabled = True
        Me.CmbCashHead.Location = New System.Drawing.Point(253, 19)
        Me.CmbCashHead.Name = "CmbCashHead"
        Me.CmbCashHead.Size = New System.Drawing.Size(235, 21)
        Me.CmbCashHead.Sorted = True
        Me.CmbCashHead.TabIndex = 41
        '
        'BtnCancel
        '
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnCancel.Location = New System.Drawing.Point(271, 19)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(73, 26)
        Me.BtnCancel.TabIndex = 67
        Me.BtnCancel.Text = "Cance&l"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'GrpCashHead
        '
        Me.GrpCashHead.Controls.Add(Me.TxtVoucherNo)
        Me.GrpCashHead.Controls.Add(Me.Label1)
        Me.GrpCashHead.Controls.Add(Me.CmbCashHead)
        Me.GrpCashHead.Controls.Add(Me.Label6)
        Me.GrpCashHead.Controls.Add(Me.DtPkrReceiptDate)
        Me.GrpCashHead.Controls.Add(Me.Label2)
        Me.GrpCashHead.Location = New System.Drawing.Point(12, 12)
        Me.GrpCashHead.Name = "GrpCashHead"
        Me.GrpCashHead.Size = New System.Drawing.Size(675, 51)
        Me.GrpCashHead.TabIndex = 6
        Me.GrpCashHead.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(183, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Cash Head*"
        '
        'DtPkrReceiptDate
        '
        Me.DtPkrReceiptDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrReceiptDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPkrReceiptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrReceiptDate.Location = New System.Drawing.Point(574, 19)
        Me.DtPkrReceiptDate.Name = "DtPkrReceiptDate"
        Me.DtPkrReceiptDate.Size = New System.Drawing.Size(91, 20)
        Me.DtPkrReceiptDate.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(494, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Receipt Date"
        '
        'BtnUpdate
        '
        Me.BtnUpdate.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnUpdate.Location = New System.Drawing.Point(192, 19)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(73, 26)
        Me.BtnUpdate.TabIndex = 66
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnClose.Location = New System.Drawing.Point(587, 19)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(73, 26)
        Me.BtnClose.TabIndex = 65
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'GrpButtons
        '
        Me.GrpButtons.Controls.Add(Me.BtnPrint)
        Me.GrpButtons.Controls.Add(Me.BtnSearch)
        Me.GrpButtons.Controls.Add(Me.BtnCancel)
        Me.GrpButtons.Controls.Add(Me.BtnUpdate)
        Me.GrpButtons.Controls.Add(Me.BtnClose)
        Me.GrpButtons.Controls.Add(Me.BtnRemove)
        Me.GrpButtons.Location = New System.Drawing.Point(12, 539)
        Me.GrpButtons.Name = "GrpButtons"
        Me.GrpButtons.Size = New System.Drawing.Size(675, 54)
        Me.GrpButtons.TabIndex = 7
        Me.GrpButtons.TabStop = False
        '
        'BtnRemove
        '
        Me.BtnRemove.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnRemove.Location = New System.Drawing.Point(350, 19)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(73, 26)
        Me.BtnRemove.TabIndex = 64
        Me.BtnRemove.Text = "&Remove"
        Me.BtnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Ledger Name*"
        '
        'GrdReceipts
        '
        Me.GrdReceipts.AllowUserToAddRows = False
        Me.GrdReceipts.AllowUserToDeleteRows = False
        Me.GrdReceipts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdReceipts.Location = New System.Drawing.Point(6, 77)
        Me.GrdReceipts.Name = "GrdReceipts"
        Me.GrdReceipts.ReadOnly = True
        Me.GrdReceipts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdReceipts.Size = New System.Drawing.Size(663, 377)
        Me.GrdReceipts.TabIndex = 64
        '
        'BtnAdd
        '
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnAdd.Location = New System.Drawing.Point(585, 45)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(79, 26)
        Me.BtnAdd.TabIndex = 62
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'TxtRemark
        '
        Me.TxtRemark.BackColor = System.Drawing.Color.White
        Me.TxtRemark.Location = New System.Drawing.Point(264, 46)
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(315, 20)
        Me.TxtRemark.TabIndex = 45
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(209, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Remarks"
        '
        'TxtAmount
        '
        Me.TxtAmount.BackColor = System.Drawing.Color.White
        Me.TxtAmount.Location = New System.Drawing.Point(561, 19)
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtAmount.Size = New System.Drawing.Size(103, 20)
        Me.TxtAmount.TabIndex = 41
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(468, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Receipt Amount*"
        '
        'GrpReceiptDetails
        '
        Me.GrpReceiptDetails.Controls.Add(Me.TxtInvoiceNo)
        Me.GrpReceiptDetails.Controls.Add(Me.Label3)
        Me.GrpReceiptDetails.Controls.Add(Me.GrdReceipts)
        Me.GrpReceiptDetails.Controls.Add(Me.BtnAdd)
        Me.GrpReceiptDetails.Controls.Add(Me.TxtRemark)
        Me.GrpReceiptDetails.Controls.Add(Me.Label8)
        Me.GrpReceiptDetails.Controls.Add(Me.TxtAmount)
        Me.GrpReceiptDetails.Controls.Add(Me.Label5)
        Me.GrpReceiptDetails.Controls.Add(Me.CmbLedger)
        Me.GrpReceiptDetails.Controls.Add(Me.Label7)
        Me.GrpReceiptDetails.Location = New System.Drawing.Point(12, 69)
        Me.GrpReceiptDetails.Name = "GrpReceiptDetails"
        Me.GrpReceiptDetails.Size = New System.Drawing.Size(675, 464)
        Me.GrpReceiptDetails.TabIndex = 5
        Me.GrpReceiptDetails.TabStop = False
        Me.GrpReceiptDetails.Text = "Current Receipt Entries"
        '
        'TxtInvoiceNo
        '
        Me.TxtInvoiceNo.BackColor = System.Drawing.Color.White
        Me.TxtInvoiceNo.Location = New System.Drawing.Point(100, 46)
        Me.TxtInvoiceNo.Name = "TxtInvoiceNo"
        Me.TxtInvoiceNo.Size = New System.Drawing.Size(103, 20)
        Me.TxtInvoiceNo.TabIndex = 66
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "Invoice No."
        '
        'CmbLedger
        '
        Me.CmbLedger.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbLedger.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbLedger.FormattingEnabled = True
        Me.CmbLedger.Location = New System.Drawing.Point(100, 19)
        Me.CmbLedger.Name = "CmbLedger"
        Me.CmbLedger.Size = New System.Drawing.Size(362, 21)
        Me.CmbLedger.Sorted = True
        Me.CmbLedger.TabIndex = 35
        '
        'BtnSearch
        '
        Me.BtnSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnSearch.Location = New System.Drawing.Point(508, 19)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(73, 26)
        Me.BtnSearch.TabIndex = 68
        Me.BtnSearch.Text = "&Search"
        Me.BtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnPrint.Location = New System.Drawing.Point(429, 19)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(73, 26)
        Me.BtnPrint.TabIndex = 69
        Me.BtnPrint.Text = "&Print Slip"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'FrmCashReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(699, 602)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpCashHead)
        Me.Controls.Add(Me.GrpButtons)
        Me.Controls.Add(Me.GrpReceiptDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCashReceipt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cash Receipt"
        Me.GrpCashHead.ResumeLayout(False)
        Me.GrpCashHead.PerformLayout()
        Me.GrpButtons.ResumeLayout(False)
        CType(Me.GrdReceipts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpReceiptDetails.ResumeLayout(False)
        Me.GrpReceiptDetails.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtVoucherNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbCashHead As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents GrpCashHead As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DtPkrReceiptDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents GrpButtons As System.Windows.Forms.GroupBox
    Friend WithEvents BtnRemove As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GrdReceipts As System.Windows.Forms.DataGridView
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents TxtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GrpReceiptDetails As System.Windows.Forms.GroupBox
    Friend WithEvents CmbLedger As System.Windows.Forms.ComboBox
    Friend WithEvents TxtInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
End Class
