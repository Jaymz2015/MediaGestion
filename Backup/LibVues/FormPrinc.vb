Public Class FormPrinc

    Private ctrlP As CtrlPrinc

    Public Sub New()

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        ctrlP = New CtrlPrinc

    End Sub

    Private Sub QuitterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitterToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVMenu.Click

        'Ouverture du menu sélectionné dans la ListView par double-clic
        Select Case LVMenu.SelectedIndices(0)
            Case 0 'Films
                Call EcranFilms()
            Case 1 'Jeux
                Call EcranJeux()
            Case 3 'Prets
                Call EcranPrets()
            Case 4 'Quitter
                Me.Close()
        End Select

    End Sub

    Private Sub EcranFilms()
        Call CloseWindows()
      
        Dim ecrFilms As New FormFilms(ctrlP.GetCtrlFilms())
        ecrFilms.MdiParent = Me
        ecrFilms.Show()

    End Sub

    Private Sub EcranJeux()
        Call CloseWindows()

        Dim ecrJeux As New FormJeux(ctrlP.GetCtrlJeux())
        ecrJeux.MdiParent = Me
        ecrJeux.Show()

    End Sub

    Private Sub EcranPrets()
        Call CloseWindows()

        Dim ecrPrets As New FormPrets(ctrlP.GetCtrlPrets())
        ecrPrets.MdiParent = Me
        ecrPrets.Show()

    End Sub

    Private Sub CloseWindows()
        'Fermer une fenêtre fille éventuellement ouverte
        If Me.MdiChildren.Length > 0 Then
            Dim f As Form
            For Each f In Me.MdiChildren
                f.Close()
                f = Nothing
            Next
        End If
    End Sub

End Class
