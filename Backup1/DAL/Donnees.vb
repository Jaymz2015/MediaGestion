Imports System.IO
Imports Utilitaires

Public Class donnees
    Inherits DataSet

    Public tableFilms As Films
    Public tableGenres As Genres
    Public tablePrets As Prets
    Public tableJeux As Jeux
    Public tableMachines As Machines
    Public tableProprietaires As Proprietaires

    Private Const KS_NOM_MODULE = "DAL - Donnees - "

    Friend WithEvents ctn As System.Data.SqlClient.SqlConnection

    'Public Const chaineConnection As String = "Data Source=PC-JEROME;Initial Catalog=CatalogueMedias;Integrated Security=False; User ID=jaymz; Password=secret"
    Public Const chaineConnection As String = "Data Source=PC-JEROME;Initial Catalog=CatalogueMedias;Integrated Security=true"

    Public Sub New()

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début New Donnees")

        tableFilms = New Films(getConnexion())
        tableJeux = New Jeux(getConnexion())
        tableGenres = New Genres(getConnexion())
        'tablePrets = New Prets(getConnexion())
        tableMachines = New Machines(getConnexion())
        tableProprietaires = New Proprietaires(getConnexion())

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin New Donnees")
    End Sub

    'Singleton sur la connexion à la base
    Public Function getConnexion() As System.Data.SqlClient.SqlConnection

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début getConnexion")


            If ctn Is Nothing Then
                Me.ctn = New System.Data.SqlClient.SqlConnection
                Me.ctn.ConnectionString = chaineConnection
            End If

            Return ctn

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR getConnexion", ex)
            Return Nothing
        Finally

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin getConnexion")
        End Try


    End Function




End Class
