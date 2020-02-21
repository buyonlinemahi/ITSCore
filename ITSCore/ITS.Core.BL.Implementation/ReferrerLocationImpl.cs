using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
 Page Name:  ReferrerLocationImpl.cs                      
 Latest Version:   1.6                                                     
 
 Revision History:  
 * 
  1.0 – 10/30/2012  Anuj Batra
  Purpose:   Create a file for ReferrerLocation interface implementation and Added a method to update the referrer location information. 
 
 * Edited By :   Robin Singh
   Version  :    1.1
   Description : Added a method to Delete the referrer location information.
   ModifiedDate: 10/30/2012

 *Edited By :   Vishal
  Version  :    1.2
  Description : Added a method to get referrerlocations by referrerid name GetReferrerLocationsByReferrerID
  ModifiedDate: 10/30/2012 
 * 
  *Edited By :   Satya
  Version  :    1.3
  Description : Added a method to add referrer location
  ModifiedDate: 10/30/2012
 * 
  *Edited By :   Vijay Kumar
  Version    :    1.4
  Description : Added a method to Update ReferrerLocationMainOffice by  ReferrerID, ReferrerOfficeLocationID
  ModifiedDate: 11/29/2012 
  
 *Edited By :   Anuj Batra
  Version    :  1.5
  Description : Updated the AddReferrerLocation method.
  ModifiedDate: 02/01/2013 
 
 *Edited By :   Manjit Singh
  Version    :  1.6
  Description : Added condition in UpdateReferrerLocation method if IsMainOffice is true
  ModifiedDate: March 5, 2013
 
 */

namespace ITS.Core.BL.Implementation
{
    public class ReferrerLocationImpl : IReferrerLocation
    {
        private readonly IReferrerLocationRepository _referrerLocationRepository;

        public ReferrerLocationImpl(IReferrerLocationRepository referrerLocationRepository)
        {
            _referrerLocationRepository = referrerLocationRepository;
        }


        public IEnumerable<ReferrerLocation> GetReferrerLocationsByReferrerID(int referrerID)
        {
            return _referrerLocationRepository.GetReferrerLocationsByReferrerID(referrerID);
        }

        public ReferrerLocation GetReferrerMainLocation(int referrerID)
        {
            return _referrerLocationRepository.GetMainReferrerLocationByReferrerID(referrerID);
        }

        public int AddReferrerLocation(ReferrerLocation referrerLocation)
        {
           
            int refererrLocationId= _referrerLocationRepository.AddReferrerLocation(referrerLocation);
            if (referrerLocation.IsMainOffice) { _referrerLocationRepository.UpdateReferrerLocationMainOffice(referrerLocation.ReferrerID, refererrLocationId); }
            return refererrLocationId;
        }

        public int UpdateReferrerLocation(ReferrerLocation referrerLocation)
        {
            if (referrerLocation.IsMainOffice) { _referrerLocationRepository.UpdateReferrerLocationMainOffice(referrerLocation.ReferrerID, referrerLocation.ReferrerLocationID); }
            return _referrerLocationRepository.UpdateReferrerLocation(referrerLocation);

        }

        public int DeleteReferrerLocation(int referrerLocationID)
        {
            return _referrerLocationRepository.DeleteByReferrerLocationID(referrerLocationID);

        }
        public int UpdateReferrerLocationMainOffice(int referrerID, int referrerOfficeLocationID)
        {
            return _referrerLocationRepository.UpdateReferrerLocationMainOffice(referrerID, referrerOfficeLocationID);
        }
    }
}
