using Common.Interfaces;
using Common.Models;
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
        public IEnumerable<Common.Models.Racunar> GetAllMojiRacunari(long idVlasnika)
        {
            return masterRepository.RacunarRepository.GetAllMy(idVlasnika);
        }
        public IEnumerable<Common.Models.Racunar> GetAllNeprodatiRacunari()
        {
            return masterRepository.RacunarRepository.GetAllNeprodatiRacunari();
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
        #region Vlasnik_Racunar_Ops
        public bool AddPosjeduje(Common.Models.Posjeduje posjeduje)
        {
            return masterRepository.PosjedujeRepository.Add(posjeduje);
        }
        public bool DeletePosjeduje(int idRacunara, long jmbgVl)

        {
            return masterRepository.PosjedujeRepository.Delete(jmbgVl, idRacunara);
        }
        public IEnumerable<Common.Models.Posjeduje> GetAllPosjeduje()
        {
            return masterRepository.PosjedujeRepository.GetAll();
        }
        public Common.Models.Posjeduje GetPosjeduje(int idRacunara, long jmbgVl)
        {
            return masterRepository.PosjedujeRepository.Get(jmbgVl, idRacunara);
        }
        public void UpdatePosjeduje(Common.Models.Posjeduje posjeduje)
        {
            masterRepository.PosjedujeRepository.Update(posjeduje);
        }
        #endregion
        #region SastojiSe_Ops
        public bool AddSastojiSe(Common.Models.SastojiSe sastojiSe)
        {
            return masterRepository.SastojiSeRepository.Add(sastojiSe);
        }
        public bool DeleteSastojiSe(int idk1, int idk2)
        {
            return masterRepository.SastojiSeRepository.Delete(idk1, idk2);
        }
        public IEnumerable<Common.Models.SastojiSe> GetAllSastojiSe()
        {
            return masterRepository.SastojiSeRepository.GetAll();
        }
        public Common.Models.SastojiSe GetSastojiSe(int idk1, int idk2)
        {
            return masterRepository.SastojiSeRepository.Get(idk1, idk2);
        }
        public void UpdateSastojiSe(Common.Models.SastojiSe sastojiSe)
        {
            masterRepository.SastojiSeRepository.Update(sastojiSe);
        }
        #endregion
        #region Radi_Ops
        public bool AddRadi(Common.Models.Radi radi)
        {
            return masterRepository.RadiRepository.Add(radi);
        }
        public bool DeleteRadi(long jmbgServisera, int idServisa)
        {
            return masterRepository.RadiRepository.Delete(jmbgServisera, idServisa);
        }
        public IEnumerable<Common.Models.Radi> GetAllRadi()
        {
            return masterRepository.RadiRepository.GetAll();
        }
        public Common.Models.Radi GetRadi(long jmbgServisera, int idServisa)
        {
            return masterRepository.RadiRepository.Get(jmbgServisera, idServisa);
        }
        public void UpdateRadi(Common.Models.Radi radi)
        {
            masterRepository.RadiRepository.Update(radi);
        }
        #endregion
        #region Donosi_Ops
        public bool AddDonosi(Common.Models.Donosi donosi)
        {
            return masterRepository.DonosiRepository.Add(donosi);
        }
        public bool DeleteDonosi(long jmbgVl, int idRacunara, int idServisa)
        {
            return masterRepository.DonosiRepository.Delete(jmbgVl, idRacunara, idServisa);
        }
        public IEnumerable<Common.Models.Donosi> GetAllDonosi()
        {
            return masterRepository.DonosiRepository.GetAll();
        }
        public Common.Models.Donosi GetDonosi(long jmbgVl, int idRacunara, int idServisa)
        {
            return masterRepository.DonosiRepository.Get(jmbgVl, idRacunara, idServisa);
        }
        public void UpdateDonosi(Common.Models.Donosi donosi)
        {
            masterRepository.DonosiRepository.Update(donosi);
        }
        #endregion
        #region Servisira_Ops
        public bool AddServisira(Common.Models.Servisira servisira)
        {
            return masterRepository.ServisiraRepository.Add(servisira);
        }
        public bool DeleteServisira(long jmbgVl, int idRacunara, int idServisa, long jmbgS)
        {
            return masterRepository.ServisiraRepository.Delete(jmbgVl, idRacunara, idServisa, jmbgS);
        }
        public IEnumerable<Common.Models.Servisira> GetAllServisira()
        {
            return masterRepository.ServisiraRepository.GetAll();
        }
        public Common.Models.Servisira GetServisira(long jmbgVl, int idRacunara, int idServisa, long jmbgS)
        {
            return masterRepository.ServisiraRepository.Get(jmbgVl, idRacunara, idServisa, jmbgS);
        }
        public void UpdateServisira(Common.Models.Servisira servisira)
        {
            masterRepository.ServisiraRepository.Update(servisira);
        }


        #endregion

        public Common.Models.Racunarski_servis GetRacunarskiServis(int idServisa)
        {
            return masterRepository.RacunarskiServisRepository.Get(idServisa);
        }

        public int ReturnNumberOfUserComputersByType(long ownerId, Common.Models.Vrsta_racunara vrsta_Racunara)
        {
            return masterRepository.MiscRepository.ReturnNumberOfUserComputersByType(ownerId, (Vrsta_racunara)vrsta_Racunara);
        }

        public Common.Models.SqlUpitVlasnikServisCijena ReturnOwnerWithMaxRepairPrice()
        {
            return masterRepository.MiscRepository.ReturnOwnerWithMaxRepairPrice();
        }
        public string ReturnTheOldestWorker(string nazivServisa)
        {
            return masterRepository.MiscRepository.ReturnTheOldestWorker(nazivServisa);
        }
        public int ReturnCountOfAdultOwners()
        {
            return masterRepository.MiscRepository.ReturnCountOfAdultOwners();
        }

        public bool PrijaviKorisnika(string korisnickoIme, string lozinka)
        {
            return masterRepository.KorisnikRepository.PrijaviKorisnika(korisnickoIme, lozinka);
        }

        public bool RegistrujKorisnika(Korisnik korisnik)
        {
            return masterRepository.KorisnikRepository.RegistrujKorisnika(korisnik);
        }

        public string VratiUloguKorisnika(string korisnickoIme)
        {
            return masterRepository.KorisnikRepository.VratiUloguKorisnika(korisnickoIme);
        }
        public long VratiJMBGVlasnika(string korisnickoIme)
        {
            return masterRepository.KorisnikRepository.VratiJMBGVlasnika(korisnickoIme);
        }

        public int VratiIdServisa(long jmbgServisera)
        {
            return masterRepository.ServiserRacunaraRepository.VratiIdServisa(jmbgServisera);
        }
    }
}
