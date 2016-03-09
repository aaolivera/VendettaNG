using Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Servicios.Models
{
    public class Mundo
    {
        private static Mundo mundo;
        private Dictionary<string, Usuario> Objetos { get; set; }

        private Mundo(List<Usuario> objetosEjecutables)
        {
            this.Objetos = objetosEjecutables.ToDictionary(x => x.Nombre, x => x);
        }

        public static Mundo Obtener(List<Usuario> objetosEjecutables)
        {
            if (mundo == null)
            {
                mundo = new Mundo(objetosEjecutables);                
            }
            return mundo;
        }

        public static void Destruir()
        {
            mundo = null;
        }

        public void Ejecutar()
        {
            foreach(var i in Objetos.Values)
            {
                i.Ejecutar();
            }
        }

        public bool AregarUsuario(Usuario objeto)
        {
            if(!Objetos.ContainsKey(objeto?.Nombre))
            {
                Objetos.Add(objeto.Nombre, objeto);
                return true;
            }
            return false;
        }

        
    }
}
