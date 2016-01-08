<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogPret
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
        Me.txtNom = New System.Windows.Forms.TextBox
        Me.lblTitre = New System.Windows.Forms.Label
        Me.lblNom = New System.Windows.Forms.Label
        Me.DtpPrete = New System.Windows.Forms.DateTimePicker
        Me.lblDateEmprunt = New System.Windows.Forms.Label
        Me.lblDateRendu = New System.Windows.Forms.Label
        Me.DtpRendu = New System.Windows.Forms.DateTimePicker
        Me.lblTitre2 = New System.Windows.Forms.Label
        Me.BtnValider = New System.Windows.Forms.Button
        Me.BtnAnnuler = New System.Windows.Forms.Button
        Me.lblPrenom = New System.Windows.Forms.Label
        Me.txtPrenom = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNom
        '
        Me.txtNom.Location = New System.Drawing.Point(90, 55)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(148, 20)
        Me.txtNom.TabIndex = 3
        '
        'lblTitre
        '
        Me.lblTitre.AutoSize = True
        Me.lblTitre.Location = New System.Drawing.Point(15, 11)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Size = New System.Drawing.Size(34, 13)
        Me.lblTitre.TabIndex = 0
        Me.lblTitre.Text = "Titre :"
        '
        'lblNom
        '
        Me.lblNom.AutoSize = True
        Me.lblNom.Location = New System.Drawing.Point(12, 58)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(35, 13)
        Me.lblNom.TabIndex = 2
        Me.lblNom.Text = "Nom :"
        '
        'DtpPrete
        '
        Me.DtpPrete.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpPrete.Location = New System.Drawing.Point(90, 116)
        Me.DtpPrete.Name = "DtpPrete"
        Me.DtpPrete.Size = New System.Drawing.Size(103, 20)
        Me.DtpPrete.TabIndex = 7
        '
        'lblDateEmprunt
        '
        Me.lblDateEmprunt.AutoSize = True
        Me.lblDateEmprunt.Location = New System.Drawing.Point(12, 120)
        Me.lblDateEmprunt.Name = "lblDateEmprunt"
        Me.lblDateEmprunt.Size = New System.Drawing.Size(69, 13)
        Me.lblDateEmprunt.TabIndex = 6
        Me.lblDateEmprunt.Text = "Emprunté le :"
        '
        'lblDateRendu
        '
        Me.lblDateRendu.AutoSize = True
        Me.lblDateRendu.Location = New System.Drawing.Point(12, 152)
        Me.lblDateRendu.Name = "lblDateRendu"
        Me.lblDateRendu.Size = New System.Drawing.Size(56, 13)
        Me.lblDateRendu.TabIndex = 8
        Me.lblDateRendu.Text = "Rendu le :"
        '
        'DtpRendu
        '
        Me.DtpRendu.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpRendu.Location = New System.Drawing.Point(90, 148)
        Me.DtpRendu.Name = "DtpRendu"
        Me.DtpRendu.Size = New System.Drawing.Size(103, 20)
        Me.DtpRendu.TabIndex = 9
        '
        'lblTitre2
        '
        Me.lblTitre2.AutoSize = True
        Me.lblTitre2.Location = New System.Drawing.Point(90, 11)
        Me.lblTitre2.Name = "lblTitre2"
        Me.lblTitre2.Size = New System.Drawing.Size(28, 13)
        Me.lblTitre2.TabIndex = 1
        Me.lblTitre2.Text = "Titre"
        '
        'BtnValider
        '
        Me.BtnValider.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnValider.Location = New System.Drawing.Point(43, 13)
        Me.BtnValider.Name = "BtnValider"
        Me.BtnValider.Size = New System.Drawing.Size(75, 23)
        Me.BtnValider.TabIndex = 10
        Me.BtnValider.Text = "Valider"
        Me.BtnValider.UseVisualStyleBackColor = True
        '
        'BtnAnnuler
        '
        Me.BtnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnAnnuler.Location = New System.Drawing.Point(155, 13)
        Me.BtnAnnuler.Name = "BtnAnnuler"
        Me.BtnAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.BtnAnnuler.TabIndex = 11
        Me.BtnAnnuler.Text = "Annuler"
        Me.BtnAnnuler.UseVisualStyleBackColor = True
        '
        'lblPrenom
        '
        Me.lblPrenom.AutoSize = True
        Me.lblPrenom.Location = New System.Drawing.Point(12, 89)
        Me.lblPrenom.Name = "lblPrenom"
        Me.lblPrenom.Size = New System.Drawing.Size(49, 13)
        Me.lblPrenom.TabIndex = 4
        Me.lblPrenom.Text = "Prénom :"
        '
        'txtPrenom
        '
        Me.txtPrenom.Location = New System.Drawing.Point(90, 86)
        Me.txtPrenom.Name = "txtPrenom"
        Me.txtPrenom.Size = New System.Drawing.Size(148, 20)
        Me.txtPrenom.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel1.Controls.Add(Me.lblTitre)
        Me.Panel1.Controls.Add(Me.lblTitre2)
        Me.Panel1.Location = New System.Drawing.Point(-3, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(270, 35)
        Me.Panel1.TabIndex = 12
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel2.Controls.Add(Me.BtnValider)
        Me.Panel2.Controls.Add(Me.BtnAnnuler)
        Me.Panel2.Location = New System.Drawing.Point(-3, 187)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(270, 49)
        Me.Panel2.TabIndex = 13
        '
        'DialogPret
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(264, 235)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtPrenom)
        Me.Controls.Add(Me.lblPrenom)
        Me.Controls.Add(Me.DtpRendu)
        Me.Controls.Add(Me.lblDateRendu)
        Me.Controls.Add(Me.lblDateEmprunt)
        Me.Controls.Add(Me.DtpPrete)
        Me.Controls.Add(Me.lblNom)
        Me.Controls.Add(Me.txtNom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogPret"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prêt"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNom As System.Windows.Forms.TextBox
    Friend WithEvents lblTitre As System.Windows.Forms.Label
    Friend WithEvents lblNom As System.Windows.Forms.Label
    Friend WithEvents DtpPrete As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDateEmprunt As System.Windows.Forms.Label
    Friend WithEvents lblDateRendu As System.Windows.Forms.Label
    Friend WithEvents DtpRendu As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTitre2 As System.Windows.Forms.Label
    Friend WithEvents BtnValider As System.Windows.Forms.Button
    Friend WithEvents BtnAnnuler As System.Windows.Forms.Button
    Friend WithEvents lblPrenom As System.Windows.Forms.Label
    Friend WithEvents txtPrenom As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
