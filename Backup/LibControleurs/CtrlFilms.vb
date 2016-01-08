Public Class CtrlFilms

    'Référence sur la DataSet
    Private base As donnees

    Public Sub New(ByVal b As donnees)
        base = b
    End Sub

    Public Function obtenirGenres() As List(Of Genre)
        Return base.tableGenres.obtenirListe(1)
    End Function

    Public Function obtenirFilms() As List(Of Film)
        Return base.tableFilms.obtenirListe()
    End Function

    Public Function obtenirFilms(ByVal p_sCodeGenre As String) As List(Of Film)
        If p_sCodeGenre = "AAA" Then
            Return base.tableFilms.obtenirListe()
        Else
            Return base.tableFilms.obtenirListe(p_sCodeGenre)
        End If
    End Function

    Public Function obtenirPretEnCours(ByVal codeFilm As Guid) As Pret
        Return base.tablePrets.obtenir(codeFilm, Nothing)
    End Function

    'Fonction qui recherche les jeux en fonction d'un titre, et éventuellement d'une machine ou d'un genre
    Public Function chercherFilms(ByVal p_sTitre As String, ByVal p_oGenre1 As Genre, ByVal p_oGenre2 As Genre, _
            ByVal p_sAnnee1 As String, ByVal p_sAnnee2 As String, ByVal p_iDureeMin As Integer, ByVal p_iDureeMax As Integer, _
            ByVal p_sActeur As String, ByVal p_sRealisateur As String) As List(Of Film)

        Dim l_sGenre1 As String
        Dim l_sGenre2 As String

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

        Return base.tableFilms.chercherFilms(p_sTitre, l_sGenre1, l_sGenre2, p_sAnnee1, p_sAnnee2, _
                                                p_iDureeMin, p_iDureeMax, p_sActeur, p_sRealisateur)


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

    Public Function ajouterFilm(ByVal titre As String, ByVal duree As Integer, ByVal genre As String, ByVal dateSortie As DateTime, ByVal leResume As String, _
    ByVal jaquette As String, ByVal realisateur As String, ByVal acteurs As String, ByVal support As String) As Film

        Dim f As Film

        f = New Film(titre, genre, duree, dateSortie, support, leResume, realisateur, acteurs, jaquette, Nothing, True)
        base.tableFilms.ajouter(f)
        Return f

    End Function


    Public Sub modifierFilm(ByVal f As Film, ByVal titre As String, ByVal duree As Integer, ByVal genre As String, ByVal dateSortie As DateTime, ByVal leResume As String, _
    ByVal jaquette As String, ByVal realisateur As String, ByVal acteurs As String, ByVal support As String)

        f.Titre = titre
        f.Duree = duree
        f.CodeGenre = genre
        f.DateSortie = dateSortie
        f.LeResume = leResume
        f.Jaquette = jaquette
        f.leRealisateur = realisateur
        f.lesActeurs = acteurs
        f.Type = support

        base.tableFilms.modifier(f)

    End Sub

    Public Function effacerFilm(ByVal f As Film) As String

        Try
            base.tableFilms.effacer(f)
            Return Nothing
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    'Enregistrement d'un prêt
    Public Function enregistrerPret(ByVal f As Film, ByVal datePrete As DateTime, ByVal nom As String, ByVal prenom As String) As Boolean

        'TODO : gérer la transaction

        Dim p As Pret
        p = New Pret(f.Code, Nothing, datePrete, nom, prenom)

        'Le film n'est plus disponible
        f.Dispo = False

        'Mise à jour dans la table films de la disponibilité du film
        base.tableFilms.modifier(f)

        'AJout du prêt
        base.tablePrets.ajouter(p)

    End Function

    'Modification d'un prêt
    Public Sub clorePret(ByVal p As Pret, ByVal f As Film, ByVal dateRendu As Date)

        'Le film est de nouveau disponible disponible
        f.Dispo = true



        'Mise à jour dans la table films de la disponibilité du film
        base.tableFilms.modifier(f)

        'Fermeture du prêt
        p.DateRendu = dateRendu
        base.tablePrets.modifier(p)

    End Sub



End Class
