'Handles all Functionality related to ClsCustomerMaster
Module ModCustomerMasterDAL

    Private Function GetCustomerMasterObj(ByRef row As DataRow) As ClsCustomerMaster
        Dim customerMaster As New ClsCustomerMaster
        Try
            With row
                customerMaster.Id = .Item(cId)
                customerMaster.Name = .Item(cName)
                customerMaster.Address = .Item(cAddress)
                customerMaster.City = .Item(cCity)
                customerMaster.Pin = .Item(cPin)
                customerMaster.EMail = .Item(cEmail)
                customerMaster.AccountId = .Item(cAccountId)
                'customerMaster.CardNo = .Item(cCardNo)
                customerMaster.PhoneR = .Item(cPhoneR)
                customerMaster.PhoneO = .Item(cPhoneO)
                customerMaster.Mobile = .Item(cMobile)
                customerMaster.MemberOf = .Item(cMemberOf)
                'customerMaster.DlNo = .Item(cDlNo)
                customerMaster.UpTtNo = .Item(cUpTtNo)
                customerMaster.TinNo = .Item(cTinNo)
                customerMaster.UserId = .Item(cUserId)
                customerMaster.DateOn = .Item(cDateOn)
                customerMaster.CustomerTypeId = .Item(cCustomerTypeId)
                customerMaster.DueDays = .Item(cDueDays)
                customerMaster.TaxId = .Item(cTaxId)
                customerMaster.HQId = .Item(cHQId)
            End With

        Catch ex As Exception
            AddToLog(ex)

        End Try

        Return customerMaster
    End Function

    Private Function GetCustomerMaster(ByRef rows As DataRowCollection) As ClsCustomerMaster()
        Dim customerMasters(0) As ClsCustomerMaster
        customerMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(customerMasters, count)
                For x = 0 To count - 1
                    customerMasters(x) = GetCustomerMasterObj(rows(x))

                Next
            End If

        Catch ex As Exception
            AddToLog(ex)

        End Try

        Return customerMasters
    End Function

    ''' <summary>
    ''' This function will give records from Customer Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsCustomerMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCustomerMaster(ByVal calledBy As String) As ClsCustomerMaster()
        Dim customerMasters(0) As ClsCustomerMaster
        customerMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCustomerMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    customerMasters = GetCustomerMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return customerMasters
    End Function

    ''' <summary>
    ''' This function will give records from Customer Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="fieldName">Field Name from which records are required</param>
    ''' <param name="likeValue">Value like which records are required</param>
    ''' <returns>ClsCustomerMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCustomerMasterLike(ByVal calledBy As String, ByVal fieldName As String, ByVal likeValue As String) As ClsCustomerMaster()
        Dim customerMasters(0) As ClsCustomerMaster
        customerMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCustomerMasterLike(fieldName, likeValue).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    customerMasters = GetCustomerMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return customerMasters
    End Function

    ''' <summary>
    ''' This function will give all code from Customer Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>List of String as code</returns>
    ''' <remarks></remarks>
    Public Function GetAllCustomerMasterCode(ByVal calledBy As String) As List(Of String)
        Dim customerCodeList As New List(Of String)

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCustomerMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    For Each row As DataRow In ds.Tables(0).Rows
                        customerCodeList.Add(row.Item(cAccountId))
                    Next
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return customerCodeList
    End Function

    ''' <summary>
    ''' This function will give record from Customer Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsCustomerMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCustomerMaster(ByVal calledBy As String, ByVal id As Integer) As ClsCustomerMaster
        Dim customerMaster As ClsCustomerMaster = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetCustomerMaster(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    customerMaster = GetCustomerMasterObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return customerMaster
    End Function

    ''' <summary>
    ''' This function will give customer id from Customer Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="code">Code for which record is required</param>
    ''' <returns>Id as integer</returns>
    ''' <remarks></remarks>
    Public Function GetCustomerMasterIdForCode(ByVal calledBy As String, ByVal code As String) As Integer
        Dim customerId As Integer = cInvalidId

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetCustomerMasterIdForCode(code).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    customerId = ds.Tables(0).Rows(0).Item(cId)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return customerId
    End Function

    ''' <summary>
    ''' This function is used to insert Customer Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="customerMasterObj">ClsCustomerMaster object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoCustomerMaster(ByVal calledBy As String, ByRef customerMasterObj As ClsCustomerMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoCustomerMaster(customerMasterObj).Trim
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
    ''' This function is used to update Customer Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="customerMasterObj">ClsCustomerMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateCustomerMaster(ByVal calledBy As String, ByRef customerMasterObj As ClsCustomerMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateCustomerMaster(customerMasterObj).Trim
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