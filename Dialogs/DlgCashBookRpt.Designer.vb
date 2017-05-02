<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgCashBookRpt
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
        Me.GrpHead = New System.Windows.Forms.GroupBox
        Me.CmbHeads = New System.Windows.Forms.ComboBox
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnShow = New System.Windows.Forms.Button
        Me.GrpCondition.SuspendLayout()
        Me.GrpHead.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpCondition
        '
        Me.GrpCondition.Controls.Add(Me.DtPkrDateTo)
        Me.GrpCondition.Controls.Add(Me.DtPkrDateFrom)
        Me.GrpCondition.Controls.Add(Me.OptBetweenDates)
        Me.GrpCondition.Controls.Add(Me.OptOnDate)
        Me.GrpCondition.Controls.Add(Me.OptAll)
        Me.GrpCondition.Location = New System.Drawing.Point(12, 71)
        Me.GrpCondition.Name = "GrpCondition"
        Me.GrpCondition.Size = New System.Drawing.Size(291, 99)
        Me.GrpCondition.TabIndex = 82
        Me.GrpCondition.TabStop = False
        Me.GrpCondition.Text = "Date Range"
        '
        'DtPkrDateTo
        '
        Me.DtPkrDateTo.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrDateTo.Location = New System.Drawing.Point(91, 66)
        Me.DtPkrDateTo.Name = "DtPkrDateTo"
        Me.DtPkrDateTo.Size = New System.Drawing.Size(90, 20)
        Me.DtPkrDateTo.TabIndex = 81
        '
        'DtPkrDateFrom
        '
        Me.DtPkrDateFrom.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrDateFrom.Location = New System.Drawing.Point(91, 40)
        Me.DtPkrDateFrom.Name = "DtPkrDateFrom"
        Me.DtPkrDateFrom.Size = New System.Drawing.Size(90, 20)
        Me.DtPkrDateFrom.TabIndex = 80
        '
        'OptBetweenDates
        '
        Me.OptBetweenDates.AutoSize = True
        Me.OptBetweenDates.Location = New System.Drawing.Point(6, 65)
        Me.OptBetweenDates.Name = "OptBetweenDates"
        Me.OptBetweenDates.Size = New System.Drawing.Size(67, 17)
        Me.OptBetweenDates.TabIndex = 79
        Me.OptBetweenDates.Text = "Between"
        Me.OptBetweenDates.UseVisualStyleBackColor = True
        '
        'OptOnDate
        '
        Me.OptOnDate.AutoSize = True
        Me.OptOnDate.Location = New System.Drawing.Point(6, 42)
        Me.OptOnDate.Name = "OptOnDate"
        Me.OptOnDate.Size = New System.Drawing.Size(65, 17)
        Me.OptOnDate.TabIndex = 78
        Me.OptOnDate.Text = "On Date"
        Me.OptOnDate.UseVisualStyleBackColor = True
        '
        'OptAll
        '
        Me.OptAll.AutoSize = True
        Me.OptAll.Checked = True
        Me.OptAll.Location = New System.Drawing.Point(6, 19)
        Me.OptAll.Name = "OptAll"
        Me.OptAll.Size = New System.Drawing.Size(36, 17)
        Me.OptAll.TabIndex = 77
        Me.OptAll.TabStop = True
        Me.OptAll.Text = "All"
        Me.OptAll.UseVisualStyleBackColor = True
        '
        'GrpHead
        '
        Me.GrpHead.Controls.Add(Me.CmbHeads)
        Me.GrpHead.Location = New System.Drawing.Point(12, 12)
        Me.GrpHead.Name = "GrpHead"
        Me.GrpHead.Size = New System.Drawing.Size(291, 53)
        Me.GrpHead.TabIndex = 81
        Me.GrpHead.TabStop = False
        Me.GrpHead.Text = "Select Cash Head"
        '
        'CmbHeads
        '
        Me.CmbHeads.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbHeads.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbHeads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbHeads.FormattingEnabled = True
        Me.CmbHeads.Location = New System.Drawing.Point(6, 19)
        Me.CmbHeads.Name = "CmbHeads"
        Me.CmbHeads.Size = New System.Drawing.Size(276, 21)
        Me.CmbHeads.Sorted = True
        Me.CmbHeads.TabIndex = 74
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(242, 176)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(61, 30)
        Me.BtnClose.TabIndex = 80
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnShow
        '
        Me.BtnShow.Location = New System.Drawing.Point(175, 176)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(61, 30)
        Me.BtnShow.TabIndex = 79
        Me.BtnShow.Text = "&Show"
        Me.BtnShow.UseVisualStyleBackColor = True
        '
        'DlgCashBookRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(320, 218)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpCondition)
        Me.Controls.Add(Me.GrpHead)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgCashBookRpt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cash Book"
        Me.GrpCondition.ResumeLayout(False)
        Me.GrpCondition.PerformLayout()
        Me.GrpHead.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpCondition As System.Windows.Forms.GroupBox
    Friend WithEvents DtPkrDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtPkrDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents OptBetweenDates As System.Windows.Forms.RadioButton
    Friend WithEvents OptOnDate As System.Windows.Forms.RadioButton
    Friend WithEvents OptAll As System.Windows.Forms.RadioButton
    Friend WithEvents GrpHead As System.Windows.Forms.GroupBox
    Friend WithEvents CmbHeads As System.Windows.Forms.ComboBox
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnShow As System.Windows.Forms.Button

End Class
