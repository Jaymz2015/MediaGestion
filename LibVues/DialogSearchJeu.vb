Public Class DialogSearchJeu

    Private m_oCtrlJeux As CtrlJeux


    Public Sub New(ByVal p_oCtrlJeux)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        m_oCtrlJeux = p_oCtrlJeux
        init()

    End Sub

    Private Sub init()

        Me.CBGenre.DataSource = m_oCtrlJeux.obtenirGenres
        Me.CBMachine.DataSource = m_oCtrlJeux.obtenirMachines

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

End Class