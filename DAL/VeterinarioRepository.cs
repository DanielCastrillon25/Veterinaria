using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace DAL
{
    public class VeterinarioRepository : FileRepository<Veterinario>
    {
        public VeterinarioRepository(string ruta) : base(ruta)
        {
        }

        public override List<Veterinario> Consultar()
        {
            try
            {
                List<Veterinario> lista = new List<Veterinario>();

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

        public override Veterinario Mappear(string datos)
        {
            string[] campos = datos.Split(';');
            Veterinario veterinario = new Veterinario();
            veterinario.Id = int.Parse(campos[0]);
            veterinario.Nombre = campos[1];
            veterinario.Especialidad = campos[2];
            return veterinario;
        }
    }
}