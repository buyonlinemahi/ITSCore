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
    public class TreatmentCategoriesRegistrationTypeImpl : ITreatmentCategoriesRegistrationType
    {
        private readonly ITreatmentCategoriesRegistrationTypeRepository _treatmentCategoriesTreatmentTypeRepository;


        public TreatmentCategoriesRegistrationTypeImpl(ITreatmentCategoriesRegistrationTypeRepository treatmentCategoriesRegistrationTypeRepository)
        {
            _treatmentCategoriesTreatmentTypeRepository = treatmentCategoriesRegistrationTypeRepository;
        }


        public IEnumerable<TreatmentCategoriesRegistrationType> GetTreatmentCategoriesRegistrationTypeByTreatmentCategoryID(int treatmentCategoryID)
        {
            return _treatmentCategoriesTreatmentTypeRepository.GetTreatmentCategoriesRegistrationTypeByTreatmentCategoryID(treatmentCategoryID);
        }

        public IEnumerable<TreatmentCategoriesRegistrationType> GetTreatmentCategoriesRegistrationTypeByRegistrationTypeID(int registrationTypeID)
        {
            return _treatmentCategoriesTreatmentTypeRepository.GetTreatmentCategoriesRegistrationTypeByRegistrationTypeID(registrationTypeID);
        }
    }
}
