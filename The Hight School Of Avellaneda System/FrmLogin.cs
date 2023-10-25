using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
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

            this.KeyPreview = true;
            this.KeyDown += BtnIngresar_KeyDown;
            this.KeyDown += FrmLogin_KeyDown;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                _login.Login(this.txtUsername.Text, this.txtPassword.Text);
                
                frmMain frm = new frmMain();
                this.Hide();
                frm.ShowDialog();               
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show(ex.Message);
                txtUsername.Text = "USUARIO";
                txtPassword.Text = "CONTRASEÑA";
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "USUARIO")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.LightGray;
            }
            
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "USUARIO";
                txtUsername.ForeColor = Color.DimGray;
            }

        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "CONTRASEÑA")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = true;
            }
            
        }


        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "CONTRASEÑA";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnIngresar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Simula un clic en el botón cuando se presiona Enter
                BtnIngresar.PerformClick();
            }
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                // Simula un clic en el botón cuando se presiona Enter
                this.Close();
            }
        }
    }
}
