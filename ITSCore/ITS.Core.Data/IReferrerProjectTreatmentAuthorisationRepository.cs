using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
    * Author : Satya
    * Latest Version : 1.1
    * Reason :- Interface For ReferrerProjectTreatmentAuthorisation  
    * Created on 11-10-2012 
 
 Revision History
 Version : 1.0 ,Satya, 11-10-2012 
 Description: Add Interface For ReferrerProjectTreatmentAuthorisation
 * 
 *  Revision History
 Version : 1.1 ,Vijay Kumar, 11-19-2012 
 Description: Add delete Method For ReferrerProjectTreatmentAuthorisation
*/

namespace ITS.Core.Data
{
    public interface IReferrerProjectTreatmentAuthorisationRepository : IBaseRepository<ReferrerProjectTreatmentAuthorisation>
    {
        int AddReferrerProjectTreatmentAuthorisation(ReferrerProjectTreatmentAuthorisation referrerProjectTreatmentAuthorisation);
        int UpdateReferrerProjectTreatmentAuthorisation(ReferrerProjectTreatmentAuthorisation referrerProjectTreatmentAuthorisation);
        int DeleteReferrerProjectTreatmentAuthorisation(int referrerProjectTreatmentAuthorisationID);
        IEnumerable<ReferrerProjectTreatmentAuthorisation> GetReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentID(int referrerProjectTreatmentID);
    }
}
