using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
/* Latest Version : 1.0
 * 
 * Author  : Anuj Batra
 * Date    : 07-02-2013
 * Desc    : Test file for TreatmentCategoriesPricingTypes
*/
namespace CoreTest
{
    [TestClass]
    public class TreatmentCategoriesPricingTypesTest
    {
        ITreatmentCategoriesPricingTypesRepository _treatmentCategoriesPricingTypes;

        public TreatmentCategoriesPricingTypesTest()
        {
            _treatmentCategoriesPricingTypes = new TreatmentCategoriesPricingTypesRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

        }
        [TestMethod]
        public void GetPricingTypesByTreatmentCategoryID()
        {
            ITS.Core.BL.ITreatmentCategoriesPricingTypes treatmentCategoriesPricingTypes = new ITS.Core.BL.Implementation.TreatmentCategoriesPricingTypesImpl(_treatmentCategoriesPricingTypes);
            IEnumerable<TreatmentCategoriesPricingTypes> _treatmentCategoryPricingTypesObj = treatmentCategoriesPricingTypes.GetPricingTypesByTreatmentCategoryID(1);
            Assert.IsTrue(_treatmentCategoryPricingTypesObj.Any());
        }
    }
}
