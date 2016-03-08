﻿using Dominio.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System;

namespace Dominio.Entidades
{
    public class CampoDeEntrenamiento : Habitacion
    {
        public virtual ICollection<UnidadPendiente> UnidadesEnCola { get; set; }
       
        public override bool Depositar(Material material, int v)
        {
            return false;
        }

        public override void Ejecutar() {
            var primero = UnidadesEnCola.FirstOrDefault();
            if(primero?.TiempoRestante.Ticks > 0)
            {
                primero.TiempoRestante = primero.TiempoRestante.Subtract(new TimeSpan(1));
            }
            else if (primero?.TiempoRestante.Ticks == 0)
            {
                Edificio.ApostarUnidad(primero.Unidad);
                UnidadesEnCola.Remove(primero);
            }
        }
    }
}