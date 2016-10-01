Public Class Form2

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            My.Settings.account = TextBox1.Text
            My.Settings.Save()

            Form1.Steemapi()

            Try
                'steemit name to username
                Form1.Label8.Text = "@ " & TextBox1.Text
                Form3.Label8.Text = "@ " & TextBox1.Text
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim result As Integer = MessageBox.Show("Exit Application?", "Warning", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                'MessageBox.Show("No pressed")
            ElseIf result = DialogResult.Yes Then
                'MessageBox.Show("Yes pressed")
                End
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'home
        Try
            If TextBox1.Text = "" Then
                Process.Start("https://steemit.com")

            Else
                Process.Start("https://steemit.com/@" & TextBox1.Text & "/feed")

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'new
        Try
            Process.Start("https://steemit.com/created")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'wallet
        Try
            If TextBox1.Text = "" Then
                Process.Start("https://steemit.com")

            Else
                Process.Start("https://steemit.com/@" & TextBox1.Text & "/transfers")

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Try
            If RadioButton2.Checked = True Then
                Form1.Hide()
                Form3.Show()

                Form1.Label9.Text = 2

            ElseIf RadioButton2.Checked = False Then
                Form3.Hide()
                Form1.Show()

                Form1.Label9.Text = 1
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class