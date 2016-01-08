Public Class Pret

    Private pCode As Guid
    Private pCodeFilm As Guid
    Private pTitre As String
    Private pDatePrete As Date
    Private pDateRendu As Date
    Private pNom As String
    Private pPrenom As String
    Private pCodeJeu As Guid

    Public Property CodeJeu() As Guid
        Get
            Return pCodeJeu
        End Get
        Set(ByVal value As Guid)
            pCodeJeu = value
        End Set
    End Property


    Public Property Code() As Guid
        Get
            Return pCode
        End Get
        Set(ByVal value As Guid)
            pCode = value
        End Set
    End Property

    Public Property CodeFilm() As Guid
        Get
            Return pCodeFilm
        End Get
        Set(ByVal value As Guid)
            pCodeFilm = value
        End Set
    End Property

    Public Property Titre() As String
        Get
            Return pTitre
        End Get
        Set(ByVal value As String)
            pTitre = value
        End Set
    End Property

    Public Property DatePrete() As Date
        Get
            Return pDatePrete
        End Get
        Set(ByVal value As Date)
            pDatePrete = value
        End Set
    End Property

    Public Property DateRendu() As Date
        Get
            Return pDateRendu
        End Get
        Set(ByVal value As Date)
            pDateRendu = value
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

    Public Property Prenom() As String
        Get
            Return pPrenom
        End Get
        Set(ByVal value As String)
            pPrenom = value
        End Set
    End Property

    Public Sub New()

    End Sub

    'Création d'un objet pret à partir d'une dataRow récupérée dans la base
    Public Sub New(ByVal dr As Data.DataRow)
        MyClass.New()

        Code = dr("code")

        If Not IsDBNull(dr("codeFilm")) Then
            CodeFilm = dr("codeFilm")
        Else
            CodeFilm = Nothing
        End If


        If Not IsDBNull(dr("codeJeu")) Then
            CodeJeu = dr("codeJeu")
        Else
            CodeJeu = Nothing
        End If

        DatePrete = Format(dr("datePrete"), "d")

        If Not IsDBNull(dr("dateRendu")) Then
            DateRendu = Format(dr("dateRendu"), "d")
        Else
            DateRendu = Nothing
        End If

        If Not IsDBNull(dr("nom")) Then
            Nom = dr("nom")
        Else
            Nom = ""
        End If

        If Not IsDBNull(dr("prenom")) Then
            Prenom = dr("prenom")
        Else
            Prenom = ""
        End If

    End Sub

    Public Sub New(ByVal _codeFilm As Guid, ByVal _codeJeu As Guid, ByVal _datePrete As Date, ByVal _nom As String, ByVal _prenom As String)

        MyClass.New()

        Code = System.Guid.NewGuid
        CodeFilm = _codeFilm
        CodeJeu = _codeJeu
        DatePrete = _datePrete
        DateRendu = Nothing
        Nom = _nom
        Prenom = _prenom
    End Sub


End Class
