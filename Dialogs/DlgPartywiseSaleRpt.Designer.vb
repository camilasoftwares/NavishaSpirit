<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgPartywiseSaleRpt
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbPatient = New System.Windows.Forms.ComboBox
        Me.LblPatientName = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DtPkrDateFrom = New System.Windows.Forms.DateTimePicker
        Me.DtPkrDateTo = New System.Windows.Forms.DateTimePicker
        Me.OptBetween = New System.Windows.Forms.RadioButton
        Me.OptAll = New System.Windows.Forms.RadioButton
        Me.OptSpecific = New System.Windows.Forms.RadioButton
        Me.BtnShow = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.CmbPatient)
        Me.GroupBox2.Controls.Add(Me.LblPatientName)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(338, 68)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(83, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(249, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "**Leave Customer Name blank to get all Customerwise list."
        '
        'CmbPatient
        '
        Me.CmbPatient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbPatient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPatient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbPatient.FormattingEnabled = True
        Me.CmbPatient.Location = New System.Drawing.Point(102, 19)
        Me.CmbPatient.Name = "CmbPatient"
        Me.CmbPatient.Size = New System.Drawing.Size(230, 21)
        Me.CmbPatient.Sorted = True
        Me.CmbPatient.TabIndex = 1
        '
        'LblPatientName
        '
        Me.LblPatientName.AutoSize = True
        Me.LblPatientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPatientName.Location = New System.Drawing.Point(14, 22)
        Me.LblPatientName.Name = "LblPatientName"
        Me.LblPatientName.Size = New System.Drawing.Size(82, 13)
        Me.LblPatientName.TabIndex = 0
        Me.LblPatientName.Text = "Customer Name"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DtPkrDateFrom)
        Me.GroupBox1.Controls.Add(Me.DtPkrDateTo)
        Me.GroupBox1.Controls.Add(Me.OptBetween)
        Me.GroupBox1.Controls.Add(Me.OptAll)
        Me.GroupBox1.Controls.Add(Me.OptSpecific)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(14, 96)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(338, 98)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Date Range"
        '
        'DtPkrDateFrom
        '
        Me.DtPkrDateFrom.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrDateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPkrDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrDateFrom.Location = New System.Drawing.Point(112, 41)
        Me.DtPkrDateFrom.Name = "DtPkrDateFrom"
        Me.DtPkrDateFrom.Size = New System.Drawing.Size(130, 20)
        Me.DtPkrDateFrom.TabIndex = 3
        '
        'DtPkrDateTo
        '
        Me.DtPkrDateTo.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrDateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPkrDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrDateTo.Location = New System.Drawing.Point(112, 64)
        Me.DtPkrDateTo.Name = "DtPkrDateTo"
        Me.DtPkrDateTo.Size = New System.Drawing.Size(130, 20)
        Me.DtPkrDateTo.TabIndex = 4
        '
        'OptBetween
        '
        Me.OptBetween.AutoSize = True
        Me.OptBetween.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.OptBetween.Location = New System.Drawing.Point(22, 67)
        Me.OptBetween.Name = "OptBetween"
        Me.OptBetween.Size = New System.Drawing.Size(67, 17)
        Me.OptBetween.TabIndex = 2
        Me.OptBetween.TabStop = True
        Me.OptBetween.Text = "Between"
        Me.OptBetween.UseVisualStyleBackColor = True
        '
        'OptAll
        '
        Me.OptAll.AutoSize = True
        Me.OptAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.OptAll.Location = New System.Drawing.Point(22, 21)
        Me.OptAll.Name = "OptAll"
        Me.OptAll.Size = New System.Drawing.Size(79, 17)
        Me.OptAll.TabIndex = 0
        Me.OptAll.TabStop = True
        Me.OptAll.Text = "All Records"
        Me.OptAll.UseVisualStyleBackColor = True
        '
        'OptSpecific
        '
        Me.OptSpecific.AutoSize = True
        Me.OptSpecific.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.OptSpecific.Location = New System.Drawing.Point(22, 44)
        Me.OptSpecific.Name = "OptSpecific"
        Me.OptSpecific.Size = New System.Drawing.Size(63, 17)
        Me.OptSpecific.TabIndex = 1
        Me.OptSpecific.TabStop = True
        Me.OptSpecific.Text = "Specific"
        Me.OptSpecific.UseVisualStyleBackColor = True
        '
        'BtnShow
        '
        Me.BtnShow.Location = New System.Drawing.Point(223, 210)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(61, 30)
        Me.BtnShow.TabIndex = 6
        Me.BtnShow.Text = "&Show"
        Me.BtnShow.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(291, 210)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(61, 30)
        Me.BtnClose.TabIndex = 7
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'DlgPartywiseSaleRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(371, 253)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnShow)
        Me.Controls.Add(Me.BtnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgPartywiseSaleRpt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Party wise Sale"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbPatient As System.Windows.Forms.ComboBox
    Friend WithEvents LblPatientName As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DtPkrDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtPkrDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents OptBetween As System.Windows.Forms.RadioButton
    Friend WithEvents OptAll As System.Windows.Forms.RadioButton
    Friend WithEvents OptSpecific As System.Windows.Forms.RadioButton
    Friend WithEvents BtnShow As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button

End Class
