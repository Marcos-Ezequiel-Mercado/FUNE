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
    public partial class frmBitacora : Form
    {
        BitacoraAppService _bita;
        UsuarioAppService _usu;
        DataTable dt = new DataTable();
        public frmBitacora()
        {
            _bita= new BitacoraAppService();
            _usu = new UsuarioAppService();
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DateTime fechaDesde, fechaHasta;
           dataGridView1.DataSource =  _bita.GetAllWhitFilters(dateTimePicker1.Text, dateTimePicker2.Text, +
                                        Convert.ToInt16(comboBox1.SelectedValue), comboBox2.Text, radioButton1.Checked);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaDesde = dateTimePicker1.Value;
            dateTimePicker1.Value = fechaDesde;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = fechaDesde.ToShortDateString();
           // MessageBox.Show("la fecha es: " + fechaDesde.ToString("dd/MM/yyyy"));

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaHasta = dateTimePicker2.Value;
            dateTimePicker2.Value = fechaHasta;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = fechaHasta.ToShortDateString();
           // MessageBox.Show("la fecha es: " + fechaHasta.ToString("dd/MM/yyyy"));

        }

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            Set();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Set();
        }

        private void Set()
        {
            radioButton1.Checked = true;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "Seleccione";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "Seleccione";
            dataGridView1.DataSource = null;
            SetComboUsuarios();
            SetComboCriticidad();   
            
        } 
        private void SetComboUsuarios()
        {
            //comboBox1.Items.Clear();
            //comboBox1.Text="Seleccione usuario";
            var listUsuario = _usu.GetAll();
            List<Usuario> list = new List<Usuario>();
            foreach( var item in listUsuario )
            {
                Email email = new Email();
                Usuario usuario = new Usuario(email);
                //usuario. = item.Nombre_y_Apellido.ToString().Trim();
                usuario.Id = item.Id;
                list.Add(usuario);
            }
            comboBox1.DataSource=list;
            comboBox1.DisplayMember = "Nombre_y_Apellido";
            comboBox1.ValueMember = "Id";
        }
        private void SetComboCriticidad()
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "Seleccione criticidad";
            {
                comboBox2.Items.Add("Baja");
                comboBox2.Items.Add("Media");
                comboBox2.Items.Add("Alta");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
