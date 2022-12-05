Imports IBM.Data.DB2

Public Class pwCheck
    Private CONN As DB2Connection
    Public PwCONFIRM As Boolean = False

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim CMD As DB2Command
        Dim RDR As DB2DataReader

        CMD = New DB2Command("select password from EMPLOYEE where ACCID ='" & txtpw.Text & "'", CONN)
        RDR = cmd.ExecuteReader
        RDR.Read()
        If RDR.HasRows Then
            PwCONFIRM = True
        Else
            PwCONFIRM = False
        End If
        key.Close()
        Me.Close()

    End Sub

    Private Sub ConfirmCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn = New DB2Connection("server=localhost;database=JMG;" + "uid=db2admin;password=db2admin;")
            conn.Open()

            txtpw.Clear()


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Class