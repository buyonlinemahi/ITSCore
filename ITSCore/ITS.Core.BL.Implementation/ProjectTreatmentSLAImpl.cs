using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment
/*
              
 Latest Version:  1.0
                                                
 * Author : Vishal
 * Date : 14-Nov-2012
 * Version : 1.0
 * Description : implement interface For Get_ProjectTreatmentSLAsByProjectTreatmentSLAID
 * Description : implement interface  For Add_ProjectTreatmentSLAs
 * Description : implement interface  For Update_ProjectTreatmentSLAsByProjectTreatmentSLAID
 ==================================================================================

 */
#endregion
namespace ITS.Core.BL.Implementation
{
   public class ProjectTreatmentSLAImpl : IProjectTreatmentSLA
    {
       private readonly IProjectTreatmentSLARepository _projectTreatmentSLARepository;

       public ProjectTreatmentSLAImpl(IProjectTreatmentSLARepository projectTreatmentSLARepository)
        {
            _projectTreatmentSLARepository = projectTreatmentSLARepository;
        }      

       public int AddProjectTreatmentSLAs(ProjectTreatmentSLA projectTreatmentSLA)
       {
           return _projectTreatmentSLARepository.AddProjectTreatmentSLAs(projectTreatmentSLA);
       }

       public int UpdateProjectTreatmentSLAsByProjectTreatmentSLAID(ProjectTreatmentSLA projectTreatmentSLA)
       {
           return _projectTreatmentSLARepository.UpdateProjectTreatmentSLAsByProjectTreatmentSLAID(projectTreatmentSLA);
       }

       public IEnumerable<ProjectTreatmentSLA> GetProjectTreatmentSLAsByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
       {
           return _projectTreatmentSLARepository.GetProjectTreatmentSLAsByReferrerProjectTreatmentID(referrerProjectTreatmentID);
 
       }

       public IEnumerable<ProjectTreatmentSLAName> GetProjectTreatmentSLAsNameByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
       {
           return _projectTreatmentSLARepository.GetProjectTreatmentSLAsNameByReferrerProjectTreatmentID(referrerProjectTreatmentID);
       }
    }
       
    
       
}
