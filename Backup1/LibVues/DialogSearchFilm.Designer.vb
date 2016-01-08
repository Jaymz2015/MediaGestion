<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogSearchFilm
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
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.TBAnnee2 = New System.Windows.Forms.MaskedTextBox
        Me.TBAnnee1 = New System.Windows.Forms.MaskedTextBox
        Me.LblAnnee2 = New System.Windows.Forms.Label
        Me.LblAnnee1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.CBGenre2 = New System.Windows.Forms.ComboBox
        Me.LblGenre2 = New System.Windows.Forms.Label
        Me.CBGenre1 = New System.Windows.Forms.ComboBox
        Me.LblGenre1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTitre = New System.Windows.Forms.Label
        Me.TBSearch = New System.Windows.Forms.TextBox
        Me.BtnAnnuler = New System.Windows.Forms.Button
        Me.BtnValider = New System.Windows.Forms.Button
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.LblMmax = New System.Windows.Forms.Label
        Me.TBMmax = New System.Windows.Forms.TextBox
        Me.TBHmax = New System.Windows.Forms.TextBox
        Me.LblHmax = New System.Windows.Forms.Label
        Me.LblMmin = New System.Windows.Forms.Label
        Me.TBMmin = New System.Windows.Forms.TextBox
        Me.TBHmin = New System.Windows.Forms.TextBox
        Me.LblHmin = New System.Windows.Forms.Label
        Me.LblDureeMax = New System.Windows.Forms.Label
        Me.LblDureeMin = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.TBRealisateur = New System.Windows.Forms.TextBox
        Me.LblRealisateur = New System.Windows.Forms.Label
        Me.TBActeur = New System.Windows.Forms.TextBox
        Me.LblActeur = New System.Windows.Forms.Label
        Me.PanelSupport = New System.Windows.Forms.Panel
        Me.CBSupport = New System.Windows.Forms.ComboBox
        Me.LblSupport = New System.Windows.Forms.Label
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.CBProprietaire = New System.Windows.Forms.ComboBox
        Me.LblProprietaire = New System.Windows.Forms.Label
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.PanelSupport.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.TBAnnee2)
        Me.Panel3.Controls.Add(Me.TBAnnee1)
        Me.Panel3.Controls.Add(Me.LblAnnee2)
        Me.Panel3.Controls.Add(Me.LblAnnee1)
        Me.Panel3.Location = New System.Drawing.Point(206, 78)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(137, 133)
        Me.Panel3.TabIndex = 2
        '
        'TBAnnee2
        '
        Me.TBAnnee2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBAnnee2.Location = New System.Drawing.Point(20, 90)
        Me.TBAnnee2.Mask = "9999"
        Me.TBAnnee2.Name = "TBAnnee2"
        Me.TBAnnee2.Size = New System.Drawing.Size(99, 22)
        Me.TBAnnee2.TabIndex = 1
        '
        'TBAnnee1
        '
        Me.TBAnnee1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBAnnee1.Location = New System.Drawing.Point(20, 34)
        Me.TBAnnee1.Mask = "9999"
        Me.TBAnnee1.Name = "TBAnnee1"
        Me.TBAnnee1.Size = New System.Drawing.Size(99, 22)
        Me.TBAnnee1.TabIndex = 0
        '
        'LblAnnee2
        '
        Me.LblAnnee2.AutoSize = True
        Me.LblAnnee2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAnnee2.Location = New System.Drawing.Point(17, 71)
        Me.LblAnnee2.Name = "LblAnnee2"
        Me.LblAnnee2.Size = New System.Drawing.Size(28, 16)
        Me.LblAnnee2.TabIndex = 3
        Me.LblAnnee2.Text = "et..."
        '
        'LblAnnee1
        '
        Me.LblAnnee1.AutoSize = True
        Me.LblAnnee1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAnnee1.Location = New System.Drawing.Point(17, 13)
        Me.LblAnnee1.Name = "LblAnnee1"
        Me.LblAnnee1.Size = New System.Drawing.Size(75, 16)
        Me.LblAnnee1.TabIndex = 2
        Me.LblAnnee1.Text = "sorti entre..."
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.CBGenre2)
        Me.Panel2.Controls.Add(Me.LblGenre2)
        Me.Panel2.Controls.Add(Me.CBGenre1)
        Me.Panel2.Controls.Add(Me.LblGenre1)
        Me.Panel2.Location = New System.Drawing.Point(28, 78)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(172, 133)
        Me.Panel2.TabIndex = 1
        '
        'CBGenre2
        '
        Me.CBGenre2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBGenre2.FormattingEnabled = True
        Me.CBGenre2.Location = New System.Drawing.Point(16, 90)
        Me.CBGenre2.Name = "CBGenre2"
        Me.CBGenre2.Size = New System.Drawing.Size(140, 24)
        Me.CBGenre2.TabIndex = 1
        '
        'LblGenre2
        '
        Me.LblGenre2.AutoSize = True
        Me.LblGenre2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGenre2.Location = New System.Drawing.Point(13, 71)
        Me.LblGenre2.Name = "LblGenre2"
        Me.LblGenre2.Size = New System.Drawing.Size(61, 16)
        Me.LblGenre2.TabIndex = 7
        Me.LblGenre2.Text = "Genre 2 :"
        '
        'CBGenre1
        '
        Me.CBGenre1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBGenre1.FormattingEnabled = True
        Me.CBGenre1.Location = New System.Drawing.Point(16, 34)
        Me.CBGenre1.Name = "CBGenre1"
        Me.CBGenre1.Size = New System.Drawing.Size(140, 24)
        Me.CBGenre1.TabIndex = 0
        '
        'LblGenre1
        '
        Me.LblGenre1.AutoSize = True
        Me.LblGenre1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGenre1.Location = New System.Drawing.Point(13, 15)
        Me.LblGenre1.Name = "LblGenre1"
        Me.LblGenre1.Size = New System.Drawing.Size(61, 16)
        Me.LblGenre1.TabIndex = 5
        Me.LblGenre1.Text = "Genre 1 :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.LblTitre)
        Me.Panel1.Controls.Add(Me.TBSearch)
        Me.Panel1.Location = New System.Drawing.Point(28, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(315, 60)
        Me.Panel1.TabIndex = 0
        '
        'LblTitre
        '
        Me.LblTitre.AutoSize = True
        Me.LblTitre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitre.Location = New System.Drawing.Point(12, 18)
        Me.LblTitre.Name = "LblTitre"
        Me.LblTitre.Size = New System.Drawing.Size(48, 20)
        Me.LblTitre.TabIndex = 1
        Me.LblTitre.Text = "Titre :"
        '
        'TBSearch
        '
        Me.TBSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBSearch.Location = New System.Drawing.Point(66, 15)
        Me.TBSearch.Name = "TBSearch"
        Me.TBSearch.Size = New System.Drawing.Size(185, 26)
        Me.TBSearch.TabIndex = 0
        '
        'BtnAnnuler
        '
        Me.BtnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnAnnuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAnnuler.Location = New System.Drawing.Point(206, 510)
        Me.BtnAnnuler.Name = "BtnAnnuler"
        Me.BtnAnnuler.Size = New System.Drawing.Size(121, 32)
        Me.BtnAnnuler.TabIndex = 12
        Me.BtnAnnuler.Text = "&Annuler"
        Me.BtnAnnuler.UseVisualStyleBackColor = True
        '
        'BtnValider
        '
        Me.BtnValider.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnValider.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnValider.Location = New System.Drawing.Point(43, 510)
        Me.BtnValider.Name = "BtnValider"
        Me.BtnValider.Size = New System.Drawing.Size(121, 32)
        Me.BtnValider.TabIndex = 11
        Me.BtnValider.Text = "&Valider"
        Me.BtnValider.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.LblMmax)
        Me.Panel4.Controls.Add(Me.TBMmax)
        Me.Panel4.Controls.Add(Me.TBHmax)
        Me.Panel4.Controls.Add(Me.LblHmax)
        Me.Panel4.Controls.Add(Me.LblMmin)
        Me.Panel4.Controls.Add(Me.TBMmin)
        Me.Panel4.Controls.Add(Me.TBHmin)
        Me.Panel4.Controls.Add(Me.LblHmin)
        Me.Panel4.Controls.Add(Me.LblDureeMax)
        Me.Panel4.Controls.Add(Me.LblDureeMin)
        Me.Panel4.Location = New System.Drawing.Point(28, 267)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(315, 73)
        Me.Panel4.TabIndex = 3
        '
        'LblMmax
        '
        Me.LblMmax.AutoSize = True
        Me.LblMmax.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMmax.Location = New System.Drawing.Point(280, 34)
        Me.LblMmax.Name = "LblMmax"
        Me.LblMmax.Size = New System.Drawing.Size(26, 16)
        Me.LblMmax.TabIndex = 17
        Me.LblMmax.Text = "mn"
        '
        'TBMmax
        '
        Me.TBMmax.Location = New System.Drawing.Point(240, 33)
        Me.TBMmax.Name = "TBMmax"
        Me.TBMmax.Size = New System.Drawing.Size(34, 20)
        Me.TBMmax.TabIndex = 3
        Me.TBMmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TBHmax
        '
        Me.TBHmax.Location = New System.Drawing.Point(179, 33)
        Me.TBHmax.Name = "TBHmax"
        Me.TBHmax.Size = New System.Drawing.Size(34, 20)
        Me.TBHmax.TabIndex = 2
        Me.TBHmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblHmax
        '
        Me.LblHmax.AutoSize = True
        Me.LblHmax.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHmax.Location = New System.Drawing.Point(219, 34)
        Me.LblHmax.Name = "LblHmax"
        Me.LblHmax.Size = New System.Drawing.Size(15, 16)
        Me.LblHmax.TabIndex = 14
        Me.LblHmax.Text = "h"
        '
        'LblMmin
        '
        Me.LblMmin.AutoSize = True
        Me.LblMmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMmin.Location = New System.Drawing.Point(108, 34)
        Me.LblMmin.Name = "LblMmin"
        Me.LblMmin.Size = New System.Drawing.Size(26, 16)
        Me.LblMmin.TabIndex = 13
        Me.LblMmin.Text = "mn"
        '
        'TBMmin
        '
        Me.TBMmin.Location = New System.Drawing.Point(77, 33)
        Me.TBMmin.Name = "TBMmin"
        Me.TBMmin.Size = New System.Drawing.Size(34, 20)
        Me.TBMmin.TabIndex = 1
        Me.TBMmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TBHmin
        '
        Me.TBHmin.Location = New System.Drawing.Point(16, 33)
        Me.TBHmin.Name = "TBHmin"
        Me.TBHmin.Size = New System.Drawing.Size(34, 20)
        Me.TBHmin.TabIndex = 0
        Me.TBHmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblHmin
        '
        Me.LblHmin.AutoSize = True
        Me.LblHmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHmin.Location = New System.Drawing.Point(56, 34)
        Me.LblHmin.Name = "LblHmin"
        Me.LblHmin.Size = New System.Drawing.Size(15, 16)
        Me.LblHmin.TabIndex = 10
        Me.LblHmin.Text = "h"
        '
        'LblDureeMax
        '
        Me.LblDureeMax.AutoSize = True
        Me.LblDureeMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDureeMax.Location = New System.Drawing.Point(176, 14)
        Me.LblDureeMax.Name = "LblDureeMax"
        Me.LblDureeMax.Size = New System.Drawing.Size(79, 16)
        Me.LblDureeMax.TabIndex = 9
        Me.LblDureeMax.Text = "Durée max :"
        '
        'LblDureeMin
        '
        Me.LblDureeMin.AutoSize = True
        Me.LblDureeMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDureeMin.Location = New System.Drawing.Point(13, 14)
        Me.LblDureeMin.Name = "LblDureeMin"
        Me.LblDureeMin.Size = New System.Drawing.Size(75, 16)
        Me.LblDureeMin.TabIndex = 8
        Me.LblDureeMin.Text = "Durée min :"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.Add(Me.TBRealisateur)
        Me.Panel5.Controls.Add(Me.LblRealisateur)
        Me.Panel5.Controls.Add(Me.TBActeur)
        Me.Panel5.Controls.Add(Me.LblActeur)
        Me.Panel5.Location = New System.Drawing.Point(28, 346)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(315, 86)
        Me.Panel5.TabIndex = 4
        '
        'TBRealisateur
        '
        Me.TBRealisateur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBRealisateur.Location = New System.Drawing.Point(102, 12)
        Me.TBRealisateur.Name = "TBRealisateur"
        Me.TBRealisateur.Size = New System.Drawing.Size(195, 22)
        Me.TBRealisateur.TabIndex = 1
        '
        'LblRealisateur
        '
        Me.LblRealisateur.AutoSize = True
        Me.LblRealisateur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRealisateur.Location = New System.Drawing.Point(13, 15)
        Me.LblRealisateur.Name = "LblRealisateur"
        Me.LblRealisateur.Size = New System.Drawing.Size(83, 16)
        Me.LblRealisateur.TabIndex = 10
        Me.LblRealisateur.Text = "Réalisateur :"
        '
        'TBActeur
        '
        Me.TBActeur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBActeur.Location = New System.Drawing.Point(102, 44)
        Me.TBActeur.Name = "TBActeur"
        Me.TBActeur.Size = New System.Drawing.Size(195, 22)
        Me.TBActeur.TabIndex = 0
        '
        'LblActeur
        '
        Me.LblActeur.AutoSize = True
        Me.LblActeur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblActeur.Location = New System.Drawing.Point(13, 47)
        Me.LblActeur.Name = "LblActeur"
        Me.LblActeur.Size = New System.Drawing.Size(52, 16)
        Me.LblActeur.TabIndex = 8
        Me.LblActeur.Text = "Acteur :"
        '
        'PanelSupport
        '
        Me.PanelSupport.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.PanelSupport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelSupport.Controls.Add(Me.CBSupport)
        Me.PanelSupport.Controls.Add(Me.LblSupport)
        Me.PanelSupport.Location = New System.Drawing.Point(28, 217)
        Me.PanelSupport.Name = "PanelSupport"
        Me.PanelSupport.Size = New System.Drawing.Size(315, 44)
        Me.PanelSupport.TabIndex = 13
        '
        'CBSupport
        '
        Me.CBSupport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBSupport.FormattingEnabled = True
        Me.CBSupport.Items.AddRange(New Object() {"DVD", "DivX", "BRay", "TNT", "TNTH"})
        Me.CBSupport.Location = New System.Drawing.Point(80, 10)
        Me.CBSupport.Name = "CBSupport"
        Me.CBSupport.Size = New System.Drawing.Size(121, 24)
        Me.CBSupport.TabIndex = 7
        '
        'LblSupport
        '
        Me.LblSupport.AutoSize = True
        Me.LblSupport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSupport.Location = New System.Drawing.Point(13, 13)
        Me.LblSupport.Name = "LblSupport"
        Me.LblSupport.Size = New System.Drawing.Size(61, 16)
        Me.LblSupport.TabIndex = 6
        Me.LblSupport.Text = "Support :"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel6.Controls.Add(Me.CBProprietaire)
        Me.Panel6.Controls.Add(Me.LblProprietaire)
        Me.Panel6.Location = New System.Drawing.Point(28, 438)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(315, 55)
        Me.Panel6.TabIndex = 14
        '
        'CBProprietaire
        '
        Me.CBProprietaire.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBProprietaire.FormattingEnabled = True
        Me.CBProprietaire.Location = New System.Drawing.Point(102, 12)
        Me.CBProprietaire.Name = "CBProprietaire"
        Me.CBProprietaire.Size = New System.Drawing.Size(195, 24)
        Me.CBProprietaire.TabIndex = 8
        '
        'LblProprietaire
        '
        Me.LblProprietaire.AutoSize = True
        Me.LblProprietaire.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProprietaire.Location = New System.Drawing.Point(13, 15)
        Me.LblProprietaire.Name = "LblProprietaire"
        Me.LblProprietaire.Size = New System.Drawing.Size(84, 16)
        Me.LblProprietaire.TabIndex = 10
        Me.LblProprietaire.Text = "Propriétaire :"
        '
        'DialogSearchFilm
        '
        Me.AcceptButton = Me.BtnValider
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.CancelButton = Me.BtnAnnuler
        Me.ClientSize = New System.Drawing.Size(371, 548)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.PanelSupport)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnAnnuler)
        Me.Controls.Add(Me.BtnValider)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogSearchFilm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Rechercher un film"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.PanelSupport.ResumeLayout(False)
        Me.PanelSupport.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TBAnnee2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TBAnnee1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents LblAnnee2 As System.Windows.Forms.Label
    Friend WithEvents LblAnnee1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents CBGenre1 As System.Windows.Forms.ComboBox
    Friend WithEvents LblGenre1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LblTitre As System.Windows.Forms.Label
    Friend WithEvents TBSearch As System.Windows.Forms.TextBox
    Friend WithEvents BtnAnnuler As System.Windows.Forms.Button
    Friend WithEvents BtnValider As System.Windows.Forms.Button
    Friend WithEvents CBGenre2 As System.Windows.Forms.ComboBox
    Friend WithEvents LblGenre2 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents LblMmax As System.Windows.Forms.Label
    Friend WithEvents TBMmax As System.Windows.Forms.TextBox
    Friend WithEvents TBHmax As System.Windows.Forms.TextBox
    Friend WithEvents LblHmax As System.Windows.Forms.Label
    Friend WithEvents LblMmin As System.Windows.Forms.Label
    Friend WithEvents TBMmin As System.Windows.Forms.TextBox
    Friend WithEvents TBHmin As System.Windows.Forms.TextBox
    Friend WithEvents LblHmin As System.Windows.Forms.Label
    Friend WithEvents LblDureeMax As System.Windows.Forms.Label
    Friend WithEvents LblDureeMin As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents TBRealisateur As System.Windows.Forms.TextBox
    Friend WithEvents LblRealisateur As System.Windows.Forms.Label
    Friend WithEvents TBActeur As System.Windows.Forms.TextBox
    Friend WithEvents LblActeur As System.Windows.Forms.Label
    Friend WithEvents PanelSupport As System.Windows.Forms.Panel
    Friend WithEvents CBSupport As System.Windows.Forms.ComboBox
    Friend WithEvents LblSupport As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents LblProprietaire As System.Windows.Forms.Label
    Friend WithEvents CBProprietaire As System.Windows.Forms.ComboBox
End Class
