'Handles all Functionality related to ClsCreditNote
Module ModCreditNoteDAL

    Private Function GetCreditNoteObj(ByRef row As DataRow) As ClsCreditNote
        Dim creditNoteObj As New ClsCreditNote
        Try
            With row
                creditNoteObj.Id = .Item(cId)
                creditNoteObj.Code = .Item(cCode)
                creditNoteObj.AgainstCode = .Item(cAgainstCode)
                creditNoteObj.CustomerCode = .Item(cCustomerCode)
                creditNoteObj.NoteDate = .Item(cNoteDate)
                creditNoteObj.Amount = .Item(cAmount)
                creditNoteObj.Narration = .Item(cNarration)
                creditNoteObj.Remark = .Item(cRemark)
                creditNoteObj.UserId = .Item(cUserId)
                creditNoteObj.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return creditNoteObj
    End Function

    Private Function GetCreditNote(ByRef rows As DataRowCollection) As ClsCreditNote()
        Dim creditNotes(0) As ClsCreditNote
        creditNotes = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer
                Array.Resize(creditNotes, count)
                For x = 0 To count - 1
                    creditNotes(x) = GetCreditNoteObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return creditNotes
    End Function

    ''' <summary>
    ''' This function will give records from Cash Note table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsCreditNote Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCreditNotes(ByVal calledBy As String) As ClsCreditNote()
        Dim creditNotes(0) As ClsCreditNote
        creditNotes = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCreditNote().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    creditNotes = GetCreditNote(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return creditNotes
    End Function

    ''' <summary>
    ''' This function will give records from Credit Note table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="forField">Field in which search takes place</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsCreditNote Object or nothing</returns>
    ''' <remarks></remarks>
    Private Function GetAllCreditNoteValuesLike(ByVal calledBy As String, ByVal forField As String, ByVal value As String) As ClsCreditNote()
        Dim creditNotes(0) As ClsCreditNote
        creditNotes = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCreditNoteValuesLike(forField, value).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    creditNotes = GetCreditNote(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return creditNotes
    End Function

    ''' <summary>
    ''' This function will give records from Credit Note table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="day">Day for which search takes place</param>
    ''' <param name="month">Month for which search takes place</param>
    ''' <param name="year">Year for which search takes place</param>
    ''' <returns>Array of ClsCreditNote Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCreditNoteLikeNoteDate(ByVal calledBy As String, Optional ByVal day As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "") As ClsCreditNote()
        Dim creditNotes(0) As ClsCreditNote
        creditNotes = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCreditNoteLikeNoteDate(day, month, year).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    creditNotes = GetCreditNote(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return creditNotes
    End Function

    ''' <summary>
    ''' This function will give records from Credit Note table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsCreditNote Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCreditNoteCodeLike(ByVal calledBy As String, ByVal value As String) As ClsCreditNote()
        Return GetAllCreditNoteValuesLike(calledBy, cCode, value)
    End Function

    ''' <summary>
    ''' This function will give records from Credit Note table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsCreditNote Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCreditNoteCustomerLike(ByVal calledBy As String, ByVal value As String) As ClsCreditNote()
        Return GetAllCreditNoteValuesLike(calledBy, cCustomerCode, value)
    End Function

    ''' <summary>
    ''' This function will give records from Cash Note table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsCreditNote Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCreditNote(ByVal calledBy As String, ByVal id As Long) As ClsCreditNote
        Dim creditNote As ClsCreditNote = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetCreditNote(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    creditNote = GetCreditNoteObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return creditNote
    End Function

    ''' <summary>
    ''' This function is used to insert Cash Note Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="creditNotesObj">ClsCreditNotes object to insert</param>
    ''' <returns>Id in long</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoCreditNote(ByVal calledBy As String, ByRef creditNotesObj As ClsCreditNote) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoCreditNote(creditNotesObj).Trim
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
    ''' <param name="creditNotesObj">ClsCreditNotes object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateCreditNote(ByVal calledBy As String, ByRef creditNotesObj As ClsCreditNote) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateCreditNote(creditNotesObj).Trim
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
