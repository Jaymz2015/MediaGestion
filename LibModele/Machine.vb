Public Class Machine


    Private pCode As String
    Private pNom As String
    Private pConstructeur As String
    Private pAnnee As String

    Public Property Annee() As String
        Get
            Return pAnnee
        End Get
        Set(ByVal value As String)
            pAnnee = value
        End Set
    End Property

    Public Property Constructeur() As String
        Get
            Return pConstructeur
        End Get
        Set(ByVal value As String)
            pConstructeur = value
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

    Public Property Code() As String
        Get
            Return pCode
        End Get
        Set(ByVal value As String)
            pCode = value
        End Set
    End Property


    Public Sub New()


    End Sub

    Public Sub New(ByVal dr As Data.DataRow)
        MyClass.New()

        Code = dr("code")
        Nom = dr("nom")
        If IsDBNull(dr("constructeur")) Then
            Constructeur = ""
        Else
            Constructeur = dr("constructeur")
        End If

        If IsDBNull(dr("annee")) Then
            Annee = ""
        Else
            Annee = dr("annee")
        End If




    End Sub

    Public Overrides Function toString() As String

        Return Me.Nom

    End Function





End Class
