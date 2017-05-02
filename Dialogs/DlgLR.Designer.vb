<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgLR
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
        Me.GrpInvoice = New System.Windows.Forms.GroupBox
        Me.LblSaleDate = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.CmbCustomer = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.CmbInvoice = New System.Windows.Forms.ComboBox
        Me.GrpLRDetail = New System.Windows.Forms.GroupBox
        Me.TxtDueDays = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.DtPkrDueDate = New System.Windows.Forms.DateTimePicker
        Me.Label30 = New System.Windows.Forms.Label
        Me.DtPkrLRDate = New System.Windows.Forms.DateTimePicker
        Me.Label27 = New System.Windows.Forms.Label
        Me.TxtLRNo = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.GrpInvoice.SuspendLayout()
        Me.GrpLRDetail.SuspendLayout()
        CType(Me.TxtDueDays, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpInvoice
        '
        Me.GrpInvoice.Controls.Add(Me.LblSaleDate)
        Me.GrpInvoice.Controls.Add(Me.Label1)
        Me.GrpInvoice.Controls.Add(Me.Label19)
        Me.GrpInvoice.Controls.Add(Me.CmbCustomer)
        Me.GrpInvoice.Controls.Add(Me.Label18)
        Me.GrpInvoice.Controls.Add(Me.CmbInvoice)
        Me.GrpInvoice.Location = New System.Drawing.Point(12, 12)
        Me.GrpInvoice.Name = "GrpInvoice"
        Me.GrpInvoice.Size = New System.Drawing.Size(329, 104)
        Me.GrpInvoice.TabIndex = 0
        Me.GrpInvoice.TabStop = False
        Me.GrpInvoice.Text = "Invoices"
        '
        'LblSaleDate
        '
        Me.LblSaleDate.AutoSize = True
        Me.LblSaleDate.Location = New System.Drawing.Point(66, 76)
        Me.LblSaleDate.Name = "LblSaleDate"
        Me.LblSaleDate.Size = New System.Drawing.Size(0, 13)
        Me.LblSaleDate.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sale Date"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 49)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(51, 13)
        Me.Label19.TabIndex = 2
        Me.Label19.Text = "Customer"
        '
        'CmbCustomer
        '
        Me.CmbCustomer.BackColor = System.Drawing.Color.White
        Me.CmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCustomer.Enabled = False
        Me.CmbCustomer.FormattingEnabled = True
        Me.CmbCustomer.Location = New System.Drawing.Point(63, 46)
        Me.CmbCustomer.Name = "CmbCustomer"
        Me.CmbCustomer.Size = New System.Drawing.Size(250, 21)
        Me.CmbCustomer.Sorted = True
        Me.CmbCustomer.TabIndex = 3
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Invoices"
        '
        'CmbInvoice
        '
        Me.CmbInvoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbInvoice.FormattingEnabled = True
        Me.CmbInvoice.Location = New System.Drawing.Point(63, 19)
        Me.CmbInvoice.Name = "CmbInvoice"
        Me.CmbInvoice.Size = New System.Drawing.Size(164, 21)
        Me.CmbInvoice.Sorted = True
        Me.CmbInvoice.TabIndex = 1
        '
        'GrpLRDetail
        '
        Me.GrpLRDetail.Controls.Add(Me.TxtDueDays)
        Me.GrpLRDetail.Controls.Add(Me.Label2)
        Me.GrpLRDetail.Controls.Add(Me.DtPkrDueDate)
        Me.GrpLRDetail.Controls.Add(Me.Label30)
        Me.GrpLRDetail.Controls.Add(Me.DtPkrLRDate)
        Me.GrpLRDetail.Controls.Add(Me.Label27)
        Me.GrpLRDetail.Controls.Add(Me.TxtLRNo)
        Me.GrpLRDetail.Controls.Add(Me.Label26)
        Me.GrpLRDetail.Location = New System.Drawing.Point(12, 122)
        Me.GrpLRDetail.Name = "GrpLRDetail"
        Me.GrpLRDetail.Size = New System.Drawing.Size(329, 128)
        Me.GrpLRDetail.TabIndex = 1
        Me.GrpLRDetail.TabStop = False
        Me.GrpLRDetail.Text = "LR Detail"
        '
        'TxtDueDays
        '
        Me.TxtDueDays.Location = New System.Drawing.Point(69, 71)
        Me.TxtDueDays.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.TxtDueDays.Name = "TxtDueDays"
        Me.TxtDueDays.Size = New System.Drawing.Size(93, 20)
        Me.TxtDueDays.TabIndex = 5
        Me.TxtDueDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Due Days"
        '
        'DtPkrDueDate
        '
        Me.DtPkrDueDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrDueDate.Enabled = False
        Me.DtPkrDueDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPkrDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrDueDate.Location = New System.Drawing.Point(69, 97)
        Me.DtPkrDueDate.Name = "DtPkrDueDate"
        Me.DtPkrDueDate.Size = New System.Drawing.Size(93, 20)
        Me.DtPkrDueDate.TabIndex = 7
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(6, 100)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(53, 13)
        Me.Label30.TabIndex = 6
        Me.Label30.Text = "Due Date"
        '
        'DtPkrLRDate
        '
        Me.DtPkrLRDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrLRDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPkrLRDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrLRDate.Location = New System.Drawing.Point(69, 45)
        Me.DtPkrLRDate.Name = "DtPkrLRDate"
        Me.DtPkrLRDate.Size = New System.Drawing.Size(93, 20)
        Me.DtPkrLRDate.TabIndex = 3
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(6, 48)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(47, 13)
        Me.Label27.TabIndex = 2
        Me.Label27.Text = "LR Date"
        '
        'TxtLRNo
        '
        Me.TxtLRNo.Location = New System.Drawing.Point(69, 19)
        Me.TxtLRNo.Name = "TxtLRNo"
        Me.TxtLRNo.Size = New System.Drawing.Size(158, 20)
        Me.TxtLRNo.TabIndex = 1
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(6, 23)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(44, 13)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "L.R.No."
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(186, 260)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 3
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(100, 260)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(72, 26)
        Me.BtnUpdate.TabIndex = 2
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'DlgLR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(357, 298)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.GrpLRDetail)
        Me.Controls.Add(Me.GrpInvoice)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgLR"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "LRs"
        Me.GrpInvoice.ResumeLayout(False)
        Me.GrpInvoice.PerformLayout()
        Me.GrpLRDetail.ResumeLayout(False)
        Me.GrpLRDetail.PerformLayout()
        CType(Me.TxtDueDays, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpInvoice As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents CmbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CmbInvoice As System.Windows.Forms.ComboBox
    Friend WithEvents LblSaleDate As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpLRDetail As System.Windows.Forms.GroupBox
    Friend WithEvents DtPkrDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents DtPkrLRDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TxtLRNo As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDueDays As System.Windows.Forms.NumericUpDown
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button

End Class
