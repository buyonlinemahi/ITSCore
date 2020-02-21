using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
namespace ITS.Core.Data.SqlServer.Repository
{
    public class ReferrerAuthorisationsRepository : BaseRepository<ReferrerAuthorisations, ITSDBContext>, IReferrerAuthorisationsRepository
    {
        public ReferrerAuthorisationsRepository(IContextFactory<ITSDBContext> contextFactory)
            : base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {

        }

        public IEnumerable<ReferrerAuthorisations> GetReferrerAuthorisationsByReferrerID(int referrerID,int userID, int skip, int take)
        {
            SqlParameter referrerIDParam = new SqlParameter("@ReferrerID", referrerID);
            SqlParameter _UserID = new SqlParameter("@UserID", userID);
            SqlParameter skipParam = new SqlParameter("@Skip", skip);
            SqlParameter takeParam = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<ReferrerAuthorisations>(Global.StoredProcedureConst.ReferrerAuthorisationsRepository.GetReferrerAuthorisationsByReferrerID, referrerIDParam, _UserID, skipParam, takeParam);
        }

        public int GetReferrerAuthorisationCountByReferrerID(int referrerID,int userID)
        {
            SqlParameter referrerIDParam = new SqlParameter("@ReferrerID", referrerID);
            SqlParameter _UserID = new SqlParameter("@UserID", userID);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.ReferrerAuthorisationsRepository.GetReferrerAuthorisationCountByReferrerID, referrerIDParam, _UserID).SingleOrDefault();
        }
    }
}
