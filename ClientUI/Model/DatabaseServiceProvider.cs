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
    }
}
