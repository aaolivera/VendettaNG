using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Edificio : IIdentificable
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual Usuario Usuario { get; set; }
        [InverseProperty("Edificio")]
        public virtual ICollection<Habitacion> Habitaciones { get; set; }
        [InverseProperty("Edificio")]
        public virtual ICollection<Recurso> Recursos { get; set; }

        public void Ejecutar() { }
    }
}
