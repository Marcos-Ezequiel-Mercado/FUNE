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
    public partial class frmControlDeCambios : Form
    {
        public int usuarioEnSesion;
        public long usuarioEnSesionDNI;

        private DVAppService _dv;
        private ControlDeCambiosAppService _control;
        private UsuarioAppService _usuario;
        public frmControlDeCambios()
        {
            _dv = new DVAppService();
            _control= new ControlDeCambiosAppService();
            _usuario = new UsuarioAppService();
            InitializeComponent();
        }

        private void frmControlDeCambios_Load(object sender, EventArgs e)
        {
            setComboIdiomas();
        }

        private void setComboIdiomas()
        {
            var listDv = _dv.GetAll();
            List<Digitoverificador> list = new List<Digitoverificador>();
            foreach (var item in listDv)
            {
                Digitoverificador dv = new Digitoverificador();
                dv.Id = item.Id;
                dv.tabla = item.tabla.ToString();
                list.Add(dv);
            }
            cmbEntidad.DataSource = list;
            cmbEntidad.DisplayMember = "tabla";
            cmbEntidad.ValueMember = "Id";
            cmbEntidad.Text = "Seleccione Entidad";

        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbEntidad.SelectedIndex == 0) 
        //    {
                                
        //    }
        //    dataGridView1.DataSource = _control.GetAll();
        //    this.dataGridView1.Columns[1].Visible = false;
        //    //this.dataGridView1.Columns[3].Visible = false;
        //    this.dataGridView1.Columns[7].Visible = false;
        //    this.dataGridView1.Columns[8].Visible = false;

        //    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
        //    dataGridView1.Columns.Add(btn);
        //    btn.Text = "Revertir";
        //    btn.Name = "Revertir";
        //    btn.UseColumnTextForButtonValue = true;
        //}

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _control.FindByFilter(txtBuscar.Text, Convert.ToInt32(cmbEntidad.SelectedValue));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Revertir")
                {
                    //string state = Convert.ToString(EntityState.Modified);
                    
                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idFila"].Value.ToString());
                    Email email = new Email();
                    Usuario usuarioActual = new Usuario(email);
                    usuarioActual = _usuario.ObtenerUsuarioPorId(id);
                    _control.usuarioPreRevertir(usuarioActual, dataGridView1.CurrentRow.Cells[5].Value.ToString(), dataGridView1.CurrentRow.Cells[6].Value.ToString(), usuarioEnSesion, usuarioEnSesionDNI);
                    dataGridView1.DataSource = _control.FindByFilter(txtBuscar.Text, Convert.ToInt32(cmbEntidad.SelectedValue));
                }
            }
            catch (Exception ex) 
            {
                
                

            }
        }

        private void cmbEntidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _control.GetAll(Convert.ToInt32(cmbEntidad.SelectedValue));
            //this.dataGridView1.Columns[0].Visible = false;
            //this.dataGridView1.Columns[8].Visible = false;
            //this.dataGridView1.Columns[7].Visible = false;
            //this.dataGridView1.Columns[8].Visible = false;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.Text = "Revertir";
            btn.Name = "Revertir";
            btn.UseColumnTextForButtonValue = true;
        }
    }
}
