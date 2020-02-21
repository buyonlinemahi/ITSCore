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
    public class PrimaryConditionTest
    {
        IPrimaryConditionRepository _IPrimaryConditionRepository; 

        public PrimaryConditionTest()
        {
        }

        [TestInitialize()]
        public void PrimaryConditionInit()
        {
            _IPrimaryConditionRepository = new PrimaryConditionRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetAllPrimaryCondition()
        {
            IPrimaryCondition PrimaryCondition = new PrimaryConditionImpl(_IPrimaryConditionRepository);
            IEnumerable<PrimaryCondition> _primaryResult = PrimaryCondition.GetAllPrimaryCondition();
            Assert.IsTrue(_primaryResult.Any());
        }
    }
}
