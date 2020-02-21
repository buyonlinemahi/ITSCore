using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Summary description for AssessmentTypeTest
/// </summary>
/// 
/*
 * 
 * Latest Version :1.0
=========================================================================================
* Created By : Vijay Kumar
* Date : 19-Nov-2012
* Version : 1.0
* Description : Add Test Method For AssessmentTypeTest(GetAssessmentService_Method)
==================================================================================
*/

namespace CoreTest
{
    [TestClass]
   public class AssessmentTypeTest
    {

         IAssessmentTypeRepository _AssessmentTypeRepository;
         public AssessmentTypeTest()
        {
        }

        [TestInitialize()]
         public void AssessmentTypeRepositoryTestInit()
        {
            _AssessmentTypeRepository = new AssessmentTypeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void GetAssessmentService_Method()
        {
            IEnumerable<AssessmentType> AssessmentTypeRepository = _AssessmentTypeRepository.GetAll();
            Assert.IsTrue(AssessmentTypeRepository.Any());
        }
    }
}
