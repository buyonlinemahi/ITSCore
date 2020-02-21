namespace ITS.Core.Data.Model
{

    public class ReferrerPricingValue
    {
        public decimal? Price { get; set; }
        public int? PricingID { get; set; }
        public int? ReferrerProjectTreatmentID { get; set; }
        public int TreatmentCategoryID { get; set; }
        public string TreatmentCategoryName { get; set; }
        public string PricingTypeName { get; set; }
        public int PricingTypeID { get; set; }
        
        
    }
}
