using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repos
{
    public class GarantniListRepository
    {
        private readonly ProjectDbContext dbCtx;

        public GarantniListRepository(ProjectDbContext context)
        {
            dbCtx = context;
        }

        public bool Add(Common.Models.Garantni_list garantni_List)
        {
            if (dbCtx.Garantni_listSet.FirstOrDefault((s) => s.Id_gar_list == garantni_List.Id_gar_list) != null)
            {
                return false;
            }

            dbCtx.Garantni_listSet.Add(new Garantni_list()
            {
                Period_vazenja = garantni_List.Period_vazenja
            });

            return dbCtx.SaveChanges() > 0;
        }

        public bool Delete(int idGL)
        {
            try
            {
                dbCtx.Garantni_listSet.Remove(dbCtx.Garantni_listSet.FirstOrDefault((s) => s.Id_gar_list == idGL));
                dbCtx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public IEnumerable<Common.Models.Garantni_list> GetAll()
        {
            var retVal = new List<Common.Models.Garantni_list>();
            foreach (var glFromDb in dbCtx.Garantni_listSet.ToList())
            {
                var garantni_list = new Common.Models.Garantni_list()
                {
                    Id_gar_list = glFromDb.Id_gar_list,
                    Period_vazenja = glFromDb.Period_vazenja
                };
                retVal.Add(garantni_list);
            }
            return retVal;
        }

        public Common.Models.Garantni_list Get(int idGL)
        {
            var glFromDb = dbCtx.Garantni_listSet.Find(idGL);
            if (glFromDb != null)
            {
                var garantni_list = new Common.Models.Garantni_list()
                {
                    Id_gar_list = glFromDb.Id_gar_list,
                    Period_vazenja = glFromDb.Period_vazenja
                };
                return garantni_list;
            }
            return null;
        }
        public void Update(Common.Models.Garantni_list garantni_List)
        {
            var garantni_ListForDb = new Garantni_list()
            {
                Id_gar_list = garantni_List.Id_gar_list,
                Period_vazenja = garantni_List.Period_vazenja
            };

            try {
                var garantni_ListFromDb = dbCtx.Garantni_listSet.FirstOrDefault((s) => s.Id_gar_list == garantni_ListForDb.Id_gar_list);
                dbCtx.Entry(garantni_ListFromDb).CurrentValues.SetValues(garantni_ListForDb);
                dbCtx.SaveChanges();
            }catch(Exception e)
            {

            }
        }
    }
}
