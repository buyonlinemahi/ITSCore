using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace ITS.Core.BL.Implementation
{
    public class CaseBespokeServicePricingImpl : ICaseBespokeServicePricing
    {
        private readonly ICaseBespokeServicePricingRepository _caseBespokeServicePricingRepository;
        
        public CaseBespokeServicePricingImpl(ICaseBespokeServicePricingRepository caseBespokeServicePricingRepository)
        {
            _caseBespokeServicePricingRepository = caseBespokeServicePricingRepository;
        }
        
        public int AddCaseBespokeServicePricing( IEnumerable<CaseBespokeServicePricing> caseBespokeServicePricings)
        {
            int id = 0;

            foreach (CaseBespokeServicePricing caseBespokeServicePricing in caseBespokeServicePricings)
            {
                id = _caseBespokeServicePricingRepository.AddCaseBespokeServicePricing(caseBespokeServicePricing);
            }

            return id;

        }

        public IEnumerable<Data.Model.CaseBespokeServicePricing> GetCaseBespokeServicePricingByCaseID(int caseID)
        {
          return  _caseBespokeServicePricingRepository.GetCaseBespokeServicePricingByCaseID(caseID);
        }


        public int UpdateCaseBespokeServicePricingByCaseBespokeServiceID(CaseBespokeServicePricing caseBespokeServicePricing)
        {
            return _caseBespokeServicePricingRepository.UpdateCaseBespokeServicePricingByCaseBespokeServiceID(caseBespokeServicePricing);
        }


        public int DeleteCaseBespokeServiceByCaseBespokeServiceID(int caseBespokeServiceID)
        {
            return _caseBespokeServicePricingRepository.DeleteCaseBespokeServiceByCaseBespokeServiceID(caseBespokeServiceID);
        }


        public IEnumerable<CaseBespokeServicePricingType> GetCaseBespokeServicePricingForInvoice(int caseID)
        {
            return _caseBespokeServicePricingRepository.GetCaseBespokeServicePricingByCaseIDAndIsComplete(caseID, true).Where(bespokeTreatmentPricing => (!bespokeTreatmentPricing.WasAbandoned ?? true));
        }

        public IEnumerable<CaseBespokeServicePricingType> GetCaseBespokeServicePricingByCaseIDAndComplete(int caseID)
        {
            return _caseBespokeServicePricingRepository.GetCaseBespokeServicePricingByCaseIDAndIsComplete(caseID, true);
        }



        public IEnumerable<CaseBespokeServicePricingType> GetCaseBespokeServicePricingByCaseIDAndInComplete(int caseID)
        {
            return _caseBespokeServicePricingRepository.GetCaseBespokeServicePricingByCaseIDAndIsComplete(caseID, false);
        }


        public int UpdateCaseBespokeReferrerPriceByCaseBespokeServiceID(int caseBespokeServiceID, decimal referrerPrice)
        {
            return _caseBespokeServicePricingRepository.UpdateCaseBespokeReferrerPriceByCaseBespokeServiceID(caseBespokeServiceID, referrerPrice);
        }
    }
}
