using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.Data
{
    public interface IPractitionerTreatmentRegistrationRepository : IBaseRepository<PractitionerTreatmentRegistration>
    {
        IEnumerable<SupplierPractitionerTreatmentRegistration> GetSupplierPractitionerTreatmentRegistrationsBySupplierID(int supplierID);
        IEnumerable<PractitionerTreatmentRegistration> GetPractitionerTreatmentRegistrationsLikePractitionerName(string practitionerName, int skip, int take);
        int GetPractitionerTreatmentRegistrationsLikePractitionerNameCount(string practitionerName);
        IEnumerable<PractitionerTreatmentRegistration> GetPractitionerTreatmentRegistrationsLikeTreatmentCategoryName(string treatmentCategoryName, int skip, int take);
        int GetPractitionerTreatmentRegistrationsLikeTreatmentCategoryNameCount(string treatmentCategoryName);
        IEnumerable<PractitionerTreatmentRegistration> GetPractitionerTreatmentRegistrationsLikePractitionerNameForSupplier(string searchKey);
        
    }
}
