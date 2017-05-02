'Handles all Functionality related to ClsItemMaster
Module ModItemMasterDAL

    Dim dsItemMaster As DataSet = Nothing

    Private Function GetItemMasterObj(ByRef row As DataRow) As ClsItemMaster
        Dim itemMaster As New ClsItemMaster
        Try
            With row
                itemMaster.Id = .Item(cId)
                itemMaster.Name = .Item(cName)
                itemMaster.NameFirst = .Item(cNameFirst)
                itemMaster.UserId = .Item(cUserId)
                itemMaster.DateOn = .Item(cDateOn)
                itemMaster.ItemCode = .Item(cItemCode)
                itemMaster.VAT = .Item(cVAT)
                itemMaster.PackType = .Item(cPackType)
                'itemMaster.GenericId1 = .Item(cGenericId1X)
                'itemMaster.GenericId2 = .Item(cGenericId2X)
                'itemMaster.GenericId3 = .Item(cGenericId3X)
                itemMaster.CategoryId = .Item(cCategoryId)
                'itemMaster.ScheduleId = .Item(cScheduleIdX)
                itemMaster.StorageId = .Item(cStorageId)
                itemMaster.ManufacturerId = .Item(cManufacturerId)
                itemMaster.PIId = .Item(cPIId)
                itemMaster.Minimum = .Item(cMinimum)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return itemMaster
    End Function

    Private Function GetItemMaster(ByRef rows As DataRowCollection) As ClsItemMaster()
        Dim itemMasters(0) As ClsItemMaster
        itemMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(itemMasters, count)
                For x = 0 To count - 1
                    itemMasters(x) = GetItemMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return itemMasters
    End Function

    Private Function GetItemMaster(ByRef rows() As DataRow) As ClsItemMaster()
        Dim itemMasters(0) As ClsItemMaster
        itemMasters = Nothing

        Try
            Dim count As Integer = rows.Length
            If count > 0 Then
                Dim x As Integer

                Array.Resize(itemMasters, count)
                For x = 0 To count - 1
                    itemMasters(x) = GetItemMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return itemMasters
    End Function

    ''' <summary>
    ''' This function is used to check that given ClsItemMaster Object is possible to update.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="itemMasterObj">ClsItemMaster Object to check</param>
    ''' <returns>True if updaitem otherwise False</returns>
    ''' <remarks></remarks>
    Public Function ItemMasterUpdatable(ByVal calledBy As String, ByRef itemMasterObj As ClsItemMaster) As Boolean
        Dim updateItem As Boolean = True

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.ItemMasterUpdatable(itemMasterObj).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    updateItem = False
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return updateItem
    End Function

    ''' <summary>
    ''' This function will give records from Item Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <remarks></remarks>
    Public Sub GetAllItemMaster(ByVal calledBy As String)
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllItemMaster().Trim
                If sql = "" Then Exit For

                dsItemMaster = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)

            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    ''' <summary>
    ''' This function will give records from Item Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsItemMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllItemMaster(ByVal calledBy As String, ByVal newDataSet As Boolean) As ClsItemMaster()
        Dim itemMasters(0) As ClsItemMaster
        itemMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                If newDataSet = True Then GetAllItemMaster(calledBy)

                If dsItemMaster IsNot Nothing Then
                    If dsItemMaster.Tables(0).Rows.Count > 0 Then
                        itemMasters = GetItemMaster(dsItemMaster.Tables(0).Rows)
                    End If
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return itemMasters
    End Function

    ''' <summary>
    ''' This function will give records from Item Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="ids">Comma seperated Ids</param>
    ''' <returns>ClsItemMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllItemMaster(ByVal calledBy As String, ByVal ids As String, ByVal newDataSet As Boolean) As ClsItemMaster()
        Dim itemMasters(0) As ClsItemMaster
        itemMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                If newDataSet = True Then GetAllItemMaster(calledBy)

                If dsItemMaster IsNot Nothing Then
                    If dsItemMaster.Tables(0).Rows.Count > 0 Then
                        Dim str As String = cId + " in (" + ids + ")"
                        Dim dtRow() As DataRow = dsItemMaster.Tables(0).Select(str)
                        If dtRow.Length <> 0 Then itemMasters = GetItemMaster(dtRow)
                    End If
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return itemMasters
    End Function

    ''' <summary>
    ''' This function will give records from Item Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="categoryId">Category Id for which the records are required</param>
    ''' <returns>ClsItemMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllItemMasterForCategoryId(ByVal calledBy As String, ByVal categoryId As Integer, ByVal newDataSet As Boolean) As ClsItemMaster()
        Dim itemMasters(0) As ClsItemMaster
        itemMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                If newDataSet = True Then GetAllItemMaster(calledBy, True)

                If dsItemMaster IsNot Nothing Then
                    If dsItemMaster.Tables(0).Rows.Count > 0 Then
                        Dim str As String = cCategoryId + "=" + CStr(categoryId)
                        Dim dtRow() As DataRow = dsItemMaster.Tables(0).Select(str)
                        If dtRow.Length <> 0 Then itemMasters = GetItemMaster(dtRow)
                    End If
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return itemMasters
    End Function

    ''' <summary>
    ''' This function will give records from Item Master table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="fieldName">Field Name in which the item is to search</param>
    ''' <param name="likeValue">Value for which records are required</param>
    ''' <returns>ClsItemMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllItemMasterLike(ByVal calledBy As String, ByVal fieldName As String, ByVal likeValue As String) As ClsItemMaster()
        Dim itemMasters(0) As ClsItemMaster
        itemMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllItemMasterLike(fieldName, likeValue).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    itemMasters = GetItemMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return itemMasters
    End Function

    ''' <summary>
    ''' This function will give name from Item Master table.
    ''' </summary>
    ''' <param name="id">Item Id for which the name is required</param>
    ''' <returns>Name</returns>
    ''' <remarks></remarks>
    Public Function GetItemMasterName(ByVal id As Integer) As String
        Dim result As String = ""

        Try
            Dim temp As Integer
            For temp = 0 To 0
                If dsItemMaster IsNot Nothing Then
                    If dsItemMaster.Tables(0).Rows.Count > 0 Then
                        Dim str As String = cId + "=" + CStr(id)
                        Dim dtRow() As DataRow = dsItemMaster.Tables(0).Select(str)
                        If dtRow.Length <> 0 Then result = dtRow(0).Item(cName)
                    End If
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function will give name from Item Master table.
    ''' </summary>
    ''' <param name="id">Item Id for which the name is required</param>
    ''' <returns>Name</returns>
    ''' <remarks></remarks>
    Public Function GetItemMaster(ByVal id As Integer) As ClsItemMaster
        Dim result As ClsItemMaster = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                If dsItemMaster IsNot Nothing Then
                    If dsItemMaster.Tables(0).Rows.Count > 0 Then
                        Dim str As String = cId + "=" + CStr(id)
                        Dim dtRow() As DataRow = dsItemMaster.Tables(0).Select(str)
                        If dtRow.Length <> 0 Then result = GetItemMasterObj(dtRow(0))
                    End If
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to insert Item Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="itemMasterObj">ClsItemMaster object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoItemMaster(ByVal calledBy As String, ByRef itemMasterObj As ClsItemMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoItemMaster(itemMasterObj).Trim
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
    ''' This function is used to update Item Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="itemMasterObj">ClsItemMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateItemMaster(ByVal calledBy As String, ByRef itemMasterObj As ClsItemMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateItemMaster(itemMasterObj).Trim
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