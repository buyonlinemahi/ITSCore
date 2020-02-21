using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
/*

 * Latest Version :1.0
=========================================================================================
* Created By : Vishal
* Date : 12/21/2012
* Version : 1.0
* Description : Add Test Method For RegistrationType to get  GetAllRegistrationType
==================================================================================
*/

namespace CoreTest
{



    [TestClass]
    public class RegistrationTypeTest
    {

        IRegistrationTypeRepository _registrationTypeRepository;
        public RegistrationTypeTest()
        {
        }

        [TestInitialize()]
        public void ComplaintStatusRepositoryTestInit()
        {
            _registrationTypeRepository = new RegistrationTypeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetAllRegistrationType()
        {
            //this Test for BL Layer
            IRegistrationType _registrationType = new RegistrationTypeImpl(_registrationTypeRepository);
            IEnumerable<RegistrationType> RegistrationTypeResult = _registrationType.GetAllRegistrationType();
            Assert.IsTrue(RegistrationTypeResult.Any());

        }



    }
}
