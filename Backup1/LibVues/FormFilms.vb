Imports System.IO
Imports Utilitaires
Imports LibAllocine.Dl.Dto
Imports MediaGestion.Modele
Imports MediaGestion.Metier


Public Class FormFilms

    Private m_oCtrlFilm As CtrlFilms
    Private m_lListe As List(Of Film)
    Private m_iPosition As Integer
    Private m_bModeNew As Boolean
    Private m_ListeRecherche As List(Of Film)
    ' Le libellé du support affiché dans les combos et correspond à ce qui est enregistré en base
    Private m_sSupport As String
    Private m_sFolder As String
    Private m_oLeFilmAffiche As Film
    Private m_bNouvelAffichagePossible As Boolean
    Private m_iNbModif As Integer

    Private Const KS_NOM_MODULE = "LibVues - FormFilms - "

    Private mGestionnaireFilms As GestionnaireFilms


    Public Sub New(ByVal p_oControleur As CtrlFilms)

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début New FormFilms")

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "après initialize component")

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

        'Affectation du controleur
        m_oCtrlFilm = p_oControleur

        mGestionnaireFilms = New GestionnaireFilms

        'Initialisation de la form
        Init()

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin New FormFilms")

    End Sub

#Region "Methodes privées"

    'Initialisation de la fenêtre
    Private Sub Init()

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début init")


            m_sFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            'm_sFolder = "\\" & System.Environment.MachineName & "\Images"


            m_bNouvelAffichagePossible = True
            m_iNbModif = 0
            InfoSaisie.BlinkStyle = ErrorBlinkStyle.NeverBlink

            'On récupère la liste des genres
            Me.CBGenre.ValueMember = "Code"
            Me.CBGenre.DisplayMember = "Libelle"

            Me.CBGenreNavig.ValueMember = "Code"
            Me.CBGenreNavig.DisplayMember = "Libelle"

            'Il faut 2 instances différentes de la liste de genres sinon les 2 combos seront liées
            'On créé donc 2 listes
            Me.CBGenre.DataSource = m_oCtrlFilm.ObtenirGenres
            Me.CBGenreNavig.DataSource = m_oCtrlFilm.ObtenirGenres

            'On récupère la liste des propriétaires
            Me.CBProprietaire.ValueMember = "Code"
            Me.CBProprietaire.DisplayMember = "NomPrenom"

            Me.CBProprietaire.DataSource = m_oCtrlFilm.ObtenirProprietaires

            Me.CBSupport.SelectedIndex = 1

            'Récupération de la liste des films
            m_lListe = m_oCtrlFilm.ObtenirFilms()

            If m_lListe.Count > 0 Then
                'On affiche le premier film
                Call Affiche(LeFilm)
            Else
                Call MiseAJourCompteur()

                Me.BtnDelete.Enabled = False
                Me.BtnSave.Enabled = False
                Me.CheckDispo.Enabled = False
            End If

            Me.BtnAdd.Enabled = True

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR init", ex)

        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin init")
        End Try

    End Sub

    ' Procédure permettant de gérer l'état des boutons de navigation
    Private Sub GestionNavBar()

        Dim l_bEstListeVide As Boolean

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début gestionNavBar")

            'Gestion des boutons de navigation
            If m_lListe.Count > 1 Then

                If m_iPosition = 0 Then
                    Me.BtnPremier.Enabled = False
                    Me.BtnPrec.Enabled = False
                    Me.BtnSuiv.Enabled = True
                    Me.BtnDernier.Enabled = True
                ElseIf m_iPosition = m_lListe.Count - 1 Then
                    Me.BtnPremier.Enabled = True
                    Me.BtnPrec.Enabled = True
                    Me.BtnSuiv.Enabled = False
                    Me.BtnDernier.Enabled = False
                Else
                    Me.BtnPremier.Enabled = True
                    Me.BtnPrec.Enabled = True
                    Me.BtnSuiv.Enabled = True
                    Me.BtnDernier.Enabled = True
                End If

            Else
                Me.BtnPrec.Enabled = False
                Me.BtnSuiv.Enabled = False
                Me.BtnPremier.Enabled = False
                Me.BtnDernier.Enabled = False

            End If

            'Gestion des boutons de gestion

            l_bEstListeVide = (m_lListe.Count = 0)

            Me.BtnDelete.Enabled = Not l_bEstListeVide
            Me.BtnSave.Enabled = Not l_bEstListeVide
            Me.BtnSearch.Enabled = Not l_bEstListeVide
            Me.BtnPrint.Enabled = Not l_bEstListeVide

            Me.BtnAdd.Enabled = Not m_bModeNew
            Me.BtnCancel.Enabled = m_bModeNew

            Me.TBTitre.Enabled = Not l_bEstListeVide
            Me.DTPSortie.Enabled = Not l_bEstListeVide
            Me.TBdureeH.Enabled = Not l_bEstListeVide
            Me.TBdureeM.Enabled = Not l_bEstListeVide
            Me.CBGenre.Enabled = Not l_bEstListeVide
            Me.CBGenre.Enabled = Not l_bEstListeVide
            Me.TBrealisateur.Enabled = Not l_bEstListeVide
            Me.TBacteurs.Enabled = Not l_bEstListeVide
            Me.RtbResume.Enabled = Not l_bEstListeVide
            Me.CheckDispo.Enabled = Not l_bEstListeVide
            Me.CBSupport.Enabled = Not l_bEstListeVide

            'Même si la liste des films, on doit pouvoir modifier la valeur de la combo (pour changer de genre par ex)
            Me.GBNavig.Enabled = True

        Catch ex As Exception

            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR gestionNavBar")
        Finally

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin gestionNavBar")

        End Try

    End Sub

    ' Affichage de la fiche du film : uniquement la pochette dans un premier temps
    Private Sub Affiche(ByVal f As Film)

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début Affiche : " + f.Titre)

            'On bloque un nouvel appel à la méthode affiche tant que celle-ci n'est pas totalement chargée
            m_bNouvelAffichagePossible = False

            m_oLeFilmAffiche = f

            Me.Cursor = Cursors.WaitCursor

            If Dir(m_sFolder + "\Pochettes\DVD\" + f.Jaquette) <> "" Then
                Me.PBJaquette.ImageLocation = m_sFolder + "\Pochettes\DVD\" + f.Jaquette
            ElseIf Dir(m_sFolder + "\Pochettes\DVD\Musique\" + f.Jaquette) <> "" Then
                Me.PBJaquette.ImageLocation = m_sFolder + "\Pochettes\DVD\Musique\" + f.Jaquette
            Else
                Me.PBJaquette.ImageLocation = Nothing
                'On ne charge pas d'image donc on peut directement afficher la suite de la fiche
                AfficheSuite(f)
            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            m_bNouvelAffichagePossible = True
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR Affiche", ex)
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin Affiche")
        End Try

    End Sub

    ' Affichage du reste de la fiche une fois que la pochette est affichée
    Private Sub AfficheSuite(ByVal f As Film)

        Dim l_bEstConcertOuClips As Boolean = False

        Try

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début AfficheSuite : " + f.Titre)

            If f.CodeGenre = "DA" Or f.CodeGenre = "ANIM" Then
                Me.LblActeurs.Text = "Voix :"
            Else
                Me.LblActeurs.Text = "Acteurs :"
            End If

            'Si le media est un concert ou des clips, on affiche pas les acteurs et réalisateur
            l_bEstConcertOuClips = (f.CodeGenre = "LIVE" Or f.CodeGenre = "CLIP")
            Me.LblActeurs.Visible = Not l_bEstConcertOuClips
            Me.TBacteurs.Visible = Not l_bEstConcertOuClips
            Me.LblRealisateur.Visible = Not l_bEstConcertOuClips
            Me.TBrealisateur.Visible = Not l_bEstConcertOuClips

            'Gestion de l'affichage de l'image du support
            If f.Type.ToLower = Constantes.KS_SUPPORT_DVD Then
                Me.CBSupport.SelectedIndex = Constantes.EnumTypeSupport.DVD
                m_sSupport = Constantes.KS_SUPPORT_DVD
            ElseIf f.Type.ToLower = Constantes.KS_SUPPORT_DIVX Then
                Me.CBSupport.SelectedIndex = Constantes.EnumTypeSupport.DIVX
                m_sSupport = Constantes.KS_SUPPORT_DIVX
            ElseIf f.Type.ToLower = Constantes.KS_SUPPORT_TNT Then
                Me.CBSupport.SelectedIndex = Constantes.EnumTypeSupport.TNT
                m_sSupport = Constantes.KS_SUPPORT_TNT
            ElseIf f.Type.ToLower = Constantes.KS_SUPPORT_TNT_HD Then
                Me.CBSupport.SelectedIndex = Constantes.EnumTypeSupport.TNT_HD
                m_sSupport = Constantes.KS_SUPPORT_TNT_HD
            Else
                Me.CBSupport.SelectedIndex = Constantes.EnumTypeSupport.BLURAY
                m_sSupport = Constantes.KS_SUPPORT_BLURAY
            End If

            Me.TBTitre.Text = f.Titre
            Me.TBdureeH.Text = f.Duree \ 60
            Me.TBdureeM.Text = f.Duree Mod 60
            Me.DTPSortie.Text = f.DateSortie
            Me.RtbResume.Text = f.LeResume
            Me.TBrealisateur.Text = f.leRealisateur
            Me.TBacteurs.Text = f.lesActeurs
            Me.CBProprietaire.SelectedValue = f.CodeProprietaire

            Me.CheckDispo.Checked = f.Dispo

            'Gestion des couleurs de la combo dispo
            AffichageComboDispo()

            Me.CBGenre.SelectedValue = f.CodeGenre

            'Mise à jour du compteur
            MiseAJourCompteur()

            'Mise à jour de l'état des boutons de navigation
            GestionNavBar()

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR AfficheSuite", ex)
        Finally

            Me.Cursor = Cursors.Default
            Me.PBJaquette.Focus()
            m_oLeFilmAffiche = Nothing
            m_bNouvelAffichagePossible = True

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin AfficheSuite")
        End Try


    End Sub

    ' Retourne le film affiché
    Private Function LeFilm() As Film

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début LeFilm : position = " + m_iPosition.ToString)

            If Not m_lListe Is Nothing AndAlso m_lListe.Count > 0 Then
                Return m_lListe(m_iPosition)
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR LeFilm", ex)
            Return Nothing
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin LeFilm")

        End Try

    End Function

    ' Gestion du compteur
    Private Sub MiseAJourCompteur()

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début miseAJourCompteur")

            If m_lListe.Count > 0 And Not m_bModeNew Then
                Me.lblCpt.Text = (m_iPosition + 1).ToString + "/" + m_lListe.Count.ToString
            ElseIf m_bModeNew Then
                Me.lblCpt.Text = ""
            Else
                Me.lblCpt.Text = "0/0"
            End If
        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR miseAJourCompteur")
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin miseAJourCompteur")

        End Try

    End Sub

    ' Remise à blanc des champs
    Private Sub RAZ()
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début RAZ")

        MiseAJourCompteur()
        Me.TBTitre.Text = Nothing
        Me.TBrealisateur.Text = Nothing
        Me.TBdureeM.Text = Nothing
        Me.TBdureeH.Text = Nothing
        Me.TBacteurs.Text = Nothing
        Me.RtbResume.Text = Nothing
        Me.PBJaquette.Image = Nothing

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin RAZ")

    End Sub

    ' Active ou désactive les champs de saisie
    Private Sub EtatChamps(ByVal etat As Boolean)

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début etatChamps")

        Me.TBTitre.Enabled = etat
        Me.TBrealisateur.Enabled = etat
        Me.CBGenre.Enabled = etat
        Me.CBProprietaire.Enabled = etat
        Me.TBdureeM.Enabled = etat
        Me.TBdureeH.Enabled = etat
        Me.TBacteurs.Enabled = etat
        Me.RtbResume.Enabled = etat
        Me.PBJaquette.Enabled = etat
        Me.DTPSortie.Enabled = etat
        Me.CheckDispo.Enabled = etat

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin etatChamps")

    End Sub

    Private Sub BlockNavig(ByVal mode As Boolean)

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début blockNavig")

        Me.BtnPremier.Enabled = Not mode
        Me.BtnPrec.Enabled = Not mode
        Me.BtnSuiv.Enabled = Not mode
        Me.BtnDernier.Enabled = Not mode
        Me.GBNavig.Enabled = Not mode

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin blockNavig")
    End Sub

    ' Mise à jour de liste des jeux quand on choisit une navigation par genre
    Private Sub MajListeParGenre()

        Dim l_sCodeGenre As String

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début MajListeParGenre")

            'Si la liste complète n'est pas encore construite, celà indique qu'on est au démarrage de l'appli
            'On ne construit donc pas la liste des films par genre. Au début on construit la liste complète des films
            If Not m_lListe Is Nothing Then

                l_sCodeGenre = ""

                'On récupère les valeurs des codes
                If Not CBGenreNavig.SelectedValue Is Nothing Then
                    l_sCodeGenre = CBGenreNavig.SelectedValue.ToString

                    Log.MonitoringLogger.Info(KS_NOM_MODULE + "Code genre = " + l_sCodeGenre)
                End If

                If l_sCodeGenre <> "" Then
                    'Récupération de la liste
                    m_lListe = m_oCtrlFilm.ObtenirFilms(l_sCodeGenre)
                    EtatChamps(True)

                    ' Si la liste n'est pas vide, on affiche le premier film de la liste
                    If m_lListe.Count > 0 Then
                        m_iPosition = 0
                        Affiche(LeFilm)
                    Else
                        'Aucun film, donc on efface les champs et on les grise. On désactive également les boutons de navigation
                        RAZ()
                        EtatChamps(False)
                        GestionNavBar()
                    End If
                End If

                'Permet de "sortir" des combo
                Me.LblSortie.Select()

            Else
                Log.MonitoringLogger.Info(KS_NOM_MODULE + "On ne fait rien")

            End If

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR MajListeParGenre")

        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin MajListeParGenre")
        End Try

    End Sub

    Private Sub SauverFilm()

        Dim l_iDuree As Integer
        Dim l_sNomImage As String = ""
        Dim l_oNewFilm As Film
        Dim i As Integer

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début SauverFilm : " + Me.TBTitre.Text)

            'Curseur sablier
            Me.Cursor = Cursors.WaitCursor

            If Me.TBdureeM.Text <> "" Then
                l_iDuree = Me.TBdureeH.Text * 60 + Me.TBdureeM.Text
            End If

            If Not Me.PBJaquette.ImageLocation Is Nothing Then
                l_sNomImage = Me.PBJaquette.ImageLocation.Split("\")(Me.PBJaquette.ImageLocation.Split("\").Length - 1)
            End If

            'On ajoute une nouvelle fiche
            If m_bModeNew Then
                Try
                    Log.MonitoringLogger.Info(KS_NOM_MODULE + "On créé une nouvelle fiche")

                    l_oNewFilm = m_oCtrlFilm.AjouterFilm(Me.TBTitre.Text, l_iDuree, Me.CBGenre.SelectedValue, Me.DTPSortie.Value, _
                    Me.RtbResume.Text, l_sNomImage, Me.TBrealisateur.Text, Me.TBacteurs.Text, Me.CBSupport.SelectedItem, Me.CBProprietaire.SelectedValue)

                    'Affichage d'un message
                    MessageBox.Show("Fiche créée avec succès !", "Création", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'on reconstruit la liste complète
                    m_lListe = m_oCtrlFilm.ObtenirFilms
                    Me.CBGenreNavig.SelectedValue = "AAA"

                    'on se place sur la bonne position
                    For i = 0 To m_lListe.Count - 1
                        If l_oNewFilm.Code.ToString = m_lListe.Item(i).Code.ToString Then
                            m_iPosition = i
                        End If
                    Next

                    m_bModeNew = False

                    'On débloque la navigation
                    BlockNavig(False)
                    GestionNavBar()
                    MiseAJourCompteur()

                    'Si la liste est vide on remet tout à zéro sinon on affiche la première fiche
                    If Not LeFilm() Is Nothing Then
                        Call Affiche(LeFilm)
                    Else
                        RAZ()
                    End If
                Catch ex As Exception

                    'Echec de l'enregistrement
                    MessageBox.Show("Erreur à l'enregistrement : " & ex.Message, "Création", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try

            Else
                Try
                    Log.MonitoringLogger.Info(KS_NOM_MODULE + "On modifie une fiche existante")

                    'On modifie une fiche
                    m_oCtrlFilm.ModifierFilm(LeFilm(), Me.TBTitre.Text, l_iDuree, Me.CBGenre.SelectedValue, Me.DTPSortie.Value, Me.RtbResume.Text, _
                     l_sNomImage, Me.TBrealisateur.Text, Me.TBacteurs.Text, Me.CBSupport.SelectedItem, Me.CBProprietaire.SelectedValue)

                    'Mise à jour de la liste des films
                    m_lListe = m_oCtrlFilm.ObtenirFilms(Me.CBGenreNavig.SelectedValue)

                    'Affichage d'un message
                    MessageBox.Show("Modification effectuée !", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    'Affichage d'un message
                    MessageBox.Show("Erreur lors de la modification!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try

            End If

            'On efface les éventuels avertissements de modification
            EffacerSignalModif()

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR SauverFilm")
        Finally
            'Curseur normal
            Me.Cursor = Cursors.Default
            l_oNewFilm = Nothing

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin SauverFilm")

        End Try

    End Sub

    Private Sub FermerFenetre()

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début FermerFenetre")

        'Libération mémoire
        m_oCtrlFilm = Nothing
        m_lListe = Nothing
        m_ListeRecherche = Nothing

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin FermerFenetre")
    End Sub

    Private Sub SupprimerFilm()

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début SupprimerFilm : " + LeFilm.Titre)

            'Affichage d'un message
            If MessageBox.Show("Voulez-vous vraiment supprimer cette fiche ?", "Suppression", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If m_oCtrlFilm.EffacerFilm(LeFilm) Then

                    MessageBox.Show("Suppression réussie ! ", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'Mise à jour de la liste des films
                    'm_lListe = m_oCtrlFilm.obtenirFilms()
                    MajListeParGenre()

                    ' Si la liste n'est pas vide, on affiche le premier film de la liste
                    If m_lListe.Count > 0 Then
                        m_iPosition = 0
                        Affiche(m_lListe(0))
                    Else
                        'Aucun film, donc on efface les champs et on les grise. On désactive également les boutons de navigation
                        RAZ()
                        EtatChamps(False)
                        GestionNavBar()
                        MiseAJourCompteur()
                    End If
                End If
            End If

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR SupprimerFilm", ex)
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin SupprimerFilm")
        End Try

    End Sub

    Private Sub ChercherFilm()
        Dim l_oDialogRecherche As DialogSearchFilm
        Dim l_sTitre As String
        Dim l_oGenre1 As Genre
        Dim l_oGenre2 As Genre
        Dim l_oEcranRecherche As FormSearch
        Dim i As Integer
        Dim l_oFilm As Film
        Dim l_sAnnee1 As String
        Dim l_sAnnee2 As String
        Dim l_sActeur As String
        Dim l_sRealisateur As String

        Dim l_iDureeMin As Integer
        Dim l_iDureeMax As Integer
        Dim l_sSupport As String
        Dim l_oProprietaire As Proprietaire

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début ChercherFilm")

            l_iDureeMin = 0
            l_iDureeMax = 0
            l_oDialogRecherche = New DialogSearchFilm(m_oCtrlFilm)

            If l_oDialogRecherche.ShowDialog() = Windows.Forms.DialogResult.OK Then

                l_sTitre = l_oDialogRecherche.TBSearch.Text
                l_sAnnee1 = l_oDialogRecherche.TBAnnee1.Text
                l_sAnnee2 = l_oDialogRecherche.TBAnnee2.Text
                l_oGenre1 = l_oDialogRecherche.CBGenre1.SelectedItem
                l_oGenre2 = l_oDialogRecherche.CBGenre2.SelectedItem
                l_oProprietaire = l_oDialogRecherche.CBProprietaire.SelectedItem

                If Not (l_oDialogRecherche.TBMmin.Text = "" And l_oDialogRecherche.TBHmin.Text = "") Then
                    l_iDureeMin = Int(l_oDialogRecherche.TBHmin.Text) * 60 + Int(l_oDialogRecherche.TBMmin.Text)
                End If
                If Not (l_oDialogRecherche.TBMmax.Text = "" And l_oDialogRecherche.TBHmax.Text = "") Then
                    l_iDureeMax = Int(l_oDialogRecherche.TBHmax.Text) * 60 + Int(l_oDialogRecherche.TBMmax.Text)
                End If

                l_sActeur = l_oDialogRecherche.TBActeur.Text
                l_sRealisateur = l_oDialogRecherche.TBRealisateur.Text
                l_sSupport = l_oDialogRecherche.CBSupport.SelectedItem

                l_oDialogRecherche = Nothing

                'Récupération de la liste des films
                m_ListeRecherche = m_oCtrlFilm.ChercherFilms(l_sTitre, l_oGenre1, l_oGenre2, l_sAnnee1, l_sAnnee2, _
                                                      l_iDureeMin, l_iDureeMax, l_sActeur, l_sRealisateur, l_sSupport, l_oProprietaire)

                'Si la liste n'est pas vide, on affiche la liste des films trouvés dans une nouvelle fenêtre
                If Not m_ListeRecherche Is Nothing AndAlso m_ListeRecherche.Count > 0 Then
                    'Affichage de la liste des films trouvés
                    l_oEcranRecherche = New FormSearch(m_oCtrlFilm, m_ListeRecherche)
                    'Si on clique sur OK on affiche le film
                    l_oEcranRecherche.ShowDialog()

                    If l_oEcranRecherche.ChoixRealise Then

                        'on reconstruit la liste complète
                        Me.CBGenreNavig.SelectedValue = "AAA"

                        For i = 0 To m_lListe.Count - 1

                            l_oFilm = m_lListe.Item(i)

                            If (l_oFilm.Code.ToString = l_oEcranRecherche.FilmSelectionne.Code.ToString) Then
                                m_iPosition = i
                                Exit For
                            End If
                        Next
                        Affiche(LeFilm)
                    End If
                    l_oEcranRecherche = Nothing
                Else
                    MessageBox.Show("Aucun film n'a été trouvé !", "Résultat", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If
        Catch ex As Exception
            MessageBox.Show("Erreur : " + ex.Message)
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "ERREUR ChercherFilm", ex)
        Finally
            l_oDialogRecherche = Nothing
            l_oGenre1 = Nothing
            l_oGenre2 = Nothing
            l_oEcranRecherche = Nothing
            l_oFilm = Nothing
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin ChercherFilm")
        End Try

    End Sub

    Private Sub ChercherFilmsaAvoir()

        Dim l_oGenre1 As Genre
        Dim l_oGenre2 As Genre
        Dim l_oEcranRecherche As FormSearch
        Dim i As Integer
        Dim l_oFilm As Film

        Dim l_iDureeMin As Integer
        Dim l_iDureeMax As Integer

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début ChercherFilmsaAvoir")

            l_iDureeMin = 0
            l_iDureeMax = 0

            'Récupération de la liste des jeux
            m_ListeRecherche = m_oCtrlFilm.ChercherFilmsaAvoir()

            'Si la liste n'est pas vide, on affiche la liste des films trouvés dans une nouvelle fenêtre
            If Not m_ListeRecherche Is Nothing AndAlso m_ListeRecherche.Count > 0 Then
                'Affichage de la liste des films trouvés
                l_oEcranRecherche = New FormSearch(m_oCtrlFilm, m_ListeRecherche)
                'Si on clique sur OK on affiche le film
                l_oEcranRecherche.ShowDialog()

                If l_oEcranRecherche.ChoixRealise Then

                    For i = 0 To m_lListe.Count - 1

                        l_oFilm = m_lListe.Item(i)

                        If (l_oFilm.Code.ToString = l_oEcranRecherche.FilmSelectionne.Code.ToString) Then
                            m_iPosition = i
                            Exit For
                        End If
                    Next
                    Affiche(LeFilm)
                End If
                l_oEcranRecherche = Nothing
            Else
                MessageBox.Show("Aucun film n'a été trouvé !", "Résultat", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR ChercherFilmsaAvoir")
        Finally
            l_oGenre1 = Nothing
            l_oGenre2 = Nothing
            l_oEcranRecherche = Nothing
            l_oFilm = Nothing
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin ChercherFilmsaAvoir")
        End Try


    End Sub

    Private Sub AnnulerModification()
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début AnnulerModification")

        If m_bModeNew Then
            m_bModeNew = False

            If m_lListe.Count > 0 Then
                Call Affiche(LeFilm)
            Else
                Call RAZ()
                Call GestionNavBar()
            End If
        End If

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin AnnulerModification")
    End Sub

    Private Sub AjouterFilm()

        Dim l_oProprietaire As Proprietaire

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début AjouterFilm")

            m_bModeNew = True

            Me.BtnSave.Enabled = True
            Me.BtnAdd.Enabled = False
            Me.BtnDelete.Enabled = False
            Me.BtnPrint.Enabled = False
            Me.BtnCancel.Enabled = True
            Me.CheckDispo.Enabled = False

            Me.CBGenre.Enabled = True
            Me.CBProprietaire.Enabled = True
            Me.TBTitre.Enabled = True
            Me.TBdureeH.Enabled = True
            Me.TBdureeM.Enabled = True
            Me.TBacteurs.Enabled = True
            Me.TBrealisateur.Enabled = True
            Me.RtbResume.Enabled = True
            Me.DTPSortie.Enabled = True
            Me.PBJaquette.Enabled = True
            Me.GBNavig.Enabled = True
            Me.CBSupport.Enabled = True

            Me.LblActeurs.Visible = True
            Me.TBacteurs.Visible = True
            Me.LblRealisateur.Visible = True
            Me.TBrealisateur.Visible = True

            Me.CBGenre.SelectedIndex = 0

            Me.CBSupport.SelectedItem = "BRay"

            'choisir le propriétaire par défaut
            l_oProprietaire = m_oCtrlFilm.ObtenirProprietaireParDefaut()

            If Not l_oProprietaire Is Nothing Then
                Me.CBProprietaire.SelectedValue = m_oCtrlFilm.ObtenirProprietaireParDefaut().Code()
            Else
                Me.CBProprietaire.SelectedIndex = 1
            End If


            'En mode ajout la navigation devient impossible
            Call BlockNavig(True)

            'Mise à jour du compteur
            Call MiseAJourCompteur()

            'Réinitialisation des champs
            With Me
                .TBTitre.Text = Nothing
                .TBdureeH.Text = Nothing
                .TBdureeM.Text = Nothing
                .TBacteurs.Text = Nothing
                .TBrealisateur.Text = Nothing
                .RtbResume.Text = Nothing
                .DTPSortie.Value = Now
                .PBJaquette.ImageLocation = Nothing
            End With

            'Permet de "sortir" des combo
            Me.TBTitre.Select()

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR AjouterFilm", ex)
            MessageBox.Show("Erreur à l'initialisation d'une nouvelle fiche. Erreur = " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin AjouterFilm")
        End Try


    End Sub

    'Mise à jour des champs suite à une recherche sur Allociné
    Private Sub MAJchamps(ByVal p_oFilm As FicheFilmAllocine)

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début MAJchamps")

            Me.TBTitre.Text = p_oFilm.Titre
            Me.TBrealisateur.Text = p_oFilm.Casting.Realisateur
            Me.TBacteurs.Text = p_oFilm.Casting.Acteurs

            Dim duree As Integer
            duree = p_oFilm.Duree / 60

            Me.TBdureeH.Text = duree \ 60
            Me.TBdureeM.Text = duree Mod 60

            Me.DTPSortie.Text = p_oFilm.InfosSortie.DateSortie
            Me.RtbResume.Text = p_oFilm.LeSynopsis


            'Dim codeGenre As String = m_oCtrlFilm.GetCodeLibelle(p_oFilm.ListeGenres.LeGenre)
            Dim codeGenre As String = m_oCtrlFilm.GetCodeLibelle(p_oFilm.LeGenre.Libelle)

            If Not codeGenre = "" Then
                Me.CBGenre.SelectedValue = codeGenre
            End If

            'Déplacer la jaquette
            Dim l_sSouceFile As String
            l_sSouceFile = "C:\Temp\" + p_oFilm.NomJaquette
            Dim l_sDestFile As String
            l_sDestFile = m_sFolder + "\Pochettes\DVD\" + p_oFilm.NomJaquette

            Log.MonitoringLogger.Info(KS_NOM_MODULE + String.Format("Déplacement du fichier {0} vers le fichier {1}.", l_sSouceFile, l_sDestFile))

            'On regarde si l'image existe déjà, si c'est le cas on la supprime
            If (File.Exists(l_sDestFile)) Then
                File.Delete(l_sDestFile)
            End If

            File.Move(l_sSouceFile, l_sDestFile)

            If Dir(m_sFolder + "\Pochettes\DVD\" + p_oFilm.NomJaquette) <> "" Then
                Me.PBJaquette.ImageLocation = m_sFolder + "\Pochettes\DVD\" + p_oFilm.NomJaquette
            ElseIf Dir(m_sFolder + "\Pochettes\DVD\Musique\" + p_oFilm.NomJaquette) <> "" Then
                Me.PBJaquette.ImageLocation = m_sFolder + "\Pochettes\DVD\Musique\" + p_oFilm.NomJaquette
            Else
                Me.PBJaquette.ImageLocation = Nothing
            End If

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR MAJchamps", ex)

        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin MAJchamps")

        End Try

    End Sub

    'Efface les avertissements de modifications apportées
    Private Sub EffacerSignalModif()
        InfoSaisie.Clear()
        m_iNbModif = 0
    End Sub

    'Si des modifications doivent être enregistrées, on propose de les enregistrer
    Private Function ResterSurCetteFicheCarModificationsEnCours()

        Dim l_oDialogResult As System.Windows.Forms.DialogResult
        Dim l_bResterSurCetteFiche As Boolean

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début ResterSurCetteFicheCarModificationsEnCours : ")

            l_bResterSurCetteFiche = False

            If m_iNbModif > 0 Then

                l_oDialogResult = MessageBox.Show("Des modifications ont été apportées. Voulez-vous les sauvegarder ?", "Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

                If l_oDialogResult = Windows.Forms.DialogResult.Yes Then
                    SauverFilm()
                ElseIf l_oDialogResult = Windows.Forms.DialogResult.No Then
                    EffacerSignalModif()
                Else
                    l_bResterSurCetteFiche = True
                End If

            End If

            Return l_bResterSurCetteFiche
        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR ResterSurCetteFicheCarModificationsEnCours : ")
            Return False
        Finally
            l_oDialogResult = Nothing
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin ResterSurCetteFicheCarModificationsEnCours : " + l_bResterSurCetteFiche.ToString)
        End Try

    End Function


#End Region

#Region "Gestion des événements"

    Private Sub FormFilms_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        FermerFenetre()
    End Sub

    Private Sub FormFilms_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.Control And (e.KeyCode = Keys.S) Then
            If Me.BtnSave.Enabled Then
                SauverFilm()
            End If
        ElseIf e.Control And (e.KeyCode = Keys.Q) Then
            Me.Close()
        ElseIf e.Control And e.KeyCode = Keys.Delete Then
            If Me.BtnDelete.Enabled Then
                SupprimerFilm()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            If Me.BtnSearch.Enabled Then
                AnnulerModification()
            End If
        ElseIf e.Control And (e.KeyCode = Keys.F) Then
            If Me.BtnSearch.Enabled Then
                ChercherFilm()
            End If
        ElseIf e.KeyCode = Keys.Add Then
            If Me.BtnSearch.Enabled And Not m_bModeNew Then
                e.SuppressKeyPress = True
                AjouterFilm()
            End If
        ElseIf e.KeyCode = Keys.F5 Then
            'On rafraichi la fenêtre
            Affiche(LeFilm)
        End If

    End Sub

    Private Sub FormFilms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début FormFilms_Load")

        Me.Dock = DockStyle.Fill

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin FormFilms_Load")

    End Sub

    Private Sub PBJaquette_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBJaquette.Click

        Dim l_sFolder As String
        Dim l_oDlgOuvrir As OpenFileDialog

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début PBJaquette_Click")

            If m_lListe.Count > 0 Or m_bModeNew Then

                'Répertoire contenant les jaquettes de films
                'l_sFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\Pochettes\DVD"
                l_sFolder = Constantes.NOM_REPERTOIRE_IMAGES + "Pochettes/DVD/"

                If Not Directory.Exists(l_sFolder) Then
                    Directory.CreateDirectory(l_sFolder)
                End If

                l_oDlgOuvrir = New OpenFileDialog
                l_oDlgOuvrir.RestoreDirectory = True
                l_oDlgOuvrir.Title = "Sélection de la jaquette"
                l_oDlgOuvrir.Filter = "Images|*.jpg"
                l_oDlgOuvrir.AddExtension = False
                l_oDlgOuvrir.InitialDirectory = Path.GetFullPath(l_sFolder)

                If Not l_oDlgOuvrir.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                    Me.PBJaquette.ImageLocation = l_oDlgOuvrir.FileName
                End If
            End If

        Catch ex As Exception

            mGestionnaireFilms.TraiterErreur(KS_NOM_MODULE, "PBJaquette_Click", ex, True)

        Finally
            l_oDlgOuvrir = Nothing
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin PBJaquette_Click")
        End Try

    End Sub

    ' Boutons de navigation
    Private Sub BtnNavig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPremier.Click, BtnPrec.Click, BtnSuiv.Click, BtnDernier.Click

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début BtnNavig_Click : " + TypeName(sender))

        If m_bNouvelAffichagePossible And Not m_bModeNew Then

            'On vérifie si des modifications doivent être enregistrées
            If Not ResterSurCetteFicheCarModificationsEnCours() Then

                If sender Is BtnPremier Then
                    'Premier film
                    m_iPosition = 0
                ElseIf sender Is BtnPrec Then
                    'Film précédent
                    If m_iPosition > 0 Then
                        m_iPosition -= 1
                    End If
                ElseIf sender Is BtnSuiv Then
                    'Film suivant
                    If m_iPosition < m_lListe.Count - 1 Then
                        m_iPosition += 1
                    End If
                ElseIf sender Is BtnDernier Then
                    'Dernier film
                    m_iPosition = m_lListe.Count - 1
                End If

                Affiche(m_lListe(m_iPosition))

            End If

        End If

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin BtnNavig_Click")


    End Sub

    ' Action sur la roulette de la souris
    Private Sub FormFilms_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel

        Dim l_bResterSurCetteFiche As Boolean

        Try
            l_bResterSurCetteFiche = False

            If Not m_bModeNew And m_bNouvelAffichagePossible Then

                If sender Is Me And Not ResterSurCetteFicheCarModificationsEnCours() Then
                    If (e.Delta > 0) Then
                        'Film précédent
                        If m_iPosition > 0 Then
                            m_iPosition -= 1
                        End If
                    Else
                        'Film suivant
                        If m_iPosition < m_lListe.Count - 1 Then
                            m_iPosition += 1
                        End If
                    End If

                    Affiche(m_lListe(m_iPosition))
                End If
            End If

        Catch ex As Exception

        Finally

        End Try

    End Sub

    ' Ajout d'un film
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début BtnAdd_Click")
        AjouterFilm()
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin BtnAdd_Click")
    End Sub

    ' Suppression d'un film
    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début BtnDelete_Click")
        SupprimerFilm()
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin BtnDelete_Click")
    End Sub

    '------------------------------------------------------------------------
    'BOUTON SAUVER
    '------------------------------------------------------------------------
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début BtnSave_Click")
        SauverFilm()
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin BtnSave_Click")
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début BtnPrint_Click")

        'affiche un aperçu de l'impression

        PrintPreviewDialog1.Width = 1200
        PrintPreviewDialog1.Height = 800

        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1

        CType(PrintPreviewDialog1, System.Windows.Forms.Form).WindowState = System.Windows.Forms.FormWindowState.Maximized

        PrintDocument1.DefaultPageSettings.Landscape = True

        PrintPreviewDialog1.ShowDialog()

        'PrintDocument1.Print()

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin BtnPrint_Click")

    End Sub

    ' Algorithme d'impression de la jaquette : justifie le texte à droite et à gauche
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début PrintDocument1_PrintPage")


        Dim l_oFilm As Film = m_lListe(m_iPosition)

        ' On découpe le résumé en mots
        Dim l_sMots() As String = Nothing

        'La taille des éléments graphics est exprimée en 1/100 de pouces. 1 pouce = 2,54 cm
        'Coordonnées du bord supérieur gauche de la jaquette
        Dim l_iXj As Integer = 100
        Dim l_iYj As Integer = 200

        'Page de gauche
        Dim RG As Rectangle

        'Page de droite
        Dim RD As Rectangle

        Dim RC As Rectangle

        ' taille du rectangle
        Dim taille As Integer = 472
        Dim tailleR As Integer = taille - 2 * 30

        'définition des polices
        Dim Police As New Font("Arial", 10)

        Dim Police2 As New Font("Arial", 10, FontStyle.Bold)

        Dim sf As StringFormat = StringFormat.GenericTypographic

        'Hauteur d'une ligne en fonction de la police choisie
        Dim HL As Single = Police.GetHeight(e.Graphics)

        Dim i As Integer

        Dim depart As PointF = RC.Location

        Dim tailleEspace As Integer
        Dim noLigne As Integer = 0
        Dim tailleLigne As Integer

        Dim nbMots As Integer = 0
        Dim im As System.Drawing.Bitmap

        Dim ratio As Double
        Dim hauteurIM As Integer

        Dim genre As String
        Dim EnTete As String

        Dim x As Integer
        Dim y As Integer


        'Définition des 2 pages
        RG = New Rectangle(l_iXj, l_iYj, taille, taille)
        RD = New Rectangle(l_iXj + taille, l_iYj, taille, taille)

        e.Graphics.DrawRectangle(Pens.Black, RG)
        e.Graphics.DrawRectangle(Pens.Black, RD)

        'Définition de l'image et centrage sur la page de gauche
        im = New System.Drawing.Bitmap(m_sFolder + "\Pochettes\DVD\" + l_oFilm.Jaquette)

        ratio = im.Height / im.Width

        hauteurIM = 236 * ratio '236 est la largeur fixe de toutes les images

        'x = (W-w)/2  y = (H-h)2
        e.Graphics.DrawImage(im, 118 + l_iXj, CType((taille - hauteurIM) / 2, Integer) + l_iYj, 236, hauteurIM)

        e.Graphics.DrawString(l_oFilm.Titre, Police2, Brushes.Black, l_iXj + taille + 30, l_iYj + 30)

        'Rectangle pour l'entête
        Dim RE As Rectangle = New Rectangle(l_iXj + taille + 30, l_iYj + 30 + 2 * HL, tailleR, 6 * HL)

        'e.Graphics.DrawRectangle(Pens.Black, RE)

        'Libellé du genre
        genre = m_oCtrlFilm.GetLibelle(l_oFilm.CodeGenre)

        EnTete = "Sortie : " & Format(l_oFilm.DateSortie, "d MMMM yyyy") & vbCrLf & _
                "Durée : " & l_oFilm.Duree \ 60 & "h " & l_oFilm.Duree Mod 60 & "mn" & vbCrLf & _
                "Genre : " & genre & vbCrLf & _
                "Réalisateur : " & l_oFilm.leRealisateur & vbCrLf
        If l_oFilm.CodeGenre = "ANIM" Or l_oFilm.CodeGenre = "DA" Then
            EnTete = EnTete & "Voix : " & l_oFilm.lesActeurs & vbCrLf
        Else
            EnTete = EnTete & "Acteurs : " & l_oFilm.lesActeurs & vbCrLf
        End If

        e.Graphics.DrawString(EnTete, Police, Brushes.Black, RE)

        'Rectangle pour le corps
        RC = New Rectangle(l_iXj + taille + 30, l_iYj + 30 + 10 * HL, tailleR, 16 * HL)

        'e.Graphics.DrawRectangle(Pens.Black, RC)

        ' Ecriture du corps
        '-----------------------------------------------------------------

        l_sMots = l_oFilm.LeResume.Split

        Dim taillesMots(l_sMots.Length - 1) As Integer

        'on commence au coin supérieur gauche du rectangle
        depart = RC.Location

        ' Taille de chaque mot
        For i = 0 To l_sMots.Length - 1
            taillesMots(i) = e.Graphics.MeasureString(l_sMots(i), Police, depart, sf).Width
        Next

        'indique l'index du 1er mot de la ligne en cours de traitement dans le paragraphe
        Dim pos As Integer = 0

        'début de la boucle
        '----------------------------

        'tant qu'il reste des mots à écrire
        Do While (pos < l_sMots.Length)

            nbMots = 0

            ' On recherche le nombre de mots qu'il est possible de mettre
            While tailleLigne < tailleR And (nbMots + pos) < l_sMots.Length
                tailleLigne = tailleLigne + taillesMots(nbMots + pos)
                nbMots = nbMots + 1
            End While

            Dim reste As Integer

            'On retire le dernier mot si la ligne est plus longue que la largeur du cadre : ici la ligne prend toute la largeur
            If tailleLigne > tailleR Then
                nbMots = nbMots - 1
                tailleLigne = tailleLigne - taillesMots(nbMots + pos)
            End If

            'si on est à la dernière ligne, on attribue un espacement fixe de 4 pixels entre le mots, sinon on le calcule
            If nbMots + pos >= l_sMots.Length Then
                tailleEspace = 4

            Else

                ' Calcul de l'espace entre les mots = largeur du rectangle d'écriture - largeur de tous les mots sur la ligne / nombre de mots-1
                If nbMots > 1 Then
                    tailleEspace = (tailleR - tailleLigne) \ (nbMots - 1)
                    reste = (tailleR - tailleLigne) Mod (nbMots - 1)
                End If

                'Si l'espace entre les mots est trop serré, on retire des mots
                While (tailleEspace < 3 And nbMots > 2)
                    'On retire le dernier mot
                    nbMots = nbMots - 1
                    tailleLigne = tailleLigne - taillesMots(nbMots + pos)

                    tailleEspace = (tailleR - tailleLigne) \ (nbMots - 1)
                    reste = (tailleR - tailleLigne) Mod (nbMots - 1)
                End While

            End If

            ' Coordonnées du point d'insertion du mot sur la page
            x = depart.X
            y = depart.Y + noLigne * HL

            'construction d'un tableau conservant les espaces entre les mots s'il reste au moins 2 mots à écrire
            If (nbMots > 1) Then
                Dim espace(nbMots - 2) As Integer

                For i = 0 To espace.Length - 1
                    espace(i) = tailleEspace
                Next

                i = 0
                'on distribue les pixels d'espaces restants en les ajoutants 1 à 1 dans le tableau des espaces
                While reste > 0
                    espace(i) += 1
                    reste -= 1
                    i += 1
                End While

                ' Construction de la ligne
                For i = 0 To nbMots - 1
                    e.Graphics.DrawString(l_sMots(i + pos), Police, Brushes.Black, x, y, StringFormat.GenericTypographic)
                    'on définit la position suivante : inutile lorsqu'on arrive au dernier mot de la ligne
                    If i < nbMots - 1 Then x = x + taillesMots(i + pos) + espace(i)
                Next

            Else
                e.Graphics.DrawString(l_sMots(pos), Police, Brushes.Black, x, y, StringFormat.GenericTypographic)
            End If

            'on réinitialise les tailles de ligne et d'espace entre les mots
            tailleLigne = 0
            tailleEspace = 0

            'on décale d'une ligne vers le bas
            noLigne += 1

            'on décale le curseur dans le tableau des mots
            pos += nbMots

        Loop

        l_oFilm = Nothing
        l_sMots = Nothing
        RG = Nothing
        RD = Nothing
        RC = Nothing
        Police = Nothing
        Police2 = Nothing
        sf = Nothing
        depart = Nothing
        im = Nothing

        'PrintDialog1.ShowDialog()

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin PrintDocument1_PrintPage")

    End Sub

    ' Formatage de la durée du film
    Private Sub TBdureeM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TBdureeM.Validating

        Try
            If (TBdureeM.Text > 60) Then
                Me.TBdureeH.Text = TBdureeM.Text \ 60
                Me.TBdureeM.Text = TBdureeM.Text Mod 60
            End If
        Catch ex As Exception
            Me.TBdureeH.Text = Nothing
            Me.TBdureeM.Text = Nothing
        End Try

    End Sub

    'Clic sur bouton Allocine
    Private Sub BtnAllocine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAllocine.Click

        Dim tableau() As String
        Dim motsCles As String = ""
        Dim l_sUrl As String = ""
        Dim l_oFicheAllocine As FicheFilmAllocine
        Dim l_oEcranRecherche As FormSearch
        Dim l_oFilm As Film
        Dim l_oListeFichesFilmsAllocine As ListeFichesFilmsAllocine

        Dim l_cListeFilms As List(Of FicheFilmAllocine)

        l_oEcranRecherche = Nothing

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début BtnAllocine_Click")

            'Initialisations
            l_oFicheAllocine = Nothing
            tableau = Me.TBTitre.Text.Split
            l_oFilm = Nothing

            'Construction de l'URL

            '------------------------------'
            ' ALLOCINE
            '------------------------------'

            Me.Cursor = Cursors.WaitCursor

            l_oListeFichesFilmsAllocine = m_oCtrlFilm.RechercheAllocineV2(Me.TBTitre.Text)

            Me.Cursor = Cursors.Default

            If l_oListeFichesFilmsAllocine.NbResultats > 0 Then

                'Affichage du résultat dans une nouvelle fenêtre
                l_oEcranRecherche = New FormSearch(m_oCtrlFilm, l_oListeFichesFilmsAllocine)

                'Si on valide par OK, on ouvre un explorateur
                If l_oEcranRecherche.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    l_oFicheAllocine = m_oCtrlFilm.FicheAllocine

                    If Not l_oFicheAllocine Is Nothing Then

                        Me.Cursor = Cursors.WaitCursor

                        l_oFicheAllocine = m_oCtrlFilm.ObtenirFicheFilmAllocineV2(l_oFicheAllocine.Code)

                        Me.Cursor = Cursors.Default

                        If MessageBox.Show("Données récupérées avec succès. Voulez-vous mettre à jour les champs ?", "Allociné", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                            MAJchamps(l_oFicheAllocine)
                        End If

                        If MessageBox.Show("Voulez-vous consulter la fiche sur  Allocine.fr ?", "Allociné", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                            System.Diagnostics.Process.Start(l_oFicheAllocine.ListeURLs.Lien.Url)
                        End If

                    Else
                        MessageBox.Show("Objet non défini", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                End If

            Else
                MessageBox.Show("Aucun résultat !", "Recherche", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception

            Me.Cursor = Cursors.Default
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR BtnAllocine_Click", ex)

            If Not l_oEcranRecherche Is Nothing AndAlso l_oEcranRecherche.Visible Then
                l_oEcranRecherche.Close()
            End If


            MessageBox.Show("Erreur lors de la récupération des données du site Allocine : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            l_oFicheAllocine = Nothing
            l_cListeFilms = Nothing
            l_oEcranRecherche = Nothing
            l_oFicheAllocine = Nothing

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin BtnAllocine_Click")

        End Try
    End Sub

    ' Mise a jour de la liste des films quand on choisit un genre
    Private Sub CBGenreNavig_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBGenreNavig.SelectedValueChanged

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début CBGenreNavig_SelectedValueChanged")

        If Not m_bModeNew Then
            MajListeParGenre()
        End If

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin CBGenreNavig_SelectedValueChanged")

    End Sub

    ' Changement de couleur et de texte de la combo Disponibilités
    Private Sub CheckDispo_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckDispo.CheckStateChanged
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début CheckDispo_CheckStateChanged")
        AffichageComboDispo()
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin CheckDispo_CheckStateChanged")
    End Sub

    ' Changement de couleur et de texte de la combo Disponibilités
    Private Sub AffichageComboDispo()
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début AffichageComboDispo")

        If CheckDispo.Checked Then
            CheckDispo.Text = "Disponible"
            CheckDispo.ForeColor = Color.Green
        Else
            CheckDispo.Text = "Indisponible"
            CheckDispo.ForeColor = Color.Red
        End If

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin AffichageComboDispo")
    End Sub

    ' Choix de la disponibilité
    Private Sub CheckDispo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckDispo.Click


        Dim l_bMode As Boolean
        Dim l_oEcran As DialogPret
        Dim l_iReponse As System.Windows.Forms.DialogResult

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début CheckDispo_Click")

            'Mode enregistrement d'un prêt
            'Si false, alors on effectue un emprunt
            'Si true, on restitue le film ou acquisition
            l_bMode = CheckDispo.Checked

            If CheckDispo.Checked Then

                'On regarde si un prêt est en cours pour savoir s'il s'agit d'une restitution ou d'une acquisition
                If Not m_oCtrlFilm.ObtenirPretEnCours(LeFilm.Code) Is Nothing Then
                    'Il s'agit d'une restitution
                    l_oEcran = New DialogPret(m_oCtrlFilm, LeFilm(), enumStatutDispo.rendu, Me)

                    'Annulation sur l'écran de prêt
                    If l_oEcran.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                        'on revient à l'état initial
                        CheckDispo.Checked = Not l_bMode
                    End If

                Else
                    'Il s'agit d'une acquisition
                    'Il faut uniquement enregistrer le statut du film à dispo
                    m_oCtrlFilm.ModifierDispo(LeFilm(), True)

                End If

            Else

                l_iReponse = MessageBox.Show("S'agit-il d'un film à acquérir ?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

                If l_iReponse = Windows.Forms.DialogResult.No Then
                    'Il s'agit d'un emprunt
                    l_oEcran = New DialogPret(m_oCtrlFilm, LeFilm(), enumStatutDispo.emprunte, Me)

                    'Annulation sur l'écran de prêt
                    If l_oEcran.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                        'on revient à l'état initial
                        CheckDispo.Checked = Not l_bMode
                    End If

                ElseIf l_iReponse = Windows.Forms.DialogResult.Yes Then
                    'Il s'agit d'un jeu à acquérir
                    'Il faut uniquement enregistrer le statut du film à non dispo
                    m_oCtrlFilm.ModifierDispo(LeFilm(), False)
                Else
                    'on revient à l'état initial
                    CheckDispo.Checked = Not l_bMode
                End If

            End If

        Catch ex As Exception
            'On revient à l'état initial
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR CheckDispo_Click")
            CheckDispo.Checked = Not l_bMode
            MessageBox.Show("Erreur : " & ex.Message, "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            l_oEcran = Nothing
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin CheckDispo_Click")

        End Try


    End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début BtnCancel_Click")
        AnnulerModification()
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin BtnCancel_Click")
    End Sub

    Private Sub Combos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBSupport.SelectedIndexChanged, CBGenre.SelectedIndexChanged, CBProprietaire.SelectedIndexChanged

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début Combos_SelectedIndexChanged")

            If sender Is CBSupport Then
                m_sSupport = Me.CBSupport.SelectedItem.ToString.ToLower

                If m_sSupport = Constantes.KS_SUPPORT_DVD Then
                    PB_Support.Image = GestionMedias.My.Resources.Resources.dvd
                ElseIf m_sSupport = Constantes.KS_SUPPORT_DIVX Then
                    PB_Support.Image = GestionMedias.My.Resources.Resources.divx
                ElseIf m_sSupport.ToLower().Replace(" ", "") = Constantes.KS_SUPPORT_TNT_HD Then
                    PB_Support.Image = GestionMedias.My.Resources.Resources.tnt_hd
                ElseIf m_sSupport = Constantes.KS_SUPPORT_TNT Then
                    PB_Support.Image = GestionMedias.My.Resources.Resources.tnt
                Else
                    PB_Support.Image = GestionMedias.My.Resources.Resources.bluray
                End If
            End If

            'Si on est en modification de film, on vérifie si des champs sont modifiés par l'utilisateur
            If Not m_bModeNew AndAlso m_bNouvelAffichagePossible AndAlso Not LeFilm() Is Nothing Then
                If sender Is CBSupport Then
                    If CBSupport.SelectedValue <> LeFilm.Type Then
                        InfoSaisie.SetError(sender, "modification effectuée")
                        m_iNbModif += 1
                    Else
                        'Il y avait une erreur, il faut la supprimer
                        If InfoSaisie.GetError(sender) <> "" Then
                            InfoSaisie.SetError(sender, Nothing)
                            m_iNbModif -= 1
                        End If
                    End If

                End If

                If sender Is CBProprietaire Then

                    If CBProprietaire.SelectedValue <> LeFilm.CodeProprietaire Then
                        InfoSaisie.SetError(sender, "modification effectuée")
                        m_iNbModif += 1
                    Else
                        'Il y avait une erreur, il faut la supprimer
                        If InfoSaisie.GetError(sender) <> "" Then
                            InfoSaisie.SetError(sender, Nothing)
                            m_iNbModif -= 1
                        End If
                    End If
                End If

                If sender Is CBGenre Then

                    If CBGenre.SelectedValue <> LeFilm.CodeGenre Then
                        InfoSaisie.SetError(sender, "modification effectuée")
                        m_iNbModif += 1
                    Else
                        'Il y avait une erreur, il faut la supprimer
                        If InfoSaisie.GetError(sender) <> "" Then
                            InfoSaisie.SetError(sender, Nothing)
                            m_iNbModif -= 1
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR Combos_SelectedIndexChanged", ex)
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin Combos_SelectedIndexChanged")
        End Try

    End Sub

    ' Recherche d'un film
    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début BtnSearch_Click")
        ChercherFilm()
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin BtnSearch_Click")
    End Sub

    ' Recherche des films à acquérir
    Private Sub BtnFilmsaAvoir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFilmsaAvoir.Click
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début BtnFilmsaAvoir_Click")
        ChercherFilmsaAvoir()
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin BtnFilmsaAvoir_Click")
    End Sub

    Private Sub PBJaquette_LoadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles PBJaquette.LoadCompleted
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début PBJaquette_LoadCompleted")

        'Affichage de la suite de la fiche
        If Not m_bNouvelAffichagePossible Then
            AfficheSuite(m_oLeFilmAffiche)
        Else
            'Modification de la pochette
            If Not m_bModeNew AndAlso Not LeFilm() Is Nothing Then
                If Not PBJaquette.ImageLocation.Contains(LeFilm.Jaquette) Then
                    InfoSaisie.SetError(sender, "modification effectuée")
                    m_iNbModif += 1
                Else
                    'Il y avait une erreur, il faut la supprimer
                    If InfoSaisie.GetError(sender) <> "" Then
                        InfoSaisie.SetError(sender, Nothing)
                        m_iNbModif -= 1
                    End If
                End If
            End If

        End If
        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin PBJaquette_LoadCompleted")
    End Sub

    Private Sub TextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBTitre.TextChanged, TBacteurs.TextChanged, TBrealisateur.TextChanged, TBdureeH.TextChanged, TBdureeM.TextChanged, RtbResume.TextChanged

        Try
            'Si on est en modification de film, on vérifie si des champs sont modifiés par l'utilisateur
            If Not m_bModeNew AndAlso m_bNouvelAffichagePossible AndAlso Not LeFilm() Is Nothing Then

                'On compare avec l'objet initial pour voir si des modifications ont été apportées
                If sender Is TBTitre Then
                    If TBTitre.Text <> LeFilm.Titre Then
                        InfoSaisie.SetError(sender, "modification effectuée")
                        m_iNbModif += 1
                    Else
                        'Il y avait une erreur, il faut la supprimer
                        If InfoSaisie.GetError(sender) <> "" Then
                            InfoSaisie.SetError(sender, Nothing)
                            m_iNbModif -= 1
                        End If
                    End If
                End If

                If sender Is TBacteurs Then
                    If TBacteurs.Text <> LeFilm.lesActeurs Then
                        InfoSaisie.SetError(sender, "modification effectuée")
                        m_iNbModif += 1
                    Else
                        'Il y avait une erreur, il faut la supprimer
                        If InfoSaisie.GetError(sender) <> "" Then
                            InfoSaisie.SetError(sender, Nothing)
                            m_iNbModif -= 1
                        End If
                    End If
                End If

                If sender Is TBrealisateur Then
                    If TBrealisateur.Text <> LeFilm.leRealisateur Then
                        InfoSaisie.SetError(sender, "modification effectuée")
                        m_iNbModif += 1
                    Else
                        'Il y avait une erreur, il faut la supprimer
                        If InfoSaisie.GetError(sender) <> "" Then
                            InfoSaisie.SetError(sender, Nothing)
                            m_iNbModif -= 1
                        End If

                    End If
                End If

                If sender Is RtbResume Then
                    If RtbResume.Text <> LeFilm.LeResume Then
                        InfoSaisie.SetError(sender, "modification effectuée")
                        m_iNbModif += 1
                    Else
                        'Il y avait une erreur, il faut la supprimer
                        If InfoSaisie.GetError(sender) <> "" Then
                            InfoSaisie.SetError(sender, Nothing)
                            m_iNbModif -= 1
                        End If
                    End If
                End If

                If (sender Is TBdureeH Or sender Is TBdureeM) Then
                    If CInt(TBdureeH.Text) * 60 + CInt(TBdureeM.Text) <> LeFilm.Duree Then
                        InfoSaisie.SetError(sender, "modification effectuée")
                        m_iNbModif += 1
                    Else
                        'Il y avait une erreur, il faut la supprimer
                        If InfoSaisie.GetError(sender) <> "" Then
                            InfoSaisie.SetError(sender, Nothing)
                            m_iNbModif -= 1
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            InfoSaisie.Clear()
            m_iNbModif = 0
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR TextBox_Validating", ex)
        Finally

        End Try

    End Sub



#End Region



End Class
