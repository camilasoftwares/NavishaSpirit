Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmCustomerMaster

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim flagChange As Boolean = False

    'Private Const lcCardNo As String = "Card No"
    Private Const lcName As String = "Name"
    Private Const lcAddress As String = "Address"
    Private Const lcCity As String = "City"
    Private Const lcMobile As String = "Mobile"
    Private Const lcPhoneR As String = "Phone Res."
    Private Const lcPhoneO As String = "Phone Off."
    Private Const lcGeneral As String = "General"

    Enum Index
        GrpCustomer = 0
        TxtCustomerCode
        TxtName
        TxtAddress
        TxtCity
        CmbCustomerType
        TxtPin
        TxtPhoneR
        TxtPhoneO
        TxtMobile
        TxtEmail
        TxtUpttNo
        TxtTinNo
        TxtDueDays
        CmbTax
        CmbHQ
        GrpButton
        BtnAdd
        BtnUpdate
        BtnCancel
        BtnClose
        GrpSearch
        CmbFieldToSearch
        TxtLikeValue
        GrpCustomerDetails
        GrdCustomerDetails
    End Enum

#End Region

#Region "Control Functions"

    Private Sub Help(ByVal sender As Object, ByVal hlpEvent As System.Windows.Forms.HelpEventArgs) Handles MyBase.HelpRequested
        Try
            Dim obj As Object = Me.Owner
            obj.ShowHelp()
        Catch ex As Exception
        End Try

        hlpEvent.Handled = True
    End Sub

    Private Sub FrmCustomerMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub GrdCustomerDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdCustomerDetails.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.Customers_NoUpdate) = True Then Exit Sub

            editRow = GrdCustomerDetails.Rows(e.RowIndex)
            With editRow
                TxtCustomerCode.Text = .Cells(cAccountId).Value
                TxtName.Text = .Cells(cName).Value
                TxtAddress.Text = .Cells(cAddress).Value
                CmbCustomerType.Text = .Cells(cCustomerType).Value
                TxtCity.Text = .Cells(cCity).Value
                TxtPin.Text = .Cells(cPin).Value
                'TxtCardNo.Text = .Cells(cCardNo).Value
                TxtMobile.Text = .Cells(cMobile).Value
                TxtPhoneR.Text = .Cells(cPhoneR).Value
                TxtPhoneO.Text = .Cells(cPhoneO).Value
                TxtEmail.Text = .Cells(cEmail).Value
                TxtUpttNo.Text = .Cells(cUpTtNo).Value
                TxtTinNo.Text = .Cells(cTinNo).Value
                'TxtDLNo.Text = .Cells(cDlNo).Value
                TxtDueDays.Text = .Cells(cDueDays).Value
                CmbTax.Text = GetTaxName(.Cells(cTaxId).Value)
                CmbHQ.Text = GetHQName(.Cells(cHQId).Value)
            End With

            BtnAdd.Enabled = False
            BtnUpdate.Enabled = True
            BtnCancel.Enabled = True
            GrpSearch.Enabled = False

            'TxtCardNo.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdCustomerDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdCustomerDetails.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub CmbFieldToSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFieldToSearch.SelectedIndexChanged
        TxtLikeValue.Text = ""
    End Sub

    Private Sub TxtLikeValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLikeValue.TextChanged
        Dim valueLike As String = TxtLikeValue.Text.Trim
        If valueLike = "" Then
            LoadGridValues()
        Else
            LoadGridValuesWithSearchLike(valueLike)
        End If
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.Customers_NoAdd) = True Then Exit Sub
            If ValidateValues() = False Then Exit Sub

            Dim customer As New ClsCustomerMaster
            With customer
                .AccountId = TxtCustomerCode.Text
                .Name = TxtName.Text
                .Address = TxtAddress.Text
                .City = TxtCity.Text
                .Pin = TxtPin.Text
                '.CardNo = TxtCardNo.Text
                .CustomerTypeId = GetSelectedItemId(CmbCustomerType)
                .DueDays = Val(TxtDueDays.Text)
                .Mobile = TxtMobile.Text
                .PhoneR = TxtPhoneR.Text
                .PhoneO = TxtPhoneO.Text
                .EMail = TxtEmail.Text
                .UpTtNo = TxtUpttNo.Text
                .TinNo = TxtTinNo.Text
                '.DlNo = TxtDLNo.Text
                .UserId = gUser.LoginName
                .DateOn = Now
                .TaxId = GetSelectedItemId(CmbTax)
                .HQId = GetSelectedItemId(CmbHQ)
            End With

            If InsertIntoCustomerMaster(Me.Name, customer) > 0 Then
                LoadGridValues()
                flagChange = True
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.Customers_NoUpdate) = True Then Exit Sub
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim customer As New ClsCustomerMaster
            With customer
                .Id = editRow.Cells(cId).Value
                .UserId = editRow.Cells(cUserId).Value
                .DateOn = editRow.Cells(cDateOn).Value
                .AccountId = TxtCustomerCode.Text
                .Name = TxtName.Text
                .Address = TxtAddress.Text
                .City = TxtCity.Text
                .Pin = TxtPin.Text
                '.CardNo = TxtCardNo.Text
                .CustomerTypeId = GetSelectedItemId(CmbCustomerType)
                .DueDays = Val(TxtDueDays.Text)
                .Mobile = TxtMobile.Text
                .PhoneR = TxtPhoneR.Text
                .PhoneO = TxtPhoneO.Text
                .EMail = TxtEmail.Text
                .UpTtNo = TxtUpttNo.Text
                .TinNo = TxtTinNo.Text
                '.DlNo = TxtDLNo.Text
                .TaxId = GetSelectedItemId(CmbTax)
                .HQId = GetSelectedItemId(CmbHQ)
            End With

            If UpdateCustomerMaster(Me.Name, customer) <> EnResult.Change Then Exit Sub

            flagChange = True
            With editRow
                .Cells(cAccountId).Value = TxtCustomerCode.Text
                .Cells(cName).Value = TxtName.Text
                .Cells(cAddress).Value = TxtAddress.Text
                .Cells(cCity).Value = TxtCity.Text
                .Cells(cPin).Value = TxtPin.Text
                '.Cells(cCardNo).Value = TxtCardNo.Text
                .Cells(cMobile).Value = TxtMobile.Text
                .Cells(cPhoneR).Value = TxtPhoneR.Text
                .Cells(cPhoneO).Value = TxtPhoneO.Text
                .Cells(cEmail).Value = TxtEmail.Text
                .Cells(cUpTtNo).Value = TxtUpttNo.Text
                .Cells(cTinNo).Value = TxtTinNo.Text
                '.Cells(cDlNo).Value = TxtDLNo.Text
                .Cells(cDueDays).Value = Val(TxtDueDays.Text)
                .Cells(cCustomerTypeId).Value = customer.CustomerTypeId
                .Cells(cCustomerType).Value = GetCustomerType(.Cells(cCustomerTypeId).Value)
                .Cells(cTaxId).Value = customer.TaxId
                .Cells(cTaxName).Value = GetTaxName(.Cells(cTaxId).Value)
                .Cells(cHQId).Value = customer.HQId
                .Cells(cHeadQuarter).Value = GetHQName(.Cells(cHQId).Value)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        ResetControlsToAddNew()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TxtPin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPin.KeyPress
        e.Handled = Check_Numeric(e.KeyChar)
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUpttNo.KeyDown, TxtTinNo.KeyDown, TxtPin.KeyDown, TxtPhoneR.KeyDown, TxtPhoneO.KeyDown, TxtName.KeyDown, TxtMobile.KeyDown, TxtLikeValue.KeyDown, TxtEmail.KeyDown, TxtCustomerCode.KeyDown, TxtCity.KeyDown, TxtAddress.KeyDown, CmbFieldToSearch.KeyDown, CmbCustomerType.KeyDown, TxtDueDays.KeyDown, CmbTax.KeyDown, CmbHQ.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub TxtDueDays_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDueDays.KeyPress
        e.Handled = Check_Numeric(e.KeyChar)
    End Sub

#End Region

#Region "Public Functions"

    Public Function Change() As Boolean
        Return flagChange
    End Function

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        With CmbFieldToSearch
            .Items.Clear()
            '.Items.Add(lcCardNo)
            .Items.Add(lcName)
            .Items.Add(lcAddress)
            .Items.Add(lcCity)
            .Items.Add(lcMobile)
            .Items.Add(lcPhoneR)
            .Items.Add(lcPhoneO)
            .SelectedIndex = 0
        End With

        SetTabIndex()
        SetGrid()
        LoadComboBoxValuesForCustomerType()
        LoadComboBoxValuesForTax()
        LoadComboBoxValuesForHQ()
        LoadGridValues()

        ResetControlsToAddNew()
    End Sub

    Private Sub SetTabIndex()
        GrpCustomer.TabIndex = Index.GrpCustomer
        TxtCustomerCode.TabIndex = Index.TxtCustomerCode
        'TxtCardNo.TabIndex = Index.TxtCardNo
        TxtName.TabIndex = Index.TxtName
        TxtAddress.TabIndex = Index.TxtAddress
        TxtCity.TabIndex = Index.TxtCity
        CmbCustomerType.TabIndex = Index.CmbCustomerType
        TxtPin.TabIndex = Index.TxtPin
        TxtMobile.TabIndex = Index.TxtMobile
        TxtPhoneR.TabIndex = Index.TxtPhoneR
        TxtPhoneO.TabIndex = Index.TxtPhoneO
        TxtEmail.TabIndex = Index.TxtEmail
        TxtUpttNo.TabIndex = Index.TxtUpttNo
        TxtTinNo.TabIndex = Index.TxtTinNo
        TxtDueDays.TabIndex = Index.TxtDueDays
        'TxtDLNo.TabIndex = Index.TxtDLNo
        GrpButton.TabIndex = Index.GrpButton
        BtnAdd.TabIndex = Index.BtnAdd
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
        GrpSearch.TabIndex = Index.GrpSearch
        CmbFieldToSearch.TabIndex = Index.CmbFieldToSearch
        TxtLikeValue.TabIndex = Index.TxtLikeValue
        GrpCustomerDetails.TabIndex = Index.GrpCustomerDetails
        GrdCustomerDetails.TabIndex = Index.GrdCustomerDetails
        CmbTax.TabIndex = Index.CmbTax
        CmbHQ.TabIndex = Index.CmbHQ
    End Sub

    Private Sub SetGrid()
        With GrdCustomerDetails
            Dim colCount As Integer = 20
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 120
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cAccountId, "C. Code")
                        .Columns(index).Width = defaultCellWidth - 50

                    Case 2
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Width = defaultCellWidth + 40

                    Case 3
                        Dim index As Integer = .Columns.Add(cCustomerTypeId, cCustomerTypeId)
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cCustomerType, "Type")
                        .Columns(index).Width = 80

                    Case 5
                        Dim index As Integer = .Columns.Add(cAddress, cAddress)
                        .Columns(index).Width = defaultCellWidth + 80

                    Case 6
                        Dim index As Integer = .Columns.Add(cCity, cCity)
                        .Columns(index).Width = defaultCellWidth - 30

                    Case 7
                        Dim index As Integer = .Columns.Add(cPin, cPin)
                        .Columns(index).Width = defaultCellWidth - 30

                    Case 8
                        Dim index As Integer = .Columns.Add(cMobile, cMobile)
                        .Columns(index).Width = defaultCellWidth

                    Case 9
                        Dim index As Integer = .Columns.Add(cPhoneR, cPhoneR)
                        .Columns(index).Width = defaultCellWidth

                    Case 10
                        Dim index As Integer = .Columns.Add(cPhoneO, cPhoneO)
                        .Columns(index).Width = defaultCellWidth

                    Case 11
                        Dim index As Integer = .Columns.Add(cEmail, "E-Mail")
                        .Columns(index).Width = defaultCellWidth

                    Case 12
                        Dim index As Integer = .Columns.Add(cUpTtNo, "S.T. No.")
                        .Columns(index).Width = defaultCellWidth

                    Case 13
                        Dim index As Integer = .Columns.Add(cTinNo, "Tin No.")
                        .Columns(index).Width = defaultCellWidth

                    Case 14
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                    Case 15
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 16
                        Dim index As Integer = .Columns.Add(cDueDays, "Due Days")
                        .Columns(index).Width = defaultCellWidth - 30

                    Case 17
                        Dim index As Integer = .Columns.Add(cTaxId, cTaxId)
                        .Columns(index).Visible = False

                    Case 18
                        Dim index As Integer = .Columns.Add(cTaxName, "Tax")
                        .Columns(index).Width = defaultCellWidth

                    Case 19
                        Dim index As Integer = .Columns.Add(cHQId, cHQId)
                        .Columns(index).Visible = False

                    Case 20
                        Dim index As Integer = .Columns.Add(cHeadQuarter, "HQ")
                        .Columns(index).Width = defaultCellWidth

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValues()
        Try
            GrdCustomerDetails.Rows.Clear()
            Dim customers() As ClsCustomerMaster = GetAllCustomerMaster(Me.Name)
            If customers Is Nothing Then Exit Try

            Dim customer As ClsCustomerMaster
            For Each customer In customers
                InsertIntoGrid(customer)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadGridValuesWithSearchLike(ByVal txtLike As String)
        Try
            GrdCustomerDetails.Rows.Clear()
            Dim field As String = ""
            If CmbFieldToSearch.Text = lcAddress Then
                field = cAddress
                'ElseIf CmbFieldToSearch.Text = lcCardNo Then
                '    field = cCardNo
            ElseIf CmbFieldToSearch.Text = lcName Then
                field = cName
            ElseIf CmbFieldToSearch.Text = lcCity Then
                field = cCity
            ElseIf CmbFieldToSearch.Text = lcMobile Then
                field = cMobile
            ElseIf CmbFieldToSearch.Text = lcPhoneR Then
                field = cPhoneR
            ElseIf CmbFieldToSearch.Text = lcPhoneO Then
                field = cPhoneO
            End If

            Dim customers() As ClsCustomerMaster = GetAllCustomerMasterLike(Me.Name, field, txtLike)
            If customers Is Nothing Then Exit Try

            Dim customer As ClsCustomerMaster
            For Each customer In customers
                InsertIntoGrid(customer)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef customerObj As ClsCustomerMaster)
        Try
            If customerObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdCustomerDetails.Rows.Add
            With GrdCustomerDetails.Rows(rowIndex)
                .Cells(cId).Value = customerObj.Id
                .Cells(cAccountId).Value = customerObj.AccountId
                .Cells(cName).Value = customerObj.Name
                .Cells(cAddress).Value = customerObj.Address
                .Cells(cCity).Value = customerObj.City
                .Cells(cPin).Value = customerObj.Pin
                '.Cells(cCardNo).Value = customerObj.CardNo
                .Cells(cCustomerTypeId).Value = customerObj.CustomerTypeId
                .Cells(cCustomerType).Value = GetCustomerType(.Cells(cCustomerTypeId).Value)
                .Cells(cDueDays).Value = customerObj.DueDays
                .Cells(cMobile).Value = customerObj.Mobile
                .Cells(cPhoneR).Value = customerObj.PhoneR
                .Cells(cPhoneO).Value = customerObj.PhoneO
                .Cells(cEmail).Value = customerObj.EMail
                .Cells(cUpTtNo).Value = customerObj.UpTtNo
                .Cells(cTinNo).Value = customerObj.TinNo
                '.Cells(cDlNo).Value = customerObj.DlNo
                .Cells(cUserId).Value = customerObj.UserId
                .Cells(cDateOn).Value = customerObj.DateOn
                .Cells(cTaxId).Value = customerObj.TaxId
                .Cells(cTaxName).Value = GetTaxName(.Cells(cTaxId).Value)
                .Cells(cHQId).Value = customerObj.HQId
                .Cells(cHeadQuarter).Value = GetHQName(.Cells(cHQId).Value)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForCustomerType()
        Try
            CmbCustomerType.Items.Clear()

            Dim customerTypes() As ClsCustomerType = GetAllCustomerTypes(Me.Name)
            If customerTypes Is Nothing Then Exit Try

            For Each customerType As ClsCustomerType In customerTypes
                CmbCustomerType.Items.Add(customerType)
            Next

            Dim customerTypeObj As New ClsCustomerType
            With customerTypeObj
                .Id = cInvalidId
                .Name = lcGeneral
            End With

            CmbCustomerType.Items.Add(customerTypeObj)
            CmbCustomerType.DisplayMember = cName
            CmbCustomerType.ValueMember = cId

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForHQ()
        Try
            CmbHQ.DataSource = Nothing
            CmbHQ.Items.Clear()
            CmbHQ.Text = ""

            Dim hqs() As ClsHQMaster = GetAllHQMaster(Me.Name)

            With CmbHQ
                .DataSource = hqs
                .DisplayMember = cName
                .ValueMember = cId
                If .Items.Count > 0 Then .SelectedIndex = 0
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForTax()
        Try
            CmbTax.DataSource = Nothing
            CmbTax.Items.Clear()
            CmbTax.Text = ""

            Dim taxs() As ClsTaxMaster = GetAllTaxMasters(Me.Name)

            With CmbTax
                .DataSource = taxs
                .DisplayMember = cName
                .ValueMember = cId
                If .Items.Count > 0 Then .SelectedIndex = 0
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If TxtName.Text.Trim = "" Then
                ErrorInData("Please enter customer name.", TxtName)
                Exit Try
            End If

            If TxtAddress.Text.Trim = "" Then
                ErrorInData("Please enter address.", TxtAddress)
                Exit Try
            End If

            If TxtCity.Text.Trim = "" Then
                ErrorInData("Please enter city.", TxtCity)
                Exit Try
            End If

            If TxtEmail.Text.Trim <> "" And CheckEmailAddress(TxtEmail.Text.Trim) = False Then
                ErrorInData("Please enter E-Mail correctly.", TxtEmail)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlsToAddNew()
        If CmbFieldToSearch.Items.Count > 0 Then CmbFieldToSearch.SelectedIndex = 0
        TxtCustomerCode.Text = ""
        TxtName.Text = ""
        TxtAddress.Text = ""
        TxtCity.Text = ""
        'TxtCardNo.Text = ""
        TxtPin.Text = ""
        TxtLikeValue.Text = ""
        TxtPhoneO.Text = ""
        TxtPhoneR.Text = ""
        TxtMobile.Text = ""
        TxtEmail.Text = ""
        TxtUpttNo.Text = ""
        TxtTinNo.Text = ""
        TxtDueDays.Text = ""
        'TxtDLNo.Text = ""
        CmbCustomerType.Text = lcGeneral
        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        GrpSearch.Enabled = True
        RemoveErrorIcon()

        editRow = Nothing

        'TxtCardNo.Focus()
    End Sub

    Private Function GetCustomerType(ByVal id As Integer) As String
        Dim result As String = lcGeneral
        Try
            If id <= 0 Then Exit Try

            For Each customerTypeObj As ClsCustomerType In CmbCustomerType.Items
                If customerTypeObj.Id = id Then
                    result = customerTypeObj.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetTaxName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            If id = cInvalidId Then Exit Try

            For Each tax As ClsTaxMaster In CmbTax.Items
                If tax.Id = id Then
                    result = tax.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetHQName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            If id = cInvalidId Then Exit Try

            For Each hq As ClsHQMaster In CmbHQ.Items
                If hq.Id = id Then
                    result = hq.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

#End Region

End Class
