using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class ConsultaVeterinaria : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public Mascota Mascota { get; private set; }
        public Veterinario Veterinario { get; private set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }

        public ConsultaVeterinaria()
        {
            Fecha = DateTime.Now;
        }

        public void AsignarMascota(Mascota mascota)
        {
            if (Mascota == null)
            {
                Mascota = mascota;
            }
        }

        public void AsignarVeterinario(Veterinario veterinario)
        {
            if (Veterinario == null)
            {
                Veterinario = veterinario;
            }
        }

        public override string ToString()
        {
            return $"{Id};{Fecha.ToString("yyyy-MM-dd")};{Mascota.Id};{Veterinario.Id};{Diagnostico};{Tratamiento}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ConsultaVeterinaria))
                return false;

            ConsultaVeterinaria other = (ConsultaVeterinaria)obj;
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}