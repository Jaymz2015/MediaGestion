<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormJeux
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.PB_Machine = New System.Windows.Forms.PictureBox
        Me.lblCpt = New System.Windows.Forms.Label
        Me.BtnSearch = New System.Windows.Forms.Button
        Me.GBNavig = New System.Windows.Forms.GroupBox
        Me.LblGenre2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CBMachineNavig = New System.Windows.Forms.ComboBox
        Me.CBGenreNavig = New System.Windows.Forms.ComboBox
        Me.CheckDispo = New System.Windows.Forms.CheckBox
        Me.TBTitre = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnPrec = New System.Windows.Forms.Button
        Me.BtnDernier = New System.Windows.Forms.Button
        Me.BtnSuiv = New System.Windows.Forms.Button
        Me.BtnPremier = New System.Windows.Forms.Button
        Me.CBGenre = New System.Windows.Forms.ComboBox
        Me.LblRealisateur = New System.Windows.Forms.Label
        Me.LblGenre = New System.Windows.Forms.Label
        Me.LblSortie = New System.Windows.Forms.Label
        Me.TBediteur = New System.Windows.Forms.TextBox
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnDelete = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.PBPhoto = New System.Windows.Forms.PictureBox
        Me.CBMachine = New System.Windows.Forms.ComboBox
        Me.LblMachine = New System.Windows.Forms.Label
        Me.LblEtatBoitier = New System.Windows.Forms.Label
        Me.LblEtatLivret = New System.Windows.Forms.Label
        Me.LblEtatJeu = New System.Windows.Forms.Label
        Me.GBEtat = New System.Windows.Forms.GroupBox
        Me.PanelEtatBoitier = New System.Windows.Forms.Panel
        Me.RBBoitierAbsent = New System.Windows.Forms.RadioButton
        Me.RBBoitierExcellent = New System.Windows.Forms.RadioButton
        Me.RBBoitierMoyen = New System.Windows.Forms.RadioButton
        Me.RBBoitierBon = New System.Windows.Forms.RadioButton
        Me.RBBoitierMauvais = New System.Windows.Forms.RadioButton
        Me.PanelEtatJeu = New System.Windows.Forms.Panel
        Me.RBJeuAbsent = New System.Windows.Forms.RadioButton
        Me.RBJeuBon = New System.Windows.Forms.RadioButton
        Me.RBJeuMoyen = New System.Windows.Forms.RadioButton
        Me.RBJeuMauvais = New System.Windows.Forms.RadioButton
        Me.RBJeuExcellent = New System.Windows.Forms.RadioButton
        Me.PanelEtatLivret = New System.Windows.Forms.Panel
        Me.RBLivretAbsent = New System.Windows.Forms.RadioButton
        Me.RBLivretExcellent = New System.Windows.Forms.RadioButton
        Me.RBLivretBon = New System.Windows.Forms.RadioButton
        Me.RBLivretMoyen = New System.Windows.Forms.RadioButton
        Me.RBLivretMauvais = New System.Windows.Forms.RadioButton
        Me.RBCopie = New System.Windows.Forms.RadioButton
        Me.RBOriginal = New System.Windows.Forms.RadioButton
        Me.GBSupport = New System.Windows.Forms.GroupBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnJeuxaAvoir = New System.Windows.Forms.Button
        Me.BtnJVC = New System.Windows.Forms.Button
        Me.TBSortie = New System.Windows.Forms.MaskedTextBox
        Me.LblDeveloppeur = New System.Windows.Forms.Label
        Me.TBDeveloppeur = New System.Windows.Forms.TextBox
        CType(Me.PB_Machine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBNavig.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PBPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBEtat.SuspendLayout()
        Me.PanelEtatBoitier.SuspendLayout()
        Me.PanelEtatJeu.SuspendLayout()
        Me.PanelEtatLivret.SuspendLayout()
        Me.GBSupport.SuspendLayout()
        Me.SuspendLayout()
        '
        'PB_Machine
        '
        Me.PB_Machine.Location = New System.Drawing.Point(432, 0)
        Me.PB_Machine.Name = "PB_Machine"
        Me.PB_Machine.Size = New System.Drawing.Size(300, 60)
        Me.PB_Machine.TabIndex = 59
        Me.PB_Machine.TabStop = False
        '
        'lblCpt
        '
        Me.lblCpt.AutoSize = True
        Me.lblCpt.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCpt.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblCpt.Location = New System.Drawing.Point(192, 624)
        Me.lblCpt.Name = "lblCpt"
        Me.lblCpt.Size = New System.Drawing.Size(33, 19)
        Me.lblCpt.TabIndex = 58
        Me.lblCpt.Text = "cpt"
        '
        'BtnSearch
        '
        Me.BtnSearch.BackgroundImage = Global.GestionMedias.My.Resources.Resources.xmag
        Me.BtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSearch.Location = New System.Drawing.Point(339, 0)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(60, 60)
        Me.BtnSearch.TabIndex = 57
        Me.BtnSearch.TabStop = False
        Me.ToolTip1.SetToolTip(Me.BtnSearch, "Rechercher un jeu")
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'GBNavig
        '
        Me.GBNavig.Controls.Add(Me.LblGenre2)
        Me.GBNavig.Controls.Add(Me.Label1)
        Me.GBNavig.Controls.Add(Me.CBMachineNavig)
        Me.GBNavig.Controls.Add(Me.CBGenreNavig)
        Me.GBNavig.Location = New System.Drawing.Point(432, 493)
        Me.GBNavig.Name = "GBNavig"
        Me.GBNavig.Size = New System.Drawing.Size(222, 93)
        Me.GBNavig.TabIndex = 8
        Me.GBNavig.TabStop = False
        Me.GBNavig.Text = "Navigation"
        '
        'LblGenre2
        '
        Me.LblGenre2.AutoSize = True
        Me.LblGenre2.Location = New System.Drawing.Point(25, 21)
        Me.LblGenre2.Name = "LblGenre2"
        Me.LblGenre2.Size = New System.Drawing.Size(42, 13)
        Me.LblGenre2.TabIndex = 0
        Me.LblGenre2.Text = "Genre :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Machine :"
        '
        'CBMachineNavig
        '
        Me.CBMachineNavig.FormattingEnabled = True
        Me.CBMachineNavig.Location = New System.Drawing.Point(85, 56)
        Me.CBMachineNavig.Name = "CBMachineNavig"
        Me.CBMachineNavig.Size = New System.Drawing.Size(121, 21)
        Me.CBMachineNavig.TabIndex = 3
        '
        'CBGenreNavig
        '
        Me.CBGenreNavig.FormattingEnabled = True
        Me.CBGenreNavig.Location = New System.Drawing.Point(85, 18)
        Me.CBGenreNavig.Name = "CBGenreNavig"
        Me.CBGenreNavig.Size = New System.Drawing.Size(121, 21)
        Me.CBGenreNavig.TabIndex = 1
        '
        'CheckDispo
        '
        Me.CheckDispo.AutoSize = True
        Me.CheckDispo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckDispo.Location = New System.Drawing.Point(724, 562)
        Me.CheckDispo.Name = "CheckDispo"
        Me.CheckDispo.Size = New System.Drawing.Size(112, 24)
        Me.CheckDispo.TabIndex = 9
        Me.CheckDispo.Text = "Disponible"
        Me.CheckDispo.UseVisualStyleBackColor = True
        '
        'TBTitre
        '
        Me.TBTitre.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBTitre.Location = New System.Drawing.Point(432, 91)
        Me.TBTitre.Name = "TBTitre"
        Me.TBTitre.Size = New System.Drawing.Size(404, 36)
        Me.TBTitre.TabIndex = 0
        Me.TBTitre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnPrec)
        Me.Panel1.Controls.Add(Me.BtnDernier)
        Me.Panel1.Controls.Add(Me.BtnSuiv)
        Me.Panel1.Controls.Add(Me.BtnPremier)
        Me.Panel1.Location = New System.Drawing.Point(108, 646)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(209, 57)
        Me.Panel1.TabIndex = 10
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
        Me.BtnPrec.TabStop = False
        Me.ToolTip1.SetToolTip(Me.BtnPrec, "fiche précédente")
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
        Me.BtnDernier.TabStop = False
        Me.ToolTip1.SetToolTip(Me.BtnDernier, "dernière fiche")
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
        Me.BtnSuiv.TabStop = False
        Me.ToolTip1.SetToolTip(Me.BtnSuiv, "fiche suivante")
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
        Me.BtnPremier.TabStop = False
        Me.ToolTip1.SetToolTip(Me.BtnPremier, "première fiche")
        Me.BtnPremier.UseVisualStyleBackColor = True
        '
        'CBGenre
        '
        Me.CBGenre.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBGenre.FormattingEnabled = True
        Me.CBGenre.Location = New System.Drawing.Point(545, 185)
        Me.CBGenre.Name = "CBGenre"
        Me.CBGenre.Size = New System.Drawing.Size(174, 24)
        Me.CBGenre.TabIndex = 3
        '
        'LblRealisateur
        '
        Me.LblRealisateur.AutoSize = True
        Me.LblRealisateur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRealisateur.Location = New System.Drawing.Point(429, 219)
        Me.LblRealisateur.Name = "LblRealisateur"
        Me.LblRealisateur.Size = New System.Drawing.Size(56, 16)
        Me.LblRealisateur.TabIndex = 44
        Me.LblRealisateur.Text = "Editeur :"
        '
        'LblGenre
        '
        Me.LblGenre.AutoSize = True
        Me.LblGenre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGenre.Location = New System.Drawing.Point(429, 188)
        Me.LblGenre.Name = "LblGenre"
        Me.LblGenre.Size = New System.Drawing.Size(51, 16)
        Me.LblGenre.TabIndex = 42
        Me.LblGenre.Text = "Genre :"
        '
        'LblSortie
        '
        Me.LblSortie.AutoSize = True
        Me.LblSortie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSortie.Location = New System.Drawing.Point(429, 159)
        Me.LblSortie.Name = "LblSortie"
        Me.LblSortie.Size = New System.Drawing.Size(89, 16)
        Me.LblSortie.TabIndex = 38
        Me.LblSortie.Text = "Année sortie :"
        '
        'TBediteur
        '
        Me.TBediteur.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBediteur.Location = New System.Drawing.Point(545, 216)
        Me.TBediteur.Name = "TBediteur"
        Me.TBediteur.Size = New System.Drawing.Size(174, 23)
        Me.TBediteur.TabIndex = 4
        '
        'BtnAdd
        '
        Me.BtnAdd.BackgroundImage = Global.GestionMedias.My.Resources.Resources.edit_add
        Me.BtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnAdd.Enabled = False
        Me.BtnAdd.FlatAppearance.BorderSize = 0
        Me.BtnAdd.Location = New System.Drawing.Point(25, 0)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(60, 60)
        Me.BtnAdd.TabIndex = 31
        Me.BtnAdd.TabStop = False
        Me.ToolTip1.SetToolTip(Me.BtnAdd, "Créer une nouvelle fiche")
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.BackgroundImage = Global.GestionMedias.My.Resources.Resources.reload
        Me.BtnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnCancel.Enabled = False
        Me.BtnCancel.FlatAppearance.BorderSize = 0
        Me.BtnCancel.Location = New System.Drawing.Point(205, 0)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(60, 60)
        Me.BtnCancel.TabIndex = 35
        Me.BtnCancel.TabStop = False
        Me.ToolTip1.SetToolTip(Me.BtnCancel, "Annuler")
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.BackgroundImage = Global.GestionMedias.My.Resources.Resources.edit_remove
        Me.BtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnDelete.Enabled = False
        Me.BtnDelete.FlatAppearance.BorderSize = 0
        Me.BtnDelete.Location = New System.Drawing.Point(85, 0)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(60, 60)
        Me.BtnDelete.TabIndex = 33
        Me.BtnDelete.TabStop = False
        Me.ToolTip1.SetToolTip(Me.BtnDelete, "Supprimer la fiche")
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.BackgroundImage = Global.GestionMedias.My.Resources.Resources.savepetit
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.Location = New System.Drawing.Point(145, 0)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(60, 60)
        Me.BtnSave.TabIndex = 34
        Me.BtnSave.TabStop = False
        Me.ToolTip1.SetToolTip(Me.BtnSave, "Enregistrer la fiche")
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'PBPhoto
        '
        Me.PBPhoto.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PBPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PBPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBPhoto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PBPhoto.ImageLocation = ""
        Me.PBPhoto.Location = New System.Drawing.Point(25, 91)
        Me.PBPhoto.Name = "PBPhoto"
        Me.PBPhoto.Size = New System.Drawing.Size(374, 531)
        Me.PBPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBPhoto.TabIndex = 32
        Me.PBPhoto.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PBPhoto, "Cliquer pour ajouter une image")
        '
        'CBMachine
        '
        Me.CBMachine.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBMachine.FormattingEnabled = True
        Me.CBMachine.Location = New System.Drawing.Point(545, 276)
        Me.CBMachine.Name = "CBMachine"
        Me.CBMachine.Size = New System.Drawing.Size(174, 24)
        Me.CBMachine.TabIndex = 5
        '
        'LblMachine
        '
        Me.LblMachine.AutoSize = True
        Me.LblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMachine.Location = New System.Drawing.Point(429, 279)
        Me.LblMachine.Name = "LblMachine"
        Me.LblMachine.Size = New System.Drawing.Size(65, 16)
        Me.LblMachine.TabIndex = 61
        Me.LblMachine.Text = "Machine :"
        '
        'LblEtatBoitier
        '
        Me.LblEtatBoitier.AutoSize = True
        Me.LblEtatBoitier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEtatBoitier.Location = New System.Drawing.Point(8, 28)
        Me.LblEtatBoitier.Name = "LblEtatBoitier"
        Me.LblEtatBoitier.Size = New System.Drawing.Size(51, 16)
        Me.LblEtatBoitier.TabIndex = 62
        Me.LblEtatBoitier.Text = "boitier :"
        '
        'LblEtatLivret
        '
        Me.LblEtatLivret.AutoSize = True
        Me.LblEtatLivret.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEtatLivret.Location = New System.Drawing.Point(8, 63)
        Me.LblEtatLivret.Name = "LblEtatLivret"
        Me.LblEtatLivret.Size = New System.Drawing.Size(42, 16)
        Me.LblEtatLivret.TabIndex = 63
        Me.LblEtatLivret.Text = "livret :"
        '
        'LblEtatJeu
        '
        Me.LblEtatJeu.AutoSize = True
        Me.LblEtatJeu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEtatJeu.Location = New System.Drawing.Point(10, 99)
        Me.LblEtatJeu.Name = "LblEtatJeu"
        Me.LblEtatJeu.Size = New System.Drawing.Size(32, 16)
        Me.LblEtatJeu.TabIndex = 64
        Me.LblEtatJeu.Text = "jeu :"
        '
        'GBEtat
        '
        Me.GBEtat.Controls.Add(Me.PanelEtatBoitier)
        Me.GBEtat.Controls.Add(Me.PanelEtatJeu)
        Me.GBEtat.Controls.Add(Me.PanelEtatLivret)
        Me.GBEtat.Controls.Add(Me.LblEtatJeu)
        Me.GBEtat.Controls.Add(Me.LblEtatLivret)
        Me.GBEtat.Controls.Add(Me.LblEtatBoitier)
        Me.GBEtat.Location = New System.Drawing.Point(432, 349)
        Me.GBEtat.Name = "GBEtat"
        Me.GBEtat.Size = New System.Drawing.Size(404, 138)
        Me.GBEtat.TabIndex = 7
        Me.GBEtat.TabStop = False
        Me.GBEtat.Text = "Etat"
        '
        'PanelEtatBoitier
        '
        Me.PanelEtatBoitier.Controls.Add(Me.RBBoitierAbsent)
        Me.PanelEtatBoitier.Controls.Add(Me.RBBoitierExcellent)
        Me.PanelEtatBoitier.Controls.Add(Me.RBBoitierMoyen)
        Me.PanelEtatBoitier.Controls.Add(Me.RBBoitierBon)
        Me.PanelEtatBoitier.Controls.Add(Me.RBBoitierMauvais)
        Me.PanelEtatBoitier.Location = New System.Drawing.Point(65, 21)
        Me.PanelEtatBoitier.Name = "PanelEtatBoitier"
        Me.PanelEtatBoitier.Size = New System.Drawing.Size(327, 24)
        Me.PanelEtatBoitier.TabIndex = 0
        '
        'RBBoitierAbsent
        '
        Me.RBBoitierAbsent.AutoSize = True
        Me.RBBoitierAbsent.Checked = True
        Me.RBBoitierAbsent.Location = New System.Drawing.Point(10, 5)
        Me.RBBoitierAbsent.Name = "RBBoitierAbsent"
        Me.RBBoitierAbsent.Size = New System.Drawing.Size(57, 17)
        Me.RBBoitierAbsent.TabIndex = 0
        Me.RBBoitierAbsent.TabStop = True
        Me.RBBoitierAbsent.Tag = "0"
        Me.RBBoitierAbsent.Text = "absent"
        Me.RBBoitierAbsent.UseVisualStyleBackColor = True
        '
        'RBBoitierExcellent
        '
        Me.RBBoitierExcellent.AutoSize = True
        Me.RBBoitierExcellent.Location = New System.Drawing.Point(254, 5)
        Me.RBBoitierExcellent.Name = "RBBoitierExcellent"
        Me.RBBoitierExcellent.Size = New System.Drawing.Size(67, 17)
        Me.RBBoitierExcellent.TabIndex = 4
        Me.RBBoitierExcellent.TabStop = True
        Me.RBBoitierExcellent.Tag = "5"
        Me.RBBoitierExcellent.Text = "excellent"
        Me.RBBoitierExcellent.UseVisualStyleBackColor = True
        '
        'RBBoitierMoyen
        '
        Me.RBBoitierMoyen.AutoSize = True
        Me.RBBoitierMoyen.Location = New System.Drawing.Point(143, 5)
        Me.RBBoitierMoyen.Name = "RBBoitierMoyen"
        Me.RBBoitierMoyen.Size = New System.Drawing.Size(56, 17)
        Me.RBBoitierMoyen.TabIndex = 2
        Me.RBBoitierMoyen.TabStop = True
        Me.RBBoitierMoyen.Tag = "3"
        Me.RBBoitierMoyen.Text = "moyen"
        Me.RBBoitierMoyen.UseVisualStyleBackColor = True
        '
        'RBBoitierBon
        '
        Me.RBBoitierBon.AutoSize = True
        Me.RBBoitierBon.Location = New System.Drawing.Point(205, 5)
        Me.RBBoitierBon.Name = "RBBoitierBon"
        Me.RBBoitierBon.Size = New System.Drawing.Size(43, 17)
        Me.RBBoitierBon.TabIndex = 3
        Me.RBBoitierBon.TabStop = True
        Me.RBBoitierBon.Tag = "4"
        Me.RBBoitierBon.Text = "bon"
        Me.RBBoitierBon.UseVisualStyleBackColor = True
        '
        'RBBoitierMauvais
        '
        Me.RBBoitierMauvais.AutoSize = True
        Me.RBBoitierMauvais.Location = New System.Drawing.Point(73, 5)
        Me.RBBoitierMauvais.Name = "RBBoitierMauvais"
        Me.RBBoitierMauvais.Size = New System.Drawing.Size(64, 17)
        Me.RBBoitierMauvais.TabIndex = 1
        Me.RBBoitierMauvais.TabStop = True
        Me.RBBoitierMauvais.Tag = "2"
        Me.RBBoitierMauvais.Text = "mauvais"
        Me.RBBoitierMauvais.UseVisualStyleBackColor = True
        '
        'PanelEtatJeu
        '
        Me.PanelEtatJeu.Controls.Add(Me.RBJeuAbsent)
        Me.PanelEtatJeu.Controls.Add(Me.RBJeuBon)
        Me.PanelEtatJeu.Controls.Add(Me.RBJeuMoyen)
        Me.PanelEtatJeu.Controls.Add(Me.RBJeuMauvais)
        Me.PanelEtatJeu.Controls.Add(Me.RBJeuExcellent)
        Me.PanelEtatJeu.Location = New System.Drawing.Point(65, 96)
        Me.PanelEtatJeu.Name = "PanelEtatJeu"
        Me.PanelEtatJeu.Size = New System.Drawing.Size(327, 27)
        Me.PanelEtatJeu.TabIndex = 1
        '
        'RBJeuAbsent
        '
        Me.RBJeuAbsent.AutoSize = True
        Me.RBJeuAbsent.Checked = True
        Me.RBJeuAbsent.Location = New System.Drawing.Point(10, 3)
        Me.RBJeuAbsent.Name = "RBJeuAbsent"
        Me.RBJeuAbsent.Size = New System.Drawing.Size(57, 17)
        Me.RBJeuAbsent.TabIndex = 0
        Me.RBJeuAbsent.TabStop = True
        Me.RBJeuAbsent.Tag = "0"
        Me.RBJeuAbsent.Text = "absent"
        Me.RBJeuAbsent.UseVisualStyleBackColor = True
        '
        'RBJeuBon
        '
        Me.RBJeuBon.AutoSize = True
        Me.RBJeuBon.Location = New System.Drawing.Point(205, 3)
        Me.RBJeuBon.Name = "RBJeuBon"
        Me.RBJeuBon.Size = New System.Drawing.Size(43, 17)
        Me.RBJeuBon.TabIndex = 3
        Me.RBJeuBon.TabStop = True
        Me.RBJeuBon.Tag = "4"
        Me.RBJeuBon.Text = "bon"
        Me.RBJeuBon.UseVisualStyleBackColor = True
        '
        'RBJeuMoyen
        '
        Me.RBJeuMoyen.AutoSize = True
        Me.RBJeuMoyen.Location = New System.Drawing.Point(143, 3)
        Me.RBJeuMoyen.Name = "RBJeuMoyen"
        Me.RBJeuMoyen.Size = New System.Drawing.Size(56, 17)
        Me.RBJeuMoyen.TabIndex = 2
        Me.RBJeuMoyen.TabStop = True
        Me.RBJeuMoyen.Tag = "3"
        Me.RBJeuMoyen.Text = "moyen"
        Me.RBJeuMoyen.UseVisualStyleBackColor = True
        '
        'RBJeuMauvais
        '
        Me.RBJeuMauvais.AutoSize = True
        Me.RBJeuMauvais.Location = New System.Drawing.Point(73, 3)
        Me.RBJeuMauvais.Name = "RBJeuMauvais"
        Me.RBJeuMauvais.Size = New System.Drawing.Size(64, 17)
        Me.RBJeuMauvais.TabIndex = 1
        Me.RBJeuMauvais.TabStop = True
        Me.RBJeuMauvais.Tag = "2"
        Me.RBJeuMauvais.Text = "mauvais"
        Me.RBJeuMauvais.UseVisualStyleBackColor = True
        '
        'RBJeuExcellent
        '
        Me.RBJeuExcellent.AutoSize = True
        Me.RBJeuExcellent.Location = New System.Drawing.Point(254, 3)
        Me.RBJeuExcellent.Name = "RBJeuExcellent"
        Me.RBJeuExcellent.Size = New System.Drawing.Size(67, 17)
        Me.RBJeuExcellent.TabIndex = 4
        Me.RBJeuExcellent.TabStop = True
        Me.RBJeuExcellent.Tag = "5"
        Me.RBJeuExcellent.Text = "excellent"
        Me.RBJeuExcellent.UseVisualStyleBackColor = True
        '
        'PanelEtatLivret
        '
        Me.PanelEtatLivret.Controls.Add(Me.RBLivretAbsent)
        Me.PanelEtatLivret.Controls.Add(Me.RBLivretExcellent)
        Me.PanelEtatLivret.Controls.Add(Me.RBLivretBon)
        Me.PanelEtatLivret.Controls.Add(Me.RBLivretMoyen)
        Me.PanelEtatLivret.Controls.Add(Me.RBLivretMauvais)
        Me.PanelEtatLivret.Location = New System.Drawing.Point(65, 58)
        Me.PanelEtatLivret.Name = "PanelEtatLivret"
        Me.PanelEtatLivret.Size = New System.Drawing.Size(327, 28)
        Me.PanelEtatLivret.TabIndex = 0
        '
        'RBLivretAbsent
        '
        Me.RBLivretAbsent.AutoSize = True
        Me.RBLivretAbsent.Checked = True
        Me.RBLivretAbsent.Location = New System.Drawing.Point(10, 5)
        Me.RBLivretAbsent.Name = "RBLivretAbsent"
        Me.RBLivretAbsent.Size = New System.Drawing.Size(57, 17)
        Me.RBLivretAbsent.TabIndex = 0
        Me.RBLivretAbsent.TabStop = True
        Me.RBLivretAbsent.Tag = "0"
        Me.RBLivretAbsent.Text = "absent"
        Me.RBLivretAbsent.UseVisualStyleBackColor = True
        '
        'RBLivretExcellent
        '
        Me.RBLivretExcellent.AutoSize = True
        Me.RBLivretExcellent.Location = New System.Drawing.Point(254, 5)
        Me.RBLivretExcellent.Name = "RBLivretExcellent"
        Me.RBLivretExcellent.Size = New System.Drawing.Size(67, 17)
        Me.RBLivretExcellent.TabIndex = 4
        Me.RBLivretExcellent.TabStop = True
        Me.RBLivretExcellent.Tag = "5"
        Me.RBLivretExcellent.Text = "excellent"
        Me.RBLivretExcellent.UseVisualStyleBackColor = True
        '
        'RBLivretBon
        '
        Me.RBLivretBon.AutoSize = True
        Me.RBLivretBon.Location = New System.Drawing.Point(205, 5)
        Me.RBLivretBon.Name = "RBLivretBon"
        Me.RBLivretBon.Size = New System.Drawing.Size(43, 17)
        Me.RBLivretBon.TabIndex = 3
        Me.RBLivretBon.TabStop = True
        Me.RBLivretBon.Tag = "4"
        Me.RBLivretBon.Text = "bon"
        Me.RBLivretBon.UseVisualStyleBackColor = True
        '
        'RBLivretMoyen
        '
        Me.RBLivretMoyen.AutoSize = True
        Me.RBLivretMoyen.Location = New System.Drawing.Point(143, 5)
        Me.RBLivretMoyen.Name = "RBLivretMoyen"
        Me.RBLivretMoyen.Size = New System.Drawing.Size(56, 17)
        Me.RBLivretMoyen.TabIndex = 2
        Me.RBLivretMoyen.TabStop = True
        Me.RBLivretMoyen.Tag = "3"
        Me.RBLivretMoyen.Text = "moyen"
        Me.RBLivretMoyen.UseVisualStyleBackColor = True
        '
        'RBLivretMauvais
        '
        Me.RBLivretMauvais.AutoSize = True
        Me.RBLivretMauvais.Location = New System.Drawing.Point(73, 5)
        Me.RBLivretMauvais.Name = "RBLivretMauvais"
        Me.RBLivretMauvais.Size = New System.Drawing.Size(64, 17)
        Me.RBLivretMauvais.TabIndex = 1
        Me.RBLivretMauvais.TabStop = True
        Me.RBLivretMauvais.Tag = "2"
        Me.RBLivretMauvais.Text = "mauvais"
        Me.RBLivretMauvais.UseVisualStyleBackColor = True
        '
        'RBCopie
        '
        Me.RBCopie.AutoSize = True
        Me.RBCopie.Location = New System.Drawing.Point(133, 10)
        Me.RBCopie.Name = "RBCopie"
        Me.RBCopie.Size = New System.Drawing.Size(51, 17)
        Me.RBCopie.TabIndex = 1
        Me.RBCopie.Text = "copie"
        Me.RBCopie.UseVisualStyleBackColor = True
        '
        'RBOriginal
        '
        Me.RBOriginal.AutoSize = True
        Me.RBOriginal.Checked = True
        Me.RBOriginal.Location = New System.Drawing.Point(28, 10)
        Me.RBOriginal.Name = "RBOriginal"
        Me.RBOriginal.Size = New System.Drawing.Size(58, 17)
        Me.RBOriginal.TabIndex = 0
        Me.RBOriginal.TabStop = True
        Me.RBOriginal.Text = "original"
        Me.RBOriginal.UseVisualStyleBackColor = True
        '
        'GBSupport
        '
        Me.GBSupport.Controls.Add(Me.RBOriginal)
        Me.GBSupport.Controls.Add(Me.RBCopie)
        Me.GBSupport.Location = New System.Drawing.Point(432, 310)
        Me.GBSupport.Name = "GBSupport"
        Me.GBSupport.Size = New System.Drawing.Size(212, 33)
        Me.GBSupport.TabIndex = 6
        Me.GBSupport.TabStop = False
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'BtnJeuxaAvoir
        '
        Me.BtnJeuxaAvoir.BackgroundImage = Global.GestionMedias.My.Resources.Resources.acheter
        Me.BtnJeuxaAvoir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnJeuxaAvoir.Location = New System.Drawing.Point(279, 0)
        Me.BtnJeuxaAvoir.Name = "BtnJeuxaAvoir"
        Me.BtnJeuxaAvoir.Size = New System.Drawing.Size(60, 60)
        Me.BtnJeuxaAvoir.TabIndex = 80
        Me.BtnJeuxaAvoir.TabStop = False
        Me.ToolTip1.SetToolTip(Me.BtnJeuxaAvoir, "Rechercher un jeu")
        Me.BtnJeuxaAvoir.UseVisualStyleBackColor = True
        '
        'BtnJVC
        '
        Me.BtnJVC.BackgroundImage = Global.GestionMedias.My.Resources.Resources.jeuxvideo1
        Me.BtnJVC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnJVC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnJVC.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.BtnJVC.Location = New System.Drawing.Point(776, 0)
        Me.BtnJVC.Name = "BtnJVC"
        Me.BtnJVC.Size = New System.Drawing.Size(60, 60)
        Me.BtnJVC.TabIndex = 81
        Me.BtnJVC.TabStop = False
        Me.ToolTip1.SetToolTip(Me.BtnJVC, "Rechercher un jeu sur jeuxvideo.com")
        Me.BtnJVC.UseVisualStyleBackColor = True
        '
        'TBSortie
        '
        Me.TBSortie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBSortie.Location = New System.Drawing.Point(545, 156)
        Me.TBSortie.Mask = "0000"
        Me.TBSortie.Name = "TBSortie"
        Me.TBSortie.Size = New System.Drawing.Size(58, 22)
        Me.TBSortie.TabIndex = 2
        '
        'LblDeveloppeur
        '
        Me.LblDeveloppeur.AutoSize = True
        Me.LblDeveloppeur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDeveloppeur.Location = New System.Drawing.Point(429, 249)
        Me.LblDeveloppeur.Name = "LblDeveloppeur"
        Me.LblDeveloppeur.Size = New System.Drawing.Size(93, 16)
        Me.LblDeveloppeur.TabIndex = 79
        Me.LblDeveloppeur.Text = "Développeur :"
        '
        'TBDeveloppeur
        '
        Me.TBDeveloppeur.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBDeveloppeur.Location = New System.Drawing.Point(545, 246)
        Me.TBDeveloppeur.Name = "TBDeveloppeur"
        Me.TBDeveloppeur.Size = New System.Drawing.Size(174, 23)
        Me.TBDeveloppeur.TabIndex = 78
        '
        'FormJeux
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(877, 780)
        Me.Controls.Add(Me.BtnJVC)
        Me.Controls.Add(Me.BtnJeuxaAvoir)
        Me.Controls.Add(Me.LblDeveloppeur)
        Me.Controls.Add(Me.TBDeveloppeur)
        Me.Controls.Add(Me.TBSortie)
        Me.Controls.Add(Me.GBSupport)
        Me.Controls.Add(Me.GBEtat)
        Me.Controls.Add(Me.LblMachine)
        Me.Controls.Add(Me.CBMachine)
        Me.Controls.Add(Me.PB_Machine)
        Me.Controls.Add(Me.lblCpt)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.GBNavig)
        Me.Controls.Add(Me.CheckDispo)
        Me.Controls.Add(Me.TBTitre)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CBGenre)
        Me.Controls.Add(Me.LblRealisateur)
        Me.Controls.Add(Me.LblGenre)
        Me.Controls.Add(Me.LblSortie)
        Me.Controls.Add(Me.TBediteur)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.PBPhoto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormJeux"
        Me.Text = "FormJeux"
        CType(Me.PB_Machine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBNavig.ResumeLayout(False)
        Me.GBNavig.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PBPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBEtat.ResumeLayout(False)
        Me.GBEtat.PerformLayout()
        Me.PanelEtatBoitier.ResumeLayout(False)
        Me.PanelEtatBoitier.PerformLayout()
        Me.PanelEtatJeu.ResumeLayout(False)
        Me.PanelEtatJeu.PerformLayout()
        Me.PanelEtatLivret.ResumeLayout(False)
        Me.PanelEtatLivret.PerformLayout()
        Me.GBSupport.ResumeLayout(False)
        Me.GBSupport.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PB_Machine As System.Windows.Forms.PictureBox
    Friend WithEvents lblCpt As System.Windows.Forms.Label
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents GBNavig As System.Windows.Forms.GroupBox
    Friend WithEvents CBGenreNavig As System.Windows.Forms.ComboBox
    Friend WithEvents CheckDispo As System.Windows.Forms.CheckBox
    Friend WithEvents TBTitre As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnPrec As System.Windows.Forms.Button
    Friend WithEvents BtnDernier As System.Windows.Forms.Button
    Friend WithEvents BtnSuiv As System.Windows.Forms.Button
    Friend WithEvents BtnPremier As System.Windows.Forms.Button
    Friend WithEvents CBGenre As System.Windows.Forms.ComboBox
    Friend WithEvents LblRealisateur As System.Windows.Forms.Label
    Friend WithEvents LblGenre As System.Windows.Forms.Label
    Friend WithEvents LblSortie As System.Windows.Forms.Label
    Friend WithEvents TBediteur As System.Windows.Forms.TextBox
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents PBPhoto As System.Windows.Forms.PictureBox
    Friend WithEvents CBMachine As System.Windows.Forms.ComboBox
    Friend WithEvents LblMachine As System.Windows.Forms.Label
    Friend WithEvents LblEtatBoitier As System.Windows.Forms.Label
    Friend WithEvents LblEtatLivret As System.Windows.Forms.Label
    Friend WithEvents LblEtatJeu As System.Windows.Forms.Label
    Friend WithEvents GBEtat As System.Windows.Forms.GroupBox
    Friend WithEvents RBCopie As System.Windows.Forms.RadioButton
    Friend WithEvents RBOriginal As System.Windows.Forms.RadioButton
    Friend WithEvents GBSupport As System.Windows.Forms.GroupBox
    Friend WithEvents RBJeuBon As System.Windows.Forms.RadioButton
    Friend WithEvents RBJeuMoyen As System.Windows.Forms.RadioButton
    Friend WithEvents RBJeuMauvais As System.Windows.Forms.RadioButton
    Friend WithEvents RBJeuExcellent As System.Windows.Forms.RadioButton
    Friend WithEvents RBLivretExcellent As System.Windows.Forms.RadioButton
    Friend WithEvents RBLivretBon As System.Windows.Forms.RadioButton
    Friend WithEvents RBLivretMoyen As System.Windows.Forms.RadioButton
    Friend WithEvents RBLivretMauvais As System.Windows.Forms.RadioButton
    Friend WithEvents RBJeuAbsent As System.Windows.Forms.RadioButton
    Friend WithEvents RBLivretAbsent As System.Windows.Forms.RadioButton
    Friend WithEvents PanelEtatJeu As System.Windows.Forms.Panel
    Friend WithEvents PanelEtatLivret As System.Windows.Forms.Panel
    Friend WithEvents PanelEtatBoitier As System.Windows.Forms.Panel
    Friend WithEvents RBBoitierAbsent As System.Windows.Forms.RadioButton
    Friend WithEvents RBBoitierExcellent As System.Windows.Forms.RadioButton
    Friend WithEvents RBBoitierMoyen As System.Windows.Forms.RadioButton
    Friend WithEvents RBBoitierBon As System.Windows.Forms.RadioButton
    Friend WithEvents RBBoitierMauvais As System.Windows.Forms.RadioButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TBSortie As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBMachineNavig As System.Windows.Forms.ComboBox
    Friend WithEvents LblGenre2 As System.Windows.Forms.Label
    Friend WithEvents LblDeveloppeur As System.Windows.Forms.Label
    Friend WithEvents TBDeveloppeur As System.Windows.Forms.TextBox
    Friend WithEvents BtnJeuxaAvoir As System.Windows.Forms.Button
    Friend WithEvents BtnJVC As System.Windows.Forms.Button
End Class
