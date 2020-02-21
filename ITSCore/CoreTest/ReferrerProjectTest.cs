using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
namespace CoreTest
{
    /// <summary>
    /// Summary description for ReferrerProjectTest
    /// </summary>
    /// 
    /*
     * 
     * Latest Version :1.5
=========================================================================================
 * Edited By : Satya
 * Date : 09-Nov-2012
 * Version : 1.1
 * Description : Add Test Method For ReferrerProjectTest
==================================================================================
  Edited By : Vishal
  Date : 11-09-2012
  Version : 1.1
  Description : Add Test Method For GetReferrerByProjectNameAutoComplete for AutoComplete
  Description : Add Test Method For AddReferrerProject for Add ReferrerProject
  Description : Add Test Method For UpdateReferrerProject for ReferrerProject
===================================================================================

 * Edited By : Vishal
 * Date : 10-Nov-2012
 * Version : 1.2
 * Description : Change Method Name Getall to GetAll_ReferrerProject()

 ==============================================================================================
  * Edited By : Vishal
 * Date : 12-Nov-2012
 * Version : 1.3
 * Description : Modify  Method AutoComplete Add new parameter referrerId to it
 ==============================================================================================
 * Craeted By : Harpreet Singh
 * Date : 03-Dec-2012
 * Version : 1.4
 * Description : Created the method for get referrer project by project id
 ==============================================================================================
      
 ==============================================================================================
 * Updated By  : Pardeep Kumar
 * Date        : 13-June-2013
 * Version     : 1.5
 * Description : Updated AddReferrerProject_Test and UpdateReferrerProject_Test methods
 ==============================================================================================     
 */
    [TestClass]
    public class ReferrerProjectTest
    {
        IReferrerProjectRepository _referrerProjectRepository;
        IReferrerRepository _referrerRepository;
        IReferrerProjectTreatmentRepository _referrerProjectTreatmentRepository;
        IReferrerProjectTreatmentPricingRepository _referrerProjectTreatmentPricingRepository;
        IReferrerProject _BLReferrerProject;

        

        public ReferrerProjectTest()
        {
        }

        [TestInitialize()]
        public void ReferrerProjectTestInit()
        {
            _referrerProjectTreatmentRepository = new ReferrerProjectTreatmentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _referrerProjectTreatmentPricingRepository = new ReferrerProjectTreatmentPricingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _referrerProjectRepository = new ReferrerProjectRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _referrerRepository = new ReferrerRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

            _BLReferrerProject = new ReferrerProjectImpl(_referrerProjectRepository, _referrerProjectTreatmentRepository, _referrerProjectTreatmentPricingRepository);

            
        }

        [TestMethod]
        public void GetAll_ReferrerProject()
        {
            IEnumerable<ReferrerProject> referrerProjectRepository = _referrerProjectRepository.GetAll();
            Assert.IsTrue(referrerProjectRepository.Any());
        }

        [TestMethod]
        public void AddReferrerProject_Test()
        {

            ReferrerProject _referrerProjectObj = new ReferrerProject();
            _referrerProjectObj.ProjectName = "jasdkara";
            _referrerProjectObj.ReferrerID = 445;
            _referrerProjectObj.StatusID = 1;
            _referrerProjectObj.FirstAppointmentOffered = true;
            _referrerProjectObj.Enabled = true;
            _referrerProjectObj.EmailSendingOptionID = 3;
            _referrerProjectObj.CentralEmail = "Coretest@test.com";
            _referrerProjectObj.IsTriage = true;
            _referrerProjectObj.IsActive = true;
            int _ReferrerProjectResult = _referrerProjectRepository.AddReferrerProject(_referrerProjectObj);
            Assert.IsTrue(_ReferrerProjectResult != 0, "Error in inserting ReferrerProject !!!");
        }

        [TestMethod]
        public void UpdateReferrerProject_Test()
        {
            ReferrerProject _referrerProjectObj = new ReferrerProject();
            _referrerProjectObj.ReferrerProjectID = 4175;
            _referrerProjectObj.ProjectName = "raj Singh Tomer";
            _referrerProjectObj.ReferrerID = 278;
            _referrerProjectObj.StatusID = 1;
            _referrerProjectObj.FirstAppointmentOffered = false;
            _referrerProjectObj.Enabled = false;
            _referrerProjectObj.EmailSendingOptionID = 3;
            _referrerProjectObj.IsTriage = false;
            _referrerProjectObj.CentralEmail = "Vishal@test.com";
            _referrerProjectObj.IsActive = false;
            int _ReferrerProjectResult = _referrerProjectRepository.UpdateReferrerProject(_referrerProjectObj);
            Assert.IsTrue(_ReferrerProjectResult != 0, "Error in Updating the ReferrerProject !!!");
        }

        [TestMethod]
        public void GetReferrerProjectNameAutoComplete_Test()
        {
            IEnumerable<ReferrerProject> _ReferrerProjectResult = _referrerProjectRepository.GetReferrerProjectNameAutoComplete("r", 278);
            Assert.IsTrue(_ReferrerProjectResult.Any());
        }

        [TestMethod]
        public void get_all_referrer_projects_by_referrerid()
        {
            IEnumerable<ReferrerProject> _ReferrerProjectResult = _referrerProjectRepository.GetReferrerProjectsByReferrerID(_referrerRepository.GetAll().First().ReferrerID);
            Assert.IsTrue(_ReferrerProjectResult.Any());
        }
        [TestMethod]
        public void GetReferrerAssignedUserByReferrerID()
        {
           var _referrerProject = _referrerProjectRepository.GetReferrerAssignedUserByReferrerID(566);
            Assert.IsTrue(_referrerProject.Any());
        }

        [TestMethod]
        public void get_all_referrer_complete_projects_by_referrerid()
        {
            IEnumerable<ReferrerProject> _ReferrerProjectResult = _referrerProjectRepository.GetCompleteReferrerProjectsByReferrerID(_referrerRepository.GetAll().First().ReferrerID);
            Assert.IsTrue(_ReferrerProjectResult.Any(), "referrer has no complete projects");
        }

        [TestMethod]
        public void get_referrer_project_by_projectid()
        {
            ReferrerProject _ReferrerProjectResult = _referrerProjectRepository.GetReferrerProjectByProjectID(472);
            Assert.IsTrue(_ReferrerProjectResult != null, "unable get ReferrerProject By ProjectID");
        }
        [TestMethod]
        public void UpdateReferrerProjectStatusByReferrerProjectID()
        {
            ReferrerProjectImpl obj = new ReferrerProjectImpl(_referrerProjectRepository, _referrerProjectTreatmentRepository, _referrerProjectTreatmentPricingRepository);
          //  _referrerProjectRepository.UpdateReferrerProjectStatusByReferrerProjectID(2578,1);
            var tt = obj.UpdateProjectStatus(3039, false);
            //Assert.IsTrue(obj.UpdateProjectStatus(2994, true) != 0, "Error in UpdateReferrerProjectStatusByReferrerProjectID !!!");
            

        }

        [TestMethod]
        public void GetReferrerProjectFirstAppointmentOfferedByReferrerProjectTreatmentID()
        {
            bool firstAppointmentOffered = _BLReferrerProject.GetReferrerProjectFirstAppointmentOfferedByReferrerProjectTreatmentID(8361);
            Assert.IsTrue(firstAppointmentOffered != null, "unable get firstAppointmentOffered By ReferrerProjectTreatmentID");
        }





    }
}
