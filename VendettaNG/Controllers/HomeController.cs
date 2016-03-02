using System.Web.Mvc;
using Dominio.Consultas;
using Servicios;

namespace VendettaNG.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IServicioRepositorio servcio):base(servcio)
        {
        }

        [AllowAnonymous]
        public ActionResult Index()
        {

            return View();
        }

    }
}
