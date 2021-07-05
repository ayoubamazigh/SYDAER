Imports System.Data.SqlClient
Public Class Visit_Tech
    Public connection As New SqlConnection("server=DESKTOP-R8C69DV; DataBase= SYDAER; integrated security= True")
    Public command As New SqlCommand
    Public datareader As SqlDataReader
    Public datareader2 As SqlDataReader

    Public Sub Connexion()
        Try
            connection.Open()
        Catch ex As Exception
        End Try
    End Sub



    Public Sub dgvLoad()
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT * FROM VISITE_TECHNIQUE WHERE code_Gestation = '" & TextBox1.Text & "'"
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



    Private Sub Visit_Tech_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "select count(code_Vilage) from VILAGE where code_Gestation = '" & TextBox1.Text & "';"
            command.CommandType = CommandType.Text
            Dim i As Integer = command.ExecuteScalar
            If (i <> 0) Then
                MessageBox.Show("Cette gestation est déjà terminée!", "error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Button5.Enabled = False
                Button6.Enabled = False
                Button7.Enabled = False
                Button2.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
        dgvLoad()
    End Sub

    Private Sub Visit_Tech_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Mainpage.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim recomendation As String
        Dim thisDate As Date
        thisDate = Today

        If (RadioButton1.Checked) Then
            recomendation = "1"
        Else
            recomendation = "0"
        End If

        If (TextBox1.Text = "" Or (RadioButton1.Checked = False And RadioButton2.Checked = False)) Then
            MessageBox.Show("remplir les champs requis!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If (Format(DateTimePicker1.Value, "yyyy-M-dd") > thisDate) Then
                MessageBox.Show("la date ne doit pas être postérieure à la date d'aujourd'hui!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Try
                    Connexion()
                    command.Connection = connection
                    command.CommandText = "UPDATE VISITE_TECHNIQUE set recomendation = 0 where  code_Gestation = '" & TextBox1.Text & "';"
                    command.CommandType = CommandType.Text
                    command.ExecuteNonQuery()

                    command.CommandText = "INSERT INTO VISITE_TECHNIQUE VALUES ('" & recomendation & "','" & TextBox3.Text & "','" & TextBox1.Text & "','" & Format(DateTimePicker1.Value, "yyyy-M-dd") & "')"
                    command.CommandType = CommandType.Text
                    Dim i As Integer = command.ExecuteNonQuery()
                    If (i = 1) Then
                        MsgBox("Visite Technique a été ajouté avec succès")
                        connection.Close()
                        dgvLoad()
                    Else
                        MessageBox.Show("Visite Technique n'est pas été ajouté", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
                End Try
                connection.Close()
            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim recomendation As String

        If (RadioButton1.Checked) Then
            recomendation = "1"
        Else
            recomendation = "0"
        End If


        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "UPDATE VISITE_TECHNIQUE SET recomendation = '" & recomendation & "', observation = '" & TextBox3.Text & "', date_Visit_Tech = '" & Format(DateTimePicker1.Value, "yyyy-M-dd") & "' WHERE code_Visite_Tech = " & TextBox2.Text & ""
            command.CommandType = CommandType.Text
            Dim i As Integer = command.ExecuteNonQuery()
            If (i = 1) Then
                MsgBox("Visit technique a Modefier avec succès")
            Else
                MessageBox.Show("Visit technique n'est Modefier", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            command.CommandText = "select * from VISITE_TECHNIQUE WHERE code_Visite_Tech = " & TextBox2.Text
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            datareader.Read()
            If (datareader(1) = "1") Then
                RadioButton1.Checked = True
            Else
                RadioButton2.Checked = True
            End If
            TextBox3.Text = datareader(2)
            DateTimePicker1.Value = datareader(4)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dialog As DialogResult
        dialog = MessageBox.Show("êtes-vous sûr de supprimer", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialog = DialogResult.Yes Then
            Try
                Connexion()
                command.Connection = connection
                command.CommandText = "DELETE FROM VISITE_TECHNIQUE WHERE code_Visite_Tech = " & TextBox2.Text
                command.CommandType = CommandType.Text
                Dim i As Integer = command.ExecuteNonQuery()
                connection.Close()
                If (i = 1) Then
                    MsgBox("Visite tech a Modefier avec succès")
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

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class