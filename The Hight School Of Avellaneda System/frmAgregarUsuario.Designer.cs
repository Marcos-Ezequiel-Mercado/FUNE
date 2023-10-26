namespace The_Hight_School_Of_Avellaneda_System
{
    partial class frmAgregarUsuario
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblCodigoPostal = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.grpBxDatosPersonales = new System.Windows.Forms.GroupBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.grpBxDireccion = new System.Windows.Forms.GroupBox();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.grpBxContacto = new System.Windows.Forms.GroupBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.grpBxInfoUsuario = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFamilia = new System.Windows.Forms.ComboBox();
            this.cmbIdioma = new System.Windows.Forms.ComboBox();
            this.lblIdioma = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtcontrasenia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpBxDatosPersonales.SuspendLayout();
            this.grpBxDireccion.SuspendLayout();
            this.grpBxContacto.SuspendLayout();
            this.grpBxInfoUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(7, 450);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(312, 37);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(4, 26);
            this.lblDni.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(35, 13);
            this.lblDni.TabIndex = 1;
            this.lblDni.Text = "D.N.I:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(3, 49);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(4, 74);
            this.lblApellido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 3;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(4, 21);
            this.lblCalle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(33, 13);
            this.lblCalle.TabIndex = 4;
            this.lblCalle.Text = "Calle:";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(3, 49);
            this.lblNumero.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(47, 13);
            this.lblNumero.TabIndex = 5;
            this.lblNumero.Text = "Numero:";
            // 
            // lblCodigoPostal
            // 
            this.lblCodigoPostal.AutoSize = true;
            this.lblCodigoPostal.Location = new System.Drawing.Point(4, 75);
            this.lblCodigoPostal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodigoPostal.Name = "lblCodigoPostal";
            this.lblCodigoPostal.Size = new System.Drawing.Size(75, 13);
            this.lblCodigoPostal.TabIndex = 6;
            this.lblCodigoPostal.Text = "Código Postal:";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(4, 100);
            this.lblLocalidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(56, 13);
            this.lblLocalidad.TabIndex = 7;
            this.lblLocalidad.Text = "Localidad:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(3, 22);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 13);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "E-Mail:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(3, 44);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 9;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new System.Drawing.Point(4, 23);
            this.lblNombreUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblNombreUsuario.TabIndex = 10;
            this.lblNombreUsuario.Text = "Usuario:";
            this.lblNombreUsuario.Click += new System.EventHandler(this.lblNombreUsuario_Click);
            // 
            // grpBxDatosPersonales
            // 
            this.grpBxDatosPersonales.Controls.Add(this.txtDNI);
            this.grpBxDatosPersonales.Controls.Add(this.txtNombre);
            this.grpBxDatosPersonales.Controls.Add(this.txtApellido);
            this.grpBxDatosPersonales.Controls.Add(this.lblDni);
            this.grpBxDatosPersonales.Controls.Add(this.lblNombre);
            this.grpBxDatosPersonales.Controls.Add(this.lblApellido);
            this.grpBxDatosPersonales.Location = new System.Drawing.Point(8, 5);
            this.grpBxDatosPersonales.Margin = new System.Windows.Forms.Padding(2);
            this.grpBxDatosPersonales.Name = "grpBxDatosPersonales";
            this.grpBxDatosPersonales.Padding = new System.Windows.Forms.Padding(2);
            this.grpBxDatosPersonales.Size = new System.Drawing.Size(312, 94);
            this.grpBxDatosPersonales.TabIndex = 11;
            this.grpBxDatosPersonales.TabStop = false;
            this.grpBxDatosPersonales.Text = "Datos Personales";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(88, 22);
            this.txtDNI.Margin = new System.Windows.Forms.Padding(2);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(216, 20);
            this.txtDNI.TabIndex = 12;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(88, 46);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(216, 20);
            this.txtNombre.TabIndex = 13;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(88, 70);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(2);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(216, 20);
            this.txtApellido.TabIndex = 14;
            // 
            // grpBxDireccion
            // 
            this.grpBxDireccion.Controls.Add(this.cmbLocalidad);
            this.grpBxDireccion.Controls.Add(this.txtCodigoPostal);
            this.grpBxDireccion.Controls.Add(this.txtNumero);
            this.grpBxDireccion.Controls.Add(this.txtCalle);
            this.grpBxDireccion.Controls.Add(this.lblCalle);
            this.grpBxDireccion.Controls.Add(this.lblNumero);
            this.grpBxDireccion.Controls.Add(this.lblCodigoPostal);
            this.grpBxDireccion.Controls.Add(this.lblLocalidad);
            this.grpBxDireccion.Location = new System.Drawing.Point(8, 104);
            this.grpBxDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.grpBxDireccion.Name = "grpBxDireccion";
            this.grpBxDireccion.Padding = new System.Windows.Forms.Padding(2);
            this.grpBxDireccion.Size = new System.Drawing.Size(312, 121);
            this.grpBxDireccion.TabIndex = 15;
            this.grpBxDireccion.TabStop = false;
            this.grpBxDireccion.Text = "Dirección";
            this.grpBxDireccion.Enter += new System.EventHandler(this.grpBxDireccion_Enter);
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(88, 95);
            this.cmbLocalidad.Margin = new System.Windows.Forms.Padding(2);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(216, 21);
            this.cmbLocalidad.TabIndex = 16;
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(88, 71);
            this.txtCodigoPostal.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(216, 20);
            this.txtCodigoPostal.TabIndex = 10;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(88, 45);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(216, 20);
            this.txtNumero.TabIndex = 9;
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(88, 18);
            this.txtCalle.Margin = new System.Windows.Forms.Padding(2);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(216, 20);
            this.txtCalle.TabIndex = 8;
            // 
            // grpBxContacto
            // 
            this.grpBxContacto.Controls.Add(this.txtTelefono);
            this.grpBxContacto.Controls.Add(this.txtEmail);
            this.grpBxContacto.Controls.Add(this.lblEmail);
            this.grpBxContacto.Controls.Add(this.lblTelefono);
            this.grpBxContacto.Location = new System.Drawing.Point(8, 231);
            this.grpBxContacto.Margin = new System.Windows.Forms.Padding(2);
            this.grpBxContacto.Name = "grpBxContacto";
            this.grpBxContacto.Padding = new System.Windows.Forms.Padding(2);
            this.grpBxContacto.Size = new System.Drawing.Size(312, 65);
            this.grpBxContacto.TabIndex = 16;
            this.grpBxContacto.TabStop = false;
            this.grpBxContacto.Text = "Datos de Contacto";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(88, 42);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(216, 20);
            this.txtTelefono.TabIndex = 11;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(88, 16);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(216, 20);
            this.txtEmail.TabIndex = 10;
            // 
            // grpBxInfoUsuario
            // 
            this.grpBxInfoUsuario.Controls.Add(this.label1);
            this.grpBxInfoUsuario.Controls.Add(this.cmbFamilia);
            this.grpBxInfoUsuario.Controls.Add(this.cmbIdioma);
            this.grpBxInfoUsuario.Controls.Add(this.lblIdioma);
            this.grpBxInfoUsuario.Controls.Add(this.txtUsuario);
            this.grpBxInfoUsuario.Controls.Add(this.lblNombreUsuario);
            this.grpBxInfoUsuario.Location = new System.Drawing.Point(8, 300);
            this.grpBxInfoUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.grpBxInfoUsuario.Name = "grpBxInfoUsuario";
            this.grpBxInfoUsuario.Padding = new System.Windows.Forms.Padding(2);
            this.grpBxInfoUsuario.Size = new System.Drawing.Size(312, 101);
            this.grpBxInfoUsuario.TabIndex = 17;
            this.grpBxInfoUsuario.TabStop = false;
            this.grpBxInfoUsuario.Text = "Información de Usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Familia";
            // 
            // cmbFamilia
            // 
            this.cmbFamilia.FormattingEnabled = true;
            this.cmbFamilia.Location = new System.Drawing.Point(88, 73);
            this.cmbFamilia.Name = "cmbFamilia";
            this.cmbFamilia.Size = new System.Drawing.Size(216, 21);
            this.cmbFamilia.TabIndex = 16;
            // 
            // cmbIdioma
            // 
            this.cmbIdioma.FormattingEnabled = true;
            this.cmbIdioma.Location = new System.Drawing.Point(88, 47);
            this.cmbIdioma.Margin = new System.Windows.Forms.Padding(2);
            this.cmbIdioma.Name = "cmbIdioma";
            this.cmbIdioma.Size = new System.Drawing.Size(216, 21);
            this.cmbIdioma.TabIndex = 15;
            // 
            // lblIdioma
            // 
            this.lblIdioma.AutoSize = true;
            this.lblIdioma.Location = new System.Drawing.Point(7, 50);
            this.lblIdioma.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdioma.Name = "lblIdioma";
            this.lblIdioma.Size = new System.Drawing.Size(41, 13);
            this.lblIdioma.TabIndex = 14;
            this.lblIdioma.Text = "Idioma:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(88, 20);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(216, 20);
            this.txtUsuario.TabIndex = 12;
            // 
            // txtcontrasenia
            // 
            this.txtcontrasenia.Location = new System.Drawing.Point(96, 405);
            this.txtcontrasenia.Margin = new System.Windows.Forms.Padding(2);
            this.txtcontrasenia.Name = "txtcontrasenia";
            this.txtcontrasenia.Size = new System.Drawing.Size(216, 20);
            this.txtcontrasenia.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 408);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Password:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // frmAgregarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 516);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtcontrasenia);
            this.Controls.Add(this.grpBxInfoUsuario);
            this.Controls.Add(this.grpBxContacto);
            this.Controls.Add(this.grpBxDireccion);
            this.Controls.Add(this.grpBxDatosPersonales);
            this.Controls.Add(this.btnGuardar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAgregarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Usuario";
            this.Load += new System.EventHandler(this.frmAgregarUsuario_Load);
            this.grpBxDatosPersonales.ResumeLayout(false);
            this.grpBxDatosPersonales.PerformLayout();
            this.grpBxDireccion.ResumeLayout(false);
            this.grpBxDireccion.PerformLayout();
            this.grpBxContacto.ResumeLayout(false);
            this.grpBxContacto.PerformLayout();
            this.grpBxInfoUsuario.ResumeLayout(false);
            this.grpBxInfoUsuario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblCodigoPostal;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.GroupBox grpBxDatosPersonales;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.GroupBox grpBxDireccion;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.ComboBox cmbLocalidad;
        private System.Windows.Forms.GroupBox grpBxContacto;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.GroupBox grpBxInfoUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.ComboBox cmbIdioma;
        private System.Windows.Forms.Label lblIdioma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFamilia;
        private System.Windows.Forms.TextBox txtcontrasenia;
        private System.Windows.Forms.Label label2;
    }
}