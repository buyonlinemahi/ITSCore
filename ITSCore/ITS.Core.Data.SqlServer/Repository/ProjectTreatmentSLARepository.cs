using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

/*
 Page Name:  ProjectTreatmentSLARepository.cs                      
 Latest Version:  1.2                                              
  Purpose: create ProjectTreatmentSLA Repository  inside itscore project                                                         
  Revision History:                                        
                                                           
   1.0 – 11/09/2012 Satya 
                 
 * Edited By : Vishal
 * Date : 14-Nov-2012
 * Version : 1.1
 * Description : implement interface For Get_ProjectTreatmentSLAsByProjectTreatmentSLAID
 * Description : implement interface  For Add_ProjectTreatmentSLAs
 * Description : implement interface  For Update_ProjectTreatmentSLAsByProjectTreatmentSLAID
 ==================================================================================
  Edited By :   Vishal
  Version  :    1.2
  Description : Modify Add  method to add Scope Identy
  ModifiedDate: 11/19/2012 
 
 
 */


namespace ITS.Core.Data.SqlServer.Repository
{
    public class ProjectTreatmentSLARepository : BaseRepository<ProjectTreatmentSLA, ITSDBContext>, IProjectTreatmentSLARepository
    {
        public ProjectTreatmentSLARepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {


        }

        public int AddProjectTreatmentSLAs(ProjectTreatmentSLA projectTreatmentSLA)
        {
            SqlParameter _ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", projectTreatmentSLA.ReferrerProjectTreatmentID);
            SqlParameter _ServiceLevelAgreementID = new SqlParameter("@ServiceLevelAgreementID", projectTreatmentSLA.ServiceLevelAgreementID);
            SqlParameter _NumberOfDays = new SqlParameter("@NumberOfDays", projectTreatmentSLA.NumberOfDays);
            SqlParameter _Enabled = new SqlParameter("@Enabled", projectTreatmentSLA.Enabled);
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.ProjectTreatmentSLARepositoryProcedure.Add_ProjectTreatmentSLAs, _ReferrerProjectTreatmentID, _ServiceLevelAgreementID, _NumberOfDays,_Enabled).SingleOrDefault();
          

        }
        public int UpdateProjectTreatmentSLAsByProjectTreatmentSLAID(ProjectTreatmentSLA projectTreatmentSLA)
        {
            SqlParameter ProjectTreatmentSLAID = new SqlParameter("@ProjectTreatmentSLAID", projectTreatmentSLA.ProjectTreatmentSLAID);
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", projectTreatmentSLA.ReferrerProjectTreatmentID);
            SqlParameter ServiceLevelAgreementID = new SqlParameter("@ServiceLevelAgreementID", projectTreatmentSLA.ServiceLevelAgreementID);
            SqlParameter NumberOfDays = new SqlParameter("@NumberOfDays", projectTreatmentSLA.NumberOfDays);
            SqlParameter Enabled = new SqlParameter("@Enabled", projectTreatmentSLA.Enabled);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ProjectTreatmentSLARepositoryProcedure.Update_ProjectTreatmentSLAsByProjectTreatmentSLAID, ProjectTreatmentSLAID, ReferrerProjectTreatmentID, ServiceLevelAgreementID, NumberOfDays,Enabled);
        }

        public IEnumerable<ProjectTreatmentSLA> GetProjectTreatmentSLAsByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            SqlParameter _ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentID);
            return Context.Database.SqlQuery<ProjectTreatmentSLA>(Global.StoredProcedureConst.ProjectTreatmentSLARepositoryProcedure.Get_ProjectTreatmentSLAsByReferrerProjectTreatmentID, _ReferrerProjectTreatmentID);

        }

        public IEnumerable<ProjectTreatmentSLAName> GetProjectTreatmentSLAsNameByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            SqlParameter _ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentID);
            return Context.Database.SqlQuery<ProjectTreatmentSLAName>(Global.StoredProcedureConst.ProjectTreatmentSLARepositoryProcedure.GetProjectTreatmentSLAsNameByReferrerProjectTreatmentID, _ReferrerProjectTreatmentID);

        }
    }
}
