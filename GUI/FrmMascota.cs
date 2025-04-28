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
    public partial class FrmMascota : Form
    {
        private IService<Mascota> serviceMascota;
        private IService<Propietario> servicePropietario;
        private IService<Raza> serviceRaza;
        private IService<Especie> serviceEspecie;

        public FrmMascota()
        {
            InitializeComponent();
            serviceMascota = new MascotaService();
            servicePropietario = new PropietarioService();
            serviceRaza = new RazaService();
            serviceEspecie = new EspecieService();
        }

        private void FrmMascota_Load(object sender, EventArgs e)
        {
            CargarComboPropietarios();
            CargarComboEspecies();
            CargarComboRazas();
            CargarListaMascotas();
        }

        private void CargarListaMascotas()
        {
            lstMascotas.DataSource = serviceMascota.Consultar();
            lstMascotas.DisplayMember = "Nombre";
        }

        private void CargarComboPropietarios()
        {
            var listaPropietarios = servicePropietario.Consultar();
            cbPropietarios.DataSource = listaPropietarios;
            cbPropietarios.DisplayMember = "Nombre";
            cbPropietarios.ValueMember = "Id";
        }

        private void CargarComboEspecies()
        {
            var listaEspecies = serviceEspecie.Consultar();
            cbEspecies.DataSource = listaEspecies;
            cbEspecies.DisplayMember = "Nombre";
            cbEspecies.ValueMember = "Id";
        }

        private void CargarComboRazas()
        {
            if (cbEspecies.SelectedValue != null)
            {
                int especieId = (int)cbEspecies.SelectedValue;
                var listaRazas = ((RazaService)serviceRaza).ConsultarPorEspecie(especieId);
                cbRazas.DataSource = listaRazas;
                cbRazas.DisplayMember = "Nombre";
                cbRazas.ValueMember = "Id";
            }
        }

        private void cbEspecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboRazas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();

                Mascota mascota = new Mascota
                {
                    Id = int.Parse(txtId.Text),
                    Nombre = txtId.Text,
                    Edad = int.Parse(txtEdad.Text)
                };

                if (cbPropietarios.SelectedValue != null)
                {
                    int propietarioId = (int)cbPropietarios.SelectedValue;
                    mascota.AsignarPropietario(servicePropietario.BuscarId(propietarioId));
                }

                if (cbRazas.SelectedValue != null)
                {
                    int razaId = (int)cbRazas.SelectedValue;
                    mascota.AsignarRaza(serviceRaza.BuscarId(razaId));
                }

                Guardar(mascota);
                CargarListaMascotas();
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

            if (string.IsNullOrEmpty(txtEdad.Text))
            {
                throw new Exception("La edad es requerida");
            }

            if (cbPropietarios.SelectedValue == null)
            {
                throw new Exception("Debe seleccionar un propietario");
            }

            if (cbRazas.SelectedValue == null)
            {
                throw new Exception("Debe seleccionar una raza");
            }
        }

        private void Guardar(Mascota mascota)
        {
            var mensaje = serviceMascota.Guardar(mascota);
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
            txtEdad.Text = "";
            cbPropietarios.SelectedIndex = -1;
            cbEspecies.SelectedIndex = -1;
            cbRazas.SelectedIndex = -1;
            txtId.Focus();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            AbrirConsulta();
        }

        private void AbrirConsulta()
        {
            Form f = new FrmConsultaMascotas();
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
            var mascotaBuscada = serviceMascota.BuscarId(id);
            VerMascota(mascotaBuscada);
        }

        private void VerMascota(Mascota mascota)
        {
            if (mascota == null)
            {
                MessageBox.Show("No se encontró la mascota");
                return;
            }

            txtId.Text = mascota.Id.ToString();
            txtId.Text = mascota.Nombre;
            txtEdad.Text = mascota.Edad.ToString();

            if (mascota.Propietario != null)
            {
                cbPropietarios.SelectedValue = mascota.Propietario.Id;
            }

            if (mascota.Raza != null && mascota.Raza.Especie != null)
            {
                cbEspecies.SelectedValue = mascota.Raza.Especie.Id;
                CargarComboRazas();
                cbRazas.SelectedValue = mascota.Raza.Id;
            }
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void lstMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMascotas.SelectedItem != null)
            {
                Mascota selectedMascota = (Mascota)lstMascotas.SelectedItem;
                VerMascota(selectedMascota);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Debe seleccionar una mascota para eliminar");
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar esta mascota?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string mensaje = serviceMascota.Eliminar(int.Parse(txtId.Text));
                MessageBox.Show(mensaje);
                CargarListaMascotas();
                LimpiarCampos();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Debe seleccionar una mascota para ver su historial");
                return;
            }

            int mascotaId = int.Parse(txtId.Text);
            AbrirHistorialConsultas(mascotaId);
        }

        private void AbrirHistorialConsultas(int mascotaId)
        {
            FrmHistorialConsultas frm = new FrmHistorialConsultas(mascotaId);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}