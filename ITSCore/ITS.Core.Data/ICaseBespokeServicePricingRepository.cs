using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.Data
{
   public  interface ICaseBespokeServicePricingRepository
    {
       int AddCaseBespokeServicePricing(CaseBespokeServicePricing caseBespokeServicePricing);
        IEnumerable<CaseBespokeServicePricing> GetCaseBespokeServicePricingByCaseID(int caseID);
        int UpdateCaseBespokeServicePricingByCaseBespokeServiceID(CaseBespokeServicePricing caseBespokeServicePricing);
        int DeleteCaseBespokeServiceByCaseBespokeServiceID(int caseBespokeServiceID);
        IEnumerable<CaseBespokeServicePricingType> GetCaseBespokeServicePricingByCaseIDAndIsComplete(int caseID, bool isComplete);
        int UpdateCaseBespokeReferrerPriceByCaseBespokeServiceID(int caseBespokeServiceID, decimal referrerPrice);

    }
}
