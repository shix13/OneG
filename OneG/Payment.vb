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
        Me.cmbTableNo.Text = "SELECT"
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
                rows = New String() {rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4)}
                Me.dgvPayment.Rows.Add(rows)
            End While


            str = "call db2admin.GETLASTRECEIPTNO(?)"
            cmd = New DB2Command(str, conn)
            param1 = cmd.Parameters.Add("@1", DB2Type.Integer)
            param1.Direction = ParameterDirection.Output
            rdr = cmd.ExecuteReader

            Me.txtReceiptNo.Text = param1.Value.ToString
            Me.txtAmountToPay.Clear()
            Me.txtOrderNo.Clear()

            Dim dtadapt2 As DB2DataAdapter
            Dim ds2 As DataSet = New DataSet()

            dtadapt2 = New DB2DataAdapter("select * from tables", conn)
            dtadapt2.Fill(ds2, "Tables")
            cmbTableNo.DisplayMember = "tableno"
            cmbTableNo.ValueMember = "tableno"
            cmbTableNo.DataSource = ds2.Tables("Tables")
            txtAmountToPay.Text = "0.0"

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

End Class