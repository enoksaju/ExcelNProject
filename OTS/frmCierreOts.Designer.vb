<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCierreOts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCierreOts))
        Me.MovimientosOT1 = New TRYINTELISISSELECTCTL.MovimientosOT()
        Me.SuspendLayout()
        '
        'MovimientosOT1
        '
        Me.MovimientosOT1.Location = New System.Drawing.Point(5, 5)
        Me.MovimientosOT1.Name = "MovimientosOT1"
        Me.MovimientosOT1.Size = New System.Drawing.Size(625, 390)
        Me.MovimientosOT1.TabIndex = 0
        '
        'frmCierreOts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(635, 400)
        Me.Controls.Add(Me.MovimientosOT1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCierreOts"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.Text = "Cierre de Ordenes"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MovimientosOT1 As TRYINTELISISSELECTCTL.MovimientosOT
End Class
