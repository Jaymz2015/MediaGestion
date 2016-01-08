Imports Utilitaires

Public Class Films
    Inherits DataTable

    Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlSelectCommand2 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand

    Friend WithEvents da As System.Data.SqlClient.SqlDataAdapter

    Friend WithEvents ctn As System.Data.SqlClient.SqlConnection

    Private Const KS_NOM_MODULE = "DAL - Films - "

    Public Sub New(ByVal _ctn As System.Data.SqlClient.SqlConnection)

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début New Films")

            ctn = _ctn
            InitializeComponent()
            da.FillSchema(Me, SchemaType.Source)

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR New Films", ex)

        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin New Films")
        End Try

    End Sub

    'Fonction qui retourne la liste des films
    Public Overridable Function obtenirListe() As List(Of Film)
        Dim liste As List(Of Film)
        Dim ligne As Data.DataRow
        Dim film As Film

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début obtenirListe")

            Me.da.SelectCommand = Me.SqlSelectCommand1

            'on vide la table avant de la remplir à partir de la base
            Me.Clear()
            da.Fill(Me)
            liste = New List(Of Film)

            For Each ligne In Rows
                'Construction d'un objet film à partir d'une dataRow
                film = New Film(ligne)
                'On ajoute ce film à la liste
                liste.Add(film)
            Next

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Nombre de films récupérés en base  = " + liste.Count.ToString)

            Return liste

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR obtenirListe", ex)
            Throw ex
        Finally
            liste = Nothing
            ligne = Nothing
            film = Nothing
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin obtenirListe")
        End Try

    End Function

    'Fonction qui retourne la liste des films en fonction du genre
    Public Overridable Function obtenirListe(ByVal g As String) As List(Of Film)

        Dim liste As List(Of Film)
        Dim ligne As Data.DataRow
        Dim film As Film

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début obtenirListe")

            'on vide la table avant de la remplir à partir de la base
            Me.Clear()

            Me.SqlSelectCommand2.CommandText = "SELECT code, titre, duree, codeGenre, dateSortie, resume, jaquette, realisateur," _
             & "acteurs,support, dispo, note, codeProprietaire FROM Film where codeGenre = @codeGenre order by titre"
            Me.SqlSelectCommand2.Parameters.Clear()
            Me.SqlSelectCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@codeGenre", g))
            Me.da.SelectCommand = Me.SqlSelectCommand2

            da.Fill(Me)
            liste = New List(Of Film)

            For Each ligne In Rows
                'Construction d'un objet film à partir d'une dataRow
                film = New Film(ligne)
                'On ajoute ce film à la liste
                liste.Add(film)
            Next

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Nombre de films récupérés en base  = " + liste.Count.ToString)

            Return liste

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR obtenirListe", ex)
            Throw ex

        Finally
            liste = Nothing
            ligne = Nothing
            film = Nothing
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin obtenirListe")
        End Try


    End Function

    'Fonction qui retourne la liste des jeux en fonction du genre
    Public Overridable Function chercherFilms(ByVal p_sTitre As String, ByVal p_sGenre1 As String, _
        ByVal p_sGenre2 As String, ByVal p_sAnnee1 As String, ByVal p_sAnnee2 As String, ByVal p_iDureeMin As Integer, _
        ByVal p_iDureeMax As Integer, ByVal p_sActeur As String, ByVal p_sRealisateur As String, _
        ByVal p_sSupport As String, ByVal p_sProprietaire As String) As List(Of Film)

        Dim liste As List(Of Film)
        Dim ligne As Data.DataRow
        Dim film As Film
        Dim l_sRequete As String

        Dim l_dDate1 As Date
        Dim l_dDate2 As Date

        Try

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début chercherFilms")

            'on vide la table avant de la remplir à partir de la base
            Me.Clear()

            'Construction de la requête
            l_sRequete = "SELECT code, titre, duree, codeGenre, dateSortie, resume, jaquette," _
             & "realisateur,acteurs,support,dispo, note FROM FILM "

            'Conditions
            l_sRequete = l_sRequete + "WHERE titre like '%" + p_sTitre + "%'"

            If Not p_sGenre1 = Nothing And Not p_sGenre2 = Nothing Then
                l_sRequete = l_sRequete + " and (codeGenre like '%" + Trim(p_sGenre1) + "%'" + _
                            " or codeGenre like '%" + Trim(p_sGenre2) + "%')"
            ElseIf Not p_sGenre1 = Nothing And p_sGenre2 = Nothing Then
                l_sRequete = l_sRequete + " and codeGenre like '%" + Trim(p_sGenre1) + "%'"
            ElseIf Not p_sGenre2 = Nothing And p_sGenre1 = Nothing Then
                l_sRequete = l_sRequete + " and codeGenre like '%" + Trim(p_sGenre2) + "%'"
            End If

            If p_sAnnee1 <> "" Then
                l_dDate1 = New Date(p_sAnnee1, 1, 1)
                If p_sAnnee2 <> "" Then
                    l_dDate2 = New Date(p_sAnnee2, 1, 1)

                    l_sRequete = l_sRequete + " and dateSortie between '" + l_dDate1.ToString + "' and '" + l_dDate2.ToString + "'"
                Else
                    l_sRequete = l_sRequete + " and dateSortie = '" + l_dDate1.ToString + "'"
                End If
            End If

            If p_iDureeMin > 0 And p_iDureeMax > 0 Then
                l_sRequete = l_sRequete + " and duree between " + CStr(p_iDureeMin) + " and " + CStr(p_iDureeMax)
            End If

            If p_sActeur <> "" Then
                l_sRequete = l_sRequete + " and acteurs like '%" + p_sActeur + "%'"
            End If

            If p_sRealisateur <> "" Then
                l_sRequete = l_sRequete + " and realisateur like '%" + p_sRealisateur + "%'"
            End If

            If p_sSupport <> "" Then
                l_sRequete = l_sRequete + " and support like '%" + p_sSupport + "%'"
            End If

            'If p_sProprietaire <> "" Then
            '    l_sRequete = l_sRequete + " and codeProprietaire like '%" + p_sProprietaire + "%'"
            'End If

            l_sRequete = l_sRequete + " order by titre"

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Requête envoyée  = " + l_sRequete)

            Me.SqlSelectCommand2.CommandText = l_sRequete
            Me.SqlSelectCommand2.Parameters.Clear()
            Me.da.SelectCommand = Me.SqlSelectCommand2

            'On lance le SELECT
            da.Fill(Me)
            'Construction d'une nouvelle liste
            liste = New List(Of Film)

            For Each ligne In Rows
                'Construction d'un objet film à partir d'une dataRow
                film = New Film(ligne)
                'On ajoute ce film à la liste
                liste.Add(film)
            Next

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Nombre de films récupérés en base  = " + liste.Count.ToString)

            'On retourne la liste
            Return liste

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR chercherFilms", ex)
            Throw ex
        Finally
            liste = Nothing
            ligne = Nothing
            film = Nothing
            l_dDate1 = Nothing
            l_dDate2 = Nothing
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin chercherFilms")
        End Try

    End Function

    'Fonction qui retourne la liste des jeux en fonction du genre
    Public Overridable Function chercherFilmsaAvoir() As List(Of Film)

        Dim liste As List(Of Film)
        Dim ligne As Data.DataRow
        Dim film As Film
        Dim l_sRequete As String


        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début chercherFilmsaAvoir")

            'on vide la table avant de la remplir à partir de la base
            Me.Clear()

            'Construction de la requête
            l_sRequete = "SELECT f.code, titre, duree, codeGenre, dateSortie, resume, jaquette," _
             & "realisateur,acteurs,support,dispo, note, codeProprietaire " _
             & "FROM Film f where not exists(select p.codeFilm from PRETS p where p.codeFilm = f.code) and f.dispo = 0 order by titre"

            Me.SqlSelectCommand2.CommandText = l_sRequete
            Me.SqlSelectCommand2.Parameters.Clear()
            Me.da.SelectCommand = Me.SqlSelectCommand2

            da.Fill(Me)
            'Construction d'une nouvelle liste
            liste = New List(Of Film)

            For Each ligne In Rows
                'Construction d'un objet film à partir d'une dataRow
                film = New Film(ligne)
                'On ajoute ce film à la liste
                liste.Add(film)
            Next

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Nombre de films récupérés en base  = " + liste.Count.ToString)

            'On retourne la liste
            Return liste

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR chercherFilmsaAvoir", ex)
            Throw ex
        Finally
            ligne = Nothing
            film = Nothing
            liste = Nothing
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin chercherFilmsaAvoir")
        End Try
    End Function

    'Ajout d'un film
    Public Sub ajouter(ByVal f As Film)

        'Construction d'un tableau à 1 élément
        Dim dr(0) As Data.DataRow
        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début ajouter : " + f.Titre)

            dr(0) = Me.NewRow()
            dr(0)("code") = f.Code
            dr(0)("titre") = f.Titre
            dr(0)("duree") = f.Duree
            dr(0)("codeGenre") = f.CodeGenre
            dr(0)("dateSortie") = f.DateSortie
            dr(0)("resume") = f.LeResume
            dr(0)("jaquette") = f.Jaquette
            dr(0)("realisateur") = f.leRealisateur
            dr(0)("acteurs") = f.lesActeurs
            dr(0)("support") = f.Type
            dr(0)("dispo") = f.Dispo
            dr(0)("note") = f.Note
            dr(0)("codeProprietaire") = f.CodeProprietaire

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

    'Modification d'un film
    Public Sub modifier(ByVal f As Film)
        'Construction d'un tableau à 1 élément
        Dim dr(0) As Data.DataRow

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début modifier : " + f.Titre)

            'Récupération des lignes contenant le code film (en fait une seule)
            dr = Me.Select("code=" & "'" & f.Code.ToString & "'")
            'Mise à jour de la ligne récupérée
            dr(0).BeginEdit()
            dr(0)("code") = f.Code
            dr(0)("titre") = f.Titre
            dr(0)("duree") = f.Duree
            dr(0)("codeGenre") = f.CodeGenre
            dr(0)("dateSortie") = f.DateSortie
            dr(0)("resume") = f.LeResume
            dr(0)("jaquette") = f.Jaquette
            dr(0)("realisateur") = f.leRealisateur
            dr(0)("acteurs") = f.lesActeurs
            dr(0)("support") = f.Type
            dr(0)("dispo") = f.Dispo
            dr(0)("note") = f.Note

            If Not f.CodeProprietaire = Nothing Then
                dr(0)("codeProprietaire") = f.CodeProprietaire
            End If

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

    'Suppression d'un film
    Public Sub effacer(ByVal f As Film)
        'Construction d'un tableau à 1 élément
        Dim dr(0) As Data.DataRow

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début effacer : " + f.Titre)

            'Récupération des lignes contenant le code film (en fait une seule)
            dr = Me.Select("code=" & "'" & f.Code.ToString & "'")
            'Suppression de la ligne
            dr(0).Delete()
            'Mise à jour de la table
            da.Update(Me)

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR effacer", ex)
            Throw ex
        Finally
            dr = Nothing
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
        'Me.ctn = New System.Data.SqlClient.SqlConnection

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
        {New System.Data.Common.DataTableMapping("Film", "Films", New System.Data.Common.DataColumnMapping() _
          {New System.Data.Common.DataColumnMapping("code", "Code"), _
            New System.Data.Common.DataColumnMapping("titre", "Titre"), _
             New System.Data.Common.DataColumnMapping("dateSortie", "DateSortie"), _
             New System.Data.Common.DataColumnMapping("resume", "Resume"), _
             New System.Data.Common.DataColumnMapping("jaquette", "Jaquette"), _
            New System.Data.Common.DataColumnMapping("realisateur", "Realisateur"), _
             New System.Data.Common.DataColumnMapping("acteurs", "Acteurs"), _
             New System.Data.Common.DataColumnMapping("support", "Type"), _
             New System.Data.Common.DataColumnMapping("dispo", "Dispo"), _
             New System.Data.Common.DataColumnMapping("note", "Note"), _
             New System.Data.Common.DataColumnMapping("codeProprietaire", "CodeProprietaire"), _
             New System.Data.Common.DataColumnMapping("duree", "Duree")})})

        'ctn
        '-------------------
        'Me.ctn.ConnectionString = donnees.chaineConnection

        'SqlDeleteCommand1
        '-------------------
        Me.SqlDeleteCommand1.CommandText = "Delete from Film WHERE (code = @code)"
        Me.SqlDeleteCommand1.Connection = Me.ctn
        Me.SqlDeleteCommand1.Parameters.Add( _
            New System.Data.SqlClient.SqlParameter("@code", System.Data.SqlDbType.UniqueIdentifier, 16, "code"))

        'SqlInsertCommand1
        '-------------------
        Me.SqlInsertCommand1.CommandText = "INSERT INTO FILM(code, titre, duree, codeGenre, dateSortie, resume," & _
        "jaquette, realisateur, acteurs, support, dispo, note, codeProprietaire) VALUES (@code, @titre, @duree, @genre, @sortie," & _
        "@resume, @jaquette, @realisateur, @acteurs, @support, @dispo, @note, @proprietaire);"

        'Définition des paramètres et lien avac 
        Me.SqlInsertCommand1.Connection = Me.ctn
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@code", System.Data.SqlDbType.UniqueIdentifier, 16, "code"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@titre", System.Data.SqlDbType.VarChar, 60, "titre"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@duree", System.Data.SqlDbType.Int, 4, "duree"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@genre", System.Data.SqlDbType.Char, 5, "codeGenre"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sortie", System.Data.SqlDbType.DateTime, 8, "dateSortie"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@resume", System.Data.SqlDbType.VarChar, 1500, "resume"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@jaquette", System.Data.SqlDbType.VarChar, 100, "jaquette"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@realisateur", System.Data.SqlDbType.VarChar, 50, "realisateur"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@acteurs", System.Data.SqlDbType.VarChar, 200, "acteurs"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@support", System.Data.SqlDbType.VarChar, 4, "support"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@dispo", System.Data.SqlDbType.Bit, 1, "dispo"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@note", System.Data.SqlDbType.TinyInt, 1, "note"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@proprietaire", System.Data.SqlDbType.UniqueIdentifier, 16, "codeProprietaire"))

        Me.SqlInsertCommand1.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord

        'SqlSelectCommand1
        '-------------------
        Me.SqlSelectCommand1.CommandText = "SELECT code, titre, duree, codeGenre, dateSortie, resume, jaquette, realisateur," _
         & "acteurs,support, dispo, note, codeProprietaire FROM Film order by titre"
        Me.SqlSelectCommand1.Connection = Me.ctn

        'SqlSelectCommand2
        '-------------------
        Me.SqlSelectCommand2.Connection = Me.ctn

        'SqlUpdateCommand1
        '-------------------
        Me.SqlUpdateCommand1.CommandText = "UPDATE film SET titre = @titre, duree = @duree, codeGenre = @codeGenre," & _
        "dateSortie = @dateSortie, resume = @resume, jaquette = @jaquette, realisateur = @realisateur, acteurs = @acteurs," & _
        "support = @support, dispo= @dispo, note= @note, codeProprietaire =@proprietaire WHERE (code = @code)"

        Me.SqlUpdateCommand1.Connection = Me.ctn
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@code", System.Data.SqlDbType.UniqueIdentifier, 16, "code"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@titre", System.Data.SqlDbType.VarChar, 60, "titre"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@duree", System.Data.SqlDbType.Int, 4, "duree"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@codeGenre", System.Data.SqlDbType.Char, 5, "codeGenre"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@dateSortie", System.Data.SqlDbType.DateTime, 8, "dateSortie"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@resume", System.Data.SqlDbType.VarChar, 1500, "resume"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@jaquette", System.Data.SqlDbType.VarChar, 100, "jaquette"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@realisateur", System.Data.SqlDbType.VarChar, 50, "realisateur"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@acteurs", System.Data.SqlDbType.VarChar, 200, "acteurs"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@support", System.Data.SqlDbType.VarChar, 4, "support"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@dispo", System.Data.SqlDbType.Bit, 1, "dispo"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@note", System.Data.SqlDbType.TinyInt, 1, "note"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@proprietaire", System.Data.SqlDbType.UniqueIdentifier, 16, "codeProprietaire"))

        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin InitializeComponent")

    End Sub

    Protected Overrides Sub Finalize()

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début Finalize")
        MyBase.Finalize()
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin Finalize")
    End Sub
End Class
