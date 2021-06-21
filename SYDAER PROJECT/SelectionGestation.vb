Imports System.Data.SqlClient
Public Class SelectionGestation

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


    Public Sub cmbvload()
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT code_Vache FROM Vache"
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

    Public Sub cmbgload()
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT code_Gestation FROM Gestation"
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            While (datareader.Read)
                ComboBox2.Items.Add(datareader(0))
            End While
            datareader.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
    End Sub

    Private Sub SelectionGestation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbgload()
        cmbvload()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            ComboBox2.Items.Clear()
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT code_Gestation FROM Gestation Where code_Vache = '" & ComboBox1.Text & "'"
            command.CommandType = CommandType.Text
            datareader = command.ExecuteReader
            While (datareader.Read)
                ComboBox2.Items.Add(datareader(0))
            End While
            datareader.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
    End Sub
End Class