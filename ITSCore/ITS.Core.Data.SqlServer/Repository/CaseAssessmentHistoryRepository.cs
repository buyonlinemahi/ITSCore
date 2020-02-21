using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
   public class CaseAssessmentHistoryRepository : BaseRepository<CaseAssessmentHistory, ITSDBContext>, ICaseAssessmentHistoryRepository
    {
        public CaseAssessmentHistoryRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }
        public int AddCaseAssessmentHistory(CaseAssessment caseAssessment)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseAssessment.CaseID);
            SqlParameter _AssessmentServiceID = new SqlParameter("@AssessmentServiceID", caseAssessment.AssessmentServiceID);
            SqlParameter _HasPatientConsentForm = new SqlParameter("@HasPatientConsentForm", (object)caseAssessment.HasPatientConsentForm ?? System.DBNull.Value);
            SqlParameter _IncidentAndDiagnosisDescription = new SqlParameter("@IncidentAndDiagnosisDescription", caseAssessment.IncidentAndDiagnosisDescription);
            SqlParameter _NeuralSymptomDescription = new SqlParameter("@NeuralSymptomDescription", !string.IsNullOrEmpty(caseAssessment.NeuralSymptomDescription) ? (object)caseAssessment.NeuralSymptomDescription : System.DBNull.Value);
            SqlParameter _PreExistingConditionDescription = new SqlParameter("@PreExistingConditionDescription", !string.IsNullOrEmpty(caseAssessment.PreExistingConditionDescription) ? (object)caseAssessment.PreExistingConditionDescription : System.DBNull.Value);
            SqlParameter _IsPatientUndergoingTreatment = new SqlParameter("@IsPatientUndergoingTreatment", (object)caseAssessment.IsPatientUndergoingTreatment ?? System.DBNull.Value);
            SqlParameter _IsPatientTakingMedication = new SqlParameter("@IsPatientTakingMedication", (object)caseAssessment.IsPatientTakingMedication ?? System.DBNull.Value);
            SqlParameter _PatientRequiresFurtherInvestigation = new SqlParameter("@PatientRequiresFurtherInvestigation", (object)caseAssessment.PatientRequiresFurtherInvestigation ?? System.DBNull.Value);
            SqlParameter _FactorsAffectingTreatmentDescription = new SqlParameter("@FactorsAffectingTreatmentDescription", !string.IsNullOrEmpty(caseAssessment.FactorsAffectingTreatmentDescription) ? (object)caseAssessment.FactorsAffectingTreatmentDescription : System.DBNull.Value);
            SqlParameter _PatientOccupation = new SqlParameter("@PatientOccupation ", !string.IsNullOrEmpty(caseAssessment.PatientOccupation) ? (object)caseAssessment.PatientOccupation : System.DBNull.Value);
            SqlParameter _PatientRoleID = new SqlParameter("@PatientRoleID", caseAssessment.PatientRoleID);
            SqlParameter _WasPatientWorkingAtTheTimeOfTheAccident = new SqlParameter("@WasPatientWorkingAtTheTimeOfTheAccident", (object)caseAssessment.WasPatientWorkingAtTheTimeOfTheAccident ?? System.DBNull.Value);
            SqlParameter _IsPatientSufferingFinancialLoss = new SqlParameter("@IsPatientSufferingFinancialLoss", (object)caseAssessment.IsPatientSufferingFinancialLoss ?? System.DBNull.Value);
            SqlParameter _AnticipatedDateOfDischarge = new SqlParameter("@AnticipatedDateOfDischarge",caseAssessment.AnticipatedDateOfDischarge == null? DBNull.Value : (object)caseAssessment.AnticipatedDateOfDischarge);
            SqlParameter _FinalAssessmentDate = new SqlParameter("@FinalAssessmentDate", SqlDbType.Date);
            SqlParameter _HasPatientPastSymptoms = new SqlParameter("@HasPatientPastSymptoms", caseAssessment.HasPatientPastSymptoms);
            SqlParameter _HasPatientHomeExerciseProgramme = new SqlParameter("@HasPatientHomeExerciseProgramme",(object)caseAssessment.HasPatientHomeExerciseProgramme ?? System.DBNull.Value);
            SqlParameter _AssessmentAuthorisationID = new SqlParameter("@AssessmentAuthorisationID", caseAssessment.AssessmentAuthorisationID);
            SqlParameter _AuthorisationDetail = new SqlParameter("@AuthorisationDetail", !string.IsNullOrEmpty(caseAssessment.AuthorisationDetail) ? (object)caseAssessment.AuthorisationDetail : System.DBNull.Value);
            SqlParameter _IsAccepted = new SqlParameter("@IsAccepted", caseAssessment.IsAccepted);
            SqlParameter _IsPatientDischarge = new SqlParameter("@IsPatientDischarge",(object)caseAssessment.IsPatientDischarge ?? System.DBNull.Value);
            SqlParameter _DeniedMessage = new SqlParameter("@DeniedMessage", !string.IsNullOrEmpty(caseAssessment.DeniedMessage) ? (object)caseAssessment.DeniedMessage : System.DBNull.Value);
            SqlParameter _UserID = new SqlParameter("@UserID", caseAssessment.UserID);
            SqlParameter _HasYellowFlags = new SqlParameter("@HasYellowFlags", (object)caseAssessment.HasYellowFlags ?? System.DBNull.Value);
            SqlParameter _HasRedFlags = new SqlParameter("@HasRedFlags", (object)caseAssessment.HasRedFlags ?? System.DBNull.Value);
            SqlParameter _RelevantTestUndertaken = new SqlParameter("@RelevantTestUndertaken", caseAssessment.RelevantTestUndertaken);



            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.CaseAssessmentHistoryRepositoryProcedure.AddCaseAssessmentHistory, _CaseID,
                _AssessmentServiceID, _HasPatientConsentForm, _IncidentAndDiagnosisDescription, _NeuralSymptomDescription, _PreExistingConditionDescription, 
                _IsPatientUndergoingTreatment, _IsPatientTakingMedication, _PatientRequiresFurtherInvestigation, _FactorsAffectingTreatmentDescription, _PatientOccupation,
                _WasPatientWorkingAtTheTimeOfTheAccident, _IsPatientSufferingFinancialLoss, _AnticipatedDateOfDischarge, _HasPatientHomeExerciseProgramme, 
                _HasPatientPastSymptoms, _AssessmentAuthorisationID, _AuthorisationDetail, _IsAccepted, _IsPatientDischarge, _DeniedMessage, _UserID, _HasYellowFlags,
                _HasRedFlags, _PatientRoleID, _RelevantTestUndertaken).SingleOrDefault();

        }

    }
}
