Imports System.Net.NetworkInformation
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports IBM.Data.DB2

Public Class Payment
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
    Private Sub Payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn = New DB2Connection("server=localhost;database=oneg;" + "uid=db2admin;password=db2admin;")
            conn.Open()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            With Me.dgvPayment
                .ColumnCount = 5
                .Columns(0).Name = "RECEIPT NO"
                .Columns(1).Name = "DATE OF TRANSACTION"
                .Columns(2).Name = "AMOUNT"
                .Columns(3).Name = "TABLE NO"
                .Columns(4).Name = "PROCESSED BY"

                Call REFRESHORDERDATAGRID()
            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub REFRESHORDERDATAGRID()

        Me.lblWelcomeBar.Text = "WELCOME, " + Home.nameU.ToString + " !"

        Dim str As String
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        Dim param1 As DB2Parameter
        Dim rows As String()

        Try


            str = "select * from table( db2admin.paymentlist()) as udf"
            cmd = New DB2Command(str, conn)
            rdr = cmd.ExecuteReader
            rdr.Read()

            Me.dgvPayment.Rows.Clear()
            While rdr.Read
                rows = New String() {rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(4), rdr.GetString(3)}
                Me.dgvPayment.Rows.Add(rows)
            End While


            str = "call db2admin.GETLASTRECEIPTNO(?)"
            cmd = New DB2Command(str, conn)
            param1 = cmd.Parameters.Add("@1", DB2Type.Integer)
            param1.Direction = ParameterDirection.Output
            rdr = cmd.ExecuteReader

            Me.txtReceiptNo.Text = param1.Value.ToString
            Me.txtAmountToPay.Clear()


            Dim dtadapt2 As DB2DataAdapter
            Dim ds2 As DataSet = New DataSet()

            dtadapt2 = New DB2DataAdapter("select * from table(db2admin.tablelist()) as udf WHERE AVAILABILITY ='NOT AVAILABLE'", conn)
            dtadapt2.Fill(ds2, "Tables")
            cmbTableNo.DisplayMember = "tableno"
            cmbTableNo.ValueMember = "tableno"
            cmbTableNo.DataSource = ds2.Tables("Tables")

            txtOrderNo.Text = ""
            cmbTableNo.Text = "SELECT TABLE"
            txtAmountToPay.Text = "0.00"

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


    Private Sub cmbTableNo_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbTableNo.SelectedIndexChanged


        Dim cmdsearch As DB2Command
        Dim rdrsearch As DB2DataReader

        Try

            cmdsearch = New DB2Command("select ORDERNO,ORDERTOTAL from table(db2admin.orderlist()) as udf where TABLENO = @table AND PAYMENT ='NOT PAID'", conn)
            cmdsearch.Parameters.Add("@table", DB2Type.Integer).Value = cmbTableNo.Text
            rdrsearch = cmdsearch.ExecuteReader
            While rdrsearch.Read
                txtOrderNo.Text = rdrsearch.GetString(0)
                txtAmountToPay.Text = rdrsearch.GetString(1)
            End While


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmbTableNo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTableNo.SelectedValueChanged

    End Sub

    Private Sub ConfirmBtn_Click(sender As Object, e As EventArgs) Handles ConfirmBtn.Click
        Dim PARAM1 As DB2Parameter
        Dim PARAM2 As DB2Parameter
        Dim PARAM3 As DB2Parameter
        Dim PARAM4 As DB2Parameter
        Dim PARAM5 As DB2Parameter

        Dim cmdInsert1 As DB2Command
        If txtAmountToPay.Text = "0.00" Or txtAmountToPay.Text <= 0 Then
            MsgBox("Amount to pay cannot be less than zero (0)")
        Else
            ConfirmationBox.ShowDialog()

            If ConfirmationBox.confirmPayment = True Then
                Try

                    cmdInsert1 = New DB2Command("CALL PAYMENT_INSERT(?,?,?,?,?)", conn)

                    PARAM1 = cmdInsert1.Parameters.Add("@n1", DB2Type.Integer)
                    PARAM1.Direction = ParameterDirection.Input
                    cmdInsert1.Parameters("@n1").Value = txtReceiptNo.Text

                    PARAM2 = cmdInsert1.Parameters.Add("@n2", DB2Type.Date)
                    PARAM2.Direction = ParameterDirection.Input
                    cmdInsert1.Parameters("@n2").Value = dtpSideBar.Text

                    PARAM3 = cmdInsert1.Parameters.Add("@n3", DB2Type.Decimal)
                    PARAM3.Direction = ParameterDirection.Input
                    cmdInsert1.Parameters("@n3").Value = txtAmountToPay.Text

                    PARAM4 = cmdInsert1.Parameters.Add("@n4", DB2Type.VarChar)
                    PARAM4.Direction = ParameterDirection.Input
                    cmdInsert1.Parameters("@n4").Value = Home.ACCID.ToString

                    PARAM5 = cmdInsert1.Parameters.Add("@n5", DB2Type.Integer)
                    PARAM5.Direction = ParameterDirection.Input
                    cmdInsert1.Parameters("@n5").Value = cmbTableNo.Text()

                    cmdInsert1.ExecuteNonQuery()

                    cmdInsert1 = New DB2Command("update ORDER set  PAYMENT ='PAID' where orderno= '" & txtOrderNo.Text & "'", conn)
                    cmdInsert1.ExecuteNonQuery()
                    cmdInsert1 = New DB2Command("update tables set  availability ='AVAILABLE' where TABLENO= '" & cmbTableNo.Text & "'", conn)
                    cmdInsert1.ExecuteNonQuery()
                    MsgBox("payment info recorded...")
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Else
                MsgBox("Payment has been Canceled.")
            End If
        End If

        Call REFRESHORDERDATAGRID()
    End Sub

    Private Sub txtOrderNo_TextChanged(sender As Object, e As EventArgs) Handles txtOrderNo.TextChanged

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

    Private Sub MainBtn_Click(sender As Object, e As EventArgs) Handles MainBtn.Click
        If Home.role = "Cashier" Or Home.role = "CASHIER" Then
            MsgBox("Account Type Not Authorized.")
        ElseIf Home.role = "Cook" Then
            MainMenu.Show()
            Me.Close()
        Else
            MainTable.Show()
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
            Me.Close()
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

    Private Sub IconMainBtn_Click(sender As Object, e As EventArgs) Handles IconMainBtn.Click
        If Home.role = "Cashier" Or Home.role = "CASHIER" Then
            MsgBox("Account Type Not Authorized.")
        ElseIf Home.role = "Cook" Then
            MainMenu.Show()
            Me.Close()
        Else
            MainTable.Show()
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