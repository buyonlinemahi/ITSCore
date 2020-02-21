using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
/*
  Page Name:  IProjectTreatmentSLARepository.cs                      
  Latest Version:  1.0                                              
  Purpose: Create ProjectTreatmentSLA Repository  interface                                                      
  Revision History:                                        
                                                           
 * 1.0 – 11/09/2012 Satya 
=============================================================================
  * Edited By : Vishal
 * Date : 14-Nov-2012
 * Version : 1.0
 * Description : Add Interface For Get_ProjectTreatmentSLAsByProjectTreatmentSLAID
 * Description : Add Interface For Add_ProjectTreatmentSLAs
 * Description : Add Interface For Update_ProjectTreatmentSLAsByProjectTreatmentSLAID
 ==================================================================================
 */
namespace ITS.Core.Data
{
    public interface IProjectTreatmentSLARepository : IBaseRepository<ProjectTreatmentSLA>
    {
        IEnumerable<ProjectTreatmentSLA> GetProjectTreatmentSLAsByReferrerProjectTreatmentID(int referrerProjectTreatmentID);
        IEnumerable<ProjectTreatmentSLAName> GetProjectTreatmentSLAsNameByReferrerProjectTreatmentID(int referrerProjectTreatmentID);

        int AddProjectTreatmentSLAs(ProjectTreatmentSLA projectTreatmentSLA);

        int UpdateProjectTreatmentSLAsByProjectTreatmentSLAID(ProjectTreatmentSLA projectTreatmentSLA);

        
    }
}
