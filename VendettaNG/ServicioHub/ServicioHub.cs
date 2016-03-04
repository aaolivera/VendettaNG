using System.Threading.Tasks;
using Dominio.Dto;
using Dominio.Enum;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Servicios;
using WebMatrix.WebData;

namespace VendettaNG.ServicioHub
{
    [HubName("servicioHub")]
    public class ServicioHub : Hub
    {
        private readonly IServicioRepositorio _servicio;

        public ServicioHub(IServicioRepositorio servicio)
            : base()
        {
            _servicio = servicio;
        }
        //Si quiero enviarle un mensaje a mis amigos, lo envio a "mi grupo" (amigo + nombre usuario)
        //Si quiero enviarle un mensaje a un amigo, lo envio a su grupo (su nombre usuario)
        [Authorize]
        public void EnviarMensaje(MensajeDto mensaje)
        {
            if (Clients != null)
            {
                mensaje.NombreEmisor = WebSecurity.CurrentUserName;
                switch (mensaje.TipoMensaje)
                {
                    case TipoMensaje.Privado:
                        Clients.Group(TipoMensaje.Privado + mensaje.NombreReceptor).recibirMensaje(mensaje);
                        return;
                    case TipoMensaje.Publico:
                        Clients.Group(TipoMensaje.Publico.ToString()).recibirMensaje(mensaje);
                        return;
                    case TipoMensaje.Amigos:
                        Clients.Group(TipoMensaje.Amigos + mensaje.NombreEmisor).recibirMensaje(mensaje);
                        return;
                    case TipoMensaje.Equipo:
                        Clients.Group(TipoMensaje.Equipo + mensaje.NombreReceptor).recibirMensaje(mensaje);
                        return;
                }
            }
        }

        public override Task OnConnected()
        {
            //Para recibir Mensajes publicos
            Groups.Add(Context.ConnectionId, TipoMensaje.Publico.ToString());

            if (Context.User.Identity.IsAuthenticated)
            {
                var usuario = _servicio.ObtenerUsuario(Context.User.Identity.Name);


                if (usuario != null)
                {
                    //Para recibir Mensajes privados
                    Groups.Add(Context.ConnectionId, TipoMensaje.Privado + usuario.NombreUsuario);
                    //Para recibir mensajs semi publicos
                    //foreach (var amigo in usuario.Amigos)
                    //{
                    //    Groups.Add(Context.ConnectionId, TipoMensaje.Amigos + amigo);
                    //}
                    //foreach (var equipo in usuario.Equipos)
                    //{
                    //    Groups.Add(Context.ConnectionId, TipoMensaje.Equipo + equipo);
                    //}
                }
            }
            return base.OnConnected();
        }

        //public override Task OnDisconnected(bool stopCalled)
        //{
        //    Groups.Remove(Context.ConnectionId, TipoMensaje.Publico.ToString());

        //    if (Context.User.Identity.IsAuthenticated)
        //    {
        //        var usuario = _servicio.ObtenerUsuario(WebSecurity.CurrentUserId);

        //        if (usuario != null)
        //        {
        //            //Para recibir Mensajes privados
        //            Groups.Remove(Context.ConnectionId, TipoMensaje.Privado + usuario.NombreUsuario);
        //            //Para recibir mensajs semi publicos
        //            foreach (var amigo in usuario.Amigos)
        //            {
        //                Groups.Remove(Context.ConnectionId, TipoMensaje.Amigos + amigo);
        //            }
        //            foreach (var equipo in usuario.Equipos)
        //            {
        //                Groups.Remove(Context.ConnectionId, TipoMensaje.Equipo + equipo);
        //            }
        //        }
        //    }

        //    return base.OnDisconnected(stopCalled);
        //}

    }
}