using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI
{
    public class DatabaseServiceProvider
    {
        public static DatabaseServiceProvider Instance { get; } = new DatabaseServiceProvider();
        private IMscOperations proxy;

        private DatabaseServiceProvider()
        {
            proxy = new ChannelFactory<IMscOperations>("ClientUI").CreateChannel();
        }

        public bool AddServis(Servis servis)
        {
            return proxy.AddServis(servis);
        }

        public IEnumerable<Servis> GetAllServiss()
        {
            return proxy.GetAllServiss();
        }

        public Servis GetServis(int idServisa)
        {
            return proxy.GetServis(idServisa);
        }

        public bool DeleteServis(int idServisa)
        {
            return proxy.DeleteServis(idServisa);
        }

        public void UpdateServis(Servis servis)
        {
            proxy.UpdateServis(servis);
        }
    }
}
