using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


 /// <summary>
/// Summary description for AssessmentServiceTest
/// </summary>
/// 
/*
 * 
 * Latest Version :1.0
=========================================================================================
* Created By : Vijay Kumar
* Date : 19-Nov-2012
* Version : 1.0
* Description : Add Test Method For AssessmentServiceTest(GetAllAssessmentService_Method)
==================================================================================
*/

namespace CoreTest
{

    [TestClass]
    public class AssessmentServiceTest
    {

        IAssessmentServiceRepository _AssessmentServiceRepository;
        public AssessmentServiceTest()
        {
        }

        [TestInitialize()]
        public void AssessmentServiceRepositoryTestInit()
        {
            _AssessmentServiceRepository = new AssessmentServiceRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetAllAssessmentService_Method()
        {


            IEnumerable<AssessmentService> AssessmentServiceRepository = _AssessmentServiceRepository.GetAll();
            Assert.IsTrue(AssessmentServiceRepository.Any());

        }


      
    }

}