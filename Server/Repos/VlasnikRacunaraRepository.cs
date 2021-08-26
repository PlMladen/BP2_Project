using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repos
{
    public class VlasnikRacunaraRepository
    {
        private readonly ProjectDbContext dbCtx;

        public VlasnikRacunaraRepository(ProjectDbContext context)
        {
            dbCtx = context;
        }

        public bool Add(Common.Models.Vlasnik_racunara vlasnik)
        {
            if (dbCtx.Vlasnik_racunaraSet.FirstOrDefault((s) => s.JMBG_vl == vlasnik.JMBG_vl) != null)
            {
                return false;
            }
            try
            {
                dbCtx.Vlasnik_racunaraSet.Add(new Vlasnik_racunara()
                {
                    JMBG_vl = vlasnik.JMBG_vl,
                    Dat_rodjenja_vl = vlasnik.Dat_rodjenja_vl,
                    Ime_vl = vlasnik.Ime_vl,
                    Prezime_vl = vlasnik.Prezime_vl,
                    Adresa_vl = new Adresa()
                    {
                        Ulica = vlasnik.Adresa_vl.Ulica,
                        Broj = vlasnik.Adresa_vl.Broj,
                        Grad = vlasnik.Adresa_vl.Grad,
                        PostanskiBroj = vlasnik.Adresa_vl.PostanskiBroj
                    }
                });
            }
            catch (Exception e)
            {

            }
            return dbCtx.SaveChanges() > 0;
        }

        private bool ObrisiKorisnika(long idVlasnika)
        {
            
            try
            {
                var s = dbCtx.Database.ExecuteSqlCommand(String.Format("delete from korisnici where JMBGKorisnika={0}", idVlasnika));
                if (s != 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {

            }
            return false;
        }

        public bool Delete(long idVlasnika)
        {
            try
            {
                dbCtx.Vlasnik_racunaraSet.Remove(dbCtx.Vlasnik_racunaraSet.FirstOrDefault((s) => s.JMBG_vl == idVlasnika));
                dbCtx.PosjedujeSet.RemoveRange(dbCtx.PosjedujeSet.Where(s => s.Vlasnik_racunaraJMBG_vl == idVlasnika));
                dbCtx.SaveChanges();
                if (ObrisiKorisnika(idVlasnika))
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public IEnumerable<Common.Models.Vlasnik_racunara> GetAll()
        {
            var retVal = new List<Common.Models.Vlasnik_racunara>();
            foreach (var vlasnikFromDb in dbCtx.Vlasnik_racunaraSet.ToList())
            {
                var vlasnik = new Common.Models.Vlasnik_racunara()
                {
                    JMBG_vl = vlasnikFromDb.JMBG_vl,
                    Dat_rodjenja_vl = vlasnikFromDb.Dat_rodjenja_vl,
                    Ime_vl = vlasnikFromDb.Ime_vl,
                    Prezime_vl = vlasnikFromDb.Prezime_vl,
                    Adresa_vl = new Common.Models.Adresa()
                    {
                        Ulica = vlasnikFromDb.Adresa_vl.Ulica,
                        Broj = vlasnikFromDb.Adresa_vl.Broj,
                        Grad = vlasnikFromDb.Adresa_vl.Grad,
                        PostanskiBroj = vlasnikFromDb.Adresa_vl.PostanskiBroj
                    }
                };
                retVal.Add(vlasnik);
            }
            return retVal;
        }

        public Common.Models.Vlasnik_racunara Get(long idVlasnika)
        {
            var vlasnikFromDb = dbCtx.Vlasnik_racunaraSet.Find(idVlasnika);
            if (vlasnikFromDb != null)
            {
                var vlasnik = new Common.Models.Vlasnik_racunara()
                {
                    JMBG_vl = vlasnikFromDb.JMBG_vl,
                    Dat_rodjenja_vl = vlasnikFromDb.Dat_rodjenja_vl,
                    Ime_vl = vlasnikFromDb.Ime_vl,
                    Prezime_vl = vlasnikFromDb.Prezime_vl,
                    Adresa_vl = new Common.Models.Adresa()
                    {
                        Ulica = vlasnikFromDb.Adresa_vl.Ulica,
                        Broj = vlasnikFromDb.Adresa_vl.Broj,
                        Grad = vlasnikFromDb.Adresa_vl.Grad,
                        PostanskiBroj = vlasnikFromDb.Adresa_vl.PostanskiBroj
                    }
                };
                return vlasnik;
            }
            return null;
        }
        public void Update(Common.Models.Vlasnik_racunara vlasnik)
        {
            var vlasnikForDb = new Vlasnik_racunara()
            {
                JMBG_vl = vlasnik.JMBG_vl,
                Dat_rodjenja_vl = vlasnik.Dat_rodjenja_vl,
                Ime_vl = vlasnik.Ime_vl,
                Prezime_vl = vlasnik.Prezime_vl,
                Adresa_vl = new Adresa()
                {
                    Ulica = vlasnik.Adresa_vl.Ulica,
                    Broj = vlasnik.Adresa_vl.Broj,
                    Grad = vlasnik.Adresa_vl.Grad,
                    PostanskiBroj = vlasnik.Adresa_vl.PostanskiBroj
                }
            };

            try
            {
                var vlasnikFromDb = dbCtx.Vlasnik_racunaraSet.FirstOrDefault((s) => s.JMBG_vl == vlasnikForDb.JMBG_vl);
                dbCtx.Entry(vlasnikFromDb).CurrentValues.SetValues(vlasnikForDb);
                dbCtx.SaveChanges();
            }catch(Exception e)
            {

            }
        }
    }
}
