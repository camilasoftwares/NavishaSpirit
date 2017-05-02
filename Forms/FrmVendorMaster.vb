Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmVendorMaster

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim virtualId As Integer = 0
    Dim flagChange As Boolean = False

    Private Const lcName As String = "Name"
    Private Const lcAddress As String = "Address"
    Private Const lcCity As String = "City"
    Private Const lcMobile As String = "Mobile"
    Private Const lcPhoneR As String = "Phone Res."
    Private Const lcPhoneO As String = "Phone Off."
    Private Const lcDeleted As String = "Deleted"

    Enum Index
        GrpVendor = 0
        TxtVendorCode
        TxtName
        TxtAddress
        TxtCity
        TxtPin
        TxtMobile
        TxtPhoneR
        TxtPhoneO
        TxtEmail
        TxtUpttNo
        TxtTinNo
        GrpManufacturers
        CmbManufacturers
        BtnAdd
        GrdManufacturers
        GrpButton
        BtnSave
        BtnUpdate
        BtnCancel
        BtnClose
        GrpSearch
        CmbFieldToSearch
        TxtLikeValue
        GrpVendorDetail
        GrdVendorDetail
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

    Private Sub FrmVendorMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            RemoveErrorIcon()
            If AndedTheString(gUser.AuthorizationNo, Authorization.Vendors_NoAdd) = True Then Exit Sub

            Dim manufacturer As String = CmbManufacturers.Text.Trim
            If manufacturer = "" Then
                ErrorInData("Please select manufacturer", CmbManufacturers)
                Exit Try
            End If

            Dim row As DataGridViewRow
            For Each row In GrdManufacturers.Rows
                If row.Cells(cManufacturer).Value = manufacturer Then
                    row.Cells(lcDeleted).Value = False
                    row.Visible = True
                    Exit Try
                End If
            Next

            virtualId = virtualId - 1
            Dim vendor As New ClsVendorDetail
            With vendor
                If editRow Is Nothing Then
                    .AccountId = cInvalidId
                Else
                    .AccountId = editRow.Cells(cId).Value
                End If

                .Id = virtualId
                .ManufacturerId = GetSelectedItemId(CmbManufacturers)
            End With

            InsertIntoGridForManufacturer(vendor)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdManufacturers_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdManufacturers.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try

            With GrdManufacturers.Rows(e.RowIndex)
                .Cells(lcDeleted).Value = True
                .Visible = False
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdManufacturers_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdManufacturers.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.Vendors_NoUpdate) = True Then Exit Sub
            If ValidateValues() = False Then Exit Sub

            If Not (GetRowForFieldAndValue(GrdVendorDetail, cName, TxtName.Text.Trim) Is Nothing) Then
                ErrorInData("Name already exist in list", TxtName)
                Exit Sub
            End If

            Dim vendor As New ClsVendorMaster
            With vendor
                .AccountId = TxtVendorCode.Text
                .Name = TxtName.Text
                .Address = TxtAddress.Text
                .City = TxtCity.Text
                .Pin = TxtPin.Text
                .Mobile = TxtMobile.Text
                .PhoneR = TxtPhoneR.Text
                .PhoneO = TxtPhoneO.Text
                .EMail = TxtEmail.Text
                .UpTtNo = TxtUpttNo.Text
                .TinNo = TxtTinNo.Text
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            Dim id As Integer = InsertIntoVendorMaster(Me.Name, vendor)
            If id > 0 Then
                Dim accId As String = GetVendorMasterAccountId(Me.Name, id)
                If accId.Trim <> "" Then
                    ProcessVendorDetail(accId)
                    vendor.Id = id
                    vendor.AccountId = accId

                    InsertIntoGridForVendor(vendor)
                End If

                flagChange = True
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.Vendors_NoUpdate) = True Then Exit Sub
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim vendor As New ClsVendorMaster
            With vendor
                .Id = editRow.Cells(cId).Value
                .UserId = editRow.Cells(cUserId).Value
                .DateOn = editRow.Cells(cDateOn).Value
                .AccountId = TxtVendorCode.Text
                .Name = TxtName.Text
                .Address = TxtAddress.Text
                .City = TxtCity.Text
                .Pin = TxtPin.Text
                .Mobile = TxtMobile.Text
                .PhoneR = TxtPhoneR.Text
                .PhoneO = TxtPhoneO.Text
                .EMail = TxtEmail.Text
                .UpTtNo = TxtUpttNo.Text
                .TinNo = TxtTinNo.Text
            End With

            If VendorMasterUpdatable(Me.Name, vendor) = False Then
                ErrorInData("This name is already exist with other id.", TxtName)
                Exit Sub
            End If

            If UpdateVendorMaster(Me.Name, vendor) <> EnResult.Change Then Exit Sub

            ProcessVendorDetail(TxtVendorCode.Text.Trim)

            flagChange = True
            With editRow
                .Cells(cAccountId).Value = TxtVendorCode.Text
                .Cells(cName).Value = TxtName.Text
                .Cells(cAddress).Value = TxtAddress.Text
                .Cells(cCity).Value = TxtCity.Text
                .Cells(cPin).Value = TxtPin.Text
                .Cells(cMobile).Value = TxtMobile.Text
                .Cells(cPhoneR).Value = TxtPhoneR.Text
                .Cells(cPhoneO).Value = TxtPhoneO.Text
                .Cells(cEmail).Value = TxtEmail.Text
                .Cells(cUpTtNo).Value = TxtUpttNo.Text
                .Cells(cTinNo).Value = TxtTinNo.Text
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

    Private Sub CmbFieldToSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFieldToSearch.SelectedIndexChanged
        TxtLikeValue.Text = ""
    End Sub

    Private Sub TxtLikeValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLikeValue.TextChanged
        Dim valueLike As String = TxtLikeValue.Text.Trim
        If valueLike = "" Then
            LoadGridValuesForVendors()
        Else
            LoadGridValuesWithSearchLike(valueLike)
        End If
    End Sub

    Private Sub GrdVendorDetail_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdVendorDetail.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.Vendors_NoUpdate) = True Then Exit Sub

            editRow = GrdVendorDetail.Rows(e.RowIndex)
            With editRow
                TxtVendorCode.Text = .Cells(cAccountId).Value
                TxtName.Text = .Cells(cName).Value
                TxtAddress.Text = .Cells(cAddress).Value
                TxtCity.Text = .Cells(cCity).Value
                TxtPin.Text = .Cells(cPin).Value
                TxtMobile.Text = .Cells(cMobile).Value
                TxtPhoneR.Text = .Cells(cPhoneR).Value
                TxtPhoneO.Text = .Cells(cPhoneO).Value
                TxtEmail.Text = .Cells(cEmail).Value
                TxtUpttNo.Text = .Cells(cUpTtNo).Value
                TxtTinNo.Text = .Cells(cTinNo).Value

                LoadGridValuesForManufacturer(.Cells(cAccountId).Value)
            End With

            BtnSave.Enabled = False
            BtnUpdate.Enabled = True
            BtnCancel.Enabled = True
            GrpSearch.Enabled = False

            TxtName.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdVendorDetail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdVendorDetail.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub TxtPin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPin.KeyPress
        e.Handled = Check_Numeric(e.KeyChar)
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtVendorCode.KeyDown, TxtUpttNo.KeyDown, TxtTinNo.KeyDown, TxtPin.KeyDown, TxtPhoneR.KeyDown, TxtPhoneO.KeyDown, TxtName.KeyDown, TxtMobile.KeyDown, TxtLikeValue.KeyDown, TxtEmail.KeyDown, TxtCity.KeyDown, TxtAddress.KeyDown, CmbManufacturers.KeyDown, CmbFieldToSearch.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
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
            .Items.Add(lcName)
            .Items.Add(lcAddress)
            .Items.Add(lcCity)
            .Items.Add(lcMobile)
            .Items.Add(lcPhoneR)
            .Items.Add(lcPhoneO)
            .SelectedIndex = 0
        End With

        SetTabIndex()
        SetGridVendors()
        SetGridManufacturers()
        LoadComboBoxValuesForManufacturer()
        LoadGridValuesForVendors()

        ResetControlsToAddNew()
    End Sub

    Private Sub SetTabIndex()
        GrpVendor.TabIndex = Index.GrpVendor
        TxtVendorCode.TabIndex = Index.TxtVendorCode
        TxtName.TabIndex = Index.TxtName
        TxtAddress.TabIndex = Index.TxtAddress
        TxtCity.TabIndex = Index.TxtCity
        TxtPin.TabIndex = Index.TxtPin
        TxtMobile.TabIndex = Index.TxtMobile
        TxtPhoneR.TabIndex = Index.TxtPhoneR
        TxtPhoneO.TabIndex = Index.TxtPhoneO
        TxtEmail.TabIndex = Index.TxtEmail
        TxtUpttNo.TabIndex = Index.TxtUpttNo
        TxtTinNo.TabIndex = Index.TxtTinNo
        GrpManufacturers.TabIndex = Index.GrpManufacturers
        CmbManufacturers.TabIndex = Index.CmbManufacturers
        GrdManufacturers.TabIndex = Index.GrdManufacturers
        BtnSave.TabIndex = Index.BtnSave
        GrpButton.TabIndex = Index.GrpButton
        BtnAdd.TabIndex = Index.BtnAdd
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
        GrpSearch.TabIndex = Index.GrpSearch
        CmbFieldToSearch.TabIndex = Index.CmbFieldToSearch
        TxtLikeValue.TabIndex = Index.TxtLikeValue
        GrpVendorDetail.TabIndex = Index.GrpVendorDetail
        GrdVendorDetail.TabIndex = Index.GrdVendorDetail
    End Sub

    Private Sub SetGridManufacturers()
        With GrdManufacturers
            Dim colCount As Integer = 4
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cAccountId, cAccountId)
                        .Columns(index).Visible = False

                    Case 2
                        Dim index As Integer = .Columns.Add(cManufacturerId, cManufacturerId)
                        .Columns(index).Visible = False

                    Case 3
                        Dim index As Integer = .Columns.Add(cManufacturer, cManufacturer)
                        .Columns(index).Width = 220

                    Case 4
                        Dim index As Integer = .Columns.Add(lcDeleted, lcDeleted)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub SetGridVendors()
        With GrdVendorDetail
            Dim colCount As Integer = 13
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cAccountId, "V. Code")
                        .Columns(index).Width = 70

                    Case 2
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                    Case 3
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Width = 160

                    Case 4
                        Dim index As Integer = .Columns.Add(cAddress, cAddress)
                        .Columns(index).Width = 200

                    Case 5
                        Dim index As Integer = .Columns.Add(cCity, cCity)
                        .Columns(index).Width = 90

                    Case 6
                        Dim index As Integer = .Columns.Add(cPin, cPin)
                        .Columns(index).Width = 90

                    Case 7
                        Dim index As Integer = .Columns.Add(cMobile, cMobile)
                        .Columns(index).Width = 120

                    Case 8
                        Dim index As Integer = .Columns.Add(cPhoneR, "Phone Res.")
                        .Columns(index).Width = 120

                    Case 9
                        Dim index As Integer = .Columns.Add(cPhoneO, "Phone Off.")
                        .Columns(index).Width = 120

                    Case 10
                        Dim index As Integer = .Columns.Add(cEmail, "E-Mail")
                        .Columns(index).Width = 120

                    Case 11
                        Dim index As Integer = .Columns.Add(cUpTtNo, "S.T. No.")
                        .Columns(index).Width = 120

                    Case 12
                        Dim index As Integer = .Columns.Add(cTinNo, "Tin No.")
                        .Columns(index).Width = 120

                    Case 13
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValuesForVendors()
        Try
            GrdVendorDetail.Rows.Clear()
            Dim vendors() As ClsVendorMaster = GetAllVendorMaster(Me.Name)
            If vendors Is Nothing Then Exit Try

            Dim vendor As ClsVendorMaster
            For Each vendor In vendors
                InsertIntoGridForVendor(vendor)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadGridValuesForManufacturer(ByVal accountId As String)
        Try
            GrdManufacturers.Rows.Clear()
            If accountId.Trim = "" Then Exit Try

            Dim vendors() As ClsVendorDetail = GetAllVendorDetailForAccountId(Me.Name, accountId)
            If vendors Is Nothing Then Exit Try

            Dim vendor As ClsVendorDetail
            For Each vendor In vendors
                InsertIntoGridForManufacturer(vendor)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadGridValuesWithSearchLike(ByVal txtLike As String)
        Try
            GrdVendorDetail.Rows.Clear()
            Dim field As String = ""
            If CmbFieldToSearch.Text = lcAddress Then
                field = cAddress
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

            Dim vendors() As ClsVendorMaster = GetAllVendorMasterLike(Me.Name, field, txtLike)
            If vendors Is Nothing Then Exit Try

            Dim vendor As ClsVendorMaster
            For Each vendor In vendors
                InsertIntoGridForVendor(vendor)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForManufacturer()
        Try
            CmbManufacturers.Items.Clear()

            Dim manufacturers() As ClsManufacturerMaster = GetAllManufacturerMaster(Me.Name)
            If manufacturers Is Nothing Then Exit Try

            Dim manufacturer As ClsManufacturerMaster
            For Each manufacturer In manufacturers
                AddItemToComboBox(manufacturer.Name, manufacturer.Id, CmbManufacturers)
            Next

            If CmbManufacturers.Items.Count > 0 Then CmbManufacturers.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGridForVendor(ByRef vendorObj As ClsVendorMaster)
        Try
            If vendorObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdVendorDetail.Rows.Add
            With GrdVendorDetail.Rows(rowIndex)
                .Cells(cId).Value = vendorObj.Id
                .Cells(cAccountId).Value = vendorObj.AccountId
                .Cells(cName).Value = vendorObj.Name
                .Cells(cAddress).Value = vendorObj.Address
                .Cells(cCity).Value = vendorObj.City
                .Cells(cPin).Value = vendorObj.Pin
                .Cells(cMobile).Value = vendorObj.Mobile
                .Cells(cPhoneR).Value = vendorObj.PhoneR
                .Cells(cPhoneO).Value = vendorObj.PhoneO
                .Cells(cEmail).Value = vendorObj.EMail
                .Cells(cUpTtNo).Value = vendorObj.UpTtNo
                .Cells(cTinNo).Value = vendorObj.TinNo
                .Cells(cUserId).Value = vendorObj.UserId
                .Cells(cDateOn).Value = vendorObj.DateOn
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGridForManufacturer(ByRef vendorObj As ClsVendorDetail)
        Try
            If vendorObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdManufacturers.Rows.Add
            With GrdManufacturers.Rows(rowIndex)
                .Cells(cId).Value = vendorObj.Id
                .Cells(cAccountId).Value = vendorObj.AccountId
                .Cells(cManufacturerId).Value = vendorObj.ManufacturerId
                .Cells(cManufacturer).Value = GetTextForValue(CmbManufacturers, vendorObj.ManufacturerId)
                .Cells(lcDeleted).Value = False
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
                ErrorInData("Please enter vendor name.", TxtName)
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
        If CmbManufacturers.Items.Count > 0 Then CmbManufacturers.SelectedIndex = 0
        TxtVendorCode.Text = ""
        TxtName.Text = ""
        TxtAddress.Text = ""
        TxtCity.Text = ""
        TxtPin.Text = ""
        TxtLikeValue.Text = ""
        TxtPhoneO.Text = ""
        TxtPhoneR.Text = ""
        TxtMobile.Text = ""
        TxtEmail.Text = ""
        TxtUpttNo.Text = ""
        TxtTinNo.Text = ""
        GrdManufacturers.Rows.Clear()
        virtualId = 0
        BtnSave.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        GrpSearch.Enabled = True
        RemoveErrorIcon()

        editRow = Nothing

        TxtName.Focus()
    End Sub

    Private Sub ProcessVendorDetail(ByVal accountId As String)
        Try
            If accountId.Trim = "" Then Exit Try

            Dim row As DataGridViewRow
            For Each row In GrdManufacturers.Rows
                With row
                    If .Cells(lcDeleted).Value = True And .Cells(cId).Value < 0 Then
                        Continue For
                    ElseIf .Cells(lcDeleted).Value = False And .Cells(cId).Value > 0 Then
                        Continue For
                    ElseIf .Cells(lcDeleted).Value = True And .Cells(cId).Value > 0 Then
                        DeleteVendorDetail(Me.Name, .Cells(cId).Value)
                    ElseIf .Cells(lcDeleted).Value = False And .Cells(cId).Value < 0 Then
                        Dim vendor As New ClsVendorDetail
                        vendor.AccountId = accountId
                        vendor.ManufacturerId = .Cells(cManufacturerId).Value

                        Dim id As Integer = InsertIntoVendorDetail(Me.Name, vendor)
                        If id > 0 Then
                            .Cells(cId).Value = id
                        End If
                    End If
                End With
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

End Class
