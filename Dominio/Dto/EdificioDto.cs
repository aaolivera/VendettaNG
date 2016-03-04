using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dominio.Recursos;

namespace Dominio.Dto
{
    public sealed class EdificioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
