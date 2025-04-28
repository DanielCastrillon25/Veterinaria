using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Mascota : NamedEntity
    {
        public int Edad { get; set; }
        public Propietario Propietario { get; private set; }
        public Raza Raza { get; private set; }

        public Mascota()
        {
        }

        public void AsignarPropietario(Propietario propietario)
        {
            if (Propietario == null)
            {
                Propietario = propietario;
            }
        }

        public void AsignarRaza(Raza raza)
        {
            if (Raza == null)
            {
                Raza = raza;
            }
        }

        public override string ToString()
        {
            return $"{Id};{Nombre};{Edad};{Propietario.Id};{Raza.Id}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Mascota))
                return false;

            Mascota other = (Mascota)obj;
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}