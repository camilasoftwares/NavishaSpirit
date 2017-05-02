Imports System.Windows.Forms

Public Class FrmTransferData

#Region "Private Variables"

    Dim lTotalRecords As Long = 0
    Dim lFinishedRecords As Long = 0
    Dim lCurrentKey As String = ""

#End Region

#Region "Private Functions - For Controls"

    Private Sub FrmTransferData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LblMsg.Text = "Status"
        LblToTransfer.Text = "Records to Transfer"
        LblTransferred.Text = "Records Transferred"
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnTransferData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTransferData.Click
        Try
            Dim dlg As New DlgInputBox("Password", "Please enter security password to transfer data.", True)
            If dlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim str As String = dlg.EnteredText
                If str <> "999" Then
                    MsgBox("Illegal Password. Please provide a valid password to transfer data.", MsgBoxStyle.Critical, "Invalid")
                    Exit Try
                End If
            Else
                Exit Try
            End If

            GrpControl.Enabled = False
            SetStatus("Creating List")
            Dim lastUpdateDate As Date = GetTransferDate()

            '************** Create List of customer code present in Connection String ****************
            Dim customerCodeList As List(Of String) = GetAllCustomerMasterCode(Me.Name)
            ClsDBFunctions.GetInstance.CheckAndSortConnectionStringKeys(customerCodeList)

            If customerCodeList.Count = 0 Then
                SetStatus("No Customer connection key found.")
                Exit Try
            End If

            SetStatus("Preparing List of Transfers...")

            '************** Create List to Transfer ****************
            Dim categoryList As New List(Of ClsCategoryMaster)
            Dim categories() As ClsCategoryMaster = GetAllCategoryMaster(Me.Name)
            If categories IsNot Nothing Then categoryList.AddRange(categories)

            Dim manufacturerList As New List(Of ClsManufacturerMaster)
            Dim manufacturers() As ClsManufacturerMaster = GetAllManufacturerMaster(Me.Name)
            If manufacturers IsNot Nothing Then manufacturerList.AddRange(manufacturers)

            Dim itemList As New List(Of ClsItemMaster)
            Dim items() As ClsItemMaster = GetAllItemMaster(Me.Name, True)
            If items IsNot Nothing Then itemList.AddRange(items)

            Dim taxList As New List(Of ClsTaxMaster)
            Dim taxes() As ClsTaxMaster = GetAllTaxMasters(Me.Name)
            If taxes IsNot Nothing Then taxList.AddRange(taxes)

            'All sale objects get fill and reserved in this call for further use
            Dim salesList As List(Of ClsSalesMaster)= GetAllSalesMasterForDateOn(Me.Name, lastUpdateDate, Now)
            Dim saleIdList As List(Of Long) = GetAllSalesMasterId()

            Dim saleDetailList As List(Of ClsSalesDetail) = GetAllSalesDetailForSaleIds(Me.Name, saleIdList)

            ''All sample objects get fill and reserved in this call for further use
            'Dim sampleList As List(Of ClsSampleMaster) = GetAllSampleMasterForDateOn(Me.Name, lastUpdateDate, Now)
            'Dim sampleIdList As List(Of Long) = GetAllSampleMasterId()

            'Dim sampleDetailList As List(Of ClsSampleDetail) = GetAllSampleDetailForSampleIds(Me.Name, sampleIdList)

            '************** Final Confirmation ****************
            Dim total As Long = customerCodeList.Count * (categoryList.Count + manufacturerList.Count + itemList.Count + taxList.Count) + salesList.Count + saleDetailList.Count '+ sampleList.Count + sampleDetailList.Count
            SetRecordsToTransfer(total)
            lFinishedRecords = 0
            LblTransferred.Text = CStr(0)

            If MsgBox("Total No. of records are " + CStr(total) + ". Do you want to transfer?", MsgBoxStyle.YesNo, "Last Confirmation") = MsgBoxResult.No Then
                SetStatus("Transfer aborted")
                Exit Try
            End If

            '************** Transfer List ****************
            For Each code As String In customerCodeList
                lCurrentKey = code

                'Categories
                For Each category As ClsCategoryMaster In categoryList
                    TransferObject(category)
                    IncreaseRecordsTransferred()
                Next

                'Manufacturers
                For Each manufacturer As ClsManufacturerMaster In manufacturerList
                    TransferObject(manufacturer)
                    IncreaseRecordsTransferred()
                Next

                'Items
                For Each item As ClsItemMaster In itemList
                    TransferObject(item)
                    IncreaseRecordsTransferred()
                Next

                'Taxes
                For Each tax As ClsTaxMaster In taxList
                    TransferObject(tax)
                    IncreaseRecordsTransferred()
                Next

                Dim customerId As Integer = GetCustomerMasterIdForCode(Me.Name, code)
                If customerId <= cInvalidId Then Continue For

                'Sales
                salesList = GetAllSalesMasterForCustomerId(customerId)
                For Each sale As ClsSalesMaster In salesList
                    saleDetailList = GetAllSalesDetailForSaleId(sale.Id)

                    TransferObject(sale, saleDetailList)

                    IncreaseRecordsTransferred(saleDetailList.Count + 1)    '1 for sale
                Next

                ''Sample
                'sampleList = GetAllSampleMasterForCustomerId(customerId)
                'For Each sample As ClsSampleMaster In sampleList
                '    sampleDetailList = GetAllSampleDetailForSampleId(sample.Id)

                '    TransferObject(sample, sampleDetailList)

                '    IncreaseRecordsTransferred(sampleDetailList.Count + 1)    '1 for sample
                'Next

            Next

            '************** Final Step ****************

            If lTotalRecords <> lFinishedRecords Then
                SetStatus("Not all record transfered")
                MsgBox("Data Transfer incomplete due to unavailability of connection.", MsgBoxStyle.Information, "InComplete")
                Exit Try
            End If

            'UpdateTransferDate(Now)

            SetStatus("Finished")
            MsgBox("Data Transfer completed successfully.", MsgBoxStyle.Information, "Completed")

        Catch ex As Exception
            AddToLog(ex)
            SetStatus("Transfer Failed")
            MsgBox(("Data Transfer Failed. Reason - " + ex.Message), MsgBoxStyle.Critical, "Failed")
        End Try

        lCurrentKey = ""
        GrpControl.Enabled = True
    End Sub

    Private Sub SetStatus(ByVal status As String)
        LblMsg.Text = status
    End Sub

    Private Sub SetRecordsToTransfer(ByVal count As Long)
        LblToTransfer.Text = CStr(count)
        lTotalRecords = count
        PgBar.Maximum = lTotalRecords
    End Sub

    Private Sub IncreaseRecordsTransferred(ByVal count As Integer)
        For x As Integer = 1 To count
            IncreaseRecordsTransferred()
        Next
    End Sub

    Private Sub IncreaseRecordsTransferred()
        lFinishedRecords = lFinishedRecords + 1
        LblTransferred.Text = CStr(lFinishedRecords)
        PgBar.Value = lFinishedRecords
    End Sub

#End Region

#Region "Private functions - For Query"

    Private Sub TransferObject(ByRef obj As Object)
        Dim qry As String = ClsTransferScripts.GetInstance.GetFullQuery(obj)

        Dim retObj As Object = ClsDBFunctions.GetInstance.ExecuteQuery_Scalar(qry, Me.Name, lCurrentKey)
        If retObj IsNot Nothing Then
            If retObj.ToString.Trim <> "" Then AddToLog(retObj.ToString)
        End If
    End Sub

    ''' <summary>
    ''' This function will execute master and its detail
    ''' </summary>
    ''' <param name="saleobj">Sales Master Object</param>
    ''' <param name="saleDetailList">List of Sale Detail objects</param>
    ''' <remarks></remarks>
    Private Sub TransferObject(ByRef saleobj As ClsSalesMaster, ByRef saleDetailList As List(Of ClsSalesDetail))
        Dim qry As String = ClsTransferScripts.GetInstance.GetFullQuery(saleobj, saleDetailList)

        Dim retObj As Object = ClsDBFunctions.GetInstance.ExecuteQuery_Scalar(qry, Me.Name, lCurrentKey)
        If retObj IsNot Nothing Then
            If retObj.ToString.Trim <> "" Then AddToLog(retObj.ToString)
        End If
    End Sub

    '''' <summary>
    '''' This function will execute master and its detail
    '''' </summary>
    '''' <param name="sampleobj">Sample Master Object</param>
    '''' <param name="sampleDetailList">List of Sample Detail objects</param>
    '''' <remarks></remarks>
    'Private Sub TransferObject(ByRef sampleobj As ClsSampleMaster, ByRef sampleDetailList As List(Of ClsSampleDetail))
    '    Dim qry As String = ClsTransferScripts.GetInstance.GetFullQuery(sampleobj, sampleDetailList)

    '    Dim retObj As Object = ClsDBFunctions.GetInstance.ExecuteQuery_Scalar(qry, Me.Name, lCurrentKey)
    '    If retObj IsNot Nothing Then
    '        If retObj.ToString.Trim <> "" Then AddToLog(retObj.ToString)
    '    End If
    'End Sub

#End Region

End Class
