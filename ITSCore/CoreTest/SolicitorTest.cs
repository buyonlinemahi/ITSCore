using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
Latest Version:1.0
 * Author : Vishal
 * Date : 12/15/2012
 * Task : #279
 * Description : Add Test Method For Solicitor

 */

namespace CoreTest
{
    [TestClass]
    public class SolicitorTest
    {
        private ISolicitorRepository _SolicitorRepository;
        private ISolicitor _BL;

        public SolicitorTest()
        {
        }

        [TestInitialize()]
        public void SolicitorRepositoryTestInit()
        {
            _SolicitorRepository = new SolicitorRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _BL = new SolicitorImpl(_SolicitorRepository);
        }

        [TestMethod]
        public void AddSolicitor()
        {
            Solicitor _SolicitorObj = new Solicitor();
            _SolicitorObj.CompanyName = "dsfds";
            _SolicitorObj.Address = null;
            _SolicitorObj.Phone = null;
            _SolicitorObj.Email = null;
            _SolicitorObj.FirstName = "test";
            _SolicitorObj.LastName = "test";
            _SolicitorObj.PostCode = null;
            _SolicitorObj.Fax = null;
            _SolicitorObj.ReferenceNumber = null;
            _SolicitorObj.City = null;
            _SolicitorObj.Region = null;
            _SolicitorObj.IsReferralUnderJointInstruction = true;
            int _SolicitorResult = _SolicitorRepository.AddSolicitor(_SolicitorObj);
            Assert.IsTrue(_SolicitorResult != 0, "Error in inserting Solicitor !!!");
        }

        [TestMethod]
        public void UpdateSolicitorBySolicitorID()
        {
            Solicitor _SolicitorObj = new Solicitor();
            _SolicitorObj.SolicitorID = 176;
            _SolicitorObj.CompanyName = null;
            _SolicitorObj.Address = "Jaipur";
            _SolicitorObj.Phone = "98745612";
            _SolicitorObj.Email = "Raj@gmial.com";
            _SolicitorObj.FirstName = "Rajendra";
            _SolicitorObj.LastName = "Sharma";
            _SolicitorObj.PostCode = "302145";
            _SolicitorObj.Fax = "142145454";
            _SolicitorObj.ReferenceNumber = "445454";
            _SolicitorObj.City = "City1";
            _SolicitorObj.Region = "Region2";
            _SolicitorObj.IsReferralUnderJointInstruction = false;
            int _SolicitorResult = _BL.UpdateSolicitorBySolicitorID(_SolicitorObj);
            Assert.IsTrue(_SolicitorResult != 0, "Error in inserting Solicitor !!!");
        }

        [TestMethod]
        public void GetSolicitorBySolicitorID()
        {
            var _SolicitorResult = _BL.GetSolicitorBySolicitorID(25);
            Assert.IsTrue(_SolicitorResult != null, "Error in Get Solicitor !!!");
        }

        [TestMethod]
        public void GetSolicitorByPatientID()
        {
            var _SolicitorResult = _BL.GetSolicitorByPatientID(35);
            Assert.IsTrue(_SolicitorResult != null, "Error in Get Solicitor !!!");
        }
    }
}