using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreTest
{
    [TestClass]
    public class DrugTestTest
    {
        IDrugTestRepository _drugTestRepository;
        IDrugTest _drugTest;

        IAdditionalTestRepository _additionalTestRepository;
        IAdditionalTest _additionalTest;

        IReasonForReferralRepository _reasonForReferralRepository;
        IReasonForReferral _reasonForReferral;

        INetworkRailStandardApplicableRepository _networkRailStandardApplicableRepository;
        INetworkRailStandardApplicable _networkRailStandardApplicable;

        [TestInitialize()]
        public void SupplierInit()
        {
            var baseContextFactory = new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>();
            _drugTestRepository = new DrugTestRepository(baseContextFactory);
            _drugTest = new DrugTestImpl(_drugTestRepository);

            _additionalTestRepository = new AdditionalTestRepository(baseContextFactory);
            _additionalTest = new AdditionalTestImpl(_additionalTestRepository);

            _reasonForReferralRepository = new  ReasonForReferralRepository(baseContextFactory);
            _reasonForReferral = new ReasonForReferralImpl(_reasonForReferralRepository);

            _networkRailStandardApplicableRepository = new NetworkRailStandardApplicableRepository(baseContextFactory);
            _networkRailStandardApplicable = new NetworkRailStandardApplicableImpl(_networkRailStandardApplicableRepository);
        }

        [TestMethod]
        public void AddDrugTest()
        {
            DrugTest objDrugTest = new DrugTest();            
            objDrugTest.IsDrugAndAlcohalTest = false;
            objDrugTest.NetworkRailStandardApplicableID = 0;
            objDrugTest.ReasonForReferralID = 0;
            objDrugTest.IsSentinalUpdating = true;
            objDrugTest.SentinalNumber = null;
            objDrugTest.AdditionalTestID = 1;
            objDrugTest.AdditionalTestOther = null;

            int res = _drugTest.AddDrugTest(objDrugTest);            
            Assert.IsTrue(res != 0, "Error in inserting _Supplier !!!");
        }

        [TestMethod]
        public void UpdateDrugTest()
        {
            DrugTest objDrugTest = new DrugTest();
            objDrugTest.DrugTestID = 2;
            objDrugTest.IsDrugAndAlcohalTest = true;
            objDrugTest.NetworkRailStandardApplicableID = 1;
            objDrugTest.ReasonForReferralID = 1;
            objDrugTest.IsSentinalUpdating = true;
            objDrugTest.SentinalNumber = "TP2";
            objDrugTest.AdditionalTestID = 1;
            objDrugTest.AdditionalTestOther = null;

            int res = _drugTest.UpdateDrugTest(objDrugTest);            
            Assert.IsTrue(res != 0, "Error in inserting _Supplier !!!");
        }

        [TestMethod]
        public void GetDrugTestByCaseID()
        {
            var res = _drugTest.GetDrugTestByCaseID(51);
            Assert.IsTrue(res != null, "Error");
        }

        [TestMethod]
        public void GetAllAdditionalTest()
        {
            var res = _additionalTest.GetAllAdditionalTest();
            Assert.IsTrue(res != null, "Error");
        }

        [TestMethod]
        public void GetAllReasonForReferralTest()
        {
            var res = _reasonForReferral.GetAllReasonForReferral();
            Assert.IsTrue(res != null, "Error");
        }

        [TestMethod]
        public void GetAllNetworkRailStandardApplicableTest()
        {
            var res = _networkRailStandardApplicable.GetAllNetworkRailStandardApplicable();
            Assert.IsTrue(res != null, "Error");
        }
    }
}
