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
    public partial class FrmLogin : Form
    {
        LoginAppService _login;


        public FrmLogin()
        {
            _login= new LoginAppService();
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                _login.Login(this.txtUsername.Text, this.txtPassword.Text);
                
                frmMain frm = new frmMain();                               
                frm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "The Hight School Of Avellaneda System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show(ex.Message);
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }
    }
}
