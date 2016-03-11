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
using Dominio.Comandos;

namespace Servicios.Impl
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Servidor : IServidor
    {
        private readonly IRepositorio repositorio;
        private readonly IConversor conversor;
        private readonly IServicioComandos servicioComandos;
        private Mundo mundo;
        private readonly ILogger log;
        private CancellationTokenSource ts;

        public Servidor(IRepositorio repositorio, IServicioComandos servicioComandos, IConversor conversor, ILogger log)
        {
            this.repositorio = repositorio;
            this.conversor = conversor;
            this.servicioComandos = servicioComandos;
            this.log = log;           
        }

        public bool Start()
        {
            if(ts == null || ts.IsCancellationRequested) {
                ts = new CancellationTokenSource();
                var ct = ts.Token;

                var usuarios = repositorio.Listar<Usuario>().ToList();
                mundo = Mundo.Crear(usuarios);

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

        public Resultado EjecutarComando(Comando comando)
        {
            return servicioComandos.Ejecutar(comando);
        }

        public void Inicializar()
        {
                var u = new Usuario { Nombre = "a" };
                var e = new Edificio { Nombre = "E", Usuario = u };
                e.Habitaciones.Add(new FabricaDeMunicion { Nombre = "F", Edificio = e });
                e.Habitaciones.Add(new DepositoDeMunicion { Nombre = "D", Edificio = e });
                e.Habitaciones.Add(new CampoDeEntrenamiento { Nombre = "C", Edificio = e });
                u.Edificios.Add(e);

                if (mundo.AregarUsuario(u)) {
                    repositorio.Agregar<Usuario>(u);
                }
            
            }
        
    }
}
