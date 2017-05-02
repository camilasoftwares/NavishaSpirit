'Handles all Functionality related to ClsCashPayment
Module ModCashPaymentDAL

    Private Function GetCashPaymentObj(ByRef row As DataRow) As ClsCashPayment
        Dim cashPayment As New ClsCashPayment
        Try
            With row
                cashPayment.Id = .Item(cId)
                cashPayment.ToHeadId = .Item(cToHeadId)
                cashPayment.FromHeadId = .Item(cFromHeadId)
                cashPayment.Amount = .Item(cAmount)
                cashPayment.BillNo = .Item(cBillNo)
                cashPayment.Remark = .Item(cRemark)
                cashPayment.UserId = .Item(cUserId)
                cashPayment.DateOn = .Item(cDateOn)
                cashPayment.PaymentDate = .Item(cPaymentDate)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return CashPayment
    End Function

    Private Function GetCashPayment(ByRef rows As DataRowCollection) As ClsCashPayment()
        Dim cashPayments(0) As ClsCashPayment
        cashPayments = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer
                Array.Resize(cashPayments, count)
                For x = 0 To count - 1
                    cashPayments(x) = GetCashPaymentObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return cashPayments
    End Function

    ''' <summary>
    ''' This function will give records from Cash Payment table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsCashPayment Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCashPayments(ByVal calledBy As String) As ClsCashPayment()
        Dim CashPayments(0) As ClsCashPayment
        CashPayments = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCashPayment().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    CashPayments = GetCashPayment(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return CashPayments
    End Function

    ''' <summary>
    ''' This function will give records from Cash Payment table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="forField">Field in which search takes place</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsCashPayment Object or nothing</returns>
    ''' <remarks></remarks>
    Private Function GetAllCashPaymentValuesLike(ByVal calledBy As String, ByVal forField As String, ByVal value As String) As ClsCashPayment()
        Dim cashPayments(0) As ClsCashPayment
        cashPayments = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCashPaymentValuesLike(forField, value).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    cashPayments = GetCashPayment(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return cashPayments
    End Function

    ''' <summary>
    ''' This function will give records from Cash Payment table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="day">Day for which search takes place</param>
    ''' <param name="month">Month for which search takes place</param>
    ''' <param name="year">Year for which search takes place</param>
    ''' <returns>Array of ClsCashPayment Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCashPaymentLikePaymentDate(ByVal calledBy As String, Optional ByVal day As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "") As ClsCashPayment()
        Dim cashPayments(0) As ClsCashPayment
        cashPayments = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCashPaymentLikePaymentDate(day, month, year).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    cashPayments = GetCashPayment(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return cashPayments
    End Function

    ''' <summary>
    ''' This function will give records from Cash Payment table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsCashPayment Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCashPaymentCodeLike(ByVal calledBy As String, ByVal value As String) As ClsCashPayment()
        Return GetAllCashPaymentValuesLike(calledBy, cCode, value)
    End Function

    ''' <summary>
    ''' This function will give records from Cash Payment table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsCashPayment Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCashPaymentBillNoLike(ByVal calledBy As String, ByVal value As String) As ClsCashPayment()
        Return GetAllCashPaymentValuesLike(calledBy, cBillNo, value)
    End Function

    ''' <summary>
    ''' This function will give records from Cash Payment table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsCashPayment Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCashPaymentPaymentToLike(ByVal calledBy As String, ByVal value As String) As ClsCashPayment()
        Return GetAllCashPaymentValuesLike(calledBy, cToHeadId, value)
    End Function

    ''' <summary>
    ''' This function will give records from Cash Payment table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsCashPayment Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCashPayment(ByVal calledBy As String, ByVal id As Long) As ClsCashPayment
        Dim cashPayment As ClsCashPayment = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetCashPayment(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    cashPayment = GetCashPaymentObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return cashPayment
    End Function

    ''' <summary>
    ''' This function is used to insert Cash Payment Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="cashPaymentsObj">ClsCashPayments object to insert</param>
    ''' <returns>Id in long</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoCashPayment(ByVal calledBy As String, ByRef cashPaymentsObj As ClsCashPayment) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoCashPayment(cashPaymentsObj).Trim
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
    ''' This function is used to update Cash Payment Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="cashPaymentsObj">ClsCashPayments object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateCashPayment(ByVal calledBy As String, ByRef cashPaymentsObj As ClsCashPayment) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateCashPayment(cashPaymentsObj).Trim
                If sql = "" Then Exit For

                If ClsDBFunctions.GetInstance.ExecuteQuery_NonQuery(sql, calledBy) > 0 Then result = EnResult.Change
            Next

        Catch ex As Exception
            AddToLog(ex)
            result = EnResult.Err
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to delete Cash Payment Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is to delete</param>
    ''' <remarks></remarks>
    Public Function DeleteCashPayment(ByVal calledBy As String, ByVal id As Long) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DeleteCashPayment(id).Trim
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
