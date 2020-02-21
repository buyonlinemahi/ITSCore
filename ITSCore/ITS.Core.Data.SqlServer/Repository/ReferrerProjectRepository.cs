using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;



#region Comment
/*
 
 Page Name:  ReferrerProjectRepository.cs                      
 Latest Version:  1.4                                             
 Purpose: create Referrer Project Repository  inside itscore project                                                         
 Revision History:                                        
                                                           
 1.0 – 11/09/2012 Satya 
 
 * Revision History:                                                   
 ===================================================================================
  Edited By : Vishal
  Date : 11-09-2012
  Version : 1.1
  Description : Add Method For GetReferrerByProjectNameAutoComplete for AutoComplete
  Description : Add Method For AddReferrerProject for Add ReferrerProject
  Description : Add Method For UpdateReferrerProject for ReferrerProject
===================================================================================
   * Edited By : Vishal
 * Date : 12-Nov-2012
 * Version : 1.2
 * Description : Modify  Method AutoComplete Add new parameter referrerId to it
 ==============================================================================================
  Edited By :   Vishal
  Version  :    1.3
  Description : Modify Add  method to add Scope Identy
  ModifiedDate: 11/19/2012 
 * 
 * =============================================================================================
 * 
 * Edited By  : Pardeep
 * Version    : 1.4
 * Date       : 13-June-2013
 * Description: Updated method AddReferrerProject, as new sqlparamerter is added _EmailSendingOptionID
 *            : Updated method UpdateReferrerProject, as new sqlparamerter is added _EmailSendingOptionID
 
 
 */
#endregion


namespace ITS.Core.Data.SqlServer.Repository
{
    public class ReferrerProjectRepository : BaseRepository<ReferrerProject, ITSDBContext>, IReferrerProjectRepository
    {
        public ReferrerProjectRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }




        public int AddReferrerProject(ReferrerProject referrerProject)
        {
            SqlParameter _ProjectName = new SqlParameter("@ProjectName", referrerProject.ProjectName);
            SqlParameter _ReferrerID = new SqlParameter("@ReferrerID", referrerProject.ReferrerID);
            SqlParameter _StatusID = new SqlParameter("@StatusID", referrerProject.StatusID);
            SqlParameter _FirstAppointmentOffered = new SqlParameter("@FirstAppointmentOffered", referrerProject.FirstAppointmentOffered);
            SqlParameter _Enabled = new SqlParameter("@Enabled", referrerProject.Enabled);
            SqlParameter _EmailSendingOptionID = new SqlParameter("@EmailSendingOptionID", referrerProject.EmailSendingOptionID);
            SqlParameter _CentralEmail = new SqlParameter("@CentralEmail", referrerProject.CentralEmail);
            SqlParameter _IsTriage = new SqlParameter("@IsTriage", referrerProject.IsTriage);
            SqlParameter _IsActive = new SqlParameter("@IsActive", referrerProject.IsActive);

            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.ReferrerProjectRepositoryProcedures.Add_ReferrerProject, _ProjectName, _ReferrerID, _StatusID, _FirstAppointmentOffered, _Enabled, _IsTriage, _CentralEmail, _EmailSendingOptionID, _IsActive).SingleOrDefault();
        }

        public int UpdateReferrerProject(ReferrerProject referrerProject)
        {
            SqlParameter _ReferrerProjectID = new SqlParameter("@ReferrerProjectID", referrerProject.ReferrerProjectID);
            SqlParameter _ProjectName = new SqlParameter("@ProjectName", referrerProject.ProjectName);
            SqlParameter _ReferrerID = new SqlParameter("@ReferrerID", referrerProject.ReferrerID);
            SqlParameter _StatusID = new SqlParameter("@StatusID", referrerProject.StatusID);
            SqlParameter _FirstAppointmentOffered = new SqlParameter("@FirstAppointmentOffered", referrerProject.FirstAppointmentOffered);
            SqlParameter _Enabled = new SqlParameter("@Enabled", referrerProject.Enabled);
            SqlParameter _EmailSendingOptionID = new SqlParameter("@EmailSendingOptionID", referrerProject.EmailSendingOptionID);
            SqlParameter _CentralEmail = new SqlParameter("@CentralEmail", referrerProject.CentralEmail);
            SqlParameter _IsTriage = new SqlParameter("@IsTriage", referrerProject.IsTriage);
            SqlParameter _IsActive = new SqlParameter("@IsActive", referrerProject.IsActive);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerProjectRepositoryProcedures.Update_ReferrerProjectByReferrerProjectID, _ReferrerProjectID, _ProjectName, _ReferrerID, _StatusID, _FirstAppointmentOffered, _Enabled, _EmailSendingOptionID, _CentralEmail, _IsTriage, _IsActive);
        }

        public IEnumerable<ReferrerProject> GetReferrerProjectNameAutoComplete(string projectNameLike, int referrerID)
        {
            SqlParameter _ProjectName = new SqlParameter("@ProjectName", projectNameLike);
            SqlParameter _ReferrerID = new SqlParameter("@ReferrerID", referrerID);
            return Context.Database.SqlQuery<ReferrerProject>(Global.StoredProcedureConst.ReferrerProjectRepositoryProcedures.Get_ReferrerProjectsLikeProjectName, _ProjectName, _ReferrerID);
        }

        public IEnumerable<ReferrerProject> GetReferrerProjectsByReferrerID(int referrerID)
        {
            SqlParameter referrerIDParam = new SqlParameter("@ReferrerID", referrerID);
            return Context.Database.SqlQuery<ReferrerProject>(Global.StoredProcedureConst.ReferrerProjectRepositoryProcedures.GetReferrerProjectsByReferrerID, referrerIDParam);
        }
        public IEnumerable<ReferrerAssignedUser> GetReferrerAssignedUserByReferrerID(int referrerID)
        {
            SqlParameter _referreID = new SqlParameter("@ReferrerID", referrerID);
            return Context.Database.SqlQuery<ReferrerAssignedUser>(Global.StoredProcedureConst.ReferrerProjectRepositoryProcedures.GetReferrerAssignedUserByReferrerID, _referreID);
         }


        public ReferrerProject GetReferrerProjectByProjectID(int projectID)
        {
            SqlParameter projectIDParam = new SqlParameter("@ProjectID", projectID);
            return Context.Database.SqlQuery<ReferrerProject>(Global.StoredProcedureConst.ReferrerProjectRepositoryProcedures.GetReferrerProjectByProjectID, projectIDParam).SingleOrDefault();
        }


        public int UpdateReferrerProjectStatusByReferrerProjectID(int referrerProjectID, int statusID)
        {
            SqlParameter referrerProjectId = new SqlParameter("@ReferrerProjectID", referrerProjectID);
            SqlParameter statusId = new SqlParameter("@StatusID", statusID);
            return (int)Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerProjectRepositoryProcedures.Update_ReferrerProjectStatusByReferrerProjectID, referrerProjectId, statusId);
        }

        public IEnumerable<ReferrerProject> GetCompleteReferrerProjectsByReferrerID(int referrerID)
        {
            SqlParameter referrerIDParam = new SqlParameter("@ReferrerID", referrerID);
            return Context.Database.SqlQuery<ReferrerProject>(Global.StoredProcedureConst.ReferrerProjectRepositoryProcedures.GetReferrerCompleteProjectsByReferrerID, referrerIDParam);
        }

        public IEnumerable<ReferrerProject> GetReferrerProjectAssignedToUser(int referrerID, int userID)
        {
            SqlParameter _referrerID = new SqlParameter("@referrerID", referrerID);
            SqlParameter _userID = new SqlParameter("@userID", userID);
            return Context.Database.SqlQuery<ReferrerProject>(Global.StoredProcedureConst.ReferrerProjectRepositoryProcedures.GetReferrerProjectAssignedToUser, _referrerID, _userID);
        }

        public IEnumerable<ReferrerProject> GetReferrerProjectNotAssignedToUser(int referrerID, int userID)
        {
            SqlParameter _referrerID = new SqlParameter("@referrerID", referrerID);
            SqlParameter _userID = new SqlParameter("@userID", userID);
            return Context.Database.SqlQuery<ReferrerProject>(Global.StoredProcedureConst.ReferrerProjectRepositoryProcedures.GetReferrerProjectNotAssignedToUser, _referrerID, _userID);
        }
    }
}
