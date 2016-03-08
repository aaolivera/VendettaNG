using Dominio.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Unidad : ObjetoEjecutable
    {
        public virtual int Cantidad { get; set; }
        public virtual Especializacion Especializacion { get; set; }
        public virtual Edificio Edificio { get; set; }
    }
}
