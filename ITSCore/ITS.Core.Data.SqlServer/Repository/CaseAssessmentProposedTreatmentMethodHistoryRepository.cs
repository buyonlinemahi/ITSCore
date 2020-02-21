using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Data.SqlClient;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CaseAssessmentProposedTreatmentMethodHistoryRepository : BaseRepository<CaseAssessmentProposedTreatmentMethodHistory, ITSDBContext>, ICaseAssessmentProposedTreatmentMethodHistoryRepository
    {
        public CaseAssessmentProposedTreatmentMethodHistoryRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddCaseAssessmentProposedTreatmentMethodHistory(CaseAssessmentProposedTreatmentMethodHistory caseAssessmentProposedTreatmentMethodHistory)
        {
            SqlParameter CaseAssessmentHistoryID = new SqlParameter("@CaseAssessmentHistoryID", caseAssessmentProposedTreatmentMethodHistory.CaseAssessmentHistoryID);
            SqlParameter CaseID = new SqlParameter("@CaseID", caseAssessmentProposedTreatmentMethodHistory.CaseID);
            SqlParameter ProposedTreatmentMethodID = new SqlParameter("@ProposedTreatmentMethodID", caseAssessmentProposedTreatmentMethodHistory.ProposedTreatmentMethodID);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentProposedTreatmentMethodHistoryRepositoryProcedure.AddCaseAssessmentProposedTreatmentMethodHistory, CaseAssessmentHistoryID, CaseID, ProposedTreatmentMethodID);
        }

    }
}