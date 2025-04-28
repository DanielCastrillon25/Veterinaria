using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI
{
    public partial class FrmPropietario : Form
    {
        private IService<Propietario> servicePropietario;

        public FrmPropietario()
        {
            InitializeComponent();
            servicePropietario = new PropietarioService();
        }

        private void FrmPropietario_Load(object sender, EventArgs e)
        {
            CargarListaPropietarios();
        }

        private void CargarListaPropietarios()
        {
            lstPropietarios.DataSource = servicePropietario.Consultar();
            lstPropietarios.DisplayMember = "Nombre";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();

                Propietario propietario = new Propietario
                {
                    Id = int.Parse(txtId.Text),
                    Nombre = txtNombre.Text,
                    Cedula = txtCedula.Text,
                    Telefono = txtTelefono.Text
                };

                Guardar(propietario);
                CargarListaPropietarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                throw new Exception("El ID es requerido");
            }

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                throw new Exception("El nombre es requerido");
            }

            if (string.IsNullOrEmpty(txtCedula.Text))
            {
                throw new Exception("La cédula es requerida");
            }

            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                throw new Exception("El teléfono es requerido");
            }
        }

        private void Guardar(Propietario propietario)
        {
            var mensaje = servicePropietario.Guardar(propietario);
            MessageBox.Show(mensaje);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtCedula.Text = "";
            txtTelefono.Text = "";
            txtId.Focus();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            AbrirConsulta();
        }

        private void AbrirConsulta()
        {
            Form f = new FrmConsultaPropietarios();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                Buscar(int.Parse(txtId.Text));
            }
        }

        private void Buscar(int id)
        {
            var propietarioBuscado = servicePropietario.BuscarId(id);
            VerPropietario(propietarioBuscado);
        }

        private void VerPropietario(Propietario propietario)
        {
            if (propietario == null)
            {
                MessageBox.Show("No se encontró el propietario");
                return;
            }

            txtId.Text = propietario.Id.ToString();
            txtNombre.Text = propietario.Nombre;
            txtCedula.Text = propietario.Cedula;
            txtTelefono.Text = propietario.Telefono;
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void lstPropietarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPropietarios.SelectedItem != null)
            {
                Propietario selectedPropietario = (Propietario)lstPropietarios.SelectedItem;
                VerPropietario(selectedPropietario);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Debe seleccionar un propietario para eliminar");
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este propietario?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string mensaje = servicePropietario.Eliminar(int.Parse(txtId.Text));
                MessageBox.Show(mensaje);
                CargarListaPropietarios();
                LimpiarCampos();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lstPropietarios_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}