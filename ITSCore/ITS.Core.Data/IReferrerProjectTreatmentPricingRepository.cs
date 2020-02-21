using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
/*
  Page Name:  IReferrerProjectTreatmentPricingRepository.cs                      
  Latest Version:  1.1                                              
  Purpose: Create Referrer Project Treatment Pricing Repository  interface                                                      
  Revision History:                                        
                                                           
 * 1.0 – 11/09/2012 Satya 
 * ==============================================================================================
 * Edited By : Vishal
 * Date : 14-Nov-2012
 * Version : 1.1
  Description : Add interface For Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentID()
  Description : Add interface For Add_ReferrerProjectTreatmentPricing()
  Description : Add interface For Update_ReferrerProjectTreatmentPricingByPricingID()
     * 
 ==============================================================================================
 */
namespace ITS.Core.Data
{
    public interface IReferrerProjectTreatmentPricingRepository : IBaseRepository<ReferrerProjectTreatmentPricing>
    {
        IEnumerable<ReferrerProjectTreatmentPricing> GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentID(int referrerProjectTreatmentID);

        int AddReferrerProjectTreatmentPricing(ReferrerProjectTreatmentPricing referrerProjectTreatmentPricing);

        int UpdateReferrerProjectTreatmentPricingByPricingID(ReferrerProjectTreatmentPricing referrerProjectTreatmentPricing);

        IEnumerable<ReferrerPricingValue> GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndTreatmentCategoryID(int referrerProjectTreatmentID, int treatmentCategoryID);

        ReferrerProjectTreatmentPricing GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndPricingTypeID(int referrerProjectTreatmentID, int pricingTypeID);

    }
}

