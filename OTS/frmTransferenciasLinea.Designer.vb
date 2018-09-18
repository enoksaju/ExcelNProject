<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferenciasLinea
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransferenciasLinea))
        Me.CtlMoviminetosFechaLinea1 = New TRYINTELISISSELECTCTL.ctlMoviminetosFechaLinea()
        Me.SuspendLayout()
        '
        'CtlMoviminetosFechaLinea1
        '
        Me.CtlMoviminetosFechaLinea1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtlMoviminetosFechaLinea1.Location = New System.Drawing.Point(0, 0)
        Me.CtlMoviminetosFechaLinea1.Name = "CtlMoviminetosFechaLinea1"
        Me.CtlMoviminetosFechaLinea1.Size = New System.Drawing.Size(888, 552)
        Me.CtlMoviminetosFechaLinea1.TabIndex = 0
        '
        'frmTransferenciasLinea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(888, 552)
        Me.Controls.Add(Me.CtlMoviminetosFechaLinea1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTransferenciasLinea"
        Me.Text = "Transferencias Linea"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CtlMoviminetosFechaLinea1 As TRYINTELISISSELECTCTL.ctlMoviminetosFechaLinea
End Class
