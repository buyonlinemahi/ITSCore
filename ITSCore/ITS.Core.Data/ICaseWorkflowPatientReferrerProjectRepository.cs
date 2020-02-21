using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
namespace ITS.Core.Data
{
	public interface ICaseWorkflowPatientReferrerProjectRepository : IBaseRepository<CaseWorkflowPatientReferrerProject>
	{
        IEnumerable<CaseWorkflowPatientReferrerProject> GetCasesWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryID(int workflowID, int treatmentCategoryID, int skip, int take);
        IEnumerable<CaseWorkflowPatientReferrerProject> GetCaseWorkflowPatientReferrerProjectsByWorkflowID(string workflowID, int skip, int take);
        IEnumerable<CaseWorkflowPatientReferrerProject> GetReferralWorkflowPatientReferrerProjects(int skip, int take);
        IEnumerable<CaseWorkflowPatientReferrerProject> GetReferralWorkflowPatientReferrerProjectsByTreatmentCategoryID(int treatmentCategoryID, int skip, int take);
        int GetCaseReferralWorkflowPatientReferrerProjectsCount();
        int GetCaseReferralWorkflowPatientReferrerProjectsByTreatmentCategoryIDCount(int treatmentCategoryID);

        int GetCaseWorkflowPatientReferrerProjectsByWorkflowIDCount(string workflowIDs);
        int GetCaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryIDCount(int workflowID, int treatmentCategoryID);
	}
}
