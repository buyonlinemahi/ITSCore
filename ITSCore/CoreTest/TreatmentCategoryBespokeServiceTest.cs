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
    public class TreatmentCategoryBespokeServiceTest
    {

        ITreatmentCategoryBespokeServiceRepository _treatmentCategoryBespokeServiceRepository;
        public TreatmentCategoryBespokeServiceTest()
        {
        }

        [TestInitialize()]
        public void TreatmentCategoryBespokeServiceRepositoryTestInit()
        {
            _treatmentCategoryBespokeServiceRepository = new TreatmentCategoryBespokeServiceRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


      
        [TestMethod]
        public void Get_TreatmentCategoryBespokeServicesByTreatmentCategoryID()
        {
            ITreatmentCategoryBespokeService objBL = new TreatmentCategoryBespokeServiceImpl(_treatmentCategoryBespokeServiceRepository);
            IEnumerable<TreatmentCategoryBespokeService> result = objBL.GetTreatmentCategoryBespokeServicesByTreatmentCategoryID(1);
            Assert.IsTrue(result.Any());
        }


      
    }

}