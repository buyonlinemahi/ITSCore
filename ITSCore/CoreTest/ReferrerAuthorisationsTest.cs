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
    /// <summary>
    /// Summary description for ReferrerAuthorisationsTest
    /// </summary>
    [TestClass]
    public class ReferrerAuthorisationsTest
    {
        IReferrerAuthorisationsRepository _referrerAuthorisationsRepository;

        public ReferrerAuthorisationsTest()
        {

        }

        [TestInitialize()]
        public void ReferrerAuthorisationsInit()
        {
            _referrerAuthorisationsRepository = new ReferrerAuthorisationsRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void GetReferrerAuthorisationsByReferrerID()
        {
            IReferrerAuthorisations referrerAuthorisations = new ReferrerAuthorisationsImpl(_referrerAuthorisationsRepository);
            IEnumerable<ReferrerAuthorisations> referrerAuthorisationsResult = referrerAuthorisations.GetReferrerAuthorisationsByReferrerID(540,349, 5, 5).ToList();
            Assert.IsTrue(referrerAuthorisationsResult.Any(), "No authorisations for referrerid input");
        }

        [TestMethod]
        public void GetReferrerAuthorisationCaseCount()
        {
            int count = _referrerAuthorisationsRepository.GetReferrerAuthorisationCountByReferrerID(540,349);
        }
    }
}
