using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;


/*
 *
 * Latest Version : 1.1
 * Author         : Vijay Kumar
 * Date           : 16-Nov-2012
 * Version        : 1.0
 * Created class  : ReferrerProjectTreatmentAssessmentImpl with a method to GetAll,AddReferrerProjectTreatmentAssignment,UpdateReferrerProjectTreatmentAssignment;
 * 
 * *  * Revision History
 Version : 1.1 ,Vijay, 11-19-2012 
 Description: Add delete Method for ReferrerProjectTreatmentAssessment
 */

namespace ITS.Core.BL.Implementation
{
    public class ReferrerProjectTreatmentAssessmentImpl : IReferrerProjectTreatmentAssessment
    {


        private readonly IReferrerProjectTreatmentAssessmentRepository _referrerProjectTreatmentAssignmentRepository;

        public ReferrerProjectTreatmentAssessmentImpl(IReferrerProjectTreatmentAssessmentRepository referrerProjectTreatmentAssignmentRepository)
        {
            _referrerProjectTreatmentAssignmentRepository = referrerProjectTreatmentAssignmentRepository;
        }

        public int AddReferrerProjectTreatmentAssignment(ReferrerProjectTreatmentAssessment referrerProjectTreatmentAssignment)
        {
            return _referrerProjectTreatmentAssignmentRepository.AddReferrerProjectTreatmentAssignment(referrerProjectTreatmentAssignment);
        }

        public int UpdateReferrerProjectTreatmentAssignment(ReferrerProjectTreatmentAssessment referrerProjectTreatmentAssignment)
        {
            return _referrerProjectTreatmentAssignmentRepository.UpdateReferrerProjectTreatmentAssignment(referrerProjectTreatmentAssignment);
        }

        public IEnumerable<ReferrerProjectTreatmentAssessment> GetReferrerProjectTreatmentAssessmentByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            return _referrerProjectTreatmentAssignmentRepository.GetReferrerProjectTreatmentAssessmentByReferrerProjectTreatmentID(referrerProjectTreatmentID);
        }

        public int DeleteReferrerProjectTreatmentAssignment(int referrerProjectTreatmentAssessmentID)
        {
            return _referrerProjectTreatmentAssignmentRepository.DeleteReferrerProjectTreatmentAssignment(referrerProjectTreatmentAssessmentID);
        }

        public IEnumerable<ReferrerProjectTreatmentAssessment> GetAllReferrerProjectTreatmentAssignment()
        {
            return _referrerProjectTreatmentAssignmentRepository.GetAll();
        }
    }
}
