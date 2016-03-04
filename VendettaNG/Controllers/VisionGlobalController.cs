using System.Web.Mvc;
using Dominio.Consultas;
using Servicios;
using System.Linq;

namespace VendettaNG.Controllers
{
    public class VisionGlobalController : BaseController
    {
        public VisionGlobalController(IServicioRepositorio servcio):base(servcio)
        {
        }

        public ActionResult Index()
        {
            var usuario = servicio.ObtenerUsuario(User.Identity.Name);
            if (usuario.Edificios?.Count > 0)
            {
                return View();
            }
            return View("PrimerEdificio");
        }

    }
}
