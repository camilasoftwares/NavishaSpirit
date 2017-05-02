<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgItemWisePurchaseRpt
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
        Me.BtnShow = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CmbItem = New System.Windows.Forms.ComboBox
        Me.LblItemNameName = New System.Windows.Forms.Label
        Me.DtPkrDateTo = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.OptBetween = New System.Windows.Forms.RadioButton
        Me.OptSpecific = New System.Windows.Forms.RadioButton
        Me.OptAllRecords = New System.Windows.Forms.RadioButton
        Me.BtnClose = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DtPkrDateFrom
        '
        Me.DtPkrDateFrom.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrDateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPkrDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrDateFrom.Location = New System.Drawing.Point(154, 46)
        Me.DtPkrDateFrom.Name = "DtPkrDateFrom"
        Me.DtPkrDateFrom.Size = New System.Drawing.Size(109, 20)
        Me.DtPkrDateFrom.TabIndex = 3
        Me.DtPkrDateFrom.Visible = False
        '
        'BtnShow
        '
        Me.BtnShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnShow.Location = New System.Drawing.Point(245, 210)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(61, 30)
        Me.BtnShow.TabIndex = 6
        Me.BtnShow.Text = "&Show"
        Me.BtnShow.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CmbItem)
        Me.GroupBox1.Controls.Add(Me.LblItemNameName)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 78)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'CmbItem
        '
        Me.CmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbItem.FormattingEnabled = True
        Me.CmbItem.Location = New System.Drawing.Point(94, 23)
        Me.CmbItem.Name = "CmbItem"
        Me.CmbItem.Size = New System.Drawing.Size(252, 21)
        Me.CmbItem.Sorted = True
        Me.CmbItem.TabIndex = 1
        '
        'LblItemNameName
        '
        Me.LblItemNameName.AutoSize = True
        Me.LblItemNameName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblItemNameName.Location = New System.Drawing.Point(6, 25)
        Me.LblItemNameName.Name = "LblItemNameName"
        Me.LblItemNameName.Size = New System.Drawing.Size(58, 13)
        Me.LblItemNameName.TabIndex = 0
        Me.LblItemNameName.Text = "Item Name"
        '
        'DtPkrDateTo
        '
        Me.DtPkrDateTo.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrDateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPkrDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrDateTo.Location = New System.Drawing.Point(154, 75)
        Me.DtPkrDateTo.Name = "DtPkrDateTo"
        Me.DtPkrDateTo.Size = New System.Drawing.Size(109, 20)
        Me.DtPkrDateTo.TabIndex = 4
        Me.DtPkrDateTo.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DtPkrDateTo)
        Me.GroupBox2.Controls.Add(Me.DtPkrDateFrom)
        Me.GroupBox2.Controls.Add(Me.OptBetween)
        Me.GroupBox2.Controls.Add(Me.OptSpecific)
        Me.GroupBox2.Controls.Add(Me.OptAllRecords)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(15, 96)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(352, 108)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Date Range"
        '
        'OptBetween
        '
        Me.OptBetween.AutoSize = True
        Me.OptBetween.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptBetween.Location = New System.Drawing.Point(39, 75)
        Me.OptBetween.Name = "OptBetween"
        Me.OptBetween.Size = New System.Drawing.Size(67, 17)
        Me.OptBetween.TabIndex = 2
        Me.OptBetween.TabStop = True
        Me.OptBetween.Text = "Between"
        Me.OptBetween.UseVisualStyleBackColor = True
        '
        'OptSpecific
        '
        Me.OptSpecific.AutoSize = True
        Me.OptSpecific.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptSpecific.Location = New System.Drawing.Point(39, 48)
        Me.OptSpecific.Name = "OptSpecific"
        Me.OptSpecific.Size = New System.Drawing.Size(63, 17)
        Me.OptSpecific.TabIndex = 1
        Me.OptSpecific.TabStop = True
        Me.OptSpecific.Text = "Specific"
        Me.OptSpecific.UseVisualStyleBackColor = True
        '
        'OptAllRecords
        '
        Me.OptAllRecords.AutoSize = True
        Me.OptAllRecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptAllRecords.Location = New System.Drawing.Point(39, 21)
        Me.OptAllRecords.Name = "OptAllRecords"
        Me.OptAllRecords.Size = New System.Drawing.Size(79, 17)
        Me.OptAllRecords.TabIndex = 0
        Me.OptAllRecords.TabStop = True
        Me.OptAllRecords.Text = "All Records"
        Me.OptAllRecords.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Location = New System.Drawing.Point(309, 210)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(61, 30)
        Me.BtnClose.TabIndex = 7
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(92, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(207, 12)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "**Leave Item  Name blank to get all Itemwise list."
        '
        'DlgItemWisePurchaseRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(379, 249)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnShow)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BtnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgItemWisePurchaseRpt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Item-Wise Purchase"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DtPkrDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnShow As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbItem As System.Windows.Forms.ComboBox
    Friend WithEvents LblItemNameName As System.Windows.Forms.Label
    Friend WithEvents DtPkrDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents OptBetween As System.Windows.Forms.RadioButton
    Friend WithEvents OptSpecific As System.Windows.Forms.RadioButton
    Friend WithEvents OptAllRecords As System.Windows.Forms.RadioButton
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
