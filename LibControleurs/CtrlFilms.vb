Imports System.IO
Imports System.Net
Imports System.Web
Imports Utilitaires
Imports LibAllocine
Imports LibAllocine.Dl.Dto
Imports Microsoft.Office.Interop
Imports MediaGestion.Metier

Public Class CtrlFilms

    'Référence sur la DataSet
    Private base As donnees

    Private Const KS_NOM_MODULE = "LibControleurs - CtrlFilms - "

    Private pFicheAllocine As FicheFilmAllocine

    Public Property FicheAllocine() As FicheFilmAllocine
        Get
            Return pFicheAllocine
        End Get
        Set(ByVal value As FicheFilmAllocine)
            pFicheAllocine = value
        End Set
    End Property

    Public Sub New(ByVal b As donnees)
        base = b
    End Sub

    Public Function ObtenirGenres() As List(Of Genre)
        Return base.tableGenres.obtenirListe(1)
    End Function

    Public Function ObtenirProprietaires() As List(Of Proprietaire)
        Return base.tableProprietaires.obtenirListe()
    End Function

    Public Function ObtenirFilms() As List(Of Film)

        'Dim gestionnaireFilms As New GestionnaireFilms()
        'Dim liste As List(Of MediaGestion.Modele.Dl.Dlo.Film)
        'liste = gestionnaireFilms.ObtenirFilms()

        Return base.tableFilms.obtenirListe()
    End Function

    Public Function ObtenirFilms(ByVal p_sCodeGenre As String) As List(Of Film)
        If p_sCodeGenre = "AAA" Then
            Return base.tableFilms.obtenirListe()
        Else
            Return base.tableFilms.obtenirListe(p_sCodeGenre)
        End If
    End Function

    Public Function ObtenirPretEnCours(ByVal codeFilm As Guid) As Pret
        Return base.tablePrets.obtenir(codeFilm, Nothing)
    End Function

    Public Function ObtenirProprietaireParDefaut() As Proprietaire
        Dim list As List(Of Proprietaire)

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début ObtenirProprietaireParDefaut")

            list = obtenirProprietaires()

            For Each p As Proprietaire In list
                If p.EstProprietairePrincipal Then
                    Return p
                End If
            Next

            Return Nothing

        Catch ex As Exception
            Throw ex
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR ObtenirProprietaireParDefaut", ex)
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin ObtenirProprietaireParDefaut")
        End Try

    End Function

    'Fonction qui recherche les jeux en fonction d'un titre, et éventuellement d'une machine ou d'un genre
    Public Function ChercherFilms(ByVal p_sTitre As String, ByVal p_oGenre1 As Genre, ByVal p_oGenre2 As Genre, _
            ByVal p_sAnnee1 As String, ByVal p_sAnnee2 As String, ByVal p_iDureeMin As Integer, ByVal p_iDureeMax As Integer, _
            ByVal p_sActeur As String, ByVal p_sRealisateur As String, ByVal p_sSupport As String, ByVal p_oProprietaire As Proprietaire) As List(Of Film)

        Dim l_sGenre1 As String
        Dim l_sGenre2 As String
        Dim l_sCodeProprietaire As String

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début ChercherFilms")

            If p_oGenre1.Libelle = "*" Then
                l_sGenre1 = Nothing
            Else
                l_sGenre1 = p_oGenre1.Code
            End If

            If p_oGenre2.Libelle = "*" Then
                l_sGenre2 = Nothing
            Else
                l_sGenre2 = p_oGenre2.Code
            End If

            If p_oProprietaire.NomPrenom = "-" Then
                l_sCodeProprietaire = ""
            Else
                l_sCodeProprietaire = p_oProprietaire.Code.ToString
            End If

            Return base.tableFilms.chercherFilms(p_sTitre, l_sGenre1, l_sGenre2, p_sAnnee1, p_sAnnee2, _
                                                    p_iDureeMin, p_iDureeMax, p_sActeur, p_sRealisateur, p_sSupport, l_sCodeProprietaire)

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR ChercherFilms", ex)
            Throw ex
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin ChercherFilms")
        End Try

    End Function

    'Fonction qui recherche les jeux en fonction d'un titre, et éventuellement d'une machine ou d'un genre
    Public Function ChercherFilmsaAvoir() As List(Of Film)

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début ChercherFilmsaAvoir")

            Return base.tableFilms.chercherFilmsaAvoir()
        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR ChercherFilmsaAvoir", ex)
            Throw ex
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin ChercherFilmsaAvoir")
        End Try

    End Function

    'Fonction qui retourne le libellé d'un genre en fonction de son code
    Public Function GetLibelle(ByVal code As String) As String

        Dim list As List(Of Genre)

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début GetLibelle : code = " + code)

            list = obtenirGenres()

            For Each g As Genre In list
                If g.Code = code Then
                    Return g.Libelle
                End If
            Next

            Return Nothing

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR GetLibelle", ex)
            Throw ex
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin GetLibelle")
        End Try

    End Function

    'Fonction qui retourne le code d'un genre en fonction de son libellé
    Public Function GetCodeLibelle(ByVal p_sLibelle As String) As String

        Dim list As List(Of Genre)

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début GetCodeLibelle : " + p_sLibelle)

            list = ObtenirGenres()

            Dim l_sLibelle As String = p_sLibelle.ToLower().Replace(" ", "").Replace("-", "")

            For Each g As Genre In list

                Dim libelleAComparer = g.Libelle.ToLower().Replace(" ", "").Replace("-", "")

                If libelleAComparer.Contains(l_sLibelle) Then
                    Return g.Code
                End If
            Next

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Le genre n'existe pas en base : " + p_sLibelle)

            Return Nothing

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR GetCodeLibelle", ex)
            Throw ex
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin GetCodeLibelle")
        End Try

    End Function

    'Ajout d'un film
    Public Function AjouterFilm(ByVal titre As String, ByVal duree As Integer, ByVal genre As String, ByVal dateSortie As DateTime, ByVal leResume As String, _
    ByVal jaquette As String, ByVal realisateur As String, ByVal acteurs As String, ByVal support As String, ByVal codeProprietaire As Guid) As Film

        Dim f As Film

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début AjouterFilm : " + titre)

            f = New Film(titre, genre, duree, dateSortie, support, leResume, realisateur, acteurs, jaquette, Nothing, True, codeProprietaire)
            base.tableFilms.ajouter(f)
            Return f

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR AjouterFilm", ex)
            Throw ex
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin AjouterFilm")
        End Try

    End Function

    'Modification d'un film
    Public Sub ModifierFilm(ByVal f As Film, ByVal titre As String, ByVal duree As Integer, ByVal genre As String, ByVal dateSortie As DateTime, ByVal leResume As String, _
    ByVal jaquette As String, ByVal realisateur As String, ByVal acteurs As String, ByVal support As String, ByVal codeProprietaire As Guid)

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début ModifierFilm : " + f.Titre)

            f.Titre = titre
            f.Duree = duree
            f.CodeGenre = genre
            f.DateSortie = dateSortie
            f.LeResume = leResume
            f.Photo = jaquette
            f.leRealisateur = realisateur
            f.lesActeurs = acteurs
            f.Type = support
            f.CodeProprietaire = codeProprietaire

            base.tableFilms.modifier(f)

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR ModifierFilm", ex)
            Throw ex
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin ModifierFilm")
        End Try


    End Sub

    'Modification de la dispo
    Public Sub ModifierDispo(ByRef p_oFilm As Film, ByVal p_bDispo As Boolean)

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début ModifierFilm : " + p_oFilm.Titre + ", " + p_bDispo.ToString)

            p_oFilm.Dispo = p_bDispo
            base.tableFilms.modifier(p_oFilm)

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR ModifierFilm", ex)
            Throw ex
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin ModifierFilm")
        End Try

    End Sub

    Public Function EffacerFilm(ByVal f As Film) As Boolean

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début EffacerFilm : " + f.Titre)
            base.tableFilms.effacer(f)

            Return True

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR EffacerFilm", ex)
            Throw ex
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin EffacerFilm")
        End Try

    End Function

    'Enregistrement d'un prêt
    Public Function EnregistrerPret(ByVal f As Film, ByVal datePrete As DateTime, ByVal nom As String, ByVal prenom As String) As Boolean

        Dim p As Pret

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début EnregistrerPret")

            p = New Pret(f.Code, Nothing, datePrete, nom, prenom)

            'Le film n'est plus disponible
            f.Dispo = False

            'Mise à jour dans la table films de la disponibilité du film
            base.tableFilms.modifier(f)

            'Ajout du prêt
            base.tablePrets.ajouter(p)

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR EnregistrerPret", ex)
            Throw ex
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin EnregistrerPret")
        End Try


    End Function

    'Modification d'un prêt
    Public Sub ClorePret(ByVal p As Pret, ByVal f As Film, ByVal dateRendu As Date)

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début ClorePret")

            'Le film est de nouveau disponible disponible
            f.Dispo = True

            'Mise à jour dans la table films de la disponibilité du film
            base.tableFilms.modifier(f)

            'Fermeture du prêt
            p.DateRendu = dateRendu
            base.tablePrets.modifier(p)

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR ClorePret", ex)
            Throw ex
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin ClorePret")
        End Try
     

    End Sub

    Public Function RechercheAllocineV2(ByVal p_sTexte As String) As ListeFichesFilmsAllocine

        Dim gestionnaireAllocine As New GestionnaireAllocine()
        RechercheAllocineV2 = gestionnaireAllocine.RechercherMedia(p_sTexte, Constantes.EnumTypeMediaAllocine.FILM)

    End Function

    Public Function ObtenirFicheFilmAllocineV2(ByVal p_sCode As String) As FicheFilmAllocine

        Dim gestionnaireAllocine As New GestionnaireAllocine()
        ObtenirFicheFilmAllocineV2 = gestionnaireAllocine.ObtenirFicheFilm(p_sCode, Constantes.EnumTypeMediaAllocine.FILM)

    End Function

    'Méthode permettant d'enregistrer dans un fichier excel la liste des films et des jeux
    Public Function ExportationExcel(ByVal p_oListeFilms As List(Of Film), ByVal p_sFileName As String) As Boolean

        Dim l_oClasseurExcel As Excel.Workbook
        Dim l_oFeuilleExcel As Excel.Worksheet
        Dim l_oAppliExcel As New Excel.Application
        Dim l_iIndex As Integer
        Dim l_cGenres As List(Of Genre)
        Dim i As Integer
        Dim l_oColonne As Excel.Range

        Try

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début exportationExcel")

            ExportationExcel = False


            l_oClasseurExcel = l_oAppliExcel.Workbooks.Add
            l_oAppliExcel.Worksheets(3).Delete()

            'Enregistrement des films
            '----------------------------
            l_iIndex = 0
            l_cGenres = base.tableGenres.obtenirListe(1)
            l_oFeuilleExcel = l_oAppliExcel.Worksheets.Item(1)
            l_oFeuilleExcel.Name = "Films"

            For Each f As Film In p_oListeFilms

                l_iIndex += 1
                l_oFeuilleExcel.Cells(l_iIndex, 1) = f.Titre

                'Récupération du libellé du genre
                For Each g As Genre In l_cGenres
                    If g.Code = f.CodeGenre Then
                        l_oFeuilleExcel.Cells(l_iIndex, 2) = g.Libelle
                    End If
                Next

                l_oFeuilleExcel.Cells(l_iIndex, 3) = f.DateSortie.Year
                l_oFeuilleExcel.Cells(l_iIndex, 4) = f.Duree \ 60 & "h" & f.Duree Mod 60
                l_oFeuilleExcel.Cells(l_iIndex, 5) = f.leRealisateur
                l_oFeuilleExcel.Cells(l_iIndex, 6) = f.lesActeurs
                l_oFeuilleExcel.Cells(l_iIndex, 7) = f.Type
                l_oFeuilleExcel.Cells(l_iIndex, 8) = f.Dispo

            Next

            'Largeur des colonnes
            For i = 1 To 7
                l_oColonne = l_oFeuilleExcel.Columns(i)
                l_oColonne.AutoFit()
                l_oColonne = Nothing
            Next

            'Enregistrement des jeux
            '----------------------------
            l_iIndex = 0
            l_cGenres = Nothing
            l_cGenres = base.tableGenres.obtenirListe(2)
            l_oFeuilleExcel = l_oAppliExcel.Worksheets.Item(2)
            l_oFeuilleExcel.Name = "Jeux"

            For Each j As Jeu In base.tableJeux.obtenirListe()

                l_iIndex += 1
                l_oFeuilleExcel.Cells(l_iIndex, 1) = j.Titre

                'Récupération du libellé du genre
                For Each g As Genre In l_cGenres
                    If g.Code = j.CodeGenre Then
                        l_oFeuilleExcel.Cells(l_iIndex, 2) = g.Libelle
                    End If
                Next

                l_oFeuilleExcel.Cells(l_iIndex, 3) = j.DateSortie.Year
                l_oFeuilleExcel.Cells(l_iIndex, 4) = j.CodeMachine
                l_oFeuilleExcel.Cells(l_iIndex, 5) = j.Editeur
                l_oFeuilleExcel.Cells(l_iIndex, 6) = j.Developpeur
                l_oFeuilleExcel.Cells(l_iIndex, 7) = j.EstCopie
                l_oFeuilleExcel.Cells(l_iIndex, 8) = j.Dispo
            Next

            'Largeur des colonnes
            For i = 1 To 8
                l_oColonne = l_oFeuilleExcel.Columns(i)
                l_oColonne.AutoFit()
                l_oColonne = Nothing
            Next


            'Sauvegarde du document
            l_oClasseurExcel.SaveAs(p_sFileName)
            l_oClasseurExcel.Close()

            ExportationExcel = True


        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ExportationExcel = False
        Finally
            l_oClasseurExcel = Nothing
            l_oFeuilleExcel = Nothing
            l_oAppliExcel = Nothing

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin exportationExcel")
        End Try


        Return False
    End Function


End Class
