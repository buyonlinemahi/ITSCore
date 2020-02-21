using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class ReferrerProjectTreatmentTreatmentTypeRepository : BaseRepository<ReferrerProjectTreatmentTreatmentType, ITSDBContext>, IReferrerProjectTreatmentTreatmentTypeRepository
    {
        public ReferrerProjectTreatmentTreatmentTypeRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<ReferrerProjectTreatmentTreatmentType> GetReferrerProjectTreatmentTreatmentTypeByReferrerProjectTreatmentTypeID(int referrerProjectTreatmentID)
        {
            return
                Context.Database.SqlQuery<ReferrerProjectTreatmentTreatmentType>(Global.StoredProcedureConst.ReferrerProjectTreatmentTreatmentTypeRepositoryProcedures.GetReferrerProjectTreatmentTreatmentTypeByReferrerProjectTreatmentTypeID, new SqlParameter("@ReferrerProjectTreatmentTypeID", referrerProjectTreatmentID));
        }
    }
}
