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
    public class ProcesadorCrearHabitacion : ProcesadorComandoDeServidor<CrearHabitacion>
    {
        public ProcesadorCrearHabitacion(IRepositorio repositorio, IConversor conversor) : base(repositorio, conversor)
        {
        }

        public override void Ejecutar(CrearHabitacion comando, Mundo mundo)
        {
            var usuario = mundo.ObtenerUsuario(comando.NombreUsuario);
            var edificio = usuario.Edificios.FirstOrDefault(x => x.Nombre == comando.EdificioNombre);

            edificio?.HabitacionesPendientes.Add(
                new HabitacionPendiente {
                    TiempoRestante = new System.TimeSpan(10),
                    Habitacion = comando.Habitacion.Crear()
                });
        }

    }
}
