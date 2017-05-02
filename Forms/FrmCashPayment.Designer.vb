<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCashPayment
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
        Me.GrpPaymentDetails = New System.Windows.Forms.GroupBox
        Me.GrdPayments = New System.Windows.Forms.DataGridView
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.TxtRemark = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtAmount = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtInvoiceAmount = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmbBill = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbLedger = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GrpCashHead = New System.Windows.Forms.GroupBox
        Me.TxtVoucherNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbCashHead = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.DtPkrPaymentDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.GrpButtons = New System.Windows.Forms.GroupBox
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnRemove = New System.Windows.Forms.Button
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.BtnSearch = New System.Windows.Forms.Button
        Me.GrpPaymentDetails.SuspendLayout()
        CType(Me.GrdPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCashHead.SuspendLayout()
        Me.GrpButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpPaymentDetails
        '
        Me.GrpPaymentDetails.Controls.Add(Me.GrdPayments)
        Me.GrpPaymentDetails.Controls.Add(Me.BtnAdd)
        Me.GrpPaymentDetails.Controls.Add(Me.TxtRemark)
        Me.GrpPaymentDetails.Controls.Add(Me.Label8)
        Me.GrpPaymentDetails.Controls.Add(Me.TxtAmount)
        Me.GrpPaymentDetails.Controls.Add(Me.Label5)
        Me.GrpPaymentDetails.Controls.Add(Me.TxtInvoiceAmount)
        Me.GrpPaymentDetails.Controls.Add(Me.Label4)
        Me.GrpPaymentDetails.Controls.Add(Me.CmbBill)
        Me.GrpPaymentDetails.Controls.Add(Me.Label3)
        Me.GrpPaymentDetails.Controls.Add(Me.CmbLedger)
        Me.GrpPaymentDetails.Controls.Add(Me.Label7)
        Me.GrpPaymentDetails.Location = New System.Drawing.Point(12, 69)
        Me.GrpPaymentDetails.Name = "GrpPaymentDetails"
        Me.GrpPaymentDetails.Size = New System.Drawing.Size(675, 487)
        Me.GrpPaymentDetails.TabIndex = 2
        Me.GrpPaymentDetails.TabStop = False
        Me.GrpPaymentDetails.Text = "Current Payment Entries"
        '
        'GrdPayments
        '
        Me.GrdPayments.AllowUserToAddRows = False
        Me.GrdPayments.AllowUserToDeleteRows = False
        Me.GrdPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdPayments.Location = New System.Drawing.Point(6, 104)
        Me.GrdPayments.Name = "GrdPayments"
        Me.GrdPayments.ReadOnly = True
        Me.GrdPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdPayments.Size = New System.Drawing.Size(663, 377)
        Me.GrdPayments.TabIndex = 64
        '
        'BtnAdd
        '
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnAdd.Location = New System.Drawing.Point(585, 72)
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
        Me.TxtRemark.Location = New System.Drawing.Point(100, 73)
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(479, 20)
        Me.TxtRemark.TabIndex = 45
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 76)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Remarks"
        '
        'TxtAmount
        '
        Me.TxtAmount.BackColor = System.Drawing.Color.White
        Me.TxtAmount.Location = New System.Drawing.Point(561, 46)
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtAmount.Size = New System.Drawing.Size(103, 20)
        Me.TxtAmount.TabIndex = 41
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(468, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Receipt Amount*"
        '
        'TxtInvoiceAmount
        '
        Me.TxtInvoiceAmount.BackColor = System.Drawing.Color.White
        Me.TxtInvoiceAmount.Enabled = False
        Me.TxtInvoiceAmount.Location = New System.Drawing.Point(367, 46)
        Me.TxtInvoiceAmount.Name = "TxtInvoiceAmount"
        Me.TxtInvoiceAmount.ReadOnly = True
        Me.TxtInvoiceAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtInvoiceAmount.Size = New System.Drawing.Size(89, 20)
        Me.TxtInvoiceAmount.TabIndex = 39
        Me.TxtInvoiceAmount.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(236, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Invoice Balance/Amount"
        '
        'CmbBill
        '
        Me.CmbBill.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbBill.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbBill.FormattingEnabled = True
        Me.CmbBill.Location = New System.Drawing.Point(100, 46)
        Me.CmbBill.Name = "CmbBill"
        Me.CmbBill.Size = New System.Drawing.Size(130, 21)
        Me.CmbBill.Sorted = True
        Me.CmbBill.TabIndex = 37
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Bill No."
        '
        'CmbLedger
        '
        Me.CmbLedger.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbLedger.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbLedger.FormattingEnabled = True
        Me.CmbLedger.Location = New System.Drawing.Point(100, 19)
        Me.CmbLedger.Name = "CmbLedger"
        Me.CmbLedger.Size = New System.Drawing.Size(411, 21)
        Me.CmbLedger.Sorted = True
        Me.CmbLedger.TabIndex = 35
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
        'GrpCashHead
        '
        Me.GrpCashHead.Controls.Add(Me.TxtVoucherNo)
        Me.GrpCashHead.Controls.Add(Me.Label1)
        Me.GrpCashHead.Controls.Add(Me.CmbCashHead)
        Me.GrpCashHead.Controls.Add(Me.Label6)
        Me.GrpCashHead.Controls.Add(Me.DtPkrPaymentDate)
        Me.GrpCashHead.Controls.Add(Me.Label2)
        Me.GrpCashHead.Location = New System.Drawing.Point(12, 12)
        Me.GrpCashHead.Name = "GrpCashHead"
        Me.GrpCashHead.Size = New System.Drawing.Size(675, 51)
        Me.GrpCashHead.TabIndex = 0
        Me.GrpCashHead.TabStop = False
        '
        'TxtVoucherNo
        '
        Me.TxtVoucherNo.BackColor = System.Drawing.Color.White
        Me.TxtVoucherNo.Enabled = False
        Me.TxtVoucherNo.Location = New System.Drawing.Point(79, 19)
        Me.TxtVoucherNo.Name = "TxtVoucherNo"
        Me.TxtVoucherNo.ReadOnly = True
        Me.TxtVoucherNo.Size = New System.Drawing.Size(98, 20)
        Me.TxtVoucherNo.TabIndex = 0
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(183, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Cash Head*"
        '
        'DtPkrPaymentDate
        '
        Me.DtPkrPaymentDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrPaymentDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPkrPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrPaymentDate.Location = New System.Drawing.Point(574, 19)
        Me.DtPkrPaymentDate.Name = "DtPkrPaymentDate"
        Me.DtPkrPaymentDate.Size = New System.Drawing.Size(91, 20)
        Me.DtPkrPaymentDate.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(494, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Payment Date"
        '
        'GrpButtons
        '
        Me.GrpButtons.Controls.Add(Me.BtnPrint)
        Me.GrpButtons.Controls.Add(Me.BtnSearch)
        Me.GrpButtons.Controls.Add(Me.BtnCancel)
        Me.GrpButtons.Controls.Add(Me.BtnUpdate)
        Me.GrpButtons.Controls.Add(Me.BtnClose)
        Me.GrpButtons.Controls.Add(Me.BtnRemove)
        Me.GrpButtons.Location = New System.Drawing.Point(12, 562)
        Me.GrpButtons.Name = "GrpButtons"
        Me.GrpButtons.Size = New System.Drawing.Size(675, 54)
        Me.GrpButtons.TabIndex = 4
        Me.GrpButtons.TabStop = False
        '
        'BtnCancel
        '
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnCancel.Location = New System.Drawing.Point(269, 19)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(73, 26)
        Me.BtnCancel.TabIndex = 67
        Me.BtnCancel.Text = "Cance&l"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnUpdate.Location = New System.Drawing.Point(190, 19)
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
        'BtnRemove
        '
        Me.BtnRemove.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnRemove.Location = New System.Drawing.Point(348, 19)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(73, 26)
        Me.BtnRemove.TabIndex = 64
        Me.BtnRemove.Text = "&Remove"
        Me.BtnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnPrint.Location = New System.Drawing.Point(427, 19)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(73, 26)
        Me.BtnPrint.TabIndex = 71
        Me.BtnPrint.Text = "&Print Slip"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'BtnSearch
        '
        Me.BtnSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnSearch.Location = New System.Drawing.Point(506, 19)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(73, 26)
        Me.BtnSearch.TabIndex = 70
        Me.BtnSearch.Text = "&Search"
        Me.BtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'FrmCashPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(699, 631)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpButtons)
        Me.Controls.Add(Me.GrpCashHead)
        Me.Controls.Add(Me.GrpPaymentDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCashPayment"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cash Payment"
        Me.GrpPaymentDetails.ResumeLayout(False)
        Me.GrpPaymentDetails.PerformLayout()
        CType(Me.GrdPayments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCashHead.ResumeLayout(False)
        Me.GrpCashHead.PerformLayout()
        Me.GrpButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpPaymentDetails As System.Windows.Forms.GroupBox
    Friend WithEvents GrdPayments As System.Windows.Forms.DataGridView
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents TxtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtInvoiceAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbBill As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbLedger As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GrpCashHead As System.Windows.Forms.GroupBox
    Friend WithEvents DtPkrPaymentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbCashHead As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtVoucherNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpButtons As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnRemove As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
End Class
