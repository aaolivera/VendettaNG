using Dominio.Enum;

namespace Dominio.Dto
{
    public sealed class MensajeDto
    {
        public int Id { get; set; }

        public TipoMensaje TipoMensaje { get; set; }

        public string NombreReceptor { get; set; }

        public string NombreEmisor { get; set; }

        public string Mensaje { get; set; }
    }
}
