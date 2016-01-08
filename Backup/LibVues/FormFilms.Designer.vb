<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFilms
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFilms))
        Me.TBdureeH = New System.Windows.Forms.TextBox
        Me.TBrealisateur = New System.Windows.Forms.TextBox
        Me.TBacteurs = New System.Windows.Forms.TextBox
        Me.LblSortie = New System.Windows.Forms.Label
        Me.LblDuree = New System.Windows.Forms.Label
        Me.LblGenre = New System.Windows.Forms.Label
        Me.LblRealisateur = New System.Windows.Forms.Label
        Me.LblActeurs = New System.Windows.Forms.Label
        Me.CBGenre = New System.Windows.Forms.ComboBox
        Me.DTPSortie = New System.Windows.Forms.DateTimePicker
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnPrec = New System.Windows.Forms.Button
        Me.BtnDernier = New System.Windows.Forms.Button
        Me.BtnSuiv = New System.Windows.Forms.Button
        Me.BtnPremier = New System.Windows.Forms.Button
        Me.TBTitre = New System.Windows.Forms.TextBox
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.RichTextBoxPrintCtrl1 = New ExtendedRichTextBox.RichTextBoxPrintCtrl
        Me.RtbResume = New ExtendedRichTextBox.RichTextBoxPrintCtrl
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog
        Me.TBdureeM = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.CheckDispo = New System.Windows.Forms.CheckBox
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.GBNavig = New System.Windows.Forms.GroupBox
        Me.LblGenre2 = New System.Windows.Forms.Label
        Me.CBGenreNavig = New System.Windows.Forms.ComboBox
        Me.lblCpt = New System.Windows.Forms.Label
        Me.PB_Support = New System.Windows.Forms.PictureBox
        Me.BtnSearch = New System.Windows.Forms.Button
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnDelete = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.PBJaquette = New System.Windows.Forms.PictureBox
        Me.CBSupport = New System.Windows.Forms.ComboBox
        Me.LblSupport = New System.Windows.Forms.Label
        Me.FilmBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GBNavig.SuspendLayout()
        CType(Me.PB_Support, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBJaquette, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FilmBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TBdureeH
        '
        Me.TBdureeH.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBdureeH.Location = New System.Drawing.Point(546, 180)
        Me.TBdureeH.Name = "TBdureeH"
        Me.TBdureeH.Size = New System.Drawing.Size(34, 23)
        Me.TBdureeH.TabIndex = 10
        Me.TBdureeH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TBrealisateur
        '
        Me.TBrealisateur.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBrealisateur.Location = New System.Drawing.Point(546, 231)
        Me.TBrealisateur.Name = "TBrealisateur"
        Me.TBrealisateur.Size = New System.Drawing.Size(276, 23)
        Me.TBrealisateur.TabIndex = 14
        '
        'TBacteurs
        '
        Me.TBacteurs.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBacteurs.Location = New System.Drawing.Point(546, 256)
        Me.TBacteurs.Name = "TBacteurs"
        Me.TBacteurs.Size = New System.Drawing.Size(276, 23)
        Me.TBacteurs.TabIndex = 16
        '
        'LblSortie
        '
        Me.LblSortie.AutoSize = True
        Me.LblSortie.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSortie.Location = New System.Drawing.Point(430, 160)
        Me.LblSortie.Name = "LblSortie"
        Me.LblSortie.Size = New System.Drawing.Size(97, 16)
        Me.LblSortie.TabIndex = 7
        Me.LblSortie.Text = "Date de sortie :"
        '
        'LblDuree
        '
        Me.LblDuree.AutoSize = True
        Me.LblDuree.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDuree.Location = New System.Drawing.Point(430, 184)
        Me.LblDuree.Name = "LblDuree"
        Me.LblDuree.Size = New System.Drawing.Size(51, 16)
        Me.LblDuree.TabIndex = 9
        Me.LblDuree.Text = "Durée :"
        '
        'LblGenre
        '
        Me.LblGenre.AutoSize = True
        Me.LblGenre.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGenre.Location = New System.Drawing.Point(430, 208)
        Me.LblGenre.Name = "LblGenre"
        Me.LblGenre.Size = New System.Drawing.Size(51, 16)
        Me.LblGenre.TabIndex = 11
        Me.LblGenre.Text = "Genre :"
        '
        'LblRealisateur
        '
        Me.LblRealisateur.AutoSize = True
        Me.LblRealisateur.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRealisateur.Location = New System.Drawing.Point(430, 234)
        Me.LblRealisateur.Name = "LblRealisateur"
        Me.LblRealisateur.Size = New System.Drawing.Size(81, 16)
        Me.LblRealisateur.TabIndex = 13
        Me.LblRealisateur.Text = "Réalisateur :"
        '
        'LblActeurs
        '
        Me.LblActeurs.AutoSize = True
        Me.LblActeurs.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblActeurs.Location = New System.Drawing.Point(430, 259)
        Me.LblActeurs.Name = "LblActeurs"
        Me.LblActeurs.Size = New System.Drawing.Size(60, 16)
        Me.LblActeurs.TabIndex = 15
        Me.LblActeurs.Text = "Acteurs :"
        '
        'CBGenre
        '
        Me.CBGenre.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBGenre.FormattingEnabled = True
        Me.CBGenre.Location = New System.Drawing.Point(546, 205)
        Me.CBGenre.Name = "CBGenre"
        Me.CBGenre.Size = New System.Drawing.Size(164, 24)
        Me.CBGenre.TabIndex = 12
        '
        'DTPSortie
        '
        Me.DTPSortie.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPSortie.Location = New System.Drawing.Point(546, 155)
        Me.DTPSortie.Name = "DTPSortie"
        Me.DTPSortie.Size = New System.Drawing.Size(204, 23)
        Me.DTPSortie.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnPrec)
        Me.Panel1.Controls.Add(Me.BtnDernier)
        Me.Panel1.Controls.Add(Me.BtnSuiv)
        Me.Panel1.Controls.Add(Me.BtnPremier)
        Me.Panel1.Location = New System.Drawing.Point(119, 610)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(209, 57)
        Me.Panel1.TabIndex = 19
        '
        'BtnPrec
        '
        Me.BtnPrec.BackgroundImage = Global.GestionMedias.My.Resources.Resources.precedentpetit
        Me.BtnPrec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPrec.FlatAppearance.BorderSize = 0
        Me.BtnPrec.Location = New System.Drawing.Point(55, 2)
        Me.BtnPrec.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnPrec.Name = "BtnPrec"
        Me.BtnPrec.Size = New System.Drawing.Size(50, 50)
        Me.BtnPrec.TabIndex = 1
        Me.BtnPrec.UseVisualStyleBackColor = True
        '
        'BtnDernier
        '
        Me.BtnDernier.BackgroundImage = Global.GestionMedias.My.Resources.Resources.dernierpetit
        Me.BtnDernier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnDernier.FlatAppearance.BorderSize = 0
        Me.BtnDernier.Location = New System.Drawing.Point(155, 2)
        Me.BtnDernier.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnDernier.Name = "BtnDernier"
        Me.BtnDernier.Size = New System.Drawing.Size(50, 50)
        Me.BtnDernier.TabIndex = 3
        Me.BtnDernier.UseVisualStyleBackColor = True
        '
        'BtnSuiv
        '
        Me.BtnSuiv.BackgroundImage = Global.GestionMedias.My.Resources.Resources.Suivantpetit
        Me.BtnSuiv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnSuiv.FlatAppearance.BorderSize = 0
        Me.BtnSuiv.Location = New System.Drawing.Point(105, 2)
        Me.BtnSuiv.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnSuiv.Name = "BtnSuiv"
        Me.BtnSuiv.Size = New System.Drawing.Size(50, 50)
        Me.BtnSuiv.TabIndex = 2
        Me.BtnSuiv.UseVisualStyleBackColor = True
        '
        'BtnPremier
        '
        Me.BtnPremier.BackgroundImage = Global.GestionMedias.My.Resources.Resources.premierpetit
        Me.BtnPremier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPremier.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnPremier.FlatAppearance.BorderSize = 0
        Me.BtnPremier.Location = New System.Drawing.Point(5, 2)
        Me.BtnPremier.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnPremier.Name = "BtnPremier"
        Me.BtnPremier.Size = New System.Drawing.Size(50, 50)
        Me.BtnPremier.TabIndex = 0
        Me.BtnPremier.UseVisualStyleBackColor = True
        '
        'TBTitre
        '
        Me.TBTitre.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBTitre.Location = New System.Drawing.Point(433, 90)
        Me.TBTitre.Name = "TBTitre"
        Me.TBTitre.Size = New System.Drawing.Size(389, 33)
        Me.TBTitre.TabIndex = 6
        Me.TBTitre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PrintDocument1
        '
        '
        'RichTextBoxPrintCtrl1
        '
        Me.RichTextBoxPrintCtrl1.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBoxPrintCtrl1.Name = "RichTextBoxPrintCtrl1"
        Me.RichTextBoxPrintCtrl1.Size = New System.Drawing.Size(100, 96)
        Me.RichTextBoxPrintCtrl1.TabIndex = 0
        Me.RichTextBoxPrintCtrl1.Text = ""
        '
        'RtbResume
        '
        Me.RtbResume.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.RtbResume.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RtbResume.Location = New System.Drawing.Point(433, 313)
        Me.RtbResume.Name = "RtbResume"
        Me.RtbResume.Size = New System.Drawing.Size(389, 272)
        Me.RtbResume.TabIndex = 20
        Me.RtbResume.Text = ""
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.UseEXDialog = True
        '
        'PageSetupDialog1
        '
        Me.PageSetupDialog1.Document = Me.PrintDocument1
        '
        'TBdureeM
        '
        Me.TBdureeM.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBdureeM.Location = New System.Drawing.Point(607, 181)
        Me.TBdureeM.Name = "TBdureeM"
        Me.TBdureeM.Size = New System.Drawing.Size(38, 23)
        Me.TBdureeM.TabIndex = 21
        Me.TBdureeM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(586, 187)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 16)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "h"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(651, 187)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 16)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "mn"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(44, 588)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(86, 13)
        Me.LinkLabel1.TabIndex = 24
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "mega-search.net"
        '
        'CheckDispo
        '
        Me.CheckDispo.AutoSize = True
        Me.CheckDispo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckDispo.Location = New System.Drawing.Point(710, 591)
        Me.CheckDispo.Name = "CheckDispo"
        Me.CheckDispo.Size = New System.Drawing.Size(112, 24)
        Me.CheckDispo.TabIndex = 25
        Me.CheckDispo.Text = "Disponible"
        Me.CheckDispo.UseVisualStyleBackColor = True
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(430, 129)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(52, 13)
        Me.LinkLabel2.TabIndex = 26
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "allocine.fr"
        '
        'GBNavig
        '
        Me.GBNavig.Controls.Add(Me.LblGenre2)
        Me.GBNavig.Controls.Add(Me.CBGenreNavig)
        Me.GBNavig.Location = New System.Drawing.Point(433, 591)
        Me.GBNavig.Name = "GBNavig"
        Me.GBNavig.Size = New System.Drawing.Size(222, 49)
        Me.GBNavig.TabIndex = 27
        Me.GBNavig.TabStop = False
        Me.GBNavig.Text = "Navigation"
        '
        'LblGenre2
        '
        Me.LblGenre2.AutoSize = True
        Me.LblGenre2.Location = New System.Drawing.Point(36, 21)
        Me.LblGenre2.Name = "LblGenre2"
        Me.LblGenre2.Size = New System.Drawing.Size(42, 13)
        Me.LblGenre2.TabIndex = 3
        Me.LblGenre2.Text = "Genre :"
        '
        'CBGenreNavig
        '
        Me.CBGenreNavig.FormattingEnabled = True
        Me.CBGenreNavig.Location = New System.Drawing.Point(84, 18)
        Me.CBGenreNavig.Name = "CBGenreNavig"
        Me.CBGenreNavig.Size = New System.Drawing.Size(121, 21)
        Me.CBGenreNavig.TabIndex = 2
        '
        'lblCpt
        '
        Me.lblCpt.AutoSize = True
        Me.lblCpt.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCpt.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblCpt.Location = New System.Drawing.Point(207, 588)
        Me.lblCpt.Name = "lblCpt"
        Me.lblCpt.Size = New System.Drawing.Size(33, 19)
        Me.lblCpt.TabIndex = 29
        Me.lblCpt.Text = "cpt"
        '
        'PB_Support
        '
        Me.PB_Support.Location = New System.Drawing.Point(433, 12)
        Me.PB_Support.Name = "PB_Support"
        Me.PB_Support.Size = New System.Drawing.Size(212, 60)
        Me.PB_Support.TabIndex = 30
        Me.PB_Support.TabStop = False
        '
        'BtnSearch
        '
        Me.BtnSearch.BackgroundImage = Global.GestionMedias.My.Resources.Resources.xmag
        Me.BtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSearch.Location = New System.Drawing.Point(762, 12)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(60, 60)
        Me.BtnSearch.TabIndex = 28
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.BackgroundImage = Global.GestionMedias.My.Resources.Resources.printerOne
        Me.BtnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPrint.Enabled = False
        Me.BtnPrint.FlatAppearance.BorderSize = 0
        Me.BtnPrint.Location = New System.Drawing.Point(340, 12)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(60, 60)
        Me.BtnPrint.TabIndex = 4
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.BackgroundImage = Global.GestionMedias.My.Resources.Resources.edit_add
        Me.BtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnAdd.Enabled = False
        Me.BtnAdd.FlatAppearance.BorderSize = 0
        Me.BtnAdd.Location = New System.Drawing.Point(47, 12)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(60, 60)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.BackgroundImage = Global.GestionMedias.My.Resources.Resources.reload
        Me.BtnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnCancel.Enabled = False
        Me.BtnCancel.FlatAppearance.BorderSize = 0
        Me.BtnCancel.Location = New System.Drawing.Point(227, 12)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(60, 60)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.BackgroundImage = Global.GestionMedias.My.Resources.Resources.edit_remove
        Me.BtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnDelete.Enabled = False
        Me.BtnDelete.FlatAppearance.BorderSize = 0
        Me.BtnDelete.Location = New System.Drawing.Point(107, 12)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(60, 60)
        Me.BtnDelete.TabIndex = 1
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.BackgroundImage = Global.GestionMedias.My.Resources.Resources.savepetit
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.Location = New System.Drawing.Point(167, 12)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(60, 60)
        Me.BtnSave.TabIndex = 2
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'PBJaquette
        '
        Me.PBJaquette.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PBJaquette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBJaquette.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PBJaquette.ImageLocation = ""
        Me.PBJaquette.Location = New System.Drawing.Point(47, 90)
        Me.PBJaquette.Name = "PBJaquette"
        Me.PBJaquette.Size = New System.Drawing.Size(353, 495)
        Me.PBJaquette.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBJaquette.TabIndex = 0
        Me.PBJaquette.TabStop = False
        '
        'CBSupport
        '
        Me.CBSupport.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBSupport.FormattingEnabled = True
        Me.CBSupport.Items.AddRange(New Object() {"DVD", "Divx", "Blue-Ray"})
        Me.CBSupport.Location = New System.Drawing.Point(546, 281)
        Me.CBSupport.Name = "CBSupport"
        Me.CBSupport.Size = New System.Drawing.Size(99, 24)
        Me.CBSupport.TabIndex = 31
        '
        'LblSupport
        '
        Me.LblSupport.AutoSize = True
        Me.LblSupport.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSupport.Location = New System.Drawing.Point(430, 284)
        Me.LblSupport.Name = "LblSupport"
        Me.LblSupport.Size = New System.Drawing.Size(62, 16)
        Me.LblSupport.TabIndex = 32
        Me.LblSupport.Text = "Support :"
        '
        'FilmBindingSource
        '
        Me.FilmBindingSource.DataSource = GetType(LibModele.Film)
        '
        'FormFilms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(905, 785)
        Me.Controls.Add(Me.LblSupport)
        Me.Controls.Add(Me.CBSupport)
        Me.Controls.Add(Me.PB_Support)
        Me.Controls.Add(Me.lblCpt)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.GBNavig)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.CheckDispo)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TBdureeM)
        Me.Controls.Add(Me.RtbResume)
        Me.Controls.Add(Me.TBTitre)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DTPSortie)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.CBGenre)
        Me.Controls.Add(Me.LblActeurs)
        Me.Controls.Add(Me.LblRealisateur)
        Me.Controls.Add(Me.LblGenre)
        Me.Controls.Add(Me.LblDuree)
        Me.Controls.Add(Me.LblSortie)
        Me.Controls.Add(Me.TBacteurs)
        Me.Controls.Add(Me.TBrealisateur)
        Me.Controls.Add(Me.TBdureeH)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.PBJaquette)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFilms"
        Me.Text = "FormFilms"
        Me.Panel1.ResumeLayout(False)
        Me.GBNavig.ResumeLayout(False)
        Me.GBNavig.PerformLayout()
        CType(Me.PB_Support, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBJaquette, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FilmBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PBJaquette As System.Windows.Forms.PictureBox
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnPrec As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnDernier As System.Windows.Forms.Button
    Friend WithEvents BtnSuiv As System.Windows.Forms.Button
    Friend WithEvents BtnPremier As System.Windows.Forms.Button
    Friend WithEvents TBdureeH As System.Windows.Forms.TextBox
    Friend WithEvents TBrealisateur As System.Windows.Forms.TextBox
    Friend WithEvents TBacteurs As System.Windows.Forms.TextBox
    Friend WithEvents LblSortie As System.Windows.Forms.Label
    Friend WithEvents LblDuree As System.Windows.Forms.Label
    Friend WithEvents LblGenre As System.Windows.Forms.Label
    Friend WithEvents LblRealisateur As System.Windows.Forms.Label
    Friend WithEvents LblActeurs As System.Windows.Forms.Label
    Friend WithEvents CBGenre As System.Windows.Forms.ComboBox
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents DTPSortie As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TBTitre As System.Windows.Forms.TextBox
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents RichTextBoxPrintCtrl1 As ExtendedRichTextBox.RichTextBoxPrintCtrl
    Friend WithEvents RtbResume As ExtendedRichTextBox.RichTextBoxPrintCtrl
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents FilmBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TBdureeM As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents CheckDispo As System.Windows.Forms.CheckBox
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents GBNavig As System.Windows.Forms.GroupBox
    Friend WithEvents CBGenreNavig As System.Windows.Forms.ComboBox
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents lblCpt As System.Windows.Forms.Label
    Friend WithEvents PB_Support As System.Windows.Forms.PictureBox
    Friend WithEvents CBSupport As System.Windows.Forms.ComboBox
    Friend WithEvents LblSupport As System.Windows.Forms.Label
    Friend WithEvents LblGenre2 As System.Windows.Forms.Label
End Class
