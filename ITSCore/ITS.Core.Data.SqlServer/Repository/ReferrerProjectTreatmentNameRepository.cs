using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class ReferrerProjectTreatmentNameRepository : BaseRepository<ReferrerProjectTreatmentName, ITSDBContext>, IReferrerProjectTreatmentNameRepository
    {
        
        public ReferrerProjectTreatmentNameRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<ReferrerProjectTreatmentName> GetReferrerProjectTreatmentNamesByReferrerProjectID(int referrerProjectID)
        {
            var _ReferrerProjectID = new SqlParameter("@ReferrerProjectID", referrerProjectID); ;
            return Context.Database.SqlQuery<ReferrerProjectTreatmentName>(Global.StoredProcedureConst.ReferrerProjectTreatmentNameRepositoryProcedure.GetReferrerProjectTreatmentNamesByReferrerProjectID, _ReferrerProjectID);
        }

        public IEnumerable<ReferrerProjectTreatmentName> GetReferrerEnabledProjectTreatmentNamesByReferrerProjectID(int referrerProjectID)
        {
            var _ReferrerProjectID = new SqlParameter("@ReferrerProjectID", referrerProjectID); ;
            return Context.Database.SqlQuery<ReferrerProjectTreatmentName>(Global.StoredProcedureConst.ReferrerProjectTreatmentNameRepositoryProcedure.GetReferrerEnabledProjectTreatmentNamesByReferrerProjectID, _ReferrerProjectID);
        }
    }
}
