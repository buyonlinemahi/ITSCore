using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
namespace CoreTest
{
    /// <summary>
    /// Summary description for ProjectTreatmentSLATest
    /// </summary>
    /// 
    /*
     * Latest Version :1.3
 ==============================================================================================
 * Edited By : Satya
 * Date : 09-Nov-2012
 * Version : 1.0
 * Description : Add Test Method For ProjectTreatmentSLATest
  ==============================================================================================
   * Edited By : Vishal
 * Date : 10-Nov-2012
 * Version : 1.1
 * Description : Change Method Name Getall to GetAll_ProjectTreatmentSLA()

 ==============================================================================================
 * Edited By : Vishal
 * Date : 14-Nov-2012
 * Version : 1.2
 * Description : CREATE to Add_ReferrerProjectTreatmentPricing()
 * Description : CREATE Method For Getall to Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentID()
 * Description : CREATE Method for Update_ReferrerProjectTreatmentPricingByPricingID()

 version :1.3
 Updated By : Anuj Batra
 Description : Updated the method's name
 ==============================================================================================
 */
    [TestClass]
    public class ProjectTreatmentSLATest
    {

        IProjectTreatmentSLARepository _projectTreatmentSLA;
        public ProjectTreatmentSLATest()
        {
        }

        [TestInitialize()]
        public void ProjectTreatmentSLATestInit()
        {
            _projectTreatmentSLA = new ProjectTreatmentSLARepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void GetAll_ProjectTreatmentSLA()
        {
            IEnumerable<ProjectTreatmentSLA> projectTreatmentSLA = _projectTreatmentSLA.GetAll();
            Assert.IsTrue(projectTreatmentSLA.Any());
        }

        [TestMethod]
        public void GetReferrerProjectTreatmentSLAByReferrerProjectTreatmentID()
        {
            IEnumerable<ProjectTreatmentSLA> _ProjectTreatmentSLAObj = _projectTreatmentSLA.GetProjectTreatmentSLAsByReferrerProjectTreatmentID(6720);
            Assert.IsTrue(_ProjectTreatmentSLAObj.Any());
        }

          [TestMethod]
        public void Get_ProjectTreatmentSLAsNameByReferrerProjectTreatmentID()
        {
            var _ProjectTreatmentSLAObj = _projectTreatmentSLA.GetProjectTreatmentSLAsNameByReferrerProjectTreatmentID(8361);

            Assert.IsTrue(_ProjectTreatmentSLAObj.Any());
        }

        

        [TestMethod]
        public void Add_ReferrerProjectTreatmentSLA()
        {
            ProjectTreatmentSLA _ProjectTreatmentSLAObj = new ProjectTreatmentSLA();
            _ProjectTreatmentSLAObj.NumberOfDays = 222;
            _ProjectTreatmentSLAObj.ReferrerProjectTreatmentID = 7652;
            _ProjectTreatmentSLAObj.ServiceLevelAgreementID = 1;
            _ProjectTreatmentSLAObj.Enabled = true;

            int _ReferrerProjectTreatmentSLAResult = _projectTreatmentSLA.AddProjectTreatmentSLAs(_ProjectTreatmentSLAObj);

            Assert.IsTrue(_ReferrerProjectTreatmentSLAResult != 0, "Error in inserting _ReferrerProjectTreatmentSLAResult !!!");
        }

        [TestMethod]
        public void Update_ReferrerProjectTreatmentSLAByProjectTreatmentSLAID()
        {

            ProjectTreatmentSLA _ProjectTreatmentSLAObj = new ProjectTreatmentSLA();
            _ProjectTreatmentSLAObj.NumberOfDays = 786;
            _ProjectTreatmentSLAObj.ProjectTreatmentSLAID = 5211;
            _ProjectTreatmentSLAObj.ReferrerProjectTreatmentID = 7652;
            _ProjectTreatmentSLAObj.ServiceLevelAgreementID = 1;

            int _ReferrerProjectTreatmentSLAResult = _projectTreatmentSLA.UpdateProjectTreatmentSLAsByProjectTreatmentSLAID(_ProjectTreatmentSLAObj);
            Assert.IsTrue(_ReferrerProjectTreatmentSLAResult != 0, "Error in updating _ReferrerProjectTreatmentSLAResult !!!");
        }
    }
}
