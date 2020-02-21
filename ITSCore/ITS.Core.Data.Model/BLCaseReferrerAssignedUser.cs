using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Core.Data.Model
{
    public class BLCaseReferrerAssignedUser
    {
        public int CaseReferrerAssignedUserID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
}
