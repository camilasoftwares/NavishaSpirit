'Handles all Functionality related to ClsCashReceipt
Module ModCashReceiptDAL

    Private Function GetCashReceiptObj(ByRef row As DataRow) As ClsCashReceipt
        Dim CashReceipt As New ClsCashReceipt
        Try
            With row
                CashReceipt.Id = .Item(cId)
                CashReceipt.ToHeadId = .Item(cToHeadId)
                CashReceipt.FromHeadId = .Item(cFromHeadId)
                CashReceipt.Amount = .Item(cAmount)
                CashReceipt.InvoiceNo = .Item(cInvoiceNo)
                CashReceipt.Remark = .Item(cRemark)
                CashReceipt.UserId = .Item(cUserId)
                CashReceipt.DateOn = .Item(cDateOn)
                CashReceipt.ReceiptDate = .Item(cReceiptDate)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return CashReceipt
    End Function

    Private Function GetCashReceipt(ByRef rows As DataRowCollection) As ClsCashReceipt()
        Dim CashReceipts(0) As ClsCashReceipt
        CashReceipts = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer
                Array.Resize(CashReceipts, count)
                For x = 0 To count - 1
                    CashReceipts(x) = GetCashReceiptObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return CashReceipts
    End Function

    ''' <summary>
    ''' This function will give records from Cash Receipt table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsCashReceipt Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCashReceipts(ByVal calledBy As String) As ClsCashReceipt()
        Dim CashReceipts(0) As ClsCashReceipt
        CashReceipts = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCashReceipt().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    CashReceipts = GetCashReceipt(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return CashReceipts
    End Function

    ''' <summary>
    ''' This function will give records from Cash Receipt table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="forField">Field in which search takes place</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsCashReceipt Object or nothing</returns>
    ''' <remarks></remarks>
    Private Function GetAllCashReceiptValuesLike(ByVal calledBy As String, ByVal forField As String, ByVal value As String) As ClsCashReceipt()
        Dim cashReceipts(0) As ClsCashReceipt
        cashReceipts = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCashReceiptValuesLike(forField, value).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    cashReceipts = GetCashReceipt(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return cashReceipts
    End Function

    ''' <summary>
    ''' This function will give records from Cash Receipt table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="day">Day for which search takes place</param>
    ''' <param name="month">Month for which search takes place</param>
    ''' <param name="year">Year for which search takes place</param>
    ''' <returns>Array of ClsCashReceipt Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCashReceiptLikeReceiptDate(ByVal calledBy As String, Optional ByVal day As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "") As ClsCashReceipt()
        Dim cashReceipts(0) As ClsCashReceipt
        cashReceipts = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCashReceiptLikeReceiptDate(day, month, year).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    cashReceipts = GetCashReceipt(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return cashReceipts
    End Function

    ''' <summary>
    ''' This function will give records from Cash Receipt table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsCashReceipt Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCashReceiptCodeLike(ByVal calledBy As String, ByVal value As String) As ClsCashReceipt()
        Return GetAllCashReceiptValuesLike(calledBy, cCode, value)
    End Function

    ''' <summary>
    ''' This function will give records from Cash Receipt table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsCashReceipt Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCashReceiptInvoiceNoLike(ByVal calledBy As String, ByVal value As String) As ClsCashReceipt()
        Return GetAllCashReceiptValuesLike(calledBy, cInvoiceNo, value)
    End Function

    ''' <summary>
    ''' This function will give records from Cash Receipt table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsCashReceipt Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCashReceiptReceiptFromLike(ByVal calledBy As String, ByVal value As String) As ClsCashReceipt()
        Return GetAllCashReceiptValuesLike(calledBy, cFromHeadId, value)
    End Function

    ''' <summary>
    ''' This function will give records from Cash Receipt table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsCashReceipt Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCashReceipt(ByVal calledBy As String, ByVal id As Long) As ClsCashReceipt
        Dim cashReceipt As ClsCashReceipt = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetCashReceipt(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    cashReceipt = GetCashReceiptObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return cashReceipt
    End Function

    ''' <summary>
    ''' This function is used to insert Cash Receipt Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="cashReceiptsObj">ClsCashReceipts object to insert</param>
    ''' <returns>Id in long</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoCashReceipt(ByVal calledBy As String, ByRef cashReceiptsObj As ClsCashReceipt) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoCashReceipt(cashReceiptsObj).Trim
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
    ''' This function is used to update Cash Receipt Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="cashReceiptsObj">ClsCashReceipts object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateCashReceipt(ByVal calledBy As String, ByRef cashReceiptsObj As ClsCashReceipt) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateCashReceipt(cashReceiptsObj).Trim
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
    ''' This function is used to delete Cash Receipt Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is to delete</param>
    ''' <remarks></remarks>
    Public Function DeleteCashReceipt(ByVal calledBy As String, ByVal id As Long) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DeleteCashReceipt(id).Trim
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
