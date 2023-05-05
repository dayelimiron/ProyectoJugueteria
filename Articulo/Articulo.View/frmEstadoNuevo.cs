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
    public partial class frmEstadoNuevo : MetroForm
    {
        int id;

        public frmEstadoNuevo()
        {
            InitializeComponent();
        }
        public frmEstadoNuevo(Estado entity)
        {
            InitializeComponent();
            id = entity.EstadoId;
            metroTextBox1.Text = entity.Nombre;


        }
        private void frmEstadoNuevo_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (metroTextBox1.Text == "")
            {
                errorProvider1.SetError(metroTextBox1, "Campo obligatorio");
                return;
            }


            Estado entity = new Estado()
            {
                Nombre = metroTextBox1.Text.Trim(),

            };
            if (id > 0)
            {
                entity.EstadoId = id;
                if (EstadoBL.Instance.Update(entity))
                {
                    MessageBox.Show("Se Modifico con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                if (EstadoBL.Instance.Insert(entity))
                {
                    MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }



            }

            metroTextBox1.ResetText();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
