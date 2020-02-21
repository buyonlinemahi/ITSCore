using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{
    /* Author : Vijay Kumar
 * Date : 11-16-2012 
 * Latest Version : 1.1
 Description : Add interface For IReferrerProjectTreatmentAuthorisation
  * 
  Revision History
 Version : 1.0 ,Vijay Kumar, 11-16-2012 
 Description: Add Method For IReferrerProjectTreatmentAuthorisation
     * 
  Revision History
 Version : 1.1 ,Vijay Kumar, 11-16-2012 
 Description: Add Method Get ReferrerProjectTreatmentAuthorisation By ReferrerProjectTreatmentID
*/
    public interface IReferrerProjectTreatmentAuthorisation
    {
        IEnumerable<ReferrerProjectTreatmentAuthorisation> GetAllReferrerProjectTreatmentAuthorisation();
        int AddReferrerProjectTreatmentAuthorisation(ReferrerProjectTreatmentAuthorisation referrerProjectTreatmentAuthorisation);
        int UpdateReferrerProjectTreatmentAuthorisation(ReferrerProjectTreatmentAuthorisation referrerProjectTreatmentAuthorisation);       
        int DeleteReferrerProjectTreatmentAuthorisation(int referrerProjectTreatmentAuthorisationID);
        IEnumerable<ReferrerProjectTreatmentAuthorisation> GetReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentID(int referrerProjectTreatmentID);
    }
}
