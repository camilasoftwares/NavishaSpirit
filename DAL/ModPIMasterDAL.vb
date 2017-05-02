'Handles all Functionality related to ClsPIMaster
Module ModPIMasterDAL

    Private Function GetPIMasterObj(ByRef row As DataRow) As ClsPIMaster
        Dim piMaster As New ClsPIMaster
        Try
            With row
                piMaster.Id = .Item(cId)
                piMaster.Name = .Item(cName)
                piMaster.UserId = .Item(cUserId)
                piMaster.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return piMaster
    End Function

    Private Function GetPIMaster(ByRef rows As DataRowCollection) As ClsPIMaster()
        Dim piMasters(0) As ClsPIMaster
        piMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(piMasters, count)
                For x = 0 To count - 1
                    piMasters(x) = GetPIMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return piMasters
    End Function

    ''' <summary>
    ''' This function will give records from PI Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsPIMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPIMaster(ByVal calledBy As String) As ClsPIMaster()
        Dim piMasters(0) As ClsPIMaster
        piMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllPIMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    piMasters = GetPIMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return piMasters
    End Function

    ''' <summary>
    ''' This function is used to insert PI Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="piMasterObj">ClsPIMaster object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoPIMaster(ByVal calledBy As String, ByRef piMasterObj As ClsPIMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoPIMaster(piMasterObj).Trim
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
    ''' This function is used to update PI Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="piMasterObj">ClsPIMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdatePIMaster(ByVal calledBy As String, ByRef piMasterObj As ClsPIMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdatePIMaster(piMasterObj).Trim
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