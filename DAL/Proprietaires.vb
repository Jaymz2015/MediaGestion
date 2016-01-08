Imports Utilitaires

Public Class Proprietaires
    Inherits DataTable

    Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand

    Friend WithEvents da As System.Data.SqlClient.SqlDataAdapter

    Friend WithEvents ctn As System.Data.SqlClient.SqlConnection

    Private Const KS_NOM_MODULE = "DAL - Proprietaires - "

    Public Sub New(ByVal _ctn As System.Data.SqlClient.SqlConnection)

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début New Proprietaires")

        ctn = _ctn
        InitializeComponent()
        da.FillSchema(Me, SchemaType.Source)
        da.Fill(Me)

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin New Proprietaires")
    End Sub

    Private Sub InitializeComponent()

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début InitializeComponent")

        Me.da = New System.Data.SqlClient.SqlDataAdapter

        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand

        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()

        'DA => définition des commandes associées au DataAdapter
        '-------------------------------------------------------
        Me.da.DeleteCommand = Me.SqlDeleteCommand1
        Me.da.InsertCommand = Me.SqlInsertCommand1
        Me.da.SelectCommand = Me.SqlSelectCommand1
        Me.da.UpdateCommand = Me.SqlUpdateCommand1


        Me.da.TableMappings.AddRange(New System.Data.Common.DataTableMapping() _
             {New System.Data.Common.DataTableMapping("PROPRIETAIRE", "Proprietaires", New System.Data.Common.DataColumnMapping() _
                {New System.Data.Common.DataColumnMapping("code", "Code"), _
                    New System.Data.Common.DataColumnMapping("nom", "Nom"), _
                    New System.Data.Common.DataColumnMapping("prenom", "Prenom"), _
                    New System.Data.Common.DataColumnMapping("adresse", "Adresse"), _
                    New System.Data.Common.DataColumnMapping("cp", "CP"), _
                    New System.Data.Common.DataColumnMapping("ville", "Ville"), _
                    New System.Data.Common.DataColumnMapping("estproprietaireprincipal", "EstProprietairePrincipal") _
            })})


        'SqlSelectCommand1
        '-------------------
        Me.SqlSelectCommand1.CommandText = "SELECT code, nom,prenom, adresse, cp, ville, estproprietaireprincipal FROM PROPRIETAIRE order by nom"
        Me.SqlSelectCommand1.Connection = Me.ctn


        'SqlDeleteCommand1
        '-------------------
        Me.SqlDeleteCommand1.CommandText = "DELETE FROM PROPRIETAIRE WHERE (code = @code)"
        Me.SqlDeleteCommand1.Connection = Me.ctn
        Me.SqlDeleteCommand1.Parameters.Add( _
            New System.Data.SqlClient.SqlParameter("@code", System.Data.SqlDbType.UniqueIdentifier, 16, "code"))

        'SqlInsertCommand1
        '-------------------
        Me.SqlInsertCommand1.CommandText = "INSERT INTO PROPRIETAIRE(code, nom, prenom, adresse, cp, ville,estproprietaireprincipal)" & _
        " VALUES (@code, @nom, @prenom, @adresse, @cp, @ville, @estproprietaireprincipal);"

        Me.SqlInsertCommand1.Connection = Me.ctn
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@code", System.Data.SqlDbType.UniqueIdentifier, 16, "code"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@nom", System.Data.SqlDbType.VarChar, 20, "nom"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@prenom", System.Data.SqlDbType.VarChar, 20, "prenom"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@adresse", System.Data.SqlDbType.VarChar, 50, "adresse"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@cp", System.Data.SqlDbType.Int, 5, "cp"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ville", System.Data.SqlDbType.VarChar, 30, "ville"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@estproprietaireprincipal", System.Data.SqlDbType.Bit, 1, "estproprietaireprincipal"))

        Me.SqlInsertCommand1.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord

        'SqlUpdateCommand1
        '-------------------
        Me.SqlUpdateCommand1.CommandText = "UPDATE PROPRIETAIRE SET code = @code, nom = @nom, prenom = @prenom," & _
        "adresse = @adresse, cp = @cp, ville = @ville, estproprietaireprincipal = @estproprietaireprincipal WHERE (code = @code)"

        Me.SqlUpdateCommand1.Connection = Me.ctn
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@code", System.Data.SqlDbType.UniqueIdentifier, 16, "code"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@nom", System.Data.SqlDbType.VarChar, 20, "nom"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@prenom", System.Data.SqlDbType.VarChar, 20, "prenom"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@adresse", System.Data.SqlDbType.VarChar, 50, "adresse"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@cp", System.Data.SqlDbType.Int, 5, "cp"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ville", System.Data.SqlDbType.VarChar, 30, "ville"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@estproprietaireprincipal", System.Data.SqlDbType.Bit, 1, "estproprietaireprincipal"))

        Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin InitializeComponent")
    End Sub

    'Fonction qui retourne la liste des genres
    Public Overridable Function obtenirListe() As List(Of Proprietaire)

        Dim liste As List(Of Proprietaire)
        Dim ligne As Data.DataRow
        Dim l_oProprietaire As Proprietaire

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début obtenirListe")

            Me.Clear()
            da.Fill(Me)
            liste = New List(Of Proprietaire)

            For Each ligne In Rows
                'Construction d'un objet genre à partir d'une dataRow
                l_oProprietaire = New Proprietaire(ligne)

                'On ajoute ce prorpriétaire à la liste
                liste.Add(l_oProprietaire)
            Next

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Nombre de propriétaires récupérés en base  = " + liste.Count.ToString)

            Return liste

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR obtenirListe", ex)
            Throw ex
        Finally
            liste = Nothing
            ligne = Nothing
            l_oProprietaire = Nothing

            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin obtenirListe")
        End Try

    End Function


    '-------------------------
    ' Ajout d'un propriétaire
    '-------------------------
    Public Sub Ajouter(ByVal p As Proprietaire)

        'Construction d'un tableau à 1 élément
        Dim dr(0) As Data.DataRow

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début Ajouter : " + p.NomPrenom)

            'Si on enregistre le propriétaire comme propriétaire principal
            'il faut mettre à jour le statut des autres propriétaires
            If p.EstProprietairePrincipal Then
                If Not MiseAJourStatut() Then
                    Throw New Exception("la mise à jour du statut des propriétaires à échoué. Enregistrement impossible")
                End If
            End If

            dr(0) = Me.NewRow()
            dr(0)("code") = p.Code
            dr(0)("nom") = p.Nom

            If p.Prenom <> "" Then
                dr(0)("prenom") = p.Prenom
            Else
                dr(0)("prenom") = System.DBNull.Value
            End If

            If p.Adresse <> "" Then
                dr(0)("adresse") = p.Adresse
            Else
                dr(0)("adresse") = System.DBNull.Value
            End If

            If p.CP > 0 Then
                dr(0)("cp") = p.CP
            Else
                dr(0)("cp") = System.DBNull.Value
            End If

            If p.Ville <> "" Then
                dr(0)("ville") = p.Ville
            Else
                dr(0)("ville") = System.DBNull.Value
            End If

            dr(0)("estproprietaireprincipal") = p.EstProprietairePrincipal

            'On ajoute la ligne créée
            Me.Rows.Add(dr(0))

            'On met à jour la table
            da.Update(dr)

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR Ajouter", ex)
            Throw ex
        Finally
            dr = Nothing
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin Ajouter")
        End Try

    End Sub

    '--------------------------------------
    ' Modification d'un propriétaire
    '--------------------------------------
    Public Sub Modifier(ByVal p As Proprietaire)
        'Construction d'un tableau à 1 élément
        Dim dr(0) As Data.DataRow


        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début Modifier : " + p.NomPrenom)

            If p.EstProprietairePrincipal Then
                If Not MiseAJourStatut() Then
                    Throw New Exception("la mise à jour du statut des propriétaires à échoué. Enregistrement impossible")
                End If
            End If

            dr = Me.Select("code=" & "'" & p.Code.ToString & "'")

            dr(0).BeginEdit()

            dr(0)("code") = p.Code
            dr(0)("nom") = p.Nom

            If p.Prenom <> "" Then
                dr(0)("prenom") = p.Prenom
            Else
                dr(0)("prenom") = System.DBNull.Value
            End If

            If p.Adresse <> "" Then
                dr(0)("adresse") = p.Adresse
            Else
                dr(0)("adresse") = System.DBNull.Value
            End If

            If p.CP > 0 Then
                dr(0)("cp") = p.CP
            Else
                dr(0)("cp") = System.DBNull.Value
            End If

            If p.Ville <> "" Then
                dr(0)("ville") = p.Ville
            Else
                dr(0)("ville") = System.DBNull.Value
            End If

            dr(0)("estproprietaireprincipal") = p.EstProprietairePrincipal
            dr(0).EndEdit()

            'Mise à jour de la table
            da.Update(dr)

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR Modifier", ex)
            Throw ex
        Finally
            dr = Nothing
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin Modifier")
        End Try



    End Sub

    '--------------------------------------
    ' Modification d'un propriétaire
    '--------------------------------------
    Public Function Obtenir(ByVal pCode As Guid) As Proprietaire
        'Construction d'un tableau à 1 élément
        Dim dr(0) As Data.DataRow
        Dim p As Proprietaire = Nothing

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début Obtenir : " + pCode.ToString())

            dr = Me.Select("code=" & "'" & pCode.ToString & "'")

            If dr.Length = 1 Then
                p = New Proprietaire(dr(0))
            End If

            Return p
        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR Obtenir", ex)
            Throw ex
        Finally
            dr = Nothing
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin Obtenir")
        End Try

    End Function

    '---------------------------------------------------
    ' Mise à jour du statut des propriétaires à FALSE
    '---------------------------------------------------
    Private Function MiseAJourStatut() As Boolean

        Try
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Début MiseAJourStatut")

            'Construction d'un tableau
            Dim dr(Me.Rows.Count - 1) As Data.DataRow

            'Récupération des lignes de la table
            dr = Me.Select()

            'Mise à jour du champ estproprietaireprincipal
            For Each l_oDr As Data.DataRow In dr
                l_oDr.BeginEdit()
                l_oDr("estproprietaireprincipal") = False
                l_oDr.EndEdit()
            Next

            da.Update(dr)

            'Mise à jour de la table. UN UPDATE NE PEUT ETRE LANCE QUE SI DES LIGNES ONT ETE MODIFIEES DANS LA TABLE
            MiseAJourStatut = True

        Catch ex As Exception
            Log.MonitoringLogger.Error(KS_NOM_MODULE + "ERREUR MiseAJourStatut", ex)
            Throw ex
            MiseAJourStatut = False
        Finally
            Log.MonitoringLogger.Info(KS_NOM_MODULE + "Fin MiseAJourStatut")
        End Try

    End Function


End Class
