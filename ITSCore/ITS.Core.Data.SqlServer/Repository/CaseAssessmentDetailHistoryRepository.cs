using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CaseAssessmentDetailHistoryRepository : BaseRepository<CaseAssessmentDetailHistory, ITSDBContext>, ICaseAssessmentDetailHistoryRepository
    {
        public CaseAssessmentDetailHistoryRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddCaseAssessmentDetailHistory(CaseAssessmentDetail caseAssessmentDetailHistory)
        {
            SqlParameter[] param = {
            new SqlParameter("@CaseAssessmentDetailID", caseAssessmentDetailHistory.CaseAssessmentDetailID),
            new SqlParameter("@AssessmentServiceID", caseAssessmentDetailHistory.AssessmentServiceID),
            new SqlParameter("@CaseID", caseAssessmentDetailHistory.CaseID),
            new SqlParameter("@HasThePatientHadTimeOff", (object)caseAssessmentDetailHistory.HasThePatientHadTimeOff ?? DBNull.Value),
            new SqlParameter("@AbsentDetail", !string.IsNullOrEmpty(caseAssessmentDetailHistory.AbsentDetail) ? (object)caseAssessmentDetailHistory.AbsentDetail : System.DBNull.Value),
            new SqlParameter("@HasThePatientReturnedToWork", (object)caseAssessmentDetailHistory.HasThePatientReturnedToWork ?? DBNull.Value),
            new SqlParameter("@PatientImpactOnWorkID", caseAssessmentDetailHistory.PatientImpactOnWorkID),
            new SqlParameter("@PatientWorkstatusID", caseAssessmentDetailHistory.PatientWorkstatusID),
            new SqlParameter("@PatientRecommendedTreatmentSessions", caseAssessmentDetailHistory.PatientRecommendedTreatmentSessions),
            new SqlParameter("@PatientRecommendedTreatmentSessionsDetail", !string.IsNullOrEmpty(caseAssessmentDetailHistory.PatientRecommendedTreatmentSessionsDetail) ? (object)caseAssessmentDetailHistory.PatientRecommendedTreatmentSessionsDetail : System.DBNull.Value),
            new SqlParameter("@PatientTreatmentPeriod", caseAssessmentDetailHistory.PatientTreatmentPeriod),
            new SqlParameter("@IsFurtherTreatmentRecommended ", (object)caseAssessmentDetailHistory.IsFurtherTreatmentRecommended ?? DBNull.Value),
            new SqlParameter("@PatientLevelOfRecoveryID", (object)caseAssessmentDetailHistory.PatientLevelOfRecoveryID ?? DBNull.Value),
            new SqlParameter("@SessionsPatientAttended", caseAssessmentDetailHistory.SessionsPatientAttended),
            new SqlParameter("@DatesOfSessionAttended", !string.IsNullOrEmpty(caseAssessmentDetailHistory.DatesOfSessionAttended) ? (object)caseAssessmentDetailHistory.DatesOfSessionAttended : System.DBNull.Value),
            new SqlParameter("@SessionsPatientFailedToAttend", caseAssessmentDetailHistory.SessionsPatientFailedToAttend),
            new SqlParameter("@FollowingTreatmentPatientLevelOfRecoveryID", (object)caseAssessmentDetailHistory.FollowingTreatmentPatientLevelOfRecoveryID ?? DBNull.Value),
            new SqlParameter("@AdditionalInformation", !string.IsNullOrEmpty(caseAssessmentDetailHistory.AdditionalInformation) ? (object)caseAssessmentDetailHistory.AdditionalInformation : System.DBNull.Value),
            new SqlParameter("@HasCompliedHomeExerciseProgramme", (object)caseAssessmentDetailHistory.HasCompliedHomeExerciseProgramme ?? DBNull.Value),
            new SqlParameter("@AbsentPeriod", caseAssessmentDetailHistory.AbsentPeriod),
            new SqlParameter("@AbsentPeriodDurationID",  (object)caseAssessmentDetailHistory.AbsentPeriodDurationID ?? DBNull.Value),
            new SqlParameter("@PatientTreatmentPeriodDetail", !string.IsNullOrEmpty(caseAssessmentDetailHistory.PatientTreatmentPeriodDetail) ? (object)caseAssessmentDetailHistory.PatientTreatmentPeriodDetail : System.DBNull.Value),
            new SqlParameter("@PatientTreatmentPeriodDurationID", (object)caseAssessmentDetailHistory.PatientTreatmentPeriodDurationID ?? DBNull.Value),
            new SqlParameter("@PractitionerID", (object)caseAssessmentDetailHistory.PractitionerID ?? DBNull.Value),
            new SqlParameter("@IsFurtherInvestigationOrOnwardReferralRequired",(object)caseAssessmentDetailHistory.IsFurtherInvestigationOrOnwardReferralRequired ?? DBNull.Value),
            new SqlParameter("@FurtherInvestigationOrOnwardReferral", !string.IsNullOrEmpty(caseAssessmentDetailHistory.FurtherInvestigationOrOnwardReferral) ? (object)caseAssessmentDetailHistory.FurtherInvestigationOrOnwardReferral : System.DBNull.Value),
            new SqlParameter("@EvidenceOfTreatmentRecommendations", !string.IsNullOrEmpty(caseAssessmentDetailHistory.EvidenceOfTreatmentRecommendations) ? (object)caseAssessmentDetailHistory.EvidenceOfTreatmentRecommendations : System.DBNull.Value),
            new SqlParameter("@TreatmentPeriodTypeID", caseAssessmentDetailHistory.TreatmentPeriodTypeID),
            new SqlParameter("@PatientDateOfReturn", (caseAssessmentDetailHistory.PatientDateOfReturn == null ? DBNull.Value : (object)caseAssessmentDetailHistory.PatientDateOfReturn)),
            new SqlParameter("@PatientRecommendationReturn", (caseAssessmentDetailHistory.PatientRecommendationReturn == null ? DBNull.Value : (object)caseAssessmentDetailHistory.PatientRecommendationReturn)),
         
             new SqlParameter("@IsPatientReturnToPreInjuryDuties", (object)caseAssessmentDetailHistory.IsPatientReturnToPreInjuryDuties ?? DBNull.Value),
            new SqlParameter("@PatientPreInjuryDutiesDate", caseAssessmentDetailHistory.PatientPreInjuryDutiesDate == null? DBNull.Value : (object)caseAssessmentDetailHistory.PatientPreInjuryDutiesDate),
            new SqlParameter("@MainFactors", caseAssessmentDetailHistory.MainFactors ==null?DBNull.Value : (object)caseAssessmentDetailHistory.MainFactors)
        };
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.CaseAssessmentDetailHistoryRepositoryProcedure.AddCaseAssessmentDetailHistory, param).SingleOrDefault();
        }
    }
}