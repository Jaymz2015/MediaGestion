Imports System.IO

Public Class FormJeux
    Dim m_oCtrlJeux As CtrlJeux
    Dim m_lListe As List(Of Jeu)
    Dim m_ListeRecherche As List(Of Jeu)
    Dim m_iPosition As Integer
    Dim m_bModeNew As Boolean
    Dim m_sMachine As String
    Dim m_sFolder As String


    Public Sub New(ByVal argC As CtrlJeux)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

        'Affectation du controleur
        m_oCtrlJeux = argC

        'Initialisation de la form
        init()

    End Sub

#Region "Methodes privées"

    'Initialisation de la fenêtre
    Private Sub init()

        'Récupération de la liste des jeux
        m_lListe = m_oCtrlJeux.obtenirJeux()

        'On récupère la liste des genres
        ' Me.CBGenre.DataSource = ctrl.obtenirGenres
        Me.CBGenre.ValueMember = "Code"
        Me.CBGenre.DisplayMember = "Libelle"

        'Me.CBGenreNavig.DataSource = ctrl.obtenirGenres
        Me.CBGenreNavig.ValueMember = "Code"
        Me.CBGenreNavig.DisplayMember = "Libelle"

        'Me.CBMachine.DataSource = ctrl.obtenirMachines
        Me.CBMachine.ValueMember = "Code"
        Me.CBMachine.DisplayMember = "Nom"
        'Me.machine = CBMachine.SelectedValue.ToString

        'Me.CBMachineNavig.DataSource = ctrl.obtenirMachines
        Me.CBMachineNavig.ValueMember = "Code"
        Me.CBMachineNavig.DisplayMember = "Nom"

        Me.CBGenre.DataSource = m_oCtrlJeux.obtenirGenres
        Me.CBGenreNavig.DataSource = m_oCtrlJeux.obtenirGenres
        Me.CBMachine.DataSource = m_oCtrlJeux.obtenirMachines
        Me.CBMachineNavig.DataSource = m_oCtrlJeux.obtenirMachines
        m_sMachine = CBMachine.SelectedValue.ToString

        If m_lListe.Count > 0 Then
            'On affiche le premier jeu
            Call affiche(leJeu)
        Else
            Call miseAJourCompteur()

            Me.BtnDelete.Enabled = False
            Me.BtnSave.Enabled = False
            Me.CheckDispo.Enabled = False
        End If

        Me.BtnAdd.Enabled = True

    End Sub

    'Affichage de la fiche du jeu
    Private Sub affiche(ByVal j As Jeu)

        Dim rb As RadioButton

        Me.Cursor = Cursors.WaitCursor

        'm_sFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        m_sFolder = "\\Jerome\Users\jaymz\Pictures"

        Me.TBTitre.Text = j.Titre

        Me.TBSortie.Text = j.DateSortie.Year
        Me.TBediteur.Text = j.Editeur

        Me.PBJaquette.ImageLocation = m_sFolder + "\Pochettes\Jeux\" + j.Jaquette

        Me.CheckDispo.Checked = j.Dispo
        Me.CBGenre.SelectedValue = j.CodeGenre
        Me.RBCopie.Checked = j.EstCopie
        Me.RBOriginal.Checked = Not j.EstCopie
        Me.CBMachine.SelectedValue = j.CodeMachine

        'Etat du boitier
        For Each c As Control In Me.PanelEtatBoitier.Controls
            rb = CType(c, RadioButton)
            If rb.Tag = j.EtatBoitier Then
                rb.Checked = True
            End If
        Next

        'Etat du livret
        For Each c As Control In Me.PanelEtatLivret.Controls
            rb = CType(c, RadioButton)
            If rb.Tag = j.EtatLivret Then
                rb.Checked = True
            End If
        Next

        'Etat du jeu
        For Each c As Control In Me.PanelEtatJeu.Controls
            rb = CType(c, RadioButton)
            If rb.Tag = j.EtatJeu Then
                rb.Checked = True
            End If
        Next

        'Gestion de l'affichage de l'image du support

        m_sMachine = j.CodeMachine.ToUpper

        Select Case m_sMachine
            Case "NINGC"
                Me.PB_Machine.Image = GestionMedias.My.Resources.Resources.gc
            Case "SEGADC"
                Me.PB_Machine.Image = GestionMedias.My.Resources.Resources.dc
            Case "SEGAMD"
                Me.PB_Machine.Image = GestionMedias.My.Resources.Resources.Megadrive
            Case "SEGAMCD"
                Me.PB_Machine.Image = GestionMedias.My.Resources.Resources.mega_cd
            Case "SEGAMS"
                Me.PB_Machine.Image = GestionMedias.My.Resources.Resources.MasterSystem
            Case "PC"
                Me.PB_Machine.Image = GestionMedias.My.Resources.Resources.pc
        End Select

        'Mise à jour du compteur
        miseAJourCompteur()

        'Mise à jour de l'état des boutons de navigation
        gestionNavBar()

        Me.Cursor = Cursors.Arrow

    End Sub

    'Gestion du compteur
    Private Sub miseAJourCompteur()

        If m_lListe.Count > 0 And Not m_bModeNew Then
            Me.lblCpt.Text = (m_iPosition + 1).ToString + "/" + m_lListe.Count.ToString
        Else
            Me.lblCpt.Text = ""
        End If

    End Sub

    'Procédure permettant de gérer l'état des boutons de navigation
    Private Sub gestionNavBar()

        Dim estListeVide As Boolean

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
        estListeVide = (m_lListe.Count = 0)

        Me.BtnDelete.Enabled = Not estListeVide
        Me.BtnSave.Enabled = Not estListeVide
        Me.BtnSearch.Enabled = Not estListeVide

        Me.BtnAdd.Enabled = Not m_bModeNew
        Me.BtnCancel.Enabled = m_bModeNew

        Me.TBTitre.Enabled = Not estListeVide
        Me.TBSortie.Enabled = Not estListeVide
        Me.TBediteur.Enabled = Not estListeVide
        Me.GBEtat.Enabled = Not estListeVide
        Me.GBSupport.Enabled = Not estListeVide
        Me.GBNavig.Enabled = Not estListeVide
        Me.CBGenre.Enabled = Not estListeVide
        Me.CBMachine.Enabled = Not estListeVide
        Me.CheckDispo.Enabled = Not estListeVide

    End Sub

    'Remise à blanc des champs
    Private Sub RAZ()
        Me.TBTitre.Text = Nothing
        Me.TBediteur.Text = Nothing
        Me.PBJaquette.Image = Nothing

    End Sub

    'Active ou désactive les champs de saisie
    Private Sub etatChamps(ByVal etat As Boolean)

        ' Me.TBSortie.Text = Nothing
        Me.TBTitre.Enabled = etat
        Me.TBSortie.Enabled = etat
        Me.TBediteur.Enabled = etat
        Me.GBEtat.Enabled = etat
        Me.GBNavig.Enabled = etat
        Me.CBGenre.Enabled = etat
        Me.CBMachine.Enabled = etat
        Me.GBSupport.Enabled = etat

    End Sub

    Private Sub blockNavig(ByVal mode As Boolean)
        Me.BtnPremier.Enabled = Not mode
        Me.BtnPrec.Enabled = Not mode
        Me.BtnSuiv.Enabled = Not mode
        Me.BtnDernier.Enabled = Not mode
        Me.GBNavig.Enabled = Not mode
    End Sub

    'Mise à jour de liste des jeux quand on choisit une navigation par genre
    Private Sub MajListeParGenre()

        Dim l_sGenre As String
        Dim l_sMachine As String

        l_sGenre = ""
        l_sMachine = ""

        'ON récupère les valeurs des codes
        If Not CBGenreNavig.SelectedValue Is Nothing Then
            l_sGenre = CBGenreNavig.SelectedValue.ToString
        End If
        If Not CBMachineNavig.SelectedValue Is Nothing Then
            l_sMachine = CBMachineNavig.SelectedValue.ToString
        End If

        If l_sGenre <> "" And l_sMachine <> "" Then
            'Récupération de la liste
            m_lListe = m_oCtrlJeux.obtenirJeux(l_sGenre, l_sMachine)
            etatChamps(True)

            ' Si la liste n'est pas vide, on affiche le premier jeu de la liste
            If m_lListe.Count > 0 Then
                m_iPosition = 0
                affiche(leJeu)
            Else
                'Aucun jeu, donc on efface les champs et on les grise. On désactive également les boutons de navigation
                RAZ()
                etatChamps(False)
                gestionNavBar()
            End If
        End If

        'Permet de "sortir" des combo
        Me.LblSortie.Select()

    End Sub

    'Retourne le jeu affiché
    Private Function leJeu() As Jeu
        If Not m_lListe Is Nothing AndAlso m_lListe.Count > 0 Then
            Return m_lListe(m_iPosition)
        Else
            Return Nothing
        End If
    End Function

    Private Sub sauverJeu()

        Dim nomImage As String
        Dim dateSortie As DateTime
        Dim newJeu As Jeu
        Dim i As Integer
        Dim etatBoitier As Integer
        Dim etatLivret As Integer
        Dim etatJeu As Integer

        nomImage = ""

        If Me.TBSortie.Text <> "" Then
            dateSortie = New DateTime(Me.TBSortie.Text, 1, 1)
        End If

        'Curseur sablier
        Me.Cursor = Cursors.WaitCursor

        If Not Me.PBJaquette.ImageLocation Is Nothing Then
            nomImage = Me.PBJaquette.ImageLocation.Split("\")(Me.PBJaquette.ImageLocation.Split("\").Length - 1)
        End If

        'Récupération de l'état du jeu
        If RBBoitierAbsent.Checked Then
            etatBoitier = 0
        ElseIf RBBoitierMauvais.Checked Then
            etatBoitier = 2
        ElseIf RBBoitierMoyen.Checked Then
            etatBoitier = 3
        ElseIf RBBoitierBon.Checked Then
            etatBoitier = 4
        ElseIf RBBoitierExcellent.Checked Then
            etatBoitier = 5
        End If

        If RBLivretAbsent.Checked Then
            etatLivret = 0
        ElseIf RBLivretMauvais.Checked Then
            etatLivret = 2
        ElseIf RBLivretMoyen.Checked Then
            etatLivret = 3
        ElseIf RBLivretBon.Checked Then
            etatLivret = 4
        ElseIf RBLivretExcellent.Checked Then
            etatLivret = 5
        End If

        If RBJeuAbsent.Checked Then
            etatJeu = 0
        ElseIf RBJeuMauvais.Checked Then
            etatJeu = 2
        ElseIf RBJeuMoyen.Checked Then
            etatJeu = 3
        ElseIf RBJeuBon.Checked Then
            etatJeu = 4
        ElseIf RBJeuExcellent.Checked Then
            etatJeu = 5
        End If

        'On ajoute une nouvelle fiche
        If (m_bModeNew) Then

            Try
                newJeu = m_oCtrlJeux.ajouterJeu(Me.TBTitre.Text, Me.CBGenre.SelectedValue, dateSortie, _
               nomImage, Me.TBediteur.Text, m_sMachine, etatBoitier, _
               etatLivret, etatJeu, Me.RBCopie.Checked)

                'Affichage d'un message
                MessageBox.Show("Fiche créée avec succès !", "Création", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Mise à jour de la liste des jeux
                m_lListe = m_oCtrlJeux.obtenirJeux()

                'on se place sur la bonne position
                For i = 0 To m_lListe.Count - 1
                    If newJeu.Code.ToString = m_lListe.Item(i).Code.ToString Then
                        m_iPosition = i
                    End If
                Next

                m_bModeNew = False
                'On débloque la navigation
                blockNavig(False)
                gestionNavBar()
                miseAJourCompteur()
                'Si la liste est vide on remet tout à zéro sinon on affiche la première fiche
                If Not leJeu() Is Nothing Then
                    Call affiche(leJeu)
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
                m_oCtrlJeux.modifierJeu(leJeu(), Me.TBTitre.Text, Me.CBGenre.SelectedValue, dateSortie, _
                                  nomImage, Me.TBediteur.Text, m_sMachine, etatBoitier, etatLivret, _
                                   etatJeu, Me.RBCopie.Checked)

                'Mise à jour de la liste des jeus
                m_lListe = m_oCtrlJeux.obtenirJeux()

                'Affichage d'un message
                MessageBox.Show("Modification effectuée !", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                'Affichage d'un message
                MessageBox.Show("Erreur lors de la modification!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        'Curseur normal
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub fermerFenetre()
        'Libération mémoire
        m_oCtrlJeux = Nothing
        m_lListe = Nothing
        m_ListeRecherche = Nothing
    End Sub

    Private Sub supprimerJeu()
        Dim l_sMsg As String
        Dim l_bOK As Boolean

        'Affichage d'un message
        If MessageBox.Show("Voulez-vous vraiment supprimer cette fiche ?", "Suppression", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            'Variable indiquant si on doit poursuivre même si la suppression a échoué
            l_bOK = False

            While Not l_bOK
                l_sMsg = m_oCtrlJeux.effacerJeu(leJeu)

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

            'Mise à jour de la liste des jeus
            m_lListe = m_oCtrlJeux.obtenirJeux()
            ' Si la liste n'est pas vide, on affiche le premier jeu de la liste
            If m_lListe.Count > 0 Then
                m_iPosition = 0
                affiche(m_lListe(0))
            Else
                'Aucun jeu, donc on efface les champs et on les grise. On désactive également les boutons de navigation
                RAZ()
                etatChamps(False)
                gestionNavBar()
                miseAJourCompteur()
            End If
        End If
    End Sub

    Private Sub annulerModification()
        If m_bModeNew Then
            m_bModeNew = False

            If m_lListe.Count > 0 Then
                Call affiche(leJeu)
            Else
                Call RAZ()
                Call gestionNavBar()
            End If
        End If
    End Sub

    Private Sub chercherJeu()
        Dim l_sTitre As String
        Dim l_oGenre As Genre
        Dim l_oMachine As Machine
        Dim l_oDialogRecherche As DialogSearchJeu
        Dim l_oEcranRecherche As FormSearch
        Dim i As Integer
        Dim l_oJeu As Jeu
        Dim l_sAnnee1 As String
        Dim l_sAnnee2 As String

        'Affichage de la boite de dialogue permettant de saisir un titre
        l_oDialogRecherche = New DialogSearchJeu(m_oCtrlJeux)

        If l_oDialogRecherche.ShowDialog = Windows.Forms.DialogResult.OK Then

            l_sTitre = l_oDialogRecherche.TBSearch.Text
            l_sAnnee1 = l_oDialogRecherche.TBAnnee1.Text
            l_sAnnee2 = l_oDialogRecherche.TBAnnee2.Text
            l_oGenre = l_oDialogRecherche.CBGenre.SelectedItem
            l_oMachine = l_oDialogRecherche.CBMachine.SelectedItem
            l_oDialogRecherche = Nothing

            'Récupération de la liste des jeux
            m_ListeRecherche = m_oCtrlJeux.chercherJeux(l_sTitre, l_oMachine, l_oGenre, l_sAnnee1, l_sAnnee2)

            'Si la liste n'est pas vide, on affiche la liste des jeux trouvés dans une nouvelle fenêtre
            If Not m_ListeRecherche Is Nothing AndAlso m_ListeRecherche.Count > 0 Then
                'Affichage de la liste des jeux trouvés
                l_oEcranRecherche = New FormSearch(m_oCtrlJeux, m_ListeRecherche)
                'Si on clique sur OK on affiche le jeu
                l_oEcranRecherche.ShowDialog()

                If l_oEcranRecherche.ChoixRealise Then

                    For i = 0 To m_lListe.Count - 1

                        l_oJeu = m_lListe.Item(i)

                        If (l_oJeu.Code.ToString = l_oEcranRecherche.JeuSelectionne.Code.ToString) Then
                            m_iPosition = i
                            Exit For
                        End If
                    Next
                    affiche(leJeu)
                End If
                l_oEcranRecherche = Nothing
            Else
                MessageBox.Show("Aucun jeu n'a été trouvé !", "Résultat", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        l_oGenre = Nothing
        l_oMachine = Nothing
        l_oDialogRecherche = Nothing
        l_oEcranRecherche = Nothing
        l_oJeu = Nothing

    End Sub

    Private Sub ajouterJeu()
        m_bModeNew = True
        Me.BtnSave.Enabled = True
        Me.BtnAdd.Enabled = False
        Me.BtnDelete.Enabled = False
        Me.BtnCancel.Enabled = True
        Me.CheckDispo.Enabled = False

        Call etatChamps(True)

        'En mode ajout la navigation devient impossible
        Call blockNavig(True)

        'Mise à jour du compteur
        Call miseAJourCompteur()

        'Réinitialisation des champs
        With Me
            .TBTitre.Text = Nothing
            .TBediteur.Text = Nothing
            .TBSortie.Text = Nothing
            .PBJaquette.ImageLocation = Nothing
        End With

        Me.TBTitre.Select()
    End Sub

#End Region

#Region "Gestion des événements"

    Private Sub FormJeux_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        fermerFenetre()
    End Sub

    Private Sub FormJeux_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And (e.KeyCode = Keys.S) Then
            If Me.BtnSave.Enabled Then
                sauverJeu()
            End If
        ElseIf e.Control And (e.KeyCode = Keys.Q) Then
            fermerFenetre()
        ElseIf e.KeyCode = Keys.Subtract Then
            If Me.BtnDelete.Enabled Then
                supprimerJeu()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            If Me.BtnSearch.Enabled Then
                annulerModification()
            End If
        ElseIf e.Control And (e.KeyCode = Keys.F) Then
            If Me.BtnSearch.Enabled Then
                chercherJeu()
            End If
        ElseIf e.KeyCode = Keys.Add Then
            If Me.BtnSearch.Enabled Then
                ajouterJeu()
            End If
        ElseIf e.KeyCode = Keys.F5 Then
            'On rafraichi la fenêtre
            Call affiche(leJeu)
        End If
    End Sub

    Private Sub FormJeux_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
    End Sub

    'TODO : gérer l'ajout d'une image
    Private Sub PBJaquette_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBJaquette.Click

        Dim l_oDlgOuvrir As OpenFileDialog

        If m_lListe.Count > 0 Or m_bModeNew Then

            'Répertoire contenant les jaquettes de jeu
            'm_sFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\Pochettes\Jeux"
            m_sFolder = "\\Jerome\Users\jaymz\Pictures\Pochettes\Jeux"

            'Si ce répertoire n'existe pas on le crée
            If Not Directory.Exists(m_sFolder) Then
                Directory.CreateDirectory(m_sFolder)
            End If

            l_oDlgOuvrir = New OpenFileDialog
            l_oDlgOuvrir.InitialDirectory = m_sFolder
            l_oDlgOuvrir.Title = "Sélection de la jaquette"
            l_oDlgOuvrir.Filter = "Images|*.jpg"
            l_oDlgOuvrir.AddExtension = False

            If Not l_oDlgOuvrir.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Me.PBJaquette.ImageLocation = l_oDlgOuvrir.FileName
            End If
        End If

        l_oDlgOuvrir = Nothing

    End Sub

    'Boutons de navigation
    Private Sub BtnNavig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPremier.Click, BtnPrec.Click, BtnSuiv.Click, BtnDernier.Click

        If sender Is BtnPremier Then
            'Premier jeu
            m_iPosition = 0
        ElseIf sender Is BtnPrec Then
            'Jeu précédent
            If m_iPosition > 0 Then
                m_iPosition -= 1
            End If
        ElseIf sender Is BtnSuiv Then
            'Jeu suivant
            If m_iPosition < m_lListe.Count - 1 Then
                m_iPosition += 1
            End If
        ElseIf sender Is BtnDernier Then
            'Dernier jeu
            m_iPosition = m_lListe.Count - 1
        End If

        affiche(m_lListe(m_iPosition))
    End Sub

    'Ajout d'un jeu
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        ajouterJeu()
    End Sub

    'Suppression d'un jeu
    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        supprimerJeu()
    End Sub

    'BOUTON SAUVER
    'todo :  quand on est en mode navigation par genre, on ajoute une fiche, on sauve : problème on a toute la liste qui s'affiche.
    'todo : quand on modifie un nom et qu'on enregistre, le classement n'est pas mis à jour
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        sauverJeu()
    End Sub

    'Lien vers internet
    Private Sub LinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        Dim l_sTableau() As String = Me.TBTitre.Text.Split
        Dim l_sRequete As String = Nothing
        Dim i As Integer
        Dim l_sUrl As String = Nothing
        Dim l_sGroupe As String = Nothing


        Select Case m_sMachine
            Case "NINGC"
                l_sGroupe = "gamecube"
            Case "SEGADC"
                l_sGroupe = ""
            Case "SEGAMD"
                l_sGroupe = ""
            Case "SEGAMCD"
                l_sGroupe = ""
            Case "SEGAMS"
                l_sGroupe = ""
            Case "PC"
                l_sGroupe = "pc"
        End Select

        If Me.TBTitre.Text <> "" Then

            For i = 0 To l_sTableau.Length - 2
                l_sRequete = l_sRequete & l_sTableau(i) & "+"
            Next

            l_sRequete = l_sRequete & l_sTableau(l_sTableau.Length - 1)

            l_sUrl = "http://www.mega-search.net/search.php?terms=" & l_sRequete & "&group=" & l_sGroupe

            System.Diagnostics.Process.Start(l_sUrl)
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked

        'Dim l_sTableau() As String = Me.TBTitre.Text.Split
        Dim url As String = Nothing

        If Me.TBTitre.Text <> "" Then

            url = "http://www.jeuxvideo.com/recherche/0-" & Me.TBTitre.Text & ".htm"

            System.Diagnostics.Process.Start(url)
        End If

    End Sub

    'Mise a jour de la liste des jeux quand on choisit un genre
    Private Sub CBGenreNavig_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBGenreNavig.SelectedValueChanged
        MajListeParGenre()
    End Sub

    Private Sub CBMachineNavig_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBMachineNavig.SelectedValueChanged
        MajListeParGenre()
    End Sub

    'Changement de couleur et de texte de la combo Disponibilités
    Private Sub CheckDispo_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckDispo.CheckStateChanged

        If CheckDispo.Checked Then
            CheckDispo.Text = "Disponible"
            CheckDispo.ForeColor = Color.Green
        Else
            CheckDispo.Text = "Indisponible"
            CheckDispo.ForeColor = Color.Red
        End If

    End Sub

    'Choix de la disponibilité
    Private Sub CheckDispo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckDispo.Click

        Dim l_bMode As Boolean
        Dim l_oEcran As DialogPret

        'Mode enregistrement d'un prêt
        'Si false, alors on effectue un emprunt
        'Si true, on restitue l'objet
        l_bMode = CheckDispo.Checked

        l_oEcran = New DialogPret(m_oCtrlJeux, leJeu(), l_bMode, Me)

        'Annulation
        If l_oEcran.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            'on revient à l'état initial : attention au bug
            CheckDispo.Checked = Not l_bMode
        End If

        l_oEcran = Nothing

    End Sub

    'Action sur la roulette de la souris
    Private Sub FormJeux_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel

        If Not m_bModeNew Then
            If sender Is Me Then
                If (e.Delta > 0) Then
                    'Jeu précédent
                    If m_iPosition > 0 Then
                        m_iPosition -= 1
                    End If
                Else
                    'Jeu suivant
                    If m_iPosition < m_lListe.Count - 1 Then
                        m_iPosition += 1
                    End If
                End If

                affiche(m_lListe(m_iPosition))
            End If
        End If

    End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        annulerModification()
    End Sub

    Private Sub RBCopie_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBCopie.CheckedChanged, RBOriginal.CheckedChanged

        If RBCopie.Checked Then
            GBEtat.Visible = False
        Else
            GBEtat.Visible = True
        End If

    End Sub

    Private Sub CBMachine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBMachine.SelectedIndexChanged

        Try
            m_sMachine = CBMachine.SelectedValue.ToString
            Select Case m_sMachine
                Case "NINGC"
                    Me.PB_Machine.Image = GestionMedias.My.Resources.Resources.gc
                Case "SEGADC"
                    Me.PB_Machine.Image = GestionMedias.My.Resources.Resources.dc
                Case "SEGAMD"
                    Me.PB_Machine.Image = GestionMedias.My.Resources.Resources.Megadrive
                Case "SEGAMCD"
                    Me.PB_Machine.Image = GestionMedias.My.Resources.Resources.mega_cd
                Case "SEGAMS"
                    Me.PB_Machine.Image = GestionMedias.My.Resources.Resources.MasterSystem
                Case "PC"
                    Me.PB_Machine.Image = GestionMedias.My.Resources.Resources.pc
            End Select
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PBJaquette_LoadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles PBJaquette.LoadCompleted
        'Mode d'affichage de la pochette
        If Not Me.PBJaquette.Image Is Nothing AndAlso (Me.PBJaquette.Image.Height / Me.PBJaquette.Image.Width) < 1.2 Then
            Me.PBJaquette.SizeMode = PictureBoxSizeMode.Zoom
        Else
            Me.PBJaquette.SizeMode = PictureBoxSizeMode.StretchImage
        End If
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        chercherJeu()
    End Sub

#End Region

  
End Class
