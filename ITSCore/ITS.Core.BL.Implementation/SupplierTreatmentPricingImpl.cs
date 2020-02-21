using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class SupplierTreatmentPricingImpl : ISupplierTreatmentPricing
    {


        private readonly ISupplierTreatmentPricingRepository _supplierTreatmentPricingRepository;

        public SupplierTreatmentPricingImpl(ISupplierTreatmentPricingRepository supplierTreatmentPricingRepository)
        {
            _supplierTreatmentPricingRepository = supplierTreatmentPricingRepository;
        }

        public   int AddSupplierTreatmentPricing(SupplierTreatmentPricing supplierTreatmentPricing)
       {
           return _supplierTreatmentPricingRepository.AddSupplierTreatmentPricing(supplierTreatmentPricing);
       }

       public  int UpdateSupplierTreatmentPricingByPricingID(SupplierTreatmentPricing supplierTreatmentPricing)
       {
           return _supplierTreatmentPricingRepository.UpdateSupplierTreatmentPricingByPricingID(supplierTreatmentPricing);
       }

       public IEnumerable<SupplierTreatmentPricing> GetSupplierTreatmentPricingBySupplierTreatmentId(int supplierTreatmentId)
       {
           return _supplierTreatmentPricingRepository.GetSupplierTreatmentPricingBySupplierTreatmentId(supplierTreatmentId);
       }


       public IEnumerable<SupplierSupplierTreatmentsAndSupplierTreatmenPricing> GetTriageSuppliersTreamentPricingByTreatmentCategoryID(int treatmentCategoryID)
       {
           return _supplierTreatmentPricingRepository.GetTriageSuppliersTreamentPricingByTreatmentCategoryID(treatmentCategoryID);
       }
       public IEnumerable<SupplierSupplierTreatmentsAndSupplierTreatmenPricing> GetTriageTopSuppliersTreamentPricingByTreatmentCategoryID(int treatmentCategoryID)
       {
           return _supplierTreatmentPricingRepository.GetTriageTopSuppliersTreamentPricingByTreatmentCategoryID(treatmentCategoryID);
       }


       
       public IEnumerable<SupplierTreatmentPricing> GetSupplierTreatmentPricingByTreatmentCategoryIDAndSupplierID(int treatmentCategoryID, int supplierID)
       {
           return _supplierTreatmentPricingRepository.GetSupplierTreatmentPricingByTreatmentCategoryIDAndSupplierID(treatmentCategoryID, supplierID);
       }


       public IEnumerable<SupplierPricingValue> GetSupplierTreatmentPricingBySupplierTreatmentIDAndTreatmentCategoryID(int supplierTreatmentID, int treatmentCategoryID)
       {
           return _supplierTreatmentPricingRepository.GetSupplierTreatmentPricingBySupplierTreatmentIDAndTreatmentCategoryID(supplierTreatmentID, treatmentCategoryID);
       }


       public IEnumerable<SupplierPricingValue> GetSupplierTreatmentPricingByTreatmentCategoryIDAndSupplierIDAndPricingTypeID(int supplierID, int treatmentCategoryID, int pricingTypeID)
       {
           return _supplierTreatmentPricingRepository.GetSupplierTreatmentPricingByTreatmentCategoryIDAndSupplierIDAndPricingTypeID(supplierID, treatmentCategoryID, pricingTypeID);
       }


       public IEnumerable<SupplierSupplierTreatmentsAndSupplierTreatmenPricingResult> GetSuppliersTreamentPricingByTreatmentCategoryID(int treatmentCategoryID)
       {
           return _supplierTreatmentPricingRepository.GetSuppliersTreamentPricingByTreatmentCategoryID(treatmentCategoryID);
       }
    }
}
