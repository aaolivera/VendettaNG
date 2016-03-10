using Dominio.Comandos;
using Repositorio;
using Servicios.Conversiones;
using Servicios.Models;

namespace Servicios.Procesamiento
{
    public abstract class ProcesadorComandoDeServidor<TComando> : IProcesadorComandoDeServidor<TComando> where TComando : Comando
    {
        protected IRepositorio Repositorio { get; private set; }
        protected IConversor Conversor { get; private set; }

        protected ProcesadorComandoDeServidor(IRepositorio repositorio, IConversor conversor)
        {
            Repositorio = repositorio;
            Conversor = conversor;
        }

        public Resultado Ejecutar(Comando comando)
        {
            return Ejecutar((TComando) comando, Mundo.Obtener());
        }

        public abstract Resultado Ejecutar(TComando comando, Mundo mundo);

    }
}
