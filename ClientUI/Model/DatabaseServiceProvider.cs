using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI
{
    public class DatabaseServiceProvider
    {
        public static DatabaseServiceProvider Instance { get; } = new DatabaseServiceProvider();
        private IMscOperations proxy;

        private DatabaseServiceProvider()
        {
            proxy = new ChannelFactory<IMscOperations>("ClientUI").CreateChannel();
        }
        #region ServisOps
        public bool AddServis(Servis servis)
        {
            return proxy.AddServis(servis);
        }

        public IEnumerable<Servis> GetAllServiss()
        {
            return proxy.GetAllServiss();
        }

        public Servis GetServis(int idServisa)
        {
            return proxy.GetServis(idServisa);
        }

        public bool DeleteServis(int idServisa)
        {
            return proxy.DeleteServis(idServisa);
        }

        public void UpdateServis(Servis servis)
        {
            proxy.UpdateServis(servis);
        }
        #endregion
        #region ServiserRacunaraOps
        public bool AddServiserRacunara(Serviser_racunara serviser)
        {
            return proxy.AddServiserRacunara(serviser);
        }

        public IEnumerable<Serviser_racunara> GetAllServiseriRacunara()
        {
            return proxy.GetAllServiseriRacunara();
        }

        public Serviser_racunara GetServiserRacunara(long idServisera)
        {
            return proxy.GetServiserRacunara(idServisera);
        }

        public bool DeleteServiserRacunara(long idServisera)
        {
            return proxy.DeleteServiserRacunara(idServisera);
        }

        public void UpdateServiserRacunara(Serviser_racunara serviser)
        {
            proxy.UpdateServiserRacunara(serviser);
        }
        #endregion
        #region RacunarOps
        public bool AddRacunar(Racunar racunar)
        {
            return proxy.AddRacunar(racunar);
        }

        public IEnumerable<Racunar> GetAllRacunari()
        {
            return proxy.GetAllRacunari();
        }

        public Racunar GetRacunar(int idRacunara)
        {
            return proxy.GetRacunar(idRacunara);
        }

        public bool DeleteRacunar(int idRacunar)
        {
            return proxy.DeleteRacunar(idRacunar);
        }

        public void UpdateRacunar(Racunar racunar)
        {
            proxy.UpdateRacunar(racunar);
        }
        #endregion
        #region VlasnikRacunaraOps
        public bool AddVlasnikRacunara(Vlasnik_racunara vlasnik)
        {
            return proxy.AddVlasnikRacunara(vlasnik);
        }

        public IEnumerable<Vlasnik_racunara> GetAllVlasniciRacunara()
        {
            return proxy.GetAllVlasniciRacunara();
        }

        public Vlasnik_racunara GetVlasnikRacunara(long idVlasnika)
        {
            return proxy.GetVlasnikRacunara(idVlasnika);
        }

        public bool DeleteVlasnikRacunara(long idVlasnika)
        {
            return proxy.DeleteVlasnikRacunara(idVlasnika);
        }

        public void UpdateVlasnikRacunara(Vlasnik_racunara vlasnik)
        {
            proxy.UpdateVlasnikRacunara(vlasnik);
        }
        #endregion
        #region KomponentaOps
        public bool AddKomponentu(Komponenta komponenta)
        {
            return proxy.AddKomponentu(komponenta);
        }

        public IEnumerable<Komponenta> GetAllKomponente()
        {
            return proxy.GetAllKomponente();
        }

        public Komponenta GetKomponentu(int idKomponente)
        {
            return proxy.GetKomponentu(idKomponente);
        }

        public bool DeleteKomponentu(int idKomponente)
        {
            return proxy.DeleteKomponentu(idKomponente);
        }

        public void UpdateKomponentu(Komponenta komponenta)
        {
            proxy.UpdateKomponentu(komponenta);
        }
        #endregion
        #region GarantniListOps
        public bool AddGarantni_list(Garantni_list garantni_List)
        {
            return proxy.AddGarantni_list(garantni_List);
        }

        public IEnumerable<Garantni_list> GetAllGarantni_listove()
        {
            return proxy.GetAllGarantni_listove();
        }

        public Garantni_list GetGarantni_list(int idGarantnog_lista)
        {
            return proxy.GetGarantni_list(idGarantnog_lista);
        }

        public bool DeleteGarantni_list(int idGarantnog_lista)
        {
            return proxy.DeleteGarantni_list(idGarantnog_lista);
        }

        public void UpdateGarantni_list(Garantni_list garantni_List)
        {
            proxy.UpdateGarantni_list(garantni_List);
        }
        #endregion
        #region Vlasnik_Racunar_Ops
        public bool AddPosjeduje(Posjeduje posjeduje)
        {
            return proxy.AddPosjeduje(posjeduje);
        }

        public IEnumerable<Posjeduje> GetAllPosjeduje()
        {
            return proxy.GetAllPosjeduje();
        }

        public Posjeduje GetPosjeduje(int idRacunara, long jmbgVl)
        {
            return proxy.GetPosjeduje(idRacunara, jmbgVl);
        }

        public bool DeletePosjeduje(int idRacunara, long jmbgVl)
        {
            return proxy.DeletePosjeduje(idRacunara, jmbgVl);
        }

        public void UpdatePosjeduje(Posjeduje posjeduje)
        {
            proxy.UpdatePosjeduje(posjeduje);
        }
        #endregion
        #region SastojiSe_Ops
        public bool AddSastojiSe(SastojiSe sastojiSe)
        {
            return proxy.AddSastojiSe(sastojiSe);
        }

        public IEnumerable<SastojiSe> GetAllSastojiSe()
        {
            return proxy.GetAllSastojiSe();
        }

        public SastojiSe GetSastojiSe(int idk1, int idk2)
        {
            return proxy.GetSastojiSe(idk1, idk2);
        }

        public bool DeleteSastojiSe(int idk1, int idk2)
        {
            return proxy.DeleteSastojiSe(idk1, idk2);
        }

        public void UpdateSastojiSe(SastojiSe sastojiSe)
        {
            proxy.UpdateSastojiSe(sastojiSe);
        }
        #endregion
        #region Radi_Ops
        public bool AddRadi(Radi radi)
        {
            return proxy.AddRadi(radi);
        }

        public IEnumerable<Radi> GetAllRadi()
        {
            return proxy.GetAllRadi();
        }

        public Radi GetRadi(long jmbgServisera, int idServisa)
        {
            return proxy.GetRadi(jmbgServisera, idServisa);
        }

        public bool DeleteRadi(long jmbgServisera, int idServisa)
        {
            return proxy.DeleteRadi(jmbgServisera, idServisa);
        }

        public void UpdateRadi(Radi radi)
        {
            proxy.UpdateRadi(radi);
        }
        #endregion
        #region Donosi_Ops
        public bool AddDonosi(Donosi donosi)
        {
            return proxy.AddDonosi(donosi);
        }

        public IEnumerable<Donosi> GetAllDonosi()
        {
            return proxy.GetAllDonosi();
        }

        public Donosi GetDonosi(long jmbgVl, int idRacunara, int idServisa)
        {
            return proxy.GetDonosi(jmbgVl, idRacunara, idServisa);
        }

        public bool DeleteDonosi(long jmbgVl, int idRacunara, int idServisa)
        {
            return proxy.DeleteDonosi(jmbgVl, idRacunara, idServisa);
        }

        public void UpdateDonosi(Donosi donosi)
        {
            proxy.UpdateDonosi(donosi);
        }
        #endregion
        #region Servisira_Ops
        public bool AddServisira(Servisira servisira)
        {
            return proxy.AddServisira(servisira);
        }

        public IEnumerable<Servisira> GetAllServisira()
        {
            return proxy.GetAllServisira();
        }

        public Servisira GetServisira(long jmbgVl, int idRacunara, int idServisa, long jmbgS)
        {
            return proxy.GetServisira(jmbgVl, idRacunara, idServisa, jmbgS);
        }

        public bool DeleteServisira(long jmbgVl, int idRacunara, int idServisa, long jmbgS)
        {
            return proxy.DeleteServisira(jmbgVl, idRacunara, idServisa, jmbgS);
        }

        public void UpdateServisira(Servisira servisira)
        {
            proxy.UpdateServisira(servisira);
        }
        #endregion

        public Racunarski_servis GetRacunarskiServis(int idServisa)
        {
            return proxy.GetRacunarskiServis(idServisa);
        }
        public int ReturnNumberOfUserComputersByType(long ownerId, Vrsta_racunara vrsta_Racunara)
        {
            return proxy.ReturnNumberOfUserComputersByType(ownerId, vrsta_Racunara);
        }
        public SqlUpitVlasnikServisCijena ReturnOwnerWithMaxRepairPrice()
        {
            return proxy.ReturnOwnerWithMaxRepairPrice();
        }


        public string ReturnTheOldestWorker(string nazivServisa)
        {
            return proxy.ReturnTheOldestWorker(nazivServisa);
        }

        public int ReturnCountOfAdultOwners()
        {
            return proxy.ReturnCountOfAdultOwners();
        }
    }
}
