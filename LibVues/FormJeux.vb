Imports System.IO
Imports Utilitaires
Imports LibAllocine.Dl.Dto
Imports MediaGestion.Modele
Imports MediaGestion.Metier
Imports MediaGestion.Modele.Dl.Dlo

Public Class FormJeux
    Private m_oCtrlJeux As CtrlJeux
    Private m_lListe As List(Of Jeu)
    Private m_ListeRecherche As List(Of Jeu)
    Private m_iPosition As Integer
    Private m_bModeNew As Boolean
    Private m_sMachine As String
    Private m_sFolder As String
    Private m_oLeJeuAffiche As Jeu
    Private m_bNouvelAffichagePossible As Boolean

    Private Const KS_NOM_MODULE = "LibVues - FormJeux - "

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

        m_bNouvelAffichagePossible = True

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

        'TODO
        'Récupération de la liste des jeux
        'm_lListe = m_oCtrlJeux.obtenirJeux()

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

    'Affichage de la fiche du jeu : uniquement la pochette
    Private Sub affiche(ByVal j As Jeu)

        'On bloque un nouvel appel à la méthode affiche tant que celle-ci n'est pas affichée
        m_bNouvelAffichagePossible = False

        m_oLeJeuAffiche = j

        'Me.PBPhoto.ImageLocation = Nothing

        Me.Cursor = Cursors.WaitCursor

        m_sFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        'm_sFolder = "\\" & System.Environment.MachineName & "\Images"

        Me.PBPhoto.ImageLocation = m_sFolder + "\Pochettes\Jeux\" + j.Photo

    End Sub

    'Affichage du reste de la fiche une fois que l'image est affichée
    Private Sub affiche2(ByVal j As Jeu)

        Dim rb As RadioButton

        Me.TBTitre.Text = j.Titre

        Me.TBSortie.Text = j.DateSortie.Year
        Me.TBediteur.Text = j.Editeur.Nom
        Me.TBDeveloppeur.Text = j.Developpeur.Nom

        'Me.CheckDispo.Checked = j.Dispo
        'Gestion des couleurs de la combo dispo
        affichageComboDispo()

        Me.CBGenre.SelectedValue = j.LeGenre.Code
        'Me.RBCopie.Checked = j.EstCopie
        'Me.RBOriginal.Checked = Not j.EstCopie
        Me.CBMachine.SelectedValue = j.LaMachine.Code

        ''Etat du boitier
        'For Each c As Control In Me.PanelEtatBoitier.Controls
        '    rb = CType(c, RadioButton)
        '    If rb.Tag = j.EtatBoitier Then
        '        rb.Checked = True
        '    End If
        'Next

        ''Etat du livret
        'For Each c As Control In Me.PanelEtatLivret.Controls
        '    rb = CType(c, RadioButton)
        '    If rb.Tag = j.EtatLivret Then
        '        rb.Checked = True
        '    End If
        'Next

        ''Etat du jeu
        'For Each c As Control In Me.PanelEtatJeu.Controls
        '    rb = CType(c, RadioButton)
        '    If rb.Tag = j.EtatJeu Then
        '        rb.Checked = True
        '    End If
        'Next

        'Gestion de l'affichage de l'image du support

        m_sMachine = j.LaMachine.Code.ToUpper

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
            Case "PSX"
                Me.PB_Machine.Image = GestionMedias.My.Resources.Resources.PSX
            Case "WII"
                Me.PB_Machine.Image = GestionMedias.My.Resources.Resources.wii_logo
        End Select

        'Mise à jour du compteur
        miseAJourCompteur()

        'Mise à jour de l'état des boutons de navigation
        gestionNavBar()

        Me.Cursor = Cursors.Arrow
        Me.PBPhoto.Focus()

        m_oLeJeuAffiche = Nothing
        'On autorise l'affichage d'une autre fiche
        m_bNouvelAffichagePossible = True

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
        Me.TBDeveloppeur.Enabled = Not estListeVide
        Me.GBEtat.Enabled = Not estListeVide
        Me.GBSupport.Enabled = Not estListeVide
        Me.CBGenre.Enabled = Not estListeVide
        Me.CBMachine.Enabled = Not estListeVide
        Me.CheckDispo.Enabled = Not estListeVide

        'Même si la liste des films, on doit pouvoir modifier la valeur de la combo (pour changer de genre par ex)
        Me.GBNavig.Enabled = True

    End Sub

    'Remise à blanc des champs
    Private Sub RAZ()
        Me.TBTitre.Text = Nothing
        Me.TBediteur.Text = Nothing
        Me.TBDeveloppeur.Text = Nothing
        Me.PBPhoto.Image = Nothing

    End Sub

    'Active ou désactive les champs de saisie
    Private Sub etatChamps(ByVal etat As Boolean)

        ' Me.TBSortie.Text = Nothing
        Me.TBTitre.Enabled = etat
        Me.TBSortie.Enabled = etat
        Me.TBediteur.Enabled = etat
        Me.TBDeveloppeur.Enabled = etat
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
            'TODO
            'm_lListe = m_oCtrlJeux.obtenirJeux(l_sGenre, l_sMachine)
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

    Private Sub SauverJeu()

        'Dim nomImage As String
        'Dim dateSortie As DateTime
        'Dim newJeu As Jeu
        'Dim i As Integer
        'Dim etatBoitier As Integer
        'Dim etatLivret As Integer
        'Dim etatJeu As Integer

        'nomImage = ""

        'If Me.TBSortie.Text <> "" Then
        '    dateSortie = New DateTime(Me.TBSortie.Text, 1, 1)
        'End If

        ''Curseur sablier
        'Me.Cursor = Cursors.WaitCursor

        'If Not Me.PBPhoto.ImageLocation Is Nothing Then
        '    nomImage = Me.PBPhoto.ImageLocation.Split("\")(Me.PBPhoto.ImageLocation.Split("\").Length - 1)
        'End If

        ''Récupération de l'état du jeu
        'If RBBoitierAbsent.Checked Then
        '    etatBoitier = 0
        'ElseIf RBBoitierMauvais.Checked Then
        '    etatBoitier = 2
        'ElseIf RBBoitierMoyen.Checked Then
        '    etatBoitier = 3
        'ElseIf RBBoitierBon.Checked Then
        '    etatBoitier = 4
        'ElseIf RBBoitierExcellent.Checked Then
        '    etatBoitier = 5
        'End If

        'If RBLivretAbsent.Checked Then
        '    etatLivret = 0
        'ElseIf RBLivretMauvais.Checked Then
        '    etatLivret = 2
        'ElseIf RBLivretMoyen.Checked Then
        '    etatLivret = 3
        'ElseIf RBLivretBon.Checked Then
        '    etatLivret = 4
        'ElseIf RBLivretExcellent.Checked Then
        '    etatLivret = 5
        'End If

        'If RBJeuAbsent.Checked Then
        '    etatJeu = 0
        'ElseIf RBJeuMauvais.Checked Then
        '    etatJeu = 2
        'ElseIf RBJeuMoyen.Checked Then
        '    etatJeu = 3
        'ElseIf RBJeuBon.Checked Then
        '    etatJeu = 4
        'ElseIf RBJeuExcellent.Checked Then
        '    etatJeu = 5
        'End If

        ''On ajoute une nouvelle fiche
        'If (m_bModeNew) Then

        '    Try
        '        newJeu = m_oCtrlJeux.ajouterJeu(Me.TBTitre.Text, Me.CBGenre.SelectedValue, dateSortie, _
        '       nomImage, Me.TBediteur.Text, Me.TBDeveloppeur.Text, m_sMachine, etatBoitier, _
        '       etatLivret, etatJeu, Me.RBCopie.Checked)

        '        'Affichage d'un message
        '        MessageBox.Show("Fiche créée avec succès !", "Création", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '        'Mise à jour de la liste des jeux
        '        'on reconstruit la liste complète
        '        m_lListe = m_oCtrlJeux.obtenirJeux()
        '        Me.CBGenreNavig.SelectedValue = "AAA"

        '        'on se place sur la bonne position
        '        For i = 0 To m_lListe.Count - 1
        '            If newJeu.Code.ToString = m_lListe.Item(i).Code.ToString Then
        '                m_iPosition = i
        '            End If
        '        Next

        '        m_bModeNew = False
        '        'On débloque la navigation
        '        blockNavig(False)
        '        gestionNavBar()
        '        miseAJourCompteur()
        '        'Si la liste est vide on remet tout à zéro sinon on affiche la première fiche
        '        If Not leJeu() Is Nothing Then
        '            Call affiche(leJeu)
        '        Else
        '            RAZ()
        '        End If

        '    Catch ex As Exception
        '        'Echec de l'enregistrement
        '        MessageBox.Show("Erreur à l'enregistrement : " & ex.Message, "Création", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'Else
        '    Try
        '        'On modifie une fiche
        '        m_oCtrlJeux.modifierJeu(leJeu(), Me.TBTitre.Text, Me.CBGenre.SelectedValue, dateSortie, _
        '                          nomImage, Me.TBediteur.Text, Me.TBDeveloppeur.Text, m_sMachine, etatBoitier, etatLivret, _
        '                           etatJeu, Me.RBCopie.Checked)

        '        'Mise à jour de la liste des jeus
        '        m_lListe = m_oCtrlJeux.obtenirJeux(Me.CBGenreNavig.SelectedValue, Me.CBMachineNavig.SelectedValue)

        '        'Affichage d'un message
        '        MessageBox.Show("Modification effectuée !", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '    Catch ex As Exception
        '        'Affichage d'un message
        '        MessageBox.Show("Erreur lors de la modification!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End If

        ''Curseur normal
        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub FermerFenetre()
        'Libération mémoire
        m_oCtrlJeux = Nothing
        m_lListe = Nothing
        m_ListeRecherche = Nothing
    End Sub

    Private Sub SupprimerJeu()
        'Dim l_sMsg As String
        'Dim l_bOK As Boolean

        ''Affichage d'un message
        'If MessageBox.Show("Voulez-vous vraiment supprimer cette fiche ?", "Suppression", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

        '    'Variable indiquant si on doit poursuivre même si la suppression a échoué
        '    l_bOK = False

        '    While Not l_bOK
        '        l_sMsg = m_oCtrlJeux.effacerJeu(leJeu)

        '        If l_sMsg Is Nothing Then
        '            MessageBox.Show("Suppression réussie ! ", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            l_bOK = True
        '        Else
        '            If MessageBox.Show("Erreur : " + l_sMsg, "Erreur", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Retry Then
        '            Else
        '                l_bOK = True
        '            End If
        '        End If
        '    End While

        '    'Mise à jour de la liste des jeus
        '    'm_lListe = m_oCtrlJeux.obtenirJeux()
        '    MajListeParGenre()

        '    ' Si la liste n'est pas vide, on affiche le premier jeu de la liste
        '    If m_lListe.Count > 0 Then
        '        m_iPosition = 0
        '        affiche(m_lListe(0))
        '    Else
        '        'Aucun jeu, donc on efface les champs et on les grise. On désactive également les boutons de navigation
        '        RAZ()
        '        etatChamps(False)
        '        gestionNavBar()
        '        miseAJourCompteur()
        '    End If
        'End If
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
            'm_ListeRecherche = m_oCtrlJeux.chercherJeux(l_sTitre, l_oMachine, l_oGenre, l_sAnnee1, l_sAnnee2)

            m_sNomJeu = l_sTitre

            Dim gestionnaire As GestionnaireJeux
            gestionnaire = New GestionnaireJeux

            m_ListeRecherche = gestionnaire.ObtenirJeux

            m_ListeRecherche.FindAll(AddressOf FindName)

            'Si la liste n'est pas vide, on affiche la liste des jeux trouvés dans une nouvelle fenêtre
            If Not m_ListeRecherche Is Nothing AndAlso m_ListeRecherche.Count > 0 Then
                'Affichage de la liste des jeux trouvés
                'l_oEcranRecherche = New FormSearch(m_oCtrlJeux, m_ListeRecherche)
                l_oEcranRecherche = New FormSearch(m_ListeRecherche)

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

    Private m_sNomJeu As String

    Public Function FindName(pMedia As Jeu) As Boolean

        If pMedia.Titre.ToUpperInvariant().Replace(" ", "").Contains(m_sNomJeu.ToUpperInvariant().Replace(" ", "")) Then

            Return True
        Else
            Return False
        End If


    End Function

    Private Sub chercherJeuxaAvoir()

        'Dim l_oGenre As Genre
        'Dim l_oMachine As Machine
        'Dim l_oEcranRecherche As FormSearch
        'Dim i As Integer
        'Dim l_oJeu As Jeu

        ''Récupération de la liste des jeux
        'm_ListeRecherche = m_oCtrlJeux.chercherJeuxAAvoir()

        ''Si la liste n'est pas vide, on affiche la liste des jeux trouvés dans une nouvelle fenêtre
        'If Not m_ListeRecherche Is Nothing AndAlso m_ListeRecherche.Count > 0 Then
        '    'Affichage de la liste des jeux trouvés
        '    'l_oEcranRecherche = New FormSearch(m_oCtrlJeux, m_ListeRecherche)
        '    l_oEcranRecherche = New FormSearch(m_ListeRecherche)
        '    l_oEcranRecherche.Text = "Liste des jeux à avoir"
        '    'Si on clique sur OK on affiche le jeu
        '    l_oEcranRecherche.ShowDialog()

        '    If l_oEcranRecherche.ChoixRealise Then

        '        For i = 0 To m_lListe.Count - 1

        '            l_oJeu = m_lListe.Item(i)

        '            If (l_oJeu.Code.ToString = l_oEcranRecherche.JeuSelectionne.Code.ToString) Then
        '                m_iPosition = i
        '                Exit For
        '            End If
        '        Next
        '        affiche(leJeu)
        '    End If
        '    l_oEcranRecherche = Nothing
        'Else
        '    MessageBox.Show("Aucun jeu n'a été trouvé !", "Résultat", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If

        'l_oGenre = Nothing
        'l_oMachine = Nothing
        'l_oEcranRecherche = Nothing
        'l_oJeu = Nothing

    End Sub

    Private Sub AjouterJeu()
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
            .TBDeveloppeur.Text = Nothing
            .TBSortie.Text = Nothing
            .PBPhoto.ImageLocation = Nothing
        End With

        Me.TBTitre.Select()
    End Sub

#End Region

#Region "Gestion des événements"

    Private Sub FormJeux_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        FermerFenetre()
    End Sub

    Private Sub FormJeux_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And (e.KeyCode = Keys.S) Then
            If Me.BtnSave.Enabled Then
                SauverJeu()
            End If
        ElseIf e.Control And (e.KeyCode = Keys.Q) Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Subtract Then
            If Me.BtnDelete.Enabled Then
                SupprimerJeu()
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
            If Me.BtnSearch.Enabled And Not m_bModeNew Then
                e.SuppressKeyPress = True
                AjouterJeu()
            End If
        ElseIf e.KeyCode = Keys.F5 Then
            'On rafraichi la fenêtre
            Call affiche(leJeu)

        End If
    End Sub

    Private Sub FormJeux_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub PBPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBPhoto.Click

        Dim l_oDlgOuvrir As OpenFileDialog

        If m_lListe.Count > 0 Or m_bModeNew Then

            'Répertoire contenant les jaquettes de jeu
            'm_sFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\Pochettes\Jeux"
            m_sFolder = Constantes.NOM_REPERTOIRE_IMAGES + "Pochettes/Jeux/"

            'Si ce répertoire n'existe pas on le crée
            If Not Directory.Exists(m_sFolder) Then
                Directory.CreateDirectory(m_sFolder)
            End If

            l_oDlgOuvrir = New OpenFileDialog
            l_oDlgOuvrir.RestoreDirectory = True
            l_oDlgOuvrir.Title = "Sélection de la jaquette"
            l_oDlgOuvrir.Filter = "Images|*.jpg"
            l_oDlgOuvrir.AddExtension = False
            l_oDlgOuvrir.InitialDirectory = Path.GetFullPath(m_sFolder)

            If Not l_oDlgOuvrir.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Me.PBPhoto.ImageLocation = l_oDlgOuvrir.FileName
            End If
        End If

        l_oDlgOuvrir = Nothing

    End Sub

    'Boutons de navigation
    Private Sub BtnNavig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPremier.Click, BtnPrec.Click, BtnSuiv.Click, BtnDernier.Click

        If m_bNouvelAffichagePossible Then

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

        End If


    End Sub

    'Ajout d'un jeu
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        AjouterJeu()
    End Sub

    'Suppression d'un jeu
    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        SupprimerJeu()
    End Sub

    'BOUTON SAUVER
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        SauverJeu()
    End Sub

    '--------------------------------------------
    ' Recherche d'un jeu
    '--------------------------------------------
    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        chercherJeu()
    End Sub

    '--------------------------------------------
    ' Recherche des tous les jeux à avoir
    '--------------------------------------------
    Private Sub BtnJeuxaAvoir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnJeuxaAvoir.Click
        chercherJeuxaAvoir()
    End Sub

    'Mise a jour de la liste des jeux quand on choisit un genre
    Private Sub CBGenreNavig_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBGenreNavig.SelectedValueChanged

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début CBGenreNavig_SelectedValueChanged")

        If Not m_bModeNew Then
            MajListeParGenre()
        End If

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin CBGenreNavig_SelectedValueChanged")

    End Sub

    Private Sub CBMachineNavig_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBMachineNavig.SelectedValueChanged

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début CBMachineNavig_SelectedValueChanged")

        If Not m_bModeNew Then
            MajListeParGenre()
        End If

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin CBMachineNavig_SelectedValueChanged")

    End Sub

    Private Sub CheckDispo_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckDispo.CheckStateChanged
        affichageComboDispo()
    End Sub

    'Changement de couleur et de texte de la combo Disponibilités
    Private Sub affichageComboDispo()
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
        Dim l_iReponse As System.Windows.Forms.DialogResult

        Try
            'Mode enregistrement d'un prêt
            'Si false, alors on effectue un emprunt
            'Si true, on restitue l'objet ou acquisition
            l_bMode = CheckDispo.Checked

            If CheckDispo.Checked Then

                'On regarde si un prêt est en cours pour savoir s'il s'agit d'une restitution ou d'une acquisition
                If Not m_oCtrlJeux.obtenirPretEnCours(leJeu.Code) Is Nothing Then
                    'Il s'agit d'une restitution
                    'l_oEcran = New DialogPret(m_oCtrlJeux, leJeu(), enumStatutDispo.rendu, Me)

                    'Annulation sur l'écran de prêt
                    If l_oEcran.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                        'on revient à l'état initial
                        CheckDispo.Checked = Not l_bMode
                    End If

                Else
                    'Il s'agit d'une acquisition
                    'Il faut uniquement enregistrer le statut du jeu à dispo
                    'm_oCtrlJeux.modifierDispo(leJeu(), True)

                End If

            Else

                l_iReponse = MessageBox.Show("S'agit-il d'un jeu à acquérir ?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

                If l_iReponse = Windows.Forms.DialogResult.No Then
                    'Il s'agit d'un emprunt
                    'l_oEcran = New DialogPret(m_oCtrlJeux, leJeu(), enumStatutDispo.emprunte, Me)

                    'Annulation sur l'écran de prêt
                    If l_oEcran.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                        'on revient à l'état initial
                        CheckDispo.Checked = Not l_bMode
                    End If

                ElseIf l_iReponse = Windows.Forms.DialogResult.Yes Then
                    'Il s'agit d'un jeu à acquérir
                    'Il faut uniquement enregistrer le statut du jeu à non dispo
                    'm_oCtrlJeux.modifierDispo(leJeu(), False)
                Else
                    'on revient à l'état initial
                    CheckDispo.Checked = Not l_bMode
                End If

            End If

        Catch ex As Exception
            'On revient à l'état initial
            CheckDispo.Checked = Not l_bMode
            MessageBox.Show("Erreur : " & ex.Message, "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            l_oEcran = Nothing
        End Try

    End Sub

    'Action sur la roulette de la souris
    Private Sub FormJeux_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel

        If Not m_bModeNew And m_bNouvelAffichagePossible Then
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
                Case "PSX"
                    Me.PB_Machine.Image = GestionMedias.My.Resources.Resources.PSX
                Case "WII"
                    Me.PB_Machine.Image = GestionMedias.My.Resources.Resources.wii_logo
            End Select
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PBPhoto_LoadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles PBPhoto.LoadCompleted

        'Mode d'affichage de la pochette
        If Not Me.PBPhoto.Image Is Nothing AndAlso (Me.PBPhoto.Image.Height / Me.PBPhoto.Image.Width) < 1.2 Then
            Me.PBPhoto.SizeMode = PictureBoxSizeMode.Zoom
        Else
            Me.PBPhoto.SizeMode = PictureBoxSizeMode.StretchImage
        End If

        If Not m_bNouvelAffichagePossible Then
            'On poursuit l'affichage
            affiche2(m_oLeJeuAffiche)
        End If


    End Sub



    Private Sub BtnJVC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnJVC.Click

        Dim tableau() As String
        Dim motsCles As String = ""
        Dim l_sUrl As String = ""
        Dim l_oFicheJVC As FicheJeuJVC
        Dim l_oEcranRecherche As FormSearch
        Dim l_oFilm As Film
        Dim l_oListeFichesJVC As ListeFichesJeuxJVC

        Dim l_cListeJeux As List(Of FicheJeuJVC)

        l_oEcranRecherche = Nothing

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début BtnJVC_Click")

            'Initialisations
            l_oFicheJVC = Nothing
            tableau = Me.TBTitre.Text.Split
            l_oFilm = Nothing

            Me.Cursor = Cursors.WaitCursor

            l_oListeFichesJVC = m_oCtrlJeux.RechercheJVC(Me.TBTitre.Text)

            If l_oListeFichesJVC.NbResultats > 0 Then

                'Affichage du résultat dans une nouvelle fenêtre
                'l_oEcranRecherche = New FormSearch(m_oCtrlJeux, l_oListeFichesJVC)
                l_oEcranRecherche = New FormSearch(l_oListeFichesJVC)

                'Si on valide par OK, on ouvre un explorateur
                If l_oEcranRecherche.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    l_oFicheJVC = m_oCtrlJeux.FicheJeuJVC

                    If Not l_oFicheJVC Is Nothing Then

                        Me.Cursor = Cursors.WaitCursor

                        l_oFicheJVC = m_oCtrlJeux.ObtenirFicheJeuJVC(l_oFicheJVC)

                        Me.Cursor = Cursors.Default

                        If MessageBox.Show("Données récupérées avec succès. Voulez-vous mettre à jour les champs ?", "Allociné", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                            MAJchamps(l_oFicheJVC)
                        End If

                    Else
                        MessageBox.Show("Objet non défini", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                End If

            Else
                Me.Cursor = Cursors.Default
                MessageBox.Show("Aucun résultat !", "Recherche", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception

            Me.Cursor = Cursors.Default
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR BtnJVC_Click", ex)

            If Not l_oEcranRecherche Is Nothing AndAlso l_oEcranRecherche.Visible Then
                l_oEcranRecherche.Close()
            End If


            MessageBox.Show("Erreur lors de la récupération des données du site JeuxVideo.com : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            Me.Cursor = Cursors.Default

            l_oFicheJVC = Nothing
            l_cListeJeux = Nothing
            l_oEcranRecherche = Nothing
            l_oFicheJVC = Nothing

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin BtnJVC_Click")

        End Try
    End Sub

    'Mise à jour des champs suite à une recherche sur Allociné
    Private Sub MAJchamps(ByVal p_oJeu As FicheJeuJVC)

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début MAJchamps")

            Me.TBTitre.Text = p_oJeu.Titre
            Me.TBediteur.Text = p_oJeu.Editeur
            Me.TBDeveloppeur.Text = p_oJeu.Developpeur
            Me.TBSortie.Text = p_oJeu.DateSortie

            Dim codeGenre As String = m_oCtrlJeux.GetCodeLibelle(p_oJeu.Genre)

            If Not codeGenre = "" Then
                Me.CBGenre.SelectedValue = codeGenre
            End If

            Dim codeMachine As String = m_oCtrlJeux.GetCodeMachine(p_oJeu.Machine)

            If Not codeMachine = "" Then
                Me.CBMachine.SelectedValue = codeMachine
            End If

            'Déplacer la jaquette
            Dim l_sSouceFile As String
            l_sSouceFile = "C:\Temp\" + p_oJeu.NomPhoto
            Dim l_sDestFile As String
            l_sDestFile = m_sFolder + "\Pochettes\Jeux\" + p_oJeu.NomPhoto

            Log.MonitoringLogger.Info(KS_NOM_MODULE + String.Format("Déplacement du fichier {0} vers le fichier {1}.", l_sSouceFile, l_sDestFile))

            File.Move(l_sSouceFile, l_sDestFile)

            If Dir(m_sFolder + "\Pochettes\Jeux\" + p_oJeu.NomPhoto) <> "" Then
                Me.PBPhoto.ImageLocation = m_sFolder + "\Pochettes\Jeux\" + p_oJeu.NomPhoto
            Else
                Me.PBPhoto.ImageLocation = Nothing
            End If

            Me.RBOriginal.Select()

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR MAJchamps", ex)

        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin MAJchamps")

        End Try

    End Sub

#End Region

   
End Class
