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
using Articulo.BusinessLogic;
using MetroFramework.Forms;

namespace Articulo.View
{
    public partial class frmAgregarEmpleado : MetroForm
    {
        int id;
        public frmAgregarEmpleado()
        {
            InitializeComponent();
        }

        public frmAgregarEmpleado(Empleado entity)
        {
            InitializeComponent();
            id = entity.EmpleadoId;
            metroTexboxNombre.Text = entity.Nombre;
            metroTextApellido.Text = entity.Apellido;
            metroTextDireccion.Text = entity.Direccion;
            metroTextTelefono.Text = entity.Telefono;
            metroTextDui.Text = entity.DUi;


        }
        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            UpdateComboEstado();
            UpdateComboUsuario();
            UpdateComboCargo();

        }

       
        private void UpdateComboEstado()
        {
            metroComboEstado.DisplayMember = "Nombre";
            metroComboEstado.ValueMember = "EstadoId";
            metroComboEstado.DataSource = EstadoBL.Instance.SellecALL();
        }

        private void UpdateComboUsuario()
        {
            metroComboUsuario.DisplayMember = "Email";
            metroComboUsuario.ValueMember = "UsuarioId";
            metroComboUsuario.DataSource = UsuarioBL.Instance.SellecALL();
        }
        private void UpdateComboCargo()
        {
            metroComboCargo.DisplayMember = "Nombre";
            metroComboCargo.ValueMember = "CargoId";
            metroComboCargo.DataSource = CargoBL.Instance.SellecALL();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();
            if (metroTexboxNombre.Text == "")
            {
                errorProvider1.SetError(metroTexboxNombre, "Campo obligatorio");
                return;
            }
            if (metroTextApellido.Text == "")
            {
                errorProvider1.SetError(metroTextApellido, "Campo obligatorio");
                return;
            }

            if (metroTextDireccion.Text == "")
            {
                errorProvider1.SetError(metroTextDireccion, "Campo obligatorio");
                return;
            }
            if (metroTextDui.Text == "")
            {
                errorProvider1.SetError(metroTextDui, "Campo obligatorio");
                return;
            }
            if (metroTextTelefono.Text == "")
            {
                errorProvider1.SetError(metroTextTelefono, "Campo obligatorio");
                return;
            }
            Empleado entity = new Empleado()
            {
                Nombre = metroTexboxNombre.Text.Trim(),
                Apellido = metroTextApellido.Text.Trim(),
                Direccion = metroTextDireccion.Text.Trim(),
                Telefono = metroTextTelefono.Text.Trim(),
                DUi = metroTextDui.Text.Trim(),
                EstadoId = (int)metroComboEstado.SelectedValue,
                CargoId = (int)metroComboCargo.SelectedValue,
                UsuarioId = (int)metroComboUsuario.SelectedValue



            };

            if (id > 0)
            {
                entity.EmpleadoId = id;
                if (EmpleadoBL.Instance.Update(entity))
                {
                    MessageBox.Show("Se Modifico con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                if (EmpleadoBL.Instance.Insert(entity))
                {
                    MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }



            }





            metroTexboxNombre.ResetText();
            metroTextApellido.ResetText();
            metroTextTelefono.ResetText();
            metroTextDireccion.ResetText();
            metroTextDui.ResetText();




        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
