'Handles all Functionality related to ClsManufacturerMaster
Module ModManufacturerMasterDAL

    Private Function GetManufacturerMasterObj(ByRef row As DataRow) As ClsManufacturerMaster
        Dim manufacturerMaster As New ClsManufacturerMaster
        Try
            With row
                manufacturerMaster.Id = .Item(cId)
                manufacturerMaster.Name = .Item(cName)
                manufacturerMaster.Address = .Item(cAddress)
                manufacturerMaster.City = .Item(cCity)
                manufacturerMaster.Pin = .Item(cPin)
                manufacturerMaster.EMail = .Item(cEmail)
                manufacturerMaster.PhoneR = .Item(cPhoneR)
                manufacturerMaster.PhoneO = .Item(cPhoneO)
                manufacturerMaster.Mobile = .Item(cMobile)
                manufacturerMaster.Representative = .Item(cRepresentative)
                manufacturerMaster.PhoneRepresentative = .Item(cPhoneRepresentative)
                manufacturerMaster.UserId = .Item(cUserId)
                manufacturerMaster.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return manufacturerMaster
    End Function

    Private Function GetManufacturerMaster(ByRef rows As DataRowCollection) As ClsManufacturerMaster()
        Dim manufacturerMasters(0) As ClsManufacturerMaster
        manufacturerMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(manufacturerMasters, count)
                For x = 0 To count - 1
                    manufacturerMasters(x) = GetManufacturerMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return manufacturerMasters
    End Function

    ''' <summary>
    ''' This function will give records from Manufacturer Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsManufacturerMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllManufacturerMaster(ByVal calledBy As String) As ClsManufacturerMaster()
        Dim manufacturerMasters(0) As ClsManufacturerMaster
        manufacturerMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllManufacturerMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    manufacturerMasters = GetManufacturerMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return manufacturerMasters
    End Function

    ''' <summary>
    ''' This function will give records from Manufacturer Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="fieldName">Field Name from which records are required</param>
    ''' <param name="likeValue">Value like which records are required</param>
    ''' <returns>ClsManufacturerMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllManufacturerMasterLike(ByVal calledBy As String, ByVal fieldName As String, ByVal likeValue As String) As ClsManufacturerMaster()
        Dim manufacturerMasters(0) As ClsManufacturerMaster
        manufacturerMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllManufacturerMasterLike(fieldName, likeValue).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    manufacturerMasters = GetManufacturerMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return manufacturerMasters
    End Function

    ''' <summary>
    ''' This function is used to insert Manufacturer Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="manufacturerMasterObj">ClsManufacturerMaster object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoManufacturerMaster(ByVal calledBy As String, ByRef manufacturerMasterObj As ClsManufacturerMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoManufacturerMaster(manufacturerMasterObj).Trim
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
    ''' This function is used to update Manufacturer Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="manufacturerMasterObj">ClsManufacturerMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateManufacturerMaster(ByVal calledBy As String, ByRef manufacturerMasterObj As ClsManufacturerMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateManufacturerMaster(manufacturerMasterObj).Trim
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