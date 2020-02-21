using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CoreTest
{


    /// <summary>
    /// 
    /// 
    /// Summary description for ReferrerProjectAssessmentTest
    /// </summary>
    /// 


    /* Author: Vijay Kumar
     * Latest Version : 1.1
     * Description : Add Test Method For ReferrerProjectTreatmentAssignmentTest
     ===============================================================================================  
     * 
     *  * 
 * /* Revised History:
 * Edited By : Vijay Kumar.
 * Latest Version : 1.0
 * Description : Add Test Method For ReferrerProjectTreatmentAssessmentTest
     * 
     *  * /* Revised History:
 * Edited By : Vijay Kumar.
 * Latest Version : 1.1
 * Description : Add delete Test Method For ReferrerProjectTreatmentAssessmentTest
     */

    [TestClass]
    public class ReferrerProjectTreatmentAssessmentTest
    {
        IReferrerProjectTreatmentAssessmentRepository _referrerProjectTreatmentAssignmentRepository;
        //public ReferrerProjectTreatmentAssessmentTest()
        //{
        //}

        [TestInitialize()]
        public void ReferrerProjectTreatmentAssessmentTestInit()
        {
            _referrerProjectTreatmentAssignmentRepository = new ReferrerProjectTreatmentAssessmentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetAll_ReferrerProjectTreatmentAssignment()
        {
            IEnumerable<ReferrerProjectTreatmentAssessment> referrerProjectTreatmentAssignmentRepository = _referrerProjectTreatmentAssignmentRepository.GetAll();
            Assert.IsTrue(referrerProjectTreatmentAssignmentRepository.Any());
        }

        [TestMethod]
        public void GetReferrerProjectTreatmentAssessmentByReferrerProjectTreatmentID()
        {
            IEnumerable<ReferrerProjectTreatmentAssessment> referrerProjectTreatmentAssignmentRepository = _referrerProjectTreatmentAssignmentRepository.GetReferrerProjectTreatmentAssessmentByReferrerProjectTreatmentID(8361);
            Assert.IsTrue(referrerProjectTreatmentAssignmentRepository.Any());
        }


        [TestMethod]
        public void Add_ReferrerProjectTreatmentAssignment()
        {
            ReferrerProjectTreatmentAssessment referrerProjectTreatmentAssignment = new ReferrerProjectTreatmentAssessment();
            referrerProjectTreatmentAssignment.AssessmentTypeID = 6;
            referrerProjectTreatmentAssignment.AssessmentServiceID = 7;
            referrerProjectTreatmentAssignment.ReferrerProjectTreatmentID = 8;
            int rv = _referrerProjectTreatmentAssignmentRepository.AddReferrerProjectTreatmentAssignment(referrerProjectTreatmentAssignment);
            Assert.IsTrue(rv != 0, "Unable to insert");
        }

        [TestMethod]
        public void Update_ReferrerProjectTreatmentAssignment()
        {
            ReferrerProjectTreatmentAssessment referrerProjectTreatmentAssignment = new ReferrerProjectTreatmentAssessment();
            referrerProjectTreatmentAssignment.ReferrerProjectTreatmentAssessmentID = 1;
            referrerProjectTreatmentAssignment.AssessmentServiceID = 3;
            referrerProjectTreatmentAssignment.AssessmentTypeID = 4;
            referrerProjectTreatmentAssignment.ReferrerProjectTreatmentID = 2;

            int returnValue = _referrerProjectTreatmentAssignmentRepository.UpdateReferrerProjectTreatmentAssignment(referrerProjectTreatmentAssignment);
            Assert.IsTrue(returnValue != 0, "Unable to update");
        }

        [TestMethod]
        public void Delete_ReferrerProjectTreatmentAssignment()
        {
            int result = _referrerProjectTreatmentAssignmentRepository.DeleteReferrerProjectTreatmentAssignment(17376);
            Assert.IsTrue(result!=0, "Unable to Delete");
        }

    }



}
