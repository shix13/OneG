Imports System.Data.Common
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
                .ColumnCount = 10
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
            End With

            Dim dtadapt2 As DB2DataAdapter
            Dim ds2 As DataSet = New DataSet()




            Me.lblWelcomeBar.Text = "WELCOME, " + Login.name.ToString + "!"
            Call RefreshorderDataGrid()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RefreshorderDataGrid()
        Try

            Dim cmd As DB2Command
            Dim rdr As DB2DataReader
            Dim rows As String()
            CmbSearchSup.Text = "NOT DELIVERED"


            cmd = New DB2Command("Select * from purchases order by po_no desc", conn)
            rdr = cmd.ExecuteReader
            Me.dgvPurchases.Rows.Clear()
            While rdr.Read
                rows = New String() {rdr.GetString(0), rdr.GetString(7), rdr.GetString(8), rdr.GetString(9), rdr.GetString(6), rdr.GetString(5), rdr.GetString(4), rdr.GetString(3), rdr.GetString(2), rdr.GetString(1)}
                Me.dgvPurchases.Rows.Add(rows)
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
        'here
    End Sub

    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub

    Private Sub searchPurchases_TextChanged(sender As Object, e As EventArgs) Handles searchPurchases.TextChanged
        Dim strsearchkey As String
        Dim cmdsearch As DB2Command
        Dim rdr As DB2DataReader
        Dim rows As String()


        Try
            strsearchkey = Me.searchPurchases.Text + "%"
            cmdsearch = New DB2Command("select * from purchases where ING_ID like '" & strsearchkey & "'", conn)
            rdr = cmdsearch.ExecuteReader

            Me.dgvPurchases.Rows.Clear()
            While rdr.Read
                rows = New String() {rdr.GetString(0), rdr.GetString(7), rdr.GetString(8), rdr.GetString(9), rdr.GetString(6), rdr.GetString(5), rdr.GetString(4), rdr.GetString(3), rdr.GetString(2), rdr.GetString(1)}
                Me.dgvPurchases.Rows.Add(rows)
            End While
        Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSearchSup.SelectedIndexChanged
        Dim cmdsearch As DB2Command
        Dim rdr As DB2DataReader
        Dim rows As String()
        Try

            cmdsearch = New DB2Command("select * from purchases where delvstat ='" & Me.CmbSearchSup.Text & "'", conn)
            rdr = cmdsearch.ExecuteReader
            Me.dgvPurchases.Rows.Clear()
            While rdr.Read
                rows = New String() {rdr.GetString(0), rdr.GetString(7), rdr.GetString(8), rdr.GetString(9), rdr.GetString(6), rdr.GetString(5), rdr.GetString(4), rdr.GetString(3), rdr.GetString(2), rdr.GetString(1)}
                Me.dgvPurchases.Rows.Add(rows)
            End While

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        Dim StrDelete As String
        Dim CmdDelete As DB2Command

        Try
            StrDelete = "delete from purchases where po_no= '" & Me.dgvPurchases.CurrentRow.Cells(0).Value & "'"
            CmdDelete = New DB2Command(StrDelete, conn)
            CmdDelete.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try


        MsgBox("Purchase Order has been Canceled")
        Call RefreshorderDataGrid()
    End Sub
End Class