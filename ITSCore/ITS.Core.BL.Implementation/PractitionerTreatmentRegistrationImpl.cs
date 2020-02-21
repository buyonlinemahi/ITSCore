using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class PractitionerTreatmentRegistrationImpl : IPractitionerTreatmentRegistration
    {
        private readonly IPractitionerTreatmentRegistrationRepository _practitionerTreatmentRegistrationRepository;

        public PractitionerTreatmentRegistrationImpl(IPractitionerTreatmentRegistrationRepository practitionerTreatmentRegistrationRepository)
        {
            _practitionerTreatmentRegistrationRepository = practitionerTreatmentRegistrationRepository;
        }


        public IEnumerable<SupplierPractitionerTreatmentRegistration> GetSupplierPractitionerTreatmentRegistrationsBySupplierID(int supplierID)
        {
            return _practitionerTreatmentRegistrationRepository.GetSupplierPractitionerTreatmentRegistrationsBySupplierID(supplierID);
        }


        public IEnumerable<PractitionerTreatmentRegistration> GetPractitionerTreatmentRegistrationsLikeTreatmentCategoryName(string treatmentCategoryName, int skip, int take)
        {
            return _practitionerTreatmentRegistrationRepository.GetPractitionerTreatmentRegistrationsLikeTreatmentCategoryName(treatmentCategoryName, skip, take);
        }



        public int GetPractitionerTreatmentRegistrationsLikeTreatmentCategoryNameCount(string treatmentCategoryName)
        {
            return _practitionerTreatmentRegistrationRepository.GetPractitionerTreatmentRegistrationsLikeTreatmentCategoryNameCount(treatmentCategoryName);
        }


        public IEnumerable<PractitionerTreatmentRegistration> GetPractitionerTreatmentRegistrationsLikePractitionerNameForSupplier(string searchKey)
        {
            return _practitionerTreatmentRegistrationRepository.GetPractitionerTreatmentRegistrationsLikePractitionerNameForSupplier(searchKey);
        }


        public IEnumerable<PractitionerTreatmentRegistration> GetPractitionerTreatmentRegistrationsLikePractitionerName(string practitionerName, int skip, int take)
        {
            return _practitionerTreatmentRegistrationRepository.GetPractitionerTreatmentRegistrationsLikePractitionerName(practitionerName, skip, take);
        }

        public int GetPractitionerTreatmentRegistrationsLikePractitionerNameCount(string practitionerName)
        {
            return _practitionerTreatmentRegistrationRepository.GetPractitionerTreatmentRegistrationsLikePractitionerNameCount(practitionerName);
        }
    }
}
