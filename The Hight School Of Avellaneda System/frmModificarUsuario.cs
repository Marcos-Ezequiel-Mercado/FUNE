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

namespace The_Hight_School_Of_Avellaneda_System
{
    public partial class frmModificarUsuario : Form
    {
        public int usuarioEnSesion;
        public long usuarioEnSesionDNI;
        public Usuario usuarioAnterior; 
        UsuarioAppService _usuario;
        IdiomaAppService _idioma;
        LocalidadAppService _localidad;
        public frmModificarUsuario()
        {
            _usuario = new UsuarioAppService();
            _idioma = new IdiomaAppService();
            _localidad = new LocalidadAppService();
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            {
                Email email = new Email();
                Usuario usuarioModificado = new Usuario(email);
                try
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                    MessageBoxIcon icon = MessageBoxIcon.Question;
                    MessageBoxIcon icon2 = MessageBoxIcon.Information;
                    string title = "The Hight Schools Of Avellaneda System";
                    string msg = "¿Esta seguro que desea modificar al Usuario con los siguientes datos? \n\nDatos Personales: \nDNI: " + txtDNI.Text + "\nNombre: " + txtNombre.Text + "\nApellido: " + txtApellido.Text +
                                 "\n\nDirección: \nCalle: " + txtCalle.Text + "\nNumero: " + txtNumero.Text + "\nCódigo Postal: " + txtCodigoPostal.Text
                                 + "\nLocalidad: " + cmbLocalidad.Text +
                                 "\n\nDatos de Contacto: \nE-Mail: " + txtEmail.Text + "\nTelefono: " + txtTelefono.Text +
                                 "\n\nInformación de Usuario: \nUsuario: " + txtUsuario.Text + "\nIdioma: " + cmbIdioma.Text +
                                 "?";
                    string msg2 = "Usuario modificado de forma exitosa.";
                    DialogResult result;
                    result = MessageBox.Show(msg, title, buttons, icon);
                    if (result == DialogResult.Yes)
                    {
                        //ACA DEBO INSTANCIAR EL NUEVO OBJETO CON LOS DATOS NUEVOS  
                        usuarioModificado.Id = usuarioAnterior.Id;
                        usuarioModificado.username = txtUsuario.Text;
                        usuarioModificado.password = usuarioAnterior.password;
                        usuarioModificado.cai = usuarioAnterior.cai;
                        usuarioModificado.estado = (int)EntityState.Modificado;
                        usuarioModificado.primerAcceso = usuarioAnterior.primerAcceso;
                        usuarioModificado.idIdioma = (int)cmbIdioma.SelectedValue;
                        usuarioModificado.dni = Convert.ToInt64(txtDNI.Text);
                        usuarioModificado.apellido = txtApellido.Text;
                        usuarioModificado.nombre = txtNombre.Text;
                        //LUEGO HAGO LA MODIFICACI{ON DE USUARIO
                        _usuario.updateUsuario(usuarioModificado, usuarioAnterior, usuarioEnSesion, usuarioEnSesionDNI);
                        //limpiar();
                        result = MessageBox.Show(msg2, title, buttons2, icon2);
                        this.Close();
                    }
                    else
                    {
                        //limpiar();
                        //panel1.Enabled = false;
                        //**btnNuevo.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "The Hight School Of Avellaneda System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //limpiar();
                    //panel1.Enabled = false;
                    //btnNuevo.Focus();
                }
            }
        }

        private void frmModificarUsuario_Load(object sender, EventArgs e)
        {
            setComboIdiomas();
            setComboLocalidades();
            txtDNI.Text = usuarioAnterior.dni.ToString();
            txtNombre.Text = usuarioAnterior.nombre.ToString();
            txtApellido.Text = usuarioAnterior.apellido.ToString();
            txtCalle.Text = "";
            txtNumero.Text = "";
            txtCodigoPostal.Text = "";
            //cmbLocalidad.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtUsuario.Text = usuarioAnterior.username.ToString();
            //if momentaneo hasta solucionar los temas de los dto
            if (usuarioAnterior.idIdioma == 1)
            { cmbIdioma.Text = "Español"; }
            else { cmbIdioma.Text = "Ingles"; }
            //fin if momentaneo hasta solucionar los temas de los dto
        }
        private void setComboIdiomas()
        {
            var listIdioma = _idioma.GetAll();
            List<Idioma> list = new List<Idioma>();
            foreach (var item in listIdioma)
            {
                Idioma idioma = new Idioma();
                idioma.Id = item.Id;
                idioma.descripcionIdioma = item.descripcionIdioma.ToString();
                list.Add(idioma);
            }
            //cmbIdioma.Text = "Seleccione Idioma";
            cmbIdioma.DataSource = list;
            cmbIdioma.DisplayMember = "descripcionIdioma";
            cmbIdioma.ValueMember = "Id";
            cmbIdioma.Text = "Seleccione Idioma";

        }

        private void setComboLocalidades()
        {
            var listLocalidad = _localidad.GetAll();
            List<Localidad> list = new List<Localidad>();
            foreach (var item in listLocalidad)
            {
                Localidad localidad = new Localidad();
                localidad.Id = item.Id;
                localidad.descripcion = item.descripcion.ToString();
                list.Add(localidad);
            }
            //cmbIdioma.Text = "Seleccione Idioma";
            cmbLocalidad.DataSource = list;
            cmbLocalidad.DisplayMember = "descripcion";
            cmbLocalidad.ValueMember = "Id";
            cmbLocalidad.Text = "Seleccione Localidad";

        }
    }
}
