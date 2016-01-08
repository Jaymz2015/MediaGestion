Imports System.IO

Public Class donnees
    Inherits DataSet

    Public tableFilms As Films
    Public tableGenres As Genres
    Public tablePrets As Prets
    Public tableJeux As Jeux
    Public tableMachines As Machines

    Friend WithEvents ctn As System.Data.SqlClient.SqlConnection

    Public Const chaineConnection As String = "Data Source=JEROME;Initial Catalog=CatalogueMedias;Integrated Security=False; User ID=sa; Password=secret"

    Public Sub New()

        tableFilms = New Films(getConnexion())
        tableJeux = New Jeux(getConnexion())
        tableGenres = New Genres(getConnexion())
        tablePrets = New Prets(getConnexion())
        tableMachines = New Machines(getConnexion())
    End Sub

    'Singleton sur la connexion à la base
    Public Function getConnexion() As System.Data.SqlClient.SqlConnection

        Try
            If ctn Is Nothing Then
                Me.ctn = New System.Data.SqlClient.SqlConnection
                Me.ctn.ConnectionString = chaineConnection
            End If

            Return ctn

        Catch ex As Exception
            Return Nothing
        End Try


    End Function




End Class
