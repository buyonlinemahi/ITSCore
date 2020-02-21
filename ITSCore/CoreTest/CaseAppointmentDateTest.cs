using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CoreTest
{
    [TestClass]
    public class CaseAppointmentDateTest
    {
        private ICaseAppointmentDateRepository _caseAppointmentDatRepository;
                
        [TestInitialize]
        public void Initialize()
        {
            _caseAppointmentDatRepository = new CaseAppointmentDateRepository(
                    new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void Repo_AddingCaseAppointmentDate_Test()
        {
            CaseAppointmentDate caseAppointmentDate = new CaseAppointmentDate()
                {
                    CaseID = 14,
                    AppointmentDateTime=new DateTime(2013,4,29),
                    FirstAppointmentOfferedDate = DateTime.Now
                };

            int ret = _caseAppointmentDatRepository.AddCaseAppointmentDate(caseAppointmentDate);
            Assert.IsTrue(ret > 0);
        }

        [TestMethod]
        public void Repo_UpdateCaseAppointmentDate_Test()
        {
            CaseAppointmentDate caseAppointmentDate = new CaseAppointmentDate()
            {
                CaseID = 111,
                AppointmentDateTime = DateTime.Now,
                FirstAppointmentOfferedDate=null
            };

            int ret = _caseAppointmentDatRepository.UpdateCaseAppointmentDate(caseAppointmentDate);
            Assert.IsTrue(ret > 0);
        }

        [TestMethod]
        public void Repo_RetrievingCaseAppointmentDateByCaseID_Test()
        {
            var ret = _caseAppointmentDatRepository.GetCaseAppointmentDateByCaseID(1182);
            Assert.IsTrue(ret != null, "unable get CaseAppointmentDate By CaseID ");
        }

        [TestMethod]
        public void BL_AddingCaseAppointmentDate_Test()
        {
            CaseAppointmentDate caseAppointmentDate = new CaseAppointmentDate()
            {
                CaseID = 12,
                AppointmentDateTime = new DateTime(2013, 4, 25),
                FirstAppointmentOfferedDate = DateTime.Now
            };
            ICaseAppointmentDate service = new CaseAppointmentDateImpl(_caseAppointmentDatRepository);
            int ret = service.AddCaseAppointmentDate(caseAppointmentDate);
            Assert.IsTrue(ret > 0);
        }

        [TestMethod]
        public void BL_RetrievingCaseAppointmentDateByCaseID_Test()
        {
            ICaseAppointmentDate service = new CaseAppointmentDateImpl(_caseAppointmentDatRepository);
            var ret = service.GetCaseAppointmentDateByCaseID(12);
            Assert.IsTrue(ret != null, "unable get CaseAppointmentDate By CaseID ");
        }
    }
}
