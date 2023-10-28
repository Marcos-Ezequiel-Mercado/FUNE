using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheHightSchoolOfAvellanedaSystem.Domain;
using TheHightSchoolOfAvellanedaSystem.Services;

namespace The_Hight_School_Of_Avellaneda_System
{
    public partial class FrmGrillaBusqueda : Form
    {
        private FichasService servicioDeBusqueda;
        private frmMain frmPrincipal;
        public FrmGrillaBusqueda(frmMain frmMain)
        {
            InitializeComponent();
            this.txtNombre.Focus();
            servicioDeBusqueda = new FichasService();
            lblCantResultados.Text = "0  fichas.";
            this.frmPrincipal = frmMain;
            btnBuscar.Enabled = false;


            this.KeyPreview = true;
            this.KeyDown += btnBuscar_KeyDown;
            this.KeyDown += button1_KeyDown;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Filtro filtro = this.crearObjetoFiltro();
            this.cargarGrilla(filtro);
        }

        public void cargarGrilla(Filtro filtro)
        {
            DataTable tablaDeDatos = servicioDeBusqueda.buscarConFiltro(filtro);

            if (tablaDeDatos != null)
            {
                dgvGrillaResultados.DataSource = tablaDeDatos;

                foreach (DataGridViewColumn column in dgvGrillaResultados.Columns)
                {
                    if (this.validarColumnaVisible(column.Name))
                    {
                        column.Visible = false;
                    }

                }
                this.lblCantResultados.Text = dgvGrillaResultados.RowCount.ToString() + "  fichas.";
                this.LimpiarTextBoxEnControles(this);
            }
        }

        private Filtro crearObjetoFiltro()
        {
            Filtro filtro = new Filtro();
            filtro.Nombre = txtNombre.Text;
            filtro.Responsable = txtResponsable.Text;
            filtro.FechaDeNacimiento = txtFallecimiento.Text;

            return filtro;
        }

        private Boolean validarColumnaVisible(String nombreColumna)
        {
            return  !nombreColumna.Equals("Nombre") &&
                    !nombreColumna.Equals("Sexo") &&
                    !nombreColumna.Equals("FechaDeNacimiento") &&
                    !nombreColumna.Equals("FechaDeFallecimiento") &&
                    !nombreColumna.Equals("HoraDeFallecimiento") &&
                    !nombreColumna.Equals("LugarDeFallecimiento") &&
                    !nombreColumna.Equals("Responsable") &&
                    !nombreColumna.Equals("Documento") &&
                    !nombreColumna.Equals("Cementerio");
        }

        private void LimpiarTextBoxEnControles(Control control)
        {
            foreach (Control childControl in control.Controls)
            {
                if (childControl is TextBox)
                {
                    TextBox textBox = (TextBox)childControl;
                    textBox.Text = string.Empty; // Limpiar el contenido del TextBox
                }
                else if (childControl.HasChildren)
                {
                    // Si el control actual tiene controles secundarios, recurrir para buscar TextBox anidados
                    LimpiarTextBoxEnControles(childControl);
                }
            }
        }

        private void dgvGrillaResultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvGrillaResultados.Rows.Count)
            {
                DataGridViewRow row = dgvGrillaResultados.Rows[e.RowIndex];

                Ficha resultado = this.crearResultadoDesdeUnRegistro(row);

                FrmVistaDetalle frmDetallesDeFicha = new FrmVistaDetalle(resultado ,frmPrincipal);
                frmPrincipal.Hide();
                frmDetallesDeFicha.ShowDialog();

            }
        }



        private Ficha crearResultadoDesdeUnRegistro(DataGridViewRow row)
        {

            Ficha resultado = new Ficha();

            PropertyInfo[] propiedades = this.getPropiedades<Ficha>();

            foreach (PropertyInfo propiedad in propiedades)
            {
                string nombrePropiedad = propiedad.Name;

                if (row.Cells[nombrePropiedad].Value != null)
                {
                    object valorCelda = row.Cells[nombrePropiedad].Value;
                    if (valorCelda != null)
                    {
                        object valorConvertido = Convert.ChangeType(valorCelda, propiedad.PropertyType);
                        propiedad.SetValue(resultado, valorConvertido);
                    }
                }
            }
            return resultado;
        }

        private PropertyInfo[] getPropiedades<T>()
        {
            DataTable dt = new DataTable();
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();
            return propertyInfos;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" || txtResponsable.Text != ""  ||  txtFallecimiento.Text != "")
            {
                btnBuscar.Enabled = true;
            }
            else
            {
                btnBuscar.Enabled = false;
            }
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" || txtResponsable.Text != "" || txtFallecimiento.Text != "" )
            {
                btnBuscar.Enabled = true;
            }
            else
            {
                btnBuscar.Enabled = false;
            }
        }

        private void txtFallecimiento_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" || txtResponsable.Text != "" || txtFallecimiento.Text != "" )
            {
                btnBuscar.Enabled = true;
            }
            else
            {
                btnBuscar.Enabled = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmPrincipal.volverAlHome();
        }

        private void btnBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Simula un clic en el botón cuando se presiona Enter
                btnBuscar.PerformClick();
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                // Simula un clic en el botón cuando se presiona Enter
                this.Close();
            }
        }
    }
}
