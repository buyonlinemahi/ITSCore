using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment

/*
  Page Name:      IPractitionerExpertiseRepository.cs                    
  Version:  1.0                                              
   Revision History:                               
  1.0– 1/03/2013 Vishal
 * Description :  Interface for IPractitionerExpertiseRepository
 * 
GetPractitionerExpertiseByPractitionerExpertiseID
GetPractitionerExpertiseByPractitionerID
GetPractitionerExpertiseByAreaofExpertiseID
DeletePractitionerExpertiseByPractitionerExpertiseID
UpdatePractitionerExpertiseByPractitionerExpertiseID
 * 
 */
#endregion
namespace ITS.Core.Data
{
    public interface IPractitionerExpertiseRepository : IBaseRepository<PractitionerExpertise>
    {
        int AddPractitionerExpertise(PractitionerExpertise practitionerExpertise);
        PractitionerExpertise GetPractitionerExpertiseByPractitionerExpertiseID(int practitionerExpertiseID);
        IEnumerable<PractitionerExpertise> GetPractitionerExpertiseByPractitionerID(int practitionerID);
        IEnumerable<PractitionerExpertise> GetPractitionerExpertiseByAreaofExpertiseID(int areaofExpertiseID);
        int DeletePractitionerExpertiseByPractitionerExpertiseID(int practitionerExpertiseID);
        int DeletePractitionerExpertiseByPractitionerID(int practitionerID);
        int UpdatePractitionerExpertiseByPractitionerExpertiseID(PractitionerExpertise practitionerExpertise);
    }
}
