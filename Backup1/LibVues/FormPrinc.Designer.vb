<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPrinc
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Gestion des films", 0)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Gestion des jeux", 1)
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Gestion des CD", 2)
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Prêts en cours", 3)
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Quitter", 4)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPrinc))
        Me.LVMenu = New System.Windows.Forms.ListView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FichierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.MiseEnPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AperçuAvantImpressionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImprimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.QuitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExporterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RechercheToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ListeDesJeuxÀAvoirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FilmsÀAvoirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PropriétairesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EnregistrerUnPropriétaireToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VoirLaListeDesPropriétairesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LVMenu
        '
        Me.LVMenu.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.LVMenu.BackColor = System.Drawing.Color.RoyalBlue
        Me.LVMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.LVMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LVMenu.ForeColor = System.Drawing.Color.White
        ListViewItem5.IndentCount = 1
        Me.LVMenu.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5})
        Me.LVMenu.LabelWrap = False
        Me.LVMenu.LargeImageList = Me.ImageList1
        Me.LVMenu.Location = New System.Drawing.Point(0, 24)
        Me.LVMenu.MultiSelect = False
        Me.LVMenu.Name = "LVMenu"
        Me.LVMenu.Size = New System.Drawing.Size(149, 708)
        Me.LVMenu.TabIndex = 1
        Me.LVMenu.UseCompatibleStateImageBehavior = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "film.png")
        Me.ImageList1.Images.SetKeyName(1, "manette.png")
        Me.ImageList1.Images.SetKeyName(2, "cd.png")
        Me.ImageList1.Images.SetKeyName(3, "note.png")
        Me.ImageList1.Images.SetKeyName(4, "quitter.png")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FichierToolStripMenuItem, Me.EditionToolStripMenuItem, Me.RechercheToolStripMenuItem, Me.PropriétairesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1008, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FichierToolStripMenuItem
        '
        Me.FichierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.MiseEnPageToolStripMenuItem, Me.AperçuAvantImpressionToolStripMenuItem, Me.ImprimerToolStripMenuItem, Me.ToolStripSeparator1, Me.QuitterToolStripMenuItem})
        Me.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem"
        Me.FichierToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.FichierToolStripMenuItem.Text = "Fichier"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(202, 6)
        '
        'MiseEnPageToolStripMenuItem
        '
        Me.MiseEnPageToolStripMenuItem.Name = "MiseEnPageToolStripMenuItem"
        Me.MiseEnPageToolStripMenuItem.ShortcutKeyDisplayString = ""
        Me.MiseEnPageToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.MiseEnPageToolStripMenuItem.Text = "Mise en page..."
        '
        'AperçuAvantImpressionToolStripMenuItem
        '
        Me.AperçuAvantImpressionToolStripMenuItem.Name = "AperçuAvantImpressionToolStripMenuItem"
        Me.AperçuAvantImpressionToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.AperçuAvantImpressionToolStripMenuItem.Text = "Aperçu avant impression"
        '
        'ImprimerToolStripMenuItem
        '
        Me.ImprimerToolStripMenuItem.Name = "ImprimerToolStripMenuItem"
        Me.ImprimerToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.ImprimerToolStripMenuItem.Text = "Imprimer..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(202, 6)
        '
        'QuitterToolStripMenuItem
        '
        Me.QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem"
        Me.QuitterToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.QuitterToolStripMenuItem.Text = "Quitter"
        '
        'EditionToolStripMenuItem
        '
        Me.EditionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExporterToolStripMenuItem})
        Me.EditionToolStripMenuItem.Name = "EditionToolStripMenuItem"
        Me.EditionToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.EditionToolStripMenuItem.Text = "Edition"
        '
        'ExporterToolStripMenuItem
        '
        Me.ExporterToolStripMenuItem.Name = "ExporterToolStripMenuItem"
        Me.ExporterToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.ExporterToolStripMenuItem.Text = "Exporter au format Excel"
        '
        'RechercheToolStripMenuItem
        '
        Me.RechercheToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ListeDesJeuxÀAvoirToolStripMenuItem, Me.FilmsÀAvoirToolStripMenuItem})
        Me.RechercheToolStripMenuItem.Name = "RechercheToolStripMenuItem"
        Me.RechercheToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.RechercheToolStripMenuItem.Text = "Recherche"
        '
        'ListeDesJeuxÀAvoirToolStripMenuItem
        '
        Me.ListeDesJeuxÀAvoirToolStripMenuItem.Name = "ListeDesJeuxÀAvoirToolStripMenuItem"
        Me.ListeDesJeuxÀAvoirToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ListeDesJeuxÀAvoirToolStripMenuItem.Text = "Jeux à avoir"
        '
        'FilmsÀAvoirToolStripMenuItem
        '
        Me.FilmsÀAvoirToolStripMenuItem.Name = "FilmsÀAvoirToolStripMenuItem"
        Me.FilmsÀAvoirToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.FilmsÀAvoirToolStripMenuItem.Text = "Films à avoir"
        '
        'PropriétairesToolStripMenuItem
        '
        Me.PropriétairesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnregistrerUnPropriétaireToolStripMenuItem, Me.VoirLaListeDesPropriétairesToolStripMenuItem})
        Me.PropriétairesToolStripMenuItem.Name = "PropriétairesToolStripMenuItem"
        Me.PropriétairesToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.PropriétairesToolStripMenuItem.Text = "Propriétaires"
        '
        'EnregistrerUnPropriétaireToolStripMenuItem
        '
        Me.EnregistrerUnPropriétaireToolStripMenuItem.Name = "EnregistrerUnPropriétaireToolStripMenuItem"
        Me.EnregistrerUnPropriétaireToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.EnregistrerUnPropriétaireToolStripMenuItem.Text = "Enregistrer un propriétaire"
        '
        'VoirLaListeDesPropriétairesToolStripMenuItem
        '
        Me.VoirLaListeDesPropriétairesToolStripMenuItem.Name = "VoirLaListeDesPropriétairesToolStripMenuItem"
        Me.VoirLaListeDesPropriétairesToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.VoirLaListeDesPropriétairesToolStripMenuItem.Text = "Voir la liste des propriétaires"
        '
        'FormPrinc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 732)
        Me.Controls.Add(Me.LVMenu)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormPrinc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion des médias"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LVMenu As System.Windows.Forms.ListView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FichierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MiseEnPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AperçuAvantImpressionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RechercheToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListeDesJeuxÀAvoirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilmsÀAvoirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExporterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PropriétairesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnregistrerUnPropriétaireToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VoirLaListeDesPropriétairesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
