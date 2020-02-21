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
    public class TreatmentCategoriesPricingTypesImpl : ITreatmentCategoriesPricingTypes
    {
        private readonly ITreatmentCategoriesPricingTypesRepository _treatmentCategoriesPricingTypesRepository;



        public TreatmentCategoriesPricingTypesImpl(ITreatmentCategoriesPricingTypesRepository treatmentCategoryPricingTypesRepository)
        {
            _treatmentCategoriesPricingTypesRepository = treatmentCategoryPricingTypesRepository;
        }


        public IEnumerable<TreatmentCategoriesPricingTypes> GetPricingTypesByTreatmentCategoryID(int treatmentCategoryID)
        {
            return _treatmentCategoriesPricingTypesRepository.GetPricingTypesByTreatmentCategoryID(treatmentCategoryID);
        }
    }
} 
