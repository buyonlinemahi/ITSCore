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
    public class PatientWorkstatusTest
    {

        IPatientWorkstatusRepository _patientWorkstatusRepository;
        public PatientWorkstatusTest()
        {
        }

        [TestInitialize()]
        public void PatientWorkstatusInit()
        {
            _patientWorkstatusRepository = new PatientWorkstatusRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetAllPatientWorkstatus()
        {
            IPatientWorkstatus patientWorkstatusBL = new PatientWorkstatusImpl(_patientWorkstatusRepository);
            IEnumerable<PatientWorkstatus> _patientWorkstatusResult = patientWorkstatusBL.GetAllPatientWorkstatus();
            Assert.IsTrue(_patientWorkstatusResult.Any());
        }
    }
}
