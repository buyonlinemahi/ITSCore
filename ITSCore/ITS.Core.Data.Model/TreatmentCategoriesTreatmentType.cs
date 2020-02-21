
/*
Page Name:  TreatmentCategoriesTreatmentType.cs                      
Version:  1.0                                              
Purpose: create TreatmentCategoriesTreatmentType model class                                                      
Revision History:                                        
                                                           
  1.0 – 01/25/2013 Robin Singh

*/

namespace ITS.Core.Data.Model
{
    public class TreatmentCategoriesTreatmentType
    {
        public int TreatmentCategoryTreatmentTypeID { get; set; }
        public int TreatmentTypeID { get; set; }
        public int TreatmentCategoryID { get; set; }
        public string TreatmentTypeName { get; set; }
      
    }
}
