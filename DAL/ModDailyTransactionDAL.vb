'Handles all Functionality related to ClsAccountHead
Module ModDailyTransactionDAL
    Private Function GetDailyTransactionObj(ByRef row As DataRow) As ClsDailyTransactionSheet
        Dim dailyTransactionSheet As New ClsDailyTransactionSheet
        Try
            With row
                dailyTransactionSheet.ItemCode = .Item(cItemCode)
                dailyTransactionSheet.ItemName = .Item(cName)
                dailyTransactionSheet.Category = .Item(cCategory)
                dailyTransactionSheet.PackType = .Item(cPackType)
                dailyTransactionSheet.OpeningQty = .Item(cOpeningQty)
                dailyTransactionSheet.PurchaseQty = .Item(cPurchaseQty)
                'dailyTransactionSheet.TransferQty = .Item(cTransferQty)
                dailyTransactionSheet.SaleQty = .Item(cSaleQty)
                dailyTransactionSheet.SaleRate = .Item(cRate)
                dailyTransactionSheet.OpeningPrice = .Item(cPriceOpening)
                dailyTransactionSheet.InPrice = .Item(cPriceIn)
                dailyTransactionSheet.OutPrice = .Item(cPriceOut)
                dailyTransactionSheet.SaleRate = .Item(cRate)
                'dailyTransactionSheet.UserId = .Item(cUserId)
                'dailyTransactionSheet.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return dailyTransactionSheet
    End Function

    Private Function GetDailyTransaction(ByRef rows As DataRowCollection) As ClsDailyTransactionSheet()
        Dim dailyTransactionSheet(0) As ClsDailyTransactionSheet
        dailyTransactionSheet = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(dailyTransactionSheet, count)
                For x = 0 To count - 1
                    dailyTransactionSheet(x) = GetDailyTransactionObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return dailyTransactionSheet
    End Function

    ''' <summary>
    ''' This function will give records from Account Head table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsAccountHead Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetDailyTransactionSheet(ByVal calledBy As String) As ClsDailyTransactionSheet()
        Dim dailyTransactionSheet(0) As ClsDailyTransactionSheet
        dailyTransactionSheet = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetDailyTransactionSheet().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    dailyTransactionSheet = GetDailyTransaction(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return dailyTransactionSheet
    End Function

End Module

