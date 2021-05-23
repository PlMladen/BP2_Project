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

    }
}
