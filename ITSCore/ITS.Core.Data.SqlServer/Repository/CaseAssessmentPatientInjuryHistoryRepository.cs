using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Data.SqlClient;

namespace ITS.Core.Data.SqlServer.Repository
{


    public class CaseAssessmentPatientInjuryHistoryRepository : BaseRepository<CaseAssessmentPatientInjuryHistory, ITSDBContext>, ICaseAssessmentPatientInjuryHistoryRepository
    {
        public CaseAssessmentPatientInjuryHistoryRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {

        }


        public int AddCaseAssessmentPatientInjuryHistory(CaseAssessmentPatientInjuryHistory caseAssessmentPatientInjuryHistory)
        {
            SqlParameter _CaseAssessmentDetailHistoryID = new SqlParameter("@CaseAssessmentDetailHistoryID", caseAssessmentPatientInjuryHistory.CaseAssessmentDetailHistoryID);
            SqlParameter AffectedArea = new SqlParameter("@AffectedArea", caseAssessmentPatientInjuryHistory.AffectedArea == null ? "" : caseAssessmentPatientInjuryHistory.AffectedArea);
            SqlParameter _Score = new SqlParameter("@Score", caseAssessmentPatientInjuryHistory.Score);
            SqlParameter Restriction = new SqlParameter("@Restriction", caseAssessmentPatientInjuryHistory.Restriction == null ? "" : caseAssessmentPatientInjuryHistory.Restriction);
            SqlParameter _SymptomDescriptionID = new SqlParameter("@SymptomDescriptionID", caseAssessmentPatientInjuryHistory.SymptomDescriptionID);
            SqlParameter _StrengthTestingID = new SqlParameter("@StrengthTestingID", caseAssessmentPatientInjuryHistory.StrengthTestingID);
            SqlParameter _AffectedAreaID = new SqlParameter("@AffectedAreaID", caseAssessmentPatientInjuryHistory.AffectedAreaID);
            SqlParameter _RestrictionRangeID = new SqlParameter("@RestrictionRangeID", caseAssessmentPatientInjuryHistory.RestrictionRangeID);
            SqlParameter _OtherSymptomDesciption = new SqlParameter("@OtherSymptomDesciption", caseAssessmentPatientInjuryHistory.OtherSymptomDesciption == null ? "" : caseAssessmentPatientInjuryHistory.OtherSymptomDesciption);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentPatientInjuryHistoryRepositoryProcedure.AddCaseAssessmentPatientInjuryHistory,
    _CaseAssessmentDetailHistoryID, AffectedArea, _Score, Restriction, _SymptomDescriptionID, _StrengthTestingID, _AffectedAreaID, _RestrictionRangeID,_OtherSymptomDesciption);



        }
    }
}