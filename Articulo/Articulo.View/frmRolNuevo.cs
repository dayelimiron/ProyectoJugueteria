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
    public partial class frmRolNuevo : MetroForm
    {
        int id;

        public frmRolNuevo()
        {
            InitializeComponent();
        }
        public frmRolNuevo(Rol entity)
        {
            InitializeComponent();
            id = entity.RolId;
            metroTextBox1.Text = entity.Nombre;
        }

        private void frmRolNuevo_Load(object sender, EventArgs e)
        {
            UpdateCombo();
        }
        private void UpdateCombo()
        {
            metroComboBox1.DisplayMember = "Nombre";
            metroComboBox1.ValueMember = "EstadoId";
            metroComboBox1.DataSource = EstadoBL.Instance.SellecALL();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (metroTextBox1.Text == "")
            {
                errorProvider1.SetError(metroTextBox1, "Campo obligatorio");
                return;
            }


            Rol entity = new Rol()
            {
                Nombre = metroTextBox1.Text.Trim(),
                EstadoId = (int)metroComboBox1.SelectedValue

            };
            if (id > 0)
            {
                entity.RolId = id;
                if (RolBL.Instance.Update(entity))
                {
                    MessageBox.Show("Se Modifico con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                if (RolBL.Instance.Insert(entity))
                {
                    MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }



            }

            metroTextBox1.ResetText();
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
