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
        private Form currentFormChildren;

        public FrmVistaDetalle(Ficha ficha, frmMain main)
        {
            this.fichaService = new FichasService();
            this.main = main;

            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += btnGuardar_KeyDown;
            this.KeyDown += btnEditar_KeyDown;
            this.KeyDown += button1_KeyDown;

            this.cargarFormulario(ficha);

            this.activarTodosLosTextBox(this, false);
            btnGuardar.Enabled = false;
 
            btnEliminar.Enabled = ManejadorDeSesion.GetInstance.IsAdmin();        

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
            txtResponsable.Text,
            txtSitConyu.Text,
            txtTelResponsable.Text);

            ficha.FechaDeFallecimiento = txtFechaFalle.Text;
            ficha.HoraDeFallecimiento = txtHoraFalle.Text;
            ficha.FechaInh = txtFechaInh.Text;
            ficha.HoraInh = txtHoraInh.Text;
            ficha.Embarazos = txtEmbarazo.Text;
            ficha.EdadMadre = txtEdadMadre.Text;
            ficha.Vivos = txtVivos.Text;
            ficha.Muertos = txtMuertos.Text;

            ficha.PesoNacer = txtPesoNacer.Text;
            ficha.PesoMorir = txtPesoMorir.Text;

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
                    activarTodosLosTextBox(this,false);
                    DialogResult result = MessageBox.Show("Se edito con exito! ¿Deseas seguir editando esta ficha?", "Confirmación", MessageBoxButtons.YesNo);

                    if (result == DialogResult.No)
                    {
                        this.Close();
                        this.main.Show();
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
                    this.main.Show();
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
                // Simula un clic en el botón cuando se presiona Escape
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

        private void button2_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmHistorico(lblId.Text));
        }

        // nuevo Matias.
        public void abrirFormularioHijo(Form children)
        {
            if (currentFormChildren != null)
            {
                currentFormChildren.Close();
            }
            currentFormChildren = children;
            children.TopLevel = false;
            children.FormBorderStyle = FormBorderStyle.None;
            children.Dock = DockStyle.Fill;
            this.Controls.Add(children);
            //panelEscritrio.Tag = children;
            children.BringToFront();
            children.Show();
        }

        private void cargarFormulario(Ficha ficha)
        {
         
            if (ficha.Id != null) {
                lblId.Text = ficha.Id.ToString();
            }
            else
            {
                lblId.Text = "";
            }


            if (ficha.Nombre != null)
            {

                txtNombre.Text = ficha.Nombre.ToString();
            }
            else
            {
                txtNombre.Text = "";
            }


            if (ficha.Responsable != null)
            {
                txtResponsable.Text = ficha.Responsable.ToString();
            }
            else
            {
                txtResponsable.Text = "";
            }


            if (ficha.Sexo != null)
            {
                txtSexo.Text = ficha.Sexo.ToString();
            }
            else
            {
                txtSexo.Text = "";
            }


            if (ficha.Estudios != null)
            {
                txtEstudios.Text = ficha.Estudios.ToString();
            }
            else
            {
                txtEstudios.Text = "";
            }


            if (ficha.FechaDeNacimiento != null)
            {
                txtFechaNaci.Text = ficha.FechaDeNacimiento.ToString();
            }
            else
            {
                txtFechaNaci.Text = "";
            }


            if (ficha.FechaDeFallecimiento != null)
            {
                txtFechaFalle.Text = ficha.FechaDeFallecimiento.ToString();
            }
            else
            {
                txtFechaFalle.Text = "";
            }


            if (ficha.HoraDeFallecimiento != null)
            {
                txtHoraFalle.Text = ficha.HoraDeFallecimiento.ToString();
            }
            else
            {
                txtHoraFalle.Text = "";
            }


            if (ficha.LugarDeFallecimiento != null)
            {
                txtUbicacion.Text = ficha.LugarDeFallecimiento.ToString();
            }
            else
            {
                txtUbicacion.Text = "";
            }


            if (ficha.Edad != null)
            {
                txtEdad.Text = ficha.Edad.ToString();
            }
            else
            {
                txtEdad.Text = "";
            }


            if (ficha.EstadoCivil != null)
            {
                txtECivil.Text = ficha.EstadoCivil.ToString();
            }
            else
            {
                txtECivil.Text = "";
            }


            if (ficha.Conyugue != null)
            {
                txtConyuge.Text = ficha.Conyugue.ToString();
            }
            else
            {
                txtConyuge.Text = "";
            }


            if (ficha.Padre != null)
            {
                txtPadre.Text = ficha.Padre.ToString();
            }
            else
            {
                txtPadre.Text = "";
            }


            if (ficha.Madre != null)
            {
                txtMadre.Text = ficha.Madre.ToString();
            }
            else
            {
                txtMadre.Text = "";
            }


            if (ficha.Domicilio != null)
            {
                txtDomicilio.Text = ficha.Domicilio.ToString();
            }
            else
            {
                txtDomicilio.Text = "";
            }

            if (ficha.Partido != null)
            {
                txtLocalidad.Text = ficha.Partido.ToString();
            }
            else
            {
                txtLocalidad.Text = "";
            }

            if (ficha.Nacionalidad != null)
            {
                txtNacionalidad.Text = ficha.Nacionalidad.ToString();
            }
            else
            {
                txtNacionalidad.Text = "";
            }


            if (ficha.Provincia  != null)
            {
                txtProvincia.Text = ficha.Provincia.ToString();
            }
            else
            {
                txtProvincia.Text = "";
            }

            if (ficha.Documento != null)
            {
                txtDocumento.Text = ficha.Documento.ToString();
            }
            else
            {
                txtDocumento.Text = "";
            }


            if (ficha.Profesion != null)
            {
                txtProfesion.Text = ficha.Profesion.ToString();
            }
            else
            {
                txtProfesion.Text = "";
            }


            if (ficha.Medico != null)
            {
                txtMedico.Text = ficha.Medico.ToString();
            }
            else
            {
                txtMedico.Text = "";
            }


            if (ficha.Diagnostico != null)
            {
                txtDiagnostico.Text = ficha.Diagnostico.ToString();
            }
            else
            {
                txtDiagnostico.Text = "";
            }


            if (ficha.RegistroCivil != null)
            {
                txtRegistroCivil.Text = ficha.RegistroCivil.ToString();
            }
            else
            {
                txtRegistroCivil.Text = "";
            }


            if (ficha.Cementerio != null)
            {
                txtCementerio.Text = ficha.Cementerio.ToString();
            }
            else
            {
                txtCementerio.Text = "";
            }

            if (ficha.HoraInh != null)
            {
                txtHoraInh.Text = ficha.HoraInh.ToString();
            }
            else
            {
                txtHoraInh.Text = "";
            }


            if (ficha.FechaInh != null)
            {
                txtFechaInh.Text = ficha.FechaInh.ToString();
            }
            else
            {
                txtFechaInh.Text = "";
            }


            if (ficha.Beneficios != null)
            {
                txtBeneficios.Text = ficha.Beneficios.ToString();
            }
            else
            {
                txtBeneficios.Text = "";
            }



            if (ficha.CodigoPostal != null)
            {
                txtCodigoPostal.Text = ficha.CodigoPostal.ToString();
            }
            else
            {
                txtCodigoPostal.Text = "";
            }

            if (ficha.DomicilioResponsable != null)
            {
                txtdomicilio2.Text = ficha.DomicilioResponsable.ToString();
            }
            else
            {
                txtdomicilio2.Text = "";
            }


            if (ficha.DocumentoResponsable != null)
            {
                txtDocumento2.Text = ficha.DocumentoResponsable.ToString();
            }
            else
            {
                txtDocumento2.Text = "";
            }

            if (ficha.Gastos != null)
            {
                txtGastos.Text = ficha.Gastos.ToString();
            }
            else
            {
                txtGastos.Text = "";
            }


            if (ficha.Usuario != null)
            {
                lblUsuario.Text = ficha.Usuario.ToString();
            }
            else
            {
                lblUsuario.Text = "";
            }

            if (ficha.Importe != null)
            {
                txtImporte.Text = ficha.Importe.ToString();
            }
            else
            {
                txtImporte.Text = "";
            }


            if (ficha.Responsable != null)
            {
                txtResponsable.Text = ficha.Responsable.ToString();
            }
            else
            {
                txtResponsable.Text = "";
            }


            if (ficha.TelResponsable != null)
            {
                txtTelResponsable.Text = ficha.TelResponsable.ToString();
            }
            else
            {
                txtTelResponsable.Text = "";
            }

            if (ficha.Vivos != null)
            {
                txtVivos.Text = ficha.Vivos.ToString();
            }
            else
            {
                txtVivos.Text = "";
            }

            if (ficha.Muertos != null)
            {
                txtMuertos.Text = ficha.Muertos.ToString();
            }
            else
            {
                txtMuertos.Text = "";
            }
            if (ficha.EdadMadre != null)
            {
                txtEdadMadre.Text = ficha.EdadMadre.ToString();
            }
            else
            {
                txtEdadMadre.Text = "";
            }
            if (ficha.Embarazos != null)
            {
                txtEmbarazo.Text = ficha.Embarazos.ToString();
            }
            else
            {
                txtEmbarazo.Text = "";
            }
            if (ficha.PesoMorir != null)
            {
                txtPesoMorir.Text = ficha.PesoMorir.ToString();
            }
            else
            {
                txtPesoMorir.Text = "";
            }
            if (ficha.PesoNacer != null)
            {
                txtPesoNacer.Text = ficha.PesoNacer.ToString();
            }
            else
            {
                txtPesoNacer.Text = "";
            }
            if (ficha.SitConyugal != null)
            {
                txtSitConyu.Text = ficha.SitConyugal.ToString();
            }
            else
            {
                txtSitConyu.Text = "";
            }
        }
    }
}
