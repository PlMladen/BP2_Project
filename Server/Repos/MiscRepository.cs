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
    public class MiscRepository
    {
        private readonly ProjectDbContext dbCtx;

        public MiscRepository(ProjectDbContext dbContext)
        {
            dbCtx = dbContext;
            
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
                string sql = @"declare @ret varchar(200); begin exec Vrati_najstarijeg_servisera 'Servis 3', @ret output select @ret end";
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
    }
}
