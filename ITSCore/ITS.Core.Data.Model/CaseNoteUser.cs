using System;

namespace ITS.Core.Data.Model
{
   public class CaseNoteUser
    {
        public int CaseNoteID { get; set; }
        public string Note { get; set; }
        public int CaseID { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string WorkflowDefination { get; set; }
    }
}
