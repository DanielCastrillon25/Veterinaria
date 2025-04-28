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
    public partial class FrmConsultaPropietarios : Form
    {
        IService<Propietario> servicePropietario;

        public FrmConsultaPropietarios()
        {
            InitializeComponent();
            servicePropietario = new PropietarioService();
        }

        private void FrmConsultaPropietarios_Load(object sender, EventArgs e)
        {
            CargarPropietarios();
        }

        private void CargarPropietarios()
        {
            var lista = servicePropietario.Consultar();
            dgvPropietarios.DataSource = lista;
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
                CargarPropietarios();
                return;
            }

            var lista = servicePropietario.Consultar();
            string filtro = txtFiltro.Text.ToLower();

            var resultado = lista.Where(p =>
                p.Nombre.ToLower().Contains(filtro) ||
                p.Cedula.ToLower().Contains(filtro) ||
                p.Telefono.ToLower().Contains(filtro)
            ).ToList();

            dgvPropietarios.DataSource = resultado;
        }

        private void btnCargarMascotas_Click(object sender, EventArgs e)
        {
            if (dgvPropietarios.CurrentRow != null)
            {
                int propietarioId = (int)dgvPropietarios.CurrentRow.Cells["Id"].Value;
                AbrirConsultaMascotas(propietarioId);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un propietario");
            }
        }

        private void AbrirConsultaMascotas(int propietarioId)
        {
            FrmConsultaMascotasPorPropietario frm = new FrmConsultaMascotasPorPropietario(propietarioId);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}