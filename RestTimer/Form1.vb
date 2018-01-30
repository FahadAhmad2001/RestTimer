Imports System.Threading
Public Class Form1
    Dim Status As String
    Dim maxTime As Integer
    Dim count As Integer
    Dim ShowProgress As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Status = "Stopped"
        TextBox1.Text = 30
        Timer1.Interval = 1000
        ShowProgress = "True"
        CheckBox1.Checked = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Status = "Stopped" Then
            count = 0
            Status = "Started"
            ProgressBar1.Maximum = maxTime
            Timer1.Start()
            'MsgBox(maxTime)
            Button1.Text = "Stop"
            GoTo EndChange
        End If
        If Status = "Started" Then

            Status = "Stopped"
            Timer1.Stop()
            count = 0
            ProgressBar1.Value = 0
            Button1.Text = "Start"
            GoTo EndChange
        End If
EndChange:
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        count = count + 1
        If ShowProgress = True Then
            ProgressBar1.Value = (maxTime - count)
        End If
        Label4.Text = "Time remaining: " & ((maxTime - count) / 60) & " minutes"
        If maxTime - count = 0 Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
            Timer1.Stop()
            count = 0
            ProgressBar1.Value = 0
            Button1.Text = "Start"
            Status = "Stopped"
            Label4.Text = "Time remaining: "
            MsgBox("Time to rest")
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        maxTime = TextBox1.Text * 60
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            ShowProgress = "True"
        Else
            ShowProgress = "False"
        End If
    End Sub
End Class
