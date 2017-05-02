Public Class frmDailyTransaction
    Private Sub frmDailyTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'dgvDailyTransaction.Height = Me.Height - 50
        dgvDailyTransaction.DataSource = GetDailyTransactionSheet(Me.Name)
    End Sub
End Class