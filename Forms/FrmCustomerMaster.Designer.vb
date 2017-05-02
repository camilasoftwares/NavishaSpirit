<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCustomerMaster
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
        Me.GrpCustomerDetails = New System.Windows.Forms.GroupBox
        Me.GrdCustomerDetails = New System.Windows.Forms.DataGridView
        Me.GrpButton = New System.Windows.Forms.GroupBox
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.GrpCustomer = New System.Windows.Forms.GroupBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.CmbHQ = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.CmbTax = New System.Windows.Forms.ComboBox
        Me.TxtDueDays = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.CmbCustomerType = New System.Windows.Forms.ComboBox
        Me.TxtCustomerCode = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtTinNo = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtUpttNo = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtEmail = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtPhoneO = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtPhoneR = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtMobile = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtPin = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtCity = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtAddress = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpSearch = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.CmbFieldToSearch = New System.Windows.Forms.ComboBox
        Me.TxtLikeValue = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GrpCustomerDetails.SuspendLayout()
        CType(Me.GrdCustomerDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpButton.SuspendLayout()
        Me.GrpCustomer.SuspendLayout()
        Me.GrpSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpCustomerDetails
        '
        Me.GrpCustomerDetails.Controls.Add(Me.GrdCustomerDetails)
        Me.GrpCustomerDetails.Location = New System.Drawing.Point(12, 253)
        Me.GrpCustomerDetails.Name = "GrpCustomerDetails"
        Me.GrpCustomerDetails.Size = New System.Drawing.Size(823, 301)
        Me.GrpCustomerDetails.TabIndex = 7
        Me.GrpCustomerDetails.TabStop = False
        Me.GrpCustomerDetails.Text = "Customer Details"
        '
        'GrdCustomerDetails
        '
        Me.GrdCustomerDetails.AllowUserToAddRows = False
        Me.GrdCustomerDetails.AllowUserToDeleteRows = False
        Me.GrdCustomerDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdCustomerDetails.Location = New System.Drawing.Point(7, 19)
        Me.GrdCustomerDetails.Name = "GrdCustomerDetails"
        Me.GrdCustomerDetails.ReadOnly = True
        Me.GrdCustomerDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdCustomerDetails.Size = New System.Drawing.Size(801, 276)
        Me.GrdCustomerDetails.TabIndex = 5
        '
        'GrpButton
        '
        Me.GrpButton.Controls.Add(Me.BtnCancel)
        Me.GrpButton.Controls.Add(Me.BtnUpdate)
        Me.GrpButton.Controls.Add(Me.BtnClose)
        Me.GrpButton.Controls.Add(Me.BtnAdd)
        Me.GrpButton.Location = New System.Drawing.Point(732, 12)
        Me.GrpButton.Name = "GrpButton"
        Me.GrpButton.Size = New System.Drawing.Size(103, 179)
        Me.GrpButton.TabIndex = 6
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
        'GrpCustomer
        '
        Me.GrpCustomer.Controls.Add(Me.Label19)
        Me.GrpCustomer.Controls.Add(Me.CmbHQ)
        Me.GrpCustomer.Controls.Add(Me.Label18)
        Me.GrpCustomer.Controls.Add(Me.CmbTax)
        Me.GrpCustomer.Controls.Add(Me.TxtDueDays)
        Me.GrpCustomer.Controls.Add(Me.Label17)
        Me.GrpCustomer.Controls.Add(Me.Label15)
        Me.GrpCustomer.Controls.Add(Me.CmbCustomerType)
        Me.GrpCustomer.Controls.Add(Me.TxtCustomerCode)
        Me.GrpCustomer.Controls.Add(Me.Label14)
        Me.GrpCustomer.Controls.Add(Me.TxtTinNo)
        Me.GrpCustomer.Controls.Add(Me.Label13)
        Me.GrpCustomer.Controls.Add(Me.TxtUpttNo)
        Me.GrpCustomer.Controls.Add(Me.Label10)
        Me.GrpCustomer.Controls.Add(Me.TxtEmail)
        Me.GrpCustomer.Controls.Add(Me.Label9)
        Me.GrpCustomer.Controls.Add(Me.TxtPhoneO)
        Me.GrpCustomer.Controls.Add(Me.Label8)
        Me.GrpCustomer.Controls.Add(Me.TxtPhoneR)
        Me.GrpCustomer.Controls.Add(Me.Label7)
        Me.GrpCustomer.Controls.Add(Me.TxtMobile)
        Me.GrpCustomer.Controls.Add(Me.Label6)
        Me.GrpCustomer.Controls.Add(Me.TxtPin)
        Me.GrpCustomer.Controls.Add(Me.Label5)
        Me.GrpCustomer.Controls.Add(Me.TxtCity)
        Me.GrpCustomer.Controls.Add(Me.Label3)
        Me.GrpCustomer.Controls.Add(Me.TxtAddress)
        Me.GrpCustomer.Controls.Add(Me.Label2)
        Me.GrpCustomer.Controls.Add(Me.TxtName)
        Me.GrpCustomer.Controls.Add(Me.Label1)
        Me.GrpCustomer.Location = New System.Drawing.Point(12, 12)
        Me.GrpCustomer.Name = "GrpCustomer"
        Me.GrpCustomer.Size = New System.Drawing.Size(714, 179)
        Me.GrpCustomer.TabIndex = 5
        Me.GrpCustomer.TabStop = False
        Me.GrpCustomer.Text = "Customer"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(264, 152)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(66, 13)
        Me.Label19.TabIndex = 43
        Me.Label19.Text = "Headquarter"
        '
        'CmbHQ
        '
        Me.CmbHQ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbHQ.FormattingEnabled = True
        Me.CmbHQ.Location = New System.Drawing.Point(338, 149)
        Me.CmbHQ.Name = "CmbHQ"
        Me.CmbHQ.Size = New System.Drawing.Size(241, 21)
        Me.CmbHQ.Sorted = True
        Me.CmbHQ.TabIndex = 42
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 152)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 13)
        Me.Label18.TabIndex = 41
        Me.Label18.Text = "Tax Type"
        '
        'CmbTax
        '
        Me.CmbTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTax.FormattingEnabled = True
        Me.CmbTax.Location = New System.Drawing.Point(104, 149)
        Me.CmbTax.Name = "CmbTax"
        Me.CmbTax.Size = New System.Drawing.Size(155, 21)
        Me.CmbTax.Sorted = True
        Me.CmbTax.TabIndex = 40
        '
        'TxtDueDays
        '
        Me.TxtDueDays.Location = New System.Drawing.Point(645, 121)
        Me.TxtDueDays.Name = "TxtDueDays"
        Me.TxtDueDays.Size = New System.Drawing.Size(56, 20)
        Me.TxtDueDays.TabIndex = 39
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(585, 124)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(54, 13)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "Due Days"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 74)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 13)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "Customer Type"
        '
        'CmbCustomerType
        '
        Me.CmbCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCustomerType.FormattingEnabled = True
        Me.CmbCustomerType.Location = New System.Drawing.Point(104, 71)
        Me.CmbCustomerType.Name = "CmbCustomerType"
        Me.CmbCustomerType.Size = New System.Drawing.Size(155, 21)
        Me.CmbCustomerType.Sorted = True
        Me.CmbCustomerType.TabIndex = 34
        '
        'TxtCustomerCode
        '
        Me.TxtCustomerCode.BackColor = System.Drawing.Color.White
        Me.TxtCustomerCode.Enabled = False
        Me.TxtCustomerCode.Location = New System.Drawing.Point(104, 19)
        Me.TxtCustomerCode.Name = "TxtCustomerCode"
        Me.TxtCustomerCode.ReadOnly = True
        Me.TxtCustomerCode.Size = New System.Drawing.Size(92, 20)
        Me.TxtCustomerCode.TabIndex = 0
        Me.TxtCustomerCode.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 13)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Customer Code"
        '
        'TxtTinNo
        '
        Me.TxtTinNo.Location = New System.Drawing.Point(308, 123)
        Me.TxtTinNo.Name = "TxtTinNo"
        Me.TxtTinNo.Size = New System.Drawing.Size(271, 20)
        Me.TxtTinNo.TabIndex = 25
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(264, 124)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Tin No."
        '
        'TxtUpttNo
        '
        Me.TxtUpttNo.Location = New System.Drawing.Point(104, 123)
        Me.TxtUpttNo.Name = "TxtUpttNo"
        Me.TxtUpttNo.Size = New System.Drawing.Size(155, 20)
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
        Me.TxtEmail.Location = New System.Drawing.Point(476, 97)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(225, 20)
        Me.TxtEmail.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(422, 101)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "E-Mail Id"
        '
        'TxtPhoneO
        '
        Me.TxtPhoneO.Location = New System.Drawing.Point(104, 97)
        Me.TxtPhoneO.Name = "TxtPhoneO"
        Me.TxtPhoneO.Size = New System.Drawing.Size(155, 20)
        Me.TxtPhoneO.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Phone No.(Off)"
        '
        'TxtPhoneR
        '
        Me.TxtPhoneR.Location = New System.Drawing.Point(549, 70)
        Me.TxtPhoneR.Name = "TxtPhoneR"
        Me.TxtPhoneR.Size = New System.Drawing.Size(152, 20)
        Me.TxtPhoneR.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(423, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Phone Number (Res)"
        '
        'TxtMobile
        '
        Me.TxtMobile.Location = New System.Drawing.Point(308, 97)
        Me.TxtMobile.Name = "TxtMobile"
        Me.TxtMobile.Size = New System.Drawing.Size(107, 20)
        Me.TxtMobile.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(264, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Mobile"
        '
        'TxtPin
        '
        Me.TxtPin.Location = New System.Drawing.Point(308, 70)
        Me.TxtPin.Name = "TxtPin"
        Me.TxtPin.Size = New System.Drawing.Size(107, 20)
        Me.TxtPin.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(265, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Pin "
        '
        'TxtCity
        '
        Me.TxtCity.Location = New System.Drawing.Point(569, 45)
        Me.TxtCity.Name = "TxtCity"
        Me.TxtCity.Size = New System.Drawing.Size(132, 20)
        Me.TxtCity.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(535, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "City*"
        '
        'TxtAddress
        '
        Me.TxtAddress.Location = New System.Drawing.Point(104, 45)
        Me.TxtAddress.Name = "TxtAddress"
        Me.TxtAddress.Size = New System.Drawing.Size(425, 20)
        Me.TxtAddress.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Complete Address*"
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(308, 19)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(393, 20)
        Me.TxtName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(216, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer Name*"
        '
        'GrpSearch
        '
        Me.GrpSearch.Controls.Add(Me.Label12)
        Me.GrpSearch.Controls.Add(Me.CmbFieldToSearch)
        Me.GrpSearch.Controls.Add(Me.TxtLikeValue)
        Me.GrpSearch.Controls.Add(Me.Label4)
        Me.GrpSearch.Location = New System.Drawing.Point(12, 197)
        Me.GrpSearch.Name = "GrpSearch"
        Me.GrpSearch.Size = New System.Drawing.Size(823, 50)
        Me.GrpSearch.TabIndex = 8
        Me.GrpSearch.TabStop = False
        Me.GrpSearch.Text = "Search By"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(459, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Search In"
        '
        'CmbFieldToSearch
        '
        Me.CmbFieldToSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbFieldToSearch.FormattingEnabled = True
        Me.CmbFieldToSearch.Location = New System.Drawing.Point(518, 19)
        Me.CmbFieldToSearch.Name = "CmbFieldToSearch"
        Me.CmbFieldToSearch.Size = New System.Drawing.Size(121, 21)
        Me.CmbFieldToSearch.Sorted = True
        Me.CmbFieldToSearch.TabIndex = 32
        '
        'TxtLikeValue
        '
        Me.TxtLikeValue.Location = New System.Drawing.Point(720, 19)
        Me.TxtLikeValue.Name = "TxtLikeValue"
        Me.TxtLikeValue.Size = New System.Drawing.Size(88, 20)
        Me.TxtLikeValue.TabIndex = 31
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(645, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Starting From"
        '
        'FrmCustomerMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(849, 566)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpSearch)
        Me.Controls.Add(Me.GrpCustomerDetails)
        Me.Controls.Add(Me.GrpButton)
        Me.Controls.Add(Me.GrpCustomer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCustomerMaster"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Customer Master"
        Me.GrpCustomerDetails.ResumeLayout(False)
        CType(Me.GrdCustomerDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpButton.ResumeLayout(False)
        Me.GrpCustomer.ResumeLayout(False)
        Me.GrpCustomer.PerformLayout()
        Me.GrpSearch.ResumeLayout(False)
        Me.GrpSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpCustomerDetails As System.Windows.Forms.GroupBox
    Friend WithEvents GrdCustomerDetails As System.Windows.Forms.DataGridView
    Friend WithEvents GrpButton As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents GrpCustomer As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtTinNo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtUpttNo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtPhoneO As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtPhoneR As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtMobile As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtPin As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCity As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents TxtLikeValue As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbFieldToSearch As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CmbCustomerType As System.Windows.Forms.ComboBox
    Friend WithEvents TxtDueDays As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents CmbHQ As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CmbTax As System.Windows.Forms.ComboBox

End Class
