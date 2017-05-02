'Handles all Functionality related to ClsJournalEntry
Module ModJournalEntryDAL

    Private Function GetJournalEntryObj(ByRef row As DataRow) As ClsJournalEntry
        Dim journalEntry As New ClsJournalEntry
        Try
            With row
                journalEntry.Id = .Item(cId)
                journalEntry.JournalNo = .Item(cJournalNo)
                journalEntry.Journaldate = .Item(cJournaldate)
                journalEntry.HeadId = .Item(cHeadId)
                journalEntry.DrAmount = .Item(cDrAmount)
                journalEntry.CrAmount = .Item(cCrAmount)
                journalEntry.Remark = .Item(cRemark)
                journalEntry.InvoiceNo = .Item(cInvoiceNo)
                journalEntry.UserId = .Item(cUserId)
                journalEntry.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return journalEntry
    End Function

    Private Function GetJournalEntry(ByRef rows As DataRowCollection) As ClsJournalEntry()
        Dim journalEntrys(0) As ClsJournalEntry
        journalEntrys = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer
                Array.Resize(journalEntrys, count)
                For x = 0 To count - 1
                    journalEntrys(x) = GetJournalEntryObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return journalEntrys
    End Function

    ''' <summary>
    ''' This function will give records from Journal Entry table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsCategoryMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllJournalEntry(ByVal calledBy As String) As ClsJournalEntry()
        Dim journalEntrys(0) As ClsJournalEntry
        journalEntrys = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllJournalEntry().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    journalEntrys = GetJournalEntry(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return journalEntrys
    End Function

    ''' <summary>
    ''' This function will give records from Journal Entry table for given value.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="journal">Nounal No</param>
    ''' <returns>ClsCategoryMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllJournalEntryForJournal(ByVal calledBy As String, ByVal journal As String) As ClsJournalEntry()
        Dim journalEntrys(0) As ClsJournalEntry
        journalEntrys = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllJournalEntryForJournal(journal).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    If calledBy = "GetNewJournalNo" Then    'This will ignore initializing
                        Array.Resize(journalEntrys, 1)
                        journalEntrys(0) = New ClsJournalEntry
                    Else
                        journalEntrys = GetJournalEntry(ds.Tables(0).Rows)
                    End If
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return journalEntrys
    End Function

    ''' <summary>
    ''' This function will give all journal nos from Journal Entry table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of String or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllJournalEntryWithDistinctJournalNo(ByVal calledBy As String) As String()
        Dim journalNos(0) As String
        journalNos = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllJournalEntryWithDistinctJournalNo().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                Dim count As Integer = ds.Tables(0).Rows.Count
                If count > 0 Then
                    Dim x As Integer
                    Array.Resize(journalNos, count)
                    For x = 0 To count - 1
                        journalNos(x) = ds.Tables(0).Rows(x).Item(0).ToString
                    Next
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return journalNos
    End Function

    ''' <summary>
    ''' This function will give records from Journal Entry table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsCategoryMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetJournalEntry(ByVal calledBy As String, ByVal id As Long) As ClsJournalEntry
        Dim journalEntry As ClsJournalEntry = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetJournalEntry(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    journalEntry = GetJournalEntryObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return journalEntry
    End Function

    ''' <summary>
    ''' This function is used to insert Journal Entry Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="journalEntrysObj">ClsJournalEntrys object to insert</param>
    ''' <returns>Id in long</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoJournalEntry(ByVal calledBy As String, ByRef journalEntrysObj As ClsJournalEntry) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoJournalEntry(journalEntrysObj).Trim
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
    ''' This function is used to update Journal Entry Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="journalEntrysObj">ClsJournalEntrys object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateJournalEntry(ByVal calledBy As String, ByRef journalEntrysObj As ClsJournalEntry) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateJournalEntry(journalEntrysObj).Trim
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
    ''' This function is used to delete Journal Entry Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is to delete</param>
    ''' <remarks></remarks>
    Public Function DeleteJournalEntry(ByVal calledBy As String, ByVal id As Long) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DeleteJournalEntry(id).Trim
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
