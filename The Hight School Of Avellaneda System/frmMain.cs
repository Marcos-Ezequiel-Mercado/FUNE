using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using FontAwesome.Sharp;
using TheHightSchoolOfAvellanedaSystem.AplicationService;
using TheHightSchoolOfAvellanedaSystem.Services;
using Color = System.Drawing.Color;

namespace The_Hight_School_Of_Avellaneda_System
{
    public partial class frmMain : Form
    {
        //MODIFICADO
        UsuarioAppService _usuarios;
        LoginAppService _login;

        public int idUsuarioEnSesion;
        public long dniUsuarioEnSesion;

        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentFormChildren;


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public frmMain()
        {
            InitializeComponent();
            this.leftBorderBtn = new Panel();
            this.leftBorderBtn.Size = new Size(7, 60);
            this.panelMenu.Controls.Add(this.leftBorderBtn);
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

          //  ValidarFormulario();
            _usuarios= new UsuarioAppService();
            _login = new LoginAppService();

            this.KeyPreview = true;
            this.KeyDown += frmMain_KeyDown;
            this.KeyDown += iconButton3_KeyDown;
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172,126,241);
            public static Color color2 = Color.FromArgb(249,118,176);
            public static Color color3 = Color.FromArgb(253,138,114);
            public static Color color4 = Color.FromArgb(95,77,221);
            public static Color color5 = Color.FromArgb(249,88,155);
            public static Color color6 = Color.FromArgb(24,161,251);
        }
        private void activeBotton(Object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                this.disabledButton();

                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.DarkSlateBlue;
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;

                //LEDT BORDER BUTTON
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0,currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //LBLICONHIJO
                iconFormularioHijoAActual.IconChar = currentBtn.IconChar;
                iconFormularioHijoAActual.IconColor = color;

            }
        }

        public void abrirFormularioHijo(Form children)
        {
            if (currentFormChildren != null)
            {
                currentFormChildren.Close();
            }
            currentFormChildren = children;
            children.TopLevel = false;
            children.FormBorderStyle = FormBorderStyle.None;
            children.Dock= DockStyle.Fill;
            panelEscritrio.Controls.Add(children);
            panelEscritrio.Tag = children;
            children.BringToFront();
            children.Show();
            lblIconoHijo.Text = children.Text;
        }

        private void disabledButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
      

     /*   public void ValidarFormulario()
        {
            if (!ManejadorDeSesion.GetInstance.IsLogged())
                this.toolStripStatusLabel.Text = "Por favor, inicie sesión.";
            else
            {
                this.validarPermisosMenu();
                this.toolStripStatusLabel.Text = "Usuario en sesión: " + ManejadorDeSesion.GetInstance.Session.username +
                                                 ".      Nombre y Apellido: " + ManejadorDeSesion.GetInstance.Session.nombre + 
                                                 " " + ManejadorDeSesion.GetInstance.Session.apellido;
                idUsuarioEnSesion = ManejadorDeSesion.GetInstance.Session.Id;
                dniUsuarioEnSesion = ManejadorDeSesion.GetInstance.Session.dni;
            }
            this.logoutToolStripMenuItem.Enabled = ManejadorDeSesion.GetInstance.IsLogged();
            this.buscarToolStripMenuItem.Enabled = ManejadorDeSesion.GetInstance.IsLogged();
        }*/

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

       /* private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }*/

        private void frmMain_Load(object sender, EventArgs e)
        {
           // ValidarFormulario();
        }


     /*   public void validarPermisosMenu()
        {
            this.buscarToolStripMenuItem.Visible = ManejadorDeSesion.GetInstance.IsInRole(TipoPermiso.preceptoria);
            this.buscarToolStripMenuItem.Visible = ManejadorDeSesion.GetInstance.IsInRole(TipoPermiso.seguridad);

        }*/

        private void crearFichaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarFicha frm = new AgregarFicha(this);
            frm.ShowDialog();
            this.Hide();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            activeBotton(sender, RGBColors.color1);
            abrirFormularioHijo(new AgregarFicha(this));
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            activeBotton(sender, RGBColors.color1);
            abrirFormularioHijo(new FrmGrillaBusqueda(this));
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            activeBotton(sender, RGBColors.color1);

            this.salir();
           
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.volverAlHome();
        }

        public void volverAlHome()
        {
            this.currentFormChildren.Close();
            this.disabledButton();
            leftBorderBtn.Visible = false;
            iconFormularioHijoAActual.IconChar = IconChar.Home;
            iconFormularioHijoAActual.IconColor = Color.MediumPurple;
            lblIconoHijo.Text = "HOME";
        }

        private void barraSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) 
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void salir()
        {
            DialogResult result = MessageBox.Show("¿Deseas salir de la aplicacion?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.KeyCode == Keys.O)
            {
                // Aquí, abre el formulario que desees
                frmAgregarUsuario form2 = new frmAgregarUsuario();
                form2.Show();
            }
        }

        private void iconButton3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.salir();
            }
        }

    }

}
