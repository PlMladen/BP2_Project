using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repos
{
    public class ServisiraRepository
    {
        private readonly ProjectDbContext dbCtx;

        public ServisiraRepository(ProjectDbContext context)
        {
            dbCtx = context;
        }

        public bool Add(Common.Models.Servisira servisira)
        {
            if (dbCtx.ServisiraSet.FirstOrDefault((s) => s.DonosiPosjedujeRacunarID_racunara == servisira.DonosiPosjedujeRacunarID_racunara &&
                                                      s.DonosiPosjedujeVlasnik_racunaraJMBG_vl == servisira.DonosiPosjedujeVlasnik_racunaraJMBG_vl &&
                                                      s.DonosiRacunarski_servisID_servisa == servisira.DonosiRacunarski_servisID_servisa &&
                                                      s.RadiRacunarski_servisID_servisa == servisira.RadiRacunarski_servisID_servisa &&
                                                      s.RadiServiser_racunaraJMBG_s == servisira.RadiServiser_racunaraJMBG_s) != null)
            {
                return false;
            }

            Servisira ser = new Servisira()
            {
                RadiServiser_racunaraJMBG_s = servisira.RadiServiser_racunaraJMBG_s,
                RadiRacunarski_servisID_servisa = servisira.RadiRacunarski_servisID_servisa,
                DonosiRacunarski_servisID_servisa = servisira.DonosiRacunarski_servisID_servisa,
                DonosiPosjedujeVlasnik_racunaraJMBG_vl = servisira.DonosiPosjedujeVlasnik_racunaraJMBG_vl,
                DonosiPosjedujeRacunarID_racunara = servisira.DonosiPosjedujeRacunarID_racunara,
                Cijena_serv = servisira.Cijena_serv,
                Dat_potp = servisira.Dat_potp,
                Garantni_listId_gar_list = servisira.Garantni_listId_gar_list

            };
            dbCtx.ServisiraSet.Add(ser);
            //Racunarski_servis rs = (Racunarski_servis)dbCtx.ServisSet.FirstOrDefault(s => s.ID_servisa == d.Racunarski_servisID_servisa);
            //rs.Donosi.Add(d);

            return dbCtx.SaveChanges() > 0;
        }

        public Common.Models.Servisira Get(long jmbgVl, int idRacunara, int idServisa, long jmbgS)
        {
            var servisiraFromDb = dbCtx.ServisiraSet.FirstOrDefault((s) => s.DonosiPosjedujeRacunarID_racunara == idRacunara &&
                                                                          s.DonosiPosjedujeVlasnik_racunaraJMBG_vl == jmbgVl &&
                                                                          s.DonosiRacunarski_servisID_servisa == idServisa &&
                                                                          s.RadiRacunarski_servisID_servisa == idServisa &&
                                                                          s.RadiServiser_racunaraJMBG_s == jmbgS);
            if (servisiraFromDb != null)
            {
                var servisira = new Common.Models.Servisira()
                {
                     Cijena_serv = servisiraFromDb.Cijena_serv,
                     Dat_potp = servisiraFromDb.Dat_potp,
                     Garantni_listId_gar_list = servisiraFromDb.Garantni_listId_gar_list,
                     DonosiPosjedujeRacunarID_racunara = servisiraFromDb.DonosiPosjedujeRacunarID_racunara,
                     DonosiPosjedujeVlasnik_racunaraJMBG_vl = servisiraFromDb.DonosiPosjedujeVlasnik_racunaraJMBG_vl,
                     DonosiRacunarski_servisID_servisa = servisiraFromDb.DonosiRacunarski_servisID_servisa,
                     RadiRacunarski_servisID_servisa = servisiraFromDb.RadiRacunarski_servisID_servisa,
                     RadiServiser_racunaraJMBG_s = servisiraFromDb.RadiServiser_racunaraJMBG_s
                };
                return servisira;
            }
            return null;
        }

        public IEnumerable<Common.Models.Servisira> GetAll()
        {
            var retVal = new List<Common.Models.Servisira>();
            foreach (var servisiraFromDb in dbCtx.ServisiraSet.ToList())
            {
                var servisira = new Common.Models.Servisira()
                {
                    Cijena_serv = servisiraFromDb.Cijena_serv,
                    Dat_potp = servisiraFromDb.Dat_potp,
                    Garantni_listId_gar_list = servisiraFromDb.Garantni_listId_gar_list,
                    DonosiPosjedujeRacunarID_racunara = servisiraFromDb.DonosiPosjedujeRacunarID_racunara,
                    DonosiPosjedujeVlasnik_racunaraJMBG_vl = servisiraFromDb.DonosiPosjedujeVlasnik_racunaraJMBG_vl,
                    DonosiRacunarski_servisID_servisa = servisiraFromDb.DonosiRacunarski_servisID_servisa,
                    RadiRacunarski_servisID_servisa = servisiraFromDb.RadiRacunarski_servisID_servisa,
                    RadiServiser_racunaraJMBG_s = servisiraFromDb.RadiServiser_racunaraJMBG_s,
                    Radi = new Common.Models.Radi()
                    {
                        Racunarski_servis = new Common.Models.Racunarski_servis()
                        {
                            ID_servisa = servisiraFromDb.Radi.Racunarski_servis.ID_servisa,
                            Naziv_serv = servisiraFromDb.Radi.Racunarski_servis.Naziv_serv,
                            Adresa_serv = new Common.Models.Adresa()
                            {
                                Broj = servisiraFromDb.Radi.Racunarski_servis.Adresa_serv.Broj,
                                Grad = servisiraFromDb.Radi.Racunarski_servis.Adresa_serv.Grad,
                                PostanskiBroj = servisiraFromDb.Radi.Racunarski_servis.Adresa_serv.PostanskiBroj,
                                Ulica = servisiraFromDb.Radi.Racunarski_servis.Adresa_serv.Ulica
                            },
                            Br_tel_serv = new Common.Models.Broj_telefona()
                            {
                                Broj = servisiraFromDb.Radi.Racunarski_servis.Br_tel_serv.Broj,
                                Okrug = servisiraFromDb.Radi.Racunarski_servis.Br_tel_serv.Okrug,
                                Pozivni_broj = servisiraFromDb.Radi.Racunarski_servis.Br_tel_serv.Pozivni_broj
                            },
                            Tip_serv = (Common.Models.Tip_servisa)servisiraFromDb.Radi.Racunarski_servis.Tip_serv
                        },
                        Serviser_racunara = new Common.Models.Serviser_racunara()
                        {
                            Ime_s = servisiraFromDb.Radi.Serviser_racunara.Ime_s,
                            Prezime_s = servisiraFromDb.Radi.Serviser_racunara.Prezime_s,
                            JMBG_s = servisiraFromDb.Radi.Serviser_racunara.JMBG_s,
                            Dat_rodjenja_s = servisiraFromDb.Radi.Serviser_racunara.Dat_rodjenja_s,
                            
                        }
                    },
                    Donosi = new Common.Models.Donosi()
                    {
                        PosjedujeRacunarID_racunara = servisiraFromDb.Donosi.PosjedujeRacunarID_racunara,
                        PosjedujeVlasnik_racunaraJMBG_vl = servisiraFromDb.Donosi.PosjedujeVlasnik_racunaraJMBG_vl,
                        Pposjeduje = new Common.Models.Posjeduje()
                        {
                            Id_racunara = servisiraFromDb.Donosi.Posjeduje.RacunarID_racunara,
                            Ime_vl = servisiraFromDb.Donosi.Posjeduje.Vlasnik_racunara.Ime_vl,
                            JMBG_vl = servisiraFromDb.Donosi.Posjeduje.Vlasnik_racunara.JMBG_vl,
                            Prezime_vl = servisiraFromDb.Donosi.Posjeduje.Vlasnik_racunara.Prezime_vl,
                            Proizvodjac_racunara = servisiraFromDb.Donosi.Posjeduje.Racunar.Proizvodjac,
                            Vlasnik_racunara = new Common.Models.Vlasnik_racunara()
                            {
                                Ime_vl = servisiraFromDb.Donosi.Posjeduje.Vlasnik_racunara.Ime_vl,
                                Prezime_vl = servisiraFromDb.Donosi.Posjeduje.Vlasnik_racunara.Prezime_vl
                            },
                            Vrsta_racunara = (Common.Models.Vrsta_racunara)servisiraFromDb.Donosi.Posjeduje.Racunar.Vrsta_racunara
                        }
                    },
                    Garantni_list = new Common.Models.Garantni_list()
                    {
                        Id_gar_list = servisiraFromDb.Garantni_list.Id_gar_list,
                        Period_vazenja = servisiraFromDb.Garantni_list.Period_vazenja
                    }
                };
                retVal.Add(servisira);
            }
            return retVal;
        }
        public bool Delete(long jmbgVl, int idRacunara, int idServisa, long jmbgS)
        {
            try
            {
                Servisira ser = dbCtx.ServisiraSet.FirstOrDefault((s) => s.DonosiPosjedujeRacunarID_racunara == idRacunara &&
                                                                          s.DonosiPosjedujeVlasnik_racunaraJMBG_vl == jmbgVl &&
                                                                          s.DonosiRacunarski_servisID_servisa == idServisa &&
                                                                          s.RadiRacunarski_servisID_servisa == idServisa &&
                                                                          s.RadiServiser_racunaraJMBG_s == jmbgS);

                dbCtx.ServisiraSet.Remove(ser);
                
                dbCtx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public void Update(Common.Models.Servisira servisira)
        {
            var ServisiraForDb = new Servisira()
            {
                RadiServiser_racunaraJMBG_s = servisira.Radi.Serviser_racunaraJMBG_s,
                RadiRacunarski_servisID_servisa = servisira.Radi.Racunarski_servisID_servisa1,
                DonosiRacunarski_servisID_servisa = servisira.Donosi.Racunarski_servisID_servisa,
                DonosiPosjedujeVlasnik_racunaraJMBG_vl = servisira.Donosi.PosjedujeVlasnik_racunaraJMBG_vl,
                DonosiPosjedujeRacunarID_racunara = servisira.Donosi.PosjedujeRacunarID_racunara,
                Cijena_serv = servisira.Cijena_serv,
                Dat_potp = servisira.Dat_potp,
                Garantni_listId_gar_list = servisira.Garantni_listId_gar_list
            };

            try
            {
                var servisiraFromDb = dbCtx.ServisiraSet.FirstOrDefault((s) => s.DonosiPosjedujeRacunarID_racunara == servisira.DonosiPosjedujeRacunarID_racunara &&
                                                          s.DonosiPosjedujeVlasnik_racunaraJMBG_vl == servisira.DonosiPosjedujeVlasnik_racunaraJMBG_vl &&
                                                          s.DonosiRacunarski_servisID_servisa == servisira.DonosiRacunarski_servisID_servisa &&
                                                          s.RadiRacunarski_servisID_servisa == servisira.RadiRacunarski_servisID_servisa &&
                                                          s.RadiServiser_racunaraJMBG_s == servisira.RadiServiser_racunaraJMBG_s);
                dbCtx.ServisiraSet.Remove(servisiraFromDb);
                dbCtx.ServisiraSet.Add(ServisiraForDb);
                dbCtx.SaveChanges();
            }catch(Exception e)
            {

            }
        }
    }
}
