using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public abstract class Unidad : ObjetoEjecutable
    {
        public virtual Edificio Edificio { get; set; }
    }
}
