Imports System.IO


Public Class FormFilms

    Dim m_oCtrlFilm As CtrlFilms
    Dim m_lListe As List(Of Film)
    Dim m_iPosition As Integer
    Dim m_bModeNew As Boolean
    Dim m_ListeRecherche As List(Of Film)
    Dim m_sSupport As String
    Dim m_oFolder As String

    Enum typeSupport As Integer
        DVD = 0
        DIVX = 1
        BLURAY = 2
    End Enum

    Public Sub New(ByVal argC As CtrlFilms)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

        'Affectation du controleur
        m_oCtrlFilm = argC

        'Initialisation de la form
        init()

    End Sub

#Region "Methodes privées"

    '------------------------------------------------------------------------
    'Initialisation de la fenêtre
    '------------------------------------------------------------------------
    Private Sub init()

        'Récupération de la liste des films
        m_lListe = m_oCtrlFilm.obtenirFilms()

        'On récupère la liste des genres

        Me.CBGenre.ValueMember = "Code"
        Me.CBGenre.DisplayMember = "Libelle"

        Me.CBGenreNavig.ValueMember = "Code"
        Me.CBGenreNavig.DisplayMember = "Libelle"

        Me.CBGenre.DataSource = m_oCtrlFilm.obtenirGenres
        Me.CBGenreNavig.DataSource = m_oCtrlFilm.obtenirGenres

        Me.CBSupport.SelectedIndex = 1

        If m_lListe.Count > 0 Then
            'On affiche le premier film
            Call affiche(leFilm)
        Else
            Call miseAJourCompteur()

            Me.BtnDelete.Enabled = False
            Me.BtnSave.Enabled = False
            Me.CheckDispo.Enabled = False
        End If

        Me.BtnAdd.Enabled = True

    End Sub

    '------------------------------------------------------------------------
    ' Procédure permettant de gérer l'état des boutons de navigation
    '------------------------------------------------------------------------
    Private Sub gestionNavBar()

        Dim l_bEstListeVide As Boolean

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
        Me.GBNavig.Enabled = Not l_bEstListeVide
        Me.CBGenre.Enabled = Not l_bEstListeVide
        Me.TBrealisateur.Enabled = Not l_bEstListeVide
        Me.TBacteurs.Enabled = Not l_bEstListeVide
        Me.RtbResume.Enabled = Not l_bEstListeVide
        Me.CheckDispo.Enabled = Not l_bEstListeVide
        Me.CBSupport.Enabled = Not l_bEstListeVide

    End Sub

    '------------------------------------------------------------------------
    ' Affichage de la fiche du film
    '------------------------------------------------------------------------
    Private Sub affiche(ByVal f As Film)

        Dim l_bEstConcertOuClips As Boolean = False

        Me.Cursor = Cursors.WaitCursor


        If f.CodeGenre = "DA" Or f.CodeGenre = "ANIM" Then
            Me.LblActeurs.Text = "Voix :"
        Else
            Me.LblActeurs.Text = "Acteurs :"
        End If

        'Si le media est un concert ou des clips, on affiche pas les acteurs et réalisateur
        l_bEstConcertOuClips = (f.CodeGenre = "CONC" Or f.CodeGenre = "CLIP")
        Me.LblActeurs.Visible = Not l_bEstConcertOuClips
        Me.TBacteurs.Visible = Not l_bEstConcertOuClips
        Me.LblRealisateur.Visible = Not l_bEstConcertOuClips
        Me.TBrealisateur.Visible = Not l_bEstConcertOuClips

        'Gestion de l'affichage de l'image du support
        If f.Type.ToLower = "dvd" Then
            Me.CBSupport.SelectedIndex = typeSupport.DVD

            ' PB_Support.Image = GestionMedias.My.Resources.Resources.dvd
            m_sSupport = "dvd"
        Else
            Me.CBSupport.SelectedIndex = typeSupport.DIVX
            'PB_Support.Image = GestionMedias.My.Resources.Resources.divx
            m_sSupport = "divx"
        End If

        'm_oFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        m_oFolder = "\\Jerome\Users\jaymz\Pictures"

        If Dir(m_oFolder + "\Pochettes\DVD\" + f.Jaquette) <> "" Then
            Me.PBJaquette.ImageLocation = m_oFolder + "\Pochettes\DVD\" + f.Jaquette
        ElseIf Dir(m_oFolder + "\Pochettes\DVD\Musique\" + f.Jaquette) <> "" Then
            Me.PBJaquette.ImageLocation = m_oFolder + "\Pochettes\DVD\Musique\" + f.Jaquette
        Else
            Me.PBJaquette.ImageLocation = Nothing
        End If
      
        If Me.PBJaquette.Image Is Nothing Then

        End If

        Me.TBTitre.Text = f.Titre
        Me.TBdureeH.Text = f.Duree \ 60
        Me.TBdureeM.Text = f.Duree Mod 60
        Me.DTPSortie.Text = f.DateSortie
        Me.RtbResume.Text = f.LeResume
        Me.TBrealisateur.Text = f.leRealisateur
        Me.TBacteurs.Text = f.lesActeurs
        Me.CheckDispo.Checked = f.Dispo
        Me.CBGenre.SelectedValue = f.CodeGenre

        'Mise à jour du compteur
        miseAJourCompteur()

        'Mise à jour de l'état des boutons de navigation
        gestionNavBar()

        Me.Cursor = Cursors.Arrow
    End Sub

    '------------------------------------------------------------------------
    ' Retourne le film affiché
    '------------------------------------------------------------------------
    Private Function leFilm() As Film
        If Not m_lListe Is Nothing AndAlso m_lListe.Count > 0 Then
            Return m_lListe(m_iPosition)
        Else
            Return Nothing
        End If

    End Function

    '------------------------------------------------------------------------
    ' Gestion du compteur
    '------------------------------------------------------------------------
    Private Sub miseAJourCompteur()

        If m_lListe.Count > 0 And Not m_bModeNew Then
            Me.lblCpt.Text = (m_iPosition + 1).ToString + "/" + m_lListe.Count.ToString
        Else
            Me.lblCpt.Text = ""
        End If

    End Sub

    '------------------------------------------------------------------------
    ' Remise à blanc des champs
    '------------------------------------------------------------------------
    Private Sub RAZ()
        Me.TBTitre.Text = Nothing
        Me.TBrealisateur.Text = Nothing
        Me.TBdureeM.Text = Nothing
        Me.TBdureeH.Text = Nothing
        Me.TBacteurs.Text = Nothing
        Me.RtbResume.Text = Nothing
        Me.PBJaquette.Image = Nothing

    End Sub

    '------------------------------------------------------------------------
    ' Active ou désactive les champs de saisie
    '------------------------------------------------------------------------
    Private Sub etatChamps(ByVal etat As Boolean)

        Me.TBTitre.Enabled = etat
        Me.TBrealisateur.Enabled = etat
        Me.CBGenre.Enabled = etat
        Me.TBdureeM.Enabled = etat
        Me.TBdureeH.Enabled = etat
        Me.TBacteurs.Enabled = etat
        Me.RtbResume.Enabled = etat
        Me.PBJaquette.Enabled = etat
        Me.DTPSortie.Enabled = etat
        Me.CheckDispo.Enabled = etat

    End Sub

    '------------------------------------------------------------------------
    '------------------------------------------------------------------------
    Private Sub blockNavig(ByVal mode As Boolean)
        Me.BtnPremier.Enabled = Not mode
        Me.BtnPrec.Enabled = Not mode
        Me.BtnSuiv.Enabled = Not mode
        Me.BtnDernier.Enabled = Not mode
        Me.GBNavig.Enabled = Not mode
    End Sub

    '--------------------------------------------------------------------------
    ' Mise à jour de liste des jeux quand on choisit une navigation par genre
    '--------------------------------------------------------------------------
    Private Sub MajListeParGenre()

        Dim l_sCodeGenre As String

        l_sCodeGenre = ""

        'ON récupère les valeurs des codes
        If Not CBGenreNavig.SelectedValue Is Nothing Then
            l_sCodeGenre = CBGenreNavig.SelectedValue.ToString
        End If

        If l_sCodeGenre <> "" Then
            'Récupération de la liste
            m_lListe = m_oCtrlFilm.obtenirFilms(l_sCodeGenre)
            etatChamps(True)

            ' Si la liste n'est pas vide, on affiche le premier film de la liste
            If m_lListe.Count > 0 Then
                m_iPosition = 0
                affiche(leFilm)
            Else
                'Aucun film, donc on efface les champs et on les grise. On désactive également les boutons de navigation
                RAZ()
                etatChamps(False)
                gestionNavBar()
            End If
        End If

        'Permet de "sortir" des combo
        Me.LblSortie.Select()

    End Sub

    Private Sub sauverFilm()
        Dim l_iDuree As Integer
        Dim l_sNomImage As String = ""
        Dim l_oNewFilm As Film
        Dim i As Integer

        'Curseur sablier
        Me.Cursor = Cursors.WaitCursor

        If Me.TBdureeM.Text <> "" Then
            l_iDuree = Me.TBdureeH.Text * 60 + Me.TBdureeM.Text
        End If

        If Not Me.PBJaquette.ImageLocation Is Nothing Then
            l_sNomImage = Me.PBJaquette.ImageLocation.Split("\")(Me.PBJaquette.ImageLocation.Split("\").Length - 1)
        End If

        'On ajoute une nouvelle fiche
        If (m_bModeNew) Then
            Try

                l_oNewFilm = m_oCtrlFilm.ajouterFilm(Me.TBTitre.Text, l_iDuree, Me.CBGenre.SelectedValue, Me.DTPSortie.Value, _
                Me.RtbResume.Text, l_sNomImage, Me.TBrealisateur.Text, Me.TBacteurs.Text, Me.CBSupport.SelectedItem)

                'Affichage d'un message
                MessageBox.Show("Fiche créée avec succès !", "Création", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Mise à jour de la liste des films
                m_lListe = m_oCtrlFilm.obtenirFilms()

                'on se place sur la bonne position
                For i = 0 To m_lListe.Count - 1
                    If l_oNewFilm.Code.ToString = m_lListe.Item(i).Code.ToString Then
                        m_iPosition = i
                    End If
                Next

                m_bModeNew = False
                'On débloque la navigation
                blockNavig(False)
                gestionNavBar()
                miseAJourCompteur()

                'Si la liste est vide on remet tout à zéro sinon on affiche la première fiche
                If Not leFilm() Is Nothing Then
                    Call affiche(leFilm)
                Else
                    RAZ()
                End If
            Catch ex As Exception

                'Echec de l'enregistrement
                MessageBox.Show("Erreur à l'enregistrement : " & ex.Message, "Création", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        Else
            Try
                'On modifie une fiche
                m_oCtrlFilm.modifierFilm(leFilm(), Me.TBTitre.Text, l_iDuree, Me.CBGenre.SelectedValue, Me.DTPSortie.Value, Me.RtbResume.Text, _
                                  l_sNomImage, Me.TBrealisateur.Text, Me.TBacteurs.Text, Me.CBSupport.SelectedItem)

                'Mise à jour de la liste des films
                m_lListe = m_oCtrlFilm.obtenirFilms()

                'Affichage d'un message
                MessageBox.Show("Modification effectuée !", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                'Affichage d'un message
                MessageBox.Show("Erreur lors de la modification!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End If

        'Curseur normal
        Me.Cursor = Cursors.Default

        l_oNewFilm = Nothing

    End Sub

    Private Sub fermerFenetre()
        'Libération mémoire
        m_oCtrlFilm = Nothing
        m_lListe = Nothing
        m_ListeRecherche = Nothing
    End Sub

    Private Sub supprimerFilm()

        Dim l_sMsg As String
        Dim l_bOK As Boolean

        'Affichage d'un message
        If MessageBox.Show("Voulez-vous vraiment supprimer cette fiche ?", "Suppression", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            'Variable indiquant si on doit poursuivre même si la suppression a échoué
            l_bOK = False

            While Not l_bOK
                l_sMsg = m_oCtrlFilm.effacerFilm(leFilm)

                If l_sMsg Is Nothing Then
                    MessageBox.Show("Suppression réussie ! ", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    l_bOK = True
                Else
                    If MessageBox.Show("Erreur : " + l_sMsg, "Erreur", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Retry Then
                    Else
                        l_bOK = True
                    End If
                End If
            End While

            'Mise à jour de la liste des films
            m_lListe = m_oCtrlFilm.obtenirFilms()
            ' Si la liste n'est pas vide, on affiche le premier film de la liste
            If m_lListe.Count > 0 Then
                m_iPosition = 0
                affiche(m_lListe(0))
            Else
                'Aucun film, donc on efface les champs et on les grise. On désactive également les boutons de navigation
                RAZ()
                etatChamps(False)
                gestionNavBar()
                miseAJourCompteur()
            End If
        End If
    End Sub

    Private Sub chercherFilm()
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

        Try
            l_iDureeMin = 0
            l_iDureeMax = 0
            l_oDialogRecherche = New DialogSearchFilm(m_oCtrlFilm)

            If l_oDialogRecherche.ShowDialog() = Windows.Forms.DialogResult.OK Then

                l_sTitre = l_oDialogRecherche.TBSearch.Text
                l_sAnnee1 = l_oDialogRecherche.TBAnnee1.Text
                l_sAnnee2 = l_oDialogRecherche.TBAnnee2.Text
                l_oGenre1 = l_oDialogRecherche.CBGenre1.SelectedItem
                l_oGenre2 = l_oDialogRecherche.CBGenre2.SelectedItem

                If Not (l_oDialogRecherche.TBMmin.Text = "" And l_oDialogRecherche.TBHmin.Text = "") Then
                    l_iDureeMin = Int(l_oDialogRecherche.TBHmin.Text) * 60 + Int(l_oDialogRecherche.TBMmin.Text)
                End If
                If Not (l_oDialogRecherche.TBMmax.Text = "" And l_oDialogRecherche.TBHmax.Text = "") Then
                    l_iDureeMax = Int(l_oDialogRecherche.TBHmax.Text) * 60 + Int(l_oDialogRecherche.TBMmax.Text)
                End If

                l_sActeur = l_oDialogRecherche.TBActeur.Text
                l_sRealisateur = l_oDialogRecherche.TBRealisateur.Text
                l_oDialogRecherche = Nothing

                'Récupération de la liste des jeux
                m_ListeRecherche = m_oCtrlFilm.chercherFilms(l_sTitre, l_oGenre1, l_oGenre2, l_sAnnee1, l_sAnnee2, _
                                                      l_iDureeMin, l_iDureeMax, l_sActeur, l_sRealisateur)

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
                        affiche(leFilm)
                    End If
                    l_oEcranRecherche = Nothing
                Else
                    MessageBox.Show("Aucun film n'a été trouvé !", "Résultat", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If
        Catch ex As Exception

        Finally
            l_oDialogRecherche = Nothing
            l_oGenre1 = Nothing
            l_oGenre2 = Nothing
            l_oEcranRecherche = Nothing
            l_oFilm = Nothing
        End Try


    End Sub

    Private Sub annulerModification()
        If m_bModeNew Then
            m_bModeNew = False

            If m_lListe.Count > 0 Then
                Call affiche(leFilm)
            Else
                Call RAZ()
                Call gestionNavBar()
            End If
        End If
    End Sub

    Private Sub ajouterFilm()
        m_bModeNew = True

        Me.BtnSave.Enabled = True
        Me.BtnAdd.Enabled = False
        Me.BtnDelete.Enabled = False
        Me.BtnPrint.Enabled = False
        Me.BtnCancel.Enabled = True
        Me.CheckDispo.Enabled = False

        Me.CBGenre.Enabled = True
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
        Me.CBSupport.SelectedItem = "DVD"

        'En mode ajout la navigation devient impossible
        Call blockNavig(True)

        'Mise à jour du compteur
        Call miseAJourCompteur()

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

    End Sub

#End Region

#Region "Gestion des événements"

    Private Sub FormFilms_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        fermerFenetre()
    End Sub

    Private Sub FormFilms_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And (e.KeyCode = Keys.S) Then
            If Me.BtnSave.Enabled Then
                sauverFilm()
            End If
        ElseIf e.Control And (e.KeyCode = Keys.Q) Then
            fermerFenetre()
        ElseIf e.Control And e.KeyCode = Keys.Delete Then
            If Me.BtnDelete.Enabled Then
                supprimerFilm()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            If Me.BtnSearch.Enabled Then
                annulerModification()
            End If
        ElseIf e.Control And (e.KeyCode = Keys.F) Then
            If Me.BtnSearch.Enabled Then
                chercherFilm()
            End If
        ElseIf e.KeyCode = Keys.Add Then
            If Me.BtnSearch.Enabled Then
                ajouterFilm()
            End If
        ElseIf e.KeyCode = Keys.F5 Then
            'On rafraichi la fenêtre
            Call affiche(leFilm)
        End If

    End Sub

    Private Sub FormFilms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
    End Sub

    'TODO : gérer l'ajout d'une image
    Private Sub PBJaquette_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBJaquette.Click

        Dim l_sFolder As String
        Dim l_oDlgOuvrir As OpenFileDialog

        Try
            If m_lListe.Count > 0 Or m_bModeNew Then

                'Répertoire contenant les jaquettes de films
                'l_sFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\Pochettes\DVD"
                l_sFolder = "\\Jerome\Users\jaymz\Pictures\Pochettes\DVD"

                If Not Directory.Exists(l_sFolder) Then
                    Directory.CreateDirectory(l_sFolder)
                End If

                l_oDlgOuvrir = New OpenFileDialog
                l_oDlgOuvrir.InitialDirectory = l_sFolder
                l_oDlgOuvrir.Title = "Sélection de la jaquette"
                l_oDlgOuvrir.Filter = "Images|*.jpg"
                l_oDlgOuvrir.AddExtension = False

                If Not l_oDlgOuvrir.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                    Me.PBJaquette.ImageLocation = l_oDlgOuvrir.FileName
                End If
            End If

        Catch ex As Exception

        Finally
            l_oDlgOuvrir = Nothing
        End Try
       
    End Sub

    '------------------------------------------------------------------------
    ' Boutons de navigation
    '------------------------------------------------------------------------
    Private Sub BtnNavig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPremier.Click, BtnPrec.Click, BtnSuiv.Click, BtnDernier.Click

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

        affiche(m_lListe(m_iPosition))
    End Sub

    '------------------------------------------------------------------------
    ' Ajout d'un film
    '------------------------------------------------------------------------
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        ajouterFilm()
    End Sub

    '------------------------------------------------------------------------
    ' Suppression d'un film
    '------------------------------------------------------------------------
    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        supprimerFilm()
    End Sub

    '------------------------------------------------------------------------
    'BOUTON SAUVER
    'todo : remettre par défaut le mode de navigation : bug si on modifie le genre d'une fiche alors qu'on est en mode navigation par genre
    '------------------------------------------------------------------------
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Call sauverFilm()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click

        'affiche un aperçu de l'impression

        PrintPreviewDialog1.Width = 1200
        PrintPreviewDialog1.Height = 800

        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1

        CType(PrintPreviewDialog1, System.Windows.Forms.Form).WindowState = System.Windows.Forms.FormWindowState.Maximized

        PrintDocument1.DefaultPageSettings.Landscape = True

        PrintPreviewDialog1.ShowDialog()

        'PrintDocument1.Print()

    End Sub

    '------------------------------------------------------------------------
    ' Algorithme d'impression de la jaquette : justifie le texte à droite et à gauche
    '------------------------------------------------------------------------
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

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
        im = New System.Drawing.Bitmap(m_oFolder + "\Pochettes\DVD\" + l_oFilm.Jaquette)

        ratio = im.Height / im.Width

        hauteurIM = 236 * ratio '236 est la largeur fixe de toutes les images

        'x = (W-w)/2  y = (H-h)2
        e.Graphics.DrawImage(im, 118 + l_iXj, CType((taille - hauteurIM) / 2, Integer) + l_iYj, 236, hauteurIM)

        e.Graphics.DrawString(l_oFilm.Titre, Police2, Brushes.Black, l_iXj + taille + 30, l_iYj + 30)

        'Rectangle pour l'entête
        Dim RE As Rectangle = New Rectangle(l_iXj + taille + 30, l_iYj + 30 + 2 * HL, tailleR, 6 * HL)

        'e.Graphics.DrawRectangle(Pens.Black, RE)

        'Libellé du genre
        genre = m_oCtrlFilm.getLibelle(l_oFilm.CodeGenre)

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

    End Sub

    '------------------------------------------------------------------------
    ' Formatage de la durée du film
    '------------------------------------------------------------------------
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

    '------------------------------------------------------------------------
    ' Lien vers internet
    '------------------------------------------------------------------------
    Private Sub LinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked, LinkLabel2.LinkClicked

        Dim tableau() As String = Me.TBTitre.Text.Split
        Dim requete As String = Nothing
        Dim i As Integer
        Dim url As String = Nothing

        For i = 0 To tableau.Length - 2
            requete = requete & tableau(i) & "+"
        Next

        requete = requete & tableau(tableau.Length - 1)

        If sender Is LinkLabel1 Then
            url = "http://www.mega-search.net/search.php?terms=" & requete & "&group=dvd"
        ElseIf sender Is LinkLabel2 Then
            url = "http://www.allocine.fr/recherche/?motcle=" & requete & "&x=0&y=0&rub=0"
        End If

        System.Diagnostics.Process.Start(url)

    End Sub

    '------------------------------------------------------------------------
    ' Mise a jour de la liste des films quand on choisit un genre
    '------------------------------------------------------------------------
    Private Sub CBGenreNavig_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBGenreNavig.SelectedValueChanged
        MajListeParGenre()
    End Sub

    '------------------------------------------------------------------------
    ' Changement de couleur et de texte de la combo Disponibilités
    '------------------------------------------------------------------------
    Private Sub CheckDispo_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckDispo.CheckStateChanged

        If CheckDispo.Checked Then
            CheckDispo.Text = "Disponible"
            CheckDispo.ForeColor = Color.Green
        Else
            CheckDispo.Text = "Indisponible"
            CheckDispo.ForeColor = Color.Red
        End If

    End Sub

    '------------------------------------------------------------------------
    ' Choix de la disponibilité
    '------------------------------------------------------------------------
    Private Sub CheckDispo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckDispo.Click

        Dim l_bMode As Boolean
        Dim l_oEcran As DialogPret

        Try
            'Mode enregistrement d'un prêt
            'Si false, alors on effectue un emprunt
            'Si true, on restitue l'objet
            l_bMode = CheckDispo.Checked

            l_oEcran = New DialogPret(m_oCtrlFilm, leFilm(), l_bMode, Me)

            'Annulation
            If l_oEcran.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                'on revient à l'état initial : attention au bug
                CheckDispo.Checked = Not l_bMode
            End If
        Catch ex As Exception

        Finally
            l_oEcran = Nothing
        End Try

    End Sub

    '------------------------------------------------------------------------
    ' Action sur la roulette de la souris
    '------------------------------------------------------------------------
    Private Sub FormFilms_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel

        If Not m_bModeNew Then
            If sender Is Me Then
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

                affiche(m_lListe(m_iPosition))
            End If
        End If

    End Sub

    '------------------------------------------------------------------------
    '------------------------------------------------------------------------
    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        annulerModification()
    End Sub

    '------------------------------------------------------------------------
    '------------------------------------------------------------------------
    Private Sub CBSupport_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBSupport.SelectedIndexChanged

        m_sSupport = Me.CBSupport.SelectedItem.ToString.ToLower

        If m_sSupport = "dvd" Then
            PB_Support.Image = GestionMedias.My.Resources.Resources.dvd
        Else
            PB_Support.Image = GestionMedias.My.Resources.Resources.divx
        End If
    End Sub

    '------------------------------------------------------------------------
    ' Recherche d'un film
    '------------------------------------------------------------------------
    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        chercherFilm()
    End Sub

#End Region



End Class
