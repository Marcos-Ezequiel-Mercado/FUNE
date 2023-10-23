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
        private FrmGrillaBusqueda frmGrillaBusqueda;

        public FrmVistaDetalle(Ficha ficha, FrmGrillaBusqueda frmGrillaBusqueda)
        {

            this.frmGrillaBusqueda = frmGrillaBusqueda;
            this.fichaService = new FichasService();

            InitializeComponent();            

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
                    activarTodosLosTextBox(childControl,enabled);
                }
            }
        }
      
        private void FrmVistaDetalle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Filtro filtro = new Filtro();

            if (txtNombre.Text != null)
            {
                filtro.nombre = txtNombre.Text;
            }
            else
            {
                filtro.nombre = "";
            }
            if (txtPadre.Text != null)
            {
                filtro.padre = txtPadre.Text;
            }
            else
            {
                filtro.padre = "";
            }
            if (txtMadre.Text != null)
            {
                filtro.madre = txtMadre.Text;
            }
            else
            {
                filtro.madre = "";
            }
            if (txtDomicilio.Text != null)
            {
                filtro.domicilio = txtDomicilio.Text;
            }
            else
            {
                filtro.domicilio = "";
            }
            if (txtConyuge.Text != null)
            {
                filtro.conyuge = txtConyuge.Text;
            }
            else
            {
                filtro.conyuge = "";
            }
            if (txtDocumento.Text != null)
            {
                filtro.documento = txtDocumento.Text;
            }
            else
            {
                filtro.documento = "";
            }
            if (txtFechaNaci.Text != null)
            {
                filtro.fechaDeNacimiento = txtFechaNaci.Text;
            }
            else
            {
                filtro.fechaDeNacimiento = "";
            }

            this.frmGrillaBusqueda.cargarGrilla(filtro);

            this.frmGrillaBusqueda.Show();

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
    }
}
