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
                Home.name = rdr.GetString(0)
                Home.role = rdr.GetString(1)
                Home.ACCID = rdr.GetString(2)
                MsgBox("Welcome " + Home.name + "!")

                Home.Show()
                Me.Close()


            Else
                MsgBox("Account not found in the system")
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
End Class
