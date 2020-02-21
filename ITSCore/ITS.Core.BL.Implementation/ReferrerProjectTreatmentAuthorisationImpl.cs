using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;



/*
 *
 * Latest Version : 1.0
 * Author         : Vijay Kumar
 * Date           : 16-Nov-2012
 * Version        : 1.0
 * Created class  : ReferrerProjectTreatmentAuthorizationImpl with a method to GetAll,AddReferrerProjectTreatmentAuthorisation,UpdateReferrerProjectTreatmentAuthorisation;
 * 
 * 
 Revision History
 Version : 1.2 ,Vijay, 11-19-2012 
 Description: Add delete Method for ReferrerProjectTreatmentAuthorisation
 */

namespace ITS.Core.BL.Implementation
{
    public class ReferrerProjectTreatmentAuthorisationImpl : IReferrerProjectTreatmentAuthorisation
    {

        private readonly IReferrerProjectTreatmentAuthorisationRepository _referrerProjectTreatmentAuthorisationRepository;

        public ReferrerProjectTreatmentAuthorisationImpl(IReferrerProjectTreatmentAuthorisationRepository referrerProjectTreatmentAuthorisationRepository)
        {
            _referrerProjectTreatmentAuthorisationRepository = referrerProjectTreatmentAuthorisationRepository;
        }


        public int AddReferrerProjectTreatmentAuthorisation(ReferrerProjectTreatmentAuthorisation referrerProjectTreatmentAuthorisation)
        {
            return _referrerProjectTreatmentAuthorisationRepository.AddReferrerProjectTreatmentAuthorisation(referrerProjectTreatmentAuthorisation);
        }

        public int UpdateReferrerProjectTreatmentAuthorisation(ReferrerProjectTreatmentAuthorisation referrerProjectTreatmentAuthorisation)
        {
            return _referrerProjectTreatmentAuthorisationRepository.UpdateReferrerProjectTreatmentAuthorisation(referrerProjectTreatmentAuthorisation);
        }




        public int DeleteReferrerProjectTreatmentAuthorisation(int referrerProjectTreatmentAuthorisationID)
        {
            return _referrerProjectTreatmentAuthorisationRepository.DeleteReferrerProjectTreatmentAuthorisation(referrerProjectTreatmentAuthorisationID);
        }

        public IEnumerable<ReferrerProjectTreatmentAuthorisation> GetAllReferrerProjectTreatmentAuthorisation()
        {
            return _referrerProjectTreatmentAuthorisationRepository.GetAll();
        }


        public IEnumerable<ReferrerProjectTreatmentAuthorisation> GetReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            return _referrerProjectTreatmentAuthorisationRepository.GetReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentID(referrerProjectTreatmentID);
        }
    }
}
