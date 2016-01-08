Public Class Proprietaire

#Region "Membres privés"

    Private pCode As Guid
    Private pNom As String
    Private pPrenom As String
    Private pAdresse As String
    Private pCP As Integer
    Private pVille As String
    Private pEstProprietairePrincipal As Boolean

#End Region

#Region "Propriétés"

    Public Property Code() As Guid
        Get
            Return pCode
        End Get
        Set(ByVal value As Guid)
            pCode = value
        End Set
    End Property


    Public Property Ville() As String
        Get
            Return pVille
        End Get
        Set(ByVal value As String)
            pVille = value
        End Set
    End Property

    Public Property CP() As Integer
        Get
            Return pCP
        End Get
        Set(ByVal value As Integer)
            pCP = value
        End Set
    End Property

    Public Property Adresse() As String
        Get
            Return pAdresse
        End Get
        Set(ByVal value As String)
            pAdresse = value
        End Set
    End Property


    Public Property Prenom() As String
        Get
            Return pPrenom
        End Get
        Set(ByVal value As String)
            pPrenom = value
        End Set
    End Property

    Public Property Nom() As String
        Get
            Return pNom
        End Get
        Set(ByVal value As String)
            pNom = value
        End Set
    End Property

    Public ReadOnly Property NomPrenom() As String
        Get
            Return Me.ToString
        End Get
    End Property


    Public Property EstProprietairePrincipal() As Boolean
        Get
            Return pEstProprietairePrincipal
        End Get
        Set(ByVal value As Boolean)
            pEstProprietairePrincipal = value
        End Set
    End Property

#End Region


#Region "Constructeurs"

    Public Sub New()

    End Sub

    Public Sub New(ByVal pNom As String, ByVal pPrenom As String, ByVal pAdresse As String, ByVal pCP As String, ByVal pVille As String, ByVal pEstProprietairePrincipal As Boolean)

        'On attribue un nouvel identifiant unique
        Code = System.Guid.NewGuid
        Nom = pNom
        Prenom = pPrenom
        Adresse = pAdresse
        CP = pCP
        Ville = pVille
        EstProprietairePrincipal = pEstProprietairePrincipal

    End Sub

    Public Sub New(ByVal ligne As DataRow)

        Code = ligne("code")
        Nom = ligne("nom")

        If Not IsDBNull(ligne("prenom")) Then
            Prenom = ligne("prenom")
        End If

        If Not IsDBNull(ligne("adresse")) Then
            Adresse = ligne("adresse")
        End If

        If Not IsDBNull(ligne("cp")) Then
            CP = ligne("cp")
        End If

        If Not IsDBNull(ligne("ville")) Then
            Ville = ligne("ville")
        End If

        If Not IsDBNull(ligne("estproprietaireprincipal")) Then
            EstProprietairePrincipal = ligne("estproprietaireprincipal")
        Else
            EstProprietairePrincipal = False
        End If

    End Sub

#End Region

    Public Overrides Function ToString() As String
        If Prenom <> "" Then
            Return Nom & ", " & Prenom
        Else
            Return Nom
        End If

    End Function




End Class
