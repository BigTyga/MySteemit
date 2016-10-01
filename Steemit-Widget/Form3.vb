Public Class Form3
    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            'reload account name
            Form2.TextBox1.Text = My.Settings.account
            My.Settings.Reload()

            'design layout
            Try
                If Form1.Label9.Text = 1 Then 'design #1
                    Form2.RadioButton2.Checked = False

                ElseIf Form1.Label9.Text = 2 Then 'design #2
                    Form2.RadioButton2.Checked = True
                End If

            Catch ex As Exception

            End Try

            'show form2
            Form2.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Try
            Process.Start("https://steemit.com")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label8_MouseHover(sender As Object, e As EventArgs) Handles Label8.MouseHover
        Try
            Label8.ForeColor = Color.Red
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label8_MouseLeave(sender As Object, e As EventArgs) Handles Label8.MouseLeave
        Try
            Label8.ForeColor = Color.Black
        Catch ex As Exception

        End Try
    End Sub

#Region " MouseDown/ up / move"
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Label3.MouseDown, PictureBox1.MouseDown, MyBase.MouseDown, Label7.MouseDown, Label6.MouseDown, Label1.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Label3.MouseUp, PictureBox1.MouseUp, MyBase.MouseUp, Label7.MouseUp, Label6.MouseUp, Label1.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Label3.MouseMove, PictureBox1.MouseMove, MyBase.MouseMove, Label7.MouseMove, Label6.MouseMove, Label1.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub
#End Region
End Class