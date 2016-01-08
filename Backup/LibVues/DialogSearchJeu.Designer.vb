<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogSearchJeu
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
        Me.TBSearch = New System.Windows.Forms.TextBox
        Me.LblTitre = New System.Windows.Forms.Label
        Me.CBMachine = New System.Windows.Forms.ComboBox
        Me.CBGenre = New System.Windows.Forms.ComboBox
        Me.LblMachine = New System.Windows.Forms.Label
        Me.LblGenre = New System.Windows.Forms.Label
        Me.BtnValider = New System.Windows.Forms.Button
        Me.BtnAnnuler = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.TBAnnee2 = New System.Windows.Forms.MaskedTextBox
        Me.TBAnnee1 = New System.Windows.Forms.MaskedTextBox
        Me.LblAnnee2 = New System.Windows.Forms.Label
        Me.LblAnnee1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TBSearch
        '
        Me.TBSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBSearch.Location = New System.Drawing.Point(66, 15)
        Me.TBSearch.Name = "TBSearch"
        Me.TBSearch.Size = New System.Drawing.Size(185, 26)
        Me.TBSearch.TabIndex = 0
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
        'CBMachine
        '
        Me.CBMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBMachine.FormattingEnabled = True
        Me.CBMachine.Location = New System.Drawing.Point(16, 35)
        Me.CBMachine.Name = "CBMachine"
        Me.CBMachine.Size = New System.Drawing.Size(121, 24)
        Me.CBMachine.TabIndex = 1
        '
        'CBGenre
        '
        Me.CBGenre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBGenre.FormattingEnabled = True
        Me.CBGenre.Location = New System.Drawing.Point(16, 88)
        Me.CBGenre.Name = "CBGenre"
        Me.CBGenre.Size = New System.Drawing.Size(121, 24)
        Me.CBGenre.TabIndex = 2
        '
        'LblMachine
        '
        Me.LblMachine.AutoSize = True
        Me.LblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMachine.Location = New System.Drawing.Point(13, 13)
        Me.LblMachine.Name = "LblMachine"
        Me.LblMachine.Size = New System.Drawing.Size(65, 16)
        Me.LblMachine.TabIndex = 4
        Me.LblMachine.Text = "Machine :"
        '
        'LblGenre
        '
        Me.LblGenre.AutoSize = True
        Me.LblGenre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGenre.Location = New System.Drawing.Point(13, 69)
        Me.LblGenre.Name = "LblGenre"
        Me.LblGenre.Size = New System.Drawing.Size(51, 16)
        Me.LblGenre.TabIndex = 5
        Me.LblGenre.Text = "Genre :"
        '
        'BtnValider
        '
        Me.BtnValider.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnValider.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnValider.Location = New System.Drawing.Point(49, 243)
        Me.BtnValider.Name = "BtnValider"
        Me.BtnValider.Size = New System.Drawing.Size(121, 32)
        Me.BtnValider.TabIndex = 6
        Me.BtnValider.Text = "&Valider"
        Me.BtnValider.UseVisualStyleBackColor = True
        '
        'BtnAnnuler
        '
        Me.BtnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnAnnuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAnnuler.Location = New System.Drawing.Point(193, 243)
        Me.BtnAnnuler.Name = "BtnAnnuler"
        Me.BtnAnnuler.Size = New System.Drawing.Size(121, 32)
        Me.BtnAnnuler.TabIndex = 7
        Me.BtnAnnuler.Text = "&Annuler"
        Me.BtnAnnuler.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.LblTitre)
        Me.Panel1.Controls.Add(Me.TBSearch)
        Me.Panel1.Location = New System.Drawing.Point(30, 14)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(303, 60)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.LblMachine)
        Me.Panel2.Controls.Add(Me.CBMachine)
        Me.Panel2.Controls.Add(Me.CBGenre)
        Me.Panel2.Controls.Add(Me.LblGenre)
        Me.Panel2.Location = New System.Drawing.Point(30, 80)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(158, 135)
        Me.Panel2.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.TBAnnee2)
        Me.Panel3.Controls.Add(Me.TBAnnee1)
        Me.Panel3.Controls.Add(Me.LblAnnee2)
        Me.Panel3.Controls.Add(Me.LblAnnee1)
        Me.Panel3.Location = New System.Drawing.Point(194, 80)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(139, 135)
        Me.Panel3.TabIndex = 3
        '
        'TBAnnee2
        '
        Me.TBAnnee2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBAnnee2.Location = New System.Drawing.Point(20, 90)
        Me.TBAnnee2.Mask = "9999"
        Me.TBAnnee2.Name = "TBAnnee2"
        Me.TBAnnee2.Size = New System.Drawing.Size(99, 22)
        Me.TBAnnee2.TabIndex = 2
        '
        'TBAnnee1
        '
        Me.TBAnnee1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBAnnee1.Location = New System.Drawing.Point(20, 35)
        Me.TBAnnee1.Mask = "9999"
        Me.TBAnnee1.Name = "TBAnnee1"
        Me.TBAnnee1.Size = New System.Drawing.Size(99, 22)
        Me.TBAnnee1.TabIndex = 1
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
        'DialogSearchJeu
        '
        Me.AcceptButton = Me.BtnValider
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.CancelButton = Me.BtnAnnuler
        Me.ClientSize = New System.Drawing.Size(362, 295)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnAnnuler)
        Me.Controls.Add(Me.BtnValider)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogSearchJeu"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Rechercher un jeu"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TBSearch As System.Windows.Forms.TextBox
    Friend WithEvents LblTitre As System.Windows.Forms.Label
    Friend WithEvents CBMachine As System.Windows.Forms.ComboBox
    Friend WithEvents CBGenre As System.Windows.Forms.ComboBox
    Friend WithEvents LblMachine As System.Windows.Forms.Label
    Friend WithEvents LblGenre As System.Windows.Forms.Label
    Friend WithEvents BtnValider As System.Windows.Forms.Button
    Friend WithEvents BtnAnnuler As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LblAnnee2 As System.Windows.Forms.Label
    Friend WithEvents LblAnnee1 As System.Windows.Forms.Label
    Friend WithEvents TBAnnee2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TBAnnee1 As System.Windows.Forms.MaskedTextBox
End Class
