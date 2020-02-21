using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Linq;

#region Comment

/*
  Page Name:      PractitionerExpertiseImpl.cs                    
  Version:  1.0                                              
   Revision History:                               
  1.0– 1/03/2013 Vishal
 * Description : implement Interface for PractitionerExpertiseImpl

GetPractitionerExpertiseByPractitionerExpertiseID
GetPractitionerExpertiseByPractitionerID
GetPractitionerExpertiseByAreaofExpertiseID
DeletePractitionerExpertiseByPractitionerExpertiseID
UpdatePractitionerExpertiseByPractitionerExpertiseID
 * 
 */
#endregion

namespace ITS.Core.BL.Implementation
{
    public class PractitionerExpertiseImpl : IPractitionerExpertise
    {

        private readonly IPractitionerExpertiseRepository _practitionerExpertiseRepository;


        public PractitionerExpertiseImpl(IPractitionerExpertiseRepository practitionerExpertiseRepository)
        {
            _practitionerExpertiseRepository = practitionerExpertiseRepository;

        }


        public int AddPractitionerExpertise(PractitionerExpertise practitionerExpertise)
        {
            return _practitionerExpertiseRepository.AddPractitionerExpertise(practitionerExpertise);
        }


        public PractitionerExpertise GetPractitionerExpertiseByPractitionerExpertiseID(int practitionerExpertiseID)
        {
            return _practitionerExpertiseRepository.GetPractitionerExpertiseByPractitionerExpertiseID(practitionerExpertiseID);
        }

        public IEnumerable<PractitionerExpertise> GetPractitionerExpertiseByPractitionerID(int practitionerID)
        {
            return _practitionerExpertiseRepository.GetPractitionerExpertiseByPractitionerID(practitionerID);
        }

        public IEnumerable<PractitionerExpertise> GetPractitionerExpertiseByAreaofExpertiseID(int areaofExpertiseID)
        {
            return _practitionerExpertiseRepository.GetPractitionerExpertiseByAreaofExpertiseID(areaofExpertiseID);
        }

        public int DeletePractitionerExpertiseByPractitionerExpertiseID(int practitionerExpertiseID)
        {
            return _practitionerExpertiseRepository.DeletePractitionerExpertiseByPractitionerExpertiseID(practitionerExpertiseID);
        }

        public int DeletePractitionerExpertiseByPractitionerID(int practitionerID)
        {
            return _practitionerExpertiseRepository.DeletePractitionerExpertiseByPractitionerID(practitionerID);
        }

        public void UpdatePractitionerExpertise(IList<PractitionerExpertise> practitionerExpertises)
        {
           
            _practitionerExpertiseRepository.DeletePractitionerExpertiseByPractitionerID(practitionerExpertises.First().PractitionerID);

            foreach (var practitionerExpertise in practitionerExpertises)
            {
                AddPractitionerExpertise(practitionerExpertise);
            }

        }
    }
}
