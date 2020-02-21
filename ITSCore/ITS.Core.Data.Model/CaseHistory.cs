using System;

namespace ITS.Core.Data.Model
{
    public class CaseHistory
    {
        public int CaseHistoryID { get; set; }
        public int CaseID { get; set; }
        public DateTime EventDate { get; set; }
        public int UserID { get; set; }
        public string EventDescription { get; set; }
        public int EventTypeID { get; set; }
    }    
}
