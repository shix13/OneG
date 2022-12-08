Imports System.ComponentModel
Imports System.Data.Common
Imports System.DirectoryServices.ActiveDirectory
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports IBM.Data.DB2

Public Class PurchaseOrder
    Private conn As DB2Connection
    Dim po As Integer
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


    Private Sub PurchaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New DB2Connection("server=localhost;database=oneg;" + "uid=db2admin;password=db2admin;")
        conn.Open()

        Try
            Dim chkBoxCol As New DataGridViewCheckBoxColumn
            dgvPO.Columns.Add(chkBoxCol)
            dgvPO.Columns(0).Width = 20

            With Me.dgvPO 'PO to be ordered
                .ColumnCount = 8
                .Columns(1).Name = "PURCHASE LINE ITEM"
                .Columns(2).Name = "INGREDIENT"
                .Columns(3).Name = "QTY"
                .Columns(4).Name = "UNIT"
                .Columns(5).Name = "PRICE"
                .Columns(6).Name = "SUBTOTAL"
                .Columns(7).Name = "ING_ID"
            End With

            ' dgvPO.Columns(7).Visible = False


            With Me.dgvSelect
                .ColumnCount = 4
                .Columns(0).Name = "ID"
                .Columns(1).Name = "INGREDIENT"
                .Columns(2).Name = "IN STOCK"
                .Columns(3).Name = "UNIT"
            End With
            'Me.lblWelcomeBar.Text = "WELCOME, " + Home.nameU.ToString + "!"
            Call RefreshorderDataGrid()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RefreshorderDataGrid()
        Try

            Dim cmd As DB2Command
            Dim rdr As DB2DataReader
            Dim rows As String()
            ingbtn.PerformClick()
            cmd = New DB2Command("select * from table(db2admin.ingredientlist()) as udf", conn)
            rdr = cmd.ExecuteReader

            Me.dgvSelect.Rows.Clear()
            While rdr.Read
                rows = New String() {rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3)}
                Me.dgvSelect.Rows.Add(rows)
            End While

            dgvPO.Rows.Clear()
            Dim param1 As DB2Parameter
            cmd = New DB2Command("call getlast_ponum(?)", conn)
            param1 = cmd.Parameters.Add("@n1", DB2Type.Integer)
            param1.Direction = ParameterDirection.Output
            rdr = cmd.ExecuteReader

            txtPoNum.Text = param1.Value.ToString
            txtsearch.Clear()
            txtSup.Clear()
            txtTotal.Clear()
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


    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub


    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged

        Dim strsearchkey As String
        Dim cmdsearch As DB2Command
        Dim rdrsearch As DB2DataReader
        Dim row As String()

        If SEARCHPO.Text = "Search Ingredients" Then
            Try
                strsearchkey = Me.txtsearch.Text + "%"
                cmdsearch = New DB2Command("select * from table(db2admin.ingredientlist()) as udf where ingname like @n1", conn)
                cmdsearch.Parameters.Add("@n1", DB2Type.VarChar).Value = strsearchkey
                rdrsearch = cmdsearch.ExecuteReader
                Me.dgvSelect.Rows.Clear()
                While rdrsearch.Read
                    row = New String() {rdrsearch.GetString(0), rdrsearch.GetString(1), rdrsearch.GetString(2), rdrsearch.GetString(3)}

                    Me.dgvSelect.Rows.Add(row)
                End While
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            Try
                strsearchkey = Me.txtsearch.Text + "%"
                cmdsearch = New DB2Command("select * from table(db2admin.supplierlist()) as udf where SUPNAME like @n1", conn)
                cmdsearch.Parameters.Add("@n1", DB2Type.VarChar).Value = strsearchkey
                rdrsearch = cmdsearch.ExecuteReader
                Me.dgvSelect.Rows.Clear()
                While rdrsearch.Read
                    row = New String() {rdrsearch.GetString(0), rdrsearch.GetString(1), rdrsearch.GetString(2)}

                    Me.dgvSelect.Rows.Add(row)
                End While
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ingbtn.Click
        SEARCHPO.Text = "Search Ingredients"
        With Me.dgvSelect
            .ColumnCount = 4
            .Columns(0).Name = "ID"
            .Columns(1).Name = "INGREDIENT"
            .Columns(2).Name = "IN STOCK"
            .Columns(3).Name = "UNIT"
        End With
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        ingbtn.BackColor = Color.Gray
        supbtn.BackColor = Color.FromArgb(106, 112, 124)
        Dim rows As String()

        cmd = New DB2Command("select * from table(db2admin.ingredientlist()) as udf", conn)
        rdr = cmd.ExecuteReader

        Me.dgvSelect.Rows.Clear()
        While rdr.Read
            rows = New String() {rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3)}
            Me.dgvSelect.Rows.Add(rows)
        End While

    End Sub

    Private Sub supbtn_Click(sender As Object, e As EventArgs) Handles supbtn.Click
        SEARCHPO.Text = "Search Supplier"
        With Me.dgvSelect
            .ColumnCount = 3
            .Columns(0).Name = "ID"
            .Columns(1).Name = "SUPPLIER NAME"
            .Columns(2).Name = "CONTANCT NO."
        End With
        supbtn.BackColor = Color.Gray
        ingbtn.BackColor = Color.FromArgb(106, 112, 124)
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader

        Dim rows As String()

        cmd = New DB2Command("select * from table(db2admin.supplierlist()) as udf", conn)
        rdr = cmd.ExecuteReader

        Me.dgvSelect.Rows.Clear()
        While rdr.Read
            rows = New String() {rdr.GetString(0), rdr.GetString(1), rdr.GetString(2)}
            Me.dgvSelect.Rows.Add(rows)
        End While

    End Sub

    Private Sub dgvSelect_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSelect.CellContentClick

    End Sub

    Private Sub dgvSelect_MouseUp(sender As Object, e As MouseEventArgs) Handles dgvSelect.MouseUp

        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        Dim i As Integer = 0
        Dim count As Integer = 0
        Dim similar As Boolean = False
        Dim po As Integer = 0

        If SwitchBtn.Text = "CREATE ORDER" Then

            SwitchBtn.Text = "ORDER LISTS"
            dgvPO.Columns(0).Visible = True
            dgvPO.Rows.Clear()
            With Me.dgvPO 'PO to be ordered
                .ColumnCount = 8
                .Columns(1).Name = "PURCHASE LINE ITEM"
                .Columns(2).Name = "INGREDIENT"
                .Columns(3).Name = "QTY"
                .Columns(4).Name = "UNIT"
                .Columns(5).Name = "PRICE"
                .Columns(6).Name = "SUBTOTAL"
                .Columns(7).Name = "ING_ID"
            End With
            Call RefreshorderDataGrid()
        End If

        If SEARCHPO.Text = "Search Ingredients" Then
            Try

                While dgvPO.Rows(i).Cells(1).Value IsNot Nothing
                    If dgvPO.Rows(i).Cells(2).Value = dgvSelect.CurrentRow.Cells(1).Value Then
                        similar = True
                    End If
                    i += 1
                End While


                'get the last po_no
                Me.dgvPO.Rows.Add()
                Dim param1 As DB2Parameter
                cmd = New DB2Command("call getlastnum_poLineitem(?)", conn)
                param1 = cmd.Parameters.Add("@n1", DB2Type.Integer)
                param1.Direction = ParameterDirection.Output
                rdr = cmd.ExecuteReader

                po = param1.Value.ToString


                'condition where if above cells are not empty then add 1 to current po
                While count < i
                    'if has similar purchase order existing in database then move on
                    cmd = New DB2Command("select po_list from TABLE(db2admin.lineitem_list()) as udf where po_list=@n1", conn)
                    cmd.Parameters.Add("@n1", DB2Type.Integer).Value = Me.dgvPO.Rows(count).Cells(1).Value
                    rdr = cmd.ExecuteReader
                    If rdr.HasRows Then
                        count += 1
                    Else
                        'current row is equal to po +1
                        po += 1
                        count += 1
                    End If

                End While
                ' Dim one As Decimal = 1
                Me.dgvPO.Rows(i).Cells(1).Value = po
                Me.dgvPO.Rows(i).Cells(7).Value = Me.dgvSelect.CurrentRow.Cells(0).Value
                Me.dgvPO.Rows(i).Cells(2).Value = Me.dgvSelect.CurrentRow.Cells(1).Value
                Me.dgvPO.Rows(i).Cells(4).Value = Me.dgvSelect.CurrentRow.Cells(3).Value
                Me.dgvPO.Rows(i).Cells(5).Value = "0.00"
                Me.dgvPO.Rows(i).Cells(3).Value = 1
                Me.dgvPO.Rows(i).Cells(6).Value = "0.00"

                cmd = New DB2Command("select po_list from TABLE(db2admin.lineitem_list()) as udf where po_list=@n1", conn)
                cmd.Parameters.Add("@n1", DB2Type.Integer).Value = Me.dgvPO.Rows(count).Cells(1).Value
                rdr = cmd.ExecuteReader
                If rdr.HasRows Then
                Else
                    If i > 0 Then
                        If Me.dgvPO.Rows(i - 1).Cells(1).Value = po Then
                            Me.dgvPO.Rows(i).Cells(1).Value = po + 1
                        End If
                    End If
                End If
                If similar = True Then
                    Dim answer As DialogResult
                    answer = MessageBox.Show("Ingredient Order Already Exist, Continue?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If answer = vbYes Then

                    Else
                        dgvPO.Rows.RemoveAt(i)
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
                dgvPO.ClearSelection()
            End Try
        Else
            txtSup.Text = dgvSelect.CurrentRow.Cells(0).Value.ToString
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim count As Integer = 0
        Dim k As Integer = 0
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        Dim j As Integer = 0
        Dim none As Boolean = True
        Dim i As Integer = 0
        Dim counter As Integer = 0
        Dim total As Decimal = 0

        If SwitchBtn.Text = "ORDER LISTS" Then
            Try
                k = dgvPO.Rows.Count - 1

                Dim param1 As DB2Parameter
                Dim param2 As DB2Parameter
                While count < k
                    If dgvPO.Rows(count).Cells(0).Value = True Then
                        cmd = New DB2Command("select * from table(DB2ADMIN.LINEITEM_LIST()) as udf where po_list=@n1", conn)
                        cmd.Parameters.Add("@n1", DB2Type.Integer).Value = dgvPO.Rows(count).Cells(1).Value
                        rdr = cmd.ExecuteReader
                        If rdr.HasRows Then
                            cmd = New DB2Command("call deletelineitem(?)", conn)
                            param2 = cmd.Parameters.Add("@n2", DB2Type.Integer)
                            param2.Direction = ParameterDirection.Input
                            cmd.Parameters("@n2").Value = dgvPO.Rows(count).Cells(1).Value
                            cmd.ExecuteNonQuery()
                        End If
                        dgvPO.Rows(count).Cells(0).Value = False
                            dgvPO.Rows.RemoveAt(count)
                            k -= 1
                            none = False
                        Else
                            count += 1
                    End If
                End While

                If none = True And k > 0 Then
                    cmd = New DB2Command("select * from table(db2admin.lineitem_list()) as udf where po_list=@n1", conn)
                    cmd.Parameters.Add("@n1", DB2Type.Integer).Value = dgvPO.Rows(k - 1).Cells(1).Value
                    rdr = cmd.ExecuteReader
                    If rdr.HasRows Then
                        cmd = New DB2Command("call deletelineitem(?)", conn)
                        param2 = cmd.Parameters.Add("@n2", DB2Type.Integer)
                        param2.Direction = ParameterDirection.Input
                        cmd.Parameters("@n2").Value = dgvPO.Rows(k - 1).Cells(1).Value
                        cmd.ExecuteNonQuery()
                    End If
                    dgvPO.Rows.RemoveAt(k - 1)
                End If

                While Me.dgvPO.Rows(i).Cells(1).Value IsNot Nothing
                    i += 1
                End While

                While counter < i
                    total += Me.dgvPO.Rows(counter).Cells(6).Value
                    counter += 1
                End While
                txtTotal.Text = total

                cmd = New DB2Command("call update_purchaseTotal(?)", conn)
                param1 = cmd.Parameters.Add("@1", DB2Type.Decimal)
                param1.Direction = ParameterDirection.Input
                cmd.Parameters("@1").Value = txtTotal.Text
                cmd.ExecuteNonQuery()


                cmd = New DB2Command("call getlastnum_poLineitem(?)", conn)
                param1 = cmd.Parameters.Add("@n1", DB2Type.Integer)
                param1.Direction = ParameterDirection.Output
                rdr = cmd.ExecuteReader

                'increment last po_no 
                po = param1.Value.ToString
                k = 0
                While Me.dgvPO.Rows(k).Cells(1).Value IsNot Nothing
                    k += 1
                End While


                While j < k
                    'if has similar purchase order existing inside db then move on and dont change po_no 
                    cmd = New DB2Command("select po_list from TABLE(db2admin.lineitem_list()) as udf where po_list=@n1", conn)
                    cmd.Parameters.Add("@n1", DB2Type.Integer).Value = Me.dgvPO.Rows(j).Cells(1).Value
                    rdr = cmd.ExecuteReader
                    If rdr.HasRows Then
                        j += 1
                    Else
                        ' first row is assigned the value equal to po 
                        If j = 0 Then
                            dgvPO.Rows(j).Cells(1).Value = po
                            po += 1
                            j += 1

                            'check if row-1 has value similar to current po if none then assign that value to current row
                        ElseIf Me.dgvPO.Rows(j - 1).Cells(1).Value <> po Then
                            dgvPO.Rows(j).Cells(1).Value = po
                            j += 1
                        Else
                            'current row is equal to po +1
                            po += 1
                            dgvPO.Rows(j).Cells(1).Value = po
                            j += 1
                        End If
                    End If
                End While

            Catch ex As Exception
                MsgBox(ex.ToString)


            End Try
        Else
            MsgBox("Click 'All Purchases' tab to cancel a purchase order.")
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        Dim cmdInsert As DB2Command
        Dim i As Integer = 0 'as count of row that has po_no assigned
        Dim count As Integer = 0
        Dim save As Boolean = False
        Dim rdrInsert As DB2DataReader

        If Home.role.Contains("CASHIER") Then
                MsgBox("Error: User Acount Not Authorized")

            ElseIf txtSup.Text = "" Then
                MsgBox("Please Select the Supplier.")
            ElseIf txtTotal.Text = 0 Then
                MsgBox("Please input the price for each item.")


            Else

                Try
                    While Me.dgvPO.Rows(i).Cells(1).Value IsNot Nothing
                        i += 1
                        save = True
                    End While

                    If save = True Then
                        Dim answer As DialogResult
                        answer = MessageBox.Show("Purchase Order will be saved, Continue?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If answer = vbYes Then

                            While count < i
                            Dim param1 As DB2Parameter
                            Dim param2 As DB2Parameter
                            Dim param3 As DB2Parameter
                            Dim param4 As DB2Parameter
                            Dim param5 As DB2Parameter
                            Dim param6 As DB2Parameter
                            Dim param7 As DB2Parameter
                            cmdInsert = New DB2Command("select po_no from table(db2admin.PURCHASELIST()) as udf where po_no =@n1", conn)
                            cmdInsert.Parameters.Add("@n1", DB2Type.VarChar).Value = txtPoNum.Text
                            rdrInsert = cmdInsert.ExecuteReader
                            If rdrInsert.HasRows Then

                                cmdInsert = New DB2Command("call update_purchases(?,?,?,?)", conn)

                                param1 = cmdInsert.Parameters.Add("@1", DB2Type.VarChar)
                                param1.Direction = ParameterDirection.Input
                                cmdInsert.Parameters("@1").Value = Home.ACCID.ToString
                                param2 = cmdInsert.Parameters.Add("@2", DB2Type.VarChar)
                                param2.Direction = ParameterDirection.Input
                                cmdInsert.Parameters("@2").Value = txtTotal.Text
                                param3 = cmdInsert.Parameters.Add("@3", DB2Type.VarChar)
                                param3.Direction = ParameterDirection.Input
                                cmdInsert.Parameters("@3").Value = dtpSideBar.Value
                                param4 = cmdInsert.Parameters.Add("@4", DB2Type.VarChar)
                                param4.Direction = ParameterDirection.Input
                                cmdInsert.Parameters("@4").Value = txtPoNum.Text

                                cmdInsert.ExecuteNonQuery()

                                cmdInsert = New DB2Command("select po_list from table(db2admin.lineitem_list()) as udf where po_list =@n1", conn)
                                cmdInsert.Parameters.Add("@n1", DB2Type.VarChar).Value = Me.dgvPO.Rows(count).Cells(1).Value
                                rdrInsert = cmdInsert.ExecuteReader
                                If rdrInsert.HasRows Then
                                    cmdInsert = New DB2Command("call update_po_lineitem(?,?,?,?,?)", conn)

                                    param1 = cmdInsert.Parameters.Add("@1", DB2Type.VarChar)
                                    param1.Direction = ParameterDirection.Input
                                    cmdInsert.Parameters("@1").Value = Me.dgvPO.Rows(count).Cells(3).Value
                                    param2 = cmdInsert.Parameters.Add("@2", DB2Type.VarChar)
                                    param2.Direction = ParameterDirection.Input
                                    cmdInsert.Parameters("@2").Value = Me.dgvPO.Rows(count).Cells(4).Value
                                    param3 = cmdInsert.Parameters.Add("@3", DB2Type.VarChar)
                                    param3.Direction = ParameterDirection.Input
                                    cmdInsert.Parameters("@3").Value = Me.dgvPO.Rows(count).Cells(5).Value
                                    param4 = cmdInsert.Parameters.Add("@4", DB2Type.VarChar)
                                    param4.Direction = ParameterDirection.Input
                                    cmdInsert.Parameters("@4").Value = Me.dgvPO.Rows(count).Cells(6).Value
                                    param5 = cmdInsert.Parameters.Add("@5", DB2Type.VarChar)
                                    param5.Direction = ParameterDirection.Input
                                    cmdInsert.Parameters("@5").Value = Me.dgvPO.Rows(count).Cells(1).Value

                                    cmdInsert.ExecuteNonQuery()
                                Else
                                    cmdInsert = New DB2Command("call insert_polineitem(?,?,?,?,?,?,?)", conn)

                                    param1 = cmdInsert.Parameters.Add("@n1", DB2Type.Integer)
                                    param1.Direction = ParameterDirection.Input
                                    cmdInsert.Parameters("@n1").Value = Me.dgvPO.Rows(count).Cells(1).Value

                                    param2 = cmdInsert.Parameters.Add("@n2", DB2Type.VarChar)
                                    param2.Direction = ParameterDirection.Input
                                    cmdInsert.Parameters("@n2").Value = txtPoNum.Text

                                    param3 = cmdInsert.Parameters.Add("@n3", DB2Type.VarChar)
                                    param3.Direction = ParameterDirection.Input
                                    cmdInsert.Parameters("@n3").Value = Me.dgvPO.Rows(count).Cells(7).Value

                                    param4 = cmdInsert.Parameters.Add("@n4", DB2Type.Decimal)
                                    param4.Direction = ParameterDirection.Input
                                    cmdInsert.Parameters("@n4").Value = Me.dgvPO.Rows(count).Cells(3).Value

                                    param5 = cmdInsert.Parameters.Add("@n5", DB2Type.VarChar)
                                    param5.Direction = ParameterDirection.Input
                                    cmdInsert.Parameters("@n5").Value = Me.dgvPO.Rows(count).Cells(4).Value

                                    param6 = cmdInsert.Parameters.Add("@n6", DB2Type.Double)
                                    param6.Direction = ParameterDirection.Input
                                    cmdInsert.Parameters("@n6").Value = Me.dgvPO.Rows(count).Cells(5).Value

                                    param7 = cmdInsert.Parameters.Add("@n7", DB2Type.Decimal)
                                    param7.Direction = ParameterDirection.Input
                                    cmdInsert.Parameters("@n7").Value = Me.dgvPO.Rows(count).Cells(6).Value

                                    cmdInsert.ExecuteNonQuery()
                                End If

                            Else

                                cmdInsert = New DB2Command("call insert_purchases(?,?,?,?,?,?)", conn)

                                param1 = cmdInsert.Parameters.Add("@n1", DB2Type.VarChar)
                                param1.Direction = ParameterDirection.Input
                                cmdInsert.Parameters("@n1").Value = txtPoNum.Text

                                param2 = cmdInsert.Parameters.Add("@n2", DB2Type.VarChar)
                                param2.Direction = ParameterDirection.Input
                                cmdInsert.Parameters("@n2").Value = Home.ACCID

                                param3 = cmdInsert.Parameters.Add("@n3", DB2Type.VarChar)
                                param3.Direction = ParameterDirection.Input
                                cmdInsert.Parameters("@n3").Value = txtSup.Text

                                param4 = cmdInsert.Parameters.Add("@n4", DB2Type.Decimal)
                                param4.Direction = ParameterDirection.Input
                                cmdInsert.Parameters("@n4").Value = txtTotal.Text

                                param5 = cmdInsert.Parameters.Add("@n5", DB2Type.VarChar)
                                param5.Direction = ParameterDirection.Input
                                cmdInsert.Parameters("@n5").Value = "NOT DELIVERED"

                                param6 = cmdInsert.Parameters.Add("@n6", DB2Type.Date)
                                param6.Direction = ParameterDirection.Input
                                cmdInsert.Parameters("@n6").Value = dtpSideBar.Value

                                cmdInsert.ExecuteNonQuery()

                                cmdInsert = New DB2Command("call insert_polineitem(?,?,?,?,?,?,?)", conn)

                                param1 = cmdInsert.Parameters.Add("@n1", DB2Type.Integer)
                                param1.Direction = ParameterDirection.Input
                                cmdInsert.Parameters("@n1").Value = Me.dgvPO.Rows(count).Cells(1).Value

                                param2 = cmdInsert.Parameters.Add("@n2", DB2Type.VarChar)
                                param2.Direction = ParameterDirection.Input
                                cmdInsert.Parameters("@n2").Value = txtPoNum.Text

                                param3 = cmdInsert.Parameters.Add("@n3", DB2Type.VarChar)
                                param3.Direction = ParameterDirection.Input
                                cmdInsert.Parameters("@n3").Value = Me.dgvPO.Rows(count).Cells(7).Value

                                param4 = cmdInsert.Parameters.Add("@n4", DB2Type.Decimal)
                                param4.Direction = ParameterDirection.Input
                                cmdInsert.Parameters("@n4").Value = Me.dgvPO.Rows(count).Cells(3).Value

                                param5 = cmdInsert.Parameters.Add("@n5", DB2Type.VarChar)
                                param5.Direction = ParameterDirection.Input
                                cmdInsert.Parameters("@n5").Value = Me.dgvPO.Rows(count).Cells(4).Value

                                param6 = cmdInsert.Parameters.Add("@n6", DB2Type.Double)
                                param6.Direction = ParameterDirection.Input
                                cmdInsert.Parameters("@n6").Value = Me.dgvPO.Rows(count).Cells(5).Value

                                param7 = cmdInsert.Parameters.Add("@n7", DB2Type.Decimal)
                                param7.Direction = ParameterDirection.Input
                                cmdInsert.Parameters("@n7").Value = Me.dgvPO.Rows(count).Cells(6).Value

                                cmdInsert.ExecuteNonQuery()

                            End If

                            count += 1
                            End While
                            MsgBox("Purchase Order Saved Succesfully")
                        Call RefreshorderDataGrid()
                    End If

                    End If

                Catch ex As Exception
                    MsgBox("Table(s) has missing information.")
                    MsgBox(ex.ToString)
                End Try
            End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

        Dim CmdDelete As DB2Command
        Dim i As Integer = 0
        Dim k As Integer = 0
        Dim param1 As DB2Parameter
        While Me.dgvPO.Rows(k).Cells(1).Value IsNot Nothing
            k += 1
        End While

        While i < k
            Try
                CmdDelete = New DB2Command("call deletePurchases(?)", conn)
                param1 = CmdDelete.Parameters.Add("@n1", DB2Type.Integer)
                param1.Direction = ParameterDirection.Input
                CmdDelete.Parameters("@n1").Value = Me.dgvPO.Rows(i).Cells(1).Value
                CmdDelete.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            i += 1
        End While
        MsgBox("Purchase Order on the List have been canceled")
        dgvPO.Rows.Clear()
    End Sub

    Private Sub dgvPO_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPO.CellContentClick
        If SwitchBtn.Text = "ORDER LISTS" Then

        Else

        End If
    End Sub

    Private Sub dgvPO_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPO.CellValueChanged
        Dim subtotal As Double
        Dim i As Integer = 0
        Dim count As Integer = 0
        Dim total As Decimal = 0


        If SwitchBtn.Text = "ORDER LISTS" Then

            If Me.dgvPO.CurrentRow.Cells(3).Value Is Nothing Then
                Me.dgvPO.CurrentRow.Cells(6).Value = "0.00"
            ElseIf Me.dgvPO.CurrentRow.Cells(5).Value Is Nothing Then
                Me.dgvPO.CurrentRow.Cells(6).Value = "0.00"
            Else
                Dim qty As Decimal = Me.dgvPO.CurrentRow.Cells(3).Value
                Dim price As Decimal = Me.dgvPO.CurrentRow.Cells(5).Value
                subtotal = qty * price
                Me.dgvPO.CurrentRow.Cells(6).Value = subtotal
            End If

            While Me.dgvPO.Rows(i).Cells(1).Value IsNot Nothing
                i += 1
            End While

            While count < i
                total += Me.dgvPO.Rows(count).Cells(6).Value
                count += 1

            End While

            txtTotal.Text = total

            Dim j As Integer = 0

        End If


    End Sub

    Private Sub EmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeToolStripMenuItem.Click
        PurchasesAll.Show()
        Me.Close()
    End Sub




    'CLOSE BUTTON'
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles closebtn.Click
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

    Private Sub TextBox3_TextChanged_1(sender As Object, e As EventArgs) Handles txtTotal.TextChanged

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles SwitchBtn.Click
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        If SwitchBtn.Text = "ORDER LISTS" Then
            SwitchBtn.Text = "CREATE ORDER"
            dgvPO.Rows.Clear()
            dgvPO.Columns(0).Visible = False
            With Me.dgvPO
                .ColumnCount = 5
                .Columns(1).Name = "PURCHASE NUMBER"
                .Columns(2).Name = "SUPPLIER ID"
                .Columns(3).Name = "TOTAL"
                .Columns(4).Name = "ORDER DATE"
            End With

            cmd = New DB2Command("select * from table(db2admin.purchaselist()) as udf where delvstat='NOT DELIVERED'", conn)
            rdr = cmd.ExecuteReader
            Dim i As Integer = 0
            While rdr.Read
                dgvPO.Rows.Add()
                Me.dgvPO.Rows(i).Cells(1).Value = rdr.GetString(0)
                Me.dgvPO.Rows(i).Cells(2).Value = rdr.GetString(1)
                Me.dgvPO.Rows(i).Cells(3).Value = rdr.GetString(2)
                Me.dgvPO.Rows(i).Cells(4).Value = rdr.GetString(3)

                i += 1
            End While

        Else
            SwitchBtn.Text = "ORDER LISTS"
            dgvPO.Columns(0).Visible = True
            dgvPO.Rows.Clear()
            With Me.dgvPO 'PO to be ordered
                .ColumnCount = 8
                .Columns(1).Name = "PURCHASE LINE ITEM"
                .Columns(2).Name = "INGREDIENT"
                .Columns(3).Name = "QTY"
                .Columns(4).Name = "UNIT"
                .Columns(5).Name = "PRICE"
                .Columns(6).Name = "SUBTOTAL"
                .Columns(7).Name = "ING_ID"
            End With
            Call RefreshorderDataGrid()

        End If
    End Sub

    Private Sub dgvPO_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPO.CellDoubleClick
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        Dim param1 As DB2Parameter
        If SwitchBtn.Text = "ORDER LISTS" Then

        Else

            txtPoNum.Text = dgvPO.CurrentRow.Cells(1).Value
            SwitchBtn.Text = "ORDER LISTS"
            dgvPO.Columns(0).Visible = True
            dgvPO.Rows.Clear()
            With Me.dgvPO 'PO to be ordered
                .ColumnCount = 8
                .Columns(1).Name = "PURCHASE LINE ITEM"
                .Columns(2).Name = "INGREDIENT"
                .Columns(3).Name = "QTY"
                .Columns(4).Name = "UNIT"
                .Columns(5).Name = "PRICE"
                .Columns(6).Name = "SUBTOTAL"
                .Columns(7).Name = "ING_ID"
            End With

            cmd = New DB2Command("select * from table( db2admin.Po_lineitemleftjoin_ingredients(?)) as udf ", conn)
            param1 = cmd.Parameters.Add("@1", DB2Type.VarChar)
            param1.Direction = ParameterDirection.Input
            cmd.Parameters("@1").Value = Me.txtPoNum.Text

            rdr = cmd.ExecuteReader
            Dim i As Integer = 0
            While rdr.Read
                dgvPO.Rows.Add()
                Me.dgvPO.Rows(i).Cells(1).Value = rdr.GetString(0)
                Me.dgvPO.Rows(i).Cells(2).Value = rdr.GetString(7)
                Me.dgvPO.Rows(i).Cells(3).Value = rdr.GetString(3)
                Me.dgvPO.Rows(i).Cells(4).Value = rdr.GetString(4)
                Me.dgvPO.Rows(i).Cells(5).Value = rdr.GetString(5)
                Me.dgvPO.Rows(i).Cells(6).Value = rdr.GetString(6)
                Me.dgvPO.Rows(i).Cells(7).Value = rdr.GetString(2)
                txtSup.Text = rdr.GetString(8)
                i += 1
            End While
        End If
    End Sub
End Class