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
    public class SiteAuditTotalCountAndAuditPassTest
    {
        ISiteAuditTotalCountAndAuditPassRepository _siteAuditTotalCountAndAuditPassRepository;

        public SiteAuditTotalCountAndAuditPassTest()
        {

        }

        [TestInitialize()]
        public void SiteAuditTotalCountAndAuditPassRepositoryInit()
        {
            _siteAuditTotalCountAndAuditPassRepository = new SiteAuditTotalCountAndAuditPassRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
           
        }


        [TestMethod]
        public void GetSiteAuditTotalCountAndAuditPassBySupplierID()
        {
            SiteAuditTotalCountAndAuditPass _siteAuditTotalCountAndAuditPass = _siteAuditTotalCountAndAuditPassRepository.GetSiteAuditTotalCountAndAuditPassBySupplierID(359);
            Assert.IsTrue(_siteAuditTotalCountAndAuditPass != null, "unable get siteAuditTotalCountAndAuditPass  By SupplierID ");
        }

        
    }
}
