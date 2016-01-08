Public Class DialogPret

    Private pJeu As Jeu
    Private pFilm As Film
    Private pPret As Pret
    Private pMode As Boolean
    Private pCtrlJeux As CtrlJeux
    Private pCtrlFilms As CtrlFilms
    Private pParent As Form

    Public Sub New(ByVal _ctrl As CtrlFilms, ByVal _film As Film, ByVal _mode As Boolean, ByVal _parent As Form)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        pFilm = _film
        pMode = _mode
        pCtrlFilms = _ctrl
        pParent = _parent

        Me.lblTitre2.Text = pFilm.Titre

        'Mode enregistrement = FALSE
        If pMode = False Then
            Me.DtpRendu.Enabled = False
            Me.DtpRendu.Visible = False
        Else
            pPret = pCtrlFilms.obtenirPretEnCours(pFilm.Code)

            Me.DtpPrete.Enabled = False
            Me.txtNom.ReadOnly = True
            Me.txtNom.TabStop = False
            Me.txtPrenom.ReadOnly = True
            Me.txtPrenom.TabStop = False
            afficher(pPret)
        End If



    End Sub

    Public Sub New(ByVal _ctrl As CtrlJeux, ByVal _jeu As Jeu, ByVal _mode As Boolean, ByVal _parent As Form)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        pJeu = _jeu
        pMode = _mode
        pCtrlJeux = _ctrl
        pParent = _parent

        Me.lblTitre2.Text = pJeu.Titre

        'Mode enregistrement = FALSE
        If pMode = False Then
            Me.DtpRendu.Enabled = False
            Me.DtpRendu.Visible = False
        Else
            pPret = pCtrlJeux.obtenirPretEnCours(pJeu.Code)

            Me.DtpPrete.Enabled = False
            Me.txtNom.ReadOnly = True
            Me.txtNom.TabStop = False
            Me.txtPrenom.ReadOnly = True
            Me.txtPrenom.TabStop = False
            afficher(pPret)
        End If



    End Sub


    Private Sub BtnAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnnuler.Click
        Me.Close()
    End Sub


    Private Sub BtnValider_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnValider.Click

        If pParent.Name = "FormFilms" Then

            If pMode Then
                'Fermeture du pret
                pCtrlFilms.clorePret(pPret, pFilm, DtpRendu.Value)
            Else
                'Enregistrement du pret
                pCtrlFilms.enregistrerPret(pFilm, DtpPrete.Value, Me.txtNom.Text, Me.txtPrenom.Text)
            End If

        Else

            If pMode Then
                'Fermeture du pret
                pCtrlJeux.clorePret(pPret, pJeu, DtpRendu.Value)
            Else
                'Enregistrement du pret
                pCtrlJeux.enregistrerPret(pJeu, DtpPrete.Value, Me.txtNom.Text, Me.txtPrenom.Text)
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