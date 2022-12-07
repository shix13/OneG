Imports IBM.Data.DB2

Public Class pwCheck
    Private CONN As DB2Connection
    Public PwCONFIRM As Boolean = False

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim CMD As DB2Command
        Dim RDR As DB2DataReader
        Dim STR As String
        CMD = New DB2Command("select PASSWORD from EMPLOYEE where ACCID ='" & Home.ACCID.ToString & "'", CONN)
        RDR = CMD.ExecuteReader
        RDR.Read()
        STR = RDR.GetString(0).ToString
        If RDR.HasRows Then


            If STR = txtpw1.Text Then
                PwCONFIRM = True
            Else
                PwCONFIRM = False
            End If
        End If
        key.Close()
        Me.Close()

    End Sub

    Private Sub ConfirmCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CONN = New DB2Connection("server=localhost;database=ONEG;" + "uid=db2admin;password=db2admin;")
            CONN.Open()

            txtpw1.Clear()


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Class