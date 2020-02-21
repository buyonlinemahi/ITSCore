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

    #region Comment
    /* Latest version:1.3
  
  History Revision
  * * Edited By : Vishal
 * Date : 28-Oct-2012
 * Version : 1.1
 * Description : Add Test Method For Add_Reffer
 * Description : Add Test Method For Update_Reffer
 ========================================================
  * Edited By : Vishal
 * Date : 11-08-2012
 * Version : 1.2
 * Description : Add Test Method For referrer name for AutoComplete
 =====================================================================
     * 
 * Edited By : Robin Singh
 * Date : 11-09-2012
 * Version : 1.3
 * Description : Add Test Method For UpdateReferrerAndMainLocation

 */
    #endregion
    [TestClass]
    public class ReferrerRepositoryTest
    {
        Referrer referrerObj = new Referrer();
        IReferrerRepository _referrerRepository;
        IReferrerLocationRepository _referrerLocationRepository;

        public ReferrerRepositoryTest()
        {
        }

        [TestInitialize()]
        public void ReferrerRepositoryInit()
        {
            _referrerRepository = new ReferrerRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _referrerLocationRepository = new ReferrerLocationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void AddReferrer()
        {
            IReferrer ObjBL = new ReferrerImpl(_referrerRepository, _referrerLocationRepository);
            referrerObj.ReferrerName = "Vishal Test Referrer";
            referrerObj.ReferrerContactFirstName = "Test demo FirstName ";
            referrerObj.ReferrerContactLastName = "TestLastname";
            referrerObj.ReferrerMainContactEmail = "test@gmail.com";
            referrerObj.ReferrerMainContactFax = "Test Fax";
            referrerObj.ReferrerMainContactPhone = "Test Phone";
            referrerObj.IsEmploymentDetail = true;
            referrerObj.IsPolicyDetail = false;
            referrerObj.IsEmploeeDetail = false;
            referrerObj.IsDrugandAlcoholTest = true;
            referrerObj.IsRepresentation = true;
            referrerObj.IsAdditionalQuestion = true;
            referrerObj.IsJobDemand = true;

            int referrer = ObjBL.AddReferrer(referrerObj);
            Assert.IsTrue(referrer != 0, "Insert not Successfully");
        }

        [TestMethod]
        public void AddReferrerAndMainLocation()
        {
            referrerObj.ReferrerContactFirstName = "Test1 ";
            referrerObj.ReferrerContactLastName = "TestLastname";
            //referrerObj.ReferrerContactPhone = "123456";
            //  referrerObj.ReferrerCentralEmail = "Test@gmail.com";
            referrerObj.ReferrerName = "TestName";
            //referrerObj.ReferrerContactFax = "123456";
            referrerObj.ReferrerMainContactEmail = "test@gmail.com";
            //  referrerObj.EmailSendingOptionID = 3;
            referrerObj.ReferrerMainContactFax = "Ref and main loc";
            referrerObj.ReferrerMainContactPhone = "Ref and main loc";
            referrerObj.IsPolicyDetailOpenOrDropdowns = "open";
            ReferrerLocation referrerLocation = new ReferrerLocation();
            referrerLocation.ReferrerID = _referrerRepository.AddReferrer(referrerObj);

            referrerLocation.Address = "Address ";
            referrerLocation.Name = "Name";
            referrerLocation.PostCode = "PostCode";
            referrerLocation.City = "City";
            referrerLocation.Region = "Region";
            referrerLocation.IsMainOffice = true;
            

            int referrer = _referrerLocationRepository.AddReferrerLocation(referrerLocation);

            Assert.IsTrue(referrer != 0, "Insert not Successfully");
        }

        [TestMethod]
        public void UpdateReferrer()
        {
            IReferrer ObjBL = new ReferrerImpl(_referrerRepository, _referrerLocationRepository);
            Referrer rr = ObjBL.GetReferrerDetails(585);
            referrerObj.ReferrerID = 585;
            referrerObj.ReferrerName = "Vishal test Update";
            referrerObj.ReferrerContactFirstName = "Upd";
            referrerObj.ReferrerContactLastName = "UpLast Name";
            referrerObj.ReferrerMainContactEmail = "update@gmail.com";
            referrerObj.ReferrerMainContactFax = "upd fax";
            referrerObj.ReferrerMainContactPhone = "up phone";
            referrerObj.IsPolicyDetail = true;
            referrerObj.IsEmploymentDetail = false;
            referrerObj.IsEmploeeDetail = false;
            referrerObj.IsDrugandAlcoholTest = false;
            referrerObj.IsRepresentation = false;
            referrerObj.IsAdditionalQuestion = false;
            referrerObj.IsJobDemand = false;

            int referrer = ObjBL.UpdateReferrer(referrerObj);
            referrerObj = _referrerRepository.GetReferrerDetails(585);
            Assert.AreEqual("Update", referrerObj.ReferrerContactFirstName);
        }
        [TestMethod]
        public void GetReferrerDetailsById()
        {
            Referrer referrer = _referrerRepository.GetReferrerDetails(3);
            Assert.IsTrue(referrer != null, "Unable to get Referrer Details");
        }


        [TestMethod]
        public void ReferrersLikeReferrerName()
        {
            IEnumerable<Referrer> referrer = _referrerRepository.GetReferrersLikeReferrerName("par");
            Assert.IsTrue(referrer.Any());

        }

        [TestMethod]
        public void Get_ReferrerLocationReferrerLikeReferrerName()
        {
            IEnumerable<ReferrerLocationReferrer> referrerLocationReferrer = _referrerRepository.GetReferrerLocationReferrerLikeReferrerName("s", 0, 2);
            Assert.IsTrue(referrerLocationReferrer.Any());

        }

        [TestMethod]
        public void Get_ReferrerLocationReferrerLikeReferrerNameCount()
        {
            int referrerLocationReferrerCount = _referrerRepository.GetReferrerLocationReferrerLikeReferrerNameCount("s");
            Assert.IsTrue(referrerLocationReferrerCount!=0);

        }


        [TestMethod]

        public void UpdateReferrerAndMainLocation()
        {

            referrerObj = _referrerRepository.GetReferrerDetails(388);
            referrerObj.ReferrerContactFirstName = "Anuj";
            referrerObj.ReferrerContactLastName = "Batra";
            referrerObj.ReferrerMainContactEmail = "anuj@gmail.com";
            // referrerObj.EmailSendingOptionID = 3;
            int updaterefererrer = _referrerRepository.UpdateReferrer(referrerObj);

            referrerObj = _referrerRepository.GetReferrerDetails(388);
            Assert.AreEqual(updaterefererrer, 1);
            Assert.AreEqual("Anuj", referrerObj.ReferrerContactFirstName);


            IEnumerable<ReferrerLocation> referrerLocation = _referrerLocationRepository.GetReferrerLocationsByReferrerID(89);

            ReferrerLocation e = new ReferrerLocation();
            using (IEnumerator<ReferrerLocation> enumer = referrerLocation.GetEnumerator())
            {
                if (enumer.MoveNext()) e = enumer.Current;
            }
            e.Name = "Updated 27 feb";

            int referrer = _referrerLocationRepository.UpdateReferrerLocation(e);

            Assert.AreEqual(referrer, 1);
            Assert.AreEqual("Updated", e.Name);

        }


        [TestMethod]
        public void Get_ReferrerExistsByName_BL_Test()
        {
            IReferrer referrerBL = new ReferrerImpl(_referrerRepository, _referrerLocationRepository);
            string referrerName = "harry11";
            bool GetReferrerExistsByName = referrerBL.GetReferrerExistsByName(referrerName);
            Assert.IsTrue(GetReferrerExistsByName, "False!!!");
        }

        [TestMethod]

        public void GetReferrersRecentlyAdded_BL_test()
        {

            IReferrer referrerBL = new ReferrerImpl(_referrerRepository, _referrerLocationRepository);
            IEnumerable<Referrer> Result = referrerBL.GetReferrersRecentlyAdded();
            Assert.IsTrue(Result.Any(), "False!!!");
        }

          [TestMethod]

        public void GetReferrerIDbyReferrerProjectTreatmentID_BL_test()
        {

            IReferrer referrerBL = new ReferrerImpl(_referrerRepository, _referrerLocationRepository);
            int Result = referrerBL.GetReferrerIDbyReferrerProjectTreatmentID(9997);
            //Assert.IsTrue(Result.Any(), "False!!!");
        }

        
    }

}
