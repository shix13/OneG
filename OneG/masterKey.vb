Imports System.Data.Common
Imports IBM.Data.DB2

Public Class masterKey
    Private conn As DbConnection
    Public CONFIRM As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles confBtn.Click
        Dim cmd As DB2Command
        Dim rdr As DB2DataReader
        cmd = New DB2Command("select password from EMPLOYEE where ACCID ='admin'", conn)
        rdr = cmd.ExecuteReader
        rdr.Read()
        If rdr.GetString(0).Equals(txtInput.Text) Then
            CONFIRM = True
        Else
            CONFIRM = False
            MsgBox("Incorrect Password!")
        End If
        Me.Close()
    End Sub

    Private Sub masterKey_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New DB2Connection("server=localhost;database=oneg;" + "uid=db2admin;password=db2admin;")
        conn.Open()
    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        CONFIRM = False
        Me.Close()
    End Sub
End Class