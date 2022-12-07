Imports System.Data.Common
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports IBM.Data.DB2

Public Class MainMenu
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


    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn = New DB2Connection("server=localhost;database=oneg;" + "uid=db2admin;password=db2admin;")
            conn.Open()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            '---MENU ING
            With Me.dgvIng
                .ColumnCount = 4
                .Columns(0).Name = "ID"
                .Columns(1).Name = "INGREDIENT NAME"
                .Columns(2).Name = "STOCK QTY"
                .Columns(3).Name = "UNIT"

            End With

            '---MENU ING USED (RECIPE)
            Dim chkBoxCol As New DataGridViewCheckBoxColumn
            dgvMENUANDUSED.Columns.Add(chkBoxCol)
            dgvMENUANDUSED.Columns(0).Width = 20

            With Me.dgvMENUANDUSED
                .ColumnCount = 5
                .Columns(0).Name = "-"
                .Columns(1).Name = "VIAND NAME"
                .Columns(2).Name = "INGREDIENT"
                .Columns(3).Name = "QTY USED"
                .Columns(4).Name = "UNIT"
            End With
            Me.lblWelcomeBar.Text = "WELCOME, " + Home.nameU.ToString + "!"
            dgvMENUANDUSED.Columns(1).Visible = False
            Call REFRESHORDERDATAGRID()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub REFRESHORDERDATAGRID()
        Dim str As String
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        Dim param1 As DB2Parameter
        Dim rows As String()

        Me.txtMenuItemName.Clear()
        Me.txtPrice.Clear()

        str = "call db2admin.GETLASTMENUNO(?)"
        cmd = New DB2Command(str, conn)
        param1 = cmd.Parameters.Add("@1", DB2Type.Integer)
        param1.Direction = ParameterDirection.Output
        rdr = cmd.ExecuteReader

        Me.txtMenuNo.Text = param1.Value.ToString

        str = "select * from table( db2admin.INGREDIENTLIST()) as udf"
        cmd = New DB2Command(str, conn)
        rdr = cmd.ExecuteReader

        Me.dgvIng.Rows.Clear()
        While rdr.Read
            rows = New String() {rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3)}
            Me.dgvIng.Rows.Add(rows)
        End While
        Me.dgvMENUANDUSED.Rows.Clear()



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


    Private Sub searchAll_TextChanged(sender As Object, e As EventArgs) Handles searchAll.TextChanged
        Dim strsearchkey As String
        Dim strsearchkey1 As String
        Dim cmdsearch As DB2Command
        Dim rdrsearch As DB2DataReader
        Dim row As String()

        If SWITCHBTN.Text = "MENU LIST" Then
            Try
                strsearchkey = Me.searchAll.Text + "%"
                strsearchkey1 = Me.txtMenuNo.Text + "%"
                cmdsearch = New DB2Command("select MENU_NO,ING_ID,QTYUSED,QTYUNIT from ingredients_used where  ING_ID like '" & strsearchkey & "' AND MENU_NO LIKE '" & strsearchkey1 & "'", conn)
                rdrsearch = cmdsearch.ExecuteReader
                Me.dgvMENUANDUSED.Rows.Clear()
                While rdrsearch.Read
                    row = New String() {False, rdrsearch.GetString(0), rdrsearch.GetString(1), rdrsearch.GetString(2), rdrsearch.GetString(3)}
                    Me.dgvMENUANDUSED.Rows.Add(row)
                End While

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            Try
                strsearchkey = Me.searchAll.Text + "%"
                cmdsearch = New DB2Command("select * from menu where MENUITEMNAME Like '" & strsearchkey & "' ", conn)
                rdrsearch = cmdsearch.ExecuteReader
                Me.dgvMENUANDUSED.Rows.Clear()
                While rdrsearch.Read
                    row = New String() {False, rdrsearch.GetString(0), rdrsearch.GetString(1), rdrsearch.GetString(2)}
                    Me.dgvMENUANDUSED.Rows.Add(row)
                End While

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If



    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        Dim str As String
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        Dim PARAM1 As DB2Parameter
        Dim count As Integer = 0
        Dim param2 As DB2Parameter
        Dim param3 As DB2Parameter
        Dim save As Boolean = False
        If txtMenuItemName.Text = "" Then
            MsgBox("Set Meal Name")
        ElseIf txtPrice.Text = "" Then
            MsgBox("Set Meal Price")
        Else


            While count < dgvMENUANDUSED.Rows.Count - 1
            If dgvMENUANDUSED.Rows(count).Cells(3).Value Is Nothing Then
                    MsgBox("Row: " & count + 1 & " has lacking information.")

                Else
                cmd = New DB2Command("select * from menu where menu_no= '" & txtMenuNo.Text & "'", conn)
                rdr = cmd.ExecuteReader()
                If rdr.HasRows Then

                    Try
                        str = "call updatemenu(?,?,?)"
                        cmd = New DB2Command(str, conn)
                        PARAM1 = cmd.Parameters.Add("@1", DB2Type.Integer)
                        PARAM1.Direction = ParameterDirection.Input
                        cmd.Parameters("@1").Value = Me.txtMenuNo.Text

                        param2 = cmd.Parameters.Add("@2", DB2Type.VarChar)
                        param2.Direction = ParameterDirection.Input
                        cmd.Parameters("@2").Value = Me.txtMenuItemName.Text

                        param3 = cmd.Parameters.Add("@3", DB2Type.Decimal)
                        param3.Direction = ParameterDirection.Input
                        cmd.Parameters("@3").Value = Me.txtPrice.Text
                        cmd.ExecuteNonQuery()


                        cmd = New DB2Command("select menu_no,ing_id from ingredients_used where menu_no ='" & dgvMENUANDUSED.Rows(count).Cells(1).Value & "' and ing_id ='" & dgvMENUANDUSED.Rows(count).Cells(2).Value & "' ", conn)
                        rdr = cmd.ExecuteReader
                            If rdr.HasRows Then

                                cmd = New DB2Command("update ingredients_used set qtyused= @used,qtyunit=@unit where menu_no ='" & Me.dgvMENUANDUSED.Rows(count).Cells(1).Value & "' and ing_id='" & Me.dgvMENUANDUSED.Rows(count).Cells(2).Value & "'", conn)
                                cmd.Parameters.Add("@used", DB2Type.Double).Value = Me.dgvMENUANDUSED.Rows(count).Cells(3).Value
                                cmd.Parameters.Add("@unit", DB2Type.VarChar).Value = Me.dgvMENUANDUSED.Rows(count).Cells(4).Value
                                cmd.ExecuteNonQuery()
                            Else

                                cmd = New DB2Command("insert into ingredients_used values (@qty,@un,@menu,@ing)", conn)
                                cmd.Parameters.Add("@menu", DB2Type.Integer).Value = Me.dgvMENUANDUSED.Rows(count).Cells(1).Value
                                cmd.Parameters.Add("@ing", DB2Type.VarChar).Value = Me.dgvMENUANDUSED.Rows(count).Cells(2).Value
                                cmd.Parameters.Add("@qty", DB2Type.Double).Value = Me.dgvMENUANDUSED.Rows(count).Cells(3).Value
                                cmd.Parameters.Add("@un", DB2Type.VarChar).Value = Me.dgvMENUANDUSED.Rows(count).Cells(4).Value
                                cmd.ExecuteNonQuery()
                            End If
                            save = True
                        Catch ex As Exception
                        MsgBox("Something went wrong please Try again!")
                        MsgBox(ex.ToString)
                    End Try
                Else
                    Try
                        str = "call insertmenu(?,?,?)"
                        cmd = New DB2Command(str, conn)

                        PARAM1 = cmd.Parameters.Add("@1", DB2Type.Integer)
                        PARAM1.Direction = ParameterDirection.Input
                        cmd.Parameters("@1").Value = Me.txtMenuNo.Text

                        param2 = cmd.Parameters.Add("@2", DB2Type.VarChar)
                        param2.Direction = ParameterDirection.Input
                        cmd.Parameters("@2").Value = Me.txtMenuItemName.Text

                        param3 = cmd.Parameters.Add("@3", DB2Type.Double)
                        param3.Direction = ParameterDirection.Input
                        cmd.Parameters("@3").Value = Me.txtPrice.Text
                        cmd.ExecuteNonQuery()


                        cmd = New DB2Command("insert into ingredients_used values (@qty,@un,@menu,@ing)", conn)
                        cmd.Parameters.Add("@menu", DB2Type.Integer).Value = Me.dgvMENUANDUSED.Rows(count).Cells(1).Value
                        cmd.Parameters.Add("@ing", DB2Type.VarChar).Value = Me.dgvMENUANDUSED.Rows(count).Cells(2).Value
                        cmd.Parameters.Add("@qty", DB2Type.Double).Value = Me.dgvMENUANDUSED.Rows(count).Cells(3).Value
                        cmd.Parameters.Add("@un", DB2Type.VarChar).Value = Me.dgvMENUANDUSED.Rows(count).Cells(4).Value
                        cmd.ExecuteNonQuery()
                            save = True
                        Catch ex As Exception
                        MsgBox("Fill all details")
                        MsgBox(ex.ToString)
                    End Try
                End If

            End If
            count += 1
            End While
            If save = True Then
                MsgBox("Menu Item Information Saved Successfully!")
                Call REFRESHORDERDATAGRID()
            Else
                MsgBox("Menu Information Not Saved.")
            End If

        End If
    End Sub

    Private Sub dgvIng_MouseUp(sender As Object, e As MouseEventArgs) Handles dgvIng.MouseUp

        If SWITCHBTN.Text = "MENU LIST" Then

        Else
            SWITCHBTN.Text = "MENU LIST"
            REMOVEBTN.Visible = True
            dgvMENUANDUSED.Columns(0).Visible = True
            With Me.dgvMENUANDUSED
                .ColumnCount = 5

                .Columns(1).Name = "VIAND CODE"
                .Columns(2).Name = "INGREDIENT"
                .Columns(3).Name = "QTY USED"
                .Columns(4).Name = "UNIT"
            End With
            REFRESHORDERDATAGRID()

        End If
        Try

            Dim i As Integer = 0
            Dim similar As Boolean
            While dgvMENUANDUSED.Rows(i).Cells(1).Value IsNot Nothing And dgvMENUANDUSED.Rows(i).Cells(2).Value IsNot Nothing
                If dgvMENUANDUSED.Rows(i).Cells(2).Value = dgvIng.CurrentRow.Cells(0).Value Then
                    similar = True
                End If
                i += 1
            End While

            If similar = True Then
                MsgBox("Reminder: Item already in the list")

            Else
                Me.dgvMENUANDUSED.Rows.Add()
                Me.dgvMENUANDUSED.Rows(i).Cells(2).Value = Me.dgvIng.CurrentRow.Cells(0).Value
                Me.dgvMENUANDUSED.Rows(i).Cells(1).Value = txtMenuNo.Text
                If dgvIng.CurrentRow.Cells(3).Value = "KILOGRAMS" Then
                    Me.dgvMENUANDUSED.Rows(i).Cells("UNIT").Value = "GRAMS"
                Else
                    Me.dgvMENUANDUSED.Rows(i).Cells("UNIT").Value = dgvIng.CurrentRow.Cells(3).Value
                End If

                Dim cmd As DB2Command
                Dim rdr As DB2DataReader

                cmd = New DB2Command("select * from ingredients_used where menu_no ='" & Me.txtMenuNo.Text & "' and ing_id = '" & Me.dgvMENUANDUSED.Rows(i).Cells(2).Value & "'", conn)
                rdr = cmd.ExecuteReader
                rdr.Read()
                If rdr.HasRows Then
                    Me.dgvMENUANDUSED.Rows(i).Cells(0).Value = rdr.GetString(3)
                    Me.dgvMENUANDUSED.Rows(i).Cells(1).Value = rdr.GetString(4)
                    Me.dgvMENUANDUSED.Rows(i).Cells(2).Value = rdr.GetString(1)
                    Me.dgvMENUANDUSED.Rows(i).Cells(3).Value = rdr.GetString(2)
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
            End Try
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        Dim StrDelete As String
        Dim CmdDelete As DB2Command
        Dim count As Integer = 0
        Dim i As Integer

        Dim answer As DialogResult
        answer = MessageBox.Show("Menu info will be deleted?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            If txtMenuNo.Text = "" Then
                MsgBox("Select Viand to Remove from the Menu")
            Else
                While dgvMENUANDUSED.Rows(i).Cells(1).Value IsNot Nothing And dgvMENUANDUSED.Rows(i).Cells(2).Value IsNot Nothing
                    i += 1
                End While

                Try
                    StrDelete = "delete from menu where menu_no = '" & Me.txtMenuNo.Text & "'"
                    CmdDelete = New DB2Command(StrDelete, conn)
                    CmdDelete.ExecuteNonQuery()

                    StrDelete = "delete from INGREDIENTS_USED where menu_no = '" & Me.txtMenuNo.Text & "'"
                    CmdDelete = New DB2Command(StrDelete, conn)
                    CmdDelete.ExecuteNonQuery()

                    MsgBox("Menu item has been remove.")

                    Call REFRESHORDERDATAGRID()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles SWITCHBTN.Click
        Dim str As String
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        Dim rows As String()

        Try


            If SWITCHBTN.Text = "MENU LIST" Then
                dgvMENUANDUSED.Rows.Clear()
                SWITCHBTN.Text = "RECIPE LIST"
                REMOVEBTN.Visible = False

                dgvMENUANDUSED.Columns(0).Visible = False
                With Me.dgvMENUANDUSED
                    .ColumnCount = 4
                    .Columns(1).Name = "VIAND CODE"
                    .Columns(2).Name = "VIAND NAME"
                    .Columns(3).Name = "PRICE"
                End With


                str = "select * from menu"
                cmd = New DB2Command(str, conn)
                rdr = cmd.ExecuteReader

                While rdr.Read
                    rows = New String() {"", rdr.GetString(0), rdr.GetString(1), rdr.GetString(2)}
                    Me.dgvMENUANDUSED.Rows.Add(rows)
                End While

            Else
                SWITCHBTN.Text = "MENU LIST"
                REMOVEBTN.Visible = True
                dgvMENUANDUSED.Columns(0).Visible = True
                With Me.dgvMENUANDUSED
                    .ColumnCount = 5

                    .Columns(1).Name = "VIAND CODE"
                    .Columns(2).Name = "INGREDIENT"
                    .Columns(3).Name = "QTY USED"
                    .Columns(4).Name = "UNIT"
                End With
                REFRESHORDERDATAGRID()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub dgvMENUANDUSED_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMENUANDUSED.CellContentClick

    End Sub

    Private Sub dgvMENUANDUSED_MouseUp(sender As Object, e As MouseEventArgs) Handles dgvMENUANDUSED.MouseUp
        Dim str As String
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        Dim rows As String()
        Try


            If SWITCHBTN.Text = "MENU LIST" Then



            Else
                Try
                    REMOVEBTN.Visible = True

                    txtMenuNo.Text = dgvMENUANDUSED.CurrentRow.Cells(1).Value
                    txtMenuItemName.Text = dgvMENUANDUSED.CurrentRow.Cells(2).Value
                    txtPrice.Text = dgvMENUANDUSED.CurrentRow.Cells(3).Value


                    SWITCHBTN.Text = "MENU LIST"
                    dgvMENUANDUSED.Columns(0).Visible = True
                    With Me.dgvMENUANDUSED
                        .ColumnCount = 5
                        .Columns(0).Name = ""
                        .Columns(1).Name = "VIAND CODE"
                        .Columns(2).Name = "INGREDIENT"
                        .Columns(3).Name = "QTY USED"
                        .Columns(4).Name = "UNIT"
                    End With

                    str = "select MENU_no, ing_id, qtyused,qtyunit from ingredients_used where menu_no ='" & txtMenuNo.Text & "'"
                    cmd = New DB2Command(Str, conn)
                    rdr = cmd.ExecuteReader
                    dgvMENUANDUSED.Rows.Clear()
                    While rdr.Read
                        rows = New String() {False, rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3)}
                        Me.dgvMENUANDUSED.Rows.Add(rows)
                    End While
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles REMOVEBTN.Click
        Dim k As Integer = 0
        Dim count As Integer = 0
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader

        Try
            While Me.dgvMENUANDUSED.Rows(k).Cells(1).Value IsNot Nothing And Me.dgvMENUANDUSED.Rows(k).Cells(2).Value IsNot Nothing
                k += 1
            End While

            While count < k

                If dgvMENUANDUSED.Rows(count).Cells(0).Value = True Then
                    cmd = New DB2Command("select * from ingredients_used where menu_no ='" & dgvMENUANDUSED.Rows(count).Cells(0).Value.ToString & "' and ing_id ='" & dgvMENUANDUSED.Rows(count).Cells(1).Value.ToString & "'", conn)
                    rdr = cmd.ExecuteReader
                    If rdr.HasRows Then
                        cmd = New DB2Command("delete from ingredients_used where menu_no = '" & Me.dgvMENUANDUSED.Rows(count).Cells(0).Value.ToString & "' and ing_id='" & Me.dgvMENUANDUSED.Rows(count).Cells(1).Value.ToString & "' ", conn)
                        cmd.ExecuteNonQuery()
                    End If
                    dgvMENUANDUSED.Rows(count).Cells(4).Value = False
                    dgvMENUANDUSED.Rows.RemoveAt(count)
                    k -= 1
                Else
                    count += 1
                End If

            End While
            MsgBox("Ingredient removed from list")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim strsearchkey As String
        Dim cmdsearch As DB2Command
        Dim rdrsearch As DB2DataReader
        Dim row As String()

        Try
            strsearchkey = TextBox1.Text + "%"
            cmdsearch = New DB2Command("select * from ingredients where ingname like '" & strsearchkey & "'", conn)
            rdrsearch = cmdsearch.ExecuteReader
            Me.dgvIng.Rows.Clear()
            While rdrsearch.Read
                row = New String() {rdrsearch.GetString(0), rdrsearch.GetString(1), rdrsearch.GetString(2), rdrsearch.GetString(3)}
                Me.dgvIng.Rows.Add(row)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem.Click
        If Home.role = "COOK" Or Home.role = "Cook" Then
            MainSupp.Enabled = False
            MsgBox("Account Type Not Authorized.")
        Else
            MainSupp.Show()
            Me.Close()
        End If
    End Sub

    Private Sub TableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TableToolStripMenuItem.Click
        If Home.role = "COOK" Or Home.role = "Cook" Then
            MainTable.Enabled = False
            MsgBox("Account Type Not Authorized.")
        Else
            MainTable.Show()
            Me.Close()
        End If
    End Sub

    Private Sub InventoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventoryToolStripMenuItem.Click
        MainInventory.Show()
        Me.Close()
    End Sub

    Private Sub EmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeToolStripMenuItem.Click
        If Home.role = "COOK" Or Home.role = "Cook" Then
            MainEmp.Enabled = False
            MsgBox("Account Type Not Authorized.")
        Else
            MainEmp.Show()
            Me.Close()
        End If
    End Sub

    Private Sub SystemLogsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SystemLogsToolStripMenuItem.Click
        If Home.role = "COOK" Or Home.role = "Cook" Then
            MsgBox("Account Type Not Authorized.")
        Else
            MainTransLogs.Show()
            Me.Close()
        End If
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

    Private Sub dgvIng_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIng.CellContentClick

    End Sub
End Class