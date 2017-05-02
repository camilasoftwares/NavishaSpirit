'Handles all Functionality related to ClsVendorMaster
Module ModVendorMasterDAL

    Private Function GetVendorMasterObj(ByRef row As DataRow) As ClsVendorMaster
        Dim vendorMaster As New ClsVendorMaster
        Try
            With row
                vendorMaster.Id = .Item(cId)
                vendorMaster.Name = .Item(cName)
                vendorMaster.Address = .Item(cAddress)
                vendorMaster.City = .Item(cCity)
                vendorMaster.Pin = .Item(cPin)
                vendorMaster.EMail = .Item(cEmail)
                vendorMaster.AccountId = .Item(cAccountId)
                vendorMaster.PhoneR = .Item(cPhoneR)
                vendorMaster.PhoneO = .Item(cPhoneO)
                vendorMaster.Mobile = .Item(cMobile)
                vendorMaster.UpTtNo = .Item(cUpTtNo)
                vendorMaster.TinNo = .Item(cTinNo)
                vendorMaster.UserId = .Item(cUserId)
                vendorMaster.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)

        End Try

        Return vendorMaster
    End Function

    Private Function GetVendorMaster(ByRef rows As DataRowCollection) As ClsVendorMaster()
        Dim vendorMasters(0) As ClsVendorMaster
        vendorMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(vendorMasters, count)
                For x = 0 To count - 1
                    vendorMasters(x) = GetVendorMasterObj(rows(x))

                Next
            End If

        Catch ex As Exception
            AddToLog(ex)

        End Try

        Return vendorMasters
    End Function

    ''' <summary>
    ''' This function is used to check that given ClsVendorMaster Object is possible to update.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="vendorMasterObj">ClsVendorMaster Object to check</param>
    ''' <returns>True if updatable otherwise False</returns>
    ''' <remarks></remarks>
    Public Function VendorMasterUpdatable(ByVal calledBy As String, ByRef vendorMasterObj As ClsVendorMaster) As Boolean
        Dim updatable As Boolean = True

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.VendorMasterUpdatable(vendorMasterObj).Trim
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
    ''' This function will give records from Vendor Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsVendorMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllVendorMaster(ByVal calledBy As String) As ClsVendorMaster()
        Dim vendorMasters(0) As ClsVendorMaster
        vendorMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllVendorMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    vendorMasters = GetVendorMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return vendorMasters
    End Function

    ''' <summary>
    ''' This function will give records from Vendor Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="fieldName">Field Name from which records are required</param>
    ''' <param name="likeValue">Value like which records are required</param>
    ''' <returns>ClsVendorMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllVendorMasterLike(ByVal calledBy As String, ByVal fieldName As String, ByVal likeValue As String) As ClsVendorMaster()
        Dim vendorMasters(0) As ClsVendorMaster
        vendorMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllVendorMasterLike(fieldName, likeValue).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    vendorMasters = GetVendorMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return vendorMasters
    End Function

    ''' <summary>
    ''' This function is used to get Account Id from Vendor Master Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which account Id required</param>
    ''' <returns>Account Id or ""</returns>
    ''' <remarks></remarks>
    Public Function GetVendorMasterAccountId(ByVal calledBy As String, ByVal id As Integer) As String
        Dim result As String = ""
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetVendorMasterAccountId(id).Trim
                If sql = "" Then Exit For

                Dim accId As String = ClsDBFunctions.GetInstance.ExecuteQuery_Scalar(sql, calledBy)
                If accId.Trim <> "" Then
                    result = accId
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to insert Vendor Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="vendorMasterObj">ClsVendorMaster object to insert</param>
    ''' <returns>Id in Int or cInvalid(-1)</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoVendorMaster(ByVal calledBy As String, ByRef vendorMasterObj As ClsVendorMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoVendorMaster(vendorMasterObj).Trim
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
    ''' This function is used to update Vendor Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="vendorMasterObj">ClsVendorMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateVendorMaster(ByVal calledBy As String, ByRef vendorMasterObj As ClsVendorMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateVendorMaster(vendorMasterObj).Trim
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