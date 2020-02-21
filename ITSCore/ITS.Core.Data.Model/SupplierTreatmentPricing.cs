
namespace ITS.Core.Data.Model
{
    public class SupplierTreatmentPricing
    {
        public int PricingID { get; set; }
        public int PricingTypeID { get; set; }
        public decimal? Price { get; set; }
        public int SupplierTreatmentID { get; set; }


    }
}
