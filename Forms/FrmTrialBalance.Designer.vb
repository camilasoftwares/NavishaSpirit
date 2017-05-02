<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrialBalance
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
        Me.GrpTrialBalance = New System.Windows.Forms.GroupBox
        Me.LblCredit = New System.Windows.Forms.Label
        Me.LblDebit = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GrdTrialBalance = New System.Windows.Forms.DataGridView
        Me.DtPkrDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.OptDetailed = New System.Windows.Forms.RadioButton
        Me.OptCondensed = New System.Windows.Forms.RadioButton
        Me.CmbGroups = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnShow = New System.Windows.Forms.Button
        Me.GrpTrialBalance.SuspendLayout()
        CType(Me.GrdTrialBalance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTrialBalance
        '
        Me.GrpTrialBalance.Controls.Add(Me.LblCredit)
        Me.GrpTrialBalance.Controls.Add(Me.LblDebit)
        Me.GrpTrialBalance.Controls.Add(Me.Label4)
        Me.GrpTrialBalance.Controls.Add(Me.GrdTrialBalance)
        Me.GrpTrialBalance.Location = New System.Drawing.Point(12, 86)
        Me.GrpTrialBalance.Name = "GrpTrialBalance"
        Me.GrpTrialBalance.Size = New System.Drawing.Size(631, 522)
        Me.GrpTrialBalance.TabIndex = 13
        Me.GrpTrialBalance.TabStop = False
        Me.GrpTrialBalance.Text = "Trial Balance"
        '
        'LblCredit
        '
        Me.LblCredit.AutoSize = True
        Me.LblCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCredit.Location = New System.Drawing.Point(517, 499)
        Me.LblCredit.Name = "LblCredit"
        Me.LblCredit.Size = New System.Drawing.Size(14, 13)
        Me.LblCredit.TabIndex = 19
        Me.LblCredit.Text = "0"
        '
        'LblDebit
        '
        Me.LblDebit.AutoSize = True
        Me.LblDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDebit.Location = New System.Drawing.Point(395, 499)
        Me.LblDebit.Name = "LblDebit"
        Me.LblDebit.Size = New System.Drawing.Size(14, 13)
        Me.LblDebit.TabIndex = 18
        Me.LblDebit.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(221, 499)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Total"
        '
        'GrdTrialBalance
        '
        Me.GrdTrialBalance.AllowUserToAddRows = False
        Me.GrdTrialBalance.AllowUserToDeleteRows = False
        Me.GrdTrialBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdTrialBalance.Location = New System.Drawing.Point(7, 19)
        Me.GrdTrialBalance.Name = "GrdTrialBalance"
        Me.GrdTrialBalance.ReadOnly = True
        Me.GrdTrialBalance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdTrialBalance.Size = New System.Drawing.Size(616, 471)
        Me.GrdTrialBalance.TabIndex = 5
        '
        'DtPkrDate
        '
        Me.DtPkrDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrDate.Location = New System.Drawing.Point(12, 25)
        Me.DtPkrDate.Name = "DtPkrDate"
        Me.DtPkrDate.Size = New System.Drawing.Size(90, 20)
        Me.DtPkrDate.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(105, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Display Type"
        '
        'OptDetailed
        '
        Me.OptDetailed.AutoSize = True
        Me.OptDetailed.Checked = True
        Me.OptDetailed.Location = New System.Drawing.Point(108, 28)
        Me.OptDetailed.Name = "OptDetailed"
        Me.OptDetailed.Size = New System.Drawing.Size(64, 17)
        Me.OptDetailed.TabIndex = 17
        Me.OptDetailed.TabStop = True
        Me.OptDetailed.Text = "Detailed"
        Me.OptDetailed.UseVisualStyleBackColor = True
        '
        'OptCondensed
        '
        Me.OptCondensed.AutoSize = True
        Me.OptCondensed.Location = New System.Drawing.Point(178, 28)
        Me.OptCondensed.Name = "OptCondensed"
        Me.OptCondensed.Size = New System.Drawing.Size(79, 17)
        Me.OptCondensed.TabIndex = 18
        Me.OptCondensed.Text = "Condensed"
        Me.OptCondensed.UseVisualStyleBackColor = True
        '
        'CmbGroups
        '
        Me.CmbGroups.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbGroups.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbGroups.FormattingEnabled = True
        Me.CmbGroups.Location = New System.Drawing.Point(263, 27)
        Me.CmbGroups.Name = "CmbGroups"
        Me.CmbGroups.Size = New System.Drawing.Size(372, 21)
        Me.CmbGroups.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(260, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Groups"
        '
        'BtnPrint
        '
        Me.BtnPrint.Location = New System.Drawing.Point(485, 53)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(72, 26)
        Me.BtnPrint.TabIndex = 66
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(563, 54)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 65
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnShow
        '
        Me.BtnShow.Location = New System.Drawing.Point(407, 54)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(72, 26)
        Me.BtnShow.TabIndex = 64
        Me.BtnShow.Text = "&Show"
        Me.BtnShow.UseVisualStyleBackColor = True
        '
        'FrmTrialBalance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(656, 620)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnShow)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CmbGroups)
        Me.Controls.Add(Me.OptCondensed)
        Me.Controls.Add(Me.OptDetailed)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DtPkrDate)
        Me.Controls.Add(Me.GrpTrialBalance)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTrialBalance"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Trial Balance"
        Me.GrpTrialBalance.ResumeLayout(False)
        Me.GrpTrialBalance.PerformLayout()
        CType(Me.GrdTrialBalance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GrpTrialBalance As System.Windows.Forms.GroupBox
    Friend WithEvents GrdTrialBalance As System.Windows.Forms.DataGridView
    Friend WithEvents DtPkrDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OptDetailed As System.Windows.Forms.RadioButton
    Friend WithEvents OptCondensed As System.Windows.Forms.RadioButton
    Friend WithEvents CmbGroups As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnShow As System.Windows.Forms.Button
    Friend WithEvents LblCredit As System.Windows.Forms.Label
    Friend WithEvents LblDebit As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
