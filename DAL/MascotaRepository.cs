using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace DAL
{
    public class MascotaRepository : FileRepository<Mascota>
    {
        private PropietarioRepository propietarioRepository;
        private RazaRepository razaRepository;

        public MascotaRepository(string ruta) : base(ruta)
        {
            propietarioRepository = new PropietarioRepository(Archivos.ARC_PROPIETARIO);
            razaRepository = new RazaRepository(Archivos.ARC_RAZA);
        }

        public override List<Mascota> Consultar()
        {
            try
            {
                List<Mascota> lista = new List<Mascota>();

                if (File.Exists(ruta))
                {
                    StreamReader sr = new StreamReader(ruta);
                    while (!sr.EndOfStream)
                    {
                        lista.Add(Mappear(sr.ReadLine()));
                    }
                    sr.Close();
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override Mascota Mappear(string datos)
        {
            string[] campos = datos.Split(';');
            Mascota mascota = new Mascota();
            mascota.Id = int.Parse(campos[0]);
            mascota.Nombre = campos[1];
            mascota.Edad = int.Parse(campos[2]);

            int propietarioId = int.Parse(campos[3]);
            int razaId = int.Parse(campos[4]);

            Propietario propietario = propietarioRepository.Consultar().FirstOrDefault(p => p.Id == propietarioId);
            Raza raza = razaRepository.Consultar().FirstOrDefault(r => r.Id == razaId);

            if (propietario != null)
            {
                mascota.AsignarPropietario(propietario);
            }

            if (raza != null)
            {
                mascota.AsignarRaza(raza);
            }

            return mascota;
        }

        public List<Mascota> ConsultarPorPropietario(int propietarioId)
        {
            return Consultar().Where(m => m.Propietario != null && m.Propietario.Id == propietarioId).ToList();
        }

        public List<MascotaDto> ConsultarDTO()
        {
            List<MascotaDto> listaDto = new List<MascotaDto>();
            foreach (var mascota in Consultar())
            {
                MascotaDto dto = new MascotaDto
                {
                    Id = mascota.Id,
                    Nombre = mascota.Nombre,
                    Edad = mascota.Edad,
                    NombrePropietario = mascota.Propietario?.Nombre,
                    RazaNombre = mascota.Raza?.Nombre,
                    EspecieNombre = mascota.Raza?.Especie?.Nombre
                };
                listaDto.Add(dto);
            }
            return listaDto;
        }
    }
}