Imports IBM.Data.DB2

Public Class ConfirmCode
    Private conn As Common.DbConnection
    Public randNum As New Random
    Public value As Integer
    Public CONFIRM As Boolean = False

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If txtpw.Text = "" Then
                MsgBox("Enter Password First")
            Else
            If txtpw.Text = value.ToString Then
                CONFIRM = True
            Else
                CONFIRM = False
            End If
            key.Close()
            Me.Close()
        End If

    End Sub

    Private Sub ConfirmCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn = New DB2Connection("server=localhost;database=ONEG;" + "uid=db2admin;password=db2admin;")
            conn.Open()

            txtpw.Clear()
            value = randNum.Next(1, 100000)
            If Home.role.ToString.Equals("CASHIER") Then
                MsgBox("User Account Not Authorized")
            Else
                key.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        key.Close()
        Me.Close()
    End Sub

    Private Sub txtpw_TextChanged(sender As Object, e As EventArgs) Handles txtpw.TextChanged

    End Sub
End Class