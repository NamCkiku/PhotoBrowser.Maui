using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoBrowsers
{
    public class ServiceHelpers : Microsoft.Maui.Hosting.IMauiInitializeService
    {
        public static IServiceProvider Services { get; private set; }

        public void Initialize(IServiceProvider services)
        {
            Services = services;
        }

        public static TService GetService<TService>() => //test
            Services.GetService<TService>();
    }
}