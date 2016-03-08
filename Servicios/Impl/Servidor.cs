using System.Linq;
using Dominio.Entidades;
using Repositorio;
using Servicios.Conversiones;
using Servicios.Models;
using System.Threading.Tasks;
using System.Threading;
using Ninject.Extensions.Logging;
using System.ServiceModel;

namespace Servicios.Impl
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Servidor : IServidor
    {
        private readonly IRepositorio repositorio;
        private readonly IConversor conversor;
        private readonly Mundo mundo;
        private readonly ILogger log;
        private CancellationTokenSource ts;

        public Servidor(IRepositorio repositorio, IConversor conversor, ILogger log)
        {
            this.repositorio = repositorio;
            this.conversor = conversor;
            this.log = log;
            var objetos = repositorio.Listar<ObjetoEjecutable>().ToList();
            mundo = Mundo.ObtenerMundo(objetos);
        }

        public bool Start()
        {
            if(ts == null || ts.IsCancellationRequested) {
                ts = new CancellationTokenSource();
                var ct = ts.Token;

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
                        Thread.Sleep(10000);
                    }

                }, ct);
                return true;
            }
            return false;
        }
        public bool Stop()
        {
            ts?.Cancel();
            return true;
        }

        public bool AregarObjetoEjecutable(int id)
        {
            return mundo.AregarObjetoEjecutable(repositorio.Obtener<ObjetoEjecutable>(id));
        }
    }
}
