<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgTaxOnSalesRpt
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
        Me.DtPkrDateFrom = New System.Windows.Forms.DateTimePicker
        Me.BtnDisplay = New System.Windows.Forms.Button
        Me.OptBetween = New System.Windows.Forms.RadioButton
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.DtPkrDateTo = New System.Windows.Forms.DateTimePicker
        Me.OptSpecific = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.OptAll = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DtPkrDateFrom
        '
        Me.DtPkrDateFrom.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrDateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPkrDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrDateFrom.Location = New System.Drawing.Point(112, 41)
        Me.DtPkrDateFrom.Name = "DtPkrDateFrom"
        Me.DtPkrDateFrom.Size = New System.Drawing.Size(130, 20)
        Me.DtPkrDateFrom.TabIndex = 17
        '
        'BtnDisplay
        '
        Me.BtnDisplay.Location = New System.Drawing.Point(139, 101)
        Me.BtnDisplay.Name = "BtnDisplay"
        Me.BtnDisplay.Size = New System.Drawing.Size(75, 23)
        Me.BtnDisplay.TabIndex = 19
        Me.BtnDisplay.Text = "&Display"
        Me.BtnDisplay.UseVisualStyleBackColor = True
        '
        'OptBetween
        '
        Me.OptBetween.AutoSize = True
        Me.OptBetween.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptBetween.Location = New System.Drawing.Point(22, 67)
        Me.OptBetween.Name = "OptBetween"
        Me.OptBetween.Size = New System.Drawing.Size(67, 17)
        Me.OptBetween.TabIndex = 2
        Me.OptBetween.TabStop = True
        Me.OptBetween.Text = "Between"
        Me.OptBetween.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(220, 101)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 20
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'DtPkrDateTo
        '
        Me.DtPkrDateTo.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrDateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPkrDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrDateTo.Location = New System.Drawing.Point(112, 64)
        Me.DtPkrDateTo.Name = "DtPkrDateTo"
        Me.DtPkrDateTo.Size = New System.Drawing.Size(130, 20)
        Me.DtPkrDateTo.TabIndex = 18
        '
        'OptSpecific
        '
        Me.OptSpecific.AutoSize = True
        Me.OptSpecific.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptSpecific.Location = New System.Drawing.Point(22, 44)
        Me.OptSpecific.Name = "OptSpecific"
        Me.OptSpecific.Size = New System.Drawing.Size(63, 17)
        Me.OptSpecific.TabIndex = 1
        Me.OptSpecific.TabStop = True
        Me.OptSpecific.Text = "Specific"
        Me.OptSpecific.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DtPkrDateFrom)
        Me.GroupBox1.Controls.Add(Me.DtPkrDateTo)
        Me.GroupBox1.Controls.Add(Me.OptBetween)
        Me.GroupBox1.Controls.Add(Me.OptAll)
        Me.GroupBox1.Controls.Add(Me.OptSpecific)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(307, 90)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Date Range"
        '
        'OptAll
        '
        Me.OptAll.AutoSize = True
        Me.OptAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptAll.Location = New System.Drawing.Point(22, 21)
        Me.OptAll.Name = "OptAll"
        Me.OptAll.Size = New System.Drawing.Size(79, 17)
        Me.OptAll.TabIndex = 0
        Me.OptAll.TabStop = True
        Me.OptAll.Text = "All Records"
        Me.OptAll.UseVisualStyleBackColor = True
        '
        'DlgTaxOnSalesRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(325, 131)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnDisplay)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "DlgTaxOnSalesRpt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Taxes on Sales"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DtPkrDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnDisplay As System.Windows.Forms.Button
    Friend WithEvents OptBetween As System.Windows.Forms.RadioButton
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents DtPkrDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents OptSpecific As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OptAll As System.Windows.Forms.RadioButton
End Class
