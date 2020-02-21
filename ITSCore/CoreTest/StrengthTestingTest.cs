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
    public class StrengthTestingTest
    {
         IStrengthTestingRepository _StrengthTestingRepository;
        public StrengthTestingTest()
        {
        }

        [TestInitialize()]
        public void StrengthTestingInit()
        {
            _StrengthTestingRepository = new StrengthTestingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetAllStrengthTesting()
        {
            IStrengthTesting StrengthTesting = new StrengthTestingImpl(_StrengthTestingRepository);
            IEnumerable<StrengthTesting> _StrengthTestingAreaResult = StrengthTesting.GetAllStrengthTesting();
            Assert.IsTrue(_StrengthTestingAreaResult.Any());
        }
    }
}
