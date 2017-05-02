<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgStockRpt
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
        Me.CmbRack = New System.Windows.Forms.ComboBox
        Me.CmbSchedule = New System.Windows.Forms.ComboBox
        Me.CmbCategory = New System.Windows.Forms.ComboBox
        Me.CmbManufacturer = New System.Windows.Forms.ComboBox
        Me.CmbItems = New System.Windows.Forms.ComboBox
        Me.OptRackWise = New System.Windows.Forms.RadioButton
        Me.OptScheduleWise = New System.Windows.Forms.RadioButton
        Me.OptCategoryWise = New System.Windows.Forms.RadioButton
        Me.OptManufacturerWise = New System.Windows.Forms.RadioButton
        Me.OptItemWise = New System.Windows.Forms.RadioButton
        Me.OptAllItems = New System.Windows.Forms.RadioButton
        Me.BtnShowReport = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmbRack)
        Me.GroupBox1.Controls.Add(Me.CmbSchedule)
        Me.GroupBox1.Controls.Add(Me.CmbCategory)
        Me.GroupBox1.Controls.Add(Me.CmbManufacturer)
        Me.GroupBox1.Controls.Add(Me.CmbItems)
        Me.GroupBox1.Controls.Add(Me.OptRackWise)
        Me.GroupBox1.Controls.Add(Me.OptScheduleWise)
        Me.GroupBox1.Controls.Add(Me.OptCategoryWise)
        Me.GroupBox1.Controls.Add(Me.OptManufacturerWise)
        Me.GroupBox1.Controls.Add(Me.OptItemWise)
        Me.GroupBox1.Controls.Add(Me.OptAllItems)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(458, 204)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter Options"
        '
        'CmbRack
        '
        Me.CmbRack.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbRack.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbRack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbRack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CmbRack.FormattingEnabled = True
        Me.CmbRack.Location = New System.Drawing.Point(240, 168)
        Me.CmbRack.Name = "CmbRack"
        Me.CmbRack.Size = New System.Drawing.Size(204, 21)
        Me.CmbRack.Sorted = True
        Me.CmbRack.TabIndex = 10
        '
        'CmbSchedule
        '
        Me.CmbSchedule.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbSchedule.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbSchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSchedule.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CmbSchedule.FormattingEnabled = True
        Me.CmbSchedule.Location = New System.Drawing.Point(0, 0)
        Me.CmbSchedule.Name = "CmbSchedule"
        Me.CmbSchedule.Size = New System.Drawing.Size(204, 21)
        Me.CmbSchedule.Sorted = True
        Me.CmbSchedule.TabIndex = 9
        Me.CmbSchedule.Visible = False
        '
        'CmbCategory
        '
        Me.CmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CmbCategory.FormattingEnabled = True
        Me.CmbCategory.Location = New System.Drawing.Point(240, 136)
        Me.CmbCategory.Name = "CmbCategory"
        Me.CmbCategory.Size = New System.Drawing.Size(204, 21)
        Me.CmbCategory.Sorted = True
        Me.CmbCategory.TabIndex = 8
        '
        'CmbManufacturer
        '
        Me.CmbManufacturer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbManufacturer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbManufacturer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CmbManufacturer.FormattingEnabled = True
        Me.CmbManufacturer.Location = New System.Drawing.Point(240, 98)
        Me.CmbManufacturer.Name = "CmbManufacturer"
        Me.CmbManufacturer.Size = New System.Drawing.Size(204, 21)
        Me.CmbManufacturer.Sorted = True
        Me.CmbManufacturer.TabIndex = 7
        '
        'CmbItems
        '
        Me.CmbItems.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbItems.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CmbItems.FormattingEnabled = True
        Me.CmbItems.Location = New System.Drawing.Point(240, 64)
        Me.CmbItems.Name = "CmbItems"
        Me.CmbItems.Size = New System.Drawing.Size(204, 21)
        Me.CmbItems.Sorted = True
        Me.CmbItems.TabIndex = 6
        '
        'OptRackWise
        '
        Me.OptRackWise.AutoSize = True
        Me.OptRackWise.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptRackWise.Location = New System.Drawing.Point(17, 168)
        Me.OptRackWise.Name = "OptRackWise"
        Me.OptRackWise.Size = New System.Drawing.Size(151, 17)
        Me.OptRackWise.TabIndex = 5
        Me.OptRackWise.TabStop = True
        Me.OptRackWise.Text = "Show RackWise Stock"
        Me.OptRackWise.UseVisualStyleBackColor = True
        '
        'OptScheduleWise
        '
        Me.OptScheduleWise.AutoSize = True
        Me.OptScheduleWise.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptScheduleWise.Location = New System.Drawing.Point(0, 0)
        Me.OptScheduleWise.Name = "OptScheduleWise"
        Me.OptScheduleWise.Size = New System.Drawing.Size(175, 17)
        Me.OptScheduleWise.TabIndex = 4
        Me.OptScheduleWise.TabStop = True
        Me.OptScheduleWise.Text = "Show ScheduleWise Stock"
        Me.OptScheduleWise.UseVisualStyleBackColor = True
        Me.OptScheduleWise.Visible = False
        '
        'OptCategoryWise
        '
        Me.OptCategoryWise.AutoSize = True
        Me.OptCategoryWise.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptCategoryWise.Location = New System.Drawing.Point(17, 140)
        Me.OptCategoryWise.Name = "OptCategoryWise"
        Me.OptCategoryWise.Size = New System.Drawing.Size(176, 17)
        Me.OptCategoryWise.TabIndex = 3
        Me.OptCategoryWise.TabStop = True
        Me.OptCategoryWise.Text = "Show CategoryWise Stock"
        Me.OptCategoryWise.UseVisualStyleBackColor = True
        '
        'OptManufacturerWise
        '
        Me.OptManufacturerWise.AutoSize = True
        Me.OptManufacturerWise.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptManufacturerWise.Location = New System.Drawing.Point(17, 102)
        Me.OptManufacturerWise.Name = "OptManufacturerWise"
        Me.OptManufacturerWise.Size = New System.Drawing.Size(198, 17)
        Me.OptManufacturerWise.TabIndex = 2
        Me.OptManufacturerWise.TabStop = True
        Me.OptManufacturerWise.Text = "Show ManufacturerWise Stock"
        Me.OptManufacturerWise.UseVisualStyleBackColor = True
        '
        'OptItemWise
        '
        Me.OptItemWise.AutoSize = True
        Me.OptItemWise.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptItemWise.Location = New System.Drawing.Point(17, 64)
        Me.OptItemWise.Name = "OptItemWise"
        Me.OptItemWise.Size = New System.Drawing.Size(150, 17)
        Me.OptItemWise.TabIndex = 1
        Me.OptItemWise.TabStop = True
        Me.OptItemWise.Text = "Show ItemWise Stock"
        Me.OptItemWise.UseVisualStyleBackColor = True
        '
        'OptAllItems
        '
        Me.OptAllItems.AutoSize = True
        Me.OptAllItems.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptAllItems.Location = New System.Drawing.Point(17, 26)
        Me.OptAllItems.Name = "OptAllItems"
        Me.OptAllItems.Size = New System.Drawing.Size(169, 17)
        Me.OptAllItems.TabIndex = 0
        Me.OptAllItems.TabStop = True
        Me.OptAllItems.Text = "Show Stock For All Items"
        Me.OptAllItems.UseVisualStyleBackColor = True
        '
        'BtnShowReport
        '
        Me.BtnShowReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnShowReport.Location = New System.Drawing.Point(315, 225)
        Me.BtnShowReport.Name = "BtnShowReport"
        Me.BtnShowReport.Size = New System.Drawing.Size(57, 31)
        Me.BtnShowReport.TabIndex = 1
        Me.BtnShowReport.Text = "Display"
        Me.BtnShowReport.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Location = New System.Drawing.Point(381, 225)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(57, 31)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'DlgStockRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(469, 267)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnShowReport)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "DlgStockRpt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OptAllItems As System.Windows.Forms.RadioButton
    Friend WithEvents OptRackWise As System.Windows.Forms.RadioButton
    Friend WithEvents OptScheduleWise As System.Windows.Forms.RadioButton
    Friend WithEvents OptCategoryWise As System.Windows.Forms.RadioButton
    Friend WithEvents OptManufacturerWise As System.Windows.Forms.RadioButton
    Friend WithEvents OptItemWise As System.Windows.Forms.RadioButton
    Friend WithEvents CmbRack As System.Windows.Forms.ComboBox
    Friend WithEvents CmbSchedule As System.Windows.Forms.ComboBox
    Friend WithEvents CmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents CmbManufacturer As System.Windows.Forms.ComboBox
    Friend WithEvents CmbItems As System.Windows.Forms.ComboBox
    Friend WithEvents BtnShowReport As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
End Class
