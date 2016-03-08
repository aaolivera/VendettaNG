using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ServiciosWeb.App_Start
{
    public static class Log4NetConfig
    {
        public static void Configure(HttpServerUtility server)
        {
            var fileInfo = new FileInfo(server.MapPath("~/log4net.config"));
            log4net.Config.XmlConfigurator.ConfigureAndWatch(fileInfo);
        }
    }
}