<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgExpiryRpt
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
        Me.GrpCondition = New System.Windows.Forms.GroupBox
        Me.NmrMonths = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtPkrDateFrom = New System.Windows.Forms.DateTimePicker
        Me.OptDate = New System.Windows.Forms.RadioButton
        Me.OptAll = New System.Windows.Forms.RadioButton
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnShow = New System.Windows.Forms.Button
        Me.GrpCondition.SuspendLayout()
        CType(Me.NmrMonths, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpCondition
        '
        Me.GrpCondition.Controls.Add(Me.NmrMonths)
        Me.GrpCondition.Controls.Add(Me.Label1)
        Me.GrpCondition.Controls.Add(Me.DtPkrDateFrom)
        Me.GrpCondition.Controls.Add(Me.OptDate)
        Me.GrpCondition.Controls.Add(Me.OptAll)
        Me.GrpCondition.Location = New System.Drawing.Point(12, 12)
        Me.GrpCondition.Name = "GrpCondition"
        Me.GrpCondition.Size = New System.Drawing.Size(291, 82)
        Me.GrpCondition.TabIndex = 0
        Me.GrpCondition.TabStop = False
        Me.GrpCondition.Text = "Date Range"
        '
        'NmrMonths
        '
        Me.NmrMonths.Location = New System.Drawing.Point(224, 45)
        Me.NmrMonths.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.NmrMonths.Name = "NmrMonths"
        Me.NmrMonths.Size = New System.Drawing.Size(45, 20)
        Me.NmrMonths.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(160, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "To Months"
        '
        'DtPkrDateFrom
        '
        Me.DtPkrDateFrom.CustomFormat = "MMM-yyyy"
        Me.DtPkrDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrDateFrom.Location = New System.Drawing.Point(75, 43)
        Me.DtPkrDateFrom.Name = "DtPkrDateFrom"
        Me.DtPkrDateFrom.Size = New System.Drawing.Size(79, 20)
        Me.DtPkrDateFrom.TabIndex = 2
        '
        'OptDate
        '
        Me.OptDate.AutoSize = True
        Me.OptDate.Location = New System.Drawing.Point(21, 45)
        Me.OptDate.Name = "OptDate"
        Me.OptDate.Size = New System.Drawing.Size(48, 17)
        Me.OptDate.TabIndex = 1
        Me.OptDate.Text = "From"
        Me.OptDate.UseVisualStyleBackColor = True
        '
        'OptAll
        '
        Me.OptAll.AutoSize = True
        Me.OptAll.Checked = True
        Me.OptAll.Location = New System.Drawing.Point(21, 22)
        Me.OptAll.Name = "OptAll"
        Me.OptAll.Size = New System.Drawing.Size(36, 17)
        Me.OptAll.TabIndex = 0
        Me.OptAll.TabStop = True
        Me.OptAll.Text = "All"
        Me.OptAll.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(243, 103)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(61, 30)
        Me.BtnClose.TabIndex = 84
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnShow
        '
        Me.BtnShow.Location = New System.Drawing.Point(176, 103)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(61, 30)
        Me.BtnShow.TabIndex = 83
        Me.BtnShow.Text = "&Show"
        Me.BtnShow.UseVisualStyleBackColor = True
        '
        'DlgExpiryRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(319, 145)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpCondition)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgExpiryRpt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Expiry Detail From Stock"
        Me.GrpCondition.ResumeLayout(False)
        Me.GrpCondition.PerformLayout()
        CType(Me.NmrMonths, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpCondition As System.Windows.Forms.GroupBox
    Friend WithEvents DtPkrDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents OptDate As System.Windows.Forms.RadioButton
    Friend WithEvents OptAll As System.Windows.Forms.RadioButton
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnShow As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NmrMonths As System.Windows.Forms.NumericUpDown

End Class
