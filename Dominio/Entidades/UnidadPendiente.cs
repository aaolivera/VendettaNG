using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class UnidadPendiente
    {
        public virtual Unidad Unidad { get; set; }
        public virtual TimeSpan TiempoRestante { get; set; }
    }
}
