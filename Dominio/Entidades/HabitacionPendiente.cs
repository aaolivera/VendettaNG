using Dominio.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class HabitacionPendiente : IIdentificable
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual Edificio Edificio { get; set; }
        public virtual Habitacion Habitacion { get; set; }
        public virtual TimeSpan TiempoRestante { get; set; }
    }
}
