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

        public override Resultado Ejecutar(CrearUnidad comando, Mundo mundo)
        {
            var resultado = new ResultadoCrear();

            var usuario = mundo.ObtenerUsuario(comando.NombreUsuario);
            var edificio = usuario.Edificios.FirstOrDefault(x => x.Nombre == comando.EdificioNombre);
            edificio?.UnidadesPendientes.Add(
                
                new UnidadPendiente {
                    TiempoRestante = new System.TimeSpan(10),
                    Unidad = new  Unidad
                    {
                        Cantidad=10,
                        Especializacion= Especializacion.Mercenario
                    }
                    });
            return resultado;
        }
    }
}
