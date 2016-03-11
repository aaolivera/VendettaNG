using Dominio.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public abstract class Habitacion : ObjetoEjecutable
    {
        public virtual Edificio Edificio { get; set; }
        public int Nivel { get; internal set; }

        public abstract bool Depositar(Material material, int v);

        public bool Mejorar(Habitacion habitacion)
        {
            if (GetType() == habitacion.GetType())
            {
                Nivel++;
                return true;
            }
            return false;
        }
    }
}
