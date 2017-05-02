Public Class ClsSearchDestructionSlipForm
    Inherits FrmSearchToAll

#Region "Local variables and Constants"

    Private Const lcDestructionSlipCode As String = "Destruction Slip Code"
    Private Const lcDestructionSlipDate As String = "Destruction Slip Date"

    Dim lSelectedId As Long = cInvalidId

#End Region

#Region "Required functions to initialize the object"

    Private Sub ClsSearchDestructionSlipForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            Dim destructionSlips() As ClsDestructionSlipMaster = Nothing
            Dim field As String = CmbSearchOnField.Text
            If field = lcDestructionSlipDate Then
                Dim str() As String = GetDateValues()
                Dim temp As String = str(0) + str(1) + str(2)
                If temp.Trim = "" Then
                    destructionSlips = GetAllDestructionSlipMaster(Me.Name)
                ElseIf field = lcDestructionSlipDate Then
                    destructionSlips = GetAllDestructionSlipMasterLikeDestructionDate(Me.Name, str(0), str(1), str(2))
                End If
            Else
                Dim str As String = TxtSearchValue.Text.Trim
                If str = "" Then
                    destructionSlips = GetAllDestructionSlipMaster(Me.Name)
                ElseIf field = lcDestructionSlipCode Then
                    destructionSlips = GetAllDestructionSlipMasterDestructionSlipCodeLike(Me.Name, str)
                End If
            End If

            If destructionSlips Is Nothing Then Exit Try

            Dim destructionSlip As ClsDestructionSlipMaster
            For Each destructionSlip In destructionSlips
                InsertIntoGrid(destructionSlip)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub SetGrid()
        With GrdItems
            Dim colCount As Integer = 3
            .RowHeadersVisible = False
            Dim colWidth As Integer = 140
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cDestructionSlipCode, "Destruction Slip Code")
                        .Columns(index).Width = colWidth

                    Case 2
                        Dim index As Integer = .Columns.Add(cDestructionSlipDate, "Destruction Slip Date")
                        .Columns(index).Width = colWidth
                        .Columns(index).DefaultCellStyle.Format = "dd/MM/yyyy"

                    Case 3
                        Dim index As Integer = .Columns.Add(cRemark, cRemark)
                        .Columns(index).Width = 620

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

                .Add(lcDestructionSlipCode)
                .Add(lcDestructionSlipDate)
            End With

            CmbSearchOnField.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub CmbSearchOnFieldIndexChanged()
        Try
            If CmbSearchOnField.Text = lcDestructionSlipDate Then
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

    Private Sub InsertIntoGrid(ByRef destructionSlipObj As ClsDestructionSlipMaster)
        Try
            If destructionSlipObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItems.Rows.Add
            With GrdItems.Rows(rowIndex)
                .Cells(cId).Value = destructionSlipObj.Id
                .Cells(cDestructionSlipCode).Value = destructionSlipObj.DestructionSlipCode
                .Cells(cDestructionSlipDate).Value = destructionSlipObj.DestructionSlipDate
                .Cells(cRemark).Value = destructionSlipObj.Remark
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

End Class
