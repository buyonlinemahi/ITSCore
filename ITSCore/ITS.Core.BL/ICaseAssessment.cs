using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment
/*
 Page Name:  ICaseAssessment.cs                     
 Latest Version:  1.0
 Author : Manjit Singh
======================
*/
#endregion
namespace ITS.Core.BL
{
    public interface ICaseAssessment
    {
        int AddCaseAssessment(ITS.Core.BL.Model.CaseAssessment caseAssessment);
        int UpdateCaseAssessmentAuthorisationToModifiedByCaseID(int caseID, string authorisationDetail);
        int UpdateCaseAssessmentAuthorisationToApprovedByCaseID(int caseID);
        int UpdateCaseAssessmentAuthorisationToDeniedByCaseID(int caseID, string deniedAuthorisation);
        ITS.Core.BL.Model.CaseAssessment GetCaseAssessment(int caseID);
        ITS.Core.BL.Model.CaseAssessment GetCaseAssessmentQA(int caseID);
        int UpdateCaseAssessmentByCaseID(ITS.Core.BL.Model.CaseAssessment caseAssessment);
        ITS.Core.BL.Model.CaseAssessment GetCaseAssessment(int caseID, int caseAssessmentDetailID);
        int UpdateCaseAssessmentHasPatientConsentFormByCaseId(int caseID, bool HasPatientConsentForm);
        ReportsGenerateModels GetAllDataReportGenerated(int CaseID, string ReportType, int CaseAssessmentDetailID, int AssessmentServiceID);
        int AddReferrerCaseAssessmentModification(ReferrerCaseAssessmentModification referrerCaseAssessmentModification);
        IEnumerable<ReferrerCaseAssessmentModificationAuthority>GetCaseTreatmentPricingByCaseID(int CaseID);
        IEnumerable<ReferrerCaseAssessmentModification> GetReferrerCaseAssessmentModificationsbyCaseID(int CaseID);
        int UpdateCaseAssessmentIsSavedByCaseID(int CaseID);
    }
}
