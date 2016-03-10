using Dominio.Comandos;
using Servicios.Models;

namespace Servicios.Procesamiento
{
    public interface IProcesadorComando
    {
        Resultado Ejecutar(Comando comando);
    }

    public interface IProcesadorComando<in TComando> : IProcesadorComando
    {
        Resultado Ejecutar(TComando comando);
    }

    public interface IProcesadorComandoDeServidor<in TComando> : IProcesadorComando
    {
        Resultado Ejecutar(TComando comando, Mundo mundo);
    }

}
