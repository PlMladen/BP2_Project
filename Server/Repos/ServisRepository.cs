using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repos
{
    public class ServisRepository
    {
        private readonly ProjectDbContext dbCtx;

        public ServisRepository(ProjectDbContext ctx)
        {
            dbCtx = ctx;
        }

        public bool Add(Common.Models.Servis servis)
        {
            if(dbCtx.ServisSet.FirstOrDefault((s) => s.ID_servisa == servis.ID_servisa) != null)
            {
                return false;
            }
            if(servis.Tip_serv == Common.Models.Tip_servisa.Servis_racunara)
            {
                Racunarski_servis servis1 = new Racunarski_servis()
                {

                    Adresa_serv = new Adresa()
                    {
                        Ulica = servis.Adresa_serv.Ulica,
                        Broj = servis.Adresa_serv.Broj,
                        Grad = servis.Adresa_serv.Grad,
                        PostanskiBroj = servis.Adresa_serv.PostanskiBroj
                    },
                    Naziv_serv = servis.Naziv_serv,
                    Tip_serv = (Tip_servisa)servis.Tip_serv,
                    Br_tel_serv = new Broj_telefona()
                    {
                        Broj = servis.Br_tel_serv.Broj,
                        Okrug = servis.Br_tel_serv.Okrug,
                        Pozivni_broj = servis.Br_tel_serv.Pozivni_broj
                    }
                }; dbCtx.ServisSet.Add(servis1);
            }
            else
            {
                Servis_mob_tel servis2 = new Servis_mob_tel()
                {

                    Adresa_serv = new Adresa()
                    {
                        Ulica = servis.Adresa_serv.Ulica,
                        Broj = servis.Adresa_serv.Broj,
                        Grad = servis.Adresa_serv.Grad,
                        PostanskiBroj = servis.Adresa_serv.PostanskiBroj
                    },
                    Naziv_serv = servis.Naziv_serv,
                    Tip_serv = (Tip_servisa)servis.Tip_serv,
                    Br_tel_serv = new Broj_telefona()
                    {
                        Broj = servis.Br_tel_serv.Broj,
                        Okrug = servis.Br_tel_serv.Okrug,
                        Pozivni_broj = servis.Br_tel_serv.Pozivni_broj
                    }
                }; 
                dbCtx.ServisSet.Add(servis2);
            }
                
            
            
            
            return dbCtx.SaveChanges() > 0;
        }

        public Common.Models.Servis Get(int idServisa)
        {
            var servisFromDb = dbCtx.ServisSet.Find(idServisa);
            if (servisFromDb != null) {
                var adresa = new Common.Models.Adresa(servisFromDb.Adresa_serv.Ulica, servisFromDb.Adresa_serv.Grad, servisFromDb.Adresa_serv.Broj, servisFromDb.Adresa_serv.PostanskiBroj);
                var brTel = new Common.Models.Broj_telefona(servisFromDb.Br_tel_serv.Pozivni_broj, servisFromDb.Br_tel_serv.Okrug, servisFromDb.Br_tel_serv.Broj);
                var servis = new Common.Models.Servis(servisFromDb.ID_servisa,
                                                      servisFromDb.Naziv_serv,
                                                      (Common.Models.Tip_servisa)servisFromDb.Tip_serv,
                                                       adresa,
                                                       brTel
                                                      );
                return servis;
            }
            return null;
        }

        public IEnumerable<Common.Models.Servis> GetAll()
        {
            var retVal = new List<Common.Models.Servis>();
            foreach(var servisFromDb in dbCtx.ServisSet.ToList())
            {
                var adresa = new Common.Models.Adresa(servisFromDb.Adresa_serv.Ulica, servisFromDb.Adresa_serv.Grad, servisFromDb.Adresa_serv.Broj, servisFromDb.Adresa_serv.PostanskiBroj);
                var brTel = new Common.Models.Broj_telefona(servisFromDb.Br_tel_serv.Pozivni_broj, servisFromDb.Br_tel_serv.Okrug, servisFromDb.Br_tel_serv.Broj);
                var servis = new Common.Models.Servis(servisFromDb.ID_servisa,
                                                      servisFromDb.Naziv_serv,
                                                      (Common.Models.Tip_servisa)servisFromDb.Tip_serv,
                                                       adresa,
                                                       brTel
                                                      );
                retVal.Add(servis);
            }
            return retVal;
        }

        public void Update(Common.Models.Servis servis) 
        {
            var servisForDb = new Servis()
            {
                Adresa_serv = new Adresa()
                {
                    Broj = servis.Adresa_serv.Broj,
                    Grad = servis.Adresa_serv.Grad,
                    PostanskiBroj = servis.Adresa_serv.PostanskiBroj,
                    Ulica = servis.Adresa_serv.Ulica
                },
                Br_tel_serv = new Broj_telefona()
                {
                    Broj = servis.Br_tel_serv.Broj,
                    Okrug = servis.Br_tel_serv.Okrug,
                    Pozivni_broj = servis.Br_tel_serv.Pozivni_broj
                },
                ID_servisa = servis.ID_servisa,
                Naziv_serv = servis.Naziv_serv,
                Tip_serv = (Tip_servisa)servis.Tip_serv
            };

            try
            {
                var servisFromDb = dbCtx.ServisSet.FirstOrDefault((s) => s.ID_servisa == servisForDb.ID_servisa);
                dbCtx.Entry(servisFromDb).CurrentValues.SetValues(servisForDb);
                dbCtx.SaveChanges();
            }catch(Exception e)
            {

            }
        }

        public bool Delete(int idServisa)
        {
            try
            {
                dbCtx.ServisSet.Remove(dbCtx.ServisSet.FirstOrDefault((s) => s.ID_servisa == idServisa));
                dbCtx.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
