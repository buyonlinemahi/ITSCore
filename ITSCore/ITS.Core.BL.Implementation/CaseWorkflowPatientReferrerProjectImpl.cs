using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Linq;

#region Comment
/*
 Page Name:  CaseWorkflowPatientReferrerProjectImpl.cs                      
 Latest Version:  1.0
 Author : Robin Singh
 
 * Revision History:                                                   
===================================================================================
*/
#endregion
namespace ITS.Core.BL.Implementation
{

    public class CaseWorkflowPatientReferrerProjectImpl : ICaseWorkflowPatientReferrerProject
    {

        private readonly ICaseWorkflowPatientReferrerProjectRepository _caseWorkflowPatientRepository;

        public CaseWorkflowPatientReferrerProjectImpl(ICaseWorkflowPatientReferrerProjectRepository caseWorkflowPatientRepository)
        {
            _caseWorkflowPatientRepository = caseWorkflowPatientRepository;
        }

        public IEnumerable<CaseWorkflowPatientReferrerProject> GetReferralCases(int skip, int take)
        {
            return _caseWorkflowPatientRepository.GetReferralWorkflowPatientReferrerProjects(skip, take);
        }
        public IEnumerable<CaseWorkflowPatientReferrerProject> GetReferralCasesByTreatmentCategoryID(int treatmentCategoryID, int skip, int take)
        {
            return _caseWorkflowPatientRepository.GetReferralWorkflowPatientReferrerProjectsByTreatmentCategoryID(treatmentCategoryID, skip, take);
        }
        public IEnumerable<CaseWorkflowPatientReferrerProject> GetInitialAssessmentQACaseWorkflowPatientProjects(int skip, int take)
        {
            string WorkflowIDs = Global.GlobalConst.WorkFlow.InitialAssessmentSubmittedtoInnovate.ToString() + "," + Global.GlobalConst.WorkFlow.InitialAssessmentSubmittedtoInnovateCustom.ToString();

            return _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectsByWorkflowID(WorkflowIDs, skip, take);
        }
        public IEnumerable<CaseWorkflowPatientReferrerProject> GetInitialAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryID(int treatmentCategoryID, int skip, int take)
        {
            return _caseWorkflowPatientRepository.GetCasesWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryID(Global.GlobalConst.WorkFlow.InitialAssessmentSubmittedtoInnovate, treatmentCategoryID, skip, take);
        }

        public IEnumerable<CaseWorkflowPatientReferrerProject> GetAuthorisationCaseWorkflowPatientProjects(int skip, int take)
        {
            string WorkflowIDs = Global.GlobalConst.WorkFlow.AuthorisationSenttoInnovate.ToString() + "," + Global.GlobalConst.WorkFlow.AuthorisationSenttoInnovateCustom.ToString();

            return _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectsByWorkflowID( WorkflowIDs, skip, take).ToList();

        }

        public IEnumerable<CaseWorkflowPatientReferrerProject> GetAuthorisationCaseWorkflowPatientProjectsByTreatmentCategoryID(int treatmentCategoryID, int skip, int take)
        {
            return _caseWorkflowPatientRepository.GetCasesWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryID(Global.GlobalConst.WorkFlow.AuthorisationSenttoInnovate, treatmentCategoryID, skip, take);
        }

        public IEnumerable<CaseWorkflowPatientReferrerProject> GetReviewAssessmentQACaseWorkflowPatientProjects(int skip, int take)
        {

            string WorkflowIDs = Global.GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovate.ToString() + "," + Global.GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovateCustom.ToString();
            return
            _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectsByWorkflowID(
                    WorkflowIDs, skip, take);
            /*return 
               _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectsByWorkflowID(
                    Global.GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovate, skip, take).Union(_caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectsByWorkflowID(
                    Global.GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovateCustom, skip, take));*/
        }

        public IEnumerable<CaseWorkflowPatientReferrerProject> GetReviewAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryID(int treatmentCategoryID, int skip, int take)
        {
            return _caseWorkflowPatientRepository.GetCasesWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryID(Global.GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovate, treatmentCategoryID, skip, take);
        }



        public IEnumerable<CaseWorkflowPatientReferrerProject> GetCaseStoppedCaseWorkflowPatientProjects(int skip, int take)
        {
            return
                  _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectsByWorkflowID(
                      Global.GlobalConst.WorkFlow.CaseStopped.ToString(), skip, take);

        }



        public IEnumerable<CaseWorkflowPatientReferrerProject> GetCaseCompletedCaseWorkflowPatientProjects(int skip, int take)
        {
            return
                  _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectsByWorkflowID(
                      Global.GlobalConst.WorkFlow.CaseCompleted.ToString(), skip, take);

        }



        public IEnumerable<CaseWorkflowPatientReferrerProject> GetCaseCompletedCaseWorkflowPatientProjectsByTreatmentCategoryID(int treatmentCategoryID, int skip, int take)
        {
            return _caseWorkflowPatientRepository.GetCasesWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryID(Global.GlobalConst.WorkFlow.CaseCompleted, treatmentCategoryID, skip, take);
        }



        public IEnumerable<CaseWorkflowPatientReferrerProject> GetCaseStoppedCaseWorkflowPatientProjectsByTreatmentCategoryID(int treatmentCategoryID, int skip, int take)
        {
            return _caseWorkflowPatientRepository.GetCasesWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryID(Global.GlobalConst.WorkFlow.CaseStopped, treatmentCategoryID, skip, take);
        }

        public IEnumerable<CaseWorkflowPatientReferrerProject> GetFinalAssessmentCaseWorkflowPatientProjects(int skip, int take)
        {
            string WorkflowIDs = Global.GlobalConst.WorkFlow.FinalAssessmentReportSubmittedtoInnovate.ToString() + "," + Global.GlobalConst.WorkFlow.FinalAssessmentReportSubmittedtoInnovateCustom.ToString();
            return _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectsByWorkflowID(WorkflowIDs, skip, take);
        }

        public IEnumerable<CaseWorkflowPatientReferrerProject> GetFinalAssessmentCaseWorkflowPatientProjectsByTreatmentCategoryID(int treatmentCategoryID, int skip, int take)
        {
            return _caseWorkflowPatientRepository.GetCasesWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryID(Global.GlobalConst.WorkFlow.FinalAssessmentReportSubmittedtoInnovate, treatmentCategoryID, skip, take);
        }


        public int GetCaseReferralWorkflowPatientReferrerProjectsCount()
        {
            return _caseWorkflowPatientRepository.GetCaseReferralWorkflowPatientReferrerProjectsCount();
        }

        public int GetCaseReferralWorkflowPatientReferrerProjectsByTreatmentCategoryIDCount(int treatmentCategoryID)
        {
            return _caseWorkflowPatientRepository.GetCaseReferralWorkflowPatientReferrerProjectsByTreatmentCategoryIDCount(treatmentCategoryID);
        }



        public int GetInitialAssessmentQACaseWorkflowPatientProjectsCount()
        {
            string WorkflowIds = Global.GlobalConst.WorkFlow.InitialAssessmentSubmittedtoInnovate.ToString() + "," + Global.GlobalConst.WorkFlow.InitialAssessmentSubmittedtoInnovateCustom.ToString();
            return _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectsByWorkflowIDCount(WorkflowIds);
        }

        public int GetInitialAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryIDCount(int treatmentCategoryID)
        {
            return _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryIDCount(Global.GlobalConst.WorkFlow.InitialAssessmentSubmittedtoInnovate, treatmentCategoryID);
        }

        public int GetAuthorisationCaseWorkflowPatientProjectsCount()
        {
            string WorkflowIds = Global.GlobalConst.WorkFlow.AuthorisationSenttoInnovate.ToString() + "," + Global.GlobalConst.WorkFlow.AuthorisationSenttoInnovateCustom.ToString();
            return _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectsByWorkflowIDCount(WorkflowIds);
        }

        public int GetAuthorisationCaseWorkflowPatientProjectsByTreatmentCategoryIDCount(int treatmentCategoryID)
        {
            return _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryIDCount(Global.GlobalConst.WorkFlow.AuthorisationSenttoInnovate, treatmentCategoryID);
        }

        public int GetReviewAssessmentQACaseWorkflowPatientProjectsCount()
        {
            string WorkflowIds = Global.GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovate.ToString() + "," + Global.GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovateCustom.ToString();
            return _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectsByWorkflowIDCount(WorkflowIds);
        }

        public int GetReviewAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryIDCount(int treatmentCategoryID)
        {
            return _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryIDCount(Global.GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovate, treatmentCategoryID);
        }

        public int GetCaseStoppedCaseWorkflowPatientProjectsCount()
        {

            return _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectsByWorkflowIDCount(Global.GlobalConst.WorkFlow.CaseStopped.ToString());
        }

        public int GetCaseStoppedCaseWorkflowPatientProjectsByTreatmentCategoryIDCount(int treatmentCategoryID)
        {
            return _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryIDCount(Global.GlobalConst.WorkFlow.CaseStopped, treatmentCategoryID);
        }


        public int GetCaseCompletedCaseWorkflowPatientProjectsCount()
        {
            return _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectsByWorkflowIDCount(Global.GlobalConst.WorkFlow.CaseCompleted.ToString());
        }

        public int GetCaseCompletedCaseWorkflowPatientProjectsByTreatmentCategoryIDCount(int treatmentCategoryID)
        {
            return _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryIDCount(Global.GlobalConst.WorkFlow.CaseCompleted, treatmentCategoryID);
        }

        public int GetFinalAssessmentCaseWorkflowPatientProjectsCount()
        {
            string WorkflowIds = Global.GlobalConst.WorkFlow.FinalAssessmentReportSubmittedtoInnovate.ToString() + "," + Global.GlobalConst.WorkFlow.FinalAssessmentReportSubmittedtoInnovateCustom.ToString();
            return _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectsByWorkflowIDCount(WorkflowIds);
        }

        public int GetFinalAssessmentCaseWorkflowPatientProjectsByTreatmentCategoryIDCount(int treatmentCategoryID)
        {
            return _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryIDCount(Global.GlobalConst.WorkFlow.FinalAssessmentReportSubmittedtoInnovate, treatmentCategoryID);
        }


        public IEnumerable<CaseWorkflowPatientReferrerProject> GetTriageAssessmentQACaseWorkflowPatientProjects(int skip, int take)
        {
            return  _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectsByWorkflowID(Global.GlobalConst.WorkFlow.TriageAssessmentSubmittedtoInnovate.ToString(), skip, take);
        }

        public IEnumerable<CaseWorkflowPatientReferrerProject> GetTriageAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryID(int treatmentCategoryID, int skip, int take)
        {
            return _caseWorkflowPatientRepository.GetCasesWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryID
                (Global.GlobalConst.WorkFlow.TriageAssessmentSubmittedtoInnovate, treatmentCategoryID, skip, take);
     
        }

        public int GetTriageAssessmentQACaseWorkflowPatientProjectsCount()
        {
            return _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectsByWorkflowIDCount(Global.GlobalConst.WorkFlow.TriageAssessmentSubmittedtoInnovate.ToString());
        }

        public int GetTriageAssessmentQACaseWorkflowPatientProjectsByTreatmentCategoryIDCount(int treatmentCategoryID)
        {
            return _caseWorkflowPatientRepository.GetCaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryIDCount(Global.GlobalConst.WorkFlow.TriageAssessmentSubmittedtoInnovate, treatmentCategoryID);
        }
    }
}
