Imports System.Windows.Forms.VisualStyles.VisualStyleElement
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

        Me.lblWelcomeBar.Text = "WELCOME, " + Login.name.ToString + " !"

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

            dtadapt2 = New DB2DataAdapter("select * from tables WHERE AVAILABILITY ='NOT AVAILABLE'", conn)
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

    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub



    Private Sub cmbTableNo_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbTableNo.SelectedIndexChanged


        Dim cmdsearch As DB2Command
        Dim rdrsearch As DB2DataReader

        Try

            cmdsearch = New DB2Command("select ORDERNO,ORDERTOTAL from ORDER where TABLENO = '" & cmbTableNo.Text & "' AND PAYMENT ='NOT PAID'", conn)
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


        Dim cmdInsert As DB2Command
        'dtpSideBar.Value = Now
        If txtAmountToPay.Text = "0.00" Or txtAmountToPay.Text <= 0 Then
            MsgBox("Amount to pay cannot be less than zero (0)")
        Else
            ConfirmationBox.ShowDialog()

            If ConfirmationBox.confirmPayment = True Then
                Try

                    cmdInsert = New DB2Command("insert into payment values (@rcpt,@date,@amt,@accid,@table)", conn)
                    cmdInsert.Parameters.Add("@date", DB2Type.Date).Value = dtpSideBar.Text
                    cmdInsert.Parameters.Add("@amt", DB2Type.Decimal).Value = txtAmountToPay.Text
                    cmdInsert.Parameters.Add("@table", DB2Type.Integer).Value = cmbTableNo.Text()
                    cmdInsert.Parameters.Add("@accid", DB2Type.VarChar).Value = Login.ACCID.ToString
                    cmdInsert.Parameters.Add("@rcpt", DB2Type.Integer).Value = txtReceiptNo.Text
                    cmdInsert.ExecuteNonQuery()

                    cmdInsert = New DB2Command("update ORDER set  PAYMENT ='PAID' where orderno= '" & txtOrderNo.Text & "'", conn)
                    cmdInsert.ExecuteNonQuery()
                    cmdInsert = New DB2Command("update tables set  availability ='AVAILABLE' where TABLENO= '" & cmbTableNo.Text & "'", conn)
                    cmdInsert.ExecuteNonQuery()
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
End Class