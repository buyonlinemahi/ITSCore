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
    public class SymptomDescriptionTest
    {
         ISymptomDescriptionRepository _SymptomDescriptionRepository;
         public SymptomDescriptionTest()
        {
        }

        [TestInitialize()]
         public void SymptomDescriptionInit()
        {
            _SymptomDescriptionRepository = new SymptomDescriptionRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetAllSymptomDescription()
        {
            ISymptomDescription SymptomDescription = new SymptomDescriptionImpl(_SymptomDescriptionRepository);
            IEnumerable<SymptomDescription> _SymptomDescriptionResult = SymptomDescription.GetAllSymptomDescription();
            Assert.IsTrue(_SymptomDescriptionResult.Any());
        }
    }
}
