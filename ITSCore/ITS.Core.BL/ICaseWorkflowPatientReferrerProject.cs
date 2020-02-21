using ITS.Core.Data.Model;

using System.Collections.Generic;

namespace ITS.Core.BL
{


    public interface ICaseWorkflowPatientReferrerProject
    {
        IEnumerable<CaseWorkflowPatientReferrerProject> GetReferralCases(int skip, int take);
        IEnumerable<CaseWorkflowPatientReferrerProject> GetReferralCasesByTreatmentCategoryID(int treatmentCategory, int skip, int take);
        IEnumerable<CaseWorkflowPatientReferrerProject> GetInitialAssessmentQACaseWorkflowPatientProjects(int skip, int take);
        IEnumerable<CaseWorkflowPatientReferrerProject> GetInitialAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryID(int treatmentCategoryID, int skip, int take);
        IEnumerable<CaseWorkflowPatientReferrerProject> GetAuthorisationCaseWorkflowPatientProjects(int skip, int take);
        IEnumerable<CaseWorkflowPatientReferrerProject> GetAuthorisationCaseWorkflowPatientProjectsByTreatmentCategoryID(int treatmentCategoryID, int skip, int take);
        IEnumerable<CaseWorkflowPatientReferrerProject> GetReviewAssessmentQACaseWorkflowPatientProjects(int skip, int take);
        IEnumerable<CaseWorkflowPatientReferrerProject> GetReviewAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryID(int treatmentCategoryID, int skip, int take);

        IEnumerable<CaseWorkflowPatientReferrerProject> GetCaseStoppedCaseWorkflowPatientProjects(int skip, int take);
        IEnumerable<CaseWorkflowPatientReferrerProject> GetCaseStoppedCaseWorkflowPatientProjectsByTreatmentCategoryID(int treatmentCategoryID, int skip, int take);
        IEnumerable<CaseWorkflowPatientReferrerProject> GetFinalAssessmentCaseWorkflowPatientProjects(int skip, int take);
        IEnumerable<CaseWorkflowPatientReferrerProject> GetFinalAssessmentCaseWorkflowPatientProjectsByTreatmentCategoryID(int treatmentCategoryID, int skip, int take);

        IEnumerable<CaseWorkflowPatientReferrerProject> GetTriageAssessmentQACaseWorkflowPatientProjects(int skip, int take);
        IEnumerable<CaseWorkflowPatientReferrerProject> GetTriageAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryID(int treatmentCategoryID, int skip, int take);

        int GetCaseReferralWorkflowPatientReferrerProjectsCount();
        int GetCaseReferralWorkflowPatientReferrerProjectsByTreatmentCategoryIDCount(int treatmentCategoryID);

        int GetInitialAssessmentQACaseWorkflowPatientProjectsCount();
        int GetInitialAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryIDCount(int treatmentCategoryID);
        int GetAuthorisationCaseWorkflowPatientProjectsCount();
        int GetAuthorisationCaseWorkflowPatientProjectsByTreatmentCategoryIDCount(int treatmentCategoryID);
        int GetReviewAssessmentQACaseWorkflowPatientProjectsCount();
        int GetReviewAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryIDCount(int treatmentCategoryID);

        int GetCaseStoppedCaseWorkflowPatientProjectsCount();
        int GetCaseStoppedCaseWorkflowPatientProjectsByTreatmentCategoryIDCount(int treatmentCategoryID);
        int GetFinalAssessmentCaseWorkflowPatientProjectsCount();
        int GetFinalAssessmentCaseWorkflowPatientProjectsByTreatmentCategoryIDCount(int treatmentCategoryID);

        int GetTriageAssessmentQACaseWorkflowPatientProjectsCount();
        int GetTriageAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryIDCount(int treatmentCategoryID);

        IEnumerable<CaseWorkflowPatientReferrerProject> GetCaseCompletedCaseWorkflowPatientProjects(int skip, int take);
        IEnumerable<CaseWorkflowPatientReferrerProject> GetCaseCompletedCaseWorkflowPatientProjectsByTreatmentCategoryID(int treatmentCategoryID, int skip, int take);
        int GetCaseCompletedCaseWorkflowPatientProjectsByTreatmentCategoryIDCount(int treatmentCategoryID);
        int GetCaseCompletedCaseWorkflowPatientProjectsCount();
    }
}
