'Handles all Functionality related to ClsTaxMaster
Module ModTaxMasterDAL

    Private Function GetTaxMasterObj(ByRef row As DataRow) As ClsTaxMaster
        Dim taxMaster As New ClsTaxMaster
        Try
            With row
                taxMaster.Id = .Item(cId)
                taxMaster.Name = .Item(cName)
                taxMaster.TaxPercent = .Item(cTaxPercent)
                taxMaster.DisplayName = .Item(cDisplayName)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return taxMaster
    End Function

    Private Function GetTaxMaster(ByRef rows As DataRowCollection) As ClsTaxMaster()
        Dim taxMasters(0) As ClsTaxMaster
        taxMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(taxMasters, count)
                For x = 0 To count - 1
                    taxMasters(x) = GetTaxMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return taxMasters
    End Function

    ''' <summary>
    ''' This function is used to check that given ClsTaxMaster Object is possible to update.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="cityMasterObj">ClsTaxMaster Object to check</param>
    ''' <returns>True if updatable otherwise False</returns>
    ''' <remarks></remarks>
    Public Function TaxMasterUpdatable(ByVal calledBy As String, ByRef cityMasterObj As ClsTaxMaster) As Boolean
        Dim updatable As Boolean = True

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.TaxMasterUpdatable(cityMasterObj).Trim
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
    ''' This function will give records from Tax Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of ClsTaxMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllTaxMasters(ByVal calledBy As String) As ClsTaxMaster()
        Dim TaxMasters(0) As ClsTaxMaster
        TaxMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllTaxMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    TaxMasters = GetTaxMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return TaxMasters
    End Function

    ''' <summary>
    ''' This function will give records from Tax Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsTaxMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetTaxMaster(ByVal calledBy As String, ByVal id As Integer) As ClsTaxMaster
        Dim taxMaster As ClsTaxMaster = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetTaxMaster(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    taxMaster = GetTaxMasterObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return taxMaster
    End Function

    ''' <summary>
    ''' This function is used to insert Tax Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="taxMastersObj">ClsTaxMaster object to insert</param>
    ''' <returns>Id in integer</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoTaxMaster(ByVal calledBy As String, ByRef taxMastersObj As ClsTaxMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoTaxMaster(taxMastersObj).Trim
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
    ''' This function is used to update Tax Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="taxMastersObj">ClsTaxMasters object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateTaxMaster(ByVal calledBy As String, ByRef taxMastersObj As ClsTaxMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateTaxMaster(taxMastersObj).Trim
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
