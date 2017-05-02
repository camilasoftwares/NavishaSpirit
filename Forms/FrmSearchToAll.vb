Public MustInherit Class FrmSearchToAll

#Region "Local variables and Constants"

    Private drivedClassObj As Object = Nothing
    Dim classTypeObj As ClassType = ClassType.ClsInvalid

    Enum Index
        GrpCondition
        CmbSearchOnField
        TxtSearchValue
        PnlDate
        TxtMaskDate
        BtnShowDetails
        BtnClose
        GrdItems
    End Enum

    Protected Enum ClassType
        ClsInvalid = 0
        ClsSearchPurchaseForm
        ClsSearchSaleForm
        ClsSearchSaleReturnForm
        ClsSearchPurchaseOrderForm
        ClsSearchDestructionSlipForm
        ClsSearchPurchaseReturnForm
        ClsSearchSampleForm
        ClsSearchCreditNoteForm
        ClsSearchDebitNoteForm
        ClsSearchCashReceiptForm
        ClsSearchChequeReceiptForm
        ClsSearchCashPaymentForm
        ClsSearchChequePaymentForm
    End Enum

#End Region

#Region "Abstract Functions"

    Protected MustOverride Sub SetGrid()
    Protected MustOverride Sub LoadGridValues()
    Protected MustOverride Sub GridRowDoubleClicked(ByRef row As DataGridViewRow)
    Protected MustOverride Sub CloseObj()
    Protected MustOverride Sub FillSearchValues()
    Protected MustOverride Sub CmbSearchOnFieldIndexChanged()

#End Region

#Region "Protected Members"

    'Don't Remove This
    Protected Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Protected Sub SetChildClassObj(ByRef childClassObj As Object)
        Try
            If ReferenceEquals(drivedClassObj, childClassObj) = True Then Exit Sub

            drivedClassObj = childClassObj

            If TypeOf drivedClassObj Is ClsSearchPurchaseForm Then
                classTypeObj = ClassType.ClsSearchPurchaseForm

            ElseIf TypeOf drivedClassObj Is ClsSearchSaleForm Then
                classTypeObj = ClassType.ClsSearchSaleForm

            ElseIf TypeOf drivedClassObj Is ClsSearchSaleReturnForm Then
                classTypeObj = ClassType.ClsSearchSaleReturnForm

            ElseIf TypeOf drivedClassObj Is ClsSearchPurchaseOrderForm Then
                classTypeObj = ClassType.ClsSearchPurchaseOrderForm

            ElseIf TypeOf drivedClassObj Is ClsSearchDestructionSlipForm Then
                classTypeObj = ClassType.ClsSearchDestructionSlipForm

            ElseIf TypeOf drivedClassObj Is ClsSearchPurchaseReturnForm Then
                classTypeObj = ClassType.ClsSearchPurchaseReturnForm

            ElseIf TypeOf drivedClassObj Is ClsSearchSampleForm Then
                classTypeObj = ClassType.ClsSearchSampleForm

            ElseIf TypeOf drivedClassObj Is ClsSearchCreditNoteForm Then
                classTypeObj = ClassType.ClsSearchCreditNoteForm

            ElseIf TypeOf drivedClassObj Is ClsSearchDebitNoteForm Then
                classTypeObj = ClassType.ClsSearchDebitNoteForm

            ElseIf TypeOf drivedClassObj Is ClsSearchCashReceiptForm Then
                classTypeObj = ClassType.ClsSearchCashReceiptForm

            ElseIf TypeOf drivedClassObj Is ClsSearchChequeReceiptForm Then
                classTypeObj = ClassType.ClsSearchChequeReceiptForm

            ElseIf TypeOf drivedClassObj Is ClsSearchCashPaymentForm Then
                classTypeObj = ClassType.ClsSearchCashPaymentForm

            ElseIf TypeOf drivedClassObj Is ClsSearchChequePaymentForm Then
                classTypeObj = ClassType.ClsSearchChequePaymentForm

            Else
                classTypeObj = ClassType.ClsInvalid

                'This part raises exception because no other object is allowed here
                MsgBox("This is not allowed in 'Add New Item'.", , "Error")
                CloseObj()
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Function GetDateValues() As String()
        Dim sep As String = System.Globalization.DateTimeFormatInfo.CurrentInfo.DateSeparator

        Return TxtMaskDate.Text.Split(sep)
    End Function

#End Region

#Region "Control Functions"

    Private Sub FrmSearchToAll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnShowDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShowDetails.Click
        LoadGridValues()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        CloseObj
    End Sub

    Private Sub GrdItems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItems.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try

            GridRowDoubleClicked(GrdItems.Rows(e.RowIndex))

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearchValue.KeyDown, CmbSearchOnField.KeyDown, PnlDate.KeyDown, TxtMaskDate.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub CmbSearchOnField_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSearchOnField.SelectedIndexChanged
        CmbSearchOnFieldIndexChanged()
    End Sub

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        PnlDate.Visible = False

        SetTabIndex()
        SetGrid()
        FillSearchValues()

        CmbSearchOnField.Focus()
    End Sub

    Private Sub SetTabIndex()
        GrpCondition.TabIndex = Index.GrpCondition
        CmbSearchOnField.TabIndex = Index.CmbSearchOnField
        TxtSearchValue.TabIndex = Index.TxtSearchValue
        BtnShowDetails.TabIndex = Index.BtnShowDetails
        BtnClose.TabIndex = Index.BtnClose
        GrdItems.TabIndex = Index.GrdItems
        PnlDate.TabIndex = Index.PnlDate
        TxtMaskDate.TabIndex = Index.TxtMaskDate
    End Sub

#End Region

End Class