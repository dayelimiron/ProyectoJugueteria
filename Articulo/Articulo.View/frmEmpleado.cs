using Articulo.BusinessLogic;
using Articulo.Entities;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Articulo.View
{
    public partial class frmEmpleado : MetroForm
    {
        private List<Empleado> _listado;

        public frmEmpleado()
        {
            InitializeComponent();
        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            _listado = EmpleadoBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            Id = x.EmpleadoId,
                            Nombre = x.Nombre,
                            Apellido = x.Apellido,
                            Direccion = x.Direccion,
                            Dui = x.DUi,
                            Telefono = x.Telefono,
                            Cargo = x.Cargos.Nombre,
                            Estado = x.Estado.Nombre,
                            Usuario = x.Usuario.Email
                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            frmAgregarEmpleado frm = new frmAgregarEmpleado();
            frm.ShowDialog();
            UpdateGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                string nombre = dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                string apellido = dataGridView1.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
                string telefono = dataGridView1.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                string direccion = dataGridView1.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
                string dui = dataGridView1.Rows[e.RowIndex].Cells["Dui"].Value.ToString();

                Empleado entity = new Empleado()
                {
                    EmpleadoId = id,
                    Nombre = nombre,
                    Apellido = apellido,
                    Telefono = telefono,
                    Direccion = direccion,
                    DUi = dui
                };

                //Editar
                frmAgregarEmpleado frm = new frmAgregarEmpleado(entity);
                frm.ShowDialog();
                UpdateGrid();


            }
            if (dataGridView1.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                DialogResult dr = MessageBox.Show("Desea eliminar el registro actual?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (EmpleadoBL.Instance.Delete(id))
                    {
                        MessageBox.Show("Se elimino con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                UpdateGrid();

            }
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {

            _listado = EmpleadoBL.Instance.SellecALL();
            var busqueda = from x in _listado
                           select new
                           {
                               Id = x.EmpleadoId,
                               Nombre = x.Nombre,
                               Apellido = x.Apellido,
                               Direccion = x.Direccion,
                               Dui = x.DUi,
                               Telefono = x.Telefono,
                               Cargo = x.Cargos.Nombre,
                               Estado = x.Estado.Nombre,
                               Usuario = x.Usuario.Email
                           };
            var query = busqueda.Where(x => x.Nombre.ToLower().Contains(metroTextBox1.Text.ToLower())
                        || x.Apellido.ToLower().Contains(metroTextBox1.Text.ToLower())).ToList();

            dataGridView1.DataSource = query.ToList();
        }
    }
}