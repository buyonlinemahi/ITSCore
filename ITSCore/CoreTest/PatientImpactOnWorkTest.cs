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
   public class PatientImpactOnWorkTest
    {

        IPatientImpactOnWorkRepository _patientImpactOnWorkRepository;
        public PatientImpactOnWorkTest()
        {
        }

        [TestInitialize()]
        public void PatientImpactOnWorkTestTestInit()
        {
            _patientImpactOnWorkRepository = new PatientImpactOnWorkRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void Get_AllPatientImpactOnWork()
        {
            IPatientImpactOnWork _patientImpactOnWorkService = new PatientImpactOnWorkImpl(_patientImpactOnWorkRepository);
            IEnumerable<PatientImpactOnWork> patientImpactOnWorkService = _patientImpactOnWorkService.GetAllPatientImpactOnWork();
            Assert.IsTrue(patientImpactOnWorkService.Any());
        }
    }
}
