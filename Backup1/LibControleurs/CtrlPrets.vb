Public Class CtrlPrets

    Private base As donnees
    Private liste As List(Of Pret)

    Public Sub New(ByVal b As donnees)
        base = b
    End Sub

    'Méthode retournant la liste des prêts en cours
    'Il s'agit d'un singleton
    Public Function obtenirListePrets(ByVal p_bPretsEnCours As Boolean) As List(Of Pret)

        Return base.tablePrets.obtenirListe(p_bPretsEnCours)

    End Function

 

End Class
