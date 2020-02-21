namespace ITS.Core.Data.Model
{
    /*
 Page Name:  ReferrerProjectTreatmentPricing.cs                      
  Version:  1.0                                              
  Purpose: create ReferrerProjectTreatmentPricing model class                                                      
  Revision History:                                        
                                                           
    1.0 – 11/09/2012 Satya 

 */
    /// <summary>
    /// 
    /// </summary>
    public class ReferrerProjectTreatmentPricing
    {
        public int PricingID { get; set; }
        public int PricingTypeID { get; set; }
        public decimal? Price { get; set; }
        public int ReferrerProjectTreatmentID { get; set; }
        
        
    }
}
