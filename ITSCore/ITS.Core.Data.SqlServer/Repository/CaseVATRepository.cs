using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CaseVATRepository : BaseRepository<CaseVAT, ITSDBContext>, ICaseVATRepository
    {
        public CaseVATRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddCaseVAT(CaseVAT caseVAT)
        {
            SqlParameter CaseID = new SqlParameter("@CaseID", caseVAT.CaseID);
            SqlParameter VAT = new SqlParameter("@VAT", caseVAT.VAT);          
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseVATRepositoryProcedure.AddCaseVAT, CaseID, VAT);
       
        }

        public CaseVAT GetCaseVATByCaseID(int caseID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<CaseVAT>(Global.StoredProcedureConst.CaseVATRepositoryProcedure.GetCaseVATByCaseID, _CaseID).SingleOrDefault<CaseVAT>();
        }
    }
}