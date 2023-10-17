using System;
using System.Windows.Forms;
using TheHightSchoolOfAvellanedaSystem.AplicationService;
using TheHightSchoolOfAvellanedaSystem.Services;

namespace The_Hight_School_Of_Avellaneda_System
{
    public partial class frmMain : Form
    {
        //MODIFICADO
        UsuarioAppService _usuarios;
        LoginAppService _login;
        public int idUsuarioEnSesion;
        public long dniUsuarioEnSesion;

        private int childFormNumber = 0;

        public frmMain()
        {
            InitializeComponent();
          //  ValidarFormulario();
            _usuarios= new UsuarioAppService();
            _login = new LoginAppService();
        }


        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _login.Logout();
            ValidarFormulario();
        }

        private void buscarMenuItem_Click(object sender, EventArgs e)
        {
            FrmGrillaBusqueda frm = new FrmGrillaBusqueda();
            frm.MdiParent = this;
            frm.Show();
        }

        public void ValidarFormulario()
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
        }

        

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }


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

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           // ValidarFormulario();
        }


        public void validarPermisosMenu()
        {
            this.buscarToolStripMenuItem.Visible = ManejadorDeSesion.GetInstance.IsInRole(TipoPermiso.preceptoria);
            this.buscarToolStripMenuItem.Visible = ManejadorDeSesion.GetInstance.IsInRole(TipoPermiso.seguridad);

        }

     
    }

}
