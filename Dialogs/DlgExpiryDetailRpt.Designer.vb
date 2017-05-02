<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgExpiryDetailRpt
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
        Me.DtPkrDateTo = New System.Windows.Forms.DateTimePicker
        Me.DtPkrDateFrom = New System.Windows.Forms.DateTimePicker
        Me.OptBetweenDates = New System.Windows.Forms.RadioButton
        Me.OptOnDate = New System.Windows.Forms.RadioButton
        Me.OptAll = New System.Windows.Forms.RadioButton
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnShow = New System.Windows.Forms.Button
        Me.GrpCondition.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpCondition
        '
        Me.GrpCondition.Controls.Add(Me.DtPkrDateTo)
        Me.GrpCondition.Controls.Add(Me.DtPkrDateFrom)
        Me.GrpCondition.Controls.Add(Me.OptBetweenDates)
        Me.GrpCondition.Controls.Add(Me.OptOnDate)
        Me.GrpCondition.Controls.Add(Me.OptAll)
        Me.GrpCondition.Location = New System.Drawing.Point(12, 12)
        Me.GrpCondition.Name = "GrpCondition"
        Me.GrpCondition.Size = New System.Drawing.Size(257, 109)
        Me.GrpCondition.TabIndex = 0
        Me.GrpCondition.TabStop = False
        Me.GrpCondition.Text = "Date Range"
        '
        'DtPkrDateTo
        '
        Me.DtPkrDateTo.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrDateTo.Location = New System.Drawing.Point(91, 68)
        Me.DtPkrDateTo.Name = "DtPkrDateTo"
        Me.DtPkrDateTo.Size = New System.Drawing.Size(118, 20)
        Me.DtPkrDateTo.TabIndex = 4
        '
        'DtPkrDateFrom
        '
        Me.DtPkrDateFrom.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrDateFrom.Location = New System.Drawing.Point(91, 42)
        Me.DtPkrDateFrom.Name = "DtPkrDateFrom"
        Me.DtPkrDateFrom.Size = New System.Drawing.Size(118, 20)
        Me.DtPkrDateFrom.TabIndex = 3
        '
        'OptBetweenDates
        '
        Me.OptBetweenDates.AutoSize = True
        Me.OptBetweenDates.Location = New System.Drawing.Point(6, 67)
        Me.OptBetweenDates.Name = "OptBetweenDates"
        Me.OptBetweenDates.Size = New System.Drawing.Size(67, 17)
        Me.OptBetweenDates.TabIndex = 2
        Me.OptBetweenDates.Text = "Between"
        Me.OptBetweenDates.UseVisualStyleBackColor = True
        '
        'OptOnDate
        '
        Me.OptOnDate.AutoSize = True
        Me.OptOnDate.Location = New System.Drawing.Point(6, 44)
        Me.OptOnDate.Name = "OptOnDate"
        Me.OptOnDate.Size = New System.Drawing.Size(65, 17)
        Me.OptOnDate.TabIndex = 1
        Me.OptOnDate.Text = "On Date"
        Me.OptOnDate.UseVisualStyleBackColor = True
        '
        'OptAll
        '
        Me.OptAll.AutoSize = True
        Me.OptAll.Checked = True
        Me.OptAll.Location = New System.Drawing.Point(6, 21)
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
        Me.BtnClose.Location = New System.Drawing.Point(208, 127)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(61, 30)
        Me.BtnClose.TabIndex = 84
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnShow
        '
        Me.BtnShow.Location = New System.Drawing.Point(141, 127)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(61, 30)
        Me.BtnShow.TabIndex = 83
        Me.BtnShow.Text = "&Show"
        Me.BtnShow.UseVisualStyleBackColor = True
        '
        'DlgExpiryDetailRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(292, 171)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpCondition)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgExpiryDetailRpt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Expiry Detail Report"
        Me.GrpCondition.ResumeLayout(False)
        Me.GrpCondition.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpCondition As System.Windows.Forms.GroupBox
    Friend WithEvents DtPkrDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtPkrDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents OptBetweenDates As System.Windows.Forms.RadioButton
    Friend WithEvents OptOnDate As System.Windows.Forms.RadioButton
    Friend WithEvents OptAll As System.Windows.Forms.RadioButton
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnShow As System.Windows.Forms.Button

End Class
