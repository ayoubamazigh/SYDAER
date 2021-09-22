Imports System.Data.SqlClient
Public Class analyse
    Public connection As New SqlConnection("server=DESKTOP-R8C69DV; DataBase= SYDAER; integrated security= True")
    Public command As New SqlCommand
    Public datareader As SqlDataReader

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
            command.CommandText = "SELECT code_insemination as 'Code Insemination' , cirtificat_Insemination as 'Cirtificat', date_Insemination as 'Date d''insemination', TAUREAU.nom_Taureau as 'Nom Taureau' , gestation.code_Gestation as 'Code Gestation', vache.code_Vache as 'Code Vache', ELVEUR.prenom_Elveur + ' ' + ELVEUR.nom_Elveur as 'Nom Elveur', ELVEUR.tele_Elveur as 'Telephone' FROM INSEMINATION,VACHE,GESTATION, ELVEUR,TAUREAU where GESTATION.code_Vache = VACHE.code_Vache and VACHE.code_Elveur = ELVEUR.code_Elveur and INSEMINATION.code_Taureau = TAUREAU.code_Taureau and date_Insemination > '2021-04-30' and code_Insemination NOT IN (select code_Insemination from DIAGNOSTIQUE);"
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


    Public Sub cmbtload()
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT code_Taureau from TAUREAU;"
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            While (datareader.Read)
                ComboBox3.Items.Add(datareader(0))
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
    End Sub

    Public Sub cmbeload()
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT code_Elveur FROM Elveur"
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            While (datareader.Read)
                ComboBox1.Items.Add(datareader(0))
            End While
            datareader.Close()
        Catch ex As Exception
        End Try
        connection.Close()
    End Sub


    Public Sub cmbvload()
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT code_Vache FROM Vache"
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            While (datareader.Read)
                ComboBox2.Items.Add(datareader(0))
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
    End Sub

    Private Sub analyse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvLoad()
        cmbtload()
        cmbeload()
        cmbvload()
    End Sub

    Private Sub analyse_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Hide()
        Main.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim query As String = "SELECT code_insemination as 'Code Insemination' , cirtificat_Insemination as 'Cirtificat', date_Insemination as 'Date d''insemination', TAUREAU.nom_Taureau as 'Nom Taureau' , gestation.code_Gestation as 'Code Gestation', vache.code_Vache as 'Code Vache',  ELVEUR.prenom_Elveur + ' ' + ELVEUR.nom_Elveur as 'Nom Elveur', ELVEUR.tele_Elveur as 'Telephone' FROM INSEMINATION,VACHE,GESTATION, ELVEUR,TAUREAU where GESTATION.code_Vache = VACHE.code_Vache and VACHE.code_Elveur = ELVEUR.code_Elveur and INSEMINATION.code_Taureau = TAUREAU.code_Taureau "

        If (CheckBox4.Checked = True) Then
            query = query + " and date_Insemination >= '" & Format(DateTimePicker1.Value, "yyyy-M-dd") & "' and date_Insemination <= '" & Format(DateTimePicker2.Value, "yyyy-M-dd") & "'"
        End If

        If (CheckBox1.Checked = True) Then
            query = query + " and Elveur.code_Elveur = '" & ComboBox1.Text & "'"
        End If

        If (CheckBox2.Checked = True) Then
            query = query + " and Vache.code_Vache = '" & ComboBox2.Text & "'"
        End If

        If (CheckBox3.Checked = True) Then
            query = query + " and taureau.code_taureau = '" & ComboBox3.Text & "'"
        End If



        query = query + " and code_Insemination NOT IN (select code_Insemination from DIAGNOSTIQUE)"


        Try
            Connexion()
            command.Connection = connection
            command.CommandText = query
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

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim imgbmt As New Bitmap(Me.DataGridView1.Width + 1, Me.DataGridView1.Height)
        DataGridView1.DrawToBitmap(imgbmt, New Rectangle(0, 0, Me.DataGridView1.Width, Me.DataGridView1.Height))
        e.Graphics.DrawImage(imgbmt, 100, 50)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class