<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExistencias
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExistencias))
        Me.CtlExistencias1 = New TRYINTELISISSELECTCTL.ctlExistencias()
        Me.SuspendLayout()
        '
        'CtlExistencias1
        '
        Me.CtlExistencias1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtlExistencias1.Location = New System.Drawing.Point(0, 0)
        Me.CtlExistencias1.Name = "CtlExistencias1"
        Me.CtlExistencias1.Size = New System.Drawing.Size(739, 453)
        Me.CtlExistencias1.TabIndex = 0
        '
        'frmExistencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 453)
        Me.Controls.Add(Me.CtlExistencias1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmExistencias"
        Me.Text = "Existencias"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CtlExistencias1 As TRYINTELISISSELECTCTL.ctlExistencias
End Class
