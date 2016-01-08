Public Class CtrlProprietaires

    Private base As donnees


    Public Sub New(ByVal b As donnees)
        base = b
    End Sub

    Public Function ObtenirProprietaires() As List(Of Proprietaire)
        Return base.tableProprietaires.obtenirListe()
    End Function

    Public Function AjouterProprietaire(ByVal pNom As String, ByVal pPrenom As String, ByVal pAdresse As String, _
     ByVal pCP As Integer, ByVal pVille As String, ByVal pEstProprietairePrincipal As String) As Proprietaire

        Dim p As Proprietaire

        Try
            'Création d'un nouvel objet propriétaire
            p = New Proprietaire(pNom, pPrenom, pAdresse, pCP, pVille, pEstProprietairePrincipal)
            base.tableProprietaires.Ajouter(p)
            Return p
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ModifierProprietaire(ByVal p As Proprietaire) As Proprietaire

        Try
            base.tableProprietaires.Modifier(p)

            Return p

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenirProprietaire(ByVal pCode As Guid)

        Return base.tableProprietaires.Obtenir(pCode)
    End Function



End Class
