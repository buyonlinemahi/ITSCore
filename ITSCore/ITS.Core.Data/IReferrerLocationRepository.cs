using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
/*
  Page Name:  IReferrerLocationRepository.cs                      
  Latest Version:  1.5                                             
  Purpose: Created method to Delete the ReferrerLocation Information.       
 * 
  Revision History:                                        
                                                           
 * 1.0 – 10/30/2012 Satya 

 * 
 * version :  1.1
 * Edited By: Anuj Batra
 * Reason :   Created method to update the ReferrerLocation Information.
 * 
 * version :  1.2
 * Edited By: Robin Singh
 * * Reason :   Created method to Delete the ReferrerLocation Information.
 
  Edited By :   Vishal
  Version  :    1.3
  Description : Added a method to get referrerlocations by referrerid
  ModifiedDate: 10/30/2012 
 * 
  Edited By :   Satya
  Version  :    1.4
  Description : Added a method to add referrer location
  ModifiedDate: 10/30/2012 
 
  Edited By :   Vijay Kumar
  Version  :    1.5
  Description : Added a method to Update ReferrerLocationMainOffice
  ModifiedDate: 11/28/2012 
 */

namespace ITS.Core.Data
{
    /// <summary>
    /// 
    /// </summary>
    public interface IReferrerLocationRepository : IBaseRepository<ReferrerLocation>
    {
        int AddReferrerLocation(ReferrerLocation referrerLocation);
        int UpdateReferrerLocation(ReferrerLocation referrerLocation);
        int DeleteByReferrerLocationID(int referrerLocationID);
        IEnumerable<ReferrerLocation> GetReferrerLocationsByReferrerID(int referrerID);
        ReferrerLocation GetMainReferrerLocationByReferrerID(int referrerID);
        int UpdateReferrerLocationMainOffice(int referrerID, int referrerOfficeLocationID);

    }

}