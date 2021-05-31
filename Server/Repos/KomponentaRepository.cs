using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repos
{
    public class KomponentaRepository
    {
        private readonly ProjectDbContext dbCtx;

        public KomponentaRepository(ProjectDbContext context)
        {
            dbCtx = context;
        }

        public bool Add(Common.Models.Komponenta komponenta)
        {
            if (dbCtx.KomponentaSet.FirstOrDefault((s) => s.Id_komp == komponenta.Id_komp) != null)
            {
                return false;
            }

            dbCtx.KomponentaSet.Add(new Komponenta()
            {
                Naz_komp = komponenta.Naz_komp,
                Cijena_komp = komponenta.Cijena_komp,
                RacunarID_racunara = komponenta.RacunarID_racunara == null ? -1 : komponenta.RacunarID_racunara
            });

            return dbCtx.SaveChanges() > 0;
        }

        public bool Delete(int idKomponente)
        {
            try
            {
                dbCtx.KomponentaSet.Remove(dbCtx.KomponentaSet.FirstOrDefault((s) => s.Id_komp == idKomponente));
                dbCtx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public IEnumerable<Common.Models.Komponenta> GetAll()
        {
            var retVal = new List<Common.Models.Komponenta>();
            foreach (var komponentaFromDb in dbCtx.KomponentaSet.ToList())
            {
                var komponenta = new Common.Models.Komponenta()
                {
                    Id_komp = komponentaFromDb.Id_komp,
                    Cijena_komp = komponentaFromDb.Cijena_komp,
                    Naz_komp = komponentaFromDb.Naz_komp,
                    RacunarID_racunara = komponentaFromDb.RacunarID_racunara
                };
                retVal.Add(komponenta);
            }
            return retVal;
        }

        public Common.Models.Komponenta Get(int idKomponente)
        {
            var komponentaFromDb = dbCtx.KomponentaSet.Find(idKomponente);
            if (komponentaFromDb != null)
            {
                var komponenta = new Common.Models.Komponenta()
                {
                    Id_komp = komponentaFromDb.Id_komp,
                    Cijena_komp = komponentaFromDb.Cijena_komp,
                    Naz_komp = komponentaFromDb.Naz_komp,
                    RacunarID_racunara = komponentaFromDb.RacunarID_racunara
                };
                return komponenta;
            }
            return null;
        }
        public void Update(Common.Models.Komponenta komponenta)
        {
            var komponentaForDb = new Komponenta()
            {
                Id_komp = komponenta.Id_komp,
                Naz_komp = komponenta.Naz_komp,
                Cijena_komp = komponenta.Cijena_komp,
                RacunarID_racunara = komponenta.RacunarID_racunara == null ? -1 : komponenta.RacunarID_racunara
            };

            try
            {
                var komponentaFromDb = dbCtx.KomponentaSet.FirstOrDefault((s) => s.Id_komp == komponentaForDb.Id_komp);
                dbCtx.Entry(komponentaFromDb).CurrentValues.SetValues(komponentaForDb);
                dbCtx.SaveChanges();
            }catch(Exception e)
            {

            }
        }
    }
}
