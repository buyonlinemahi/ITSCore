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
    public class InjuredRepresentativeOptionTest
    {
        IInjuredRepresentativeOptionRepository _IInjuredRepresentativeOptionRepository;
        public InjuredRepresentativeOptionTest()
        {
        }

        [TestInitialize()]
        public void ComplaintStatusRepositoryTestInit()
        {
            _IInjuredRepresentativeOptionRepository = new InjuredRepresentativeOptionRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetAllInjuredRepresentativeOption()
        {
            //this Test for BL Layer
            IInjuredRepresentativeOption _IInjuredRepresentativeOption = new InjuredRepresentativeOptionImpl(_IInjuredRepresentativeOptionRepository);
            IEnumerable<InjuredRepresentativeOption> InjuredRepresentativeOptionResult = _IInjuredRepresentativeOption.GetAllInjuredRepresentativeOption();
            Assert.IsTrue(InjuredRepresentativeOptionResult.Any());

        }
    }
}
