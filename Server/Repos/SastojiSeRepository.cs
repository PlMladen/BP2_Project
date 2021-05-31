using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repos
{
    public class SastojiSeRepository
    {
        private readonly ProjectDbContext dbCtx;

        public SastojiSeRepository(ProjectDbContext context)
        {
            dbCtx = context;
        }

        public bool Add(Common.Models.SastojiSe sastojiSe)
        {
            if (dbCtx.Sastoji_seSet.FirstOrDefault((s) => s.KomponentaId_komp == sastojiSe.KomponentaId_komp && s.KomponentaId_komp1 == sastojiSe.KomponentaId_komp1) != null)
            {
                return false;
            }

            Sastoji_se ss = new Sastoji_se()
            {
                KomponentaId_komp = sastojiSe.KomponentaId_komp,
                KomponentaId_komp1 = sastojiSe.KomponentaId_komp1

            };
            dbCtx.Sastoji_seSet.Add(ss);
            dbCtx.KomponentaSet.FirstOrDefault(s => s.Id_komp == ss.KomponentaId_komp).Sastoji_se.Add(ss);
            dbCtx.KomponentaSet.FirstOrDefault(s => s.Id_komp == ss.KomponentaId_komp1).Sastoji_se1.Add(ss);
            
            return dbCtx.SaveChanges() > 0;
        }

        public Common.Models.SastojiSe Get(int idk1, int idk2)
        {
            var sastojiSeFromDb = dbCtx.Sastoji_seSet.FirstOrDefault(s => s.KomponentaId_komp == idk1 && s.KomponentaId_komp1 == idk2);
            if (sastojiSeFromDb != null)
            {
                var sastojiSe = new Common.Models.SastojiSe()
                {
                    KomponentaId_komp = idk1,
                    KomponentaId_komp1 = idk2,
                    Komponenta = new Common.Models.Komponenta()
                    {
                        Cijena_komp = sastojiSeFromDb.Komponenta.Cijena_komp,
                        Id_komp = sastojiSeFromDb.Komponenta.Id_komp,
                        Naz_komp = sastojiSeFromDb.Komponenta.Naz_komp,
                        Racunar = new Common.Models.Racunar()
                        {
                            Brzina_procesora = sastojiSeFromDb.Komponenta.Racunar.Brzina_procesora,
                            ID_racunara = sastojiSeFromDb.Komponenta.Racunar.ID_racunara,
                            Kapacitet_memorije = sastojiSeFromDb.Komponenta.Racunar.Kapacitet_memorije,
                            Kapacitet_RAM = sastojiSeFromDb.Komponenta.Racunar.Kapacitet_RAM,
                            Proizvodjac = sastojiSeFromDb.Komponenta.Racunar.Proizvodjac,
                            Vrsta_racunara = (Common.Models.Vrsta_racunara)sastojiSeFromDb.Komponenta.Racunar.Vrsta_racunara
                        },
                        RacunarID_racunara = sastojiSeFromDb.Komponenta.Racunar.ID_racunara
                    },
                    Komponenta1 = new Common.Models.Komponenta()
                    {
                        Cijena_komp = sastojiSeFromDb.Komponenta1.Cijena_komp,
                        Id_komp = sastojiSeFromDb.Komponenta1.Id_komp,
                        Naz_komp = sastojiSeFromDb.Komponenta1.Naz_komp,
                        Racunar = new Common.Models.Racunar()
                        {
                            Brzina_procesora = sastojiSeFromDb.Komponenta1.Racunar.Brzina_procesora,
                            ID_racunara = sastojiSeFromDb.Komponenta1.Racunar.ID_racunara,
                            Kapacitet_memorije = sastojiSeFromDb.Komponenta1.Racunar.Kapacitet_memorije,
                            Kapacitet_RAM = sastojiSeFromDb.Komponenta1.Racunar.Kapacitet_RAM,
                            Proizvodjac = sastojiSeFromDb.Komponenta1.Racunar.Proizvodjac,
                            Vrsta_racunara = (Common.Models.Vrsta_racunara)sastojiSeFromDb.Komponenta1.Racunar.Vrsta_racunara
                        },
                        RacunarID_racunara = sastojiSeFromDb.Komponenta1.Racunar.ID_racunara
                    }
                };
                return sastojiSe;
            }
            return null;
        }

        public IEnumerable<Common.Models.SastojiSe> GetAll()
        {
            var retVal = new List<Common.Models.SastojiSe>();
            foreach (var sastojiSeFromDb in dbCtx.Sastoji_seSet.ToList())
            {
                var sastojiSe = new Common.Models.SastojiSe()
                {
                    KomponentaId_komp = sastojiSeFromDb.KomponentaId_komp,
                    KomponentaId_komp1 = sastojiSeFromDb.KomponentaId_komp1,
                    Komponenta = new Common.Models.Komponenta()
                    {
                        Cijena_komp = sastojiSeFromDb.Komponenta.Cijena_komp,
                        Id_komp = sastojiSeFromDb.Komponenta.Id_komp,
                        Naz_komp = sastojiSeFromDb.Komponenta.Naz_komp,
                        Racunar = new Common.Models.Racunar()
                        {
                            Brzina_procesora = sastojiSeFromDb.Komponenta.Racunar.Brzina_procesora,
                            ID_racunara = sastojiSeFromDb.Komponenta.Racunar.ID_racunara,
                            Kapacitet_memorije = sastojiSeFromDb.Komponenta.Racunar.Kapacitet_memorije,
                            Kapacitet_RAM = sastojiSeFromDb.Komponenta.Racunar.Kapacitet_RAM,
                            Proizvodjac = sastojiSeFromDb.Komponenta.Racunar.Proizvodjac,
                            Vrsta_racunara = (Common.Models.Vrsta_racunara)sastojiSeFromDb.Komponenta.Racunar.Vrsta_racunara
                        },
                        RacunarID_racunara = sastojiSeFromDb.Komponenta.Racunar.ID_racunara
                    },
                    Komponenta1 = new Common.Models.Komponenta()
                    {
                        Cijena_komp = sastojiSeFromDb.Komponenta1.Cijena_komp,
                        Id_komp = sastojiSeFromDb.Komponenta1.Id_komp,
                        Naz_komp = sastojiSeFromDb.Komponenta1.Naz_komp,
                        Racunar = new Common.Models.Racunar()
                        {
                            Brzina_procesora = sastojiSeFromDb.Komponenta1.Racunar.Brzina_procesora,
                            ID_racunara = sastojiSeFromDb.Komponenta1.Racunar.ID_racunara,
                            Kapacitet_memorije = sastojiSeFromDb.Komponenta1.Racunar.Kapacitet_memorije,
                            Kapacitet_RAM = sastojiSeFromDb.Komponenta1.Racunar.Kapacitet_RAM,
                            Proizvodjac = sastojiSeFromDb.Komponenta1.Racunar.Proizvodjac,
                            Vrsta_racunara = (Common.Models.Vrsta_racunara)sastojiSeFromDb.Komponenta1.Racunar.Vrsta_racunara
                        },
                        RacunarID_racunara = sastojiSeFromDb.Komponenta1.Racunar.ID_racunara
                    }
                };
                retVal.Add(sastojiSe);
            }
            return retVal;
        }
        public bool Delete(int idk1, int idk2)
        {
            try
            {
                Sastoji_se ss = dbCtx.Sastoji_seSet.FirstOrDefault((s) => s.KomponentaId_komp == idk1 && s.KomponentaId_komp1 == idk2);

                dbCtx.Sastoji_seSet.Remove(ss);
                dbCtx.KomponentaSet.FirstOrDefault(s => s.Id_komp == idk1).Sastoji_se.Remove(ss);
                dbCtx.KomponentaSet.FirstOrDefault(s => s.Id_komp == idk2).Sastoji_se1.Remove(ss);
                dbCtx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public void Update(Common.Models.SastojiSe sastojiSe)
        {
            var SastojiSeForDb = new Sastoji_se()
            {
                KomponentaId_komp = sastojiSe.Komponenta.Id_komp,
                KomponentaId_komp1 = sastojiSe.Komponenta1.Id_komp
            };

            try
            {
                var sastojiSeFromDb = dbCtx.Sastoji_seSet.FirstOrDefault((s) => s.KomponentaId_komp == sastojiSe.KomponentaId_komp && s.KomponentaId_komp1 == sastojiSe.KomponentaId_komp1);
                dbCtx.Sastoji_seSet.Remove(sastojiSeFromDb);
                dbCtx.Sastoji_seSet.Add(SastojiSeForDb);
                dbCtx.SaveChanges();
            }catch(Exception e)
            {

            }
        }
    }
}
