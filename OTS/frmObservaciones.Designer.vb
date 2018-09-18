<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmObservaciones
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
        Me.components = New System.ComponentModel.Container()
        Me.DataSet1 = New OTS.DataSet1()
        Me.SP_ORDENTRABAJOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SP_ORDENTRABAJOTableAdapter = New OTS.DataSet1TableAdapters.SP_ORDENTRABAJOTableAdapter()
        Me.TableAdapterManager = New OTS.DataSet1TableAdapters.TableAdapterManager()
        Me.FillToolStrip = New System.Windows.Forms.ToolStrip()
        Me.OTToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.OTToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.FillToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.OBSERVACIONESTextBox = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SP_ORDENTRABAJOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FillToolStrip.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SP_ORDENTRABAJOBindingSource
        '
        Me.SP_ORDENTRABAJOBindingSource.DataMember = "SP_ORDENTRABAJO"
        Me.SP_ORDENTRABAJOBindingSource.DataSource = Me.DataSet1
        '
        'SP_ORDENTRABAJOTableAdapter
        '
        Me.SP_ORDENTRABAJOTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.LINEASTableAdapter = Nothing
        Me.TableAdapterManager.MAQUINASTableAdapter = Nothing
        Me.TableAdapterManager.ORDENTRABAJOTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = OTS.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'FillToolStrip
        '
        Me.FillToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OTToolStripLabel, Me.OTToolStripTextBox, Me.FillToolStripButton})
        Me.FillToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.FillToolStrip.Name = "FillToolStrip"
        Me.FillToolStrip.Size = New System.Drawing.Size(559, 25)
        Me.FillToolStrip.TabIndex = 1
        Me.FillToolStrip.Text = "FillToolStrip"
        '
        'OTToolStripLabel
        '
        Me.OTToolStripLabel.Name = "OTToolStripLabel"
        Me.OTToolStripLabel.Size = New System.Drawing.Size(25, 22)
        Me.OTToolStripLabel.Text = "OT:"
        '
        'OTToolStripTextBox
        '
        Me.OTToolStripTextBox.Name = "OTToolStripTextBox"
        Me.OTToolStripTextBox.Size = New System.Drawing.Size(100, 25)
        '
        'FillToolStripButton
        '
        Me.FillToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.FillToolStripButton.Name = "FillToolStripButton"
        Me.FillToolStripButton.Size = New System.Drawing.Size(46, 22)
        Me.FillToolStripButton.Text = "Buscar"
        '
        'OBSERVACIONESTextBox
        '
        Me.OBSERVACIONESTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SP_ORDENTRABAJOBindingSource, "OBSERVACIONES", True))
        Me.OBSERVACIONESTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OBSERVACIONESTextBox.Location = New System.Drawing.Point(8, 8)
        Me.OBSERVACIONESTextBox.Multiline = True
        Me.OBSERVACIONESTextBox.Name = "OBSERVACIONESTextBox"
        Me.OBSERVACIONESTextBox.Size = New System.Drawing.Size(543, 265)
        Me.OBSERVACIONESTextBox.TabIndex = 3
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OBSERVACIONESTextBox, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 25)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(559, 281)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'frmObservaciones
        '
        Me.ClientSize = New System.Drawing.Size(559, 306)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.FillToolStrip)
        Me.Name = "frmObservaciones"
        Me.Text = "Observaciones"
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SP_ORDENTRABAJOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FillToolStrip.ResumeLayout(False)
        Me.FillToolStrip.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataSet1 As DataSet1
    Friend WithEvents SP_ORDENTRABAJOBindingSource As Windows.Forms.BindingSource
    Friend WithEvents SP_ORDENTRABAJOTableAdapter As DataSet1TableAdapters.SP_ORDENTRABAJOTableAdapter
    Friend WithEvents TableAdapterManager As DataSet1TableAdapters.TableAdapterManager
    Friend WithEvents FillToolStrip As Windows.Forms.ToolStrip
    Friend WithEvents OTToolStripLabel As Windows.Forms.ToolStripLabel
    Friend WithEvents OTToolStripTextBox As Windows.Forms.ToolStripTextBox
    Friend WithEvents FillToolStripButton As Windows.Forms.ToolStripButton
    Friend WithEvents OBSERVACIONESTextBox As Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
End Class
