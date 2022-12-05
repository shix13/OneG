Imports System.Windows
Imports IBM.Data.DB2
Public Class Login
    Private conn As IDbConnection

    Dim i As Integer = 0
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn = New DB2Connection("server=localhost;database=oneg;" + "uid=db2admin;password=db2admin;")
            conn.Open()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        Dim str As String
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        Dim param1 As DB2Parameter
        Dim param2 As DB2Parameter

        Try
            str = "select fname,position,ACCID from table( db2admin.login(?,?)) as udf"
            cmd = New DB2Command(str, conn)
            param1 = cmd.Parameters.Add("@1", DB2Type.VarChar)
            param1.Direction = ParameterDirection.Input
            cmd.Parameters("@1").Value = Me.txtAccID.Text

            param2 = cmd.Parameters.Add("@2", DB2Type.VarChar)
            param2.Direction = ParameterDirection.Input
            cmd.Parameters("@2").Value = Me.txtPass.Text

            rdr = cmd.ExecuteReader
            If rdr.HasRows Then
                rdr.Read()
                Home.nameU = rdr.GetString(0)
                Home.role = rdr.GetString(1)
                Home.ACCID = rdr.GetString(2)
                MsgBox("Welcome " + Home.nameU + "!")

                Home.Show()
                Me.Close()


            Else
                MsgBox("AccountId/Password Incorrect. Please Try Again!")
                i += 1
                If (i > 4) Then
                    MsgBox("Maximum Attempt Reached! (5)")
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub txtAccID_MouseEnter(sender As Object, e As EventArgs) Handles txtAccID.MouseEnter
        If txtAccID.Text = "Type Your Account ID" Then
            txtAccID.Text = ""
            txtAccID.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtAccID_MouseLeave(sender As Object, e As EventArgs) Handles txtAccID.MouseLeave
        If txtAccID.Text = "" Then
            txtAccID.Text = "Type Your Account ID"
            txtAccID.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtPass_MouseEnter(sender As Object, e As EventArgs) Handles txtPass.MouseEnter
        If txtPass.Text = "Password" Then
            txtPass.Text = ""
            txtPass.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtPass_MouseLeave(sender As Object, e As EventArgs) Handles txtPass.MouseLeave
        If txtPass.Text = "" Then
            txtPass.Text = "Password"
            txtPass.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtPass_TextChanged(sender As Object, e As EventArgs) Handles txtPass.TextChanged

    End Sub

    Private Sub SignUpLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles SignUpLink.LinkClicked
        Me.Hide()
        SignUp.ShowDialog()
        Me.Show()
    End Sub

    Private Sub txtPass_MouseClick(sender As Object, e As MouseEventArgs) Handles txtPass.MouseClick

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class
