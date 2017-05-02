'Handles all Functionality related to ClsDebitNote
Module ModDebitNoteDAL

    Private Function GetDebitNoteObj(ByRef row As DataRow) As ClsDebitNote
        Dim debitNoteObj As New ClsDebitNote
        Try
            With row
                debitNoteObj.Id = .Item(cId)
                debitNoteObj.Code = .Item(cCode)
                debitNoteObj.AgainstCode = .Item(cAgainstCode)
                debitNoteObj.VendorCode = .Item(cVendorCode)
                debitNoteObj.NoteDate = .Item(cNoteDate)
                debitNoteObj.Amount = .Item(cAmount)
                debitNoteObj.Narration = .Item(cNarration)
                debitNoteObj.Remark = .Item(cRemark)
                debitNoteObj.UserId = .Item(cUserId)
                debitNoteObj.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return debitNoteObj
    End Function

    Private Function GetDebitNote(ByRef rows As DataRowCollection) As ClsDebitNote()
        Dim debitNotes(0) As ClsDebitNote
        debitNotes = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer
                Array.Resize(debitNotes, count)
                For x = 0 To count - 1
                    debitNotes(x) = GetDebitNoteObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return debitNotes
    End Function

    ''' <summary>
    ''' This function will give records from Cash Note table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsDebitNote Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllDebitNotes(ByVal calledBy As String) As ClsDebitNote()
        Dim debitNotes(0) As ClsDebitNote
        debitNotes = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllDebitNote().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    debitNotes = GetDebitNote(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return debitNotes
    End Function

    ''' <summary>
    ''' This function will give records from Debit Note table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="forField">Field in which search takes place</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsDebitNote Object or nothing</returns>
    ''' <remarks></remarks>
    Private Function GetAllDebitNoteValuesLike(ByVal calledBy As String, ByVal forField As String, ByVal value As String) As ClsDebitNote()
        Dim debitNotes(0) As ClsDebitNote
        debitNotes = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllDebitNoteValuesLike(forField, value).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    debitNotes = GetDebitNote(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return debitNotes
    End Function

    ''' <summary>
    ''' This function will give records from Debit Note table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="day">Day for which search takes place</param>
    ''' <param name="month">Month for which search takes place</param>
    ''' <param name="year">Year for which search takes place</param>
    ''' <returns>Array of ClsDebitNote Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllDebitNoteLikeNoteDate(ByVal calledBy As String, Optional ByVal day As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "") As ClsDebitNote()
        Dim debitNotes(0) As ClsDebitNote
        debitNotes = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllDebitNoteLikeNoteDate(day, month, year).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    debitNotes = GetDebitNote(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return debitNotes
    End Function

    ''' <summary>
    ''' This function will give records from Debit Note table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsDebitNote Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllDebitNoteCodeLike(ByVal calledBy As String, ByVal value As String) As ClsDebitNote()
        Return GetAllDebitNoteValuesLike(calledBy, cCode, value)
    End Function

    ''' <summary>
    ''' This function will give records from Debit Note table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsDebitNote Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllDebitNoteVendorLike(ByVal calledBy As String, ByVal value As String) As ClsDebitNote()
        Return GetAllDebitNoteValuesLike(calledBy, cVendorCode, value)
    End Function

    ''' <summary>
    ''' This function will give records from Cash Note table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsDebitNote Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetDebitNote(ByVal calledBy As String, ByVal id As Long) As ClsDebitNote
        Dim debitNote As ClsDebitNote = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetDebitNote(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    debitNote = GetDebitNoteObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return debitNote
    End Function

    ''' <summary>
    ''' This function is used to insert Cash Note Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="debitNotesObj">ClsDebitNotes object to insert</param>
    ''' <returns>Id in long</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoDebitNote(ByVal calledBy As String, ByRef debitNotesObj As ClsDebitNote) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoDebitNote(debitNotesObj).Trim
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
    ''' This function is used to update Cash Note Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="debitNotesObj">ClsDebitNotes object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateDebitNote(ByVal calledBy As String, ByRef debitNotesObj As ClsDebitNote) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateDebitNote(debitNotesObj).Trim
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
