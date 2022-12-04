Imports IBM.Data.DB2

Public Class MainSupp
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


    Private Sub MainSupp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn = New DB2Connection("server=localhost;database=oneg;" + "uid=db2admin;password=db2admin;")
            conn.Open()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            With Me.dgvSupplier
                .ColumnCount = 3
                .Columns(0).Name = "SUPPLIER ID"
                .Columns(1).Name = "NAME"
                .Columns(2).Name = "CONTACT NO"

                Call REFRESHORDERDATAGRID()
            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub REFRESHORDERDATAGRID()
        Dim randNum As New Random
        Dim value As Integer = randNum.Next(1, 10000)
        txtSupID.Text = "SUP_" + value.ToString

        Me.lblWelcomeBar.Text = "WELCOME, " + Home.name.ToString + " !"
        Dim str As String
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        Dim rows As String()
        Me.txtContactNo.Clear()
        Me.txtSupName.Clear()


        str = "select * from table( db2admin.SUPPLIERLIST()) as udf"
        cmd = New DB2Command(str, conn)
        rdr = cmd.ExecuteReader

        Me.dgvSupplier.Rows.Clear()
        While rdr.Read
            rows = New String() {rdr.GetString(0), rdr.GetString(1), rdr.GetString(2)}
            Me.dgvSupplier.Rows.Add(rows)
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



    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        Dim str As String
        Dim cmd As DB2Command
        Dim param1 As DB2Parameter
        Dim param2 As DB2Parameter
        Dim param3 As DB2Parameter
        Dim RDR As DB2DataReader


        cmd = New DB2Command("select SUPID from SUPPLIER where SUPID ='" & txtSupID.Text & "'", conn)
        RDR = cmd.ExecuteReader
        If RDR.HasRows Then
            Try
                str = "call updatesupplier(?,?,?)"
                cmd = New DB2Command(str, conn)

                param1 = cmd.Parameters.Add("@1", DB2Type.VarChar)
                param1.Direction = ParameterDirection.Input
                cmd.Parameters("@1").Value = Me.txtSupID.Text

                param2 = cmd.Parameters.Add("@2", DB2Type.VarChar)
                param2.Direction = ParameterDirection.Input
                cmd.Parameters("@2").Value = Me.txtSupName.Text

                param3 = cmd.Parameters.Add("@3", DB2Type.VarChar)
                param3.Direction = ParameterDirection.Input
                cmd.Parameters("@3").Value = Me.txtContactNo.Text

                cmd.ExecuteNonQuery()
                MsgBox("Supplier Information has been Updated!")
                Call REFRESHORDERDATAGRID()

            Catch ex As Exception
                MsgBox("Something went wrong please try again!")

            End Try
        Else

            Try
                str = "call INSERTSUPPLIER(?,?,?)"
                cmd = New DB2Command(str, conn)

                param1 = cmd.Parameters.Add("@1", DB2Type.VarChar)
                param1.Direction = ParameterDirection.Input
                cmd.Parameters("@1").Value = Me.txtSupID.Text

                param2 = cmd.Parameters.Add("@2", DB2Type.VarChar)
                param2.Direction = ParameterDirection.Input
                cmd.Parameters("@2").Value = Me.txtSupName.Text

                param3 = cmd.Parameters.Add("@3", DB2Type.VarChar)
                param3.Direction = ParameterDirection.Input
                cmd.Parameters("@3").Value = Me.txtContactNo.Text



                cmd.ExecuteNonQuery()
                MsgBox("Supplier Information Saved Successfully!")
                REFRESHORDERDATAGRID()
            Catch ex As Exception
                MsgBox("Something went wrong please try again!")


            End Try

        End If

    End Sub

    Private Sub searchSupp_TextChanged(sender As Object, e As EventArgs) Handles searchSupp.TextChanged
        Dim strsearchkey As String
        Dim cmdsearch As DB2Command
        Dim rdr As DB2DataReader
        Dim rows As String()

        Try
            strsearchkey = Me.searchSupp.Text + "%"
            cmdsearch = New DB2Command("select * from supplier where supname like '" & strsearchkey & "'", conn)
            rdr = cmdsearch.ExecuteReader
            Me.dgvSupplier.Rows.Clear()

            While rdr.Read
                rows = New String() {rdr.GetString(0), rdr.GetString(1), rdr.GetString(2)}
                Me.dgvSupplier.Rows.Add(rows)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    Private Sub dgvSupplier_MouseUp(sender As Object, e As MouseEventArgs) Handles dgvSupplier.MouseUp
        Try
            Me.txtSupID.Text = Me.dgvSupplier.CurrentRow.Cells(0).Value
            Me.txtSupName.Text = Me.dgvSupplier.CurrentRow.Cells(1).Value
            Me.txtContactNo.Text = Me.dgvSupplier.CurrentRow.Cells(2).Value

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        Dim str As String
        Dim cmd As DB2Command
        Dim param1 As DB2Parameter


        Try

            str = "call DELETESUPPLIER(?)"
            cmd = New DB2Command(str, conn)

            param1 = cmd.Parameters.Add("@1", DB2Type.VarChar)
            param1.Direction = ParameterDirection.Input
            cmd.Parameters("@1").Value = Me.txtSupID.Text


            cmd.ExecuteNonQuery()
            MsgBox("Supplier Information has been Deleted!")
            Call REFRESHORDERDATAGRID()
        Catch ex As Exception
            MsgBox("Something went wrong please try again!")
        End Try
    End Sub

    Private Sub MenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuToolStripMenuItem.Click
        MainMenu.Show()
        Me.Close()
    End Sub

    Private Sub InventoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventoryToolStripMenuItem.Click
        MainInventory.Show()
        Me.Close()
    End Sub

    Private Sub EmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeToolStripMenuItem.Click
        MainEmp.Show()
        Me.Close()
    End Sub

    Private Sub TableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TableToolStripMenuItem.Click
        MainTable.Show()
        Me.Close()
    End Sub




    'CLOSE BUTTON'
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Home.Show()
        Me.Close()
    End Sub


    'WORD BUTTONS'
    Private Sub OrderBtn_Click(sender As Object, e As EventArgs) Handles OrderBtn.Click
        If Home.role = "COOK" Or Home.role = "Cook" Then
            MsgBox("Account Type Not Authorized.")
        Else
            Order.Show()
            Me.Close()
        End If
    End Sub
    Private Sub PayBtn_Click(sender As Object, e As EventArgs) Handles PayBtn.Click
        If Home.role = "COOK" Or Home.role = "Cook" Then
            MsgBox("Account Type Not Authorized.")
        Else
            Payment.Show()
            Me.Close()
        End If
    End Sub

    Private Sub AccBtn_Click(sender As Object, e As EventArgs) Handles AccBtn.Click
        AccountUser.Show()
        Me.Close()
    End Sub

    Private Sub PurcBtn_Click(sender As Object, e As EventArgs) Handles PurcBtn.Click
        If Home.role = "Cashier" Or Home.role = "CASHIER" Then
            MsgBox("Account Type Not Authorized.")
        Else
            PurchaseOrder.Show()
            Me.Hide()
        End If
    End Sub

    'LOGOUT BUTTON'
    Private Sub LogoutBtn_Click(sender As Object, e As EventArgs) Handles LogoutBtn.Click
        logout.ShowDialog()
        If logout.out = True Then
            MsgBox("Logging out of account.")
            Login.Show()
            Me.Close()
        Else
            MsgBox("Log out Cancelled.")
        End If

    End Sub


    'ICON BUTTONS'
    Private Sub IconOrderBtn_Click(sender As Object, e As EventArgs) Handles IconOrderBtn.Click
        If Home.role = "COOK" Or Home.role = "Cook" Then
            MsgBox("Account Type Not Authorized.")
        Else
            Order.Show()
            Me.Close()
        End If
    End Sub
    Private Sub IconPayBtn_Click(sender As Object, e As EventArgs) Handles IconPayBtn.Click
        If Home.role = "Cook" Or Home.role = "COOK" Then
            MsgBox("Account Type Not Authorized.")
        Else
            Payment.Show()
            Me.Close()
        End If
    End Sub

    Private Sub IconAccBtn_Click(sender As Object, e As EventArgs) Handles IconAccBtn.Click
        AccountUser.Show()
        Me.Close()
    End Sub

    Private Sub IconPurcBtn_Click(sender As Object, e As EventArgs) Handles IconPurcBtn.Click
        If Home.role = "Cashier" Or Home.role = "CASHIER" Then
            MsgBox("Account Type Not Authorized.")
        Else
            PurchaseOrder.Show()
            Me.Close()
        End If
    End Sub




End Class