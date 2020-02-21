using ITS.Core.BL.Implementation.Base;
using ITS.Core.BL.Implementation.Global;
using ITS.Core.Data.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace WorkFlowTest
{
    [TestClass]
    public class WorkflowTest
    {
        [TestMethod]
        public void get_next_workflow_after_referrer_submits_referral()
        {
            Case c = new Case { WorkflowID = GlobalConst.WorkFlow.ReferralSubmitted, CaseID = 6 };

            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, null, 0, 0, 0);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.ReferredtoSupplier, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_referral_accepted()
        {
            Case c = new Case { WorkflowID = GlobalConst.WorkFlow.ReferralAccepted, CaseID = 1 };

            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, null, 0, 0, 0);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.ReferredtoSupplier, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_bookia()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.InitialAssessmentBooked, CaseID = 1 };

            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, null, 0, 0, 0);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.InitialAssessmentSubmittedtoInnovate, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_referrer_submits_referral_triage_case()
        {
            Case c = new Case { WorkflowID = GlobalConst.WorkFlow.ReferralSubmitted, CaseID = 6, IsTriage = true };

            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, null, 0, 0, 0);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.ReferreredtoTriageSupplier, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_referred_to_triage_supplier()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.ReferreredtoTriageSupplier, CaseID = 1 };

            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, null, 0, 0, 0);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.TriageAssessmentSubmittedtoInnovate, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_triage_submitted_to_innovate_treatment_required()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.TriageAssessmentSubmittedtoInnovate, CaseID = 1, IsTriage = true, IsTreatmentRequired = true };

            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, null, 0, 0, 0);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.ReferralAccepted, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_triage_submitted_to_innovate_no_treatment_required()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.TriageAssessmentSubmittedtoInnovate, CaseID = 1, IsTriage = true, IsTreatmentRequired = false };

            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, null, 0, 0, 0);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.CaseCompleted, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_initial_assessment_qa_accepted_with_approved_delegated_authority()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.InitialAssessmentSubmittedtoInnovate, CaseID = 1, IsTriage = true, IsTreatmentRequired = false};
            CaseAssessment ca = new CaseAssessment { IsAccepted = true };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, ca, 0, 1000, 100);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.AuthorisationSenttoSupplierOrPatientinTreatment, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_initial_assessment_qa_not_accepted()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.InitialAssessmentSubmittedtoInnovate, CaseID = 1, IsTriage = true, IsTreatmentRequired = false };
            CaseAssessment ca = new CaseAssessment { IsAccepted = false };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, ca, 0, 1000, 100);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.ReportNotAccepted, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_initial_assessment_qa_accepted_with_rejected_delegated_authority()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.InitialAssessmentSubmittedtoInnovate, CaseID = 1, IsTriage = true, IsTreatmentRequired = false };
            CaseAssessment ca = new CaseAssessment { IsAccepted = true };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, ca, 0, 0, 100);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.InitialAssessmentReportSubmittedtoReferrerOrAwaitingAuthorisation, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_initial_assessment_submitted_to_referrer_approved()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.InitialAssessmentReportSubmittedtoReferrerOrAwaitingAuthorisation, CaseID = 1, IsTriage = true, IsTreatmentRequired = false };
            CaseAssessment ca = new CaseAssessment { IsAccepted = true, AssessmentAuthorisationID = GlobalConst.AssessmentAuthorisation.APPROVED };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, ca, 0, 0, 100);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.AuthorisationSenttoInnovate, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_initial_assessment_submitted_to_referrer_denied()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.InitialAssessmentReportSubmittedtoReferrerOrAwaitingAuthorisation, CaseID = 1, IsTriage = true, IsTreatmentRequired = false };
            CaseAssessment ca = new CaseAssessment { IsAccepted = true, AssessmentAuthorisationID = GlobalConst.AssessmentAuthorisation.DENIED };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, ca, 0, 0, 100);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.CaseStopped, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_initial_assessment_authorisation_sent_to_innovate()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.AuthorisationSenttoInnovate, CaseID = 1, IsTriage = true, IsTreatmentRequired = false };
            CaseAssessment ca = new CaseAssessment { IsAccepted = true, AssessmentAuthorisationID = GlobalConst.AssessmentAuthorisation.APPROVED };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, ca, 0, 0, 100);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.AuthorisationSenttoSupplierOrPatientinTreatment, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_authorisation_sent_to_supplier_patient_not_discharged()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.AuthorisationSenttoSupplierOrPatientinTreatment, CaseID = 1, IsTriage = true, IsTreatmentRequired = false };
            CaseAssessment ca = new CaseAssessment { IsAccepted = true, IsPatientDischarge = false };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, ca, 0, 0, 100);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovate, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_review_assessment_submitted_to_innovate_report_accepted()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovate, CaseID = 1, IsTriage = true, IsTreatmentRequired = false };
            CaseAssessment ca = new CaseAssessment { IsAccepted = true };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, ca, 0, 0, 100);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoReferrer, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_review_assessment_submitted_to_innovate_report_not_accepted()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovate, CaseID = 1, IsTriage = true, IsTreatmentRequired = false };
            CaseAssessment ca = new CaseAssessment { IsAccepted = false, IsPatientDischarge = false };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, ca, 0, 0, 100);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.ReviewAssessmentReportNotAccepted, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_review_assessment_submitted_to_referrer_approved()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoReferrer, CaseID = 1, IsTriage = true, IsTreatmentRequired = false };
            CaseAssessment ca = new CaseAssessment { IsAccepted = true, AssessmentAuthorisationID = GlobalConst.AssessmentAuthorisation.APPROVED };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, ca, 0, 0, 100);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.AuthorisationSenttoInnovate, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_review_assessment_qa_submitted_to_innovate_report_accepted_with_approved_delegated_authority()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovate, CaseID = 1, IsTriage = true, IsTreatmentRequired = false };
            CaseAssessment ca = new CaseAssessment { IsAccepted = true, AssessmentAuthorisationID = GlobalConst.AssessmentAuthorisation.APPROVED };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, ca, 0, 1000, 100);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.AuthorisationSenttoSupplierOrPatientinTreatment, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_review_assessment_qa_submitted_to_innovate_report_accepted_with_rejected_delegated_authority()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoInnovate, CaseID = 1, IsTriage = true, IsTreatmentRequired = false };
            CaseAssessment ca = new CaseAssessment { IsAccepted = true, AssessmentAuthorisationID = GlobalConst.AssessmentAuthorisation.APPROVED };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, ca, 0, 10, 100);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoReferrer, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_authorisation_sent_to_supplier_patient_discharged()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.AuthorisationSenttoSupplierOrPatientinTreatment, CaseID = 1, IsTriage = true, IsTreatmentRequired = false };
            CaseAssessment ca = new CaseAssessment { IsPatientDischarge = true };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, ca, 0, 0, 100);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.FinalAssessmentReportSubmittedtoInnovate, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_final_assessment_submitted_to_innovate_report_accepted()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.FinalAssessmentReportSubmittedtoInnovate, CaseID = 1 };
            CaseAssessment ca = new CaseAssessment { IsAccepted = true };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, ca, 0, 0, 100);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.CaseCompleted, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_final_assessment_submitted_to_innovate_report_not_accepted()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.FinalAssessmentReportSubmittedtoInnovate, CaseID = 1, IsTriage = true, IsTreatmentRequired = false };
            CaseAssessment ca = new CaseAssessment { IsAccepted = false };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, ca, 0, 0, 100);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.FinalAssessmentReportNotAccepted, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_final_assessment_submitted_to_referrer()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.FinalAssessmentReportSubmittedtoReferrer, CaseID = 1, IsTriage = true, IsTreatmentRequired = false };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, null, 0, 0, 100);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.CaseCompleted, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_case_stop()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.CaseStopped, CaseID = 395, IsTriage = true, IsTreatmentRequired = false };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, null, 0, 0, 100);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.CaseStoppedSenttoSupplier, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_authorisation_sent_to_innovate_approved()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.AuthorisationSenttoInnovate, CaseID = 1 };
            CaseAssessment ca = new CaseAssessment { AssessmentAuthorisationID = GlobalConst.AssessmentAuthorisation.APPROVED };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, ca, 0, 0, 100);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.AuthorisationSenttoSupplierOrPatientinTreatment, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_authorisation_sent_to_innovate_modified()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.AuthorisationSenttoInnovate, CaseID = 1 };
            CaseAssessment ca = new CaseAssessment { AssessmentAuthorisationID = GlobalConst.AssessmentAuthorisation.MODIFIED };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, ca, 0, 0, 100);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.PatientInTreatment, "incorrect workflow output");
        }

        [TestMethod]
        public void get_next_workflow_after_case_complete()
        {
            Case c = new Case { WorkflowID = ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.CaseCompleted, CaseID = 1 };
            Workflow w = ITS.Core.BL.Implementation.Init.WorkflowInit.InitWorkFlowUpdate(c, null, 0, 0, 0);
            int nextWorkflow = w.Run();
            Assert.IsTrue(nextWorkflow == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.InvoiceSent, "incorrect workflow output");
        }
    }
}
