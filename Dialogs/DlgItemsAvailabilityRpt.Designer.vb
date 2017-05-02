<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgItemsAvailabilityRpt
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CmbItems = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.OptSchedule = New System.Windows.Forms.RadioButton
        Me.OptCategory = New System.Windows.Forms.RadioButton
        Me.OptManufacturer = New System.Windows.Forms.RadioButton
        Me.OptGeneric3 = New System.Windows.Forms.RadioButton
        Me.OptGeneric2 = New System.Windows.Forms.RadioButton
        Me.OptGeneric1 = New System.Windows.Forms.RadioButton
        Me.OptAllGeneric = New System.Windows.Forms.RadioButton
        Me.ChkOnlyAvailableStock = New System.Windows.Forms.CheckBox
        Me.BtnShowReport = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmbItems)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(397, 71)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Item Name"
        '
        'CmbItems
        '
        Me.CmbItems.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbItems.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbItems.FormattingEnabled = True
        Me.CmbItems.Location = New System.Drawing.Point(6, 30)
        Me.CmbItems.Name = "CmbItems"
        Me.CmbItems.Size = New System.Drawing.Size(377, 21)
        Me.CmbItems.Sorted = True
        Me.CmbItems.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.OptSchedule)
        Me.GroupBox2.Controls.Add(Me.OptCategory)
        Me.GroupBox2.Controls.Add(Me.OptManufacturer)
        Me.GroupBox2.Controls.Add(Me.OptGeneric3)
        Me.GroupBox2.Controls.Add(Me.OptGeneric2)
        Me.GroupBox2.Controls.Add(Me.OptGeneric1)
        Me.GroupBox2.Controls.Add(Me.OptAllGeneric)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 89)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(400, 75)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Show Availability Report Matching With"
        '
        'OptSchedule
        '
        Me.OptSchedule.AutoSize = True
        Me.OptSchedule.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptSchedule.Location = New System.Drawing.Point(0, 0)
        Me.OptSchedule.Name = "OptSchedule"
        Me.OptSchedule.Size = New System.Drawing.Size(77, 17)
        Me.OptSchedule.TabIndex = 6
        Me.OptSchedule.TabStop = True
        Me.OptSchedule.Text = "Schedule"
        Me.OptSchedule.UseVisualStyleBackColor = True
        Me.OptSchedule.Visible = False
        '
        'OptCategory
        '
        Me.OptCategory.AutoSize = True
        Me.OptCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptCategory.Location = New System.Drawing.Point(21, 46)
        Me.OptCategory.Name = "OptCategory"
        Me.OptCategory.Size = New System.Drawing.Size(78, 17)
        Me.OptCategory.TabIndex = 5
        Me.OptCategory.TabStop = True
        Me.OptCategory.Text = "Category"
        Me.OptCategory.UseVisualStyleBackColor = True
        '
        'OptManufacturer
        '
        Me.OptManufacturer.AutoSize = True
        Me.OptManufacturer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptManufacturer.Location = New System.Drawing.Point(21, 23)
        Me.OptManufacturer.Name = "OptManufacturer"
        Me.OptManufacturer.Size = New System.Drawing.Size(100, 17)
        Me.OptManufacturer.TabIndex = 4
        Me.OptManufacturer.TabStop = True
        Me.OptManufacturer.Text = "Manufacturer"
        Me.OptManufacturer.UseVisualStyleBackColor = True
        '
        'OptGeneric3
        '
        Me.OptGeneric3.AutoSize = True
        Me.OptGeneric3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptGeneric3.Location = New System.Drawing.Point(0, 0)
        Me.OptGeneric3.Name = "OptGeneric3"
        Me.OptGeneric3.Size = New System.Drawing.Size(76, 17)
        Me.OptGeneric3.TabIndex = 3
        Me.OptGeneric3.TabStop = True
        Me.OptGeneric3.Text = "Generic3"
        Me.OptGeneric3.UseVisualStyleBackColor = True
        Me.OptGeneric3.Visible = False
        '
        'OptGeneric2
        '
        Me.OptGeneric2.AutoSize = True
        Me.OptGeneric2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptGeneric2.Location = New System.Drawing.Point(0, 0)
        Me.OptGeneric2.Name = "OptGeneric2"
        Me.OptGeneric2.Size = New System.Drawing.Size(76, 17)
        Me.OptGeneric2.TabIndex = 2
        Me.OptGeneric2.TabStop = True
        Me.OptGeneric2.Text = "Generic2"
        Me.OptGeneric2.UseVisualStyleBackColor = True
        Me.OptGeneric2.Visible = False
        '
        'OptGeneric1
        '
        Me.OptGeneric1.AutoSize = True
        Me.OptGeneric1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptGeneric1.Location = New System.Drawing.Point(0, 0)
        Me.OptGeneric1.Name = "OptGeneric1"
        Me.OptGeneric1.Size = New System.Drawing.Size(76, 17)
        Me.OptGeneric1.TabIndex = 1
        Me.OptGeneric1.TabStop = True
        Me.OptGeneric1.Text = "Generic1"
        Me.OptGeneric1.UseVisualStyleBackColor = True
        Me.OptGeneric1.Visible = False
        '
        'OptAllGeneric
        '
        Me.OptAllGeneric.AutoSize = True
        Me.OptAllGeneric.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptAllGeneric.Location = New System.Drawing.Point(0, 0)
        Me.OptAllGeneric.Name = "OptAllGeneric"
        Me.OptAllGeneric.Size = New System.Drawing.Size(264, 17)
        Me.OptAllGeneric.TabIndex = 0
        Me.OptAllGeneric.TabStop = True
        Me.OptAllGeneric.Text = "All Generics(Generic1,Generic2,Generic3)"
        Me.OptAllGeneric.UseVisualStyleBackColor = True
        Me.OptAllGeneric.Visible = False
        '
        'ChkOnlyAvailableStock
        '
        Me.ChkOnlyAvailableStock.AutoSize = True
        Me.ChkOnlyAvailableStock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkOnlyAvailableStock.Location = New System.Drawing.Point(33, 174)
        Me.ChkOnlyAvailableStock.Name = "ChkOnlyAvailableStock"
        Me.ChkOnlyAvailableStock.Size = New System.Drawing.Size(190, 17)
        Me.ChkOnlyAvailableStock.TabIndex = 2
        Me.ChkOnlyAvailableStock.Text = "Display Only Available Stock"
        Me.ChkOnlyAvailableStock.UseVisualStyleBackColor = True
        '
        'BtnShowReport
        '
        Me.BtnShowReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnShowReport.Location = New System.Drawing.Point(270, 170)
        Me.BtnShowReport.Name = "BtnShowReport"
        Me.BtnShowReport.Size = New System.Drawing.Size(61, 30)
        Me.BtnShowReport.TabIndex = 3
        Me.BtnShowReport.Text = "Display"
        Me.BtnShowReport.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Location = New System.Drawing.Point(337, 170)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(61, 30)
        Me.BtnClose.TabIndex = 4
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'DlgItemsAvailabilityRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(424, 209)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnShowReport)
        Me.Controls.Add(Me.ChkOnlyAvailableStock)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "DlgItemsAvailabilityRpt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Items Availability"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbItems As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents OptAllGeneric As System.Windows.Forms.RadioButton
    Friend WithEvents OptSchedule As System.Windows.Forms.RadioButton
    Friend WithEvents OptCategory As System.Windows.Forms.RadioButton
    Friend WithEvents OptManufacturer As System.Windows.Forms.RadioButton
    Friend WithEvents OptGeneric3 As System.Windows.Forms.RadioButton
    Friend WithEvents OptGeneric2 As System.Windows.Forms.RadioButton
    Friend WithEvents OptGeneric1 As System.Windows.Forms.RadioButton
    Friend WithEvents ChkOnlyAvailableStock As System.Windows.Forms.CheckBox
    Friend WithEvents BtnShowReport As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
End Class
