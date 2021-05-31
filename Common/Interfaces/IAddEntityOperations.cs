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
    public interface IAddEntityOperations
    {
        [OperationContract]
        bool AddServis(Servis servis);
        [OperationContract]
        bool AddServiserRacunara(Serviser_racunara serviser);
        [OperationContract]
        bool AddRacunar(Racunar racunar);
        [OperationContract]
        bool AddVlasnikRacunara(Vlasnik_racunara vlasnik);
        [OperationContract]
        bool AddKomponentu(Komponenta komponenta);
        [OperationContract]
        bool AddGarantni_list(Garantni_list garantni_List);
        [OperationContract]
        bool AddPosjeduje(Posjeduje posjeduje);
        [OperationContract]
        bool AddSastojiSe(SastojiSe sastojiSe);
        [OperationContract]
        bool AddRadi(Radi radi);
        [OperationContract]
        bool AddDonosi(Donosi donosi);
        [OperationContract]
        bool AddServisira(Servisira servisira);
    }
}
