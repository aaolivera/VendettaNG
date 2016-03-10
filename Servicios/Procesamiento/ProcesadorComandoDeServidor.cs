using System;
using Dominio.Comandos;
using Repositorio;
using Servicios.Conversiones;
using Servicios.Models;
using System.Linq;

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
            var resultado = new Resultado();

            ValidarCostos((TComando)comando, Mundo.Obtener(), resultado);
            if (!resultado.HayErrores)
            {
                Ejecutar((TComando)comando, Mundo.Obtener());
            }
            return resultado;
        }

        public abstract void Ejecutar(TComando comando, Mundo mundo);

        public bool ValidarCostos(TComando comando, Mundo mundo, Resultado resultado)
        {
            return true;
        }
    }
}
