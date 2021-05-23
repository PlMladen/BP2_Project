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
    public interface IGetAllEntities
    {
        [OperationContract]
        IEnumerable<Servis> GetAllServiss();
        [OperationContract]
        IEnumerable<Serviser_racunara> GetAllServiseriRacunara();
        [OperationContract]
        IEnumerable<Racunar> GetAllRacunari();
        [OperationContract]
        IEnumerable<Vlasnik_racunara> GetAllVlasniciRacunara();
        [OperationContract]
        IEnumerable<Komponenta> GetAllKomponente();
        [OperationContract]
        IEnumerable<Garantni_list> GetAllGarantni_listove();
    }
}
