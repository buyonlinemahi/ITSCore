using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Data.SqlClient;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CaseAssessmentPatientImpactHistoryRepository : BaseRepository<CaseAssessmentPatientImpactHistory, ITSDBContext>, ICaseAssessmentPatientImpactHistoryRepository
    {
        public CaseAssessmentPatientImpactHistoryRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {

        }

        public int AddCaseAssessmentPatientImpactHistory(CaseAssessmentPatientImpactHistory caseAssessmentPatientImpactHistory)
        {
            SqlParameter PatientImpactID = new SqlParameter("@PatientImpactID", caseAssessmentPatientImpactHistory.PatientImpactID);
            SqlParameter PatientImpactValueID = new SqlParameter("@PatientImpactValueID", caseAssessmentPatientImpactHistory.PatientImpactValueID);
            SqlParameter CaseAssessmentDetailHistoryID = new SqlParameter("@CaseAssessmentDetailHistoryID", caseAssessmentPatientImpactHistory.CaseAssessmentDetailHistoryID);
            SqlParameter Comment = new SqlParameter("@Comment", !string.IsNullOrEmpty(caseAssessmentPatientImpactHistory.Comment) ? (object)caseAssessmentPatientImpactHistory.Comment : System.DBNull.Value);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentPatientImpactHistoryProcedures.AddCaseAssessmentPatientImpactHistory,
               PatientImpactID, PatientImpactValueID, CaseAssessmentDetailHistoryID, Comment);
        }
    }
}
