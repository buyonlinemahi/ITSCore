using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CoreTest
{
    /// <summary>
    /// Summary description for ReferrerRepositoryTest
    /// </summary>
    /// 
    /*
 * Edited By : Satya
 * Date : 07-Nov-2012
 * Version : 1.0
 * Description : Add Test Method For GetAllTreatmentCategory
 */
    [TestClass]
    public class TreatmentCategoryTest
    {
       
        ITreatmentCategoryRepository _treatmentCategoryRepository;
        public TreatmentCategoryTest()
        {
        }

        [TestInitialize()]
        public void TreatmentCategoryRepositoryInit()
        {
            _treatmentCategoryRepository = new TreatmentCategoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void GetAllTreatmentCategory()
        {
            IEnumerable<TreatmentCategory> treatmentCategory = _treatmentCategoryRepository.GetAll();
            Assert.IsTrue(treatmentCategory.Any());
        }

    }
}
