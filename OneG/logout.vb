Public Class logout
    Public out As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles logOutBtn.Click
        out = True
        Me.Close()
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        out = False
        Me.Close()
    End Sub
End Class