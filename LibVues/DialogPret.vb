Public Class DialogPret

    Private m_oJeu As Jeu
    Private m_oFilm As Film
    Private m_oPret As Pret
    Private m_lMode As Long
    Private m_oCtrlJeux As CtrlJeux
    Private m_oCtrlFilms As CtrlFilms
    Private m_oFormMere As Form

    Public Sub New(ByVal _ctrl As CtrlFilms, ByVal _film As Film, ByVal _mode As Long, ByVal _parent As Form)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        m_oFilm = _film
        m_lMode = _mode
        m_oCtrlFilms = _ctrl
        m_oFormMere = _parent

        Me.lblTitre2.Text = m_oFilm.Titre

        'Mode enregistrement d'un prêt
        If m_lMode = enumStatutDispo.emprunte Then

            Me.DtpRendu.Enabled = False
            Me.DtpRendu.Visible = False

        ElseIf m_lMode = enumStatutDispo.rendu Then

            m_oPret = m_oCtrlFilms.obtenirPretEnCours(m_oFilm.Code)

            Me.DtpPrete.Enabled = False
            Me.txtNom.ReadOnly = True
            Me.txtNom.TabStop = False
            Me.txtPrenom.ReadOnly = True
            Me.txtPrenom.TabStop = False
            afficher(m_oPret)
        End If


    End Sub

    Public Sub New(ByVal _ctrl As CtrlJeux, ByVal _jeu As Jeu, ByVal _mode As Long, ByVal _parent As Form)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        m_oJeu = _jeu
        m_lMode = _mode
        m_oCtrlJeux = _ctrl
        m_oFormMere = _parent

        Me.lblTitre2.Text = m_oJeu.Titre

        'Mode enregistrement
        If m_lMode = enumStatutDispo.emprunte Then
            Me.DtpRendu.Enabled = False
            Me.DtpRendu.Visible = False
        ElseIf m_lMode = enumStatutDispo.rendu Then
            m_oPret = m_oCtrlJeux.obtenirPretEnCours(m_oJeu.Code)

            Me.DtpPrete.Enabled = False
            Me.txtNom.ReadOnly = True
            Me.txtNom.TabStop = False
            Me.txtPrenom.ReadOnly = True
            Me.txtPrenom.TabStop = False
            afficher(m_oPret)
        End If

    End Sub


    Private Sub BtnAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnnuler.Click
        Me.Close()
    End Sub


    Private Sub BtnValider_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnValider.Click

        If m_oFormMere.Name = "FormFilms" Then

            If m_lMode = enumStatutDispo.rendu Then
                'Fermeture du pret
                m_oCtrlFilms.clorePret(m_oPret, m_oFilm, DtpRendu.Value)
            ElseIf m_lMode = enumStatutDispo.emprunte Then
                'Enregistrement du pret
                m_oCtrlFilms.enregistrerPret(m_oFilm, DtpPrete.Value, Me.txtNom.Text, Me.txtPrenom.Text)
            End If

        Else

            If m_lMode = enumStatutDispo.rendu Then
                'Fermeture du pret
                m_oCtrlJeux.clorePret(m_oPret, m_oJeu, DtpRendu.Value)
            ElseIf m_lMode = enumStatutDispo.emprunte Then
                'Enregistrement du pret
                m_oCtrlJeux.enregistrerPret(m_oJeu, DtpPrete.Value, Me.txtNom.Text, Me.txtPrenom.Text)
            End If

        End If
      


    End Sub

    'Affichage du prêt
    Private Sub afficher(ByVal p As Pret)

        DtpPrete.Value = p.DatePrete
        txtNom.Text = p.Nom
        txtPrenom.Text = p.Prenom

    End Sub

End Class