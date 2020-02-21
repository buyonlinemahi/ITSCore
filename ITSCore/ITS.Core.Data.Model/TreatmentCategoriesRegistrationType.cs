
/*
Page Name:  TreatmentCategoriesRegistrationType.cs                      
Version:  1.0                                              
Purpose: create TreatmentCategoriesRegistrationType model class                                                      
Revision History:                                        
                                                           
  1.0 – 01/30/2013 Robin Singh, vijay, pardeep

*/

namespace ITS.Core.Data.Model
{
    public class TreatmentCategoriesRegistrationType
    {
        public int TreatmentCategoryRegistrationTypeID { get; set; }
        public int RegistrationTypeID { get; set; }
        public int TreatmentCategoryID { get; set; }
        public string RegistrationTypeName { get; set; }
        public string TreatmentCategoryName { get; set; }

    }
}
