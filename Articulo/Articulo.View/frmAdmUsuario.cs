using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Articulo.BusinessLogic;
using Articulo.Entities;
using MetroFramework.Forms;

namespace Articulo.View
{
    public partial class frmAdmUsuario : MetroForm
    {
        private List<Usuario> _listado;

        public frmAdmUsuario()
        {
            InitializeComponent();
        }

        private void frmAdmUsuario_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            _listado = UsuarioBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            Id = x.UsuarioId,
                            Correo = x.Email,
                            Clave = x.Password,
                            Rol = x.Roles.Nombre
                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            frmUsuarioNuevo frm = new frmUsuarioNuevo();
            frm.ShowDialog();
            UpdateGrid();
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            _listado = UsuarioBL.Instance.SellecALL();

            var busqueda = from x in _listado
                           select new
                           {
                               Id = x.UsuarioId,
                               Correo = x.Email,
                               Clave = x.Password,
                               Rol = x.Roles.Nombre
                           };
            var query = busqueda.Where(x => x.Correo.ToLower().Contains(metroTextBox1.Text.ToLower())).ToList();
            dataGridView1.DataSource = query;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                string correo = dataGridView1.Rows[e.RowIndex].Cells["Correo"].Value.ToString();
                string clave = dataGridView1.Rows[e.RowIndex].Cells["Clave"].Value.ToString();
              

                Usuario entity = new Usuario()
                {
                    UsuarioId = id,
                    Email = correo,
                    Password= clave
                  
                };

                //Editar
                frmUsuarioNuevo frm = new frmUsuarioNuevo(entity);
                frm.ShowDialog();
                UpdateGrid();


            }
            if (dataGridView1.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                DialogResult dr = MessageBox.Show("Desea eliminar el registro actual?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (UsuarioBL.Instance.Delete(id))
                    {
                        MessageBox.Show("Se elimino con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                UpdateGrid();

            }
        }
    }
}
