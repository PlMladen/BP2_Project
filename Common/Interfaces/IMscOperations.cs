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

        [OperationContract]
        bool PrijaviKorisnika(string korisnickoIme, string lozinka);
        [OperationContract]
        bool RegistrujKorisnika(Korisnik korisnik);

        [OperationContract]
        string VratiUloguKorisnika(string korisnickoIme);
        [OperationContract]
        long VratiJMBGVlasnika(string korisnickoIme);
        [OperationContract]
        IEnumerable<Racunar> GetAllMojiRacunari(long idVlasnika);
        [OperationContract]
        IEnumerable<Racunar> GetAllNeprodatiRacunari();
        [OperationContract]
        int VratiIdServisa(long jmbgServisera);
    }
}
