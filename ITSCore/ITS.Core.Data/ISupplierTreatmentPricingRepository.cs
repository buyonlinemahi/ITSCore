using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;


namespace ITS.Core.Data
{
    public interface ISupplierTreatmentPricingRepository : IBaseRepository<SupplierTreatmentPricing>
    {
        int AddSupplierTreatmentPricing(SupplierTreatmentPricing supplierTreatmentPricing);
        int UpdateSupplierTreatmentPricingByPricingID(SupplierTreatmentPricing supplierTreatmentPricing);
        IEnumerable<SupplierTreatmentPricing> GetSupplierTreatmentPricingBySupplierTreatmentId(int supplierTreatmentId);
        IEnumerable<SupplierSupplierTreatmentsAndSupplierTreatmenPricing> GetTriageSuppliersTreamentPricingByTreatmentCategoryID(int treatmentCategoryID);
        IEnumerable<SupplierSupplierTreatmentsAndSupplierTreatmenPricing> GetTriageTopSuppliersTreamentPricingByTreatmentCategoryID(int treatmentCategoryID);
        IEnumerable<SupplierTreatmentPricing> GetSupplierTreatmentPricingByTreatmentCategoryIDAndSupplierID(int treatmentCategoryID, int supplierID);
        IEnumerable<SupplierPricingValue> GetSupplierTreatmentPricingBySupplierTreatmentIDAndTreatmentCategoryID(int supplierTreatmentID, int treatmentCategoryID);
        IEnumerable<SupplierPricingValue> GetSupplierTreatmentPricingByTreatmentCategoryIDAndSupplierIDAndPricingTypeID(int supplierID, int treatmentCategoryID, int pricingTypeID);
        IEnumerable<SupplierSupplierTreatmentsAndSupplierTreatmenPricingResult> GetSuppliersTreamentPricingByTreatmentCategoryID(int treatmentCategoryID);
    }
}
