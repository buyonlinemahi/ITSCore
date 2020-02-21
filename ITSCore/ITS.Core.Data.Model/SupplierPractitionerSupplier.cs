
namespace ITS.Core.Data.Model
{
    public class SupplierPractitionerSupplier
    {
        public int SupplierPractitionerID { get; set; }
        public int SupplierID { get; set; }
        public int PractitionerRegistrationID { get; set; }
        public string SupplierName { get; set; }
        public string RegistrationNumber { get; set; }
        public string RegistrationTypeName { get; set; }

    }
}
