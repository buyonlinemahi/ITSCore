using System;

namespace ITS.Core.Data.Model
{
    public class CaseHistoryUser
    {
        public int CaseHistoryID { get; set; }
        public int CaseID { get; set; }
        public DateTime EventDate { get; set; }
        public int UserID { get; set; }
        public string EventDescription { get; set; }
        public int EventTypeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}
