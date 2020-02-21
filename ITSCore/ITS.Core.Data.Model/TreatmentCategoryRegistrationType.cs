/*
Page Name:  TreatmentCategoryRegistrationType.cs                      
Version:  1.0                                              
Purpose: create TreatmentCategoryRegistrationType model class                                                      
Revision History:                                        
                                                           
  1.0 – 01/30/2013 Robin Singh, pardeep, vijay

*/

namespace ITS.Core.Data.Model
{
    public class TreatmentCategoryRegistrationType
    {
        public int TreatmentCategoryRegistrationTypeID { get; set; }
        public int RegistrationTypeID { get; set; }
        public int TreatmentCategoryID { get; set; }


    }
}
