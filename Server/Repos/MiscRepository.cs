using Common.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repos
{
    public class MiscRepository
    {
        private readonly ProjectDbContext dbCtx;
        private readonly PosjedujeRepository posjedujeRepository;
        private readonly KorisnikRepository korisnikRepository;
        private readonly RacunarRepository racunarRepository;
        private readonly VlasnikRacunaraRepository vlasnikRacunaraRepository;

        public MiscRepository(ProjectDbContext dbContext, 
                              PosjedujeRepository posjeduje,
                              KorisnikRepository korisnik,
                              RacunarRepository racunar,
                              VlasnikRacunaraRepository vlasnikRacunaraRepo)
        {
            dbCtx = dbContext;
            posjedujeRepository = posjeduje;
            korisnikRepository = korisnik;
            racunarRepository = racunar;
            vlasnikRacunaraRepository = vlasnikRacunaraRepo;
        }

        public int ReturnNumberOfUserComputersByType(long ownerId, Vrsta_racunara vrsta_Racunara)
        {
            int retVal = 0;
            try
            {
                string sql = @"declare @retVal int exec @retVal = izlistaj_za_vlasnika_broj_racunara_po_tipu @ID_vlasnika, @BrRacunara select @retVal";
                List<SqlParameter> parms = new List<SqlParameter>()
            {
              new SqlParameter {ParameterName = "@ID_vlasnika", Value = ownerId , DbType = System.Data.DbType.Int64},
              new SqlParameter{ ParameterName = "@BrRacunara", Value = (short)vrsta_Racunara, DbType = System.Data.DbType.Int32 },

            };

                retVal = dbCtx.Database.SqlQuery<int>(sql, parms.ToArray()).DefaultIfEmpty<int>(0).FirstOrDefault();
            }
            catch(Exception e)
            {

            }
            return retVal;
        }

        public Common.Models.SqlUpitVlasnikServisCijena ReturnOwnerWithMaxRepairPrice()
        {
            Common.Models.SqlUpitVlasnikServisCijena retVal = null;
            try
            {
                string sql = @"select * from vrati_vlasnika_sa_najskupljom_popravkom()";
                var s = dbCtx.Database.SqlQuery<SqlUpitVlasnikServisCijena>(sql).DefaultIfEmpty<SqlUpitVlasnikServisCijena>(null).FirstOrDefault();
                if (s != null) {
                    retVal = new Common.Models.SqlUpitVlasnikServisCijena()
                    {
                        Cijena = s.Cijena,
                        Ime = s.Ime,
                        JMBG_vlasnika = s.JMBG_vlasnika,
                        Naziv_servisa = s.Naziv_servisa,
                        Prezime = s.Prezime
                    };
                }
            }catch(Exception e)
            {

            }
            
            return retVal;
        }

        public string ReturnTheOldestWorker(string nazivServisa)
        {
            string retVal = string.Empty;
            try
            {
                string sql = @"declare @ret varchar(200); begin exec Vrati_najstarijeg_servisera @Naziv_servisa, @ret output select @ret end";
                List<SqlParameter> parms = new List<SqlParameter>()
                 {
                    new SqlParameter {ParameterName = "@Naziv_servisa", Value = nazivServisa , DbType = System.Data.DbType.String},
                    new SqlParameter{ ParameterName = "@retVal", Value = "", DbType = System.Data.DbType.String, Direction = ParameterDirection.Output },

                };

                retVal = dbCtx.Database.SqlQuery<string>(sql, parms.ToArray()).DefaultIfEmpty<string>("").FirstOrDefault();
                
            }
            catch (Exception e)
            {

            }

            return retVal;
        }

        public int ReturnCountOfAdultOwners()
        {
            int retVal = 0;
            try
            {
                string sql = @"declare @ret as int; begin exec Vrati_broj_punoljetnih_vlasnika_racunara  @ret output select @ret end";
                List<SqlParameter> parms = new List<SqlParameter>()
                 {
                    new SqlParameter{ ParameterName = "@retVal", Value = 0, DbType = System.Data.DbType.Int32, Direction = ParameterDirection.Output },

                };

                retVal = dbCtx.Database.SqlQuery<int>(sql, parms.ToArray()).DefaultIfEmpty<int>(0).FirstOrDefault();

            }
            catch (Exception e)
            {

            }

            return retVal;
        }
        public bool EksportujPosjedujeVezuUCsv(string direktorijum)
        {
            List<Common.Models.PosjedujeKorisnik> PosjedujeKorisnikSet = new List<PosjedujeKorisnik>();
            
            foreach (var item in posjedujeRepository.GetAll())
            {
                Korisnik k = korisnikRepository.VratiKorisnika(korisnikRepository.VratiKorisnickoIme(item.JMBG_vl));
                Common.Models.PosjedujeKorisnik posjedujeKorisnik = new PosjedujeKorisnik()
                {
                    Id_racunara = item.Id_racunara,
                    Ime_vl = item.Ime_vl,
                    JMBG_vl = item.JMBG_vl,
                    Prezime_vl = item.Prezime_vl,
                    Proizvodjac_racunara = item.Proizvodjac_racunara,
                    Vrsta_racunara = item.Vrsta_racunara,
                    
                    Uloga = "Vlasnik_racunara",
                    
                    KorisnickoIme = k.KorisnickoIme,
                    Lozinka = k.Lozinka,
                    ProfilOdobren = k.ProfilAktivan
                };

                if (item.Racunar != null)
                    posjedujeKorisnik.Racunar = item.Racunar;
                if (item.Vlasnik_racunara != null)
                    posjedujeKorisnik.Vlasnik_racunara = item.Vlasnik_racunara;
                PosjedujeKorisnikSet.Add(posjedujeKorisnik);
            }
            using(var streamWriter = new StreamWriter(direktorijum))
            {
                using(var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(PosjedujeKorisnikSet);
                }
            }
            return true;
        }
        public IEnumerable<Common.Models.Posjeduje> ImportujPosjedujeVezuIzCsv(string direktorijum)
        {
            List<Common.Models.PosjedujeKorisnik> retVal1 = new List<Common.Models.PosjedujeKorisnik>();
            Common.Models.PosjedujeKorisnik value;
            using(var fileReader = File.OpenText(direktorijum))
            {
                var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);
                while (csvReader.Read())
                {
                    var x = csvReader.GetRecord<Common.Models.PosjedujeKorisnik>();
                    retVal1.Add(x);
                    
                }

            }

            
            foreach (var item in retVal1)
            {
                if(korisnikRepository.VratiKorisnika(item.KorisnickoIme) == null)
                {
                    Common.Models.Korisnik k = new Korisnik()
                    {
                        Ime = item.Ime_vl,
                        KorisnickoIme = item.KorisnickoIme,
                        JMBG = item.JMBG_vl,
                        Lozinka = item.Lozinka,
                        ProfilAktivan = item.ProfilOdobren,
                        Uloga = "Vlasnik_racunara",
                        Prezime = item.Prezime_vl,
                        DatumRodjenja = item.Vlasnik_racunara.Dat_rodjenja_vl,
                        Adresa = item.Vlasnik_racunara.Adresa_vl
                    };
                    korisnikRepository.RegistrujKorisnika(k);
                }
                if(racunarRepository.GetRacunar(item.Id_racunara) == null)
                {
                    racunarRepository.Add(new Common.Models.Racunar()
                    {
                        Brzina_procesora = item.Racunar.Brzina_procesora,
                        ID_racunara = item.Id_racunara,
                        Kapacitet_memorije = item.Racunar.Kapacitet_memorije,
                        Kapacitet_RAM = item.Racunar.Kapacitet_RAM,
                        Komponenta = item.Racunar.Komponenta ,
                        Vrsta_racunara = item.Vrsta_racunara,
                        Proizvodjac = item.Proizvodjac_racunara,
                        Posjeduje = item.Racunar.Posjeduje
                    });
                }
                
                    if(posjedujeRepository.Get(item.JMBG_vl, item.Id_racunara) == null)
                    {
                        posjedujeRepository.Add(new Common.Models.Posjeduje()
                        {
                            Id_racunara = item.Id_racunara,
                            JMBG_vl = item.JMBG_vl,
                            Ime_vl = item.Ime_vl,
                            Prezime_vl = item.Prezime_vl,
                            Proizvodjac_racunara = item.Proizvodjac_racunara,
                            Vrsta_racunara = item.Vrsta_racunara,
                            Racunar = item.Racunar != null ? item.Racunar : racunarRepository.GetRacunar(item.Id_racunara),
                            Vlasnik_racunara = item.Vlasnik_racunara != null ? item.Vlasnik_racunara : vlasnikRacunaraRepository.Get(item.JMBG_vl)
                        });
                    }
                    /*else
                    {
                        posjedujeRepository.Delete(item.JMBG_vl, item.Id_racunara);
                        posjedujeRepository.Add(new Common.Models.Posjeduje()
                        {
                            Id_racunara = item.Id_racunara,
                            JMBG_vl = item.JMBG_vl,
                            Ime_vl = item.Ime_vl,
                            Prezime_vl = item.Prezime_vl,
                            Proizvodjac_racunara = item.Proizvodjac_racunara,
                            Vrsta_racunara = item.Vrsta_racunara,
                            Racunar = item.Racunar != null ? item.Racunar : racunarRepository.GetRacunar(item.Id_racunara),
                            Vlasnik_racunara = item.Vlasnik_racunara != null ? item.Vlasnik_racunara : vlasnikRacunaraRepository.Get(item.JMBG_vl)
                        });
                    }*/
                
            }
           
            return retVal1;
        }

        public bool EksportujPosjedujeVezuZaVlasnikaUCsv(string direktorijum, long jmbg)
        {
            List<Common.Models.PosjedujeKorisnik> PosjedujeKorisnikSet = new List<PosjedujeKorisnik>();

            foreach (var item in posjedujeRepository.GetAll().Where(_ => _.JMBG_vl == jmbg))
            {
                Korisnik k = korisnikRepository.VratiKorisnika(korisnikRepository.VratiKorisnickoIme(item.JMBG_vl));
                Common.Models.PosjedujeKorisnik posjedujeKorisnik = new PosjedujeKorisnik()
                {
                    Id_racunara = item.Id_racunara,
                    Ime_vl = item.Ime_vl,
                    JMBG_vl = item.JMBG_vl,
                    Prezime_vl = item.Prezime_vl,
                    Proizvodjac_racunara = item.Proizvodjac_racunara,
                    Vrsta_racunara = item.Vrsta_racunara,

                    Uloga = "Vlasnik_racunara",

                    KorisnickoIme = k.KorisnickoIme,
                    Lozinka = k.Lozinka,
                    ProfilOdobren = k.ProfilAktivan
                };

                if (item.Racunar != null)
                    posjedujeKorisnik.Racunar = item.Racunar;
                if (item.Vlasnik_racunara != null)
                    posjedujeKorisnik.Vlasnik_racunara = item.Vlasnik_racunara;
                PosjedujeKorisnikSet.Add(posjedujeKorisnik);
            }
            using (var streamWriter = new StreamWriter(direktorijum))
            {
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(PosjedujeKorisnikSet);
                }
            }
            return true;
            
        }
    }
}
