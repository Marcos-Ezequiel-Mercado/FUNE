using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheHightSchoolOfAvellanedaSystem.AplicationService;
using TheHightSchoolOfAvellanedaSystem.Domain;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace The_Hight_School_Of_Avellaneda_System
{
    public partial class frmBackup : Form
    {
        public int usuarioEnSesion;

        BackupAppService _backup; 
        public frmBackup()
        {
            _backup = new BackupAppService();
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowDialog();
            txtDestino.Text = fb.SelectedPath;
        }

        private void limpiar()
        {
            txtDestino.Clear();
            button2.Focus();
        } 
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                MessageBoxIcon icon2 = MessageBoxIcon.Information;
                string title = "The Hight Schools Of Avellaneda System";
                string msg = "¿Esta seguro que desea realizar la copia de seguridad?";
                string msg2 = "Copia de seguridad realizada de forma exitosa.";
                DialogResult result;
                result = MessageBox.Show(msg, title, buttons, icon);
                if (result == DialogResult.Yes)
                {
                    _backup.RealizarBU(txtDestino.Text);
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
                MessageBox.Show(ex.Message, "The Hight School Of Avellaneda System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
