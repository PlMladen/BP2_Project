using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ServerOperations : IMscOperations
    {
        MasterRepository masterRepository = new MasterRepository(new ProjectDbContext());
        #region ServisOps
        public bool AddServis(Common.Models.Servis servis)
        {
            return masterRepository.ServisRepository.Add(servis);
        }
        public bool DeleteServis(int idServisa)
        {
            return masterRepository.ServisRepository.Delete(idServisa);
        }
        public IEnumerable<Common.Models.Servis> GetAllServiss()
        {
            return masterRepository.ServisRepository.GetAll();
        }
        public Common.Models.Servis GetServis(int idServisa)
        {
            return masterRepository.ServisRepository.Get(idServisa);
        }
        public void UpdateServis(Common.Models.Servis servis)
        {
            masterRepository.ServisRepository.Update(servis);
        }
        #endregion
        #region ServiserRacunaraOps
        public bool AddServiserRacunara(Common.Models.Serviser_racunara serviser)
        {
            return masterRepository.ServiserRacunaraRepository.Add(serviser);
        }

        public bool DeleteServiserRacunara(long idServisera)
        {
            return masterRepository.ServiserRacunaraRepository.Delete(idServisera);
        }

        public IEnumerable<Common.Models.Serviser_racunara> GetAllServiseriRacunara()
        {
            return masterRepository.ServiserRacunaraRepository.GetAll();
        }

        public Common.Models.Serviser_racunara GetServiserRacunara(long idServisera)
        {
            return masterRepository.ServiserRacunaraRepository.Get(idServisera);
        }

        public void UpdateServiserRacunara(Common.Models.Serviser_racunara serviser)
        {
            masterRepository.ServiserRacunaraRepository.Update(serviser);
        }
        #endregion
        #region RacunarOps
        public bool AddRacunar(Common.Models.Racunar racunar)
        {
            return masterRepository.RacunarRepository.Add(racunar);
        }
        public bool DeleteRacunar(int idRacunar)
        {
            return masterRepository.RacunarRepository.Delete(idRacunar);
        }
        public IEnumerable<Common.Models.Racunar> GetAllRacunari()
        {
            return masterRepository.RacunarRepository.GetAll();
        }
        public Common.Models.Racunar GetRacunar(int idRacunar)
        {
            return masterRepository.RacunarRepository.GetRacunar(idRacunar);
        }
        public void UpdateRacunar(Common.Models.Racunar racunar)
        {
            masterRepository.RacunarRepository.Update(racunar);
        }
        #endregion
        #region VlasnikRacunaraOps
        public bool AddVlasnikRacunara(Common.Models.Vlasnik_racunara vlasnik)
        {
            return masterRepository.VlasnikRacunaraRepository.Add(vlasnik);
        }

        public bool DeleteVlasnikRacunara(long idVlasnika)
        {
            return masterRepository.VlasnikRacunaraRepository.Delete(idVlasnika);
        }

        public IEnumerable<Common.Models.Vlasnik_racunara> GetAllVlasniciRacunara()
        {
            return masterRepository.VlasnikRacunaraRepository.GetAll();
        }

        public Common.Models.Vlasnik_racunara GetVlasnikRacunara(long idVlasnika)
        {
            return masterRepository.VlasnikRacunaraRepository.Get(idVlasnika);
        }

        public void UpdateVlasnikRacunara(Common.Models.Vlasnik_racunara vlasnik)
        {
            masterRepository.VlasnikRacunaraRepository.Update(vlasnik);
        }
        #endregion
        #region KomponentaOps
        public bool AddKomponentu(Common.Models.Komponenta komponenta)
        {
            return masterRepository.KomponentaRepository.Add(komponenta);
        }
        public bool DeleteKomponentu(int idKomponente)
        {
            return masterRepository.KomponentaRepository.Delete(idKomponente);
        }
        public IEnumerable<Common.Models.Komponenta> GetAllKomponente()
        {
            return masterRepository.KomponentaRepository.GetAll();
        }
        public Common.Models.Komponenta GetKomponentu(int idKomponente)
        {
            return masterRepository.KomponentaRepository.Get(idKomponente);
        }
        public void UpdateKomponentu(Common.Models.Komponenta komponenta)
        {
            masterRepository.KomponentaRepository.Update(komponenta);
        }
        #endregion
        #region GarantniListOps
        public bool AddGarantni_list(Common.Models.Garantni_list garantni_list)
        {
            return masterRepository.GarantniListRepository.Add(garantni_list);
        }
        public bool DeleteGarantni_list(int idGarantnog_lista)
        {
            return masterRepository.GarantniListRepository.Delete(idGarantnog_lista);
        }
        public IEnumerable<Common.Models.Garantni_list> GetAllGarantni_listove()
        {
            return masterRepository.GarantniListRepository.GetAll();
        }
        public Common.Models.Garantni_list GetGarantni_list(int idGarantnog_lista)
        {
            return masterRepository.GarantniListRepository.Get(idGarantnog_lista);
        }
        public void UpdateGarantni_list(Common.Models.Garantni_list garantni_list)
        {
            masterRepository.GarantniListRepository.Update(garantni_list);
        }
        #endregion
    }
}
