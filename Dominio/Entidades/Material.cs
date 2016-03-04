using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Material : IIdentificable
    {
        [Key]
        public int Id { get; set; }

        public virtual string Nombre { get; set; }
    }
}
