Public Class ClsSearchCreditNoteForm
    Inherits FrmSearchToAll

#Region "Local variables and Constants"

    Private Const lcCreditNoteCode As String = "C.N. Code"
    Private Const lcCustomerName As String = "Customer Name"
    Private Const lcCreditNoteDate As String = "C.N. Date"

    Dim lCustomers() As ClsCustomerMaster = Nothing
    Dim lSelectedId As Long = cInvalidId

#End Region

#Region "Required functions to initialize the object"

    Private Sub ClsSearchCreditNoteForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.SetChildClassObj(Me)
        LoadCustomers()
    End Sub

#End Region

#Region "Protected Functions"

    Protected Overrides Sub GridRowDoubleClicked(ByRef row As System.Windows.Forms.DataGridViewRow)
        Try
            If row Is Nothing Then Exit Try

            Dim id As Long = row.Cells(cId).Value
            If id > 0 Then
                lSelectedId = id
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub LoadGridValues()
        Try
            GrdItems.Rows.Clear()

            Dim creditNotes() As ClsCreditNote = Nothing
            Dim field As String = CmbSearchOnField.Text
            If field = lcCreditNoteDate Then
                Dim str() As String = GetDateValues()
                Dim temp As String = str(0) + str(1) + str(2)
                If temp.Trim = "" Then
                    creditNotes = GetAllCreditNotes(Me.Name)
                ElseIf field = lcCreditNoteDate Then
                    creditNotes = GetAllCreditNoteLikeNoteDate(Me.Name, str(0), str(1), str(2))
                End If
            Else
                Dim str As String = TxtSearchValue.Text.Trim
                If str = "" Then
                    creditNotes = GetAllCreditNotes(Me.Name)
                ElseIf field = lcCreditNoteCode Then
                    creditNotes = GetAllCreditNoteCodeLike(Me.Name, str)
                ElseIf field = lcCustomerName Then
                    creditNotes = GetAllCreditNoteCustomerLike(Me.Name, str)
                End If
            End If

            If creditNotes Is Nothing Then Exit Try

            Dim creditNote As ClsCreditNote
            For Each creditNote In creditNotes
                InsertIntoGrid(creditNote)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub SetGrid()
        With GrdItems
            Dim colCount As Integer = 6
            .RowHeadersVisible = False
            Dim colWidth As Integer = 150
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cCode, "Code")
                        .Columns(index).Width = colWidth

                    Case 2
                        Dim index As Integer = .Columns.Add(cNoteDate, "C.N. Date")
                        .Columns(index).Width = colWidth
                        .Columns(index).DefaultCellStyle.Format = "dd/MM/yyyy"

                    Case 3
                        Dim index As Integer = .Columns.Add(cCustomerName, "Customer Name")
                        .Columns(index).Width = 300

                    Case 4
                        Dim index As Integer = .Columns.Add(cAmount, cAmount)
                        .Columns(index).Width = colWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"

                    Case 5
                        Dim index As Integer = .Columns.Add(cCustomerCode, cCustomerCode)
                        .Columns(index).Visible = False

                    Case 6
                        Dim index As Integer = .Columns.Add(cRemark, cRemark)
                        .Columns(index).Width = colWidth

                End Select
            Next
        End With
    End Sub

    Protected Overrides Sub CloseObj()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Protected Overrides Sub FillSearchValues()
        Try
            With CmbSearchOnField.Items
                .Clear()

                .Add(lcCreditNoteCode)
                .Add(lcCustomerName)
                .Add(lcCreditNoteDate)
            End With

            CmbSearchOnField.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub CmbSearchOnFieldIndexChanged()
        Try
            If CmbSearchOnField.Text = lcCreditNoteDate Then
                PnlDate.Visible = True
                TxtSearchValue.Visible = False
            Else
                TxtSearchValue.Visible = True
                PnlDate.Visible = False
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Public Functions"

    Public Function GetSelectedId() As Long
        Return lSelectedId
    End Function

#End Region

#Region "Private Functions"

    Private Sub InsertIntoGrid(ByRef creditNoteObj As ClsCreditNote)
        Try
            If creditNoteObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItems.Rows.Add
            With GrdItems.Rows(rowIndex)
                .Cells(cId).Value = creditNoteObj.Id
                .Cells(cCode).Value = creditNoteObj.Code
                .Cells(cNoteDate).Value = creditNoteObj.NoteDate
                .Cells(cAmount).Value = creditNoteObj.Amount
                .Cells(cRemark).Value = creditNoteObj.Remark
                .Cells(cCustomerCode).Value = creditNoteObj.CustomerCode
                .Cells(cCustomerName).Value = GetCustomerName(.Cells(cCustomerCode).Value)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadCustomers()
        lCustomers = GetAllCustomerMaster(Me.Name)
    End Sub

    Private Function GetCustomerName(ByVal code As String) As String
        Dim result As String = ""
        Try
            code = code.Trim
            If lCustomers Is Nothing Then Exit Try

            Dim customer As ClsCustomerMaster
            For Each customer In lCustomers
                If UCase(customer.AccountId) = UCase(code) Then
                    result = customer.Name
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
