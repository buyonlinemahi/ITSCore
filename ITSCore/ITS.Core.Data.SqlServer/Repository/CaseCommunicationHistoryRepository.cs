using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CaseCommunicationHistoryRepository : BaseRepository<CaseCommunicationHistory, ITSDBContext>, ICaseCommunicationHistoryRepository
    {
        public CaseCommunicationHistoryRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddCaseCommunicationHistory(CaseCommunicationHistory caseCommunicationHistory)
        {
            SqlParameter CaseID = new SqlParameter("@CaseID  ", caseCommunicationHistory.CaseID);
            SqlParameter SentTo = new SqlParameter("@SentTo  ", caseCommunicationHistory.SentTo);
            SqlParameter SentCC = new SqlParameter("@SentCC ", !string.IsNullOrEmpty(caseCommunicationHistory.SentCC) ? (object)caseCommunicationHistory.SentCC : System.DBNull.Value);
            SqlParameter Subject = new SqlParameter("@Subject  ", caseCommunicationHistory.Subject);
            SqlParameter Message = new SqlParameter("@Message  ", caseCommunicationHistory.Message);
            SqlParameter UserID = new SqlParameter("@UserID  ", caseCommunicationHistory.UserID);
            SqlParameter UploadPath = new SqlParameter("@UploadPath ", !string.IsNullOrEmpty(caseCommunicationHistory.UploadPath) ? (object)caseCommunicationHistory.UploadPath : System.DBNull.Value);


            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.CaseCommunicationHistoryRepositoryProcedure.AddCaseCommunicationHistory, CaseID, SentTo, SentCC, Subject, Message, UserID, UploadPath).SingleOrDefault();
        }

        public IEnumerable<CaseCommunicationHistoryUser> GetCaseCommunicationHistoriesByCaseID(int caseID)
        {
            SqlParameter CaseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<CaseCommunicationHistoryUser>(Global.StoredProcedureConst.CaseCommunicationHistoryRepositoryProcedure.GetCaseCommunicationHistoriesByCaseID, CaseID);
        }

    }
}