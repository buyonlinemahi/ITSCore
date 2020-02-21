using System;

namespace ITS.Core.Data.Model
{
    public class PractitionerRegistration
    {
        public int PractitionerRegistrationID { get; set; }
        public int PractitionerID { get; set; }
        public int TreatmentCategoryID { get; set; }
        public int? RegistrationTypeID { get; set; }
        public string RegistrationNumber { get; set; }
        public string Qualification { get; set; }
        public DateTime QualificationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int YearsQualified { get; set; }
        public bool IsActive { get; set; }

    }
}
