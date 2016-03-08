using log4net;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Edificio : ObjetoEjecutable
    {
        public virtual Usuario Usuario { get; set; }
        [InverseProperty("Edificio")]
        public virtual ICollection<Habitacion> Habitaciones { get; set; }
        [InverseProperty("Edificio")]
        public virtual ICollection<Recurso> Recursos { get; set; }
        [InverseProperty("Edificio")]
        public virtual ICollection<Unidad> Unidad { get; set; }

        public override void Ejecutar() {
            var a = 1;

        }
    }
}
