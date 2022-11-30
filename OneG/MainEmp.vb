Imports IBM.Data.DB2

Public Class MainEmp
    Private conn As Common.DbConnection
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


    Private Sub MainEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn = New DB2Connection("server=localhost;database=oneg;" + "uid=db2admin;password=db2admin;")
            conn.Open()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            With Me.dgvEmployeeAcc
                .ColumnCount = 5
                .Columns(0).Name = "ACCOUNT ID"
                .Columns(1).Name = "FIRST NAME"
                .Columns(2).Name = "MIDDLE NAME"
                .Columns(3).Name = "LAST NAME"
                .Columns(4).Name = "POSITION"
                Call REFRESHORDERDATAGRID()
            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub REFRESHORDERDATAGRID()
        Me.cmbPosition.Text = "SELECT"
        Me.lblWelcomeBar.Text = "WELCOME, " + Login.name.ToString + " !"
        Dim str As String
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        Dim rows As String()
        Dim value As Integer = CInt(Int((10000 * Rnd()) + 1))
        txtAccID.Text = "ACC_" + value.ToString
        Me.txtFName.Clear()
        Me.txtLName.Clear()
        Me.txtMName.Clear()
        Me.txtPass.Clear()


        str = "select * from table( db2admin.EMPLOYEELIST()) as udf"
        cmd = New DB2Command(str, conn)
        rdr = cmd.ExecuteReader

        Me.dgvEmployeeAcc.Rows.Clear()
        While rdr.Read
            rows = New String() {rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(5)}
            Me.dgvEmployeeAcc.Rows.Add(rows)
        End While
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

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        Dim str As String
        Dim cmd As DB2Command
        Dim param1 As DB2Parameter
        Dim param2 As DB2Parameter
        Dim param3 As DB2Parameter
        Dim param4 As DB2Parameter
        Dim param5 As DB2Parameter
        Dim param6 As DB2Parameter

        Try
            str = "call insertEmployee(?,?,?,?,?,?)"
            cmd = New DB2Command(str, conn)

            param1 = cmd.Parameters.Add("@1", DB2Type.VarChar)
            param1.Direction = ParameterDirection.Input
            cmd.Parameters("@1").Value = Me.txtAccID.Text

            param2 = cmd.Parameters.Add("@2", DB2Type.VarChar)
            param2.Direction = ParameterDirection.Input
            cmd.Parameters("@2").Value = Me.txtLName.Text

            param3 = cmd.Parameters.Add("@3", DB2Type.VarChar)
            param3.Direction = ParameterDirection.Input
            cmd.Parameters("@3").Value = Me.txtFName.Text

            param4 = cmd.Parameters.Add("@4", DB2Type.VarChar)
            param4.Direction = ParameterDirection.Input
            cmd.Parameters("@4").Value = Me.txtMName.Text

            param5 = cmd.Parameters.Add("@5", DB2Type.VarChar)
            param5.Direction = ParameterDirection.Input
            cmd.Parameters("@5").Value = Me.cmbPosition.Text

            param6 = cmd.Parameters.Add("@6", DB2Type.VarChar)
            param6.Direction = ParameterDirection.Input
            cmd.Parameters("@6").Value = Me.txtPass.Text

            cmd.ExecuteNonQuery()
            MsgBox("Account Saved Successfully!")
            REFRESHORDERDATAGRID()
        Catch ex As Exception
            MsgBox("Something went wrong please try again!")
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim str As String
        Dim cmd As DB2Command
        Dim param1 As DB2Parameter
        Dim param2 As DB2Parameter
        Dim param3 As DB2Parameter
        Dim param4 As DB2Parameter
        Dim param5 As DB2Parameter
        Dim param6 As DB2Parameter
        Dim PW As String = Me.txtPass.Text

        Try
            If (PW Is Nothing) Then
                str = "call updateemployee_WO_PW(?,?,?,?,?)"
                cmd = New DB2Command(str, conn)

                param1 = cmd.Parameters.Add("@1", DB2Type.VarChar)
                param1.Direction = ParameterDirection.Input
                cmd.Parameters("@1").Value = Me.txtAccID.Text

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
                cmd.Parameters("@6").Value = Me.cmbPosition.Text

                cmd.ExecuteNonQuery()
                MsgBox("Employee Information has been Updated!")
                Call REFRESHORDERDATAGRID()

            Else
                str = "call updateemployee(?,?,?,?,?,?)"
                cmd = New DB2Command(str, conn)

                param1 = cmd.Parameters.Add("@1", DB2Type.VarChar)
                param1.Direction = ParameterDirection.Input
                cmd.Parameters("@1").Value = Me.txtAccID.Text

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
                cmd.Parameters("@6").Value = Me.cmbPosition.Text

                cmd.ExecuteNonQuery()
                MsgBox("Employee Information has been Updated!")
                Call REFRESHORDERDATAGRID()
            End If

        Catch ex As Exception
            MsgBox("Something went wrong please try again!")

        End Try
    End Sub

    Private Sub dgvEmployeeAcc_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmployeeAcc.CellContentClick

    End Sub

    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub

    Private Sub dgvEmployeeAcc_MouseUp(sender As Object, e As MouseEventArgs) Handles dgvEmployeeAcc.MouseUp
        Try
            Me.txtAccID.Text = Me.dgvEmployeeAcc.CurrentRow.Cells(0).Value
            Me.txtFName.Text = Me.dgvEmployeeAcc.CurrentRow.Cells(1).Value
            Me.txtMName.Text = Me.dgvEmployeeAcc.CurrentRow.Cells(2).Value
            Me.txtLName.Text = Me.dgvEmployeeAcc.CurrentRow.Cells(3).Value
            Me.cmbPosition.Text = Me.dgvEmployeeAcc.CurrentRow.Cells(4).Value
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        Dim str As String
        Dim cmd As DB2Command
        Dim param1 As DB2Parameter


        Try

            str = "call DELETEemployee(?)"
            cmd = New DB2Command(str, conn)

            param1 = cmd.Parameters.Add("@1", DB2Type.VarChar)
            param1.Direction = ParameterDirection.Input
            cmd.Parameters("@1").Value = Me.txtAccID.Text


            cmd.ExecuteNonQuery()
            MsgBox("Employee Account has been Deleted!")
            Call REFRESHORDERDATAGRID()
        Catch ex As Exception
            MsgBox("Something went wrong please try again!")
        End Try
    End Sub

    Private Sub txtSearch_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub searchAccID_TextChanged(sender As Object, e As EventArgs) Handles searchAccID.TextChanged
        Dim strsearchkey As String
        Dim cmdsearch As DB2Command
        Dim rdr As DB2DataReader
        Dim rows As String()

        Try
            strsearchkey = Me.searchAccID.Text + "%"
            cmdsearch = New DB2Command("select * from employee where lname like '" & strsearchkey & "'", conn)
            rdr = cmdsearch.ExecuteReader

            Me.dgvEmployeeAcc.Rows.Clear()
            While rdr.Read
                rows = New String() {rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(5)}
                Me.dgvEmployeeAcc.Rows.Add(rows)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class