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
    public class AffectedAreaTest
    {
        IAffectedAreaRepository _AffectedAreaRepository;
        public AffectedAreaTest()
        {
        }

        [TestInitialize()]
        public void AffectedAreaInit()
        {
            _AffectedAreaRepository = new AffectedAreaRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetAllAffectedArea()
        {
            IAffectedArea AffectedArea = new AffectedAreaImpl(_AffectedAreaRepository);
            IEnumerable<AffectedArea> _affectedAreaResult = AffectedArea.GetAllAffectedArea();
            Assert.IsTrue(_affectedAreaResult.Any());
        }
        [TestMethod]
        public void Namedescription()
        {
            IAffectedArea AffectedArea = new AffectedAreaImpl(_AffectedAreaRepository);
            var result = AffectedArea.GetAffectedAreaDesciptionByID(2);
            Assert.IsTrue(result.Any());

           
        }
    }
}
