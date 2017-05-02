'Handles all Functionality related to ClsSpecialityMaster
Module ModSpecialityMasterDAL

    Private Function GetSpecialityMasterObj(ByRef row As DataRow) As ClsSpecialityMaster
        Dim specialityMaster As New ClsSpecialityMaster
        Try
            With row
                specialityMaster.Id = .Item(cId)
                specialityMaster.Name = .Item(cName)
                specialityMaster.UserId = .Item(cUserId)
                specialityMaster.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return specialityMaster
    End Function

    Private Function GetSpecialityMaster(ByRef rows As DataRowCollection) As ClsSpecialityMaster()
        Dim specialityMasters(0) As ClsSpecialityMaster
        specialityMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(specialityMasters, count)
                For x = 0 To count - 1
                    specialityMasters(x) = GetSpecialityMasterObj(rows(x))

                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return specialityMasters
    End Function

    ''' <summary>
    ''' This function is used to check that given ClsSpecialityMaster Object is possible to update.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="specialityMasterObj">ClsSpecialityMaster Object to check</param>
    ''' <returns>True if updatable otherwise False</returns>
    ''' <remarks></remarks>
    Public Function SpecialityMasterUpdatable(ByVal calledBy As String, ByRef specialityMasterObj As ClsSpecialityMaster) As Boolean
        Dim updatable As Boolean = True

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.SpecialityMasterUpdatable(specialityMasterObj).Trim
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
    ''' This function will give records from Speciality Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsSpecialityMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSpecialityMaster(ByVal calledBy As String) As ClsSpecialityMaster()
        Dim specialityMasters(0) As ClsSpecialityMaster
        specialityMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSpecialityMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    specialityMasters = GetSpecialityMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return specialityMasters
    End Function

    ''' <summary>
    ''' This function is used to insert Speciality Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="specialityMasterObj">ClsSpecialityMaster object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoSpecialityMaster(ByVal calledBy As String, ByRef specialityMasterObj As ClsSpecialityMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoSpecialityMaster(specialityMasterObj).Trim
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
    ''' This function is used to update Speciality Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="specialityMasterObj">ClsSpecialityMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateSpecialityMaster(ByVal calledBy As String, ByRef specialityMasterObj As ClsSpecialityMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateSpecialityMaster(specialityMasterObj).Trim
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