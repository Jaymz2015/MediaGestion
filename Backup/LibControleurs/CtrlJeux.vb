Public Class CtrlJeux

    Private base As donnees

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
    ByVal jaquette As String, ByVal editeur As String, ByVal machine As String, ByVal etatBoitier As Integer, _
    ByVal etatLivret As Integer, ByVal etatJeu As Integer, ByVal estCopie As Boolean) As Jeu

        Dim j As Jeu

        Try
            j = New Jeu(titre, genre, machine, editeur, dateSortie, jaquette, Nothing, True, etatBoitier, etatLivret, etatJeu, estCopie)
            base.tableJeux.ajouter(j)
            Return j
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function


    Public Sub modifierJeu(ByVal j As Jeu, ByVal titre As String, ByVal genre As String, ByVal dateSortie As DateTime, _
    ByVal jaquette As String, ByVal editeur As String, ByVal machine As String, ByVal etatBoitier As Integer, _
    ByVal etatLivret As Integer, ByVal etatJeu As Integer, ByVal estCopie As Boolean) 
        Try
            j.Titre = titre
            j.CodeGenre = genre
            j.DateSortie = dateSortie
            j.Jaquette = jaquette
            j.CodeMachine = machine
            j.Editeur = editeur
            j.EtatBoitier = etatBoitier
            j.EtatLivret = etatLivret
            j.EtatJeu = etatJeu
            j.EstCopie = estCopie
            base.tableJeux.modifier(j)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

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

        'TODO : gérer la transaction

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



End Class
