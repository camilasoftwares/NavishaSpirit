'Handles all Functionality related to ClsCustomerType
Module ModCustomerTypeDAL

    Private Function GetCustomerTypeObj(ByRef row As DataRow) As ClsCustomerType
        Dim customerType As New ClsCustomerType
        Try
            With row
                customerType.Id = .Item(cId)
                customerType.Name = .Item(cName)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return customerType
    End Function

    Private Function GetCustomerType(ByRef rows As DataRowCollection) As ClsCustomerType()
        Dim customerTypes(0) As ClsCustomerType
        customerTypes = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(customerTypes, count)
                For x = 0 To count - 1
                    customerTypes(x) = GetCustomerTypeObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return customerTypes
    End Function

    ''' <summary>
    ''' This function is used to check that given ClsCustomerType Object is possible to update.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="cityMasterObj">ClsCustomerType Object to check</param>
    ''' <returns>True if updatable otherwise False</returns>
    ''' <remarks></remarks>
    Public Function CustomerTypeUpdatable(ByVal calledBy As String, ByRef cityMasterObj As ClsCustomerType) As Boolean
        Dim updatable As Boolean = True

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.CustomerTypeUpdatable(cityMasterObj).Trim
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
    ''' This function will give records from Customer Type table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of ClsCustomerType Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCustomerTypes(ByVal calledBy As String) As ClsCustomerType()
        Dim CustomerTypes(0) As ClsCustomerType
        CustomerTypes = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCustomerType().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    CustomerTypes = GetCustomerType(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return CustomerTypes
    End Function

    ''' <summary>
    ''' This function will give records from Customer Type table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsCustomerType Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCustomerType(ByVal calledBy As String, ByVal id As Integer) As ClsCustomerType
        Dim customerType As ClsCustomerType = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetCustomerType(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    customerType = GetCustomerTypeObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return customerType
    End Function

    ''' <summary>
    ''' This function is used to insert Customer Type Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="customerTypesObj">ClsCustomerType object to insert</param>
    ''' <returns>Id in integer</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoCustomerType(ByVal calledBy As String, ByRef customerTypesObj As ClsCustomerType) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoCustomerType(customerTypesObj).Trim
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
    ''' This function is used to update Customer Type Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="customerTypesObj">ClsCustomerTypes object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateCustomerType(ByVal calledBy As String, ByRef customerTypesObj As ClsCustomerType) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateCustomerType(customerTypesObj).Trim
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
