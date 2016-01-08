<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogFicheProprietaire
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.LblNom = New System.Windows.Forms.Label
        Me.TxtNom = New System.Windows.Forms.TextBox
        Me.LblPrenom = New System.Windows.Forms.Label
        Me.TxtPrenom = New System.Windows.Forms.TextBox
        Me.LblAdresse = New System.Windows.Forms.Label
        Me.TxtAdresse = New System.Windows.Forms.TextBox
        Me.LblCP = New System.Windows.Forms.Label
        Me.TxtVille = New System.Windows.Forms.TextBox
        Me.LblVille = New System.Windows.Forms.Label
        Me.CBProprietairePrincipal = New System.Windows.Forms.CheckBox
        Me.TxtCP = New System.Windows.Forms.MaskedTextBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(92, 223)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.BackColor = System.Drawing.SystemColors.Control
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 7
        Me.OK_Button.Text = "OK"
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 8
        Me.Cancel_Button.Text = "Annuler"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'LblNom
        '
        Me.LblNom.AutoSize = True
        Me.LblNom.Location = New System.Drawing.Point(13, 13)
        Me.LblNom.Name = "LblNom"
        Me.LblNom.Size = New System.Drawing.Size(35, 13)
        Me.LblNom.TabIndex = 11
        Me.LblNom.Text = "Nom :"
        '
        'TxtNom
        '
        Me.TxtNom.Location = New System.Drawing.Point(95, 10)
        Me.TxtNom.Name = "TxtNom"
        Me.TxtNom.Size = New System.Drawing.Size(174, 20)
        Me.TxtNom.TabIndex = 1
        '
        'LblPrenom
        '
        Me.LblPrenom.AutoSize = True
        Me.LblPrenom.Location = New System.Drawing.Point(13, 41)
        Me.LblPrenom.Name = "LblPrenom"
        Me.LblPrenom.Size = New System.Drawing.Size(49, 13)
        Me.LblPrenom.TabIndex = 12
        Me.LblPrenom.Text = "Prénom :"
        '
        'TxtPrenom
        '
        Me.TxtPrenom.Location = New System.Drawing.Point(95, 38)
        Me.TxtPrenom.Name = "TxtPrenom"
        Me.TxtPrenom.Size = New System.Drawing.Size(174, 20)
        Me.TxtPrenom.TabIndex = 2
        '
        'LblAdresse
        '
        Me.LblAdresse.AutoSize = True
        Me.LblAdresse.Location = New System.Drawing.Point(13, 69)
        Me.LblAdresse.Name = "LblAdresse"
        Me.LblAdresse.Size = New System.Drawing.Size(51, 13)
        Me.LblAdresse.TabIndex = 13
        Me.LblAdresse.Text = "Adresse :"
        '
        'TxtAdresse
        '
        Me.TxtAdresse.Location = New System.Drawing.Point(95, 66)
        Me.TxtAdresse.Name = "TxtAdresse"
        Me.TxtAdresse.Size = New System.Drawing.Size(174, 20)
        Me.TxtAdresse.TabIndex = 3
        '
        'LblCP
        '
        Me.LblCP.AutoSize = True
        Me.LblCP.Location = New System.Drawing.Point(13, 97)
        Me.LblCP.Name = "LblCP"
        Me.LblCP.Size = New System.Drawing.Size(69, 13)
        Me.LblCP.TabIndex = 14
        Me.LblCP.Text = "Code postal :"
        '
        'TxtVille
        '
        Me.TxtVille.Location = New System.Drawing.Point(95, 122)
        Me.TxtVille.Name = "TxtVille"
        Me.TxtVille.Size = New System.Drawing.Size(174, 20)
        Me.TxtVille.TabIndex = 5
        '
        'LblVille
        '
        Me.LblVille.AutoSize = True
        Me.LblVille.Location = New System.Drawing.Point(13, 125)
        Me.LblVille.Name = "LblVille"
        Me.LblVille.Size = New System.Drawing.Size(32, 13)
        Me.LblVille.TabIndex = 15
        Me.LblVille.Text = "Ville :"
        '
        'CBProprietairePrincipal
        '
        Me.CBProprietairePrincipal.AutoSize = True
        Me.CBProprietairePrincipal.Location = New System.Drawing.Point(16, 159)
        Me.CBProprietairePrincipal.Name = "CBProprietairePrincipal"
        Me.CBProprietairePrincipal.Size = New System.Drawing.Size(121, 17)
        Me.CBProprietairePrincipal.TabIndex = 6
        Me.CBProprietairePrincipal.Text = "Propriétaire principal"
        Me.CBProprietairePrincipal.UseVisualStyleBackColor = True
        '
        'TxtCP
        '
        Me.TxtCP.Location = New System.Drawing.Point(95, 94)
        Me.TxtCP.Mask = "00000"
        Me.TxtCP.Name = "TxtCP"
        Me.TxtCP.Size = New System.Drawing.Size(51, 20)
        Me.TxtCP.TabIndex = 4
        '
        'DialogFicheProprietaire
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(330, 264)
        Me.Controls.Add(Me.TxtCP)
        Me.Controls.Add(Me.CBProprietairePrincipal)
        Me.Controls.Add(Me.TxtVille)
        Me.Controls.Add(Me.LblVille)
        Me.Controls.Add(Me.LblCP)
        Me.Controls.Add(Me.TxtAdresse)
        Me.Controls.Add(Me.LblAdresse)
        Me.Controls.Add(Me.TxtPrenom)
        Me.Controls.Add(Me.LblPrenom)
        Me.Controls.Add(Me.TxtNom)
        Me.Controls.Add(Me.LblNom)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogFicheProprietaire"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Enregistrement propriétaire"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents LblNom As System.Windows.Forms.Label
    Friend WithEvents TxtNom As System.Windows.Forms.TextBox
    Friend WithEvents LblPrenom As System.Windows.Forms.Label
    Friend WithEvents TxtPrenom As System.Windows.Forms.TextBox
    Friend WithEvents LblAdresse As System.Windows.Forms.Label
    Friend WithEvents TxtAdresse As System.Windows.Forms.TextBox
    Friend WithEvents LblCP As System.Windows.Forms.Label
    Friend WithEvents TxtVille As System.Windows.Forms.TextBox
    Friend WithEvents LblVille As System.Windows.Forms.Label
    Friend WithEvents CBProprietairePrincipal As System.Windows.Forms.CheckBox
    Friend WithEvents TxtCP As System.Windows.Forms.MaskedTextBox

End Class
