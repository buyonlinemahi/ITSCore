using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CasePatientReferrerSupplierRepository : BaseRepository<CasePatientReferrerSupplier, ITSDBContext>, ICasePatientReferrerSupplierRepository
    {
        public CasePatientReferrerSupplierRepository(IContextFactory<ITSDBContext> contextFactory):
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {

        }

        public CasePatientReferrerSupplier GetCasePatientReferrerSupplierByCaseID(int caseID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<CasePatientReferrerSupplier>
                (Global.StoredProcedureConst.CasePatientReferrerSupplierRepositoryProcedures.GetCasePatientReferrerSupplierByCaseID, _CaseID).SingleOrDefault();
        }
    }
}
