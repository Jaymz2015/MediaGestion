Imports Utilitaires
Imports LibAllocine
Imports LibAllocine.Dl.Dto

Public Class CtrlJeux

    Private base As donnees

    Private Const KS_NOM_MODULE = "LibControleurs - CtrlJeux - "

    Private pFicheJVC As FicheJeuJVC

    Public Property FicheJeuJVC() As FicheJeuJVC
        Get
            Return pFicheJVC
        End Get
        Set(ByVal value As FicheJeuJVC)
            pFicheJVC = value
        End Set
    End Property

    Public Sub New(ByVal b As donnees)
        base = b
    End Sub

    Public Function obtenirJeux() As List(Of Jeu)
        Return base.tableJeux.obtenirListe()
    End Function

    Public Function obtenirJeux(ByVal p_sCodeGenre As String, ByVal p_sCodeMachine As String) As List(Of Jeu)
        Return base.tableJeux.obtenirListe(p_sCodeGenre, p_sCodeMachine)
    End Function

    'Fonction qui recherche les jeux en fonction d'un titre, et éventuellement d'une machine ou d'un genre
    Public Function chercherJeux(ByVal p_sTitre As String, ByVal p_oMachine As Machine, ByVal p_oGenre As Genre, _
            ByVal p_sAnnee1 As String, ByVal p_sAnnee2 As String) As List(Of Jeu)

        Dim l_sMachine As String
        Dim l_sGenre As String

        If p_oMachine.Nom = "*" Then
            l_sMachine = Nothing
        Else
            l_sMachine = p_oMachine.Code
        End If
        If p_oGenre.Libelle = "*" Then
            l_sGenre = Nothing
        Else
            l_sGenre = p_oGenre.Code
        End If

        Return base.tableJeux.chercherJeux(p_sTitre, l_sMachine, l_sGenre, p_sAnnee1, p_sAnnee2)
    End Function

    Public Function obtenirGenres() As List(Of Genre)
        Return base.tableGenres.obtenirListe(2)
    End Function

    Public Function obtenirMachines() As List(Of Machine)
        Return base.tableMachines.obtenirListe()
    End Function


    Public Function obtenirPretEnCours(ByVal codeJeu As Guid) As Pret
        Return base.tablePrets.obtenir(Nothing, codeJeu)
    End Function

    'Fonction qui retourne le libellé d'un genre en fonction de son code
    Public Function getLibelle(ByVal code As String) As String

        Dim list As List(Of Genre)

        list = obtenirGenres()

        For i As Integer = 0 To list.Count - 1
            If list(i).Code = code Then
                Return list(i).Libelle
            End If
        Next

        Return Nothing

    End Function

    Public Function ajouterJeu(ByVal titre As String, ByVal genre As String, ByVal dateSortie As DateTime, _
    ByVal jaquette As String, ByVal editeur As String, ByVal developpeur As String, ByVal machine As String, ByVal etatBoitier As Integer, _
    ByVal etatLivret As Integer, ByVal etatJeu As Integer, ByVal estCopie As Boolean) As Jeu

        Dim j As Jeu

        Try
            j = New Jeu(titre, genre, machine, editeur, developpeur, dateSortie, jaquette, Nothing, True, etatBoitier, etatLivret, etatJeu, estCopie)
            base.tableJeux.ajouter(j)
            Return j
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function


    Public Sub modifierJeu(ByVal j As Jeu, ByVal titre As String, ByVal genre As String, ByVal dateSortie As DateTime, _
    ByVal jaquette As String, ByVal editeur As String, ByVal developpeur As String, ByVal machine As String, ByVal etatBoitier As Integer, _
    ByVal etatLivret As Integer, ByVal etatJeu As Integer, ByVal estCopie As Boolean)
        Try
            j.Titre = titre
            j.CodeGenre = genre
            j.DateSortie = dateSortie
            j.Jaquette = jaquette
            j.CodeMachine = machine
            j.Editeur = editeur
            j.Developpeur = developpeur
            j.EtatBoitier = etatBoitier
            j.EtatLivret = etatLivret
            j.EtatJeu = etatJeu
            j.EstCopie = estCopie
            base.tableJeux.modifier(j)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Sub modifierDispo(ByRef p_oJeu As Jeu, ByVal p_bDispo As Boolean)
        p_oJeu.Dispo = p_bDispo

        base.tableJeux.modifier(p_oJeu)
    End Sub

    Public Function effacerJeu(ByVal j As Jeu) As String

        Try
            base.tableJeux.effacer(j)
            Return Nothing
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    'Enregistrement d'un prêt
    Public Function enregistrerPret(ByVal j As Jeu, ByVal datePrete As DateTime, ByVal nom As String, ByVal prenom As String) As Boolean

        Dim p As Pret
        p = New Pret(Nothing, j.Code, datePrete, nom, prenom)

        'Le jeu n'est plus disponible
        j.Dispo = False

        'Mise à jour dans la table jeus de la disponibilité du jeu
        base.tableJeux.modifier(j)

        'AJout du prêt
        base.tablePrets.ajouter(p)

    End Function

    'Modification d'un prêt
    Public Sub clorePret(ByVal p As Pret, ByVal j As Jeu, ByVal dateRendu As Date)

        'Le jeu est de nouveau disponible disponible
        j.Dispo = True

        'Mise à jour dans la table jeus de la disponibilité du jeu
        base.tableJeux.modifier(j)

        'Fermeture du prêt
        p.DateRendu = dateRendu
        base.tablePrets.modifier(p)

    End Sub

    Public Function chercherJeuxAAvoir() As List(Of Jeu)

        Return base.tableJeux.chercherJeuxaAvoir
    End Function

    Public Function RechercheJVC(ByVal p_sTexte As String) As ListeFichesJeuxJVC

        Dim gestionnaireJVC As New GestionnaireJVC()
        RechercheJVC = gestionnaireJVC.RechercherJeu(p_sTexte)

    End Function

    Public Function ObtenirFicheJeuJVC(ByVal p_oFicheJeu As FicheJeuJVC) As FicheJeuJVC

        Dim gestionnaireJVC As New GestionnaireJVC()
        ObtenirFicheJeuJVC = gestionnaireJVC.ObtenirFicheDetailleJeu(p_oFicheJeu)

    End Function

    'Fonction qui retourne le code d'un genre en fonction de son libellé
    Public Function GetCodeLibelle(ByVal p_sLibelle As String) As String

        Dim list As List(Of Genre)


        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début GetCodeLibelle : " + p_sLibelle)

            list = ObtenirGenres()

            Dim l_sLibelle As String = p_sLibelle.Replace(" ", "-")

            For Each g As Genre In list

                Dim l_sGenre = g.Libelle.Replace(" ", "-")

                If l_sGenre.Length >= l_sLibelle.Length _
                AndAlso l_sGenre.ToLower.Contains(l_sLibelle.ToLower) Then
                    Return g.Code
                End If
            Next

            Return Nothing

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR GetCodeLibelle", ex)
            Throw ex
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin GetCodeLibelle")
        End Try

    End Function

    'Fonction qui retourne le code d'un genre en fonction de son libellé
    Public Function GetCodeMachine(ByVal p_sMachine As String) As String

        Dim list As List(Of Machine)

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début GetCodeMachine : " + p_sMachine)

            list = obtenirMachines()

            Dim l_sMachineParam As String = p_sMachine.Replace(" ", "-")

            For Each m As Machine In list

                Dim l_sMachine = m.Nom.Replace(" ", "-")

                If l_sMachine.Length >= l_sMachineParam.Length _
                AndAlso l_sMachine.ToLower.Contains(l_sMachineParam.ToLower) Then
                    Return m.Code
                End If
            Next

            Return Nothing

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR GetCodeMachine", ex)
            Throw ex
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin GetCodeMachine")
        End Try

    End Function

End Class
