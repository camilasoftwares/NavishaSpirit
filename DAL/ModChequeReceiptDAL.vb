'Handles all Functionality related to ClsChequeReceipt
Module ModChequeReceiptDAL

    Private Function GetChequeReceiptObj(ByRef row As DataRow) As ClsChequeReceipt
        Dim ChequeReceipt As New ClsChequeReceipt
        Try
            With row
                ChequeReceipt.Id = .Item(cId)
                ChequeReceipt.FromHeadId = .Item(cFromHeadId)
                ChequeReceipt.ToHeadId = .Item(cToHeadId)
                ChequeReceipt.ChequeNo = .Item(cChequeNo)
                ChequeReceipt.ChequeDate = .Item(cChequeDate)
                ChequeReceipt.Amount = .Item(cAmount)
                ChequeReceipt.InvoiceNo = .Item(cInvoiceNo)
                ChequeReceipt.BankName = .Item(cBankName)
                ChequeReceipt.SendToBank = .Item(cSendToBank)
                ChequeReceipt.Remark = .Item(cRemark)
                ChequeReceipt.UserId = .Item(cUserId)
                ChequeReceipt.DateOn = .Item(cDateOn)
                ChequeReceipt.ReceiptDate = .Item(cReceiptDate)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ChequeReceipt
    End Function

    Private Function GetChequeReceipt(ByRef rows As DataRowCollection) As ClsChequeReceipt()
        Dim ChequeReceipts(0) As ClsChequeReceipt
        ChequeReceipts = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer
                Array.Resize(ChequeReceipts, count)
                For x = 0 To count - 1
                    ChequeReceipts(x) = GetChequeReceiptObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ChequeReceipts
    End Function

    ''' <summary>
    ''' This function will give records from Cheque Receipt table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsChequeReceipt  Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllChequeReceipts(ByVal calledBy As String) As ClsChequeReceipt()
        Dim ChequeReceipts(0) As ClsChequeReceipt
        ChequeReceipts = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllChequeReceipt().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    ChequeReceipts = GetChequeReceipt(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ChequeReceipts
    End Function

    ''' <summary>
    ''' This function will give all bank names from Cheque Receipt table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>List of string</returns>
    ''' <remarks></remarks>
    Public Function GetAllBankName(ByVal calledBy As String) As List(Of String)
        Dim bankNames As New List(Of String)

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllBankName().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                Dim count As Integer = ds.Tables(0).Rows.Count
                If count > 0 Then
                    Dim x As Integer
                    For x = 0 To count - 1
                        Dim str As String = ds.Tables(0).Rows(x).Item(0).ToString
                        bankNames.Add(str)
                    Next
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return bankNames
    End Function

    ''' <summary>
    ''' This function will give records from Cheque Receipt table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="forField">Field in which search takes place</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsChequeReceipt Object or nothing</returns>
    ''' <remarks></remarks>
    Private Function GetAllChequeReceiptValuesLike(ByVal calledBy As String, ByVal forField As String, ByVal value As String) As ClsChequeReceipt()
        Dim chequeReceipts(0) As ClsChequeReceipt
        chequeReceipts = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllChequeReceiptValuesLike(forField, value).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    chequeReceipts = GetChequeReceipt(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return chequeReceipts
    End Function

    ''' <summary>
    ''' This function will give records from Cheque Receipt table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="fieldName">Field in which search takes place</param>
    ''' <param name="day">Day for which search takes place</param>
    ''' <param name="month">Month for which search takes place</param>
    ''' <param name="year">Year for which search takes place</param>
    ''' <returns>Array of ClsChequeReceipt Objects or nothing</returns>
    ''' <remarks></remarks>
    Private Function GetAllChequeReceiptLikeDate(ByVal calledBy As String, ByVal fieldName As String, Optional ByVal day As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "") As ClsChequeReceipt()
        Dim chequeReceipts(0) As ClsChequeReceipt
        chequeReceipts = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllChequeReceiptLikeDate(fieldName, day, month, year).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    chequeReceipts = GetChequeReceipt(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return chequeReceipts
    End Function

    ''' <summary>
    ''' This function will give records from Cheque Receipt table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="day">Day for which search takes place</param>
    ''' <param name="month">Month for which search takes place</param>
    ''' <param name="year">Year for which search takes place</param>
    ''' <returns>Array of ClsChequeReceipt Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllChequeReceiptLikeReceiptDate(ByVal calledBy As String, Optional ByVal day As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "") As ClsChequeReceipt()
        Return GetAllChequeReceiptLikeDate(calledBy, cReceiptDate, day, month, year)
    End Function

    ''' <summary>
    ''' This function will give records from Cheque Receipt table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="day">Day for which search takes place</param>
    ''' <param name="month">Month for which search takes place</param>
    ''' <param name="year">Year for which search takes place</param>
    ''' <returns>Array of ClsChequeReceipt Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllChequeReceiptLikeChequeDate(ByVal calledBy As String, Optional ByVal day As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "") As ClsChequeReceipt()
        Return GetAllChequeReceiptLikeDate(calledBy, cChequeDate, day, month, year)
    End Function

    ''' <summary>
    ''' This function will give records from Cheque Receipt table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsChequeReceipt Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllChequeReceiptCodeLike(ByVal calledBy As String, ByVal value As String) As ClsChequeReceipt()
        Return GetAllChequeReceiptValuesLike(calledBy, cCode, value)
    End Function

    ''' <summary>
    ''' This function will give records from Cheque Receipt table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsChequeReceipt Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllChequeReceiptInvoiceNoLike(ByVal calledBy As String, ByVal value As String) As ClsChequeReceipt()
        Return GetAllChequeReceiptValuesLike(calledBy, cInvoiceNo, value)
    End Function

    ''' <summary>
    ''' This function will give records from Cheque Receipt table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsChequeReceipt Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllChequeReceiptReceiptFromLike(ByVal calledBy As String, ByVal value As String) As ClsChequeReceipt()
        Return GetAllChequeReceiptValuesLike(calledBy, cFromHeadId, value)
    End Function

    ''' <summary>
    ''' This function will give records from Cheque Receipt table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsChequeReceipt Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllChequeReceiptBankNameLike(ByVal calledBy As String, ByVal value As String) As ClsChequeReceipt()
        Return GetAllChequeReceiptValuesLike(calledBy, cBankName, value)
    End Function

    ''' <summary>
    ''' This function will give records from Cheque Receipt table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsChequeReceipt Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetChequeReceipt(ByVal calledBy As String, ByVal id As Long) As ClsChequeReceipt
        Dim chequeReceipt As ClsChequeReceipt = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetChequeReceipt(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    chequeReceipt = GetChequeReceiptObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return chequeReceipt
    End Function

    ''' <summary>
    ''' This function is used to insert Cheque Receipt Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="chequeReceiptsObj">ClsChequeReceipts object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoChequeReceipt(ByVal calledBy As String, ByRef chequeReceiptsObj As ClsChequeReceipt) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoChequeReceipt(chequeReceiptsObj).Trim
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
    ''' This function is used to update Cheque Receipt Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="chequeReceiptsObj">ClsChequeReceipts object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateChequeReceipt(ByVal calledBy As String, ByRef chequeReceiptsObj As ClsChequeReceipt) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateChequeReceipt(chequeReceiptsObj).Trim
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
    ''' This function is used to delete Cheque Receipt Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is to delete</param>
    ''' <remarks></remarks>
    Public Function DeleteChequeReceipt(ByVal calledBy As String, ByVal id As Long) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DeleteChequeReceipt(id).Trim
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
