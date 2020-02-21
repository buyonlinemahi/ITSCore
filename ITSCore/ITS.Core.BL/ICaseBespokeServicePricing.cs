using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface ICaseBespokeServicePricing
    {
        int AddCaseBespokeServicePricing(IEnumerable<CaseBespokeServicePricing> caseBespokeServicePricings);
        IEnumerable<CaseBespokeServicePricing> GetCaseBespokeServicePricingByCaseID(int caseID);
        int UpdateCaseBespokeServicePricingByCaseBespokeServiceID(CaseBespokeServicePricing caseBespokeServicePricing);
        int DeleteCaseBespokeServiceByCaseBespokeServiceID(int caseBespokeServiceID);
        IEnumerable<CaseBespokeServicePricingType> GetCaseBespokeServicePricingForInvoice(int caseID);

        IEnumerable<CaseBespokeServicePricingType> GetCaseBespokeServicePricingByCaseIDAndComplete(int caseID);
        IEnumerable<CaseBespokeServicePricingType> GetCaseBespokeServicePricingByCaseIDAndInComplete(int caseID);

        int UpdateCaseBespokeReferrerPriceByCaseBespokeServiceID(int caseBespokeServiceID, decimal referrerPrice);
    }
}
