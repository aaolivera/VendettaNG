using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Dominio.Comandos
{
    public class CrearUnidad : Comando
    {
        public string EdificioNombre { get; set; }
        public string NombreUsuario { get; set; }
    }
}
