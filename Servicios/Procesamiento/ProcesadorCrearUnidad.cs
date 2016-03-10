using Dominio;
using Dominio.Comandos;
using Dominio.Entidades;
using Dominio.Enum;
using Repositorio;
using Servicios.Conversiones;
using Servicios.Models;
using System.Linq;

namespace Servicios.Procesamiento
{
    public class ProcesadorCrearUnidad : ProcesadorComandoDeServidor<CrearUnidad>
    {
        public ProcesadorCrearUnidad(IRepositorio repositorio, IConversor conversor) : base(repositorio, conversor)
        {
        }

        public override void Ejecutar(CrearUnidad comando, Mundo mundo)
        {
            var usuario = mundo.ObtenerUsuario(comando.NombreUsuario);
            var edificio = usuario.Edificios.FirstOrDefault(x => x.Nombre == comando.EdificioNombre);

            edificio?.UnidadesPendientes.Add(
                new UnidadPendiente {
                    TiempoRestante = new System.TimeSpan(10 * comando.Cantidad),
                    Unidad = new  Unidad
                    {
                        Cantidad= comando.Cantidad,
                        Especializacion= comando.Especializacion
                    }
                });
        }
    }
}
