using System;

namespace ITS.Core.Data.Model
{
    public class CasePatientReferrer
    {
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int ReferrerID { get; set; }
        public string CaseNumber { get; set; }
        public string CaseReferrerReferenceNumber { get; set; }
        public string ReferrerName { get; set; }
        public int CaseID { get; set; }
        public string Address { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

    }
}
