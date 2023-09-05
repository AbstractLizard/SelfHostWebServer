namespace SelfHostWebServer
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.SelfHost;
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext.InitializeApplicationContext();

            var config = new HttpSelfHostConfiguration(ApplicationContext.BaseAddress);

            config.MapHttpAttributeRoutes();

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine($"WebApi hosted on {ApplicationContext.BaseAddress} It can be tested now");
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }
    }
}
