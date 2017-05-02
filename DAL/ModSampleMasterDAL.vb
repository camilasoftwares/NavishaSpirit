'Handles all Functionality related to ClsSampleMaster
Module ModSampleMasterDAL

    Dim dsSampleMaster As DataSet = Nothing

    Private Function GetSampleMasterObj(ByRef row As DataRow) As ClsSampleMaster
        Dim sampleMaster As New ClsSampleMaster
        Try
            With row
                sampleMaster.Id = .Item(cId)
                sampleMaster.SampleCode = .Item(cSampleCode)
                sampleMaster.CustomerId = .Item(cCustomerId)
                'sampleMaster.DoctorId = .Item(cDoctorIdX)
                sampleMaster.Mode = .Item(cMode)
                sampleMaster.Remark = .Item(cRemark)
                sampleMaster.Prescription = .Item(cPrescription)
                sampleMaster.CashOutAmount = .Item(cCashOutAmount)
                sampleMaster.AdjustedAmount = .Item(cAdjustedAmount)
                sampleMaster.SampleDate = .Item(cSampleDate)
                sampleMaster.CashMemo = .Item(cCashMemo)
                sampleMaster.ForCashOut = .Item(cForCashOut)
                sampleMaster.UserId = .Item(cUserId)
                sampleMaster.DateOn = .Item(cDateOn)
                sampleMaster.NotClosed = .Item(cNotClosed)
                sampleMaster.DiscountAmount = .Item(cDiscountAmount)
                sampleMaster.DivisionId = .Item(cDivisionId)
                sampleMaster.PickSlipNo = .Item(cPickSlipNo)
                sampleMaster.OrderNo = .Item(cOrderNo)
                sampleMaster.OrderDate = .Item(cOrderDate)
                sampleMaster.Reference = .Item(cReference)
                sampleMaster.TransporterId = .Item(cTransporterId)
                sampleMaster.Destination = .Item(cDestination)
                sampleMaster.LRNo = .Item(cLRNo)
                sampleMaster.LRDate = .Item(cLRDate)
                sampleMaster.ChequeNo = .Item(cChequeNo)
                sampleMaster.Cases = .Item(cCases)
                sampleMaster.DueDate = .Item(cDueDate)
                sampleMaster.HQId = .Item(cHQId)
                sampleMaster.CreditAdjust = .Item(cCreditAdjust)
                sampleMaster.DebitAdjust = .Item(cDebitAdjust)
                sampleMaster.TaxId = .Item(cTaxId)
                sampleMaster.TaxPercent = .Item(cTaxPercent)
                sampleMaster.PreExciseAmount = .Item(cPreExciseAmount)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleMaster
    End Function

    Private Function GetSampleMaster(ByRef rows As DataRowCollection) As ClsSampleMaster()
        Dim sampleMasters(0) As ClsSampleMaster
        sampleMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(sampleMasters, count)
                For x = 0 To count - 1
                    sampleMasters(x) = GetSampleMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleMasters
    End Function

    Private Function GetSampleMaster(ByRef rows() As DataRow) As ClsSampleMaster()
        Dim sampleMasters(0) As ClsSampleMaster
        sampleMasters = Nothing

        Try
            Dim count As Integer = rows.Length
            If count > 0 Then
                Dim x As Integer

                Array.Resize(sampleMasters, count)
                For x = 0 To count - 1
                    sampleMasters(x) = GetSampleMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleMasters
    End Function

    ''' <summary>
    ''' This function will give all records from Sample Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of ClsSampleMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSampleMaster(ByVal calledBy As String) As ClsSampleMaster()
        Dim sampleMasters(0) As ClsSampleMaster
        sampleMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSampleMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    sampleMasters = GetSampleMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleMasters
    End Function

    ''' <summary>
    ''' This function will give all records opened for cash out from Sample Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of ClsSampleMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSampleMasterForCashOut(ByVal calledBy As String) As ClsSampleMaster()
        Dim sampleMasters(0) As ClsSampleMaster
        sampleMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSampleMasterForCashOut().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    sampleMasters = GetSampleMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleMasters
    End Function

    ''' <summary>
    ''' This function will give all records from Sample Master table for given customer code.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="customerCode">Code for which records are required</param>
    ''' <returns>Array of ClsSampleMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSampleMasterForCustomerCode(ByVal calledBy As String, ByVal customerCode As String) As ClsSampleMaster()
        Dim sampleMasters(0) As ClsSampleMaster
        sampleMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSampleMasterForCustomerCode(customerCode).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    sampleMasters = GetSampleMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleMasters
    End Function

    ''' <summary>
    ''' This function will give records from Sample Master table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="forField">Field in which search takes place</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsSampleMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Private Function GetAllSampleMasterValuesLike(ByVal calledBy As String, ByVal forField As String, ByVal value As String) As ClsSampleMaster()
        Dim sampleMasters(0) As ClsSampleMaster
        sampleMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSampleMasterValuesLike(forField, value).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    sampleMasters = GetSampleMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleMasters
    End Function

    ''' <summary>
    ''' This function will give records from Sample Master table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="day">Day for which search takes place</param>
    ''' <param name="month">Month for which search takes place</param>
    ''' <param name="year">Year for which search takes place</param>
    ''' <returns>Array of ClsSampleMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSampleMasterLikeSampleDate(ByVal calledBy As String, Optional ByVal day As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "") As ClsSampleMaster()
        Dim sampleMasters(0) As ClsSampleMaster
        sampleMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSampleMasterLikeSampleDate(day, month, year).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    sampleMasters = GetSampleMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleMasters
    End Function

    ''' <summary>
    ''' This function will give records from Sample Master table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsSampleMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSampleMasterSampleCodeLike(ByVal calledBy As String, ByVal value As String) As ClsSampleMaster()
        Return GetAllSampleMasterValuesLike(calledBy, cSampleCode, value)
    End Function

    ''' <summary>
    ''' This function will give records from Sample Master table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsSampleMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSampleMasterModeLike(ByVal calledBy As String, ByVal value As String) As ClsSampleMaster()
        Return GetAllSampleMasterValuesLike(calledBy, cMode, value)
    End Function

    ''' <summary>
    ''' This function will give records from Sample Master table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsSampleMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSampleMasterCustomerLike(ByVal calledBy As String, ByVal value As String) As ClsSampleMaster()
        Return GetAllSampleMasterValuesLike(calledBy, cCustomerId, value)
    End Function

    ''' <summary>
    ''' This function will give records from Sample Master table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsSampleMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSampleMasterDoctorLike(ByVal calledBy As String, ByVal value As String) As ClsSampleMaster()
        Return GetAllSampleMasterValuesLike(calledBy, cDoctorId, value)
    End Function

    ''' <summary>
    ''' This function will give all records for DateOn between dates from Sample Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>List of ClsSampleMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSampleMasterForDateOn(ByVal calledBy As String, ByVal dateFrom As Date, ByVal dateTo As Date) As List(Of ClsSampleMaster)
        Dim sampleMasterList As New List(Of ClsSampleMaster)

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSampleMasterForDateOn(dateFrom, dateTo).Trim
                If sql = "" Then Exit For

                dsSampleMaster = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If dsSampleMaster.Tables(0).Rows.Count > 0 Then
                    Dim sampleMasters() As ClsSampleMaster = GetSampleMaster(dsSampleMaster.Tables(0).Rows)
                    sampleMasterList.AddRange(sampleMasters)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleMasterList
    End Function

    ''' <summary>
    ''' This function will give all records for given customer Id from preserved dataset.
    ''' </summary>
    ''' <param name="customerId">Customer Id for which the records are required</param>
    ''' <returns>List of ClsSampleMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSampleMasterForCustomerId(ByVal customerId As Integer) As List(Of ClsSampleMaster)
        Dim sampleMasterList As New List(Of ClsSampleMaster)

        Try
            Dim temp As Integer
            For temp = 0 To 0
                If dsSampleMaster Is Nothing Then Exit For

                If dsSampleMaster.Tables(0).Rows.Count > 0 Then
                    Dim str As String = cCustomerId + " = " + CStr(customerId)
                    Dim dtRow() As DataRow = dsSampleMaster.Tables(0).Select(str)
                    If dtRow.Length <> 0 Then sampleMasterList.AddRange(GetSampleMaster(dtRow))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleMasterList
    End Function

    ''' <summary>
    ''' This function will give all Ids from preserved dataset.
    ''' </summary>
    ''' <returns>List of long</returns>
    ''' <remarks></remarks>
    Public Function GetAllSampleMasterId() As List(Of Long)
        Dim idList As New List(Of Long)

        Try
            Dim temp As Integer
            For temp = 0 To 0
                If dsSampleMaster Is Nothing Then Exit For

                If dsSampleMaster.Tables(0).Rows.Count > 0 Then
                    For Each row As DataRow In dsSampleMaster.Tables(0).Rows
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
    ''' This function will give record from Sample Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="loginName">Login Name for which the record is required</param>
    ''' <returns>ClsSampleMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetSampleMasterNotClosedForLogin(ByVal calledBy As String, ByVal loginName As String) As ClsSampleMaster
        Dim sampleMaster As ClsSampleMaster = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetSampleMasterNotClosedForLogin(loginName).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    sampleMaster = GetSampleMasterObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleMaster
    End Function

    ''' <summary>
    ''' This function will give sample id from Sample Master table not closed.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="loginName">Login Name for which the record is required</param>
    ''' <returns>Id in Long or cInvalidId</returns>
    ''' <remarks></remarks>
    Public Function GetSampleMasterIdNotClosedForLogin(ByVal calledBy As String, ByVal loginName As String) As Long
        Dim result As Long = cInvalidId

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetSampleMasterIdNotClosedForLogin(loginName).Trim
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
    ''' This function will give record from Sample Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsSampleMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetSampleMaster(ByVal calledBy As String, ByVal id As Long) As ClsSampleMaster
        Dim sampleMaster As ClsSampleMaster = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetSampleMaster(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    sampleMaster = GetSampleMasterObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleMaster
    End Function

    ''' <summary>
    ''' This function will give Net Amount from Sample Master table for given id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which amount is required</param>
    ''' <returns>Amount in Double</returns>
    ''' <remarks></remarks>
    Public Function GetSampleMasterNetAmount(ByVal calledBy As String, ByVal id As Long) As Double
        Dim result As Double = 0

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetSampleMasterNetAmount(id).Trim
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
    ''' This function will give discount Amount from Sample Master table for given id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which amount is required</param>
    ''' <returns>Amount in Double</returns>
    ''' <remarks></remarks>
    Public Function GetSampleMasterDiscountAmount(ByVal calledBy As String, ByVal id As Long) As Double
        Dim result As Double = 0

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetSampleMasterDiscountAmount(id).Trim
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
    ''' This function is used to insert Sample Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="sampleMasterObj">ClsSampleMaster object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoSampleMaster(ByVal calledBy As String, ByRef sampleMasterObj As ClsSampleMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoSampleMaster(sampleMasterObj).Trim
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
    ''' This function is used to update Sample Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="sampleMasterObj">ClsSampleMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateSampleMaster(ByVal calledBy As String, ByRef sampleMasterObj As ClsSampleMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateSampleMaster(sampleMasterObj).Trim
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