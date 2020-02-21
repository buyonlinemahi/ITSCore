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
    public class CasePatientContactAttemptTest
    {
        private ICasePatientContactAttemptRepository _casePatientContactAttemptRepository;

        [TestInitialize]
        public void Initialize()
        {
            _casePatientContactAttemptRepository = new CasePatientContactAttemptRepository(new
            Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void GetPatientContactAttemptsByCaseID_Test()
        {
            ICasePatientContactAttempt casePatientContactAttempt = new CasePatientContactAttemptImpl(_casePatientContactAttemptRepository);
            var res = casePatientContactAttempt.GetPatientContactAttemptsByCaseID(12);
            Assert.IsTrue(res != null, "unable to get CasePatientContactAttempt");
        }

        [TestMethod]
        public void AddPatientContactAttempt_Test()
        {
            CasePatientContactAttempt casePatientContactAttempt = new CasePatientContactAttempt()
            {
                PatientID = 28,
                CaseID = 12,
                ContactAttemptDate = DateTime.Now
            };

            var res = _casePatientContactAttemptRepository.AddPatientContactAttempt(casePatientContactAttempt);
            Assert.IsTrue(res > 0);

        }

        [TestMethod]
        public void DeletePatientContactAttemptByID()
        {
            ICasePatientContactAttempt casePatientContactAttempt = new CasePatientContactAttemptImpl(_casePatientContactAttemptRepository);
            int _casePatientContactAttempt = casePatientContactAttempt.DeletePatientContactAttempt(1443);
            Assert.IsTrue(_casePatientContactAttempt != 0, "Error in Deleting _Case !!!");
        }
    }
}
