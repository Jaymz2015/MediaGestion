<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPrets
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
        Me.DGVPrets = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RBEnCours = New System.Windows.Forms.RadioButton
        Me.RBTout = New System.Windows.Forms.RadioButton
        CType(Me.DGVPrets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGVPrets
        '
        Me.DGVPrets.AllowUserToAddRows = False
        Me.DGVPrets.AllowUserToDeleteRows = False
        Me.DGVPrets.AllowUserToResizeColumns = False
        Me.DGVPrets.AllowUserToResizeRows = False
        Me.DGVPrets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVPrets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVPrets.Location = New System.Drawing.Point(27, 75)
        Me.DGVPrets.MultiSelect = False
        Me.DGVPrets.Name = "DGVPrets"
        Me.DGVPrets.ReadOnly = True
        Me.DGVPrets.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.DGVPrets.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DGVPrets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVPrets.Size = New System.Drawing.Size(641, 308)
        Me.DGVPrets.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.RBEnCours)
        Me.Panel1.Controls.Add(Me.RBTout)
        Me.Panel1.Location = New System.Drawing.Point(27, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(640, 33)
        Me.Panel1.TabIndex = 7
        '
        'RBEnCours
        '
        Me.RBEnCours.AutoSize = True
        Me.RBEnCours.Location = New System.Drawing.Point(14, 6)
        Me.RBEnCours.Name = "RBEnCours"
        Me.RBEnCours.Size = New System.Drawing.Size(93, 17)
        Me.RBEnCours.TabIndex = 1
        Me.RBEnCours.Text = "Prêts en cours"
        Me.RBEnCours.UseVisualStyleBackColor = True
        '
        'RBTout
        '
        Me.RBTout.AutoSize = True
        Me.RBTout.Checked = True
        Me.RBTout.Location = New System.Drawing.Point(131, 6)
        Me.RBTout.Name = "RBTout"
        Me.RBTout.Size = New System.Drawing.Size(47, 17)
        Me.RBTout.TabIndex = 0
        Me.RBTout.TabStop = True
        Me.RBTout.Text = "Tout"
        Me.RBTout.UseVisualStyleBackColor = True
        '
        'FormPrets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(819, 645)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DGVPrets)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPrets"
        Me.Text = "FormPrets"
        CType(Me.DGVPrets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGVPrets As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RBEnCours As System.Windows.Forms.RadioButton
    Friend WithEvents RBTout As System.Windows.Forms.RadioButton
End Class
