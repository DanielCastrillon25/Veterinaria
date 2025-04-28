using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class ConsultaVeterinariaDto
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public string NombreMascota { get; set; }
        public string NombreVeterinario { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
    }
}