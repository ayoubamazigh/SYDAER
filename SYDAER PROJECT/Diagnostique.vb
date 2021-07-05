Imports System.Data.SqlClient
Public Class Diagnostique
    Public connection As New SqlConnection("server=DESKTOP-R8C69DV; DataBase= SYDAER; integrated security= True")
    Public command As New SqlCommand
    Public datareader As SqlDataReader

    Public Sub Connexion()
        Try
            connection.Open()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub cmbload()
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT code_Insemination FROM Insemination WHERE code_Gestation = '" & TextBox6.Text & "'"
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
            command.CommandText = "SELECT * FROM Diagnostique"
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            Dim table As New DataTable
            table.Load(datareader)
            datareader.Close()
            DataGridView2.DataSource = table
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
    End Sub
    Private Sub Label15_Click(sender As Object, e As EventArgs)
        TAUREAU.Show()
    End Sub

    Private Sub Diagnostique_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "select count(code_Vilage) from VILAGE where code_Gestation = '" & TextBox1.Text & "';"
            command.CommandType = CommandType.Text
            Dim i As Integer = command.ExecuteScalar
            If (i <> 0) Then
                MessageBox.Show("Cette gestation est déjà terminée!", "error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Button9.Enabled = False
                Button3.Enabled = False
                Button4.Enabled = False
                Button8.Enabled = False
            End If
            dgvLoad()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()

        dgvLoad()
        cmbload()
    End Sub

    Private Sub Diagnostique_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Mainpage.Show()
        Me.Hide()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim thisDate As Date
        thisDate = Today

        If (ComboBox1.Text = "" Or TextBox6.Text = "") Then
            MessageBox.Show("remplir les champs requis!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If (Format(DateTimePicker1.Value, "yyyy-M-dd") > thisDate) Then
                MessageBox.Show("la date ne doit pas être postérieure à la date d'aujourd'hui!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Try
                    Connexion()
                    command.Connection = connection
                    command.CommandText = "INSERT INTO DIAGNOSTIQUE VALUES ('" & Format(DateTimePicker1.Value, "yyyy-M-dd") & "','" & TextBox2.Text & "','" & TextBox4.Text & "','" & ComboBox1.Text & "');"
                    command.CommandType = CommandType.Text
                    Dim i As Integer = command.ExecuteNonQuery()
                    If (i = 1) Then
                        MsgBox("Diagnostique a été ajouté avec succès")
                        connection.Close()
                        dgvLoad()
                    Else
                        MessageBox.Show("Diagnostique n'est pas été ajouté", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
                End Try
                connection.Close()
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT * FROM DIAGNOSTIQUE WHERE code_Diagnostique = '" & TextBox1.Text & "'"
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            datareader.Read()
            TextBox1.Text = datareader(0)
            DateTimePicker1.Value = datareader(1)
            TextBox2.Text = datareader(2)
            ComboBox1.Text = datareader(4)
            TextBox4.Text = datareader(3)
        Catch ex As Exception

        End Try
        connection.Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "UPDATE DIAGNOSTIQUE SET date_Diagnostique = '" & Format(DateTimePicker1.Value, "yyyy-M-dd") & "', type_Diagnostique = '" & TextBox2.Text & "', observation = '" & TextBox4.Text & "', code_Insemination = '" & ComboBox1.Text & "' where code_Diagnostique =  " & TextBox1.Text
            command.CommandType = CommandType.Text
            Dim i As Integer = command.ExecuteNonQuery()
            If (i = 1) Then
                MsgBox("Diagnostique a Modefier avec succès")
            Else
                MessageBox.Show("Diagnostique n'est Modefier ajouté", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
        dgvLoad()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dialog As DialogResult
        dialog = MessageBox.Show("êtes-vous sûr de supprimer", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialog = DialogResult.Yes Then
            Try
                Connexion()
                command.Connection = connection
                command.CommandText = "DELETE FROM DIAGNOSTIQUE WHERE code_Diagnostique = " & TextBox1.Text
                command.CommandType = CommandType.Text
                Dim i As Integer = command.ExecuteNonQuery()
                connection.Close()
                If (i = 1) Then
                    MsgBox("Diagnostique a Modefier avec succès")
                    dgvLoad()
                Else
                    MessageBox.Show("Diagnostique n'est Modefier ajouté", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            End Try
            connection.Close()
        End If
    End Sub
End Class