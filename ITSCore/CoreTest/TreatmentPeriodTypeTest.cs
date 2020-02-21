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
    public class TreatmentPeriodTypeTest
    {
        ITreatmentPeriodTypeRepository _TreatmentPeriodTypeRepository;

        public TreatmentPeriodTypeTest()
        {
        }

        [TestInitialize()]
        public void TreatmentPeriodTypeInit()
        {
            _TreatmentPeriodTypeRepository = new TreatmentPeriodTypeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void Get_AllTreatmentPeriodType()
        {
            ITreatmentPeriodType service = new TreatmentPeriodTypeImpl(_TreatmentPeriodTypeRepository);
            IEnumerable<TreatmentPeriodType> TreatmentPeriodTypeRepository = service.GetTreatmentPeriodTypes();
            Assert.IsTrue(TreatmentPeriodTypeRepository.Any());
        }
    }
}
