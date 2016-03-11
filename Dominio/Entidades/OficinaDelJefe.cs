using Dominio.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System;

namespace Dominio.Entidades
{
    public class OficinaDelJefe : Habitacion
    {
        
        public override bool Depositar(Material material, int v)
        {
            return false;
        }

        public override void Ejecutar() {
            var primero = Edificio.HabitacionesPendientes.FirstOrDefault();
            if(primero?.TiempoRestante.Ticks > 0)
            {
                primero.TiempoRestante = primero.TiempoRestante.Subtract(new TimeSpan(1));
            }
            else if (primero?.TiempoRestante.Ticks == 0)
            {
                Edificio.MejorarHabitacion(primero.Habitacion);
                Edificio.HabitacionesPendientes.Remove(primero);
            }
        }
    }
}
