﻿using ITS.Core.BL.Implementation.Base;
using ITS.Core.BL.Implementation.Global;
using ITS.Core.Data.Model;
using System;

namespace ITS.Core.BL.Implementation.WorkflowEngine
{
    internal class AuthorisationSenttoInnovateCustomWorkflow : Workflow
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
                    EventDescription = GlobalConst.WorkflowEventDescription.AuthorisationSenttoInnovateCustom
                };
            }
        }

        public override int Run()
        {
            return GlobalConst.WorkFlow.AuthorisationSenttoInnovateCustom;
        }
    }
}