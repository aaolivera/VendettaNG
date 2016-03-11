using Dominio.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Dominio.Entidades
{
    public class Unidad : IIdentificable
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual int Cantidad { get; set; }
        public virtual Especializacion Especializacion { get; set; }
        public virtual Edificio Edificio { get; set; }

        public bool Apostar(Unidad unidad)
        {
            if (Especializacion == unidad.Especializacion)
            {
                Cantidad+= unidad.Cantidad;
                return true;
            }
            return false;
        }
    }
}
