namespace Dominio.Entidades
{
    public class Amistad
    {
        public int Id { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Usuario UsuarioRelacionado { get; set; }
    }
}
