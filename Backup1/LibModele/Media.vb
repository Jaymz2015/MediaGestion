Public MustInherit Class Media

#Region "Membres privés"

    Private pCode As Guid
    Private pTitre As String
    Private pCodeGenre As String
    Private pDateSortie As Date
    Private pJaquette As String
    Private pDispo As Boolean
    Private pNote As Integer
    Private pCodeProprietaire As Guid

#End Region

#Region "Accesseurs"

    Public Property Code() As Guid
        Get
            Return pCode
        End Get
        Set(ByVal value As Guid)
            pCode = value
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

    Public Property CodeGenre() As String
        Get
            Return pCodeGenre
        End Get
        Set(ByVal value As String)
            pCodeGenre = value
        End Set
    End Property

    Public Property DateSortie() As Date
        Get
            Return pDateSortie
        End Get
        Set(ByVal value As Date)
            pDateSortie = value
        End Set
    End Property

    Public Property Jaquette() As String
        Get
            Return pJaquette
        End Get
        Set(ByVal value As String)
            pJaquette = value
        End Set
    End Property

    Public Property Dispo() As Boolean
        Get
            Return pDispo
        End Get
        Set(ByVal value As Boolean)
            pDispo = value
        End Set
    End Property

    Public Property Note() As Integer
        Get
            Return pNote
        End Get
        Set(ByVal value As Integer)
            pNote = value
        End Set
    End Property

    Public Property CodeProprietaire() As Guid
        Get
            Return pCodeProprietaire
        End Get
        Set(ByVal value As Guid)
            pCodeProprietaire = value
        End Set
    End Property

#End Region

#Region "Constructeurs"

    Public Sub New()

    End Sub

#End Region





End Class
