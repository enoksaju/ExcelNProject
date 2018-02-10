Imports ComponentFactory.Krypton.Toolkit

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits KryptonForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.KryptonManager1 = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonRibbon1 = New ComponentFactory.Krypton.Ribbon.KryptonRibbon()
        CType(Me.KryptonRibbon1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonManager1
        '
        Me.KryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2013
        '
        'KryptonRibbon1
        '
        Me.KryptonRibbon1.InDesignHelperMode = True
        Me.KryptonRibbon1.Name = "KryptonRibbon1"
        Me.KryptonRibbon1.SelectedTab = Nothing
        Me.KryptonRibbon1.Size = New System.Drawing.Size(587, 117)
        Me.KryptonRibbon1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 425)
        Me.Controls.Add(Me.KryptonRibbon1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.KryptonRibbon1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonRibbon1 As ComponentFactory.Krypton.Ribbon.KryptonRibbon
    Private WithEvents KryptonManager1 As KryptonManager
End Class
