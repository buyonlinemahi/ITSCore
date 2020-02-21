using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

#region Comment

/*
 * 
 * Latest Version: 1.1
 History Revision
=============================================================================================
 * Edited By : Satya
 * Date : 09-Nov-2012
 * Version : 1.0
 * Description : Add Test Method For ServiceLevelAgreementTest
 ==========================================================================================
 
 * Edited By : Vishal
 * Date : 10-Nov-2012
 * Version : 1.1
 * Description : Change Method Name Getall to GetAll_ServiceLevelAgreement()
 ==============================================================================================
 */
#endregion

namespace CoreTest
{
    /// <summary>
    /// Summary description for ServiceLevelAgreementTest
    /// </summary>
    /// 

    [TestClass]
    public class ServiceLevelAgreementTest
    {

        IServiceLevelAgreementRepository _serviceLevelAgreementRepository;
        public ServiceLevelAgreementTest()
        {
        }

        [TestInitialize()]
        public void ServiceLevelAgreementTestInit()
        {
            _serviceLevelAgreementRepository = new ServiceLevelAgreementRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void GetAll_ServiceLevelAgreement()
        {
            IEnumerable<ServiceLevelAgreement> serviceLevelAgreementRepository = _serviceLevelAgreementRepository.GetAll();
            Assert.IsTrue(serviceLevelAgreementRepository.Any());

        }

    }
}
