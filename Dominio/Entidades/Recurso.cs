namespace Dominio.Entidades
{
    public class Recurso
    {
        public int Id { get; set; }

        public virtual Material Material { get; set; }

        public virtual Edificio Edificio { get; set; }
    }
}
