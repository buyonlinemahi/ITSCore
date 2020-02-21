using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{


    /* Author : Vijay Kumar
     * Date : 11-16-2012 
     * Latest Version : 1.1
     Description : Add interface For IReferrerProjectTreatmentAssessment
      * 
      Revision History
     Version : 1.0 ,Vijay Kumar, 11-16-2012 
     Description: Add Method For IReferrerProjectTreatmentAssessment
     * 
     *  Revision History
     Version : 1.1 ,Vijay Kumar, 11-19-2012 
     Description: Add  DeleteReferrerProjectTreatmentAssignment Method For IReferrerProjectTreatmentAssessment
    */
    public interface IReferrerProjectTreatmentAssessment
    {

        IEnumerable<ReferrerProjectTreatmentAssessment> GetAllReferrerProjectTreatmentAssignment();
        int AddReferrerProjectTreatmentAssignment(ReferrerProjectTreatmentAssessment referrerProjectTreatmentAssignment);
        int UpdateReferrerProjectTreatmentAssignment(ReferrerProjectTreatmentAssessment referrerProjectTreatmentAssignment);
        int DeleteReferrerProjectTreatmentAssignment(int referrerProjectTreatmentAssessmentID);
        IEnumerable<ReferrerProjectTreatmentAssessment> GetReferrerProjectTreatmentAssessmentByReferrerProjectTreatmentID(int referrerProjectTreatmentID);

    }
}
