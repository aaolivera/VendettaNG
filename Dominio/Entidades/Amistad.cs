using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Amistad : IIdentificable
    {
        [Key]
        public int Id { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Usuario UsuarioRelacionado { get; set; }
    }
}
