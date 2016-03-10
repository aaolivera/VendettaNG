using log4net;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.Enum;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Edificio : ObjetoEjecutable
    {
        public virtual Usuario Usuario { get; set; }

        private ICollection<Habitacion> _habitaciones;
        public virtual ICollection<Habitacion> Habitaciones { get { return _habitaciones ?? (_habitaciones = new List<Habitacion>()); } }

        private ICollection<Unidad> _unidades;
        public virtual ICollection<Unidad> Unidades { get { return _unidades ?? (_unidades = new List<Unidad>()); }  }

        private ICollection<UnidadPendiente> _unidadesPendientes;
        public virtual ICollection<UnidadPendiente> UnidadesPendientes { get { return _unidadesPendientes ?? (_unidadesPendientes = new List<UnidadPendiente>()); } }


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

        public override void Ejecutar()
        {
            foreach(var i in Habitaciones){
                i.Ejecutar();
            }
        }
    }
}
