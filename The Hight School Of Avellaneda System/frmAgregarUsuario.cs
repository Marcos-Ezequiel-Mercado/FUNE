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
    public partial class frmAgregarUsuario : Form
    {
        public int usuarioEnSesion;
        public long usuarioEnSesionDNI;
        IdiomaAppService _idioma;
        FamiliaAppService _familia;
        LocalidadAppService _localidad;
        UsuarioAppService _usuario;
        public frmAgregarUsuario()
        {
            _idioma = new IdiomaAppService();
            _familia = new FamiliaAppService();
            _localidad = new LocalidadAppService();
            _usuario = new UsuarioAppService();
            InitializeComponent();
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
        private void setComboFamilias()
        {
            var listFamilias = _familia.GetAll();
            List<Familia> list = new List<Familia>();
            foreach (var item in listFamilias)
            {
                Familia familia = new Familia();
                familia.Id = item.Id;
                familia.nombre = item.nombre.ToString();
                list.Add(familia);
            }
            //cmbIdioma.Text = "Seleccione Idioma";
            cmbFamilia.DataSource = list;
            cmbFamilia.DisplayMember = "nombre";
            cmbFamilia.ValueMember = "Id";
            cmbFamilia.Text = "Seleccione Familia";
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    string msg = "¿Esta seguro que desea dar de alta al siguiente Usuario? \n\nDatos Personales: \nDNI: " + txtDNI.Text + "\nNombre: " + txtNombre.Text + "\nApellido: " + txtApellido.Text +
                                 "\n\nDirección: \nCalle: " + txtCalle.Text + "\nNumero: " + txtNumero.Text + "\nCódigo Postal: " + txtCodigoPostal.Text 
                                 + "\nLocalidad: " + cmbLocalidad.Text +
                                 "\n\nDatos de Contacto: \nE-Mail: " + txtEmail.Text + "\nTelefono: " + txtTelefono.Text +
                                 "\n\nInformación de Usuario: \nUsuario: " + txtUsuario.Text + "\nIdioma: " + cmbIdioma.Text + "\nFamilia: " + cmbFamilia.Text +
                                 "?";
                    string msg2 = "Usuario insertado de forma exitosa.";
                    DialogResult result;
                    result = MessageBox.Show(msg, title, buttons, icon);
                    if (result == DialogResult.Yes)
                    {
                        _usuario.usuarioInsert(txtDNI.Text, txtNombre.Text, txtApellido.Text, txtCalle.Text, txtNumero.Text, txtCodigoPostal.Text, 
                                               Convert.ToString(cmbLocalidad.SelectedValue), txtEmail.Text, txtTelefono.Text, txtUsuario.Text, 
                                               Convert.ToString(cmbIdioma.SelectedValue), Convert.ToString(cmbFamilia.SelectedValue),usuarioEnSesion, usuarioEnSesionDNI,txtcontrasenia.Text);
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

        private void grpBxDireccion_Enter(object sender, EventArgs e)
        {

        }

        private void lblNombreUsuario_Click(object sender, EventArgs e)
        {

        }

        private void frmAgregarUsuario_Load(object sender, EventArgs e)
        {
            setComboLocalidades();
            setComboIdiomas();
            setComboFamilias();
            txtDNI.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
