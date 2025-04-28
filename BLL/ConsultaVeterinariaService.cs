using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITY;

namespace BLL
{
    public class ConsultaVeterinariaService : IService<ConsultaVeterinaria>
    {
        private readonly ConsultaVeterinariaRepository repoConsulta;

        public ConsultaVeterinariaService()
        {
            repoConsulta = new ConsultaVeterinariaRepository(Archivos.ARC_CONSULTA);
        }

        public List<ConsultaVeterinaria> Consultar()
        {
            return repoConsulta.Consultar();
        }

        public List<ConsultaVeterinariaDto> ConsultarDTO()
        {
            return repoConsulta.ConsultarDTO();
        }

        public string Guardar(ConsultaVeterinaria entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la consulta no puede ser nula");
                }

                if (entity.Mascota == null)
                {
                    throw new NullReferenceException("Error... la mascota de la consulta no puede ser nula");
                }

                if (entity.Veterinario == null)
                {
                    throw new NullReferenceException("Error... el veterinario de la consulta no puede ser nulo");
                }

                return repoConsulta.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar consulta: {ex.Message}";
            }
        }

        public string Modificar(ConsultaVeterinaria entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la consulta no puede ser nula");
                }

                if (entity.Mascota == null)
                {
                    throw new NullReferenceException("Error... la mascota de la consulta no puede ser nula");
                }

                if (entity.Veterinario == null)
                {
                    throw new NullReferenceException("Error... el veterinario de la consulta no puede ser nulo");
                }

                return repoConsulta.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar consulta: {ex.Message}";
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

                return repoConsulta.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar consulta: {ex.Message}";
            }
        }

        public ConsultaVeterinaria BuscarId(int id)
        {
            return Consultar().FirstOrDefault(x => x.Id == id);
        }

        public List<ConsultaVeterinaria> ConsultarPorMascota(int mascotaId)
        {
            return repoConsulta.ConsultarPorMascota(mascotaId);
        }
    }
}