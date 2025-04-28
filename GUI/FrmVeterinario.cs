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
    public partial class FrmVeterinario : Form
    {
        private IService<Veterinario> serviceVeterinario;

        public FrmVeterinario()
        {
            InitializeComponent();
            serviceVeterinario = new VeterinarioService();
        }

        private void FrmVeterinario_Load(object sender, EventArgs e)
        {
            CargarListaVeterinarios();
        }

        private void CargarListaVeterinarios()
        {
            lstVeterinarios.DataSource = serviceVeterinario.Consultar();
            lstVeterinarios.DisplayMember = "Nombre";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();

                Veterinario veterinario = new Veterinario
                {
                    Id = int.Parse(txtId.Text),
                    Nombre = txtId.Text,
                    Especialidad = txtEspecialidad.Text
                };

                Guardar(veterinario);
                CargarListaVeterinarios();
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

            if (string.IsNullOrEmpty(txtId.Text))
            {
                throw new Exception("El nombre es requerido");
            }

            if (string.IsNullOrEmpty(txtEspecialidad.Text))
            {
                throw new Exception("La especialidad es requerida");
            }
        }

        private void Guardar(Veterinario veterinario)
        {
            var mensaje = serviceVeterinario.Guardar(veterinario);
            MessageBox.Show(mensaje);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtId.Text = "";
            txtEspecialidad.Text = "";
            txtId.Focus();
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
            var veterinarioBuscado = serviceVeterinario.BuscarId(id);
            VerVeterinario(veterinarioBuscado);
        }

        private void VerVeterinario(Veterinario veterinario)
        {
            if (veterinario == null)
            {
                MessageBox.Show("No se encontró el veterinario");
                return;
            }

            txtId.Text = veterinario.Id.ToString();
            txtId.Text = veterinario.Nombre;
            txtEspecialidad.Text = veterinario.Especialidad;
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void lstVeterinarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVeterinarios.SelectedItem != null)
            {
                Veterinario selectedVeterinario = (Veterinario)lstVeterinarios.SelectedItem;
                VerVeterinario(selectedVeterinario);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Debe seleccionar un veterinario para eliminar");
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este veterinario?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string mensaje = serviceVeterinario.Eliminar(int.Parse(txtId.Text));
                MessageBox.Show(mensaje);
                CargarListaVeterinarios();
                LimpiarCampos();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}