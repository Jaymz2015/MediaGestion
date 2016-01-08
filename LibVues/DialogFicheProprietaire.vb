Imports System.Windows.Forms

Public Class DialogFicheProprietaire

    Private m_oCtrl As CtrlProprietaires
    Private m_bModification As Boolean
    Private m_oProprietaire As Proprietaire

    Public Sub New(ByVal p_oCtrl As CtrlProprietaires)


        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        m_bModification = False
        m_oCtrl = p_oCtrl

    End Sub

    Public Sub New(ByVal p_oCtrl As CtrlProprietaires, ByVal p_oProprietaire As Proprietaire)


        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

        m_oCtrl = p_oCtrl
        m_oProprietaire = p_oProprietaire

        initFiche(p_oProprietaire)

    End Sub

    Private Sub initFiche(ByVal p As Proprietaire)

        Me.TxtNom.Text = p.Nom
        Me.TxtPrenom.Text = p.Prenom
        Me.TxtAdresse.Text = p.Adresse

        If p.CP > 0 Then
            Me.TxtCP.Text = p.CP
        Else
            Me.TxtCP.Text = ""
        End If

        Me.TxtVille.Text = p.Ville
        Me.CBProprietairePrincipal.Checked = p.EstProprietairePrincipal
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Dim l_oDialogResult As System.Windows.Forms.DialogResult

        Try
            'Enregistrement du propriétaire

            If Not m_oProprietaire Is Nothing Then

                If m_bModification Then
                    l_oDialogResult = MessageBox.Show("Des modifications ont été apportées. Voulez-vous les enregistrer ?", "Modification", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                    If l_oDialogResult = Windows.Forms.DialogResult.Yes Then
                        'Enregistrement des modifications
                        m_oProprietaire.Nom = TxtNom.Text
                        m_oProprietaire.Prenom = TxtPrenom.Text
                        m_oProprietaire.Adresse = TxtAdresse.Text
                        m_oProprietaire.CP = GetCP(TxtCP.Text)
                        m_oProprietaire.Ville = TxtVille.Text
                        m_oProprietaire.EstProprietairePrincipal = CBProprietairePrincipal.Checked

                        m_oCtrl.ModifierProprietaire(m_oProprietaire)

                        Me.DialogResult = System.Windows.Forms.DialogResult.Yes
                        Me.Close()
                    ElseIf l_oDialogResult = Windows.Forms.DialogResult.No Then

                        Me.DialogResult = System.Windows.Forms.DialogResult.No
                        Me.Close()

                    Else
                        'On ne fait rien
                    End If

                Else
                    'On ferme la fenêtre, aucune modification n'a été apportée (comme un cancel
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                    Me.Close()
                End If


            Else

                m_oCtrl.AjouterProprietaire(Me.TxtNom.Text, Me.TxtPrenom.Text, Me.TxtAdresse.Text, IIf(Me.TxtCP.Text <> "", Me.TxtCP.Text, 0), Me.TxtVille.Text, Me.CBProprietairePrincipal.Checked)

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)

        Finally
            l_oDialogResult = Nothing
        End Try

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        m_oProprietaire = Nothing
        m_bModification = False
        m_oCtrl = Nothing
    End Sub

    Private Sub TxtAdresse_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNom.Validating, TxtPrenom.Validating, TxtAdresse.Validating, TxtCP.Validating, TxtVille.Validating, CBProprietairePrincipal.Validating

        If Not m_oProprietaire Is Nothing Then
            'On compare avec l'objet initial pour voir si des modifications ont été apportées
            If TxtNom.Text <> m_oProprietaire.Nom Or _
                TxtPrenom.Text <> m_oProprietaire.Prenom Or _
                TxtAdresse.Text <> m_oProprietaire.Adresse Or _
                GetCP(TxtCP.Text) <> m_oProprietaire.CP Or _
                TxtVille.Text <> m_oProprietaire.Ville Or _
                CBProprietairePrincipal.Checked <> m_oProprietaire.EstProprietairePrincipal Then

                m_bModification = True
            Else
                m_bModification = False
            End If

        End If
       

    End Sub

    Private Function GetCP(ByVal pCP As String) As Integer

        If pCP = "" Then
            Return 0
        Else
            Return CStr(pCP)
        End If

    End Function




End Class
