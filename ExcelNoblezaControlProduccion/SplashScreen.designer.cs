namespace EstacionPesaje
{
    partial class SplashScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.MainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DetailsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.messageText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.ApplicationTitle = new System.Windows.Forms.Label();
            this.MainLayoutPanel.SuspendLayout();
            this.DetailsLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLayoutPanel
            // 
            this.MainLayoutPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MainLayoutPanel.BackgroundImage = global::EstacionPesaje.Properties.Resources.logo;
            this.MainLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MainLayoutPanel.ColumnCount = 1;
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainLayoutPanel.Controls.Add(this.DetailsLayoutPanel, 0, 2);
            this.MainLayoutPanel.Controls.Add(this.panel1, 0, 0);
            this.MainLayoutPanel.Controls.Add(this.ApplicationTitle, 0, 1);
            this.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainLayoutPanel.Name = "MainLayoutPanel";
            this.MainLayoutPanel.RowCount = 1;
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.17544F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.82456F));
            this.MainLayoutPanel.Size = new System.Drawing.Size(312, 155);
            this.MainLayoutPanel.TabIndex = 1;
            // 
            // DetailsLayoutPanel
            // 
            this.DetailsLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.DetailsLayoutPanel.ColumnCount = 1;
            this.DetailsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DetailsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.DetailsLayoutPanel.Controls.Add(this.messageText, 0, 0);
            this.DetailsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailsLayoutPanel.Location = new System.Drawing.Point(3, 120);
            this.DetailsLayoutPanel.Name = "DetailsLayoutPanel";
            this.DetailsLayoutPanel.RowCount = 1;
            this.DetailsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DetailsLayoutPanel.Size = new System.Drawing.Size(306, 32);
            this.DetailsLayoutPanel.TabIndex = 1;
            // 
            // messageText
            // 
            this.messageText.BackColor = System.Drawing.Color.Transparent;
            this.messageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageText.Location = new System.Drawing.Point(3, 0);
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(300, 32);
            this.messageText.TabIndex = 4;
            this.messageText.Text = "Cargando ...";
            this.messageText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.messageText.UseWaitCursor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 23);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::EstacionPesaje.Properties.Resources.Cancel_vs_32x;
            this.button1.Location = new System.Drawing.Point(281, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ApplicationTitle
            // 
            this.ApplicationTitle.BackColor = System.Drawing.Color.Transparent;
            this.ApplicationTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ApplicationTitle.Font = new System.Drawing.Font("Calibri Light", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ApplicationTitle.Location = new System.Drawing.Point(3, 81);
            this.ApplicationTitle.Name = "ApplicationTitle";
            this.ApplicationTitle.Size = new System.Drawing.Size(306, 36);
            this.ApplicationTitle.TabIndex = 0;
            this.ApplicationTitle.Text = "Control de Producción";
            this.ApplicationTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 155);
            this.Controls.Add(this.MainLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashScreen";
            this.Opacity = 0.8D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            this.MainLayoutPanel.ResumeLayout(false);
            this.DetailsLayoutPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel MainLayoutPanel;
        internal System.Windows.Forms.TableLayoutPanel DetailsLayoutPanel;
        internal System.Windows.Forms.Label messageText;
        internal System.Windows.Forms.Label ApplicationTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}