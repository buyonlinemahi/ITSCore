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
    public class TreatmentCategoriesBespokeServiceTest
    {

        ITreatmentCategoriesBespokeServiceRepository _treatmentCategoriesBespokeServiceRepository;
        public TreatmentCategoriesBespokeServiceTest()
        {
        }

        [TestInitialize()]
        public void TreatmentCategoriesBespokeServiceTestInit()
        {
            _treatmentCategoriesBespokeServiceRepository = new TreatmentCategoriesBespokeServiceRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


      
        [TestMethod]
        public void Get_TreatmentCategoriesBespokeServicesByTreatmentCategoryID()
        {
            ITreatmentCategoriesBespokeService objBL = new TreatmentCategoriesBespokeServiceImpl(_treatmentCategoriesBespokeServiceRepository);
            IEnumerable<TreatmentCategoriesBespokeService> result = objBL.GetTreatmentCategoriesBespokeServicesByTreatmentCategoryID(1);
            Assert.IsTrue(result.Any());
        }


      
    }

}