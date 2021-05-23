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
        Serviser_racunara GetServiserRacunara(long idServisera);
        [OperationContract]
        Racunar GetRacunar(int idRacunara);
        [OperationContract]
        Vlasnik_racunara GetVlasnikRacunara(long idVlasnika);
        [OperationContract]
        Komponenta GetKomponentu(int idKomponente);
        [OperationContract]
        Garantni_list GetGarantni_list(int idGarantnog_lista);
    }
}
