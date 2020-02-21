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
    public class RestrictionRangeTest
    {
          IRestrictionRangeRepository _RestrictionRangeRepositor;
          public RestrictionRangeTest()
        {
        }

        [TestInitialize()]
          public void RestrictionRangeInit()
        {
            _RestrictionRangeRepositor = new RestrictionRangeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetAllRestrictionRange()
        {
            IRestrictionRange RestrictionRange = new RestrictionRangeImpl(_RestrictionRangeRepositor);
            IEnumerable<RestrictionRange> _RestrictionRangeResult = RestrictionRange.GetAllRestrictionRange();
            Assert.IsTrue(_RestrictionRangeResult.Any());
        }
    }
}
