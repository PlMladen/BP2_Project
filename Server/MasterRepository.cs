using Server.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class MasterRepository
    {
        private readonly ProjectDbContext dbContext;

        public ServisRepository ServisRepository { get; }

        public MasterRepository(ProjectDbContext context)
        {
            dbContext = context;
            ServisRepository = new ServisRepository(context);
        }
    }
}
