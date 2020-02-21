using ITS.Core.BL.Implementation.Base;
using ITS.Core.BL.Implementation.Global;
using ITS.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Core.BL.Implementation.WorkflowEngine
{
    public class TreatmentModificationSendToSupplierWorkflow : Workflow
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
                    EventDescription = GlobalConst.WorkflowEventDescription.PatientInTreatment
                };
            }
        }

        public override int Run()
        {
            return GlobalConst.WorkFlow.PatientInTreatment;
        }
    }
}
