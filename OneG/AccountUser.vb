Imports IBM.Data.DB2

Public Class AccountUser
    Dim CONN As Common.DbConnection
    Dim sidebar As String = "Close"

    Sub clear()
        lblWelcomeBar.Visible = False
        dtpSideBar.Visible = False
        OrderBtn.Visible = False
        PayBtn.Visible = False
        MainBtn.Visible = False
        AccBtn.Visible = False
        PurcBtn.Visible = False
        LogoutBtn.Visible = False
    End Sub


    Sub setname()
        lblWelcomeBar.Visible = True
        dtpSideBar.Visible = True
        OrderBtn.Visible = True
        PayBtn.Visible = True
        MainBtn.Visible = True
        AccBtn.Visible = True
        PurcBtn.Visible = True
        LogoutBtn.Visible = True
    End Sub


    Private Sub AccountUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        Try


            CONN = New DB2Connection("server=localhost;database=oneg;" + "uid=db2admin;password=db2admin;")
            CONN.Open()

            cmd = New DB2Command("select * from EMPLOYEE where ACCID ='" & Login.ACCID.ToString & "'", CONN)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                TXTACCID.Text = rdr.GetString(0)
                txtFName.Text = rdr.GetString(1)
                txtMName.Text = rdr.GetString(2)
                txtLName.Text = rdr.GetString(3)

                TXTPOSITION.Text = rdr.GetString(5)

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub MenuBarBtn_Click(sender As Object, e As EventArgs) Handles MenuBarBtn.Click
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If sidebar = "Open" Then
            leftSideBar.Width -= 65
            If leftSideBar.Width <= 65 Then
                clear()
                sidebar = "Close"
                Timer1.Stop()
            End If
        Else
            leftSideBar.Width += 65
            If leftSideBar.Width >= 200 Then
                setname()
                sidebar = "Open"
                Timer1.Stop()
            End If


        End If
    End Sub

    Private Sub REFRESHORDERDATAGRID()
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        cmd = New DB2Command("select * from EMPLOYEE where ACCID ='" & Login.ACCID.ToString & "'", CONN)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            TXTACCID.Text = rdr.GetString(0)
            txtFName.Text = rdr.GetString(1)
            txtMName.Text = rdr.GetString(2)
            txtLName.Text = rdr.GetString(3)

            TXTPOSITION.Text = rdr.GetString(5)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles savebtn.Click
        Dim str As String
        Dim cmd As DB2Command
        Try
            Dim param1 As DB2Parameter
            Dim param2 As DB2Parameter
            Dim param3 As DB2Parameter
            Dim param4 As DB2Parameter
            Dim param5 As DB2Parameter
            Dim param6 As DB2Parameter
            Dim PW As String = Me.txtPass.Text

            If (PW Is Nothing) Then
                str = "call updateemployee_WO_PW(?,?,?,?,?)"
                cmd = New DB2Command(str, CONN)

                param1 = cmd.Parameters.Add("@1", DB2Type.VarChar)
                param1.Direction = ParameterDirection.Input
                cmd.Parameters("@1").Value = Me.TXTACCID.Text

                param2 = cmd.Parameters.Add("@2", DB2Type.VarChar)
                param2.Direction = ParameterDirection.Input
                cmd.Parameters("@2").Value = Me.txtFName.Text

                param3 = cmd.Parameters.Add("@3", DB2Type.VarChar)
                param3.Direction = ParameterDirection.Input
                cmd.Parameters("@3").Value = Me.txtMName.Text

                param4 = cmd.Parameters.Add("@4", DB2Type.VarChar)
                param4.Direction = ParameterDirection.Input
                cmd.Parameters("@4").Value = Me.txtLName.Text

                param6 = cmd.Parameters.Add("@6", DB2Type.VarChar)
                param6.Direction = ParameterDirection.Input
                cmd.Parameters("@6").Value = Me.TXTPOSITION.Text

                cmd.ExecuteNonQuery()
                MsgBox("Employee Information has been Updated!")
                Call REFRESHORDERDATAGRID()

            Else

                str = "call updateemployee(?,?,?,?,?,?)"
                cmd = New DB2Command(str, CONN)

                param1 = cmd.Parameters.Add("@1", DB2Type.VarChar)
                param1.Direction = ParameterDirection.Input
                cmd.Parameters("@1").Value = Me.TXTACCID.Text

                param2 = cmd.Parameters.Add("@2", DB2Type.VarChar)
                param2.Direction = ParameterDirection.Input
                cmd.Parameters("@2").Value = Me.txtFName.Text

                param3 = cmd.Parameters.Add("@3", DB2Type.VarChar)
                param3.Direction = ParameterDirection.Input
                cmd.Parameters("@3").Value = Me.txtMName.Text

                param4 = cmd.Parameters.Add("@4", DB2Type.VarChar)
                param4.Direction = ParameterDirection.Input
                cmd.Parameters("@4").Value = Me.txtLName.Text

                param5 = cmd.Parameters.Add("@5", DB2Type.VarChar)
                param5.Direction = ParameterDirection.Input
                cmd.Parameters("@5").Value = Me.txtPass.Text

                param6 = cmd.Parameters.Add("@6", DB2Type.VarChar)
                param6.Direction = ParameterDirection.Input
                cmd.Parameters("@6").Value = Me.TXTPOSITION.Text

                cmd.ExecuteNonQuery()
                MsgBox("Employee Information has been Updated!")
                Call REFRESHORDERDATAGRID()
            End If

        Catch ex As Exception
            MsgBox("Something went wrong please try again!")

        End Try
    End Sub
End Class