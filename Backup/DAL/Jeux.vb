Public Class Jeux
    Inherits DataTable
    Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlSelectCommand2 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand

    Friend WithEvents da As System.Data.SqlClient.SqlDataAdapter

    Friend WithEvents ctn As System.Data.SqlClient.SqlConnection

    Public Sub New(ByVal _ctn As System.Data.SqlClient.SqlConnection)
        ctn = _ctn
        InitializeComponent()
        da.FillSchema(Me, SchemaType.Source)
    End Sub

    'Fonction qui retourne la liste des Jeux
    Public Overridable Function obtenirListe() As List(Of Jeu)
        Dim liste As List(Of Jeu)
        Dim ligne As Data.DataRow
        Dim jeu As Jeu

        Me.da.SelectCommand = Me.SqlSelectCommand1

        'on vide la table avant de la remplir à partir de la base
        Me.Clear()
        da.Fill(Me)
        liste = New List(Of Jeu)

        For Each ligne In Rows
            'Construction d'un objet jeu à partir d'une dataRow
            jeu = New Jeu(ligne)
            'On ajoute ce jeu à la liste
            liste.Add(jeu)
        Next

        Return liste

    End Function

    'Fonction qui retourne la liste des jeux en fonction du genre
    Public Overridable Function obtenirListe(ByVal p_sCodeGenre As String, ByVal p_sCodeMachine As String) As List(Of Jeu)
        Dim l_cListe As List(Of Jeu)
        Dim l_oLigne As Data.DataRow
        Dim l_oJeu As Jeu
        Dim l_sRequete As String

        'on vide la table avant de la remplir à partir de la base
        Me.Clear()

        l_sRequete = "SELECT code, titre, codeMachine, codeGenre, dateSortie, jaquette," _
                 & "editeur,dispo, note, etatBoitier, etatLivret, etatJeu,estCopie FROM Jeux"


        If p_sCodeGenre <> "AAA" Then
            l_sRequete = l_sRequete & " where codeGenre like '" & p_sCodeGenre & "'"

            If p_sCodeMachine <> "AAA" Then
                l_sRequete = l_sRequete & " and codeMachine like '" & p_sCodeMachine & "'"
            End If
        Else
            If p_sCodeMachine <> "AAA" Then
                l_sRequete = l_sRequete & " where codeMachine like '" & p_sCodeMachine & "'"
            End If
        End If

        l_sRequete = l_sRequete & " order by titre"

        Me.SqlSelectCommand2.CommandText = l_sRequete
        'Me.SqlSelectCommand2.Parameters.Clear()
        'Me.SqlSelectCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@codeGenre", p_sCodeGenre))
        Me.da.SelectCommand = Me.SqlSelectCommand2

        da.Fill(Me)
        l_cListe = New List(Of Jeu)

        For Each l_oLigne In Rows
            'Construction d'un objet jeu à partir d'une dataRow
            l_oJeu = New Jeu(l_oLigne)
            'On ajoute ce jeu à la liste
            l_cListe.Add(l_oJeu)
        Next

        Return l_cListe

    End Function

    'Fonction qui retourne la liste des jeux en fonction du genre
    Public Overridable Function chercherJeux(ByVal p_sTitre As String, ByVal p_sMachine As String, _
        ByVal p_sGenre As String, ByVal p_sAnnee1 As String, ByVal p_sAnnee2 As String) As List(Of Jeu)

        Dim liste As List(Of Jeu)
        Dim ligne As Data.DataRow
        Dim jeu As Jeu
        Dim l_sRequete As String

        Dim l_dDate1 As Date
        Dim l_dDate2 As Date

        'on vide la table avant de la remplir à partir de la base
        Me.Clear()

        'Construction de la requête
        l_sRequete = "SELECT code, titre, codeMachine, codeGenre, dateSortie, jaquette," _
         & "editeur,dispo, note, etatBoitier, etatLivret, etatJeu,estCopie FROM Jeux where titre like '%" _
         + p_sTitre + "%'"

        If Not p_sMachine = Nothing Then
            l_sRequete = l_sRequete + "and codeMachine like '%" + p_sMachine + "%'"
        End If

        If Not p_sGenre = Nothing Then
            l_sRequete = l_sRequete + "and codeGenre like '%" + p_sGenre + "%'"
        End If

        If p_sAnnee1 <> "" Then
            l_dDate1 = New Date(p_sAnnee1, 1, 1)
            If p_sAnnee2 <> "" Then
                l_dDate2 = New Date(p_sAnnee2, 1, 1)

                l_sRequete = l_sRequete + " and dateSortie between '" + l_dDate1.ToString + "' and '" + l_dDate2.ToString + "'"
            Else
                l_sRequete = l_sRequete + " and dateSortie = '" + l_dDate1.ToString + "'"
            End If
        End If

        l_sRequete = l_sRequete + " order by titre"

        Me.SqlSelectCommand2.CommandText = l_sRequete
        Me.SqlSelectCommand2.Parameters.Clear()
        Me.da.SelectCommand = Me.SqlSelectCommand2

        da.Fill(Me)
        'Construction d'une nouvelle liste
        liste = New List(Of Jeu)

        For Each ligne In Rows
            'Construction d'un objet jeu à partir d'une dataRow
            jeu = New Jeu(ligne)
            'On ajoute ce jeu à la liste
            liste.Add(jeu)
        Next

        'On retourne la liste
        Return liste

    End Function

    'Ajout d'un jeu
    Public Sub ajouter(ByVal j As Jeu)

        'Construction d'un tableau à 1 élément
        Dim dr(0) As Data.DataRow
        dr(0) = Me.NewRow()
        dr(0)("code") = j.Code
        dr(0)("titre") = j.Titre
        dr(0)("codeMachine") = j.CodeMachine
        dr(0)("codeGenre") = j.CodeGenre
        dr(0)("dateSortie") = j.DateSortie
        dr(0)("jaquette") = j.Jaquette
        dr(0)("dispo") = j.Dispo
        dr(0)("note") = j.Note
        dr(0)("editeur") = j.Editeur
        dr(0)("etatBoitier") = j.EtatBoitier
        dr(0)("etatLivret") = j.EtatLivret
        dr(0)("etatJeu") = j.EtatJeu
        dr(0)("estCopie") = j.EstCopie

        'On ajoute la ligne crée
        Me.Rows.Add(dr(0))

        'On met à jour la table
        da.Update(dr)

    End Sub

    'Modification d'un jeu
    Public Sub modifier(ByVal j As Jeu)
        'Construction d'un tableau à 1 élément
        Dim dr(0) As Data.DataRow

        'Récupération des lignes contenant le code jeu (en fait une seule)
        dr = Me.Select("code=" & "'" & j.Code.ToString & "'")
        'Mise à jour de la ligne récupérée
        dr(0).BeginEdit()
        dr(0)("code") = j.Code
        dr(0)("titre") = j.Titre
        dr(0)("codeMachine") = j.CodeMachine
        dr(0)("codeGenre") = j.CodeGenre
        dr(0)("dateSortie") = j.DateSortie
        dr(0)("jaquette") = j.Jaquette
        dr(0)("editeur") = j.Editeur
        dr(0)("dispo") = j.Dispo
        dr(0)("note") = j.Note
        dr(0)("etatBoitier") = j.EtatBoitier
        dr(0)("etatLivret") = j.EtatLivret
        dr(0)("etatJeu") = j.EtatJeu
        dr(0)("estCopie") = j.EstCopie
        dr(0).EndEdit()

        'Mise à jour de la table
        da.Update(dr)

    End Sub

    'Suppression d'un jeu - on efface la ligne correspondante dans la DataTable
    Public Sub effacer(ByVal j As Jeu)
        Try
            'Construction d'un tableau à 1 élément
            Dim dr(0) As Data.DataRow
            'Récupération des lignes contenant le code jeu (en fait une seule)
            dr = Me.Select("code=" & "'" & j.Code.ToString & "'")
            'Suppression de la ligne
            dr(0).Delete()
            'Mise à jour de la table
            da.Update(Me)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Private Sub InitializeComponent()

        ' DataAdapter
        '------------------
        Me.da = New System.Data.SqlClient.SqlDataAdapter

        ' Connexion
        '-------------------
        'Me.ctn = New System.Data.SqlClient.SqlConnection

        ' SqlCommand
        '-------------------
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlSelectCommand2 = New System.Data.SqlClient.SqlCommand
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand

        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()

        'da
        '-------------------
        Me.da.DeleteCommand = Me.SqlDeleteCommand1
        Me.da.InsertCommand = Me.SqlInsertCommand1
        Me.da.SelectCommand = Me.SqlSelectCommand1
        Me.da.UpdateCommand = Me.SqlUpdateCommand1

        Me.da.TableMappings.AddRange(New System.Data.Common.DataTableMapping() _
        {New System.Data.Common.DataTableMapping("Jeux", "Jeux", New System.Data.Common.DataColumnMapping() _
          {New System.Data.Common.DataColumnMapping("code", "Code"), _
            New System.Data.Common.DataColumnMapping("titre", "Titre"), _
            New System.Data.Common.DataColumnMapping("dateSortie", "DateSortie"), _
            New System.Data.Common.DataColumnMapping("codeMachine", "CodeMachine"), _
            New System.Data.Common.DataColumnMapping("jaquette", "Jaquette"), _
            New System.Data.Common.DataColumnMapping("editeur", "Editeur"), _
            New System.Data.Common.DataColumnMapping("dispo", "Dispo"), _
            New System.Data.Common.DataColumnMapping("note", "Note"), _
            New System.Data.Common.DataColumnMapping("etatBoitier", "EtatBoitier"), _
            New System.Data.Common.DataColumnMapping("etatLivret", "EtatLivret"), _
            New System.Data.Common.DataColumnMapping("etatJeu", "EtatJeu"), _
            New System.Data.Common.DataColumnMapping("estCopie", "EstCopie") _
            })})

        'ctn
        '-------------------
        'Me.ctn.ConnectionString = donnees.chaineConnection

        'SqlDeleteCommand1
        '-------------------
        Me.SqlDeleteCommand1.CommandText = "Delete from Jeux WHERE (code = @code)"
        Me.SqlDeleteCommand1.Connection = Me.ctn
        Me.SqlDeleteCommand1.Parameters.Add( _
            New System.Data.SqlClient.SqlParameter("@code", System.Data.SqlDbType.UniqueIdentifier, 16, "code"))

        'SqlInsertCommand1
        '-------------------
        Me.SqlInsertCommand1.CommandText = "INSERT INTO JEUX(code, titre, codeMachine, codeGenre, dateSortie," & _
        "jaquette, editeur, dispo, note, etatBoitier, etatLivret, etatJeu,estCopie) VALUES (@code, @titre, @codeMachine, @genre, @sortie," & _
        "@jaquette, @editeur, @dispo, @note,@etatBoitier, @etatLivret, @etatJeu, @estCopie );"

        Me.SqlInsertCommand1.Connection = Me.ctn
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@code", System.Data.SqlDbType.UniqueIdentifier, 16, "code"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@titre", System.Data.SqlDbType.VarChar, 40, "titre"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@codeMachine", System.Data.SqlDbType.VarChar, 10, "codeMachine"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@genre", System.Data.SqlDbType.Char, 5, "codeGenre"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sortie", System.Data.SqlDbType.DateTime, 8, "dateSortie"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@jaquette", System.Data.SqlDbType.VarChar, 100, "jaquette"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@editeur", System.Data.SqlDbType.VarChar, 30, "editeur"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@dispo", System.Data.SqlDbType.Bit, 1, "dispo"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@note", System.Data.SqlDbType.TinyInt, 1, "note"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@etatBoitier", System.Data.SqlDbType.TinyInt, 1, "etatBoitier"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@etatLivret", System.Data.SqlDbType.TinyInt, 1, "etatLivret"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@etatJeu", System.Data.SqlDbType.TinyInt, 1, "etatJeu"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@estCopie", System.Data.SqlDbType.Bit, 1, "estCopie"))
        Me.SqlInsertCommand1.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord

        'SqlSelectCommand1
        '-------------------
        Me.SqlSelectCommand1.CommandText = "SELECT code, titre, codeMachine, codeGenre, dateSortie, jaquette, editeur," _
         & "dispo, note, etatBoitier, etatLivret,etatJeu,estCopie FROM Jeux order by titre"
        Me.SqlSelectCommand1.Connection = Me.ctn

        'SqlSelectCommand2
        '-------------------
        Me.SqlSelectCommand2.Connection = Me.ctn

        'SqlUpdateCommand1
        '-------------------
        Me.SqlUpdateCommand1.CommandText = "UPDATE JEUX SET titre = @titre, codeMachine = @codeMachine, codeGenre = @codeGenre," & _
        "dateSortie = @dateSortie, jaquette = @jaquette, editeur = @editeur, dispo= @dispo, note= @note," & _
        "etatBoitier = @etatBoitier, etatLivret = @etatLivret, etatJeu = @etatJeu, estCopie = @estCopie WHERE (code = @code)"

        Me.SqlUpdateCommand1.Connection = Me.ctn
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@code", System.Data.SqlDbType.UniqueIdentifier, 16, "code"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@titre", System.Data.SqlDbType.VarChar, 40, "titre"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@codeMachine", System.Data.SqlDbType.VarChar, 10, "codeMachine"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@codeGenre", System.Data.SqlDbType.Char, 5, "codeGenre"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@dateSortie", System.Data.SqlDbType.DateTime, 8, "dateSortie"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@jaquette", System.Data.SqlDbType.VarChar, 100, "jaquette"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@editeur", System.Data.SqlDbType.VarChar, 50, "editeur"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@dispo", System.Data.SqlDbType.Bit, 1, "dispo"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@note", System.Data.SqlDbType.TinyInt, 1, "note"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@etatBoitier", System.Data.SqlDbType.TinyInt, 1, "etatBoitier"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@etatLivret", System.Data.SqlDbType.TinyInt, 1, "etatLivret"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@etatJeu", System.Data.SqlDbType.TinyInt, 1, "etatJeu"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@estCopie", System.Data.SqlDbType.Bit, 1, "estCopie"))

        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub


End Class
