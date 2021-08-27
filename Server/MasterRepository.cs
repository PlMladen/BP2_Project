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
        public ServiserRacunaraRepository ServiserRacunaraRepository { get; }
        public RacunarRepository RacunarRepository { get; }
        public VlasnikRacunaraRepository VlasnikRacunaraRepository { get; }
        public KomponentaRepository KomponentaRepository { get; }
        public GarantniListRepository GarantniListRepository { get; }
        public PosjedujeRepository PosjedujeRepository { get; }
        public SastojiSeRepository SastojiSeRepository { get; }
        public RadiRepository RadiRepository { get; }
        public DonosiRepository DonosiRepository { get; }
        public ServisiraRepository ServisiraRepository { get; }
        public RacunarskiServisRepository RacunarskiServisRepository { get; }
        public MiscRepository MiscRepository { get; }
        public KorisnikRepository KorisnikRepository { get; }
        public MasterRepository(ProjectDbContext context)
        {
            dbContext = context;
            ServisRepository = new ServisRepository(context);
            ServiserRacunaraRepository = new ServiserRacunaraRepository(context, ServisRepository);
            RacunarRepository = new RacunarRepository(context);
            VlasnikRacunaraRepository = new VlasnikRacunaraRepository(context);
            KomponentaRepository = new KomponentaRepository(context);
            GarantniListRepository = new GarantniListRepository(context);
            PosjedujeRepository = new PosjedujeRepository(context);
            SastojiSeRepository = new SastojiSeRepository(context);
            RadiRepository = new RadiRepository(context);
            DonosiRepository = new DonosiRepository(context);
            ServisiraRepository = new ServisiraRepository(context);
            RacunarskiServisRepository = new RacunarskiServisRepository(context);
            KorisnikRepository = new KorisnikRepository(context, VlasnikRacunaraRepository, ServiserRacunaraRepository);
            MiscRepository = new MiscRepository(context, PosjedujeRepository, KorisnikRepository, RacunarRepository, VlasnikRacunaraRepository);
        }
    }
}
