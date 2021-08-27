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
        bool VratiAktivnostProfilaKorisnika(string korisnickoIme);
        [OperationContract]
        bool VratiAktivnostProfilaKorisnikaJmbg(long jmbg);
        [OperationContract]
        bool PromijeniAktivnostProfilaKorisnika(long korisnickoIme, bool odobren);
        [OperationContract]
        long VratiJMBGVlasnika(string korisnickoIme);
        [OperationContract]
        IEnumerable<Racunar> GetAllMojiRacunari(long idVlasnika);
        [OperationContract]
        IEnumerable<Racunar> GetAllNeprodatiRacunari();
        [OperationContract]
        int VratiIdServisa(long jmbgServisera);
        [OperationContract]
        Korisnik VratiKorisnika(string korisnickoIme);
        [OperationContract]
        bool EksportujPosjedujeVezuUCsv(string direktorijum);
        [OperationContract]
        bool EksportujPosjedujeVezuZaVlasnikaUCsv(string direktorijum, long jmbg);
        [OperationContract]
        IEnumerable<Common.Models.Posjeduje> ImportujPosjedujeVezuIzCsv(string direktorijum);
    }
}
