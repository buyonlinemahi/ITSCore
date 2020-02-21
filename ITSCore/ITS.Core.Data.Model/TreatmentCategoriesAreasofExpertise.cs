
/*
Page Name:  TreatmentCategoriesAreasofExpertise.cs                      
Version:  1.0                                              
Purpose: create TreatmentCategoriesAreasofExpertise model class                                                      
Revision History:                                        
                                                           
  1.0 – 01/30/2013 Robin Singh, vijay, pardeep

*/

namespace ITS.Core.Data.Model
{
    public class TreatmentCategoriesAreasofExpertise
    {
        public int TreatmentCategoryAreasofExpertiseID { get; set; }
        public int AreasofExpertiseID { get; set; }
        public int TreatmentCategoryID { get; set; }
        public string AreasofExpertiseName { get; set; }
        public string TreatmentCategoryName { get; set; }

    }
}
