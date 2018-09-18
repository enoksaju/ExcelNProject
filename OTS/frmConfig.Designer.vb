<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConfig
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
        Dim BDNombreLabel As System.Windows.Forms.Label
        Dim PassLabel As System.Windows.Forms.Label
        Dim PathBDLabel As System.Windows.Forms.Label
        Dim PathReportsLabel As System.Windows.Forms.Label
        Dim PortLabel As System.Windows.Forms.Label
        Dim UserLabel As System.Windows.Forms.Label
        Dim AdminUserLabel As System.Windows.Forms.Label
        Dim AdminPassLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfig))
        Me.OrdenesTrabajo_ConfigBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BDNombreTextBox = New System.Windows.Forms.TextBox()
        Me.PassTextBox = New System.Windows.Forms.TextBox()
        Me.PathBDTextBox = New System.Windows.Forms.TextBox()
        Me.PathReportsTextBox = New System.Windows.Forms.TextBox()
        Me.PortTextBox = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.UserTextBox = New System.Windows.Forms.TextBox()
        Me.AdminUserTextBox = New System.Windows.Forms.TextBox()
        Me.AdminPassTextBox = New System.Windows.Forms.TextBox()
        BDNombreLabel = New System.Windows.Forms.Label()
        PassLabel = New System.Windows.Forms.Label()
        PathBDLabel = New System.Windows.Forms.Label()
        PathReportsLabel = New System.Windows.Forms.Label()
        PortLabel = New System.Windows.Forms.Label()
        UserLabel = New System.Windows.Forms.Label()
        AdminUserLabel = New System.Windows.Forms.Label()
        AdminPassLabel = New System.Windows.Forms.Label()
        CType(Me.OrdenesTrabajo_ConfigBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BDNombreLabel
        '
        BDNombreLabel.AutoSize = True
        BDNombreLabel.Location = New System.Drawing.Point(21, 15)
        BDNombreLabel.Name = "BDNombreLabel"
        BDNombreLabel.Size = New System.Drawing.Size(62, 13)
        BDNombreLabel.TabIndex = 1
        BDNombreLabel.Text = "BDNombre:"
        '
        'PassLabel
        '
        PassLabel.AutoSize = True
        PassLabel.Location = New System.Drawing.Point(50, 121)
        PassLabel.Name = "PassLabel"
        PassLabel.Size = New System.Drawing.Size(33, 13)
        PassLabel.TabIndex = 2
        PassLabel.Text = "Pass:"
        '
        'PathBDLabel
        '
        PathBDLabel.AutoSize = True
        PathBDLabel.Location = New System.Drawing.Point(33, 41)
        PathBDLabel.Name = "PathBDLabel"
        PathBDLabel.Size = New System.Drawing.Size(50, 13)
        PathBDLabel.TabIndex = 4
        PathBDLabel.Text = "Path BD:"
        '
        'PathReportsLabel
        '
        PathReportsLabel.AutoSize = True
        PathReportsLabel.Location = New System.Drawing.Point(11, 263)
        PathReportsLabel.Name = "PathReportsLabel"
        PathReportsLabel.Size = New System.Drawing.Size(72, 13)
        PathReportsLabel.TabIndex = 6
        PathReportsLabel.Text = "Path Reports:"
        '
        'PortLabel
        '
        PortLabel.AutoSize = True
        PortLabel.Location = New System.Drawing.Point(54, 67)
        PortLabel.Name = "PortLabel"
        PortLabel.Size = New System.Drawing.Size(29, 13)
        PortLabel.TabIndex = 8
        PortLabel.Text = "Port:"
        '
        'OrdenesTrabajo_ConfigBindingSource
        '
        Me.OrdenesTrabajo_ConfigBindingSource.DataSource = GetType(OTS.OrdenesTrabajo.Config)
        '
        'BDNombreTextBox
        '
        Me.BDNombreTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrdenesTrabajo_ConfigBindingSource, "BDNombre", True))
        Me.BDNombreTextBox.Location = New System.Drawing.Point(89, 12)
        Me.BDNombreTextBox.Name = "BDNombreTextBox"
        Me.BDNombreTextBox.Size = New System.Drawing.Size(320, 20)
        Me.BDNombreTextBox.TabIndex = 2
        '
        'PassTextBox
        '
        Me.PassTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrdenesTrabajo_ConfigBindingSource, "Pass", True))
        Me.PassTextBox.Location = New System.Drawing.Point(89, 116)
        Me.PassTextBox.Name = "PassTextBox"
        Me.PassTextBox.Size = New System.Drawing.Size(320, 20)
        Me.PassTextBox.TabIndex = 3
        Me.PassTextBox.UseSystemPasswordChar = True
        '
        'PathBDTextBox
        '
        Me.PathBDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrdenesTrabajo_ConfigBindingSource, "PathBD", True))
        Me.PathBDTextBox.Location = New System.Drawing.Point(89, 38)
        Me.PathBDTextBox.Name = "PathBDTextBox"
        Me.PathBDTextBox.Size = New System.Drawing.Size(320, 20)
        Me.PathBDTextBox.TabIndex = 5
        '
        'PathReportsTextBox
        '
        Me.PathReportsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrdenesTrabajo_ConfigBindingSource, "PathReports", True))
        Me.PathReportsTextBox.Location = New System.Drawing.Point(89, 260)
        Me.PathReportsTextBox.Name = "PathReportsTextBox"
        Me.PathReportsTextBox.Size = New System.Drawing.Size(320, 20)
        Me.PathReportsTextBox.TabIndex = 7
        '
        'PortTextBox
        '
        Me.PortTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrdenesTrabajo_ConfigBindingSource, "Port", True))
        Me.PortTextBox.Location = New System.Drawing.Point(89, 64)
        Me.PortTextBox.Name = "PortTextBox"
        Me.PortTextBox.Size = New System.Drawing.Size(320, 20)
        Me.PortTextBox.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(284, 298)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 33)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "GUARDAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 298)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(125, 33)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "CANCELAR"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'UserLabel
        '
        UserLabel.AutoSize = True
        UserLabel.Location = New System.Drawing.Point(51, 93)
        UserLabel.Name = "UserLabel"
        UserLabel.Size = New System.Drawing.Size(32, 13)
        UserLabel.TabIndex = 13
        UserLabel.Text = "User:"
        '
        'UserTextBox
        '
        Me.UserTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrdenesTrabajo_ConfigBindingSource, "User", True))
        Me.UserTextBox.Location = New System.Drawing.Point(89, 90)
        Me.UserTextBox.Name = "UserTextBox"
        Me.UserTextBox.Size = New System.Drawing.Size(320, 20)
        Me.UserTextBox.TabIndex = 14
        '
        'AdminUserLabel
        '
        AdminUserLabel.AutoSize = True
        AdminUserLabel.Location = New System.Drawing.Point(19, 175)
        AdminUserLabel.Name = "AdminUserLabel"
        AdminUserLabel.Size = New System.Drawing.Size(64, 13)
        AdminUserLabel.TabIndex = 14
        AdminUserLabel.Text = "Admin User:"
        '
        'AdminUserTextBox
        '
        Me.AdminUserTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrdenesTrabajo_ConfigBindingSource, "AdminUser", True))
        Me.AdminUserTextBox.Location = New System.Drawing.Point(89, 172)
        Me.AdminUserTextBox.Name = "AdminUserTextBox"
        Me.AdminUserTextBox.Size = New System.Drawing.Size(320, 20)
        Me.AdminUserTextBox.TabIndex = 15
        '
        'AdminPassLabel
        '
        AdminPassLabel.AutoSize = True
        AdminPassLabel.Location = New System.Drawing.Point(18, 201)
        AdminPassLabel.Name = "AdminPassLabel"
        AdminPassLabel.Size = New System.Drawing.Size(65, 13)
        AdminPassLabel.TabIndex = 16
        AdminPassLabel.Text = "Admin Pass:"
        '
        'AdminPassTextBox
        '
        Me.AdminPassTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrdenesTrabajo_ConfigBindingSource, "AdminPass", True))
        Me.AdminPassTextBox.Location = New System.Drawing.Point(89, 198)
        Me.AdminPassTextBox.Name = "AdminPassTextBox"
        Me.AdminPassTextBox.Size = New System.Drawing.Size(320, 20)
        Me.AdminPassTextBox.TabIndex = 17
        Me.AdminPassTextBox.UseSystemPasswordChar = True
        '
        'frmConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 351)
        Me.Controls.Add(AdminPassLabel)
        Me.Controls.Add(Me.AdminPassTextBox)
        Me.Controls.Add(AdminUserLabel)
        Me.Controls.Add(Me.AdminUserTextBox)
        Me.Controls.Add(UserLabel)
        Me.Controls.Add(Me.UserTextBox)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(PortLabel)
        Me.Controls.Add(Me.PortTextBox)
        Me.Controls.Add(PathReportsLabel)
        Me.Controls.Add(Me.PathReportsTextBox)
        Me.Controls.Add(PathBDLabel)
        Me.Controls.Add(Me.PathBDTextBox)
        Me.Controls.Add(PassLabel)
        Me.Controls.Add(Me.PassTextBox)
        Me.Controls.Add(BDNombreLabel)
        Me.Controls.Add(Me.BDNombreTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfig"
        Me.Text = "Configurar"
        CType(Me.OrdenesTrabajo_ConfigBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OrdenesTrabajo_ConfigBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BDNombreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PassTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PathBDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PathReportsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PortTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents UserTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AdminUserTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AdminPassTextBox As System.Windows.Forms.TextBox
End Class
