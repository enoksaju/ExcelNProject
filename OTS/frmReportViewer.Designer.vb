<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReportViewer
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportViewer))
        Me.CtlEmptyOTs1 = New libReportsOTS.ctlEmptyOTs()
        Me.SuspendLayout()
        '
        'CtlEmptyOTs1
        '
        Me.CtlEmptyOTs1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtlEmptyOTs1.Location = New System.Drawing.Point(10, 10)
        Me.CtlEmptyOTs1.Name = "CtlEmptyOTs1"
        Me.CtlEmptyOTs1.Size = New System.Drawing.Size(927, 638)
        Me.CtlEmptyOTs1.TabIndex = 0
        '
        'frmReportViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 658)
        Me.Controls.Add(Me.CtlEmptyOTs1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReportViewer"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Text = "Ordenes de Trabajo"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CtlEmptyOTs1 As libReportsOTS.ctlEmptyOTs
End Class
