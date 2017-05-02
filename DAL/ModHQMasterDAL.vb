'Handles all Functionality related to ClsHQMaster
Module ModHQMasterDAL

    Private Function GetHQMasterObj(ByRef row As DataRow) As ClsHQMaster
        Dim hqMaster As New ClsHQMaster
        Try
            With row
                hqMaster.Id = .Item(cId)
                hqMaster.Name = .Item(cName)
                hqMaster.Address = .Item(cAddress)
                hqMaster.City = .Item(cCity)
                hqMaster.Pin = .Item(cPin)
                hqMaster.EMail = .Item(cEmail)
                hqMaster.PhoneR = .Item(cPhoneR)
                hqMaster.PhoneO = .Item(cPhoneO)
                hqMaster.Mobile = .Item(cMobile)
                hqMaster.Representative = .Item(cRepresentative)
                hqMaster.PhoneRepresentative = .Item(cPhoneRepresentative)
                hqMaster.UserId = .Item(cUserId)
                hqMaster.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return hqMaster
    End Function

    Private Function GetHQMaster(ByRef rows As DataRowCollection) As ClsHQMaster()
        Dim hqMasters(0) As ClsHQMaster
        hqMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(hqMasters, count)
                For x = 0 To count - 1
                    hqMasters(x) = GetHQMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return hqMasters
    End Function

    ''' <summary>
    ''' This function will give records from HQ Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsHQMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllHQMaster(ByVal calledBy As String) As ClsHQMaster()
        Dim hqMasters(0) As ClsHQMaster
        hqMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllHQMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    hqMasters = GetHQMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return hqMasters
    End Function

    ''' <summary>
    ''' This function will give records from HQ Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="fieldName">Field Name from which records are required</param>
    ''' <param name="likeValue">Value like which records are required</param>
    ''' <returns>ClsHQMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllHQMasterLike(ByVal calledBy As String, ByVal fieldName As String, ByVal likeValue As String) As ClsHQMaster()
        Dim hqMasters(0) As ClsHQMaster
        hqMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllHQMasterLike(fieldName, likeValue).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    hqMasters = GetHQMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return hqMasters
    End Function

    ''' <summary>
    ''' This function is used to insert HQ Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="hqMasterObj">ClsHQMaster object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoHQMaster(ByVal calledBy As String, ByRef hqMasterObj As ClsHQMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoHQMaster(hqMasterObj).Trim
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
    ''' This function is used to update HQ Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="hqMasterObj">ClsHQMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateHQMaster(ByVal calledBy As String, ByRef hqMasterObj As ClsHQMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateHQMaster(hqMasterObj).Trim
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