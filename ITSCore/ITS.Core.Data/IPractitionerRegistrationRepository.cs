using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;


namespace ITS.Core.Data
{
    public interface IPractitionerRegistrationRepository : IBaseRepository<PractitionerRegistration>
    {
        int AddPractitionerRegistration(PractitionerRegistration practitionerRegistration);
        int DeletePractitionerRegistrationByPractitionerRegistrationID(int practitionerRegistrationID);
        PractitionerRegistration GetPractitionerRegistrationByPractitionerRegistrationID(int practitionerRegistrationID);
        IEnumerable<PractitionerRegistration> GetPractitionerRegistrationsByPractitionerID(int PractitionerID);
        IEnumerable<PractitionerRegistration> GetPractitionerRegistrationsByTreatmentCategoryID(int treatmentCategoryID);
        IEnumerable<PractitionerRegistration> GetPractitionerRegistrationsByRegistrationTypeID(int registrationTypeID);
        int UpdatePractitionerRegistrationByPractitionerRegistrationID(PractitionerRegistration practitionerRegistration);
        PractitionerRegistration GetPractitionerRegistrationExistsByPractitionerTreatmentCategoryIDAndRegistrationTypeID(PractitionerRegistration practitionerRegistration);
    }
}
