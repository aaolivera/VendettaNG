using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class ObjetoEjecutable : IIdentificable
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }

        public virtual void Ejecutar() { }
    }
}
