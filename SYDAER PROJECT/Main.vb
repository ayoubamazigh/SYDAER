Imports System.Data.SqlClient
Public Class Main
    Public connection As New SqlConnection("server=DESKTOP-R8C69DV; DataBase= SYDAER; integrated security= True")
    Public command As New SqlCommand
    Public datareader As SqlDataReader

    Public Sub Connexion()
        Try
            connection.Open()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub dgv1Load()
        Dim thisDate As Date
        thisDate = Today
        thisDate = thisDate.AddMonths(-1)

        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "select  VISITE_TECHNIQUE.date_visit_tech as 'Date Visite tech', VISITE_TECHNIQUE.code_Gestation as 'Code de la Gestation', vache.code_Vache as 'Code de la Vache', ELVEUR.code_Elveur as 'Code d''Elveur',ELVEUR.prenom_Elveur + ' ' + ELVEUR.nom_Elveur as 'Nom d''elveur ', ELVEUR.tele_Elveur as 'Telephone d''Elveur' from VISITE_TECHNIQUE, GESTATION, VACHE, ELVEUR where VISITE_TECHNIQUE.code_Gestation = GESTATION.code_Gestation and GESTATION.code_Vache = VACHE.code_Vache and vache.code_Elveur = ELVEUR.code_Elveur and date_Visit_Tech > '" & thisDate & "' and recomendation = '1' order by date_Visit_Tech"
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

    Public Sub dgv2Load()
        Dim thisDate As Date
        thisDate = Today
        thisDate = thisDate.AddMonths(-2)


        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT cirtificat_Insemination as 'Cirtificat', date_Insemination as 'Date d''insemination', TAUREAU.nom_Taureau as 'Nom Taureau' , gestation.code_Gestation as 'Code Gestation', vache.code_Vache as 'Code Vache', ELVEUR.code_Elveur as 'Code Elvuer', ELVEUR.prenom_Elveur + ' ' + ELVEUR.nom_Elveur as 'Nom Elveur', ELVEUR.tele_Elveur as 'Telephone' FROM INSEMINATION,VACHE,GESTATION, ELVEUR,TAUREAU where GESTATION.code_Vache = VACHE.code_Vache and VACHE.code_Elveur = ELVEUR.code_Elveur and INSEMINATION.code_Taureau = TAUREAU.code_Taureau and date_Insemination > '2021-04-30' and code_Insemination NOT IN (select code_Insemination from DIAGNOSTIQUE);"
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        FormElveur.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Mainpage.Show()
        Me.Hide()
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Voulez-vous vraiment quitter", "Quitter", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialog = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv1Load()
        dgv2Load()

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        FormElveur.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        FormElveur.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        FormVache.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        FormVache.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Mainpage.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        analyse.Show()
        Me.Hide()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class