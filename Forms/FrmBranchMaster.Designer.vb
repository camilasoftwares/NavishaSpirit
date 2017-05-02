<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBranchMaster
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
        Me.GrpBranch = New System.Windows.Forms.GroupBox
        Me.TxtBranchCode = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtTinNo = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtUpttNo = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtEmail = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtFax = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtPhone = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtContactPerson = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtPin = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtState = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtCity = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtAddress = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpBranchDetails = New System.Windows.Forms.GroupBox
        Me.GrdBranchDetails = New System.Windows.Forms.DataGridView
        Me.GrpButton.SuspendLayout()
        Me.GrpBranch.SuspendLayout()
        Me.GrpBranchDetails.SuspendLayout()
        CType(Me.GrdBranchDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpButton
        '
        Me.GrpButton.Controls.Add(Me.BtnCancel)
        Me.GrpButton.Controls.Add(Me.BtnUpdate)
        Me.GrpButton.Controls.Add(Me.BtnClose)
        Me.GrpButton.Controls.Add(Me.BtnAdd)
        Me.GrpButton.Location = New System.Drawing.Point(888, 12)
        Me.GrpButton.Name = "GrpButton"
        Me.GrpButton.Size = New System.Drawing.Size(103, 158)
        Me.GrpButton.TabIndex = 3
        Me.GrpButton.TabStop = False
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(15, 83)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(72, 26)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "Cance&l"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(15, 51)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(72, 26)
        Me.BtnUpdate.TabIndex = 2
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(15, 115)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(15, 19)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(72, 26)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'GrpBranch
        '
        Me.GrpBranch.Controls.Add(Me.TxtBranchCode)
        Me.GrpBranch.Controls.Add(Me.Label14)
        Me.GrpBranch.Controls.Add(Me.TxtTinNo)
        Me.GrpBranch.Controls.Add(Me.Label13)
        Me.GrpBranch.Controls.Add(Me.TxtUpttNo)
        Me.GrpBranch.Controls.Add(Me.Label10)
        Me.GrpBranch.Controls.Add(Me.TxtEmail)
        Me.GrpBranch.Controls.Add(Me.Label9)
        Me.GrpBranch.Controls.Add(Me.TxtFax)
        Me.GrpBranch.Controls.Add(Me.Label8)
        Me.GrpBranch.Controls.Add(Me.TxtPhone)
        Me.GrpBranch.Controls.Add(Me.Label7)
        Me.GrpBranch.Controls.Add(Me.TxtContactPerson)
        Me.GrpBranch.Controls.Add(Me.Label6)
        Me.GrpBranch.Controls.Add(Me.TxtPin)
        Me.GrpBranch.Controls.Add(Me.Label5)
        Me.GrpBranch.Controls.Add(Me.TxtState)
        Me.GrpBranch.Controls.Add(Me.Label4)
        Me.GrpBranch.Controls.Add(Me.TxtCity)
        Me.GrpBranch.Controls.Add(Me.Label3)
        Me.GrpBranch.Controls.Add(Me.TxtAddress)
        Me.GrpBranch.Controls.Add(Me.Label2)
        Me.GrpBranch.Controls.Add(Me.TxtName)
        Me.GrpBranch.Controls.Add(Me.Label1)
        Me.GrpBranch.Location = New System.Drawing.Point(12, 12)
        Me.GrpBranch.Name = "GrpBranch"
        Me.GrpBranch.Size = New System.Drawing.Size(870, 158)
        Me.GrpBranch.TabIndex = 2
        Me.GrpBranch.TabStop = False
        Me.GrpBranch.Text = "Branch"
        '
        'TxtBranchCode
        '
        Me.TxtBranchCode.BackColor = System.Drawing.Color.White
        Me.TxtBranchCode.Enabled = False
        Me.TxtBranchCode.Location = New System.Drawing.Point(88, 19)
        Me.TxtBranchCode.Name = "TxtBranchCode"
        Me.TxtBranchCode.ReadOnly = True
        Me.TxtBranchCode.Size = New System.Drawing.Size(92, 20)
        Me.TxtBranchCode.TabIndex = 27
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(69, 13)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Branch Code"
        '
        'TxtTinNo
        '
        Me.TxtTinNo.Location = New System.Drawing.Point(426, 126)
        Me.TxtTinNo.Name = "TxtTinNo"
        Me.TxtTinNo.Size = New System.Drawing.Size(284, 20)
        Me.TxtTinNo.TabIndex = 25
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(378, 129)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Tin No."
        '
        'TxtUpttNo
        '
        Me.TxtUpttNo.Location = New System.Drawing.Point(88, 123)
        Me.TxtUpttNo.Name = "TxtUpttNo"
        Me.TxtUpttNo.Size = New System.Drawing.Size(284, 20)
        Me.TxtUpttNo.TabIndex = 19
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 126)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "S.T. No."
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(602, 97)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(256, 20)
        Me.TxtEmail.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(515, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "E-Mail"
        '
        'TxtFax
        '
        Me.TxtFax.Location = New System.Drawing.Point(330, 97)
        Me.TxtFax.Name = "TxtFax"
        Me.TxtFax.Size = New System.Drawing.Size(179, 20)
        Me.TxtFax.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(273, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Fax No."
        '
        'TxtPhone
        '
        Me.TxtPhone.Location = New System.Drawing.Point(88, 97)
        Me.TxtPhone.Name = "TxtPhone"
        Me.TxtPhone.Size = New System.Drawing.Size(179, 20)
        Me.TxtPhone.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Phone No."
        '
        'TxtContactPerson
        '
        Me.TxtContactPerson.Location = New System.Drawing.Point(602, 71)
        Me.TxtContactPerson.Name = "TxtContactPerson"
        Me.TxtContactPerson.Size = New System.Drawing.Size(256, 20)
        Me.TxtContactPerson.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(515, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Contact Person"
        '
        'TxtPin
        '
        Me.TxtPin.Location = New System.Drawing.Point(406, 71)
        Me.TxtPin.Name = "TxtPin"
        Me.TxtPin.Size = New System.Drawing.Size(103, 20)
        Me.TxtPin.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(378, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Pin"
        '
        'TxtState
        '
        Me.TxtState.Location = New System.Drawing.Point(252, 71)
        Me.TxtState.Name = "TxtState"
        Me.TxtState.Size = New System.Drawing.Size(120, 20)
        Me.TxtState.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(214, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "State"
        '
        'TxtCity
        '
        Me.TxtCity.Location = New System.Drawing.Point(88, 71)
        Me.TxtCity.Name = "TxtCity"
        Me.TxtCity.Size = New System.Drawing.Size(120, 20)
        Me.TxtCity.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "City*"
        '
        'TxtAddress
        '
        Me.TxtAddress.Location = New System.Drawing.Point(437, 45)
        Me.TxtAddress.Name = "TxtAddress"
        Me.TxtAddress.Size = New System.Drawing.Size(421, 20)
        Me.TxtAddress.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(335, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Complete Address*"
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(88, 45)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(241, 20)
        Me.TxtName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Branch Name*"
        '
        'GrpBranchDetails
        '
        Me.GrpBranchDetails.Controls.Add(Me.GrdBranchDetails)
        Me.GrpBranchDetails.Location = New System.Drawing.Point(16, 176)
        Me.GrpBranchDetails.Name = "GrpBranchDetails"
        Me.GrpBranchDetails.Size = New System.Drawing.Size(975, 315)
        Me.GrpBranchDetails.TabIndex = 4
        Me.GrpBranchDetails.TabStop = False
        Me.GrpBranchDetails.Text = "Branch Details"
        '
        'GrdBranchDetails
        '
        Me.GrdBranchDetails.AllowUserToAddRows = False
        Me.GrdBranchDetails.AllowUserToDeleteRows = False
        Me.GrdBranchDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdBranchDetails.Location = New System.Drawing.Point(7, 19)
        Me.GrdBranchDetails.Name = "GrdBranchDetails"
        Me.GrdBranchDetails.ReadOnly = True
        Me.GrdBranchDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdBranchDetails.Size = New System.Drawing.Size(962, 290)
        Me.GrdBranchDetails.TabIndex = 5
        '
        'FrmBranchMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(1003, 503)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpBranchDetails)
        Me.Controls.Add(Me.GrpButton)
        Me.Controls.Add(Me.GrpBranch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBranchMaster"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Branch Master"
        Me.GrpButton.ResumeLayout(False)
        Me.GrpBranch.ResumeLayout(False)
        Me.GrpBranch.PerformLayout()
        Me.GrpBranchDetails.ResumeLayout(False)
        CType(Me.GrdBranchDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpButton As System.Windows.Forms.GroupBox
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents GrpBranch As System.Windows.Forms.GroupBox
    Friend WithEvents TxtTinNo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtUpttNo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtFax As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtContactPerson As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtPin As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtState As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCity As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtBranchCode As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents GrpBranchDetails As System.Windows.Forms.GroupBox
    Friend WithEvents GrdBranchDetails As System.Windows.Forms.DataGridView

End Class
