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

        public FrmGrillaBusqueda()
        {
            InitializeComponent();
            servicioDeBusqueda = new FichasService();
        }

        // boton buscar.
        private void button1_Click(object sender, EventArgs e)
        {

            Filtro filtro = this.crearObjetoFiltro();

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
            
                this.LimpiarTextBoxEnControles(this);
            }         

        }

        private Filtro crearObjetoFiltro()
        {
            Filtro filtro = new Filtro();
            filtro.nombre = txtNombre.Text;
            filtro.madre = txtMadre.Text;
            filtro.padre = txtPadre.Text;
            filtro.conyuge = txtConyugue.Text;
            filtro.documento = txtDocumento.Text;
            filtro.fechaDeNacimiento = txtFallecimiento.Text;
            filtro.domicilio = txtDomicilio.Text;

            return filtro;
        }

        private Boolean validarColumnaVisible(String nombreColumna)
        {
            return  !nombreColumna.Equals("Nombre") &&
                    !nombreColumna.Equals("Sexo") &&
                    !nombreColumna.Equals("FechaDeNacimiento") &&
                    !nombreColumna.Equals("Hora") &&
                    !nombreColumna.Equals("Padre") &&
                    !nombreColumna.Equals("Madre") &&
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

                    FrmVistaDetalle frmDetallesDeFicha = new FrmVistaDetalle(resultado);
                    // con esta line se carga la grilla una ves cerrado el formulario vistadetalle.
                    frmDetallesDeFicha.FormClosed += cargar_grilla_reg_ant;
                    
                    frmDetallesDeFicha.Show();
                }
        }
        //============
        // nuevo Matias.
        /*llamo el metodo cargar grilla para que cuando se cierra el formulario vista detalla
         se haga click en el boton busqueda para cargar la grilla.*/
        private void cargar_grilla_reg_ant(Object sender, FormClosedEventArgs e)
        {
            btnBuscar.PerformClick();
        }
        //==============
        private void FrmDetallesDeFicha_FormClosed(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
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
    }
}
