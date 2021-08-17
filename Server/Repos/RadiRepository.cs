using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repos
{
    public class RadiRepository
    {
        private readonly ProjectDbContext dbCtx;

        public RadiRepository(ProjectDbContext context)
        {
            dbCtx = context;
        }

        public bool Add(Common.Models.Radi radi)
        {
            if (dbCtx.RadiSet.FirstOrDefault((s) => s.Racunarski_servisID_servisa == radi.Racunarski_servisID_servisa1 && s.Serviser_racunaraJMBG_s == radi.Serviser_racunaraJMBG_s) != null)
            {
                return false;
            }
            
            Radi r = new Radi()
            {
                Racunarski_servisID_servisa = radi.Racunarski_servisID_servisa1,
                Serviser_racunaraJMBG_s = radi.Serviser_racunaraJMBG_s
            };
            dbCtx.RadiSet.Add(r);
            
            return dbCtx.SaveChanges() > 0;
        }

       
        public Common.Models.Radi Get(long jmbgServisera, int idServisa)
        {
            var radiFromDb = dbCtx.RadiSet.FirstOrDefault(s => s.Racunarski_servisID_servisa == idServisa && s.Serviser_racunaraJMBG_s == jmbgServisera);
            if (radiFromDb != null)
            {
                var radi = new Common.Models.Radi()
                {
                    Racunarski_servisID_servisa1 = radiFromDb.Racunarski_servisID_servisa,
                    Serviser_racunaraJMBG_s = radiFromDb.Serviser_racunaraJMBG_s,
                    Serviser_racunara = new Common.Models.Serviser_racunara()
                    {
                        Dat_rodjenja_s = radiFromDb.Serviser_racunara.Dat_rodjenja_s,
                        Ime_s = radiFromDb.Serviser_racunara.Ime_s,
                        JMBG_s = radiFromDb.Serviser_racunara.JMBG_s,
                        Prezime_s = radiFromDb.Serviser_racunara.Prezime_s
                    },
                    Racunarski_servis = new Common.Models.Racunarski_servis()
                    {
                        ID_servisa = radiFromDb.Racunarski_servis.ID_servisa,
                        Naziv_serv = radiFromDb.Racunarski_servis.Naziv_serv,
                        Tip_serv = (Common.Models.Tip_servisa)radiFromDb.Racunarski_servis.Tip_serv,
                        Br_tel_serv = new Common.Models.Broj_telefona()
                        {
                            Broj = radiFromDb.Racunarski_servis.Br_tel_serv.Broj,
                            Okrug = radiFromDb.Racunarski_servis.Br_tel_serv.Okrug,
                            Pozivni_broj = radiFromDb.Racunarski_servis.Br_tel_serv.Pozivni_broj
                        },
                        Adresa_serv = new Common.Models.Adresa()
                        {
                            Broj = radiFromDb.Racunarski_servis.Adresa_serv.Broj,
                            Grad = radiFromDb.Racunarski_servis.Adresa_serv.Grad,
                            PostanskiBroj = radiFromDb.Racunarski_servis.Adresa_serv.PostanskiBroj,
                            Ulica = radiFromDb.Racunarski_servis.Adresa_serv.Ulica
                        }
                    }
                };
                return radi;
            }
            return null;
        }

        public IEnumerable<Common.Models.Radi> GetAll()
        {
            var retVal = new List<Common.Models.Radi>();
            foreach (var radiFromDb in dbCtx.RadiSet.ToList())
            {
                var radi = new Common.Models.Radi()
                {
                    Racunarski_servisID_servisa1 = radiFromDb.Racunarski_servisID_servisa,
                    Serviser_racunaraJMBG_s = radiFromDb.Serviser_racunaraJMBG_s,
                    Serviser_racunara = new Common.Models.Serviser_racunara()
                    {
                        Dat_rodjenja_s = radiFromDb.Serviser_racunara.Dat_rodjenja_s,
                        Ime_s = radiFromDb.Serviser_racunara.Ime_s,
                        JMBG_s = radiFromDb.Serviser_racunara.JMBG_s,
                        Prezime_s = radiFromDb.Serviser_racunara.Prezime_s
                    },
                    Racunarski_servis = new Common.Models.Racunarski_servis()
                    {
                        ID_servisa = radiFromDb.Racunarski_servis.ID_servisa,
                        Naziv_serv = radiFromDb.Racunarski_servis.Naziv_serv,
                        Tip_serv = (Common.Models.Tip_servisa)radiFromDb.Racunarski_servis.Tip_serv,
                        Br_tel_serv = new Common.Models.Broj_telefona()
                        {
                            Broj = radiFromDb.Racunarski_servis.Br_tel_serv.Broj,
                            Okrug = radiFromDb.Racunarski_servis.Br_tel_serv.Okrug,
                            Pozivni_broj = radiFromDb.Racunarski_servis.Br_tel_serv.Pozivni_broj
                        },
                        Adresa_serv = new Common.Models.Adresa()
                        {
                            Broj = radiFromDb.Racunarski_servis.Adresa_serv.Broj,
                            Grad = radiFromDb.Racunarski_servis.Adresa_serv.Grad,
                            PostanskiBroj = radiFromDb.Racunarski_servis.Adresa_serv.PostanskiBroj,
                            Ulica = radiFromDb.Racunarski_servis.Adresa_serv.Ulica
                        }
                    }
                }; 
                retVal.Add(radi);
            }
            return retVal;
        }
        public bool Delete(long jmbgServisera, int idServisa)
        {
            try
            {
                Radi r = dbCtx.RadiSet.FirstOrDefault((s) => s.Racunarski_servisID_servisa == idServisa && s.Serviser_racunaraJMBG_s == jmbgServisera);

                dbCtx.RadiSet.Remove(r);
                dbCtx.Serviser_racunaraSet.FirstOrDefault(s => s.JMBG_s == jmbgServisera).Radi.Remove(r);
                Racunarski_servis rs = (Racunarski_servis)dbCtx.ServisSet.FirstOrDefault(s => s.ID_servisa == idServisa);
                rs.Radi.Remove(r);
                dbCtx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public void Update(Common.Models.Radi radi)
        {
            var RadiForDb = new Radi()
            {
                Racunarski_servisID_servisa = radi.Racunarski_servis.ID_servisa,
                Serviser_racunaraJMBG_s = radi.Serviser_racunara.JMBG_s
            };

            try
            {
                var radiFromDb = dbCtx.RadiSet.FirstOrDefault((s) => s.Serviser_racunaraJMBG_s == radi.Serviser_racunaraJMBG_s && s.Racunarski_servisID_servisa == radi.Racunarski_servisID_servisa1);
                dbCtx.RadiSet.Remove(radiFromDb);
                dbCtx.RadiSet.Add(RadiForDb);
                dbCtx.SaveChanges();
            }catch(Exception e)
            {

            }
        }
    }
}
