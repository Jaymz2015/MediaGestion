Public Class DialogSearchFilm

    Private m_oCtrlFilms As CtrlFilms
    Private m_bErreurSaisie As Boolean

    Public Sub New(ByVal p_oCtrlFilms)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        m_oCtrlFilms = p_oCtrlFilms
        init()

    End Sub

    Private Sub init()
        ' Il faut 2 instances distinctes de la liste des genres
        Me.CBGenre1.DataSource = m_oCtrlFilms.obtenirGenres
        Me.CBGenre2.DataSource = m_oCtrlFilms.obtenirGenres
        Me.CBProprietaire.DataSource = m_oCtrlFilms.obtenirProprietaires
        Me.CBProprietaire.SelectedText = "-"
    End Sub

    Private Sub TBAnnee_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TBAnnee1.Validating, TBAnnee2.Validating

        Dim l_iAnnee1 As Integer
        Dim l_iAnnee2 As Integer

        If Me.TBAnnee1.Text <> "" Then

            l_iAnnee1 = Int(Me.TBAnnee1.Text)

            If Me.TBAnnee2.Text <> "" Then

                l_iAnnee2 = Int(Me.TBAnnee2.Text)

                If l_iAnnee1 < 1800 Or l_iAnnee1 > Now.Year _
                    Or l_iAnnee2 < 1800 Or l_iAnnee2 > Now.Year _
                    Or l_iAnnee1 > l_iAnnee2 Then

                    MessageBox.Show("Dates non valides !", "Saisie non valide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.TBAnnee1.Text = Nothing
                    Me.TBAnnee2.Text = Nothing

                End If
            Else
                If l_iAnnee1 < 1800 Or l_iAnnee1 > Now.Year Then

                    MessageBox.Show("Dates non valides !", "Saisie non valide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.TBAnnee1.Text = Nothing
                    Me.TBAnnee2.Text = Nothing
                End If

            End If
        Else
            If Me.TBAnnee2.Text <> "" Then
                l_iAnnee2 = Int(Me.TBAnnee2.Text)

                If l_iAnnee2 < 1800 Or l_iAnnee2 > Now.Year Then

                    MessageBox.Show("Dates non valides !", "Saisie non valide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.TBAnnee1.Text = Nothing
                    Me.TBAnnee2.Text = Nothing

                End If

            Else

            End If
        End If

    End Sub


    Private Sub TBAnnee2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TBAnnee2.Validating

        If Me.TBAnnee1.Text <> "" And Me.TBAnnee2.Text <> "" Then

            If Int(Me.TBAnnee2.Text) < 1800 Or Int(Me.TBAnnee2.Text) > Now.Year Or Int(Me.TBAnnee2.Text) < Int(Me.TBAnnee1.Text) Then

                MessageBox.Show("Dates non valides !", "Saisie non valide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.TBAnnee2.Text = Nothing
            End If

        End If

    End Sub

    Private Sub Duree_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TBMmin.Validating, TBHmin.Validating, TBMmax.Validating, TBHmax.Validating

        Dim l_iMmin As Integer
        Dim l_iHMin As Integer
        Dim l_iMmax As Integer
        Dim l_iHmax As Integer

        If Me.TBHmin.Text <> "" Then

            l_iHMin = Int(Me.TBHmin.Text)

            If l_iHMin < 0 Then
                Me.TBHmin.Text = ""
            End If

            If Me.TBMmin.Text = "" Then
                Me.TBMmin.Text = "00"
            End If
        End If

        If Me.TBMmin.Text <> "" Then

            l_iMmin = Int(Me.TBMmin.Text)

            If l_iMmin < 0 Or l_iMmin > 59 Then
                Me.TBMmin.Text = "00"
            End If

            If Me.TBHmin.Text = "" Then
                Me.TBHmin.Text = "0"
            End If
        End If

        If Me.TBHmax.Text <> "" Then

            l_iHmax = Int(Me.TBHmax.Text)

            If l_iHmax < 0 Then
                Me.TBHmax.Text = ""
            End If

            If Me.TBMmax.Text = "" Then
                Me.TBMmax.Text = "00"
            End If
        End If

        If Me.TBMmax.Text <> "" Then

            l_iMmax = Int(Me.TBMmax.Text)

            If l_iMmax < 0 Or l_iMmax > 59 Then
                Me.TBMmax.Text = "00"
            End If

            If Me.TBHmax.Text = "" Then
                Me.TBHmax.Text = "0"
            End If
        End If

    End Sub


    Private Sub BtnValider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnValider.Click

        Dim l_iMmin As Integer
        Dim l_iHMin As Integer
        Dim l_iMmax As Integer
        Dim l_iHmax As Integer

        If Me.TBHmin.Text <> "" Then
            l_iMmin = Me.TBHmin.Text
        Else
            l_iMmin = 0
        End If

        If Me.TBMmin.Text <> "" Then
            l_iHMin = Me.TBMmin.Text
        Else
            l_iHMin = 0
        End If

        If Me.TBHmax.Text <> "" Then
            l_iMmax = Me.TBHmax.Text
        Else
            l_iMmax = 0
        End If

        If Me.TBMmax.Text <> "" Then
            l_iHmax = Me.TBMmax.Text
        Else
            l_iHmax = 0
        End If

        If Not (l_iMmin + l_iHMin + l_iMmax + l_iHmax = 0) _
            And (l_iHMin * 60 + l_iMmin >= l_iHmax * 60 + l_iMmax) Then

            MessageBox.Show("Valeurs incohérentes, vérifiez votre saisie !", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            m_bErreurSaisie = True
        Else
            m_bErreurSaisie = False
        End If

    End Sub

    'On n'autorise pas la fermeture de la fenêtre si la saisie n'est pas correcte
    Private Sub DialogSearchFilm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If m_bErreurSaisie Then
            e.Cancel = True
        End If

    End Sub

End Class