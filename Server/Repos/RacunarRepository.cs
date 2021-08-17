using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repos
{
    public class RacunarRepository
    {
        private readonly ProjectDbContext dbCtx;

        public RacunarRepository(ProjectDbContext db)
        {
            dbCtx = db;
        }

        public bool Add(Common.Models.Racunar racunar)
        {
            if(dbCtx.RacunarSet.FirstOrDefault((m) => m.ID_racunara == racunar.ID_racunara) != null)
            {
                return false;
            }

            dbCtx.RacunarSet.Add(new Racunar()
            {
                Brzina_procesora = racunar.Brzina_procesora,
                Kapacitet_memorije = racunar.Kapacitet_memorije,
                Kapacitet_RAM = racunar.Kapacitet_RAM,
                Proizvodjac  = racunar.Proizvodjac,
                Vrsta_racunara = (Vrsta_racunara)racunar.Vrsta_racunara,
                
            });

            return dbCtx.SaveChanges() > 0;
        }

        public bool Delete(int idRacunara)
        {
            try
            {
                dbCtx.RacunarSet.Remove(dbCtx.RacunarSet.FirstOrDefault((s) => s.ID_racunara == idRacunara));
                dbCtx.PosjedujeSet.RemoveRange(dbCtx.PosjedujeSet.Where(s => s.RacunarID_racunara == idRacunara).ToList());
                foreach(var x in dbCtx.KomponentaSet)
                {
                    if (x.RacunarID_racunara == idRacunara)
                    {
                        x.RacunarID_racunara = 0;
                    }
                }
                dbCtx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public Common.Models.Racunar GetRacunar(int racunarId)
        {
            var racunarFromDb = dbCtx.RacunarSet.Find(racunarId);
            if (racunarFromDb != null)
            {
                var racunarForVw = new Common.Models.Racunar()
                {
                    Brzina_procesora = racunarFromDb.Brzina_procesora,
                    ID_racunara = racunarFromDb.ID_racunara,
                    Kapacitet_memorije = racunarFromDb.Kapacitet_memorije,
                    Kapacitet_RAM = racunarFromDb.Kapacitet_RAM,
                    Proizvodjac = racunarFromDb.Proizvodjac,
                    Vrsta_racunara = (Common.Models.Vrsta_racunara)racunarFromDb.Vrsta_racunara
                };

                return racunarForVw;
            }
            return null;
        }

        public void Update(Common.Models.Racunar racunar)
        {
            var racunarForDb = new Racunar()
            {
                ID_racunara = racunar.ID_racunara,
                Proizvodjac =racunar.Proizvodjac,
                Kapacitet_RAM = racunar.Kapacitet_RAM,
                Kapacitet_memorije = racunar.Kapacitet_memorije,
                Brzina_procesora = racunar.Brzina_procesora,
                Vrsta_racunara = (Vrsta_racunara)racunar.Vrsta_racunara
            };

            try
            {
                var racunarFromDb = dbCtx.RacunarSet.FirstOrDefault((s) => s.ID_racunara == racunarForDb.ID_racunara);
                dbCtx.Entry(racunarFromDb).CurrentValues.SetValues(racunarForDb);
                dbCtx.SaveChanges();
            }catch(Exception e)
            {

            }
        }

        public IEnumerable<Common.Models.Racunar> GetAll()
        {
            var retVal = new List<Common.Models.Racunar>();
            foreach (var racunarFromDb in dbCtx.RacunarSet.ToList())
            {
                var racunar = new Common.Models.Racunar()
                {
                    ID_racunara = racunarFromDb.ID_racunara,
                    Proizvodjac = racunarFromDb.Proizvodjac,
                    Kapacitet_RAM = racunarFromDb.Kapacitet_RAM,
                    Kapacitet_memorije = racunarFromDb.Kapacitet_memorije,
                    Brzina_procesora = racunarFromDb.Brzina_procesora,
                    Vrsta_racunara = (Common.Models.Vrsta_racunara)racunarFromDb.Vrsta_racunara

                };
                retVal.Add(racunar);
            }
            return retVal;
        }

        public IEnumerable<Common.Models.Racunar> GetAllMy(long idVlasnika)
        {
            var retVal = new List<Common.Models.Racunar>();
            foreach (var racunarFromDb in dbCtx.RacunarSet.ToList())
            {
                if (racunarFromDb.Posjeduje.Any(_ => _.Vlasnik_racunaraJMBG_vl == idVlasnika))
                {
                    var racunar = new Common.Models.Racunar()
                    {
                        ID_racunara = racunarFromDb.ID_racunara,
                        Proizvodjac = racunarFromDb.Proizvodjac,
                        Kapacitet_RAM = racunarFromDb.Kapacitet_RAM,
                        Kapacitet_memorije = racunarFromDb.Kapacitet_memorije,
                        Brzina_procesora = racunarFromDb.Brzina_procesora,
                        Vrsta_racunara = (Common.Models.Vrsta_racunara)racunarFromDb.Vrsta_racunara

                    };
                    retVal.Add(racunar);
                }
            }
            return retVal;
        }
        public IEnumerable<Common.Models.Racunar> GetAllNeprodatiRacunari()
        {
            var retVal = new List<Common.Models.Racunar>();
            foreach (var racunarFromDb in dbCtx.RacunarSet.ToList())
            {
                if (racunarFromDb.Posjeduje.Count == 0)
                {
                    var racunar = new Common.Models.Racunar()
                    {
                        ID_racunara = racunarFromDb.ID_racunara,
                        Proizvodjac = racunarFromDb.Proizvodjac,
                        Kapacitet_RAM = racunarFromDb.Kapacitet_RAM,
                        Kapacitet_memorije = racunarFromDb.Kapacitet_memorije,
                        Brzina_procesora = racunarFromDb.Brzina_procesora,
                        Vrsta_racunara = (Common.Models.Vrsta_racunara)racunarFromDb.Vrsta_racunara

                    };
                    retVal.Add(racunar);
                }
            }
            return retVal;
        }
    }
}
