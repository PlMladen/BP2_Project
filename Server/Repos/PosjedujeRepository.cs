using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repos
{
    public class PosjedujeRepository
    {
        private readonly ProjectDbContext dbCtx;

        public PosjedujeRepository(ProjectDbContext context)
        {
            dbCtx = context;
        }

        public bool Add(Common.Models.Posjeduje posjeduje)
        {
            if (dbCtx.PosjedujeSet.FirstOrDefault((s) => s.RacunarID_racunara == posjeduje.Id_racunara && s.Vlasnik_racunaraJMBG_vl == posjeduje.JMBG_vl) != null)
            {
                return false;
            }

            Posjeduje p = new Posjeduje()
            {
                RacunarID_racunara = posjeduje.Id_racunara,
                Vlasnik_racunaraJMBG_vl = posjeduje.JMBG_vl,
               
            };
            dbCtx.PosjedujeSet.Add(p);
            dbCtx.Vlasnik_racunaraSet.FirstOrDefault(s => s.JMBG_vl == p.Vlasnik_racunaraJMBG_vl).Posjeduje.Add(p);
            dbCtx.RacunarSet.FirstOrDefault(s => s.ID_racunara == p.RacunarID_racunara).Posjeduje.Add(p);

            return dbCtx.SaveChanges() > 0;
        }

        public Common.Models.Posjeduje Get(long jmbgVl, int idRacunara)
        {
            var posjedujeFromDb = dbCtx.PosjedujeSet.FirstOrDefault(s => s.RacunarID_racunara == idRacunara && s.Vlasnik_racunaraJMBG_vl == jmbgVl);
            if (posjedujeFromDb != null)
            {
                var posjeduje = new Common.Models.Posjeduje()
                {
                    Id_racunara = posjedujeFromDb.RacunarID_racunara,
                    JMBG_vl = posjedujeFromDb.Vlasnik_racunaraJMBG_vl,
                    Racunar = new Common.Models.Racunar() { 
                        ID_racunara = posjedujeFromDb.Racunar.ID_racunara,
                        Brzina_procesora = posjedujeFromDb.Racunar.Brzina_procesora,
                        Kapacitet_memorije = posjedujeFromDb.Racunar.Kapacitet_memorije,
                        Kapacitet_RAM = posjedujeFromDb.Racunar.Kapacitet_RAM,
                        Proizvodjac = posjedujeFromDb.Racunar.Proizvodjac,
                        Vrsta_racunara = (Common.Models.Vrsta_racunara)posjedujeFromDb.Racunar.Vrsta_racunara,
                        
                    },
                    Vlasnik_racunara = new Common.Models.Vlasnik_racunara()
                    {
                        JMBG_vl = posjedujeFromDb.Vlasnik_racunara.JMBG_vl,
                        Prezime_vl = posjedujeFromDb.Vlasnik_racunara.Prezime_vl,
                        Ime_vl = posjedujeFromDb.Vlasnik_racunara.Ime_vl,
                        Dat_rodjenja_vl = posjedujeFromDb.Vlasnik_racunara.Dat_rodjenja_vl,
                        Adresa_vl = new Common.Models.Adresa()
                        {
                            Ulica = posjedujeFromDb.Vlasnik_racunara.Adresa_vl.Ulica,
                            Broj = posjedujeFromDb.Vlasnik_racunara.Adresa_vl.Broj,
                            Grad = posjedujeFromDb.Vlasnik_racunara.Adresa_vl.Grad,
                            PostanskiBroj = posjedujeFromDb.Vlasnik_racunara.Adresa_vl.PostanskiBroj
                        }
                    },
                    Ime_vl = posjedujeFromDb.Vlasnik_racunara.Ime_vl,
                    Prezime_vl = posjedujeFromDb.Vlasnik_racunara.Prezime_vl,
                    Proizvodjac_racunara = posjedujeFromDb.Racunar.Proizvodjac,
                    Vrsta_racunara = (Common.Models.Vrsta_racunara)posjedujeFromDb.Racunar.Vrsta_racunara
                };
                return posjeduje;
            }
            return null;
        }

        public IEnumerable<Common.Models.Posjeduje> GetAll()
        {
            var retVal = new List<Common.Models.Posjeduje>();
            foreach (var posjedujeFromDb in dbCtx.PosjedujeSet.ToList())
            {
                var posjeduje = new Common.Models.Posjeduje()
                {
                    Id_racunara = posjedujeFromDb.RacunarID_racunara,
                    JMBG_vl = posjedujeFromDb.Vlasnik_racunaraJMBG_vl,
                    Racunar = new Common.Models.Racunar()
                    {
                        ID_racunara = posjedujeFromDb.Racunar.ID_racunara,
                        Brzina_procesora = posjedujeFromDb.Racunar.Brzina_procesora,
                        Kapacitet_memorije = posjedujeFromDb.Racunar.Kapacitet_memorije,
                        Kapacitet_RAM = posjedujeFromDb.Racunar.Kapacitet_RAM,
                        Proizvodjac = posjedujeFromDb.Racunar.Proizvodjac,
                        Vrsta_racunara = (Common.Models.Vrsta_racunara)posjedujeFromDb.Racunar.Vrsta_racunara,

                    },
                    Vlasnik_racunara = new Common.Models.Vlasnik_racunara()
                    {
                        JMBG_vl = posjedujeFromDb.Vlasnik_racunara.JMBG_vl,
                        Prezime_vl = posjedujeFromDb.Vlasnik_racunara.Prezime_vl,
                        Ime_vl = posjedujeFromDb.Vlasnik_racunara.Ime_vl,
                        Dat_rodjenja_vl = posjedujeFromDb.Vlasnik_racunara.Dat_rodjenja_vl,
                        Adresa_vl = new Common.Models.Adresa()
                        {
                            Ulica = posjedujeFromDb.Vlasnik_racunara.Adresa_vl.Ulica,
                            Broj = posjedujeFromDb.Vlasnik_racunara.Adresa_vl.Broj,
                            Grad = posjedujeFromDb.Vlasnik_racunara.Adresa_vl.Grad,
                            PostanskiBroj = posjedujeFromDb.Vlasnik_racunara.Adresa_vl.PostanskiBroj
                        }
                    },
                    Ime_vl = posjedujeFromDb.Vlasnik_racunara.Ime_vl,
                    Prezime_vl = posjedujeFromDb.Vlasnik_racunara.Prezime_vl,
                    Proizvodjac_racunara = posjedujeFromDb.Racunar.Proizvodjac,
                    Vrsta_racunara = (Common.Models.Vrsta_racunara)posjedujeFromDb.Racunar.Vrsta_racunara
                };
                retVal.Add(posjeduje);
            }
            return retVal;
        }
        public bool Delete(long jmbgVl, int idRacunara)
        {
            try
            {
                Posjeduje p = dbCtx.PosjedujeSet.FirstOrDefault((s) => s.RacunarID_racunara == idRacunara && s.Vlasnik_racunaraJMBG_vl == jmbgVl);
                
                dbCtx.PosjedujeSet.Remove(p);
                dbCtx.Vlasnik_racunaraSet.FirstOrDefault(s => s.JMBG_vl == jmbgVl).Posjeduje.Remove(p);
                dbCtx.RacunarSet.FirstOrDefault(s => s.ID_racunara == idRacunara).Posjeduje.Remove(p);
                dbCtx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public void Update(Common.Models.Posjeduje posjeduje)
        {
            var PosjedujeForDb = new Posjeduje()
            {
                RacunarID_racunara = posjeduje.Racunar.ID_racunara,
                Vlasnik_racunaraJMBG_vl = posjeduje.Vlasnik_racunara.JMBG_vl
            };

            try
            {
                var posjedujeFromDb = dbCtx.PosjedujeSet.FirstOrDefault((s) => s.Vlasnik_racunaraJMBG_vl == posjeduje.JMBG_vl && s.RacunarID_racunara == posjeduje.Id_racunara);
                dbCtx.PosjedujeSet.Remove(posjedujeFromDb);
                dbCtx.PosjedujeSet.Add(PosjedujeForDb);
                dbCtx.SaveChanges();
            }catch(Exception e)
            {

            }
        }
    }
}
