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
    public partial class FrmConsultaMascotasPorPropietario : Form
    {
        MascotaService serviceMascota;
        IService<Propietario> servicePropietario;
        private int propietarioId;

        public FrmConsultaMascotasPorPropietario(int propietarioId)
        {
            InitializeComponent();
            serviceMascota = new MascotaService();
            servicePropietario = new PropietarioService();
            this.propietarioId = propietarioId;
        }

        private void FrmConsultaMascotasPorPropietario_Load(object sender, EventArgs e)
        {
            CargarDatosPropietario();
            CargarMascotas();
        }

        private void CargarDatosPropietario()
        {
            var propietario = servicePropietario.BuscarId(propietarioId);
            if (propietario != null)
            {
                lblNombrePropietario.Text = propietario.Nombre;
                lblCedula.Text = propietario.Cedula;
                lblTelefono.Text = propietario.Telefono;
            }
        }

        private void CargarMascotas()
        {
            var listaMascotas = serviceMascota.ConsultarPorPropietario(propietarioId);
            List<MascotaDto> listaDtos = new List<MascotaDto>();

            foreach (var mascota in listaMascotas)
            {
                MascotaDto dto = new MascotaDto
                {
                    Id = mascota.Id,
                    Nombre = mascota.Nombre,
                    Edad = mascota.Edad,
                    RazaNombre = mascota.Raza?.Nombre,
                    EspecieNombre = mascota.Raza?.Especie?.Nombre
                };
                listaDtos.Add(dto);
            }

            dgvMascotas.DataSource = listaDtos;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
    }
}