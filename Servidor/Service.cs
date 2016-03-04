using Dependencias;
using Ninject;
using Servidor.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.Logging;
namespace Servidor
{
    public partial class Service : ServiceBase
    {
        private ServiceHost serviceHost;
        public static IKernel KernelInstance { get; private set; }

        public Service()
        {
            InitializeComponent();
        }

        internal void Start(string[] args)
        {
            this.OnStart(args);
        }

        protected override void OnStart(string[] args)
        {
            var fileInfo = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "/log4net.config");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(fileInfo);
            CreateKernel();
            var log = KernelInstance.Get<ILoggerFactory>().GetCurrentClassLogger();

            try
            {
                log.Info("Iniciando Servicio...");

                if (serviceHost != null)
                {
                    serviceHost.Close();
                }
                log.Info("Iniciando servicios web...");
                var urlOrquestador = String.Format(ConfigurationManager.AppSettings["UrlOrquestador"],
                                                   Environment.MachineName);
                var urlsOrquestador = urlOrquestador.Split(',').Select(url => new Uri(url)).ToArray();
                serviceHost = new NinjectServiceHost(KernelInstance, typeof(ServicioOrquestador), urlsOrquestador);

                log.Info("Inicializando orquestador...");
                ServicioOrquestador.Iniciar(Environment.MachineName, urlsOrquestador[0].AbsoluteUri);
                log.Info("Servicio iniciado");

                serviceHost.Open();
                log.Info("Servicio orquestador escuchando peticiones");

                Task.Run(() => ServicioOrquestador.VerificarDispositivos());

            }
            catch (ReflectionTypeLoadException rte)
            {
                log.Error(rte, "No se pudo iniciar el orquestador");
                foreach (var loaderException in rte.LoaderExceptions)
                {
                    log.Debug(loaderException, "Loader Exception");
                }
            }
            catch (Exception e)
            {
                log.Error(e, "No se pudo iniciar el orquestador");
                throw;
            }
        }

        protected override void OnStop()
        {
        }

        private IServicioOrquestador ServicioOrquestador
        {
            get { return KernelInstance.Get<IServicioOrquestador>(); }
        }

        private void CreateKernel()
        {
            KernelInstance = new StandardKernel();
            KernelInstance.Load(new ServidorModule());
        }

        private void DisposeKernel()
        {
            if (KernelInstance != null)
            {
                KernelInstance.Dispose();
                KernelInstance = null;
            }
        }
    }
}
