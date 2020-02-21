using ITS.Core.BL.Implementation.Base;
using ITS.Core.BL.Implementation.Global;
using ITS.Core.BL.Implementation.WorkflowEngine;
using ITS.Core.Data.Model;

namespace ITS.Core.BL.Implementation.Init
{
    public sealed class WorkflowInit
    {
        public static Workflow InitWorkFlowUpdate(Case currentCase, CaseAssessment caseAssessment, int userID, decimal authorizedAmount, decimal treatmentAmount)
        {
            //bool wasUpdated = false;

            switch (currentCase.WorkflowID)
            {
                case GlobalConst.WorkFlow.ReferralSubmitted:
                    if (currentCase.IsTriage)
                        return new RefertoTriageSupplierWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };
                    else
                        return new RefertoSupplierWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.ReferralAccepted:
                    if (currentCase.IsTriage && !currentCase.IsTreatmentRequired)
                        return new RefertoTriageSupplierWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };
                    else
                        return new RefertoSupplierWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.PatientContacted:
                    return new PatientContactedWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.ReferredtoSupplier:
                    return new InitialAssessmentBookWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.ReferreredtoTriageSupplier:
                    return new TriageAssessmentSubmitToInnovateWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.InitialAssessmentBooked:
                    return new InitialAssessmentSubmitToInnovateWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };//new InitialAssessmentAttendedWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.InitialAssessmentBookedCustom:
                    return new InitialAssessmentBookedCustomWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.InitialAssessmentSupplierCustom:
                    return new InitialAssessmentSupplierCustomWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.InitialAssessmentAttended: //marked remove this workflow
                    return new InitialAssessmentSubmitToInnovateWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.TriageAssessmentSubmittedtoInnovate:
                    if (currentCase.IsTreatmentRequired)
                        return new ReferralAcceptWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };
                    else
                        return new CaseCompleteWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };
                
                case GlobalConst.WorkFlow.InitialAssessmentSubmittedtoInnovate:
                    if (caseAssessment.IsAccepted) //if report is accepted
                        return new InitialAssessmentReportSubmitToReferrerWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID, CaseTreatmentAmount = treatmentAmount, DelegatedAuthorizedAmount = authorizedAmount };
                    else if (!caseAssessment.IsAccepted)
                        return new ReportNotAcceptWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };
                    else
                        break;

                case GlobalConst.WorkFlow.InitialAssessmentSubmittedtoInnovateCustom:
                    return new InitialAssessmentBookedCustomWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.ReportNotAccepted:
                    return new InitialAssessmentSubmitToInnovateWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.ReportNotAcceptedCustom:
                    return new ReportNotAcceptedCustomWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.InitialAssessmentReportSubmittedtoReferrerOrAwaitingAuthorisation:
                    if (caseAssessment.AssessmentAuthorisationID == GlobalConst.AssessmentAuthorisation.DENIED)
                        return new CaseStopWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };
                    else
                        return new AuthorisationSendToInnovateWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.InitialAssessmentReportSubmittedtoReferrerOrAwaitingAuthorisationCustom:
                    return new InitialAssessmentReportSubmittedtoReferrerOrAwaitingAuthorisationCustomWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.AuthorisationSenttoInnovate:
                    if (caseAssessment.AssessmentAuthorisationID == GlobalConst.AssessmentAuthorisation.APPROVED)
                    {
                        //return new AuthorisationSendToSupplierWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };
                        return new TreatmentModificationSendToSupplierWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };
                    }
                    else if (caseAssessment.AssessmentAuthorisationID == GlobalConst.AssessmentAuthorisation.MODIFIED)
                        return new TreatmentModificationSendToSupplierWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };
                    else
                        break;

                case GlobalConst.WorkFlow.AuthorisationSenttoInnovateCustom:
                    return new AuthorisationSenttoInnovateCustomWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.PatientInTreatment:
                    return new PatientInTreatmentWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.PatientInTreatmentCustom:
                    return new PatientInTreatmentCustomWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.AuthorisationSenttoSupplierOrPatientinTreatment:
                    if (caseAssessment.IsPatientDischarge ?? false) //if ispatientdischarge is true move to final assessment.
                        return new FinalAssessmentSubmitToInnovateWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };
                    else
                        return new ReviewAssessmentSubmitToInnovateWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.AuthorisationSenttoSupplierOrPatientinTreatmentCustom:
                    return new AuthorisationSenttoSupplierOrPatientinTreatmentCustomWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.ReviewAssessmentAttended:
                    return new ReviewAssessmentAttendedWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovate:
                    if (caseAssessment.IsAccepted)
                        return new ReviewAssessmentReportSubmitToReferrerWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID, CaseTreatmentAmount = treatmentAmount, DelegatedAuthorizedAmount = authorizedAmount };
                    else
                        return new ReportNotAcceptWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID, AssessmentServiceID = GlobalConst.AssessmentService.ReviewAssessment };

                case GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovateCustom:
                    return new ReviewAssessmentReportSubmittedtoInnovateCustomWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.ReviewAssessmentReportNotAccepted:
                    return new ReviewAssessmentSubmitToInnovateWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.ReviewAssessmentReportNotAcceptedCustom:
                    return new ReviewAssessmentReportNotAcceptedCustomWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoReferrer:
                    if (caseAssessment.AssessmentAuthorisationID == GlobalConst.AssessmentAuthorisation.DENIED)
                        return new CaseStopWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };
                    else
                        return new AuthorisationSendToInnovateWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoReferrerCustom:
                    return new ReviewAssessmentReportSubmittedtoReferrerCustomWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.FinalAssessmentReportSubmittedtoInnovate:
                    if (caseAssessment.IsAccepted)
                        return new FinalAssessmentReportSubmitToReferrerWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };
                    else
                        return new ReportNotAcceptWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID, AssessmentServiceID = GlobalConst.AssessmentService.FinalAssessment };

                case GlobalConst.WorkFlow.FinalAssessmentReportSubmittedtoInnovateCustom:
                    return new FinalAssessmentReportSubmittedtoInnovateCustomWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.FinalAssessmentReportNotAccepted:
                    return new FinalAssessmentSubmitToInnovateWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.FinalAssessmentReportSubmittedtoReferrer:
                    return new CaseCompleteWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.CaseStopped:
                    return new CaseStopSendToSupplierWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.CaseStoppedSenttoSupplier:
                    return new CaseCompleteWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.CaseCompleted:
                    return new InvoiceSendWorkflow { CurrentCase = currentCase, CaseAssessment = caseAssessment, UserID = userID };

                case GlobalConst.WorkFlow.InvoiceSent:
                    break;
            }

            return null;
        }
    }
}