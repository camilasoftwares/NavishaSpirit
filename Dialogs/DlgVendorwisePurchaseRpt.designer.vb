<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgVendorwisePurchaseRpt
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
        Me.DtPkrDateTo = New System.Windows.Forms.DateTimePicker
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbVendor = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.DtPkrDateFrom = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.OptBetween = New System.Windows.Forms.RadioButton
        Me.OptAll = New System.Windows.Forms.RadioButton
        Me.OptSpecific = New System.Windows.Forms.RadioButton
        Me.BtnShow = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
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
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(332, 179)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(61, 30)
        Me.BtnCancel.TabIndex = 20
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.CmbVendor)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(381, 60)
        Me.Panel1.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(55, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(312, 12)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "**Leave Vendor Name blank to get all vendors purchase with Itemwise list."
        '
        'CmbVendor
        '
        Me.CmbVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbVendor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CmbVendor.FormattingEnabled = True
        Me.CmbVendor.Location = New System.Drawing.Point(80, 14)
        Me.CmbVendor.Name = "CmbVendor"
        Me.CmbVendor.Size = New System.Drawing.Size(287, 21)
        Me.CmbVendor.Sorted = True
        Me.CmbVendor.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Vendor Name"
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DtPkrDateFrom)
        Me.GroupBox1.Controls.Add(Me.DtPkrDateTo)
        Me.GroupBox1.Controls.Add(Me.OptBetween)
        Me.GroupBox1.Controls.Add(Me.OptAll)
        Me.GroupBox1.Controls.Add(Me.OptSpecific)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(381, 90)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Date Range"
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
        Me.BtnShow.Location = New System.Drawing.Point(267, 179)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(61, 30)
        Me.BtnShow.TabIndex = 19
        Me.BtnShow.Text = "&Show"
        Me.BtnShow.UseVisualStyleBackColor = True
        '
        'DlgVendorwisePurchaseRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(408, 221)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "DlgVendorwisePurchaseRpt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vendor-wise Purchase"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DtPkrDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmbVendor As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DtPkrDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OptBetween As System.Windows.Forms.RadioButton
    Friend WithEvents OptAll As System.Windows.Forms.RadioButton
    Friend WithEvents OptSpecific As System.Windows.Forms.RadioButton
    Friend WithEvents BtnShow As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
