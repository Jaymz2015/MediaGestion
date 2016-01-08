Imports Utilitaires

Public Class Prets
    Inherits DataTable

    Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlSelectCommand2 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand

    Friend WithEvents da As System.Data.SqlClient.SqlDataAdapter

    Friend WithEvents ctn As System.Data.SqlClient.SqlConnection

    Private Const KS_NOM_MODULE = "DAL - Prets - "

    Public Sub New(ByVal _ctn As System.Data.SqlClient.SqlConnection)

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début New Prets")

        ctn = _ctn
        InitializeComponent()
        da.FillSchema(Me, SchemaType.Source)

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin New Prets")
    End Sub

    'Fonction qui retourne la liste des prêts
    Public Overridable Function obtenir(ByVal codeFilm As Guid, ByVal codeJeu As Guid) As Pret

        Dim ligne As Data.DataRow
        Dim pret As Pret

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début obtenir")

            pret = Nothing

            Me.da.SelectCommand = Me.SqlSelectCommand2

            'on vide la table avant de la remplir à partir de la base
            Me.Clear()
            Me.SqlSelectCommand2.Parameters.Clear()

            If codeFilm = Nothing Then
                Me.SqlSelectCommand2.CommandText = "SELECT code, codeFilm, codeJeu, datePrete, dateRendu, nom, prenom FROM Prets where codeFilm is null and codeJeu = @codeJeu and dateRendu is null"
                Me.SqlSelectCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@codeJeu", codeJeu))
            Else
                Me.SqlSelectCommand2.CommandText = "SELECT code, codeFilm, codeJeu, datePrete, dateRendu, nom, prenom FROM Prets where codeFilm = @codeFilm and codeJeu is null and dateRendu is null"
                Me.SqlSelectCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@codeFilm", codeFilm))
            End If

            da.Fill(Me)

            For Each ligne In Rows
                'Construction d'un objet prêt à partir d'une dataRow
                pret = New Pret(ligne)

                Log.MonitoringLogger.Info(KS_NOM_MODULE + "Prêt en cours  = " + pret.Nom + " " + pret.Prenom)
            Next

            Return pret

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR obtenir", ex)
            Throw ex
        Finally
            ligne = Nothing
            pret = Nothing
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin obtenir")
        End Try
       

    End Function

    'Fonction qui retourne la liste des prêts
    Public Overridable Function obtenirListe(ByVal p_bSeulsPretsEnCours As Boolean) As List(Of Pret)

        Dim liste As List(Of Pret) = Nothing
        Dim ligne As Data.DataRow
        Dim pret As Pret

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début obtenirListe")

            Me.da.SelectCommand = Me.SqlSelectCommand1

            'on vide la table avant de la remplir à partir de la base
            Me.Clear()
            If da.Fill(Me) > 0 Then

                liste = New List(Of Pret)

                For Each ligne In Me.Rows
                    'Construction d'un objet prêt à partir d'une dataRow
                    pret = New Pret(ligne)

                    'Récupération du nom du media
                    If pret.CodeFilm = Nothing Then
                        pret.Titre = obtenirTitre(Nothing, pret.CodeJeu)
                    Else
                        pret.Titre = obtenirTitre(pret.CodeFilm, Nothing)
                    End If

                    'On ajoute ce film à la liste
                    If (p_bSeulsPretsEnCours And pret.DateRendu = Nothing) Or Not p_bSeulsPretsEnCours Then
                        liste.Add(pret)
                    End If

                Next

                Log.MonitoringLogger.Info(KS_NOM_MODULE + "Nombre de prêts récupérés en base  = " + liste.Count.ToString)


            End If

            Return liste

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR obtenirListe", ex)
            Throw ex
        Finally
            liste = Nothing
            ligne = Nothing
            pret = Nothing
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin obtenirListe")
        End Try

    End Function

    'Ajout d'un film
    Public Sub ajouter(ByVal p As Pret)
        'Construction d'un tableau à 1 élément
        Dim dr(0) As Data.DataRow

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début ajouter : " + p.Code.ToString)

            dr(0) = Me.NewRow()
            dr(0)("code") = p.Code

            If p.CodeFilm = Nothing Then
                dr(0)("codeFilm") = DBNull.Value
            Else
                dr(0)("codeFilm") = p.CodeFilm
            End If

            If p.CodeJeu = Nothing Then
                dr(0)("codeJeu") = DBNull.Value
            Else
                dr(0)("codeJeu") = p.CodeJeu
            End If

            dr(0)("datePrete") = p.DatePrete
            If p.DateRendu.Year <> 1 Then
                dr(0)("dateRendu") = p.DateRendu
            End If
            dr(0)("nom") = p.Nom
            dr(0)("prenom") = p.Prenom
            'On ajoute la ligne crée
            Me.Rows.Add(dr(0))

            'On met à jour la table
            da.Update(dr)

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR ajouter", ex)
            Throw ex
        Finally
            dr = Nothing
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin ajouter")
        End Try

    End Sub

    'Modification d'un pret
    Public Sub modifier(ByVal p As Pret)

        'Construction d'un tableau à 1 élément
        Dim dr(0) As Data.DataRow

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début modifier : " + p.Code.ToString)

            'Récupération des lignes contenant le code film (en fait une seule)
            dr = Me.Select("code=" & "'" & p.Code.ToString & "'")

            'Mise à jour de la ligne récupérée
            dr(0).BeginEdit()
            dr(0)("code") = p.Code
            If p.CodeFilm = Nothing Then
                dr(0)("codeFilm") = DBNull.Value
            Else
                dr(0)("codeFilm") = p.CodeFilm
            End If

            If p.CodeJeu = Nothing Then
                dr(0)("codeJeu") = DBNull.Value
            Else
                dr(0)("codeJeu") = p.CodeJeu
            End If
            dr(0)("datePrete") = p.DatePrete
            dr(0)("dateRendu") = p.DateRendu
            dr(0)("nom") = p.Nom
            dr(0)("prenom") = p.Prenom

            dr(0).EndEdit()
            'Mise à jour de la table
            da.Update(dr)

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR modifier", ex)
            Throw ex
        Finally
            dr = Nothing
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin modifier")
        End Try
       
    End Sub

    'Suppression d'un pret
    Public Sub effacer(ByVal p As Pret)

        'Construction d'un tableau à 1 élément
        Dim dr(0) As Data.DataRow

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début effacer : " + p.Code.ToString)

            'Récupération des lignes contenant le code pret (en fait une seule)
            dr = Me.Select("code=" & "'" & p.Code.ToString & "'")
            'Suppression de la ligne
            dr(0).Delete()
            'Mise à jour de la table
            da.Update(Me)

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR effacer", ex)
            Throw ex
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin effacer")
        End Try

    End Sub

    Private Sub InitializeComponent()

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début InitializeComponent")

        ' DataAdapter
        '------------------
        Me.da = New System.Data.SqlClient.SqlDataAdapter

        ' Connexion
        '-------------------
        ' Me.ctn = New System.Data.SqlClient.SqlConnection

        ' SqlCommand
        '-------------------
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlSelectCommand2 = New System.Data.SqlClient.SqlCommand
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand

        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()

        'da
        '-------------------
        Me.da.DeleteCommand = Me.SqlDeleteCommand1
        Me.da.InsertCommand = Me.SqlInsertCommand1
        Me.da.SelectCommand = Me.SqlSelectCommand1
        Me.da.UpdateCommand = Me.SqlUpdateCommand1

        Me.da.TableMappings.AddRange(New System.Data.Common.DataTableMapping() _
        {New System.Data.Common.DataTableMapping("Prets", "Prets", New System.Data.Common.DataColumnMapping() _
          {New System.Data.Common.DataColumnMapping("code", "Code"), _
            New System.Data.Common.DataColumnMapping("codeFilm", "codeFilm"), _
             New System.Data.Common.DataColumnMapping("codeJeu", "codeJeu"), _
             New System.Data.Common.DataColumnMapping("datePrete", "DatePrete"), _
             New System.Data.Common.DataColumnMapping("dateRendu", "DateRendu"), _
             New System.Data.Common.DataColumnMapping("nom", "Nom"), _
             New System.Data.Common.DataColumnMapping("prenom", "Prenom")})})

        'ctn
        '-------------------
        'Me.ctn.ConnectionString = donnees.chaineConnection

        'SqlDeleteCommand1
        '-------------------
        Me.SqlDeleteCommand1.CommandText = "Delete from Prets WHERE (code = @code)"
        Me.SqlDeleteCommand1.Connection = Me.ctn
        Me.SqlDeleteCommand1.Parameters.Add( _
            New System.Data.SqlClient.SqlParameter("@code", System.Data.SqlDbType.UniqueIdentifier, 16, "code"))

        'SqlInsertCommand1
        '-------------------
        Me.SqlInsertCommand1.CommandText = "INSERT INTO PRETS(code, codeFilm,codeJeu, datePrete, dateRendu, nom, prenom) " & _
        " VALUES (@code, @codeFilm, @codeJeu,@datePrete, @dateRendu, @nom, @prenom);"

        Me.SqlInsertCommand1.Connection = Me.ctn
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@code", System.Data.SqlDbType.UniqueIdentifier, 16, "code"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@codeFilm", System.Data.SqlDbType.UniqueIdentifier, 16, "codeFilm"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@codeJeu", System.Data.SqlDbType.UniqueIdentifier, 16, "codeJeu"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@datePrete", System.Data.SqlDbType.DateTime, 8, "datePrete"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@dateRendu", System.Data.SqlDbType.DateTime, 8, "dateRendu"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@nom", System.Data.SqlDbType.VarChar, 30, "nom"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@prenom", System.Data.SqlDbType.VarChar, 30, "prenom"))

        Me.SqlInsertCommand1.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord

        'SqlSelectCommand1
        '-------------------
        Me.SqlSelectCommand1.CommandText = "SELECT code, codeFilm,codeJeu, datePrete, dateRendu, nom, prenom FROM Prets order by datePrete"
        Me.SqlSelectCommand1.Connection = Me.ctn

        'SqlSelectCommand2
        '-------------------
        Me.SqlSelectCommand2.Connection = Me.ctn


        'SqlUpdateCommand1
        '-------------------
        Me.SqlUpdateCommand1.CommandText = "UPDATE Prets SET codeFilm = @codeFilm, datePrete = @datePrete, dateRendu = @dateRendu," & _
        "nom = @nom, prenom= @prenom WHERE (code = @code)"

        Me.SqlUpdateCommand1.Connection = Me.ctn
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@code", System.Data.SqlDbType.UniqueIdentifier, 16, "code"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@codeFilm", System.Data.SqlDbType.UniqueIdentifier, 16, "codeFilm"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@codeJeu", System.Data.SqlDbType.UniqueIdentifier, 16, "codeJeu"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@datePrete", System.Data.SqlDbType.DateTime, 8, "datePrete"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@dateRendu", System.Data.SqlDbType.DateTime, 8, "dateRendu"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@nom", System.Data.SqlDbType.VarChar, 30, "nom"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@prenom", System.Data.SqlDbType.VarChar, 30, "prenom"))

        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin InitializeComponent")

    End Sub

    'Fonction qui retourne le nom d'un media en fonction de son code
    Private Function obtenirTitre(ByVal codeFilm As Guid, ByVal codeJeu As Guid) As String

        Dim cmd As System.Data.SqlClient.SqlCommand
        Dim param As System.Data.SqlClient.SqlParameter
        Dim lecteur As System.Data.SqlClient.SqlDataReader
        Dim resultat As String = Nothing
        Dim code As Guid

        lecteur = Nothing

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début obtenirTitre")

            'Ouverture de la connexion
            ctn.Open()

            'Définition de la commande
            cmd = New System.Data.SqlClient.SqlCommand
            cmd.Connection = Me.ctn

            If codeJeu = Nothing Then
                cmd.CommandText = "SELECT TITRE FROM FILM WHERE CODE = @code"
                code = codeFilm
            Else
                cmd.CommandText = "SELECT TITRE FROM JEUX WHERE CODE = @code"
                code = codeJeu
            End If

            'Définition du paramètre de la requête
            param = New System.Data.SqlClient.SqlParameter("@code", code)
            param.Direction = ParameterDirection.Input
            cmd.Parameters.Add(param)

            'Exécution de la requête
            lecteur = cmd.ExecuteReader

            While lecteur.Read
                resultat = lecteur("titre")
            End While

            'Fermeture et libération mémoire
            lecteur.Close()
            ctn.Close()

            Log.MonitoringLogger.Error(KS_NOM_MODULE + "Résultat = " + resultat)

            Return resultat

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR obtenirTitre", ex)
            Throw ex
        Finally
            param = Nothing
            cmd = Nothing
            If Not lecteur Is Nothing Then
                lecteur.Close()
            End If

            lecteur = Nothing

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin obtenirTitre")

        End Try

    End Function

End Class
