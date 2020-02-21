using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment
/*
    * Created by : Robin Singh
    * Latest Version : 1.0
    * Reason :- created Interface and Added Method For TreatmentCategoriesAreasofExpertiseRepository    
    * Created on 01-30-2013

*/
#endregion

namespace ITS.Core.Data
{
    public interface ITreatmentCategoriesAreasofExpertiseRepository : IBaseRepository<TreatmentCategoriesAreasofExpertise>
    {
        IEnumerable<TreatmentCategoriesAreasofExpertise> GetTreatmentCategoriesAreasofExpertiseByTreatmentCategoryID(int treatmentCategoryID);
        IEnumerable<TreatmentCategoriesAreasofExpertise> GetTreatmentCategoriesAreasofExpertiseByAreasofExpertiseID(int areasofExpertiseID);
    }
}
