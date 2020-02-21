using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Summary description for DelegatedAuthorisationTest
/// </summary>
/// 
/*
 * 
 * Latest Version :1.0
=========================================================================================
* Created By : Vijay Kumar
* Date : 19-Nov-2012
* Version : 1.0
* Description : Add Test Method For DelegatedAuthorisationTest(GetAssessmentService_Method)
==================================================================================
*/

namespace CoreTest
{
    [TestClass]
    public class DelegatedAuthorisationTest
    {
         IDelegatedAuthorisationRepository _DelegatedAuthorisation;
         public DelegatedAuthorisationTest()
        {
        }

        [TestInitialize()]
         public void DelegatedAuthorisationRepositoryTestInit()
        {
            _DelegatedAuthorisation = new DelegatedAuthorisationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void GetAssessmentService_Method()
        {
            IEnumerable<DelegatedAuthorisation> DelegatedAuthorisationRepository = _DelegatedAuthorisation.GetAll();
            Assert.IsTrue(DelegatedAuthorisationRepository.Any());
        }


    }
}
