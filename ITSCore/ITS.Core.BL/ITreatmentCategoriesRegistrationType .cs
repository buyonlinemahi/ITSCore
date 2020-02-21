using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment
/*
    * Page Name: ITreatmentCategoriesRegistrationType.cs
    * Author : Robin Singh
    * Latest Version : 1.0
    * Reason :- Added Interface ITreatmentCategoriesRegistrationType
    * Created on 01-30-2013     
*/
#endregion

namespace ITS.Core.BL
{
    public interface ITreatmentCategoriesRegistrationType
    {
        IEnumerable<TreatmentCategoriesRegistrationType> GetTreatmentCategoriesRegistrationTypeByTreatmentCategoryID(int treatmentCategoryID);
        IEnumerable<TreatmentCategoriesRegistrationType> GetTreatmentCategoriesRegistrationTypeByRegistrationTypeID(int registrationTypeID);
    }
}
