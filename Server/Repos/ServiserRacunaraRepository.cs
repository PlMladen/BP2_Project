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


    }
}
