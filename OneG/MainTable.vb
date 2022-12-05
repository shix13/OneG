Imports IBM.Data.DB2
Public Class MainTable
    Dim sidebar As String = "Close"
    Private conn As Common.DbConnection
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


    Private Sub MainTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn = New DB2Connection("server=localhost;database=oneg;" + "uid=db2admin;password=db2admin;")
            conn.Open()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try


            With Me.dgvTable
                .ColumnCount = 3
                .Columns(0).Name = "TABLE NO"
                .Columns(1).Name = "NUM OF SEATS"
                .Columns(2).Name = "AVAILABILITY"
                Call RefreshorderDataGrid()
            End With


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub REFRESHORDERDATAGRID()
        Me.cmbNoOfSeat.Text = "SELECT"
        Me.lblWelcomeBar.Text = "WELCOME, " + Home.nameU.ToString + " !"
        Dim str As String
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        Dim param1 As DB2Parameter
        Dim rows As String()
        str = "call db2admin.getlasttableno(?)"
        cmd = New DB2Command(str, conn)
        param1 = cmd.Parameters.Add("@1", DB2Type.Integer)
        param1.Direction = ParameterDirection.Output

        rdr = cmd.ExecuteReader
        Me.txtTableNo.Text = param1.Value.ToString


        str = "select * from table( db2admin.tablelist()) as udf"
        cmd = New DB2Command(str, conn)
        rdr = cmd.ExecuteReader

        Me.dgvTable.Rows.Clear()
        While rdr.Read
            rows = New String() {rdr.GetString(0), rdr.GetString(1), rdr.GetString(2)}
            Me.dgvTable.Rows.Add(rows)
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



    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles savebtn.Click

        Dim str As String
        Dim cmd As DB2Command
        Dim RDR As DB2DataReader
        Dim param1 As DB2Parameter
        Dim param2 As DB2Parameter



        cmd = New DB2Command("select TABLENO from TABLES where TABLENO ='" & txtTableNo.Text & "'", conn)
        RDR = cmd.ExecuteReader
        If RDR.HasRows Then

            Try

                str = "call updatetable(?,?)"
                cmd = New DB2Command(str, conn)

                param1 = cmd.Parameters.Add("@1", DB2Type.VarChar)
                param1.Direction = ParameterDirection.Input
                cmd.Parameters("@1").Value = Me.txtTableNo.Text

                param2 = cmd.Parameters.Add("@2", DB2Type.Integer)
                param2.Direction = ParameterDirection.Input
                cmd.Parameters("@2").Value = Me.cmbNoOfSeat.Text


                cmd.ExecuteNonQuery()
                MsgBox("Table has been Updated!")
                Call REFRESHORDERDATAGRID()
            Catch ex As Exception
                MsgBox("Something went wrong please try again!")

            End Try
        Else
            If cmbNoOfSeat.Text = "SELECT" Or cmbNoOfSeat.Text = "" Then
                MsgBox("Please Select the Number of Seats")
            Else


                Try


                    str = "call INSERTTABLE(?,?)"
                    cmd = New DB2Command(str, conn)

                    param1 = cmd.Parameters.Add("@1", DB2Type.VarChar)
                    param1.Direction = ParameterDirection.Input
                    cmd.Parameters("@1").Value = Me.txtTableNo.Text

                    param2 = cmd.Parameters.Add("@2", DB2Type.VarChar)
                    param2.Direction = ParameterDirection.Input
                    cmd.Parameters("@2").Value = Me.cmbNoOfSeat.Text



                    cmd.ExecuteNonQuery()
                    MsgBox("Table Added Successfully!")
                    Call REFRESHORDERDATAGRID()
                Catch ex As Exception
                    MsgBox("Something went wrong please try again!")
                End Try
            End If
        End If
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        Dim str As String
        Dim cmd As DB2Command
        Dim param1 As DB2Parameter
        Dim answer As DialogResult
        answer = MessageBox.Show("Table info will be delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            Try

                str = "call DELETETABLE(?)"
                cmd = New DB2Command(str, conn)

                param1 = cmd.Parameters.Add("@1", DB2Type.VarChar)
                param1.Direction = ParameterDirection.Input
                cmd.Parameters("@1").Value = Me.txtTableNo.Text


                cmd.ExecuteNonQuery()
                MsgBox("Table has been Deleted!")
                Call REFRESHORDERDATAGRID()
            Catch ex As Exception
                MsgBox("Something went wrong please try again!")
            End Try
        End If
    End Sub



    Private Sub dgvTable_MouseUp(sender As Object, e As MouseEventArgs) Handles dgvTable.MouseUp
        Try
            Me.txtTableNo.Text = Me.dgvTable.CurrentRow.Cells(0).Value
            Me.cmbNoOfSeat.Text = Me.dgvTable.CurrentRow.Cells(1).Value
        Catch ex As Exception

        End Try

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
    Private Sub EmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeToolStripMenuItem.Click
        MainEmp.Show()
        Me.Close()
    End Sub
    Private Sub SupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem.Click
        MainSupp.Show()
        Me.Close()
    End Sub

    Private Sub MenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuToolStripMenuItem.Click
        MainMenu.Show()
        Me.Close()
    End Sub

    Private Sub InventoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventoryToolStripMenuItem.Click
        MainInventory.Show()
        Me.Close()
    End Sub

    Private Sub TransactionLogsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SystemLogsToolStripMenuItem.Click
        MainTransLogs.Show()
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