Imports System.Windows.Forms

Public Class DlgInputBox

#Region "Local Variables"

    Dim lText As String = ""

#End Region

#Region "Control Functions"

    Public Sub New(Optional ByVal title As String = "Title", Optional ByVal msg As String = "Message", Optional ByVal passwordField As Boolean = False)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Text = title
        LblMessage.Text = msg

        If passwordField = True Then TxtText.PasswordChar = "*"

    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        lText = TxtText.Text
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DlgInputBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

#End Region

#Region "Public Functions"

    Public Function EnteredText() As String
        Return lText
    End Function

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        Dim sz As Size = Me.Size
        Dim widthMe As Integer = Me.Size.Width
        Dim widthLbl As Integer = LblMessage.Size.Width

        If widthMe - widthLbl < 24 Then
            widthMe = widthLbl + 24
            sz.Width = widthMe
            Me.Size = sz
        End If

    End Sub

#End Region

End Class
