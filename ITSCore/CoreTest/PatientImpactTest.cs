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
    public class PatientImpactTest
    {

        IPatientImpactRepository _patientImpactRepository;
        public PatientImpactTest()
        {
        }

        [TestInitialize()]
        public void PatientImpactInit()
        {
            _patientImpactRepository = new PatientImpactRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetAllPatientImpacts()
        {
            IPatientImpact patientImpactBL = new PatientImpactImpl(_patientImpactRepository);
            IEnumerable<PatientImpact> _patientImpactResult = patientImpactBL.GetAllPatientImpacts();
            Assert.IsTrue(_patientImpactResult.Any());
        }

    }
}