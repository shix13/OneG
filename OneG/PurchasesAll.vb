Imports System.Data.Common
Imports System.Net.Security
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports IBM.Data.DB2

Public Class PurchasesAll
    Private conn As DbConnection
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


    Private Sub PurchasesAll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New DB2Connection("server=localhost;database=oneg;" + "uid=db2admin;password=db2admin;")
        conn.Open()

        Try


            With Me.dgvPurchases 'PO to be ordered
                .ColumnCount = 12
                .Columns(0).Name = "PURCHASE ORDER NUMBER"
                .Columns(1).Name = "PROCESSED BY"
                .Columns(2).Name = "SUPPLIER"
                .Columns(3).Name = "INGREDIENT"
                .Columns(4).Name = "QTY"
                .Columns(5).Name = "UNIT"
                .Columns(6).Name = "PURCHASE PRICE"
                .Columns(7).Name = "SUBTOTAL"
                .Columns(8).Name = "DELIVERY STATUS"
                .Columns(9).Name = "DATE ORDERED"
                .Columns(10).Name = "sup id"
                .Columns(11).Name = "ing id"
            End With

            dgvPurchases.Columns(10).Visible = False
            dgvPurchases.Columns(11).Visible = False

            Me.lblWelcomeBar.Text = "WELCOME, " + Home.nameU.ToString + "!"
            Call RefreshorderDataGrid()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RefreshorderDataGrid()
        Try

            Dim cmd As DB2Command
            Dim rdr As DB2DataReader
            Dim i As Integer = 0
            CmbSearchSup.Text = "NOT DELIVERED"


            cmd = New DB2Command("select * from table( db2admin.purchaseOrder_leftJoin()) as udf", conn)
            rdr = cmd.ExecuteReader
            Me.dgvPurchases.Rows.Clear()
            While rdr.Read
                dgvPurchases.Rows.Add()

                Me.dgvPurchases.Rows(i).Cells(0).Value = rdr.GetString(0)
                Me.dgvPurchases.Rows(i).Cells(1).Value = rdr.GetString(7)
                Me.dgvPurchases.Rows(i).Cells(2).Value = rdr.GetString(15)
                Me.dgvPurchases.Rows(i).Cells(3).Value = rdr.GetString(11)
                Me.dgvPurchases.Rows(i).Cells(4).Value = rdr.GetString(6)
                Me.dgvPurchases.Rows(i).Cells(5).Value = rdr.GetString(5)
                Me.dgvPurchases.Rows(i).Cells(6).Value = rdr.GetString(4)
                Me.dgvPurchases.Rows(i).Cells(7).Value = rdr.GetString(3)
                Me.dgvPurchases.Rows(i).Cells(8).Value = rdr.GetString(2)
                Me.dgvPurchases.Rows(i).Cells(9).Value = rdr.GetString(1)
                Me.dgvPurchases.Rows(i).Cells(10).Value = rdr.GetString(8)
                Me.dgvPurchases.Rows(i).Cells(11).Value = rdr.GetString(9)
                i += 1

            End While


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


    Private Sub dgvPurchases_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPurchases.CellContentClick


    End Sub

    Private Sub searchPurchases_TextChanged(sender As Object, e As EventArgs) Handles searchPurchases.TextChanged

        Dim cmd As DB2Command
        Dim rdr As DB2DataReader

        Dim i As Integer = 0

        Try
            cmd = New DB2Command("select * from table( db2admin.purchaseOrder_leftJoin()) as udf", conn)
            rdr = cmd.ExecuteReader
            Me.dgvPurchases.Rows.Clear()
            While rdr.Read
                If rdr.GetString(11).StartsWith(searchPurchases.Text) Then
                    dgvPurchases.Rows.Add()
                    Me.dgvPurchases.Rows(i).Cells(0).Value = rdr.GetString(0)
                    Me.dgvPurchases.Rows(i).Cells(1).Value = rdr.GetString(7)
                    Me.dgvPurchases.Rows(i).Cells(2).Value = rdr.GetString(15)
                    Me.dgvPurchases.Rows(i).Cells(3).Value = rdr.GetString(11)
                    Me.dgvPurchases.Rows(i).Cells(4).Value = rdr.GetString(6)
                    Me.dgvPurchases.Rows(i).Cells(5).Value = rdr.GetString(5)
                    Me.dgvPurchases.Rows(i).Cells(6).Value = rdr.GetString(4)
                    Me.dgvPurchases.Rows(i).Cells(7).Value = rdr.GetString(3)
                    Me.dgvPurchases.Rows(i).Cells(8).Value = rdr.GetString(2)
                    Me.dgvPurchases.Rows(i).Cells(9).Value = rdr.GetString(1)
                    Me.dgvPurchases.Rows(i).Cells(10).Value = rdr.GetString(8)
                    Me.dgvPurchases.Rows(i).Cells(11).Value = rdr.GetString(9)
                    i += 1
                End If

            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSearchSup.SelectedIndexChanged
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader

        Dim i As Integer = 0

        Try
            cmd = New DB2Command("select * from table( db2admin.purchaseOrder_leftJoin()) as udf", conn)
            rdr = cmd.ExecuteReader
            Me.dgvPurchases.Rows.Clear()
            While rdr.Read
                If rdr.GetString(2).StartsWith(CmbSearchSup.Text) Then
                    dgvPurchases.Rows.Add()
                    Me.dgvPurchases.Rows(i).Cells(0).Value = rdr.GetString(0)
                    Me.dgvPurchases.Rows(i).Cells(1).Value = rdr.GetString(7)
                    Me.dgvPurchases.Rows(i).Cells(2).Value = rdr.GetString(15)
                    Me.dgvPurchases.Rows(i).Cells(3).Value = rdr.GetString(11)
                    Me.dgvPurchases.Rows(i).Cells(4).Value = rdr.GetString(6)
                    Me.dgvPurchases.Rows(i).Cells(5).Value = rdr.GetString(5)
                    Me.dgvPurchases.Rows(i).Cells(6).Value = rdr.GetString(4)
                    Me.dgvPurchases.Rows(i).Cells(7).Value = rdr.GetString(3)
                    Me.dgvPurchases.Rows(i).Cells(8).Value = rdr.GetString(2)
                    Me.dgvPurchases.Rows(i).Cells(9).Value = rdr.GetString(1)
                    Me.dgvPurchases.Rows(i).Cells(10).Value = rdr.GetString(8)
                    Me.dgvPurchases.Rows(i).Cells(11).Value = rdr.GetString(9)
                    i += 1
                End If


            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        Dim StrDelete As String
        Dim CmdDelete As DB2Command

        If dgvPurchases.CurrentRow.Cells(8).Value = "DELIVERED" Then
            MsgBox("Delivered Items cannot be deleted")
        Else
            masterKey.ShowDialog()
            If masterKey.CONFIRM = True Then
                Try
                    StrDelete = "delete from purchases where po_no= '" & Me.dgvPurchases.CurrentRow.Cells(0).Value & "'"
                    CmdDelete = New DB2Command(StrDelete, conn)
                    CmdDelete.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
                MsgBox("Purchase Order has been Canceled.")
            Else
                MsgBox("Purchase Deletion has been Canceled.")
            End If
        End If


        Call RefreshorderDataGrid()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        Dim count As Integer = dgvPurchases.Rows.Count - 1
        Dim i As Integer = 0
        Dim cmdInsert As DB2Command
        Dim updated As Boolean = False
        Try
            Dim answer As DialogResult
            answer = MessageBox.Show("Purchase Order has Changes, Save?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If answer = vbYes Then

                While i < count
                    If Me.dgvPurchases.Rows(i).Cells(8).Value = "DELIVERED" Then

                    Else

                        cmdInsert = New DB2Command("update purchases set qtypur = @qty,ing_id = @ing,supid =@supid,empid=@emp ,pricepur=@price,subtotal=@sub,delvstat=@delv,purunit=@unit where po_no= '" & Me.dgvPurchases.Rows(i).Cells(0).Value & "'", conn)
                        cmdInsert.Parameters.Add("@ing", DB2Type.VarChar).Value = Me.dgvPurchases.Rows(i).Cells(11).Value
                        cmdInsert.Parameters.Add("@supid", DB2Type.VarChar).Value = Me.dgvPurchases.Rows(i).Cells(10).Value
                        cmdInsert.Parameters.Add("@qty", DB2Type.Double).Value = Me.dgvPurchases.Rows(i).Cells(4).Value
                        cmdInsert.Parameters.Add("@unit", DB2Type.VarChar).Value = Me.dgvPurchases.Rows(i).Cells(5).Value
                        cmdInsert.Parameters.Add("@price", DB2Type.Double).Value = Me.dgvPurchases.Rows(i).Cells(6).Value
                        cmdInsert.Parameters.Add("@sub", DB2Type.Double).Value = Me.dgvPurchases.Rows(i).Cells(7).Value
                        cmdInsert.Parameters.Add("@delv", DB2Type.VarChar).Value = Me.dgvPurchases.Rows(i).Cells(8).Value
                        cmdInsert.Parameters.Add("@emp", DB2Type.VarChar).Value = Me.dgvPurchases.Rows(i).Cells(1).Value
                        cmdInsert.ExecuteNonQuery()
                        updated = True
                    End If
                    i += 1
                End While

                If updated = False Then
                    MsgBox("Delivered Items cannot be updated")
                Else
                    MsgBox("Purchase Order Updated Succesfully")
                End If
                Call RefreshorderDataGrid()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub dgvPurchases_MouseUp(sender As Object, e As MouseEventArgs) Handles dgvPurchases.MouseUp
        If Me.dgvPurchases.CurrentRow.Cells(8).Value = "DELIVERED" Then
            MsgBox("Delivered Items cannot be updated")
        Else
        End If
    End Sub

    Private Sub dgvPurchases_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPurchases.CellDoubleClick
        If Me.dgvPurchases.CurrentRow.Cells(8).Value = "DELIVERED" Then
            MsgBox("Delivered Items cannot be updated")
        Else
            ConfirmCode.ShowDialog()

            If ConfirmCode.CONFIRM = True Then
                Me.dgvPurchases.CurrentRow.Cells(8).Value = "DELIVERED"

                Dim cmdInsert As DB2Command

                Dim count As Integer = 0
                Dim cmdupdate2 As DB2Command



                Try

                    cmdInsert = New DB2Command("update purchases set qtypur = @qty,ing_id = @ing,supid =@supid,empid=@emp ,pricepur=@price,subtotal=@sub,delvstat=@delv,purunit=@unit where po_no= '" & Me.dgvPurchases.CurrentRow.Cells(0).Value & "'", conn)
                    cmdInsert.Parameters.Add("@ing", DB2Type.VarChar).Value = Me.dgvPurchases.CurrentRow.Cells(11).Value
                    cmdInsert.Parameters.Add("@supid", DB2Type.VarChar).Value = Me.dgvPurchases.CurrentRow.Cells(10).Value
                    cmdInsert.Parameters.Add("@qty", DB2Type.Double).Value = Me.dgvPurchases.CurrentRow.Cells(4).Value
                    cmdInsert.Parameters.Add("@unit", DB2Type.VarChar).Value = Me.dgvPurchases.CurrentRow.Cells(5).Value
                    cmdInsert.Parameters.Add("@price", DB2Type.Double).Value = Me.dgvPurchases.CurrentRow.Cells(6).Value
                    cmdInsert.Parameters.Add("@sub", DB2Type.Double).Value = Me.dgvPurchases.CurrentRow.Cells(7).Value
                    cmdInsert.Parameters.Add("@delv", DB2Type.VarChar).Value = Me.dgvPurchases.CurrentRow.Cells(8).Value
                    cmdInsert.Parameters.Add("@emp", DB2Type.VarChar).Value = Me.dgvPurchases.CurrentRow.Cells(1).Value
                    cmdInsert.ExecuteNonQuery()



                    Dim stat As String = Me.dgvPurchases.CurrentRow.Cells(8).Value
                    Dim unit As String

                    If stat = "DELIVERED" Then
                        Dim Cmdunit As DB2Command
                        Dim rdrunit As DB2DataReader

                        Cmdunit = New DB2Command("select ingunit from ingredients where ing_ID= '" & Me.dgvPurchases.CurrentRow.Cells(11).Value & "'", conn)
                        rdrunit = Cmdunit.ExecuteReader
                        rdrunit.Read()

                        unit = rdrunit.GetString(0)

                        If unit = "KILOGRAMS" And Me.dgvPurchases.CurrentRow.Cells(5).Value = "KILOGRAMS" Then
                            cmdupdate2 = New DB2Command("update ingredients set ingqty = ingqty +@sqty where ing_id= '" & Me.dgvPurchases.CurrentRow.Cells(11).Value & "'", conn)
                            cmdupdate2.Parameters.Add("@sqty", DB2Type.Decimal).Value = Me.dgvPurchases.CurrentRow.Cells(4).Value
                            cmdupdate2.ExecuteNonQuery()

                        ElseIf unit = "KILOGRAMS" And Me.dgvPurchases.CurrentRow.Cells(5).Value = "GRAMS" Then
                            cmdupdate2 = New DB2Command("update ingredients set ingqty = ingqty +@sqty where ing_id= '" & Me.dgvPurchases.CurrentRow.Cells(11).Value & "'", conn)
                            cmdupdate2.Parameters.Add("@sqty", DB2Type.Decimal).Value = Me.dgvPurchases.CurrentRow.Cells(4).Value / 1000
                            cmdupdate2.ExecuteNonQuery()


                        ElseIf unit = "GRAMS" And Me.dgvPurchases.CurrentRow.Cells(5).Value = "KILOGRAMS" Then
                            cmdupdate2 = New DB2Command("update ingredients set ingqty = ingqty +@sqty where ing_id= '" & Me.dgvPurchases.CurrentRow.Cells(11).Value & "'", conn)
                            cmdupdate2.Parameters.Add("@sqty", DB2Type.Decimal).Value = Me.dgvPurchases.CurrentRow.Cells(4).Value * 1000
                            cmdupdate2.ExecuteNonQuery()

                        ElseIf unit = "GRAMS" And Me.dgvPurchases.CurrentRow.Cells(5).Value = "GRAMS" Then
                            cmdupdate2 = New DB2Command("update ingredients set ingqty = ingqty +@sqty where ing_ID= '" & Me.dgvPurchases.CurrentRow.Cells(11).Value & "'", conn)
                            cmdupdate2.Parameters.Add("@sqty", DB2Type.Decimal).Value = Me.dgvPurchases.CurrentRow.Cells(4).Value
                            cmdupdate2.ExecuteNonQuery()
                        Else
                            cmdupdate2 = New DB2Command("update ingredients set ingqty = ingqty +@sqty where ing_ID= '" & Me.dgvPurchases.CurrentRow.Cells(11).Value & "'", conn)
                            cmdupdate2.Parameters.Add("@sqty", DB2Type.Decimal).Value = Me.dgvPurchases.CurrentRow.Cells(4).Value
                            cmdupdate2.ExecuteNonQuery()
                        End If
                    End If


                    MsgBox("Purchase Order Updated Succesfully")

                Catch ex As Exception
                    MsgBox("Tables with missing information is/are not recorded")

                End Try

            End If
        End If
        Call RefreshorderDataGrid()
    End Sub


    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked
        PurchaseOrder.Show()
        Me.Close()
    End Sub



    'CLOSE BUTTON'
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
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
    Private Sub MainBtn_Click(sender As Object, e As EventArgs) Handles MainBtn.Click
        If Home.role = "Cashier" Or Home.role = "CASHIER" Then
            MsgBox("Account Type Not Authorized.")
        ElseIf Home.role = "Cook" Or Home.role = "COOK" Then
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
    Private Sub IconMainBtn_Click(sender As Object, e As EventArgs) Handles IconMainBtn.Click
        If Home.role = "Cashier" Or Home.role = "CASHIER" Then
            MsgBox("Account Type Not Authorized.")
        ElseIf Home.role = "Cook" Or Home.role = "COOK" Then
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

    Private Sub dgvPurchases_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPurchases.CellValueChanged
        Dim subtotal As Double

        If Me.dgvPurchases.CurrentRow.Cells(4).Value = "" Then
            Me.dgvPurchases.CurrentRow.Cells(7).Value = "0.00"
        ElseIf Me.dgvPurchases.CurrentRow.Cells(6).Value = "" Then
            Me.dgvPurchases.CurrentRow.Cells(7).Value = "0.00"
        Else
            Dim qty As Decimal = Me.dgvPurchases.CurrentRow.Cells(4).Value
            Dim price As Decimal = Me.dgvPurchases.CurrentRow.Cells(6).Value
            subtotal = qty * price
            Me.dgvPurchases.CurrentRow.Cells(7).Value = subtotal
        End If

    End Sub
End Class