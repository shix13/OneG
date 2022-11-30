Imports System.ComponentModel.Design
Imports IBM.Data.DB2
Public Class SignUp
    Private conn As IDbConnection

    Private Sub SignUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn = New DB2Connection("server=localhost;database=oneg;" + "uid=db2admin;password=db2admin;")
            conn.Open()
            Call REFRESHORDERDATAGRID()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub REFRESHORDERDATAGRID()
        Dim value As Integer = CInt(Int((10000 * Rnd()) + 1))
        txtAccID.Text = "ACC_" + value.ToString
        txtFName.Clear()
        txtLName.Clear()
        txtMName.Clear()
        txtPass.Clear()
        cmbPosition.Text = "Select"

    End Sub

    Private Sub SignUpBtn_Click(sender As Object, e As EventArgs) Handles SignUpBtn.Click
        Dim str As String
        Dim cmd As DB2Command
        Dim param1 As DB2Parameter
        Dim param2 As DB2Parameter
        Dim param3 As DB2Parameter
        Dim param4 As DB2Parameter
        Dim param5 As DB2Parameter
        Dim param6 As DB2Parameter

        Try
            str = "call insertEmployee(?,?,?,?,?,?)"
            cmd = New DB2Command(str, conn)

            param1 = cmd.Parameters.Add("@1", DB2Type.VarChar)
            param1.Direction = ParameterDirection.Input
            cmd.Parameters("@1").Value = Me.txtAccID.Text

            param2 = cmd.Parameters.Add("@2", DB2Type.VarChar)
            param2.Direction = ParameterDirection.Input
            cmd.Parameters("@2").Value = Me.txtLName.Text

            param3 = cmd.Parameters.Add("@3", DB2Type.VarChar)
            param3.Direction = ParameterDirection.Input
            cmd.Parameters("@3").Value = Me.txtFName.Text

            param4 = cmd.Parameters.Add("@4", DB2Type.VarChar)
            param4.Direction = ParameterDirection.Input
            cmd.Parameters("@4").Value = Me.txtMName.Text

            param5 = cmd.Parameters.Add("@5", DB2Type.VarChar)
            param5.Direction = ParameterDirection.Input
            cmd.Parameters("@5").Value = Me.cmbPosition.Text

            param6 = cmd.Parameters.Add("@6", DB2Type.VarChar)
            param6.Direction = ParameterDirection.Input
            cmd.Parameters("@6").Value = Me.txtPass.Text

            cmd.ExecuteNonQuery()
            MsgBox("Account Saved Successfully!")
            Call REFRESHORDERDATAGRID()
        Catch ex As Exception
            MsgBox("Something went wrong please try again!")
        End Try

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.Close()
    End Sub
End Class
