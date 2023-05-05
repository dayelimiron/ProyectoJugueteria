using Articulo.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Articulo.BusinessLogic;

namespace Articulo.View
{
    public partial class frmCargo : MetroForm
    {
        private List<Cargo> _listado;

        public frmCargo()
        {
            InitializeComponent();
        }

        private void frmCargo_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            _listado = CargoBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            Id = x.CargoId,
                            Nombre = x.Nombre,
                            Estado = x.Estado.Nombre
                        };
            dataGridView1.DataSource = query.ToList();
        }


        private void metroLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            frmAgregarCargo frm = new frmAgregarCargo();
            frm.ShowDialog();
            UpdateGrid();
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            _listado = CargoBL.Instance.SellecALL();

            var busqueda = from x in _listado
                           select new
                           {
                               Id = x.CargoId,
                               Nombre = x.Nombre,
                               Estado = x.Estado.Nombre
                           };
            var query = busqueda.Where(x => x.Nombre.ToLower().Contains(metroTextBox1.Text.ToLower())).ToList();
            dataGridView1.DataSource = query;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                string nombre = dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

                Cargo entity = new Cargo()
                {
                    CargoId = id,
                    Nombre = nombre
                };

                //Editar
                frmAgregarCargo frm = new frmAgregarCargo(entity);
                frm.ShowDialog();
                UpdateGrid();


            }
            if (dataGridView1.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                DialogResult dr = MessageBox.Show("Desea eliminar el registro actual?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (CargoBL.Instance.Delete(id))
                    {
                        MessageBox.Show("Se elimino con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                UpdateGrid();
            }

        }


    }
}
