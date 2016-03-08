using Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Servicios.Models
{
    public class Mundo
    {
        private static Mundo mundo;
        private Mundo(List<ObjetoEjecutable> objetosEjecutables)
        {
            this.Objetos = objetosEjecutables;
        }

        public static Mundo ObtenerMundo(List<ObjetoEjecutable> objetosEjecutables)
        {
            if (mundo == null)
            {
                mundo = new Mundo(objetosEjecutables);                
            }
            return mundo;
        }

        public void Ejecutar()
        {
            Objetos.ForEach(x => x.Ejecutar());
        }

        public bool AregarObjetoEjecutable(ObjetoEjecutable objetosEjecutable)
        {
            if(!Objetos.Any(x => x.Id == objetosEjecutable?.Id))
            {
                Objetos.Add(objetosEjecutable);
                return true;
            }
            return false;
        }

        private List<ObjetoEjecutable> Objetos { get; set; }
    }
}
