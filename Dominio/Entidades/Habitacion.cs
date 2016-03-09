using Dominio.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public abstract class Habitacion : ObjetoEjecutable
    {
        public virtual Edificio Edificio { get; set; }
        public abstract bool Depositar(Material material, int v);
    }
}
