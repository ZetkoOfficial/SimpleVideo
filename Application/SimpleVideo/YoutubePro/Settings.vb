Imports System.Collections.Specialized

Public Class Settings
    Dim YoutuberNames As StringCollection = New StringCollection
    Dim YoutuberLinks As StringCollection = New StringCollection

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        YoutuberNames = My.Settings.YoutuberNames
        YoutuberLinks = My.Settings.YoutuberLinks

        AddYoutuber.ShowDialog()
        Dim tempName As String = AddYoutuber.TextBox1.Text
        Dim tempLink As String = AddYoutuber.TextBox2.Text
        YoutuberNames.Add(tempName)
        YoutuberLinks.Add(tempLink)

        My.Settings.YoutuberNames = YoutuberNames
        My.Settings.YoutuberLinks = YoutuberLinks

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()

        For Each Item In My.Settings.YoutuberNames
            ListBox1.Items.Add(Item)
        Next

        For Each Item In My.Settings.YoutuberLinks
            ListBox2.Items.Add(Item)
        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ListBox2.SelectedIndex = ListBox1.SelectedIndex
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        YoutuberNames = My.Settings.YoutuberNames
        YoutuberLinks = My.Settings.YoutuberLinks


        If ListBox1.SelectedItem = "-" Then
        Else

            On Error Resume Next
            YoutuberNames.RemoveAt(ListBox1.SelectedIndex)
            On Error Resume Next
            YoutuberLinks.RemoveAt(ListBox1.SelectedIndex)
        End If


        My.Settings.YoutuberNames = YoutuberNames
        My.Settings.YoutuberLinks = YoutuberLinks
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        ListBox1.SelectedIndex = ListBox2.SelectedIndex
    End Sub

    Private Sub Settings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.InAppBrowser = CheckBox1.Checked
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckBox1.Checked = My.Settings.InAppBrowser
    End Sub
End Class