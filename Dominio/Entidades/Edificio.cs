using log4net;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.Enum;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Edificio : IIdentificable
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual Usuario Usuario { get; set; }

        //[InverseProperty("Edificio")]
        public virtual ICollection<Habitacion> Habitaciones { get; set; }

        private ICollection<Unidad> _unidades;
        //[InverseProperty("Edificio")]
        public virtual ICollection<Unidad> Unidades { get { return _unidades ?? (_unidades = new List<Unidad>()); }  }

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
    }
}
