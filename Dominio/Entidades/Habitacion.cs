using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public abstract class Habitacion : ObjetoEjecutable
    {
        public virtual Edificio Edificio { get; set; }
    }
}
