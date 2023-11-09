namespace The_Hight_School_Of_Avellaneda_System
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.barraSuperior = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.lblIconoHijo = new System.Windows.Forms.Label();
            this.iconFormularioHijoAActual = new FontAwesome.Sharp.IconPictureBox();
            this.shadowsPanel = new System.Windows.Forms.Panel();
            this.panelEscritrio = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.panelMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.barraSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconFormularioHijoAActual)).BeginInit();
            this.panelEscritrio.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panelMenu.Controls.Add(this.iconButton4);
            this.panelMenu.Controls.Add(this.iconButton3);
            this.panelMenu.Controls.Add(this.iconButton2);
            this.panelMenu.Controls.Add(this.iconButton1);
            this.panelMenu.Controls.Add(this.panel2);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(234, 749);
            this.panelMenu.TabIndex = 4;
            // 
            // iconButton3
            // 
            this.iconButton3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton3.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.iconButton3.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton3.Location = new System.Drawing.Point(0, 689);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton3.Size = new System.Drawing.Size(234, 60);
            this.iconButton3.TabIndex = 3;
            this.iconButton3.Text = "Logout";
            this.iconButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton3.UseVisualStyleBackColor = true;
            this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click);
            this.iconButton3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.iconButton3_KeyDown);
            // 
            // iconButton2
            // 
            this.iconButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconButton2.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.Location = new System.Drawing.Point(0, 200);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton2.Size = new System.Drawing.Size(234, 60);
            this.iconButton2.TabIndex = 2;
            this.iconButton2.Text = "Buscar fichas";
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = true;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            this.iconButton1.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(0, 140);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton1.Size = new System.Drawing.Size(234, 60);
            this.iconButton1.TabIndex = 1;
            this.iconButton1.Text = "Agregar ficha";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.btnHome);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 140);
            this.panel2.TabIndex = 0;
            // 
            // btnHome
            // 
            this.btnHome.Image = global::The_Hight_School_Of_Avellaneda_System.Properties.Resources.WhatsApp_Image_2023_10_22_at_13_32_22;
            this.btnHome.Location = new System.Drawing.Point(-14, -17);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(248, 177);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // barraSuperior
            // 
            this.barraSuperior.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.barraSuperior.Controls.Add(this.iconPictureBox1);
            this.barraSuperior.Controls.Add(this.lblIconoHijo);
            this.barraSuperior.Controls.Add(this.iconFormularioHijoAActual);
            this.barraSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSuperior.Location = new System.Drawing.Point(234, 0);
            this.barraSuperior.Name = "barraSuperior";
            this.barraSuperior.Size = new System.Drawing.Size(1243, 73);
            this.barraSuperior.TabIndex = 5;
            this.barraSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barraSuperior_MouseDown);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPictureBox1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.ArrowsToCircle;
            this.iconPictureBox1.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.Location = new System.Drawing.Point(1188, 23);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox1.TabIndex = 4;
            this.iconPictureBox1.TabStop = false;
            this.iconPictureBox1.Click += new System.EventHandler(this.iconPictureBox1_Click);
            // 
            // lblIconoHijo
            // 
            this.lblIconoHijo.AutoSize = true;
            this.lblIconoHijo.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.lblIconoHijo.Location = new System.Drawing.Point(57, 32);
            this.lblIconoHijo.Name = "lblIconoHijo";
            this.lblIconoHijo.Size = new System.Drawing.Size(39, 13);
            this.lblIconoHijo.TabIndex = 1;
            this.lblIconoHijo.Text = "HOME";
            // 
            // iconFormularioHijoAActual
            // 
            this.iconFormularioHijoAActual.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.iconFormularioHijoAActual.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.iconFormularioHijoAActual.IconChar = FontAwesome.Sharp.IconChar.House;
            this.iconFormularioHijoAActual.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.iconFormularioHijoAActual.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconFormularioHijoAActual.Location = new System.Drawing.Point(19, 23);
            this.iconFormularioHijoAActual.Name = "iconFormularioHijoAActual";
            this.iconFormularioHijoAActual.Size = new System.Drawing.Size(32, 32);
            this.iconFormularioHijoAActual.TabIndex = 0;
            this.iconFormularioHijoAActual.TabStop = false;
            // 
            // shadowsPanel
            // 
            this.shadowsPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.shadowsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.shadowsPanel.Location = new System.Drawing.Point(234, 73);
            this.shadowsPanel.Name = "shadowsPanel";
            this.shadowsPanel.Size = new System.Drawing.Size(1243, 11);
            this.shadowsPanel.TabIndex = 7;
            // 
            // panelEscritrio
            // 
            this.panelEscritrio.BackColor = System.Drawing.Color.SlateBlue;
            this.panelEscritrio.Controls.Add(this.panel1);
            this.panelEscritrio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEscritrio.Location = new System.Drawing.Point(234, 84);
            this.panelEscritrio.Name = "panelEscritrio";
            this.panelEscritrio.Size = new System.Drawing.Size(1243, 665);
            this.panelEscritrio.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 665);
            this.panel1.TabIndex = 0;
            // 
            // iconButton4
            // 
            this.iconButton4.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton4.FlatAppearance.BorderSize = 0;
            this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton4.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton4.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.Portrait;
            this.iconButton4.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton4.Location = new System.Drawing.Point(0, 260);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton4.Size = new System.Drawing.Size(234, 60);
            this.iconButton4.TabIndex = 4;
            this.iconButton4.Text = "Ultima ficha";
            this.iconButton4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton4.UseVisualStyleBackColor = true;
            this.iconButton4.Click += new System.EventHandler(this.iconButton4_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1477, 749);
            this.Controls.Add(this.panelEscritrio);
            this.Controls.Add(this.shadowsPanel);
            this.Controls.Add(this.barraSuperior);
            this.Controls.Add(this.panelMenu);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FUNERARIA";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.panelMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.barraSuperior.ResumeLayout(false);
            this.barraSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconFormularioHijoAActual)).EndInit();
            this.panelEscritrio.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.Panel barraSuperior;
        private FontAwesome.Sharp.IconPictureBox iconFormularioHijoAActual;
        private System.Windows.Forms.Label lblIconoHijo;
        private System.Windows.Forms.Panel shadowsPanel;
        private System.Windows.Forms.Panel panelEscritrio;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton4;
    }
}



