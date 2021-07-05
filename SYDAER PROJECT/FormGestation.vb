Imports System.Data.SqlClient
Public Class FormGestation
    Public connection As New SqlConnection("server=DESKTOP-R8C69DV; DataBase= SYDAER; integrated security= True")
    Public command As New SqlCommand
    Public datareader As SqlDataReader

    Public Sub Connexion()
        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Public Sub cmbload()
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT code_Vache FROM Vache"
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            While (datareader.Read)
                ComboBox1.Items.Add(datareader(0))
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
    End Sub

    Public Sub dgvLoad()
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT * FROM GESTATION"
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

    Private Sub FormGestation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvLoad()
        cmbload()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim thisDate As Date
        thisDate = Today


        If (TextBox1.Text = "" Or ComboBox1.Text = "") Then
            MessageBox.Show("remplir les champs requis!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If (Format(DateTimePicker1.Value, "yyyy-M-dd") > thisDate) Then
                MessageBox.Show("la date ne doit pas être postérieure à la date d'aujourd'hui!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Try
                    Connexion()
                    command.Connection = connection
                    command.CommandText = "INSERT INTO Gestation VALUES ('" & TextBox1.Text & "','" & Format(DateTimePicker1.Value, "yyyy-M-dd") & "','" & TextBox3.Text & "','" & ComboBox1.Text & "');"
                    command.CommandType = CommandType.Text
                    Dim i As Integer = command.ExecuteNonQuery()
                    If (i = 1) Then
                        MsgBox("Gestation a été ajouté avec succès")
                        connection.Close()
                        dgvLoad()
                    Else
                        MessageBox.Show("Gestation n'est pas été ajouté", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
                End Try
                connection.Close()
            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "UPDATE Gestation SET  date_Dernier_Velage = '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "', observation = '" & TextBox3.Text & "', code_Vache = '" & ComboBox1.Text & "' WHERE code_Gestation = '" & TextBox1.Text & "'"
            command.CommandType = CommandType.Text
            Dim i As Integer = command.ExecuteNonQuery()
            If (i = 1) Then
                MsgBox(" a Modefier avec succès")
            Else
                MessageBox.Show("Taureau n'est Modefier ajouté", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
        dgvLoad()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT * FROM Gestation WHERE code_Gestation = '" & TextBox1.Text & "'"
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            datareader.Read()
            DateTimePicker1.Value = datareader(1)
            TextBox3.Text = datareader(2)
            ComboBox1.Text = datareader(3)
        Catch ex As Exception

        End Try
        connection.Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim dialog As DialogResult
        dialog = MessageBox.Show("êtes-vous sûr de supprimer", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialog = DialogResult.Yes Then
            Try
                Connexion()
                command.Connection = connection
                command.CommandText = "DELETE FROM Gestation WHERE code_gestation = '" & TextBox1.Text & "';"
                command.CommandType = CommandType.Text
                Dim i As Integer = command.ExecuteNonQuery()
                connection.Close()
                If (i = 1) Then
                    MsgBox("Gestation a Modefier avec succès")
                    dgvLoad()
                Else
                    MessageBox.Show("gestation n'est Modefier ajouté", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            End Try
            connection.Close()
        End If
    End Sub
End Class