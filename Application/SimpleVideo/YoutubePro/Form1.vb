Imports System.Collections.Specialized

Public Class Form1
    Dim YoutuberNames As StringCollection = New StringCollection
    Dim YoutuberLinks As StringCollection = New StringCollection

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Settings.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        YoutuberLinks = My.Settings.YoutuberLinks
        YoutuberNames = My.Settings.YoutuberNames

        Dim index As Integer
        Dim realIndex As Integer
        Do Until index = YoutuberNames.Count
            If YoutuberNames.Item(index) = TextBox1.Text Then
                realIndex = index
            End If

            index += 1
        Loop


        If My.Settings.InAppBrowser Then
            WebBrowser1.Navigate(YoutuberLinks.Item(realIndex))
        Else
            On Error Resume Next
            Process.Start(YoutuberLinks.Item(realIndex))
        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        YoutuberLinks = My.Settings.YoutuberLinks
        YoutuberNames = My.Settings.YoutuberNames

        Dim index As Integer
        Dim realIndex As Integer
        Do Until index = YoutuberNames.Count
            If YoutuberNames.Item(index) = TextBox1.Text Then
                realIndex = index
            End If

            index += 1
        Loop
        If My.Settings.InAppBrowser Then
            WebBrowser1.Navigate(YoutuberLinks.Item(realIndex) + "/search?query=" + TextBox2.Text)
        Else
            On Error Resume Next
            Process.Start(YoutuberLinks.Item(realIndex) + "/search?query=" + TextBox2.Text)
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If My.Settings.InAppBrowser Then
            WebBrowser1.Visible = True
            If Me.Height < 540 Then
                Me.Size = New System.Drawing.Size(844, 540)
                Me.MaximizeBox = True

            End If

        Else
            WebBrowser1.Visible = False
            Me.Size = New System.Drawing.Size(844, 94)
            Me.MaximizeBox = False
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub
End Class
