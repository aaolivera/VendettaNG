using Dominio.Entidades;
using Repositorio;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Servicios.Models
{
    public class Mundo
    {
        private static Mundo mundo;
        private IRepositorio repositorio;
        private Mundo(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
            this.Edificios = repositorio.Listar<Edificio>().ToList();
            this.Unidades = repositorio.Listar<Unidad>().ToList();
        }

        public static Mundo ObtenerMundo(IRepositorio repositorio)
        {
            if (mundo == null)
            {
                mundo = new Mundo(repositorio);
                
            }
            return mundo;
        }

        public void Ejecutar()
        {
            Edificios.ForEach(x => x.Ejecutar());
            Unidades.ForEach(x => x.Ejecutar());
        }

        public void AregarEdificio(int id)
        {
            if(!Edificios.Any(x => x.Id == id))
            {
                Edificios.Add(repositorio.Obtener<Edificio>(id));
            }
        }

        public void AregarUnidad(int id)
        {
            if (!Unidades.Any(x => x.Id == id))
            {
                Unidades.Add(repositorio.Obtener<Unidad>(id));
            }

        }
        private List<Edificio> Edificios { get; set; }
        private List<Unidad> Unidades { get; set; }
    }
}
