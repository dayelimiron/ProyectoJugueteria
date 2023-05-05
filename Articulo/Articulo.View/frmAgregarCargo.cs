using Articulo.BusinessLogic;
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

namespace Articulo.View
{
    public partial class frmAgregarCargo : Form
    {
        int id;
        public frmAgregarCargo()
        {
            InitializeComponent();
        }
        public frmAgregarCargo(Cargo entity)
        {
            InitializeComponent();
            id = entity.CargoId;
            metroTextBox1.Text = entity.Nombre;


        }
        private void frmAgregarCargo_Load(object sender, EventArgs e)
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


            Cargo entity = new Cargo()
            {
                Nombre = metroTextBox1.Text.Trim(),
                EstadoId = (int)metroComboBox1.SelectedValue

            };
            if (id > 0)
            {
                entity.CargoId = id;
                if (CargoBL.Instance.Update(entity))
                {
                    MessageBox.Show("Se Modifico con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                if (CargoBL.Instance.Insert(entity))
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

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
