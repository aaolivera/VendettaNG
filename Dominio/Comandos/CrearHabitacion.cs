using Dominio.Entidades;
using Dominio.Enum;
using Dominio.Models.Factorys;
using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Dominio.Comandos
{
    public class CrearHabitacion : Comando
    {
        public string EdificioNombre { get; set; }
        public string NombreUsuario { get; set; }
        public IFactoryHabitacion Habitacion { get; set; }
    }
}
