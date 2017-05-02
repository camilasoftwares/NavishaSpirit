<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDailyTransaction
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
        Me.components = New System.ComponentModel.Container()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dgvDailyTransaction = New System.Windows.Forms.DataGridView()
        Me.ClsDailyTransactionSheetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dgvDailyTransaction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClsDailyTransactionSheetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(938, 651)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "&Cancel"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dgvDailyTransaction
        '
        Me.dgvDailyTransaction.AllowUserToAddRows = False
        Me.dgvDailyTransaction.AllowUserToDeleteRows = False
        Me.dgvDailyTransaction.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDailyTransaction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDailyTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDailyTransaction.Location = New System.Drawing.Point(12, 12)
        Me.dgvDailyTransaction.Name = "dgvDailyTransaction"
        Me.dgvDailyTransaction.Size = New System.Drawing.Size(1002, 332)
        Me.dgvDailyTransaction.TabIndex = 1
        '
        'ClsDailyTransactionSheetBindingSource
        '
        Me.ClsDailyTransactionSheetBindingSource.DataSource = GetType(AIMS.ClsDailyTransactionSheet)
        '
        'frmDailyTransaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1026, 685)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvDailyTransaction)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDailyTransaction"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Daily Transaction"
        CType(Me.dgvDailyTransaction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClsDailyTransactionSheetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnClose As Button
    Friend WithEvents dgvDailyTransaction As DataGridView
    Friend WithEvents ClsDailyTransactionSheetBindingSource As BindingSource
End Class
