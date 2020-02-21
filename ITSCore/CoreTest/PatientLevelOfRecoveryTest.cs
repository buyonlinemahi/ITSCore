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
    [TestClass]
   public class PatientLevelOfRecoveryTest
    {

         IPatientLevelOfRecoveryRepository _patientLevelOfRecoveryRepository;
         public PatientLevelOfRecoveryTest()
        {
        }

        [TestInitialize()]
         public void PatientLevelOfRecoveryTestInit()
        {
            _patientLevelOfRecoveryRepository = new PatientLevelOfRecoveryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void Get_AllPatientLevelOfRecovery()
        {
            IPatientLevelOfRecovery _patientLevelOfRecoveryService = new PatientLevelOfRecoveryImpl(_patientLevelOfRecoveryRepository);
            IEnumerable<PatientLevelOfRecovery> patientLevelOfRecoveryService = _patientLevelOfRecoveryService.GetAllPatientLevelOfRecovery();
            Assert.IsTrue(patientLevelOfRecoveryService.Any());
        }
    }
}
