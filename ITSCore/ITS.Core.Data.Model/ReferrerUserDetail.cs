﻿using System;

namespace ITS.Core.Data.Model
{
    public class ReferrerUserDetail
    {
        public string UserName { get; set; }
        public int GroupID { get; set; }
        public int UserID { get; set; }
        public string GroupName { get; set; }

        public int ReferrerID { get; set; }
        public string FullName { get; set; }
        public string CaseNumber { get; set; }
        public string CaseReferrerReferenceNumber { get; set; }
        public string WorkflowDefination { get; set; }

    }
}
