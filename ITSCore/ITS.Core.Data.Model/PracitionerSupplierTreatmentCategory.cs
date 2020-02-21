
namespace ITS.Core.Data.Model
{
    public class PracitionerSupplierTreatmentCategory
    {
        public string PractitionerFirstName { get; set; }
        public string PractitionerLastName { get; set; }
        public int SupplierID { get; set; }
        public int SupplierPractitionerID { get; set; }
        public int PractitionerRegistrationID { get; set; }
        public int PractitionerID { get; set; }
        public int TreatmentCategoryID { get; set; }
    }
}
