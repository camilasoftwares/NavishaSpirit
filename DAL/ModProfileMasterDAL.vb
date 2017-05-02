'Handles all Functionality related to ClsProfileMaster
Module ModProfileMasterDAL

    Private Function GetProfileMasterObj(ByRef row As DataRow) As ClsProfileMaster
        Dim profileMaster As New ClsProfileMaster
        Try
            With row
                profileMaster.Id = .Item(cId)
                profileMaster.Name = .Item(cName)
                profileMaster.AuthorizationNo = .Item(cAuthorizationNo)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return profileMaster
    End Function

    Private Function GetProfileMaster(ByRef rows As DataRowCollection) As ClsProfileMaster()
        Dim profileMasters(0) As ClsProfileMaster
        profileMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer
                Array.Resize(profileMasters, count)
                For x = 0 To count - 1
                    profileMasters(x) = GetProfileMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return profileMasters
    End Function

    ''' <summary>
    ''' This function is used to check that given ClsProfileMaster Object is possible to update.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="profileMasterObj">ClsProfileMaster Object to check</param>
    ''' <returns>True if updaprofile otherwise False</returns>
    ''' <remarks></remarks>
    Public Function ProfileMasterUpdatable(ByVal calledBy As String, ByRef profileMasterObj As ClsProfileMaster) As Boolean
        Dim updaprofile As Boolean = True

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.ProfileMasterUpdatable(profileMasterObj).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    updaprofile = False
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return updaprofile
    End Function

    ''' <summary>
    ''' This function will give all records in Profile Master Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of ClsProfileMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllProfileMaster(ByVal calledBy As String) As ClsProfileMaster()
        Dim profileMasters(0) As ClsProfileMaster
        profileMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllProfileMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    profileMasters = GetProfileMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return profileMasters
    End Function

    ''' <summary>
    ''' This function will give all records in Profile Master Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of ClsProfileMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetProfileById(ByVal calledBy As String, ProfileId As Int32) As ClsProfileMaster
        Dim profileMaster As ClsProfileMaster
        profileMaster = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetProfileMasterById(ProfileId).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    profileMaster = GetProfileMasterObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return profileMaster
    End Function

    ''' <summary>
    ''' This function is used to insert object in Profile Master Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="profileMasterObj">ClsProfileMaster object to insert</param>
    ''' <returns>Id in integer or cinvalid(-1)</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoProfileMaster(ByVal calledBy As String, ByRef profileMasterObj As ClsProfileMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoProfileMaster(profileMasterObj).Trim
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
    ''' This function is used to update Profile Master Object in Profile.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="profileMasterObj">ClsProfileMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateProfileMaster(ByVal calledBy As String, ByRef profileMasterObj As ClsProfileMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateProfileMaster(profileMasterObj).Trim
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
