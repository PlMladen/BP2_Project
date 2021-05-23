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
    public interface IUpdateEntity
    {
        [OperationContract]
        void UpdateServis(Servis servis);

        [OperationContract]
        void UpdateServiserRacunara(Serviser_racunara serviser);

        [OperationContract]
        void UpdateRacunar(Racunar racunar);

        [OperationContract]
        void UpdateVlasnikRacunara(Vlasnik_racunara vlasnik);
        [OperationContract]
        void UpdateKomponentu(Komponenta komponenta);
        [OperationContract]
        void UpdateGarantni_list(Garantni_list garantni_List);
    }
}
