Imports System.Data.SqlClient
Public Class Insemination
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
            command.CommandText = " SELECT MAX(code_Insemination) FROM Insemination"
            command.CommandType = CommandType.Text
            Dim I As Integer = command.ExecuteScalar
            TextBox1.Text = I + 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
    End Sub

    Public Sub cmbload()
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT * FROM TAUREAU"
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
            command.CommandText = "SELECT * FROM INSEMINATION WHERE code_Gestation ='" & TextBox6.Text & "';"
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


    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        TAUREAU.Show()
    End Sub

    Private Sub Insemination_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "select count(code_Vilage) from VILAGE where code_Gestation = '" & TextBox1.Text & "';"
            command.CommandType = CommandType.Text
            Dim i As Integer = command.ExecuteScalar
            If (i <> 0) Then
                MessageBox.Show("Cette gestation est déjà terminée!", "error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Button9.Enabled = False
                Button8.Enabled = False
                Button3.Enabled = False
                Button4.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()



        dgvLoad()
        txtload()
        cmbload()
    End Sub

    Private Sub Insemination_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Mainpage.Show()
        Me.Hide()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim thisDate As Date
        thisDate = Today

        If (TextBo4.Text = "" Or TextBox6.Text = "" Or ComboBox1.Text = "") Then
            MessageBox.Show("remplir les champs requis!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If (Format(DateTimePicker2.Value, "yyyy-M-dd") > thisDate) Then
                MessageBox.Show("la date ne doit pas être postérieure à la date d'aujourd'hui!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Try
                    Connexion()
                    command.Connection = connection
                    command.CommandText = "UPDATE VISITE_TECHNIQUE set recomendation = 0 where  code_Gestation = '" & TextBox6.Text & "';"
                    command.CommandType = CommandType.Text
                    command.ExecuteNonQuery()

                    command.CommandText = "INSERT INTO INSEMINATION VALUES('" & TextBo4.Text & "','" & Format(DateTimePicker2.Value, "yyyy-M-dd") & "', '" & TextBox5.Text & "','" & TextBox2.Text & "', '" & ComboBox1.Text & "','" & TextBox3.Text & "','" & TextBox7.Text & "','" & TextBox6.Text & "');"
                    command.CommandType = CommandType.Text
                    Dim i As Integer = command.ExecuteNonQuery()
                    If (i = 1) Then
                        MsgBox("Insemination a été ajouté avec succès")
                        connection.Close()
                        dgvLoad()
                        txtload()
                    Else
                        MessageBox.Show("Insemination n'est pas été ajouté", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            command.CommandText = "SELECT * FROM INSEMINATION WHERE code_Insemination = '" & TextBox1.Text & "'"
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            datareader.Read()
            TextBox1.Text = datareader(0)
            TextBo4.Text = datareader(1)
            DateTimePicker2.Value = datareader(2)
            TextBox5.Text = datareader(3)
            TextBox2.Text = datareader(4)
            TextBox3.Text = datareader(6)
            ComboBox1.Text = datareader(5)
            TextBox7.Text = datareader(7)
            TextBox6.Text = datareader(8)
        Catch ex As Exception

        End Try
        connection.Close()
    End Sub

    Private Sub TextBo4_TextChanged(sender As Object, e As EventArgs) Handles TextBo4.TextChanged

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "update INSEMINATION set cirtificat_Insemination = '" & TextBo4.Text & "', date_Insemination = '" & Format(DateTimePicker2.Value, "yyyy-M-dd") & "', order_Insemination = '" & TextBox5.Text & "', nature_Chaleur = '" & TextBox2.Text & "', code_Taureau = '" & ComboBox1.Text & "', hormone_Utulisee = '" & TextBox3.Text & "', Observation = '" & TextBox7.Text & "', code_Gestation = '" & TextBox6.Text & "' WHERE code_Insemination = '" & TextBox1.Text & "' ;"
            command.CommandType = CommandType.Text
            Dim i As Integer = command.ExecuteNonQuery()
            If (i = 1) Then
                MsgBox("Insemination a Modefier avec succès")
            Else
                MessageBox.Show("Insemination n'est Modefier ajouté", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                command.CommandText = "DELETE FROM INSEMINATION WHERE code_Insemination = '" & TextBox1.Text & "';"
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

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged

    End Sub
End Class