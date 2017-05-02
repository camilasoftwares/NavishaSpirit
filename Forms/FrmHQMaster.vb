Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmHQMaster

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim flagChange As Boolean = False

    Private Const lcName As String = "Name"
    Private Const lcAddress As String = "Address"
    Private Const lcCity As String = "City"
    Private Const lcMobile As String = "Mobile"
    Private Const lcPhoneR As String = "Phone Res."
    Private Const lcPhoneO As String = "Phone Off."

    Enum Index
        GrpHQ = 0
        TxtName
        TxtAddress
        TxtCity
        TxtPin
        TxtMobile
        TxtPhoneR
        TxtPhoneO
        TxtEmail
        CmbRepresentative
        TxtPhoneRepresentative
        GrpButton
        BtnAdd
        BtnUpdate
        BtnCancel
        BtnClose
        GrpSearch
        CmbFieldToSearch
        TxtLikeValue
        GrpHQDetails
        GrdHQDetails
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

    Private Sub FrmHQMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub CmbRepresentative_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbRepresentative.KeyPress
        'AutoComplete(CmbRepresentative, e)
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

    Private Sub GrdHQDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdHQDetails.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.HQ_NoUpdate) = True Then Exit Sub

            editRow = GrdHQDetails.Rows(e.RowIndex)
            With editRow
                CmbRepresentative.Text = .Cells(cRepresentative).Value
                TxtName.Text = .Cells(cName).Value
                TxtAddress.Text = .Cells(cAddress).Value
                TxtCity.Text = .Cells(cCity).Value
                TxtPin.Text = .Cells(cPin).Value
                TxtMobile.Text = .Cells(cMobile).Value
                TxtPhoneR.Text = .Cells(cPhoneR).Value
                TxtPhoneO.Text = .Cells(cPhoneO).Value
                TxtEmail.Text = .Cells(cEmail).Value
                TxtPhoneRepresentative.Text = .Cells(cPhoneRepresentative).Value
            End With

            BtnAdd.Enabled = False
            BtnUpdate.Enabled = True
            BtnCancel.Enabled = True
            GrpSearch.Enabled = False

            TxtName.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdHQDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdHQDetails.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.HQ_NoAdd) = True Then Exit Sub
            If ValidateValues() = False Then Exit Sub

            Dim hq As New ClsHQMaster
            With hq
                .Name = TxtName.Text
                .Address = TxtAddress.Text
                .City = TxtCity.Text
                .Pin = TxtPin.Text
                .Mobile = TxtMobile.Text
                .PhoneR = TxtPhoneR.Text
                .PhoneO = TxtPhoneO.Text
                .EMail = TxtEmail.Text
                .Representative = CmbRepresentative.Text
                .PhoneRepresentative = TxtPhoneRepresentative.Text
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            Dim id As Integer = InsertIntoHQMaster(Me.Name, hq)
            If id > 0 Then
                flagChange = True
                hq.Id = id
                InsertIntoGrid(hq)
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.HQ_NoUpdate) = True Then Exit Sub
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim hq As New ClsHQMaster
            With hq
                .Id = editRow.Cells(cId).Value
                .UserId = editRow.Cells(cUserId).Value
                .DateOn = editRow.Cells(cDateOn).Value
                .Name = TxtName.Text
                .Address = TxtAddress.Text
                .City = TxtCity.Text
                .Pin = TxtPin.Text
                .Mobile = TxtMobile.Text
                .PhoneR = TxtPhoneR.Text
                .PhoneO = TxtPhoneO.Text
                .EMail = TxtEmail.Text
                .Representative = CmbRepresentative.Text
                .PhoneRepresentative = TxtPhoneRepresentative.Text
            End With

            If UpdateHQMaster(Me.Name, hq) <> EnResult.Change Then Exit Sub

            flagChange = True
            With editRow
                .Cells(cRepresentative).Value = CmbRepresentative.Text
                .Cells(cPhoneRepresentative).Value = TxtPhoneRepresentative.Text
                .Cells(cName).Value = TxtName.Text
                .Cells(cAddress).Value = TxtAddress.Text
                .Cells(cCity).Value = TxtCity.Text
                .Cells(cPin).Value = TxtPin.Text
                .Cells(cMobile).Value = TxtMobile.Text
                .Cells(cPhoneR).Value = TxtPhoneR.Text
                .Cells(cPhoneO).Value = TxtPhoneO.Text
                .Cells(cEmail).Value = TxtEmail.Text
            End With

            InsertIntoComboBoxForRepresentative(CmbRepresentative.Text.Trim)

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

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPin.KeyDown, TxtPhoneRepresentative.KeyDown, TxtPhoneR.KeyDown, TxtPhoneO.KeyDown, TxtName.KeyDown, TxtMobile.KeyDown, TxtLikeValue.KeyDown, TxtEmail.KeyDown, TxtCity.KeyDown, TxtAddress.KeyDown, CmbRepresentative.KeyDown, CmbFieldToSearch.KeyDown
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
            .Items.Add(cRepresentative)
            .Items.Add(lcName)
            .Items.Add(lcAddress)
            .Items.Add(lcCity)
            .Items.Add(lcMobile)
            .Items.Add(lcPhoneR)
            .Items.Add(lcPhoneO)
            .SelectedIndex = 0
        End With

        CmbRepresentative.Items.Clear()
        SetTabIndex()
        SetGrid()
        LoadGridValues()

        ResetControlsToAddNew()
    End Sub

    Private Sub SetTabIndex()
        GrpHQ.TabIndex = Index.GrpHQ
        CmbRepresentative.TabIndex = Index.CmbRepresentative
        TxtPhoneRepresentative.TabIndex = Index.TxtPhoneRepresentative
        TxtName.TabIndex = Index.TxtName
        TxtAddress.TabIndex = Index.TxtAddress
        TxtCity.TabIndex = Index.TxtCity
        TxtPin.TabIndex = Index.TxtPin
        TxtMobile.TabIndex = Index.TxtMobile
        TxtPhoneR.TabIndex = Index.TxtPhoneR
        TxtPhoneO.TabIndex = Index.TxtPhoneO
        TxtEmail.TabIndex = Index.TxtEmail
        GrpButton.TabIndex = Index.GrpButton
        BtnAdd.TabIndex = Index.BtnAdd
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
        GrpSearch.TabIndex = Index.GrpSearch
        CmbFieldToSearch.TabIndex = Index.CmbFieldToSearch
        TxtLikeValue.TabIndex = Index.TxtLikeValue
        GrpHQDetails.TabIndex = Index.GrpHQDetails
        GrdHQDetails.TabIndex = Index.GrdHQDetails
    End Sub

    Private Sub SetGrid()
        With GrdHQDetails
            Dim colCount As Integer = 12
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Width = 140

                    Case 2
                        Dim index As Integer = .Columns.Add(cRepresentative, cRepresentative)
                        .Columns(index).Width = 120

                    Case 3
                        Dim index As Integer = .Columns.Add(cPhoneRepresentative, "Rep. Phone")
                        .Columns(index).Width = 90

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
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 12
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValues()
        Try
            GrdHQDetails.Rows.Clear()
            Dim hqs() As ClsHQMaster = GetAllHQMaster(Me.Name)
            If hqs Is Nothing Then Exit Try

            Dim hq As ClsHQMaster
            For Each hq In hqs
                InsertIntoGrid(hq)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadGridValuesWithSearchLike(ByVal txtLike As String)
        Try
            GrdHQDetails.Rows.Clear()
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
            ElseIf CmbFieldToSearch.Text = cRepresentative Then
                field = cRepresentative
            End If

            Dim hqs() As ClsHQMaster = GetAllHQMasterLike(Me.Name, field, txtLike)
            If hqs Is Nothing Then Exit Try

            Dim hq As ClsHQMaster
            For Each hq In hqs
                InsertIntoGrid(hq)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef hqObj As ClsHQMaster)
        Try
            If hqObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdHQDetails.Rows.Add
            With GrdHQDetails.Rows(rowIndex)
                .Cells(cId).Value = hqObj.Id
                .Cells(cName).Value = hqObj.Name
                .Cells(cAddress).Value = hqObj.Address
                .Cells(cCity).Value = hqObj.City
                .Cells(cPin).Value = hqObj.Pin
                .Cells(cMobile).Value = hqObj.Mobile
                .Cells(cPhoneR).Value = hqObj.PhoneR
                .Cells(cPhoneO).Value = hqObj.PhoneO
                .Cells(cEmail).Value = hqObj.EMail
                .Cells(cUserId).Value = hqObj.UserId
                .Cells(cDateOn).Value = hqObj.DateOn
                .Cells(cRepresentative).Value = hqObj.Representative
                .Cells(cPhoneRepresentative).Value = hqObj.PhoneRepresentative
                InsertIntoComboBoxForRepresentative(hqObj.Representative)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoComboBoxForRepresentative(ByVal representative As String)
        Try
            If representative.Trim = "" Then Exit Try

            If CmbRepresentative.FindStringExact(representative) < 0 Then CmbRepresentative.Items.Add(representative)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If TxtName.Text.Trim = "" Then
                ErrorInData("Please enter HQ name.", TxtName)
                Exit Try
            End If

            'If TxtAddress.Text.Trim = "" Then
            '    ErrorInData("Please enter address.", TxtAddress)
            '    Exit Try
            'End If

            'If TxtCity.Text.Trim = "" Then
            '    ErrorInData("Please enter city.", TxtCity)
            '    Exit Try
            'End If

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
        CmbRepresentative.Text = ""
        TxtName.Text = ""
        TxtAddress.Text = ""
        TxtCity.Text = ""
        TxtPin.Text = ""
        TxtLikeValue.Text = ""
        TxtPhoneO.Text = ""
        TxtPhoneR.Text = ""
        TxtMobile.Text = ""
        TxtEmail.Text = ""
        TxtPhoneRepresentative.Text = ""
        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        GrpSearch.Enabled = True

        editRow = Nothing

        TxtName.Focus()
    End Sub

#End Region

End Class
