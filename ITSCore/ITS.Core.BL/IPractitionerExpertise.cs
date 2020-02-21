using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment

/*
  Page Name:      IPractitionerExpertise.cs                    
  Version:  1.0                                              
   Revision History:                               
  1.0– 1/03/2013 Vishal

 * Description : add Interface for IPractitioner
 GetPractitionerExpertiseByPractitionerExpertiseID
GetPractitionerExpertiseByPractitionerID
GetPractitionerExpertiseByAreaofExpertiseID
DeletePractitionerExpertiseByPractitionerExpertiseID
UpdatePractitionerExpertiseByPractitionerExpertiseID
 */
#endregion

namespace ITS.Core.BL
{
    public interface IPractitionerExpertise
    {
        int AddPractitionerExpertise(PractitionerExpertise practitionerExpertise);

        PractitionerExpertise GetPractitionerExpertiseByPractitionerExpertiseID(int practitionerExpertiseID);

        IEnumerable<PractitionerExpertise> GetPractitionerExpertiseByPractitionerID(int practitionerID);

        IEnumerable<PractitionerExpertise> GetPractitionerExpertiseByAreaofExpertiseID(int areaofExpertiseID);

        int DeletePractitionerExpertiseByPractitionerExpertiseID(int practitionerExpertiseID);

        int DeletePractitionerExpertiseByPractitionerID(int practitionerID);

        void UpdatePractitionerExpertise(IList<PractitionerExpertise> practitionerExpertises);
    }
}
