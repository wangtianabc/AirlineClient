Imports System.ComponentModel
Imports System.Data.SQLite

Public Class SqliteForm
    Private connection As SQLiteConnection
    Private cmd As SQLiteCommand
    Private Sub SqliteForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dbPath As String = Application.StartupPath & "\../../../DB/airline.s3db"
        connection = New SQLiteConnection("Data Source=" & dbPath & ";Pooling=true;FailIfMissing=false")
        If connection.State <> ConnectionState.Open Then
            Try
                connection.Open()
                cmd = New SQLiteCommand()
                cmd.Connection = Me.connection
                MsgBox("打开成功")
            Catch ex As Exception
                MsgBox("打开失败")
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button_CreateTable.Click
        cmd.CommandText = "CREATE TABLE Test (ID INTEGER PRIMARY KEY,TestName VARCHAR(500),TestTime DateTime,Operator VARCHAR(100))"
        Dim result As Integer = cmd.ExecuteNonQuery()
        If result = 0 Then
            MsgBox("成功")
        Else
            MsgBox("失败")
        End If
    End Sub

    Private Sub Button_InsertTable_Click(sender As Object, e As EventArgs) Handles Button_InsertTable.Click
        cmd.CommandText = "insert into Test(TestName,TestTime,Operator)values(@Name,@TestTime,@Operator)"
        cmd.Parameters.Add("@Name", Data.DbType.String).Value = "动静"
        cmd.Parameters.Add("@TestTime", Data.DbType.DateTime).Value = Now()
        cmd.Parameters.Add("@Operator", Data.DbType.String).Value = "peer"
        Dim result As Integer = cmd.ExecuteNonQuery()
        If result <> 0 Then
            MsgBox("插入成功")
        End If
    End Sub

    Private Sub Button_Select_Click(sender As Object, e As EventArgs) Handles Button_Update.Click
        cmd.CommandText = "update  Test set TestName='动静1'"
        Dim result As Integer = cmd.ExecuteNonQuery()
        If result <> 0 Then
            MsgBox("更新成功")
        End If
    End Sub

    Private Sub Button_Select_Click_1(sender As Object, e As EventArgs) Handles Button_Select.Click
        Dim sa As New SQLiteDataAdapter("select * from Test", connection)
        Dim ds As New System.Data.DataSet
        sa.Fill(ds, "Test")
        Dim mytable As New System.Data.DataTable
        mytable = ds.Tables("Test")
        Me.DataGridView1.DataSource = mytable
        Me.DataGridView1.Refresh()
    End Sub

    Private Sub Button_Delete_Click(sender As Object, e As EventArgs) Handles Button_Delete.Click
        cmd.CommandText = "delete from Test"
        Dim result As Integer = cmd.ExecuteNonQuery()
        If result <> 0 Then
            MsgBox("删除成功")
        End If
    End Sub

    Private Sub SqliteForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If connection.State <> ConnectionState.Closed Then
            connection.Close()
        End If
    End Sub
End Class