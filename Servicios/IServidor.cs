using System.Collections.Generic;
using System.ServiceModel;
using Dominio.Dto;
using Dominio.Comandos;

namespace Servicios
{
    [ServiceContract(Namespace = "http://VendettaNG.com.ar")]
    public interface IServidor
    {
        [OperationContract]
        bool Start();
        [OperationContract]
        bool Stop();

        [OperationContract]
        void Inicializar();

        [OperationContract]
        Resultado EjecutarComando(Comando comando);
    }
}
