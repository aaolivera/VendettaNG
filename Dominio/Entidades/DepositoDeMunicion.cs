using Dominio.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System;

namespace Dominio.Entidades
{
    public class DepositoDeMunicion : Habitacion
    {
        public int Capacidad { get; set; } = 150000;
        public int CantidadAlmacenada { get; set; }

        public override bool Depositar(Material material, int v)
        {
            if(material == Material.Municion && v < (Capacidad - CantidadAlmacenada)) {
                CantidadAlmacenada += v;
                return true;
            }
            return false;
        }

        public override void Ejecutar()
        {
           
        }
    }
}
