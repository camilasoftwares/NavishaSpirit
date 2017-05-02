'Handles all Functionality related to ClsSalesMaster
Module ModSalesMasterDAL

    Dim dsSalesMaster As DataSet = Nothing

    Private Function GetSalesMasterObj(ByRef row As DataRow) As ClsSalesMaster
        Dim salesMaster As New ClsSalesMaster
        Try
            With row
                salesMaster.Id = .Item(cId)
                salesMaster.SaleCode = .Item(cSaleCode)
                salesMaster.CustomerId = .Item(cCustomerId)
                'salesMaster.DoctorId = .Item(cDoctorIdX)
                salesMaster.Mode = .Item(cMode)
                salesMaster.Remark = .Item(cRemark)
                salesMaster.Prescription = .Item(cPrescription)
                salesMaster.CashOutAmount = .Item(cCashOutAmount)
                salesMaster.AdjustedAmount = .Item(cAdjustedAmount)
                salesMaster.SaleDate = .Item(cSaleDate)
                salesMaster.CashMemo = .Item(cCashMemo)
                salesMaster.ForCashOut = .Item(cForCashOut)
                salesMaster.UserId = .Item(cUserId)
                salesMaster.DateOn = .Item(cDateOn)
                salesMaster.NotClosed = .Item(cNotClosed)
                salesMaster.DiscountAmount = .Item(cDiscountAmount)
                salesMaster.DivisionId = .Item(cDivisionId)
                salesMaster.PickSlipNo = .Item(cPickSlipNo)
                salesMaster.OrderNo = .Item(cOrderNo)
                salesMaster.OrderDate = .Item(cOrderDate)
                salesMaster.Reference = .Item(cReference)
                salesMaster.TransporterId = .Item(cTransporterId)
                salesMaster.Destination = .Item(cDestination)
                salesMaster.LRNo = .Item(cLRNo)
                salesMaster.LRDate = .Item(cLRDate)
                salesMaster.ChequeNo = .Item(cChequeNo)
                salesMaster.Cases = .Item(cCases)
                salesMaster.DueDate = .Item(cDueDate)
                salesMaster.HQId = .Item(cHQId)
                salesMaster.CreditAdjust = .Item(cCreditAdjust)
                salesMaster.DebitAdjust = .Item(cDebitAdjust)
                salesMaster.TaxId = .Item(cTaxId)
                salesMaster.TaxPercent = .Item(cTaxPercent)
                salesMaster.PreExciseAmount = .Item(cPreExciseAmount)
                salesMaster.FreightCharge = .Item(cFreightCharge)
                salesMaster.Cancelled = .Item(cCancelled)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesMaster
    End Function

    Private Function GetSalesMaster(ByRef rows As DataRowCollection) As ClsSalesMaster()
        Dim salesMasters(0) As ClsSalesMaster
        salesMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(salesMasters, count)
                For x = 0 To count - 1
                    salesMasters(x) = GetSalesMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesMasters
    End Function

    Private Function GetSalesMaster(ByRef rows() As DataRow) As ClsSalesMaster()
        Dim salesMasters(0) As ClsSalesMaster
        salesMasters = Nothing

        Try
            Dim count As Integer = rows.Length
            If count > 0 Then
                Dim x As Integer

                Array.Resize(salesMasters, count)
                For x = 0 To count - 1
                    salesMasters(x) = GetSalesMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesMasters
    End Function

    ''' <summary>
    ''' This function will give all records from Sales Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of ClsSalesMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesMaster(ByVal calledBy As String) As ClsSalesMaster()
        Dim salesMasters(0) As ClsSalesMaster
        salesMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSalesMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    salesMasters = GetSalesMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesMasters
    End Function

    ''' <summary>
    ''' This function will give all records opened for cash out from Sales Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of ClsSalesMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesMasterForCashOut(ByVal calledBy As String) As ClsSalesMaster()
        Dim salesMasters(0) As ClsSalesMaster
        salesMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSalesMasterForCashOut().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    salesMasters = GetSalesMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesMasters
    End Function

    ''' <summary>
    ''' This function will give all records for empty LR No from Sales Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of ClsSalesMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesMasterForLRNo(ByVal calledBy As String) As ClsSalesMaster()
        Dim salesMasters(0) As ClsSalesMaster
        salesMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSalesMasterForLRNo().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    salesMasters = GetSalesMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesMasters
    End Function

    ''' <summary>
    ''' This function will give all records from Sales Master table for given customer code.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="customerCode">Code for which records are required</param>
    ''' <returns>Array of ClsSalesMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesMasterForCustomerCode(ByVal calledBy As String, ByVal customerCode As String) As ClsSalesMaster()
        Dim salesMasters(0) As ClsSalesMaster
        salesMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSalesMasterForCustomerCode(customerCode).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    salesMasters = GetSalesMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesMasters
    End Function

    ''' <summary>
    ''' This function will give records from Sales Master table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="forField">Field in which search takes place</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsSalesMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Private Function GetAllSalesMasterValuesLike(ByVal calledBy As String, ByVal forField As String, ByVal value As String) As ClsSalesMaster()
        Dim salesMasters(0) As ClsSalesMaster
        salesMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSalesMasterValuesLike(forField, value).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    salesMasters = GetSalesMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesMasters
    End Function

    ''' <summary>
    ''' This function will give records from Sales Master table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="day">Day for which search takes place</param>
    ''' <param name="month">Month for which search takes place</param>
    ''' <param name="year">Year for which search takes place</param>
    ''' <returns>Array of ClsSalesMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesMasterLikeSaleDate(ByVal calledBy As String, Optional ByVal day As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "") As ClsSalesMaster()
        Dim salesMasters(0) As ClsSalesMaster
        salesMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSalesMasterLikeSaleDate(day, month, year).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    salesMasters = GetSalesMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesMasters
    End Function

    ''' <summary>
    ''' This function will give records from Sales Master table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsSalesMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesMasterSaleCodeLike(ByVal calledBy As String, ByVal value As String) As ClsSalesMaster()
        Return GetAllSalesMasterValuesLike(calledBy, cSaleCode, value)
    End Function

    ''' <summary>
    ''' This function will give records from Sales Master table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsSalesMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesMasterModeLike(ByVal calledBy As String, ByVal value As String) As ClsSalesMaster()
        Return GetAllSalesMasterValuesLike(calledBy, cMode, value)
    End Function

    ''' <summary>
    ''' This function will give records from Sales Master table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsSalesMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesMasterCustomerLike(ByVal calledBy As String, ByVal value As String) As ClsSalesMaster()
        Return GetAllSalesMasterValuesLike(calledBy, cCustomerId, value)
    End Function

    ''' <summary>
    ''' This function will give records from Sales Master table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsSalesMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesMasterDoctorLike(ByVal calledBy As String, ByVal value As String) As ClsSalesMaster()
        Return GetAllSalesMasterValuesLike(calledBy, cDoctorId, value)
    End Function

    ''' <summary>
    ''' This function will give all records for DateOn between dates from Sales Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>List of ClsSalesMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesMasterForDateOn(ByVal calledBy As String, ByVal dateFrom As Date, ByVal dateTo As Date) As List(Of ClsSalesMaster)
        Dim salesMasterList As New List(Of ClsSalesMaster)

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSalesMasterForDateOn(dateFrom, dateTo).Trim
                If sql = "" Then Exit For

                dsSalesMaster = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If dsSalesMaster.Tables(0).Rows.Count > 0 Then
                    Dim salesMasters() As ClsSalesMaster = GetSalesMaster(dsSalesMaster.Tables(0).Rows)
                    salesMasterList.AddRange(salesMasters)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesMasterList
    End Function

    ''' <summary>
    ''' This function will give all records for given customer Id from preserved dataset.
    ''' </summary>
    ''' <param name="customerId">Customer Id for which the records are required</param>
    ''' <returns>List of ClsSalesMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesMasterForCustomerId(ByVal customerId As Integer) As List(Of ClsSalesMaster)
        Dim salesMasterList As New List(Of ClsSalesMaster)

        Try
            Dim temp As Integer
            For temp = 0 To 0
                If dsSalesMaster Is Nothing Then Exit For

                If dsSalesMaster.Tables(0).Rows.Count > 0 Then
                    Dim str As String = cCustomerId + " = " + CStr(customerId)
                    Dim dtRow() As DataRow = dsSalesMaster.Tables(0).Select(str)
                    If dtRow.Length <> 0 Then salesMasterList.AddRange(GetSalesMaster(dtRow))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesMasterList
    End Function

    ''' <summary>
    ''' This function will give all Ids from preserved dataset.
    ''' </summary>
    ''' <returns>List of long</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesMasterId() As List(Of Long)
        Dim idList As New List(Of Long)

        Try
            Dim temp As Integer
            For temp = 0 To 0
                If dsSalesMaster Is Nothing Then Exit For

                If dsSalesMaster.Tables(0).Rows.Count > 0 Then
                    'Dim str As String = "distinct(" + cId + ")"
                    'Dim dtRow() As DataRow = dsSalesMaster.Tables(0).Select(str)
                    For Each row As DataRow In dsSalesMaster.Tables(0).Rows
                        Dim id As Long = row.Item(cId)
                        If idList.Contains(id) = False Then idList.Add(id)
                    Next

                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return idList
    End Function

    ''' <summary>
    ''' This function will give record from Sales Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="loginName">Login Name for which the record is required</param>
    ''' <returns>ClsSalesMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetSalesMasterNotClosedForLogin(ByVal calledBy As String, ByVal loginName As String) As ClsSalesMaster
        Dim salesMaster As ClsSalesMaster = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetSalesMasterNotClosedForLogin(loginName).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    salesMaster = GetSalesMasterObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesMaster
    End Function

    ''' <summary>
    ''' This function will give sales id from Sales Master table not closed.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="loginName">Login Name for which the record is required</param>
    ''' <returns>Id in Long or cInvalidId</returns>
    ''' <remarks></remarks>
    Public Function GetSalesMasterIdNotClosedForLogin(ByVal calledBy As String, ByVal loginName As String) As Long
        Dim result As Long = cInvalidId

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetSalesMasterIdNotClosedForLogin(loginName).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    If IsDBNull(ds.Tables(0).Rows(0).Item(0)) = True Then Exit Try

                    result = Val(ds.Tables(0).Rows(0).Item(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function will give record from Sales Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsSalesMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetSalesMaster(ByVal calledBy As String, ByVal id As Long) As ClsSalesMaster
        Dim salesMaster As ClsSalesMaster = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetSalesMaster(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    salesMaster = GetSalesMasterObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesMaster
    End Function

    ''' <summary>
    ''' This function will give Net Amount from Sales Master table for given id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which amount is required</param>
    ''' <returns>Amount in Double</returns>
    ''' <remarks></remarks>
    Public Function GetSalesMasterNetAmount(ByVal calledBy As String, ByVal id As Long) As Double
        Dim result As Double = 0

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetSalesMasterNetAmount(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    If IsDBNull(ds.Tables(0).Rows(0).Item(0)) = True Then Exit Try

                    result = Val(ds.Tables(0).Rows(0).Item(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function will give discount Amount from Sales Master table for given id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which amount is required</param>
    ''' <returns>Amount in Double</returns>
    ''' <remarks></remarks>
    Public Function GetSalesMasterDiscountAmount(ByVal calledBy As String, ByVal id As Long) As Double
        Dim result As Double = 0

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetSalesMasterDiscountAmount(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    If IsDBNull(ds.Tables(0).Rows(0).Item(0)) = True Then Exit Try

                    result = Val(ds.Tables(0).Rows(0).Item(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to insert Sales Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="salesMasterObj">ClsSalesMaster object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoSalesMaster(ByVal calledBy As String, ByRef salesMasterObj As ClsSalesMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoSalesMaster(salesMasterObj).Trim
                If sql = "" Then Exit For

                Dim id As Integer = ClsDBFunctions.GetInstance.ExecuteQuery_Scalar(sql, calledBy)
                If id > 0 Then
                    result = id
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to update Sales Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="salesMasterObj">ClsSalesMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateSalesMaster(ByVal calledBy As String, ByRef salesMasterObj As ClsSalesMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateSalesMaster(salesMasterObj).Trim
                If sql = "" Then Exit For

                If ClsDBFunctions.GetInstance.ExecuteQuery_NonQuery(sql, calledBy) > 0 Then result = EnResult.Change
            Next

        Catch ex As Exception
            AddToLog(ex)
            result = EnResult.Err
        End Try

        Return result
    End Function

End Module