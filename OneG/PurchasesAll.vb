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
                .ColumnCount = 6
                .Columns(0).Name = "PURCHASE ORDER NUMBER"
                .Columns(1).Name = "SUPPLIER ID"
                .Columns(2).Name = "TOTAL CREDIT"
                .Columns(3).Name = "ORDER DATE"
                .Columns(4).Name = "PROCESSED BY"
                .Columns(5).Name = "STATUS"
            End With


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


            cmd = New DB2Command("select * from PURCHASES", conn)
            rdr = cmd.ExecuteReader
            Me.dgvPurchases.Rows.Clear()
            While rdr.Read
                dgvPurchases.Rows.Add()
                Me.dgvPurchases.Rows(i).Cells(0).Value = rdr.GetString(0)
                Me.dgvPurchases.Rows(i).Cells(1).Value = rdr.GetString(1)
                Me.dgvPurchases.Rows(i).Cells(2).Value = rdr.GetString(2)
                Me.dgvPurchases.Rows(i).Cells(3).Value = rdr.GetString(3)
                Me.dgvPurchases.Rows(i).Cells(4).Value = rdr.GetString(4)
                Me.dgvPurchases.Rows(i).Cells(5).Value = rdr.GetString(5)
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



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSearchSup.SelectedIndexChanged
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader

        Dim i As Integer = 0

        Try
            cmd = New DB2Command("select * from purchases", conn)
            rdr = cmd.ExecuteReader
            Me.dgvPurchases.Rows.Clear()
            While rdr.Read
                If rdr.GetString(5).StartsWith(CmbSearchSup.Text) Then
                    dgvPurchases.Rows.Add()
                    Me.dgvPurchases.Rows(i).Cells(0).Value = rdr.GetString(0)
                    Me.dgvPurchases.Rows(i).Cells(1).Value = rdr.GetString(1)
                    Me.dgvPurchases.Rows(i).Cells(2).Value = rdr.GetString(2)
                    Me.dgvPurchases.Rows(i).Cells(3).Value = rdr.GetString(3)
                    Me.dgvPurchases.Rows(i).Cells(4).Value = rdr.GetString(4)
                    Me.dgvPurchases.Rows(i).Cells(5).Value = rdr.GetString(5)
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

        If dgvPurchases.CurrentRow.Cells(5).Value = "DELIVERED" Then
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

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs)
        Dim count As Integer = dgvPurchases.Rows.Count - 1
        Dim i As Integer = 0
        Dim cmdInsert As DB2Command
        Dim updated As Boolean = False

        Try
            Dim answer As DialogResult
            answer = MessageBox.Show("Purchase Order has Changes, Save?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If answer = vbYes Then

                While i < count
                    If Me.dgvPurchases.Rows(i).Cells(5).Value = "DELIVERED" Then

                    Else
                        Dim param1 As DB2Parameter

                        cmdInsert = New DB2Command("call update_purchaseStat(?)", conn)

                        param1 = cmdInsert.Parameters.Add("@1", DB2Type.VarChar)
                        param1.Direction = ParameterDirection.Input
                        cmdInsert.Parameters("@1").Value = Me.dgvPurchases.Rows(i).Cells(0).Value
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
        If Me.dgvPurchases.CurrentRow.Cells(5).Value = "DELIVERED" Then
            MsgBox("Delivered Items cannot be updated")
        Else
        End If
    End Sub

    Private Sub dgvPurchases_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPurchases.CellDoubleClick
        If Me.dgvPurchases.CurrentRow.Cells(5).Value = "DELIVERED" Then
            MsgBox("Delivered Items cannot be updated")
        Else
            ConfirmCode.ShowDialog()
            If ConfirmCode.CONFIRM = True Then


                Dim cmdInsert As DB2Command
                Dim rdr As DB2DataReader
                Dim count As Integer = 0
                Dim cmdupdate2 As DB2Command

                Try

                    '--------------------------------SELECT ALL LINE ITEM FROM DATABASE-------------------------------------------------
                    cmdInsert = New DB2Command("select * from TABLE(DB2ADMIN.lineitem_list()) AS UDF where po_no = @N1", conn)
                    cmdInsert.Parameters.Add("@N1", DB2Type.VarChar).Value = Me.dgvPurchases.CurrentRow.Cells(0).Value
                    rdr = cmdInsert.ExecuteReader
                    While rdr.Read

                        Dim Cmdunit As DB2Command
                        Dim rdrunit As DB2DataReader
                        Dim pounit As String = rdr.GetString(4).ToString
                        Dim ing As String = rdr.GetString(2).ToString
                        Dim qty As Decimal = rdr.GetString(3).ToString
                        Cmdunit = New DB2Command("select ingunit from TABLE(DB2ADMIN.INGREDIENTLIST()) AS udf where ing_ID= @n2", conn)
                        Cmdunit.Parameters.Add("@N2", DB2Type.VarChar).Value = ing
                        rdrunit = Cmdunit.ExecuteReader
                        rdrunit.Read()

                        Dim unit As String = rdrunit.GetString(0)

                        If unit = "KILOGRAMS" And pounit = "KILOGRAMS" Then
                            cmdupdate2 = New DB2Command("update ingredients set ingqty = ingqty +@sqty where ing_id= '" & ing & "'", conn)
                            cmdupdate2.Parameters.Add("@sqty", DB2Type.Decimal).Value = qty
                            cmdupdate2.ExecuteNonQuery()

                        ElseIf unit = "KILOGRAMS" And pounit = "GRAMS" Then
                            cmdupdate2 = New DB2Command("update ingredients set ingqty = ingqty +@sqty where ing_id= '" & ing & "'", conn)
                            cmdupdate2.Parameters.Add("@sqty", DB2Type.Decimal).Value = qty / 1000
                            cmdupdate2.ExecuteNonQuery()


                        ElseIf unit = "GRAMS" And pounit = "KILOGRAMS" Then
                            cmdupdate2 = New DB2Command("update ingredients set ingqty = ingqty +@sqty where ing_id= '" & ing & "'", conn)
                            cmdupdate2.Parameters.Add("@sqty", DB2Type.Decimal).Value = qty * 1000
                            cmdupdate2.ExecuteNonQuery()

                        ElseIf unit = "GRAMS" And pounit = "GRAMS" Then
                            cmdupdate2 = New DB2Command("update ingredients set ingqty = ingqty +@sqty where ing_ID= '" & ing & "'", conn)
                            cmdupdate2.Parameters.Add("@sqty", DB2Type.Decimal).Value = qty
                            cmdupdate2.ExecuteNonQuery()
                        Else
                            cmdupdate2 = New DB2Command("update ingredients set ingqty = ingqty +@sqty where ing_ID= '" & ing & "'", conn)
                            cmdupdate2.Parameters.Add("@sqty", DB2Type.Decimal).Value = qty
                            cmdupdate2.ExecuteNonQuery()
                        End If

                    End While

                    '-------------------------UPDATE DELIVERY STATUS--------------------------------------------------------
                    Dim param1 As DB2Parameter
                    cmdInsert = New DB2Command("call update_purchaseStat(?)", conn)

                    param1 = cmdInsert.Parameters.Add("@1", DB2Type.VarChar)
                    param1.Direction = ParameterDirection.Input
                    cmdInsert.Parameters("@1").Value = Me.dgvPurchases.CurrentRow.Cells(0).Value
                    cmdInsert.ExecuteNonQuery()
                    '---------------------------------------------------------------------------------

                    MsgBox("Purchase Order Updated Succesfully")

                Catch ex As Exception
                    MsgBox("Tables with missing information is/are not recorded")
                    MsgBox(ex.ToString)
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

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader

        Dim i As Integer = 0

        Try

            cmd = New DB2Command("select * from TABLE(DB2ADMIN.PURCHASELIST()) AS UDF where po_date =@d", conn)
            cmd.Parameters.Add("@d", DB2Type.Date).Value = DateTimePicker1.Value
            rdr = cmd.ExecuteReader
            Me.dgvPurchases.Rows.Clear()
            While rdr.Read
                dgvPurchases.Rows.Add()
                Me.dgvPurchases.Rows(i).Cells(0).Value = rdr.GetString(0)
                Me.dgvPurchases.Rows(i).Cells(1).Value = rdr.GetString(1)
                Me.dgvPurchases.Rows(i).Cells(2).Value = rdr.GetString(2)
                Me.dgvPurchases.Rows(i).Cells(3).Value = rdr.GetString(3)
                Me.dgvPurchases.Rows(i).Cells(4).Value = rdr.GetString(4)
                Me.dgvPurchases.Rows(i).Cells(5).Value = rdr.GetString(5)
                i += 1
            End While

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class