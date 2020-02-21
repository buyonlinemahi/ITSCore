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
    public class PatientRoleTest
    {

        IPatientRoleRepository _PatientRole;
        public PatientRoleTest()
        {
        }

        [TestInitialize()]
        public void PatientRoleRepositoryTestInit()
        {
            _PatientRole = new PatientRoleRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void Get_AllPatientRole()
        {
            IPatientRole service = new PatientRoleImpl(_PatientRole);
            IEnumerable<PatientRole> PatientRoleRepository = service.GetAllPatientRole();
            Assert.IsTrue(PatientRoleRepository.Any());
        }


      
    }

}