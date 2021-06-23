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
    Public Sub txtload()
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = " SELECT MAX(code_Visite_Tech) FROM VISITE_TECHNIQUE"
            command.CommandType = CommandType.Text
            Dim I As Integer = command.ExecuteScalar
            TextBox2.Text = I + 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
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
        dgvLoad()
        txtload()
    End Sub

    Private Sub Visit_Tech_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Mainpage.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "INSERT INTO VISITE_TECHNIQUE VALUES ('" & TextBox4.Text & "','" & TextBox3.Text & "','" & TextBox1.Text & "')"
            command.CommandType = CommandType.Text
            Dim i As Integer = command.ExecuteNonQuery()
            If (i = 1) Then
                MsgBox("Visite Technique a été ajouté avec succès")
                connection.Close()
                dgvLoad()
                txtload()
            Else
                MessageBox.Show("Visite Technique n'est pas été ajouté", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "UPDATE VISITE_TECHNIQUE SET recomendation = '" & TextBox4.Text & "', observation = '" & TextBox3.Text & "' WHERE code_Visite_Tech = " & TextBox2.Text & ""
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
            TextBox4.Text = datareader(1)
            TextBox3.Text = datareader(2)
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
End Class