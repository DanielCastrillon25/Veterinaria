using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITY;

namespace BLL
{
    public class PropietarioService : IService<Propietario>
    {
        private readonly PropietarioRepository repoPropietario;

        public PropietarioService()
        {
            repoPropietario = new PropietarioRepository(Archivos.ARC_PROPIETARIO);
        }

        public List<Propietario> Consultar()
        {
            return repoPropietario.Consultar();
        }

        public string Guardar(Propietario entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el propietario no puede ser nulo");
                }

                // Validar que no exista otro propietario con la misma cédula
                var propietarioExistente = repoPropietario.BuscarPorCedula(entity.Cedula);
                if (propietarioExistente != null && propietarioExistente.Id != entity.Id)
                {
                    return $"Error: Ya existe un propietario con la cédula {entity.Cedula}";
                }

                return repoPropietario.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar propietario: {ex.Message}";
            }
        }

        public string Modificar(Propietario entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el propietario no puede ser nulo");
                }

                // Validar que no exista otro propietario con la misma cédula
                var propietarioExistente = repoPropietario.BuscarPorCedula(entity.Cedula);
                if (propietarioExistente != null && propietarioExistente.Id != entity.Id)
                {
                    return $"Error: Ya existe un propietario con la cédula {entity.Cedula}";
                }

                return repoPropietario.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar propietario: {ex.Message}";
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

                return repoPropietario.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar propietario: {ex.Message}";
            }
        }

        public Propietario BuscarId(int id)
        {
            return Consultar().FirstOrDefault(x => x.Id == id);
        }

        public Propietario BuscarPorCedula(string cedula)
        {
            return repoPropietario.BuscarPorCedula(cedula);
        }
    }
}