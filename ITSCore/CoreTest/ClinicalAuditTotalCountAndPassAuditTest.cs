using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;



#region Comments

/*
 * Latest Version : 1.0
 * 
 * Author         : Satya
 * Date           : 19-April-2013
 * Version        : 1.0
 * Description    : Added Test Mehtods for SiteAuditTotalCountAndAuditPassTest
 * 
 */

#endregion

namespace CoreTest
{
    [TestClass]
    public class ClinicalAuditTotalCountAndPassAuditTest
    {
        IClinicalAuditTotalCountAndPassAuditRepository _clinicalAuditTotalCountAndPassAuditRepository;

        public ClinicalAuditTotalCountAndPassAuditTest()
        {

        }

        [TestInitialize()]
        public void ClinicalAuditTotalCountAndPassAuditRepositoryInit()
        {
            _clinicalAuditTotalCountAndPassAuditRepository = new ClinicalAuditTotalCountAndPassAuditRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
           
        }

        [TestMethod]
        public void GetSiteAuditTotalCountAndAuditPassBySupplierID()
        {
            ClinicalAuditTotalCountAndPassAudit _clinicalAuditTotalCountAndPassAudit = _clinicalAuditTotalCountAndPassAuditRepository.GetClinicalAuditTotalCountAndPassAuditsBySupplierID(359);
            Assert.IsTrue(_clinicalAuditTotalCountAndPassAudit != null, "unable get clinicalAuditTotalCountAndPassAudit  By SupplierID ");
        }

        
    }
}
