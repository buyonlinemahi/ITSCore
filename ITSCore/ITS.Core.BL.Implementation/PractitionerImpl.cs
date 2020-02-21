using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
#region Comment

/*
  Page Name:      PractitionerImpl.cs                    
  Version:  1.1
 
   Revision History:                               
  1.0– 1/03/2013 Vishal
 * Description : implement Interface for PractitionerImpl

 UpdatePractitionerByPractitionerID
 GetPractitionerByPractitionerID
 ==========================================================
 Updated By : Anuj Batra
 Version:    1.1
 Date:       08-Mar-2013
 Description: Removed the GetPractitionerByTreatmentCatagory and added DeletePractitionerByPractitionerID method.
 */
#endregion
namespace ITS.Core.BL.Implementation
{
   public class PractitionerImpl : IPractitioner
    {

       private readonly IPractitionerRepository _practitionerRepository;


       public PractitionerImpl(IPractitionerRepository practitionerRepository)
        {
            _practitionerRepository = practitionerRepository;

        }
        

       public int AddPractitioner(Practitioner practitioner)
       {
           return _practitionerRepository.AddPractitioner(practitioner);
       }

       public IEnumerable<Practitioner> GetPractitionerLikePractitionerName(string practitionerName)
       {
           return _practitionerRepository.GetPractitionerLikePractitionerName(practitionerName);
       }

      
       public int UpdatePractitionerByPractitionerID(Practitioner practitioner)
       {
           return _practitionerRepository.UpdatePractitionerByPractitionerID(practitioner);
       }

       public Practitioner GetPractitionerByPractitionerID(int practitionerID)
       {
           return _practitionerRepository.GetPractitionerByPractitionerID(practitionerID);
       }


       public int DeletePractitionerByPractitionerID(int practitionerID)
       {
           return _practitionerRepository.DeletePractitionerByPractitionerID(practitionerID);
       }


       public IEnumerable<Practitioner> GetPractitionersRecentlyAdded()
       {
           return _practitionerRepository.GetPractitionersRecentlyAdded();
       }
    }
}
