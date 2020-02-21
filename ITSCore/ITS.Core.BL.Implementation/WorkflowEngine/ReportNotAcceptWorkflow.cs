using ITS.Core.BL.Implementation.Base;
using ITS.Core.BL.Implementation.Global;
using ITS.Core.Data.Model;
using System;
namespace ITS.Core.BL.Implementation.WorkflowEngine
{
    internal class ReportNotAcceptWorkflow : Workflow
    {
        public int AssessmentServiceID { get; set; }
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
                    EventDescription = string.Format("{0} - {1}",GlobalConst.WorkflowEventDescription.ReportNotAccepted, this.CaseAssessment.DeniedMessage)
                };
            }
        }

        public override int Run()
        {
            if (AssessmentServiceID == GlobalConst.AssessmentService.ReviewAssessment)
                return GlobalConst.WorkFlow.ReviewAssessmentReportNotAccepted;
            else if (AssessmentServiceID == GlobalConst.AssessmentService.FinalAssessment)
                return GlobalConst.WorkFlow.FinalAssessmentReportNotAccepted;

            return GlobalConst.WorkFlow.ReportNotAccepted;
        }
    }
}
