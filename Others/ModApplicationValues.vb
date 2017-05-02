Module ModApplicationValues

#Region "Constants"

    '***** POINT TO REMEMBER    -   These constants value never change in any case
    Private Const cAppBillNo As String = "BillNo"
    Private Const cAppReceiptNo As String = "ReceiptNo"
    Private Const cAppJournalNo As String = "AppJournalNo"
    Private Const cAppSaleOn As String = "SaleOn"
    Private Const cAppTaxOn As String = "TaxOn"
    Private Const cTransferDate As String = "TransferDate"
    Private Const cTaxOnFree As String = "TaxOnFree"

#End Region

#Region "Variables with default values"
    Private AppBillNo As Long = 1
    Private AppReceiptNo As Long = 1
    Private AppJournalNo As Long = 1
    Private SaleOnCode As String = ""
    Private TaxOnId As Integer = cInvalidId
    Private TransferDate As Date = DateDefault
    Private TaxOnFree As Boolean = False
    Private TaxOnFreeSet As Boolean = False

#End Region

#Region "Functions to load values in variable from Database"
    '***** POINT TO REMEMBER    -   No other file will implement functoin to load values

    ''' <summary>
    ''' This function is used to Load application values (Values required to run application).
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadApplicationValues()
        Try

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to get new bill no.
    ''' </summary>
    ''' <returns>Bill no. in Long</returns>
    ''' <remarks></remarks>
    Public Function GetNewBillNo() As Long
        Dim billNo As Long = cInvalidId
        Try
            Dim appValueObj As ClsApplicationValueMaster = GetApplicationValueMaster("GetNewBillNo", cAppBillNo)
            If appValueObj Is Nothing Then
                Dim appValueMasterObj As New ClsApplicationValueMaster
                With appValueMasterObj
                    .Name = cAppBillNo
                    .IdValue = AppBillNo.ToString
                End With
                If InsertIntoApplicationValueMaster("GetNewBillNo", appValueMasterObj) <> EnResult.Change Then Exit Function
                billNo = AppBillNo
                Exit Try
            End If

            With appValueObj
                .IdValue = CStr(CLng(.IdValue) + 1)
            End With

            If UpdateApplicationValueMaster("GetNewBillNo", appValueObj) <> EnResult.Change Then Exit Function
            billNo = CLng(appValueObj.IdValue)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return billNo
    End Function

    ''' <summary>
    ''' This function is used to get new receipt no.
    ''' </summary>
    ''' <returns>Receipt no. in Long</returns>
    ''' <remarks></remarks>
    Public Function GetNewReceiptNo() As Long
        Dim receiptNo As Long = cInvalidId
        Try
            Dim appValueObj As ClsApplicationValueMaster = GetApplicationValueMaster("GetNewReceiptNo", cAppReceiptNo)
            If appValueObj Is Nothing Then
                Dim appValueMasterObj As New ClsApplicationValueMaster
                With appValueMasterObj
                    .Name = cAppReceiptNo
                    .IdValue = AppReceiptNo.ToString
                End With
                If InsertIntoApplicationValueMaster("GetNewReceiptNo", appValueMasterObj) <> EnResult.Change Then Exit Function
                receiptNo = AppReceiptNo
                Exit Try
            End If

            With appValueObj
                .IdValue = CStr(CLng(.IdValue) + 1)
            End With

            If UpdateApplicationValueMaster("GetNewReceiptNo", appValueObj) <> EnResult.Change Then Exit Try
            receiptNo = CLng(appValueObj.IdValue)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return receiptNo
    End Function

    ''' <summary>
    ''' This function is used to get last journal no.
    ''' </summary>
    ''' <returns>ClsApplicationValueMaster Object</returns>
    ''' <remarks></remarks>
    Private Function GetLastJournalNo() As ClsApplicationValueMaster
        Dim journalNo As ClsApplicationValueMaster = Nothing
        Try
            Dim appValueObj As ClsApplicationValueMaster = GetApplicationValueMaster("GetJournalNo", cAppJournalNo)
            If appValueObj Is Nothing Then
                Dim appValueMasterObj As New ClsApplicationValueMaster
                With appValueMasterObj
                    .Name = cAppJournalNo
                    .IdValue = AppJournalNo.ToString
                End With
                If InsertIntoApplicationValueMaster("GetJournalNo", appValueMasterObj) <> EnResult.Change Then Exit Try
                journalNo = appValueMasterObj
                Exit Try
            End If

            journalNo = appValueObj

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return journalNo
    End Function

    ''' <summary>
    ''' This function is used to get new journal no.
    ''' </summary>
    ''' <returns>Journal no. in String</returns>
    ''' <remarks></remarks>
    Public Function GetNewJournalNo() As String
        Dim result As String = ""
        Try
            Dim journalNoObj As ClsApplicationValueMaster = GetLastJournalNo()
            Dim journalNo As Long = CLng(journalNoObj.IdValue)
            result = cJN + CStr(journalNo)

            If GetAllJournalEntryForJournal("GetNewJournalNo", result) Is Nothing Then Exit Try

            Dim appValueMasterObj As New ClsApplicationValueMaster
            With appValueMasterObj
                .Id = journalNoObj.Id
                .Name = cAppJournalNo
                .IdValue = CStr(journalNo + 1)
            End With

            If UpdateApplicationValueMaster("GetNewJournalNo", appValueMasterObj) <> EnResult.Change Then Exit Try
            result = cJN + CStr(CLng(appValueMasterObj.IdValue))

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to get Sale On.
    ''' </summary>
    ''' <returns>Sale on in String</returns>
    ''' <remarks></remarks>
    Public Function GetSaleOn() As String
        Try
            If SaleOnCode.Trim = "" Then
                Dim appValueObj As ClsApplicationValueMaster = GetApplicationValueMaster("GetSaleOn", cAppSaleOn)
                If appValueObj Is Nothing Then
                    Dim appValueMasterObj As New ClsApplicationValueMaster
                    With appValueMasterObj
                        .Name = cAppSaleOn
                        .IdValue = cPTS
                    End With
                    If InsertIntoApplicationValueMaster("GetSaleOn", appValueMasterObj) <> EnResult.Change Then Exit Try
                    SaleOnCode = cPTS
                    Exit Try
                Else
                    SaleOnCode = appValueObj.IdValue
                End If
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return SaleOnCode
    End Function

    ''' <summary>
    ''' This function is used to get Sale On.
    ''' </summary>
    ''' <returns>Sale on in String</returns>
    ''' <remarks></remarks>
    Public Function UpdateSaleOn(ByVal value As String) As String
        Try
            Dim appValueObj As ClsApplicationValueMaster = GetApplicationValueMaster("UpdateSaleOn", cAppSaleOn)
            If appValueObj Is Nothing Then Exit Try

            appValueObj.IdValue = value
            If UpdateApplicationValueMaster("UpdateSaleOn", appValueObj) <> EnResult.Change Then Exit Try
            SaleOnCode = appValueObj.IdValue

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return SaleOnCode
    End Function

    ''' <summary>
    ''' This function is used to get Tax On.
    ''' </summary>
    ''' <returns>Tax on in String</returns>
    ''' <remarks></remarks>
    Public Function GetTaxOn() As Integer
        Try
            If TaxOnId = cInvalidId Then
                Dim appValueObj As ClsApplicationValueMaster = GetApplicationValueMaster("GetTaxOn", cAppTaxOn)
                If appValueObj Is Nothing Then
                    Dim appValueMasterObj As New ClsApplicationValueMaster
                    With appValueMasterObj
                        .Name = cAppTaxOn
                        .IdValue = CStr(0)
                    End With
                    If InsertIntoApplicationValueMaster("GetTaxOn", appValueMasterObj) <> EnResult.Change Then Exit Try
                    TaxOnId = 0
                    Exit Try
                Else
                    TaxOnId = CInt(appValueObj.IdValue)
                End If
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return TaxOnId
    End Function

    ''' <summary>
    ''' This function is used to update Tax On.
    ''' </summary>
    ''' <returns>Tax on in Date</returns>
    ''' <remarks></remarks>
    Public Function UpdateTaxOn(ByVal value As Integer) As Integer
        Try
            Dim appValueObj As ClsApplicationValueMaster = GetApplicationValueMaster("UpdateTaxOn", cAppTaxOn)
            If appValueObj Is Nothing Then Exit Try

            appValueObj.IdValue = CStr(value)
            If UpdateApplicationValueMaster("UpdateTaxOn", appValueObj) <> EnResult.Change Then Exit Try
            TaxOnId = CInt(appValueObj.IdValue)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return TaxOnId
    End Function

    ''' <summary>
    ''' This function is used to get Transfer Date.
    ''' </summary>
    ''' <returns>Transfer Date in String</returns>
    ''' <remarks></remarks>
    Public Function GetTransferDate() As Date
        Try
            If TransferDate = DateDefault Then
                Dim appValueObj As ClsApplicationValueMaster = GetApplicationValueMaster("GetTransferDate", cTransferDate)
                If appValueObj Is Nothing Then
                    Dim appValueMasterObj As New ClsApplicationValueMaster
                    With appValueMasterObj
                        .Name = cTransferDate
                        .IdValue = TransferDate.ToString("s")
                    End With
                    If InsertIntoApplicationValueMaster("GetTransferDate", appValueMasterObj) <> EnResult.Change Then Exit Try
                    TransferDate = DateDefault
                    Exit Try
                Else
                    TransferDate = CDate(appValueObj.IdValue)
                End If
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return TransferDate
    End Function

    ''' <summary>
    ''' This function is used to update Transfer Date.
    ''' </summary>
    ''' <returns>Transfer Date in Date</returns>
    ''' <remarks></remarks>
    Public Function UpdateTransferDate(ByVal value As Date) As Date
        Try
            Dim appValueObj As ClsApplicationValueMaster = GetApplicationValueMaster("UpdateTransferDate", cTransferDate)
            If appValueObj Is Nothing Then Exit Try

            appValueObj.IdValue = value.ToString("s")
            If UpdateApplicationValueMaster("UpdateTransferDate", appValueObj) <> EnResult.Change Then Exit Try
            TransferDate = CDate(appValueObj.IdValue)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return TransferDate
    End Function

    ''' <summary>
    ''' This function is used to get Tax On Free.
    ''' </summary>
    ''' <returns>Tax On Free in Boolean</returns>
    ''' <remarks></remarks>
    Public Function GetTaxOnFree() As Boolean
        Try
            If TaxOnFreeSet = False Then
                Dim appValueObj As ClsApplicationValueMaster = GetApplicationValueMaster("GetTaxOnFree", cTaxOnFree)
                If appValueObj Is Nothing Then
                    Dim appValueMasterObj As New ClsApplicationValueMaster
                    With appValueMasterObj
                        .Name = cTaxOnFree
                        .IdValue = CStr(Math.Abs(CInt(False)))
                    End With
                    If InsertIntoApplicationValueMaster("GetTaxOnFree", appValueMasterObj) <> EnResult.Change Then Exit Try
                    TaxOnFree = CStr(Math.Abs(CInt(False)))
                    Exit Try
                Else
                    TaxOnFree = CBool(appValueObj.IdValue)
                End If

                TaxOnFreeSet = True
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return TaxOnFree
    End Function

    ''' <summary>
    ''' This function is used to update Tax On Free.
    ''' </summary>
    ''' <returns>Tax On Free in Boolean</returns>
    ''' <remarks></remarks>
    Public Function UpdateTaxOnFree(ByVal value As Boolean) As Boolean
        Try
            Dim appValueObj As ClsApplicationValueMaster = GetApplicationValueMaster("UpdateTaxOnFree", cTaxOnFree)
            If appValueObj Is Nothing Then Exit Try

            appValueObj.IdValue = CStr(Math.Abs(CInt(value)))
            If UpdateApplicationValueMaster("UpdateTaxOnFree", appValueObj) <> EnResult.Change Then Exit Try
            TaxOnFree = CBool(appValueObj.IdValue)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return TaxOnFree
    End Function

#End Region

End Module
