Imports AIMS.Author

Public Class FrmCustomerType

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim flagChange As Boolean = False

    Enum Index
        GrpCustomerType
        TxtName
        BtnAdd
        BtnUpdate
        BtnCancel
        BtnClose
        GrpCustomerTypes
        GrdCustomerType
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

    Private Sub FrmCustomerTypes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.CustomerType_NoAdd) = True Then Exit Sub
            If ValidateValues() = False Then Exit Sub

            If NameExistInGrid(TxtName.Text) = True Then
                ErrorInData("Name already exist in list.", TxtName)
                Exit Sub
            End If

            Dim customerType As New ClsCustomerType
            With customerType
                .Name = TxtName.Text
            End With

            Dim id As Integer = InsertIntoCustomerType(Me.Name, customerType)
            If id > 0 Then
                flagChange = True
                customerType = GetCustomerType(Me.Name, id)
                InsertIntoGrid(customerType)
                MsgBox("Added successfully.", , "Added")
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        ResetControlsToAddNew()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.CustomerType_NoUpdate) = True Then Exit Sub
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim customerType As New ClsCustomerType
            With customerType
                .Id = editRow.Cells(cId).Value
                .Name = TxtName.Text
            End With

            If CustomerTypeUpdatable(Me.Name, customerType) = False Then
                ErrorInData("Already exist with other id.", TxtName)
                Exit Sub
            End If

            If UpdateCustomerType(Me.Name, customerType) <> EnResult.Change Then Exit Sub

            flagChange = True
            With editRow
                .Cells(cName).Value = customerType.Name
            End With

            MsgBox("Updated successfully.", , "Updated")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub GrdCustomerType_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdCustomerType.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.CustomerType_NoUpdate) = True Then Exit Sub

            editRow = GrdCustomerType.Rows(e.RowIndex)
            With editRow
                TxtName.Text = .Cells(cName).Value
            End With

            BtnAdd.Enabled = False
            BtnUpdate.Enabled = True
            BtnCancel.Enabled = True
            GrpCustomerTypes.Enabled = False

            TxtName.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdCustomerType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdCustomerType.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtName.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        SetTabIndex()
        SetGrid()
        LoadGridValues()

        ResetControlsToAddNew()
    End Sub

    Private Sub SetTabIndex()
        GrpCustomerType.TabIndex = Index.GrpCustomerType
        TxtName.TabIndex = Index.TxtName
        BtnAdd.TabIndex = Index.BtnAdd
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
        GrpCustomerTypes.TabIndex = Index.GrpCustomerTypes
        GrdCustomerType.TabIndex = Index.GrdCustomerType
    End Sub

    Private Sub SetGrid()
        With GrdCustomerType
            Dim colCount As Integer = 1
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Width = 315

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValues()
        Try
            GrdCustomerType.Rows.Clear()
            Dim customerTypes() As ClsCustomerType = GetAllCustomerTypes(Me.Name)
            If customerTypes Is Nothing Then Exit Try

            Dim customerType As ClsCustomerType
            For Each customerType In customerTypes
                InsertIntoGrid(customerType)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef customerTypeObj As ClsCustomerType)
        Try
            If customerTypeObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdCustomerType.Rows.Add
            With GrdCustomerType.Rows(rowIndex)
                .Cells(cId).Value = customerTypeObj.Id
                .Cells(cName).Value = customerTypeObj.Name
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
                ErrorInData("Please enter Customer Type.", TxtName)
                Exit Try
            End If

            If TxtName.Text.Trim = "General" Then
                ErrorInData("This is reserved. Please enter another Customer Type.", TxtName)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlsToAddNew()
        TxtName.Text = ""

        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        GrpCustomerTypes.Enabled = True

        editRow = Nothing

        TxtName.Focus()
    End Sub

    Private Function NameExistInGrid(ByVal name As String) As Boolean
        Dim result As Boolean = False
        Try
            name = name.Trim
            If name = "" Then Exit Try

            Dim row As DataGridViewRow
            For Each row In GrdCustomerType.Rows
                If row.Cells(cName).Value = name Then
                    result = True
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

#End Region

#Region "Public Functions"

    Public Function Change() As Boolean
        Return flagChange
    End Function

#End Region

End Class