using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITY;

namespace BLL
{
    public class MascotaService : IService<Mascota>
    {
        private readonly MascotaRepository repoMascota;

        public MascotaService()
        {
            repoMascota = new MascotaRepository(Archivos.ARC_MASCOTA);
        }

        public List<Mascota> Consultar()
        {
            return repoMascota.Consultar();
        }

        public List<MascotaDto> ConsultarDTO()
        {
            return repoMascota.ConsultarDTO();
        }

        public string Guardar(Mascota entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la mascota no puede ser nula");
                }

                if (entity.Propietario == null)
                {
                    throw new NullReferenceException("Error... el propietario de la mascota no puede ser nulo");
                }

                if (entity.Raza == null)
                {
                    throw new NullReferenceException("Error... la raza de la mascota no puede ser nula");
                }

                return repoMascota.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar mascota: {ex.Message}";
            }
        }

        public string Modificar(Mascota entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la mascota no puede ser nula");
                }

                if (entity.Propietario == null)
                {
                    throw new NullReferenceException("Error... el propietario de la mascota no puede ser nulo");
                }

                if (entity.Raza == null)
                {
                    throw new NullReferenceException("Error... la raza de la mascota no puede ser nula");
                }

                return repoMascota.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar mascota: {ex.Message}";
            }
        }

        public string Eliminar(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Error... el id debe ser mayor a cero");
                }

                return repoMascota.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar mascota: {ex.Message}";
            }
        }

        public Mascota BuscarId(int id)
        {
            return Consultar().FirstOrDefault(x => x.Id == id);
        }

        public List<Mascota> ConsultarPorPropietario(int propietarioId)
        {
            return repoMascota.ConsultarPorPropietario(propietarioId);
        }
    }
}