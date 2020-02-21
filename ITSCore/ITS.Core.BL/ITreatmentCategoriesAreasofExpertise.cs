using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment
/*
    * Page Name: ITreatmentCategoriesAreasofExpertise.cs
    * Author : Robin Singh
    * Latest Version : 1.0
    * Reason :- Added Interface ITreatmentCategoriesAreasofExpertise For TreatmentCategoriesAreasofExpertise 
    * Created on 01-30-2013     
*/
#endregion

namespace ITS.Core.BL
{
    public interface ITreatmentCategoriesAreasofExpertise
    {
        IEnumerable<TreatmentCategoriesAreasofExpertise> GetTreatmentCategoriesAreasofExpertiseByTreatmentCategoryID(int treatmentCategoryID);
        IEnumerable<TreatmentCategoriesAreasofExpertise> GetTreatmentCategoriesAreasofExpertiseByAreasofExpertiseID(int areasofExpertiseID);
    }
}
