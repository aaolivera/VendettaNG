using Dominio.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System;

namespace Dominio.Entidades
{
    public class FabricaDeMunicion : Habitacion
    {
        public override bool Depositar(Material material, int v)
        {
            return false;
        }

        public override void Ejecutar() {
            Edificio.Depositar(Material.Municion, 20);
        }
    }
}
