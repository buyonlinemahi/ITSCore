using ITS.Core.Data.Model;
using System.Collections.Generic;



namespace ITS.Core.BL
{
    public interface IPractitionerRegistration
    {
        int AddPractitionerRegistration(PractitionerRegistration practitionerRegistration);
        int DeletePractitionerRegistrationByPractitionerRegistrationID(int practitionerRegistrationID);
        PractitionerRegistration GetPractitionerRegistrationByPractitionerRegistrationID(int practitionerRegistrationID);
        IEnumerable<PractitionerRegistration> GetPractitionerRegistrationsByPractitionerID(int PractitionerID);
        IEnumerable<PractitionerRegistration> GetPractitionerRegistrationsByTreatmentCategoryID(int treatmentCategoryID);
        IEnumerable<PractitionerRegistration> GetPractitionerRegistrationsByRegistrationTypeID(int registrationTypeID);
        int UpdatePractitionerRegistrationByPractitionerRegistrationID(PractitionerRegistration practitionerRegistration);
    }
}
