using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using ReportModels = ITS.Core.Data.Model.Reports;

namespace ITS.Core.Data
{
    public interface ICaseAssessmentRepository : IBaseRepository<CaseAssessment>
    {
        int AddCaseAssessment(CaseAssessment caseAssessment);
        int UpdateCaseAssessmentAuthorisationByCaseID(int caseID, int assessmentAuthorisationID, string authorisationDetail);
        CaseAssessment GetCaseAssessmentByCaseID(int caseID);
        int UpdateCaseAssessmentByCaseID(CaseAssessment caseAssessment);
        bool GetCaseAssessmentExistsByCaseID(int caseID);
        int UpdateAssessmentServiceIDByCaseID(int caseID, int assessmentServiceID);
        int UpdateIsPatientDischargeByCaseID(int caseID, bool isPatientDischarge);
        int UpdateCaseAssessmentDeniedAuthorisationByCaseID(int caseID, int assessmentAuthorisationID, string deniedAuthorisation);
        int UpdateCaseAssessmentHasPatientConsentFormByCaseId(int caseID, bool HasPatientConsentForm);
        ReportModels.CaseAssessments GetCaseAssessmentAndValuesByCaseID(int caseID);
        int AddReferrerCaseAssessmentModification(ReferrerCaseAssessmentModification referrerCaseAssessmentModification);
        IEnumerable<ReferrerCaseAssessmentModificationAuthority> GetCaseTreatmentPricingByCaseID(int CaseID);
        IEnumerable<ReferrerCaseAssessmentModification> GetReferrerCaseAssessmentModificationsbyCaseID(int CaseID);
        int UpdateCaseAssessmentIsSavedByCaseID(int CaseID);
    }
}
