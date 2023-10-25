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
    public partial class frmHistorico : Form
    {
        private FichasService fichaservicio;

        public frmHistorico(string idRegistro)
        {
            InitializeComponent();
            fichaservicio = new FichasService();


            cargarGrilla(idRegistro);
        }

        private void frmHistorico_Load(object sender, EventArgs e)
        {
            
        }
        public void cargarGrilla(string idRegistro)
        {
            DataTable tablaDeDatos = fichaservicio.vistaHistorico(idRegistro);

            if (tablaDeDatos != null)
            {
                dgvGrillaResultados.DataSource = tablaDeDatos;

                //foreach (DataGridViewColumn column in dgvGrillaResultados.Columns)
                //{
                //    if (this.validarColumnaVisible(column.Name))
                //    {
                //        column.Visible = false;
                //    }

                //}
               
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
