using ITS.Core.BL.Implementation.Base;
using ITS.Core.BL.Implementation.Global;
using ITS.Core.Data.Model;
using System;
namespace ITS.Core.BL.Implementation.WorkflowEngine
{
    internal class CaseStopSendToSupplierWorkflow : Workflow
    {
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
                    EventDescription = GlobalConst.WorkflowEventDescription.CaseStoppedSenttoSupplier
                };
            }
        }

        public override int Run()
        {
            return GlobalConst.WorkFlow.CaseStoppedSenttoSupplier;
        }
    }
}
