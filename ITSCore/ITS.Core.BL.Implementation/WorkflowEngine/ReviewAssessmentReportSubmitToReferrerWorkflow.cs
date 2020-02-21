using ITS.Core.BL.Implementation.Base;
using ITS.Core.BL.Implementation.Global;
using ITS.Core.Data.Model;
using System;

namespace ITS.Core.BL.Implementation.WorkflowEngine
{
    internal class ReviewAssessmentReportSubmitToReferrerWorkflow : Workflow
    {
        public decimal DelegatedAuthorizedAmount { get; set; }
        public decimal CaseTreatmentAmount { get; set; }
        private string EventDescription { get; set; }

        public override CaseHistory History
        {
            get
            {
                return new CaseHistory
                {
                    CaseID = CurrentCase.CaseID,
                    EventDate = DateTime.Now,
                    EventTypeID = Global.GlobalConst.EventType.WORKFLOW,
                    UserID = UserID,
                    EventDescription = EventDescription
                };
            }
        }

        public override int Run()
        {
            if (DelegatedAuthorizedAmount >= CaseTreatmentAmount)
            {
                EventDescription = GlobalConst.WorkflowEventDescription.AuthorisationSenttoSupplierOrPatientinTreatment;
                return GlobalConst.WorkFlow.AuthorisationSenttoSupplierOrPatientinTreatment;
            }

            EventDescription = GlobalConst.WorkflowEventDescription.ReviewAssessmentReportSubmittedtoReferrer;
            return GlobalConst.WorkFlow.ReviewAssessmentReportSubmittedtoReferrer;
        }
    }
}
