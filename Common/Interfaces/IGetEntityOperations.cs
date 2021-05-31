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
    public interface IGetEntityOperations
    {
        [OperationContract]
        Servis GetServis(int idServisa);
        [OperationContract]
        Racunarski_servis GetRacunarskiServis(int idServisa);
        [OperationContract]
        Serviser_racunara GetServiserRacunara(long idServisera);
        [OperationContract]
        Racunar GetRacunar(int idRacunara);
        [OperationContract]
        Vlasnik_racunara GetVlasnikRacunara(long idVlasnika);
        [OperationContract]
        Komponenta GetKomponentu(int idKomponente);
        [OperationContract]
        Garantni_list GetGarantni_list(int idGarantnog_lista);
        [OperationContract]
        Posjeduje GetPosjeduje(int idRacunara, long jmbgVl);
        [OperationContract]
        SastojiSe GetSastojiSe(int idk1, int idk2);
        [OperationContract]
        Radi GetRadi(long jmbgServisera, int idServisa);
        [OperationContract]
        Donosi GetDonosi(long jmbgVl, int idRacunara, int idServisa);
        [OperationContract]
        Servisira GetServisira(long jmbgVl, int idRacunara, int idServisa, long jmbgS);
    }
}
