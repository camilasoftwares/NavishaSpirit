'This module contains common functions or procedure
Imports System.IO
Imports System.AppDomain
Imports System.Threading
Imports System.Text.RegularExpressions

Module ModCommonFunctions

#Region "Global Variables"

    Enum EnResult
        Err
        Change
        NoChange
    End Enum

    Enum EnLoading
        None
        LoadOnChange
        LoadOnLostFocus
    End Enum

    'Do not change the ordering or value --- Need to change in Reports also
    Enum EnFields
        PTR = 1
        PTS
        MRP
        PTD
        Rate1
        Rate2
    End Enum

#End Region

#Region "Local Variables"

    Dim errIcon As ErrorProvider = Nothing

#End Region

#Region "Common Functions"

    Public Function GetSqlRound(ByVal calledBy As String, ByVal value As Double, Optional ByVal uptoPos As UInteger = 0) As Double
        Dim result As Double = 0
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.SQLRound(value, uptoPos).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    result = Val(ds.Tables(0).Rows(0).Item(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to get the selected item id
    ''' </summary>
    ''' <param name="cmbBox">ComboBox from which the value is required.</param>
    ''' <returns>Selected item Id</returns>
    ''' <remarks></remarks>
    Public Function GetSelectedItemId(ByRef cmbBox As ComboBox) As Integer
        Dim result As Integer = cInvalidValue
        Try
            result = cmbBox.SelectedItem.Id
        Catch ex As Exception
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to get the selected item
    ''' </summary>
    ''' <param name="cmbBox">ComboBox from which the value is required.</param>
    ''' <returns>Selected item as Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetSelectedItem(ByRef cmbBox As ComboBox) As Object
        Dim result As Object = Nothing
        Try
            Dim obj As Object = cmbBox.SelectedItem
            If Not (obj Is Nothing) Then
                result = obj
                Exit Try
            End If

            If cmbBox.Text.Trim = "" Then
                Exit Try
            End If

            Dim x As Integer = cmbBox.FindStringExact(cmbBox.Text.Trim)
            If x < 0 Then
                Exit Try
            End If

            result = cmbBox.Items(x)

        Catch ex As Exception
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to select the value in place of 'SelectValue' option.
    ''' </summary>
    ''' <param name="cmbBox">ComboBox in which the value is to be selected.</param>
    ''' <param name="value">Value to be selected.</param>
    ''' <remarks></remarks>
    Public Sub SelectItemForSelectValue(ByRef cmbBox As ComboBox, ByVal value As Integer)
        Try
            Dim str As String = GetTextForValue(cmbBox, value)
            If str = "" Then
                cmbBox.Text = ""
            Else
                cmbBox.Text = str
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to get the text for given value.
    ''' </summary>
    ''' <param name="cmbBox">ComboBox from which the text is to get for given value.</param>
    ''' <param name="value">The value against which the text is required.</param>
    ''' <returns>Text against the given value or Blank if not found.</returns>
    ''' <remarks></remarks>
    Public Function GetTextForValue(ByRef cmbBox As ComboBox, ByVal value As Integer) As String
        Dim x As Integer
        Dim count As Integer
        Dim result As String = ""

        Try
            count = cmbBox.Items.Count
            For x = 0 To count - 1
                Dim obj As Object
                obj = cmbBox.Items(x)
                If obj.id = value Then
                    result = obj.Text.trim
                    Exit For

                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to check whether given char and text makes valid decimal value or not.
    ''' If the given values are 'NOT' decimal then it returns true.
    ''' </summary>
    ''' <param name="ch">Char that is going to add in text</param>
    ''' <param name="txt">Text that adds the given char to form a value</param>
    ''' <returns>Returns 'True' if the value is NOT Decimal otherwise 'False'.</returns>
    ''' <remarks></remarks>
    Public Function Check_DecimalAllow(ByVal ch As Char, ByVal txt As String) As Boolean
        Dim result As Boolean = False
        Try
            If Char.IsDigit(ch) = False Then
                Select Case Asc(ch)
                    Case 8      'Backspace
                    Case 46     ' .
                        If InStr(txt, ".") <> 0 Then result = True

                    Case 127    'DEL
                    Case Else
                        result = True

                End Select
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to check whether given char is valid numeric (without decimal) value or not.
    ''' If the given values are 'NOT' numric then it returns true.
    ''' </summary>
    ''' <param name="ch">Char that is going to add in text</param>
    ''' <returns>Returns 'True' if the value is NOT numeric otherwise 'False'.</returns>
    ''' <remarks></remarks>
    Public Function Check_Numeric(ByVal ch As Char) As Boolean
        Dim result As Boolean = False
        Try
            If Char.IsDigit(ch) = False Then
                Select Case Asc(ch)
                    Case 8      'Backspace
                    Case 127    'DEL
                    Case Else
                        result = True

                End Select
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to add values to ComboBox with display member and value member using 'ClsCombBoxObject' class object.
    ''' </summary>
    ''' <param name="displayMember">The value shown by ComboBox.</param>
    ''' <param name="valueMember">The background value for shown value in ComboBox.</param>
    ''' <param name="cmb">ComboBox in which the values to be added.</param>
    ''' <remarks></remarks>
    Public Sub AddItemToComboBox(ByVal displayMember As String, ByVal valueMember As Integer, ByRef cmb As ComboBox)
        Try
            cmb.DisplayMember = "Text"
            cmb.ValueMember = "Id"
            Dim obj As New ClsCombBoxObject(displayMember, valueMember)
            cmb.Items.Add(obj)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to clear text in DropDownList Combo Box.
    ''' Use this when the item is added by 'AddItemToComboBox' function
    ''' </summary>
    ''' <param name="cmb">ComboBox in which the functionality takes place</param>
    ''' <remarks></remarks>
    Public Sub RefillComboBox(ByRef cmb As ComboBox)
        Try
            If cmb Is Nothing Then Exit Try

            Dim obj As New ClsCombBoxObject("", cInvalidValue)
            cmb.Items.Add(obj)
            cmb.Text = ""
            cmb.Items.Remove(obj)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used for autocomplete the text on keypress event of combo box.
    ''' </summary>
    ''' <param name="cb">ComboBox</param>
    ''' <param name="e">KeyPress arguments</param>
    ''' <remarks></remarks>
    Public Sub AutoComplete(ByRef cb As ComboBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            Dim strFindStr As String = ""
            If e.KeyChar = Chr(8) Then 'Backspace
                If cb.SelectionStart <= 1 Then
                    cb.Text = ""
                    Exit Sub
                End If
                If cb.SelectionLength = 0 Then
                    strFindStr = cb.Text.Substring(0, cb.Text.Length - 1)
                Else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1)
                End If
            Else
                If cb.SelectionLength = 0 Then
                    strFindStr = cb.Text & e.KeyChar
                Else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart) & e.KeyChar
                End If
            End If
            Dim intIdx As Integer = -1 ' Search the string in the Combo Box List.
            intIdx = cb.FindString(strFindStr)
            If intIdx <> -1 Then ' String found in the List.
                cb.SelectedText = ""
                cb.SelectedIndex = intIdx
                cb.SelectionStart = strFindStr.Length
                cb.SelectionLength = cb.Text.Length
                e.Handled = True
            Else
                e.Handled = False
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to check valid e-mail address.
    ''' </summary>
    ''' <param name="emailAddress">E-mail address to check</param>
    ''' <returns>True if correct otherwise False</returns>
    ''' <remarks></remarks>
    Public Function CheckEmailAddress(ByVal emailAddress As String) As Boolean
        Dim result As Boolean = False
        Try
            Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
            Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)
            If emailAddressMatch.Success Then result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to check valid URL.
    ''' </summary>
    ''' <param name="url">URL to check</param>
    ''' <returns>True if correct otherwise False</returns>
    ''' <remarks></remarks>
    Public Function CheckURL(ByVal url As String) As Boolean
        Dim result As Boolean = False
        Try
            Dim pattern As String = "^(https?://)" & "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" & "(([0-9]{1,3}\.){3}[0-9]{1,3}" & "|" & "([0-9a-z_!~*'()-]+\.)*" & "([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." & "[a-z]{2,6})" & "(:[0-9]{1,4})?" & "((/?)|" & "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$"
            Dim urlMatch As Match = Regex.Match(url, pattern)
            If urlMatch.Success Then result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to set Wait cursor for application.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetWaitCursor()
        Cursor.Current = Cursors.WaitCursor
    End Sub

    ''' <summary>
    ''' This function is used to set Default cursor for application.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaultCursor()
        Cursor.Current = Cursors.Default
    End Sub

    ''' <summary>
    ''' This function is used to remove non-numeric variables from given string.
    ''' </summary>
    ''' <param name="str">String to modify</param>
    ''' <returns>Modified string</returns>
    ''' <remarks></remarks>
    Public Function CleanInputNumber(ByVal str As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(str, "[^0-9]", "")
    End Function

    'Public Function CleanInputAlphabet(ByVal str As String) As String
    '    Return System.Text.RegularExpressions.Regex.Replace(str, "[0-9\b\s-]", "")
    'End Function

    ''' <summary>
    ''' This function is used to get row for given item id and batch
    ''' </summary>
    ''' <param name="grd">Grid refernce in which the row is to search</param>
    ''' <param name="itemId">ItemId for which search is takes place</param>
    ''' <param name="batch">Batch for which search is takes place</param>
    ''' <returns>DataGridViewRow or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetRowForValues(ByRef grd As DataGridView, ByVal itemId As Integer, ByVal batch As String, Optional ByVal fieldName As String = cItemId) As DataGridViewRow
        Dim result As DataGridViewRow = Nothing
        Try
            If grd Is Nothing Then Exit Try
            If grd.Rows.Count = 0 Then Exit Try

            If grd.Columns.Contains(fieldName) = False Then Exit Try
            If grd.Columns.Contains(cBatch) = False Then Exit Try

            Dim row As DataGridViewRow
            For Each row In grd.Rows
                If row.Cells(fieldName).Value = itemId And row.Cells(cBatch).Value = batch Then
                    result = row
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to get row for given field name and field value
    ''' </summary>
    ''' <param name="grd">Grid refernce in which the row is to search</param>
    ''' <param name="fieldName">Field in which search is takes place</param>
    ''' <param name="fieldValue">Field value for which search is takes place</param>
    ''' <returns>DataGridViewRow or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetRowForFieldAndValue(ByRef grd As DataGridView, ByVal fieldName As String, ByVal fieldValue As String) As DataGridViewRow
        Dim result As DataGridViewRow = Nothing
        Try
            If grd Is Nothing Then Exit Try
            If grd.Rows.Count = 0 Then Exit Try

            If grd.Columns.Contains(fieldName) = False Then
                MsgBox("Field '" + fieldName + "' not found in grid.", MsgBoxStyle.Critical, "Not Exist")
                Exit Try
            End If

            Dim row As DataGridViewRow
            For Each row In grd.Rows
                If row.Cells(fieldName).Value = fieldValue Then
                    result = row
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to place error icon in front of control for given error.
    ''' </summary>
    ''' <param name="msg">Message to be shown on error icon.</param>
    ''' <param name="forControl">Control in which data error found.</param>
    ''' <remarks></remarks>
    Public Sub ErrorInData(ByVal msg As String, ByRef forControl As Control)
        Try
            If forControl Is Nothing Then Exit Try

            If errIcon IsNot Nothing Then errIcon.Clear()
            If errIcon Is Nothing Then errIcon = New ErrorProvider

            With errIcon
                .SetError(forControl, msg)
            End With

            forControl.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to remove Error Icon from form
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RemoveErrorIcon()
        Try
            If errIcon IsNot Nothing Then errIcon.Clear()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to get first day date without time.
    ''' </summary>
    ''' <param name="forDate">Date for which month date is required</param>
    ''' <returns>First day Month date</returns>
    ''' <remarks></remarks>
    Public Function GetMonthDate(ByVal forDate As Date) As Date
        Dim result As Date = Nothing
        Try
            Dim temp As Date = forDate.Date 'Removing time
            Dim x As Integer = 1 - temp.Day 'Get Days to subtract from extra days
            temp = temp.AddDays(x)  'Subtracting days
            result = temp

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to update login list Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="loginId">LoginId to update</param>
    ''' <param name="loginTime">LoginTime to update</param>
    ''' <remarks></remarks>
    Public Function UpdateLoginList(ByVal calledBy As String, ByVal loginId As String, ByVal loginTime As Double) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateLoginList(loginId, loginTime).Trim
                If sql = "" Then Exit For

                If ClsDBFunctions.GetInstance.ExecuteQuery_NonQuery(sql, calledBy) > 0 Then result = EnResult.Change
            Next

        Catch ex As Exception
            'AddToLog(ex)
            result = EnResult.Err
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to delete login from login list Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="loginId">LoginId to delete</param>
    ''' <remarks></remarks>
    Public Function DeleteFromLoginList(ByVal calledBy As String, ByVal loginId As String) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DeleteFromLoginList(loginId).Trim
                If sql = "" Then Exit For

                If ClsDBFunctions.GetInstance.ExecuteQuery_NonQuery(sql, calledBy) > 0 Then result = EnResult.Change
            Next

        Catch ex As Exception
            AddToLog(ex)
            result = EnResult.Err
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function will convert image to string value which is used to store in DB
    ''' </summary>
    ''' <param name="img">Image to convert in String</param>
    ''' <returns>Converted String or blank</returns>
    ''' <remarks></remarks>
    Public Function ImageToString(ByRef img As Image) As String
        Dim result As String = ""
        Try
            If img Is Nothing Then Exit Try

            Dim ms As New MemoryStream
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim picbyte() As Byte = ms.ToArray

            result = "0x" + BitConverter.ToString(picbyte).Replace("-", "")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This will convert byte object from DB to image
    ''' </summary>
    ''' <param name="obj">Object(Value) in byte coming from DB. Send it direct to function</param>
    ''' <returns>Image or nothing</returns>
    ''' <remarks></remarks>
    Public Function StringToImage(ByRef obj As Object) As Image
        Dim result As Image = Nothing
        Try
            If obj Is Nothing Then Exit Try
            If IsDBNull(obj) = True Then Exit Try

            Dim imgBytes() As Byte = CType(obj, Byte())
            Dim stream As MemoryStream = New MemoryStream(imgBytes, 0, imgBytes.Length)
            result = Image.FromStream(stream)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This will give tax percent for given values
    ''' </summary>
    ''' <param name="taxes">Array of taxes</param>
    ''' <param name="taxId">Id of tax for which the percent is required</param>
    ''' <returns>Tax percent or 0 in single</returns>
    ''' <remarks></remarks>
    Public Function GetTaxPercent(ByRef taxes() As ClsTaxMaster, ByVal taxId As Integer) As Double
        Dim result As Double = 0
        Try
            If taxes Is Nothing Then Exit Try

            For Each tax As ClsTaxMaster In taxes
                If tax.Id = taxId Then
                    result = tax.TaxPercent
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

#End Region

#Region "Error Tracing & Log functions"

    ''' <summary>
    ''' This function is used to create error log.
    ''' </summary>
    ''' <param name="ex">Exception</param>
    ''' <remarks></remarks>
    Public Sub AddToLog(ByRef ex As Exception)
        Try
            If TypeOf ex Is ThreadAbortException Then Exit Sub
            If TypeOf ex Is SqlClient.SqlException Then
                AddToSQLServerExecption(ex)
                Exit Try
            End If

            Dim st As New System.Diagnostics.StackTrace(1)
            Dim sf As System.Diagnostics.StackFrame = st.GetFrame(0)
            Dim callingFile As String = sf.GetMethod().DeclaringType.FullName.ToString()
            Dim lnNum As Integer = sf.GetFileLineNumber
            Dim callingFuncName As String = sf.GetMethod.Name

            'check the file
            Dim fs As FileStream = New FileStream(Application.StartupPath & "\errlog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
            Dim s As StreamWriter = New StreamWriter(fs)
            s.Close()
            fs.Close()

            'log it
            Dim fs1 As FileStream = New FileStream(Application.StartupPath & "\errlog.txt", FileMode.Append, FileAccess.Write)
            Dim s1 As StreamWriter = New StreamWriter(fs1)

            Dim msg As String
            msg = "Date/Time: " + DateTime.Now.ToString
            msg = msg + " : " + callingFile
            msg = msg + " : " + callingFuncName
            msg = msg + " Line No.: " + CStr(lnNum)
            msg = msg + vbCrLf + "MSG: " + ex.Message
            msg = msg + vbCrLf
            s1.Write("================================================" & vbCrLf)
            s1.Write(msg)
            MsgBox(msg, MsgBoxStyle.Critical)

            s1.Close()
            fs1.Close()

        Catch newEx As Exception
            MsgBox(newEx.Message)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to create error log.
    ''' </summary>
    ''' <param name="ex">Exception</param>
    ''' <remarks></remarks>
    Public Sub AddToSQLServerExecption(ByRef ex As Exception)
        Try
            If Not (TypeOf ex Is SqlClient.SqlException) Then
                AddToLog(ex)
                Exit Try
            End If

            Dim except As SqlClient.SqlException = ex
            Dim str As String = "Error Code: " + CStr(except.ErrorCode) + vbCrLf + vbCrLf + except.Message
            MsgBox(str, MsgBoxStyle.Critical, "Server Error")

            Dim st As New System.Diagnostics.StackTrace(1)
            Dim sf As System.Diagnostics.StackFrame = st.GetFrame(0)
            Dim callingFile As String = sf.GetMethod().DeclaringType.FullName.ToString()
            Dim lnNum As Integer = sf.GetFileLineNumber
            Dim callingFuncName As String = sf.GetMethod.Name

            'check the file
            Dim fs As FileStream = New FileStream(Application.StartupPath & "\errlog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
            Dim s As StreamWriter = New StreamWriter(fs)
            s.Close()
            fs.Close()

            'log it
            Dim fs1 As FileStream = New FileStream(Application.StartupPath & "\errlog.txt", FileMode.Append, FileAccess.Write)
            Dim s1 As StreamWriter = New StreamWriter(fs1)

            Dim msg As String
            msg = "Date/Time: " + DateTime.Now.ToString
            msg = msg + " : " + callingFile
            msg = msg + " : " + callingFuncName
            msg = msg + " Line No.: " + CStr(lnNum)
            msg = msg + " Error Code: " + CStr(except.ErrorCode)
            msg = msg + vbCrLf + "MSG: " + ex.Message
            msg = msg + vbCrLf
            s1.Write("================================================" & vbCrLf)
            s1.Write(msg)

            s1.Close()
            fs1.Close()

        Catch newEx As Exception
            MsgBox(newEx.Message)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to add message in error log.
    ''' </summary>
    ''' <param name="msg">Message</param>
    ''' <remarks></remarks>
    Public Sub AddToLog(ByVal msg As String)
        Try
            'check the file
            Dim fs As FileStream = New FileStream(Application.StartupPath & "\errlog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
            Dim s As StreamWriter = New StreamWriter(fs)
            s.Close()
            fs.Close()

            'log it
            Dim fs1 As FileStream = New FileStream(Application.StartupPath & "\errlog.txt", FileMode.Append, FileAccess.Write)
            Dim s1 As StreamWriter = New StreamWriter(fs1)

            msg = "******** MSG: " + msg + " :************"
            msg = msg + vbCrLf
            s1.Write("================================================" & vbCrLf)
            s1.Write(msg)
            MsgBox(msg, MsgBoxStyle.Critical)

            s1.Close()
            fs1.Close()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

End Module
