using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public abstract class ObjetoEjecutable : IIdentificable
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }
        public abstract void Ejecutar();
    }
}
