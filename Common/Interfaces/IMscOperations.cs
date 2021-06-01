using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    [ServiceContract]
    public interface IMscOperations : IAddEntityOperations, IUpdateEntity, IGetAllEntities, IGetEntityOperations, IDeleteEntity
    {
        [OperationContract]
        int ReturnNumberOfUserComputersByType(long ownerId, Vrsta_racunara vrsta_Racunara);
        [OperationContract]
        SqlUpitVlasnikServisCijena ReturnOwnerWithMaxRepairPrice();
        [OperationContract]
        string ReturnTheOldestWorker(string nazivServisa);
        [OperationContract]
        int ReturnCountOfAdultOwners();
    }
}
