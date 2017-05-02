<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJournalEntry
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
        Me.GrpJournal = New System.Windows.Forms.GroupBox
        Me.DtPkrJournalDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtJournalNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpLedger = New System.Windows.Forms.GroupBox
        Me.LblDebit = New System.Windows.Forms.Label
        Me.LblCredit = New System.Windows.Forms.Label
        Me.GrdLedgers = New System.Windows.Forms.DataGridView
        Me.BtnRemove = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.TxtRemark = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.CmbDrCr = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtAmount = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtInvoiceAmount = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmbBill = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbLedger = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GrpJournals = New System.Windows.Forms.GroupBox
        Me.BtnNew = New System.Windows.Forms.Button
        Me.CmbJournals = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.BtnClose = New System.Windows.Forms.Button
        Me.GrpJournal.SuspendLayout()
        Me.GrpLedger.SuspendLayout()
        CType(Me.GrdLedgers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpJournals.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpJournal
        '
        Me.GrpJournal.Controls.Add(Me.DtPkrJournalDate)
        Me.GrpJournal.Controls.Add(Me.Label2)
        Me.GrpJournal.Controls.Add(Me.TxtJournalNo)
        Me.GrpJournal.Controls.Add(Me.Label1)
        Me.GrpJournal.Location = New System.Drawing.Point(12, 12)
        Me.GrpJournal.Name = "GrpJournal"
        Me.GrpJournal.Size = New System.Drawing.Size(749, 51)
        Me.GrpJournal.TabIndex = 0
        Me.GrpJournal.TabStop = False
        Me.GrpJournal.Text = "Journal"
        '
        'DtPkrJournalDate
        '
        Me.DtPkrJournalDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrJournalDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPkrJournalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrJournalDate.Location = New System.Drawing.Point(269, 19)
        Me.DtPkrJournalDate.Name = "DtPkrJournalDate"
        Me.DtPkrJournalDate.Size = New System.Drawing.Size(91, 20)
        Me.DtPkrJournalDate.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(196, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Journal Date"
        '
        'TxtJournalNo
        '
        Me.TxtJournalNo.BackColor = System.Drawing.Color.White
        Me.TxtJournalNo.Enabled = False
        Me.TxtJournalNo.Location = New System.Drawing.Point(67, 19)
        Me.TxtJournalNo.Name = "TxtJournalNo"
        Me.TxtJournalNo.ReadOnly = True
        Me.TxtJournalNo.Size = New System.Drawing.Size(123, 20)
        Me.TxtJournalNo.TabIndex = 37
        Me.TxtJournalNo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Jounal No"
        '
        'GrpLedger
        '
        Me.GrpLedger.Controls.Add(Me.LblDebit)
        Me.GrpLedger.Controls.Add(Me.LblCredit)
        Me.GrpLedger.Controls.Add(Me.GrdLedgers)
        Me.GrpLedger.Controls.Add(Me.BtnRemove)
        Me.GrpLedger.Controls.Add(Me.BtnAdd)
        Me.GrpLedger.Controls.Add(Me.TxtRemark)
        Me.GrpLedger.Controls.Add(Me.Label8)
        Me.GrpLedger.Controls.Add(Me.CmbDrCr)
        Me.GrpLedger.Controls.Add(Me.Label6)
        Me.GrpLedger.Controls.Add(Me.TxtAmount)
        Me.GrpLedger.Controls.Add(Me.Label5)
        Me.GrpLedger.Controls.Add(Me.TxtInvoiceAmount)
        Me.GrpLedger.Controls.Add(Me.Label4)
        Me.GrpLedger.Controls.Add(Me.CmbBill)
        Me.GrpLedger.Controls.Add(Me.Label3)
        Me.GrpLedger.Controls.Add(Me.CmbLedger)
        Me.GrpLedger.Controls.Add(Me.Label7)
        Me.GrpLedger.Location = New System.Drawing.Point(12, 69)
        Me.GrpLedger.Name = "GrpLedger"
        Me.GrpLedger.Size = New System.Drawing.Size(749, 487)
        Me.GrpLedger.TabIndex = 1
        Me.GrpLedger.TabStop = False
        Me.GrpLedger.Text = "Ledger Entries"
        '
        'LblDebit
        '
        Me.LblDebit.AutoSize = True
        Me.LblDebit.Location = New System.Drawing.Point(266, 464)
        Me.LblDebit.Name = "LblDebit"
        Me.LblDebit.Size = New System.Drawing.Size(28, 13)
        Me.LblDebit.TabIndex = 66
        Me.LblDebit.Text = "0.00"
        '
        'LblCredit
        '
        Me.LblCredit.AutoSize = True
        Me.LblCredit.Location = New System.Drawing.Point(381, 464)
        Me.LblCredit.Name = "LblCredit"
        Me.LblCredit.Size = New System.Drawing.Size(28, 13)
        Me.LblCredit.TabIndex = 65
        Me.LblCredit.Text = "0.00"
        '
        'GrdLedgers
        '
        Me.GrdLedgers.AllowUserToAddRows = False
        Me.GrdLedgers.AllowUserToDeleteRows = False
        Me.GrdLedgers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdLedgers.Location = New System.Drawing.Point(6, 104)
        Me.GrdLedgers.Name = "GrdLedgers"
        Me.GrdLedgers.ReadOnly = True
        Me.GrdLedgers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdLedgers.Size = New System.Drawing.Size(737, 352)
        Me.GrdLedgers.TabIndex = 64
        '
        'BtnRemove
        '
        Me.BtnRemove.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnRemove.Location = New System.Drawing.Point(664, 72)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(73, 26)
        Me.BtnRemove.TabIndex = 63
        Me.BtnRemove.Text = "&Remove"
        Me.BtnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnAdd.Location = New System.Drawing.Point(585, 72)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(73, 26)
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
        'CmbDrCr
        '
        Me.CmbDrCr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbDrCr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbDrCr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDrCr.FormattingEnabled = True
        Me.CmbDrCr.Location = New System.Drawing.Point(665, 46)
        Me.CmbDrCr.Name = "CmbDrCr"
        Me.CmbDrCr.Size = New System.Drawing.Size(72, 21)
        Me.CmbDrCr.Sorted = True
        Me.CmbDrCr.TabIndex = 43
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(626, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Dr/Cr"
        '
        'TxtAmount
        '
        Me.TxtAmount.BackColor = System.Drawing.Color.White
        Me.TxtAmount.Location = New System.Drawing.Point(517, 46)
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
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Amount"
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
        Me.CmbLedger.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
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
        'GrpJournals
        '
        Me.GrpJournals.Controls.Add(Me.BtnNew)
        Me.GrpJournals.Controls.Add(Me.CmbJournals)
        Me.GrpJournals.Controls.Add(Me.Label9)
        Me.GrpJournals.Controls.Add(Me.BtnClose)
        Me.GrpJournals.Location = New System.Drawing.Point(767, 12)
        Me.GrpJournals.Name = "GrpJournals"
        Me.GrpJournals.Size = New System.Drawing.Size(157, 544)
        Me.GrpJournals.TabIndex = 16
        Me.GrpJournals.TabStop = False
        '
        'BtnNew
        '
        Me.BtnNew.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnNew.Location = New System.Drawing.Point(6, 508)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(64, 26)
        Me.BtnNew.TabIndex = 68
        Me.BtnNew.Text = "&New"
        Me.BtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'CmbJournals
        '
        Me.CmbJournals.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbJournals.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbJournals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.CmbJournals.FormattingEnabled = True
        Me.CmbJournals.Location = New System.Drawing.Point(6, 38)
        Me.CmbJournals.Name = "CmbJournals"
        Me.CmbJournals.Size = New System.Drawing.Size(145, 450)
        Me.CmbJournals.Sorted = True
        Me.CmbJournals.TabIndex = 67
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "Journals"
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(88, 508)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(63, 26)
        Me.BtnClose.TabIndex = 61
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'FrmJournalEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(943, 568)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpJournals)
        Me.Controls.Add(Me.GrpLedger)
        Me.Controls.Add(Me.GrpJournal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmJournalEntry"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Journal Entry"
        Me.GrpJournal.ResumeLayout(False)
        Me.GrpJournal.PerformLayout()
        Me.GrpLedger.ResumeLayout(False)
        Me.GrpLedger.PerformLayout()
        CType(Me.GrdLedgers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpJournals.ResumeLayout(False)
        Me.GrpJournals.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpJournal As System.Windows.Forms.GroupBox
    Friend WithEvents DtPkrJournalDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtJournalNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpLedger As System.Windows.Forms.GroupBox
    Friend WithEvents CmbLedger As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtInvoiceAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbBill As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbDrCr As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnRemove As System.Windows.Forms.Button
    Friend WithEvents GrdLedgers As System.Windows.Forms.DataGridView
    Friend WithEvents GrpJournals As System.Windows.Forms.GroupBox
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents LblDebit As System.Windows.Forms.Label
    Friend WithEvents LblCredit As System.Windows.Forms.Label
    Friend WithEvents CmbJournals As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BtnNew As System.Windows.Forms.Button
End Class
