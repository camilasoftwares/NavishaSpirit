Imports System.Windows.Forms
Imports AIMS.Author

Public Class DlgLR

#Region "Control Functions"

    Private Sub DlgLR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub DtPkrLRDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtPkrLRDate.ValueChanged
        Try
            Dim customer As ClsCustomerMaster = GetSelectedItem(CmbCustomer)
            If customer Is Nothing Then Exit Try

            TxtDueDays.Value = customer.DueDays

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub EnterKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDueDays.KeyDown, TxtLRNo.KeyDown, DtPkrLRDate.KeyDown, DtPkrDueDate.KeyDown, CmbInvoice.KeyDown, CmbCustomer.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub TxtDueDays_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDueDays.ValueChanged
        Dim days As Integer = TxtDueDays.Value
        DtPkrDueDate.Value = DtPkrLRDate.Value.AddDays(days)
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            Dim salesObj As ClsSalesMaster = GetSelectedItem(CmbInvoice)
            If salesObj Is Nothing Then Exit Try

            If AndedTheString(gUser.AuthorizationNo, Authorization.LRs_NoUpdate) = True Then Exit Sub

            'Updating Master
            Dim saleMasterObj As New ClsSalesMaster
            With saleMasterObj
                .Id = salesObj.Id
                .SaleCode = salesObj.SaleCode
                .CustomerId = salesObj.CustomerId
                .DoctorId = cInvalidId
                .Mode = salesObj.Mode
                .DiscountAmount = salesObj.DiscountAmount
                .Prescription = salesObj.Prescription
                .CashOutAmount = salesObj.CashOutAmount
                .AdjustedAmount = salesObj.AdjustedAmount
                .SaleDate = salesObj.SaleDate
                .CashMemo = False
                .ForCashOut = False
                .UserId = gUser.LoginName
                .DateOn = Now
                .NotClosed = False
                .DivisionId = salesObj.DivisionId
                .TransporterId = salesObj.TransporterId
                .HQId = salesObj.HQId
                .PickSlipNo = salesObj.PickSlipNo
                .OrderNo = salesObj.OrderNo
                .Reference = salesObj.Reference
                .Destination = salesObj.Destination
                .ChequeNo = salesObj.ChequeNo
                .Cases = salesObj.Cases
                .OrderDate = salesObj.OrderDate
                .CreditAdjust = salesObj.CreditAdjust
                .DebitAdjust = salesObj.DebitAdjust
                .PreExciseAmount = salesObj.PreExciseAmount
                .TaxId = salesObj.TaxId
                .TaxPercent = salesObj.TaxPercent
                .LRNo = TxtLRNo.Text
                .LRDate = DtPkrLRDate.Value
                .DueDate = DtPkrDueDate.Value
            End With

            If UpdateSalesMaster(Me.Name, saleMasterObj) <> EnResult.Change Then Exit Sub

            MsgBox("Successfully Saved", , "Saved")
            LoadComboboxValuesForInvoices()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CmbInvoice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbInvoice.SelectedIndexChanged
        Try
            Dim sale As ClsSalesMaster = GetSelectedItem(CmbInvoice)
            If sale Is Nothing Then
                CmbCustomer.SelectedIndex = -1
                CmbCustomer.Text = ""
                LblSaleDate.Text = ""
                DtPkrLRDate.Value = Now.Date
                TxtDueDays.Value = 0
                TxtLRNo.Text = ""
            Else
                With sale
                    SelectCustomerForId(.CustomerId)
                    LblSaleDate.Text = Format(.SaleDate, "dd/MM/yyyy")
                    DtPkrLRDate.Value = .LRDate
                    TxtDueDays.Value = DateDiff(DateInterval.Day, .LRDate, .DueDate)
                    TxtLRNo.Text = .LRNo
                End With
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        LoadComboboxValues()
    End Sub

    Private Sub LoadComboboxValues()
        LoadComboboxValuesForCustomers()
        LoadComboboxValuesForInvoices()
    End Sub

    Private Sub LoadComboboxValuesForCustomers()
        Try
            CmbCustomer.DataSource = Nothing
            CmbCustomer.Items.Clear()
            CmbCustomer.Text = ""

            Dim customers() As ClsCustomerMaster = GetAllCustomerMaster(Me.Name)
            If customers Is Nothing Then Exit Try

            With CmbCustomer
                .DataSource = customers
                .DisplayMember = cName
                .ValueMember = cId
                .SelectedIndex = -1
                .Text = ""
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboboxValuesForInvoices()
        Try
            CmbInvoice.DataSource = Nothing
            CmbInvoice.Items.Clear()
            CmbInvoice.Text = ""

            Dim sales() As ClsSalesMaster = GetAllSalesMasterForLRNo(Me.Name)
            If sales Is Nothing Then Exit Try

            With CmbInvoice
                .DataSource = sales
                .DisplayMember = cSaleCode
                .ValueMember = cId
                .SelectedIndex = -1
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SelectCustomerForId(ByVal id As Integer)
        Try
            If id < 0 Then Exit Try

            For Each customer As ClsCustomerMaster In CmbCustomer.Items
                If customer.Id = id Then
                    CmbCustomer.SelectedItem = customer
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

End Class
