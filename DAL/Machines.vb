Public Class Machines
    Inherits DataTable

    Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
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

    'Fonction qui retourne la liste des machines
    Public Overridable Function obtenirListe() As List(Of Machine)
        Dim liste As List(Of Machine)
        Dim ligne As Data.DataRow
        Dim machine As Machine
        Me.Clear()
        da.Fill(Me)
        liste = New List(Of Machine)

        For Each ligne In Rows
            'Construction d'un objet film à partir d'une dataRow
            machine = New Machine(ligne)

            'On ajoute ce film à la liste
            liste.Add(machine)

        Next

        Return liste

    End Function

    Private Sub InitializeComponent()

        Me.da = New System.Data.SqlClient.SqlDataAdapter

        'Me.ctn = New System.Data.SqlClient.SqlConnection

        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand

        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()

        Me.da.SelectCommand = Me.SqlSelectCommand1
        Me.da.TableMappings.AddRange(New System.Data.Common.DataTableMapping() _
             {New System.Data.Common.DataTableMapping("MACHINES", "Machines", New System.Data.Common.DataColumnMapping() _
                {New System.Data.Common.DataColumnMapping("code", "Code"), _
                    New System.Data.Common.DataColumnMapping("nom", "Nom"), _
                    New System.Data.Common.DataColumnMapping("constructeur", "Constructeur"), _
                     New System.Data.Common.DataColumnMapping("annee", "Annee") _
            })})

        'ctn
        '
        'Me.ctn.ConnectionString = Donnees.chaineConnection
        '

        Me.SqlSelectCommand1.CommandText = "SELECT code, nom,constructeur, annee FROM MACHINES order by nom"
        Me.SqlSelectCommand1.Connection = Me.ctn


    End Sub

  


End Class

