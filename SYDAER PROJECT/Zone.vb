﻿Imports System.Data.SqlClient
Public Class Formzone
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
    Public Sub dgvLoad()
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "SELECT * FROM ZONE"
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

    Private Sub Formzone_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvLoad()
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            Connexion()
            command.Connection = connection
            command.CommandText = "INSERT INTO ZONE VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "');"
            command.CommandType = CommandType.Text
            Dim i As Integer = command.ExecuteNonQuery()
            If (i = 1) Then
                MsgBox("Zone a été ajouté avec succès")
            Else
                MessageBox.Show("Zone n'est pas été ajouté", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            command.CommandText = "UPDATE ZONE SET nom_Zone = '" & TextBox2.Text & "' where code_zone = '" & TextBox1.Text & "';"
            command.CommandType = CommandType.Text
            Dim i As Integer = command.ExecuteNonQuery()
            If (i = 1) Then
                MsgBox("Zone a Modefier avec succès")
            Else
                MessageBox.Show("Zone n'est Modefier ajouté", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        connection.Close()
        dgvLoad()
    End Sub

    Private Sub btnsupp_Click(sender As Object, e As EventArgs) Handles btnsupp.Click
        Dim dialog As DialogResult
        dialog = MessageBox.Show("êtes-vous sûr de supprimer tout?", "Supprimer tout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialog = DialogResult.Yes Then
            Try
                Connexion()
                command.Connection = connection
                command.CommandText = "DELETE FROM ZONE WHERE code_zone = '" & TextBox1.Text & "';"
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