<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmScheduleMaster
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
        Me.GrpButton = New System.Windows.Forms.GroupBox
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.GrpScheduleDetails = New System.Windows.Forms.GroupBox
        Me.GrdScheduleDetails = New System.Windows.Forms.DataGridView
        Me.GrpSchedule = New System.Windows.Forms.GroupBox
        Me.TxtColor = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbPrompt = New System.Windows.Forms.ComboBox
        Me.TxtSchedule = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DlgColor = New System.Windows.Forms.ColorDialog
        Me.Label4 = New System.Windows.Forms.Label
        Me.GrpButton.SuspendLayout()
        Me.GrpScheduleDetails.SuspendLayout()
        CType(Me.GrdScheduleDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpSchedule.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpButton
        '
        Me.GrpButton.Controls.Add(Me.BtnCancel)
        Me.GrpButton.Controls.Add(Me.BtnUpdate)
        Me.GrpButton.Controls.Add(Me.BtnClose)
        Me.GrpButton.Controls.Add(Me.BtnAdd)
        Me.GrpButton.Location = New System.Drawing.Point(12, 78)
        Me.GrpButton.Name = "GrpButton"
        Me.GrpButton.Size = New System.Drawing.Size(545, 52)
        Me.GrpButton.TabIndex = 15
        Me.GrpButton.TabStop = False
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(386, 19)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(72, 26)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "Cance&l"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(308, 19)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(72, 26)
        Me.BtnUpdate.TabIndex = 2
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(464, 19)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(230, 19)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(72, 26)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'GrpScheduleDetails
        '
        Me.GrpScheduleDetails.Controls.Add(Me.GrdScheduleDetails)
        Me.GrpScheduleDetails.Location = New System.Drawing.Point(12, 136)
        Me.GrpScheduleDetails.Name = "GrpScheduleDetails"
        Me.GrpScheduleDetails.Size = New System.Drawing.Size(545, 364)
        Me.GrpScheduleDetails.TabIndex = 14
        Me.GrpScheduleDetails.TabStop = False
        Me.GrpScheduleDetails.Text = "Schedule Details"
        '
        'GrdScheduleDetails
        '
        Me.GrdScheduleDetails.AllowUserToAddRows = False
        Me.GrdScheduleDetails.AllowUserToDeleteRows = False
        Me.GrdScheduleDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdScheduleDetails.Location = New System.Drawing.Point(6, 19)
        Me.GrdScheduleDetails.Name = "GrdScheduleDetails"
        Me.GrdScheduleDetails.ReadOnly = True
        Me.GrdScheduleDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdScheduleDetails.Size = New System.Drawing.Size(533, 339)
        Me.GrdScheduleDetails.TabIndex = 5
        '
        'GrpSchedule
        '
        Me.GrpSchedule.Controls.Add(Me.Label4)
        Me.GrpSchedule.Controls.Add(Me.TxtColor)
        Me.GrpSchedule.Controls.Add(Me.Label3)
        Me.GrpSchedule.Controls.Add(Me.CmbPrompt)
        Me.GrpSchedule.Controls.Add(Me.TxtSchedule)
        Me.GrpSchedule.Controls.Add(Me.Label2)
        Me.GrpSchedule.Controls.Add(Me.Label1)
        Me.GrpSchedule.Location = New System.Drawing.Point(12, 12)
        Me.GrpSchedule.Name = "GrpSchedule"
        Me.GrpSchedule.Size = New System.Drawing.Size(545, 60)
        Me.GrpSchedule.TabIndex = 13
        Me.GrpSchedule.TabStop = False
        Me.GrpSchedule.Text = "Schedule"
        '
        'TxtColor
        '
        Me.TxtColor.BackColor = System.Drawing.Color.White
        Me.TxtColor.Location = New System.Drawing.Point(306, 18)
        Me.TxtColor.Name = "TxtColor"
        Me.TxtColor.ReadOnly = True
        Me.TxtColor.Size = New System.Drawing.Size(35, 20)
        Me.TxtColor.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(265, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Color*"
        '
        'CmbPrompt
        '
        Me.CmbPrompt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbPrompt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbPrompt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPrompt.FormattingEnabled = True
        Me.CmbPrompt.Location = New System.Drawing.Point(469, 18)
        Me.CmbPrompt.Name = "CmbPrompt"
        Me.CmbPrompt.Size = New System.Drawing.Size(67, 21)
        Me.CmbPrompt.Sorted = True
        Me.CmbPrompt.TabIndex = 33
        '
        'TxtSchedule
        '
        Me.TxtSchedule.Location = New System.Drawing.Point(60, 19)
        Me.TxtSchedule.Name = "TxtSchedule"
        Me.TxtSchedule.Size = New System.Drawing.Size(199, 20)
        Me.TxtSchedule.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Schedule*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(347, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Prompt For Prescription"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(265, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 12)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Click on Color box to select color"
        '
        'FrmScheduleMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(569, 510)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpButton)
        Me.Controls.Add(Me.GrpScheduleDetails)
        Me.Controls.Add(Me.GrpSchedule)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmScheduleMaster"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Schedule Master"
        Me.GrpButton.ResumeLayout(False)
        Me.GrpScheduleDetails.ResumeLayout(False)
        CType(Me.GrdScheduleDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpSchedule.ResumeLayout(False)
        Me.GrpSchedule.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpButton As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents GrpScheduleDetails As System.Windows.Forms.GroupBox
    Friend WithEvents GrdScheduleDetails As System.Windows.Forms.DataGridView
    Friend WithEvents GrpSchedule As System.Windows.Forms.GroupBox
    Friend WithEvents TxtColor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbPrompt As System.Windows.Forms.ComboBox
    Friend WithEvents TxtSchedule As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DlgColor As System.Windows.Forms.ColorDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
