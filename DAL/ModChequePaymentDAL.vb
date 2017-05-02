'Handles all Functionality related to ClsChequePayment
Module ModChequePaymentDAL

    Private Function GetChequePaymentObj(ByRef row As DataRow) As ClsChequePayment
        Dim ChequePayment As New ClsChequePayment
        Try
            With row
                ChequePayment.Id = .Item(cId)
                ChequePayment.ToHeadId = .Item(cToHeadId)
                ChequePayment.FromHeadId = .Item(cFromHeadId)
                ChequePayment.ChequeNo = .Item(cChequeNo)
                ChequePayment.ChequeDate = .Item(cChequeDate)
                ChequePayment.Amount = .Item(cAmount)
                ChequePayment.BillNo = .Item(cBillNo)
                ChequePayment.Remark = .Item(cRemark)
                ChequePayment.UserId = .Item(cUserId)
                ChequePayment.DateOn = .Item(cDateOn)
                ChequePayment.PaymentDate = .Item(cPaymentDate)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ChequePayment
    End Function

    Private Function GetChequePayment(ByRef rows As DataRowCollection) As ClsChequePayment()
        Dim ChequePayments(0) As ClsChequePayment
        ChequePayments = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer
                Array.Resize(ChequePayments, count)
                For x = 0 To count - 1
                    ChequePayments(x) = GetChequePaymentObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ChequePayments
    End Function

    ''' <summary>
    ''' This function will give records from Cheque Payment table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsChequePaymentObject or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllChequePayments(ByVal calledBy As String) As ClsChequePayment()
        Dim ChequePayments(0) As ClsChequePayment
        ChequePayments = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllChequePayment().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    ChequePayments = GetChequePayment(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ChequePayments
    End Function

    ''' <summary>
    ''' This function will give records from Cheque Payment table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="forField">Field in which search takes place</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsChequePayment Object or nothing</returns>
    ''' <remarks></remarks>
    Private Function GetAllChequePaymentValuesLike(ByVal calledBy As String, ByVal forField As String, ByVal value As String) As ClsChequePayment()
        Dim chequePayments(0) As ClsChequePayment
        chequePayments = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllChequePaymentValuesLike(forField, value).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    chequePayments = GetChequePayment(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return chequePayments
    End Function

    ''' <summary>
    ''' This function will give records from Cheque Payment table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="fieldName">Field in which search takes place</param>
    ''' <param name="day">Day for which search takes place</param>
    ''' <param name="month">Month for which search takes place</param>
    ''' <param name="year">Year for which search takes place</param>
    ''' <returns>Array of ClsChequePayment Objects or nothing</returns>
    ''' <remarks></remarks>
    Private Function GetAllChequePaymentLikeDate(ByVal calledBy As String, ByVal fieldName As String, Optional ByVal day As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "") As ClsChequePayment()
        Dim chequePayments(0) As ClsChequePayment
        chequePayments = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllChequePaymentLikeDate(fieldName, day, month, year).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    chequePayments = GetChequePayment(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return chequePayments
    End Function

    ''' <summary>
    ''' This function will give records from Cheque Payment table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="day">Day for which search takes place</param>
    ''' <param name="month">Month for which search takes place</param>
    ''' <param name="year">Year for which search takes place</param>
    ''' <returns>Array of ClsChequePayment Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllChequePaymentLikePaymentDate(ByVal calledBy As String, Optional ByVal day As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "") As ClsChequePayment()
        Return GetAllChequePaymentLikeDate(calledBy, cPaymentDate, day, month, year)
    End Function

    ''' <summary>
    ''' This function will give records from Cheque Payment table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="day">Day for which search takes place</param>
    ''' <param name="month">Month for which search takes place</param>
    ''' <param name="year">Year for which search takes place</param>
    ''' <returns>Array of ClsChequePayment Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllChequePaymentLikeChequeDate(ByVal calledBy As String, Optional ByVal day As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "") As ClsChequePayment()
        Return GetAllChequePaymentLikeDate(calledBy, cChequeDate, day, month, year)
    End Function

    ''' <summary>
    ''' This function will give records from Cheque Payment table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsChequePayment Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllChequePaymentCodeLike(ByVal calledBy As String, ByVal value As String) As ClsChequePayment()
        Return GetAllChequePaymentValuesLike(calledBy, cCode, value)
    End Function

    ''' <summary>
    ''' This function will give records from Cheque Payment table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsChequePayment Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllChequePaymentBillNoLike(ByVal calledBy As String, ByVal value As String) As ClsChequePayment()
        Return GetAllChequePaymentValuesLike(calledBy, cBillNo, value)
    End Function

    ''' <summary>
    ''' This function will give records from Cheque Payment table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsChequePayment Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllChequePaymentPaymentToLike(ByVal calledBy As String, ByVal value As String) As ClsChequePayment()
        Return GetAllChequePaymentValuesLike(calledBy, cToHeadId, value)
    End Function

    ''' <summary>
    ''' This function will give records from Cheque Payment table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsChequePayment Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetChequePayment(ByVal calledBy As String, ByVal id As Long) As ClsChequePayment
        Dim chequePayment As ClsChequePayment = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetChequePayment(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    chequePayment = GetChequePaymentObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return chequePayment
    End Function

    ''' <summary>
    ''' This function is used to insert Cheque Payment Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="chequePaymentsObj">ClsChequePayment object to insert</param>
    ''' <returns>Id in Long</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoChequePayment(ByVal calledBy As String, ByRef chequePaymentsObj As ClsChequePayment) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoChequePayment(chequePaymentsObj).Trim
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
    ''' This function is used to update Cheque Payment Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="chequePaymentsObj">ClsChequePayments object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateChequePayment(ByVal calledBy As String, ByRef chequePaymentsObj As ClsChequePayment) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateChequePayment(chequePaymentsObj).Trim
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
    ''' This function is used to delete Cheque Payment Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is to delete</param>
    ''' <remarks></remarks>
    Public Function DeleteChequePayment(ByVal calledBy As String, ByVal id As Long) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DeleteChequePayment(id).Trim
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
