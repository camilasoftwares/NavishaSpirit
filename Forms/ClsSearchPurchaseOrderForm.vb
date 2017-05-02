Public Class ClsSearchPurchaseOrderForm
    Inherits FrmSearchToAll

#Region "Local variables and Constants"

    Private Const lcPurchaseOrderNo As String = "Order No"
    Private Const lcPurchaseOrderDate As String = "Order Date"
    'Private Const lcPurchaseLimitDays As String = "Purchase Limit Days"
    'Private Const lcStockLimitDays As String = "Stock Limit Days"

    Dim lSelectedId As Long = cInvalidId

#End Region

#Region "Required functions to initialize the object"

    Private Sub ClsSearchPurchaseOrderForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.SetChildClassObj(Me)
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

            Dim purchaseOrders() As ClsPurchaseOrderMaster = Nothing
            Dim field As String = CmbSearchOnField.Text
            If field = lcPurchaseOrderDate Then
                Dim str() As String = GetDateValues()
                Dim temp As String = str(0) + str(1) + str(2)
                If temp.Trim = "" Then
                    purchaseOrders = GetAllPurchaseOrderMaster(Me.Name)
                ElseIf field = lcPurchaseOrderDate Then
                    purchaseOrders = GetAllPurchaseOrderMasterLikeOrderDate(Me.Name, str(0), str(1), str(2))
                End If
            Else
                Dim str As String = TxtSearchValue.Text.Trim
                If str = "" Then
                    purchaseOrders = GetAllPurchaseOrderMaster(Me.Name)
                ElseIf field = lcPurchaseOrderNo Then
                    purchaseOrders = GetAllPurchaseOrderMasterOrderLike(Me.Name, str)
                End If
            End If

            If purchaseOrders Is Nothing Then Exit Try

            Dim purchaseOrder As ClsPurchaseOrderMaster
            For Each purchaseOrder In purchaseOrders
                InsertIntoGrid(purchaseOrder)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub SetGrid()
        With GrdItems
            Dim colCount As Integer = 4
            .RowHeadersVisible = False
            Dim colWidth As Integer = 120
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, "Order No")
                        .Columns(index).Width = colWidth

                    Case 1
                        Dim index As Integer = .Columns.Add(cOrderDate, "Order Date")
                        .Columns(index).Width = colWidth
                        .Columns(index).DefaultCellStyle.Format = "dd/MM/yyyy"

                    Case 2
                        '    Dim index As Integer = .Columns.Add(cPurchaseLimit, "Purchase Limit")
                        '    .Columns(index).Width = colWidth

                        'Case 3
                        '    Dim index As Integer = .Columns.Add(cStockLimit, "Stock Limit")
                        '    .Columns(index).Width = colWidth

                        'Case 4
                        Dim index As Integer = .Columns.Add(cRemark, cRemark)
                        '.Columns(index).Width = 420
                        .Columns(index).Width = 660

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

                .Add(lcPurchaseOrderNo)
                .Add(lcPurchaseOrderDate)
                '.Add(lcStockLimitDays)
            End With

            CmbSearchOnField.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub CmbSearchOnFieldIndexChanged()
        Try
            If CmbSearchOnField.Text = lcPurchaseOrderDate Then
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

    Private Sub InsertIntoGrid(ByRef purchaseOrderObj As ClsPurchaseOrderMaster)
        Try
            If purchaseOrderObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItems.Rows.Add
            With GrdItems.Rows(rowIndex)
                .Cells(cId).Value = purchaseOrderObj.Id
                '.Cells(cPurchaseLimit).Value = purchaseOrderObj.PurchaseLimit
                '.Cells(cStockLimit).Value = purchaseOrderObj.StockLimit
                .Cells(cRemark).Value = purchaseOrderObj.Remark
                .Cells(cOrderDate).Value = purchaseOrderObj.OrderDate
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

End Class
