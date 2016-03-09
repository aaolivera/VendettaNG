using System.Linq;
using Dominio.Entidades;
using Repositorio;
using Servicios.Conversiones;
using Servicios.Models;
using System.Threading.Tasks;
using System.Threading;
using Ninject.Extensions.Logging;
using System.ServiceModel;
using System.Collections.Generic;
using System;
using Dominio.Enum;

namespace Servicios.Impl
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Servidor : IServidor
    {
        private readonly IRepositorio repositorio;
        private readonly IConversor conversor;
        private Mundo mundo;
        private readonly ILogger log;
        private CancellationTokenSource ts;

        public Servidor(IRepositorio repositorio, IConversor conversor, ILogger log)
        {
            this.repositorio = repositorio;
            this.conversor = conversor;
            this.log = log;           
        }

        public bool Start()
        {
            if(ts == null || ts.IsCancellationRequested) {
                ts = new CancellationTokenSource();
                var ct = ts.Token;

                var usuarios = repositorio.Listar<Usuario>().ToList();
                mundo = Mundo.Obtener(usuarios);

                Task.Run(() => {
                    log.Debug("Iniciando Servidor");
                    while (true)
                    {
                        if (ct.IsCancellationRequested)
                        {
                            log.Debug("Deteniendo Servidor");
                            break;
                        }
                        mundo.Ejecutar();
                        Thread.Sleep(1000);
                    }

                }, ct);
                return true;
            }
            return false;
        }

        public bool Stop()
        {
            repositorio.GuardarCambios();
            Mundo.Destruir();
            ts?.Cancel();
            return true;
        }

        public void Inicializar()
        {
                var u = new Usuario { Nombre = "a" };
                var e = new Edificio { Nombre = "E", Usuario = u };
                e.Habitaciones.Add(new FabricaDeMunicion { Nombre = "F", Edificio = e });
                e.Habitaciones.Add(new DepositoDeMunicion { Nombre = "D", Edificio = e });
                e.Habitaciones.Add(new CampoDeEntrenamiento { Nombre = "C", Edificio = e });

                u.Edificios.Add(new Edificio { Nombre = "E", Usuario = u });
                mundo.AregarUsuario(u);
            }
            //if (!repositorio.Existe<Usuario>(x => x.Id == 1))
            //{
            //    repositorio.Agregar<Usuario>(new Usuario { Nombre = "a" });
            //    repositorio.GuardarCambios();
            //}
            //if (!repositorio.Existe<Edificio>(x => x.Id == 1))
            //{
            //    repositorio.Agregar<Edificio>(new Edificio { Nombre = "E", Usuario = repositorio.Obtener<Usuario>(1) });
            //    repositorio.GuardarCambios();
            //}

            //if (!repositorio.Existe<FabricaDeMunicion>(x => x.Id == 2))
            //{
            //    repositorio.Agregar<FabricaDeMunicion>(new FabricaDeMunicion { Nombre = "F", Edificio = repositorio.Obtener<Edificio>(1) });
            //    repositorio.GuardarCambios();
            //}
            //if (!repositorio.Existe<DepositoDeMunicion>(x => x.Id == 3))
            //{
            //    repositorio.Agregar<DepositoDeMunicion>(new DepositoDeMunicion { Nombre = "D",Capacidad = 10000, Edificio = repositorio.Obtener<Edificio>(1) });
            //    repositorio.GuardarCambios();
            //}
            //if (!repositorio.Existe<DepositoDeMunicion>(x => x.Id == 4))
            //{
            //    repositorio.Agregar<CampoDeEntrenamiento>(new CampoDeEntrenamiento {
            //        Nombre = "C",
            //        Edificio = repositorio.Obtener<Edificio>(1),
            //        UnidadesPendientes = new List<UnidadPendiente>() { new UnidadPendiente { TiempoRestante = new TimeSpan(10), Unidad = new Unidad {Cantidad = 10 , Especializacion = Especializacion.Mercenario } } }
                
            //    });
            //    repositorio.GuardarCambios();
            //}
        
    }
}
