using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment

/*
  Page Name:      IPractitioner.cs                    
  Version:  1.0                                              
   Revision History:                               
  1.0– 1/03/2013 Vishal
 * Description : add Interface for IPractitioner
 * UpdatePractitionerByPractitionerID,GetPractitionerByPractitionerID
 ==========================================================
 Updated By : Anuj Batra
 Version:    1.1
 Date:       08-Mar-2013
 Description: Removed the GetPractitionerByTreatmentCatagory and added DeletePractitionerByPractitionerID method.
 */
#endregion

namespace ITS.Core.BL
{
    public interface IPractitioner
    {
        int AddPractitioner(Practitioner practitioner);
        IEnumerable<Practitioner> GetPractitionerLikePractitionerName(string practitionerFirstName);
        int UpdatePractitionerByPractitionerID(Practitioner practitioner);
        Practitioner GetPractitionerByPractitionerID(int practitionerID);
        int DeletePractitionerByPractitionerID(int practitionerID);
        IEnumerable<Practitioner> GetPractitionersRecentlyAdded();
    }
}
