Public Class FormSearch

    Private m_oListeJeux As List(Of Jeu)
    Private m_oListeFilms As List(Of Film)
    Private m_oJeu As Jeu
    Private m_oFilm As Film
    Private m_bChoixRealise As Boolean
    Private m_oCtrlJeux As CtrlJeux
    Private m_oCtrlFilms As CtrlFilms
    Private m_bModeJeu As Boolean

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



    Public Sub New(ByVal p_oCtrlJeux As CtrlJeux, ByVal p_oListe As List(Of Jeu))

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        m_bModeJeu = True

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        m_oListeJeux = p_oListe

        m_oCtrlJeux = p_oCtrlJeux
        'Initialisation de la fenêtre
        init_DataGridViewJeu()

    End Sub

    Public Sub New(ByVal p_oCtrlFilms As CtrlFilms, ByVal p_oListe As List(Of Film))

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        m_bModeJeu = False

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        m_oListeFilms = p_oListe

        m_oCtrlFilms = p_oCtrlFilms
        'Initialisation de la fenêtre
        init_DataGridViewFilm()
       
    End Sub

   
    'Initialisation de la DataGridView
    Private Sub init_DataGridViewJeu()

        Dim l_iWidth As Integer = 0
        Dim i As Integer
        Dim l_oJeu(5) As Object
        Dim l_cGenres As List(Of Genre)
        Dim l_oImageColumn As DataGridViewImageColumn
        Dim l_sGenre As String
        Dim l_sDispo As String
        Dim l_oImage As Image

        l_sGenre = Nothing
        l_sDispo = Nothing
        l_cGenres = m_oCtrlJeux.obtenirGenres()

        Me.DGVListeFiches.Columns.Add("code", "Code")
        Me.DGVListeFiches.Columns.Add("titre", "Titre")

        'Colonne contenant des images
        l_oImageColumn = New DataGridViewImageColumn()
        l_oImageColumn.Name = "codemachine"
        l_oImageColumn.HeaderText = "Machine"
        l_oImageColumn.SortMode = DataGridViewColumnSortMode.Automatic
        Me.DGVListeFiches.Columns.Add(l_oImageColumn)

        Me.DGVListeFiches.Columns.Add("codegenre", "Genre")
        Me.DGVListeFiches.Columns.Add("datesortie", "Sortie")
        Me.DGVListeFiches.Columns.Add("dispo", "Disponible")

        Me.LblResult.Text = "Résultat de la recherche : " + CStr(m_oListeJeux.Count) + " jeux trouvé(s)"
        Me.LblResult.TextAlign = ContentAlignment.MiddleCenter

        'TODO : rajouter une colonne dans la table machine avec le logo

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
            l_oJeu(1) = Trim(j.Titre)
            l_oJeu(2) = l_oImage
            l_oJeu(3) = Trim(l_sGenre)
            l_oJeu(4) = Trim(j.DateSortie.Year)
            l_oJeu(5) = l_sDispo

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
                .Columns("titre").DisplayIndex = 1
                .Columns("codegenre").DisplayIndex = 2
                .Columns("codegenre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("codegenre").Width = 50
                .Columns("codemachine").DisplayIndex = 3
                .Columns("codemachine").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("codemachine").Width = 50
                .Columns("datesortie").DisplayIndex = 4
                .Columns("datesortie").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("datesortie").Width = 50
                .Columns("dispo").DisplayIndex = 5
                .Columns("dispo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("dispo").Width = 100
            End With

        End If
    End Sub

    'Initialisation de la DataGridView
    Private Sub init_DataGridViewFilm()

        Dim l_iWidth As Integer = 0
        Dim i As Integer
        Dim l_oJeu(5) As Object
        Dim l_cGenres As List(Of Genre)
        Dim l_sGenre As String
        Dim l_sDispo As String

        l_sGenre = Nothing
        l_sDispo = Nothing
        l_cGenres = m_oCtrlFilms.obtenirGenres()

        Me.DGVListeFiches.Columns.Add("code", "Code")
        Me.DGVListeFiches.Columns.Add("titre", "Titre")
        Me.DGVListeFiches.Columns.Add("duree", "Durée")
        Me.DGVListeFiches.Columns.Add("codegenre", "Genre")
        Me.DGVListeFiches.Columns.Add("datesortie", "Sortie")
        Me.DGVListeFiches.Columns.Add("dispo", "Disponible")

        Me.LblResult.Text = "Résultat de la recherche : " + CStr(m_oListeFilms.Count) + " films trouvé(s)"
        Me.LblResult.TextAlign = ContentAlignment.MiddleCenter

        For Each f As Film In m_oListeFilms

            'On récupère le libellé du genre
            For Each g As Genre In l_cGenres
                If g.Code.ToUpper = f.CodeGenre.ToUpper Then
                    l_sGenre = g.Libelle
                End If
            Next

            If f.Dispo Then
                l_sDispo = "oui"
            Else
                l_sDispo = "non"
            End If

            l_oJeu(0) = f
            l_oJeu(1) = Trim(f.Titre)
            If f.Duree > 0 Then
                l_oJeu(2) = CStr(f.Duree \ 60) + " h " + CStr(f.Duree Mod 60) + " mn"
            Else
                l_oJeu(2) = "non définie"
            End If

            l_oJeu(3) = Trim(l_sGenre)
            l_oJeu(4) = Trim(f.DateSortie.Year)
            l_oJeu(5) = l_sDispo

            Me.DGVListeFiches.Rows.Add(New DataGridViewRowCollection(Me.DGVListeFiches))
            Me.DGVListeFiches.Rows(i).SetValues(l_oJeu)

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
                .Columns("titre").DisplayIndex = 1
                .Columns("codegenre").DisplayIndex = 2
                .Columns("codegenre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("codegenre").Width = 50
                .Columns("duree").DisplayIndex = 3
                .Columns("duree").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("duree").Width = 50
                .Columns("datesortie").DisplayIndex = 4
                .Columns("datesortie").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("datesortie").Width = 50
                .Columns("dispo").DisplayIndex = 5
                .Columns("dispo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("dispo").Width = 100
            End With

        End If
    End Sub

    'Validation de la fenêtre
    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        If m_bModeJeu Then
            choixJeu()
        Else
            choixFilm()
        End If
    End Sub

    Private Sub DGVListeFiches_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVListeFiches.DoubleClick

        If m_bModeJeu Then
            choixJeu()
        Else
            choixFilm()
        End If

        Me.Close()
    End Sub

    Private Sub choixJeu()
        Dim l_iIndexJeu As Integer
        m_bChoixRealise = True
        'On récupère l'index du jeu sélectionné dans la DataGridView
        l_iIndexJeu = DGVListeFiches.SelectedRows.Item(0).Index
        m_oJeu = Me.DGVListeFiches.Item(0, l_iIndexJeu).Value
    End Sub

    Private Sub choixFilm()
        Dim l_iIndexFilm As Integer
        m_bChoixRealise = True
        'On récupère l'index du jeu sélectionné dans la DataGridView
        l_iIndexFilm = DGVListeFiches.SelectedRows.Item(0).Index
        m_oFilm = Me.DGVListeFiches.Item(0, l_iIndexFilm).Value
    End Sub


    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        m_bChoixRealise = False
    End Sub
End Class