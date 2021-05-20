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

        /*public Common.Models.Racunar GetRacunar(int racunarId) 
        {
            var racunar = dbCtx.RacunarSet.Include()

        }*/
    }
}
