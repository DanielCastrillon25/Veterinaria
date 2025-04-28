using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Propietario : BaseEntity
    {
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }

        public Propietario()
        {
        }

        public Propietario(int id, string nombre, string cedula, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Cedula = cedula;
            Telefono = telefono;
        }

        public override string ToString()
        {
            return $"{Id};{Nombre};{Cedula};{Telefono}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Propietario))
                return false;

            Propietario other = (Propietario)obj;
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}