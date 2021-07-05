Imports System.Data.SqlClient
Public Class Vilage
    Public connection As New SqlConnection("server=DESKTOP-R8C69DV; DataBase= SYDAER; integrated security= True")
    Public command As New SqlCommand
    Public datareader As SqlDataReader

    Public Sub Connexion()
        Try
            connection.Open()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub txtload()
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT MAX(code_Vilage) FROM Vilage"
            command.CommandType = CommandType.Text
            Dim I As Integer = command.ExecuteScalar
            TextBox1.Text = I + 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
    End Sub

    Public Sub dgvLoad()
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT * FROM Vilage where code_Gestation = '" & TextBox4.Text & "';"
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            Dim table As New DataTable
            table.Load(datareader)
            datareader.Close()
            DataGridView1.DataSource = table
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        If (TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "") Then
            MessageBox.Show("remplir les champs requis!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Try
                Connexion()
                command.Connection = connection
                command.CommandText = "INSERT INTO VILAGE VALUES ('" & TextBox2.Text & "', '" & TextBox3.Text & "','" & TextBox5.Text & "', '" & TextBox4.Text & "');"
                command.CommandType = CommandType.Text
                Dim i As Integer = command.ExecuteNonQuery()
                If (i = 1) Then
                    MsgBox("Vilage a été ajouté avec succès")
                    connection.Close()
                    dgvLoad()
                Else
                    MessageBox.Show("Vilage n'est pas été ajouté", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            End Try
            connection.Close()
        End If
    End Sub

    Private Sub Vilage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Mainpage.Show()
        Me.Hide()
    End Sub

    Private Sub Vilage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvLoad()
        txtload()
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "select * from Vilage where code_Vilage = " & TextBox1.Text
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            datareader.Read()

            TextBox1.Text = datareader(0)
            TextBox2.Text = datareader(1)
            TextBox3.Text = datareader(2)
            TextBox5.Text = datareader(3)

        Catch ex As Exception

        End Try
        connection.Close()
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "UPDATE VILAGE SET rang_Vilage = '" & TextBox2.Text & "', type_de_Vilage = '" & TextBox3.Text & "', observation = '" & TextBox5.Text & "' WHERE code_Vilage =" & TextBox1.Text
            command.CommandType = CommandType.Text
            Dim i As Integer = command.ExecuteNonQuery()
            If (i = 1) Then
                MsgBox("Vilage a Modefier avec succès")
            Else
                MessageBox.Show("Vilage n'est Modefier ajouté", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
        dgvLoad()
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Dim dialog As DialogResult
        dialog = MessageBox.Show("êtes-vous sûr de supprimer", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialog = DialogResult.Yes Then
            Try
                Connexion()
                command.Connection = connection
                command.CommandText = "DELETE FROM Vilage WHERE code_Vilage = " & TextBox1.Text
                command.CommandType = CommandType.Text
                Dim i As Integer = command.ExecuteNonQuery()
                connection.Close()
                If (i = 1) Then
                    MsgBox("Insemination a Modefier avec succès")
                    dgvLoad()
                Else
                    MessageBox.Show("Insemination n'est Modefier ajouté", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            End Try
            connection.Close()
        End If
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class