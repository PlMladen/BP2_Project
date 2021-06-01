using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repos
{
    public class ServiserRacunaraRepository
    {
        private readonly ProjectDbContext dbCtx;

        public ServiserRacunaraRepository(ProjectDbContext context)
        {
            dbCtx = context;
        }

        public bool Add(Common.Models.Serviser_racunara serviser)
        {
            if (dbCtx.Serviser_racunaraSet.FirstOrDefault((s) => s.JMBG_s == serviser.JMBG_s) != null)
            {
                return false;
            }

            dbCtx.Serviser_racunaraSet.Add(new Serviser_racunara()
            {
                JMBG_s = serviser.JMBG_s,
                Ime_s = serviser.Ime_s,
                Prezime_s = serviser.Prezime_s,
                Dat_rodjenja_s = serviser.Dat_rodjenja_s
            });

            return dbCtx.SaveChanges() > 0;
        }

        public bool Delete(long idServisera)
        {
            try
            {
                dbCtx.Serviser_racunaraSet.Remove(dbCtx.Serviser_racunaraSet.FirstOrDefault((s) => s.JMBG_s == idServisera));
                dbCtx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public IEnumerable<Common.Models.Serviser_racunara> GetAll()
        {
            var retVal = new List<Common.Models.Serviser_racunara>();
            foreach (var serviserFromDb in dbCtx.Serviser_racunaraSet.ToList())
            {
               var serviser = new Common.Models.Serviser_racunara() { 
                Ime_s = serviserFromDb.Ime_s,
                JMBG_s = serviserFromDb.JMBG_s,
                Dat_rodjenja_s = serviserFromDb.Dat_rodjenja_s,
                Prezime_s = serviserFromDb.Prezime_s
               };
                retVal.Add(serviser);
            }
            return retVal;
        }

        public Common.Models.Serviser_racunara Get(long idServisera)
        {
            var serviserFromDb = dbCtx.Serviser_racunaraSet.Find(idServisera);
            if (serviserFromDb != null)
            {
                var serviser = new Common.Models.Serviser_racunara() { 
                Ime_s = serviserFromDb.Ime_s,
                Prezime_s = serviserFromDb.Prezime_s,
                Dat_rodjenja_s = serviserFromDb.Dat_rodjenja_s,
                JMBG_s = serviserFromDb.JMBG_s
                };
                return serviser;
            }
            return null;
        }
        public void Update(Common.Models.Serviser_racunara serviser)
        {
            var serviserForDb = new Serviser_racunara()
            {
                Ime_s = serviser.Ime_s,
                JMBG_s = serviser.JMBG_s,
                Dat_rodjenja_s = serviser.Dat_rodjenja_s,
                Prezime_s = serviser.Prezime_s
            };

            try
            {
                var serviserFromDb = dbCtx.Serviser_racunaraSet.FirstOrDefault((s) => s.JMBG_s == serviserForDb.JMBG_s);
                dbCtx.Entry(serviserFromDb).CurrentValues.SetValues(serviserForDb);
                dbCtx.SaveChanges();
            }catch(Exception e)
            {

            }
        }
    }
}
