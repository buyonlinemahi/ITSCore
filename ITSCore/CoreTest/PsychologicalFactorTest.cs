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
    public class PsychologicalFactorTest
    {

        IPsychologicalFactorRepository _psychologicalFactorRepository;
        public PsychologicalFactorTest()
        {
        }

        [TestInitialize()]
        public void PsychologicalFactorInit()
        {
            _psychologicalFactorRepository = new PsychologicalFactorRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetAllPsychologicalFactors()
        {
            IPsychologicalFactor psychologicalFactorBL = new PsychologicalFactorImpl(_psychologicalFactorRepository);
            IEnumerable<PsychologicalFactor> _psychologicalFactorResult = psychologicalFactorBL.GetAllPsychologicalFactors();
            Assert.IsTrue(_psychologicalFactorResult.Any());
        }
    }
}
