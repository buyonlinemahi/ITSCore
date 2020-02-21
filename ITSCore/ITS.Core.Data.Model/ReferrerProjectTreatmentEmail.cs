
namespace ITS.Core.Data.Model
{
    /*
    Page Name:  ReferrerProjectTreatmentEmail.cs                      
    Version:  1.0                                              
    Purpose: create ReferrerProjectTreatmentEmail model class                                                      
    Revision History:                                        
                                                           
      1.0 – 11/14/2012 Harpreet Singh 

   */
    public class ReferrerProjectTreatmentEmail
    {
        public int ReferrerProjectTreatmentEmailID { get; set; }
        public int ReferrerProjectTreatmentID { get; set; }
        public int EmailTypeID { get; set; }
        public int EmailTypeValueID { get; set; }
    }
}
