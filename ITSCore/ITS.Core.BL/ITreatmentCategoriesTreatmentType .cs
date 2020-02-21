using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment
/*
    * Page Name: ITreatmentCategoriesTreatmentType.cs
    * Author : Robin Singh
    * Latest Version : 1.0
    * Reason :- Interface For TreatmentCategories and TreatmentTypes
    * Created on 01-25-2013     
*/
#endregion

namespace ITS.Core.BL
{
    public interface ITreatmentCategoriesTreatmentType
    {
        IEnumerable<TreatmentCategoriesTreatmentType> GetTreatmentCategoriesTreatmentTypeByTreatmentCategoryID(int treatmentCategoryID);
        IEnumerable<TreatmentCategoriesTreatmentType> GetTreatmentCategoriesTreatmentTypeByTreatmentTypeID(int treatmentTypeID);
    }
}
