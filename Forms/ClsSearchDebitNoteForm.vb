Public Class ClsSearchDebitNoteForm
    Inherits FrmSearchToAll

#Region "Local variables and Constants"

    Private Const lcDebitNoteCode As String = "D.N. Code"
    Private Const lcVendorName As String = "Vendor Name"
    Private Const lcDebitNoteDate As String = "D.N. Date"

    Dim lVendors() As ClsVendorMaster = Nothing
    Dim lSelectedId As Long = cInvalidId

#End Region

#Region "Required functions to initialize the object"

    Private Sub ClsSearchDebitNoteForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.SetChildClassObj(Me)
        LoadVendors()
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

            Dim debitNotes() As ClsDebitNote = Nothing
            Dim field As String = CmbSearchOnField.Text
            If field = lcDebitNoteDate Then
                Dim str() As String = GetDateValues()
                Dim temp As String = str(0) + str(1) + str(2)
                If temp.Trim = "" Then
                    debitNotes = GetAllDebitNotes(Me.Name)
                ElseIf field = lcDebitNoteDate Then
                    debitNotes = GetAllDebitNoteLikeNoteDate(Me.Name, str(0), str(1), str(2))
                End If
            Else
                Dim str As String = TxtSearchValue.Text.Trim
                If str = "" Then
                    debitNotes = GetAllDebitNotes(Me.Name)
                ElseIf field = lcDebitNoteCode Then
                    debitNotes = GetAllDebitNoteCodeLike(Me.Name, str)
                ElseIf field = lcVendorName Then
                    debitNotes = GetAllDebitNoteVendorLike(Me.Name, str)
                End If
            End If

            If debitNotes Is Nothing Then Exit Try

            Dim debitNote As ClsDebitNote
            For Each debitNote In debitNotes
                InsertIntoGrid(debitNote)
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
                        Dim index As Integer = .Columns.Add(cNoteDate, "D.N. Date")
                        .Columns(index).Width = colWidth
                        .Columns(index).DefaultCellStyle.Format = "dd/MM/yyyy"

                    Case 3
                        Dim index As Integer = .Columns.Add(cVendor, "Vendor Name")
                        .Columns(index).Width = 300

                    Case 4
                        Dim index As Integer = .Columns.Add(cAmount, cAmount)
                        .Columns(index).Width = colWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"

                    Case 5
                        Dim index As Integer = .Columns.Add(cVendorCode, cVendorCode)
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

                .Add(lcDebitNoteCode)
                .Add(lcVendorName)
                .Add(lcDebitNoteDate)
            End With

            CmbSearchOnField.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub CmbSearchOnFieldIndexChanged()
        Try
            If CmbSearchOnField.Text = lcDebitNoteDate Then
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

    Private Sub InsertIntoGrid(ByRef debitNoteObj As ClsDebitNote)
        Try
            If debitNoteObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItems.Rows.Add
            With GrdItems.Rows(rowIndex)
                .Cells(cId).Value = debitNoteObj.Id
                .Cells(cCode).Value = debitNoteObj.Code
                .Cells(cNoteDate).Value = debitNoteObj.NoteDate
                .Cells(cAmount).Value = debitNoteObj.Amount
                .Cells(cRemark).Value = debitNoteObj.Remark
                .Cells(cVendorCode).Value = debitNoteObj.VendorCode
                .Cells(cVendor).Value = GetVendorName(.Cells(cVendorCode).Value)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadVendors()
        lVendors = GetAllVendorMaster(Me.Name)
    End Sub

    Private Function GetVendorName(ByVal code As String) As String
        Dim result As String = ""
        Try
            code = code.Trim
            If lVendors Is Nothing Then Exit Try

            Dim vendor As ClsVendorMaster
            For Each vendor In lVendors
                If UCase(vendor.AccountId) = UCase(code) Then
                    result = vendor.Name
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
