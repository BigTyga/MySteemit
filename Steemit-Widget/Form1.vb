Imports Newtonsoft.Json
Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Linq
Imports System.Text.RegularExpressions

Public Class Form1
    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer

    'math
    Public score As Decimal = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Form2.TextBox1.Text = My.Settings.account
            My.Settings.Reload()

            Try
                'steemit name to username
                Label8.Text = "@ " & Form2.TextBox1.Text
                Form3.Label8.Text = "@ " & Form2.TextBox1.Text
            Catch ex As Exception

            End Try

            Steemapi()
        Catch ex As Exception

        End Try

    End Sub

#Region "STEEMIT SYMBOL"

    Public Sub steemiturl()
        Process.Start("https://steemit.com")
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            'reload account name
            Form2.TextBox1.Text = My.Settings.account
            My.Settings.Reload()

            'design layout
            Try
                If Label9.Text = 1 Then 'design #1
                    Form2.RadioButton2.Checked = False

                ElseIf Label9.Text = 2 Then 'design #2
                    Form2.RadioButton2.Checked = True
                End If

            Catch ex As Exception

            End Try


            'show form2
            Form2.Show()
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "API"

    Public Sub Steemapi()

        Try
            'reload account name
            Form2.TextBox1.Text = My.Settings.account
            My.Settings.Reload()
        Catch ex As Exception

        End Try

        Try
            'work
            Dim wrGtUrl As WebRequest
            Dim uri As String = "https://api.steemjs.com/getAccounts?names[]=" & Form2.TextBox1.Text

            wrGtUrl = WebRequest.Create(uri)
            Dim streamResponse As Stream = wrGtUrl.GetResponse().GetResponseStream
            Dim streamReader As StreamReader = New StreamReader(streamResponse)
            Dim sJson = streamReader.ReadToEnd
            Console.WriteLine(sJson)

            'Dim json = JsonConvert.DeserializeObject(Of SteemitAPI.steem_api)(sJson)
            'Dim newjson As Object = sJson.Replace("[", "").Replace("]", "")

            Dim j As Object = JsonConvert.DeserializeObject(Of Object)(sJson)

            Dim a = j(0)
            Dim b = a.ToString()

            Dim result = JsonConvert.DeserializeObject(b)
            Label4.Text = ""
            Label4.Text = result("sbd_balance")

            Label5.Text = ""
            Label5.Text = result("balance")

            Label6.Text = ""
            Dim xx As Decimal = result("voting_power") / 100
            Dim xxx As String = Decimal.Round(xx)
            Label6.Text = xxx

            'design #2 
            'voting power
            Form3.Label6.Text = ""
            Form3.Label6.Text = xxx


            'Dim str As String = result("voting_power")
            'Label6.Text = str.Remove(str.Length - 2)


            Try
                score = result("reputation")
                Dim x = CountRate(score)

                Label7.Text = ""
                Label7.Text = x

                'Desing #2
                'reputation
                Form3.Label7.Text = ""
                Form3.Label7.Text = x

            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Timer"
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Try
            Steemapi()
        Catch ex As Exception

        End Try
        Timer1.Enabled = True
    End Sub
#End Region

#Region " MouseDown/ up / move"
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Label3.MouseDown, PictureBox1.MouseDown, MyBase.MouseDown, Label7.MouseDown, Label6.MouseDown, Label5.MouseDown, Label4.MouseDown, Label2.MouseDown, Label1.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Label3.MouseUp, PictureBox1.MouseUp, MyBase.MouseUp, Label7.MouseUp, Label6.MouseUp, Label5.MouseUp, Label4.MouseUp, Label2.MouseUp, Label1.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Label3.MouseMove, PictureBox1.MouseMove, MyBase.MouseMove, Label7.MouseMove, Label6.MouseMove, Label5.MouseMove, Label4.MouseMove, Label2.MouseMove, Label1.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub
#End Region

#Region "Math it up (rep score)"
    Sub Main()
        Dim a As String
        a = "12,205,992,685,331"
        Console.WriteLine(CountRate(a))
        Console.ReadLine()

    End Sub

    Public Function CountRate(ByVal rate As String)
        Dim newRate As Double
        rate = rate.Replace(",", "")
        rate = Math.Log10(rate)
        rate -= 9
        rate *= 9
        rate += 25
        newRate = CDbl(rate)
        Return (Math.Floor(newRate))
    End Function
#End Region

#Region "Steemit.com"
    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Try
            Process.Start("https://steemit.com")
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Mouse houver/leave"
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
#End Region

End Class

