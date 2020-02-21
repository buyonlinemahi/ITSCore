
namespace ITS.Core.Data.Model
{
    public class SupplierPricingValue
    {
        public decimal? Price { get; set; }
        public int? PricingID { get; set; }
        public int? SupplierTreatmentID { get; set; }
        public int TreatmentCategoryID { get; set; }
        public string TreatmentCategoryName { get; set; }
        public string PricingTypeName { get; set; }
        public int PricingTypeID { get; set; }

    }
}
