Public Class ConfirmationBox
    Public confirmPayment As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        confirmPayment = True
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        confirmPayment = False
        Me.Close()
    End Sub
End Class