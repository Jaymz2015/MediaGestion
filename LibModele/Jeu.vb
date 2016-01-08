Imports System.Drawing
Imports Utilitaires

Public Class Jeu
    Inherits Media

#Region "Membres privés"

    Private Const KS_NOM_MODULE = "LibModele - Jeu - "

    Private pCodeMachine As String
    Private pEditeur As String
    Private pDeveloppeur As String
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

    Public Property Developpeur() As String
        Get
            Return pDeveloppeur
        End Get
        Set(ByVal value As String)
            pDeveloppeur = value
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
            Photo = dr("jaquette")
        Else
            Photo = ""
        End If

        If Not IsDBNull(dr("editeur")) Then
            Editeur = dr("editeur")
        Else
            Editeur = ""
        End If

        If Not IsDBNull(dr("developpeur")) Then
            Developpeur = dr("developpeur")
        Else
            Developpeur = ""
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
         ByVal argEditeur As String, ByVal argDeveloppeur As String, ByVal argDate As Date, ByVal argPhoto As String, ByVal argNote As String, _
         ByVal argDispo As Boolean, ByVal argEtatBoitier As Integer, ByVal argEtatLivret As Integer, _
         ByVal argEtatJeu As Integer, ByVal argEstCopie As Boolean)

        MyClass.New()

        'On attribue un nouvel identifiant unique
        Code = System.Guid.NewGuid
        Titre = argTitre
        CodeGenre = Trim$(argCodeGenre)
        CodeMachine = argCodeMachine
        DateSortie = argDate
        Photo = argPhoto
        Editeur = argEditeur
        Developpeur = argDeveloppeur
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

    Public Function ObtenirThumbnail() As Image

        Dim l_oImage As Image
        Dim l_oThumbnail As Image
        Dim l_oMyCallback As Image.GetThumbnailImageAbort
        Dim l_sRepertoire As String

        l_oMyCallback = New Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)
        l_oThumbnail = Nothing

        Try
            If Me.Photo <> vbNullString Then

                If Dir(System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\Pochettes\Jeux\" + Photo) <> "" Then
                    l_sRepertoire = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\Pochettes\Jeux\"
                Else
                    l_sRepertoire = Nothing
                End If

                If l_sRepertoire <> vbNullString Then
                    l_oImage = Image.FromFile(l_sRepertoire + Me.Photo)
                    l_oThumbnail = l_oImage.GetThumbnailImage(60, 80, l_oMyCallback, IntPtr.Zero)
                End If
            End If

        Catch ex As Exception
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "ERREUR ObtenirThumbnail", ex)
            Throw ex
        End Try

        Return l_oThumbnail

    End Function

    Private Function ThumbnailCallback() As Boolean
        ThumbnailCallback = False
    End Function


End Class
