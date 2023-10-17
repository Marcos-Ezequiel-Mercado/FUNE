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

namespace The_Hight_School_Of_Avellaneda_System
{
    public partial class FrmVistaDetalle : Form
    {

        private FichasService fichaService;

        public FrmVistaDetalle(Ficha ficha)
        {
            InitializeComponent();

            fichaService = new FichasService();

            lblId.Text = ficha.Id.ToString();
            lblTotal.Text = ficha.Total.ToString();
            txtNombre.Text = ficha.Nombre.ToString();
            txtApellido.Text = ficha.Apellido.ToString();
            txtSexo.Text = ficha.Sexo.ToString();
            txtEstudios.Text = ficha.Estudios.ToString();
            txtFechaNacimiento.Text = ficha.FechaDeNacimiento.ToString();
            txtFechaFallecimiento.Text = ficha.FechaDeFallecimiento.ToString();
            txtHoraFalle.Text = ficha.HoraDeFallecimiento.ToString();
            txtUbicacion.Text = ficha.Partido.ToString();
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
            txtdomicilio2.Text = ficha.Domicilio2.ToString();
            txtDocumento2.Text = ficha.Documento.ToString();
            txtGastos.Text = ficha.Gastos.ToString();
            txtUsuario.Text = ficha.Usuario.ToString();
            txtImporte.Text = ficha.Importe.ToString();
            txtObservacion.Text = ficha.Observacion.ToString();
            lblServre.Text = ficha.Servre.ToString();
            lblAtaud.Text = ficha.Ataud.ToString();
            lblMortaja.Text = ficha.Mortaja.ToString();
            lblFunebre.Text = ficha.Funebre.ToString();
            lblVelatorio.Text = ficha.Velatorio.ToString();
            lblMuertos.Text = ficha.Muertos.ToString();
            lblPesoNaci.Text = ficha.PesoNacer.ToString();
            lblPesoFalle.Text = ficha.PesoMorir.ToString();
            lblAzafata.Text = ficha.Azafata.ToString();
            lblLacayos.Text = ficha.Lacayos.ToString();
            lblPortac.Text = ficha.Portac.ToString();
            lblRemises.Text = ficha.Remises.ToString();
            lblAnuncios.Text = ficha.Anuncios.ToString();
            lblEmbarazos.Text = ficha.Embarazos.ToString();
            lblSitConyugal.Text = ficha.SitConyugal.ToString();
            lblTipoAtaud.Text = ficha.TipoAtaud.ToString();
            lblEdadMadre.Text = ficha.EdadMadre.ToString();
            lblVivos.Text = ficha.Vivos.ToString();
            lblFechaBaja.Text = ficha.FechaBaja.ToString();

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.activarTodosLosTextBox(this, true);
            this.btnGuardar.Enabled = true;
            this.btnEditar.Enabled = false;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Ficha ficha = this.crearFichaParaEditar();
            try {
                this.fichaService.editarFichaService(ficha);
            }
        catch { }
        }

        private Ficha crearFichaParaEditar()
        {
            Ficha ficha = new Ficha(
            Convert.ToInt32(lblId.Text),
            lblTotal.Text,
            txtNombre.Text,
            txtSexo.Text,
            txtFechaFallecimiento.Text,
            txtHoraFalle.Text,
            txtUbicacion.Text,
            txtFechaNacimiento.Text,
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
            lblEdadMadre.Text,
            lblEmbarazos.Text,
            lblSitConyugal.Text,
            lblVivos.Text,
            lblMuertos.Text,
            lblPesoNaci.Text,
            lblPesoFalle.Text,
            txtApellido.Text,
            txtdomicilio2.Text,
            txtCodigoPostal.Text,
            txtDocumento2.Text,
            txtObservacion.Text,
            lblAtaud.Text,
            lblMortaja.Text,
            lblFunebre.Text,
            lblVelatorio.Text,
            lblAzafata.Text,
            lblLacayos.Text,
            lblPortac.Text,
            lblRemises.Text,
            lblServre.Text,
            lblAnuncios.Text,
            txtBeneficios.Text,
            txtGastos.Text,
            txtImporte.Text,
            txtHoraInh.Text,
            txtFechaInh.Text,
            txtUsuario.Text,
            lblTipoAtaud.Text,
            lblFechaBaja.Text);

            return ficha;
        }
    }
}
