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
using TheHightSchoolOfAvellanedaSystem.Services;

namespace The_Hight_School_Of_Avellaneda_System
{
    public partial class frmRestore : Form
    {
        public int usuarioEnSesion;
        RestoreAppService restore; 
        public frmRestore()/**/
        {
            restore = new RestoreAppService();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                MessageBoxIcon icon2 = MessageBoxIcon.Information;
                string title = "Funeraria";
                string msg = "¿Esta seguro que desea realizar la restauración del sistema?";
                string msg2 = "Restauración realizada de forma exitosa.";
                DialogResult result;
                result = MessageBox.Show(msg, title, buttons, icon);
                if (result == DialogResult.Yes)
                {
                    restore.RealizarRestore(txtUbicacion.Text);
                    result = MessageBox.Show(msg2, title, buttons2, icon2);
                    limpiar();
                }
                else
                {
                    limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Funeraria", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void limpiar()
        {
            txtUbicacion.Clear();
            button2.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            txtUbicacion.Text = dlg.FileName;
        }
    }
}
