Imports LibAllocine.Dl.Dto
Imports Utilitaires
Imports MediaGestion.Modele

Public Class FormSearch

    Private m_oListeJeux As List(Of Jeu)
    Private m_oListeFilms As List(Of Film)
    Private m_oJeu As Jeu
    Private m_oFilm As Film
    Private m_oProprietaire As Proprietaire
    Private m_bChoixRealise As Boolean
    Private m_oCtrlJeux As CtrlJeux
    Private m_oCtrlFilms As CtrlFilms
    Private m_oCtrlProprietaires As CtrlProprietaires
    Private m_bModeJeu As Boolean
    Private m_bModeRechercherWeb As Boolean
    Private m_cListeProprietaires As List(Of Proprietaire)

    Private KS_NOM_MODULE As String = "FormSearch"

    Public ReadOnly Property ChoixRealise() As Boolean
        Get
            Return m_bChoixRealise
        End Get
    End Property

    Public ReadOnly Property JeuSelectionne() As Jeu
        Get
            Return m_oJeu
        End Get
    End Property

    Public ReadOnly Property FilmSelectionne() As Film
        Get
            Return m_oFilm
        End Get
    End Property

    Public ReadOnly Property ProprietaireSelectionne() As Proprietaire
        Get
            Return m_oProprietaire
        End Get
    End Property

    '---------------------------------
    ' Recherche d'un jeu sur JVC
    '---------------------------------
    Public Sub New(ByVal p_oCtrlJeux As CtrlJeux, ByVal p_oListe As List(Of Jeu))

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        m_bModeJeu = True
        m_bModeRechercherWeb = False

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        m_oListeJeux = p_oListe

        m_oCtrlJeux = p_oCtrlJeux
        'Initialisation de la fenêtre
        init_DataGridViewJeu()

    End Sub

    '------------------------------------------
    ' Affichage de la liste des propriétaires
    '------------------------------------------
    Public Sub New(ByVal p_oCtrlProprietaire As CtrlProprietaires)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        m_bModeJeu = False
        m_bModeRechercherWeb = False

        m_oCtrlProprietaires = p_oCtrlProprietaire

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

        'Initialisation de la fenêtre
        initDGVProprietaire()

    End Sub

    '---------------------------------
    ' Recherche d'un film en base
    '---------------------------------
    Public Sub New(ByVal p_oCtrlFilms As CtrlFilms, ByVal p_oListe As List(Of Film))

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        m_bModeJeu = False
        m_bModeRechercherWeb = False

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        m_oListeFilms = p_oListe

        m_oCtrlFilms = p_oCtrlFilms
        'Initialisation de la fenêtre
        init_DataGridViewFilm()

    End Sub

    '-------------------------------------
    ' Recherche d'un film sur Allociné V2
    '-------------------------------------
    Public Sub New(ByVal p_oCtrlFilms As CtrlFilms, ByVal pListeFichesFilmsAllocine As ListeFichesFilmsAllocine)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()
        m_bModeJeu = False
        m_bModeRechercherWeb = True

        m_oCtrlFilms = p_oCtrlFilms

        initDGVrechercherAlloCineV2(pListeFichesFilmsAllocine)

    End Sub

    '-------------------------------------
    ' Recherche d'un jeu sur JeuxVideo.com
    '-------------------------------------
    Public Sub New(ByVal p_oCtrlJeux As CtrlJeux, ByVal pListeFichesJeuxJVC As ListeFichesJeuxJVC)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()
        m_bModeJeu = True
        m_bModeRechercherWeb = True

        m_oCtrlJeux = p_oCtrlJeux

        Me.Cursor = Cursors.WaitCursor

        initDGVrechercherJVC(pListeFichesJeuxJVC)

        Me.Cursor = Cursors.Default

    End Sub

    'Initialisation de la DataGridView pour l'affichage des propriétaires
    Private Sub initDGVProprietaire()

        Dim l_oCol As Windows.Forms.DataGridViewColumn

        Try
            Me.LblResult.Text = "Liste des propriétaires"

            m_cListeProprietaires = m_oCtrlProprietaires.ObtenirProprietaires
            Me.DGVListeFiches.DataSource = m_cListeProprietaires
            Me.DGVListeFiches.MultiSelect = False
            Me.DGVListeFiches.ReadOnly = True


            Me.DGVListeFiches.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            If Me.DGVListeFiches.Columns.Count > 0 Then


                'on n'affiche pas certaines colonnes et on change le titre de certaines colonnes
                For Each l_oCol In Me.DGVListeFiches.Columns
                    If l_oCol.Name.ToLower.Equals("adresse") _
                    Or l_oCol.Name.ToLower.Equals("cp") _
                    Or l_oCol.Name.ToLower.Equals("code") _
                    Or l_oCol.Name.ToLower.Equals("nomprenom") _
                    Or l_oCol.Name.ToLower.Equals("ville") Then
                        l_oCol.Visible = False
                    End If
                Next

                With Me.DGVListeFiches
                    .Columns("Nom").DisplayIndex = 1
                    .Columns("Nom").HeaderText = "Nom"
                    .Columns("Prenom").DisplayIndex = 2
                    .Columns("Prenom").HeaderText = "Prénom"
                    .Columns("EstProprietairePrincipal").DisplayIndex = 4
                    .Columns("EstProprietairePrincipal").HeaderText = "Principal"
                End With

            End If

        Catch ex As Exception
            MessageBox.Show("Erreur lors de la création de la DataGridView : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            l_oCol = Nothing
        End Try

    End Sub

    Private Sub initDGVrechercherAlloCineV2(ByVal pListeFichesFilmsAllocine As ListeFichesFilmsAllocine)

        Dim i As Integer
        Dim l_oFiche(7) As Object
        Dim l_oImageColumn As DataGridViewImageColumn
        Dim listeFilmAllocine As List(Of FicheFilmAllocine)
        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début initDGVrechercherAlloCineV2")

            Me.LblResult.Text = "Résultat de la recherche : " + CStr(pListeFichesFilmsAllocine.NbResultats) + " films trouvé(s) sur Allociné"

            Me.DGVListeFiches.Columns.Add("fiche", "Fiche")

            'Colonne contenant des images
            l_oImageColumn = New DataGridViewImageColumn()
            l_oImageColumn.Name = "jaquette"
            l_oImageColumn.HeaderText = "Jaquette"
            l_oImageColumn.SortMode = DataGridViewColumnSortMode.Automatic
            Me.DGVListeFiches.Columns.Add(l_oImageColumn)

            Me.DGVListeFiches.Columns.Add("titre", "Titre")
            Me.DGVListeFiches.Columns.Add("annee", "Année")
            Me.DGVListeFiches.Columns.Add("realisateur", "Réalisateur")
            Me.DGVListeFiches.Columns.Add("acteurs", "Acteurs")
            Me.DGVListeFiches.Columns.Add("notepresse", "Note presse")
            Me.DGVListeFiches.Columns.Add("notepublic", "Note public")

            listeFilmAllocine = pListeFichesFilmsAllocine.ObtenirListeFilms()

            For Each fiche As FicheFilmAllocine In listeFilmAllocine

                l_oFiche(0) = fiche

                If Not fiche.LaJaquette Is Nothing AndAlso Not fiche.LaJaquette.Url Is Nothing Then
                    l_oFiche(1) = fiche.ObtenirThumbnail
                Else
                    l_oFiche(1) = Nothing
                End If

                If Not fiche.Titre = vbNullString Then
                    l_oFiche(2) = fiche.Titre
                Else
                    l_oFiche(2) = fiche.TitreOriginal
                End If

                l_oFiche(3) = fiche.AnneeProduction

                If Not fiche.Casting Is Nothing Then
                    l_oFiche(4) = fiche.Casting.Realisateur
                    l_oFiche(5) = fiche.Casting.Acteurs
                Else
                    l_oFiche(4) = Nothing
                    l_oFiche(5) = Nothing
                End If

                If Not fiche.Statistiques Is Nothing Then
                    If fiche.Statistiques.NotePresse > 0 Then
                        l_oFiche(6) = Math.Round(fiche.Statistiques.NotePresse, 1).ToString() + "/5"
                    End If

                    l_oFiche(7) = Math.Round(fiche.Statistiques.NotePublic, 1).ToString() + "/5"
                Else
                    l_oFiche(6) = Nothing
                    l_oFiche(7) = Nothing
                End If


                Me.DGVListeFiches.Rows.Add(New DataGridViewRowCollection(Me.DGVListeFiches))
                Me.DGVListeFiches.Rows(i).SetValues(l_oFiche)

                i += 1
            Next

            With Me.DGVListeFiches

                'La colonne fiche contient l'objet fiche qui sera retourné à la fenêtre principale
                .Columns("fiche").Visible = False

                'on impose à la datagrid qu'elle ne réorganise pas ses colonnes elle-même
                .AutoGenerateColumns = False

                'Redimensionnement automatique des cellules
                '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                .AllowUserToResizeRows = True

                'Centrage des entêtes
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Largeur de la colonne jaquette
                .Columns("jaquette").Width = LibAllocine.Constantes.LargeurThumbnails
                .Columns("annee").Width = 50
                .Columns("notepresse").Width = 50
                .Columns("notepublic").Width = 50
                .Columns("titre").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("titre").MinimumWidth = 100

                .ScrollBars = ScrollBars.Both

            End With

            'Redimensionnement des lignes pour s'adapter à la hauteur des images
            For Each row As DataGridViewRow In Me.DGVListeFiches.Rows
                row.Height = LibAllocine.Constantes.HauteurThumbnails
                row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

        Catch ex As Exception

            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR = " + ex.Message)
            Throw ex
        Finally
            l_oFiche = Nothing

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin initDGVrechercherAlloCineV2")
        End Try

    End Sub

    Private Sub initDGVrechercherJVC(ByVal pListeFichesJeuxJVC)

        Dim i As Integer
        Dim l_oFiche(6) As Object
        Dim l_oImageColumn As DataGridViewImageColumn

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début initDGVrechercherJVC")

            Me.LblResult.Text = "Résultat de la recherche : " + CStr(pListeFichesJeuxJVC.NbResultats) + " jeux trouvé(s) sur JeuxVideos.com"

            Me.DGVListeFiches.Columns.Add("fiche", "Fiche")

            'Colonne contenant des images
            l_oImageColumn = New DataGridViewImageColumn()
            l_oImageColumn.Name = "jaquette"
            l_oImageColumn.HeaderText = "Jaquette"
            l_oImageColumn.SortMode = DataGridViewColumnSortMode.Automatic
            Me.DGVListeFiches.Columns.Add(l_oImageColumn)

            Me.DGVListeFiches.Columns.Add("titre", "Titre")
            Me.DGVListeFiches.Columns.Add("machine", "Machine")

            Me.DGVListeFiches.Columns.Add("annee", "Année")
            Me.DGVListeFiches.Columns.Add("editeur", "Editeur")
            Me.DGVListeFiches.Columns.Add("developpeur", "Développeur")

            pListeFichesJeuxJVC.TrierListe()

            For Each fiche As FicheJeuJVC In pListeFichesJeuxJVC

                l_oFiche(0) = fiche

                If Not fiche.UrlVignette = vbNullString Then
                    l_oFiche(1) = fiche.ObtenirThumbnail
                Else
                    l_oFiche(1) = Nothing
                End If

                l_oFiche(2) = fiche.Titre
                l_oFiche(3) = fiche.Machine
                l_oFiche(4) = fiche.DateSortie
                l_oFiche(5) = fiche.Editeur
                l_oFiche(6) = fiche.Developpeur

                Me.DGVListeFiches.Rows.Add(New DataGridViewRowCollection(Me.DGVListeFiches))
                Me.DGVListeFiches.Rows(i).SetValues(l_oFiche)

                i += 1
            Next

            With Me.DGVListeFiches

                'La colonne fiche contient l'objet fiche qui sera retourné à la fenêtre principale
                .Columns("fiche").Visible = False

                'on impose à la datagrid qu'elle ne réorganise pas ses colonnes elle-même
                .AutoGenerateColumns = False

                'Redimensionnement automatique des cellules
                '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                .AllowUserToResizeRows = True

                'Centrage des entêtes
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Largeur de la colonne jaquette
                .Columns("jaquette").Width = LibAllocine.Constantes.LargeurThumbnails
                .Columns("annee").Width = 50
                .Columns("titre").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("titre").MinimumWidth = 100
                .Columns("machine").MinimumWidth = 50

                .ScrollBars = ScrollBars.Both

            End With

            'Redimensionnement des lignes pour s'adapter à la hauteur des images
            For Each row As DataGridViewRow In Me.DGVListeFiches.Rows
                row.Height = LibAllocine.Constantes.HauteurThumbnails
                row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

        Catch ex As Exception

            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR = " + ex.Message)
            Throw ex
        Finally
            l_oFiche = Nothing

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin initDGVrechercherJVC")
        End Try

    End Sub

    'Initialisation de la DataGridView
    Private Sub init_DataGridViewJeu()

        Dim l_iWidth As Integer = 0
        Dim i As Integer
        Dim l_oJeu(6) As Object
        Dim l_cGenres As List(Of Genre)
        Dim l_oImageColumn As DataGridViewImageColumn
        Dim l_sGenre As String
        Dim l_sDispo As String
        Dim l_oImage As Image

        l_sGenre = Nothing
        l_sDispo = Nothing
        l_cGenres = m_oCtrlJeux.obtenirGenres()

        Me.DGVListeFiches.Columns.Add("code", "Code")

        'Colonne contenant des images
        l_oImageColumn = New DataGridViewImageColumn()
        l_oImageColumn.Name = "jaquette"
        l_oImageColumn.HeaderText = "Jaquette"
        l_oImageColumn.SortMode = DataGridViewColumnSortMode.Automatic
        Me.DGVListeFiches.Columns.Add(l_oImageColumn)

        Me.DGVListeFiches.Columns.Add("titre", "Titre")

        'Colonne contenant des images
        l_oImageColumn = New DataGridViewImageColumn()
        l_oImageColumn.Name = "codemachine"
        l_oImageColumn.HeaderText = "Machine"
        l_oImageColumn.SortMode = DataGridViewColumnSortMode.Automatic
        Me.DGVListeFiches.Columns.Add(l_oImageColumn)

        Me.DGVListeFiches.Columns.Add("codegenre", "Genre")
        Me.DGVListeFiches.Columns.Add("datesortie", "Sortie")
        Me.DGVListeFiches.Columns.Add("dispo", "Dispo")

        Me.LblResult.Text = "Résultat de la recherche : " + CStr(m_oListeJeux.Count) + " jeux trouvé(s)"
        Me.LblResult.TextAlign = ContentAlignment.MiddleCenter

        'Affichage du logo
        For Each j As Jeu In m_oListeJeux

            Select Case j.CodeMachine.ToUpper
                Case "PC"
                    l_oImage = New Bitmap(GestionMedias.My.Resources.Resources.PC_small)
                Case "SEGAMD"
                    l_oImage = New Bitmap(GestionMedias.My.Resources.Resources.MD_small)
                Case "NINGC"
                    l_oImage = New Bitmap(GestionMedias.My.Resources.Resources.GC_small)
                Case "SEGADC"
                    l_oImage = New Bitmap(GestionMedias.My.Resources.Resources.DC_small)
                Case "SEGAMS"
                    l_oImage = New Bitmap(GestionMedias.My.Resources.Resources.MS_small)
                Case "SEGAMCD"
                    l_oImage = New Bitmap(GestionMedias.My.Resources.Resources.MCD_small)
                Case "PSX"
                    l_oImage = New Bitmap(GestionMedias.My.Resources.Resources.PSX_small)
                Case "WII"
                    l_oImage = New Bitmap(GestionMedias.My.Resources.Resources.wii_logo_small)
                Case Else
                    l_oImage = Nothing
            End Select

            'On récupère le libellé du genre
            For Each g As Genre In l_cGenres
                If g.Code.ToUpper = j.CodeGenre.ToUpper Then
                    l_sGenre = g.Libelle
                End If
            Next

            If j.Dispo Then
                l_sDispo = "oui"
            Else
                l_sDispo = "non"
            End If

            l_oJeu(0) = j

            If Not j.Jaquette Is Nothing Then
                l_oJeu(1) = j.ObtenirThumbnail
            Else
                l_oJeu(1) = Nothing
            End If

            l_oJeu(2) = Trim(j.Titre)
            l_oJeu(3) = l_oImage
            l_oJeu(4) = Trim(l_sGenre)
            l_oJeu(5) = Trim(j.DateSortie.Year)
            l_oJeu(6) = l_sDispo

            Me.DGVListeFiches.Rows.Add(New DataGridViewRowCollection(Me.DGVListeFiches))
            Me.DGVListeFiches.Rows(i).SetValues(l_oJeu)

            l_oImage = Nothing
            i += 1
        Next

        If Me.DGVListeFiches.Columns.Count > 0 Then

            With Me.DGVListeFiches
                'on impose à la datagrid qu'elle ne réorganise pas ses colonnes elle-même
                .AutoGenerateColumns = False

                'Redimensionnement automatique des cellules
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                'Centrage des entêtes
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns("code").Visible = False

                .Columns("jaquette").DisplayIndex = 1
                .Columns("jaquette").Width = LibAllocine.Constantes.LargeurThumbnails
                .Columns("jaquette").MinimumWidth = LibAllocine.Constantes.LargeurThumbnails

                .Columns("titre").DisplayIndex = 2

                .Columns("codegenre").DisplayIndex = 3
                .Columns("codegenre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("codegenre").Width = 50
                .Columns("codegenre").MinimumWidth = 50

                .Columns("codemachine").DisplayIndex = 4
                .Columns("codemachine").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("codemachine").Width = 50
                .Columns("codemachine").MinimumWidth = 50

                .Columns("datesortie").DisplayIndex = 5
                .Columns("datesortie").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("datesortie").Width = 50
                .Columns("datesortie").MinimumWidth = 50

                .Columns("dispo").DisplayIndex = 6
                .Columns("dispo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("dispo").Width = 40
                .Columns("dispo").MinimumWidth = 40

            End With

            DGVListeFiches.Columns("jaquette").Width = LibAllocine.Constantes.LargeurThumbnails

            'Redimensionnement des lignes pour s'adapter à la hauteur des images
            For Each row As DataGridViewRow In Me.DGVListeFiches.Rows
                row.Height = LibAllocine.Constantes.HauteurThumbnails
                'row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

        End If
    End Sub

    'Initialisation de la DataGridView
    Private Sub init_DataGridViewFilm()

        Dim l_iWidth As Integer = 0
        Dim i As Integer
        Dim l_oFilm(6) As Object
        Dim l_cGenres As List(Of Genre)
        Dim l_sGenre As String
        Dim l_sDispo As String
        Dim l_oImageColumn As DataGridViewImageColumn

        l_sGenre = Nothing
        l_sDispo = Nothing
        l_cGenres = m_oCtrlFilms.ObtenirGenres()

        Me.DGVListeFiches.Columns.Add("code", "Code")

        'Colonne contenant des images
        l_oImageColumn = New DataGridViewImageColumn()
        l_oImageColumn.Name = "jaquette"
        l_oImageColumn.HeaderText = "Jaquette"
        l_oImageColumn.SortMode = DataGridViewColumnSortMode.Automatic
        Me.DGVListeFiches.Columns.Add(l_oImageColumn)

        Me.DGVListeFiches.Columns.Add("titre", "Titre")
        Me.DGVListeFiches.Columns.Add("duree", "Durée")
        Me.DGVListeFiches.Columns.Add("codegenre", "Genre")
        Me.DGVListeFiches.Columns.Add("datesortie", "Sortie")
        Me.DGVListeFiches.Columns.Add("dispo", "Dispo")

        Me.LblResult.Text = "Résultat de la recherche : " + CStr(m_oListeFilms.Count) + " films trouvé(s)"
        Me.LblResult.TextAlign = ContentAlignment.MiddleCenter

        'Pour chaque film de la liste
        For Each f As Film In m_oListeFilms

            'On récupère le libellé du genre
            For Each g As Genre In l_cGenres
                If g.Code.ToUpper = f.CodeGenre.ToUpper Then
                    l_sGenre = g.Libelle
                End If
            Next

            If Not f.Jaquette Is Nothing Then
                l_oFilm(1) = f.ObtenirThumbnail
            Else
                l_oFilm(1) = Nothing
            End If

            If f.Dispo Then
                l_sDispo = "oui"
            Else
                l_sDispo = "non"
            End If

            l_oFilm(0) = f
            l_oFilm(2) = Trim(f.Titre)
            If f.Duree > 0 Then
                l_oFilm(3) = CStr(f.Duree \ 60) + " h " + CStr(f.Duree Mod 60) + " mn"
            Else
                l_oFilm(3) = "non définie"
            End If

            l_oFilm(4) = Trim(l_sGenre)
            l_oFilm(5) = Trim(f.DateSortie.Year)
            l_oFilm(6) = l_sDispo

            Me.DGVListeFiches.Rows.Add(New DataGridViewRowCollection(Me.DGVListeFiches))
            Me.DGVListeFiches.Rows(i).SetValues(l_oFilm)

            i += 1
        Next

        If Me.DGVListeFiches.Columns.Count > 0 Then

            With Me.DGVListeFiches
                'on impose à la datagrid qu'elle ne réorganise pas ses colonnes elle-même
                .AutoGenerateColumns = False

                'Redimensionnement automatique des cellules
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                'Centrage des entêtes
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns("code").Visible = False

                .Columns("jaquette").DisplayIndex = 1
                .Columns("jaquette").Width = LibAllocine.Constantes.LargeurThumbnails
                .Columns("jaquette").MinimumWidth = LibAllocine.Constantes.LargeurThumbnails

                .Columns("titre").DisplayIndex = 2
                .Columns("titre").Width = 150
                .Columns("titre").MinimumWidth = 150

                .Columns("codegenre").DisplayIndex = 3
                .Columns("codegenre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("codegenre").Width = 60
                .Columns("codegenre").MinimumWidth = 60

                .Columns("duree").DisplayIndex = 4
                .Columns("duree").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("duree").Width = 60
                .Columns("duree").MinimumWidth = 60

                .Columns("datesortie").DisplayIndex = 5
                .Columns("datesortie").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("datesortie").Width = 50
                .Columns("datesortie").MinimumWidth = 50

                .Columns("dispo").DisplayIndex = 6
                .Columns("dispo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("dispo").Width = 40
                .Columns("dispo").MinimumWidth = 40

            End With

            DGVListeFiches.Columns("jaquette").Width = LibAllocine.Constantes.LargeurThumbnails

            'Redimensionnement des lignes pour s'adapter à la hauteur des images
            For Each row As DataGridViewRow In Me.DGVListeFiches.Rows
                row.Height = LibAllocine.Constantes.HauteurThumbnails
                'row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

        End If
    End Sub

    'Validation de la fenêtre
    Private Sub ValidationFenetre()
        If m_bModeRechercherWeb Then

            If m_bModeJeu Then
                choixRechercheJVC()
            Else
                choixRechercheFilmAllocine()
            End If

        ElseIf m_bModeJeu Then
            choixJeu()
        ElseIf Not m_oCtrlProprietaires Is Nothing Then
            choixProprietaire()
        Else
            choixFilm()
        End If
    End Sub

    Private Sub choixJeu()
        Dim l_iIndexJeu As Integer

        Try
            m_bChoixRealise = True
            'On récupère l'index du jeu sélectionné dans la DataGridView
            l_iIndexJeu = DGVListeFiches.SelectedRows.Item(0).Index
            m_oJeu = Me.DGVListeFiches.Item(0, l_iIndexJeu).Value

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub choixFilm()
        Dim l_iIndexFilm As Integer

        Try
            m_bChoixRealise = True
            'On récupère l'index du jeu sélectionné dans la DataGridView
            l_iIndexFilm = DGVListeFiches.SelectedRows.Item(0).Index
            m_oFilm = Me.DGVListeFiches.Item(0, l_iIndexFilm).Value

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub choixProprietaire()
        Dim l_iIndexProprietaire As Integer

        Try
            m_bChoixRealise = True
            'On récupère l'index du jeu sélectionné dans la DataGridView
            l_iIndexProprietaire = DGVListeFiches.SelectedRows.Item(0).Index
            m_oProprietaire = ObtenirProprietaire(Me.DGVListeFiches.Item(0, l_iIndexProprietaire).Value)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub choixRechercheFilmAllocine()
        Dim l_iIndexFilm As Integer

        Try
            m_bChoixRealise = True
            'On récupère l'index du film sélectionné dans la DataGridView
            l_iIndexFilm = DGVListeFiches.SelectedRows.Item(0).Index
            m_oCtrlFilms.FicheAllocine = Me.DGVListeFiches.Item(0, l_iIndexFilm).Value
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub choixRechercheJVC()
        Dim l_iIndexJeu As Integer

        Try
            m_bChoixRealise = True
            'On récupère l'index du film sélectionné dans la DataGridView
            l_iIndexJeu = DGVListeFiches.SelectedRows.Item(0).Index
            m_oCtrlJeux.FicheJeuJVC = Me.DGVListeFiches.Item(0, l_iIndexJeu).Value
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function ObtenirProprietaire(ByVal pCode As Guid) As Proprietaire

        Try
            For Each p As Proprietaire In m_cListeProprietaires
                If p.Code = pCode Then
                    Return p
                End If
            Next

            Return Nothing
        Catch ex As Exception
            Throw ex
        Finally

        End Try

    End Function

#Region "Evenements"

    'Validation de la fenêtre par bouton OK
    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        ValidationFenetre()
    End Sub

    Private Sub DGVListeFiches_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DGVListeFiches.DataError

        e.Cancel = True
        MessageBox.Show(e.Exception.Message)


    End Sub

    'Validation de la fenêtre par double clic
    Private Sub DGVListeFiches_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVListeFiches.DoubleClick
        ValidationFenetre()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    'Bouton cancel
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        m_bChoixRealise = False
    End Sub

    Private Sub DGVListeFiches_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGVListeFiches.KeyDown
        If e.KeyCode = Keys.Enter Then
            If m_bModeRechercherWeb Then

                If m_bModeJeu Then
                    choixRechercheJVC()
                Else
                    choixRechercheFilmAllocine()
                End If

            ElseIf m_bModeJeu Then
                choixJeu()
            ElseIf Not m_oCtrlProprietaires Is Nothing Then
                choixProprietaire()
            Else
                choixFilm()
            End If
            Me.Close()

        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        m_oListeJeux = Nothing
        m_oListeFilms = Nothing
        m_oJeu = Nothing
        m_oFilm = Nothing
        m_oProprietaire = Nothing
        m_oCtrlJeux = Nothing
        m_oCtrlFilms = Nothing
        m_oCtrlProprietaires = Nothing
        m_cListeProprietaires = Nothing
        m_cListeProprietaires = Nothing
    End Sub

    Private Sub BtnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExport.Click

        If Not m_oCtrlFilms Is Nothing Then
            m_oCtrlFilms.ExportationExcel(m_oListeFilms, Constantes.NOM_REPERTOIRE_DOCUMENTS + "films.xls")

        End If
    End Sub

#End Region



    
End Class