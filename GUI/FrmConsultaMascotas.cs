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
    public partial class FrmConsultaMascotas : Form
    {
        MascotaService serviceMascota;

        public FrmConsultaMascotas()
        {
            InitializeComponent();
            serviceMascota = new MascotaService();
        }

        private void FrmConsultaMascotas_Load(object sender, EventArgs e)
        {
            CargarMascotas();
        }

        private void CargarMascotas()
        {
            var listaMascotas = serviceMascota.ConsultarDTO();
            dgvMascotas.DataSource = listaMascotas;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void FiltrarDatos()
        {
            if (string.IsNullOrEmpty(txtFiltro.Text))
            {
                CargarMascotas();
                return;
            }

            var lista = serviceMascota.ConsultarDTO();
            string filtro = txtFiltro.Text.ToLower();

            var resultado = lista.Where(m =>
                m.Nombre.ToLower().Contains(filtro) ||
                m.NombrePropietario.ToLower().Contains(filtro) ||
                m.RazaNombre.ToLower().Contains(filtro) ||
                m.EspecieNombre.ToLower().Contains(filtro)
            ).ToList();

            dgvMascotas.DataSource = resultado;
        }

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            if (dgvMascotas.CurrentRow != null)
            {
                int mascotaId = (int)dgvMascotas.CurrentRow.Cells["Id"].Value;
                AbrirHistorialConsultas(mascotaId);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una mascota");
            }
        }

        private void AbrirHistorialConsultas(int mascotaId)
        {
            FrmHistorialConsultas frm = new FrmHistorialConsultas(mascotaId);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}