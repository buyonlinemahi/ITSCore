using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
    * Author : Satya
    * Latest Version : 1.2
    * Reason :- Interface For ReferrerProjectTreatmentAssessment  
    * Created on 11-10-2012 
 

 * 
 * Revision History
 Version : 1.1 ,Vijay, 11-16-2012 
 Description: Add Method for ReferrerProjectTreatmentAssessment
 * 
 *  * Revision History
 Version : 1.2 ,Vijay, 11-19-2012 
 Description: Add delete Method for ReferrerProjectTreatmentAssessment
*/

namespace ITS.Core.Data
{
    public interface IReferrerProjectTreatmentAssessmentRepository : IBaseRepository<ReferrerProjectTreatmentAssessment>
    {

        int AddReferrerProjectTreatmentAssignment(ReferrerProjectTreatmentAssessment referrerProjectTreatmentAssignment);
        int UpdateReferrerProjectTreatmentAssignment(ReferrerProjectTreatmentAssessment referrerProjectTreatmentAssignment);
        int DeleteReferrerProjectTreatmentAssignment(int referrerProjectTreatmentAssessmentID);
        IEnumerable<ReferrerProjectTreatmentAssessment> GetReferrerProjectTreatmentAssessmentByReferrerProjectTreatmentID(int referrerProjectTreatmentID);
        
       

    }
}
