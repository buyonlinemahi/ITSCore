using ITS.Core.BL.Implementation.Base;
using ITS.Core.BL.Implementation.Global;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
namespace ITS.Core.BL.Implementation.Init
{
    public abstract class Engine
    {
        public Engine()
        {
        }

        public static bool RunWorkFlowUpdate(int caseID, int userID, ICaseRepository caseRepository, ICaseHistoryRepository caseHistoryRepository, ICaseAssessmentRepository caseAssessmentRepsository,
            IReferrerProjectTreatmentAuthorisationRepository referrerProjectTreatmentAuthorisationRepository, ICaseTreatmentPricingRepository caseTreatmentPricingRepository)
        {
            bool wasUpdated = false;
            decimal authorizedAmount = 0;
            decimal totalTreatmentAmount = 0;
            Case currentCase = caseRepository.GetCaseByCaseID(caseID);
            CaseAssessment currentCaseAssessment = null;
            ReferrerProjectTreatmentAuthorisation authorisation = referrerProjectTreatmentAuthorisationRepository.GetReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentID(currentCase.ReferrerProjectTreatmentID).Single(auth => auth.Enabled);

            if (IsAssessmentRelatedWorkflow(currentCase.WorkflowID))
                currentCaseAssessment = caseAssessmentRepsository.GetCaseAssessmentByCaseID(currentCase.CaseID);

            if (currentCase.WorkflowID == GlobalConst.WorkFlow.InitialAssessmentSubmittedtoInnovate || currentCase.WorkflowID == GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovate)
            {
                IEnumerable<CaseTreatmentPricing> caseTreatmentPricings = caseTreatmentPricingRepository.GetCaseTreatmentPricingByCaseID(currentCase.CaseID).Where(treatment => !treatment.WasAbandoned.HasValue || (treatment.WasAbandoned.HasValue && !treatment.WasAbandoned.Value));
                if (authorisation.DelegatedAuthorisationTypeID == GlobalConst.DelegatedAuthorisationType.Cost)
                {
                    authorizedAmount = authorisation.Amount.Value;
                    totalTreatmentAmount = caseTreatmentPricings.Sum(price => price.SupplierPrice);
                }
                else
                {
                    authorizedAmount = Convert.ToDecimal(authorisation.Quantity);
                    totalTreatmentAmount = Convert.ToDecimal(caseTreatmentPricings.Count());
                }
            }
            
            wasUpdated = updateWorkFlowStatus(caseRepository, caseHistoryRepository, currentCase, currentCaseAssessment, userID, authorizedAmount, totalTreatmentAmount);
            return wasUpdated;
        }

        private static bool updateWorkFlowStatus(ICaseRepository caseRepository, ICaseHistoryRepository caseHistoryRepository, Case currentCase, CaseAssessment currentCaseAssessment, int userID, decimal authorizedAmount, decimal totalTreatmentAmount)
        {
            Workflow wf = Init.WorkflowInit.InitWorkFlowUpdate(currentCase, currentCaseAssessment, userID, authorizedAmount, totalTreatmentAmount);
            if (wf != null)
            {
                int workflowID = wf.Run();
                caseRepository.UpdateCaseWorkflowByCaseID(currentCase.CaseID, workflowID);
                caseHistoryRepository.AddCaseHistory(wf.History);
                if (workflowID == GlobalConst.WorkFlow.FinalAssessmentReportSubmittedtoReferrer)
                {
                    currentCase = caseRepository.GetCaseByCaseID(currentCase.CaseID);
                    updateWorkFlowStatus(caseRepository, caseHistoryRepository, currentCase, currentCaseAssessment, userID, authorizedAmount, totalTreatmentAmount);
                }
                return true;
            }
            return false;
        }

        public static bool RunWorkFlowUpdateStoppedCase(int caseID, int userID, ICaseRepository caseRepository, ICaseHistoryRepository caseHistoryRepository, ICaseAssessmentRepository caseAssessmentRepsository,
           IReferrerProjectTreatmentAuthorisationRepository referrerProjectTreatmentAuthorisationRepository, ICaseTreatmentPricingRepository caseTreatmentPricingRepository)
        {
            bool wasUpdated = false;
            decimal authorizedAmount = 0;
            decimal totalTreatmentAmount = 0;
            Case currentCase = caseRepository.GetCaseByCaseID(caseID);
            CaseAssessment currentCaseAssessment = null;
            ReferrerProjectTreatmentAuthorisation authorisation = referrerProjectTreatmentAuthorisationRepository.GetReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentID(currentCase.ReferrerProjectTreatmentID).Single(auth => auth.Enabled);

            if (IsAssessmentRelatedWorkflow(currentCase.WorkflowID))
                currentCaseAssessment = caseAssessmentRepsository.GetCaseAssessmentByCaseID(currentCase.CaseID);

            //if (currentCase.WorkflowID == GlobalConst.WorkFlow.InitialAssessmentSubmittedtoInnovate || currentCase.WorkflowID == GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovate || currentCase.WorkflowID == GlobalConst.WorkFlow.InitialAssessmentSubmittedtoInnovateCustom || currentCase.WorkflowID == GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovateCustom)
            //{
                IEnumerable<CaseTreatmentPricing> caseTreatmentPricings = caseTreatmentPricingRepository.GetCaseTreatmentPricingByCaseID(currentCase.CaseID).Where(treatment => !treatment.WasAbandoned.HasValue || (treatment.WasAbandoned.HasValue && !treatment.WasAbandoned.Value));
                if (authorisation.DelegatedAuthorisationTypeID == GlobalConst.DelegatedAuthorisationType.Cost)
                {
                    authorizedAmount = authorisation.Amount.Value;
                    totalTreatmentAmount = caseTreatmentPricings.Sum(price => price.SupplierPrice);
                }
                else
                {
                    authorizedAmount = Convert.ToDecimal(authorisation.Quantity);
                    totalTreatmentAmount = Convert.ToDecimal(caseTreatmentPricings.Count());
                }
            //}

            Workflow wf = Init.WorkflowInit.InitWorkFlowUpdate(currentCase, currentCaseAssessment, userID, authorizedAmount, totalTreatmentAmount);
            if (wf != null)
            {
                int workflowID = wf.Run();
                if(workflowID != 210)
                {
                    caseRepository.UpdateCaseWorkflowByCaseIDStoppedCase(currentCase.CaseID);
                    caseHistoryRepository.AddCaseHistory(wf.History);
                    wasUpdated = true;
                }
            }
            return wasUpdated;
        }

        private static bool IsAssessmentRelatedWorkflow(int workflowID)
        {
            return (workflowID == GlobalConst.WorkFlow.InitialAssessmentSubmittedtoInnovate || workflowID == GlobalConst.WorkFlow.InitialAssessmentReportSubmittedtoReferrerOrAwaitingAuthorisation
                || workflowID == GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovate || workflowID == GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoReferrer
                || workflowID == GlobalConst.WorkFlow.FinalAssessmentReportSubmittedtoInnovate || workflowID == GlobalConst.WorkFlow.FinalAssessmentReportSubmittedtoReferrer || workflowID == GlobalConst.WorkFlow.AuthorisationSenttoSupplierOrPatientinTreatment
                || workflowID == GlobalConst.WorkFlow.AuthorisationSenttoInnovate);
        }

        public static bool UpdateCaseWorkflowCustomByCaseID(int caseID, int userID, int workflowID, ICaseRepository caseRepository)
        {
            int cnt = caseRepository.UpdateCaseWorkflowCustomByCaseID(caseID, userID, workflowID);
            return true;
        }


    }
}
