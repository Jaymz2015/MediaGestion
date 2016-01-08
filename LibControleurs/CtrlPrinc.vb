Imports System.Windows.Forms
Imports Utilitaires
Imports Microsoft.Office.Interop

Public Class CtrlPrinc

    Private base As donnees
    Private Const KS_NOM_MODULE = "LibControleurs - CtrlPrinc - "

    Public Sub New()

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début New CtrlPrinc")

        'base = New donnees

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin New CtrlPrinc")

    End Sub

    Public Function GetCtrlFilms() As CtrlFilms

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début GetCtrlFilms")

        Return New CtrlFilms(base)

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin GetCtrlFilms")

    End Function

    Public Function GetCtrlJeux() As CtrlJeux

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début GetCtrlJeux")

        Return New CtrlJeux(base)

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin GetCtrlJeux")

    End Function

    Public Function GetCtrlPrets() As CtrlPrets

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début GetCtrlPrets")

        Return New CtrlPrets(base)

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin GetCtrlPrets")

    End Function

    Public Function GetCtrlProprietaires() As CtrlProprietaires

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début GetCtrlProprietaires")

        Return New CtrlProprietaires(base)

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin GetCtrlProprietaires")

    End Function

    'Méthode permettant d'enregistrer dans un fichier excel la liste des films et des jeux
    Public Function exportationExcel(ByVal p_sFileName As String) As Boolean

        Dim l_oClasseurExcel As Excel.Workbook
        Dim l_oFeuilleExcel As Excel.Worksheet
        Dim l_oAppliExcel As New Excel.Application
        Dim l_iIndex As Integer
        Dim l_cGenres As List(Of Genre)
        Dim i As Integer
        Dim l_oColonne As Excel.Range

        Try

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début exportationExcel")

            exportationExcel = False


            l_oClasseurExcel = l_oAppliExcel.Workbooks.Add
            'l_oAppliExcel.Worksheets(3).Delete()

            'Enregistrement des films
            '----------------------------
            l_iIndex = 0
            l_cGenres = base.tableGenres.obtenirListe(1)
            l_oFeuilleExcel = l_oAppliExcel.Worksheets.Item(1)
            l_oFeuilleExcel.Name = "Films"

            For Each f As Film In base.tableFilms.obtenirListe

                l_iIndex += 1
                l_oFeuilleExcel.Cells(l_iIndex, 1) = f.Titre

                'Récupération du libellé du genre
                For Each g As Genre In l_cGenres
                    If g.Code = f.CodeGenre Then
                        l_oFeuilleExcel.Cells(l_iIndex, 2) = g.Libelle
                    End If
                Next

                l_oFeuilleExcel.Cells(l_iIndex, 3) = f.DateSortie.Year
                l_oFeuilleExcel.Cells(l_iIndex, 4) = f.Duree \ 60 & "h" & f.Duree Mod 60
                l_oFeuilleExcel.Cells(l_iIndex, 5) = f.leRealisateur
                l_oFeuilleExcel.Cells(l_iIndex, 6) = f.lesActeurs
                l_oFeuilleExcel.Cells(l_iIndex, 7) = f.Type
                l_oFeuilleExcel.Cells(l_iIndex, 8) = IIf(f.Dispo, "OUI", "NON")

                Dim p As Proprietaire = GetCtrlProprietaires.ObtenirProprietaire(f.CodeProprietaire)

                If Not p Is Nothing Then
                    l_oFeuilleExcel.Cells(l_iIndex, 9) = p.NomPrenom
                End If

            Next

            'Largeur des colonnes
            For i = 1 To 7
                l_oColonne = l_oFeuilleExcel.Columns(i)
                l_oColonne.AutoFit()
                l_oColonne = Nothing
            Next

            'Enregistrement des jeux
            '----------------------------
            l_iIndex = 0
            l_cGenres = Nothing
            l_cGenres = base.tableGenres.obtenirListe(2)
            l_oFeuilleExcel = l_oAppliExcel.Worksheets.Item(2)
            l_oFeuilleExcel.Name = "Jeux"

            For Each j As Jeu In base.tableJeux.obtenirListe()

                l_iIndex += 1
                l_oFeuilleExcel.Cells(l_iIndex, 1) = j.Titre

                'Récupération du libellé du genre
                For Each g As Genre In l_cGenres
                    If g.Code = j.CodeGenre Then
                        l_oFeuilleExcel.Cells(l_iIndex, 2) = g.Libelle
                    End If
                Next

                l_oFeuilleExcel.Cells(l_iIndex, 3) = j.DateSortie.Year
                l_oFeuilleExcel.Cells(l_iIndex, 4) = j.CodeMachine
                l_oFeuilleExcel.Cells(l_iIndex, 5) = j.Editeur
                l_oFeuilleExcel.Cells(l_iIndex, 6) = j.Developpeur
                l_oFeuilleExcel.Cells(l_iIndex, 7) = j.EstCopie
                l_oFeuilleExcel.Cells(l_iIndex, 8) = j.Dispo
            Next

            'Largeur des colonnes
            For i = 1 To 8
                l_oColonne = l_oFeuilleExcel.Columns(i)
                l_oColonne.AutoFit()
                l_oColonne = Nothing
            Next


            'Sauvegarde du document
            l_oClasseurExcel.SaveAs(p_sFileName)
            l_oClasseurExcel.Close()

            exportationExcel = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)

            exportationExcel = False
        Finally
            l_oClasseurExcel = Nothing
            l_oFeuilleExcel = Nothing
            l_oAppliExcel = Nothing

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin exportationExcel")
        End Try

    End Function

    




End Class
