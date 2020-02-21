using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;


#region Comment
/*
 
 Page Name:  IReferrerProjectRepository.cs                      
 Latest Version:  1.2                                              
 Purpose: Create Referrer Project Repository  interface     
 1.0 – 11/09/2012 Satya 
 
 * Revision History:                                                   
 ===================================================================================
  Edited By : Vishal
  Date : 11-09-2012
  Version : 1.1
  Description : Add interface For GetReferrerByProjectNameAutoComplete for AutoComplete
  Description : Add interface For AddReferrerProject for Add ReferrerProject
  Description : Add interface For UpdateReferrerProject for ReferrerProject
===================================================================================
 * Edited By : Vishal
 * Date : 12-Nov-2012
 * Version : 1.2
 * Description : Modify  interface AutoComplete Add new parameter referrerId to it
 ==============================================================================================
 */
#endregion


namespace ITS.Core.Data
{
    public interface IReferrerProjectRepository : IBaseRepository<ReferrerProject>
    {
        IEnumerable<ReferrerProject> GetReferrerProjectNameAutoComplete(string projectNameLike, int referrerID);
        int AddReferrerProject(ReferrerProject referrerProject);
        int UpdateReferrerProject(ReferrerProject referrerProject);
        IEnumerable<ReferrerProject> GetReferrerProjectsByReferrerID(int referrerID);
        IEnumerable<ReferrerAssignedUser> GetReferrerAssignedUserByReferrerID(int referrerID);
        IEnumerable<ReferrerProject> GetCompleteReferrerProjectsByReferrerID(int referrerID);
        ReferrerProject GetReferrerProjectByProjectID(int projectID);
        int UpdateReferrerProjectStatusByReferrerProjectID(int referrerProjectId, int statusID);        
        IEnumerable<ReferrerProject> GetReferrerProjectAssignedToUser(int referrerID, int userID);
        IEnumerable<ReferrerProject> GetReferrerProjectNotAssignedToUser(int referrerID, int userID);
    }
}
