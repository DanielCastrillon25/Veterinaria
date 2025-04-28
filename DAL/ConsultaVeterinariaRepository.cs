using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace DAL
{
    public class ConsultaVeterinariaRepository : FileRepository<ConsultaVeterinaria>
    {
        private MascotaRepository mascotaRepository;
        private VeterinarioRepository veterinarioRepository;

        public ConsultaVeterinariaRepository(string ruta) : base(ruta)
        {
            mascotaRepository = new MascotaRepository(Archivos.ARC_MASCOTA);
            veterinarioRepository = new VeterinarioRepository(Archivos.ARC_VETERINARIO);
        }

        public override List<ConsultaVeterinaria> Consultar()
        {
            try
            {
                List<ConsultaVeterinaria> lista = new List<ConsultaVeterinaria>();

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

        public override ConsultaVeterinaria Mappear(string datos)
        {
            string[] campos = datos.Split(';');
            ConsultaVeterinaria consulta = new ConsultaVeterinaria();
            consulta.Id = int.Parse(campos[0]);
            consulta.Fecha = DateTime.Parse(campos[1]);

            int mascotaId = int.Parse(campos[2]);
            int veterinarioId = int.Parse(campos[3]);

            Mascota mascota = mascotaRepository.Consultar().FirstOrDefault(m => m.Id == mascotaId);
            Veterinario veterinario = veterinarioRepository.Consultar().FirstOrDefault(v => v.Id == veterinarioId);

            if (mascota != null)
            {
                consulta.AsignarMascota(mascota);
            }

            if (veterinario != null)
            {
                consulta.AsignarVeterinario(veterinario);
            }

            consulta.Diagnostico = campos[4];
            consulta.Tratamiento = campos[5];

            return consulta;
        }

        public List<ConsultaVeterinaria> ConsultarPorMascota(int mascotaId)
        {
            return Consultar().Where(c => c.Mascota != null && c.Mascota.Id == mascotaId).ToList();
        }

        public List<ConsultaVeterinariaDto> ConsultarDTO()
        {
            List<ConsultaVeterinariaDto> listaDto = new List<ConsultaVeterinariaDto>();
            foreach (var consulta in Consultar())
            {
                ConsultaVeterinariaDto dto = new ConsultaVeterinariaDto
                {
                    Id = consulta.Id,
                    Fecha = consulta.Fecha.ToString("dd/MM/yyyy"),
                    NombreMascota = consulta.Mascota?.Nombre,
                    NombreVeterinario = consulta.Veterinario?.Nombre,
                    Diagnostico = consulta.Diagnostico,
                    Tratamiento = consulta.Tratamiento
                };
                listaDto.Add(dto);
            }
            return listaDto;
        }
    }
}