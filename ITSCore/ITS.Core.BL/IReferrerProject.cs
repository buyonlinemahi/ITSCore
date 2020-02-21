using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment
/*
 Page Name:  IReferrerProject.cs                      
 Latest Version:  1.0
 Author : Vishal
 
 * Revision History:                                                   
 ===================================================================================
  Edited By : Vishal
  Date : 11-09-2012
  Version : 1.0
  Description : Add Interface For GetReferrerByProjectNameAutoComplete for AutoComplete
  Description : Add Interface For AddReferrerProject for Add ReferrerProject
  Description : Add Interface For UpdateReferrerProject for ReferrerProject
===================================================================================
 * Edited By : Vishal
 * Date : 12-Nov-2012
 * Version : 1.3
 * Description : Modify  interface AutoComplete Add new parameter referrerId to it
 ==============================================================================================
*/
#endregion

namespace ITS.Core.BL
{
    public interface IReferrerProject
    {
        IEnumerable<ReferrerProject> GetReferrerProjectNameAutoComplete(string projectNameLike, int referrerID);
        int AddReferrerProject(ReferrerProject referrerProject);
        int UpdateReferrerProject(ReferrerProject referrerProject);
        IEnumerable<ReferrerProject> GetReferrerProjectByReferrerID(int referrerID);
        ReferrerProject GetReferrerProjectByProjectID(int projectID);
        int UpdateProjectStatus(int referrerProjectId,bool isTriage);
        IEnumerable<ReferrerProject> GetCompleteReferrerProjectsByReferrerID(int referrerID);

        bool GetReferrerProjectFirstAppointmentOfferedByReferrerProjectTreatmentID(int referrerProjectTreatmentID);
        IEnumerable<ReferrerProject> GetReferrerProjectAssignedToUser(int referrerID, int userID);
        IEnumerable<ReferrerProject> GetReferrerProjectNotAssignedToUser(int referrerID, int userID);
    }
}
