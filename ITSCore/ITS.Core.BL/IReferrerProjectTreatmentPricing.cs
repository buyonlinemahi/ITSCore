using System.Collections.Generic;
using ITS.Core.Data.Model;

namespace ITS.Core.BL
{/*

 * Author : Vishal
 * Date : 14-Nov-2012
 * Version : 1.0
  Description : Add interface For Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentID()
  Description : Add interface For Add_ReferrerProjectTreatmentPricing()
  Description : Add interface For Update_ReferrerProjectTreatmentPricingByPricingID()
     *
 ==============================================================================================
  */

    public interface IReferrerProjectTreatmentPricing
    {
        IEnumerable<ReferrerProjectTreatmentPricing> GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentID(int referrerProjectTreatmentID);

        int AddReferrerProjectTreatmentPricing(ReferrerProjectTreatmentPricing referrerProjectTreatmentPricing);

        int UpdateReferrerProjectTreatmentPricingByPricingID(ReferrerProjectTreatmentPricing referrerProjectTreatmentPricing);

        IEnumerable<ReferrerPricingValue> GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndTreatmentCategoryID(int referrerProjectTreatmentID, int treatmentCategoryID);

        ReferrerProjectTreatmentPricing GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndPricingTypeID(int referrerProjectTreatmentID, int pricingTypeID);
    }
}