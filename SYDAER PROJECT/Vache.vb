Imports System.Data.SqlClient
Public Class FormVache
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
    Public Sub cmbeload()
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT code_Elveur FROM Elveur"
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            While (datareader.Read)
                ComboBox2.Items.Add(datareader(0))
            End While
            datareader.Close()
        Catch ex As Exception
        End Try
        connection.Close()
    End Sub

    Public Sub cmbrload()
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT name_Race FROM RACE"
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            While (datareader.Read)
                ComboBox1.Items.Add(datareader(0))
            End While
            datareader.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
    End Sub

    Public Sub dgvLoad()
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT * FROM VACHE"
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

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Race.Show()
    End Sub
    Private Sub FormVache_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Main.Show()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        FormElveur.Show()
    End Sub

    Private Sub FormVache_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbeload()
        cmbrload()
        dgvLoad()
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Dim thisDate As Date
        thisDate = Today

        If (TextBox1.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "") Then
            MessageBox.Show("remplir les champs requis!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If (Format(dtp.Value, "yyyy-M-dd") > thisDate) Then
                MessageBox.Show("la date ne doit pas être postérieure à la date d'aujourd'hui!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Try
                    Connexion()
                    command.Connection = connection
                    command.CommandText = "INSERT INTO VACHE VALUES ('" & TextBox1.Text & "',(SELECT code_Race FROM RACE WHERE name_Race ='" & ComboBox1.Text & "'),' " & Format(dtp.Value, "yyyy-M-dd") & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox2.Text & "','" & TextBox6.Text & "')
"
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
            End If
        End If
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT (SELECT name_Race FROM RACE, Vache WHERE Race.code_Race = Vache.code_Race and code_Vache ='" & TextBox1.Text & "'), date_Naissance_Vache, Origine, grand_pere_M_Vache, pere_Vache, mere_Vache, code_Elveur ,Observation FROM VACHE WHERE code_Vache = '" & TextBox1.Text & "'"
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            datareader.Read()
            ComboBox1.Text = datareader(0)
            dtp.Value = datareader(1)
            TextBox2.Text = datareader(2)
            TextBox3.Text = datareader(3)
            TextBox4.Text = datareader(4)
            TextBox5.Text = datareader(5)
            TextBox6.Text = datareader(7)
            ComboBox2.Text = datareader(6)
        Catch ex As Exception

        End Try
        connection.Close()
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT prenom_Elveur + ' ' + nom_Elveur From Elveur WHERE code_Elveur = '" & ComboBox2.Text & "';"
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            While (datareader.Read)
                TextBox7.Text = datareader(0)
            End While
            datareader.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "UPDATE Vache SET code_Race = (SELECT code_Race FROM RACE WHERE name_Race = '" & ComboBox1.Text & "'), date_Naissance_Vache = '" & Format(dtp.Value, "yyyy-MM-dd") & "', Origine = '" & TextBox2.Text & "', grand_pere_M_Vache = '" & TextBox3.Text & "', pere_Vache = '" & TextBox4.Text & "', mere_Vache = '" & TextBox5.Text & "', code_Elveur = '" & ComboBox2.Text & "', Observation = '" & TextBox6.Text & "' WHERE code_Vache ='" & TextBox1.Text & "';"
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

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Dim dialog As DialogResult
        dialog = MessageBox.Show("êtes-vous sûr de supprimer", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialog = DialogResult.Yes Then
            Try
                Connexion()
                command.Connection = connection
                command.CommandText = "DELETE FROM Vache WHERE code_vache = '" & TextBox1.Text & "';"
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

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class