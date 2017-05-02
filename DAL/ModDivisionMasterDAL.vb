'Handles all Functionality related to ClsDivisionMaster
Module ModDivisionMasterDAL

    Private Function GetDivisionMasterObj(ByRef row As DataRow) As ClsDivisionMaster
        Dim divisionMaster As New ClsDivisionMaster
        Try
            With row
                divisionMaster.Id = .Item(cId)
                divisionMaster.Name = .Item(cName)
                divisionMaster.UserId = .Item(cUserId)
                divisionMaster.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return divisionMaster
    End Function

    Private Function GetDivisionMaster(ByRef rows As DataRowCollection) As ClsDivisionMaster()
        Dim divisionMasters(0) As ClsDivisionMaster
        divisionMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(divisionMasters, count)
                For x = 0 To count - 1
                    divisionMasters(x) = GetDivisionMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return divisionMasters
    End Function

    ''' <summary>
    ''' This function is used to check that given ClsDivisionMaster Object is possible to update.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="divisionMasterObj">ClsDivisionMaster Object to check</param>
    ''' <returns>True if update division otherwise False</returns>
    ''' <remarks></remarks>
    Public Function DivisionMasterUpdatable(ByVal calledBy As String, ByRef divisionMasterObj As ClsDivisionMaster) As Boolean
        Dim updateDivision As Boolean = True

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DivisionMasterUpdatable(divisionMasterObj).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    updateDivision = False
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return updateDivision
    End Function

    ''' <summary>
    ''' This function will give records from Division Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsDivisionMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllDivisionMaster(ByVal calledBy As String) As ClsDivisionMaster()
        Dim divisionMasters(0) As ClsDivisionMaster
        divisionMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllDivisionMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    divisionMasters = GetDivisionMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return divisionMasters
    End Function

    ''' <summary>
    ''' This function is used to insert Division Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="divisionMasterObj">ClsDivisionMaster object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoDivisionMaster(ByVal calledBy As String, ByRef divisionMasterObj As ClsDivisionMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoDivisionMaster(divisionMasterObj).Trim
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
    ''' This function is used to update Division Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="divisionMasterObj">ClsDivisionMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateDivisionMaster(ByVal calledBy As String, ByRef divisionMasterObj As ClsDivisionMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateDivisionMaster(divisionMasterObj).Trim
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