using System.Collections.Generic;
using System.ServiceModel;
using Dominio.Dto;

namespace Servicios
{
    [ServiceContract(Namespace = "http://UnCuentoParaTodos.com.ar")]
    public interface IServicioRepositorio
    {
        [OperationContract]
        string Saludar();

        [OperationContract]
        List<UsuarioDto> ListarUsuarios();

        [OperationContract]
        UsuarioDto ObtenerUsuario(int id);
        
    }
}
