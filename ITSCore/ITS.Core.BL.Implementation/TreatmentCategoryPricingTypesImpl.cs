using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
 *
 * Latest Version : 1.0
 * 
 * Author         : Pardeep Kumar
 * Date           : 15-Nov-2012
 * Version        : 1.0
 * 
 */

namespace ITS.Core.BL.Implementation
{
    public class TreatmentCategoryPricingTypesImpl : ITreatmentCategoryPricingTypes
    {
        private readonly ITreatmentCategoryPricingTypesRepository _treatmentCategoriesPricingTypesRepository;



        public TreatmentCategoryPricingTypesImpl(ITreatmentCategoryPricingTypesRepository treatmentCategoryPricingTypesRepository)
        {
            _treatmentCategoriesPricingTypesRepository = treatmentCategoryPricingTypesRepository;
        }


        public IEnumerable<TreatmentCategoryPricingTypes> GetPricingTypesByTreatmentCategoryID(int treatmentCategoryID)
        {
            return _treatmentCategoriesPricingTypesRepository.GetPricingTypesByTreatmentCategoryID(treatmentCategoryID);
        }
    }
}
