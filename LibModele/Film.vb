Imports System.Drawing
Imports Utilitaires

Public Class Film
    Inherits Media

#Region "Membres privés"

    Private pResume As String
    Private pRealisateur As String
    Private pActeurs As String
    Private pType As String
    Private pDuree As Integer
    Private Const KS_NOM_MODULE = "LibModele - Film - "


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

        Try

            Code = dr("code")
            Titre = dr("titre")
            Duree = dr("duree")
            CodeGenre = Trim$(dr("codeGenre"))
            DateSortie = dr("dateSortie")

            If Not IsDBNull(dr("synopsys")) Then
                pResume = dr("synopsys")
            Else
                pResume = ""
            End If

            If Not IsDBNull(dr("jaquette")) Then
                Photo = dr("jaquette")
            Else
                Photo = ""
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

            If Not IsDBNull(dr("support")) Then
                Type = dr("support")
            Else
                Type = ""
            End If

            If Not IsDBNull(dr("dispo")) Then
                Dispo = dr("dispo")
            Else
                Dispo = False
            End If

            If Not IsDBNull(dr("note")) Then
                Note = dr("note")
            Else
                Note = ""
            End If

            'Le propriétaire
            If Not IsDBNull(dr("codeProprietaire")) Then
                CodeProprietaire = dr("codeProprietaire")
            Else
                CodeProprietaire = Nothing
            End If

        Catch ex As Exception
            Throw ex
        End Try



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
        ByVal argPhoto As String, ByVal argNote As String, ByVal argDispo As Boolean, ByVal argProprietaire As Guid)

        MyClass.New()

        Code = System.Guid.NewGuid
        Titre = argTitre
        CodeGenre = Trim$(argCodeGenre)
        Duree = argDuree
        DateSortie = argDate
        Type = argType
        LeResume = argResume
        Photo = argPhoto
        Dispo = argDispo
        Note = argNote
        leRealisateur = argRealisateur
        lesActeurs = argActeurs
        CodeProprietaire = argProprietaire

    End Sub

    Public Function ObtenirThumbnail() As Image

        Dim l_oImage As Image
        Dim l_oThumbnail As Image
        Dim l_oMyCallback As Image.GetThumbnailImageAbort
        Dim l_sRepertoire As String

        l_oMyCallback = New Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)
        l_oThumbnail = Nothing

        Try
            If Me.Photo <> vbNullString Then

                'TODO : à virer du métier
                'If Dir("\\" & System.Environment.MachineName & "\Images" + "\Pochettes\DVD\" + Photo) <> "" Then
                '    l_sRepertoire = "\\" & System.Environment.MachineName & "\Images" + "\Pochettes\DVD\"
                'ElseIf Dir("\\" & System.Environment.MachineName & "\Images" + "\Pochettes\DVD\Musique\" + Photo) <> "" Then
                '    l_sRepertoire = "\\" & System.Environment.MachineName & "\Images" + "\Pochettes\DVD\Musique\"
                'Else
                '    l_sRepertoire = Nothing
                'End If
                If Dir(System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\Pochettes\DVD\" + Photo) <> "" Then
                    l_sRepertoire = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\Pochettes\DVD\"
                ElseIf Dir(System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\Pochettes\DVD\Musique\" + Photo) <> "" Then
                    l_sRepertoire = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\Pochettes\DVD\Musique\"
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

#End Region



End Class
