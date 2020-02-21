
namespace ITS.Core.Data.Model
{
    public class SupplierPractitionerTreatmentRegistration
    {

        public int SupplierPractitionerID { get; set; }
        public string PractitionerFirstName { get; set; }
        public string TreatmentCategoryName { get; set; }
        public string RegistrationNumber { get; set; }
        public string PractitionerLastName { get; set; }
        public int PractitionerID { get; set; }
        public string RegistrationTypeName { get; set; }
        public bool IsActive { get; set; }
        public int PractitionerRegistrationID { get; set; }
        
    }
}
