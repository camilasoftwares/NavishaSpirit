'Handles all Functionality related to ClsSalesReturnMaster
Module ModSalesReturnMasterDAL

    Private Function GetSalesReturnMasterObj(ByRef row As DataRow) As ClsSalesReturnMaster
        Dim salesReturnMaster As New ClsSalesReturnMaster
        Try
            With row
                salesReturnMaster.Id = .Item(cId)
                salesReturnMaster.SalesReturnCode = .Item(cSalesReturnCode)
                salesReturnMaster.SaleId = .Item(cSaleId)
                salesReturnMaster.CustomerId = .Item(cCustomerId)
                'salesReturnMaster.DoctorId = .Item(cDoctorIdX)
                salesReturnMaster.Status = .Item(cStatus)
                salesReturnMaster.Remark = .Item(cRemark)
                salesReturnMaster.ReturnDate = .Item(cReturnDate)
                salesReturnMaster.UserId = .Item(cUserId)
                salesReturnMaster.DateOn = .Item(cDateOn)
                salesReturnMaster.NotClosed = .Item(cNotClosed)
                salesReturnMaster.DiscountAmount = .Item(cDiscountAmount)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesReturnMaster
    End Function

    Private Function GetSalesReturnMaster(ByRef rows As DataRowCollection) As ClsSalesReturnMaster()
        Dim salesReturnMasters(0) As ClsSalesReturnMaster
        salesReturnMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(SalesReturnMasters, count)
                For x = 0 To count - 1
                    salesReturnMasters(x) = GetSalesReturnMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesReturnMasters
    End Function

    ''' <summary>
    ''' This function will give records from Sales Return Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of ClsSalesReturnMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesReturnMaster(ByVal calledBy As String) As ClsSalesReturnMaster()
        Dim SalesReturnMasters(0) As ClsSalesReturnMaster
        SalesReturnMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSalesReturnMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    SalesReturnMasters = GetSalesReturnMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return SalesReturnMasters
    End Function

    ''' <summary>
    ''' This function will give records from Sales Return Master table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="forField">Field in which to search</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsSalesReturnMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Private Function GetAllSalesReturnMasterValuesLike(ByVal calledBy As String, ByVal forField As String, ByVal value As String) As ClsSalesReturnMaster()
        Dim SalesReturnMasters(0) As ClsSalesReturnMaster
        SalesReturnMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSalesReturnMasterValuesLike(forField, value).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    SalesReturnMasters = GetSalesReturnMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return SalesReturnMasters
    End Function

    ''' <summary>
    ''' This function will give records from Sales Return Master table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="day">Day for which search takes place</param>
    ''' <param name="month">Month for which search takes place</param>
    ''' <param name="year">Year for which search takes place</param>
    ''' <returns>Array of ClsSalesReturnMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesReturnMasterLikeReturnDate(ByVal calledBy As String, Optional ByVal day As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "") As ClsSalesReturnMaster()
        Dim salesReturnMasters(0) As ClsSalesReturnMaster
        salesReturnMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSalesReturnMasterLikeReturnDate(day, month, year).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    salesReturnMasters = GetSalesReturnMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesReturnMasters
    End Function

    ''' <summary>
    ''' This function will give records from Sales Return Master table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsSalesReturnMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesReturnMasterReturnCodeLike(ByVal calledBy As String, ByVal value As String) As ClsSalesReturnMaster()
        Return GetAllSalesReturnMasterValuesLike(calledBy, cSalesReturnCode, value)
    End Function

    ''' <summary>
    ''' This function will give records from Sales Return Master table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsSalesReturnMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesReturnMasterSaleCodeLike(ByVal calledBy As String, ByVal value As String) As ClsSalesReturnMaster()
        Return GetAllSalesReturnMasterValuesLike(calledBy, cSaleId, value)
    End Function

    ''' <summary>
    ''' This function will give records from Sales Return Master table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsSalesReturnMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesReturnMasterCustomerLike(ByVal calledBy As String, ByVal value As String) As ClsSalesReturnMaster()
        Return GetAllSalesReturnMasterValuesLike(calledBy, cCustomerId, value)
    End Function

    ''' <summary>
    ''' This function will give records from Sales Return Master table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsSalesReturnMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesReturnMasterDoctorLike(ByVal calledBy As String, ByVal value As String) As ClsSalesReturnMaster()
        Return GetAllSalesReturnMasterValuesLike(calledBy, cDoctorId, value)
    End Function

    ''' <summary>
    ''' This function will give record from Sales Return Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="loginName">Login Name for which the record is required</param>
    ''' <returns>ClsSalesReturnMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetSalesReturnMasterNotClosedForLogin(ByVal calledBy As String, ByVal loginName As String) As ClsSalesReturnMaster
        Dim salesReturnMaster As ClsSalesReturnMaster = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetSalesReturnMasterNotClosedForLogin(loginName).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    salesReturnMaster = GetSalesReturnMasterObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesReturnMaster
    End Function

    ''' <summary>
    ''' This function will give salesReturn id from Sales Return Master table not closed.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="loginName">Login Name for which the record is required</param>
    ''' <returns>Id in Long or cInvalidId</returns>
    ''' <remarks></remarks>
    Public Function GetSalesReturnMasterIdNotClosedForLogin(ByVal calledBy As String, ByVal loginName As String) As Long
        Dim result As Long = cInvalidId

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetSalesReturnMasterIdNotClosedForLogin(loginName).Trim
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
    ''' This function will give record from Salses Retunn Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which records are required</param>
    ''' <returns>ClsSalesReturnMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetSalesReturnMaster(ByVal calledBy As String, ByVal id As Long) As ClsSalesReturnMaster
        Dim salesReturnMaster As ClsSalesReturnMaster = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetSalesReturnMaster(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    salesReturnMaster = GetSalesReturnMasterObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesReturnMaster
    End Function

    ''' <summary>
    ''' This function will give discount Amount from Sales Return Master table for given id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which amount is required</param>
    ''' <returns>Amount in Double</returns>
    ''' <remarks></remarks>
    Public Function GetSalesReturnMasterDiscountAmount(ByVal calledBy As String, ByVal id As Long) As Double
        Dim result As Double = 0

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetSalesReturnMasterDiscountAmount(id).Trim
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
    ''' This function is used to insert Sales Return Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="salesReturnMastersObj">ClsSalesReturnMasters object to insert</param>
    ''' <returns>Id in long</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoSalesReturnMaster(ByVal calledBy As String, ByRef salesReturnMastersObj As ClsSalesReturnMaster) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoSalesReturnMaster(salesReturnMastersObj).Trim
                If sql = "" Then Exit For

                Dim id As Long = ClsDBFunctions.GetInstance.ExecuteQuery_Scalar(sql, calledBy)
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
    ''' This function is used to update Sales Return Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="salesReturnMastersObj">ClsSalesReturnMasters object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateSalesReturnMaster(ByVal calledBy As String, ByRef salesReturnMastersObj As ClsSalesReturnMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateSalesReturnMaster(salesReturnMastersObj).Trim
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
