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
    public class PatientImpactValueTest
    {

        IPatientImpactValueRepository _patientImpactValueRepository;
        public PatientImpactValueTest()
        {
        }

        [TestInitialize()]
        public void PatientImpactValueInit()
        {
            _patientImpactValueRepository = new PatientImpactValueRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetAllPatientImpactValues()
        {
            IPatientImpactValue patientImpactValueBL = new PatientImpactValueImpl(_patientImpactValueRepository);
            IEnumerable<PatientImpactValue> _patientImpactValueResult = patientImpactValueBL.GetAllPatientImpactValues();
            Assert.IsTrue(_patientImpactValueResult.Any());
        }
    }
}
