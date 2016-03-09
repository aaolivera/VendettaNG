using Dominio.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class UnidadPendiente : IIdentificable
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual CampoDeEntrenamiento CampoDeEntrenamiento { get; set; }
        public virtual Unidad Unidad { get; set; }
        public virtual TimeSpan TiempoRestante { get; set; }
    }
}
