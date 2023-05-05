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
using MetroFramework.Forms;


namespace Articulo.View
{
    public partial class frmUsuario : MetroForm
    {
        public frmUsuario()
        {
            InitializeComponent();
        }

        //metodo creadomanualmente

        public void frm_closing(object sender, FormClosingEventArgs e)
        {
            metroTextBox1.Text = "";
            metroTextBox2.Text = "";

            this.Show();


        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            string usuario = metroTextBox1.Text.Trim();
            string password = metroTextBox2.Text.Trim();



            Usuario entity = UsuarioBL.Instance.Login(usuario, password);
            if (entity.Email != null || entity.Password !=null)
            {
                //ok
                MessageBox.Show("Bienvenido " + entity.Email);
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
                frm.FormClosing += frm_closing;

            }
            else
            {
                MessageBox.Show("Usuario y Password son incorrectos , vuelva a intentar!!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
