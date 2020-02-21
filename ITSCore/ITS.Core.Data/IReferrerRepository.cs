using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
/*
  Page Name:  IReferrerRepository.cs                      
  Latest Version:  1.3                                              
  Purpose: create referrer repository interface                                                      
  Revision History:                                        
                                                           
 * 1.0 – 10/26/2012 Satya 
 * 1.1 - 10/26/2012 Manjit Singh
 * getReferrerDetail contract added
 =================================================================================
 * Edited By : Vishal
 * Date : 27-Oct-2012
 * Version : 1.2
 * Description : Add Interface For Add_Reffer
 * Description : Add Interface For Update_Reffer
  ==================================================================================
  Edited By : Vishal
  Date : 11-08-2012
  Version : 1.3
  Description : Add Interface For Get_ReferrersLikeReferrerName for AutoComplete
===================================================================================
 */

namespace ITS.Core.Data
{
    /// <summary>
    /// 
    /// </summary>
    public interface IReferrerRepository : IBaseRepository<Referrer>
    {
        Referrer GetReferrerDetails(int referrerID);

        int AddReferrer(Referrer referrer);

        int UpdateReferrer(Referrer referrer);

        IEnumerable<Referrer> GetReferrersLikeReferrerName(string referrerNameLike);

        bool GetReferrerExistsByName(string referrerName);

        IEnumerable<Referrer> GetReferrersRecentlyAdded();

        int GetReferrerLocationReferrerLikeReferrerNameCount(string referrerName);
        IEnumerable<ReferrerLocationReferrer> GetReferrerLocationReferrerLikeReferrerName(string referrerName, int skip, int take);

        IEnumerable<ReferrersName> GetAllReferrers();

        int GetReferrerIDbyReferrerProjectTreatmentID(int referrerProjectTreatmentID);

    }

}
