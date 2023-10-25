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
    public partial class FrmVistaDetalle : Form
    {

        private FichasService fichaService;
        private frmMain main;

        public FrmVistaDetalle(Ficha ficha, frmMain main)
        {
            this.fichaService = new FichasService();
            this.main = main;

            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += btnGuardar_KeyDown;
            this.KeyDown += btnEditar_KeyDown;
            this.KeyDown += button1_KeyDown;

            lblId.Text = ficha.Id.ToString();       
            txtNombre.Text = ficha.Nombre.ToString();
            txtResponsable.Text = ficha.Responsable.ToString();
            txtSexo.Text = ficha.Sexo.ToString();
            txtEstudios.Text = ficha.Estudios.ToString();
            txtFechaNaci.Text = ficha.FechaDeNacimiento.ToString();
            txtFechaFalle.Text = ficha.FechaDeFallecimiento.ToString();
            txtHoraFalle.Text = ficha.HoraDeFallecimiento.ToString();
            txtUbicacion.Text = ficha.LugarDeFallecimiento.ToString();
            txtEdad.Text = ficha.Edad.ToString();
            txtECivil.Text = ficha.EstadoCivil.ToString();
            txtConyuge.Text = ficha.Conyugue.ToString();
            txtPadre.Text = ficha.Padre.ToString();
            txtMadre.Text = ficha.Madre.ToString();
            txtDomicilio.Text = ficha.Domicilio.ToString();
            txtLocalidad.Text = ficha.Partido.ToString();
            txtNacionalidad.Text = ficha.Nacionalidad.ToString();
            txtProvincia.Text = ficha.Provincia.ToString();
            txtDocumento.Text = ficha.Documento.ToString();
            txtProfesion.Text = ficha.Profesion.ToString();
            txtMedico.Text = ficha.Medico.ToString();
            txtDiagnostico.Text = ficha.Diagnostico.ToString();
            txtRegistroCivil.Text = ficha.RegistroCivil.ToString();
            txtCementerio.Text = ficha.Cementerio.ToString();
            txtHoraInh.Text = ficha.HoraInh.ToString();
            txtFechaInh.Text = ficha.FechaInh.ToString();
            txtBeneficios.Text = ficha.Beneficios.ToString();
            txtCodigoPostal.Text = ficha.CodigoPostal.ToString();
            txtdomicilio2.Text = ficha.DomicilioResponsable.ToString();
            txtDocumento2.Text = ficha.DocumentoResponsable.ToString();
            txtGastos.Text = ficha.Gastos.ToString();
            lblUsuario.Text = ficha.Usuario.ToString();
            txtImporte.Text = ficha.Importe.ToString();
            txtResponsable.Text = ficha.Responsable.ToString();

            this.activarTodosLosTextBox(this, false);
            btnGuardar.Enabled = false;
          
        }

        private void activarTodosLosTextBox(Control control, bool enabled)
        {
            foreach (Control childControl in control.Controls)
            {
                if (childControl is TextBox)
                {
                    TextBox textBox = (TextBox)childControl;
                    textBox.Enabled = enabled;
                }
                else if (childControl.HasChildren)
                {
                    activarTodosLosTextBox(childControl, enabled);
                }
            }
        }


        private Ficha crearFichaParaEditar()
        {
            Ficha ficha = new Ficha(
            Convert.ToInt32(lblId.Text),          
            txtNombre.Text,
           txtSexo.Text,
            txtFechaFalle.Text,
            txtHoraFalle.Text,
            txtUbicacion.Text,
            txtFechaNaci.Text,
            txtEdad.Text,
            txtEstudios.Text,
            txtECivil.Text,
            txtConyuge.Text,
            txtPadre.Text,
            txtMadre.Text,
            txtDomicilio.Text,
            txtLocalidad.Text,
            txtNacionalidad.Text,
            txtProvincia.Text,
            txtDocumento.Text,
            txtProfesion.Text,
            txtMedico.Text,
            txtDiagnostico.Text,
            txtRegistroCivil.Text,
            txtCementerio.Text,
            txtdomicilio2.Text,
            txtCodigoPostal.Text,
            txtDocumento2.Text,  
            txtBeneficios.Text,
            txtGastos.Text,
            txtHoraInh.Text,
            txtFechaInh.Text,
            lblUsuario.Text,
            txtAtaud.Text,
            txtResponsable.Text);
            return ficha;
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            this.activarTodosLosTextBox(this, true);
            this.btnGuardar.Enabled = true;
            this.btnEditar.Enabled = false;
            this.btnEliminar.Enabled = false;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            Ficha ficha = this.crearFichaParaEditar();

            try
            {
                if (this.fichaService.editarFichaService(ficha))
                {
                    DialogResult result = MessageBox.Show("Se edito con exito! ¿Deseas seguir editando esta ficha?", "Confirmación", MessageBoxButtons.YesNo);

                    if (result == DialogResult.No)
                    {
                        this.Close();
                    }
                    else
                    {
                        btnGuardar.Enabled = false;
                        btnEditar.Enabled = true;
                        btnEliminar.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar la ficha. Error: " + ex.Message);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Desea seguir con la eliminacion de la ficha?", "Confirmación", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    this.fichaService.eliminarFicha(lblId.Text);
                    MessageBox.Show("Se elimino con exito!", "Confirmación", 0, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar la ficha. Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.main.Show();
            this.Close();
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                // Simula un clic en el botón cuando se presiona Enter
                this.main.Show();
                this.Close();
            }
        }

        private void btnGuardar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Simula un clic en el botón cuando se presiona Enter
                btnGuardar.PerformClick();
            }
        }

        private void btnEditar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Simula un clic en el botón cuando se presiona Enter
                btnEditar.PerformClick();
            }
        }
    }
}
