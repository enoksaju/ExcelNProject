namespace EstacionesPesaje
{
    partial class LogInForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            this.passwordKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.loginModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userNameKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.BasicInfoLayout = new System.Windows.Forms.TableLayoutPanel();
            this.emailKryptonWrapLabel = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.usuarioBasicInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.apellidoPaternoKryptonWrapLabel = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.apellidoMaternoKryptonWrapLabel = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.nombreKryptonWrapLabel = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonCheckBox1 = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.loginModelBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.BasicInfoLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBasicInfoBindingSource)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // passwordKryptonTextBox
            // 
            this.passwordKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.loginModelBindingSource, "Password", true));
            this.passwordKryptonTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordKryptonTextBox.Location = new System.Drawing.Point(80, 33);
            this.passwordKryptonTextBox.Name = "passwordKryptonTextBox";
            this.passwordKryptonTextBox.PasswordChar = '●';
            this.passwordKryptonTextBox.Size = new System.Drawing.Size(118, 23);
            this.passwordKryptonTextBox.TabIndex = 2;
            this.passwordKryptonTextBox.UseSystemPasswordChar = true;
            // 
            // loginModelBindingSource
            // 
            this.loginModelBindingSource.DataSource = typeof(libProduccionDataBase.Identity.Model.LoginModel);
            // 
            // userNameKryptonTextBox
            // 
            this.userNameKryptonTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.userNameKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.loginModelBindingSource, "UserName", true));
            this.userNameKryptonTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userNameKryptonTextBox.Location = new System.Drawing.Point(80, 3);
            this.userNameKryptonTextBox.Name = "userNameKryptonTextBox";
            this.userNameKryptonTextBox.Size = new System.Drawing.Size(118, 23);
            this.userNameKryptonTextBox.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.userNameKryptonTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.passwordKryptonTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.kryptonWrapLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.kryptonWrapLabel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(201, 60);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(3, 0);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(71, 30);
            this.kryptonWrapLabel1.Text = "Usuario:";
            this.kryptonWrapLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // kryptonWrapLabel2
            // 
            this.kryptonWrapLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonWrapLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.kryptonWrapLabel2.Location = new System.Drawing.Point(3, 30);
            this.kryptonWrapLabel2.Name = "kryptonWrapLabel2";
            this.kryptonWrapLabel2.Size = new System.Drawing.Size(71, 30);
            this.kryptonWrapLabel2.Text = "Contraseña:";
            this.kryptonWrapLabel2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BasicInfoLayout
            // 
            this.BasicInfoLayout.BackColor = System.Drawing.Color.Transparent;
            this.BasicInfoLayout.ColumnCount = 2;
            this.BasicInfoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BasicInfoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.BasicInfoLayout.Controls.Add(this.emailKryptonWrapLabel, 0, 2);
            this.BasicInfoLayout.Controls.Add(this.apellidoPaternoKryptonWrapLabel, 0, 1);
            this.BasicInfoLayout.Controls.Add(this.apellidoMaternoKryptonWrapLabel, 1, 1);
            this.BasicInfoLayout.Controls.Add(this.nombreKryptonWrapLabel, 0, 0);
            this.BasicInfoLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasicInfoLayout.Location = new System.Drawing.Point(0, 0);
            this.BasicInfoLayout.Name = "BasicInfoLayout";
            this.BasicInfoLayout.RowCount = 3;
            this.BasicInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.BasicInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.BasicInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BasicInfoLayout.Size = new System.Drawing.Size(198, 56);
            this.BasicInfoLayout.TabIndex = 5;
            // 
            // emailKryptonWrapLabel
            // 
            this.BasicInfoLayout.SetColumnSpan(this.emailKryptonWrapLabel, 2);
            this.emailKryptonWrapLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.usuarioBasicInfoBindingSource, "Email", true));
            this.emailKryptonWrapLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailKryptonWrapLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.emailKryptonWrapLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.emailKryptonWrapLabel.Location = new System.Drawing.Point(3, 36);
            this.emailKryptonWrapLabel.Name = "emailKryptonWrapLabel";
            this.emailKryptonWrapLabel.Size = new System.Drawing.Size(192, 20);
            // 
            // usuarioBasicInfoBindingSource
            // 
            this.usuarioBasicInfoBindingSource.DataSource = typeof(libProduccionDataBase.Identity.Model.UsuarioBasicInfo);
            // 
            // apellidoPaternoKryptonWrapLabel
            // 
            this.apellidoPaternoKryptonWrapLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.usuarioBasicInfoBindingSource, "ApellidoPaterno", true));
            this.apellidoPaternoKryptonWrapLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.apellidoPaternoKryptonWrapLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.apellidoPaternoKryptonWrapLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.apellidoPaternoKryptonWrapLabel.Location = new System.Drawing.Point(3, 18);
            this.apellidoPaternoKryptonWrapLabel.Name = "apellidoPaternoKryptonWrapLabel";
            this.apellidoPaternoKryptonWrapLabel.Size = new System.Drawing.Size(92, 18);
            // 
            // apellidoMaternoKryptonWrapLabel
            // 
            this.apellidoMaternoKryptonWrapLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.usuarioBasicInfoBindingSource, "ApellidoMaterno", true));
            this.apellidoMaternoKryptonWrapLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.apellidoMaternoKryptonWrapLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.apellidoMaternoKryptonWrapLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.apellidoMaternoKryptonWrapLabel.Location = new System.Drawing.Point(101, 18);
            this.apellidoMaternoKryptonWrapLabel.Name = "apellidoMaternoKryptonWrapLabel";
            this.apellidoMaternoKryptonWrapLabel.Size = new System.Drawing.Size(94, 18);
            // 
            // nombreKryptonWrapLabel
            // 
            this.BasicInfoLayout.SetColumnSpan(this.nombreKryptonWrapLabel, 2);
            this.nombreKryptonWrapLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.usuarioBasicInfoBindingSource, "Nombre", true));
            this.nombreKryptonWrapLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nombreKryptonWrapLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nombreKryptonWrapLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.nombreKryptonWrapLabel.Location = new System.Drawing.Point(3, 0);
            this.nombreKryptonWrapLabel.Name = "nombreKryptonWrapLabel";
            this.nombreKryptonWrapLabel.Size = new System.Drawing.Size(192, 18);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.89899F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.10101F));
            this.tableLayoutPanel3.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.69231F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.30769F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(415, 115);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.BasicInfoLayout);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(210, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(202, 60);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.kryptonCheckBox1);
            this.panel1.Controls.Add(this.kryptonButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 66);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 49);
            this.panel1.TabIndex = 6;
            // 
            // kryptonCheckBox1
            // 
            this.kryptonCheckBox1.Checked = global::EstacionesPesaje.Properties.Settings.Default.RememberMe;
            this.kryptonCheckBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EstacionesPesaje.Properties.Settings.Default, "RememberMe", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.kryptonCheckBox1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ItalicControl;
            this.kryptonCheckBox1.Location = new System.Drawing.Point(83, 8);
            this.kryptonCheckBox1.Name = "kryptonCheckBox1";
            this.kryptonCheckBox1.Size = new System.Drawing.Size(88, 20);
            this.kryptonCheckBox1.TabIndex = 4;
            this.kryptonCheckBox1.Values.Text = "Recordarme";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kryptonButton1.Location = new System.Drawing.Point(296, 8);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(111, 32);
            this.kryptonButton1.TabIndex = 3;
            this.kryptonButton1.Values.Image = global::EstacionesPesaje.Properties.Resources.login_user2;
            this.kryptonButton1.Values.Text = "Entrar";
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver;
            // 
            // LogInForm
            // 
            this.AcceptButton = this.kryptonButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(415, 115);
            this.Controls.Add(this.tableLayoutPanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogInForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogInForm_FormClosing);
            this.Load += new System.EventHandler(this.LogInForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loginModelBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.BasicInfoLayout.ResumeLayout(false);
            this.BasicInfoLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBasicInfoBindingSource)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource loginModelBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox passwordKryptonTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox userNameKryptonTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel2;
        private System.Windows.Forms.TableLayoutPanel BasicInfoLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel emailKryptonWrapLabel;
        private System.Windows.Forms.BindingSource usuarioBasicInfoBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel apellidoPaternoKryptonWrapLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel apellidoMaternoKryptonWrapLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel nombreKryptonWrapLabel;
        private System.Windows.Forms.Panel panel2;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox kryptonCheckBox1;
    }
}