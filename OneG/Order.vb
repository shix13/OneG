Imports IBM.Data.DB2
Imports System.ComponentModel.Design
Imports System.Net.NetworkInformation
Imports System.Security.Policy
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Order
    Dim conn As Common.DbConnection
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


    Private Sub Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn = New DB2Connection("server=localhost;database=ONEG;" + "uid=db2admin;password=db2admin;")
            conn.Open()

            With Me.dgvMenu 'menu
                .ColumnCount = 3
                .Columns(0).Name = "VIAND CODE"
                .Columns(1).Name = "VIAND NAME"
                .Columns(2).Name = "PRICE"


            End With
            Dim chkBoxCol As New DataGridViewCheckBoxColumn
            dgvOrder.Columns.Add(chkBoxCol)
            dgvOrder.Columns(0).Width = 20

            With Me.dgvOrder 'viandOrder to be ordered
                .ColumnCount = 7
                .Columns(1).Name = "VIAND ORDER"
                .Columns(2).Name = "ORDER NUMBER"
                .Columns(3).Name = "VIAND "
                .Columns(4).Name = "ORDER QTY"
                .Columns(5).Name = "SUBTOTAL"
                .Columns(6).Name = "MENU CODE"
            End With
            dgvOrder.Columns(6).Visible = False
            Me.lblWelcomeBar.Text = "WELCOME, " + Login.name.ToString + "!"
            Call RefreshorderDataGrid1()
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Sub
    Private Sub RefreshorderDataGrid1()
        Try

            Dim str As String
            Dim cmd As DB2Command
            Dim rdr As DB2DataReader
            Dim param1 As DB2Parameter
            Dim rows As String()

            Me.txtTotal.Text = "0.00"

            If TableOrderBtn.Text = "ORDER LISTS" Then
                SaveBtn.Visible = False
                DeleteBtn.Visible = False
                REMOVEBTN.Visible = False
            Else
                SaveBtn.Visible = True
                DeleteBtn.Visible = True
                REMOVEBTN.Visible = True
            End If

            cmd = New DB2Command("select * from menu", conn)
            rdr = cmd.ExecuteReader

            Me.dgvMenu.Rows.Clear()
            While rdr.Read
                rows = New String() {rdr.GetString(0), rdr.GetString(1), rdr.GetString(2)}
                Me.dgvMenu.Rows.Add(rows)
            End While
            Me.dgvOrder.Rows.Clear()

            str = "call db2admin.GETLASTORDERNUM(?)"
            cmd = New DB2Command(str, conn)
            param1 = cmd.Parameters.Add("@1", DB2Type.Integer)
            param1.Direction = ParameterDirection.Output
            rdr = cmd.ExecuteReader

            Me.txtOrderNo.Text = param1.Value.ToString

            Dim dtadapt2 As DB2DataAdapter
            Dim ds2 As DataSet = New DataSet()

            dtadapt2 = New DB2DataAdapter("select * from TABLES WHERE AVAILABILITY='AVAILABLE'", conn)
            dtadapt2.Fill(ds2, "TABLES")
            cmbTableNo.DisplayMember = "TABLENO"
            cmbTableNo.ValueMember = "TABLENO"
            cmbTableNo.DataSource = ds2.Tables("TABLES")

            Me.cmbTableNo.Text = "SELECT TABLE"
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

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        Dim cmdInsert As DB2Command
        Dim rdrInsert As DB2DataReader
        Dim cmdInsert1 As DB2Command
        Dim rdrInsert1 As DB2DataReader
        Dim count As Integer = 0
        Dim i As Integer = 0
        Try

            If cmbTableNo.Text = "" Or cmbTableNo.Text = "SELECT TABLE" Then
                MsgBox("Table Number is empty.")
            ElseIf dgvOrder.Rows(i).Cells(1).ToString = "" Then
                MsgBox("Please Select a Menu item before saving.")
            Else

                Dim answer As DialogResult
                answer = MessageBox.Show("Purchase Order has Changes, Save?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If answer = vbYes Then


                    Try
                        While Me.dgvOrder.Rows(i).Cells(1).Value IsNot Nothing
                            i += 1
                        End While

                        While count < i

                            'check if order already exist in db
                            cmdInsert = New DB2Command("select orderno from order where orderno ='" & txtOrderNo.Text & "'", conn)
                            rdrInsert = cmdInsert.ExecuteReader
                            If rdrInsert.HasRows Then
                                masterKey.ShowDialog()
                                If masterKey.CONFIRM = True Then
                                    'order exist so we update 
                                    cmdInsert = New DB2Command("update order set ordertotal= @total where orderno='" & txtOrderNo.Text & "'", conn)
                                    cmdInsert.Parameters.Add("@total", DB2Type.Decimal).Value = txtTotal.Text
                                    cmdInsert.ExecuteNonQuery()

                                    'check if viandorder exist
                                    cmdInsert = New DB2Command("select vo_no,itemqty from viandorder where vo_no='" & dgvOrder.Rows(count).Cells(1).Value & "'", conn)
                                    rdrInsert = cmdInsert.ExecuteReader
                                    rdrInsert.Read()
                                    If rdrInsert.HasRows Then
                                        Dim oldqty As Integer = rdrInsert.GetString(1)
                                        'get the old itemqty
                                        'multiply to the ing_used

                                        cmdInsert = New DB2Command("select ing_ID, qtyused,qtyunit from ingredients_used where menu_no ='" & Me.dgvOrder.Rows(count).Cells(6).Value & "'", conn)
                                        rdrInsert = cmdInsert.ExecuteReader
                                        While rdrInsert.Read

                                            Dim qty As Decimal = rdrInsert.GetString(1) * oldqty
                                            Dim ing As String = rdrInsert.GetString(0)
                                            Dim unit As String = rdrInsert.GetString(2) 'unit in ing_used table 


                                            'get the unit of that ingredient (grams/kilograms)
                                            cmdInsert1 = New DB2Command("select ingunit from ingredients where ing_ID ='" & ing & "'", conn)
                                            rdrInsert1 = cmdInsert1.ExecuteReader
                                            rdrInsert1.Read()
                                            Dim ingunit As String = rdrInsert1.GetString(0) 'the unit in ingredients
                                            'compare units
                                            If unit = ingunit Then
                                                cmdInsert1 = New DB2Command("update ingredients set ingqty =ingqty+ '" & qty & "' where ing_ID ='" & ing & "'", conn)
                                                cmdInsert1.ExecuteNonQuery()
                                            ElseIf unit = "KILOGRAMS" And ingunit = "GRAMS" Then
                                                cmdInsert1 = New DB2Command("update ingredients set ingqty =ingqty+ @qty where ing_ID ='" & ing & "'", conn)
                                                cmdInsert1.Parameters.Add("@qty", DB2Type.Decimal).Value = qty * 1000
                                                cmdInsert1.ExecuteNonQuery()
                                            ElseIf unit = "GRAMS" And ingunit = "KILOGRAMS" Then
                                                cmdInsert1 = New DB2Command("update ingredients set ingqty =ingqty+ @qty where ing_ID ='" & ing & "'", conn)
                                                cmdInsert1.Parameters.Add("@qty", DB2Type.Decimal).Value = qty / 1000
                                                cmdInsert1.ExecuteNonQuery()
                                            End If
                                        End While
                                        'add to the ingredients


                                        cmdInsert = New DB2Command("update viandorder set itemqty= @qty ,subtotal =@sub where vo_no='" & Me.dgvOrder.Rows(count).Cells(1).Value & "'", conn)
                                        cmdInsert.Parameters.Add("@qty", DB2Type.Integer).Value = Me.dgvOrder.Rows(count).Cells(4).Value
                                        cmdInsert.Parameters.Add("@sub", DB2Type.Decimal).Value = Me.dgvOrder.Rows(count).Cells(5).Value
                                        cmdInsert.ExecuteNonQuery()

                                        'get the ing_used details of that menu item
                                        cmdInsert = New DB2Command("select ing_ID, qtyused,qtyunit from ingredients_used where menu_no ='" & Me.dgvOrder.Rows(count).Cells(6).Value & "'", conn)
                                        rdrInsert = cmdInsert.ExecuteReader
                                        While rdrInsert.Read


                                            Dim qty As Decimal = rdrInsert.GetString(1) * Me.dgvOrder.Rows(count).Cells(4).Value
                                            Dim ing As String = rdrInsert.GetString(0)
                                            Dim unit As String = rdrInsert.GetString(2) 'unit in ing_used table 


                                            'get the unit of that ingredient (grams/kilograms)
                                            cmdInsert1 = New DB2Command("select ingunit from ingredients where ing_ID ='" & ing & "'", conn)
                                            rdrInsert1 = cmdInsert1.ExecuteReader
                                            rdrInsert1.Read()
                                            Dim ingunit As String = rdrInsert1.GetString(0) 'the unit in ingredients
                                            'compare units
                                            If unit = ingunit Then
                                                cmdInsert1 = New DB2Command("update ingredients set ingqty =ingqty- '" & qty & "' where ing_ID ='" & ing & "'", conn)
                                                cmdInsert1.ExecuteNonQuery()
                                            ElseIf unit = "KILOGRAMS" And ingunit = "GRAMS" Then
                                                cmdInsert1 = New DB2Command("update ingredients set ingqty =ingqty- @qty where ing_ID ='" & ing & "'", conn)
                                                cmdInsert1.Parameters.Add("@qty", DB2Type.Decimal).Value = qty * 1000
                                                cmdInsert1.ExecuteNonQuery()
                                            ElseIf unit = "GRAMS" And ingunit = "KILOGRAMS" Then
                                                cmdInsert1 = New DB2Command("update ingredients set ingqty =ingqty- @qty where ing_ID ='" & ing & "'", conn)
                                                cmdInsert1.Parameters.Add("@qty", DB2Type.Decimal).Value = qty / 1000
                                                cmdInsert1.ExecuteNonQuery()

                                            End If
                                        End While



                                    Else

                                        cmdInsert = New DB2Command("insert into viandorder values(@VO,@sub,@qty,@OrdID,@menu)", conn)
                                        cmdInsert.Parameters.Add("@VO", DB2Type.Integer).Value = Me.dgvOrder.Rows(count).Cells(1).Value
                                        cmdInsert.Parameters.Add("@OrdID", DB2Type.Integer).Value = Me.dgvOrder.Rows(count).Cells(2).Value
                                        cmdInsert.Parameters.Add("@menu", DB2Type.Integer).Value = Me.dgvOrder.Rows(count).Cells(6).Value
                                        cmdInsert.Parameters.Add("@qty", DB2Type.Integer).Value = Me.dgvOrder.Rows(count).Cells(4).Value
                                        cmdInsert.Parameters.Add("@sub", DB2Type.Decimal).Value = Me.dgvOrder.Rows(count).Cells(5).Value
                                        cmdInsert.ExecuteNonQuery()


                                        cmdInsert = New DB2Command("select ing_ID, qtyused,qtyunit from ingredients_used where menu_no ='" & Me.dgvOrder.Rows(count).Cells(6).Value & "'", conn)
                                        rdrInsert = cmdInsert.ExecuteReader
                                        While rdrInsert.Read


                                            Dim qty As Decimal = rdrInsert.GetString(1) * Me.dgvOrder.Rows(count).Cells(4).Value
                                            Dim ing As String = rdrInsert.GetString(0)
                                            Dim unit As String = rdrInsert.GetString(2) 'unit in ing_used table 


                                            'get the unit of that ingredient (grams/kilograms)
                                            cmdInsert1 = New DB2Command("select ingunit from ingredients where ing_ID='" & ing & "'", conn)
                                            rdrInsert1 = cmdInsert1.ExecuteReader
                                            rdrInsert1.Read()
                                            Dim ingunit As String = rdrInsert1.GetString(0) 'the unit in ingredients
                                            'compare units
                                            If unit = ingunit Then
                                                cmdInsert1 = New DB2Command("update ingredients set ingqty =ingqty- '" & qty & "' where ing_ID ='" & ing & "'", conn)
                                                cmdInsert1.ExecuteNonQuery()
                                            ElseIf unit = "KILOGRAMS" And ingunit = "GRAMS" Then
                                                cmdInsert1 = New DB2Command("update ingredients set ingqty =ingqty- @qty where ing_ID ='" & ing & "'", conn)
                                                cmdInsert1.Parameters.Add("@qty", DB2Type.Decimal).Value = qty * 1000
                                                cmdInsert1.ExecuteNonQuery()
                                            ElseIf unit = "GRAMS" And ingunit = "KILOGRAMS" Then
                                                cmdInsert1 = New DB2Command("update ingredients set ingqty =ingqty- @qty where ing_ID ='" & ing & "'", conn)
                                                cmdInsert1.Parameters.Add("@qty", DB2Type.Decimal).Value = qty / 1000
                                                cmdInsert1.ExecuteNonQuery()

                                            End If
                                        End While
                                    End If
                                End If
                            Else
                                'order didnt exist
                                cmdInsert = New DB2Command("insert into order(ORDERNO,ORDERTOTAL,ORDERDATE,TABLENO,ACCID)  values (@Ord, @total,@date,@cust,@emp)", conn)
                                cmdInsert.Parameters.Add("@cust", DB2Type.Integer).Value = cmbTableNo.Text
                                cmdInsert.Parameters.Add("@Ord", DB2Type.Integer).Value = txtOrderNo.Text
                                cmdInsert.Parameters.Add("@emp", DB2Type.VarChar).Value = Login.ACCID.ToString
                                cmdInsert.Parameters.Add("@total", DB2Type.Decimal).Value = txtTotal.Text
                                cmdInsert.Parameters.Add("@date", DB2Type.Date).Value = dtpSideBar.Text
                                cmdInsert.ExecuteNonQuery()

                                cmdInsert = New DB2Command("insert into viandorder values(@VO,@sub,@qty,@OrdID,@menu)", conn)
                                cmdInsert.Parameters.Add("@VO", DB2Type.Integer).Value = Me.dgvOrder.Rows(count).Cells(1).Value
                                cmdInsert.Parameters.Add("@OrdID", DB2Type.Integer).Value = Me.dgvOrder.Rows(count).Cells(2).Value
                                cmdInsert.Parameters.Add("@menu", DB2Type.Integer).Value = Me.dgvOrder.Rows(count).Cells(6).Value
                                cmdInsert.Parameters.Add("@qty", DB2Type.Integer).Value = Me.dgvOrder.Rows(count).Cells(4).Value
                                cmdInsert.Parameters.Add("@sub", DB2Type.Decimal).Value = Me.dgvOrder.Rows(count).Cells(5).Value
                                cmdInsert.ExecuteNonQuery()

                                cmdInsert = New DB2Command("select ing_ID, qtyused,qtyunit from ingredients_used where menu_no ='" & Me.dgvOrder.Rows(count).Cells(6).Value & "'", conn)
                                rdrInsert = cmdInsert.ExecuteReader
                                While rdrInsert.Read


                                    Dim qty As Decimal = rdrInsert.GetString(1) * Me.dgvOrder.Rows(count).Cells(4).Value
                                    Dim ing As String = rdrInsert.GetString(0)
                                    Dim unit As String = rdrInsert.GetString(2) 'unit in ing_used table 


                                    'get the unit of that ingredient (grams/kilograms)
                                    cmdInsert1 = New DB2Command("select ingunit from ingredients where ing_ID ='" & ing & "'", conn)
                                    rdrInsert1 = cmdInsert1.ExecuteReader
                                    rdrInsert1.Read()
                                    Dim ingunit As String = rdrInsert1.GetString(0) 'the unit in ingredients
                                    'compare units
                                    If unit = ingunit Then
                                        cmdInsert1 = New DB2Command("update ingredients set ingqty =ingqty- '" & qty & "' where ing_ID ='" & ing & "'", conn)
                                        cmdInsert1.ExecuteNonQuery()
                                    ElseIf unit = "KILOGRAMS" And ingunit = "GRAMS" Then
                                        cmdInsert1 = New DB2Command("update ingredients set ingqty =ingqty- @qty where ing_ID ='" & ing & "'", conn)
                                        cmdInsert1.Parameters.Add("@qty", DB2Type.Decimal).Value = qty * 1000
                                        cmdInsert1.ExecuteNonQuery()
                                    ElseIf unit = "GRAMS" And ingunit = "KILOGRAMS" Then
                                        cmdInsert1 = New DB2Command("update ingredients set ingqty =ingqty- @qty where ing_ID ='" & ing & "'", conn)
                                        cmdInsert1.Parameters.Add("@qty", DB2Type.Decimal).Value = qty / 1000
                                        cmdInsert1.ExecuteNonQuery()
                                    End If

                                End While
                            End If
                            count += 1
                        End While
                        MsgBox("Order Saved!")
                        cmdInsert1 = New DB2Command("update tables set availability ='NOT AVAILABLE' where TABLENO ='" & cmbTableNo.Text & "'", conn)
                        cmdInsert1.ExecuteNonQuery()
                        Call RefreshorderDataGrid1()
                    Catch ex As Exception
                        MsgBox("Fill all details to better serve your customer")
                        MsgBox(ex.ToString)
                    End Try
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub dgvMenu_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMenu.CellContentClick

    End Sub

    Private Sub dgvMenu_MouseUp(sender As Object, e As MouseEventArgs) Handles dgvMenu.MouseUp

        Try
            If TableOrderBtn.Text = "TABLE ORDER" Then

            Else
                TableOrderBtn.Text = "TABLE ORDER"
                dgvOrder.Columns(0).Visible = True
                With Me.dgvOrder 'viandOrder to be ordered
                    .ColumnCount = 7
                    .Columns(1).Name = "VIAND ORDER"
                    .Columns(2).Name = "ORDER NUMBER"
                    .Columns(3).Name = "VIAND"
                    .Columns(4).Name = "ORDER QTY"
                    .Columns(5).Name = "SUBTOTAL"
                    .Columns(6).Name = "MENU CODE"

                End With
                RefreshorderDataGrid1()

            End If
            Dim dbLast As Integer = 0
            Dim total As Decimal = 0
            Dim count As Integer = 0
            Dim temp As Integer = 0
            Dim similar As Boolean = False
            Dim cmd As DB2Command
            Dim rdr As DB2DataReader

            cmd = New DB2Command("select vo_no from viandorder order by vo_no asc", conn)
            rdr = cmd.ExecuteReader
            If rdr.HasRows Then
                While rdr.Read
                    Integer.TryParse(rdr.GetString(0), temp)
                End While
            End If
            temp += 1   'new vo_no to insert
            Try


                Dim i As Integer = 0 'check how many rows in the dgv
                While Me.dgvOrder.Rows(i).Cells(1).Value IsNot Nothing
                    If Me.dgvOrder.Rows(i).Cells(6).Value = dgvMenu.CurrentRow.Cells(0).Value Then
                        similar = True
                    End If
                    i += 1
                End While

                If similar = True Then
                    MsgBox("Item already ordered (Option: Update Order Qty)")

                Else
                    dgvOrder.Rows.Add()

                    dgvOrder.Rows(i).Cells(5).Value = Me.dgvMenu.CurrentRow.Cells(2).Value
                    dgvOrder.Rows(i).Cells(2).Value = txtOrderNo.Text
                    dgvOrder.Rows(i).Cells(6).Value = Me.dgvMenu.CurrentRow.Cells(0).Value
                    dgvOrder.Rows(i).Cells(3).Value = Me.dgvMenu.CurrentRow.Cells(1).Value
                    dgvOrder.Rows(i).Cells(4).Value = "1"

                    'traverse to all rows
                    While count < i
                        total += Me.dgvOrder.Rows(count).Cells(5).Value
                        count += 1

                    End While
                    txtTotal.Text = total

                    count = 0

                    If i = 1 And temp = 1 Then
                        Me.dgvOrder.Rows(i).Cells(1).Value = 1
                    Else
                        Me.dgvOrder.Rows(i).Cells(1).Value = temp
                        If i > 0 Then
                            If Me.dgvOrder.Rows(i - 1).Cells(1).Value >= temp Then
                                Me.dgvOrder.Rows(i).Cells(1).Value = Me.dgvOrder.Rows(i - 1).Cells(1).Value + 1
                            End If
                        End If

                    End If
                End If


            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            dgvOrder.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        If TableOrderBtn.Text = "ORDER LISTS" Then
            SaveBtn.Visible = False
            DeleteBtn.Visible = False
            REMOVEBTN.Visible = False
        Else
            SaveBtn.Visible = True
            DeleteBtn.Visible = True
            REMOVEBTN.Visible = True
        End If

    End Sub



    Private Sub dgvOrder_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrder.CellValueChanged
        Dim cmdSearch As DB2Command
        Dim rdrSearch As DB2DataReader
        Dim price As Decimal = 0
        Dim i As Integer = 0
        Dim count As Integer = 0
        Dim total As Decimal = 0


        If dgvOrder.CurrentRow.Cells(6).Value IsNot Nothing Then
            cmdSearch = New DB2Command("select price from menu where menu_no ='" & dgvOrder.CurrentRow.Cells(6).Value & "'", conn)
            rdrSearch = cmdSearch.ExecuteReader
            While rdrSearch.Read
                price = rdrSearch.GetString(0)
            End While

            Dim subtotal As Decimal = Me.dgvOrder.CurrentRow.Cells(4).Value * price
            Me.dgvOrder.CurrentRow.Cells(5).Value = subtotal

            While Me.dgvOrder.Rows(i).Cells(1).Value IsNot Nothing
                i += 1
            End While

            While count < i
                total += Me.dgvOrder.Rows(count).Cells(5).Value
                count += 1

            End While

            txtTotal.Text = total
        End If
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        Dim StrDelete As String
        Dim CmdDelete As DB2Command
        Dim i As Integer = 0
        Dim count As Integer = 0
        Dim cmdInsert As DB2Command
        Dim rdrInsert As DB2DataReader
        Dim cmdInsert1 As DB2Command
        Dim rdrInsert1 As DB2DataReader
        Try
            While Me.dgvOrder.Rows(i).Cells(1).Value IsNot Nothing
                i += 1
            End While

            While count < i

                'check if order already exist in db
                cmdInsert = New DB2Command("select orderno from order where orderno ='" & txtOrderNo.Text & "'", conn)
                rdrInsert = cmdInsert.ExecuteReader
                If rdrInsert.HasRows Then

                    'check if viandorder exist
                    cmdInsert = New DB2Command("select vo_no,itemqty from viandorder where vo_no='" & dgvOrder.Rows(count).Cells(1).Value & "'", conn)
                    rdrInsert = cmdInsert.ExecuteReader
                    rdrInsert.Read()
                    If rdrInsert.HasRows Then
                        Dim oldqty As Decimal = rdrInsert.GetString(1)
                        'get the old itemqty
                        'multiply to the ing_used


                        cmdInsert = New DB2Command("select ing_id, qtyused,qtyunit from ingredients_used where menu_no ='" & Me.dgvOrder.Rows(count).Cells(6).Value & "'", conn)
                        rdrInsert = cmdInsert.ExecuteReader
                        While rdrInsert.Read


                            Dim qty As Decimal = rdrInsert.GetString(1) * oldqty
                            Dim ing As String = rdrInsert.GetString(0)
                            Dim unit As String = rdrInsert.GetString(2) 'unit in ing_used table 


                            'get the unit of that ingredient (grams/kilograms)
                            cmdInsert1 = New DB2Command("select ingunit from ingredients where ing_id ='" & ing & "'", conn)
                            rdrInsert1 = cmdInsert1.ExecuteReader
                            rdrInsert1.Read()
                            Dim ingunit As String = rdrInsert1.GetString(0) 'the unit in ingredients
                            'compare units
                            If unit = ingunit Then
                                cmdInsert1 = New DB2Command("update ingredients set ingqty =ingqty+ '" & qty & "' where ing_ID ='" & ing & "'", conn)
                                cmdInsert1.ExecuteNonQuery()
                            ElseIf unit = "KILOGRAMS" And ingunit = "GRAMS" Then
                                cmdInsert1 = New DB2Command("update ingredients set ingqty =ingqty+ @qty where ing_ID ='" & ing & "'", conn)
                                cmdInsert1.Parameters.Add("@qty", DB2Type.Decimal).Value = qty * 1000
                                cmdInsert1.ExecuteNonQuery()
                            ElseIf unit = "GRAMS" And ingunit = "KILOGRAMS" Then
                                cmdInsert1 = New DB2Command("update ingredients set ingqty =ingqty+ @qty where ing_ID ='" & ing & "'", conn)
                                cmdInsert1.Parameters.Add("@qty", DB2Type.Decimal).Value = qty / 1000
                                cmdInsert1.ExecuteNonQuery()

                            End If

                            StrDelete = "delete from viandorder where vo_no = '" & Me.dgvOrder.Rows(count).Cells(1).Value & "'"
                            CmdDelete = New DB2Command(StrDelete, conn)
                            CmdDelete.ExecuteNonQuery()

                        End While
                        'add to the ingredients

                    End If
                End If
                count += 1
            End While
            cmdInsert1 = New DB2Command("update tables set availability='AVAILABLE' WHERE tableno ='" & cmbTableNo.Text & "'", conn)
            cmdInsert1.ExecuteNonQuery()
            StrDelete = "delete from order where orderno = '" & Me.txtOrderNo.Text & "'"
            CmdDelete = New DB2Command(StrDelete, conn)
            CmdDelete.ExecuteNonQuery()
            MsgBox("The order was successfully deleted ...")

            Call RefreshorderDataGrid1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TableOrderBtn_Click(sender As Object, e As EventArgs) Handles TableOrderBtn.Click
        Dim str As String
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        Dim rows As String()


        Try


            If TableOrderBtn.Text = "TABLE ORDER" Then
                dgvOrder.Rows.Clear()
                TableOrderBtn.Text = "ORDER LISTS"
                dgvOrder.Columns(0).Visible = False
                With Me.dgvOrder
                    .ColumnCount = 6
                    .Columns(1).Name = "ORDER NUMBER"
                    .Columns(2).Name = "TOTAL"
                    .Columns(3).Name = "TRANSACTION DATE"
                    .Columns(4).Name = "TABLE"
                    .Columns(5).Name = "PROCESSED BY"
                End With


                str = "select * from ORDER where payment = 'NOT PAID'"
                cmd = New DB2Command(str, conn)
                rdr = cmd.ExecuteReader

                While rdr.Read
                    rows = New String() {"", rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4)}
                    Me.dgvOrder.Rows.Add(rows)
                End While

            Else
                TableOrderBtn.Text = "TABLE ORDER"
                dgvOrder.Columns(0).Visible = True
                With Me.dgvOrder 'viandOrder to be ordered
                    .ColumnCount = 6
                    .Columns(1).Name = "VIAND ORDER"
                    .Columns(2).Name = "ORDER NUMBER"
                    .Columns(3).Name = "VIAND CODE"
                    .Columns(4).Name = "ORDER QTY"
                    .Columns(5).Name = "SUBTOTAL"

                End With
                RefreshorderDataGrid1()

            End If
            If TableOrderBtn.Text = "ORDER LISTS" Then
                SaveBtn.Visible = False
                DeleteBtn.Visible = False
                REMOVEBTN.Visible = False
            Else
                SaveBtn.Visible = True
                DeleteBtn.Visible = True
                REMOVEBTN.Visible = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub dgvOrder_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrder.CellContentClick

    End Sub

    Private Sub dgvOrder_MouseUp(sender As Object, e As MouseEventArgs) Handles dgvOrder.MouseUp
        Dim str As String
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        Dim rows As String()
        Dim i As Integer = 0
        Try


            If TableOrderBtn.Text = "TABLE ORDER" Then


            Else
                Try
                    txtOrderNo.Text = dgvOrder.CurrentRow.Cells(1).Value
                    txtTotal.Text = dgvOrder.CurrentRow.Cells(2).Value
                    cmbTableNo.Text = dgvOrder.CurrentRow.Cells(4).Value
                    TableOrderBtn.Text = "TABLE ORDER"


                    dgvOrder.Columns(0).Visible = True
                    With Me.dgvOrder 'viandOrder to be ordered
                        .ColumnCount = 7
                        .Columns(0).Name = ""
                        .Columns(1).Name = "VIAND ORDER"
                        .Columns(2).Name = "ORDER NUMBER"
                        .Columns(3).Name = "VIAND"
                        .Columns(4).Name = "ORDER QTY"
                        .Columns(5).Name = "SUBTOTAL"
                        .Columns(6).Name = "MENU CODE"
                    End With
                    cmd = New DB2Command("select * from table( db2admin.ORDER_LEFTJOIN_MENU()) as udf", conn)
                    rdr = cmd.ExecuteReader
                    Me.dgvOrder.Rows.Clear()
                    While rdr.Read
                        If rdr.GetString(3).StartsWith(txtOrderNo.Text) Then
                            dgvOrder.Rows.Add()
                            Me.dgvOrder.Rows(i).Cells(0).Value = False
                            Me.dgvOrder.Rows(i).Cells(1).Value = rdr.GetString(0)
                            Me.dgvOrder.Rows(i).Cells(2).Value = rdr.GetString(3)
                            Me.dgvOrder.Rows(i).Cells(3).Value = rdr.GetString(6)
                            Me.dgvOrder.Rows(i).Cells(4).Value = rdr.GetString(2)
                            Me.dgvOrder.Rows(i).Cells(5).Value = rdr.GetString(1)
                            Me.dgvOrder.Rows(i).Cells(6).Value = rdr.GetString(4)
                            i += 1
                        End If
                    End While


                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
            If TableOrderBtn.Text = "ORDER LISTS" Then
                SaveBtn.Visible = False
                DeleteBtn.Visible = False
                REMOVEBTN.Visible = False
            Else
                SaveBtn.Visible = True
                DeleteBtn.Visible = True
                REMOVEBTN.Visible = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub REMOVEBTN_Click(sender As Object, e As EventArgs) Handles REMOVEBTN.Click
        Dim count As Integer = 0
        Dim k As Integer = 0
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        Dim total As Decimal
        Dim cmdInsert As DB2Command
        Dim rdrInsert As DB2DataReader
        Dim cmdInsert1 As DB2Command
        Dim rdrInsert1 As DB2DataReader
        Dim none As Boolean = True
        Dim po As Integer
        Dim postr As String
        Dim j As Integer = 0
        Try

            k = dgvOrder.Rows.Count - 1

            If k <= 1 Then
                MsgBox("You can't have less than 1 Viand order (Suggestion: Cancel the Order)")
            Else


                While count < k

                    If dgvOrder.Rows(count).Cells(0).Value = True Then

                        k -= 1
                        none = False
                    Else
                        count += 1
                    End If
                End While


                cmd = New DB2Command("select vo_no from viandorder order by vo_no asc", conn)
                rdr = cmd.ExecuteReader
                If rdr.HasRows Then
                    While rdr.Read
                        postr = rdr.GetString(0)
                        Integer.TryParse(postr, po)

                    End While
                Else
                    po = 10000 'as start
                End If

                'increment last po_no 
                po += 1

                k = 0
                While Me.dgvOrder.Rows(k).Cells(1).Value IsNot Nothing
                    k += 1
                End While

                While j < k
                    If dgvOrder.Rows(j).Cells(0).Value = True Then


                        'check if order already exist in db
                        cmdInsert = New DB2Command("select orderNO from order where orderNO ='" & txtOrderNo.Text & "'", conn)
                        rdrInsert = cmdInsert.ExecuteReader
                        If rdrInsert.HasRows Then

                            'check if viandorder exist
                            cmdInsert = New DB2Command("select vo_no,itemqty from viandorder where vo_no='" & dgvOrder.Rows(j).Cells(1).Value & "'", conn)
                            rdrInsert = cmdInsert.ExecuteReader
                            rdrInsert.Read()
                            If rdrInsert.HasRows Then
                                Dim oldqty As Decimal = rdrInsert.GetString(1)
                                'get the old itemqty
                                'multiply to the ing_used

                                cmdInsert = New DB2Command("select ing_ID, qtyused,qtyunit from ingredients_used where menu_no ='" & Me.dgvOrder.Rows(j).Cells(6).Value & "'", conn)
                                rdrInsert = cmdInsert.ExecuteReader
                                While rdrInsert.Read

                                    Dim qty As Decimal = rdrInsert.GetString(1) * oldqty
                                    Dim ing As String = rdrInsert.GetString(0)
                                    Dim unit As String = rdrInsert.GetString(2) 'unit in ing_used table 


                                    'get the unit of that ingredient (grams/kilograms)
                                    cmdInsert1 = New DB2Command("select ingunit from ingredients where ing_ID ='" & ing & "'", conn)
                                    rdrInsert1 = cmdInsert1.ExecuteReader
                                    rdrInsert1.Read()

                                    Dim ingunit As String = rdrInsert1.GetString(0) 'the unit in ingredients
                                    'compare units
                                    If unit = ingunit Then
                                        cmdInsert1 = New DB2Command("update ingredients set ingqty =ingqty+ '" & qty & "' where ing_id ='" & ing & "'", conn)
                                        cmdInsert1.ExecuteNonQuery()
                                    ElseIf unit = "KILOGRAMS" And ingunit = "GRAMS" Then
                                        cmdInsert1 = New DB2Command("update ingredients set ingqty =ingqty+ @qty where ing_id ='" & ing & "'", conn)
                                        cmdInsert1.Parameters.Add("@qty", DB2Type.Decimal).Value = qty * 1000
                                        cmdInsert1.ExecuteNonQuery()
                                    ElseIf unit = "GRAMS" And ingunit = "KILOGRAMS" Then
                                        cmdInsert1 = New DB2Command("update ingredients set ingqty =ingqty+ @qty where ing_id ='" & ing & "'", conn)
                                        cmdInsert1.Parameters.Add("@qty", DB2Type.Decimal).Value = qty / 1000
                                        cmdInsert1.ExecuteNonQuery()

                                    End If
                                End While
                                'add to the ingredients

                            End If
                        End If



                        cmd = New DB2Command("select * from viandorder where vo_no ='" & Me.dgvOrder.Rows(j).Cells(1).Value & "'", conn)
                        rdr = cmd.ExecuteReader
                        If rdr.HasRows Then
                            cmd = New DB2Command("delete from viandorder where vo_no='" & dgvOrder.Rows(j).Cells(1).Value & "'", conn)
                            cmd.ExecuteNonQuery()
                        End If
                        dgvOrder.Rows(j).Cells(0).Value = False

                        dgvOrder.Rows.RemoveAt(j)
                        k -= 1
                    Else
                        j += 1
                    End If
                End While

                count = 0
                While count <= k
                    total += Me.dgvOrder.Rows(count).Cells(5).Value
                    count += 1
                End While

                txtTotal.Text = total
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub searchMenu_TextChanged(sender As Object, e As EventArgs) Handles searchMenu.TextChanged
        Dim strsearchkey As String
        Dim cmdsearch As DB2Command
        Dim rdrsearch As DB2DataReader
        Dim row As String()

        Try
            strsearchkey = searchMenu.Text + "%"
            cmdsearch = New DB2Command("select * from menu where menuitemname like '" & strsearchkey & "'", conn)
            rdrsearch = cmdsearch.ExecuteReader
            Me.dgvMenu.Rows.Clear()
            While rdrsearch.Read
                row = New String() {rdrsearch.GetString(0), rdrsearch.GetString(1), rdrsearch.GetString(2)}
                Me.dgvMenu.Rows.Add(row)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class