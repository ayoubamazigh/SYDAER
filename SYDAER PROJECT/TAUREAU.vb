Imports System.Data.SqlClient
Public Class TAUREAU
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
            command.CommandText = "SELECT code_Race FROM Race"
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
            command.CommandText = "SELECT * FROM Taureau"
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            Dim table As New DataTable
            table.Load(datareader)
            datareader.Close()
            dgv.DataSource = table
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
    End Sub

    Private Sub TAUREAU_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvLoad()
        cmbload()
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "INSERT INTO Taureau VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox3.Text & "'); "
            command.CommandType = CommandType.Text
            Dim i As Integer = command.ExecuteNonQuery()
            If (i = 1) Then
                MsgBox("TAUREAU a été ajouté avec succès")
            Else
                MessageBox.Show("Taureau n'est pas été ajouté", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
        dgvLoad()
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "Update TAUREAU Set nom_Taureau ='" & TextBox2.Text & "', code_Race = '" & ComboBox1.Text & "', categorie = '" & TextBox4.Text & "', type_de_Pallaitte ='" & TextBox5.Text & "', origine = '" & TextBox3.Text & "' WHERE code_Taureau = '" & TextBox1.Text & "';"

            command.CommandType = CommandType.Text
            Dim i As Integer = command.ExecuteNonQuery()
            If (i = 1) Then
                MsgBox("Taureau a Modefier avec succès")
            Else
                MessageBox.Show("Taureau n'est Modefier ajouté", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
        dgvLoad()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Race.Show()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Origine.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT * FROM Taureau WHERE code_Taureau = '" & TextBox1.Text & "';"
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            datareader.Read()
            TextBox2.Text = datareader(1)
            ComboBox1.Text = datareader(2)
            TextBox4.Text = datareader(3)
            TextBox5.Text = datareader(4)
            TextBox3.Text = datareader(5)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
    End Sub

    Private Sub btnsupp_Click(sender As Object, e As EventArgs) Handles btnsupp.Click
        Dim dialog As DialogResult
        dialog = MessageBox.Show("êtes-vous sûr de supprimer", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialog = DialogResult.Yes Then
            Try
                Connexion()
                command.Connection = connection
                command.CommandText = "DELETE TAUREAU WHERE code_Taureau = '" & TextBox1.Text & "';"
                command.CommandType = CommandType.Text
                Dim i As Integer = command.ExecuteNonQuery()
                connection.Close()
                If (i = 1) Then
                    MsgBox("Zone a Modefier avec succès")
                    dgvLoad()
                Else
                    MessageBox.Show("Zone n'est Modefier ajouté", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            End Try
            connection.Close()
        End If
    End Sub

End Class