using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repos
{
    public class DonosiRepository
    {
        private readonly ProjectDbContext dbCtx;

        public DonosiRepository(ProjectDbContext context)
        {
            dbCtx = context;
        }

        public bool Add(Common.Models.Donosi donosi)
        {
            if (dbCtx.DonosiSet.FirstOrDefault((s) => s.PosjedujeRacunarID_racunara == donosi.PosjedujeRacunarID_racunara &&
                                                      s.PosjedujeVlasnik_racunaraJMBG_vl == donosi.PosjedujeVlasnik_racunaraJMBG_vl &&
                                                      s.Racunarski_servisID_servisa == donosi.Racunarski_servisID_servisa) != null)
            {
                return false;
            }

            Donosi d = new Donosi()
            {
                PosjedujeRacunarID_racunara = donosi.PosjedujeRacunarID_racunara,
                PosjedujeVlasnik_racunaraJMBG_vl = donosi.PosjedujeVlasnik_racunaraJMBG_vl,
                Racunarski_servisID_servisa = donosi.Racunarski_servisID_servisa
                
               
            };
            dbCtx.DonosiSet.Add(d);
            Racunarski_servis rs =  (Racunarski_servis)dbCtx.ServisSet.FirstOrDefault(s => s.ID_servisa == d.Racunarski_servisID_servisa);
            rs.Donosi.Add(d);

            return dbCtx.SaveChanges() > 0;
        }

        public Common.Models.Donosi Get(long jmbgVl, int idRacunara, int idServisa)
        {
            var donosiFromDb = dbCtx.DonosiSet.FirstOrDefault(s => s.PosjedujeRacunarID_racunara == idRacunara && 
                                                                   s.PosjedujeVlasnik_racunaraJMBG_vl == jmbgVl &&
                                                                   s.Racunarski_servisID_servisa == idServisa);
            if (donosiFromDb != null)
            {
                var donosi = new Common.Models.Donosi()
                {
                    PosjedujeRacunarID_racunara = donosiFromDb.PosjedujeRacunarID_racunara,
                    PosjedujeVlasnik_racunaraJMBG_vl = donosiFromDb.PosjedujeVlasnik_racunaraJMBG_vl,
                    Racunarski_servisID_servisa = donosiFromDb.Racunarski_servisID_servisa,
                    Pposjeduje = new Common.Models.Posjeduje() 
                    { 
                    Id_racunara = donosiFromDb.Posjeduje.RacunarID_racunara,
                    Ime_vl = donosiFromDb.Posjeduje.Vlasnik_racunara.Ime_vl,
                    JMBG_vl = donosiFromDb.Posjeduje.Vlasnik_racunaraJMBG_vl,
                    Prezime_vl = donosiFromDb.Posjeduje.Vlasnik_racunara.Prezime_vl
                    },
                    Racunarski_servis = new Common.Models.Racunarski_servis()
                    {
                        ID_servisa = donosiFromDb.Racunarski_servisID_servisa,
                        Naziv_serv = donosiFromDb.Racunarski_servis.Naziv_serv
                    }
                    
                    
                };
                return donosi;
            }
            return null;
        }

        public IEnumerable<Common.Models.Donosi> GetAll()
        {
            var retVal = new List<Common.Models.Donosi>();
            foreach (var donosiFromDb in dbCtx.DonosiSet.ToList())
            {
                var donosi = new Common.Models.Donosi()
                {
                    PosjedujeRacunarID_racunara = donosiFromDb.PosjedujeRacunarID_racunara,
                    PosjedujeVlasnik_racunaraJMBG_vl = donosiFromDb.PosjedujeVlasnik_racunaraJMBG_vl,
                    Racunarski_servisID_servisa = donosiFromDb.Racunarski_servisID_servisa,
                    Pposjeduje = new Common.Models.Posjeduje()
                    {
                        Id_racunara = donosiFromDb.Posjeduje.RacunarID_racunara,
                        Ime_vl = donosiFromDb.Posjeduje.Vlasnik_racunara.Ime_vl,
                        JMBG_vl = donosiFromDb.Posjeduje.Vlasnik_racunaraJMBG_vl,
                        Prezime_vl = donosiFromDb.Posjeduje.Vlasnik_racunara.Prezime_vl
                    },
                    Racunarski_servis = new Common.Models.Racunarski_servis()
                    {
                        ID_servisa = donosiFromDb.Racunarski_servisID_servisa,
                        Naziv_serv = donosiFromDb.Racunarski_servis.Naziv_serv
                    }

                };
                retVal.Add(donosi);
            }
            return retVal;
        }
        public bool Delete(long jmbgVl, int idRacunara, int idServisa)
        {
            try
            {
                Donosi d = dbCtx.DonosiSet.FirstOrDefault((s) => s.PosjedujeRacunarID_racunara == idRacunara && 
                                                                 s.PosjedujeVlasnik_racunaraJMBG_vl == jmbgVl &&
                                                                 s.Racunarski_servisID_servisa == idServisa);

                dbCtx.DonosiSet.Remove(d);
                Racunarski_servis rs = (Racunarski_servis)dbCtx.ServisSet.FirstOrDefault(s => s.ID_servisa == idServisa);
                rs.Donosi.Remove(d);
                dbCtx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public void Update(Common.Models.Donosi donosi)
        {
            var DonosiForDb = new Donosi()
            {
                PosjedujeRacunarID_racunara = donosi.Pposjeduje.Id_racunara,
                PosjedujeVlasnik_racunaraJMBG_vl = donosi.Pposjeduje.JMBG_vl,
                Racunarski_servisID_servisa = donosi.Racunarski_servis.ID_servisa
                
            };
            try
            {
                var donosiFromDb = dbCtx.DonosiSet.FirstOrDefault((s) => s.PosjedujeRacunarID_racunara == donosi.PosjedujeRacunarID_racunara &&
                                                                     s.PosjedujeVlasnik_racunaraJMBG_vl == donosi.PosjedujeVlasnik_racunaraJMBG_vl &&
                                                                     s.Racunarski_servisID_servisa == donosi.Racunarski_servisID_servisa);
                dbCtx.DonosiSet.Remove(donosiFromDb);
                dbCtx.DonosiSet.Add(DonosiForDb);
                dbCtx.SaveChanges();
            }catch(Exception e)
            {

            }
        }
    }
}
