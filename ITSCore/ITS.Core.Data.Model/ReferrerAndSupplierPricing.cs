
namespace ITS.Core.Data.Model
{
    public class ReferrerAndSupplierPricing
    {
        public int? ReferrerPricingID { get; set; }
        public decimal? ReferrerPrice { get; set; }
        public int? SupplierPriceID { get; set; }
        public decimal? SupplierPrice { get; set; }
        public int? SupplierID { get; set; }
        public int ReferrerProjectTreatmentID { get; set; }
        public int? PricingTypeID { get; set; }
        public string PricingTypeName { get; set; }
        public int? SupplierTreatmentID { get; set; }
    }
}
