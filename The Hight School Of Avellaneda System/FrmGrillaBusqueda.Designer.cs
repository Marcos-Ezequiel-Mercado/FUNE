namespace The_Hight_School_Of_Avellaneda_System
{
    partial class FrmGrillaBusqueda
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
            this.Filtros = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.txtFallecimiento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConyugue = new System.Windows.Forms.TextBox();
            this.txtMadre = new System.Windows.Forms.TextBox();
            this.txtPadre = new System.Windows.Forms.TextBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.dgvGrillaResultados = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.Filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // Filtros
            // 
            this.Filtros.Controls.Add(this.label7);
            this.Filtros.Controls.Add(this.txtDomicilio);
            this.Filtros.Controls.Add(this.txtFallecimiento);
            this.Filtros.Controls.Add(this.label6);
            this.Filtros.Controls.Add(this.label5);
            this.Filtros.Controls.Add(this.label4);
            this.Filtros.Controls.Add(this.label3);
            this.Filtros.Controls.Add(this.label2);
            this.Filtros.Controls.Add(this.label1);
            this.Filtros.Controls.Add(this.txtConyugue);
            this.Filtros.Controls.Add(this.txtMadre);
            this.Filtros.Controls.Add(this.txtPadre);
            this.Filtros.Controls.Add(this.txtDocumento);
            this.Filtros.Controls.Add(this.txtNombre);
            this.Filtros.Location = new System.Drawing.Point(24, 22);
            this.Filtros.Name = "Filtros";
            this.Filtros.Size = new System.Drawing.Size(752, 260);
            this.Filtros.TabIndex = 0;
            this.Filtros.TabStop = false;
            this.Filtros.Text = "---Filtros---";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(366, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Domicilio =";
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(447, 166);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(277, 20);
            this.txtDomicilio.TabIndex = 13;
            // 
            // txtFallecimiento
            // 
            this.txtFallecimiento.Location = new System.Drawing.Point(103, 224);
            this.txtFallecimiento.Name = "txtFallecimiento";
            this.txtFallecimiento.Size = new System.Drawing.Size(131, 20);
            this.txtFallecimiento.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "F. fallecimiento =";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Documento = ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(377, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Padre = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Madre =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Conyugue =";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre =";
            // 
            // txtConyugue
            // 
            this.txtConyugue.Location = new System.Drawing.Point(103, 101);
            this.txtConyugue.Name = "txtConyugue";
            this.txtConyugue.Size = new System.Drawing.Size(239, 20);
            this.txtConyugue.TabIndex = 3;
            // 
            // txtMadre
            // 
            this.txtMadre.Location = new System.Drawing.Point(447, 43);
            this.txtMadre.Name = "txtMadre";
            this.txtMadre.Size = new System.Drawing.Size(277, 20);
            this.txtMadre.TabIndex = 1;
            // 
            // txtPadre
            // 
            this.txtPadre.Location = new System.Drawing.Point(447, 101);
            this.txtPadre.Name = "txtPadre";
            this.txtPadre.Size = new System.Drawing.Size(277, 20);
            this.txtPadre.TabIndex = 4;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(103, 166);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(131, 20);
            this.txtDocumento.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(103, 43);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(239, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // dgvGrillaResultados
            // 
            this.dgvGrillaResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGrillaResultados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGrillaResultados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvGrillaResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrillaResultados.Location = new System.Drawing.Point(24, 288);
            this.dgvGrillaResultados.Name = "dgvGrillaResultados";
            this.dgvGrillaResultados.ReadOnly = true;
            this.dgvGrillaResultados.RowHeadersVisible = false;
            this.dgvGrillaResultados.Size = new System.Drawing.Size(752, 290);
            this.dgvGrillaResultados.TabIndex = 7;
            this.dgvGrillaResultados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrillaResultados_CellDoubleClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(650, 585);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(126, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmGrillaBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvGrillaResultados);
            this.Controls.Add(this.Filtros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmGrillaBusqueda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGrillaBusqueda";
            this.Filtros.ResumeLayout(false);
            this.Filtros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaResultados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Filtros;
        private System.Windows.Forms.DataGridView dgvGrillaResultados;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtConyugue;
        private System.Windows.Forms.TextBox txtMadre;
        private System.Windows.Forms.TextBox txtPadre;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFallecimiento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDomicilio;
    }
}