Imports Utilitaires
Imports MediaGestion.Modele
Imports System.IO

Public Class FormPrinc

    Private ctrlP As CtrlPrinc
    Private Const KS_NOM_MODULE = "LibVues - FormPrinc - "

    Public Sub New()

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "D�but New FormPrinc")

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque apr�s l'appel InitializeComponent().
        ctrlP = New CtrlPrinc

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin New FormPrinc")

    End Sub

    Private Sub EcranFilms()

        Dim ecrFilms As FormFilms

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "D�but EcranFilms")

            Call CloseWindows()

            ecrFilms = New FormFilms(ctrlP.GetCtrlFilms())
            ecrFilms.MdiParent = Me
            ecrFilms.Show()

        Catch ex As Exception

        Finally
            ecrFilms = Nothing

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin EcranFilms")
        End Try

    End Sub

    Private Sub EcranJeux()

        Dim ecrJeux As FormJeux

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "D�but EcranJeux")

            Call CloseWindows()

            ecrJeux = New FormJeux(ctrlP.GetCtrlJeux())
            ecrJeux.MdiParent = Me
            ecrJeux.Show()

        Catch ex As Exception


        Finally
            ecrJeux = Nothing

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin EcranJeux")
        End Try


    End Sub

    Private Sub EcranPrets()

        Dim ecrPrets As FormPrets

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "D�but EcranPrets")

            Call CloseWindows()

            ecrPrets = New FormPrets(ctrlP.GetCtrlPrets())
            ecrPrets.MdiParent = Me
            ecrPrets.Show()

        Catch ex As Exception

        Finally
            ecrPrets = Nothing

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin EcranPrets")
        End Try

    End Sub

    '------------------------------------------
    ' ENREGISTREMENT D'UN NOUVEAU PROPRIETAIRE
    '------------------------------------------
    Private Sub DialogCreerProprietaire()

        Dim l_oDialogEnregistrerProprietaire As DialogFicheProprietaire

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "D�but DialogCreerProprietaire")

            'Cr�ation de l'IHM
            l_oDialogEnregistrerProprietaire = New DialogFicheProprietaire(ctrlP.GetCtrlProprietaires)

            'Affichage de l'IHM
            If l_oDialogEnregistrerProprietaire.ShowDialog() = Windows.Forms.DialogResult.OK Then
                MessageBox.Show("Enregistrement OK !", "Enregistrement termin�", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Erreur � l'enregistrement : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            l_oDialogEnregistrerProprietaire = Nothing

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin DialogCreerProprietaire")
        End Try

    End Sub

    Private Sub CloseWindows()

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "D�but CloseWindows")

        'Fermer une fen�tre fille �ventuellement ouverte
        If Me.MdiChildren.Length > 0 Then
            Dim f As Form
            For Each f In Me.MdiChildren
                f.Close()
                f = Nothing
            Next
        End If

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin CloseWindows")
    End Sub

    Private Sub CreerFenetreListeProprietaires()

        'Dim l_oEcranListeProprietaires As FormSearch
        'Dim l_oDialogAfficherProprietaire As DialogFicheProprietaire
        'Dim l_oDialogResult As System.Windows.Forms.DialogResult

        'Try
        '    Log.MonitoringLogger.Info(KS_NOM_MODULE + "D�but CreerFenetreListeProprietaires")

        '    l_oEcranListeProprietaires = New FormSearch(ctrlP.GetCtrlProprietaires)
        '    'Si on clique sur OK on affiche le film
        '    l_oEcranListeProprietaires.ShowDialog()

        '    If l_oEcranListeProprietaires.ChoixRealise Then

        '        'l_oDialogAfficherProprietaire = New DialogFicheProprietaire(ctrlP.GetCtrlProprietaires, l_oEcranListeProprietaires.ProprietaireSelectionne)

        '        'Mise � jour 
        '        'l_oDialogResult = l_oDialogAfficherProprietaire.ShowDialog()

        '        If l_oDialogResult = Windows.Forms.DialogResult.OK Or l_oDialogResult = Windows.Forms.DialogResult.Yes Then
        '            MessageBox.Show("Mise � jour OK !", "Enregistrement termin�", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        End If

        '    End If

        'Catch ex As Exception
        '    MessageBox.Show("Erreur : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    l_oEcranListeProprietaires = Nothing

        '    Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin CreerFenetreListeProprietaires")

        'End Try

    End Sub

    Private Sub QuitterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitterToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVMenu.Click

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "D�but ListView1_DoubleClick")

        'Ouverture du menu s�lectionn� dans la ListView par double-clic
        Select Case LVMenu.SelectedIndices(0)
            Case 0 'Films
                Call EcranFilms()
            Case 1 'Jeux
                Call EcranJeux()
            Case 3 'Prets
                Call EcranPrets()
            Case 4 'Quitter
                If MessageBox.Show("Voulez-vous vraiment quitter ?", "Fermeture", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Close()
                End If

        End Select

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin ListView1_DoubleClick")

    End Sub

    '------------------------------------------
    'GESTIONS DES EVENEMENTS ToolStripMenuItem
    '------------------------------------------
    Private Sub GererToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExporterToolStripMenuItem.Click, EnregistrerUnPropri�taireToolStripMenuItem.Click, VoirLaListeDesPropri�tairesToolStripMenuItem.Click

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "D�but GererToolStripMenuItem_Click")

        If sender Is ExporterToolStripMenuItem Then

            Dim saveFileDialog As SaveFileDialog
            Dim nomFichier As String = ""

            saveFileDialog = New SaveFileDialog
            saveFileDialog.RestoreDirectory = True
            saveFileDialog.Title = "Export des films"
            saveFileDialog.Filter = "Excel|*.xls"
            saveFileDialog.AddExtension = False
            saveFileDialog.InitialDirectory = Path.GetFullPath(Constantes.NOM_REPERTOIRE_DOCUMENTS)
            saveFileDialog.FileName = "films"

            If Not saveFileDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                nomFichier = saveFileDialog.FileName

                Me.Cursor = Cursors.WaitCursor

                If Me.ctrlP.exportationExcel(nomFichier) = True Then
                    MessageBox.Show("Export OK", "EXPORT", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Export KO", "EXPORT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                Me.Cursor = Cursors.Default
            End If

        ElseIf sender Is EnregistrerUnPropri�taireToolStripMenuItem Then
            DialogCreerProprietaire()
        ElseIf sender Is VoirLaListeDesPropri�tairesToolStripMenuItem Then
            CreerFenetreListeProprietaires()
        End If

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin GererToolStripMenuItem_Click")

    End Sub

End Class
