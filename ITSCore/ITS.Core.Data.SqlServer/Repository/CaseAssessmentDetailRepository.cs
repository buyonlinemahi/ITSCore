using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ReportModels = ITS.Core.Data.Model.Reports;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CaseAssessmentDetailRepository : BaseRepository<CaseAssessmentDetail, ITSDBContext>, ICaseAssessmentDetailRepository
    {
        public CaseAssessmentDetailRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddCaseAssessmentDetail(CaseAssessmentDetail caseAssessmentDetail)
        {
            SqlParameter[] param = { 
            new SqlParameter("@AssessmentServiceID", caseAssessmentDetail.AssessmentServiceID),
            new SqlParameter("@CaseID", caseAssessmentDetail.CaseID),
            new SqlParameter("@HasThePatientHadTimeOff", (object)caseAssessmentDetail.HasThePatientHadTimeOff ?? DBNull.Value),
            new SqlParameter("@AbsentDetail", !string.IsNullOrEmpty(caseAssessmentDetail.AbsentDetail) ? (object)caseAssessmentDetail.AbsentDetail : System.DBNull.Value),
            new SqlParameter("@HasThePatientReturnedToWork", (object)caseAssessmentDetail.HasThePatientReturnedToWork ?? DBNull.Value),
            new SqlParameter("@PatientImpactOnWorkID", caseAssessmentDetail.PatientImpactOnWorkID),
            new SqlParameter("@PatientWorkstatusID", caseAssessmentDetail.PatientWorkstatusID),
            new SqlParameter("@PatientRecommendedTreatmentSessions", caseAssessmentDetail.PatientRecommendedTreatmentSessions),
            new SqlParameter("@PatientRecommendedTreatmentSessionsDetail", !string.IsNullOrEmpty(caseAssessmentDetail.PatientRecommendedTreatmentSessionsDetail) ? (object)caseAssessmentDetail.PatientRecommendedTreatmentSessionsDetail : System.DBNull.Value),
            new SqlParameter("@PatientTreatmentPeriod", caseAssessmentDetail.PatientTreatmentPeriod),
            new SqlParameter("@IsFurtherTreatmentRecommended ",(object)caseAssessmentDetail.IsFurtherTreatmentRecommended ?? DBNull.Value),
            new SqlParameter("@PatientLevelOfRecoveryID",(object)caseAssessmentDetail.PatientLevelOfRecoveryID ?? DBNull.Value),
            new SqlParameter("@SessionsPatientAttended", caseAssessmentDetail.SessionsPatientAttended),
            new SqlParameter("@DatesOfSessionAttended", !string.IsNullOrEmpty(caseAssessmentDetail.DatesOfSessionAttended) ? (object)caseAssessmentDetail.DatesOfSessionAttended : System.DBNull.Value),
            new SqlParameter("@SessionsPatientFailedToAttend", caseAssessmentDetail.SessionsPatientFailedToAttend),
            new SqlParameter("@FollowingTreatmentPatientLevelOfRecoveryID", (object)caseAssessmentDetail.FollowingTreatmentPatientLevelOfRecoveryID ?? DBNull.Value),
            new SqlParameter("@AdditionalInformation", !string.IsNullOrEmpty(caseAssessmentDetail.AdditionalInformation) ? (object)caseAssessmentDetail.AdditionalInformation : System.DBNull.Value),
            new SqlParameter("@HasCompliedHomeExerciseProgramme", (object)caseAssessmentDetail.HasCompliedHomeExerciseProgramme ?? DBNull.Value),
            new SqlParameter("@AbsentPeriod", caseAssessmentDetail.AbsentPeriod),
            new SqlParameter("@AbsentPeriodDurationID", (object)caseAssessmentDetail.AbsentPeriodDurationID ?? DBNull.Value),
            new SqlParameter("@PatientTreatmentPeriodDetail", !string.IsNullOrEmpty(caseAssessmentDetail.PatientTreatmentPeriodDetail) ? (object)caseAssessmentDetail.PatientTreatmentPeriodDetail : System.DBNull.Value),
            new SqlParameter("@PatientTreatmentPeriodDurationID", (object)caseAssessmentDetail.PatientTreatmentPeriodDurationID ?? DBNull.Value),
            new SqlParameter("@PractitionerID", (object)caseAssessmentDetail.PractitionerID ?? DBNull.Value),
            new SqlParameter("@EvidenceOfClinicalReasoning", !string.IsNullOrEmpty(caseAssessmentDetail.EvidenceOfClinicalReasoning) ? (object)caseAssessmentDetail.EvidenceOfClinicalReasoning : System.DBNull.Value),
            new SqlParameter("@IsFurtherInvestigationOrOnwardReferralRequired",(object)caseAssessmentDetail.IsFurtherInvestigationOrOnwardReferralRequired ?? DBNull.Value),
            new SqlParameter("@FurtherInvestigationOrOnwardReferral", !string.IsNullOrEmpty(caseAssessmentDetail.FurtherInvestigationOrOnwardReferral) ? (object)caseAssessmentDetail.FurtherInvestigationOrOnwardReferral : System.DBNull.Value),
            new SqlParameter("@EvidenceOfTreatmentRecommendations", !string.IsNullOrEmpty(caseAssessmentDetail.EvidenceOfTreatmentRecommendations) ? (object)caseAssessmentDetail.EvidenceOfTreatmentRecommendations : System.DBNull.Value),
            new SqlParameter("@TreatmentPeriodTypeID", caseAssessmentDetail.TreatmentPeriodTypeID),
            new SqlParameter("@PatientDateOfReturn", (caseAssessmentDetail.PatientDateOfReturn == null ? DBNull.Value : (object)caseAssessmentDetail.PatientDateOfReturn)),
            new SqlParameter("@PatientRecommendationReturn", (caseAssessmentDetail.PatientRecommendationReturn == null ? DBNull.Value : (object)caseAssessmentDetail.PatientRecommendationReturn)),
            new SqlParameter("@IsPatientReturnToPreInjuryDuties", (object)caseAssessmentDetail.IsPatientReturnToPreInjuryDuties ?? DBNull.Value),
            new SqlParameter("@PatientPreInjuryDutiesDate", caseAssessmentDetail.PatientPreInjuryDutiesDate == null? DBNull.Value : (object)caseAssessmentDetail.PatientPreInjuryDutiesDate),
            new SqlParameter("@MainFactors", caseAssessmentDetail.MainFactors ==null?DBNull.Value : (object)caseAssessmentDetail.MainFactors)
        };
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.CaseAssessmentDetailRepositoryProcedure.AddCaseAssessmentDetail, param).SingleOrDefault();
        }

        public int UpdateCaseAssessmentDetailByCaseAssessmentDetailID(CaseAssessmentDetail caseAssessmentDetail)
        {
            SqlParameter[] param = { 
            new SqlParameter("@CaseAssessmentDetailID", caseAssessmentDetail.CaseAssessmentDetailID),
            new SqlParameter("@AssessmentServiceID", caseAssessmentDetail.AssessmentServiceID),
            new SqlParameter("@CaseID", caseAssessmentDetail.CaseID),
            new SqlParameter("@HasThePatientHadTimeOff", (object)caseAssessmentDetail.HasThePatientHadTimeOff ?? DBNull.Value),
            new SqlParameter("@AbsentDetail", !string.IsNullOrEmpty(caseAssessmentDetail.AbsentDetail) ? (object)caseAssessmentDetail.AbsentDetail : System.DBNull.Value),
            new SqlParameter("@HasThePatientReturnedToWork", (object)caseAssessmentDetail.HasThePatientReturnedToWork ?? DBNull.Value),
            new SqlParameter("@PatientImpactOnWorkID", caseAssessmentDetail.PatientImpactOnWorkID),
            new SqlParameter("@PatientWorkstatusID", caseAssessmentDetail.PatientWorkstatusID),
            new SqlParameter("@PatientRecommendedTreatmentSessions", caseAssessmentDetail.PatientRecommendedTreatmentSessions),
            new SqlParameter("@PatientRecommendedTreatmentSessionsDetail", !string.IsNullOrEmpty(caseAssessmentDetail.PatientRecommendedTreatmentSessionsDetail) ? (object)caseAssessmentDetail.PatientRecommendedTreatmentSessionsDetail : System.DBNull.Value),
            new SqlParameter("@PatientTreatmentPeriod", caseAssessmentDetail.PatientTreatmentPeriod),
            new SqlParameter("@IsFurtherTreatmentRecommended ",(object)caseAssessmentDetail.IsFurtherTreatmentRecommended ?? DBNull.Value),
            new SqlParameter("@PatientLevelOfRecoveryID", caseAssessmentDetail.PatientLevelOfRecoveryID),
            new SqlParameter("@SessionsPatientAttended", caseAssessmentDetail.SessionsPatientAttended),
            new SqlParameter("@DatesOfSessionAttended", !string.IsNullOrEmpty(caseAssessmentDetail.DatesOfSessionAttended) ? (object)caseAssessmentDetail.DatesOfSessionAttended : System.DBNull.Value),
            new SqlParameter("@SessionsPatientFailedToAttend", caseAssessmentDetail.SessionsPatientFailedToAttend),
            new SqlParameter("@FollowingTreatmentPatientLevelOfRecoveryID", (object)caseAssessmentDetail.FollowingTreatmentPatientLevelOfRecoveryID ?? DBNull.Value),
            new SqlParameter("@AdditionalInformation", !string.IsNullOrEmpty(caseAssessmentDetail.AdditionalInformation) ? (object)caseAssessmentDetail.AdditionalInformation : System.DBNull.Value),
            new SqlParameter("@HasCompliedHomeExerciseProgramme", (object)caseAssessmentDetail.HasCompliedHomeExerciseProgramme ?? DBNull.Value),
            new SqlParameter("@AbsentPeriod", caseAssessmentDetail.AbsentPeriod),
            new SqlParameter("@AbsentPeriodDurationID", (object)caseAssessmentDetail.AbsentPeriodDurationID ?? DBNull.Value),
            new SqlParameter("@PatientTreatmentPeriodDetail", !string.IsNullOrEmpty(caseAssessmentDetail.PatientTreatmentPeriodDetail) ? (object)caseAssessmentDetail.PatientTreatmentPeriodDetail : System.DBNull.Value),
            new SqlParameter("@PatientTreatmentPeriodDurationID", (object)caseAssessmentDetail.PatientTreatmentPeriodDurationID ?? DBNull.Value),
            new SqlParameter("@PractitionerID", (object)caseAssessmentDetail.PractitionerID ?? DBNull.Value),
            new SqlParameter("@EvidenceOfClinicalReasoning", !string.IsNullOrEmpty(caseAssessmentDetail.EvidenceOfClinicalReasoning) ? (object)caseAssessmentDetail.EvidenceOfClinicalReasoning : System.DBNull.Value),
            new SqlParameter("@IsFurtherInvestigationOrOnwardReferralRequired",(object)caseAssessmentDetail.IsFurtherInvestigationOrOnwardReferralRequired ?? DBNull.Value),
            new SqlParameter("@FurtherInvestigationOrOnwardReferral", !string.IsNullOrEmpty(caseAssessmentDetail.FurtherInvestigationOrOnwardReferral) ? (object)caseAssessmentDetail.FurtherInvestigationOrOnwardReferral : System.DBNull.Value),
            new SqlParameter("@EvidenceOfTreatmentRecommendations", !string.IsNullOrEmpty(caseAssessmentDetail.EvidenceOfTreatmentRecommendations) ? (object)caseAssessmentDetail.EvidenceOfTreatmentRecommendations : System.DBNull.Value),
            new SqlParameter("@TreatmentPeriodTypeID", caseAssessmentDetail.TreatmentPeriodTypeID),
            new SqlParameter("@PatientDateOfReturn", (caseAssessmentDetail.PatientDateOfReturn == null ? DBNull.Value : (object)caseAssessmentDetail.PatientDateOfReturn)),
            new SqlParameter("@PatientRecommendationReturn", (caseAssessmentDetail.PatientRecommendationReturn == null ? DBNull.Value : (object)caseAssessmentDetail.PatientRecommendationReturn)),
            new SqlParameter("@IsPatientReturnToPreInjuryDuties", (object)caseAssessmentDetail.IsPatientReturnToPreInjuryDuties ?? DBNull.Value),
            new SqlParameter("@PatientPreInjuryDutiesDate", caseAssessmentDetail.PatientPreInjuryDutiesDate == null? DBNull.Value : (object)caseAssessmentDetail.PatientPreInjuryDutiesDate),
            new SqlParameter("@MainFactors", caseAssessmentDetail.MainFactors ==null?DBNull.Value : (object)caseAssessmentDetail.MainFactors)
        };
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentDetailRepositoryProcedure.UpdateCaseAssessmentDetailByCaseAssessmentDetailID, param);
        }

        public IEnumerable<CaseAssessmentDetail> GetCaseAssessmentDetailByCaseIDAndAssessmentServiceID(int caseID, int assessmentServiceID)
        {
            SqlParameter AssessmentServiceID = new SqlParameter("@AssessmentServiceID", assessmentServiceID);
            SqlParameter CaseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<CaseAssessmentDetail>(Global.StoredProcedureConst.CaseAssessmentDetailRepositoryProcedure.GetCaseAssessmentDetailByCaseIDAndAssessmentServiceID, CaseID, AssessmentServiceID).ToList();
        }


        public IEnumerable<CaseAssessmentDetail> GetAllCaseAssessmentDetailByCaseID(int caseID)
        {
            SqlParameter CaseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<CaseAssessmentDetail>(Global.StoredProcedureConst.CaseAssessmentDetailRepositoryProcedure.GetCaseAssessmentDetailsByCaseID, CaseID).ToList();
        }

        public CaseAssessmentDetail GetCaseAssessmentDetailByCaseAssessmentDetailID(int caseAssessmentDetailID)
        {
            SqlParameter CaseAssessmentDetailID = new SqlParameter("@CaseAssessmentDetailID", caseAssessmentDetailID);
            return Context.Database.SqlQuery<CaseAssessmentDetail>(Global.StoredProcedureConst.CaseAssessmentDetailRepositoryProcedure.GetCaseAssessmentDetailByCaseAssessmentDetailID, CaseAssessmentDetailID).SingleOrDefault<CaseAssessmentDetail>();
        }

        public ReportModels.CaseAssessmentsDetails GetCaseAssessmentDetailAndValuesByCaseIDAndAssessmentServiceID(int caseID, int assessmentServiceID)
        {
            SqlParameter AssessmentServiceID = new SqlParameter("@AssessmentServiceID", assessmentServiceID);
            SqlParameter CaseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<ReportModels.CaseAssessmentsDetails>(Global.StoredProcedureConst.CaseAssessmentDetailRepositoryProcedure.GetCaseAssessmentDetailAndValuesByCaseIDAndAssessmentServiceID, CaseID, AssessmentServiceID).SingleOrDefault<ReportModels.CaseAssessmentsDetails>();
        }
    }
}