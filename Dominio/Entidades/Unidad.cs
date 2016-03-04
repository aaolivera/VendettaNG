using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public abstract class Unidad : IIdentificable
    {
        [Key]
        public int Id { get; set; }

        public virtual string Nombre { get; set; }
        public virtual Edificio Edificio { get; set; }
        public abstract void Ejecutar();
    }
}
