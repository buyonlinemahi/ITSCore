using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;



namespace ITS.Core.Data
{
    public interface ITreatmentCategoriesPricingTypesRepository : IBaseRepository<TreatmentCategoriesPricingTypes>
    {
        IEnumerable<TreatmentCategoriesPricingTypes> GetPricingTypesByTreatmentCategoryID(int treatmentCategoryID); 
    }
}
