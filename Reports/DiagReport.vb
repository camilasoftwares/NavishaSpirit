Imports System.Windows.Forms

Public Class DiagReport

    Dim flag As Boolean = False

    Private Sub DiagReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.RptViewer.RefreshReport()
        If flag = True Then
            SetPrintCopy()
            flag = False
        End If
    End Sub

    Private Sub RptViewer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RptViewer.GotFocus
        SetDefaultCursor()
    End Sub

    Public Sub SetPrintCopy()
        flag = True
    End Sub

    Public Sub SetPrint()
        Dim ctrl As Control = Nothing
        For Each ctrl In Me.RptViewer.Controls  'Me.Controls
            If TypeOf (ctrl) Is ToolStrip Then
                Dim btn As New ToolStripButton
                btn.Text = "Print"
                CType(ctrl, ToolStrip).Items.Add(btn)
                AddHandler btn.Click, AddressOf PrintCopy
                Exit For
            End If
        Next
    End Sub

    Private Sub PrintCopy(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim rpt As Object = Me.RptViewer.ReportSource
        If rpt IsNot Nothing Then
            rpt.PrintToPrinter(2, False, 0, 0)

        End If
    End Sub

End Class
