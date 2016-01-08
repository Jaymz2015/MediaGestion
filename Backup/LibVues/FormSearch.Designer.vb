<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSearch
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
        Me.DGVListeFiches = New System.Windows.Forms.DataGridView
        Me.LblResult = New System.Windows.Forms.Label
        Me.BtnShow = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        CType(Me.DGVListeFiches, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGVListeFiches
        '
        Me.DGVListeFiches.AllowUserToAddRows = False
        Me.DGVListeFiches.AllowUserToDeleteRows = False
        Me.DGVListeFiches.AllowUserToResizeColumns = False
        Me.DGVListeFiches.AllowUserToResizeRows = False
        Me.DGVListeFiches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVListeFiches.Location = New System.Drawing.Point(23, 41)
        Me.DGVListeFiches.MultiSelect = False
        Me.DGVListeFiches.Name = "DGVListeFiches"
        Me.DGVListeFiches.ReadOnly = True
        Me.DGVListeFiches.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.DGVListeFiches.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DGVListeFiches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVListeFiches.Size = New System.Drawing.Size(592, 290)
        Me.DGVListeFiches.TabIndex = 0
        '
        'LblResult
        '
        Me.LblResult.AutoSize = True
        Me.LblResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblResult.Location = New System.Drawing.Point(20, 9)
        Me.LblResult.Name = "LblResult"
        Me.LblResult.Size = New System.Drawing.Size(159, 16)
        Me.LblResult.TabIndex = 1
        Me.LblResult.Text = "Résultat de la recherche :"
        '
        'BtnShow
        '
        Me.BtnShow.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnShow.Location = New System.Drawing.Point(190, 347)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(114, 32)
        Me.BtnShow.TabIndex = 2
        Me.BtnShow.Text = "&Afficher"
        Me.BtnShow.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(335, 347)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(114, 32)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "A&nnuler"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'FormSearch
        '
        Me.AcceptButton = Me.BtnShow
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(638, 400)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnShow)
        Me.Controls.Add(Me.LblResult)
        Me.Controls.Add(Me.DGVListeFiches)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSearch"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Recherche"
        CType(Me.DGVListeFiches, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGVListeFiches As System.Windows.Forms.DataGridView
    Friend WithEvents LblResult As System.Windows.Forms.Label
    Friend WithEvents BtnShow As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
End Class
