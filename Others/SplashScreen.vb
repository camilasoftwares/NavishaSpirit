Public NotInheritable Class SplashScreen

    Private Sub TmrSplash_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrSplash.Tick
        Me.Close()
        Me.Dispose()
    End Sub

End Class
