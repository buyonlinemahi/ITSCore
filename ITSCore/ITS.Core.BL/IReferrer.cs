using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment
/*
 Page Name:  IReferrer.cs                      
 Latest Version:  1.3
 Purpose: Added a method to GetReferrerDetail                                                     
 
 * Revision History:                                                   
    1.0 – 10/26/2012 Manjit Singh 
 * Interface for Referrer created with GetReferrerDetails
  
 =================================================================================
 * Edited By : Vishal
 * Date : 27-Oct-2012
 * Version : 1.1
 * Description : Add Interface For Add_Reffer
 * Description : Add Interface For Update_Reffer
 ==================================================================================
  Edited By : Vishal
  Date : 11-08-2012
  Version : 1.2
  Description : Add Interface For Get_ReferrersLikeReferrerName for AutoComplete
===================================================================================
 * 
  Edited By : Robin Singh
  Date :      11-09-2012
  Version : 1.3
  Description : Add Interface For UpdateReferrerAndMainLocation
 */
#endregion

namespace ITS.Core.BL
{
    public interface IReferrer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Referrer GetReferrerDetails(int referrerID);
        int AddReferrer(Referrer referrer);
        int UpdateReferrer(Referrer referrer);
        int AddReferrerAndMainLocation(Referrer referrer, ReferrerLocation location);
        IEnumerable<Referrer> GetReferrersLikeReferrerName(string referrerNameLike);
        int UpdateReferrerAndMainLocation(Referrer referrer, ReferrerLocation location);
        IEnumerable<Referrer> GetAllReferrer();
        bool GetReferrerExistsByName(string referrerName);
        IEnumerable<Referrer> GetReferrersRecentlyAdded();

        int GetReferrerLocationReferrerLikeReferrerNameCount(string referrerName);
        IEnumerable<ReferrerLocationReferrer> GetReferrerLocationReferrerLikeReferrerName(string referrerName, int skip, int take);

        IEnumerable<ReferrersName> GetAllReferrers();

        int GetReferrerIDbyReferrerProjectTreatmentID(int referrerProjectTreatmentID);

    }
}



