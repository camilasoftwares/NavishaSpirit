Imports System.Windows.Forms

Public Class FrmCustomerTypePrice

#Region "Local Variables and Constants"

    Dim lCustomerTypes As ClsCustomerType() = Nothing
    Dim lItemId As Integer = cInvalidId
    Dim lItemName As String = ""
    Dim lBatch As String = ""
    Dim lCustomerTypePrices As ClsCustomerTypePrice() = Nothing

#End Region

#Region "Controls Functions"

    Private Sub FrmCustomerTypePrice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub GrdCustomerTypePrice_CellParsing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellParsingEventArgs) Handles GrdCustomerTypePrice.CellParsing
        Dim result As Boolean = IsNumeric(e.Value)
        Dim defaultValue As Double = 0
        If result = False Then
            e.Value = defaultValue
            MsgBox("Please enter decimal values only.", MsgBoxStyle.Critical, "Decimal Value")

        ElseIf e.Value.ToString.Trim = "" Then
            e.Value = defaultValue
        End If

        e.ParsingApplied = True
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If GrdCustomerTypePrice.Rows.Count = 0 Then Exit Try

            Dim customerTypePriceList As New List(Of ClsCustomerTypePrice)
            For Each row As DataGridViewRow In GrdCustomerTypePrice.Rows
                Dim customerTypePriceObj As New ClsCustomerTypePrice
                With row
                    customerTypePriceObj.Id = .Cells(cId).Value
                    customerTypePriceObj.ItemId = .Cells(cItemId).Value
                    customerTypePriceObj.Batch = .Cells(cBatch).Value
                    customerTypePriceObj.CustomerTypeId = .Cells(cCustomerTypeId).Value
                    customerTypePriceObj.Price = .Cells(cPrice).Value
                End With

                customerTypePriceList.Add(customerTypePriceObj)
            Next

            Dim result As EnResult = InsertUpdateCustomerTypePrice(Me.Name, customerTypePriceList)
            If result = EnResult.Change Then
                MsgBox("Successfuly updated.", , "Updated")
            ElseIf result = EnResult.NoChange Then
                MsgBox("No updation done.", , "No updation")
                Exit Try
            Else
                Exit Try
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        SetGrid()
        LoadCustomerTypes()
        FillGridWithCustomerTypes()
        FillGridWithCustomerTypePrices()
    End Sub

    Private Sub SetGrid()
        With GrdCustomerTypePrice
            Dim colCount As Integer = 5
            Dim defaultCellWidth As Integer = 100
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cCustomerTypeId, cCustomerTypeId)
                        .Columns(index).Visible = False

                    Case 2
                        Dim index As Integer = .Columns.Add(cItemId, cItemId)
                        .Columns(index).Visible = False

                    Case 3
                        Dim index As Integer = .Columns.Add(cCustomerType, "Customer Type")
                        .Columns(index).Width = defaultCellWidth + 140
                        .Columns(index).ReadOnly = True

                    Case 4
                        Dim index As Integer = .Columns.Add(cBatch, cBatch)
                        .Columns(index).Visible = False

                    Case 5
                        Dim index As Integer = .Columns.Add(cPrice, cPrice)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).ValueType = System.Type.GetType("System.Double")

                End Select
            Next
        End With
    End Sub

    Private Sub FillGridWithCustomerTypes()
        Try
            GrdCustomerTypePrice.Rows.Clear()
            If lCustomerTypes Is Nothing Then Exit Try

            For Each customerType As ClsCustomerType In lCustomerTypes
                Dim index As Integer = GrdCustomerTypePrice.Rows.Add
                With GrdCustomerTypePrice.Rows(index)
                    .Cells(cId).Value = cInvalidId
                    .Cells(cItemId).Value = lItemId
                    .Cells(cBatch).Value = lBatch
                    .Cells(cCustomerTypeId).Value = customerType.Id
                    .Cells(cCustomerType).Value = customerType.Name
                    .Cells(cPrice).Value = 0
                End With
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub FillGridWithCustomerTypePrices()
        Try
            If lCustomerTypePrices Is Nothing Then Exit Try
            If GrdCustomerTypePrice.Rows.Count = 0 Then Exit Try

            For Each row As DataGridViewRow In GrdCustomerTypePrice.Rows
                With row
                    Dim customerTypePrice As ClsCustomerTypePrice = GetCustomerTypePriceObject(.Cells(cCustomerTypeId).Value)
                    If customerTypePrice IsNot Nothing Then
                        .Cells(cId).Value = customerTypePrice.Id
                        .Cells(cItemId).Value = customerTypePrice.ItemId
                        .Cells(cBatch).Value = customerTypePrice.Batch
                        .Cells(cPrice).Value = customerTypePrice.Price
                    End If
                End With
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadCustomerTypes()
        Try
            lCustomerTypes = GetAllCustomerTypes(Me.Name)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadCustomerTypePrices()
        Try
            lCustomerTypePrices = GetAllCustomerTypePrices(Me.Name, lItemId, lBatch)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetCustomerTypePriceObject(ByVal customerTypeId As Integer) As ClsCustomerTypePrice
        Dim result As ClsCustomerTypePrice = Nothing
        Try
            If lCustomerTypePrices Is Nothing Then Exit Try

            For Each customerTypePrice As ClsCustomerTypePrice In lCustomerTypePrices
                If customerTypePrice.CustomerTypeId = customerTypeId Then
                    result = customerTypePrice
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

    Public Sub SetValues(ByVal itemId As Integer, ByVal itemName As String, ByVal batch As String)
        lItemId = itemId
        lItemName = itemName.Trim
        lBatch = batch.Trim

        TxtItemName.Text = lItemName
        'TxtBatch.Text = lBatch

        LoadCustomerTypePrices()
        FillGridWithCustomerTypePrices()
    End Sub

#End Region

End Class
