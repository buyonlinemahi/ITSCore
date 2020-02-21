using ITS.Core.Data.Model;
using System.Collections.Generic;
namespace ITS.Core.BL
{
    /*
     Latest Version:  1.0
                                                
 * Author : Vishal
 * Date : 14-Nov-2012
 * Version : 1.0
 * Description : Add Interface For Get_ProjectTreatmentSLAsByProjectTreatmentSLAID
 * Description : Add Interface For Add_ProjectTreatmentSLAs
 * Description : Add Interface For Update_ProjectTreatmentSLAsByProjectTreatmentSLAID
 ==================================================================================

     */
    public interface IProjectTreatmentSLA
    {
        IEnumerable<ProjectTreatmentSLA> GetProjectTreatmentSLAsByReferrerProjectTreatmentID(int referrerProjectTreatmentID);
        IEnumerable<ProjectTreatmentSLAName> GetProjectTreatmentSLAsNameByReferrerProjectTreatmentID(int referrerProjectTreatmentID);

        int AddProjectTreatmentSLAs(ProjectTreatmentSLA projectTreatmentSLA);

        int UpdateProjectTreatmentSLAsByProjectTreatmentSLAID(ProjectTreatmentSLA projectTreatmentSLA);

    }
}
