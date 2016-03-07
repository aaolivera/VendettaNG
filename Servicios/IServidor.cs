using System.Collections.Generic;
using System.ServiceModel;
using Dominio.Dto;

namespace Servicios
{
    [ServiceContract(Namespace = "http://VendettaNG.com.ar")]
    public interface IServidor
    {
        void Start();
        void Stop();


    }
}
