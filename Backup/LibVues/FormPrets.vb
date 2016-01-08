Public Class FormPrets

    Private m_oCtrl As CtrlPrets


    Public Sub New(ByVal c As CtrlPrets)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        m_oCtrl = c

        Me.RBEnCours.Checked = True

    End Sub

    'Initialisation de la DataGridView
    Private Sub configurerDataGridView(ByVal p_cListePrets As List(Of Pret))

        Dim l_iWidth As Integer = 0
        Dim l_oCol As Windows.Forms.DataGridViewColumn

        Me.DGVPrets.DataSource = p_cListePrets

        'on impose à la datagrid qu'elle ne réorganise pas ses colonnes elle-même
        Me.DGVPrets.AutoGenerateColumns = False

        'Redimensionnement automatique des cellules
        Me.DGVPrets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        If Me.DGVPrets.Columns.Count > 0 Then

            With Me.DGVPrets
                .Columns("Titre").DisplayIndex = 1
                .Columns("Titre").HeaderText = "Titre"
                .Columns("Nom").DisplayIndex = 2
                .Columns("Prenom").DisplayIndex = 3
                .Columns("DatePrete").DisplayIndex = 4
                .Columns("DatePrete").HeaderText = "Prêté le"
                .Columns("DateRendu").DisplayIndex = 5
                .Columns("DateRendu").HeaderText = "Rendu le"
            End With

            'on n'affiche pas certaines colonnes et on change le titre de certaines colonnes
            For Each l_oCol In Me.DGVPrets.Columns
                If l_oCol.Name.ToLower.Equals("codefilm") _
                Or l_oCol.Name.ToLower.Equals("codejeu") _
                Or l_oCol.Name.ToLower.Equals("code") Then
                    l_oCol.Visible = False
                End If
            Next

        End If

    End Sub

    Private Sub FormPrets_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill

    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Libération mémoire
        m_oCtrl = Nothing

        Me.Close()
    End Sub


    Private Sub RB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBEnCours.CheckedChanged, RBTout.CheckedChanged

        If Not m_oCtrl Is Nothing Then
            If RBEnCours.Checked Then
                configurerDataGridView(m_oCtrl.obtenirListePrets(True))
            Else
                configurerDataGridView(m_oCtrl.obtenirListePrets(False))
            End If
        End If


    End Sub
End Class