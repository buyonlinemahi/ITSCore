using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
 *
 * Latest Version : 1.0
 * 
 * Author         : Robin Singh
 * Date           : 25-Jan-2013
 * Version        : 1.0
 * 
 */

namespace ITS.Core.BL.Implementation
{
    public class TreatmentCategoriesTreatmentTypeImpl : ITreatmentCategoriesTreatmentType
    {
        private readonly ITreatmentCategoriesTreatmentTypeRepository _treatmentCategoriesTreatmentTypeRepository;


        public TreatmentCategoriesTreatmentTypeImpl(ITreatmentCategoriesTreatmentTypeRepository treatmentCategoriesTreatmentTypeRepository)
        {
            _treatmentCategoriesTreatmentTypeRepository = treatmentCategoriesTreatmentTypeRepository;
        }

        public IEnumerable<TreatmentCategoriesTreatmentType> GetTreatmentCategoriesTreatmentTypeByTreatmentCategoryID(int treatmentCategoryID)
        {
            return _treatmentCategoriesTreatmentTypeRepository.GetTreatmentCategoriesTreatmentTypeByTreatmentCategoryID(treatmentCategoryID);
        }

        public IEnumerable<TreatmentCategoriesTreatmentType> GetTreatmentCategoriesTreatmentTypeByTreatmentTypeID(int treatmentTypeID)
        {
            return _treatmentCategoriesTreatmentTypeRepository.GetTreatmentCategoriesTreatmentTypeByTreatmentTypeID(treatmentTypeID);
        }
    }
}
