<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgItemwiseSaleRpt
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
        Me.DtPkrDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.BtnShow = New System.Windows.Forms.Button()
        Me.OptBetween = New System.Windows.Forms.RadioButton()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.DtPkrDateTo = New System.Windows.Forms.DateTimePicker()
        Me.OptSpecific = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.OptAll = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbItem = New System.Windows.Forms.ComboBox()
        Me.LblItemName = New System.Windows.Forms.Label()
        Me.cmb_Categary = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.DtPkrDateFrom.TabIndex = 2
        '
        'BtnShow
        '
        Me.BtnShow.Location = New System.Drawing.Point(177, 206)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(61, 30)
        Me.BtnShow.TabIndex = 2
        Me.BtnShow.Text = "&Show"
        Me.BtnShow.UseVisualStyleBackColor = True
        '
        'OptBetween
        '
        Me.OptBetween.AutoSize = True
        Me.OptBetween.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.OptBetween.Location = New System.Drawing.Point(22, 67)
        Me.OptBetween.Name = "OptBetween"
        Me.OptBetween.Size = New System.Drawing.Size(67, 17)
        Me.OptBetween.TabIndex = 3
        Me.OptBetween.TabStop = True
        Me.OptBetween.Text = "Between"
        Me.OptBetween.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(244, 206)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(61, 30)
        Me.BtnClose.TabIndex = 3
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DtPkrDateFrom)
        Me.GroupBox1.Controls.Add(Me.DtPkrDateTo)
        Me.GroupBox1.Controls.Add(Me.OptBetween)
        Me.GroupBox1.Controls.Add(Me.OptAll)
        Me.GroupBox1.Controls.Add(Me.OptSpecific)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 107)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(293, 98)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Date Range"
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmb_Categary)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.CmbItem)
        Me.GroupBox2.Controls.Add(Me.LblItemName)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(293, 94)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(68, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(207, 12)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "**Leave Item  Name blank to get all Itemwise list."
        '
        'CmbItem
        '
        Me.CmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbItem.FormattingEnabled = True
        Me.CmbItem.Location = New System.Drawing.Point(82, 47)
        Me.CmbItem.Name = "CmbItem"
        Me.CmbItem.Size = New System.Drawing.Size(205, 21)
        Me.CmbItem.Sorted = True
        Me.CmbItem.TabIndex = 0
        '
        'LblItemName
        '
        Me.LblItemName.AutoSize = True
        Me.LblItemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblItemName.Location = New System.Drawing.Point(6, 50)
        Me.LblItemName.Name = "LblItemName"
        Me.LblItemName.Size = New System.Drawing.Size(58, 13)
        Me.LblItemName.TabIndex = 0
        Me.LblItemName.Text = "Item Name"
        '
        'cmb_Categary
        '
        Me.cmb_Categary.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_Categary.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_Categary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Categary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Categary.FormattingEnabled = True
        Me.cmb_Categary.Location = New System.Drawing.Point(83, 19)
        Me.cmb_Categary.Name = "cmb_Categary"
        Me.cmb_Categary.Size = New System.Drawing.Size(204, 21)
        Me.cmb_Categary.Sorted = True
        Me.cmb_Categary.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Item Categary"
        '
        'DlgItemwiseSaleRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(320, 244)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BtnShow)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "DlgItemwiseSaleRpt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Wise Sale"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DtPkrDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnShow As System.Windows.Forms.Button
    Friend WithEvents OptBetween As System.Windows.Forms.RadioButton
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents DtPkrDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents OptSpecific As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OptAll As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbItem As System.Windows.Forms.ComboBox
    Friend WithEvents LblItemName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_Categary As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
