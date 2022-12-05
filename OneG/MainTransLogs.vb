Imports IBM.Data.DB2
Public Class MainTransLogs
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
            With Me.dgvSystemLogs
                .ColumnCount = 2
                .Columns(0).Name = "DATE"
                .Columns(1).Name = "TRANSACTION HISTORY"

                Call REFRESHORDERDATAGRID()
            End With
            dgvSystemLogs.Columns(0).Width = 80
            'dgvSystemLogs.RowTemplate.Height = 30

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub REFRESHORDERDATAGRID()
        Me.cmbSystemLogs.Text = "SELECT"
        Me.lblWelcomeBar.Text = "WELCOME, " + Home.nameU.ToString + " !"
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        Dim rows As String()



        cmd = New DB2Command("Select * from transactlog", conn)
        rdr = cmd.ExecuteReader

        Me.dgvSystemLogs.Rows.Clear()
        While rdr.Read
            rows = New String() {rdr.GetString(0), rdr.GetString(1)}
            Me.dgvSystemLogs.Rows.Add(rows)
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



    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked
        MainEmp.Show()
        Me.Hide()
    End Sub
    Private Sub TableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TableToolStripMenuItem.Click
        MainTable.Show()
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

    Private Sub dgvSystemLogs_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSystemLogs.CellContentClick

    End Sub

    Private Sub cmbSystemLogs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSystemLogs.SelectedIndexChanged
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        Dim rows As String()

        If cmbSystemLogs.Text = "ALL" Then
            cmd = New DB2Command("Select * from transactlog", conn)
            rdr = cmd.ExecuteReader

            Me.dgvSystemLogs.Rows.Clear()
            While rdr.Read
                rows = New String() {rdr.GetString(0), rdr.GetString(1)}
                Me.dgvSystemLogs.Rows.Add(rows)
            End While

        Else

            cmd = New DB2Command("Select * from transactlog where comment like '" & cmbSystemLogs.Text & "%'", conn)
            rdr = cmd.ExecuteReader

            Me.dgvSystemLogs.Rows.Clear()
            While rdr.Read
                rows = New String() {rdr.GetString(0), rdr.GetString(1)}
                Me.dgvSystemLogs.Rows.Add(rows)
            End While
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        Dim rows As String()



        cmd = New DB2Command("select * from transactlog where logdate = @d ", conn)

        cmd.Parameters.Add("@d", DB2Type.Date).Value = DateTimePicker1.Value
        rdr = cmd.ExecuteReader

        Me.dgvSystemLogs.Rows.Clear()
        While rdr.Read
            rows = New String() {rdr.GetString(0), rdr.GetString(1)}
            Me.dgvSystemLogs.Rows.Add(rows)
        End While
    End Sub
End Class