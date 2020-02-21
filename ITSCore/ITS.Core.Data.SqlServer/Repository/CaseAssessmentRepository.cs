using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ReportModels = ITS.Core.Data.Model.Reports;

/*
 * Page Name:  CaseAssessmentRepository.cs
 * Latest Version:  1.0

 * Author         : Manjit Singh
 * Date           : April 30, 2013
 * Latest version : 1.0
 * Descrition     : class added and method to AddCaseAssessment
===================================================================================

*/

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CaseAssessmentRepository : BaseRepository<CaseAssessment, ITSDBContext>, ICaseAssessmentRepository
    {
        public CaseAssessmentRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddCaseAssessment(CaseAssessment caseAssessment)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseAssessment.CaseID);
            SqlParameter _AssessmentServiceID = new SqlParameter("@AssessmentServiceID", caseAssessment.AssessmentServiceID);
            SqlParameter _HasPatientConsentForm = new SqlParameter("@HasPatientConsentForm", (object)caseAssessment.HasPatientConsentForm ?? System.DBNull.Value);
            SqlParameter _IncidentAndDiagnosisDescription = new SqlParameter("@IncidentAndDiagnosisDescription", caseAssessment.IncidentAndDiagnosisDescription);
            SqlParameter _NeuralSymptomDescription = new SqlParameter("@NeuralSymptomDescription", !string.IsNullOrEmpty(caseAssessment.NeuralSymptomDescription) ? (object)caseAssessment.NeuralSymptomDescription : System.DBNull.Value);
            SqlParameter _PreExistingConditionDescription = new SqlParameter("@PreExistingConditionDescription", !string.IsNullOrEmpty(caseAssessment.PreExistingConditionDescription) ? (object)caseAssessment.PreExistingConditionDescription : System.DBNull.Value);
            SqlParameter _IsPatientUndergoingTreatment = new SqlParameter("@IsPatientUndergoingTreatment ", (object)caseAssessment.IsPatientUndergoingTreatment ?? System.DBNull.Value);
            SqlParameter _IsPatientTakingMedication = new SqlParameter("@IsPatientTakingMedication ", (object)caseAssessment.IsPatientTakingMedication ?? System.DBNull.Value);
            SqlParameter _PatientRequiresFurtherInvestigation = new SqlParameter("@PatientRequiresFurtherInvestigation  ", (object)caseAssessment.PatientRequiresFurtherInvestigation ?? System.DBNull.Value);
            SqlParameter _FactorsAffectingTreatmentDescription = new SqlParameter("@FactorsAffectingTreatmentDescription ", !string.IsNullOrEmpty(caseAssessment.FactorsAffectingTreatmentDescription) ? (object)caseAssessment.FactorsAffectingTreatmentDescription : System.DBNull.Value);
            SqlParameter _PatientOccupation = new SqlParameter("@PatientOccupation ", !string.IsNullOrEmpty(caseAssessment.PatientOccupation) ? (object)caseAssessment.PatientOccupation : System.DBNull.Value);
            SqlParameter _PatientRoleID = new SqlParameter("@PatientRoleID", caseAssessment.PatientRoleID);
            SqlParameter _WasPatientWorkingAtTheTimeOfTheAccident = new SqlParameter("@WasPatientWorkingAtTheTimeOfTheAccident", (object)caseAssessment.WasPatientWorkingAtTheTimeOfTheAccident ?? System.DBNull.Value);
            SqlParameter _IsPatientSufferingFinancialLoss = new SqlParameter("@IsPatientSufferingFinancialLoss ", (object)caseAssessment.IsPatientSufferingFinancialLoss ?? System.DBNull.Value);
            SqlParameter _AnticipatedDateOfDischarge = new SqlParameter("@AnticipatedDateOfDischarge", caseAssessment.AnticipatedDateOfDischarge == null ? System.DBNull.Value : (object)caseAssessment.AnticipatedDateOfDischarge);
            SqlParameter _HasPatientHomeExerciseProgramme = new SqlParameter("@HasPatientHomeExerciseProgramme", (object)caseAssessment.HasPatientHomeExerciseProgramme ?? System.DBNull.Value);
            

            SqlParameter _HasPatientPastSymptoms = new SqlParameter("@HasPatientPastSymptoms ", caseAssessment.HasPatientPastSymptoms);
            SqlParameter _AssessmentAuthorisationID = new SqlParameter("@AssessmentAuthorisationID  ", caseAssessment.AssessmentAuthorisationID);
            SqlParameter _AuthorisationDetail = new SqlParameter("@AuthorisationDetail ", !string.IsNullOrEmpty(caseAssessment.AuthorisationDetail) ? (object)caseAssessment.AuthorisationDetail : System.DBNull.Value);
            SqlParameter _IsAccepted = new SqlParameter("@IsAccepted ", caseAssessment.IsAccepted);
            SqlParameter _IsPatientDischarge = new SqlParameter("@IsPatientDischarge ",(object)caseAssessment.IsPatientDischarge ?? System.DBNull.Value);
            SqlParameter _DeniedMessage = new SqlParameter("@DeniedMessage  ", !string.IsNullOrEmpty(caseAssessment.DeniedMessage) ? (object)caseAssessment.DeniedMessage : System.DBNull.Value);
            SqlParameter _HasYellowFlags = new SqlParameter("@HasYellowFlags  ", (object)caseAssessment.HasYellowFlags ?? System.DBNull.Value);
            SqlParameter _HasRedFlags = new SqlParameter("@HasRedFlags  ", (object)caseAssessment.HasRedFlags ?? System.DBNull.Value);            
            SqlParameter _UserID = new SqlParameter("@UserID  ", caseAssessment.UserID);
            SqlParameter _IsSaved = new SqlParameter("@IsSaved  ", caseAssessment.IsSaved);
            SqlParameter _RelevantTestUndertaken = new SqlParameter("@RelevantTestUndertaken", caseAssessment.RelevantTestUndertaken);

            return Context.Database.ExecuteSqlCommand(
                Global.StoredProcedureConst.CaseAssessmentRepositoryProcedure.AddCaseAssessment, _CaseID, _AssessmentServiceID, _HasPatientConsentForm, _IncidentAndDiagnosisDescription, _NeuralSymptomDescription, _PreExistingConditionDescription, _IsPatientUndergoingTreatment, _IsPatientTakingMedication, _PatientRequiresFurtherInvestigation, _FactorsAffectingTreatmentDescription, _PatientOccupation, _PatientRoleID, _WasPatientWorkingAtTheTimeOfTheAccident, _IsPatientSufferingFinancialLoss, _AnticipatedDateOfDischarge, _HasPatientHomeExerciseProgramme, _HasPatientPastSymptoms, _AssessmentAuthorisationID, _AuthorisationDetail, _IsAccepted, _IsPatientDischarge, _DeniedMessage, _HasYellowFlags, _HasRedFlags, _UserID, _IsSaved,
                _RelevantTestUndertaken);
        }

        public int UpdateCaseAssessmentAuthorisationByCaseID(int caseID, int assessmentAuthorisationID, string authorisationDetail)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            SqlParameter _AssessmentAuthorisationID = new SqlParameter("@AssessmentAuthorisationID", assessmentAuthorisationID);
            SqlParameter _AuthorisationDetail = new SqlParameter("@AuthorisationDetail", !string.IsNullOrEmpty(authorisationDetail) ? (object)authorisationDetail : System.DBNull.Value);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentRepositoryProcedure.UpdateCaseAssessmentAuthorisationByCasetID, _CaseID, _AssessmentAuthorisationID, _AuthorisationDetail);
        }

        public int UpdateCaseAssessmentDeniedAuthorisationByCaseID(int caseID, int assessmentAuthorisationID, string deniedAuthorisation)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            SqlParameter _AssessmentAuthorisationID = new SqlParameter("@AssessmentAuthorisationID", assessmentAuthorisationID);
            SqlParameter _DeniedAuthorisation = new SqlParameter("@DeniedAuthorisation", !string.IsNullOrEmpty(deniedAuthorisation) ? (object)deniedAuthorisation : System.DBNull.Value);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentRepositoryProcedure.UpdateCaseAssessmentDeniedAuthorisationByCaseID, _CaseID, _AssessmentAuthorisationID, _DeniedAuthorisation);
        }

        public CaseAssessment GetCaseAssessmentByCaseID(int caseID)
        {
            SqlParameter caseIDParam = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<CaseAssessment>(Global.StoredProcedureConst.CaseAssessmentRepositoryProcedure.GetCaseAssessmentByCaseID, caseIDParam).FirstOrDefault<CaseAssessment>();
        }

        public ReportModels.CaseAssessments GetCaseAssessmentAndValuesByCaseID(int caseID)
        {
            SqlParameter caseIDParam = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<ReportModels.CaseAssessments>(Global.StoredProcedureConst.CaseAssessmentRepositoryProcedure.GetCaseAssessmentAndValuesByCaseID, caseIDParam).SingleOrDefault<ReportModels.CaseAssessments>();
        }


        public int UpdateCaseAssessmentByCaseID(CaseAssessment caseAssessment)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseAssessment.CaseID);
            SqlParameter _AssessmentServiceID = new SqlParameter("@AssessmentServiceID", caseAssessment.AssessmentServiceID);
            SqlParameter _HasPatientConsentForm = new SqlParameter("@HasPatientConsentForm", (object)caseAssessment.HasPatientConsentForm ?? System.DBNull.Value);
            SqlParameter _IncidentAndDiagnosisDescription = new SqlParameter("@IncidentAndDiagnosisDescription", caseAssessment.IncidentAndDiagnosisDescription);
            SqlParameter _NeuralSymptomDescription = new SqlParameter("@NeuralSymptomDescription", !string.IsNullOrEmpty(caseAssessment.NeuralSymptomDescription) ? (object)caseAssessment.NeuralSymptomDescription : System.DBNull.Value);
            SqlParameter _PreExistingConditionDescription = new SqlParameter("@PreExistingConditionDescription", !string.IsNullOrEmpty(caseAssessment.PreExistingConditionDescription) ? (object)caseAssessment.PreExistingConditionDescription : System.DBNull.Value);
            SqlParameter _IsPatientUndergoingTreatment = new SqlParameter("@IsPatientUndergoingTreatment ", (object)caseAssessment.IsPatientUndergoingTreatment ?? System.DBNull.Value);
            SqlParameter _IsPatientTakingMedication = new SqlParameter("@IsPatientTakingMedication ", (object)caseAssessment.IsPatientTakingMedication ?? System.DBNull.Value);
            SqlParameter _PatientRequiresFurtherInvestigation = new SqlParameter("@PatientRequiresFurtherInvestigation  ", (object)caseAssessment.PatientRequiresFurtherInvestigation ?? System.DBNull.Value);
            SqlParameter _FactorsAffectingTreatmentDescription = new SqlParameter("@FactorsAffectingTreatmentDescription", !string.IsNullOrEmpty(caseAssessment.FactorsAffectingTreatmentDescription) ? (object)caseAssessment.FactorsAffectingTreatmentDescription : System.DBNull.Value);
            SqlParameter _PatientOccupation = new SqlParameter("@PatientOccupation ", !string.IsNullOrEmpty(caseAssessment.PatientOccupation) ? (object)caseAssessment.PatientOccupation : System.DBNull.Value);
            SqlParameter _PatientRoleID = new SqlParameter("@PatientRoleID", caseAssessment.PatientRoleID);
            SqlParameter _WasPatientWorkingAtTheTimeOfTheAccident = new SqlParameter("@WasPatientWorkingAtTheTimeOfTheAccident", (object)caseAssessment.WasPatientWorkingAtTheTimeOfTheAccident ?? System.DBNull.Value);
            SqlParameter _IsPatientSufferingFinancialLoss = new SqlParameter("@IsPatientSufferingFinancialLoss ", (object)caseAssessment.IsPatientSufferingFinancialLoss ?? System.DBNull.Value);
            SqlParameter _AnticipatedDateOfDischarge = new SqlParameter("@AnticipatedDateOfDischarge", caseAssessment.AnticipatedDateOfDischarge == null? System.DBNull.Value : (object)caseAssessment.AnticipatedDateOfDischarge);
            
            SqlParameter _HasPatientPastSymptoms = new SqlParameter("@HasPatientPastSymptoms", caseAssessment.HasPatientPastSymptoms);
            SqlParameter _HasPatientHomeExerciseProgramme = new SqlParameter("@HasPatientHomeExerciseProgramme", (object)caseAssessment.HasPatientHomeExerciseProgramme ?? System.DBNull.Value);
            SqlParameter _AssessmentAuthorisationID = new SqlParameter("@AssessmentAuthorisationID", caseAssessment.AssessmentAuthorisationID);
            SqlParameter _AuthorisationDetail = new SqlParameter("@AuthorisationDetail", !string.IsNullOrEmpty(caseAssessment.AuthorisationDetail) ? (object)caseAssessment.AuthorisationDetail : System.DBNull.Value);
            SqlParameter _IsAccepted = new SqlParameter("@IsAccepted", caseAssessment.IsAccepted);
            SqlParameter _IsPatientDischarge = new SqlParameter("@IsPatientDischarge", (object)caseAssessment.IsPatientDischarge ?? System.DBNull.Value);
            SqlParameter _DeniedMessage = new SqlParameter("@DeniedMessage", !string.IsNullOrEmpty(caseAssessment.DeniedMessage) ? (object)caseAssessment.DeniedMessage : System.DBNull.Value);
            SqlParameter _UserID = new SqlParameter("@UserID", caseAssessment.UserID);
            SqlParameter _HasYellowFlags = new SqlParameter("@HasYellowFlags  ", (object)caseAssessment.HasYellowFlags ?? System.DBNull.Value);
            SqlParameter _HasRedFlags = new SqlParameter("@HasRedFlags  ", (object)caseAssessment.HasRedFlags ?? System.DBNull.Value);
            SqlParameter _IsSaved = new SqlParameter("@IsSaved", caseAssessment.IsSaved);
            SqlParameter _RelevantTestUndertaken = new SqlParameter("@RelevantTestUndertaken", caseAssessment.RelevantTestUndertaken);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentRepositoryProcedure.UpdateCaseAssessmentByCaseID, _CaseID, _AssessmentServiceID, _HasPatientConsentForm,
                _IncidentAndDiagnosisDescription, _NeuralSymptomDescription, _PreExistingConditionDescription, _IsPatientUndergoingTreatment, _IsPatientTakingMedication, 
                _PatientRequiresFurtherInvestigation, _FactorsAffectingTreatmentDescription, _PatientOccupation, _PatientRoleID, _WasPatientWorkingAtTheTimeOfTheAccident,
                _IsPatientSufferingFinancialLoss, _AnticipatedDateOfDischarge, _HasPatientHomeExerciseProgramme,  _HasPatientPastSymptoms, _AssessmentAuthorisationID, _AuthorisationDetail,
                _IsAccepted, _IsPatientDischarge, _DeniedMessage, _HasYellowFlags, _HasRedFlags, _UserID, _IsSaved, _RelevantTestUndertaken);
        }


        

        public int UpdateCaseAssessmentHasPatientConsentFormByCaseId(int caseID, bool HasPatientConsentForm)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            SqlParameter _HasPatientConsentForm = new SqlParameter("@HasPatientConsentForm", HasPatientConsentForm);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentRepositoryProcedure.UpdateCaseAssessmentHasPatientConsentFormByCaseId,_CaseID,_HasPatientConsentForm);
        }
        
        public bool GetCaseAssessmentExistsByCaseID(int caseID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            return (bool)Context.Database.SqlQuery<bool>(Global.StoredProcedureConst.CaseAssessmentRepositoryProcedure.GetCaseAssessmentExistsByCaseID, _CaseID).SingleOrDefault();
        }

        public int UpdateAssessmentServiceIDByCaseID(int caseID, int assessmentServiceID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            SqlParameter AssessmentServiceID = new SqlParameter("@AssessmentServiceID", assessmentServiceID);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentRepositoryProcedure.UpdateAssessmentServiceIDByCaseID, _CaseID, AssessmentServiceID);
        }

        public int UpdateIsPatientDischargeByCaseID(int caseID, bool isPatientDischarge)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
            SqlParameter IsPatientDischarge = new SqlParameter("@IsPatientDischarge", isPatientDischarge);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentRepositoryProcedure.UpdateIsPatientDischargeByCaseID, _CaseID, IsPatientDischarge);
        }
        public int AddReferrerCaseAssessmentModification(ReferrerCaseAssessmentModification objReferrerCaseAssessmentModification)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", objReferrerCaseAssessmentModification.CaseID);
            SqlParameter _TreatmentSession = new SqlParameter("@TreatmentSession", objReferrerCaseAssessmentModification.TreatmentSession);
            SqlParameter _AssessmentServiceID = new SqlParameter("@AssessmentServiceID",objReferrerCaseAssessmentModification.AssessmentServiceID);

            return Context.Database.ExecuteSqlCommand(
              Global.StoredProcedureConst.ReferrerCaseAssessmentModificationProcedure.AddReferrerCaseAssessmentModification, _CaseID, _TreatmentSession, _AssessmentServiceID);
 
        }
        public IEnumerable<ReferrerCaseAssessmentModification> GetReferrerCaseAssessmentModificationsbyCaseID(int CaseID)    
        {

            SqlParameter _CaseID = new SqlParameter("@CaseID", CaseID);
            return Context.Database.SqlQuery<ReferrerCaseAssessmentModification>(Global.StoredProcedureConst.ReferrerCaseAssessmentModificationProcedure.GetReferrerCaseAssessmentModificationsbyCaseID, _CaseID);

        }

        public IEnumerable<ReferrerCaseAssessmentModificationAuthority> GetCaseTreatmentPricingByCaseID(int CaseID)    // For Session Which are Approved On not 
        {
            
            SqlParameter _CaseID = new SqlParameter("@CaseID", CaseID);
            return Context.Database.SqlQuery<ReferrerCaseAssessmentModificationAuthority>(Global.StoredProcedureConst.ReferrerCaseAssessmentModificationProcedure.GetCaseTreatmentPricingByCaseID, _CaseID);
            
        }

        public int UpdateCaseAssessmentIsSavedByCaseID(int CaseID)
        {
        SqlParameter _CaseID = new SqlParameter("@CaseID", CaseID);
        return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAssessmentRepositoryProcedure.UpdateCaseAssessmentIsSavedByCaseID, _CaseID);
        }
    }
}