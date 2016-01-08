Public Class Genre

    Private pCode As String
    Private pLibelle As String
    Private pMedia As Integer


    Public Property Media() As Integer
        Get
            Return pMedia
        End Get
        Set(ByVal value As Integer)
            pMedia = value
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

    Public Property Libelle() As String
        Get
            Return pLibelle
        End Get
        Set(ByVal value As String)
            pLibelle = value
        End Set
    End Property

    Public Sub New()


    End Sub

    Public Sub New(ByVal p_sCode As String, ByVal p_sLibelle As String, ByVal p_iMedia As Integer)
        Me.Libelle = p_sLibelle
        Me.Code = Trim$(p_sCode)
        Me.Media = p_iMedia

    End Sub


    Public Sub New(ByVal ligne As DataRow)
        Code = Trim$(ligne("codeGenre"))
        Media = ligne("media")
        If Not IsDBNull(ligne("Libelle")) Then
            Libelle = ligne("Libelle")
        Else
            Libelle = ""
        End If

    End Sub

    Public Overrides Function ToString() As String
        Return Libelle
    End Function

End Class
