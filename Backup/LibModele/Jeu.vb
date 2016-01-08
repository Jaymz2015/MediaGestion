Public Class Jeu
    Inherits Media

#Region "Membres privés"

    Private pCodeMachine As String
    Private pEditeur As String
    Private pEtatBoitier As Integer
    Private pEtatLivret As Integer
    Private pEtatJeu As Integer
    Private pEstCopie As Boolean

    Public Property EstCopie() As Boolean
        Get
            Return pEstCopie
        End Get
        Set(ByVal value As Boolean)
            pEstCopie = value
        End Set
    End Property


    Public Property CodeMachine() As String
        Get
            Return pCodeMachine
        End Get
        Set(ByVal value As String)
            pCodeMachine = value
        End Set
    End Property

    Public Property Editeur() As String
        Get
            Return pEditeur
        End Get
        Set(ByVal value As String)
            pEditeur = value
        End Set
    End Property

    Public Property EtatBoitier() As Integer
        Get
            Return pEtatBoitier
        End Get
        Set(ByVal value As Integer)
            pEtatBoitier = value
        End Set
    End Property

    Public Property EtatLivret() As Integer
        Get
            Return pEtatLivret
        End Get
        Set(ByVal value As Integer)
            pEtatLivret = value
        End Set
    End Property

    Public Property EtatJeu() As Integer
        Get
            Return pEtatJeu
        End Get
        Set(ByVal value As Integer)
            pEtatJeu = value
        End Set
    End Property



#End Region

#Region "Constructeurs"

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal dr As Data.DataRow)
        MyClass.New()
        Code = dr("code")
        Titre = dr("titre")
        CodeGenre = Trim$(dr("codeGenre"))
        DateSortie = dr("dateSortie")
        CodeMachine = dr("codeMachine")
        Dispo = dr("dispo")

        If Not IsDBNull(dr("jaquette")) Then
            Jaquette = dr("jaquette")
        Else
            Jaquette = ""
        End If

        If Not IsDBNull(dr("editeur")) Then
            Editeur = dr("editeur")
        Else
            Editeur = ""
        End If

        If Not IsDBNull(dr("note")) Then
            Note = dr("note")
        Else
            Note = ""
        End If

        EstCopie = dr("estCopie")

        EtatBoitier = dr("etatBoitier")  
        EtatLivret = dr("etatLivret")
        EtatJeu = dr("etatJeu")


    End Sub

    'Constructeur avec tous les champs de la table
    Public Sub New(ByVal argTitre As String, ByVal argCodeGenre As String, ByVal argCodeMachine As String, _
         ByVal argEditeur As String, ByVal argDate As Date, ByVal argJaquette As String, ByVal argNote As String, _
         ByVal argDispo As Boolean, ByVal argEtatBoitier As Integer, ByVal argEtatLivret As Integer, _
         ByVal argEtatJeu As Integer, ByVal argEstCopie As Boolean)

        MyClass.New()

        'On attribue un nouvel identifiant unique
        Code = System.Guid.NewGuid
        Titre = argTitre
        CodeGenre = Trim$(argCodeGenre)
        CodeMachine = argCodeMachine
        DateSortie = argDate
        Jaquette = argJaquette
        Editeur = argEditeur
        Dispo = argDispo
        Note = argNote
        EtatBoitier = argEtatBoitier
        EtatLivret = argEtatLivret
        EtatJeu = argEtatJeu
        EstCopie = argEstCopie

    End Sub

    'Constructeur avec en argument les champs obligatoires
    Public Sub New(ByVal argTitre As String, ByVal argCodeGenre As String, ByVal argCodeMachine As String, _
          ByVal argDate As Date, ByVal argDispo As Boolean, ByVal argEstCopie As Boolean)

        MyClass.New()

        'On attribue un nouvel identifiant unique
        Code = System.Guid.NewGuid
        Titre = argTitre
        CodeGenre = Trim$(argCodeGenre)
        DateSortie = argDate
        Dispo = argDispo
        CodeMachine = argCodeMachine
        EstCopie = argEstCopie

    End Sub



#End Region



End Class
