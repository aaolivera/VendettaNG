using System.Data.Entity;
using System.ServiceModel;
using Ninject.Modules;
using Repositorio;
using Servicios.Conversiones;
using Servicios;
using Servicios.Impl;
using Servicios.Conversiones.Impl;

namespace Molinos.Scato.Dependencias
{
    public class ServiciosWebNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<DbContexto>().InScope(ctx => OperationContext.Current);
            Bind<IRepositorio>().To<RepositorioEF>().InScope(ctx => OperationContext.Current);

            Bind<IConversor>().To<ConversorAutoMapper>().InSingletonScope();

            Bind<IServicioRepositorio, ServicioRepositorio>().To<ServicioRepositorio>().InScope(ctx => OperationContext.Current);
            Bind<IServicioComandos, ServicioComandos>().To<ServicioComandos>().InSingletonScope();
            
        }
    }
}
