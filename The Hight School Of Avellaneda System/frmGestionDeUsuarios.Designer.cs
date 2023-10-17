namespace The_Hight_School_Of_Avellaneda_System
{
    partial class frmGestionDeUsuarios
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
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.dtGResultados = new System.Windows.Forms.DataGridView();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnRecuperar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnReiniciarCAI = new System.Windows.Forms.Button();
            this.btnDesbloquear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(8, 33);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(297, 20);
            this.txtBuscar.TabIndex = 9;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.Location = new System.Drawing.Point(5, 18);
            this.lblBusqueda.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(40, 13);
            this.lblBusqueda.TabIndex = 10;
            this.lblBusqueda.Text = "Buscar";
            this.lblBusqueda.Click += new System.EventHandler(this.lblBusqueda_Click);
            // 
            // dtGResultados
            // 
            this.dtGResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtGResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGResultados.Location = new System.Drawing.Point(8, 69);
            this.dtGResultados.Margin = new System.Windows.Forms.Padding(2);
            this.dtGResultados.Name = "dtGResultados";
            this.dtGResultados.RowHeadersWidth = 62;
            this.dtGResultados.RowTemplate.Height = 28;
            this.dtGResultados.Size = new System.Drawing.Size(764, 304);
            this.dtGResultados.TabIndex = 11;
            this.dtGResultados.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtGResultados_CellFormatting);
            // 
            // btnAnular
            // 
            this.btnAnular.BackColor = System.Drawing.Color.IndianRed;
            this.btnAnular.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAnular.Location = new System.Drawing.Point(8, 395);
            this.btnAnular.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(105, 31);
            this.btnAnular.TabIndex = 9;
            this.btnAnular.Text = "Anular";
            this.btnAnular.UseVisualStyleBackColor = false;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEditar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditar.Location = new System.Drawing.Point(139, 395);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(105, 31);
            this.btnEditar.TabIndex = 10;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.SeaGreen;
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNuevo.Location = new System.Drawing.Point(667, 26);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(105, 31);
            this.btnNuevo.TabIndex = 11;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnRecuperar
            // 
            this.btnRecuperar.BackColor = System.Drawing.Color.Orange;
            this.btnRecuperar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRecuperar.Location = new System.Drawing.Point(270, 395);
            this.btnRecuperar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRecuperar.Name = "btnRecuperar";
            this.btnRecuperar.Size = new System.Drawing.Size(105, 31);
            this.btnRecuperar.TabIndex = 12;
            this.btnRecuperar.Text = "Recuperar";
            this.btnRecuperar.UseVisualStyleBackColor = false;
            this.btnRecuperar.Click += new System.EventHandler(this.btnRecuperar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Gray;
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSalir.Location = new System.Drawing.Point(663, 395);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(105, 31);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnReiniciarCAI
            // 
            this.btnReiniciarCAI.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReiniciarCAI.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReiniciarCAI.Location = new System.Drawing.Point(401, 395);
            this.btnReiniciarCAI.Margin = new System.Windows.Forms.Padding(2);
            this.btnReiniciarCAI.Name = "btnReiniciarCAI";
            this.btnReiniciarCAI.Size = new System.Drawing.Size(105, 31);
            this.btnReiniciarCAI.TabIndex = 14;
            this.btnReiniciarCAI.Text = "Reiniciar CAI";
            this.btnReiniciarCAI.UseVisualStyleBackColor = false;
            // 
            // btnDesbloquear
            // 
            this.btnDesbloquear.BackColor = System.Drawing.Color.Orange;
            this.btnDesbloquear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDesbloquear.Location = new System.Drawing.Point(532, 395);
            this.btnDesbloquear.Margin = new System.Windows.Forms.Padding(2);
            this.btnDesbloquear.Name = "btnDesbloquear";
            this.btnDesbloquear.Size = new System.Drawing.Size(105, 31);
            this.btnDesbloquear.TabIndex = 15;
            this.btnDesbloquear.Text = "Desbloquear";
            this.btnDesbloquear.UseVisualStyleBackColor = false;
            // 
            // frmGestionDeUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 443);
            this.Controls.Add(this.btnDesbloquear);
            this.Controls.Add(this.btnReiniciarCAI);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRecuperar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dtGResultados);
            this.Controls.Add(this.lblBusqueda);
            this.Controls.Add(this.txtBuscar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmGestionDeUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGestionDeUsuarios";
            this.Load += new System.EventHandler(this.frmGestionDeUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.DataGridView dtGResultados;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnRecuperar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnReiniciarCAI;
        private System.Windows.Forms.Button btnDesbloquear;
    }
}