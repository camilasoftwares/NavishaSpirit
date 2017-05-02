Public Class ClsSearchCashReceiptForm
    Inherits FrmSearchToAll

#Region "Local variables and Constants"

    Private Const lcCashReceiptCode As String = "C.R. Code"
    Private Const lcReceiptFrom As String = "Receipt From"
    Private Const lcInvoiceNo As String = "Invoice No"
    Private Const lcCashReceiptDate As String = "C.R. Date"

    Private Const lcTo As String = "To"
    Private Const lcFrom As String = "From"

    Dim lAccountHeads() As ClsAccountHead = Nothing
    Dim lSelectedId As Long = cInvalidId

#End Region

#Region "Required functions to initialize the object"

    Private Sub ClsSearchCashReceiptForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.SetChildClassObj(Me)
        LoadAccountHead()
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

            Dim cashReceipts() As ClsCashReceipt = Nothing
            Dim field As String = CmbSearchOnField.Text
            If field = lcCashReceiptDate Then
                Dim str() As String = GetDateValues()
                Dim temp As String = str(0) + str(1) + str(2)
                If temp.Trim = "" Then
                    cashReceipts = GetAllCashReceipts(Me.Name)
                ElseIf field = lcCashReceiptDate Then
                    cashReceipts = GetAllCashReceiptLikeReceiptDate(Me.Name, str(0), str(1), str(2))
                End If
            Else
                Dim str As String = TxtSearchValue.Text.Trim
                If str = "" Then
                    cashReceipts = GetAllCashReceipts(Me.Name)
                ElseIf field = lcCashReceiptCode Then
                    cashReceipts = GetAllCashReceiptCodeLike(Me.Name, str)
                ElseIf field = lcInvoiceNo Then
                    cashReceipts = GetAllCashReceiptInvoiceNoLike(Me.Name, str)
                ElseIf field = lcReceiptFrom Then
                    cashReceipts = GetAllCashReceiptReceiptFromLike(Me.Name, str)
                End If
            End If

            If cashReceipts Is Nothing Then Exit Try

            Dim cashReceipt As ClsCashReceipt
            For Each cashReceipt In cashReceipts
                InsertIntoGrid(cashReceipt)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub SetGrid()
        With GrdItems
            Dim colCount As Integer = 9
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
                        Dim index As Integer = .Columns.Add(cReceiptDate, "C.R. Date")
                        .Columns(index).Width = colWidth
                        .Columns(index).DefaultCellStyle.Format = "dd/MM/yyyy"

                    Case 3
                        Dim index As Integer = .Columns.Add(cToHeadId, cToHeadId)
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cAmount, cAmount)
                        .Columns(index).Width = colWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"

                    Case 5
                        Dim index As Integer = .Columns.Add(lcTo, lcTo)
                        .Columns(index).Width = colWidth

                    Case 6
                        Dim index As Integer = .Columns.Add(lcFrom, lcFrom)
                        .Columns(index).Width = colWidth

                    Case 7
                        Dim index As Integer = .Columns.Add(cInvoiceNo, "Invoice No")
                        .Columns(index).Width = colWidth

                    Case 8
                        Dim index As Integer = .Columns.Add(cRemark, cRemark)
                        .Columns(index).Width = colWidth

                    Case 9
                        Dim index As Integer = .Columns.Add(cFromHeadId, cFromHeadId)
                        .Columns(index).Visible = False

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

                .Add(lcCashReceiptCode)
                .Add(lcInvoiceNo)
                .Add(lcReceiptFrom)
                .Add(lcCashReceiptDate)
            End With

            CmbSearchOnField.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub CmbSearchOnFieldIndexChanged()
        Try
            If CmbSearchOnField.Text = lcCashReceiptDate Then
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

    Private Sub InsertIntoGrid(ByRef cashReceiptObj As ClsCashReceipt)
        Try
            If cashReceiptObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItems.Rows.Add
            With GrdItems.Rows(rowIndex)
                .Cells(cId).Value = cashReceiptObj.Id
                .Cells(cCode).Value = cCAR + CStr(cashReceiptObj.Id)
                .Cells(cReceiptDate).Value = cashReceiptObj.ReceiptDate
                .Cells(cAmount).Value = cashReceiptObj.Amount
                .Cells(cInvoiceNo).Value = cashReceiptObj.InvoiceNo
                .Cells(cRemark).Value = cashReceiptObj.Remark
                .Cells(cFromHeadId).Value = cashReceiptObj.FromHeadId
                .Cells(cToHeadId).Value = cashReceiptObj.ToHeadId
                .Cells(lcTo).Value = GetAccountHeadName(.Cells(cToHeadId).Value)
                .Cells(lcFrom).Value = GetAccountHeadName(.Cells(cFromHeadId).Value)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadAccountHead()
        lAccountHeads = GetAllAccountHead(Me.Name)
    End Sub

    Private Function GetAccountHeadName(ByVal id As Long) As String
        Dim result As String = ""
        Try
            If id < 0 Then Exit Try
            If lAccountHeads Is Nothing Then Exit Try

            Dim accountHead As ClsAccountHead
            For Each accountHead In lAccountHeads
                If accountHead.Id = id Then
                    result = accountHead.Name
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
