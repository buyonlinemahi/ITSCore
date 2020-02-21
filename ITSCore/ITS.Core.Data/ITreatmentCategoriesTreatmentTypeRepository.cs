using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment
/*
    * Created by : Robin Singh
    * Latest Version : 1.0
    * Reason :- Interface For TreatmentCategoriesTreatmentType Repository   
    * Created on 01-25-2013

*/
#endregion

namespace ITS.Core.Data
{
    public interface ITreatmentCategoriesTreatmentTypeRepository : IBaseRepository<TreatmentCategoriesTreatmentType>
    {
        IEnumerable<TreatmentCategoriesTreatmentType> GetTreatmentCategoriesTreatmentTypeByTreatmentCategoryID(int treatmentCategoryID);
        IEnumerable<TreatmentCategoriesTreatmentType> GetTreatmentCategoriesTreatmentTypeByTreatmentTypeID(int treatmentTypeID);
              
    }
    
}
