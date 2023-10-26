using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheHightSchoolOfAvellanedaSystem.Domain;
using TheHightSchoolOfAvellanedaSystem.Services;

namespace The_Hight_School_Of_Avellaneda_System
{
    public partial class AgregarFicha : Form
    {
        private FichasService fichaService;
        private TheHightSchoolOfAvellanedaSystem.Domain.Usuario usuario;
        private frmMain frmMain;
        public AgregarFicha(frmMain frmMain)
        {
            InitializeComponent();
            btnGuardar.Enabled = false;
            this.fichaService = new FichasService();
            this.frmMain = frmMain;
            usuario = this.capturarUsuarioLogueado();
            //  lblUsuario.Text = Convert.ToString(usuario.Id) + " - " + usuario.nombre.ToString() + " " + usuario.apellido.ToString();

            this.KeyPreview = true;
            this.KeyDown += btnGuardar_KeyDown;
            this.KeyDown += button1_KeyDown;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Ficha ficha = createEntidadFicha();
                bool exito = this.fichaService.guardarFicha(ficha, usuario);
                if (exito)
                {
                    limpiarTodosLosTextBox(this);
                    DialogResult result = MessageBox.Show("Se creo la ficha con exito! ¿Deseas crear otra esta ficha?",
                        "Confirmación", 
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        frmMain.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al crear la ficha! detalle: " + ex.Message);
            }
           

        }

        private Ficha createEntidadFicha()
        {
            Ficha ficha = new Ficha();

            ficha.Nombre = txtNombre.Text;
            ficha.Documento = txtDocumento.Text;
            ficha.FechaDeNacimiento = dtpNacimiento.Value.ToShortDateString();
            ficha.Edad = txtEdad.Text;
            ficha.Sexo = cmbSexo.Text;
            ficha.Domicilio = txtDomicilio.Text;
            ficha.Partido = txtLocalidad.Text;
            ficha.Nacionalidad = txtNacionalidad.Text;
            ficha.Provincia = txtProvincia.Text;
            ficha.EstadoCivil = txtECivil.Text;
            ficha.Conyugue = txtConyuge.Text;
            ficha.Padre = txtPadre.Text;
            ficha.Madre = txtMadre.Text;
            ficha.Profesion = txtProfesion.Text;
            ficha.RegistroCivil = txtRegistroCivil.Text;
            ficha.CodigoPostal = txtCodigoPostal.Text;
            ficha.Responsable = txtResponsable.Text;
            ficha.DomicilioResponsable = txtdomicilio2.Text;
            ficha.DocumentoResponsable = txtDocumento2.Text;
            ficha.FechaDeFallecimiento = dtpFechaFalle.Value.ToShortDateString(); ;
            ficha.HoraDeFallecimiento = dtpHoraFalle.Value.ToShortTimeString();
            ficha.LugarDeFallecimiento = txtUbicacion.Text;
            ficha.Medico = txtMedico.Text;
            ficha.Diagnostico = txtDiagnostico.Text;
            ficha.Estudios = txtEstudios.Text;
            ficha.Importe = txtImporte.Text;
            ficha.FechaInh = dtpFechaInh.Value.ToShortDateString();
            ficha.HoraInh = dtpHoraInh.Value.ToShortDateString();
            ficha.Ataud = txtAtaud.Text;
            ficha.Cementerio = txtCementerio.Text;
            ficha.Beneficios = txtBeneficios.Text;
            ficha.Gastos = txtGastos.Text;
            ficha.Afin = txtAfin.Text;
            ficha.SitConyugal = txtSitConyugal.Text;
            ficha.Embarazos = txtEmbarazo.Text;
            ficha.EdadMadre = txtEdadMadre.Text;
            ficha.Vivos = txtVivos.Text;
            ficha.Muertos = txtMuertos.Text;
            ficha.PesoNacer = txtPesoNacer.Text;
            ficha.PesoMorir = txtPesoMorir.Text;

            return ficha;
        }

        private TheHightSchoolOfAvellanedaSystem.Domain.Usuario capturarUsuarioLogueado()
        {
            TheHightSchoolOfAvellanedaSystem.Domain.Usuario usuario = new TheHightSchoolOfAvellanedaSystem.Domain.Usuario();
            usuario.Id = ManejadorDeSesion.GetInstance.Session.Id;
            usuario.nombre = ManejadorDeSesion.GetInstance.Session.nombre;
            usuario.apellido = ManejadorDeSesion.GetInstance.Session.apellido;
            usuario.dni = ManejadorDeSesion.GetInstance.Session.dni;
            usuario.username = ManejadorDeSesion.GetInstance.Session.username;

            return usuario;

        }
        private void limpiarTodosLosTextBox(Control control)
        {
            foreach (Control childControl in control.Controls)
            {
                if (childControl is TextBox)
                {
                    TextBox textBox = (TextBox)childControl;
                    textBox.Text = "";
                }
                else if (childControl.HasChildren)
                {
                    limpiarTodosLosTextBox(childControl);
                }
            }
        }

        private void FrmCrearFicha_Load(object sender, EventArgs e)
        {
            //txtNombre.TextChanged += textboxChanged;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtDocumento.Text != "" && txtDomicilio.Text != "" && txtResponsable.Text != "")
            {
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtDocumento.Text != "" && txtDomicilio.Text != "" && txtResponsable.Text != "")
            {
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
        }

        private void txtDomicilio_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtDocumento.Text != "" && txtDomicilio.Text != "" && txtResponsable.Text != "")
            {
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
        }

        private void txtResponsable_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtDocumento.Text != "" && txtDomicilio.Text != "" && txtResponsable.Text != "")
            {
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.frmMain.volverAlHome();
        }

        private void btnGuardar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Simula un clic en el botón cuando se presiona Enter
                btnGuardar.PerformClick();
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {
            if (txtEdad.Text == "0")
            {
                lblSitConyugal.Visible = true;
                txtSitConyugal.Visible = true;
                lblEmbarazo.Visible = true;
                txtEmbarazo.Visible = true;
                lblVivos.Visible = true;
                txtVivos.Visible = true;
                lblMuertos.Visible = true;
                txtMuertos.Visible = true;
                lblPesoNacer.Visible = true;
                txtPesoNacer.Visible = true;
                lblPesoMorir.Visible = true;
                txtPesoMorir.Visible = true;
                lblEdadMadre.Visible = true;
                txtEdadMadre.Visible = true;
            }
            else
            {
                lblSitConyugal.Visible = false;
                txtSitConyugal.Visible = false;
                lblEmbarazo.Visible = false;
                txtEmbarazo.Visible = false;
                lblVivos.Visible = false;
                txtVivos.Visible = false;
                lblMuertos.Visible = false;
                txtMuertos.Visible = false;
                lblPesoNacer.Visible = false;
                txtPesoNacer.Visible = false;
                lblPesoMorir.Visible = false;
                txtPesoMorir.Visible = false;
                lblEdadMadre.Visible = false;
                txtEdadMadre.Visible = false;
            }
        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            // Obtiene la fecha actual
            DateTime fechaActual = DateTime.Today;

            // Calcula la edad restando el año de nacimiento al año actual
            int edad = fechaActual.Year - fechaNacimiento.Year;

            // Comprueba si el cumpleaños ya pasó este año
            if (fechaNacimiento > fechaActual.AddYears(-edad))
            {
                edad--;
            }

            return edad;
        }

        private void dtpNacimiento_ValueChanged(object sender, EventArgs e)
        {
            // Obtiene la fecha de nacimiento desde el DateTimePicker
            DateTime fechaNacimiento = dtpNacimiento.Value;

            // Calcula la edad
            int edad = CalcularEdad(fechaNacimiento);

            // Muestra la edad en el TextBox
            txtEdad.Text = edad.ToString();
        }
    }
}
