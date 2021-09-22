Imports System.Data.SqlClient
Public Class FormElveur
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
            Command.Connection = connection
            command.CommandText = "SELECT nom_Zone FROM ZONE"
            command.CommandType = CommandType.Text
            datareader = Command.ExecuteReader
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
            Command.Connection = connection
            command.CommandText = "SELECT code_Elveur, prenom_Elveur, nom_Elveur, adresse_Elveur,tele_Elveur,particularite, nom_zone from elveur,zone where zone.code_Zone = ELVEUR.code_Zone"
            command.CommandType = CommandType.Text
            datareader = Command.ExecuteReader
            Dim table As New DataTable
            table.Load(datareader)
            datareader.Close()
            dgv.DataSource = table
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
    End Sub

    Private Sub FormElveur_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbload()
        dgvLoad()
    End Sub
    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Formzone.Show()
    End Sub

    Private Sub FormElveur_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Main.Show()
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Dim count As Integer

        If (TextBox1.Text = "" Or ComboBox1.Text = "") Then
            MessageBox.Show("remplir les champs requis!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            Try
                Connexion()
                command.Connection = connection
                command.CommandText = "SELECT count(*) FROM ELVEUR WHERE tele_Elveur = '" & TextBox5.Text & "';"
                command.CommandType = CommandType.Text
                count = command.ExecuteScalar()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            End Try
            connection.Close()



            If (count = 0) Then
                Try
                    Connexion()
                    command.Connection = connection
                    command.CommandText = "INSERT INTO ELVEUR VALUES ('" & TextBox1.Text & "','" & TextBox3.Text & "','" & TextBox2.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "',(SELECT code_zone from ZONE where nom_zone = '" & ComboBox1.Text & "'));"
                    command.CommandType = CommandType.Text
                    Dim i As Integer = command.ExecuteNonQuery()
                    If (i = 1) Then
                        MsgBox("Elveur a été ajouté avec succès")
                        connection.Close()
                        dgvLoad()
                    Else
                        MessageBox.Show("Elveur n'est pas été ajouté", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
                End Try
                connection.Close()
            Else
                MessageBox.Show("ce numéro de téléphone existe déjà!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT code_Elveur, nom_Elveur, prenom_Elveur, adresse_Elveur,tele_Elveur,particularite, nom_zone from elveur,zone where zone.code_Zone = ELVEUR.code_Zone AND code_Elveur = '" & TextBox1.Text & "';"
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            datareader.Read()
            TextBox3.Text = datareader(1)
            TextBox2.Text = datareader(2)
            TextBox4.Text = datareader(3)
            TextBox5.Text = datareader(4)
            TextBox6.Text = datareader(5)
            ComboBox1.Text = datareader(6)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "UPDATE ELVEUR SET code_Elveur = '" & TextBox1.Text & "', prenom_Elveur = '" & TextBox2.Text & "', nom_Elveur = '" & TextBox3.Text & "', adresse_Elveur = '" & TextBox4.Text & "', tele_Elveur = '" & TextBox5.Text & "', particularite = '" & TextBox6.Text & "', code_Zone = (SELECT code_Zone FROM ZONE WHERE nom_Zone = '" & ComboBox1.Text & "') WHERE code_ELVEUR ='" & TextBox1.Text & "';"
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

    Private Sub btnsupp_Click(sender As Object, e As EventArgs) Handles btnsupp.Click
        Dim dialog As DialogResult
        dialog = MessageBox.Show("êtes-vous sûr de supprimer", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialog = DialogResult.Yes Then
            Try
                Connexion()
                command.Connection = connection
                command.CommandText = "DELETE FROM ELVEUR WHERE code_Elveur = '" & TextBox1.Text & "';"
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

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub elveur_Enter(sender As Object, e As EventArgs) Handles elveur.Enter

    End Sub
End Class