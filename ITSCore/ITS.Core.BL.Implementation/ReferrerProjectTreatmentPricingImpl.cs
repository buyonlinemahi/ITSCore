using System.Collections.Generic;
using ITS.Core.Data;
using ITS.Core.Data.Model;

/*

 * Author : Vishal
 * Date : 14-Nov-2012
 * Version : 1.0
  Description : Implement interface For Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentID()
  Description : Implement interface For Add_ReferrerProjectTreatmentPricing()
  Description : Implement interface For Update_ReferrerProjectTreatmentPricingByPricingID()
     *
 ==============================================================================================
  */

namespace ITS.Core.BL.Implementation
{
    public class ReferrerProjectTreatmentPricingImpl : IReferrerProjectTreatmentPricing
    {
        private readonly IReferrerProjectTreatmentPricingRepository _referrerProjectTreatmentPricingRepository;

        public ReferrerProjectTreatmentPricingImpl(IReferrerProjectTreatmentPricingRepository referrerProjectTreatmentPricingRepository)
        {
            _referrerProjectTreatmentPricingRepository = referrerProjectTreatmentPricingRepository;
        }

        public IEnumerable<ReferrerProjectTreatmentPricing> GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            return _referrerProjectTreatmentPricingRepository.GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentID(referrerProjectTreatmentID);
        }

        public int AddReferrerProjectTreatmentPricing(ReferrerProjectTreatmentPricing referrerProjectTreatmentPricing)
        {
            return _referrerProjectTreatmentPricingRepository.AddReferrerProjectTreatmentPricing(referrerProjectTreatmentPricing);
        }

        public int UpdateReferrerProjectTreatmentPricingByPricingID(ReferrerProjectTreatmentPricing referrerProjectTreatmentPricing)
        {
            return _referrerProjectTreatmentPricingRepository.UpdateReferrerProjectTreatmentPricingByPricingID(referrerProjectTreatmentPricing);
        }

        public IEnumerable<ReferrerPricingValue> GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndTreatmentCategoryID(int referrerProjectTreatmentID, int treatmentCategoryID)
        {
            return _referrerProjectTreatmentPricingRepository.GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndTreatmentCategoryID(referrerProjectTreatmentID, treatmentCategoryID);
        }

        public ReferrerProjectTreatmentPricing GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndPricingTypeID(int referrerProjectTreatmentID, int pricingTypeID)
        {
            return _referrerProjectTreatmentPricingRepository.GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndPricingTypeID(referrerProjectTreatmentID, pricingTypeID);
        }
    }
}