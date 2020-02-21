using System;

namespace ITS.Core.Data.Model
{
    public class CasePatient
    {
        public int PatientID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public DateTime InjuryDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int CaseID { get; set; }
        public string CaseNumber { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public DateTime CaseSubmittedDate { get; set; }
    }
}
