Imports System.IO

Public Class ClsTextReport

    Dim filePath As String = "c:\tempRpt.txt"
    Dim lLineLength As Integer = 30
    Dim lFillChar As String = " "

    Shared sInstance As ClsTextReport

#Region "Report Functions"

    ''' <summary>
    ''' This function is used to get Instance of this class
    ''' </summary>
    ''' <returns>Instance of this class</returns>
    ''' <remarks></remarks>
    Public Shared Function GetInstance() As ClsTextReport
        If sInstance Is Nothing Then
            sInstance = New ClsTextReport
        End If

        Return sInstance
    End Function

    Public Sub ClearReportFile()
        Try
            CreateReportFile()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CreateReportFile()
        Try
            If File.Exists(filePath) = True Then File.Delete(filePath)

            File.Create(filePath).Close()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Public Sub WriteLineToFile(ByVal ln As String)
        Try
            Dim streamWriter As New StreamWriter(filePath, True)
            streamWriter.WriteLine(ln)
            streamWriter.Close()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Text Formatting Functions"

    Public Sub SetLineLength(ByVal length As Integer)
        If length <= 0 Then
            MsgBox("Length can't be -ve or zero.")
            Exit Sub
        End If

        lLineLength = length
    End Sub

    Public Function AlignTextLeft(ByVal txt As String) As String
        Dim result As String = ""
        Try
            Dim str As String = Left(txt, lLineLength)
            Dim leftChr As Integer = lLineLength - str.Length

            Dim temp As New String(lFillChar, leftChr)
            result = str + temp

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Public Function AlignTextRight(ByVal txt As String) As String
        Dim result As String = ""
        Try
            Dim str As String = Left(txt, lLineLength)
            Dim leftChr As Integer = lLineLength - str.Length

            Dim temp As New String(lFillChar, leftChr)
            result = temp + str

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Public Function AlignTextCentered(ByVal txt As String) As String
        Dim result As String = ""
        Try
            Dim str As String = Left(txt, lLineLength)
            Dim leftChr As Integer = lLineLength - str.Length

            Dim midPlace As Integer = Fix(leftChr / 2)
            Dim temp As String = ""

            'Inserting Blank before
            temp = New String(lFillChar, midPlace)
            str = temp + str

            'Inserting Blank after
            leftChr = lLineLength - str.Length
            temp = New String(lFillChar, leftChr)

            result = str + temp

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Public Function PlaceText(ByVal txt As String, ByVal fromIndex As Integer, ByVal toIndex As Integer) As String
        Dim result As String = ""
        Try
            If fromIndex < 0 Or toIndex < 0 Or toIndex < fromIndex Then Exit Try

            Dim temp As String = ""

            'Inserting Blank before
            Dim leftChr As Integer = fromIndex - 1
            If leftChr > 0 Then temp = New String(lFillChar, leftChr)

            Dim str As String = temp
            Dim x As Integer
            Dim y As Integer = 1
            temp = ""
            For x = fromIndex To toIndex
                temp += Mid(txt, y, 1)
                y += 1

                If x = lLineLength Then Exit For
            Next

            str += temp

            'Inserting Blank after
            leftChr = lLineLength - str.Length
            temp = New String(lFillChar, leftChr)

            result = str + temp

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Public Function PlaceText(ByVal txt As String, ByVal fromIndex As Integer) As String
        Dim result As String = ""
        Try
            If fromIndex < 0 Then Exit Try

            Dim temp As String = ""

            'Inserting Blank before
            Dim leftChr As Integer = fromIndex - 1
            If leftChr > 0 Then temp = New String(lFillChar, leftChr)

            Dim str As String = temp
            Dim x As Integer
            Dim y As Integer = 1
            temp = ""
            For x = fromIndex To lLineLength
                temp += Mid(txt, y, 1)
                y += 1

                If y > txt.Length Then Exit For
            Next

            str += temp

            'Inserting Blank after
            leftChr = lLineLength - str.Length
            temp = New String(lFillChar, leftChr)

            result = str + temp

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Public Function PlaceInTextRight(ByVal inTxt As String, ByVal txt As String) As String
        Dim result As String = ""
        Try
            Dim chrs As Integer = txt.Length
            Dim targetChrs As Integer = inTxt.Length
            If chrs > targetChrs Then
                Dim extras As Integer = chrs - targetChrs
                result = Mid(txt, extras + 1, targetChrs)

            ElseIf chrs < targetChrs Then
                Dim extras As Integer = targetChrs - chrs
                Dim temp As String = ""
                temp = Mid(inTxt, 1, extras)
                result = temp + txt

            Else
                result = txt
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Public Function PlaceInTextLeft(ByVal inTxt As String, ByVal txt As String) As String
        Dim result As String = ""
        Try
            Dim chrs As Integer = txt.Length
            Dim targetChrs As Integer = inTxt.Length
            If chrs > targetChrs Then
                result = Mid(txt, 1, targetChrs)

            ElseIf chrs < targetChrs Then
                Dim extras As Integer = targetChrs - chrs
                Dim temp As String = ""
                temp = Mid(inTxt, chrs + 1, extras + 1)
                result = txt + temp

            Else
                result = txt
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Public Function GetLineOfChar(ByVal chr As String) As String
        Dim result As String = ""
        Try
            result = New String(chr, lLineLength)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

#End Region

End Class
