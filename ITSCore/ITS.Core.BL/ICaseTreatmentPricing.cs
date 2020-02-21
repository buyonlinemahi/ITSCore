using ITS.Core.Data.Model;
using System;
using System.Collections.Generic;
 

namespace ITS.Core.BL
{
    public interface ICaseTreatmentPricing
    {
        int AddCaseTreatmentPricing(IEnumerable<CaseTreatmentPricing> caseTreatmentPricings);
        IEnumerable<CaseTreatmentPricing> GetCaseTreatmentPricingByCaseID(int caseID);
        IEnumerable<CaseTreatmentPricingType> GetCaseTreatmentPricingByCaseIDAndComplete(int caseID);
        IEnumerable<CaseTreatmentPricingType> GetCaseTreatmentPricingByCaseIDAndInComplete(int caseID);
        int UpdateCaseTreatmentPricingByCaseTreatmentPricingID(CaseTreatmentPricing caseTreatmentPricing);
        IEnumerable<TreatmentReferrerSupplierPricing> GetTreatmentReferrerSupplierPricing(int supplierID, int referrerProjectTreatmentID, int treatmentCategoryID);
        IEnumerable<TreatmentReferrerSupplierPricing> GetTreatmentReferrerSupplierPricingQA(int supplierID, int referrerProjectTreatmentID, int treatmentCategoryID);
        int UpdateCaseTreatmentPricingPriceByCaseTreatmentPricingID(CaseTreatmentPricing caseTreatmentPricing);
        IEnumerable<CaseTreatmentPricingType> GetCaseTreatmentPricingsForInvoice(int caseID);
        int DeleteCaseTreatmentPricingByCaseTreatmentPricingID(int caseTreatmentPricingID);
        int UpdateCaseTreatmentReferrerPriceByCaseTreatmentPricingID(int caseTreatmentPricingID, decimal referrerPrice, int ReferrerPricingID,DateTime DateOfService);
        int GetCheckCaseTreatmentPricingByCaseID(int CaseId, int AssessmentServiceID);
        int UpdateCaseTreatmentPricing(IEnumerable<CaseTreatmentPricing> caseTreatmentPricings);
        IEnumerable<CaseTreatmentPricingType> GetCaseTreatmentPricingByCaseIDCaseSearch(int caseID);
        int AddCaseTreatmentPricingCaseSearch(CaseTreatmentPricing caseTreatmentPricings);
        int UpdateCaseTreatmentPricingPriceByReferrerPricingID(CaseTreatmentPricingCaseSearch caseTreatmentPricings);
        int DeleteCaseTreatmentPricingByCaseIDCaseStopped(int caseID);
        int UpdateCaseTreatmentPricingAuthorisationStatusByCaseID(int caseID);
        EPNATreatmentSession GetEPNATreatmentSessionDetail(int caseID);
        TreatmentSessionByCaseID GetTreatmentSessionByCaseID(int caseID);
    }
}
