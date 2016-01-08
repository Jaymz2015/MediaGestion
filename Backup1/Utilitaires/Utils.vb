Imports log4net
Imports log4net.Config

Public Class Utils

    Private Shared LeLog As ILog

    Private Const KS_NOM_MODULE = "Utilitaires - Utils"


    Private Function MonTrim(ByVal p_sChaine As String) As String
        Dim chars As Char()
        Dim l_sRetour As String

        Try
            chars = p_sChaine.ToCharArray()

            l_sRetour = vbNullString

            For i As Integer = 0 To chars.Length - 1

                If chars(i) <> Chr(9) And chars(i) <> Chr(10) And chars(i) <> Chr(13) And chars(i) <> Chr(32) Then
                    l_sRetour = l_sRetour & chars(i)

                End If
            Next

            Return l_sRetour

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR MonTrim", ex)
            Throw ex
        End Try

    End Function

    Private Function EstChaineVide(ByVal p_sChaine As String) As Boolean

        Dim chars As Char()

        Try
            EstChaineVide = True

            chars = p_sChaine.ToCharArray()

            For i As Integer = 0 To chars.Length - 1

                If chars(i) <> Chr(9) And chars(i) <> Chr(10) And chars(i) <> Chr(13) And chars(i) <> Chr(32) Then
                    EstChaineVide = False
                End If
            Next

        Catch ex As Exception
            EstChaineVide = False
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR EstChaineVide", ex)
        End Try

    End Function
End Class
