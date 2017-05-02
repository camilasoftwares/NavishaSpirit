<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrackLog
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
        Me.BtnClose = New System.Windows.Forms.Button
        Me.TabLog = New System.Windows.Forms.TabControl
        Me.TabLogMaster = New System.Windows.Forms.TabPage
        Me.GrdMasterLog = New System.Windows.Forms.DataGridView
        Me.BtnShow = New System.Windows.Forms.Button
        Me.DtPkrAfter = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.CmbTransactionType = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabLogDetail = New System.Windows.Forms.TabPage
        Me.GrdLogDetail = New System.Windows.Forms.DataGridView
        Me.TabLog.SuspendLayout()
        Me.TabLogMaster.SuspendLayout()
        CType(Me.GrdMasterLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabLogDetail.SuspendLayout()
        CType(Me.GrdLogDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(759, 568)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 25)
        Me.BtnClose.TabIndex = 0
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'TabLog
        '
        Me.TabLog.Controls.Add(Me.TabLogMaster)
        Me.TabLog.Controls.Add(Me.TabLogDetail)
        Me.TabLog.Location = New System.Drawing.Point(12, 12)
        Me.TabLog.Name = "TabLog"
        Me.TabLog.SelectedIndex = 0
        Me.TabLog.Size = New System.Drawing.Size(826, 550)
        Me.TabLog.TabIndex = 1
        '
        'TabLogMaster
        '
        Me.TabLogMaster.BackColor = System.Drawing.SystemColors.Control
        Me.TabLogMaster.Controls.Add(Me.GrdMasterLog)
        Me.TabLogMaster.Controls.Add(Me.BtnShow)
        Me.TabLogMaster.Controls.Add(Me.DtPkrAfter)
        Me.TabLogMaster.Controls.Add(Me.Label2)
        Me.TabLogMaster.Controls.Add(Me.CmbTransactionType)
        Me.TabLogMaster.Controls.Add(Me.Label1)
        Me.TabLogMaster.Location = New System.Drawing.Point(4, 22)
        Me.TabLogMaster.Name = "TabLogMaster"
        Me.TabLogMaster.Padding = New System.Windows.Forms.Padding(3)
        Me.TabLogMaster.Size = New System.Drawing.Size(818, 524)
        Me.TabLogMaster.TabIndex = 0
        Me.TabLogMaster.Text = "Main Records"
        '
        'GrdMasterLog
        '
        Me.GrdMasterLog.AllowUserToAddRows = False
        Me.GrdMasterLog.AllowUserToDeleteRows = False
        Me.GrdMasterLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdMasterLog.Location = New System.Drawing.Point(9, 37)
        Me.GrdMasterLog.Name = "GrdMasterLog"
        Me.GrdMasterLog.ReadOnly = True
        Me.GrdMasterLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdMasterLog.Size = New System.Drawing.Size(803, 481)
        Me.GrdMasterLog.TabIndex = 5
        '
        'BtnShow
        '
        Me.BtnShow.Location = New System.Drawing.Point(533, 4)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(86, 27)
        Me.BtnShow.TabIndex = 4
        Me.BtnShow.Text = "&Show"
        Me.BtnShow.UseVisualStyleBackColor = True
        '
        'DtPkrAfter
        '
        Me.DtPkrAfter.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrAfter.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrAfter.Location = New System.Drawing.Point(432, 7)
        Me.DtPkrAfter.Name = "DtPkrAfter"
        Me.DtPkrAfter.Size = New System.Drawing.Size(95, 20)
        Me.DtPkrAfter.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(323, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Show Log after date"
        '
        'CmbTransactionType
        '
        Me.CmbTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTransactionType.FormattingEnabled = True
        Me.CmbTransactionType.Location = New System.Drawing.Point(135, 6)
        Me.CmbTransactionType.Name = "CmbTransactionType"
        Me.CmbTransactionType.Size = New System.Drawing.Size(182, 21)
        Me.CmbTransactionType.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select Transaction Type"
        '
        'TabLogDetail
        '
        Me.TabLogDetail.BackColor = System.Drawing.SystemColors.Control
        Me.TabLogDetail.Controls.Add(Me.GrdLogDetail)
        Me.TabLogDetail.Location = New System.Drawing.Point(4, 22)
        Me.TabLogDetail.Name = "TabLogDetail"
        Me.TabLogDetail.Padding = New System.Windows.Forms.Padding(3)
        Me.TabLogDetail.Size = New System.Drawing.Size(818, 524)
        Me.TabLogDetail.TabIndex = 1
        Me.TabLogDetail.Text = "Detail Records"
        '
        'GrdLogDetail
        '
        Me.GrdLogDetail.AllowUserToAddRows = False
        Me.GrdLogDetail.AllowUserToDeleteRows = False
        Me.GrdLogDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdLogDetail.Location = New System.Drawing.Point(8, 6)
        Me.GrdLogDetail.Name = "GrdLogDetail"
        Me.GrdLogDetail.ReadOnly = True
        Me.GrdLogDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdLogDetail.Size = New System.Drawing.Size(803, 512)
        Me.GrdLogDetail.TabIndex = 6
        '
        'FrmTrackLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(850, 605)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabLog)
        Me.Controls.Add(Me.BtnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTrackLog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Check Log"
        Me.TabLog.ResumeLayout(False)
        Me.TabLogMaster.ResumeLayout(False)
        Me.TabLogMaster.PerformLayout()
        CType(Me.GrdMasterLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabLogDetail.ResumeLayout(False)
        CType(Me.GrdLogDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents TabLog As System.Windows.Forms.TabControl
    Friend WithEvents TabLogMaster As System.Windows.Forms.TabPage
    Friend WithEvents TabLogDetail As System.Windows.Forms.TabPage
    Friend WithEvents CmbTransactionType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnShow As System.Windows.Forms.Button
    Friend WithEvents DtPkrAfter As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GrdMasterLog As System.Windows.Forms.DataGridView
    Friend WithEvents GrdLogDetail As System.Windows.Forms.DataGridView

End Class
