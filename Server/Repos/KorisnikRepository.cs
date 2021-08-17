using Common.Models;
using System;
using System.Collections.Generic;
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
            string sql = String.Format("INSERT INTO korisnici (JMBGKorisnika, KorisnickoIme, Lozinka, Uloga) values ({0}, '{1}', '{2}', '{3}')", korisnik.JMBG, korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Uloga);
            
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
