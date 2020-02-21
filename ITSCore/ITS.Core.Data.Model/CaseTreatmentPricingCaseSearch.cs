using System;


namespace ITS.Core.Data.Model
{
    public class CaseTreatmentPricingCaseSearch
    {
        public int CaseTreatmentPricingID { get; set; }
        public int CaseID { get; set; }
        public int ReferrerPricingID { get; set; }
        public decimal ReferrerPrice { get; set; }
        public DateTime? DateOfService { get; set; }
        public bool? PatientDidNotAttend { get; set; }
        public bool? WasAbandoned { get; set; }
        public bool? IsComplete { get; set; }
        public int SupplierPriceID { get; set; }
        public decimal SupplierPrice { get; set; }
        public int? IsChanged { get; set; }
        public string PricingTypeName { get; set; }
    }
}
