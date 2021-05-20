using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ServerOperations : IMscOperations
    {
        MasterRepository masterRepository = new MasterRepository(new ProjectDbContext());
        public bool AddServis(Common.Models.Servis servis)
        {
            return masterRepository.ServisRepository.Add(servis);
        }

        public bool DeleteServis(int idServisa)
        {
            return masterRepository.ServisRepository.Delete(idServisa);
        }

        public IEnumerable<Common.Models.Servis> GetAllServiss()
        {
            return masterRepository.ServisRepository.GetAll();
        }

        public Common.Models.Servis GetServis(int idServisa)
        {
            return masterRepository.ServisRepository.Get(idServisa);
        }

        public void UpdateServis(Common.Models.Servis servis)
        {
            masterRepository.ServisRepository.Update(servis);
        }
    }
}
