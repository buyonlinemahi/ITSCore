using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
 *
 * Latest Version : 1.0
 * 
 * Author         : Robin Singh
 * Date           : 30-Jan-2013
 * Version        : 1.0
 * 
 */

namespace ITS.Core.BL.Implementation
{
    public class TreatmentCategoriesAreasofExpertiseImpl : ITreatmentCategoriesAreasofExpertise
    {
        private readonly ITreatmentCategoriesAreasofExpertiseRepository _treatmentCategoriesAreasofExpertiseRepository;


        public TreatmentCategoriesAreasofExpertiseImpl(ITreatmentCategoriesAreasofExpertiseRepository treatmentCategoriesAreasofExpertiseRepository)
        {
            _treatmentCategoriesAreasofExpertiseRepository = treatmentCategoriesAreasofExpertiseRepository;
        }


        public IEnumerable<TreatmentCategoriesAreasofExpertise> GetTreatmentCategoriesAreasofExpertiseByTreatmentCategoryID(int treatmentCategoryID)
        {
            return _treatmentCategoriesAreasofExpertiseRepository.GetTreatmentCategoriesAreasofExpertiseByTreatmentCategoryID(treatmentCategoryID);
        }

        public IEnumerable<TreatmentCategoriesAreasofExpertise> GetTreatmentCategoriesAreasofExpertiseByAreasofExpertiseID(int areasofExpertiseID)
        {
            return _treatmentCategoriesAreasofExpertiseRepository.GetTreatmentCategoriesAreasofExpertiseByAreasofExpertiseID(areasofExpertiseID);
        }
    }
}
