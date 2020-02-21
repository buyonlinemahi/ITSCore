using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;



namespace ITS.Core.Data.SqlServer.Repository
{
    public class PatientImpactOnWorkRepository : BaseRepository<PatientImpactOnWork, ITSDBContext>, IPatientImpactOnWorkRepository
    {
        public PatientImpactOnWorkRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

    }
}
