using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    [ServiceContract]
    public interface IDeleteEntity
    {
        [OperationContract]
        bool DeleteServis(int idServisa);
        [OperationContract]
        bool DeleteServiserRacunara(long idServisera);
        [OperationContract]
        bool DeleteRacunar(int idRacunara);
        [OperationContract]
        bool DeleteVlasnikRacunara(long idVlasnika);
        [OperationContract]
        bool DeleteKomponentu(int idKomponente);
        [OperationContract]
        bool DeleteGarantni_list(int idGarantnog_lista);
        [OperationContract]
        bool DeletePosjeduje(int idRacunara, long jmbgVl);
        [OperationContract]
        bool DeleteSastojiSe(int idk1, int idk2);
        [OperationContract]
        bool DeleteRadi(long jmbgServisera, int idServisa);
        [OperationContract]
        bool DeleteDonosi(long jmbgVl, int idRacunara, int idServisa);
        [OperationContract]
        bool DeleteServisira(long jmbgVl, int idRacunara, int idServisa, long jmbgS);
        [OperationContract]
        bool ObrisiKorisnika(long korisnickoIme);

    }
}
