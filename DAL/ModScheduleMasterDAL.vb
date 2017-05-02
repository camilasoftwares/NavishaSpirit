'Handles all Functionality related to ClsScheduleMaster
Module ModScheduleMasterDAL

    Private Function GetScheduleMasterObj(ByRef row As DataRow) As ClsScheduleMaster
        Dim scheduleMaster As New ClsScheduleMaster
        Try
            With row
                scheduleMaster.Id = .Item(cId)
                scheduleMaster.Name = .Item(cName)
                scheduleMaster.Color = .Item(cColor)
                scheduleMaster.Prompt = .Item(cPrompt)
                scheduleMaster.UserId = .Item(cUserId)
                scheduleMaster.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return scheduleMaster
    End Function

    Private Function GetScheduleMaster(ByRef rows As DataRowCollection) As ClsScheduleMaster()
        Dim scheduleMasters(0) As ClsScheduleMaster
        scheduleMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(scheduleMasters, count)
                For x = 0 To count - 1
                    scheduleMasters(x) = GetScheduleMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return scheduleMasters
    End Function

    ''' <summary>
    ''' This function is used to check that given ClsScheduleMaster Object is possible to update.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="scheduleMasterObj">ClsScheduleMaster Object to check</param>
    ''' <returns>True if updatable otherwise False</returns>
    ''' <remarks></remarks>
    Public Function ScheduleMasterUpdatable(ByVal calledBy As String, ByRef scheduleMasterObj As ClsScheduleMaster) As Boolean
        Dim updatable As Boolean = True

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.ScheduleMasterUpdatable(scheduleMasterObj).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    updatable = False
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return updatable
    End Function

    ''' <summary>
    ''' This function will give records from Schedule Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsScheduleMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllScheduleMaster(ByVal calledBy As String) As ClsScheduleMaster()
        Dim scheduleMasters(0) As ClsScheduleMaster
        scheduleMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllScheduleMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    scheduleMasters = GetScheduleMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return scheduleMasters
    End Function

    ''' <summary>
    ''' This function is used to insert Schedule Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="scheduleMasterObj">ClsScheduleMaster object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoScheduleMaster(ByVal calledBy As String, ByRef scheduleMasterObj As ClsScheduleMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoScheduleMaster(scheduleMasterObj).Trim
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
    ''' This function is used to update Schedule Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="scheduleMasterObj">ClsScheduleMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateScheduleMaster(ByVal calledBy As String, ByRef scheduleMasterObj As ClsScheduleMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateScheduleMaster(scheduleMasterObj).Trim
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