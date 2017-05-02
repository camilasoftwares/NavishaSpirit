'Handles all Functionality related to ClsPurchaseOrderMaster
Module ModPurchaseOrderMasterDAL

    Private Function GetPurchaseOrderMasterObj(ByRef row As DataRow) As ClsPurchaseOrderMaster
        Dim purchaseOrderMaster As New ClsPurchaseOrderMaster
        Try
            With row
                purchaseOrderMaster.Id = .Item(cId)
                purchaseOrderMaster.OrderDate = .Item(cOrderDate)
                'purchaseOrderMaster.StockLimit = .Item(cStockLimit)
                'purchaseOrderMaster.PurchaseLimit = .Item(cPurchaseLimit)
                purchaseOrderMaster.Remark = .Item(cRemark)
                purchaseOrderMaster.UserId = .Item(cUserId)
                purchaseOrderMaster.DateOn = .Item(cDateOn)
                purchaseOrderMaster.NotClosed = .Item(cNotClosed)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseOrderMaster
    End Function

    Private Function GetPurchaseOrderMaster(ByRef rows As DataRowCollection) As ClsPurchaseOrderMaster()
        Dim purchaseOrderMasters(0) As ClsPurchaseOrderMaster
        purchaseOrderMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(purchaseOrderMasters, count)
                For x = 0 To count - 1
                    purchaseOrderMasters(x) = GetPurchaseOrderMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseOrderMasters
    End Function

    ''' <summary>
    ''' This function will give record from Purchase Order Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="loginName">Login Name for which the record is required</param>
    ''' <returns>ClsPurchaseOrderMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetPurchaseOrderMasterNotClosedForLogin(ByVal calledBy As String, ByVal loginName As String) As ClsPurchaseOrderMaster
        Dim purchaseOrderMaster As ClsPurchaseOrderMaster = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetPurchaseOrderMasterNotClosedForLogin(loginName).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseOrderMaster = GetPurchaseOrderMasterObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseOrderMaster
    End Function

    ''' <summary>
    ''' This function will give purchaseOrder id from Purchase Order Master table not closed.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="loginName">Login Name for which the record is required</param>
    ''' <returns>Id in Long or cInvalidId</returns>
    ''' <remarks></remarks>
    Public Function GetPurchaseOrderMasterIdNotClosedForLogin(ByVal calledBy As String, ByVal loginName As String) As Long
        Dim result As Long = cInvalidId

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetPurchaseOrderMasterIdNotClosedForLogin(loginName).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    If IsDBNull(ds.Tables(0).Rows(0).Item(0)) = True Then Exit Try

                    result = Val(ds.Tables(0).Rows(0).Item(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function will give record from Purchase Order Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsPurchaseOrderMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetPurchaseOrderMaster(ByVal calledBy As String, ByVal id As Long) As ClsPurchaseOrderMaster
        Dim purchaseOrderMaster As ClsPurchaseOrderMaster = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetPurchaseOrderMaster(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseOrderMaster = GetPurchaseOrderMasterObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseOrderMaster
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Order Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of ClsPurchaseOrderMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseOrderMaster(ByVal calledBy As String) As ClsPurchaseOrderMaster()
        Dim purchaseOrderMasters(0) As ClsPurchaseOrderMaster
        purchaseOrderMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllPurchaseOrderMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseOrderMasters = GetPurchaseOrderMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseOrderMasters
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Order Master table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="forField">Field in which searching takes place</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsPurchaseOrderMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Private Function GetAllPurchaseOrderMasterValuesLike(ByVal calledBy As String, ByVal forField As String, ByVal value As String) As ClsPurchaseOrderMaster()
        Dim purchaseOrderMasters(0) As ClsPurchaseOrderMaster
        purchaseOrderMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllPurchaseOrderMasterValuesLike(forField, value).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseOrderMasters = GetPurchaseOrderMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseOrderMasters
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Order Master table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="day">Day for which search takes place</param>
    ''' <param name="month">Month for which search takes place</param>
    ''' <param name="year">Year for which search takes place</param>
    ''' <returns>Array of ClsPurchaseOrderMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseOrderMasterLikeOrderDate(ByVal calledBy As String, Optional ByVal day As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "") As ClsPurchaseOrderMaster()
        Dim purchaseOrderMasters(0) As ClsPurchaseOrderMaster
        purchaseOrderMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllPurchaseOrderMasterLikeOrderDate(day, month, year).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseOrderMasters = GetPurchaseOrderMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseOrderMasters
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Order Master table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsPurchaseOrderMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseOrderMasterOrderLike(ByVal calledBy As String, ByVal value As String) As ClsPurchaseOrderMaster()
        Return GetAllPurchaseOrderMasterValuesLike(calledBy, cId, value)
    End Function

    '''' <summary>
    '''' This function will give records from Purchase Order Master table for given values.
    '''' </summary>
    '''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    '''' <param name="value">Value to search like</param>
    '''' <returns>Array of ClsPurchaseOrderMaster Objects or nothing</returns>
    '''' <remarks></remarks>
    'Public Function GetAllPurchaseOrderMasterPurchaseLimitLike(ByVal calledBy As String, ByVal value As String) As ClsPurchaseOrderMaster()
    '    Return GetAllPurchaseOrderMasterValuesLike(calledBy, cPurchaseLimit, value)
    'End Function

    '''' <summary>
    '''' This function will give records from Purchase Order Master table for given values.
    '''' </summary>
    '''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    '''' <param name="value">Value to search like</param>
    '''' <returns>Array of ClsPurchaseOrderMaster Objects or nothing</returns>
    '''' <remarks></remarks>
    'Public Function GetAllPurchaseOrderMasterStockLimitLike(ByVal calledBy As String, ByVal value As String) As ClsPurchaseOrderMaster()
    '    Return GetAllPurchaseOrderMasterValuesLike(calledBy, cStockLimit, value)
    'End Function

    ''' <summary>
    ''' This function is used to insert Purchase Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="purchaseOrderMasterObj">ClsPurchaseOrderMaster object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoPurchaseOrderMaster(ByVal calledBy As String, ByRef purchaseOrderMasterObj As ClsPurchaseOrderMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoPurchaseOrderMaster(purchaseOrderMasterObj).Trim
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
    ''' This function is used to update Purchase Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="purchaseOrderMasterObj">ClsPurchaseOrderMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdatePurchaseOrderMaster(ByVal calledBy As String, ByRef purchaseOrderMasterObj As ClsPurchaseOrderMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdatePurchaseOrderMaster(purchaseOrderMasterObj).Trim
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