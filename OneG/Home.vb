Imports IBM.Data.DB2

Public Class Home
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


    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn = New DB2Connection("server=localhost;database=oneg;" + "uid=db2admin;password=db2admin;")
            conn.Open()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Me.lblWelcomeHome.Text = "WELCOME, " + Login.name.ToString + "!"
        Me.lblWelcomeBar.Text = "WELCOME, " + Login.name.ToString + "!"

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

    Private Sub OrderBtn_Click(sender As Object, e As EventArgs) Handles OrderBtn.Click

        Order.Show()
        Me.Close()
    End Sub

    Private Sub PayBtn_Click(sender As Object, e As EventArgs) Handles PayBtn.Click

        Payment.Show()
        Me.Close()
    End Sub

    Private Sub MainBtn_Click(sender As Object, e As EventArgs) Handles MainBtn.Click

        MainTable.Show()
        Me.Close()
    End Sub

    Private Sub AccBtn_Click(sender As Object, e As EventArgs) Handles AccBtn.Click
        AccountUser.Show()
        Me.Close()
    End Sub

    Private Sub PurcBtn_Click(sender As Object, e As EventArgs) Handles PurcBtn.Click
        PurchaseOrder.Show()
        Me.Close()
    End Sub

    Private Sub LogoutBtn_Click(sender As Object, e As EventArgs) Handles LogoutBtn.Click
        logout.ShowDialog()

        MsgBox("Please Log in Again.")
        Login.Show()
        Me.Close()
    End Sub
End Class