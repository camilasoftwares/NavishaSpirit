'Handles all Functionality related to ClsCategoryMaster
Module ModCategoryMasterDAL

    Private Function GetCategoryMasterObj(ByRef row As DataRow) As ClsCategoryMaster
        Dim categoryMaster As New ClsCategoryMaster
        Try
            With row
                categoryMaster.Id = .Item(cId)
                categoryMaster.Name = .Item(cName)
                categoryMaster.PIId = .Item(cPIId)
                categoryMaster.UserId = .Item(cUserId)
                categoryMaster.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return categoryMaster
    End Function

    Private Function GetCategoryMaster(ByRef rows As DataRowCollection) As ClsCategoryMaster()
        Dim categoryMasters(0) As ClsCategoryMaster
        categoryMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(categoryMasters, count)
                For x = 0 To count - 1
                    categoryMasters(x) = GetCategoryMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return categoryMasters
    End Function

    ''' <summary>
    ''' This function is used to check that given ClsCategoryMaster Object is possible to update.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="categoryMasterObj">ClsCategoryMaster Object to check</param>
    ''' <returns>True if updacategory otherwise False</returns>
    ''' <remarks></remarks>
    Public Function CategoryMasterUpdatable(ByVal calledBy As String, ByRef categoryMasterObj As ClsCategoryMaster) As Boolean
        Dim updateCategory As Boolean = True

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.CategoryMasterUpdatable(categoryMasterObj).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    updateCategory = False
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return updateCategory
    End Function

    ''' <summary>
    ''' This function will give records from Category Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsCategoryMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCategoryMaster(ByVal calledBy As String) As ClsCategoryMaster()
        Dim categoryMasters(0) As ClsCategoryMaster
        categoryMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCategoryMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    categoryMasters = GetCategoryMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return categoryMasters
    End Function

    ''' <summary>
    ''' This function is used to insert Category Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="categoryMasterObj">ClsCategoryMaster object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoCategoryMaster(ByVal calledBy As String, ByRef categoryMasterObj As ClsCategoryMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoCategoryMaster(categoryMasterObj).Trim
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
    ''' This function is used to update Category Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="categoryMasterObj">ClsCategoryMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateCategoryMaster(ByVal calledBy As String, ByRef categoryMasterObj As ClsCategoryMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateCategoryMaster(categoryMasterObj).Trim
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