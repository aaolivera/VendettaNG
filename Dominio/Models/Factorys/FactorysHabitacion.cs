using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Models.Factorys
{
    public class FCampoDeEntrenamiento : IFactoryHabitacion
    {
        public Habitacion Crear()
        {
            return new CampoDeEntrenamiento();
        }
    }
    public class FDepositoDeMunicion : IFactoryHabitacion
    {
        public Habitacion Crear()
        {
            return new DepositoDeMunicion();
        }
    }
    public class FFabricaDeMunicion : IFactoryHabitacion
    {
        public Habitacion Crear()
        {
            return new FabricaDeMunicion();
        }
    }
}
