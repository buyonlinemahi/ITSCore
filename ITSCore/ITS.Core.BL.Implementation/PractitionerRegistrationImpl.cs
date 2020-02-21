using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;


namespace ITS.Core.BL.Implementation
{
    public class PractitionerRegistrationImpl : IPractitionerRegistration
    {

       private readonly IPractitionerRegistrationRepository _practitionerRegistrationRepository;


       public PractitionerRegistrationImpl(IPractitionerRegistrationRepository practitionerRegistrationRepository)
        {
            _practitionerRegistrationRepository = practitionerRegistrationRepository;

        }
        

       public int AddPractitionerRegistration(PractitionerRegistration practitionerRegistration)
       {
           return _practitionerRegistrationRepository.GetPractitionerRegistrationExistsByPractitionerTreatmentCategoryIDAndRegistrationTypeID(practitionerRegistration) != null ? -1 : _practitionerRegistrationRepository.AddPractitionerRegistration(practitionerRegistration);

       }

       public int DeletePractitionerRegistrationByPractitionerRegistrationID(int practitionerRegistrationID)
       {
           return _practitionerRegistrationRepository.DeletePractitionerRegistrationByPractitionerRegistrationID(practitionerRegistrationID);
       }

       public PractitionerRegistration GetPractitionerRegistrationByPractitionerRegistrationID(int practitionerRegistrationID)
       {
           return _practitionerRegistrationRepository.GetPractitionerRegistrationByPractitionerRegistrationID(practitionerRegistrationID);
       }

       public IEnumerable<PractitionerRegistration> GetPractitionerRegistrationsByPractitionerID(int PractitionerID)
       {
           return _practitionerRegistrationRepository.GetPractitionerRegistrationsByPractitionerID(PractitionerID);
       }

       public IEnumerable<PractitionerRegistration> GetPractitionerRegistrationsByTreatmentCategoryID(int treatmentCategoryID)
       {
           return _practitionerRegistrationRepository.GetPractitionerRegistrationsByTreatmentCategoryID(treatmentCategoryID);
       }

       public IEnumerable<PractitionerRegistration> GetPractitionerRegistrationsByRegistrationTypeID(int registrationTypeID)
       {
           return _practitionerRegistrationRepository.GetPractitionerRegistrationsByRegistrationTypeID(registrationTypeID);
       }

       public int UpdatePractitionerRegistrationByPractitionerRegistrationID(PractitionerRegistration practitionerRegistration)
       {
           var result = _practitionerRegistrationRepository.GetPractitionerRegistrationExistsByPractitionerTreatmentCategoryIDAndRegistrationTypeID(practitionerRegistration);
           if (result != null)
           {
               if (result.PractitionerRegistrationID == practitionerRegistration.PractitionerRegistrationID)
               {
                   return _practitionerRegistrationRepository.UpdatePractitionerRegistrationByPractitionerRegistrationID(practitionerRegistration);
               }
               else
               {
                   return -1;
               }
           }
           else
           {
               return _practitionerRegistrationRepository.UpdatePractitionerRegistrationByPractitionerRegistrationID(practitionerRegistration);
           }
     
       }
    }
}
