using Core.Base.Data.SqlServer;
using global::Core.Base.Data.SqlServer.Factory;
using global::Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{

    public class CaseHistoryRepository : BaseRepository<CaseHistory, ITSDBContext>, ICaseHistoryRepository
    {
        public CaseHistoryRepository(IContextFactory<ITSDBContext> contextFactory)
            : base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddCaseHistory(CaseHistory caseHistory)
        {
            var _CaseID = new SqlParameter("@CaseID", caseHistory.CaseID);
            var _EventDate = new SqlParameter("@EventDate", caseHistory.EventDate);
            var _UserID = new SqlParameter("@UserID", caseHistory.UserID);
            var _EventDescription = new SqlParameter("@EventDescription", caseHistory.EventDescription);
            var _EventTypeID = new SqlParameter("@EventTypeID", caseHistory.EventTypeID);

            return (int)Context.Database.SqlQuery<decimal>(
                Global.StoredProcedureConst.CaseHistoryRepositoryProcedure.Add_CaseHistory,
                _CaseID,
                _EventDate,
                _UserID,
                _EventDescription,
                _EventTypeID).SingleOrDefault();
        }
        
        public int UpdateCaseHistory(CaseHistory caseHistory)
        {
            var _CaseID = new SqlParameter("@CaseID", caseHistory.CaseID);
            var _EventDate = new SqlParameter("@EventDate", caseHistory.EventDate);
            var _UserID = new SqlParameter("@UserID", caseHistory.UserID);
            var _EventDescription = new SqlParameter("@EventDescription", caseHistory.EventDescription);
            var _EventTypeID = new SqlParameter("@EventTypeID", caseHistory.EventTypeID);
            var _CaseHistoryID = new SqlParameter("@EventTypeID", caseHistory.CaseHistoryID);

            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.CaseHistoryRepositoryProcedure.Update_CaseHistory,
                _CaseID,
                _EventDate,
                _UserID,
                _EventDescription,
                _EventTypeID,
                _CaseHistoryID
                ).SingleOrDefault();
        }

        public IEnumerable<CaseHistory> GetCaseHistories()
        {
            return Context.Database.SqlQuery<CaseHistory>(Global.StoredProcedureConst.CaseHistoryRepositoryProcedure.Get_CaseHistories);
        }
        public IEnumerable<CaseHistoryUser> GetCaseHistoriesByCaseID(int caseID)
        {
            SqlParameter CaseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<CaseHistoryUser>(Global.StoredProcedureConst.CaseHistoryRepositoryProcedure.GetCaseHistoriesByCaseID, CaseID);
        }
    }
}