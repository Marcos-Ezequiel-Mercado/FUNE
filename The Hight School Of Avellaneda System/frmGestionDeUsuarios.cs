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
using TheHightSchoolOfAvellanedaSystem.Domain;
using static System.Windows.Forms.AxHost;

namespace The_Hight_School_Of_Avellaneda_System
{
    public partial class frmGestionDeUsuarios : Form
    {
        public int usuarioEnSesion;
        public long usuarioEnSesionDNI;

        UsuarioAppService _usuario;
        Usuario _objUsuario;
        Email _email; 
        //private List<Usuario> Usuarios;
        public frmGestionDeUsuarios()
        {
            _usuario = new UsuarioAppService();
            _objUsuario = new Usuario();
            InitializeComponent();
            
        }
            
    
        
        private void panel1_Paint(object sender, PaintEventArgs e){}
        private void lblBusqueda_Click(object sender, EventArgs e){}

        private void frmGestionDeUsuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        private void ListarUsuarios()
        {
            try
            {
                dtGResultados.DataSource = _usuario.GetAllUsuarios();
                this.dtGResultados.Columns[0].Visible = false;
                ////this.dtGResultados.Columns[1].Visible = false;
                this.dtGResultados.Columns[2].Visible = false;
                this.dtGResultados.Columns[3].Visible = false;
                ////this.dtGResultados.Columns[4].Visible = false;
                this.dtGResultados.Columns[5].Visible = false;
                this.dtGResultados.Columns[7].Visible = false;
                this.dtGResultados.Columns[16].Visible = false;
                this.dtGResultados.Columns[17].Visible = false;




                int c = dtGResultados.Rows.Count;
                for (int i = 0; i < c; i++)
                {
                    if ((int)dtGResultados.Rows[i].Cells[4].Value == 3)
                    {
                        dtGResultados.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        //dtGResultados.Rows[i].DefaultCellStyle.BackColor = Color.Red;

                    }
                    //dtGResultados.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
                this.dtGResultados.CurrentCell = null;
                this.dtGResultados.Rows[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "The Hight School Of Avellaneda System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //this.Close();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dtGResultados.DataSource = _usuario.FindById(txtBuscar.Text);
        }

        public static int parentX, parentY;
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form modalBackground= new Form();
            using (frmAgregarUsuario modal = new frmAgregarUsuario())
            {
                modalBackground.StartPosition = FormStartPosition.CenterScreen;
                modalBackground.FormBorderStyle = FormBorderStyle.None;
                //modalBackground.WindowState= FormWindowState.Maximized;
                modalBackground.Opacity = .50d;
                modalBackground.BackColor = Color.Black;
                modalBackground.Size = this.Size;
                modalBackground.Location = this.Location;
                modalBackground.ShowInTaskbar = false;
                modalBackground.Show();
                modal.Owner = modalBackground;
                parentX = this.Location.X;
                parentY = this.Location.Y;
                modal.usuarioEnSesion = usuarioEnSesion;
                modal.usuarioEnSesionDNI = usuarioEnSesionDNI;
                modal.ShowDialog();
                modalBackground.Dispose();
                ListarUsuarios();
            }

        }
        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (dtGResultados.SelectedRows.Count > 0)
            {
                //Luego debo rellenar las propiedades del Email cuando me lo traiga de la base luego de hacer Join
                Email emailSeleccionado = new Email();
                //---------------
                Usuario usuarioSeleccionado = new Usuario(emailSeleccionado);
                usuarioSeleccionado.Id = (int)dtGResultados.CurrentRow.Cells[0].Value;
                usuarioSeleccionado.username = (string)dtGResultados.CurrentRow.Cells[1].Value;
                usuarioSeleccionado.password = (string)dtGResultados.CurrentRow.Cells[2].Value;
                usuarioSeleccionado.cai = (int)dtGResultados.CurrentRow.Cells[3].Value;
                usuarioSeleccionado.estado = (int)dtGResultados.CurrentRow.Cells[4].Value;
                usuarioSeleccionado.primerAcceso = (bool)dtGResultados.CurrentRow.Cells[5].Value;
                usuarioSeleccionado.idIdioma = (int)dtGResultados.CurrentRow.Cells[6].Value;
                usuarioSeleccionado.dvh = (int)dtGResultados.CurrentRow.Cells[7].Value;
                usuarioSeleccionado.dni = (long)dtGResultados.CurrentRow.Cells[8].Value;
                usuarioSeleccionado.apellido = (string)dtGResultados.CurrentRow.Cells[9].Value;
                usuarioSeleccionado.nombre = (string)dtGResultados.CurrentRow.Cells[10].Value;

                Form modalBackground = new Form();
                using (frmModificarUsuario modal = new frmModificarUsuario())
                {
                    modalBackground.StartPosition = FormStartPosition.CenterScreen;
                    modalBackground.FormBorderStyle = FormBorderStyle.None;
                    //modalBackground.WindowState= FormWindowState.Maximized;
                    modalBackground.Opacity = .50d;
                    modalBackground.BackColor = Color.Black;
                    modalBackground.Size = this.Size;
                    modalBackground.Location = this.Location;
                    modalBackground.ShowInTaskbar = false;
                    modalBackground.Show();
                    modal.Owner = modalBackground;
                    parentX = this.Location.X;
                    parentY = this.Location.Y;
                    modal.usuarioEnSesion = usuarioEnSesion;
                    modal.usuarioEnSesionDNI = usuarioEnSesionDNI;
                    modal.usuarioAnterior = usuarioSeleccionado;
                    modal.ShowDialog();
                    modalBackground.Dispose();
                    ListarUsuarios();
                }
            }
            else { MessageBox.Show("Por favor seleccione un usuario de la lista para editar.", "The Hight School Of Avellaneda System", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                    MessageBoxIcon icon = MessageBoxIcon.Question;
                    MessageBoxIcon icon2 = MessageBoxIcon.Information;
                    string title = "The Hight Schools Of Avellaneda System";
                    string msg = "¿Esta seguro que desea dar de alta a: "; //\n\nNombre de Usuario: " + txtNombreUsuario.Text + "\nNombre y Apellido: " + txtNombreyApellido.Text + "\nE-mail: " + txtEmail.Text + "\nIdioma: " + idioma + "?";
                    string msg2 = "Usuario insertado de forma exitosa.";
                    DialogResult result;
                    result = MessageBox.Show(msg, title, buttons, icon);
                    if (result == DialogResult.Yes)
                    {
                        //_usuario.usuarioInsert(txtNombreUsuario.Text, txtNombreyApellido.Text, txtEmail.Text, idioma, usuarioEnSesion, EntityState.Added);
                        limpiar();
                        result = MessageBox.Show(msg2, title, buttons2, icon2);
                        //panel1.Enabled = false;
                        btnNuevo.Focus();
                        //ListarUsuarios();
                        dtGResultados.DataSource = _usuario.FindById(txtBuscar.Text);
                    }
                    else
                    {
                        limpiar();
                        //panel1.Enabled = false;
                        btnNuevo.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "The Hight School Of Avellaneda System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                    //panel1.Enabled = false;
                    btnNuevo.Focus();
                }
            }
            //else if (_objUsuario.State == EntityState.Modified)
            {
                //MessageBox.Show("Vamos a editar");
                Email email = new Email();
                Email emailAnterior = new Email();
                Usuario usuario = new Usuario(email);
                Usuario usuarioAnterior = new Usuario(emailAnterior);
                string idioma = null;
                //if (rdbCastellano.Checked) { idioma = rdbCastellano.Text; }
                //else if (rdbIngles.Checked) { idioma = rdbIngles.Text; }
                try
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                    MessageBoxIcon icon = MessageBoxIcon.Question;
                    MessageBoxIcon icon2 = MessageBoxIcon.Information;
                    string title = "The Hight Schools Of Avellaneda System";
                    string msg = "¿Esta seguro que desea modificar los siguientes datos del usuario: "; // + txtNombreUsuario.Text + " \n\nNombre y Apellido: " + txtNombreyApellido.Text + "\nE-mail: " + txtEmail.Text + "\nIdioma: " + idioma + "?";
                    string msg2 = "Usuario modificado de forma exitosa.";
                    DialogResult result;
                    result = MessageBox.Show(msg, title, buttons, icon);
                    if (result == DialogResult.Yes)
                    {
                        //usuario.Username = txtNombreUsuario.Text;
                        usuarioAnterior.username = (string)dtGResultados.CurrentRow.Cells[0].Value;
                        usuario.password = (string)dtGResultados.CurrentRow.Cells[1].Value;
                        usuarioAnterior.password = (string)dtGResultados.CurrentRow.Cells[1].Value;
                        //usuario.Nombre_y_Apellido = txtNombreyApellido.Text;
                        //usuarioAnterior.Nombre_y_Apellido = (string)dtGResultados.CurrentRow.Cells[2].Value;
                        usuario.cai = (int)dtGResultados.CurrentRow.Cells[3].Value;
                        usuarioAnterior.cai = (int)dtGResultados.CurrentRow.Cells[3].Value;
                        usuario.dvh = (int)dtGResultados.CurrentRow.Cells[4].Value;
                        usuarioAnterior.dvh = (int)dtGResultados.CurrentRow.Cells[4].Value;
                        usuario.estado = (int)dtGResultados.CurrentRow.Cells[5].Value;
                        usuarioAnterior.estado = (int)dtGResultados.CurrentRow.Cells[5].Value;
                        //usuario.Email = txtEmail.Text;
                        //usuarioAnterior.Email = (string)dtGResultados.CurrentRow.Cells[6].Value;
                        usuario.primerAcceso = (bool)dtGResultados.CurrentRow.Cells[7].Value;
                        usuarioAnterior.primerAcceso = (bool)dtGResultados.CurrentRow.Cells[7].Value;
                        //usuario.State = EntityState.Modified;
                        //usuarioAnterior.State = EntityState.Modified;
                        usuario.Id = (int)dtGResultados.CurrentRow.Cells[9].Value;
                        usuarioAnterior.Id = (int)dtGResultados.CurrentRow.Cells[9].Value;
                        //_usuario.updateUsuario(usuario, usuarioEnSesion, usuarioAnterior, dniusuarioEnSesion);
                        //txtNombreUsuario.Enabled = true;
                        limpiar();
                        result = MessageBox.Show(msg2, title, buttons2, icon2);
                        //panel1.Enabled = false;
                        btnNuevo.Focus();
                        //ListarUsuarios();
                        dtGResultados.DataSource = _usuario.FindById(txtBuscar.Text);
                    }
                    else
                    {
                        //txtNombreUsuario.Enabled = true;
                        limpiar();
                        //panel1.Enabled = false;
                        btnNuevo.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "The Hight School Of Avellaneda System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                    //panel1.Enabled = false;
                    btnNuevo.Focus();
                }
            }
            //else if (_objUsuario.State == EntityState.Deleted)
            {

                Email email = new Email();
                Email emailAnterior = new Email();
                Usuario usuario = new Usuario(email);
                Usuario usuarioAnterior = new Usuario(emailAnterior);
                string idioma = null;
                //if (rdbCastellano.Checked) { idioma = rdbCastellano.Text; }
                //else if (rdbIngles.Checked) { idioma = rdbIngles.Text; }
                try
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                    MessageBoxIcon icon = MessageBoxIcon.Question;
                    MessageBoxIcon icon2 = MessageBoxIcon.Information;
                    string title = "The Hight Schools Of Avellaneda System";
                    string msg = "¿Esta seguro que desea anular al usuario: ";// + txtNombreyApellido.Text + "?";
                    string msg2 = "Usuario anulado de forma exitosa.";
                    DialogResult result;
                    result = MessageBox.Show(msg, title, buttons, icon);
                    if (result == DialogResult.Yes)
                    {
                        //usuario.Username = txtNombreUsuario.Text;
                        usuarioAnterior.username = (string)dtGResultados.CurrentRow.Cells[0].Value;
                        usuario.password = (string)dtGResultados.CurrentRow.Cells[1].Value;
                        usuarioAnterior.password = (string)dtGResultados.CurrentRow.Cells[1].Value;
                        //usuario.Nombre_y_Apellido = txtNombreyApellido.Text;
                        //usuarioAnterior.Nombre_y_Apellido = (string)dtGResultados.CurrentRow.Cells[2].Value;
                        usuario.cai = (int)dtGResultados.CurrentRow.Cells[3].Value;
                        usuarioAnterior.cai = (int)dtGResultados.CurrentRow.Cells[3].Value;
                        usuario.dvh = (int)dtGResultados.CurrentRow.Cells[4].Value;
                        usuarioAnterior.dvh = (int)dtGResultados.CurrentRow.Cells[4].Value;
                        usuario.estado = (int)dtGResultados.CurrentRow.Cells[5].Value;
                        usuarioAnterior.estado = (int)dtGResultados.CurrentRow.Cells[5].Value;
                        //usuario.Email = txtEmail.Text;
                        //usuarioAnterior.Email = (string)dtGResultados.CurrentRow.Cells[6].Value;
                        usuario.primerAcceso = (bool)dtGResultados.CurrentRow.Cells[7].Value;
                        usuarioAnterior.primerAcceso = (bool)dtGResultados.CurrentRow.Cells[7].Value;
                        //usuario.State = EntityState.Deleted;
                        //usuarioAnterior.State = EntityState.Deleted;
                        usuario.Id = (int)dtGResultados.CurrentRow.Cells[9].Value;
                        usuarioAnterior.Id = (int)dtGResultados.CurrentRow.Cells[9].Value;
                        //_usuario.updateUsuario(usuario, idioma, usuarioEnSesion, usuarioAnterior);
                        //txtNombreUsuario.Enabled = true;
                        //txtNombreyApellido.Enabled = true;
                        //txtEmail.Enabled = true;
                        //grpIdiomas.Enabled = true;
                        limpiar();
                        result = MessageBox.Show(msg2, title, buttons2, icon2);
                        //panel1.Enabled = false;
                        btnNuevo.Focus();
                        //ListarUsuarios();
                        dtGResultados.DataSource = _usuario.FindById(txtBuscar.Text);
                    }
                    else
                    {
                        //txtNombreUsuario.Enabled = true;
                        limpiar();
                        //txtNombreUsuario.Enabled = true;
                        //txtNombreyApellido.Enabled = true;
                        //txtEmail.Enabled = true;
                        //grpIdiomas.Enabled = true;
                        //panel1.Enabled = false;
                        btnNuevo.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "The Hight School Of Avellaneda System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                    //panel1.Enabled = false;
                    btnNuevo.Focus();
                }
            }



        }
        private void limpiar()
        {
            //txtNombreUsuario.Clear();
            //txtNombreyApellido.Clear();
            //txtEmail.Clear();
            //rdbIngles.Checked = false;
            //rdbCastellano.Checked = false;
        }

        

        private void btnAnular_Click(object sender, EventArgs e)
        {
            int idiomaInt;
            //panel1.Enabled = true;
            //_objUsuario.State = EntityState.Deleted;
            if (dtGResultados.SelectedRows.Count > 0)
            {
                //panel1.Enabled = true;
                //Usuario usuario = new Usuario();
                //txtNombreyApellido.Text = (string)dtGResultados.CurrentRow.Cells[2].Value;
                //txtNombreUsuario.Text = (string)dtGResultados.CurrentRow.Cells[0].Value;
                //txtEmail.Text = (string)dtGResultados.CurrentRow.Cells[6].Value;
                //txtNombreUsuario.Enabled = false;
                //txtNombreyApellido.Enabled = false;
                //txtEmail.Enabled = false;
                //grpIdiomas.Enabled = false;
                //idiomaInt = _usuario.usuarioSelectLaguage((int)dtGResultados.CurrentRow.Cells[8].Value);
                //if (idiomaInt == 1) { rdbCastellano.Checked = true; }
                //else { rdbIngles.Checked = true; }
            }
            else { MessageBox.Show("Por favor seleccione un usuario de la lista para editar.", "The Hight School Of Avellaneda System", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void dtGResultados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int c = dtGResultados.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                if ((int)dtGResultados.Rows[i].Cells[4].Value == 3)
                {
                    dtGResultados.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {

        }
    }
}
