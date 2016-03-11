using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models.Factorys
{
    public interface IFactoryHabitacion
    {
        Habitacion Crear();
    }
}
