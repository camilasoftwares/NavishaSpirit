'Handles all Functionality related to ClsDoctorMaster
Module ModDoctorMasterDAL

    Private Function GetDoctorMasterObj(ByRef row As DataRow) As ClsDoctorMaster
        Dim doctorMaster As New ClsDoctorMaster
        Try
            With row
                doctorMaster.Id = .Item(cId)
                doctorMaster.Name = .Item(cName)
                doctorMaster.Address = .Item(cAddress)
                doctorMaster.City = .Item(cCity)
                doctorMaster.Pin = .Item(cPin)
                doctorMaster.EMail = .Item(cEmail)
                doctorMaster.PhoneR = .Item(cPhoneR)
                doctorMaster.PhoneO = .Item(cPhoneO)
                doctorMaster.Mobile = .Item(cMobile)
                'doctorMaster.SpecialityId = .Item(cSpecialityIdX)
                doctorMaster.UserId = .Item(cUserId)
                doctorMaster.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return doctorMaster
    End Function

    Private Function GetDoctorMaster(ByRef rows As DataRowCollection) As ClsDoctorMaster()
        Dim doctorMasters(0) As ClsDoctorMaster
        doctorMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(doctorMasters, count)
                For x = 0 To count - 1
                    doctorMasters(x) = GetDoctorMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return doctorMasters
    End Function

    ''' <summary>
    ''' This function will give records from Doctor Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsDoctorMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllDoctorMaster(ByVal calledBy As String) As ClsDoctorMaster()
        Dim doctorMasters(0) As ClsDoctorMaster
        doctorMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllDoctorMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    doctorMasters = GetDoctorMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return doctorMasters
    End Function

    ''' <summary>
    ''' This function will give records from Doctor Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="fieldName">Field Name from which records are required</param>
    ''' <param name="likeValue">Value like which records are required</param>
    ''' <returns>ClsDoctorMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllDoctorMasterLike(ByVal calledBy As String, ByVal fieldName As String, ByVal likeValue As String) As ClsDoctorMaster()
        Dim doctorMasters(0) As ClsDoctorMaster
        doctorMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllDoctorMasterLike(fieldName, likeValue).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    doctorMasters = GetDoctorMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return doctorMasters
    End Function

    ''' <summary>
    ''' This function will give records from Doctor Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="likeValue">Value like which records are required</param>
    ''' <returns>ClsDoctorMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllDoctorMasterSpecialityLike(ByVal calledBy As String, ByVal likeValue As String) As ClsDoctorMaster()
        Dim doctorMasters(0) As ClsDoctorMaster
        doctorMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllDoctorMasterSpecialityLike(likeValue).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    doctorMasters = GetDoctorMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return doctorMasters
    End Function

    ''' <summary>
    ''' This function is used to insert Doctor Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="doctorMasterObj">ClsDoctorMaster object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoDoctorMaster(ByVal calledBy As String, ByRef doctorMasterObj As ClsDoctorMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoDoctorMaster(doctorMasterObj).Trim
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
    ''' This function is used to update Doctor Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="doctorMasterObj">ClsDoctorMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateDoctorMaster(ByVal calledBy As String, ByRef doctorMasterObj As ClsDoctorMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateDoctorMaster(doctorMasterObj).Trim
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