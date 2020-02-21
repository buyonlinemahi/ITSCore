using System;

namespace ITS.Core.Data.Model
{
    public class Practitioner
    {
        
        public int PractitionerID { get; set; }
        public string PractitionerFirstName { get; set; }
        public string PractitionerLastName { get; set; }
        public DateTime DateAdded { get; set; }
       
    }
}
