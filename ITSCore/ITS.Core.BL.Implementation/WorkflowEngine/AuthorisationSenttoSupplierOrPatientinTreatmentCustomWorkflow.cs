using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITS.Core.BL.Implementation.Base;
using ITS.Core.Data.Model;
using ITS.Core.BL.Implementation.Global;

namespace ITS.Core.BL.Implementation.WorkflowEngine
{
    internal class AuthorisationSenttoSupplierOrPatientinTreatmentCustomWorkflow : Workflow
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
                    EventDescription = GlobalConst.WorkflowEventDescription.AuthorisationSenttoSupplierOrPatientinTreatment
                };
            }
        }

        public override int Run()
        {
            return GlobalConst.WorkFlow.AuthorisationSenttoSupplierOrPatientinTreatment;
        }
    }

}
