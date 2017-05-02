'Handles all Functionality related to ClsBranchMaster
Module ModBranchMasterDAL

    Private Function GetBranchMasterObj(ByRef row As DataRow) As ClsBranchMaster
        Dim branchMaster As New ClsBranchMaster
        Try
            With row
                branchMaster.Id = .Item(cId)
                branchMaster.Name = .Item(cName)
                branchMaster.BranchCode = .Item(cBranchCode)
                branchMaster.Address = .Item(cAddress)
                branchMaster.City = .Item(cCity)
                branchMaster.Pin = .Item(cPin)
                branchMaster.ContactPerson = .Item(cContactPerson)
                branchMaster.Phone = .Item(cPhone)
                branchMaster.Fax = .Item(cFax)
                branchMaster.EMail = .Item(cEmail)
                branchMaster.State = .Item(cState)
                branchMaster.UpTtNo = .Item(cUpTtNo)
                branchMaster.TinNo = .Item(cTinNo)
                branchMaster.UserId = .Item(cUserId)
                branchMaster.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)

        End Try

        Return branchMaster
    End Function

    Private Function GetBranchMaster(ByRef rows As DataRowCollection) As ClsBranchMaster()
        Dim branchMasters(0) As ClsBranchMaster
        branchMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(branchMasters, count)
                For x = 0 To count - 1
                    branchMasters(x) = GetBranchMasterObj(rows(x))

                Next
            End If

        Catch ex As Exception
            AddToLog(ex)

        End Try

        Return branchMasters
    End Function

    ''' <summary>
    ''' This function will give records from Branch Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsBranchMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllBranchMaster(ByVal calledBy As String) As ClsBranchMaster()
        Dim branchMasters(0) As ClsBranchMaster
        branchMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllBranchMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    branchMasters = GetBranchMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return branchMasters
    End Function

    ''' <summary>
    ''' This function is used to insert Branch Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="branchMasterObj">ClsBranchMaster object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoBranchMaster(ByVal calledBy As String, ByRef branchMasterObj As ClsBranchMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoBranchMaster(branchMasterObj).Trim
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
    ''' This function is used to update Branch Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="branchMasterObj">ClsBranchMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateBranchMaster(ByVal calledBy As String, ByRef branchMasterObj As ClsBranchMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateBranchMaster(branchMasterObj).Trim
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