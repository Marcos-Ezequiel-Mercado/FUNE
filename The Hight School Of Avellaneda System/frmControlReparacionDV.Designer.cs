namespace The_Hight_School_Of_Avellaneda_System
{
    partial class frmControlReparacionDV
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnControlar = new System.Windows.Forms.Button();
            this.btnReparar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(776, 351);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnControlar
            // 
            this.btnControlar.Location = new System.Drawing.Point(44, 393);
            this.btnControlar.Name = "btnControlar";
            this.btnControlar.Size = new System.Drawing.Size(195, 37);
            this.btnControlar.TabIndex = 1;
            this.btnControlar.Text = "Controlar";
            this.btnControlar.UseVisualStyleBackColor = true;
            this.btnControlar.Click += new System.EventHandler(this.btnControlar_Click);
            // 
            // btnReparar
            // 
            this.btnReparar.Location = new System.Drawing.Point(300, 393);
            this.btnReparar.Name = "btnReparar";
            this.btnReparar.Size = new System.Drawing.Size(197, 37);
            this.btnReparar.TabIndex = 2;
            this.btnReparar.Text = "Reparar";
            this.btnReparar.UseVisualStyleBackColor = true;
            this.btnReparar.Click += new System.EventHandler(this.btnReparar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(565, 393);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(181, 37);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmControlReparacionDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnReparar);
            this.Controls.Add(this.btnControlar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmControlReparacionDV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control-Reparacion DVs";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnControlar;
        private System.Windows.Forms.Button btnReparar;
        private System.Windows.Forms.Button btnSalir;
    }
}