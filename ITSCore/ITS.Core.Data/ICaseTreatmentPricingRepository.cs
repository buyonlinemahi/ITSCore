using ITS.Core.Data.Model;
using System;
using System.Collections.Generic;

namespace ITS.Core.Data
{
    public interface ICaseTreatmentPricingRepository
    {
        int AddCaseTreatmentPricing(CaseTreatmentPricing caseTreatmentPricing);
        IEnumerable<CaseTreatmentPricing> GetCaseTreatmentPricingByCaseID(int caseID);
        IEnumerable<CaseTreatmentPricingType> GetCaseTreatmentPricingByCaseIDAndIsComplete(int caseID, bool isComplete);
        int UpdateCaseTreatmentPricingByCaseTreatmentPricingID(CaseTreatmentPricing caseTreatmentPricing);
        int UpdateCaseTreatmentPricingPriceByReferrerPricingID(CaseTreatmentPricingCaseSearch caseTreatmentPricing);
        IEnumerable<TreatmentReferrerSupplierPricing> GetReferrerAndSupplierTreatmentPricingBySupplierIDAndTreatmentCategoryIDAndReferrerTreatmentID(int supplierID, int referrerProjectTreatmentID, int treatmentCategoryID);
        TreatmentReferrerSupplierPricing GetReferrerAndSupplierTreatmentPricingBySupplierIDAndTreatmentCategoryIDAndReferrerTreatmentIDAndPricingTypeID(int supplierID, int referrerProjectTreatmentID, int treatmentCategoryID, int pricingTypeID);
        int UpdateCaseTreatmentPricingPriceByCaseTreatmentPricingID(CaseTreatmentPricing caseTreatmentPricing);
        int DeleteCaseTreatmentPricingByCaseTreatmentPricingID(int caseTreatmentPricingID);
        int UpdateCaseTreatmentReferrerPriceByCaseTreatmentPricingID(int caseTreatmentPricingID, decimal referrerPrice, int ReferrerPricingID, DateTime DateOfService);
        IEnumerable<ReferrerAndSupplierPricing> GetReferrerReferrerAndSupplierTreatmentPricingByCaseID(int caseID, int? PricingTypeID);
        int GetCheckCaseTreatmentPricingByCaseID(int caseID,int AssessmentServiceID);
        int UpdateCaseTreatmentPricing(CaseTreatmentPricing caseTreatmentPricing);
        IEnumerable<CaseTreatmentPricingType> GetCaseTreatmentPricingByCaseIDCaseSearch(int caseID);
        int DeleteCaseTreatmentPricingByCaseIDCaseStopped(int caseID);
        int UpdateCaseTreatmentPricingAuthorisationStatusByCaseID(int caseID);
        EPNATreatmentSession GetEPNATreatmentSessionDetail(int caseID);
        TreatmentSessionByCaseID GetTreatmentSessionByCaseID(int caseID);
    }
}
