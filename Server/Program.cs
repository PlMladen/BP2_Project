using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        private static ServiceHost serviceHost;
        static void Main(string[] args)
        {
            Console.WriteLine("Server is starting ...");
            serviceHost = new ServiceHost(typeof(ServerOperations));
            serviceHost.Open();
            Console.WriteLine("Server started!\n[Press any key to shutdown]\n");
            Console.ReadKey();
            Console.WriteLine("Server is shutting down...");
            serviceHost.Close();
            Console.WriteLine("Server closed!");
            Console.ReadKey();

        }
    }
}
