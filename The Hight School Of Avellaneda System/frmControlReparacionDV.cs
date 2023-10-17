using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheHightSchoolOfAvellanedaSystem.AplicationService;

namespace The_Hight_School_Of_Avellaneda_System
{
    public partial class frmControlReparacionDV : Form
    {
        DVAppService iniciador = new DVAppService();
        DataTable dt = new DataTable();

        public frmControlReparacionDV()
        {
            InitializeComponent();
        }

        private void btnControlar_Click(object sender, EventArgs e)
        {
            try
            {
                dt = iniciador.verificarCosistencia();
                dataGridView1.DataSource= dt;
            }
            catch (Exception ex)
            {
               dataGridView1.DataSource= null;
               MessageBox.Show(ex.Message, "The Hight School Of Avellaneda System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReparar_Click(object sender, EventArgs e)
        {
            try
            {
                DVAppService modificador = new DVAppService();
                modificador.UpdateDV(dt);
                MessageBox.Show("Se actualizaron correctamente los digitos verificadores", "The Hight School Of Avellaneda System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataGridView1.DataSource = null;
            }
            catch (Exception ex)
            {
                dataGridView1.DataSource = null;
                MessageBox.Show(ex.Message, "The Hight School Of Avellaneda System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }   
    }
}
