using System;

namespace ITS.Core.Data.Model
{
   public class PasswordHistory
    {
        public int PasswordHistoryID { get; set; }
        public int UserID { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
