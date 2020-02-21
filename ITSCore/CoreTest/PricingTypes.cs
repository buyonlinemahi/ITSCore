using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CoreTest
{

    [TestClass]
    public class PricingTypesTest
    {

        IPricingTypesRepository _pricingTypesRepository;
        public PricingTypesTest()
        {
        }

        [TestInitialize()]
        public void PricingTypesInit()
        {
            _pricingTypesRepository = new PricingTypesRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void GetAllPricingTypes()
        {
            IEnumerable<PricingType> _pricingTypes = _pricingTypesRepository.GetAll();
            Assert.IsTrue(_pricingTypes.Any());
                
        }

    }

}