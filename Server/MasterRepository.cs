﻿using Server.Repos;
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
        public ServiserRacunaraRepository ServiserRacunaraRepository { get; }
        public RacunarRepository RacunarRepository { get; }
        public VlasnikRacunaraRepository VlasnikRacunaraRepository { get; }
        public KomponentaRepository KomponentaRepository { get; }
        public GarantniListRepository GarantniListRepository { get; }
        public MasterRepository(ProjectDbContext context)
        {
            dbContext = context;
            ServisRepository = new ServisRepository(context);
            ServiserRacunaraRepository = new ServiserRacunaraRepository(context);
            RacunarRepository = new RacunarRepository(context);
            VlasnikRacunaraRepository = new VlasnikRacunaraRepository(context);
            KomponentaRepository = new KomponentaRepository(context);
            GarantniListRepository = new GarantniListRepository(context);
        }
    }
}
