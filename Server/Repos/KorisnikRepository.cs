using Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repos
{
    public class KorisnikRepository
    {
        private readonly ProjectDbContext dbCtx;
        private readonly VlasnikRacunaraRepository vlasnikRacunaraRepository;
        private readonly ServiserRacunaraRepository serviserRacunaraRepository;

        public KorisnikRepository(ProjectDbContext context, VlasnikRacunaraRepository racunaraRepository, ServiserRacunaraRepository serviserRacunara)
        {
            dbCtx = context;
            vlasnikRacunaraRepository = racunaraRepository;
            serviserRacunaraRepository = serviserRacunara;
        }

        public bool PrijaviKorisnika(string korisnickoIme, string lozinka)
        {
            string sql = @"select count(*) from korisnici where KorisnickoIme=@KorisnickoIme and Lozinka=@Lozinka";
            List<SqlParameter> parms = new List<SqlParameter>()
            {
              new SqlParameter {ParameterName = "@KorisnickoIme", Value = korisnickoIme , DbType = System.Data.DbType.String},
              new SqlParameter{ ParameterName = "@Lozinka", Value = lozinka, DbType = System.Data.DbType.String },

            };
            try
            {
                var s = dbCtx.Database.SqlQuery<int>(sql, parms.ToArray()).DefaultIfEmpty<int>(0).FirstOrDefault();
                if (s != 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {

            }
            return false ;
        }
        public bool ObrisiKorisnika(long jmbg)
        {
            string sql = @"delete from korisnici where JMBGKorisnika=@JMBGKorisnika";
            List<SqlParameter> parms = new List<SqlParameter>()
            {
              new SqlParameter {ParameterName = "@JMBGKorisnika", Value = jmbg , DbType = System.Data.DbType.Int64},
              
            };
            try
            {
                var s = dbCtx.Database.SqlQuery<int>(sql, parms.ToArray()).DefaultIfEmpty<int>(0).FirstOrDefault();
                if (s != 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {

            }
            return false ;
        }
        public bool RegistrujKorisnika(Korisnik korisnik)
        {
            if (korisnik.Uloga.Equals("Vlasnik_racunara"))
            {
                if (!vlasnikRacunaraRepository.Add(new Common.Models.Vlasnik_racunara()
                {
                    Adresa_vl = korisnik.Adresa,
                    Dat_rodjenja_vl = korisnik.DatumRodjenja,
                    Ime_vl = korisnik.Ime,
                    JMBG_vl = korisnik.JMBG,
                    Prezime_vl = korisnik.Prezime
                }))
                {
                    return false;
                }
            }
            else
            {
                if(!serviserRacunaraRepository.Add(new Common.Models.Serviser_racunara()
                {
                    Ime_s = korisnik.Ime,
                    JMBG_s = korisnik.JMBG,
                    Prezime_s = korisnik.Prezime,
                    Dat_rodjenja_s = korisnik.DatumRodjenja
                }))
                {
                    return false;
                }
            }
            string sql = String.Format("INSERT INTO korisnici (JMBGKorisnika, KorisnickoIme, Lozinka, Uloga, ProfilOdobren) values ({0}, '{1}', '{2}', '{3}', '{4}')", korisnik.JMBG, korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Uloga, false);
            
            try
            {
                var s = dbCtx.Database.ExecuteSqlCommand(sql);
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
        public string VratiUloguKorisnika(string korisnickoIme)
        {
            string retVal = string.Empty;
            string sql = @"SELECT Uloga from Korisnici WHERE KorisnickoIme=@KorisnickoIme";
            List<SqlParameter> parms = new List<SqlParameter>()
            {
              new SqlParameter {ParameterName = "@KorisnickoIme", Value = korisnickoIme , DbType = System.Data.DbType.String},
            };
            try
            {
                var s = dbCtx.Database.SqlQuery<string>(sql, parms.ToArray()).FirstOrDefault();
                if (s != "")
                {
                    retVal = s;
                }
            }
            catch (Exception e)
            {

            }


            return retVal;
        }
        public Korisnik VratiKorisnika(string korisnickoIme)
        {
            string retVal = string.Empty;
            string sql = @"SELECT Lozinka from Korisnici WHERE KorisnickoIme=@KorisnickoIme";
            List<SqlParameter> parms = new List<SqlParameter>()
            {
              new SqlParameter {ParameterName = "@KorisnickoIme", Value = korisnickoIme , DbType = System.Data.DbType.String},
            };
            try
            {
                var s = dbCtx.Database.SqlQuery<string>(sql, parms.ToArray()).FirstOrDefault();
                if (s != "")
                {
                    retVal = s;
                }
            }
            catch (Exception e)
            {

            }
            string ulogaKorisnika = VratiUloguKorisnika(korisnickoIme);

            Korisnik korisnik = null;
            if (ulogaKorisnika.Equals("Vlasnik_racunara"))
            {
                Common.Models.Vlasnik_racunara v = vlasnikRacunaraRepository.Get(VratiJMBGVlasnika(korisnickoIme));
                if (v != null)
                {
                    korisnik = new Korisnik()
                    {
                        JMBG = v.JMBG_vl,
                        Ime = v.Ime_vl,
                        Prezime = v.Prezime_vl,
                        Lozinka = retVal,
                        Uloga = ulogaKorisnika,
                        KorisnickoIme = korisnickoIme,
                        DatumRodjenja = v.Dat_rodjenja_vl,
                        Adresa = new Common.Models.Adresa()
                        {
                            Broj = v.Adresa_vl.Broj,
                            Grad = v.Adresa_vl.Grad,
                            PostanskiBroj = v.Adresa_vl.PostanskiBroj,
                            Ulica = v.Adresa_vl.Ulica
                        }
                    };
                    
                }
            }
            else if(ulogaKorisnika.Equals("Serviser_racunara"))
            {
                Common.Models.Serviser_racunara s = serviserRacunaraRepository.Get(VratiJMBGVlasnika(korisnickoIme));
                if(s != null)
                {
                    korisnik = new Korisnik()
                    {
                        JMBG = s.JMBG_s,
                        Ime = s.Ime_s,
                        Prezime = s.Prezime_s,
                        Lozinka = retVal,
                        Uloga = ulogaKorisnika,
                        KorisnickoIme = korisnickoIme,
                        DatumRodjenja = s.Dat_rodjenja_s,
                        
                    };
                }
            }
            else
            {
                Administrator a = VratiAdministratora(VratiJMBGVlasnika(korisnickoIme));
                if(a != null)
                {
                    korisnik = new Korisnik()
                    {
                        JMBG = a.JMBG_a,
                        Ime = a.Ime_a,
                        Prezime = a.Prezime_a,
                        Lozinka = retVal,
                        Uloga = "Administrator",
                        KorisnickoIme = korisnickoIme,
                        DatumRodjenja = a.Dat_rodjenja_a,

                    };
                }
            }

            return korisnik;
        }

        private Common.Models.Administrator VratiAdministratora(long jmbg)
        {
            Administrator retVal = new Administrator();
            retVal.JMBG_a = jmbg;


            string sqlIme = @"SELECT Ime_a from Administratori WHERE JMBG_a=@JMBG_a";
            string sqlPrezime = @"SELECT Prezime_a from Administratori WHERE JMBG_a=@JMBG_a";
            string sqlDat = @"SELECT Dat_rodjenja_a from Administratori WHERE JMBG_a=@JMBG_a";
            List<SqlParameter> parms = new List<SqlParameter>()
            {
              new SqlParameter {ParameterName = "@JMBG_a", Value = jmbg , DbType = System.Data.DbType.Int64},
            };
            List<SqlParameter> parms1 = new List<SqlParameter>()
            {
              new SqlParameter {ParameterName = "@JMBG_a", Value = jmbg , DbType = System.Data.DbType.Int64},
            };
            List<SqlParameter> parms2 = new List<SqlParameter>()
            {
              new SqlParameter {ParameterName = "@JMBG_a", Value = jmbg , DbType = System.Data.DbType.Int64},
            };
            try
            {
                var s = dbCtx.Database.SqlQuery<string>(sqlIme, parms.ToArray()).FirstOrDefault();
                if (s != "")
                {
                    retVal.Ime_a = s;
                }
                var s1 = dbCtx.Database.SqlQuery<string>(sqlPrezime, parms1.ToArray()).FirstOrDefault();
                if (s1 != "")
                {
                    retVal.Prezime_a = s1;
                }
                var s2 = dbCtx.Database.SqlQuery<DateTime>(sqlDat, parms2.ToArray()).FirstOrDefault();
                if (s2 != null)
                {
                    retVal.Dat_rodjenja_a = s2;
                }
            }
            catch (Exception e)
            {
                return null;
            }


            return retVal;
        }

        public bool VratiAktivnostProfilaKorisnika(string korisnickoIme)
        {
            bool retVal = false;
            string sql = @"SELECT ProfilOdobren from Korisnici WHERE KorisnickoIme=@KorisnickoIme";
            List<SqlParameter> parms = new List<SqlParameter>()
            {
              new SqlParameter {ParameterName = "@KorisnickoIme", Value = korisnickoIme , DbType = System.Data.DbType.String},
            };
            try
            {
                var s = dbCtx.Database.SqlQuery<bool>(sql, parms.ToArray()).FirstOrDefault();
                if (s)
                {
                    retVal = true;
                }
            }
            catch (Exception e)
            {

            }


            return retVal;
        }
        public bool VratiAktivnostProfilaKorisnikaJmbg(long jmbg)
        {
            bool retVal = false;
            string sql = @"SELECT ProfilOdobren from Korisnici WHERE JMBGKorisnika=@JMBGKorisnika";
            List<SqlParameter> parms = new List<SqlParameter>()
            {
              new SqlParameter {ParameterName = "@JMBGKorisnika", Value = jmbg , DbType = System.Data.DbType.Int64},
            };
            try
            {
                var s = dbCtx.Database.SqlQuery<bool>(sql, parms.ToArray()).FirstOrDefault();
                if (s)
                {
                    retVal = true;
                }
            }
            catch (Exception e)
            {

            }


            return retVal;
        }
        public bool PromijeniAktivnostProfilaKorisnika(long jmbg, bool odobren)
        {
            bool retVal = false;
            string sql = @"UPDATE Korisnici set ProfilOdobren=@Odobren WHERE JMBGKorisnika=@JMBGKorisnika";
            List<SqlParameter> parms = new List<SqlParameter>()
            {
              new SqlParameter {ParameterName = "@JMBGKorisnika", Value = jmbg , DbType = System.Data.DbType.Int64},
              new SqlParameter {ParameterName = "@Odobren", Value = odobren , DbType = System.Data.DbType.Boolean},
            };
            try
            {
                int s = dbCtx.Database.ExecuteSqlCommand(String.Format("UPDATE Korisnici set ProfilOdobren='{0}' WHERE JMBGKorisnika={1}", odobren, jmbg));
                if (s != 0)
                {
                    retVal = true;
                }
            }
            catch (Exception e)
            {

            }


            return retVal;
        }

        public long VratiJMBGVlasnika(string korisnickoIme)
        {
            long retVal = -1;
            string sql = @"SELECT JMBGKorisnika from Korisnici WHERE KorisnickoIme=@KorisnickoIme";
            List<SqlParameter> parms = new List<SqlParameter>()
            {
              new SqlParameter {ParameterName = "@KorisnickoIme", Value = korisnickoIme , DbType = System.Data.DbType.String},
            };
            try
            {
                var s = dbCtx.Database.SqlQuery<long>(sql, parms.ToArray()).FirstOrDefault();
                if (s != 0)
                {
                    retVal = s;
                }
            }
            catch (Exception e)
            {

            }


            return retVal;
        }
    }
}
