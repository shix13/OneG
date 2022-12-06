﻿Imports System.ComponentModel.Design
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
        Dim randNum As New Random
        Dim value As Integer = randNum.Next(1, 10000)
        txtAccID.Text = "ACC_" + value.ToString
        txtFName.Clear()
        txtLName.Clear()
        txtMName.Clear()
        txtPass.Clear()
        cmbPosition.Text = "SELECT"

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
        Dim PW As String = Me.txtPass.Text
        If txtFName.Text = "" Or txtLName.Text = "" Or txtMName.Text = "" Or txtPass.Text = "" Then
            MsgBox("Fill Up All details")
        ElseIf cmbPosition.Text = "" Or cmbPosition.Text = "SELECT" Then
            MsgBox("Select an Organizational Role")
        Else
            If (PW.Length < 8) Then
                MsgBox("Password Length requires 8 or more characters")
            Else
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
                    cmd.Parameters("@5").Value = Me.cmbPosition.Text.ToUpper


                    param6 = cmd.Parameters.Add("@6", DB2Type.VarChar)
                    param6.Direction = ParameterDirection.Input
                    cmd.Parameters("@6").Value = Me.txtPass.Text

                    cmd.ExecuteNonQuery()
                    MsgBox("Account Saved Successfully!")
                    Call REFRESHORDERDATAGRID()
                    Login.Show()
                    Me.Close()
                Catch ex As Exception
                    MsgBox("Something went wrong please try again!")
                End Try
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub txtAccID_TextChanged(sender As Object, e As EventArgs) Handles txtAccID.TextChanged

    End Sub
End Class
