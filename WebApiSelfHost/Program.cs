using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using WebApiSelfHost.Configuration;

namespace WebApiSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(f =>
            {
                f.Service<OwinService>(s =>
                {
                    s.ConstructUsing(() => new OwinService());
                    s.WhenStarted(service => service.Start());
                    s.WhenStopped(service => service.Stop());
                });

                f.RunAsLocalSystem();
                f.StartAutomatically();

                f.SetDescription("Serviço de teste de WebAPI self-hosted.");
                f.SetDisplayName("WebAPISelfHosted");
                f.SetServiceName("WebAPISelfHosted");
            });
        }
    }
}
