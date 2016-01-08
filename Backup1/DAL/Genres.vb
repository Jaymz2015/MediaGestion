Imports Utilitaires

Public Class Genres
    Inherits DataTable

    Private Enum media
        tout
        film
        jeu
    End Enum


    Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand

    Friend WithEvents da As System.Data.SqlClient.SqlDataAdapter

    Friend WithEvents ctn As System.Data.SqlClient.SqlConnection

    Private Const KS_NOM_MODULE = "DAL - Genres - "

    Public Sub New(ByVal _ctn As System.Data.SqlClient.SqlConnection)
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début New Genres")

        ctn = _ctn
        InitializeComponent()
        da.FillSchema(Me, SchemaType.Source)

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin New Genres")
    End Sub

    'Fonction qui retourne la liste des genres
    Public Overridable Function obtenirListe(ByVal type As Integer) As List(Of Genre)

        Dim liste As List(Of Genre)
        Dim ligne As Data.DataRow
        Dim genre As Genre

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début obtenirListe")

            Me.Clear()
            da.Fill(Me)
            liste = New List(Of Genre)

            For Each ligne In Rows
                'Construction d'un objet genre à partir d'une dataRow
                genre = New Genre(ligne)

                'On ajoute le genre que si celui-ci est un genre universel ou spécifique ou type media attendu
                If genre.Media = media.tout Or genre.Media = type Then
                    'On ajoute ce film à la liste
                    liste.Add(genre)

                End If
            Next

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Nombre de genres récupérés en base  = " + liste.Count.ToString)

            Return liste

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR obtenirListe", ex)
            Throw ex
        Finally
            liste = Nothing
            ligne = Nothing
            genre = Nothing
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin obtenirListe")
        End Try
       

    End Function

    Private Sub InitializeComponent()

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début InitializeComponent")

        Me.da = New System.Data.SqlClient.SqlDataAdapter

        'Me.ctn = New System.Data.SqlClient.SqlConnection

        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand

        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()

        Me.da.SelectCommand = Me.SqlSelectCommand1
        Me.da.TableMappings.AddRange(New System.Data.Common.DataTableMapping() _
             {New System.Data.Common.DataTableMapping("Genre", "Genres", New System.Data.Common.DataColumnMapping() _
                {New System.Data.Common.DataColumnMapping("codeGenre", "Code"), _
                    New System.Data.Common.DataColumnMapping("media", "Media"), _
                    New System.Data.Common.DataColumnMapping("libelle", "Libelle") _
            })})

        'ctn
        '
        'Me.ctn.ConnectionString = Donnees.chaineConnection
        '

        Me.SqlSelectCommand1.CommandText = "SELECT codeGenre, libelle,media FROM Genre order by libelle"
        Me.SqlSelectCommand1.Connection = Me.ctn

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin InitializeComponent")

    End Sub


End Class
