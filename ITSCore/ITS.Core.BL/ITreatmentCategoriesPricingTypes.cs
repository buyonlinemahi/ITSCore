using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{
   public interface ITreatmentCategoriesPricingTypes
    {
        IEnumerable<TreatmentCategoriesPricingTypes> GetPricingTypesByTreatmentCategoryID(int treatmentCategoryID); 
    }
}
