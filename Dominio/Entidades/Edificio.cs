using log4net;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.Enum;
using System;
using System.Linq;

namespace Dominio.Entidades
{
    //[Table("Edificio")]
    public class Edificio : ObjetoEjecutable
    {
        public virtual Usuario Usuario { get; set; }
        [InverseProperty("Edificio")]
        public virtual ICollection<Habitacion> Habitaciones { get; set; }

        [InverseProperty("Edificio")]
        public virtual ICollection<Unidad> Unidades { get; set; }

        public void Depositar(Material material, int v)
        {
            foreach (var i in Habitaciones)
            {
                if(i.Depositar(material, v))
                {
                    break;
                }
            }
        }

        public void ApostarUnidad(Unidad unidad)
        {
            var unidadLocal = Unidades.FirstOrDefault(x => x.Especializacion == unidad.Especializacion);
            if(unidadLocal == null)
            {
                unidad.Edificio = this;
                Unidades.Add(unidad);
            }
            else
            {
                unidadLocal.Cantidad += unidad.Cantidad;
            }
        }

        public override void Ejecutar() {
            var a = 1;

        }
    }
}
