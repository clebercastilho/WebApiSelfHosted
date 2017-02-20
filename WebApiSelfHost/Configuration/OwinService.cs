using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSelfHost.Configuration
{
    public class OwinService
    {
        private IDisposable _webApi;

        public void Start() => _webApi = WebApp.Start<ApiConfiguration>("http://+:9000");
        public void Stop() => _webApi.Dispose();
    }
}
