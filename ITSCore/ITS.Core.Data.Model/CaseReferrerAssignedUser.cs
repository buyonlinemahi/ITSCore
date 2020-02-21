using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Core.Data.Model
{
    public class CaseReferrerAssignedUser
    {
        public int CaseReferrerAssignedUserID { get; set; }
        public int UserID { get; set; }
        public int CaseID { get; set; }
    }
}
