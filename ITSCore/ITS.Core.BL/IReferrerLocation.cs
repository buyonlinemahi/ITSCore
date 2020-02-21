using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
 Page Name:  IReferrerLocation.cs
 Latest Version:  1.4
 Purpose: Added a method to Delete the referrer location information
 
 * Revision History:
 * 
  1.0 – 10/30/2012  Anuj Batra
  Purpose:  Create a file for ReferrerLocation interface and Added a method to update the referrer location information.   
 
 * 
  Edited By :   Robin Singh
  Version  :    1.1
  Description : Added a method to Delete the referrer location information
  ModifiedDate: 10/30/2012
 
 * 
  Edited By :   Vishal
  Version  :    1.2
  Description : Added a method to get referrerlocations by referrerid
  ModifiedDate: 10/30/2012 
 * 
   Edited By :   Satya
  Version  :    1.3
  Description : Added a method to add referrerlocations
  ModifiedDate: 10/30/2012 
 
  Edited By :   Vijay Kumar
  Version  :    1.4
  Description : Added a method to Update ReferrerLocationMainOffice
  ModifiedDate: 11/29/2012 

 */
namespace ITS.Core.BL
{
    public interface  IReferrerLocation
    {
        int AddReferrerLocation(ReferrerLocation referrerLocation);
        int UpdateReferrerLocation(ReferrerLocation referrerLocation);
        int DeleteReferrerLocation(int referrerLocationID);
        IEnumerable<ReferrerLocation> GetReferrerLocationsByReferrerID(int referrerID);
        ReferrerLocation GetReferrerMainLocation(int referrerID);
        int UpdateReferrerLocationMainOffice(int referrerID, int referrerOfficeLocationID);
    }
}
