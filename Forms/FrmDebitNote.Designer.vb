<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDebitNote
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
        Me.PnlDetail = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtRemark = New System.Windows.Forms.TextBox
        Me.CmbAgainstHead = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtNarration = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtAmount = New System.Windows.Forms.TextBox
        Me.DtPkrNoteDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbVendor = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtDebitCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PnlButtons = New System.Windows.Forms.Panel
        Me.BtnSearch = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnNew = New System.Windows.Forms.Button
        Me.PnlDetail.SuspendLayout()
        Me.PnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlDetail
        '
        Me.PnlDetail.Controls.Add(Me.Label6)
        Me.PnlDetail.Controls.Add(Me.TxtRemark)
        Me.PnlDetail.Controls.Add(Me.CmbAgainstHead)
        Me.PnlDetail.Controls.Add(Me.Label5)
        Me.PnlDetail.Controls.Add(Me.Label4)
        Me.PnlDetail.Controls.Add(Me.TxtNarration)
        Me.PnlDetail.Controls.Add(Me.Label10)
        Me.PnlDetail.Controls.Add(Me.TxtAmount)
        Me.PnlDetail.Controls.Add(Me.DtPkrNoteDate)
        Me.PnlDetail.Controls.Add(Me.Label3)
        Me.PnlDetail.Controls.Add(Me.CmbVendor)
        Me.PnlDetail.Controls.Add(Me.Label2)
        Me.PnlDetail.Controls.Add(Me.TxtDebitCode)
        Me.PnlDetail.Controls.Add(Me.Label1)
        Me.PnlDetail.Location = New System.Drawing.Point(12, 12)
        Me.PnlDetail.Name = "PnlDetail"
        Me.PnlDetail.Size = New System.Drawing.Size(643, 306)
        Me.PnlDetail.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(255, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Remark"
        '
        'TxtRemark
        '
        Me.TxtRemark.Location = New System.Drawing.Point(258, 56)
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(374, 20)
        Me.TxtRemark.TabIndex = 11
        '
        'CmbAgainstHead
        '
        Me.CmbAgainstHead.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbAgainstHead.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbAgainstHead.FormattingEnabled = True
        Me.CmbAgainstHead.Location = New System.Drawing.Point(6, 55)
        Me.CmbAgainstHead.Name = "CmbAgainstHead"
        Me.CmbAgainstHead.Size = New System.Drawing.Size(246, 21)
        Me.CmbAgainstHead.Sorted = True
        Me.CmbAgainstHead.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Head To Credit"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Narration"
        '
        'TxtNarration
        '
        Me.TxtNarration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNarration.Location = New System.Drawing.Point(6, 95)
        Me.TxtNarration.Multiline = True
        Me.TxtNarration.Name = "TxtNarration"
        Me.TxtNarration.Size = New System.Drawing.Size(626, 201)
        Me.TxtNarration.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(519, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Amount"
        '
        'TxtAmount
        '
        Me.TxtAmount.Location = New System.Drawing.Point(522, 16)
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtAmount.Size = New System.Drawing.Size(110, 20)
        Me.TxtAmount.TabIndex = 7
        '
        'DtPkrNoteDate
        '
        Me.DtPkrNoteDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrNoteDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPkrNoteDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrNoteDate.Location = New System.Drawing.Point(419, 16)
        Me.DtPkrNoteDate.Name = "DtPkrNoteDate"
        Me.DtPkrNoteDate.Size = New System.Drawing.Size(97, 20)
        Me.DtPkrNoteDate.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(416, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Date"
        '
        'CmbVendor
        '
        Me.CmbVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbVendor.FormattingEnabled = True
        Me.CmbVendor.Location = New System.Drawing.Point(148, 16)
        Me.CmbVendor.Name = "CmbVendor"
        Me.CmbVendor.Size = New System.Drawing.Size(265, 21)
        Me.CmbVendor.Sorted = True
        Me.CmbVendor.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(145, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Vendor Name"
        '
        'TxtDebitCode
        '
        Me.TxtDebitCode.BackColor = System.Drawing.Color.White
        Me.TxtDebitCode.Enabled = False
        Me.TxtDebitCode.Location = New System.Drawing.Point(3, 16)
        Me.TxtDebitCode.Name = "TxtDebitCode"
        Me.TxtDebitCode.ReadOnly = True
        Me.TxtDebitCode.Size = New System.Drawing.Size(139, 20)
        Me.TxtDebitCode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Debit Note Code:"
        '
        'PnlButtons
        '
        Me.PnlButtons.Controls.Add(Me.BtnSearch)
        Me.PnlButtons.Controls.Add(Me.BtnClose)
        Me.PnlButtons.Controls.Add(Me.BtnPrint)
        Me.PnlButtons.Controls.Add(Me.BtnSave)
        Me.PnlButtons.Controls.Add(Me.BtnNew)
        Me.PnlButtons.Location = New System.Drawing.Point(12, 324)
        Me.PnlButtons.Name = "PnlButtons"
        Me.PnlButtons.Size = New System.Drawing.Size(643, 35)
        Me.PnlButtons.TabIndex = 1
        '
        'BtnSearch
        '
        Me.BtnSearch.Location = New System.Drawing.Point(380, 3)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(80, 26)
        Me.BtnSearch.TabIndex = 2
        Me.BtnSearch.Text = "Searc&h"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(552, 3)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(80, 26)
        Me.BtnClose.TabIndex = 4
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.Location = New System.Drawing.Point(466, 3)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(80, 26)
        Me.BtnPrint.TabIndex = 3
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(294, 3)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(80, 26)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnNew
        '
        Me.BtnNew.Location = New System.Drawing.Point(208, 3)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(80, 26)
        Me.BtnNew.TabIndex = 0
        Me.BtnNew.Text = "&New"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'FrmDebitNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(668, 375)
        Me.ControlBox = False
        Me.Controls.Add(Me.PnlButtons)
        Me.Controls.Add(Me.PnlDetail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDebitNote"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Debit Note"
        Me.PnlDetail.ResumeLayout(False)
        Me.PnlDetail.PerformLayout()
        Me.PnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlDetail As System.Windows.Forms.Panel
    Friend WithEvents TxtDebitCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbVendor As System.Windows.Forms.ComboBox
    Friend WithEvents DtPkrNoteDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtNarration As System.Windows.Forms.TextBox
    Friend WithEvents PnlButtons As System.Windows.Forms.Panel
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents CmbAgainstHead As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtRemark As System.Windows.Forms.TextBox

End Class
