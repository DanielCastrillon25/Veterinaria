using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class MascotaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string NombrePropietario { get; set; }
        public string RazaNombre { get; set; }
        public string EspecieNombre { get; set; }
    }
}