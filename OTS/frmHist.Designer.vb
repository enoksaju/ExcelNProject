<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHist
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
        Me.components = New System.ComponentModel.Container()
        Dim OTLabel As System.Windows.Forms.Label
        Dim CLIENTELabel As System.Windows.Forms.Label
        Dim PRODUCTOLabel As System.Windows.Forms.Label
        Dim CANTIDADLabel As System.Windows.Forms.Label
        Dim UNIDADLabel As System.Windows.Forms.Label
        Dim MLLabel As System.Windows.Forms.Label
        Dim FechaCapturaLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHist))
        Me.TEMPCAPTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TEMPCAPTBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.OTLabel1 = New System.Windows.Forms.Label()
        Me.CLIENTELabel1 = New System.Windows.Forms.Label()
        Me.PRODUCTOLabel1 = New System.Windows.Forms.Label()
        Me.CANTIDADLabel1 = New System.Windows.Forms.Label()
        Me.UNIDADLabel1 = New System.Windows.Forms.Label()
        Me.MLLabel1 = New System.Windows.Forms.Label()
        Me.FechaCapturaLabel1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.impresion_tp = New System.Windows.Forms.TabPage()
        Me.laminacion_tp = New System.Windows.Forms.TabPage()
        Me.refinado_tp = New System.Windows.Forms.TabPage()
        Me.doblado_tp = New System.Windows.Forms.TabPage()
        Me.corte_tp = New System.Windows.Forms.TabPage()
        Me.embobinado_tp = New System.Windows.Forms.TabPage()
        Me.extrusion_tp = New System.Windows.Forms.TabPage()
        Me.mangas_tp = New System.Windows.Forms.TabPage()
        Me.sellado_tp = New System.Windows.Forms.TabPage()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.INSTIMPRESIONTextBox = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        OTLabel = New System.Windows.Forms.Label()
        CLIENTELabel = New System.Windows.Forms.Label()
        PRODUCTOLabel = New System.Windows.Forms.Label()
        CANTIDADLabel = New System.Windows.Forms.Label()
        UNIDADLabel = New System.Windows.Forms.Label()
        MLLabel = New System.Windows.Forms.Label()
        FechaCapturaLabel = New System.Windows.Forms.Label()
        CType(Me.TEMPCAPTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEMPCAPTBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TEMPCAPTBindingNavigator.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.impresion_tp.SuspendLayout()
        Me.laminacion_tp.SuspendLayout()
        Me.refinado_tp.SuspendLayout()
        Me.doblado_tp.SuspendLayout()
        Me.corte_tp.SuspendLayout()
        Me.embobinado_tp.SuspendLayout()
        Me.extrusion_tp.SuspendLayout()
        Me.mangas_tp.SuspendLayout()
        Me.sellado_tp.SuspendLayout()
        Me.SuspendLayout()
        '
        'OTLabel
        '
        OTLabel.AutoSize = True
        OTLabel.Dock = System.Windows.Forms.DockStyle.Fill
        OTLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        OTLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        OTLabel.Location = New System.Drawing.Point(5, 5)
        OTLabel.Margin = New System.Windows.Forms.Padding(5)
        OTLabel.Name = "OTLabel"
        OTLabel.Size = New System.Drawing.Size(106, 14)
        OTLabel.TabIndex = 1
        OTLabel.Text = "OT:"
        OTLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'CLIENTELabel
        '
        CLIENTELabel.AutoSize = True
        CLIENTELabel.Dock = System.Windows.Forms.DockStyle.Fill
        CLIENTELabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CLIENTELabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CLIENTELabel.Location = New System.Drawing.Point(5, 29)
        CLIENTELabel.Margin = New System.Windows.Forms.Padding(5)
        CLIENTELabel.Name = "CLIENTELabel"
        CLIENTELabel.Size = New System.Drawing.Size(106, 14)
        CLIENTELabel.TabIndex = 3
        CLIENTELabel.Text = "Cliente:"
        CLIENTELabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PRODUCTOLabel
        '
        PRODUCTOLabel.AutoSize = True
        PRODUCTOLabel.Dock = System.Windows.Forms.DockStyle.Fill
        PRODUCTOLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PRODUCTOLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        PRODUCTOLabel.Location = New System.Drawing.Point(5, 53)
        PRODUCTOLabel.Margin = New System.Windows.Forms.Padding(5)
        PRODUCTOLabel.Name = "PRODUCTOLabel"
        PRODUCTOLabel.Size = New System.Drawing.Size(106, 14)
        PRODUCTOLabel.TabIndex = 5
        PRODUCTOLabel.Text = "Producto:"
        PRODUCTOLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'CANTIDADLabel
        '
        CANTIDADLabel.AutoSize = True
        CANTIDADLabel.Dock = System.Windows.Forms.DockStyle.Fill
        CANTIDADLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CANTIDADLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CANTIDADLabel.Location = New System.Drawing.Point(5, 77)
        CANTIDADLabel.Margin = New System.Windows.Forms.Padding(5)
        CANTIDADLabel.Name = "CANTIDADLabel"
        CANTIDADLabel.Size = New System.Drawing.Size(106, 14)
        CANTIDADLabel.TabIndex = 7
        CANTIDADLabel.Text = "Cantidad:"
        CANTIDADLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'UNIDADLabel
        '
        UNIDADLabel.AutoSize = True
        UNIDADLabel.Dock = System.Windows.Forms.DockStyle.Fill
        UNIDADLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UNIDADLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        UNIDADLabel.Location = New System.Drawing.Point(242, 77)
        UNIDADLabel.Margin = New System.Windows.Forms.Padding(5)
        UNIDADLabel.Name = "UNIDADLabel"
        UNIDADLabel.Size = New System.Drawing.Size(111, 14)
        UNIDADLabel.TabIndex = 9
        UNIDADLabel.Text = "Unidad:"
        UNIDADLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MLLabel
        '
        MLLabel.AutoSize = True
        MLLabel.Dock = System.Windows.Forms.DockStyle.Fill
        MLLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        MLLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        MLLabel.Location = New System.Drawing.Point(5, 101)
        MLLabel.Margin = New System.Windows.Forms.Padding(5)
        MLLabel.Name = "MLLabel"
        MLLabel.Size = New System.Drawing.Size(106, 17)
        MLLabel.TabIndex = 11
        MLLabel.Text = "Metros Lineales:"
        MLLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'FechaCapturaLabel
        '
        FechaCapturaLabel.AutoSize = True
        FechaCapturaLabel.Dock = System.Windows.Forms.DockStyle.Fill
        FechaCapturaLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        FechaCapturaLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        FechaCapturaLabel.Location = New System.Drawing.Point(242, 101)
        FechaCapturaLabel.Margin = New System.Windows.Forms.Padding(5)
        FechaCapturaLabel.Name = "FechaCapturaLabel"
        FechaCapturaLabel.Size = New System.Drawing.Size(111, 17)
        FechaCapturaLabel.TabIndex = 13
        FechaCapturaLabel.Text = "Fecha Captura:"
        FechaCapturaLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TEMPCAPTBindingSource
        '
        Me.TEMPCAPTBindingSource.DataSource = GetType(libProduccionDataBase.Tablas.TEMPCAPT)
        '
        'TEMPCAPTBindingNavigator
        '
        Me.TEMPCAPTBindingNavigator.AddNewItem = Nothing
        Me.TEMPCAPTBindingNavigator.BindingSource = Me.TEMPCAPTBindingSource
        Me.TEMPCAPTBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.TEMPCAPTBindingNavigator.DeleteItem = Nothing
        Me.TEMPCAPTBindingNavigator.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TEMPCAPTBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TEMPCAPTBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.ToolStripTextBox1, Me.ToolStripButton1, Me.ToolStripSeparator1})
        Me.TEMPCAPTBindingNavigator.Location = New System.Drawing.Point(5, 0)
        Me.TEMPCAPTBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.TEMPCAPTBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.TEMPCAPTBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.TEMPCAPTBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.TEMPCAPTBindingNavigator.Name = "TEMPCAPTBindingNavigator"
        Me.TEMPCAPTBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.TEMPCAPTBindingNavigator.Size = New System.Drawing.Size(573, 25)
        Me.TEMPCAPTBindingNavigator.Stretch = True
        Me.TEMPCAPTBindingNavigator.TabIndex = 0
        Me.TEMPCAPTBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Número total de elementos"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Mover primero"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Mover anterior"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Posición"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Posición actual"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Mover siguiente"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Mover último"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(150, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.OTS.My.Resources.Resources.magnifier
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'OTLabel1
        '
        Me.OTLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TEMPCAPTBindingSource, "OT", True))
        Me.OTLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OTLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OTLabel1.ForeColor = System.Drawing.Color.Black
        Me.OTLabel1.Location = New System.Drawing.Point(121, 5)
        Me.OTLabel1.Margin = New System.Windows.Forms.Padding(5)
        Me.OTLabel1.Name = "OTLabel1"
        Me.OTLabel1.Size = New System.Drawing.Size(111, 14)
        Me.OTLabel1.TabIndex = 2
        Me.OTLabel1.Text = "-"
        '
        'CLIENTELabel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.CLIENTELabel1, 4)
        Me.CLIENTELabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TEMPCAPTBindingSource, "OrdenTrabajo.CLIENTE", True))
        Me.CLIENTELabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CLIENTELabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CLIENTELabel1.ForeColor = System.Drawing.Color.Black
        Me.CLIENTELabel1.Location = New System.Drawing.Point(121, 29)
        Me.CLIENTELabel1.Margin = New System.Windows.Forms.Padding(5)
        Me.CLIENTELabel1.Name = "CLIENTELabel1"
        Me.CLIENTELabel1.Size = New System.Drawing.Size(447, 14)
        Me.CLIENTELabel1.TabIndex = 4
        Me.CLIENTELabel1.Text = "-"
        '
        'PRODUCTOLabel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.PRODUCTOLabel1, 4)
        Me.PRODUCTOLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PRODUCTOLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PRODUCTOLabel1.ForeColor = System.Drawing.Color.Black
        Me.PRODUCTOLabel1.Location = New System.Drawing.Point(121, 53)
        Me.PRODUCTOLabel1.Margin = New System.Windows.Forms.Padding(5)
        Me.PRODUCTOLabel1.Name = "PRODUCTOLabel1"
        Me.PRODUCTOLabel1.Size = New System.Drawing.Size(447, 14)
        Me.PRODUCTOLabel1.TabIndex = 6
        Me.PRODUCTOLabel1.Text = "-"
        '
        'CANTIDADLabel1
        '
        Me.CANTIDADLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TEMPCAPTBindingSource, "OrdenTrabajo.CANTIDAD", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "-", "N2"))
        Me.CANTIDADLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CANTIDADLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CANTIDADLabel1.ForeColor = System.Drawing.Color.Black
        Me.CANTIDADLabel1.Location = New System.Drawing.Point(121, 77)
        Me.CANTIDADLabel1.Margin = New System.Windows.Forms.Padding(5)
        Me.CANTIDADLabel1.Name = "CANTIDADLabel1"
        Me.CANTIDADLabel1.Size = New System.Drawing.Size(111, 14)
        Me.CANTIDADLabel1.TabIndex = 8
        Me.CANTIDADLabel1.Text = "-"
        '
        'UNIDADLabel1
        '
        Me.UNIDADLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TEMPCAPTBindingSource, "OrdenTrabajo.UNIDAD", True))
        Me.UNIDADLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UNIDADLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UNIDADLabel1.ForeColor = System.Drawing.Color.Black
        Me.UNIDADLabel1.Location = New System.Drawing.Point(363, 77)
        Me.UNIDADLabel1.Margin = New System.Windows.Forms.Padding(5)
        Me.UNIDADLabel1.Name = "UNIDADLabel1"
        Me.UNIDADLabel1.Size = New System.Drawing.Size(102, 14)
        Me.UNIDADLabel1.TabIndex = 10
        Me.UNIDADLabel1.Text = "-"
        '
        'MLLabel1
        '
        Me.MLLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TEMPCAPTBindingSource, "ML", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "-", "N2"))
        Me.MLLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MLLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MLLabel1.ForeColor = System.Drawing.Color.Black
        Me.MLLabel1.Location = New System.Drawing.Point(121, 101)
        Me.MLLabel1.Margin = New System.Windows.Forms.Padding(5)
        Me.MLLabel1.Name = "MLLabel1"
        Me.MLLabel1.Size = New System.Drawing.Size(111, 17)
        Me.MLLabel1.TabIndex = 12
        Me.MLLabel1.Text = "-"
        '
        'FechaCapturaLabel1
        '
        Me.FechaCapturaLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TEMPCAPTBindingSource, "FechaCaptura", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "-", "d"))
        Me.FechaCapturaLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FechaCapturaLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FechaCapturaLabel1.ForeColor = System.Drawing.Color.Black
        Me.FechaCapturaLabel1.Location = New System.Drawing.Point(363, 101)
        Me.FechaCapturaLabel1.Margin = New System.Windows.Forms.Padding(5)
        Me.FechaCapturaLabel1.Name = "FechaCapturaLabel1"
        Me.FechaCapturaLabel1.Size = New System.Drawing.Size(102, 17)
        Me.FechaCapturaLabel1.TabIndex = 14
        Me.FechaCapturaLabel1.Text = "-"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(5, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(573, 123)
        Me.Panel1.TabIndex = 15
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoScroll = True
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(OTLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FechaCapturaLabel1, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(FechaCapturaLabel, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.OTLabel1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(CLIENTELabel, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.UNIDADLabel1, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(UNIDADLabel, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.MLLabel1, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(MLLabel, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.CLIENTELabel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(PRODUCTOLabel, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.PRODUCTOLabel1, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(CANTIDADLabel, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.CANTIDADLabel1, 1, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(573, 123)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(5, 148)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(573, 291)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Instrucciones"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.impresion_tp)
        Me.TabControl1.Controls.Add(Me.laminacion_tp)
        Me.TabControl1.Controls.Add(Me.refinado_tp)
        Me.TabControl1.Controls.Add(Me.doblado_tp)
        Me.TabControl1.Controls.Add(Me.corte_tp)
        Me.TabControl1.Controls.Add(Me.embobinado_tp)
        Me.TabControl1.Controls.Add(Me.extrusion_tp)
        Me.TabControl1.Controls.Add(Me.mangas_tp)
        Me.TabControl1.Controls.Add(Me.sellado_tp)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.HotTrack = True
        Me.TabControl1.ImageList = Me.ImageList1
        Me.TabControl1.ItemSize = New System.Drawing.Size(60, 18)
        Me.TabControl1.Location = New System.Drawing.Point(3, 16)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(567, 272)
        Me.TabControl1.TabIndex = 0
        '
        'impresion_tp
        '
        Me.impresion_tp.Controls.Add(Me.INSTIMPRESIONTextBox)
        Me.impresion_tp.ImageIndex = 2
        Me.impresion_tp.Location = New System.Drawing.Point(4, 22)
        Me.impresion_tp.Name = "impresion_tp"
        Me.impresion_tp.Size = New System.Drawing.Size(559, 246)
        Me.impresion_tp.TabIndex = 0
        Me.impresion_tp.Text = "Impresión"
        Me.impresion_tp.UseVisualStyleBackColor = True
        '
        'laminacion_tp
        '
        Me.laminacion_tp.Controls.Add(Me.TextBox1)
        Me.laminacion_tp.ImageIndex = 6
        Me.laminacion_tp.Location = New System.Drawing.Point(4, 22)
        Me.laminacion_tp.Name = "laminacion_tp"
        Me.laminacion_tp.Size = New System.Drawing.Size(559, 246)
        Me.laminacion_tp.TabIndex = 1
        Me.laminacion_tp.Text = "Laminación"
        Me.laminacion_tp.UseVisualStyleBackColor = True
        '
        'refinado_tp
        '
        Me.refinado_tp.Controls.Add(Me.TextBox2)
        Me.refinado_tp.ImageIndex = 1
        Me.refinado_tp.Location = New System.Drawing.Point(4, 22)
        Me.refinado_tp.Name = "refinado_tp"
        Me.refinado_tp.Size = New System.Drawing.Size(559, 246)
        Me.refinado_tp.TabIndex = 2
        Me.refinado_tp.Text = "Refinado"
        Me.refinado_tp.UseVisualStyleBackColor = True
        '
        'doblado_tp
        '
        Me.doblado_tp.Controls.Add(Me.TextBox3)
        Me.doblado_tp.ImageIndex = 7
        Me.doblado_tp.Location = New System.Drawing.Point(4, 22)
        Me.doblado_tp.Name = "doblado_tp"
        Me.doblado_tp.Size = New System.Drawing.Size(559, 246)
        Me.doblado_tp.TabIndex = 3
        Me.doblado_tp.Text = "Doblado"
        Me.doblado_tp.UseVisualStyleBackColor = True
        '
        'corte_tp
        '
        Me.corte_tp.Controls.Add(Me.TextBox4)
        Me.corte_tp.ImageIndex = 3
        Me.corte_tp.Location = New System.Drawing.Point(4, 22)
        Me.corte_tp.Name = "corte_tp"
        Me.corte_tp.Size = New System.Drawing.Size(559, 246)
        Me.corte_tp.TabIndex = 4
        Me.corte_tp.Text = "Corte"
        Me.corte_tp.UseVisualStyleBackColor = True
        '
        'embobinado_tp
        '
        Me.embobinado_tp.Controls.Add(Me.TextBox5)
        Me.embobinado_tp.ImageIndex = 5
        Me.embobinado_tp.Location = New System.Drawing.Point(4, 22)
        Me.embobinado_tp.Name = "embobinado_tp"
        Me.embobinado_tp.Size = New System.Drawing.Size(559, 246)
        Me.embobinado_tp.TabIndex = 5
        Me.embobinado_tp.Text = "Embobinado"
        Me.embobinado_tp.UseVisualStyleBackColor = True
        '
        'extrusion_tp
        '
        Me.extrusion_tp.Controls.Add(Me.TextBox6)
        Me.extrusion_tp.ImageIndex = 8
        Me.extrusion_tp.Location = New System.Drawing.Point(4, 22)
        Me.extrusion_tp.Name = "extrusion_tp"
        Me.extrusion_tp.Size = New System.Drawing.Size(559, 246)
        Me.extrusion_tp.TabIndex = 6
        Me.extrusion_tp.Text = "Extrusión"
        Me.extrusion_tp.UseVisualStyleBackColor = True
        '
        'mangas_tp
        '
        Me.mangas_tp.Controls.Add(Me.TextBox7)
        Me.mangas_tp.ImageIndex = 4
        Me.mangas_tp.Location = New System.Drawing.Point(4, 22)
        Me.mangas_tp.Name = "mangas_tp"
        Me.mangas_tp.Size = New System.Drawing.Size(559, 246)
        Me.mangas_tp.TabIndex = 7
        Me.mangas_tp.Text = "Mangas"
        Me.mangas_tp.UseVisualStyleBackColor = True
        '
        'sellado_tp
        '
        Me.sellado_tp.Controls.Add(Me.TextBox8)
        Me.sellado_tp.ImageIndex = 0
        Me.sellado_tp.Location = New System.Drawing.Point(4, 22)
        Me.sellado_tp.Name = "sellado_tp"
        Me.sellado_tp.Size = New System.Drawing.Size(559, 246)
        Me.sellado_tp.TabIndex = 8
        Me.sellado_tp.Text = "Sellado"
        Me.sellado_tp.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "book_Open_16xLG.png")
        Me.ImageList1.Images.SetKeyName(1, "clipboard_cut.png")
        Me.ImageList1.Images.SetKeyName(2, "colors.png")
        Me.ImageList1.Images.SetKeyName(3, "Cut_16x.png")
        Me.ImageList1.Images.SetKeyName(4, "database.png")
        Me.ImageList1.Images.SetKeyName(5, "item_disable.png")
        Me.ImageList1.Images.SetKeyName(6, "layers.png")
        Me.ImageList1.Images.SetKeyName(7, "note.png")
        Me.ImageList1.Images.SetKeyName(8, "script.png")
        '
        'INSTIMPRESIONTextBox
        '
        Me.INSTIMPRESIONTextBox.AcceptsReturn = True
        Me.INSTIMPRESIONTextBox.AcceptsTab = True
        Me.INSTIMPRESIONTextBox.BackColor = System.Drawing.Color.White
        Me.INSTIMPRESIONTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TEMPCAPTBindingSource, "OrdenTrabajo.INSTIMPRESION", True))
        Me.INSTIMPRESIONTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.INSTIMPRESIONTextBox.Location = New System.Drawing.Point(0, 0)
        Me.INSTIMPRESIONTextBox.Multiline = True
        Me.INSTIMPRESIONTextBox.Name = "INSTIMPRESIONTextBox"
        Me.INSTIMPRESIONTextBox.ReadOnly = True
        Me.INSTIMPRESIONTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.INSTIMPRESIONTextBox.Size = New System.Drawing.Size(559, 246)
        Me.INSTIMPRESIONTextBox.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.AcceptsReturn = True
        Me.TextBox1.AcceptsTab = True
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TEMPCAPTBindingSource, "OrdenTrabajo.INSTLAMINACION", True))
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(0, 0)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(559, 246)
        Me.TextBox1.TabIndex = 2
        '
        'TextBox2
        '
        Me.TextBox2.AcceptsReturn = True
        Me.TextBox2.AcceptsTab = True
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TEMPCAPTBindingSource, "OrdenTrabajo.INSTREFINADO", True))
        Me.TextBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox2.Location = New System.Drawing.Point(0, 0)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox2.Size = New System.Drawing.Size(559, 246)
        Me.TextBox2.TabIndex = 2
        '
        'TextBox3
        '
        Me.TextBox3.AcceptsReturn = True
        Me.TextBox3.AcceptsTab = True
        Me.TextBox3.BackColor = System.Drawing.Color.White
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TEMPCAPTBindingSource, "OrdenTrabajo.INSTDOBLADO", True))
        Me.TextBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox3.Location = New System.Drawing.Point(0, 0)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox3.Size = New System.Drawing.Size(559, 246)
        Me.TextBox3.TabIndex = 2
        '
        'TextBox4
        '
        Me.TextBox4.AcceptsReturn = True
        Me.TextBox4.AcceptsTab = True
        Me.TextBox4.BackColor = System.Drawing.Color.White
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TEMPCAPTBindingSource, "OrdenTrabajo.INSTCORTE", True))
        Me.TextBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox4.Location = New System.Drawing.Point(0, 0)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox4.Size = New System.Drawing.Size(559, 246)
        Me.TextBox4.TabIndex = 2
        '
        'TextBox5
        '
        Me.TextBox5.AcceptsReturn = True
        Me.TextBox5.AcceptsTab = True
        Me.TextBox5.BackColor = System.Drawing.Color.White
        Me.TextBox5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TEMPCAPTBindingSource, "OrdenTrabajo.INSTEMBOBINADO", True))
        Me.TextBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox5.Location = New System.Drawing.Point(0, 0)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox5.Size = New System.Drawing.Size(559, 246)
        Me.TextBox5.TabIndex = 2
        '
        'TextBox6
        '
        Me.TextBox6.AcceptsReturn = True
        Me.TextBox6.AcceptsTab = True
        Me.TextBox6.BackColor = System.Drawing.Color.White
        Me.TextBox6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TEMPCAPTBindingSource, "OrdenTrabajo.INSTEXTRUSION", True))
        Me.TextBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox6.Location = New System.Drawing.Point(0, 0)
        Me.TextBox6.Multiline = True
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox6.Size = New System.Drawing.Size(559, 246)
        Me.TextBox6.TabIndex = 2
        '
        'TextBox7
        '
        Me.TextBox7.AcceptsReturn = True
        Me.TextBox7.AcceptsTab = True
        Me.TextBox7.BackColor = System.Drawing.Color.White
        Me.TextBox7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TEMPCAPTBindingSource, "OrdenTrabajo.INSTMANGAS", True))
        Me.TextBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox7.Location = New System.Drawing.Point(0, 0)
        Me.TextBox7.Multiline = True
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox7.Size = New System.Drawing.Size(559, 246)
        Me.TextBox7.TabIndex = 2
        '
        'TextBox8
        '
        Me.TextBox8.AcceptsReturn = True
        Me.TextBox8.AcceptsTab = True
        Me.TextBox8.BackColor = System.Drawing.Color.White
        Me.TextBox8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TEMPCAPTBindingSource, "OrdenTrabajo.INSTSELLADO", True))
        Me.TextBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox8.Location = New System.Drawing.Point(0, 0)
        Me.TextBox8.Multiline = True
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox8.Size = New System.Drawing.Size(559, 246)
        Me.TextBox8.TabIndex = 2
        '
        'frmHist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(583, 444)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TEMPCAPTBindingNavigator)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmHist"
        Me.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Historico"
        CType(Me.TEMPCAPTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEMPCAPTBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TEMPCAPTBindingNavigator.ResumeLayout(False)
        Me.TEMPCAPTBindingNavigator.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.impresion_tp.ResumeLayout(False)
        Me.impresion_tp.PerformLayout()
        Me.laminacion_tp.ResumeLayout(False)
        Me.laminacion_tp.PerformLayout()
        Me.refinado_tp.ResumeLayout(False)
        Me.refinado_tp.PerformLayout()
        Me.doblado_tp.ResumeLayout(False)
        Me.doblado_tp.PerformLayout()
        Me.corte_tp.ResumeLayout(False)
        Me.corte_tp.PerformLayout()
        Me.embobinado_tp.ResumeLayout(False)
        Me.embobinado_tp.PerformLayout()
        Me.extrusion_tp.ResumeLayout(False)
        Me.extrusion_tp.PerformLayout()
        Me.mangas_tp.ResumeLayout(False)
        Me.mangas_tp.PerformLayout()
        Me.sellado_tp.ResumeLayout(False)
        Me.sellado_tp.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TEMPCAPTBindingSource As Windows.Forms.BindingSource
    Friend WithEvents TEMPCAPTBindingNavigator As Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As Windows.Forms.ToolStripSeparator
    Friend WithEvents OTLabel1 As Windows.Forms.Label
    Friend WithEvents CLIENTELabel1 As Windows.Forms.Label
    Friend WithEvents PRODUCTOLabel1 As Windows.Forms.Label
    Friend WithEvents CANTIDADLabel1 As Windows.Forms.Label
    Friend WithEvents UNIDADLabel1 As Windows.Forms.Label
    Friend WithEvents MLLabel1 As Windows.Forms.Label
    Friend WithEvents FechaCapturaLabel1 As Windows.Forms.Label
    Friend WithEvents ToolStripTextBox1 As Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripButton1 As Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents impresion_tp As Windows.Forms.TabPage
    Friend WithEvents laminacion_tp As Windows.Forms.TabPage
    Friend WithEvents refinado_tp As Windows.Forms.TabPage
    Friend WithEvents doblado_tp As Windows.Forms.TabPage
    Friend WithEvents corte_tp As Windows.Forms.TabPage
    Friend WithEvents embobinado_tp As Windows.Forms.TabPage
    Friend WithEvents extrusion_tp As Windows.Forms.TabPage
    Friend WithEvents mangas_tp As Windows.Forms.TabPage
    Friend WithEvents sellado_tp As Windows.Forms.TabPage
    Friend WithEvents ImageList1 As Windows.Forms.ImageList
    Friend WithEvents INSTIMPRESIONTextBox As Windows.Forms.TextBox
    Friend WithEvents TextBox1 As Windows.Forms.TextBox
    Friend WithEvents TextBox2 As Windows.Forms.TextBox
    Friend WithEvents TextBox3 As Windows.Forms.TextBox
    Friend WithEvents TextBox4 As Windows.Forms.TextBox
    Friend WithEvents TextBox5 As Windows.Forms.TextBox
    Friend WithEvents TextBox6 As Windows.Forms.TextBox
    Friend WithEvents TextBox7 As Windows.Forms.TextBox
    Friend WithEvents TextBox8 As Windows.Forms.TextBox
End Class
