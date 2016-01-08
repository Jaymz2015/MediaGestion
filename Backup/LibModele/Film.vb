Public Class Film
    Inherits Media

#Region "Membres privés"

    Private pResume As String
    Private pRealisateur As String
    Private pActeurs As String
    Private pType As String
    Private pDuree As Integer

    Public Property lesActeurs() As String
        Get
            Return pActeurs
        End Get
        Set(ByVal value As String)
            pActeurs = value
        End Set
    End Property

    Public Property Duree() As Integer
        Get
            Return pDuree
        End Get
        Set(ByVal value As Integer)
            pDuree = value
        End Set
    End Property

    Public Property LeResume() As String
        Get
            Return pResume
        End Get
        Set(ByVal value As String)
            pResume = value
        End Set
    End Property

    Public Property leRealisateur() As String
        Get
            Return pRealisateur
        End Get
        Set(ByVal value As String)
            pRealisateur = value
        End Set
    End Property

    Public Property Type() As String
        Get
            Return pType
        End Get
        Set(ByVal value As String)
            pType = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub

    'Création d'un objet film à partir d'une dataRow récupérée dans la base
    Public Sub New(ByVal dr As Data.DataRow)
        MyClass.New()

        Code = dr("code")
        Titre = dr("titre")
        Duree = dr("duree")
        CodeGenre = Trim$(dr("codeGenre"))
        DateSortie = dr("dateSortie")

        If Not IsDBNull(dr("resume")) Then
            pResume = dr("resume")
        Else
            pResume = ""
        End If

        If Not IsDBNull(dr("jaquette")) Then
            Jaquette = dr("jaquette")
        Else
            Jaquette = ""
        End If

        If Not IsDBNull(dr("realisateur")) Then
            leRealisateur = dr("realisateur")
        Else
            leRealisateur = ""
        End If

        If Not IsDBNull(dr("acteurs")) Then
            lesActeurs = dr("acteurs")
        Else
            lesActeurs = ""
        End If

        Type = dr("support")

        Dispo = dr("dispo")

        If Not IsDBNull(dr("note")) Then
            Note = dr("note")
        Else
            Note = ""
        End If

    End Sub

    Public Sub New(ByVal argTitre As String, ByVal argCodeGenre As String, ByVal argDuree As Integer, ByVal argDate As Date, _
        ByVal argType As String, ByVal argDispo As Boolean)

        MyClass.New()

        Code = System.Guid.NewGuid
        Titre = argTitre
        CodeGenre = Trim$(argCodeGenre)
        Duree = argDuree
        DateSortie = argDate
        Type = argType
        Dispo = argDispo
        leRealisateur = Nothing

    End Sub

    Public Sub New(ByVal argTitre As String, ByVal argCodeGenre As String, ByVal argDuree As Integer, ByVal argDate As Date, _
        ByVal argType As String, ByVal argResume As String, ByVal argRealisateur As String, ByVal argActeurs As String, _
        ByVal argJaquette As String, ByVal argNote As String, ByVal argDispo As Boolean)

        MyClass.New()

        Code = System.Guid.NewGuid
        Titre = argTitre
        CodeGenre = Trim$(argCodeGenre)
        Duree = argDuree
        DateSortie = argDate
        Type = argType
        LeResume = argResume
        Jaquette = argJaquette
        Dispo = argDispo
        Note = argNote
        leRealisateur = argRealisateur
        lesActeurs = argActeurs

    End Sub


#End Region



End Class
