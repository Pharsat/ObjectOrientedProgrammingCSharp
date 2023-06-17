namespace HerenciaYPolimorfismo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ClaseBase
    {
        public const string NombreGeneralDeGrupos = "Grupo A";
        public readonly string nombreGeneralDeGrupos = "Grupo A";
        public string Nombre { get; set; }

        public ClaseBase()
        {
            Nombre = "Cristian";
            Console.WriteLine($"Constructor clase base. El nombre es {Nombre}");
        }

        public List<string> CrearGrupo()
        {
            return new List<string>();
        }

        public List<string> CrearGrupo(string nombreDelGrupo, List<string> listaDeNombres)
        {
            var lista = new List<string>() { nombreDelGrupo };
            lista.AddRange(listaDeNombres);
            return lista;
        }

        public List<string> CrearGrupo(List<string> listaDeNombres, string nombreDelGrupo)
        {
            return new List<string>() { nombreDelGrupo };
        }
    }
}
